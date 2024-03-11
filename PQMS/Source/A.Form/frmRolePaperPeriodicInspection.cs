using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PQMS.C.Unit;
using Spire.Doc;
using System.Data.SqlClient;

namespace PQMS
{
    public partial class frmRolePaperPeriodicInspection : Form
    {
        private UnitCommon unitCommon;
        private UnitSMTP unitSMTP;

        private OleDbConnection Conn;
        private Dictionary<string, string> comboBoxData = new Dictionary<string, string>();
        private Form2_Anyang parentForm;

        private string s_title = "";
        public int appNo = 0;
        public int MenuNo = 0;
        public int WorkNo = 0;
        public int accountNo = 0;
        public int requesteraccountNo = 0;
        public int approveraccountNo = 0;
        public string requesterDeptCode = "";        
        public string DeptNo = "";
        public string DeptNo2 = "";
        public string requestedby = "";
        public int approveDepth = 0;

        public frmRolePaperPeriodicInspection(Form2_Anyang parent)
        {
            InitializeComponent();
            Initialize();
            unitCommon = new UnitCommon();

            s_title = "부서관리-직무기술서-승인요청";
            this.parentForm = parent;

        }

        private void Initialize()
        {
            unitCommon = new UnitCommon();
            unitSMTP = new UnitSMTP();
        }


