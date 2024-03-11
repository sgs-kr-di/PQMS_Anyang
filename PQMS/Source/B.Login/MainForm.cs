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
//using static userManagement.global;


namespace userManagement
{
    public partial class MainForm : Form
    {

        public string userId = "";
        public string loginId = "";
        public string appId = "PQMS";
        public string accountNo = "";
        public string empno = "";


        public MainForm()
        {
            InitializeComponent();

            panel1.Top = 160;
            panel1.Left = 348;

            menuStrip1.Visible = false;

        }

        private OleDbConnection Conn;

        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";

        /*
        private string userId = string.Empty;
        private string logInId = string.Empty;
        private string appId = string.Empty;
        */

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUserMaster frmUserMaster = new frmUserMaster();
            frmUserMaster.MdiParent = this;

            //frmUserMaster.loginId = loginId;
            //frmUserMaster.accountNo = accountNo;
            //frmUserMaster.userId = userId;
            //frmUserMaster.appId = appId;

            frmUserMaster.Show();
            frmUserMaster.WindowState = FormWindowState.Maximized;
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountMaster frmAccountMaster = new frmAccountMaster();
            frmAccountMaster.MdiParent = this;

            //frmAccountMaster.loginId = loginId;
            //frmAccountMaster.accountNo = accountNo;
            //frmAccountMaster.userId = userId;
            //frmAccountMaster.appId = appId;

            frmAccountMaster.Show();
            frmAccountMaster.WindowState = FormWindowState.Maximized;
        }

        private void deptMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeptMaster frmDeptMaster = new frmDeptMaster();
            frmDeptMaster.MdiParent = this;

            //frmDeptMaster.loginId = loginId;
            //frmDeptMaster.accountNo = accountNo;
            //frmDeptMaster.userId = userId;
            //frmDeptMaster.appId = appId;

