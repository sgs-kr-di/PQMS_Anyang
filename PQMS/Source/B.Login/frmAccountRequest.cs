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
    public partial class frmAccountRequest : Form
    {
        public frmAccountRequest()
        {
            InitializeComponent();
        }

        public frmAccountRequest(string userId, string logInId)
        {
            InitializeComponent();
            this.txtUserId.Text = userId;
            this.txtLogInId.Text = logInId;
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
    }
}
