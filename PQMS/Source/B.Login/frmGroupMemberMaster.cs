using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace userManagement
{
    public partial class frmGroupMemberMaster : Form
    {
        public frmGroupMemberMaster()
        {
            InitializeComponent();

            objectEnable(false);

            cmbSetting("appMaster", "appNo", "appId", "", "", cmbAppId, "N");
            cmbSetting("codeMaster", "code", "codename", "codecategory", "roleType", cmbGroupType, "N");

            btnUpd.Enabled = false;
            btnSave.Enabled = false;
        }

        private OleDbConnection Conn;

        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";

        private string nM1;
        private string nM2;
        private string nM3;
        private string nM4;

        public string loginId
        {
            get { return nM1; }
            set { nM1 = value; }
        }

        public string userId
        {
            get { return nM2; }
            set { nM2 = value; }
        }

        public string appId
        {
            get { return nM3; }
            set { nM3 = value; }
        }

        public string accountNo
        {
            get { return nM4; }
            set { nM4 = value; }
        }

        String mode = "";

        private void objectEnable(Boolean trueFalse)
        {
            foreach (Control ControlClear in this.Controls)
            {
                if (typeof(TextBox) == ControlClear.GetType())
                {
                    if (!(ControlClear as TextBox).Name.Equals("txtSelectedAccountNo") && !(ControlClear as TextBox).Name.Equals("txtSelectedGroupNo") && !(ControlClear as TextBox).Name.Equals("txtSelectedMemberNo"))
                            (ControlClear as TextBox).Enabled = trueFalse;
                }
                if (typeof(CheckBox) == ControlClear.GetType())
                {
                    (ControlClear as CheckBox).Enabled = trueFalse;
                }
                if (typeof(ComboBox) == ControlClear.GetType())
                {
                    (ControlClear as ComboBox).Enabled = trueFalse;
                }
            }
        }

        private void cmbSetting(string tTable, string tField1, string tField2, string tField3, string tField4, ComboBox tCmb, string splitter)
        {

            Conn = new OleDbConnection(connect_string);

            string query = "";

            if (tField3 == "")
            {
                query  = " select " + tField1 + "," + tField2 + " from " + tTable + " with(nolock)";
                query += " where disuse = 0";
                query += " order by " + tField1;
            }
            else
            {
                query = " select " + tField1 + "," + tField2 + " from " + tTable + " with(nolock)";
                query += " where " + tField3 + " = '" + tField4 + "'";
                query += "   and disuse = 0";
                query += " order by " + tField3 + "," + tField1;
            }


            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    tCmb.Items.Clear();

                    tCmb.Items.Add("");

                    while (reader.Read())
                    {
                        if (splitter.Equals("Y"))
                            tCmb.Items.Add(reader.GetValue(0).ToString() + " :: " + reader.GetValue(1).ToString());
                        else
                            tCmb.Items.Add(reader.GetValue(1).ToString());
                    }

                    tCmb.SelectedIndex = 0;
                }
            }

            Conn.Close();
        }

        private void objectClear()
        {
            foreach (Control ControlClear in this.Controls)
            {
                if (typeof(TextBox) == ControlClear.GetType())
                {
                    if (!(ControlClear as TextBox).Name.Equals("") && !(ControlClear as TextBox).Name.Equals(""))
                        (ControlClear as TextBox).Text = "";
                }
                if (typeof(CheckBox) == ControlClear.GetType())
                {
                    (ControlClear as CheckBox).Checked = false;
                }

                if (typeof(ComboBox) == ControlClear.GetType())
                {
                    if (!((ControlClear as ComboBox).Name.Equals("cmbAppId") || (ControlClear as ComboBox).Name.Equals("cmbGroupType")))
                    {
                        (ControlClear as ComboBox).Items.Clear();
                        (ControlClear as ComboBox).Text = "";
                    }
                    
                }

            }
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            if (!mode.Equals("select"))
            {
                objectEnable(true);
                objectClear();

                cmbAppId.SelectedIndex = 0;

                btnUpd.Enabled = false;
                btnSave.Enabled = false;

                mode = "select";
                lblMode.Text = mode;
            }

            else if (mode.Equals("select"))
            {
                if (cmbAppId.Text.Trim().Equals(""))
                {
                    MessageBox.Show("APP 을 선택 하세요!");
                    return;
                }

                if (cmbGroupName.Text.Trim().Equals(""))
                {
                    //MessageBox.Show("Group 을 선택 하세요!");
                    //return;
                }

                mode = "";
                lblMode.Text = "MODE";

                Conn = new OleDbConnection(connect_string);

                ////dgvUserRequestStatus.Rows.Clear();

                string query = "";

                query = " select max(t2.groupMemberNo) as groupMemberNo,    ";
                query += "       t1.appid,  t2.groupNo,  t1.groupname, t1.rolecode, t1.roletype,  ";
                query += "       t1.deptno, t4.deptName, t3.accountNo, t3.loginid,  t2.disuse  ";
                query += " from groupmaster as t1 with(nolock)              ";
                query += " left join groupmembermaster as t2 with(nolock)   ";
                query += " on  t1.groupNo = t2.groupNo                       ";
                query += " and t2.Disuse = '" + Convert.ToInt32(chkDisuse.Checked) + "'";
                query += " inner join accountmaster as t3 with(nolock)         ";
                query += " on  t2.accountNo = t3.accountNo                         ";
                query += " inner join deptMaster as t4 with(nolock)       ";
                query += " on  t1.deptno = t4.deptNo                   ";
                query += " where 1=1 ";
                if (!cmbAppId.Text.Trim().Equals(""))
                {
                    query += " and t1.AppId = '" + cmbAppId.Text.Trim() + "'";
                }

                if (!cmbGroupName.Text.Trim().Equals(""))
                {
                    query += " and t1.groupNo = '" + txtSelectedGroupNo.Text.Trim() + "'";
                }

                if (!cmbLoginId.Text.Trim().Equals(""))
                {
                    query += " and t3.accountNo = '" + txtSelectedAccountNo.Text.Trim() + "'";
                }
                query += " and t1.disuse = 0                       ";
                query += " and t3.disuse = 0                         ";
                query += " and t4.disuse = 0                         ";


                query += " group by t2.groupNo, t1.groupname, t1.appid,     t1.rolecode, t1.roletype, ";
                query += " t1.deptno,  t4.deptName,  t3.accountNo, t3.loginid,  t2.disuse ";
                query += " order by t1.appID, t1.groupName, t4.deptName, t1.roleType, t3.loginid ";

                    OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();

                dgvGroupMemberMaster.RowCount = 1000;

                int i;
                int wRowNo = 0;

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        dgvGroupMemberMaster.ColumnCount = reader.FieldCount + 1;

                        for (i = 1; i < reader.FieldCount + 1; i++)
                        {
                            dgvGroupMemberMaster.Columns[i].HeaderText = reader.GetName(i - 1).ToString();
                            if (i == 1)
                            {
                                //dgvUserRequestStatus.Columns[i].Width = 40;
                                //dgvUserRequestStatus.Columns[i].Visible = false;

                                dgvGroupMemberMaster.Columns[i].Width = 100;
                                dgvGroupMemberMaster.Columns[i].Visible = true;
                            }
                            else
                            {
                                if (i == 2)
                                {
                                    dgvGroupMemberMaster.Columns[i].Width = 100;
                                }
                                else
                                {
                                    dgvGroupMemberMaster.Columns[i].Width = 100;
                                }
                            }
                        }

                        while (reader.Read())
                        {
                            dgvGroupMemberMaster.Rows[wRowNo].Cells[0].Value = false;
                            for (i = 0; i < reader.FieldCount; i++)
                            {
                                dgvGroupMemberMaster.Rows[wRowNo].Cells[i + 1].Value = reader.GetValue(i);
                            }
                            wRowNo = wRowNo + 1;
                            dgvGroupMemberMaster.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();
                        }
                    }
                }
                if (wRowNo > 0)
                {
                    dgvGroupMemberMaster.RowCount = wRowNo + 1;
                }
                else
                {
                    dgvGroupMemberMaster.RowCount = 1;
                }

                Conn.Close();

                objectEnable(false);
            }
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            objectEnable(true);
            objectClear();

            cmbAppId.SelectedIndex = 0;

            chkDisuse.Enabled = false;

            mode = "insert";
            lblMode.Text = mode;

            btnUpd.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            if (!mode.Equals("update") && chkDisuse.Checked)
            {
                MessageBox.Show("disuse 처리한 건은 수정 할 수 없습니다. 신규로 등록 하세요!");
                return;
            }

            objectEnable(false);

            chkDisuse.Enabled = true;

            mode = "update";
            lblMode.Text = mode;

            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode.Equals("insert"))
            {

                if (txtSelectedAccountNo.Text.Equals(""))
                {
                    MessageBox.Show("사용자를 선택해 주세요!");
                    return;
                }

                if (txtSelectedGroupNo.Text.Equals(""))
                {
                    MessageBox.Show("그룹을 선택해 주세요!");
                    return;
                }                



                string dupChk = "";
                Conn = new OleDbConnection(connect_string);

                string query = " select t1.groupMemberNo " +
                             "     from groupMemberMaster as t1 with(nolock) " +
                             "     inner join groupmaster as t2 with(nolock) " +
                             "     on  t1.groupNo = t2.groupNo " +
                             "     and t2.roleType = '" + cmbGroupType.Text + "' " +
                             "    where accountNo = '" + txtSelectedAccountNo.Text.Trim() + "' " +
                             "      and t1.disuse = 0";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            if (cmbGroupType.Text.Equals("menu"))
                            {
                                dupChk = "nok";
                                MessageBox.Show("해당 계정은 이미 메뉴 그룹에 등록된 이력이 있습니다. \n하나의 계정은 하나의 메뉴 그룹에만 등록 가능 합니다. ");
                                return;
                                
                            }
                        }
                    }
                    else
                    {
                        dupChk = "ok";
                    }
                }

                Conn.Close();

                if (dupChk == "ok")
                {
                    String disuseChecker = "";
                    String disuseDate = "''";

                    if (chkDisuse.Checked)
                    {
                        disuseChecker = accountNo;
                        disuseDate = "getdate()";
                    }

                    query =
                        " insert into groupMemberMaster     " +
                        "  (groupNo        ,  " +
                        " 	accountNo      ,  " +
                        " 	registeredBy  ,  " +
                        " 	registeredDate,  " +
                        " 	modifiedBy    ,  " +
                        " 	ModifiedDate,     " +
                        "   Disuse                 , " +
                        "   DisusedBy              , " +
                        "   DisusedDate              " +
                        " )                           " +
                        " Values                      " +
                        " (                           " +
                        " '" + txtSelectedGroupNo.Text + "',   " +
                        " '" + txtSelectedAccountNo.Text + "',   " +
                        " '" + accountNo + "', " +
                        " getdate(), " +
                        " '', " +
                        " '', " +
                        " '" + Convert.ToInt32(chkDisuse.Checked) + "', " +
                        " '" + disuseChecker + "', " +
                        disuseDate +
                        " )";

                    cmd = new OleDbCommand(query, Conn);

                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();

                    MessageBox.Show("등록 완료!");

                    objectClear();

                    mode = "";
                    lblMode.Text = "MODE";

                    chkDisuse.Enabled = true;

                    btnUpd.Enabled = false;
                    btnSave.Enabled = false;
                }
            }

            if (mode.Equals("update"))
            {

                if (txtSelectedMemberNo.Text.Equals(""))
                {
                    MessageBox.Show("수정 할 수 없는 건 입니다.");
                    return;
                }

                mode = "";
                lblMode.Text = "MODE";

                string query = "";
                Conn = new OleDbConnection(connect_string);

                String disuseChecker = "";
                String disuseDate = "''";

                if (chkDisuse.Checked)
                {
                    disuseChecker = accountNo;
                    disuseDate = "getdate()";
                }

                query =
                    " update groupMemberMaster  " +
                    " set                " +
                    //                        " 	groupNo      = '" + txtSelectedGroupNo.Text + "',  " +
                    //                        "   accountNo          = '" + txtSelectedAccountNo.Text + "',  " +

                    " 	modifiedBy     = '" + accountNo + "',  " +
                    "   ModifiedDate   = getdate(), " +
                    "   Disuse         = '" + Convert.ToInt32(chkDisuse.Checked) + "', " +
                    "   DisusedBy      = '" + disuseChecker + "', " +
                    "   DisusedDate    = " + disuseDate +
                    " where                      " +
                    "   groupMemberNo    = '" + txtSelectedMemberNo.Text + "'";



                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();
                cmd.ExecuteNonQuery();
                Conn.Close();

                MessageBox.Show("수정 완료!");

                objectEnable(false);
                objectClear();

                mode = "";
                lblMode.Text = "MODE";

                btnUpd.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void cmbAppId_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSetting("accountMaster", "accountNo", "loginId", "appId", cmbAppId.Text, cmbLoginId, "Y");
        }


        private void cmbGroupNameSetting(string tField1, string tField2, string tField3, ComboBox tCmb, string splitter, string newAcoount)
        {

            Conn = new OleDbConnection(connect_string);

            string query = "";

            if (newAcoount.Equals("ins"))
            {
                //모든 그룹에 미등록된 사람 찾기
                query = " select t3.groupNo, t3.groupName, t1.appID       ";
                query += " from accountMaster as t1 with(nolock)           ";
                query += " right join groupMemberMaster as t2 with(nolock) ";
                query += " on t1.accountNo = t2.accountNo                  ";
                query += " and t1.accountNo = " + tField2 + "              ";
                query += " and t1.Disuse = 0                               ";
                query += " and t2.Disuse = 0                               ";
                query += " right join groupmaster as t3 with(nolock)        ";
                query += " on t2.groupNo = t3.groupNo                      ";                
                query += " and t2.Disuse = 0                               ";
                query += " and t3.Disuse = 0                               ";
                query += " where t1.accountNo is null                      ";
                query += "   and t3.appID = '" + tField1 + "'              ";
                query += "   and t3.roleType = '" + tField3 + "'           ";
            }
            else if (newAcoount.Equals("updSel"))
            {
                //선택한 사람이 등록된 그룹 찾기
                query  = " select t2.groupNo, t3.groupName                 ";
                query += " from accountMaster as t1 with(nolock)           ";
                query += " inner join groupMemberMaster as t2 with(nolock) ";
                query += " on t1.accountNo = t2.accountNo                  ";
                query += " and t1.accountNo = " + tField2 + "              ";
                query += " and t1.Disuse = 0                               ";
                query += " and t2.Disuse = 0                               ";
                query += " inner join groupmaster as t3 with(nolock)       ";
                query += " on t2.groupNo = t3.groupNo                      ";
                query += " and t2.Disuse = 0                               ";
                query += " and t3.Disuse = 0                               ";
                query += " where t1.appID = '" + tField1 + "'              ";
                query += "   and t3.roleType = '" + tField3 + "'           ";
            }


            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                tCmb.Items.Clear();

                if (reader.HasRows == true)
                {
                    tCmb.Items.Add("");

                    while (reader.Read())
                    {
                        if (splitter.Equals("Y"))
                            tCmb.Items.Add(reader.GetValue(0).ToString() + " :: " + reader.GetValue(1).ToString());
                        else
                            tCmb.Items.Add(reader.GetValue(1).ToString());
                    }

                    tCmb.SelectedIndex = 0;
                }
            }

            Conn.Close();

        }

        private void cmbLoginId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbLoginId.Text.Equals(""))
            {
                ////cmbGroupType.SelectedIndex = 0;

                txtSelectedGroupNo.Text = "";            
                cmbGroupName.Items.Clear();

            
                int idx = cmbLoginId.Text.IndexOf(" :: ");
                txtSelectedAccountNo.Text = cmbLoginId.Text.Substring(0, idx);

                //MessageBox.Show("111");

                if (!cmbGroupType.Text.Equals(""))
                {
                    if (mode.Equals("insert"))
                    {
                        //MessageBox.Show("222");
                        cmbGroupNameSetting(cmbAppId.Text, txtSelectedAccountNo.Text, cmbGroupType.Text, cmbGroupName, "Y", "ins");
                    }
                    else if (mode.Equals("update") || mode.Equals("select") || mode.Equals(""))
                    {
                        //MessageBox.Show("333");
                        cmbGroupNameSetting(cmbAppId.Text, txtSelectedAccountNo.Text, cmbGroupType.Text, cmbGroupName, "Y", "updSel");
                    }
                }
            }

        }

        private void cmbGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSelectedGroupNo.Text = "";
            cmbGroupName.Items.Clear();
        }

        private void cmbGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbGroupName.Text.Equals(""))
            {
                int idx = cmbGroupName.Text.IndexOf(" :: ");
                txtSelectedGroupNo.Text = cmbGroupName.Text.Substring(0, idx);
            }
        }

        private void dgvGroupMemberMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvGroupMemberMaster.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() != null)
                {
                    mode = "";
                    lblMode.Text = "MODE";

                    ////objectEnable(false);
                    //cmbLoginId.Enabled = true;
                    cmbLoginId.Items.Clear();

                    txtSelectedMemberNo.Text = dgvGroupMemberMaster.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                    txtSelectedGroupNo.Text = dgvGroupMemberMaster.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();

                    cmbAppId.SelectedIndex = cmbAppId.Items.IndexOf(dgvGroupMemberMaster.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                    cmbLoginId.Items.Add(dgvGroupMemberMaster.Rows[e.RowIndex].Cells[9].Value.ToString().Trim() + " :: " + dgvGroupMemberMaster.Rows[e.RowIndex].Cells[10].Value.ToString().Trim());
                    cmbLoginId.SelectedIndex = cmbLoginId.Items.IndexOf(dgvGroupMemberMaster.Rows[e.RowIndex].Cells[9].Value.ToString().Trim() + " :: " + dgvGroupMemberMaster.Rows[e.RowIndex].Cells[10].Value.ToString().Trim());

                    cmbGroupType.SelectedIndex = cmbGroupType.Items.IndexOf(dgvGroupMemberMaster.Rows[e.RowIndex].Cells[6].Value.ToString().Trim());
                   
                    chkDisuse.Checked = Convert.ToBoolean(dgvGroupMemberMaster.Rows[e.RowIndex].Cells[11].Value.ToString());

                    cmbGroupName.SelectedIndex = cmbGroupName.Items.IndexOf(dgvGroupMemberMaster.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() + " :: " + dgvGroupMemberMaster.Rows[e.RowIndex].Cells[4].Value.ToString().Trim());

                    btnUpd.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
            catch (Exception exp)
            {
                return;
            }
        }
    }
}
    