            frmDeptMaster.Show();
            frmDeptMaster.WindowState = FormWindowState.Maximized;
        }

        private void appMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppMaster frmAppMaster = new frmAppMaster();
            frmAppMaster.MdiParent = this;

            frmAppMaster.loginId = loginId;
            frmAppMaster.accountNo = accountNo;
            frmAppMaster.userId = userId;
            frmAppMaster.appId = appId;

            frmAppMaster.Show();
            frmAppMaster.WindowState = FormWindowState.Maximized;
        }

        private void groupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmGroupMaster frmGroupMaster = new frmGroupMaster();
            frmGroupMaster.MdiParent = this;

            frmGroupMaster.loginId = loginId;
            frmGroupMaster.accountNo = accountNo;
            frmGroupMaster.userId = userId;
            frmGroupMaster.appId = appId;

            frmGroupMaster.Show();
            frmGroupMaster.WindowState = FormWindowState.Maximized;
        }

        private void groupMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGroupMemberMaster frmGroupMemberMaster = new frmGroupMemberMaster();
            frmGroupMemberMaster.MdiParent = this;

            frmGroupMemberMaster.loginId = loginId;
            frmGroupMemberMaster.accountNo = accountNo;
            frmGroupMemberMaster.userId = userId;
            frmGroupMemberMaster.appId = appId;

            frmGroupMemberMaster.Show();
            frmGroupMemberMaster.WindowState = FormWindowState.Maximized;
        }

        private void codeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCodeMaster frmCodeMaster = new frmCodeMaster();
            frmCodeMaster.MdiParent = this;

            //frmCodeMaster.loginId = loginId;
            //frmCodeMaster.accountNo = accountNo;
            //frmCodeMaster.userId = userId;
            //frmCodeMaster.appId = appId;

            frmCodeMaster.Show();
            frmCodeMaster.WindowState = FormWindowState.Maximized;
        }

        private void requestStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginId != "")
            {
                frmRequestStatus frmRequstStatus = new frmRequestStatus();
                frmRequstStatus.MdiParent = this;


                frmRequstStatus.loginId = loginId;
                frmRequstStatus.accountNo = accountNo;
                frmRequstStatus.userId = userId;
                frmRequstStatus.appId = appId;

                frmRequstStatus.Show();
                frmRequstStatus.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPwChange_Click(object sender, EventArgs e)
        {
            MessageBox.Show("준비중 입니다. PW 변경은 D&I 부서에 문의해 주세요");
            
            //아직 준비중...
            /*
            panel1.Visible = false;
            panel2.Visible = true;
            panel2.Top = 160;
            panel2.Left = 348;
            */
        }

        private void btnAccRequst_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel3.Top = 160;
            panel3.Left = 348;
        }

        private void btnPwChangeCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void btnRegCheckCancel_Click(object sender, EventArgs e)
        {
            txtUserId.Text = "";
            txtLogInId.Text = "";

            panel3.Visible = false;
            panel1.Visible = true;
        }

        public void RegChk() 
        {
            //userid, loginid 동시 사용 버전일때 사용 코드 20220525 DH
            txtUserId.Text = txtLogInId.Text;

            if (txtUserId.Text.Trim() == "" && txtLogInId.Text.Trim() == "")
            {
                MessageBox.Show("아이디를 입력 하세요");
                return;
            }

            if (!new EmailAddressAttribute().IsValid(txtLogInId.Text))
            {
                MessageBox.Show("로그인 아이디는 E-Mail 형태로 등록해 주세요!");
                return;
            }

            Conn = new OleDbConnection(connect_string);

            string query = " select t1.userid, isnull(t2.logInID,'') as logInID " +
                            "from usermaster as T1 with(nolock) " +
                            "left join accountMaster t2 with(nolock) " +
                            "on  t1.userid = t2.userid " +
                            "and t2.logInID = '" + txtLogInId.Text.Trim() + "' " +
                            "and t2.appID = '" + appId + "' " +
                            "and t2.disuse = 0 " +
                            //"and t2.appid ='usermanagement' " +
                            "where 1=1 " +
                            "  and t1.userid = '" + txtUserId.Text.Trim() + "' " +
                            "  and t1.disuse = 0 ";


            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                //usermaster에 데이터 있는 경우
                if (reader.HasRows == true)
                {

                    reader.Read();

                    //accountMaster 테이블에 해당 app의 로그인 아이디가 존재 하는 경우
                    if (reader.GetValue(1).ToString() != "")
                    {
                        MessageBox.Show("이미 등록 되어 있습니다!");
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show(appId + " 프로그램에 계정이 없습니다. 등록 요청 하시겠습니까?"
                                                                  , "계정 등록 요청", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            panel3.Visible = false;

                            frmUserRequest frmUserRequest = new frmUserRequest(txtUserId.Text.Trim(), txtLogInId.Text.Trim(), appId, "accountN");

                            frmUserRequest.Show();

                            txtUserId.Text = "";
                            txtLogInId.Text = "";
                        }
                        else
                        {
                            panel3.Visible = false;
                            panel1.Visible = true;

                            txtUserId.Text = "";
                            txtLogInId.Text = "";
                        }
                    }

                }
                //usermaster, accountMaster 두 테이블 모두 데이터 없는 경우
                else
                {
                    DialogResult dialogResult = MessageBox.Show("사용자 정보 및 계정이 없습니다. 등록 요청 하시겠습니까?"
                                                              , "계정 등록 요청", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        panel3.Visible = false;

                        frmUserRequest frmUserRequest = new frmUserRequest(txtUserId.Text.Trim(), txtLogInId.Text.Trim(), appId, "userNaccountN");
                        frmUserRequest.Show();
                        txtUserId.Text = "";
                        txtLogInId.Text = "";
                    }
                    else
                    {
                        panel3.Visible = false;
                        panel1.Visible = true;

                        txtUserId.Text = "";
                        txtLogInId.Text = "";
                    }
                }
            }

            Conn.Close();
        }

        private void btnRegCheck_Click(object sender, EventArgs e)
        {
            //userid, loginid 동시 사용 버전일때 사용 코드 20220525 DH
            txtUserId.Text = txtLogInId.Text;

            if (txtUserId.Text.Trim() == "" && txtLogInId.Text.Trim() == "")
            {
                MessageBox.Show("아이디를 입력 하세요");
                return;
            }

            if (!new EmailAddressAttribute().IsValid(txtLogInId.Text))
            {
                MessageBox.Show("로그인 아이디는 E-Mail 형태로 등록해 주세요!");
                return;
            }

            Conn = new OleDbConnection(connect_string);

            string query = " select t1.userid, isnull(t2.logInID,'') as logInID " +
                            "from usermaster as T1 with(nolock) " +
                            "left join accountMaster t2 with(nolock) " +
                            "on  t1.userid = t2.userid " +
                            "and t2.logInID = '" + txtLogInId.Text.Trim() + "' " +
                            "and t2.appID = '" + appId + "' " +
                            "and t2.disuse = 0 " +
                            //"and t2.appid ='usermanagement' " +
                            "where 1=1 " +
                            "  and t1.userid = '" + txtUserId.Text.Trim() + "' " +
                            "  and t1.disuse = 0 ";


            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                //usermaster에 데이터 있는 경우
                if (reader.HasRows == true)
                {
                    
                    reader.Read();

                    //accountMaster 테이블에 해당 app의 로그인 아이디가 존재 하는 경우
                    if (reader.GetValue(1).ToString() != "")
                    {
                        MessageBox.Show("이미 등록 되어 있습니다!");
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show(appId + " 프로그램에 계정이 없습니다. 등록 요청 하시겠습니까?"
                                                                  , "계정 등록 요청", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            panel3.Visible = false;

                            frmUserRequest frmUserRequest = new frmUserRequest(txtUserId.Text.Trim(), txtLogInId.Text.Trim(), appId, "accountN");

                            frmUserRequest.Show();

                            txtUserId.Text = "";
                            txtLogInId.Text = "";
                        }
                        else
                        {
                            panel3.Visible = false;
                            panel1.Visible = true;

                            txtUserId.Text = "";
                            txtLogInId.Text = "";
                        }
                    }

                }
                //usermaster, accountMaster 두 테이블 모두 데이터 없는 경우
                else
                {
                    DialogResult dialogResult = MessageBox.Show("사용자 정보 및 계정이 없습니다. 등록 요청 하시겠습니까?"
                                                              , "계정 등록 요청", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        panel3.Visible = false;

                        frmUserRequest frmUserRequest = new frmUserRequest(txtUserId.Text.Trim(), txtLogInId.Text.Trim(), appId, "userNaccountN");
                        frmUserRequest.Show();
                        txtUserId.Text = "";
                        txtLogInId.Text = "";
                    }
                    else
                    {
                        panel3.Visible = false;
                        panel1.Visible = true;

                        txtUserId.Text = "";
                        txtLogInId.Text = "";
                    }
                }
            }

            Conn.Close();
        }

        private void menuMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenuMaster frmMenuMaster = new frmMenuMaster();
            frmMenuMaster.MdiParent = this;

            frmMenuMaster.loginId = loginId;
            frmMenuMaster.accountNo = accountNo;
            frmMenuMaster.userId = userId;
            frmMenuMaster.appId = appId;            

            frmMenuMaster.Show();
            frmMenuMaster.WindowState = FormWindowState.Maximized;
        }

        private void menuRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenuRole frmMenuRole = new frmMenuRole();
            frmMenuRole.MdiParent = this;

            frmMenuRole.loginId = loginId;
            frmMenuRole.accountNo = accountNo;
            frmMenuRole.userId = userId;
            frmMenuRole.appId = appId;

            frmMenuRole.Show();
            frmMenuRole.WindowState = FormWindowState.Maximized;
        }

        private void approveRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApproveRole frmApproveRole = new frmApproveRole();
            frmApproveRole.MdiParent = this;

            //frmApproveRole.loginId = loginId;
            //frmApproveRole.accountNo = accountNo;
            //frmApproveRole.userId = userId;
            //frmApproveRole.appId = appId;

            frmApproveRole.Show();
            frmApproveRole.WindowState = FormWindowState.Maximized;
        }

        public string Call_Login_Chk(string sID, string sPW)
        {
            return login_chk(sID, sPW);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Call_Login_Chk(txtStaffID.Text, txtStaffPWD.Text);
            // login_chk();
        }
        private void login_chk2()
        {
            userId = txtStaffID.Text;
            loginId = txtStaffID.Text;
            appId = "PQMS";

            menuStrip1.Visible = true;
            panel1.Visible = false;
        }

        private string login_chk(string sID = "", string sPW = "")
        {
            string sSuccess = "";
            accountNo = "";
            userId = "";
            loginId = "";
            appId = "PQMS";

            Conn = new OleDbConnection(connect_string);

            string query = " select a.accountNo, a.logInId, a.userId, a.appId, b.empID" +
                         "     from accountMaster a with(nolock) inner join userMaster b on a.userID = b.userID " +
                         "    where a.logInId = '" + sID + "' " +
                         "      and a.passWord = '" + sPW + "' " +
                         "      and a.appID = '" + appId + "' " +
                         "      and a.requestStatusCode ='approved'" +
                         "      and a.disuse <> 1 ";

             OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        panel1.Visible = false;

                        accountNo = reader.GetValue(0).ToString();
                        loginId = reader.GetValue(1).ToString();
                        userId = reader.GetValue(2).ToString();
                        appId = "PQMS";
                        empno = reader.GetValue(4).ToString();

                        //staff_id = reader.GetValue(0).ToString();
                        //Team_id = reader.GetValue(2).ToString();
                        //SubTeam_id = reader.GetValue(3).ToString();
                        //approver_id = reader.GetValue(1).ToString();
                        //stusername.Text = staff_id;
                        MessageBox.Show(userId + " 님이 로그인 했습니다.");

                        menuStrip1.Visible = true;
                        panel1.Visible = false;

                        break;

                        //menuRoleSet();
                    }
                    sSuccess = "Success";
                }
                else
                {
                    MessageBox.Show("아이디/패스워드 오류");
                    sSuccess = "Fail";
                }
            }
            Conn.Close();
            return sSuccess;

            //if (loginId != "")
            //{
            //    query = " select userid " +
            //    "     from Staff " +
            //    "    where approver like '%" + staff_id + "%' ";

            //    cmd = new OleDbCommand(query, Conn);

            //    Conn.Open();

            //    using (OleDbDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.HasRows == true)
            //        {
            //            while (reader.Read())
            //            {
            //                //주의 - 로그인한 사용자(staff_id)가 승인할 승인요청자(apppover_id)의 아이디 = approver_id 의 개념을 바꿈
            //                approver_id = approver_id + "," + reader.GetValue(0).ToString();

            //            }
            //        }
            //    }
            //    Conn.Close();
            //}
        }

        public static List<ToolStripMenuItem> GetItems(MenuStrip menuStrip)
        {
            List<ToolStripMenuItem> myItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem i in menuStrip.Items)
            {
                GetMenuItems(i, myItems);
            }
            return myItems;
        }

        private static void GetMenuItems(ToolStripMenuItem item, List<ToolStripMenuItem> items)
        {
            items.Add(item);
            foreach (ToolStripItem i in item.DropDownItems)
            {
                if (i is ToolStripMenuItem)
                {
                    GetMenuItems((ToolStripMenuItem)i, items);
                }
            }
        }

        private void menuRoleSet()
        {
            //ToolStripMenuItem menuItem = (ToolStripMenuItem)menuStrip1.Items["MenuRole0040001" + "ToolStripMenuItem"];
            //menuItem.Visible = false;

            List<ToolStripMenuItem> myItems = GetItems(this.menuStrip1);

            Conn = new OleDbConnection(connect_string);

            string query = " select  replace(t5.menuname, ' ' ,'')+t5.menuID as menuid, " +
                           "         t4.visible, t4.search, t4.[update], t4.[delete], t4.excel, " +
                           "         t4.download, t4.upload 								    " +
                           "        from accountMaster as t1 with(nolock)                       " +
                           "        inner join groupmembermaster as t2 with(nolock)             " +
                           "        on  t1.accountNo = t2.accountNo                             " +
                           "        and t1.disuse <> '1'                                         " +
                           "        and t2.disuse <> '1'                                         " +
                           "        inner join groupmaster as t3 with(nolock)                   " +
                           "        on t2.groupNo = t3.groupNo                                  " +
                           "        and t3.disuse <> '1'                                         " +
                           "        inner join menurole as t4 with(nolock)                      " +
                           "        on t3.groupNo = t4.groupNo                                  " +
                           "        and t4.disuse <> '1'                                        " +
                           "        inner join menumaster as t5 with(nolock)                    " +
                           "        on t4.menuno = t5.menuNo                                    " +
                           "        and t5.disuse <> '1'                                         " +
                           "        where                                                       " +
                           "            t1.appID = '" + appId + "' " +
//                           "        t1.appID = 'USERMANAGEMENT'                                 " +
                           "        and t1.loginID = '" + loginId  + "' ";


            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        foreach (var item in myItems)
                        {
                            if (item.Name == reader.GetValue(0).ToString() + "ToolStripMenuItem1" && reader.GetValue(1).ToString() == "False")
                            {
                                item.Visible = false;
                            }
                        }
                    }
                }
            }
            Conn.Close();


/*
            //메뉴 목록 뽑아내기
            List<ToolStripMenuItem> myItems = GetItems(this.menuStrip1);

            foreach (var item in myItems)
            {
                /MessageBox.Show(item.Name);
                //item.Visible = false;
            }
*/
/*          함수 안쓰고 메뉴 목록 뽑아 내기
            foreach (ToolStripMenuItem i in menuStrip1.Items)
            {
                foreach (ToolStripItem j in i.DropDownItems)
                {
                    if (j is ToolStripMenuItem)
                    {
                        MessageBox.Show(j.Name);
                    }
                }
            }
 */
        }


        private void userIdRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginId != "")
            {
                frmUserIdRequest frmUserIdRequest1 = new frmUserIdRequest();
                frmUserIdRequest1.MdiParent = this;


                frmUserIdRequest1.loginId = loginId;
                frmUserIdRequest1.accountNo = accountNo;
                frmUserIdRequest1.userId = userId;
                frmUserIdRequest1.appId = appId;

                frmUserIdRequest1.Show();
                frmUserIdRequest1.WindowState = FormWindowState.Maximized;
            }
        }

        private void txtStaffPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                login_chk();
            }
        }
    }
}
