using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PQMS.C.Unit;

namespace PQMS
{
    public partial class frmApproveRequestVer2 : Form
    {
        private UnitCommon unitCommon;

        private UnitSMTP unitSMTP;
        private OleDbConnection Conn;

        public int accountNo = 0;
        public int requesteraccountNo = 0;
        public int approveraccountNo = 0;
        public string requesterDeptCode = "";
        public int appNo = 0;
        public int MenuNo = 0;
        public int WorkNo = 0;
        public string DeptNo = "";
        public string DeptNo2 = "";
        public string requestedby = "";
        public int approveDepth = 0;

        private Form2_Anyang parentForm;


        public frmApproveRequestVer2(Form2_Anyang parent)
        {
            InitializeComponent();
            Initialize();
            unitCommon = new UnitCommon();
            this.parentForm = parent;
        }
        private void Initialize()
        {
            unitCommon = new UnitCommon();
            unitSMTP = new UnitSMTP();

            
            if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                label3.Text = "승인요청내용\n         OR\n     개정사유:";
            }
            else
            {
                label3.Text = "승인요청내용:";
            }
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
                    //MessageBox.Show(tDeptCode);
                    //MessageBox.Show(tDeptCode.Substring(0, tDeptCode.Length - 1));
                    get_first_approver(tDeptCode.Substring(0, tDeptCode.Length - 1));
                }

