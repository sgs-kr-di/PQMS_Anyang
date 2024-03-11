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
    public partial class frmMenuRole : Form
    {
        public frmMenuRole()
        {
            InitializeComponent();

            objectEnable(false);

            cmbSetting("appMaster", "appNo", "appId", "", "", cmbAppId, "N");

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
                    if(!(ControlClear as TextBox).Name.Equals("txtSelectedGroupNo") && !(ControlClear as TextBox).Name.Equals("txtSelectedMenuNo") && !(ControlClear as TextBox).Name.Equals("txtSelectedMenuRoleNo"))                    
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
                    if (!((ControlClear as ComboBox).Name.Equals("cmbAppId") || (ControlClear as ComboBox).Name.Equals("")))
                    {
                        (ControlClear as ComboBox).Items.Clear();
                        (ControlClear as ComboBox).Text = "";
                    }

                }

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

                if (cmbGroupNo.Text.Trim().Equals(""))
                {
                    //MessageBox.Show("Group 을 선택 하세요!");
                    //return;
                }

                mode = "";
                lblMode.Text = "MODE";

                Conn = new OleDbConnection(connect_string);

                ////dgvUserRequestStatus.Rows.Clear();

                string query = "";

                query = " select t2.menuRoleNo, t1.appId, t1.groupno, t1.groupName, t3.menuNo, t3.menuName,  ";
                query += " t2.visible, t2.search, t2.[update], t2.[delete], t2.excel, t2.download, t2.upload, t2.disuse ";
                query += " from groupMaster as t1 with(nolock)                                               ";
                query += " inner join menuRole as t2 with(nolock)                                            ";
                query += " on  t1.disuse = 0                                                                 ";
                query += " and t2.Disuse = '" + Convert.ToInt32(chkDisuse.Checked) + "'";
                query += " and t1.groupNo = t2.groupNo                                                       ";
                query += " inner join menuMaster as t3 with (nolock)                                         ";
                query += " on  t2.menuNo = t3.menuNo                                                         ";
                query += " and t3.Disuse = 0                                                                 ";
                query += " where 1=1                                                                         ";
                
                if (!cmbAppId.Text.Trim().Equals(""))
                {
                    query += " and t1.AppId = '" + cmbAppId.Text.Trim() + "'";
                }

                if (!cmbGroupNo.Text.Trim().Equals(""))
                {
                    query += " and t1.groupNo = '" + txtSelectedGroupNo.Text.Trim() + "'";
                }

                if (!cmbMenuNo.Text.Trim().Equals(""))
                {
                    query += " and t3.menuNo = '" + txtSelectedMenuNo.Text.Trim() + "'";
                }

                query += " order by t1.groupName                                                                ";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();

                dgvMenuRoleMaster.RowCount = 1000;

                int i;
                int wRowNo = 0;

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        dgvMenuRoleMaster.ColumnCount = reader.FieldCount + 1;

                        for (i = 1; i < reader.FieldCount + 1; i++)
                        {
                            dgvMenuRoleMaster.Columns[i].HeaderText = reader.GetName(i - 1).ToString();
                            if (i == 1)
                            {
                                //dgvUserRequestStatus.Columns[i].Width = 40;
                                //dgvUserRequestStatus.Columns[i].Visible = false;

                                dgvMenuRoleMaster.Columns[i].Width = 100;
                                dgvMenuRoleMaster.Columns[i].Visible = true;
                            }
                            else
                            {
                                if (i == 2)
                                {
                                    dgvMenuRoleMaster.Columns[i].Width = 100;
                                }
                                else
                                {
                                    dgvMenuRoleMaster.Columns[i].Width = 100;
                                }
                            }
                        }

                        while (reader.Read())
                        {
                            dgvMenuRoleMaster.Rows[wRowNo].Cells[0].Value = false;
                            for (i = 0; i < reader.FieldCount; i++)
                            {
                                dgvMenuRoleMaster.Rows[wRowNo].Cells[i + 1].Value = reader.GetValue(i);
                            }
                            wRowNo = wRowNo + 1;
                            dgvMenuRoleMaster.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();
                        }
                    }
                }
                if (wRowNo > 0)
                {
                    dgvMenuRoleMaster.RowCount = wRowNo + 1;
                }
                else
                {
                    dgvMenuRoleMaster.RowCount = 1;
                }

                Conn.Close();

                objectEnable(false);
            }
        }

        private void cmbAppId_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSetting("groupmaster", "groupNo", "groupName", "appId", cmbAppId.Text, cmbGroupNo, "Y");
            cmbSetting("menumaster", "menuNo", "menuName", "appId", cmbAppId.Text, cmbMenuNo, "Y");
        }

        private void cmbGroupNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbGroupNo.Text.Equals(""))
            {
                int idx = cmbGroupNo.Text.IndexOf(" :: ");
                txtSelectedGroupNo.Text = cmbGroupNo.Text.Substring(0, idx);
            }            
        }

        private void cmbMenuNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbMenuNo.Text.Equals(""))
            {
                int idx = cmbMenuNo.Text.IndexOf(" :: ");
                txtSelectedMenuNo.Text = cmbMenuNo.Text.Substring(0, idx);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode.Equals("insert"))
            {

                string dupChk = "";
                Conn = new OleDbConnection(connect_string);

                string query = " select menuRoleNo " +
                             "     from menuRole with(nolock)" +
                             "    where groupNo = '" + txtSelectedGroupNo.Text.Trim() + "' " +
                             "      and menuNo = '" + txtSelectedMenuNo.Text.Trim() + "' ";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            dupChk = "nok";
                            MessageBox.Show("데이터 중복!");
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
                        " insert into menuRole     " +
                        "  ( " +
                        "   groupNo       ," +
                        "   menuNo ," +
                        "   visible    ," +
                        "   search     ," +
                        "   [update]     ," +
                        "   [delete]     ," +
                        "   excel     ," +
                        "   download     ," +
                        "   upload     ," +
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
                        " '" + txtSelectedGroupNo.Text + "', " +
                        " '" + txtSelectedMenuNo.Text + "', " +
                        " '" + chkVisible.Checked + "', " +
                        " '" + chkSearch.Checked + "', " +
                        " '" + chkUpdate.Checked + "', " +
                        " '" + chkDelete.Checked + "', " +
                        " '" + chkExcel.Checked + "', " +
                        " '" + chkDownload.Checked + "', " +
                        " '" + chkUpload.Checked + "', " +

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

                    chkDisuse.Enabled = true;

                    btnUpd.Enabled = false;
                    btnSave.Enabled = false;
                }
            }
            if (mode.Equals("update"))
            {

                if (txtSelectedMenuRoleNo.Text.Equals(""))
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
                    " update menuRole  " +
                    " set                " +
                    "   visible     = '" + Convert.ToInt32(chkVisible.Checked) + "', " +
                    "   search      = '" + Convert.ToInt32(chkSearch.Checked) + "', " +
                    "   [update]    = '" + Convert.ToInt32(chkUpdate.Checked) + "', " +
                    "   [delete]    = '" + Convert.ToInt32(chkDelete.Checked) + "', " +
                    "   excel       = '" + Convert.ToInt32(chkExcel.Checked) + "', " +
                    "   download    = '" + Convert.ToInt32(chkDownload.Checked) + "', " +
                    "   upload      = '" + Convert.ToInt32(chkUpload.Checked) + "', " +
                    " 	modifiedBy     = '" + accountNo + "',  " +
                    "   ModifiedDate   = getdate(), " +
                    "   Disuse         = '" + Convert.ToInt32(chkDisuse.Checked) + "', " +
                    "   DisusedBy      = '" + disuseChecker + "', " +
                    "   DisusedDate    = " + disuseDate +
                    " where                      " +
                    "   menuRoleNo    = '" + txtSelectedMenuRoleNo.Text + "'";



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
            /*            
             if (!mode.Equals("update") && chkDisuse.Checked)
             {
                 MessageBox.Show("disuse 처리한 건은 수정 할 수 없습니다. 신규로 등록 하세요!");
                 return;
             }
            */

            objectEnable(true);

            cmbAppId.Enabled = false;
            cmbGroupNo.Enabled = false;
            cmbMenuNo.Enabled = false;            

            mode = "update";
            lblMode.Text = mode;

            btnSave.Enabled = true;
        }

        private void dgvMenuRoleMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMenuRoleMaster.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() != null)
                {
                    mode = "";
                    lblMode.Text = "MODE";

                    ////objectEnable(false);
                    //cmbLoginId.Enabled = true;

                    txtSelectedGroupNo.Text = dgvMenuRoleMaster.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                    txtSelectedMenuNo.Text = dgvMenuRoleMaster.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                    txtSelectedMenuRoleNo.Text = dgvMenuRoleMaster.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();

                    cmbAppId.SelectedIndex = cmbAppId.Items.IndexOf(dgvMenuRoleMaster.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                    cmbGroupNo.SelectedIndex = cmbGroupNo.Items.IndexOf(dgvMenuRoleMaster.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() + " :: " + dgvMenuRoleMaster.Rows[e.RowIndex].Cells[4].Value.ToString().Trim());
                    cmbMenuNo.SelectedIndex = cmbMenuNo.Items.IndexOf(dgvMenuRoleMaster.Rows[e.RowIndex].Cells[5].Value.ToString().Trim() + " :: " + dgvMenuRoleMaster.Rows[e.RowIndex].Cells[6].Value.ToString().Trim());

                    chkVisible.Checked = Convert.ToBoolean(dgvMenuRoleMaster.Rows[e.RowIndex].Cells[7].Value.ToString());
                    chkSearch.Checked = Convert.ToBoolean(dgvMenuRoleMaster.Rows[e.RowIndex].Cells[8].Value.ToString());
                    chkUpdate.Checked = Convert.ToBoolean(dgvMenuRoleMaster.Rows[e.RowIndex].Cells[9].Value.ToString());
                    chkDelete.Checked = Convert.ToBoolean(dgvMenuRoleMaster.Rows[e.RowIndex].Cells[10].Value.ToString());
                    chkExcel.Checked = Convert.ToBoolean(dgvMenuRoleMaster.Rows[e.RowIndex].Cells[11].Value.ToString());
                    chkDownload.Checked = Convert.ToBoolean(dgvMenuRoleMaster.Rows[e.RowIndex].Cells[12].Value.ToString());
                    chkUpload.Checked = Convert.ToBoolean(dgvMenuRoleMaster.Rows[e.RowIndex].Cells[13].Value.ToString());

                    chkDisuse.Checked = Convert.ToBoolean(dgvMenuRoleMaster.Rows[e.RowIndex].Cells[14].Value.ToString());

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
