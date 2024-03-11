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
    public partial class frmMenuMaster : Form
    {
        public frmMenuMaster()
        {
            InitializeComponent();

            objectEnable(false);

            cmbSetting("appMaster", "appNo", "appId", "", "", cmbAppId, "N");

            btnUpd.Enabled = false;
            btnSave.Enabled = false;

        }
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

        private OleDbConnection Conn;

        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";


        private void objectClear()
        {
            foreach (Control ControlClear in this.Controls)
            {
                if (typeof(TextBox) == ControlClear.GetType())
                {
                    if (!(ControlClear as TextBox).Name.Equals("txtSelectedAppId") && !(ControlClear as TextBox).Name.Equals("txtAppNo"))
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

            cmbAppId.Enabled = true;

            btnUpd.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            objectEnable(true);

            mode = "update";
            lblMode.Text = mode;

            cmbAppId.Enabled = false;
            btnSave.Enabled = true;
        }


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

        private void cmbSetting(string tTable, string tField1, string tField2, string tField3, string tField4, ComboBox tCmb, String splitter)
        {

            Conn = new OleDbConnection(connect_string);

            string query = "";

            if (tField3 == "")
            {
                query  = " select "   + tField1 + "," + tField2 + " from " + tTable + " with(nolock)";
                query += " where disuse = 0";
                query += " order by " + tField1;
            }
            else
            {
                query  = " select "   + tField1 + "," + tField2 + " from " + tTable + " with(nolock)";
                query += " where "    + tField3 + " = '" + tField4 + "'";
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
                        if(splitter.Equals("Y"))
                            tCmb.Items.Add(reader.GetValue(0).ToString() + " :: " + reader.GetValue(1).ToString());
                        else
                            tCmb.Items.Add(reader.GetValue(1).ToString());
                    }

                    tCmb.SelectedIndex = 0;
                }
            }

            Conn.Close();

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

                query = " select menuNo, appID, menuID, parentMenuID, menuName, disuse ";
                query += " from menuMaster with(nolock)";
                query += " where 1=1 ";

                if (!txtSelectedAppId.Text.Trim().Equals(""))
                {
                    query += " and AppId = '" + txtSelectedAppId.Text.Trim() + "'";
                }
                if (!txtMenuId.Text.Trim().Equals(""))
                {
                    query += " and menuId = '" + txtMenuId.Text.Trim() + "'";
                }
                if (!txtParentMenuId.Text.Trim().Equals(""))
                {
                    query += " and parentMenuId like '%" + txtParentMenuId.Text.Trim() + "%'";
                }
                if (!txtMenuName.Text.Trim().Equals(""))
                {
                    query += " and menuName like '%" + txtMenuName.Text.Trim() + "%'";
                }
                query += " and Disuse = '" + Convert.ToInt32(chkDisuse.Checked) + "'";
                query += " order by appID, menuID, parentMenuID";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();

                dgvMenuMaster.RowCount = 1000;

                int i;
                int wRowNo = 0;

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        dgvMenuMaster.ColumnCount = reader.FieldCount + 1;

                        for (i = 1; i < reader.FieldCount + 1; i++)
                        {
                            dgvMenuMaster.Columns[i].HeaderText = reader.GetName(i - 1).ToString();
                            if (i == 1)
                            {
                                //dgvUserRequestStatus.Columns[i].Width = 40;
                                //dgvUserRequestStatus.Columns[i].Visible = false;

                                dgvMenuMaster.Columns[i].Width = 100;
                                dgvMenuMaster.Columns[i].Visible = true;
                            }
                            else
                            {
                                if (i == 2)
                                {
                                    dgvMenuMaster.Columns[i].Width = 150;
                                }
                                else
                                {
                                    dgvMenuMaster.Columns[i].Width = 200;
                                }
                            }
                        }

                        while (reader.Read())
                        {
                            dgvMenuMaster.Rows[wRowNo].Cells[0].Value = false;
                            for (i = 0; i < reader.FieldCount; i++)
                            {
                                dgvMenuMaster.Rows[wRowNo].Cells[i + 1].Value = reader.GetValue(i);
                            }
                            wRowNo = wRowNo + 1;
                            dgvMenuMaster.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();

                        }
                    }
                }
                if (wRowNo > 0)
                {
                    dgvMenuMaster.RowCount = wRowNo + 1;
                }
                else
                {
                    dgvMenuMaster.RowCount = 1;
                }

                Conn.Close();

                objectEnable(false);
            }
        }

        private void cmbAppName_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*
            int idx = cmbAppId.Text.IndexOf(" :: ");

            txtAppNo.Text = cmbAppId.Text.Substring(0, idx);
            txtSelectedAppId.Text = cmbAppId.Text.Substring(idx+4, cmbAppId.Text.Length - idx - 4);
            */
            txtSelectedAppId.Text = cmbAppId.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode.Equals("insert"))
            {
                if (txtSelectedAppId.Text.Trim().Equals(""))
                {
                    MessageBox.Show("APP ID 값을 입력 하세요!");
                    return;
                }

                if (txtMenuId.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Menu ID 값을 입력 하세요!");
                    return;
                }
                if (txtMenuName.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Menu Name 값을 입력 하세요!");
                    return;
                }

                string dupChk = "";

                Conn = new OleDbConnection(connect_string);

                string query = " select appID " +
                             "     from menuMaster with(nolock)" +
                             "    where appID = '" + txtSelectedAppId.Text.Trim() + "' " +
                             "      and menuID = '" + txtMenuId.Text.Trim() + "' ";                             
                             //"      and disuse = 0                              ";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            dupChk = "nok";
                            MessageBox.Show("MENU ID 중복!");
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
                        " insert into menuMaster     " +
                        "  ( " +
                        "   appID        ," +
                        "   menuID       ," +
                        "   parentMenuID ," +
                        "   menuName     ," +
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
                        " '" + txtSelectedAppId.Text + "',   " +
                        " '" + txtMenuId.Text + "', " +
                        " '" + txtParentMenuId.Text + "', " +
                        " '" + txtMenuName.Text + "', " +
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
                    " update menuMaster  " +
                    " set                " +
                    " 	menuID         = '" + txtMenuId.Text + "',  " +
                    "   parentMenuID   = '" + txtParentMenuId.Text + "',  " +
                    "   menuName       = '" + txtMenuName.Text + "',  " +
                    " 	modifiedBy     = '" + accountNo + "',  " +
                    "   ModifiedDate   = getdate(), " +
                    "   Disuse         = '" + Convert.ToInt32(chkDisuse.Checked) + "', " +
                    "   DisusedBy      = '" + disuseChecker + "', " +
                    "   DisusedDate    = " + disuseDate +
                    " where                      " +
                    "       menuNo     = '" + txtMenuNo.Text + "'";



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

        private void dgvMenuMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMenuMaster.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() != null)
                {
                    objectEnable(false);

                    txtMenuNo.Text = dgvMenuMaster.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                    cmbAppId.SelectedIndex = cmbAppId.Items.IndexOf(dgvMenuMaster.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                    txtMenuId.Text = dgvMenuMaster.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                    txtParentMenuId.Text = dgvMenuMaster.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                    txtMenuName.Text = dgvMenuMaster.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                    chkDisuse.Checked = Convert.ToBoolean(dgvMenuMaster.Rows[e.RowIndex].Cells[6].Value.ToString());

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
