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
    public partial class frmGroupMaster : Form
    {
        public frmGroupMaster()
        {
            InitializeComponent();

            objectEnable(false);

            cmbSetting("appMaster", "appNo", "appId", "", "", cmbAppId, "N");
            cmbSetting("deptMaster", "deptNo", "deptName", "", "", cmbDeptName, "Y");

            cmbSetting("codeMaster", "code", "codename", "codecategory", "roleType", cmbRoleType, "N");

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
                    if (!(ControlClear as TextBox).Name.Equals("txtSelectedDeptNo") && !(ControlClear as TextBox).Name.Equals("txtSelectedAppNo"))
                        (ControlClear as TextBox).Text = "";
                }
                if (typeof(CheckBox) == ControlClear.GetType())
                {
                    (ControlClear as CheckBox).Text = "";
                }
                /*
                if (typeof(ComboBox) == ControlTextBoxClear.GetType())
                {
                    (ControlTextBoxClear as ComboBox).Text = "";
                }
                */
            }
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            objectEnable(true);
            objectClear();

            mode = "insert";
            lblMode.Text = mode;

            btnUpd.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            objectEnable(true);

            mode = "update";
            lblMode.Text = mode;

            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode.Equals("insert"))
            {
                if (txtGroupName.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Gropu Name 값을 입력 하세요!");
                    return;
                }

                if (txtRoleCode.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Role Code 값을 입력 하세요!");
                    return;
                }

                string dupChk = "";
                Conn = new OleDbConnection(connect_string);

                string query = " select groupNo " +
                             "   from groupMaster with(nolock)" +
                             "   where groupName = '" + txtGroupName.Text.Trim() + "' " +
                             "     and appID    =  '" + cmbAppId.Text.Trim() + "' " +
                             "     and deptNo   =  '" + txtSelectedDeptNo.Text.Trim() + "' " +
                             "     and roleCode =  '" + txtRoleCode.Text.Trim() + "' ";

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
                        " insert into groupMaster     " +
                        "  (                  " +
                        " 	groupName      ,  " +
                        " 	appID         ,  " +
                        " 	deptNo         ,  " +
                        " 	roleCode       ,  " +
                        " 	roleType       ,  " +
                        " 	registeredBy  ,  " +
                        " 	registeredDate,  " +
                        " 	modifiedBy    ,  " +
                        "   ModifiedDate           , " +
                        "   Disuse                 , " +
                        "   DisusedBy              , " +
                        "   DisusedDate              " +
                        " )                           " +
                        " Values                      " +
                        " (                           " +
                        " '" + txtGroupName.Text + "',   " +
                        " '" + cmbAppId.Text + "',   " +
                        " '" + txtSelectedDeptNo.Text + "', " +
                        " '" + txtRoleCode.Text + "',   " +
                        " '" + cmbRoleType.Text + "',   " +
                        " '" + accountNo + "', " +
                        " getdate(), " +
                        " '', " +
                        " ''," +
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

                    btnUpd.Enabled = false;
                    btnSave.Enabled = false;
                }
            }

            if (mode.Equals("update"))
            {

                if (txtGroupName.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Gropu Name 값을 입력 하세요!");
                    return;
                }

                if (txtRoleCode.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Role Code 값을 입력 하세요!");
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
                    " update groupMaster  " +
                    " set                " +
                    " 	groupName      = '" + txtGroupName.Text + "',  " +
                    "   appId          = '" + cmbAppId.Text + "',  " +
                    "   deptNo         = '" + txtSelectedDeptNo.Text + "',  " +
                    "   roleCode       = '" + txtRoleCode.Text + "',  " +
                    "   roleType       = '" + cmbRoleType.Text + "',  " +

                    " 	modifiedBy     = '" + accountNo + "',  " +
                    "   ModifiedDate   = getdate(), " +
                    "   Disuse         = '" + Convert.ToInt32(chkDisuse.Checked) + "', " +
                    "   DisusedBy      = '" + disuseChecker + "', " +
                    "   DisusedDate    = " + disuseDate +
                    " where                      " +
                    "       groupNo    = '" + txtSelectedGroupNo.Text + "'";



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
            //int idx = cmbAppId.Text.IndexOf(" :: ");
            //txtSelectedAppNo.Text = cmbAppId.Text.Substring(idx + 4, cmbAppId.Text.Length - idx - 4);

            txtSelectedAppNo.Text = cmbAppId.Text;
        }

        private void cmbDeptId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cmbDeptName.Text.IndexOf(" :: ");
            txtSelectedDeptNo.Text = cmbDeptName.Text.Substring(0, idx);
            //txtSelectedDeptNo.Text = cmbDeptName.Text.Substring(idx + 4, cmbDeptName.Text.Length - idx - 4);

            //txtSelectedDeptNo.Text = cmbDeptId.Text;
        }

        private void cmbRoleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtSelectedRoleType.Text = cmbRoleType.Text;
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            if (!mode.Equals("select"))
            {
                objectEnable(true);
                objectClear();

                cmbAppId.Enabled = true;

                btnUpd.Enabled = false;
                btnSave.Enabled = false;

                mode = "select";
                lblMode.Text = mode;
            }

            else if (mode.Equals("select"))
            {
                mode = "";
                lblMode.Text = "MODE";

                Conn = new OleDbConnection(connect_string);

                ////dgvUserRequestStatus.Rows.Clear();

                string query = "";

                query = " select groupNo, groupName, appID, t1.deptNo, deptName, roleCode, roleType, t1.disuse ";
                query += " from groupMaster as t1 with(nolock)";
                query += " inner join deptMaster AS t2 with(nolock)";
                query += " on t1.deptNo = t2.deptNo";
                query += " where 1=1 ";

                if (!txtGroupName.Text.Trim().Equals(""))
                {
                    query += " and groupName like '%" + txtGroupName.Text.Trim() + "%'";
                }

                if (!cmbAppId.Text.Trim().Equals(""))
                {
                    query += " and AppId = '" + cmbAppId.Text.Trim() + "'";
                }

                if (!txtSelectedDeptNo.Text.Trim().Equals(""))
                {
                    query += " and t1.deptNo = '" + txtSelectedDeptNo.Text.Trim() + "'";
                }

                if (!txtRoleCode.Text.Trim().Equals(""))
                {
                    query += " and roleCode = '" + txtRoleCode.Text.Trim() + "'";
                }

                if (!cmbRoleType.Text.Trim().Equals(""))
                {
                    query += " and roleType = '" + cmbRoleType.Text.Trim() + "'";
                }
                query += " and t1.Disuse = '" + Convert.ToInt32(chkDisuse.Checked) + "'";
                query += " order by appID, groupName, deptName, roleType";

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

                objectEnable(false);
            }
        }

        private void dgvGroupMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {                
                if (dgvGroupMaster.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() != null)
                {

                    objectEnable(false);

                    txtSelectedGroupNo.Text = dgvGroupMaster.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();                    
                    txtGroupName.Text = dgvGroupMaster.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                    cmbAppId.SelectedIndex = cmbAppId.Items.IndexOf(dgvGroupMaster.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());

                    cmbDeptName.SelectedIndex = cmbDeptName.Items.IndexOf(dgvGroupMaster.Rows[e.RowIndex].Cells[4].Value.ToString().Trim() + " :: " + dgvGroupMaster.Rows[e.RowIndex].Cells[5].Value.ToString().Trim());

                    txtRoleCode.Text = dgvGroupMaster.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                    cmbRoleType.SelectedIndex = cmbRoleType.Items.IndexOf(dgvGroupMaster.Rows[e.RowIndex].Cells[7].Value.ToString().Trim());
                    chkDisuse.Checked = Convert.ToBoolean(dgvGroupMaster.Rows[e.RowIndex].Cells[8].Value.ToString());

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
