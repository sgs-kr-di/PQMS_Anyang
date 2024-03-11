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
    public partial class frmGroupMemberMaster_org : Form
    {
        public frmGroupMemberMaster_org()
        {
            InitializeComponent();

            objectEnable(false);

            cmbSetting("appMaster",     "appNo",     "appId",      "",     "", cmbAppId, "N");

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
                query = " select " + tField1 + "," + tField2 + " from " + tTable + " with(nolock)";
                query += " order by " + tField1;
            }
            else
            {
                query = " select " + tField1 + "," + tField2 + " from " + tTable + " with(nolock)";
                query += " where " + tField3 + " = '" + tField4 + "'";
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

        private void cmbLoginIdSetting(string tField1, string tField2, ComboBox tCmb, string splitter, string newAcoount)
        {

            Conn = new OleDbConnection(connect_string);

            string query = "";

            if (newAcoount.Equals("ins"))
            {
                //모든 그룹에 미등록된 사람 찾기
                query = " select t4.accountno, t4.loginid               ";
                query += " from groupmaster as t1 with(nolock)           ";
                query += " left join groupmembermaster as t2 with(nolock)";
                query += " on  t1.groupNo = t2.groupNo                   ";
                //query += " and t1.groupNo = '" + tField2 + "' ";
                query += " and t1.Disuse = 0       ";
                query += " and t2.Disuse = 0       ";
                query += " right join accountMaster as t4 with(nolock)   ";
                query += " on  t2.accountno = t4.accountno                ";
                query += " and t4.Disuse = 0       ";
                query += " where t1.groupNo is null                      ";
                query += "   and t4.appID = '" + tField1 + "'";
                query += " order by t4.loginid ";
            }
            else if (newAcoount.Equals("upd"))
            {
                //선택한 그룹의 등록된 사람 찾기
                query = " select t4.accountno, t4.loginid               ";
                query += " from groupmaster as t1 with(nolock)           ";
                query += " left join groupmembermaster as t2 with(nolock)";
                query += " on  t1.groupNo = t2.groupNo                   ";
                query += " and t1.groupNo = '" + tField2 + "' ";
                query += " and t1.Disuse = 0       ";
                query += " and t2.Disuse = 0       ";
                query += " inner join accountMaster as t4 with(nolock)   ";
                query += " on t2.accountno = t4.accountno                ";
                query += " and t4.Disuse = 0       ";
                query += " where                                         ";
                query += " t4.appID = '" + tField1 + "'";
                query += " order by t4.loginid ";
            }

            else if (newAcoount.Equals("sel"))
            {

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
                    if(!(ControlClear as ComboBox).Name.Equals("cmbAppId"))
                        (ControlClear as ComboBox).Text = "";
                }
                
            }
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            objectEnable(true);
            objectClear();

            chkDisuse.Enabled = false;

            mode = "insert";
            lblMode.Text = mode;

            btnUpd.Enabled = false;
            btnSave.Enabled = true;
        }

        private void cmbGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {

            //txtSelectedGroupNo.Text = "";
            txtSelectedAccountNo.Text = "";

            if (!cmbGroupName.Text.Equals(""))
            {

                int idx = cmbGroupName.Text.IndexOf(" :: ");
                txtSelectedGroupNo.Text = cmbGroupName.Text.Substring(0, idx);

                if (mode.Equals("insert"))
                    cmbLoginIdSetting(cmbAppId.Text, txtSelectedGroupNo.Text, cmbLoginId, "Y", "ins");
                else if (mode.Equals("update"))
                    cmbLoginIdSetting(cmbAppId.Text, txtSelectedGroupNo.Text, cmbLoginId, "Y", "upd");
                
                //else if (mode.Equals("select"))
                  //  cmbLoginIdSetting(cmbAppId.Text, txtSelectedGroupNo.Text, cmbLoginId, "Y", "sel");
            }
        }

        private void cmbAppId_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSetting("groupMaster", "groupNo", "groupName", "appId", cmbAppId.Text, cmbGroupName, "Y");            
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            if (!mode.Equals("select"))
            {
                objectEnable(true);
                objectClear();

                cmbAppId.Enabled = true;
                cmbLoginId.Enabled = false;


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
                    MessageBox.Show("Group 을 선택 하세요!");
                    return;
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
                query += " and t1.disuse = 0                       ";
                query += " and t2.Disuse = '" + Convert.ToInt32(chkDisuse.Checked) + "'";
                query += " left join accountmaster as t3 with(nolock)         ";
                query += " on  t2.accountNo = t3.accountNo                         ";
                query += " and t3.disuse = 0                         "; 
                query += " inner join deptMaster as t4 with(nolock)       ";
                query += " on  t1.deptno = t4.deptNo                   ";
                query += " and t4.disuse = 0                         ";
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

                query += " group by t2.groupNo, t1.groupname, t1.appid,     t1.rolecode, t1.roletype, ";
                query += " t1.deptno,  t4.deptName,  t3.accountNo, t3.loginid,  t2.disuse ";
                query += " order by t1.appID, t1.groupName, t4.deptName, t1.roleType, t3.loginid ";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();

                dgvGroupMaster.RowCount = 1000;

                int i;
                int wRowNo = 0;

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        dgvGroupMaster.ColumnCount = reader.FieldCount + 1;

                        for (i = 1; i < reader.FieldCount + 1; i++)
                        {
                            dgvGroupMaster.Columns[i].HeaderText = reader.GetName(i - 1).ToString();
                            if (i == 1)
                            {
                                //dgvUserRequestStatus.Columns[i].Width = 40;
                                //dgvUserRequestStatus.Columns[i].Visible = false;

                                dgvGroupMaster.Columns[i].Width = 100;
                                dgvGroupMaster.Columns[i].Visible = true;
                            }
                            else
                            {
                                if (i == 2)
                                {
                                    dgvGroupMaster.Columns[i].Width = 150;
                                }
                                else
                                {
                                    dgvGroupMaster.Columns[i].Width = 200;
                                }
                            }
                        }

                        while (reader.Read())
                        {
                            dgvGroupMaster.Rows[wRowNo].Cells[0].Value = false;
                            for (i = 0; i < reader.FieldCount; i++)
                            {
                                dgvGroupMaster.Rows[wRowNo].Cells[i + 1].Value = reader.GetValue(i);
                            }
                            wRowNo = wRowNo + 1;
                            dgvGroupMaster.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();

                        }
                    }
                }
                if (wRowNo > 0)
                {
                    dgvGroupMaster.RowCount = wRowNo + 1;
                }
                else
                {
                    dgvGroupMaster.RowCount = 1;
                }

                Conn.Close();

                //objectEnable(false);
            }
        }

        private void cmbLoginId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbLoginId.Text.Equals(""))
            {
                int idx = cmbLoginId.Text.IndexOf(" :: ");
                txtSelectedAccountNo.Text = cmbLoginId.Text.Substring(0, idx);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode.Equals("insert"))
            {
                string dupChk = "";
                Conn = new OleDbConnection(connect_string);

                string query = " select groupNo " +
                             "     from groupMemberMaster with(nolock) " +
                             "    where groupNo = '" + txtSelectedGroupNo.Text.Trim() + "' " +
                             "      and accountNo = '" + txtSelectedAccountNo.Text.Trim() + "' " +
                             "      and disuse = 0";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            dupChk = "nok";
                            MessageBox.Show("아이디 중복!");
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
                    
                if(txtSelectedMemberNo.Text.Equals(""))
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

        private void btnUpd_Click(object sender, EventArgs e)
        {
            if(chkDisuse.Checked)
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

        private void dgvGroupMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvGroupMaster.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() != null)
                {

                     objectEnable(false);
                    //cmbLoginId.Enabled = true;
                    cmbLoginId.Items.Clear();

                    txtSelectedMemberNo.Text = dgvGroupMaster.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();

                    cmbAppId.SelectedIndex = cmbAppId.Items.IndexOf(dgvGroupMaster.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                    cmbGroupName.SelectedIndex = cmbGroupName.Items.IndexOf(dgvGroupMaster.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() + " :: " + dgvGroupMaster.Rows[e.RowIndex].Cells[4].Value.ToString().Trim());
                    //cmbLoginId.SelectedIndex = cmbLoginId.Items.IndexOf(dgvGroupMaster.Rows[e.RowIndex].Cells[9].Value.ToString().Trim() + " :: " + dgvGroupMaster.Rows[e.RowIndex].Cells[10].Value.ToString().Trim());

                    cmbLoginId.Items.Add(dgvGroupMaster.Rows[e.RowIndex].Cells[9].Value.ToString().Trim() + " :: " + dgvGroupMaster.Rows[e.RowIndex].Cells[10].Value.ToString().Trim());
                    cmbLoginId.SelectedIndex = cmbLoginId.Items.IndexOf(dgvGroupMaster.Rows[e.RowIndex].Cells[9].Value.ToString().Trim() + " :: " + dgvGroupMaster.Rows[e.RowIndex].Cells[10].Value.ToString().Trim());

                    chkDisuse.Checked = Convert.ToBoolean(dgvGroupMaster.Rows[e.RowIndex].Cells[11].Value.ToString());

                    btnUpd.Enabled = true;
                    btnSave.Enabled = false;

                    mode = "";
                    lblMode.Text = "MODE";
                }
            }
            catch (Exception exp)
            {
                return;
            }
        }
    }
}
