using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using userManagement;
using System.Data.OleDb;
using System.ComponentModel.DataAnnotations;
using PQMS.C.Unit;

namespace PQMS
{
    public partial class Form1 : Form
    {
        private MainForm MainFrmLogin;
        private Form2 frm2;
        private frmUserIdRequest frmUserIdRequest1;
        //private Form1PQMS_Repo Form1RepoSet;

        private OleDbConnection Conn;
        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";

        public string userId = "";
        public string loginId = "";
        public string appId = "PQMS";
        public string accountNo = "";

        public Form1()
        {
            InitializeComponent();
            Initialize();
            //menuStrip1.Visible = false;
        }

        private void Initialize()
        {
            MainFrmLogin = new MainForm();
            frm2 = new Form2();
            frmUserIdRequest1 = new frmUserIdRequest();
            //Form1RepoSet = new Form1PQMS_Repo();
        }

        public bool Call_formIsExist(Type tp)
        {
            return formIsExist(tp);
        }

        // 자식 폼 중복 여부
        private bool formIsExist(Type tp)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == tp)
                {
                    form.Activate();
                    form.BringToFront();
                    return true;
                }
            }
            return false;
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

        private void setDept()
        {
            Conn = new OleDbConnection(connect_string);
            loginId = txtStaffID.Text;

            string query = " select  top 1 a.SITE_CODE, a.REPOSITORY_CODE, a.WS_CODE, b.SITE_NAME, c.REPOSITORY_NAME, d.WS_NAME, a.FOLDER_CODE from accountStaffDept a " +
                            " inner join K_SITE b on a.SITE_CODE = b.SITE_CODE  and b.appNo = '3' " +
                            " inner join K_REPOSITORY c on a.SITE_CODE = c.SITE_CODE and a.REPOSITORY_CODE = c.REPOSITORY_CODE and c.appNo = '3' " +
                            " inner join K_WORKSPACE d on a.SITE_CODE = d.SITE_CODE and a.REPOSITORY_CODE = d.REPOSITORY_CODE and a.WS_CODE = d.WS_CODE and d.appNo = '3' " +
                            " where a.accountNo = '"+ MainFrmLogin.accountNo + "' ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        Form1PQMS_Repo.sSiteCode = reader.GetValue(0).ToString();
                        Form1PQMS_Repo.sRepo = reader.GetValue(1).ToString();
                        Form1PQMS_Repo.sWS = reader.GetValue(2).ToString();

                        Form1PQMS_Repo.sSiteCode_Name = reader.GetValue(3).ToString();
                        Form1PQMS_Repo.sRepo_Name = reader.GetValue(4).ToString();
                        Form1PQMS_Repo.sWS_Name = reader.GetValue(5).ToString();

                        Form1PQMS_Repo.sSTAFF_Folder = reader.GetValue(6).ToString();
                    }
                }
            }
            Conn.Close();




        }

        private void menuRoleSet()
        {
            //ToolStripMenuItem menuItem = (ToolStripMenuItem)menuStrip1.Items["MenuRole0040001" + "ToolStripMenuItem"];
            //menuItem.Visible = false;

            List<ToolStripMenuItem> myItems = GetItems(this.menuStrip1);

            foreach (var item in myItems) //로그아웃 후 재로그인 시 메뉴롤 리셋 
            {
                item.Visible = true;
            }

            Conn = new OleDbConnection(connect_string);
            loginId = txtStaffID.Text;

            string query = " select  replace(t5.menuname, ' ' ,'') as menuid,                   " +
                           "         t4.visible, t4.search, t4.[update], t4.[delete], t4.excel, " +
                           "         t4.download, t4.upload 								    " +
                           "        from accountMaster as t1 with(nolock)                       " +
                           "        inner join groupmembermaster as t2 with(nolock)             " +
                           "        on  t1.accountNo = t2.accountNo                             " +
                           "        and t1.disuse <> '1'                                        " +
                           "        and t2.disuse <> '1'                                        " +
                           "        inner join groupmaster as t3 with(nolock)                   " +
                           "        on t2.groupNo = t3.groupNo                                  " +
                           "        and t3.disuse <> '1'                                        " +
                           "        inner join menurole as t4 with(nolock)                      " +
                           "        on t3.groupNo = t4.groupNo                                  " +
                           "        and t4.disuse <> '1'                                        " +
                           "        inner join menumaster as t5 with(nolock)                    " +
                           "        on t4.menuno = t5.menuNo                                    " +
                           "        and t5.disuse <> '1'                                        " +
                           "        where                                                       " +
                           "            t1.appID = '" + appId + "'                              " +
                         //"        t1.appID = 'USERMANAGEMENT'                                 " +
                           "        and t1.loginID = '" + loginId + "'                          ";

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
                            if (item.Name.Contains(reader.GetValue(0).ToString() + "ToolStripMenuItem") && reader.GetValue(1).ToString() == "False")
                            {
                                item.Visible = false;
                            }                            
                        }
                    }
                }
                else 
                {
                    foreach (var item in myItems)
                    {                       
                        item.Visible = true;                        
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

        private void staffRoleSet()
        {
            Conn = new OleDbConnection(connect_string);
            loginId = txtStaffID.Text;

            string query = " SELECT * " +
                           " FROM[accountMaster].[dbo].[groupMaster] AS A " +
                           " INNER JOIN groupMemberMaster AS b " +
                           " ON a.groupNo = b.groupNo " +
                           " INNER JOIN accountMaster AS c " +
                           " ON b.accountNo = c.accountNo " +
                           " WHERE c.appID = '" + appId + "' AND c.loginID = '" + loginId + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    int i = 0;
                    while (reader.Read())
                    {   
                        i = i + 1;
                        if (reader.GetName(i).Equals("groupName"))
                        {
                            Form2PQMS_LoginInfo.sGroupName = reader.GetValue(i).ToString();
                        }
                    }
                    i = 0;
                }
            }
            Conn.Close();

            if (Form2PQMS_LoginInfo.sGroupName == null)
            {
                Form2PQMS_LoginInfo.sGroupName = "PQMS_KR_User";
            }
        }

        private void 자격증등록ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 child4 = new Form4();
            if (formIsExist(child4.GetType()))
            {
                child4.Dispose();     // 창 리소스 제거
            }
            else
            {
                child4.MdiParent = this;
                child4.WindowState = FormWindowState.Maximized;
                child4.Show();
            }
        }

        private void 직무코드관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 child5 = new Form13();
            if (formIsExist(child5.GetType()))
            {
                child5.Dispose();     // 창 리소스 제거
            }
            else
            {
                child5.MdiParent = this;
                child5.WindowState = FormWindowState.Maximized;
                child5.Show();
            }
        }

        private void 주관기관관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 child6 = new Form5();
            if (formIsExist(child6.GetType()))
            {
                child6.Dispose();     // 창 리소스 제거
            }
            else
            {
                child6.MdiParent = this;
                child6.WindowState = FormWindowState.Maximized;
                child6.Show();
            }
        }

        private void 교육명관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 child7 = new Form6();
            if (formIsExist(child7.GetType()))
            {
                child7.Dispose();     // 창 리소스 제거
            }
            else
            {
                child7.MdiParent = this;
                child7.WindowState = FormWindowState.Maximized;
                child7.Show();
            }
        }

        private void 직무임명관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form7 child8 = new Form7();
            if (formIsExist(child8.GetType()))
            {
                child8.Dispose();     // 창 리소스 제거
            }
            else
            {
                child8.MdiParent = this;
                child8.WindowState = FormWindowState.Maximized;
                child8.Show();
            }
        }

        private void 보수교육유효기간관리기준ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 child9 = new Form8();
            if (formIsExist(child9.GetType()))
            {
                child9.Dispose();     // 창 리소스 제거
            }
            else
            {
                child9.MdiParent = this;
                child9.WindowState = FormWindowState.Maximized;
                child9.Show();
            }
        }

        private void 대분류관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 child10 = new Form9();
            if (formIsExist(child10.GetType()))
            {
                child10.Dispose();     // 창 리소스 제거
            }
            else
            {
                child10.MdiParent = this;
                child10.WindowState = FormWindowState.Maximized;
                child10.Show();
            }
        }

        private void 중분류관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 child11 = new Form10();
            if (formIsExist(child11.GetType()))
            {
                child11.Dispose();     // 창 리소스 제거
            }
            else
            {
                child11.MdiParent = this;
                child11.WindowState = FormWindowState.Maximized;
                child11.Show();
            }
        }

        private void 조직관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 child12 = new Form11();
            if (formIsExist(child12.GetType()))
            {
                child12.Dispose();     // 창 리소스 제거
            }
            else
            {
                child12.MdiParent = this;
                child12.WindowState = FormWindowState.Maximized;
                child12.Show();
            }
        }

        private void 교육명등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 교육관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 child2 = new Form3();
            if (formIsExist(child2.GetType()))
            {
                child2.Dispose();     // 창 리소스 제거
            }
            else
            {
                child2.MdiParent = this;
                child2.WindowState = FormWindowState.Maximized;
                child2.Show();
            }
        }

        private void 자격증고나리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 child4 = new Form4();
            if (formIsExist(child4.GetType()))
            {
                child4.Dispose();     // 창 리소스 제거
            }
            else
            {
                child4.MdiParent = this;
                child4.WindowState = FormWindowState.Maximized;
                child4.Show();
            }
        }

        private void 직무임명관리ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form7 child8 = new Form7();
            if (formIsExist(child8.GetType()))
            {
                child8.Dispose();     // 창 리소스 제거
            }
            else
            {
                child8.MdiParent = this;
                child8.WindowState = FormWindowState.Maximized;
                child8.Show();
            }
        }

        private void 대분류ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 child10 = new Form9();
            if (formIsExist(child10.GetType()))
            {
                child10.Dispose();     // 창 리소스 제거
            }
            else
            {
                child10.MdiParent = this;
                child10.WindowState = FormWindowState.Maximized;
                child10.Show();
            }
        }

        private void 중분류관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form10 child11 = new Form10();
            if (formIsExist(child11.GetType()))
            {
                child11.Dispose();     // 창 리소스 제거
            }
            else
            {
                child11.MdiParent = this;
                child11.WindowState = FormWindowState.Maximized;
                child11.Show();
            }
        }

        private void 실무조직관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 child12 = new Form11();
            if (formIsExist(child12.GetType()))
            {
                child12.Dispose();     // 창 리소스 제거
            }
            else
            {
                child12.MdiParent = this;
                child12.WindowState = FormWindowState.Maximized;
                child12.Show();
            }
        }

        private void 주관기관관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 child6 = new Form5();
            if (formIsExist(child6.GetType()))
            {
                child6.Dispose();     // 창 리소스 제거
            }
            else
            {
                child6.MdiParent = this;
                child6.WindowState = FormWindowState.Maximized;
                child6.Show();
            }
        }

        private void 교육명관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form6 child7 = new Form6();
            if (formIsExist(child7.GetType()))
            {
                child7.Dispose();     // 창 리소스 제거
            }
            else
            {
                child7.MdiParent = this;
                child7.WindowState = FormWindowState.Maximized;
                child7.Show();
            }
        }

        private void 직무코드관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form13 child5 = new Form13();
            if (formIsExist(child5.GetType()))
            {
                child5.Dispose();     // 창 리소스 제거
            }
            else
            {
                child5.MdiParent = this;
                child5.WindowState = FormWindowState.Maximized;
                child5.Show();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (MainFrmLogin.Call_Login_Chk(txtStaffID.Text, txtStaffPWD.Text).Equals("Success"))
            {
                //Success_login();
            }
            else 
            {
                //MessageBox.Show("로그인 실패!");
            }

            //login_chk2();
            //if (version_chk() == true) //버전정보 확인 DB에 저장되어 있는 버전과 실행버전이 다르면 실행 불가
            //{
            //    login_chk();
            //}
        }

        //private void login_chk2()
        //{
        //    if (txtStaffID.Text == "user" && txtStaffPWD.Text == "1234")
        //    {
        //        panel1.Visible = false;
        //        menuStrip1.Visible = true;

        //        //dashBoardToolStripMenuItem.Visible = false;
        //        //기초정보관리ToolStripMenuItem.Visible = false;
        //        //workSpace관리ToolStripMenuItem1.Visible = false;
        //        //workSpace설정ToolStripMenuItem.Visible = false;
        //        //licenceToolStripMenuItem.Visible = false;
        //        //oGCToolStripMenuItem.Visible = false;

        //        Form2 child1 = new Form2();
        //        if (formIsExist(child1.GetType()))
        //        {
        //            child1.Dispose();     // 창 리소스 제거
        //        }
        //        else
        //        {
        //            child1.MdiParent = this;
        //            child1.WindowState = FormWindowState.Maximized;
        //            child1.Show();
        //        }
        //    }
        //    else if (txtStaffID.Text == "admin" && txtStaffPWD.Text == "admin")
        //    {
        //        panel1.Visible = false;
        //        menuStrip1.Visible = true;

        //        Form2 child1 = new Form2();
        //        if (formIsExist(child1.GetType()))
        //        {
        //            child1.Dispose();     // 창 리소스 제거
        //        }
        //        else
        //        {
        //            child1.MdiParent = this;
        //            child1.WindowState = FormWindowState.Maximized;
        //            child1.Show();
        //        }
        //    }
        //    // 테스트 할 때
        //    //else if (txtStaffID.Text == "" && txtStaffPWD.Text == "")
        //    //{
        //    //    panel1.Visible = false;
        //    //    menuStrip1.Visible = true;

        //    //    Form2 child1 = new Form2();
        //    //    if (formIsExist(child1.GetType()))
        //    //    {
        //    //        child1.Dispose();     // 창 리소스 제거
        //    //    }
        //    //    else
        //    //    {
        //    //        child1.MdiParent = this;
        //    //        child1.WindowState = FormWindowState.Maximized;
        //    //        child1.Show();
        //    //    }
        //    //}
        //    else
        //    {
        //        MessageBox.Show("로그인 하세요.");
        //    }

        //}

        //private void Success_login()
        //{
        //    panel1.Visible = false;
        //    menuStrip1.Visible = true;

        //    Form2 child1 = new Form2();
        //    if (formIsExist(child1.GetType()))
        //    {
        //        child1.Dispose();     // 창 리소스 제거
        //    }
        //    else
        //    {
        //        child1.MdiParent = this;
        //        child1.WindowState = FormWindowState.Maximized;
        //        child1.Show();
        //    }
        //}

        private void txtStaffPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (version_chk() == true)
                {
                    //if (MainFrmLogin.Call_Login_Chk(txtStaffID.Text, txtStaffPWD.Text).Equals("Success"))
                    //{
                    //    Success_login();
                    //}
                    //else
                    //{
                    //    //MessageBox.Show("로그인 실패!");
                    //}
                }
            }
        }

        private bool version_chk()
        {
            //Conn = new OleDbConnection(connect_string);


            //string query = " select * from Support_Version ";
            //OleDbCommand cmd = new OleDbCommand(query, Conn);

            //Conn.Open();

            //using (OleDbDataReader reader = cmd.ExecuteReader())
            //{
            //    if (reader.HasRows == true)
            //    {
            //        while (reader.Read())
            //        {
            //            if (reader.GetValue(0).ToString() != Application.ProductVersion)
            //            {
            //                MessageBox.Show("Version 정보 오류! 관리자에게 문의 하세요.");
            //                return false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Version 정보 오류");
            //        return false;
            //    }
            //}
            //Conn.Close();
            return true;

        }

        private void txtStaffPWD_TextChanged(object sender, EventArgs e)
        {

        }

        private void 부서직원관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["Form2_Anyang"];

            if (fc != null)
            {
                fc.Close();
            }

            Form2_Anyang child1 = new Form2_Anyang();
            if (formIsExist(child1.GetType()))
            {
                child1.Dispose();     // 창 리소스 제거
            }

            if (Form2PQMS_LoginInfo.sGroupName.Equals("PQMS_KR_Food"))
            {
                child1.MdiParent = this;
                child1.WindowState = FormWindowState.Maximized;
                child1.Food_Mgr_Mode();
                child1.Show();
            }
            else if (Form2PQMS_LoginInfo.sGroupName.Equals("PQMS_KR_User"))
            {
                child1.MdiParent = this;
                child1.WindowState = FormWindowState.Maximized;
                child1.Show();
            }
            else if (Form2PQMS_LoginInfo.sGroupName.Equals("PQMS_KR_ADM"))
            {
                child1.MdiParent = this;
                child1.WindowState = FormWindowState.Maximized;
                child1.Show();
            }
            else
            {
                MessageBox.Show("올바른 접근 경로가 아닙니다.");
            }
        }

        private void site관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSite child1 = new frmSite();
            if (formIsExist(child1.GetType()))
            {
                child1.Dispose();     // 창 리소스 제거
            }
            else
            {
                child1.MdiParent = this;
                child1.WindowState = FormWindowState.Maximized;
                child1.Show();
            }
        }

        private void repository관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepository child1 = new frmRepository();
            if (formIsExist(child1.GetType()))
            {
                child1.Dispose();     // 창 리소스 제거
            }
            else
            {
                child1.MdiParent = this;
                child1.WindowState = FormWindowState.Maximized;
                child1.Show();
            }
        }
        private void dept관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWSsetup child1 = new frmWSsetup();
            if (formIsExist(child1.GetType()))
            {
                child1.Dispose();     // 창 리소스 제거
            }
            else
            {
                child1.MdiParent = this;
                child1.WindowState = FormWindowState.Maximized;
                child1.Show();
            }
        }


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(cmbWS.Text))
            //{
            //    MessageBox.Show("부서를 선택해주세요!");
            //}
            //MessageBox.Show((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]);
            //if ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1] == "hyemi_ji" && txtStaffID.Text == "")
            if ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1] == "hiel_kim" && txtStaffID.Text == "")
            {
                txtStaffID.Text = "admin_anyang@sgs.com";
                txtStaffPWD.Text = "1234";
            } 

            if (string.IsNullOrEmpty(txtStaffID.Text) == true || string.IsNullOrEmpty(txtStaffPWD.Text) == true)
            {
                MessageBox.Show("ID 또는 Password를 입력해주세요.");
            }
            else
            {
                if (MainFrmLogin.Call_Login_Chk(txtStaffID.Text, txtStaffPWD.Text).Equals("Success"))
                {
                    txtSiteCode.Text = cmbSiteCode.Text.Substring(0, 4);
                    txtSiteName.Text = cmbSiteCode.Text.Substring(5, cmbSiteCode.Text.Length - 5);

                    btnRepo.PerformClick();

                    txtRepoCode.Text = cmbRepo.Text.Substring(0, 4);
                    txtRepoName.Text = cmbRepo.Text.Substring(5, cmbRepo.Text.Length - 5);

                    btnWS.PerformClick();

                    txtWSCode.Text = cmbWS.Text.Substring(0, 5);
                    txtWSName.Text = cmbWS.Text.Substring(6, cmbWS.Text.Length - 6);

                    //Form1PQMS_Repo.sSiteCode = txtSiteCode.Text;
                    //Form1PQMS_Repo.sRepo = txtRepoCode.Text;
                    //Form1PQMS_Repo.sWS = txtWSCode.Text;

                    //Form1PQMS_Repo.sSiteCode_Name = txtSiteName.Text;
                    //Form1PQMS_Repo.sRepo_Name = txtRepoName.Text;
                    //Form1PQMS_Repo.sWS_Name = txtWSName.Text;

                    SuccessLogin();
                }
            }
        }

        public void SuccessLogin()
        {
            userId = txtStaffID.Text;
            loginId = txtStaffID.Text;
            appId = "PQMS";

            Form2PQMS_LoginInfo.sloginId = loginId;
            Form2PQMS_LoginInfo.sAccountNo = MainFrmLogin.accountNo;
            Form2PQMS_LoginInfo.sUserId = userId;
            Form2PQMS_LoginInfo.sAppId = appId;
            Form2PQMS_LoginInfo.sEmpNo = MainFrmLogin.empno;

            panel1.Visible = false;
            menuStrip1.Visible = true;
            menuRoleSet();

            // 직원별 권한
            staffRoleSet();


            //직원 부서 연결 (site, repository, workspace)
            setDept();           
           
            Form2_Anyang child1 = new Form2_Anyang();

            if (formIsExist(child1.GetType()))
            {
                child1.Dispose();     // 창 리소스 제거
            }


            if (Form2PQMS_LoginInfo.sGroupName == null)
            {
                MessageBox.Show("D&I에게 문의 하세요.");
            }
            else
            {
                // 직원별 권한에 따라서 출력되는 화면이 다름.
                if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("FOOD"))
                {
                    child1.MdiParent = this;
                    child1.WindowState = FormWindowState.Maximized;
                    child1.Food_Mgr_Mode();
                    child1.Show();
                }
                else if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
                {
                    child1.MdiParent = this;
                    child1.WindowState = FormWindowState.Maximized;
                    child1.Show();
                }
                else if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("ADM"))
                {
                    child1.MdiParent = this;
                    child1.WindowState = FormWindowState.Maximized;
                    child1.Show();
                }
                else if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("DEPT"))
                {
                    child1.MdiParent = this;
                    child1.WindowState = FormWindowState.Maximized;
                    child1.Show();
                }
                else
                {
                    MessageBox.Show("올바른 접근 경로가 아닙니다.");
                }
            }        
           


            ////jhm from 호출 ( form2 tab 소스 분할 진행 중)
            //frmStaffInfoAll chilefrm = new frmStaffInfoAll();
            //chilefrm.MdiParent = this;
            //chilefrm.WindowState = FormWindowState.Maximized;
            //chilefrm.Show();


        }

        private void txtStaffPWD_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                // Perform your action here
                btnLogIn_Click(sender, e);
            }


            //if (e.KeyChar == 13)
            //{
            //    if (version_chk() == true)
            //    {
            //        if (MainFrmLogin.Call_Login_Chk(txtStaffID.Text, txtStaffPWD.Text).Equals("Success"))
            //        {
            //            SuccessLogin();
            //        }
            //        else
            //        {
            //            //MessageBox.Show("로그인 실패!");
            //        }
            //    }
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPwChange_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("준비중 입니다. PW 변경은 D&I 부서에 문의해 주세요");
            panel1.Visible = false;
            panel2.Visible = true;

        }

        private void btnAccRequst_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            //panel3.Visible = true;

            // 가운데 정렬
            //panel3.Left = (this.ClientSize.Width - panel3.Width) / 2;
            //panel3.Top = (this.ClientSize.Height - panel3.Height) / 2;

            frmMemberRequest frmMemberRequest = new frmMemberRequest(this);
            if (formIsExist(frmMemberRequest.GetType()))
            {
                frmMemberRequest.Dispose();     // 창 리소스 제거
            }
            else
            {
                frmMemberRequest.MdiParent = this;
                frmMemberRequest.WindowState = FormWindowState.Normal;
                frmMemberRequest.Show();                
            }
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

        private void btnRegCheckCancel_Click(object sender, EventArgs e)
        {
            txtUserId.Text = "";
            txtLogInId.Text = "";

            panel3.Visible = false;
            panel1.Visible = true;
        }
        
        private void btnSiteCode_Click(object sender, EventArgs e)
        {
            frm2.Call_get_comb_data("K_SITE", "SITE_CODE", "SITE_NAME", "", "", cmbSiteCode);
        }

        private void btnRepo_Click(object sender, EventArgs e)
        {
            frm2.Call_get_comb_data("K_REPOSITORY", "REPOSITORY_CODE", "REPOSITORY_NAME", "SITE_CODE", txtSiteCode.Text, cmbRepo);
        }

        private void cmbSiteCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSiteCode.Text = cmbSiteCode.Text.Substring(0, 4);
            txtSiteName.Text = cmbSiteCode.Text.Substring(5, cmbSiteCode.Text.Length - 5);

            btnRepo.PerformClick();
        }

        private void btnWS_Click(object sender, EventArgs e)
        {
            frm2.Call_get_ws_data("K_WORKSPACE", "WS_CODE", "WS_NAME", cmbWS, txtSiteCode.Text, txtRepoCode.Text);
        }

        private void cmbRepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRepoCode.Text = cmbRepo.Text.Substring(0, 4);
            txtRepoName.Text = cmbRepo.Text.Substring(5, cmbRepo.Text.Length - 5);

            btnWS.PerformClick();
        }

        private void cmbWS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWSCode.Text = cmbWS.Text.Substring(0, 5);
            txtWSName.Text = cmbWS.Text.Substring(6, cmbWS.Text.Length - 6);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;

            panel2.Left = (this.ClientSize.Width - panel2.Width) / 2;
            panel2.Top = (this.ClientSize.Height - panel2.Height) / 2;

            panel3.Left = (this.ClientSize.Width - panel3.Width) / 2;
            panel3.Top = (this.ClientSize.Height - panel3.Height) / 2;           

            btnSiteCode.PerformClick();

            string version = GetPublishVersion();

            this.Text = "NEW PQMS_" + version;



            if ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1] != "hyemi_ji")
            {
                string PC_LOGIN_USER_NAME = (System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1].ToString().ToString().Replace("_", ".");

                txtStaffID.Text = PC_LOGIN_USER_NAME + "@sgs.com";
                txtStaffPWD.Focus();

            }
            else
            {
                txtStaffPWD.Focus();
            }

        }

        private void 직무기술서관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmJobDescription childJobDescription = new frmJobDescription();
            if (formIsExist(childJobDescription.GetType()))
            {
                childJobDescription.Dispose();     // 창 리소스 제거
            }
            else
            {
                childJobDescription.MdiParent = this;
                childJobDescription.WindowState = FormWindowState.Maximized;
                childJobDescription.Show();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;

            //panel7.Left = (this.ClientSize.Height - panel7.Height) / 2;
            //panel7.Top = (this.ClientSize.Height - panel7.Height) / 2;

            if (panel2.Visible == true) 
            {
                panel2.Left = (this.ClientSize.Width - panel2.Width) / 2;
                panel2.Top = (this.ClientSize.Height - panel2.Height) / 2;
            }

            if (panel3.Visible == true)
            {
                panel3.Left = (this.ClientSize.Width - panel3.Width) / 2;
                panel3.Top = (this.ClientSize.Height - panel3.Height) / 2;
            }
        }

        private void btnLogIn_MouseUp(object sender, MouseEventArgs e)
        {
            btnLogIn.FlatStyle = FlatStyle.Flat;
        }

        private void 조직도생성ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmRoleOrgChart childfrmRoleOrgChart = new frmRoleOrgChart();

            frmOrgChart childfrmRoleOrgChart = new frmOrgChart();

            if (formIsExist(childfrmRoleOrgChart.GetType()))
            {
                childfrmRoleOrgChart.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmRoleOrgChart.MdiParent = this;
                childfrmRoleOrgChart.WindowState = FormWindowState.Maximized;
                childfrmRoleOrgChart.Show();
            }
        }

        private void 보고서양식관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport childfrmReport = new frmReport();
            if (formIsExist(childfrmReport.GetType()))
            {
                childfrmReport.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmReport.MdiParent = this;
                childfrmReport.WindowState = FormWindowState.Maximized;
                childfrmReport.Show();
            }
        }

        private void 임명장관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLOP childfrmLOP = new frmLOP();
            if (formIsExist(childfrmLOP.GetType()))
            {
                childfrmLOP.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmLOP.MdiParent = this;
                childfrmLOP.WindowState = FormWindowState.Maximized;
                childfrmLOP.Show();
            }
        }

        private void 사용자승인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserIdRequest childfrmUserIdRequest = new frmUserIdRequest();
            if (formIsExist(childfrmUserIdRequest.GetType()))
            {
                childfrmUserIdRequest.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmUserIdRequest.MdiParent = this;
                childfrmUserIdRequest.WindowState = FormWindowState.Maximized;
                childfrmUserIdRequest.Show();
            }
        }

        private void 사용자별메뉴지정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGroupMemberMaster childfrmGroupMemberMaster = new frmGroupMemberMaster();
            if (formIsExist(childfrmGroupMemberMaster.GetType()))
            {
                childfrmGroupMemberMaster.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmGroupMemberMaster.MdiParent = this;
                childfrmGroupMemberMaster.WindowState = FormWindowState.Maximized;
                childfrmGroupMemberMaster.Show();
            }
        }

        private void 임명장임명분야관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLOPDescription childfrmLOPDescription = new frmLOPDescription();
            if (formIsExist(childfrmLOPDescription.GetType()))
            {
                childfrmLOPDescription.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmLOPDescription.MdiParent = this;
                childfrmLOPDescription.WindowState = FormWindowState.Maximized;
                childfrmLOPDescription.Show();
            }
        }

        private void 수정요청변경ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditRequest childEditFrm = new frmEditRequest();
            if (formIsExist(childEditFrm.GetType()))
            {
                childEditFrm.Dispose();     // 창 리소스 제거
            }
            else
            {
                childEditFrm.MdiParent = this;
                childEditFrm.WindowState = FormWindowState.Maximized;
                childEditFrm.Show();
            }
        }

        private void btnPwChangeSubmit_Click(object sender, EventArgs e)
        {
            Conn = new OleDbConnection(connect_string);
            string sSQL = "select * from accountMaster with (nolock) where appID = '" + appId + "' and logInID = '" + txtStaffID2.Text + "' and passWord = '" + txtOldpwd.Text + "'";
            OleDbCommand cmd = new OleDbCommand(sSQL, Conn);

            Conn.Open();

            DataTable dt = new DataTable();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);                    
                }
            }

            if (dt.Rows.Count > 0)
            {
                sSQL = "update accountMaster set passWord='" + txtNewPwd.Text + "' where appID = '" + appId + "' and logInID = '" + txtStaffID2.Text + "' and passWord = '" + txtOldpwd.Text + "'";
                cmd = new OleDbCommand(sSQL, Conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("변경완료");
                panel2.Visible = false;
                panel1.Visible = true;

                txtStaffID2.Text = "";
                txtOldpwd.Text = "";
                txtNewPwd.Text = "";

            }
            else
            {
                MessageBox.Show("사용자 계정 오류!");
                return;
            }

            Conn.Close();
        }

        private void btnPwChangeCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;

            txtStaffID2.Text = "";
            txtOldpwd.Text = "";
            txtNewPwd.Text = "";
        }

        private void 승인권자설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmApproveSetting childfrmApproveSetting = new frmApproveSetting();

            frmMasterApproveRole childfrmApproveSetting = new frmMasterApproveRole();
            if (formIsExist(childfrmApproveSetting.GetType()))
            {
                childfrmApproveSetting.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmApproveSetting.MdiParent = this;
                childfrmApproveSetting.WindowState = FormWindowState.Maximized;
                childfrmApproveSetting.Show();
            }
        }

        private void 사용자승인권자지정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountApproveRole childfrmAccountApproveRoleg = new frmAccountApproveRole();
            if (formIsExist(childfrmAccountApproveRoleg.GetType()))
            {
                childfrmAccountApproveRoleg.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmAccountApproveRoleg.MdiParent = this;
                childfrmAccountApproveRoleg.WindowState = FormWindowState.Maximized;
                childfrmAccountApproveRoleg.Show();
            }
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close(); // 현재 폼 종료, Application.Restart만 하니깐 현재 폼이 안죽음
            //Application.Restart(); //

            //FormCollection fc = Application.OpenForms;

            //foreach (Form frm in fc)
            //{
            //    if (frm.Name != "Form1")
            //    {
            //        frm.Close();
            //    }
            //}

            foreach (Form fm in this.MdiChildren)
            {
                fm.Dispose();
                menuStrip1.Visible = false;
            }

            txtStaffID.Text = "";
            txtStaffPWD.Text = "";
            panel1.Visible = true;

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStaffInfoAll childfrmStaffInfoAll = new frmStaffInfoAll();
            childfrmStaffInfoAll.Owner = this;

            if (formIsExist(childfrmStaffInfoAll.GetType()))
            {
                childfrmStaffInfoAll.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmStaffInfoAll.MdiParent = this;
                childfrmStaffInfoAll.WindowState = FormWindowState.Maximized;
                childfrmStaffInfoAll.Show();
            }

        }

        public string GetPublishVersion()
        {
            string strVersion;         
            strVersion = string.Format(" Version : {0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
            return strVersion;
        }
        


    }
}
