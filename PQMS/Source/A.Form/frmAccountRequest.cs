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

namespace PQMS
{
    public partial class frmAccountRequest : Form
    {
        public frmAccountRequest()
        {
            InitializeComponent();
        }

        public frmAccountRequest(string userId, string logInId, string appNo, string appId)
        {
            InitializeComponent();

            this.txtUserId.Text = userId;
            this.txtLogInId.Text = logInId;
            this.txtAppNo.Text = appNo;
            this.txtAppId.Text = appId;
        }

        private OleDbConnection Conn;

        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            string dupChk = "";
            Conn = new OleDbConnection(connect_string);

            string query = " select accountNo " +
                         "     from accountMaster " +
                         "    where logInID = '" + txtLogInId.Text.Trim() + "' " +
                         "      and appID  = '" + txtAppId.Text.Trim() + "' ";

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

                query =
                    " insert into accountMaster     " +
                    "  ( " +
                    " 	logInID      ,  " +
                    " 	userID      ,  " +
                    " 	appID         ,  " +
                    " 	password      ,  " +
                    " 	requestStatusCode,  " +
                    " 	registeredBy  ,  " +
                    " 	registeredDate,  " +
                    " 	approvedBy    ,  " +
                    " 	approvedDate,     " +
                    " 	modifiedBy    ,  " +
                    "   ModifiedDate           , " +
                    "   Disuse                 , " +
                    "   DisusedBy              , " +
                    "   DisusedDate              " +
                    " )                           " +
                    " Values                      " +
                    " (                           " +
                    " '" + txtLogInId.Text + "', " +
                    " '" + txtUserId.Text + "', " +
                    " '" + txtAppId.Text + "', " +
                    " '" + txtPassword.Text + "', " +
                    " 'request', " +
                    " 'admin', " +
                    " getdate(), " +
                    " '', " +
                    " getdate(), " +
                    " '', " +
                    " ''," +
                    " '0', " +
                    " '', " +
                    " ''  " +
                    " )";

                cmd = new OleDbCommand(query, Conn);

                Conn.Open();
                cmd.ExecuteNonQuery();

                query = " insert into approveInfo     " +
                    "  ( " +
                    " 	userID      ,  " +
                    " 	logInID      ,  " +
                    " 	appID      ,  " +
                    " 	approveStatusCode,  " +
                    " 	registeredBy  ,  " +
                    " 	registeredDate  " +
                    " )                           " +
                    " Values                      " +
                    " (                           " +
                    " '" + txtUserId.Text + "', " +
                    " '" + txtLogInId.Text + "', " +
                    " '" + txtAppId.Text + "', " +
                    " 'request'," +
                    " @@identity,  " +
                    " getdate() " +
                    " )";
                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();

                Conn.Close();

                MessageBox.Show("등록 완료!");


                foreach (Control ControlTextBoxClear in this.Controls)
                {
                    if (typeof(TextBox) == ControlTextBoxClear.GetType())
                    {
                        (ControlTextBoxClear as TextBox).Text = "";
                    }
                }
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Get_Data();
        }

        private void Get_Data()
        {
            Conn = new OleDbConnection(connect_string);

            ////dgvUserRequestStatus.Rows.Clear();

            string query = "";

            query = " select * ";
            query = query + " from accountMaster ";
            query = query + "  order by accountNo";
            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            dgvUserRequestStatus.RowCount = 300;

            int i;
            int wRowNo = 0;

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dgvUserRequestStatus.ColumnCount = reader.FieldCount + 1;

                    for (i = 1; i < reader.FieldCount + 1; i++)
                    {
                        dgvUserRequestStatus.Columns[i].HeaderText = reader.GetName(i - 1).ToString();
                        if (i == 1)
                        {
                            //dgvUserRequestStatus.Columns[i].Width = 40;
                            //dgvUserRequestStatus.Columns[i].Visible = false;

                            dgvUserRequestStatus.Columns[i].Width = 100;
                            dgvUserRequestStatus.Columns[i].Visible = true;
                        }
                        else
                        {
                            if (i == 2)
                            {
                                dgvUserRequestStatus.Columns[i].Width = 100;
                            }
                            else
                            {
                                dgvUserRequestStatus.Columns[i].Width = 100;
                            }
                        }
                    }

                    while (reader.Read())
                    {
                        dgvUserRequestStatus.Rows[wRowNo].Cells[0].Value = false;
                        for (i = 0; i < reader.FieldCount; i++)
                        {
                            dgvUserRequestStatus.Rows[wRowNo].Cells[i + 1].Value = reader.GetValue(i);
                        }
                        wRowNo = wRowNo + 1;
                        dgvUserRequestStatus.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();

                    }
                }
            }
            if (wRowNo > 0)
            {
                dgvUserRequestStatus.RowCount = wRowNo + 1;
            }
            else
            {
                dgvUserRequestStatus.RowCount = 1;
            }

            Conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            get_ws_template2(cmbAppID, "Y");
        }

        private void get_ws_template2(ComboBox tCmb, string tWSK)
        {
            //tField1 = 검색테이블
            //tField2 = 검색필드1
            //tField3 = 검색필드2



            Conn = new OleDbConnection(connect_string);

            string query = "";

            query = "  select  appNo , appID from appMaster ";
            query = query + "      order by appNo ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    tCmb.Items.Clear();

                    while (reader.Read())
                    {
                        tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                    }
                }
            }

            Conn.Close();
        }

        private void cmbAppID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAppNo.Text = cmbAppID.Text.Substring(0, cmbAppID.Text.IndexOf(' '));
            txtAppId.Text = cmbAppID.Text.Substring(cmbAppID.Text.IndexOf(' ') + 1, cmbAppID.Text.Length - cmbAppID.Text.IndexOf(' ') - 1);

        }
    }
}
