using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using PQMS.C.Unit;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Pdf;
using System.Threading;

namespace PQMS
{
    public partial class frmApproveRequestCheckVer2 : Form
    {
        private UnitSMTP unitSMTP;
        private UnitCommon unitCommon;
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
        public string approvedby = "";
        public int FinalApproveDepth = 0;
        public int MyApproveDepth = 0;
        public int idxToBeApproved = 0;

        public string s_rpIDX = "";
        public string s_rIDX = "";

        public string s_eduFile = "";
        public string s_staffcode = "";

        public string s_filepath = "";


        public frmApproveRequestCheckVer2()
        {
            InitializeComponent();
            Initialize();
            unitCommon = new UnitCommon();
        }

        private void Initialize()
        {
            unitCommon = new UnitCommon();
            unitSMTP = new UnitSMTP();
        }


        private void frmApproveRequestCheckVer2_Load(object sender, EventArgs e)
        {
            this.Text = Form2_Tab_Info_Now.sMenuName + "-" + Form2_Tab_Info_Now.sTabName + "-" + "승인요청확인및승인";

            txtTitle.Text = Form2_Tab_Info_Now.sTabName;
            set_approve_parameter();
            //get_approve_param(); //승인관련변수할당 -> userManagement -> 승인업무정리 참조


            //get_approval_right1();
            //get_approval_right2();
            //get_max_role_depth();

            get_data_tobe_approved();

        }