                //if (cmbApprover.Items. != "")
                //{
                //    MessageBox.Show(DeptNo.ToString());
                //    break;
                //}
            }
        }


        private void getLoad_ROLE_DATE()
        {
            //if (Form2_Tab_Info_Now.sTabName == "임명장")
            //{
            //    DataTable dt = new DataTable();
            //    Conn = new OleDbConnection(unitCommon.connect_string);
            //    string query = "";

            //    query = " select A.IDX, A.STAFF_ROLE_ORG_CODE, x.ORG_NAME,  A.STAFF_ROLE_CLASS, A.STAFF_ROLE_CODE ,B.GROUP1_NUM, B.GROUP1_NAME , B.GROUP1_CODE ,C.GROUP2_NAME, C.GROUP2_CODE , A.STAFF_ROLE_CODE ,  A.STAFF_ROLE_NAME " +
            //            " from PQMS_STAFF_ROLE A  " +
            //            " inner join PQMS_ORG X on A.STAFF_ROLE_ORG_CODE = x.ORG_CODE and  X.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and 	X.REPOSITORY_CODE='" + Form1PQMS_Repo.sRepo + "' and X.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            //            " inner join PQMS_GROUP1 B on B.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and 	B.REPOSITORY_CODE='" + Form1PQMS_Repo.sRepo + "' and	B.WS_CODE='" + Form1PQMS_Repo.sWS + "' and a.STAFF_ROLE_ORG_CODE = B.GROUP1_ORG_CODE and left(a.STAFF_ROLE_CLASS, 4) = B.GROUP1_CODE " +
            //            " inner join PQMS_GROUP2 C on C.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and 	C.REPOSITORY_CODE='" + Form1PQMS_Repo.sRepo + "' and	C.WS_CODE='" + Form1PQMS_Repo.sWS + "' and a.STAFF_ROLE_ORG_CODE = C.GROUP2_ORG_CODE and left(a.STAFF_ROLE_CLASS, 4) = c.GROUP2_GROUP1_CODE and RIGHT(a.STAFF_ROLE_CLASS,4)= c.GROUP2_CODE " +
            //            $" where A.STAFF_CODE = '" + Form2PQMS_StaffInfo.sStaffCode + "' and A.STAFF_ROLE_ORG_CODE= '" + Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE + "' and ( A.STAFF_ROLE_FINAL is null or A.STAFF_ROLE_FINAL <> 'Y') " +
            //            $"  and A.STAFF_ROLE_CODE = '"+ Form2PQMS_StaffInfo .sPQMS_STAFF_ROLE_CODE+ "' ";
            //    OleDbCommand cmd = new OleDbCommand(query, Conn);
            //    Conn.Open();
            //    dt.Reset();
            //    using (OleDbDataReader reader = cmd.ExecuteReader())
            //    {
            //        dt.Load(reader);
            //    }
            //    Conn.Close();

            //    PQMS_STAFF_ROLE_CHECKGrid.DataSource = null;
            //    if (dt.Rows.Count > 0)
            //    {
            //        PQMS_STAFF_ROLE_CHECKGrid.DataSource = dt;
            //    }
            //}
        }


        private void frmApproveRequestVer2_Load(object sender, EventArgs e)
        {
            this.Text = Form2_Tab_Info_Now.sMenuName + "-" + Form2_Tab_Info_Now.sTabName + "-" + "승인요청";

            txtTitle.Text = Form2_Tab_Info_Now.sTabName;
            set_approve_parameter();
            //frmApproveRequest test = new frmApproveRequest();


            //get_approve_param(); //승인관련변수할당 -> userManagement -> 승인업무정리 참조

            //get_approval_right1();
            //get_approval_right2();
            //get_max_role_depth();
           
            getLoad_ROLE_DATE();

            if (Form2_Tab_Info_Now.sTabName == "교육보고서" || Form2_Tab_Info_Now.sTabName == "시험수행능력평가")
            {
                txtAccountNo1.Enabled = false;
                txtLoginID1.Enabled = false;
                cmbApprove1.Enabled = false;
                btnApprove1.Enabled = false;
            }

            btnApprove1_Click(null, null);
            btnApprove2_Click(null, null);
        }

        private void set_approve_parameter()
        {
            string[] frmText = this.Text.Split('-');
            txtidxNo.Text = Form2_GridIdx.sIDX;
            requesterDeptCode = get_requester_dept_code();
            appNo = get_appno(Form2PQMS_LoginInfo.sAppId);
            MenuNo = get_Menuno(frmText[0]);
            WorkNo = get_Workno(frmText[1]);
            requestedby = Form2PQMS_LoginInfo.sloginId;
            approveDepth = get_max_role_depth();
            
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

        private void get_first_approver(string approverDept)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            ////dgvUserRequestStatus.Rows.Clear();
            string tMenuName = "";
            string tWorkName = "";

            //승인 요청 업무의 경우 반드시 - Form의 Text에 "메뉴명-작업명-승인요청"으로 기재해야 함.
            string[] twords = this.Text.Split('-');
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


        private void btnApproveGo_Click(object sender, EventArgs e)
        {
            if (Form2_Tab_Info_Now.sTabName == "직무기술서" || Form2_Tab_Info_Now.sTabName == "임명장" || Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")
            {
                if (cmbApprove2.Text == "") // 선택된 2차 승인자가 없으면 에러 
                {
                    MessageBox.Show("승인권자를 선택하세요.");
                    return;
                }
            }

            if (approvechek() == 0)
            {
                //if (Form2_Tab_Info_Now.sTabName == "임명장")
                //{
                //    if (save_item2_ROLE() == 1)
                //    {
                //        MessageBox.Show("승인 요청 완료");
                //    }             
                //}
                //else
                //{
                //    save_item2();
                //    MessageBox.Show("승인 요청 완료");
                //}

                //cmbApprove2
                //if ()

                


                save_item2();
                MessageBox.Show("승인 요청 완료");
                

            }
            else
            {
                MessageBox.Show("이미 승인 요청 되었습니다.");
            }

            getLoad_ROLE_DATE();//임명장인경우 gridview 데이터 다시 로드 



            //승인완료 후 데이터 부모폼의 데이터 다시 로드 후 창 닫기 
            if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {                
                parentForm.Call_PQMS_STAFF_TRAINING();                               
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                parentForm.Call_PQMS_STAFF_ROLE_PAPER();
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                parentForm.Call_PQMS_Main_Role(Form2PQMS_StaffInfo.sStaffCode);
            }
            else if (Form2_Tab_Info_Now.sTabName == "시험수행능력평가")
            {
                parentForm.CALL_PQMS_ROLE2_EACH();
                parentForm.CAll_PQMS_EACH_LIST();

            }
            else if (Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")
            {
                parentForm.Call_PQMS_STAFF_ASSESSMENT();
            }

            this.Close();
        }


        private int approvechek()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            int tchk = 0;
            string query = "";

            string t1 = "";

            if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                t1 = "PQMS_STAFF_TRAINING";
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                t1 = "PQMS_STAFF_ROLE_PAPER";
                //t1 = "PQMS_STAFF_ROLE_PAPER_FINAL";
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                //t1 = "PQMS_STAFF_ROLE_APPOINT";
                t1 = "PQMS_STAFF_ROLE";
            }
            else if (Form2_Tab_Info_Now.sTabName == "시험수행능력평가")
            {
                t1 = "PQMS_STAFF_RP_EACH_LIST";
            }
            //else if (Form2_Tab_Info_Now.sTabName == "임명장")
            //{
            //    t1 = "PQMS_STAFF_ROLE_FINAL";                
            //}
            //else if (Form2_Tab_Info_Now.sTabName == "조직도")
            //{
            //    t1 = "PQMS_STAFF_ORG_CHART";
            //}
            //else if (Form2_Tab_Info_Now.sTabName == "수정변경요청")
            //{
            //    t1 = "PQMS_STAFF_EDITREQUEST";
            //}
            else if (Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")
            {
                t1 = "PQMS_STAFF_ASSESSMENT_REPORT";
            }


            query = "SELECT  isnull(requestStatusCode,0) FROM "+ t1 ;
            query = query + " where IDX = " + txtidxNo.Text + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        tchk = Convert.ToInt32(reader.GetValue(0).ToString());
                    }
                }
            }
            Conn.Close();
            return tchk;
        }

        private int R_Final(string tmpidx, string tmpstr , string rcode , string rname)
        {

            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "update PQMS_STAFF_ROLE set ";            
            query = query + " STAFF_ROLE_FINAL = 'Y' ";
            query = query + " where IDX in (" + tmpidx.Substring(2, tmpidx.Length - 2) + ")";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();
                                 
            
            int returnIDX = 0;

            query = "insert into PQMS_STAFF_ROLE_FINAL (STAFF_CODE, PQMS_STAFF_ROLE_IDX, PQMS_STAFF_ROLE_GROUPNAME, ROLE_ORG_CODE, ROLE_CREATE_DATE, STAFF_ROLE_CODE ,STAFF_ROLE_NAME) Values ( " +
                     " '" + Form2PQMS_StaffInfo.sStaffCode + "', '" + tmpidx.Substring(2, tmpidx.Length - 2) + "', '"+ tmpstr.Substring(2, tmpstr.Length - 2) + "', '" + Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE + "', " +
                     " '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', '" + rcode + "', '" + rname + "' )   SELECT CAST(scope_identity() AS int)  "; 

            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            returnIDX= (int)cmd.ExecuteScalar();
            Conn.Close();

            return returnIDX;       
        }


        private int save_item2_ROLE() //임명장 승인 
        {
            int returnx = 0;
            int cnt = 0;            
            string tmpidx = ""; // 선택된 체크박스 idx 값
            string tmpstr = ""; // 선택된 중분류
            string tmp_rcode = ""; // 직무코드
            string tmp_rname = ""; // 직무명 

            foreach (int id in PQMS_STAFF_ROLE_CHECKGridView.GetSelectedRows())
            {
                if (cnt == 0)
                {
                    tmp_rcode = PQMS_STAFF_ROLE_CHECKGridView.GetRowCellValue(id, "STAFF_ROLE_CODE").ToString();
                    tmp_rname = PQMS_STAFF_ROLE_CHECKGridView.GetRowCellValue(id, "STAFF_ROLE_NAME").ToString();
                }
                else
                {
                    if (tmp_rcode != PQMS_STAFF_ROLE_CHECKGridView.GetRowCellValue(id, "STAFF_ROLE_CODE").ToString())
                    {
                        MessageBox.Show("직무 코드가 다릅니다.");                        
                        return returnx;
                    }
                }
                cnt = cnt + 1;
                //list_idx.Add(PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "IDX").ToString() as string);
                tmpstr = tmpstr + ", " + PQMS_STAFF_ROLE_CHECKGridView.GetRowCellValue(id, "GROUP2_NAME").ToString();
                tmpidx = tmpidx + ", " + PQMS_STAFF_ROLE_CHECKGridView.GetRowCellValue(id, "IDX").ToString();
                //tmpreason = tmpreason + " " + PQMS_STAFF_ROLE_CHECKGridView.GetRowCellValue(id, "STAFF_RP_REASON").ToString();
            }

            int FinalIDx = R_Final(tmpidx, tmpstr, tmp_rcode, tmp_rname);

            string t1 = "";
            string t2_Log = "";
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";
            
            t1 = "PQMS_STAFF_ROLE_FINAL";
            t2_Log = "PQMS_STAFF_ROLE_FINAL_APPROVE_LOG";

            if (txtAccountNo1.Text == "") //1차 검토자가 없는경우 approvedYN 을 Y로 처리하여 1차가 승인 된 걸로 데이터 저장 
            {
                query = " update " + t1 + " set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 2" + ",";  //1: requested, 0/null:not requested / 2: 1차 승인 완료상태 (1차 승인이 없기 때문에 2차 승인으로 넘기기 위한작업)
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved  
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX = " + FinalIDx + "";

                OleDbCommand cmd = new OleDbCommand(query, Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();

                query = " update PQMS_STAFF_ROLE set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 2" + ",";  //1: requested, 0/null:not requested / 2: 1차 승인 완료상태 (1차 승인이 없기 때문에 2차 승인으로 넘기기 위한작업)
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved  
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX in  ( " + tmpidx.Substring(2, tmpidx.Length - 2 ) + " )";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();

                query = " insert into " + t2_Log;
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + FinalIDx + ",";
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
                query = query + "" + FinalIDx + ",";
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
                unitSMTP.sSUBJECT = "PQMS " + Form2_Tab_Info_Now.sTabName + " 승인요청 ";
                unitSMTP.sBODY = "PQMS " + Form2_Tab_Info_Now.sTabName + "\n\n" + "승인 요청 대상 번호 : " + txtidxNo.Text + " 승인요청  드립니다.";
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
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX = " + FinalIDx + "";

                OleDbCommand cmd = new OleDbCommand(query, Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();

                query = " update PQMS_STAFF_ROLE set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested / 2: 1차 승인 완료상태
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved  
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX in  ( " + tmpidx.Substring(2, tmpidx.Length - 2) + " )";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();

                query = " insert into " + t2_Log;
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + FinalIDx + ",";
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
                unitSMTP.sSUBJECT = "PQMS " + Form2_Tab_Info_Now.sTabName + " 검토요청 ";
                unitSMTP.sBODY = "PQMS " + Form2_Tab_Info_Now.sTabName + "\n\n" + "검토 요청 대상 번호 : " + txtidxNo.Text + " 검토요청  드립니다.";
                unitSMTP.Email_Send();

                //2차 승인 = 승인권자 
                query = " insert into  " + t2_Log;
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + FinalIDx + ",";
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
            returnx = 1;
            return returnx;
        }


        private void save_item2()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            /*
            select * from appMaster_Dept
            select * from appMaster_Work
            select * from appMaster_Menu
            */
            string t1 = "";
            string t2_Log = "";
            if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                t1 = "PQMS_STAFF_TRAINING";
                t2_Log = "PQMS_STAFF_TRAINING_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                t1 = "PQMS_STAFF_ROLE_PAPER";
                t2_Log = "PQMS_STAFF_ROLE_PAPER_APPROVE_LOG";

                //t1 = "PQMS_STAFF_ROLE_PAPER_FINAL";
                //t2_Log = "PQMS_STAFF_ROLE_PAPER_FINAL_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                t1 = "PQMS_STAFF_ROLE";
                t2_Log = "PQMS_STAFF_ROLE_APPROVE_LOG";
                //t1 = "PQMS_STAFF_ROLE_APPOINT";
                //t2_Log = "PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "시험수행능력평가")
            {
                t1 = "PQMS_STAFF_RP_EACH_LIST";
                t2_Log = "PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                t1 = "PQMS_STAFF_ROLE";
                t2_Log = "PQMS_STAFF_ROLE_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "조직도")
            {
                t1 = "PQMS_STAFF_ORG_CHART";
                t2_Log = "PQMS_STAFF_ORG_CHART_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "수정변경요청")
            {
                t1 = "PQMS_STAFF_EDITREQUEST";
                t2_Log = "PQMS_STAFF_EDITREQUEST_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")
            {
                t1 = "PQMS_STAFF_ASSESSMENT_REPORT";
                t2_Log = "PQMS_STAFF_ASSESSMENT_REPORT_APPROVE_LOG";
            }


            if (txtAccountNo1.Text == "") //1차 검토자가 없는경우 approvedYN 을 Y로 처리하여 1차가 승인 된 걸로 데이터 저장 
            {
                query = " update " + t1 + " set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 2" + ",";  //1: requested, 0/null:not requested / 2: 1차 승인 완료상태 (1차 승인이 없기 때문에 2차 승인으로 넘기기 위한작업)
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved  
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX = " + txtidxNo.Text + "";

                OleDbCommand cmd = new OleDbCommand(query, Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();

                ////직무기술서는 PQMS_STAFF_ROLE_PAPER 테이블도 신청 완료 처리를 위해서 추가 처리 해야함. 
                //if (Form2_Tab_Info_Now.sTabName == "직무기술서")
                //{
                //    query = " update PQMS_STAFF_ROLE_PAPER set ";
                //    query = query + " appNo = " + appNo + ",";
                //    query = query + " DeptNo = '" + requesterDeptCode + "',";
                //    query = query + " WorkNo = " + WorkNo + ",";
                //    query = query + " MenuNo = " + MenuNo + ",";
                //    query = query + " requestStatusCode = 2" + ",";  //1: requested, 0/null:not requested / 2: 1차 승인 완료상태 (1차 승인이 없기 때문에 2차 승인으로 넘기기 위한작업)
                //    query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved  
                //    query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                //    query = query + " where IDX in  ( " + Form2_GridIdx.sRPIDX  + " )";
                    
                //    cmd = new OleDbCommand(query, Conn);
                //    cmd.ExecuteNonQuery();
                //}

                query = " insert into " + t2_Log;
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + txtidxNo.Text + ",";
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
                query = query + "" + txtidxNo.Text + ",";
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
                unitSMTP.sSUBJECT = "PQMS " + Form2_Tab_Info_Now.sTabName + " 승인요청 ";
                unitSMTP.sBODY = "PQMS " + Form2_Tab_Info_Now.sTabName + "\n\n" + "승인 요청 대상 번호 : " + txtidxNo.Text + " 승인요청  드립니다.";
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
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX = " + txtidxNo.Text + "";

                OleDbCommand cmd = new OleDbCommand(query, Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();

                ////직무기술서는 PQMS_STAFF_ROLE_PAPER 테이블도 신청 완료 처리를 위해서 추가 처리 해야함. 
                //if (Form2_Tab_Info_Now.sTabName == "직무기술서")
                //{
                //    query = " update PQMS_STAFF_ROLE_PAPER set ";
                //    query = query + " appNo = " + appNo + ",";
                //    query = query + " DeptNo = '" + requesterDeptCode + "',";
                //    query = query + " WorkNo = " + WorkNo + ",";
                //    query = query + " MenuNo = " + MenuNo + ",";
                //    query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested / 2: 1차 승인 완료상태
                //    query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved  
                //    query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                //    query = query + " where IDX in  ( "+  Form2_GridIdx.sRPIDX  + " )";

                //    cmd = new OleDbCommand(query, Conn);
                //    cmd.ExecuteNonQuery();
                //}

                query = " insert into " + t2_Log;
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + txtidxNo.Text + ",";
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
                unitSMTP.sSUBJECT = "PQMS " + Form2_Tab_Info_Now.sTabName + " 검토요청 ";
                unitSMTP.sBODY = "PQMS " + Form2_Tab_Info_Now.sTabName +"\n\n"+  "검토 요청 대상 번호 : "+ txtidxNo.Text + " 검토요청  드립니다.";
                unitSMTP.Email_Send();

                //2차 승인 = 승인권자 
                query = " insert into  " + t2_Log;
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + txtidxNo.Text + ",";
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

        private void get_next_approver(string approverDept)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            ////dgvUserRequestStatus.Rows.Clear();
            string tMenuName = "";
            string tWorkName = "";

            //승인 요청 업무의 경우 반드시 - Form의 Text에 "메뉴명-작업명-승인요청"으로 기재해야 함.
            string[] twords = this.Text.Split('-');
            tMenuName = twords[0];
            tWorkName = twords[1];

            int tApproveDepth = 0;
            tApproveDepth =2;

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

        private void cmbApprove2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] tapprover = cmbApprove2.Text.Split(' ');
            txtAccountNo2.Text = tapprover[0];
            txtLoginID2.Text = tapprover[1];
        }
    }
}