        private void get_folder_RolePaper(System.Windows.Forms.ComboBox tCmb) //jhm0708
        {

            Conn = new OleDbConnection(unitCommon.connect_string);
            string sql = $" SELECT ROLE_CODE , ROLE_NAME " +
                   $" FROM PQMS_ROLE2_CODE " +
                   $" where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' AND REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' AND WS_CODE = '" + Form1PQMS_Repo.sWS + "' " +
                   $" ORDER BY  CASE WHEN ROLE_CODE = 'P006' THEN 0 " +
                   $" WHEN ROLE_CODE = 'P001' THEN 1 " +
                   $" WHEN ROLE_CODE = 'P002' THEN 2 " +
                   $" WHEN ROLE_CODE = 'P003' THEN 3 " +
                   $" WHEN ROLE_CODE = 'P009' THEN 4 " +
                   $" WHEN ROLE_CODE = 'P004' THEN 5 " +
                   $" WHEN ROLE_CODE = 'P010' THEN 6 " +
                   $" ELSE 7 END, ROLE_CODE ASC ";
            OleDbCommand cmd = new OleDbCommand(sql, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    tCmb.Items.Clear();


                    while (reader.Read())
                    {
                        //tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                        string text = reader["ROLE_NAME"].ToString(); // A를 Text로 사용
                        string value = reader["ROLE_CODE"].ToString(); // B를 Value로 사용

                        comboBoxData[text] = value;
                        tCmb.Items.Add(text);
                    }
                }
            }
            Conn.Close();
        }
        private void cmbApprove1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] tapprover = cmbApprove1.Text.Split(' ');
            txtAccountNo1.Text = tapprover[0];
            txtLoginID1.Text = tapprover[1];
        }

        private void btnApprove2_Click(object sender, EventArgs e)
        {
            cmbApprove2.Items.Clear();
            get_approver2();
        }
        private void get_next_approver(string approverDept)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            ////dgvUserRequestStatus.Rows.Clear();
            string tMenuName = "";
            string tWorkName = "";

            //승인 요청 업무의 경우 반드시 - Form의 Text에 "메뉴명-작업명-승인요청"으로 기재해야 함.
            string s_text = "부서관리-직무기술서-승인요청";
            string[] twords = s_text.Split('-');
            tMenuName = twords[0];
            tWorkName = twords[1];

            int tApproveDepth = 0;
            tApproveDepth = 2;

            string query = "";
            query = " SELECT a.accountNo, b.logInID, b.userID, c.firstName ";
            query = query + " FROM [accountMaster].[dbo].[approveRole_V1] a  with (nolock) inner join [accountMaster].[dbo].[accountMaster] b  with (nolock) ";
            query = query + " on (a.accountNo = b.accountNo)";
            query = query + " inner join [accountMaster].[dbo].[userMaster] c  with (nolock) on (b.userID = c.userID) ";
            query = query + " where a.appNo = " + appNo; //+ appNo
            query = query + "    and a.menuNo = " + MenuNo; //appNo + MenuNo;
            query = query + "    and a.workNo = " + WorkNo; //appNo + WorkNo;
            query = query + "    and a.deptNo = '" + approverDept + "'";
            query = query + "    and a.MyApproveDepth = " + tApproveDepth;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        cmbApprove2.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reader.GetValue(3).ToString());
                    }
                }
            }

            Conn.Close();

        }
        private void get_approver2()
        {
            //requesterDeptCode = "0001-0003-00001-00002";
            requesterDeptCode = Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM;
            string[] words = requesterDeptCode.Split('-');
            string tDeptCode = "";
            int i = 0;
            for (i = words.Length; i > -1; i--)
            {
                tDeptCode = "";
                for (int j = 0; j < i; j++)
                {
                    tDeptCode = tDeptCode + words[j] + "-";
                }
                if (tDeptCode.Trim() == "")
                {
                    break;
                }
                else
                {
                    //MessageBox.Show(tDeptCode);
                    //MessageBox.Show(tDeptCode.Substring(0, tDeptCode.Length - 1));
                    get_next_approver(tDeptCode.Substring(0, tDeptCode.Length - 1));
                }

                //if (cmbApprover.Items. != "")
                //{
                //    MessageBox.Show(DeptNo.ToString());
                //    break;
                //}
            }
        }



        private void cmbRolePaper_SelectedIndexChanged(object sender, EventArgs e)
        {    
            string selectedText = cmbRolePaper.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                txtRoleCode.Text = comboBoxData[selectedText];
                txtRoleName.Text = selectedText.ToString();
            }
        }

        private void frmRolePaperPeriodicInspection_Load(object sender, EventArgs e)
        {
            
            get_folder_RolePaper(cmbRolePaper);
            set_approve_parameter();

            btnApprove1_Click(null, null);
            btnApprove2_Click(null, null);
        }
        private void btnApprove1_Click(object sender, EventArgs e)
        {
            cmbApprove1.Items.Clear();
            //get_requester_dept_code(); //승인요청자의 부서코드 검색 -> 해당 부서의 승인권자를 찾기 위함 => 추후 로그인 이후에 처리되도록 조정예정
            get_approver(); //승인권자의 부서코드 검색
            //get_first_approver("aa"); //승인권자 가져오기
            //get_ws_template2(cmbApprover, "Y");
        }

        private void get_approver()
        {
            //requesterDeptCode = "0001-0003-00001-00002";
            requesterDeptCode = Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM;
            string[] words = requesterDeptCode.Split('-');
            string tDeptCode = "";
            int i = 0;
            for (i = words.Length; i > -1; i--)
            {
                tDeptCode = "";
                for (int j = 0; j < i; j++)
                {
                    tDeptCode = tDeptCode + words[j] + "-";
                }
                if (tDeptCode.Trim() == "")
                {
                    break;
                }
                else
                {
                    get_first_approver(tDeptCode.Substring(0, tDeptCode.Length - 1));
                }

            }
        }


        private void get_first_approver(string approverDept)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            ////dgvUserRequestStatus.Rows.Clear();
            string tMenuName = "";
            string tWorkName = "";

            //승인 요청 업무의 경우 반드시 - Form의 Text에 "메뉴명-작업명-승인요청"으로 기재해야 함.
            string s_text = "부서관리-직무기술서-승인요청";
            string[] twords = s_text.Split('-');
            tMenuName = twords[0];
            tWorkName = twords[1];

            string query = "";
            query = " SELECT a.accountNo, b.logInID, b.userID, c.firstName ";
            query = query + " FROM[accountMaster].[dbo].[approveRole_V1] a with (nolock) inner join[accountMaster].[dbo].[accountMaster] b with (nolock)";
            query = query + " on (a.accountNo = b.accountNo)";
            query = query + " inner join[accountMaster].[dbo].[userMaster] c with (nolock) on (b.userID = c.userID) ";
            query = query + " where a.appNo = " + appNo; //+ appNo
            query = query + "    and a.menuNo = " + MenuNo; //appNo + MenuNo;
            query = query + "    and a.workNo = " + WorkNo; //appNo + WorkNo;
            query = query + "    and a.deptNo = '" + approverDept + "'";
            query = query + "    and a.MyapproveDepth = 1 ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        cmbApprove1.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reader.GetValue(3).ToString());
                    }
                }
            }
            Conn.Close();
        }


        private void set_approve_parameter()
        {
            //점검요청은..직무기술서로 봄 ㅠㅠ

            string s_text = "부서관리-직무기술서-승인요청";
            string[] frmText = s_text.Split('-');
            //txtidxNo.Text = Form2_GridIdx.sIDX;
            requesterDeptCode = get_requester_dept_code();
            appNo = get_appno(Form2PQMS_LoginInfo.sAppId);
            MenuNo = get_Menuno(frmText[0]);
            WorkNo = get_Workno(frmText[1]);
            requestedby = Form2PQMS_LoginInfo.sloginId;
            approveDepth = get_max_role_depth();

        }
        private int get_max_role_depth()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);


            ////dgvUserRequestStatus.Rows.Clear();

            int tmax = 0;
            string query = "";

            query = " select isnull(max(MaxApproveDepth),0) from [accountMaster].[dbo].[approveRole_V1] with (nolock) ";
            query = query + "    where appNo = " + appNo;
            query = query + "    and menuNo = " + MenuNo;
            query = query + "    and workNo = " + WorkNo;
            query = query + "    and deptNo = '" + requesterDeptCode + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        tmax = Convert.ToInt32(reader.GetValue(0).ToString());
                    }
                }
            }
            Conn.Close();
            return tmax;
        }

        private string get_requester_dept_code()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            string trequesterDeptCode = "";

            //query = "SELECT a.STAFF_CODE, c.accountNo, c.logInID, a.STAFF_NAME,  b.userID, a.STAFF_TEAM ";
            //query = query + " FROM [PQMS_STAFF] a left outer join[accountMaster].[dbo].[userMaster] b ";
            //query = query + "            on(a.STAFF_NAME = b.firstName) ";
            //query = query + " inner join[accountMaster].[dbo].[accountMaster] c ";
            //query = query + "            on(b.userID = c.logInID) ";
            //query = query + "where a.STAFF_NAME<> '' ";
            //query = query + "  and c.logInID is not NULL ";
            //query = query + "  and c.logInID != 'NULL' ";
            //query = query + "  and c.appID = 'PQMS' ";
            //query = query + "  and c.logInID = '" + loginId + "' ";

            query = " SELECT a.[STAFF_TEAM] ";
            query = query + " FROM [PQMS_STAFF]  a ";
            query = query + "      inner join[accountMaster].[dbo].[accountMaster] b on(a.ACCOUNT_NO = b.accountNo) ";
            query = query + " where b.logInID = '" + Form2PQMS_LoginInfo.sloginId + "'";          //karls.park@sgs.com' ";
            query = query + "   and b.appID = '" + Form2PQMS_LoginInfo.sAppId + "'";                      //PQMS' ";


            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        trequesterDeptCode = reader.GetValue(0).ToString();
                    }
                }
            }
            Conn.Close();
            return trequesterDeptCode;
        }

        private int get_appno(string tVal)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            int tappno = 0;
            query = "SELECT  appNo FROM [accountMaster].[dbo].[appMaster] ";
            query = query + " where appID = '" + tVal + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        tappno = Convert.ToInt32(reader.GetValue(0).ToString());
                    }
                }
            }
            Conn.Close();

            return tappno;
        }

        private int get_Menuno(string tVal)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            int tmenuno = 0;
            query = "SELECT  menuNo FROM [accountMaster].[dbo].[appMaster_Menu] ";
            query = query + " where appNo = " + appNo + "";
            query = query + "   and MenuName = '" + tVal + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        tmenuno = Convert.ToInt32(reader.GetValue(0).ToString());
                    }
                }
            }
            Conn.Close();

            return tmenuno;
        }

        private int get_Workno(string tVal)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            int tworkno = 0;
            query = "SELECT  workNo FROM [accountMaster].[dbo].[appMaster_Work] ";
            query = query + " where appNo = " + appNo + "";
            query = query + "   and WorkName = '" + tVal + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        tworkno = Convert.ToInt32(reader.GetValue(0).ToString());
                    }
                }
            }
            Conn.Close();

            return tworkno;
        }

        private void btnRP_PeriodicInspection_Click(object sender, EventArgs e)
        {
            int rp_idx = 0;
            string rp_version = "";
            string rp_org_code = "";
            string query = "SELECT top 1 MAX(RP_VERSION) AS MaxRPVersion, RP_IDX, RP_ORG_CODE FROM PQMS_STAFF_ROLE_PAPER_VER" +
                            " WHERE STAFF_CODE = '"+ Form2PQMS_StaffInfo.sStaffCode + "' AND RP_CODE = '"+ txtRoleCode.Text+ "' " +
                            " GROUP BY RP_IDX, RP_ORG_CODE ORDER BY MaxRPVersion DESC , RP_IDX DESC ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {                       
                        rp_version = reader.GetValue(0).ToString();
                        rp_idx = Convert.ToInt32(reader.GetValue(1).ToString());
                        rp_org_code = reader.GetValue(2).ToString();
                    }
                }
            }
            Conn.Close();


            int newidx = InsertRP_GetIdx(rp_idx); //직무기술서 Insert
            InsertRP_VER_GetIdx(newidx, rp_org_code, rp_version); // 직무기술서 버전 Insert            
            save_item2(newidx); //정기점검 Insert 한 직무기술서 승인요청 처리 


            //트래이닝폴더관리 파일재생성 ... 
            string s_file = "";
            string s_approvename = "";
            int i_idx = 0;

            query = " SELECT IDX, FILE_PATH, RP_APPROVER_NAME FROM PQMS_STAFF_ROLEPAPER_TRANING_FOLDER " +
                    " WHERE STAFF_CODE = '" + Form2PQMS_StaffInfo.sStaffCode + "' AND ROLE_CODE = '" + txtRoleCode.Text + "' ";

            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        i_idx = Convert.ToInt32(reader.GetValue(0).ToString());
                        s_file = reader.GetValue(1).ToString();
                        s_approvename = reader.GetValue(2).ToString();                        
                    }
                }
            }
            Conn.Close();

            //이전트래이닝파일 삭제 및 DB삭제 
            query = "DELETE FROM PQMS_STAFF_ROLEPAPER_TRANING_FOLDER WHERE IDX = " + i_idx;
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();
            //파일삭제
            if (File.Exists(s_file))
            {
                File.Delete(s_file);
            }            
            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
            string savrfilepath = @"\\10.153.4.98\DI\PQMS\Report\RolePaper" + @"\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "트래이닝폴더관리" + @"\" + sDateTime_yyyyMM;
            DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
            if (file_di.Exists == false)
            {
                Directory.CreateDirectory(savrfilepath);
            }
            string tr_templeate = @"\\10.153.4.98\DI\PQMS\Template\RolePaper\CQP-6021-F01 (01) 트레이닝 폴더 관리.docx";
            if (unitCommon.CreateDoc_trainingFolder(tr_templeate, Form2PQMS_StaffInfo.sStaffCode, Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX, savrfilepath, txtRoleName.Text, s_approvename, txtRoleCode.Text) == 0)
            {
                MessageBox.Show("정기정검 요청 완료");
                parentForm.Change_btn9_ColorChange();
            }
            this.Close();
        }

        private void save_item2(int rp_idx)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            /*
            select * from appMaster_Dept
            select * from appMaster_Work
            select * from appMaster_Menu
            */
            string t1 = "PQMS_STAFF_ROLE_PAPER";
            string t2_Log = "PQMS_STAFF_ROLE_PAPER_APPROVE_LOG";


            if (txtAccountNo1.Text == "") //1차 검토자가 없는경우 approvedYN 을 Y로 처리하여 1차가 승인 된 걸로 데이터 저장 
            {
                query = " update " + t1 + " set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 2" + ",";  //1: requested, 0/null:not requested / 2: 1차 승인 완료상태 (1차 승인이 없기 때문에 2차 승인으로 넘기기 위한작업)
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved  
                query = query + " approveComment = N'정기정검 요청 ' + CONVERT(VARCHAR, GETDATE(), 23) ";
                query = query + " where IDX = " + rp_idx + "";

                OleDbCommand cmd = new OleDbCommand(query, Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();               

                query = " insert into " + t2_Log;
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + rp_idx + ",";
                query = query + "" + appNo + ",";
                query = query + "'" + requesterDeptCode + "',";
                query = query + "" + WorkNo + ",";
                query = query + "" + MenuNo + ",";
                query = query + "'" + txtLoginID1.Text + "',";
                query = query + "0" + ",";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + approveDepth + ","; //target/final approve depth
                query = query + "'" + Form2PQMS_LoginInfo.sloginId + "',";
                query = query + "'Y',"; //N:Not approved, Y:approved // 
                query = query + "'',";
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "')";
                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();

                //2차 승인 = 승인권자 
                query = " insert into  " + t2_Log;
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + rp_idx + ",";
                query = query + "" + appNo + ",";
                query = query + "'" + requesterDeptCode + "',";
                query = query + "" + WorkNo + ",";
                query = query + "" + MenuNo + ",";
                query = query + "'" + txtLoginID2.Text + "',";
                query = query + "1" + ",";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "'2', "; //target/final approve depth
                query = query + "'" + Form2PQMS_LoginInfo.sloginId + "',";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'',";
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "')";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();
                Conn.Close();

                //e-mail 발송로직 2차 (1차 검토자가 없으므로 바로 2차 승인자에게 메일 발송)
                unitSMTP.sFROM = Form2PQMS_LoginInfo.sloginId;
                unitSMTP.sTO = txtLoginID2.Text;
                unitSMTP.sSUBJECT = "PQMS 트래이닝폴더관리 정기정검 승인요청 ";
                unitSMTP.sBODY = "PQMS 트래이닝폴더관리 정기정검 승인요청 대상 번호 : " + rp_idx + " 승인요청  드립니다.";
                unitSMTP.Email_Send();
            }
            else
            {
                query = " update " + t1 + " set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested / 2: 1차 승인 완료상태
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved  
                query = query + " approveComment = N'정기정검 요청 ' + CONVERT(VARCHAR, GETDATE(), 23) ";
                query = query + " where IDX = " + rp_idx + "";

                OleDbCommand cmd = new OleDbCommand(query, Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();


                query = " insert into " + t2_Log;
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + rp_idx + ",";
                query = query + "" + appNo + ",";
                query = query + "'" + requesterDeptCode + "',";
                query = query + "" + WorkNo + ",";
                query = query + "" + MenuNo + ",";
                query = query + "'" + txtLoginID1.Text + "',";
                query = query + "0" + ",";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + approveDepth + ","; //target/final approve depth
                query = query + "'" + Form2PQMS_LoginInfo.sloginId + "',";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'',";
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "')";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();

                //e-mail 발송로직 1차 
                unitSMTP.sFROM = Form2PQMS_LoginInfo.sloginId;
                unitSMTP.sTO = txtLoginID1.Text;
                unitSMTP.sSUBJECT = "PQMS 트래이닝폴더관리 정기정검 승인요청 ";
                unitSMTP.sBODY = "PQMS 트래이닝폴더관리 정기정검 승인요청 대상 번호 : " + rp_idx + " 승인요청  드립니다.";
                unitSMTP.Email_Send();

                //2차 승인 = 승인권자 
                query = " insert into  " + t2_Log;
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + rp_idx + ",";
                query = query + "" + appNo + ",";
                query = query + "'" + requesterDeptCode + "',";
                query = query + "" + WorkNo + ",";
                query = query + "" + MenuNo + ",";
                query = query + "'" + txtLoginID2.Text + "',";
                query = query + "1" + ",";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "'2', "; //target/final approve depth
                query = query + "'" + Form2PQMS_LoginInfo.sloginId + "',";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'',";
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "')";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
        }

        private int InsertRP_GetIdx(int rp_idx )
        {
            int newIdx = -1;
            using (OleDbConnection connection = new OleDbConnection(unitCommon.connect_string))
            {
                try
                {
                    connection.Open();

                    // Your INSERT INTO statement
                    string insertQuery = "INSERT INTO PQMS_STAFF_ROLE_PAPER " +
                                " (STAFF_CODE, STAFF_RP_DATE, STAFF_RP_CLASS, STAFF_RP_CLASS_2, STAFF_RP_CLASS_3, STAFF_RP_CLASS_4, STAFF_RP_CLASS_5, STAFF_RP_CLASS_6, " +
                                " STAFF_RP_ORG_CODE, STAFF_RP_CODE, STAFF_RP_CODE_NAME, STAFF_RP_APPROVER, STAFF_RP_APPROVE_DATE, STAFF_RP_WRITER, STAFF_RP_WRITE_DATE, STAFF_RP_SUPPORTER," +
                                " STAFF_RP_FILE, STAFF_RP_FRISTDATE, STAFF_RP_CAREER, STAFF_RP_REASON, STAFF_RP_FINAL, STAFF_RP_EACHLIST_IDX, STAFF_RP_TRANING_IDX," +
                                " appNo, DeptNo, WorkNo, MenuNo, requestStatusCode, approveStatusCode, approveComment)" +
                                " OUTPUT INSERTED.IDX " + // OUTPUT clause to get the inserted IDX
                                " SELECT STAFF_CODE, STAFF_RP_DATE, STAFF_RP_CLASS, STAFF_RP_CLASS_2, STAFF_RP_CLASS_3, STAFF_RP_CLASS_4, STAFF_RP_CLASS_5, STAFF_RP_CLASS_6," +
                                " STAFF_RP_ORG_CODE, STAFF_RP_CODE, STAFF_RP_CODE_NAME, STAFF_RP_APPROVER, STAFF_RP_APPROVE_DATE, STAFF_RP_WRITER, CONVERT(VARCHAR, GETDATE(), 23), STAFF_RP_SUPPORTER," +
                                " STAFF_RP_FILE, STAFF_RP_FRISTDATE, STAFF_RP_CAREER, '정기점검 ' + CONVERT(VARCHAR, GETDATE(), 23), STAFF_RP_FINAL, STAFF_RP_EACHLIST_IDX, STAFF_RP_TRANING_IDX," +
                                " appNo, DeptNo, WorkNo, MenuNo, requestStatusCode, approveStatusCode, approveComment" +
                                " FROM PQMS_STAFF_ROLE_PAPER WHERE IDX = " + rp_idx;

                    using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                    {
                        newIdx = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }

            return newIdx;
        }


        private void InsertRP_VER_GetIdx(int rp_idx, string rp_org_code, string rp_ver)
        {
            int newIdx = -1;
            using (OleDbConnection connection = new OleDbConnection(unitCommon.connect_string))
            {
                try
                {
                    connection.Open();

                    // Your INSERT INTO statement
                    string insertQuery = "INSERT INTO PQMS_STAFF_ROLE_PAPER_VER " +
                                         " (STAFF_CODE,	RP_ORG_CODE,	RP_CODE,	RP_VERSION,	RP_IDX,	RP_DATE ) values " +
                                         " ( '" + Form2PQMS_StaffInfo.sStaffCode + "' , '" + rp_org_code + "', '" + txtRoleCode.Text + "', '" + rp_ver + "', '" + rp_idx.ToString() + "', CONVERT(VARCHAR, GETDATE(), 23) )";


                    using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                    {
                        newIdx = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
                      
        }



    }

}