        private void set_approve_parameter()
        {
            string[] frmText = this.Text.Split('-');
            txtidxNo.Text = Form2_GridIdx.sIDX;
            accountNo = Convert.ToInt32(Form2PQMS_LoginInfo.sAccountNo);
            appNo = get_appno(Form2PQMS_LoginInfo.sAppId);
            MenuNo = get_Menuno(frmText[0]);
            WorkNo = get_Workno(frmText[1]);
            requestedby = "";
            approvedby = Form2PQMS_LoginInfo.sloginId;

            //requesterDeptCode = get_requester_dept_code();
            //FinalApproveDepth = get_max_approve_depth();
            
            
            MyApproveDepth = get_my_approve_depth(); 

            //if (FinalApproveDepth == 0 || MyApproveDepth == 0)
            //{
            //    MessageBox.Show("승인권자가 아니시거나 혹은 승인할 내역이 없습니다.");
            //    this.Close();
            //}
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

        private string get_ApproverName()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            string returnname = "";
            query = "SELECT  b.firstName FROM [accountMaster].[dbo].[accountMaster] a ";
            query = query + "  inner join [accountMaster].[dbo].[userMaster]  b on a.userID = b.userID ";
            query = query + " where a.appNo = " + appNo + "";
            query = query + "   and a.userid = '" + Form2PQMS_LoginInfo.sloginId + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        returnname = reader.GetValue(0).ToString();
                    }
                }
            }
            Conn.Close();

            return returnname;
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



        private int get_max_approve_depth()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);


            ////dgvUserRequestStatus.Rows.Clear();

            int tmax = 0;
            string query = "";

            query = " select isnull(max(MaxApproveDepth),0) from [accountMaster].[dbo].[approveRole_V1] ";
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

        private int get_my_approve_depth()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);


            ////dgvUserRequestStatus.Rows.Clear();

            int tmax = 0;
            string query = "";

            //query = " select isnull(max(MaxApproveDepth),0) from [accountMaster].[dbo].[approveRole_V1] ";


            
            query = " select MyApproveDepth from [accountMaster].[dbo].[approveRole_V1] ";
            query = query + "    where accountNo = " + accountNo;
            query = query + "    and appNo = " + appNo;
            query = query + "    and menuNo = " + MenuNo;
            query = query + "    and workNo = " + WorkNo;
            //query = query + "    and deptNo = " + requesterDeptCode;

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
             
        private string get_dept_no(string deptID)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = "SELECT  ";
            query = query + " FROM [accountMaster].[dbo].[appMaster_Dept] ";
            query = query + " where appNo = " + appNo + "";
            query = query + "   and DeptName = '" + deptID + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        DeptNo2 = reader.GetValue(0).ToString();
                    }
                }
                else
                {
                    DeptNo2 = "";
                }
            }
            Conn.Close();

            return DeptNo2;
        }
             

        private void btnEduReportGo_Click(object sender, EventArgs e)
        {
            get_data_tobe_approved();
        }

        private void get_data_tobe_approved()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string[] frmText = this.Text.Split('-');
            int tchk = 0;
            string query = "";

            string t1 = "";
            string t2_Log = "";
            if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                t1 = "PQMS_STAFF_TRAINING";
                t2_Log = "PQMS_STAFF_TRAINING_APPROVE_LOG";
                PQMS_STAFF_ApproveRequestCheckListView.Columns[8].Visible = true;
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                //t1 = "PQMS_STAFF_ROLE_PAPER";
                //t2_Log = "PQMS_STAFF_ROLE_PAPER_APPROVE_LOG";
                t1 = "PQMS_STAFF_ROLE_PAPER_FINAL";
                t2_Log = "PQMS_STAFF_ROLE_PAPER_FINAL_APPROVE_LOG";

                PQMS_STAFF_ApproveRequestCheckListView.Columns[10].Visible = true;

            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                t1 = "PQMS_STAFF_ROLE_APPOINT";
                t2_Log = "PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
            {
                t1 = "PQMS_STAFF_RP_EACH_LIST";
                t2_Log = "PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무자료")
            {
                //t1 = "PQMS_STAFF_ROLE";
                //t2_Log = "PQMS_STAFF_ROLE_APPROVE_LOG";
                t1 = "PQMS_STAFF_ROLE_FINAL";
                t2_Log = "PQMS_STAFF_ROLE_FINAL_APPROVE_LOG";
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

               PQMS_STAFF_ApproveRequestCheckListView.Columns[9].Visible = true;
            }


            query = query + "SELECT a.IDX , a.approveIdx , b.*, a.CurrentApproveDepth, a.FinalApproveDepth, c.accountNo, c.MyApproveDepth, c.MaxApproveDepth, a.requestedBy ";
            query = query + " FROM ["+ t2_Log + "] a   ";
            query = query + " inner join ["+ t1 + "] b on (a.approveIdx = b.idx)   ";
            query = query + " inner join (select * from [accountMaster].[dbo].[approveRole_V1] where accountNo = " + accountNo + ") c ";
            query = query + " on (a.appNo = c.appNo and a.workNo = c.workNo and a.MenuNo = c.MenuNo and a.DeptNo = c.DeptNo  and b.requestStatusCode = c.MyApproveDepth) "; //and b.requestStatusCode = c.MyApproveDepth 추가

            if (MyApproveDepth == 2) //2차 승인권자의 경우는 1차 승인이 완료된 경우에만 승인이 가능 하기 때문에 로직 추가 
            {
                query = query + " inner join  (select approveIdx from  "+ t2_Log + " where FinalApproveDepth = 0 and approvedYN ='Y')  x 	   on a.approveIdx = x.approveIdx  ";
            }

            query = query + " where a.appNo = " + appNo;
            query = query + " and a.workNo = " + WorkNo;
            query = query + " and a.MenuNo = " + MenuNo;
            //query = query + "and a.DeptNo = '" + requesterDeptCode + "'" ; //approvedBy(승인권자는 어떤 부서든지 승인할 수 있기 때문에, 특정 부서만 조회할 필요없음
            query = query + " and a.requestTo = '" + approvedby + "'"; //모든 승인 요청 과정에 승인권자를 지정하도록 한다. 만약 승인권자의 지정없이 부서별로 승인이 가능하도록 하려면, 반드시 해당 부서의 팀장이나 상위부서의 팀장만을 승인권자로 설정해서 처리 토록 한다.
            query = query + " and a.CurrentApproveDepth < c.MyApproveDepth ";
            query = query + " and a.approvedYN != 'Y' ";
            query = query + " and (a.rejectDate is null or a.rejectDate = '')";
            query = query + " and b.approveStatusCode = 0   ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();            
         

            DataTable dt = new DataTable();

            PQMS_STAFF_ApproveRequestCheckListGrid.DataSource = null; 

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    PQMS_STAFF_ApproveRequestCheckListGrid.DataSource = dt;
                }
            }
            Conn.Close();

        }
           

        private void save_rejected(string t1, string t2_log)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            //query = " insert into PQMS_STAFF_ROLE_APPROVE_LOG ";
            //query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
            //query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
            //query = query + "" + idxToBeApproved + ", ";
            //query = query + "" + appNo + ", ";
            //query = query + "'" + requesterDeptCode + "', ";
            //query = query + "" + WorkNo + ", ";
            //query = query + "" + MenuNo + ", ";
            //query = query + "'" + requestedby + "',"; //승인 요청자에게 승인 보류 처리 함
            //query = query + "0, ";  //MyApproveDepth //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
            //query = query + "0,"; //FinalApproveDepth //target/final approve depth
            //query = query + "'" + approvedby + "', ";
            //query = query + "'N',"; //N:Not approved, Y:approved
            //query = query + "'', "; //approvedby = '' 처리
            //query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            //query = query + "'', ";
            //query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            //query = query + "N'" + txtApproveComment.Text + "')";

            //OleDbCommand cmd = new OleDbCommand(query, Conn);

            //Conn.Open();
            //cmd.ExecuteNonQuery();
            ////Conn.Close();

            query = " update "+ t2_log + " set ";
            query = query + " rejectDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            query = query + " approveComment = N'" + txtApproveComment.Text + "'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();

            cmd.ExecuteNonQuery();

            //Conn.Close();


            query = " update "+ t1 + " set ";
            query = query + " appNo = " + appNo + ",";
            query = query + " DeptNo = '" + requesterDeptCode + "',";
            query = query + " WorkNo = " + WorkNo + ",";
            query = query + " MenuNo = " + MenuNo + ",";
            query = query + " requestStatusCode = 0" + ",";  //1: requested, 0/null:not requested
            query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
            query = query + " approveComment = N'" + txtRequestContent.Text + "'";
            query = query + " where IDX = " + idxToBeApproved + "";


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();

            //MessageBox.Show(query);
        }


        private void create_Traning_Attendee()
        {
            //작성자의 staff_code값 확인 
            string idx_staff_code = "";
            string query = " select Staff_CODE from PQMS_STAFF_TRAINING" +
                            " where IDX = " + txtToBeApproved.Text.Trim();

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        idx_staff_code = reader.GetValue(0).ToString(); //                 
                    }
                }
            }
            Conn.Close();


            query = " SELECT * FROM PQMS_STAFF_TRAINING_ATTENDEE " +
                " Where H_IDX = " + txtToBeApproved.Text.Trim();
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            DataTable dt = new DataTable();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);                   
                }
            }
            Conn.Close();

            if (dt != null && dt.Rows.Count > 0)
            {                
                Conn.Open();
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (idx_staff_code != dt.Rows[i]["STAFF_CODE"].ToString())
                    {
                        string insert_query = " insert into PQMS_STAFF_TRAINING ( " +
                                        " STAFF_CODE, STAFF_TRAIN_COURSE, STAFF_TRAIN_GUBUN, STAFF_TRAIN_ORG, STAFF_TRAIN_EDU, STAFF_TRAIN_TRAINER, STAFF_TRAIN_DATE " +
                                        " , STAFF_TRAIN_DATE_TO, STAFF_TRAIN_HOUR, STAFF_TRAIN_ATTENDEE, STAFF_TRAIN_GOAL, STAFF_TRAIN_SUMMARY, STAFF_TRAIN_CONTENTS" +
                                        " , STAFF_TRAIN_RESULT, STAFF_TRAIN_RESULT_DIR_FILE, STAFF_TRAIN_REVIEW, STAFF_TRAIN_WRITER, STAFF_TRAIN_WRITE_DATE, STAFF_TRAIN_REVIEWER" +
                                        " , STAFF_TRAIN_REVIEW_DATE, STAFF_TRAIN_APPROVER, STAFF_TRAIN_APPROVAL_DATE, STAFF_TRAIN_REPORT_FILE, appNo" +
                                        " , DeptNo, WorkNo, MenuNo, requestStatusCode, approveStatusCode, approveComment )" +
                                        " select '" + dt.Rows[i]["STAFF_CODE"].ToString() + "' " +
                                        " ,STAFF_TRAIN_COURSE,STAFF_TRAIN_GUBUN,STAFF_TRAIN_ORG,STAFF_TRAIN_EDU,STAFF_TRAIN_TRAINER,STAFF_TRAIN_DATE  " +
                                        " ,STAFF_TRAIN_DATE_TO,STAFF_TRAIN_HOUR,STAFF_TRAIN_ATTENDEE,STAFF_TRAIN_GOAL,STAFF_TRAIN_SUMMARY,STAFF_TRAIN_CONTENTS" +
                                        " ,STAFF_TRAIN_RESULT,STAFF_TRAIN_RESULT_DIR_FILE,STAFF_TRAIN_REVIEW,STAFF_TRAIN_WRITER,STAFF_TRAIN_WRITE_DATE,STAFF_TRAIN_REVIEWER" +
                                        " ,STAFF_TRAIN_REVIEW_DATE,STAFF_TRAIN_APPROVER,STAFF_TRAIN_APPROVAL_DATE,STAFF_TRAIN_REPORT_FILE,appNo" +
                                        " ,DeptNo,WorkNo,MenuNo,requestStatusCode,approveStatusCode,approveComment" +
                                        " from PQMS_STAFF_TRAINING" +
                                        " where IDX = " + txtToBeApproved.Text.Trim();
                        cmd = new OleDbCommand(insert_query, Conn);
                        cmd.ExecuteNonQuery();
                    }
                    
                }
                Conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtidxNo.Text == "" || txtToBeApproved.Text == "")
            {
                MessageBox.Show("승인할 자료를 선택하세요");
                return;
            }

            requestedby = approvedby; //현재 승인권자가 상위 승인권자에게 승인 요청하는 요청자로서 처리
            //approvedby = approvedby;

            if (MyApproveDepth < FinalApproveDepth) //1차 승인자 
            {                
                if (Form2_Tab_Info_Now.sTabName == "교육보고서")
                {                    
                    save_approved("PQMS_STAFF_TRAINING", "PQMS_STAFF_TRAINING_APPROVE_LOG");
                }
                else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
                {
                    //   save_approved("PQMS_STAFF_ROLE_PAPER", "PQMS_STAFF_ROLE_PAPER_APPROVE_LOG");
                    save_approved("PQMS_STAFF_ROLE_PAPER_FINAL", "PQMS_STAFF_ROLE_PAPER_FINAL_APPROVE_LOG");
                    final_RolePaper("검토");
                }
                else if (Form2_Tab_Info_Now.sTabName == "임명장")
                {
                    save_approved("PQMS_STAFF_ROLE_APPOINT", "PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG");
                }
                else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
                {
                    save_approved("PQMS_STAFF_RP_EACH_LIST", "PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG");
                }
                else if (Form2_Tab_Info_Now.sTabName == "직무자료")
                {
                    //save_approved("PQMS_STAFF_ROLE", "PQMS_STAFF_ROLE_APPROVE_LOG");
                    save_approved("PQMS_STAFF_ROLE_FINAL", "PQMS_STAFF_ROLE_FINAL_APPROVE_LOG");
                }
                else if (Form2_Tab_Info_Now.sTabName == "조직도")
                {
                    save_approved("PQMS_STAFF_ORG_CHART", "PQMS_STAFF_ORG_CHART_APPROVE_LOG");
                }
                else if (Form2_Tab_Info_Now.sTabName == "수정변경요청")
                {
                    save_approved("PQMS_STAFF_EDITREQUEST", "PQMS_STAFF_EDITREQUEST_APPROVE_LOG");
                }
                else if (Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")
                {
                    save_approved("PQMS_STAFF_ASSESSMENT_REPORT", "PQMS_STAFF_ASSESSMENT_REPORT_APPROVE_LOG");
                }

                send_email();
                MessageBox.Show("1차 검토 완료");
               

            }
            else //2차 승인자 
            {
                if (Form2_Tab_Info_Now.sTabName == "교육보고서")
                {
                    save_approved("PQMS_STAFF_TRAINING", "PQMS_STAFF_TRAINING_APPROVE_LOG");
                    final_approve("PQMS_STAFF_TRAINING");

                    //승인 완료후 승인 레포트에 승인일자 넣기 위해 파일 재생성 
                    final_EduReport();

                    //참석자 테이블에 있는 STAFF_CODE PQMS_STAFF_TRAINING 테이블이 INSERT 
                    create_Traning_Attendee();
                }
                else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
                {
                    //save_approved("PQMS_STAFF_ROLE_PAPER", "PQMS_STAFF_ROLE_PAPER_APPROVE_LOG");
                    //final_approve("PQMS_STAFF_ROLE_PAPER");

                    save_approved("PQMS_STAFF_ROLE_PAPER_FINAL", "PQMS_STAFF_ROLE_PAPER_FINAL_APPROVE_LOG");
                    final_approve("PQMS_STAFF_ROLE_PAPER_FINAL");
                    final_RolePaper("승인");
                }
                else if (Form2_Tab_Info_Now.sTabName == "임명장")
                {
                    save_approved("PQMS_STAFF_ROLE_APPOINT", "PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG");
                    final_approve("PQMS_STAFF_ROLE_APPOINT");
                }
                else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
                {
                    save_approved("PQMS_STAFF_RP_EACH_LIST", "PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG");
                    final_approve("PQMS_STAFF_RP_EACH_LIST");
                }
                else if (Form2_Tab_Info_Now.sTabName == "직무자료")
                {
                    //save_approved("PQMS_STAFF_ROLE", "PQMS_STAFF_ROLE_APPROVE_LOG");
                    //final_approve("PQMS_STAFF_ROLE");
                    save_approved("PQMS_STAFF_ROLE_FINAL", "PQMS_STAFF_ROLE_FINAL_APPROVE_LOG");
                    final_approve("PQMS_STAFF_ROLE_FINAL");
                }
                else if (Form2_Tab_Info_Now.sTabName == "조직도")
                {
                    save_approved("PQMS_STAFF_ORG_CHART", "PQMS_STAFF_ORG_CHART_APPROVE_LOG");
                    final_approve("PQMS_STAFF_ORG_CHART");
                }
                else if (Form2_Tab_Info_Now.sTabName == "수정변경요청")
                {
                    save_approved("PQMS_STAFF_EDITREQUEST", "PQMS_STAFF_EDITREQUEST_APPROVE_LOG");
                    final_approve("PQMS_STAFF_EDITREQUEST");
                }
                else if (Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")
                {
                    save_approved("PQMS_STAFF_ASSESSMENT_REPORT", "PQMS_STAFF_ASSESSMENT_REPORT_APPROVE_LOG");
                   final_approve("PQMS_STAFF_ASSESSMENT_REPORT");                    
                }

                MessageBox.Show("최종 승인 완료");
            }


            txtidxNo.Text = "";
            txtToBeApproved.Text = "";


            MyApproveDepth = get_my_approve_depth();
            get_data_tobe_approved();
            

        }

        private void final_EduReport()
        {
            //승인 완료 후 파일 재생성 
            string rpt = s_eduFile;
            string sDateTime_yyyyMMdd = DateTime.Now.ToString("yyyy-MM-dd");

            string s_Paht = Path.GetDirectoryName(rpt);
            string s_NAme = Path.GetFileNameWithoutExtension(rpt) + ".doc";

            string s_full = s_Paht + "\\" + s_NAme;
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(rpt);
            doc.SaveToFile(s_full, Spire.Pdf.FileFormat.DOC);
            Delay(2000);
            //기존파일 pdf 삭제 
            if (File.Exists(rpt))
            {
                try
                {
                    File.Delete(rpt);
                }
                catch (Exception e)
                {
                    //Console.WriteLine("The deletion failed: {0}", e.Message);
                }
            }

            // DOC로 변환한 파일 에서 데이터 정보 수정 
            Document document = new Document();
            document.LoadFromFile(s_full);
            FontStyle(document);


            string s_ApproverName = get_ApproverName();

            string tmp = s_ApproverName.ToString() + "/" + sDateTime_yyyyMMdd.ToString(); //승인자이름 / 날짜 
            document.Replace("txt_ApproverName_Date", tmp, false, true);            
        
            document.SaveToFile(rpt); // pdf 로 다시 저장 

            //doc 파일 삭제
            if (File.Exists(s_full))
            {
                try
                {
                    File.Delete(s_full);
                }
                catch (Exception e)
                {
                    //Console.WriteLine("The deletion failed: {0}", e.Message);
                }
            }
        }


        private void final_RolePaper(string sAppType="") 
        {
            string rpt = @s_filepath;

            string sDateTime_yyyyMMdd = DateTime.Now.ToString("yyyy-MM-dd");

            string s_Paht = Path.GetDirectoryName(rpt);
            string s_NAme = Path.GetFileNameWithoutExtension(rpt) + ".doc";

            string s_full = s_Paht + "\\" + s_NAme;

            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(rpt);
            doc.SaveToFile(s_full, Spire.Pdf.FileFormat.DOC);

            Delay(2000);

            //기존파일 pdf 삭제 
            if (File.Exists(rpt))
            {
                try
                {
                    File.Delete(rpt);
                }
                catch (Exception e)
                {
                    //Console.WriteLine("The deletion failed: {0}", e.Message);
                }
            }

            // DOC로 변환한 파일 에서 데이터 정보 수정 
            Document document = new Document();
            document.LoadFromFile(s_full);
            FontStyle(document);

            string s_ApproverName = get_ApproverName();

            //검토자 승인자 정보 입력            
            if (sAppType == "검토") //검토 
            {
                string tmp = s_ApproverName.ToString() + "/" + sDateTime_yyyyMMdd.ToString(); //승인자이름 / 날짜 
                document.Replace("TxtReviewer1_Name_Date", tmp, false, true);  

            }
            else if (sAppType == "승인") //승인
            {
                string tmp = s_ApproverName.ToString() + "/" + sDateTime_yyyyMMdd.ToString(); //승인자이름 / 날짜 
                document.Replace("TxtApprover2_Name_Date", tmp, false, true);
                document.Replace("TxtReviewer1_Name_Date", "", false, true); //검토자가 없는 경우 공백으로 변경 
            }
            document.SaveToFile(rpt); // pdf 로 다시 저장 

            //doc 파일 삭제
            if (File.Exists(s_full))
            {
                try
                {
                    File.Delete(s_full);
                }
                catch (Exception e)
                {
                    //Console.WriteLine("The deletion failed: {0}", e.Message);
                }
            }          
        }


        private void final_Assessment()
        {
            string rpt = @s_filepath;
       
            string sDateTime_yyyyMMdd = DateTime.Now.ToString("yyyy-MM-dd");

            string s_Paht = Path.GetDirectoryName(rpt);
            string s_NAme = Path.GetFileNameWithoutExtension(rpt)+".doc";

            string s_full = s_Paht + "\\" + s_NAme;

            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(rpt);
            doc.SaveToFile(s_full , Spire.Pdf.FileFormat.DOC);

            Delay(2000);

            //기존파일 pdf 삭제 
            if (File.Exists(rpt))
            {
                try
                {
                    File.Delete(rpt);
                }
                catch (Exception e)
                {
                    //Console.WriteLine("The deletion failed: {0}", e.Message);
                }
            }

            // DOC로 변환한 파일 에서 데이터 정보 수정 
            Document document = new Document();
            document.LoadFromFile(s_full);
            FontStyle(document);

            string s_ApproverName = get_ApproverName();

            //승인자 정보 입력
            document.Replace("txtApp", s_ApproverName.ToString(), false, true);  //승인자이름
            document.Replace("txtAppDate", sDateTime_yyyyMMdd.ToString(), false, true);  //승인일자

            document.SaveToFile(rpt); // pdf 로 다시 저장 
            

            //doc 파일 삭제
            if (File.Exists(s_full))
            {
                try
                {
                    File.Delete(s_full);
                }
                catch (Exception e)
                {
                    //Console.WriteLine("The deletion failed: {0}", e.Message);
                }
            }
        }

        public void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {
                System.Windows.Forms.Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }
            return;
        }

        private void FontStyle(Document document)
        {
            ParagraphStyle krft = new ParagraphStyle(document);
            krft.Name = "kr";
            krft.CharacterFormat.FontName = "굴림";
            krft.CharacterFormat.FontSize = 10;
            document.Styles.Add(krft);

            ParagraphStyle enft = new ParagraphStyle(document);
            enft.Name = "en";
            enft.CharacterFormat.FontName = "Arial";
            enft.CharacterFormat.FontSize = 10;
            document.Styles.Add(enft);
        }

        private void send_email()
        {

            string sql = "";
            string t2_log = "";

            if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                t2_log = "PQMS_STAFF_TRAINING_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                //t2_log ="PQMS_STAFF_ROLE_PAPER_APPROVE_LOG";
                t2_log = "PQMS_STAFF_ROLE_PAPER_FINAL_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                t2_log ="PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
            {
                t2_log= "PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무자료")
            {
                t2_log= "PQMS_STAFF_ROLE_FINAL_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "조직도")
            {
                t2_log= "PQMS_STAFF_ORG_CHART_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "수정변경요청")
            {
                t2_log = "PQMS_STAFF_EDITREQUEST_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")
            {
                t2_log = "PQMS_STAFF_ASSESSMENT_REPORT_APPROVE_LOG";
            }

            sql = "select * from " + t2_log;
            sql = sql + " where approveIdx = " + txtToBeApproved.Text + " and approvedYN='N'"; // 1차 승인 완료후 2차 승인권자를 찾기

            Conn = new OleDbConnection(unitCommon.connect_string);
            OleDbCommand cmd = new OleDbCommand(sql, Conn);
            Conn.Open();

            DataTable dt = new DataTable();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);                    
                }
            }
            Conn.Close();

            unitSMTP.sFROM = dt.Rows[0]["requestedBy"].ToString();
            unitSMTP.sTO = dt.Rows[0]["requestTo"].ToString();
            unitSMTP.sSUBJECT = "PQMS " + Form2_Tab_Info_Now.sTabName + " 승인요청 ";
            unitSMTP.sBODY = "PQMS " + Form2_Tab_Info_Now.sTabName + "\n\n" + "승인 요청 대상 번호 : " + txtToBeApproved.Text + " 승인요청  드립니다.";
            unitSMTP.Email_Send();

        }


        private void save_approved(string t1, string t2_log)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " update "+ t2_log + " set ";
            query = query + " approvedBy = '" + approvedby + "',";
            query = query + " approveDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "',";
            query = query + " approvedYN = 'Y', " ;
            query = query + " approveComment =N'" + txtApproveComment.Text + "'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();          
     

            query = " update "+  t1  + " set ";
            query = query + " appNo = " + appNo + ",";
            query = query + " DeptNo = '" + requesterDeptCode + "',";
            query = query + " WorkNo = " + WorkNo + ",";
            query = query + " MenuNo = " + MenuNo + ",";
            query = query + " requestStatusCode = 2" + ",";  //1: requested, 0/null:not requested //2차 승인권자에게 넘기기 위한 작업 
            query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
            query = query + " approveComment = N'" + txtRequestContent.Text + "'";
            query = query + " where IDX = " + idxToBeApproved + "";
            cmd = new OleDbCommand(query, Conn);
            cmd.ExecuteNonQuery();


            //직무기술서는 PQMS_STAFF_ROLE_PAPER 테이블도 신청 완료 처리를 위해서 추가 처리 해야함. 
            if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                query = " update PQMS_STAFF_ROLE_PAPER set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 2" + ",";  //1: requested, 0/null:not requested / 2: 1차 승인 완료상태
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved  
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX in  ( "+ s_rpIDX +")";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();
            }            
            else if (Form2_Tab_Info_Now.sTabName == "직무자료")//직무자료는 PQMS_STAFF_ROLE 테이블도 신청 완료 처리를 위해서 추가 처리 해야함. 
            {
                query = " update PQMS_STAFF_ROLE set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 2" + ",";  //1: requested, 0/null:not requested / 2: 1차 승인 완료상태
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved  
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX in  ( " + s_rIDX + ")";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();
            }



            Conn.Close();

            //MessageBox.Show(query);
        }


        private void final_approve(string t1)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE "+ t1 + " SET ";
            query = query + " approveStatusCode = 1";
            query = query + " WHERE IDX = " + idxToBeApproved + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();

            //직무기술서는 PQMS_STAFF_ROLE_PAPER 테이블도 신청 완료 처리를 위해서 추가 처리 해야함. 
            if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                query = " update PQMS_STAFF_ROLE_PAPER set ";
                query = query + " approveStatusCode = 1";
                query = query + " where IDX in  ( " + s_rpIDX + ")";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무자료") //직무자료는 PQMS_STAFF_ROLE 테이블도 신청 완료 처리를 위해서 추가 처리 해야함. 
            {
                query = " update PQMS_STAFF_ROLE set ";
                query = query + " approveStatusCode = 1";
                query = query + " where IDX in  ( " + s_rIDX + ")";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();
            }
            else if (Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")            
            {
                final_Assessment();  // 승인데이터 보고서에 넣기 위한 로직 
            }

            Conn.Close();
        }
              


        private void button2_Click(object sender, EventArgs e)
        {
            //requestedby = approvedby;
            //approvedby = approvedby;
            
            if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                save_rejected("PQMS_STAFF_TRAINING", "PQMS_STAFF_TRAINING_APPROVE_LOG");
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                // save_rejected("PQMS_STAFF_ROLE_PAPER", "PQMS_STAFF_ROLE_PAPER_APPROVE_LOG");
                save_rejected("PQMS_STAFF_ROLE_PAPER_FINAL", "PQMS_STAFF_ROLE_PAPER_FINAL_APPROVE_LOG");
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                save_rejected("PQMS_STAFF_ROLE_APPOINT", "PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG");
            }
            else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
            {
                save_rejected("PQMS_STAFF_RP_EACH_LIST", "PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG");
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무자료")
            {
                save_rejected("PQMS_STAFF_ROLE_FINAL", "PQMS_STAFF_ROLE_FINAL_APPROVE_LOG");
            }
            else if (Form2_Tab_Info_Now.sTabName == "조직도")
            {
                save_rejected("PQMS_STAFF_ORG_CHART", "PQMS_STAFF_ORG_CHART_APPROVE_LOG");
            }
            else if (Form2_Tab_Info_Now.sTabName == "수정변경요청")
            {
                save_rejected("PQMS_STAFF_EDITREQUEST", "PQMS_STAFF_EDITREQUEST_APPROVE_LOG");
            }
            else if (Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")
            {
                save_rejected("PQMS_STAFF_ASSESSMENT_REPORT", "PQMS_STAFF_ASSESSMENT_REPORT_APPROVE_LOG");
            }

            MessageBox.Show(MyApproveDepth.ToString() + " 차 반려 처리 완료");
            get_data_tobe_approved();

        }

        private void PQMS_STAFF_ApproveRequestCheckListView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                s_rpIDX = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("PQMS_STAFF_ROLE_PAPER_IDX").ToString();
                s_filepath = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedDataRow()["RP_FINAL_FILE"].ToString();
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무자료")
            {
                s_rIDX = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("PQMS_STAFF_ROLE_IDX").ToString();
            }
            else if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                s_eduFile = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("STAFF_TRAIN_REPORT_FILE").ToString();
                s_staffcode = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("STAFF_CODE").ToString();
            }
            else if (Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")
            {
                s_filepath = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedDataRow()["FINAL_FILE"].ToString();
            }

            txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("IDX").ToString();
            txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("approveIdx").ToString();
            txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("approveComment").ToString();

            idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("approveIdx").ToString());            
            MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("MyApproveDepth").ToString());
            FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("MaxApproveDepth").ToString());
            requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("DeptNo").ToString();
            requestedby = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedRowCellValue("requestedBy").ToString();            

            if (e.Column.Caption.Equals("교육보고서"))
            {
                string strFile = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedDataRow()["STAFF_TRAIN_REPORT_FILE"].ToString();
                
                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }else if (e.Column.Caption.Equals("자격부여평가보고서"))
            {
                string strFile = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedDataRow()["FINAL_FILE"].ToString();                

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
            else if (e.Column.Caption.Equals("직무기술서"))
            {
                string strFile = PQMS_STAFF_ApproveRequestCheckListView.GetFocusedDataRow()["RP_FINAL_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

    }
}

