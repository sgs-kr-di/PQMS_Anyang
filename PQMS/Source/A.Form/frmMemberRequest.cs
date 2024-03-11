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
    public partial class frmMemberRequest : Form
    {
        private string userId = string.Empty;
        private string logInId = string.Empty;
        private string appNo = string.Empty;
        private string appID = string.Empty;
        private string userInfoYN = string.Empty;

        Form1 fm; // mainform 선언 
        public frmMemberRequest(Form1 form1) 
        {
            InitializeComponent();
            fm = form1; // mianform 의 panel 컨트롤 하기 위해서 

        }

        public frmMemberRequest(string userId, string logInId, string appNo, string appID, string userInfoYN)
        {
            InitializeComponent();
            this.userId = userId;
            this.logInId = logInId;
            this.appNo = appNo;
            this.appID = appID;

            this.txtUserId.Text = this.userId;
            this.txtAppNo.Text = this.appNo;
            this.txtAppId.Text = this.appID;
            this.txtLoginId.Text = this.logInId;

            this.userInfoYN = userInfoYN;
        }

        private OleDbConnection Conn;

        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";

        private void btnIns_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "")
            {
                txtUserId.Text = txtEmail.Text;
            }
            if (txtEmplId.Text == "")
            {
                txtEmplId.Text= txtEmail.Text;
            }

            if (txtYN1.Text == "YES")
            {
                if (txtPassword.Text != "" && txtUseYN.Text == "사용가능")
                {
                    save_item2();
                    //save_item3();
                    MessageBox.Show("프로그램 사용 신청을 했습니다. 신청에 대한 승인이 완료 되면, 프로그램 사용 가능합니다.");
                    fm.panel1.Visible = true; //mainform 의 로그인창 띄워주기 
                    this.Close();                    
                }
                else
                {
                    if (txtUseYN.Text == "사용가능")
                    {
                        MessageBox.Show("패스워드 확인 바랍니다.");
                    }
                    else
                    {
                        MessageBox.Show("중복 확인 버튼을 클릭해 주세요.");
                    }
                }
            }
            else
            {
                if (txtMemPwd.Text != "" && txtPassword.Text != "" && txtUseYN.Text == "사용가능")
                {
                    save_item();
                    save_item2();
                    //save_item3();
                    MessageBox.Show("프로그램 사용 신청을 했습니다. 신청에 대한 승인이 완료 되면, 프로그램 사용 가능합니다.");
                    fm.panel1.Visible = true; //mainform 의 로그인창 띄워주기 
                    this.Close();
                }
                else
                {
                    if (txtUseYN.Text == "사용가능")
                    {
                        MessageBox.Show("패스워드 확인 바랍니다.");
                    }
                    else
                    {
                        MessageBox.Show("중복 확인 버튼을 클릭해 주세요.");
                    }
                }


            }


            
            

        }

        private void save_item()
        {
            Conn = new OleDbConnection(connect_string);
            string query = "";

            query = "INSERT INTO userMaster(userID, firstName, lastName, companyId, department, empID, email, ";
            query = query + " email_verification_code, phone, address1, address2, disuse) VALUES ( ";
            query = query + "'" + txtUserId.Text.Trim() + "',";
            query = query + "'" + txtfirstName.Text.Trim() + "',";
            query = query + "'" + txtLastName.Text.Trim() + "',";
            query = query + "'" + txtCompany.Text.Trim() + "',";
            query = query + "'" + txtDepartment.Text.Trim() + "',";
            query = query + "'" + txtEmplId.Text.Trim() + "',";
            query = query + "'" + txtEmail.Text.Trim() + "',";
            query = query + "'" + txtMemPwd.Text.Trim() + "',";
            query = query + "'" + txtPhone.Text.Trim() + "',";
            query = query + "'" + txtAddress1.Text.Trim() + "',";
            query = query + "'" + txtAddress2.Text.Trim() + "',";
            query = query + "'" + "0" + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();

           // MessageBox.Show(query);
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            //frmAccountRequest frmAccountRequest = new frmAccountRequest(userId, logInId, appNo, appID);
            //frmAccountRequest.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //save_item();
            //Modi_rtn();
        }

        private void Modi_rtn()
        {
            //Conn = new OleDbConnection(connect_string);
            //string query = "";

            //query = "UPDATE approveInfo  SET ";
            //query = query + " RequestTo = '1'";
            //query = query + " WHERE approveNo = '" + txtApproveNO.Text.Trim() + "'";

            //OleDbCommand cmd = new OleDbCommand(query, Conn);

            //Conn.Open();

            //cmd.ExecuteNonQuery();

            //Conn.Close();
        }

        private int getMaxAccountNo()
        {
            Conn = new OleDbConnection(connect_string);

            string query = "";
            int taccountNo = 0;

            query = "  select max(accountNo) from accountMaster ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        taccountNo = Convert.ToInt32(reader.GetValue(0).ToString());
                    }
                }
                else
                {
                    taccountNo = 1;
                }
            }

            Conn.Close();

            return taccountNo;
        }

        private void save_item2()
        {
            Conn = new OleDbConnection(connect_string);
            string query = "";
            int taccountNo = 0;
              
            query =
                " insert into accountMaster     " +
                "  ( " +
                " 	logInID      ,  " +
                " 	userID      ,  " +
                " 	appID         ,  " +
                " 	appNo         ,  " +
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
                " '" + txtAppNo.Text + "', " +
                " '" + txtPassword.Text + "', " +
                " 'request', " + //request = 0
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

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

            taccountNo = getMaxAccountNo();

            query = " insert into accountApproveInfo     " +
            "  ( " +
            " 	userID      ,  " +
            " 	logInID      ,  " +
            " 	appID      ,  " +
            " 	menuNo      ,  " +
            " 	TargetNo      ,  " +
            " 	approveStatusCode,  " +
            " 	registeredBy  ,  " +
            " 	registeredDate  " +
            " )                           " +
            " Values                      " +
            " (                           " +
            " '" + txtUserId.Text + "', " +
            " '" + txtLoginId.Text + "', " +
            " '" + txtAppId.Text + "', " +
            " '" + txtMenuNo.Text + "', " +
            //" @@identity,  " +
            " " + taccountNo +", " +
            " '0'," +
            //" @@identity,  " +
            " " + taccountNo + ", " +
            " getdate() " +
            " );" +
            " insert into groupMemberMaster     " +
            "  ( " +
            " 	groupNo      ,  " +
            " 	accountNo      ,  " +
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
            " " + txtGroupNo.Text + ", " +
            //" @@identity,  " +
            " " + taccountNo + ", " +
            " 'system', " +
            " getdate(), " +
            " '', " +
            " '', " +
            " '0', " +
            " '', " +
            " ''  " +
            " );";

            cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();

            MessageBox.Show(query);
        }

        private void save_item3()
        {
            Conn = new OleDbConnection(connect_string);
            string query = "";

            query =
                " insert into groupMemberMaster     " +
                "  ( " +
                " 	groupNo      ,  " +
                " 	accountNo      ,  " +
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
                " '" + txtGroupNo.Text + "', " +
                " '" + txtLoginId.Text + "', " +
                " 'system', " +
                " getdate(), " +
                " '', " +
                " '', " +
                " '0', " +
                " '', " +
                " ''  " +
                " )";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            MessageBox.Show(query);
        }




        private void button8_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text == "" && txtMemPwd.Text == "")
            {
                MessageBox.Show("등록한 이메일과 패스워드를 확인 하세요.");
                return;
            }
            Conn = new OleDbConnection(connect_string);

            string query = " select userID, firstName, lastName, companyId, department, empID, phone, email, address2, address1, email_verification_code  " +
                            "     from userMaster " +
                            "    where email = '" + txtEmail.Text.Trim() + "' " +
                            "      and email_verification_code = '" + txtMemPwd.Text.Trim() + "' ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        txtUserId.Text = reader.GetValue(0).ToString();
                        //txtfirstName.Text = reader.GetValue(1).ToString();
                        //txtLastName.Text = reader.GetValue(2).ToString();
                        //txtCompany.Text = reader.GetValue(3).ToString();
                        //txtDepartment.Text = reader.GetValue(4).ToString();
                        //txtEmplId.Text = reader.GetValue(5).ToString();
                        //txtPhone.Text = reader.GetValue(6).ToString();
                        txtEmail.Text = reader.GetValue(7).ToString();
                        //txtAddress2.Text = reader.GetValue(8).ToString();
                        //txtAddress1.Text = reader.GetValue(9).ToString();
                        //txtMemPwd.Text = reader.GetValue(10).ToString();
                        txtYN1.Text = "YES";

                        MessageBox.Show("귀하는 멤버로 등록 되어 있습니다.");

                        

                    }
                    btnIns.Visible = true;
                    panel3.Visible = true;
                    button3.Visible = false;
                    panel1.Visible = false;
                }
                else
                {
                    txtYN1.Text = "NO";
                    //button3.Visible = true;
                    //MessageBox.Show("귀하의 멤버 정보를 확인하지 못했습니다. 아이디와 패스워드 다시 확인바랍니다. => 새로운 멤버 정보를 등록하려면, 멤버 신청 버튼을 클릭하여, 기본 정보를 함께 입력해 주시면 프로그램 신청과 함께 처리됩니다. 감사합니다.");
                    MessageBox.Show("귀하의 멤버 정보를 확인하지 못했습니다. D&I문의 하세요. ");
                }

            }

            Conn.Close();            

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void frmMemberRequest_Load(object sender, EventArgs e)
        {
            //--- 승인관련 앱과 메뉴정보를 관리해야 한다. => 승인기능이 있는 프로그램에서 아래 정보를 읽어 들인다.
            txtAppNo.Text = "3";
            txtAppId.Text = "PQMS";
            txtMenuNo.Text = "45";
            txtMenuName.Text = "사용자 승인";
            //get_menuNo();
            //--------------------------------------
        }

        private void get_menuNo()
        {
            //Conn = new OleDbConnection(connect_string);

            //////dgvUserRequestStatus.Rows.Clear();

            //string query = "";

            //query = " select menuNo from menuMaster";
            //query = query + "  where appID = '" + txtAppId.Text + "'";
            //query = query + "    and menuName = '" + this.Tag + "'";


            //OleDbCommand cmd = new OleDbCommand(query, Conn);

            //Conn.Open();

            //using (OleDbDataReader reader = cmd.ExecuteReader())
            //{
            //    if (reader.HasRows == true)
            //    {
            //        while (reader.Read())
            //        {
            //            txtMenuNo.Text = reader.GetValue(0).ToString();
            //        }
            //    }
            //}
            //Conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtLoginId.Text = txtEmail.Text;
            txtPassword.Text = txtMemPwd.Text;
            txtCFPassword.Text = txtMemPwd.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtLoginId.Text == "" )
            {
                MessageBox.Show("사용할 이메일 기입을 확인 하세요.");
                return;
            }
            Conn = new OleDbConnection(connect_string);

            string query = " select * from accountMaster " +
                            "    where loginID = '" + txtLoginId.Text.Trim() + "' " +
                            "      and userID = '" + txtUserId.Text.Trim() + "' " +
                            "      and appID = '" + txtAppId.Text.Trim() + "' ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        txtUseYN.Text = "사용불가";
                        txtLoginId.Text = "";
                        txtPassword.Text = "";
                        txtCFPassword.Text = "";

                        MessageBox.Show("해당 이메일 아이디는 이미 등록 되어 사용 불가 합니다.");
                    }
                }
                else
                {
                    txtUseYN.Text = "사용가능";
                    MessageBox.Show("해당 이메일 아이디는 사용 가능 합니다. 패스워드 등록 후 프로그램 사용 신청 하시면 됩니다.");
                }

            }

            Conn.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            button3.Visible = true;
            btnIns.Visible = true;
            panel3.Visible = true;
            panel1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            get_ws_template(cmbGroupNo, "Y");
        }

        private void get_ws_template(ComboBox tCmb, string tWSK)
        {
            //tField1 = 검색테이블
            //tField2 = 검색필드1
            //tField3 = 검색필드2



            Conn = new OleDbConnection(connect_string);

            string query = "";

            query = "  select groupNo , groupName from groupMaster ";
            query = query + " where appId  = '" + txtAppId.Text + "'";
            query = query + "      order by groupNo ";

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

        private void cmbGroupNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGroupNo.Text = cmbGroupNo.Text.Substring(0, cmbGroupNo.Text.IndexOf(' '));
        }
    }
}
