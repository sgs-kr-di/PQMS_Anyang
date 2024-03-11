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
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace userManagement
{
    public partial class frmUserRequest : Form
    {
        private string userId = string.Empty;
        private string logInId = string.Empty;
        private string userInfoYN = string.Empty;
        private string appId = string.Empty;


        public frmUserRequest()
        {
            InitializeComponent();
        }

        public frmUserRequest(string userId, string logInId, string appId, string userInfoYN)
        {
            InitializeComponent();
            this.userId = userId;
            this.logInId = logInId;
            this.appId = appId;

            this.txtUserId.Text = this.userId;
            this.txtLoginId.Text = this.logInId;
            this.txtAppId.Text = this.appId;

            this.userInfoYN = userInfoYN;

            if(this.userInfoYN.Equals("accountN"))
            {
                userMasterSetting();
            }
        }

        private OleDbConnection Conn;

        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";

        private void userMasterSetting()
        {
            Conn = new OleDbConnection(connect_string);

            ////dgvUserRequestStatus.Rows.Clear();

            string query = "";

            query  = " select userID, firstName, lastName, companyId, department,";
            query += " empID,  address1,  address2,  email,  phone ";
            query += " from userMaster with(nolock)";
            query += " where 1=1 ";
            query += " and userId = '" + userId + "'";
            query += " and disuse = 0";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        txtUserId.Text = reader.GetString(0);
                        txtFirstName.Text = reader.GetString(1);
                        txtLastName.Text = reader.GetString(2);
                        txtCompany.Text = reader.GetString(3);
                        txtDepartment.Text = reader.GetString(4);
                        txtEmplId.Text = reader.GetString(5);
                        txtAddress1.Text = reader.GetString(6);
                        txtAddress2.Text = reader.GetString(7);
                        txtEmail.Text = reader.GetString(8);
                        txtPhone.Text = reader.GetString(9);
                    }
                }
            }
            Conn.Close();
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            if(!frmValidation())
            {
                return;
            }
            
            Conn = new OleDbConnection(connect_string);
            OleDbCommand cmd = null;

            string query = "";

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
                " '" + txtLoginId.Text + "', " +
                " '" + txtUserId.Text + "', " +
                " '" + txtAppId.Text + "', " +
                " '" + txtPassword.Text + "', " +
                " 'request', " +
                " IDENT_CURRENT ('accountMaster'), " +
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

            string regAccId = "";
            query = " select @@identity ";
            cmd = new OleDbCommand(query, Conn);


            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    reader.Read();
                    regAccId = reader.GetValue(0).ToString();
                }
            }

            if (userInfoYN == "userNaccountN")
            {
                query =
                    " insert into userMaster      " +
                    " ( userID                 ,  " +
                    " 	firstName              ,  " +
                    " 	lastName               ,  " +
                    " 	companyId              ,  " +
                    " 	department             ,  " +
                    " 	empID                  ,  " +
                    " 	address1               ,  " +
                    " 	address2               ,  " +
                    " 	email                  ,  " +
                    " 	email_verification_code,  " +
                    " 	phone                  ,  " +
                    " 	phone_verification_code,  " +
                    " 	registeredBy           ,  " +
                    " 	registeredDate         ,  " +
                    "   modifiedBy             , " +
                    "   ModifiedDate             " +
                    " )                          " +
                    " Values                     " +
                    " (                          " +
                    " '" + txtUserId.Text + "', " +
                    " '" + txtFirstName.Text + "', " +
                    " '" + txtLastName.Text + "', " +
                    " '" + txtCompany.Text + "', " +
                    " '" + txtDepartment.Text + "', " +
                    " '" + txtEmplId.Text + "', " +
                    " '" + txtAddress1.Text + "', " +
                    " '" + txtAddress2.Text + "', " +
                    " '" + txtEmail.Text + "', " +
                    " '', " +
                    " '" + txtPhone.Text + "', " +
                    " '', " +
                    " '" + regAccId + "'," +
                    " getdate(), " +
                    " '', " +
                    " ''" +
                    " )";

                cmd = new OleDbCommand(query, Conn);
                
                cmd.ExecuteNonQuery();
            }

            else if (userInfoYN.Equals("accountN"))
            {
                query  = " update userMaster set ";
                query += " firstName               = " + " '" + txtFirstName.Text + "', ";
                query += " lastName                = " + " '" + txtLastName.Text + "', ";
                query += " companyId               = " + " '" + txtCompany.Text + "', ";
                query += " department              = " + " '" + txtDepartment.Text + "', ";
                query += " empID                   = " + " '" + txtEmplId.Text + "', ";
                query += " address1                = " + " '" + txtAddress1.Text + "', ";
                query += " address2                = " + " '" + txtAddress2.Text + "', ";
                query += " email                   = " + " '" + txtEmail.Text + "', ";
                query += " phone                   = " + " '" + txtPhone.Text + "', ";
                query += " modifiedBy              = " + " '" + regAccId + "',";
                query += " ModifiedDate            = getdate()                           ";
                query += " where 1=1                                                     ";
                query += "   and userID            = " + " '" + txtUserId.Text + "'      ";

                cmd = new OleDbCommand(query, Conn);

                cmd.ExecuteNonQuery();
            }


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
                " '" + txtLoginId.Text + "', " +
                " '" + txtAppId.Text + "', " +
                " 'request'," +
                " '" + regAccId + "'," +
                " getdate() " +
                " )";
            cmd = new OleDbCommand(query, Conn);
            cmd.ExecuteNonQuery();

            Conn.Close();

            MessageBox.Show("요청 완료!");            

            foreach (Control ControlTextBoxClear in this.Controls)
            {
                if (typeof(TextBox) == ControlTextBoxClear.GetType())
                {
                    (ControlTextBoxClear as TextBox).Text = "";
                }
            }

            this.Close();
        }

        private Boolean frmValidation()
        {            
            foreach (Control ControlTextBoxMandantory in this.Controls)
            {
                if (typeof(TextBox) == ControlTextBoxMandantory.GetType())
                {
                    if ( (ControlTextBoxMandantory as TextBox).Tag.Equals("mandantory"))
                    {
                        //MessageBox.Show((ControlTextBoxMandantory as TextBox).Name);

                        if ( (ControlTextBoxMandantory as TextBox).Text.Trim().Equals(""))
                        {
                            MessageBox.Show("필수 값을 입력 하세요!");
                            return false;
                        }
                    }
                }
            }


            if (!new EmailAddressAttribute().IsValid(txtLoginId.Text))
            {
                MessageBox.Show("로그인 아이디는 E-Mail 형태로 등록해 주세요!");
                return false;
            }

            if (!new EmailAddressAttribute().IsValid(txtEmail.Text))
            {
                MessageBox.Show("E-Mail이 올바르지 않습니다!");
                return false;
            }

            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("패스워드는 8자 이상 입력 하세요!");
                return false;
            }

            if(txtPhone.Text.Contains("-"))
            {
                MessageBox.Show("폰 번호에 - 기호는 삭제 하고 입력 해주세요");
                return false;
            }

            String phoneNumChk = phoneNumCheck(txtPhone.Text);

            if(!phoneNumChk.Equals("Success"))
            {
                MessageBox.Show(phoneNumChk);
                return false;
            }

            return true;
        }



    // 휴대전화번호 체크 (하이픈 없을 시)
    private String phoneNumCheck(string phone)
    {
        if (phone.Length == 10 || phone.Length == 11)
        {
            Regex regex = new Regex(@"01{1}[016789]{1}[0-9]{7,8}");

            Match m = regex.Match(phone);
            if (m.Success)
            {
               return "Success";
            }
            else
            {
                    return "휴대전화 번호 아님";
            }
        }
        else
        {
                return "휴대 전화 번호 자릿수 맞지 않음";
        }

    }

    // 휴대전화번호 체크 (하이픈 포함)
    private String phoneNumCheck2(string phone)
    {
        if (phone.Length == 12 || phone.Length == 13)
        {
            Regex regex = new Regex(@"01{1}[016789]{1}-[0-9]{3,4}-[0-9]{4}");

            Match m = regex.Match(phone);
            if (m.Success)
            {
                    return "Success";
            }
            else
            {
                    return "휴대전화 번호 아님";
            }
        }
        else
        {
                return "휴대 전화 번호 자릿수 맞지 않음";
        }

    }

    /*
    private void btnSel_Click(object sender, EventArgs e)
    {
        Conn = new OleDbConnection(connect_string);

        string query = " select userid, firstName, lastName " +
                        "     from userMaster "; //+
                                                 //"    where userid = '" + txtUserId.Text.Trim() + "' ";

        DataSet ds = new System.Data.DataSet();
        OleDbCommand cmd = new OleDbCommand(query, Conn);
        Conn.Open();

        int wRowNo = 0;
        int i = 0;

        using (OleDbDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows == true)
            {
                dgvUserMaster.ColumnCount = reader.FieldCount;


                for (i = 0; i < reader.FieldCount; i++)
                {
                    dgvUserMaster.Columns[i].HeaderText = reader.GetName(i).ToString();
                    if (i == 1)
                    {
                        //dgvUserRequestStatus.Columns[i].Width = 40;
                        //dgvUserRequestStatus.Columns[i].Visible = false;

                        dgvUserMaster.Columns[i].Width = 100;
                        //dgvUserMaster.Columns[i].Visible = true;
                    }
                    else
                    {
                        if (i == 2)
                        {
                            dgvUserMaster.Columns[i].Width = 300;
                        }
                        else
                        {
                            dgvUserMaster.Columns[i].Width = 500;
                        }
                    }
                }
                while (reader.Read())
                {
                    dgvUserMaster.RowCount = wRowNo + 1;

                    for (i = 0; i < reader.FieldCount; i++)
                    {
                        dgvUserMaster.Rows[wRowNo].Cells[i].Value = reader.GetValue(i);
                    }
                    wRowNo = wRowNo + 1;
                    dgvUserMaster.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();
                }
            }
            else
            {
                MessageBox.Show("데이터 없음");
            }
        }
        Conn.Close();
    }
    */

    private void btnAcc_Click(object sender, EventArgs e)
        {
            frmAccountRequest frmAccountRequest = new frmAccountRequest(userId, logInId);
            frmAccountRequest.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
