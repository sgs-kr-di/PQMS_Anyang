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
    public partial class frmAppMaster : Form
    {
        public frmAppMaster()
        {
            InitializeComponent();

            objectEnable(false);

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

        private void btnIns_Click(object sender, EventArgs e)
        {
            objectEnable(true);
            objectClear();
                
            mode = "insert";
            lblMode.Text = mode;

            txtAppId.Enabled = true;
            
            btnUpd.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            
            objectEnable(true);

            mode = "update";
            lblMode.Text = mode;

            txtAppId.Enabled = false;
            btnSave.Enabled = true;
        }

        

        private void btnSel_Click(object sender, EventArgs e)
        {
            if (!mode.Equals("select"))
            {
                objectEnable(true);
                objectClear();

                txtAppId.Enabled = true;

                btnUpd.Enabled = false;
                btnSave.Enabled = false;

                mode = "select";
                lblMode.Text = mode;
            }

            else if(mode.Equals("select"))
            {
                mode = "";
                lblMode.Text = "MODE";

                Conn = new OleDbConnection(connect_string);

                ////dgvUserRequestStatus.Rows.Clear();

                string query = "";

                query = " select AppNo, AppId, AppName, Description, disuse ";
                query += " from appMaster with(nolock)";
                query += " where 1=1 ";

                if (!txtAppId.Text.Trim().Equals(""))
                {
                    query += " and AppId = '" + txtAppId.Text.Trim() + "'";
                }
                if (!txtAppName.Text.Trim().Equals(""))
                {
                    query += " and AppName = '" + txtAppName.Text.Trim() + "'";
                }
                if (!txtDescription.Text.Trim().Equals(""))
                {
                    query += " and Description like '%" + txtDescription.Text.Trim() + "%'";
                }
                query += " and Disuse = '" + chkDisuse.Checked + "'";


                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();

                dgvAppMaster.RowCount = 100;

                int i;
                int wRowNo = 0;

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        dgvAppMaster.ColumnCount = reader.FieldCount + 1;

                        for (i = 1; i < reader.FieldCount + 1; i++)
                        {
                            dgvAppMaster.Columns[i].HeaderText = reader.GetName(i - 1).ToString();
                            if (i == 1)
                            {
                                //dgvUserRequestStatus.Columns[i].Width = 40;
                                //dgvUserRequestStatus.Columns[i].Visible = false;

                                dgvAppMaster.Columns[i].Width = 100;
                                dgvAppMaster.Columns[i].Visible = true;
                            }
                            else
                            {
                                if (i == 2)
                                {
                                    dgvAppMaster.Columns[i].Width = 150;
                                }
                                else
                                {
                                    dgvAppMaster.Columns[i].Width = 200;
                                }
                            }
                        }

                        while (reader.Read())
                        {
                            dgvAppMaster.Rows[wRowNo].Cells[0].Value = false;
                            for (i = 0; i < reader.FieldCount; i++)
                            {
                                dgvAppMaster.Rows[wRowNo].Cells[i + 1].Value = reader.GetValue(i);
                            }
                            wRowNo = wRowNo + 1;
                            dgvAppMaster.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();

                        }
                    }
                }
                if (wRowNo > 0)
                {
                    dgvAppMaster.RowCount = wRowNo + 1;
                }
                else
                {
                    dgvAppMaster.RowCount = 1;
                }

                Conn.Close();

                objectEnable(false);
            }
        }


        private void objectEnable(Boolean trueFalse)
        {
            foreach (Control ControlTextBoxClear in this.Controls)
            {
                if (typeof(TextBox) == ControlTextBoxClear.GetType())
                {
                    (ControlTextBoxClear as TextBox).Enabled = trueFalse;
                }
            }

            foreach (Control ControlCheckBoxClear in this.Controls)
            {
                if (typeof(CheckBox) == ControlCheckBoxClear.GetType())
                {
                    (ControlCheckBoxClear as CheckBox).Enabled = trueFalse;
                }
            }
        }

        private void objectClear()
        {

            foreach (Control ControlTextBoxClear in this.Controls)
            {
                if (typeof(TextBox) == ControlTextBoxClear.GetType())
                {
                    (ControlTextBoxClear as TextBox).Text = "";
                }
            }

            foreach (Control ControlCheckBoxClear in this.Controls)
            {
                if (typeof(CheckBox) == ControlCheckBoxClear.GetType())
                {
                    (ControlCheckBoxClear as CheckBox).Checked = false;
                }
            }
        }


        private void dgvAppMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvAppMaster.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() != null)
                {
                    objectEnable(false);

                    txtAppId.Text       = dgvAppMaster.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                    txtAppName.Text     = dgvAppMaster.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                    txtDescription.Text = dgvAppMaster.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                    chkDisuse.Checked   = Convert.ToBoolean(dgvAppMaster.Rows[e.RowIndex].Cells[5].Value.ToString());

                    btnUpd.Enabled = true;
                    btnSave.Enabled = false;

                    mode = "";
                    lblMode.Text = "MODE";
                }
            }
            catch(Exception exp)
            {
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode.Equals("insert"))
            {
                if (txtAppId.Text.Trim().Equals(""))
                {
                    MessageBox.Show("APP ID 값을 입력 하세요!");
                    return;
                }

                string dupChk = "";
                Conn = new OleDbConnection(connect_string);

                string query = " select appID " +
                             "     from appMaster with(nolock)" +
                             "    where appID = '" + txtAppId.Text.Trim() + "' ";

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
                        " insert into appMaster     " +
                        "  (appID        ,  " +
                        " 	appName      ,  " +
                        "   description  ,  " +
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
                        " '" + txtAppId.Text + "',   " +
                        " '" + txtAppName.Text + "', " +
                        " '" + txtDescription.Text + "', " +
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
                    " update appMaster  " +
                    " set                " +
                    " 	appName        = '" + txtAppName.Text + "',  " +
                    "   description    = '" + txtDescription.Text + "',  " +
                    " 	modifiedBy     = '" + accountNo + "',  " +
                    "   ModifiedDate   = getdate(), " +
                    "   Disuse         = '" + Convert.ToInt32(chkDisuse.Checked) + "', " +
                    "   DisusedBy      = '" + disuseChecker + "', " +
                    "   DisusedDate    = " + disuseDate +
                    " where                      " +
                    " appId            = '" + txtAppId.Text + "'";



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
    }
}
