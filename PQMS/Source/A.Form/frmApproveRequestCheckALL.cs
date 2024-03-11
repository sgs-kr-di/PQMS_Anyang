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
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;



namespace PQMS
{
    public partial class frmApproveRequestCheckALL : Form
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


        public frmApproveRequestCheckALL()
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
            //set_approve_parameter();
            //get_approve_param(); //승인관련변수할당 -> userManagement -> 승인업무정리 참조


            //get_approval_right1();
            //get_approval_right2();
            //get_max_role_depth();

            // get_data_tobe_approved();
            btnAppRequest_Click(sender,e);

           


        }

        private void set_approve_parameter(string sName)
        {
            string[] frmText = this.Text.Split('-');
            txtidxNo.Text = Form2_GridIdx.sIDX;
            accountNo = Convert.ToInt32(Form2PQMS_LoginInfo.sAccountNo);
            appNo = get_appno(Form2PQMS_LoginInfo.sAppId);
            //MenuNo = get_Menuno(frmText[0]);
            //WorkNo = get_Workno(frmText[1]);
            MenuNo = get_Menuno("부서관리");
            WorkNo = get_Workno(sName);
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

        private string get_ApproverPosition()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            string returnposition = "";
            query = "SELECT STAFF_POSITION FROM PQMS_STAFF ";
            query = query + "   WHERE STAFF_EMPNO = '" + Form2PQMS_LoginInfo.sEmpNo + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        returnposition = reader.GetValue(0).ToString();
                    }
                }
            }
            Conn.Close();

            return returnposition;
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
            query = query + "  order by 1 desc " ;

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
                          
        private void btnAppRequest_Click(object sender, EventArgs e)
        {
            set_approve_parameter("임명장");
            get_data_tobe_approved_Roel();

            set_approve_parameter("직무기술서");
            get_data_tobe_approved_RoelPaper();

            set_approve_parameter("자격부여평가보고서");
            get_data_tobe_approved_Assessment();

            set_approve_parameter("시험수행능력평가");
            get_data_tobe_approved_EachList();

            //get_data_tobe_approved();
            set_approve_parameter("교육보고서");
            get_data_tobe_approved_Training();
        }

        private void get_data_tobe_approved_Roel()
        {
            //임명장
            Conn = new OleDbConnection(unitCommon.connect_string);
            string[] frmText = this.Text.Split('-');
            string query = "";

            string t1 = "";
            string t2_Log = "";
            t1 = "PQMS_STAFF_ROLE";
            t2_Log = "PQMS_STAFF_ROLE_APPROVE_LOG";

            query = query + "SELECT a.IDX , a.approveIdx , substring(a.requestDate, 0,12)requestDate , b.*, a.CurrentApproveDepth, a.FinalApproveDepth, c.accountNo, c.MyApproveDepth, c.MaxApproveDepth, a.requestedBy , y.firstName ";
            query = query + " ,(CASE WHEN c.MyApproveDepth  = '1'  THEN '검토' WHEN c.MyApproveDepth = '2' THEN '승인'  ELSE ''  END) AS 'approvedMyApproveDepth' ";
            query = query + " FROM [" + t2_Log + "] a   ";
            query = query + " inner join [" + t1 + "] b on (a.approveIdx = b.idx)   ";
            query = query + " inner join (select * from [accountMaster].[dbo].[approveRole_V1] where accountNo = " + accountNo + ") c ";
            query = query + " on (a.appNo = c.appNo and a.workNo = c.workNo and a.MenuNo = c.MenuNo and a.DeptNo = c.DeptNo  and b.requestStatusCode = c.MyApproveDepth) "; //and b.requestStatusCode = c.MyApproveDepth 추가

            if (MyApproveDepth == 2) //2차 승인권자의 경우는 1차 승인이 완료된 경우에만 승인이 가능 하기 때문에 로직 추가 
            {
                query = query + " inner join  (select approveIdx from  " + t2_Log + " where FinalApproveDepth = 0 and approvedYN ='Y')  x 	   on a.approveIdx = x.approveIdx  ";
            }
            query = query + " inner join [accountMaster].[dbo].[userMaster] y on a.requestedBy = y.userID  ";
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
            PQMS_STAFF_ApproveRequestCheckListGrid_Role.DataSource = null;
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    PQMS_STAFF_ApproveRequestCheckListGrid_Role.DataSource = dt;
                }
            }
            Conn.Close();
        }

        private void get_data_tobe_approved_Training()
        {
            //교육보고서
            Conn = new OleDbConnection(unitCommon.connect_string);
            string[] frmText = this.Text.Split('-');            
            string query = "";

            string t1 = "";
            string t2_Log = "";

            t1 = "PQMS_STAFF_TRAINING";
            t2_Log = "PQMS_STAFF_TRAINING_APPROVE_LOG";
            //PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.Columns[8].Visible = true;

            query = query + "SELECT a.IDX , a.approveIdx ,substring(a.requestDate, 0,12)requestDate , b.*, a.CurrentApproveDepth, a.FinalApproveDepth, c.accountNo, c.MyApproveDepth, c.MaxApproveDepth, a.requestedBy, y.firstName ";
            query = query + " ,(CASE WHEN c.MyApproveDepth  = '1'  THEN '검토' WHEN c.MyApproveDepth = '2' THEN '승인'  ELSE ''  END) AS 'approvedMyApproveDepth' ";
            query = query + " FROM [" + t2_Log + "] a   ";
            query = query + " inner join [" + t1 + "] b on (a.approveIdx = b.idx)   ";
            query = query + " inner join (select * from [accountMaster].[dbo].[approveRole_V1] where accountNo = " + accountNo + ") c ";
            query = query + " on (a.appNo = c.appNo and a.workNo = c.workNo and a.MenuNo = c.MenuNo and a.DeptNo = c.DeptNo  and b.requestStatusCode = c.MyApproveDepth) "; //and b.requestStatusCode = c.MyApproveDepth 추가

            if (MyApproveDepth == 2) //2차 승인권자의 경우는 1차 승인이 완료된 경우에만 승인이 가능 하기 때문에 로직 추가 
            {
                query = query + " inner join  (select approveIdx from  " + t2_Log + " where FinalApproveDepth = 0 and approvedYN ='Y')  x 	   on a.approveIdx = x.approveIdx  ";
            }
            query = query + " inner join [accountMaster].[dbo].[userMaster] y on a.requestedBy = y.userID  ";
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

            PQMS_STAFF_ApproveRequestCheckListGrid_Training.DataSource = null;

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);                    

                    dt.Columns.Add("Opinion", typeof(string));

                    // GridView에 opinion column 추가
                    GridColumn opinionColumn = new GridColumn
                    {
                        FieldName = "Opinion",
                        Caption = "Opinion",
                        VisibleIndex = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.Columns.Count, // 적절한 위치에 추가
                        Width = 200,
                    };
                    opinionColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; // 헤더 가운데 정렬 설정
                    PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.Columns.Add(opinionColumn);                    
                    PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GridControl.DataSource = dt;
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Opinion"] = "";
                    }
                    // GridView 업데이트
                    PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.RefreshData();


                }
            }

            Conn.Close();
        }

        private void get_data_tobe_approved_EachList()
        {
            //시험수행능력평가 
            Conn = new OleDbConnection(unitCommon.connect_string);
            string[] frmText = this.Text.Split('-');            
            string query = "";

            string t1 = "";
            string t2_Log = "";

            t1 = "PQMS_STAFF_RP_EACH_LIST";
            t2_Log = "PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG";


            query = query + "SELECT a.IDX , z.FILE_PATH, a.approveIdx ,substring(a.requestDate, 0,12)requestDate , b.*, a.CurrentApproveDepth, a.FinalApproveDepth, c.accountNo, c.MyApproveDepth, c.MaxApproveDepth, a.requestedBy, y.firstName ";
            query = query + " ,(CASE WHEN c.MyApproveDepth  = '1'  THEN '검토' WHEN c.MyApproveDepth = '2' THEN '승인'  ELSE ''  END) AS 'approvedMyApproveDepth' ";
            query = query + " FROM [" + t2_Log + "] a   ";
            query = query + " inner join [" + t1 + "] b on (a.approveIdx = b.idx)   ";
            query = query + " inner join (select * from [accountMaster].[dbo].[approveRole_V1] where accountNo = " + accountNo + ") c ";
            query = query + " on (a.appNo = c.appNo and a.workNo = c.workNo and a.MenuNo = c.MenuNo and a.DeptNo = c.DeptNo  and b.requestStatusCode = c.MyApproveDepth) "; //and b.requestStatusCode = c.MyApproveDepth 추가

            if (MyApproveDepth == 2) //2차 승인권자의 경우는 1차 승인이 완료된 경우에만 승인이 가능 하기 때문에 로직 추가 
            {
                query = query + " inner join  (select approveIdx from  " + t2_Log + " where FinalApproveDepth = 0 and approvedYN ='Y')  x 	   on a.approveIdx = x.approveIdx  ";
            }
            query = query + " inner join PQMS_STAFF_RP_EACH_LIST_FOLDER z on b.staff_code = z.staff_code "; 
            query = query + " inner join [accountMaster].[dbo].[userMaster] y on a.requestedBy = y.userID  ";
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

            PQMS_STAFF_ApproveRequestCheckListGrid_EachList.DataSource = null;

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    PQMS_STAFF_ApproveRequestCheckListGrid_EachList.DataSource = dt;
                }
            }
            Conn.Close();
        }

        private void get_data_tobe_approved_Assessment()
        {

            //자격부여평가보고서
            Conn = new OleDbConnection(unitCommon.connect_string);
            string[] frmText = this.Text.Split('-');            
            string query = "";

            string t1 = "";
            string t2_Log = "";

            t1 = "PQMS_STAFF_ASSESSMENT_REPORT";
            t2_Log = "PQMS_STAFF_ASSESSMENT_REPORT_APPROVE_LOG";

            //PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.Columns[9].Visible = true;

            query = query + "SELECT a.IDX , a.approveIdx ,substring(a.requestDate, 0,12)requestDate , b.*, a.CurrentApproveDepth, a.FinalApproveDepth, c.accountNo, c.MyApproveDepth, c.MaxApproveDepth, a.requestedBy , y.firstName ";
            query = query + " ,(CASE WHEN c.MyApproveDepth  = '1'  THEN '검토' WHEN c.MyApproveDepth = '2' THEN '승인'  ELSE ''  END) AS 'approvedMyApproveDepth' ";
            query = query + " FROM [" + t2_Log + "] a   ";
            query = query + " inner join [" + t1 + "] b on (a.approveIdx = b.idx)   ";
            query = query + " inner join (select * from [accountMaster].[dbo].[approveRole_V1] where accountNo = " + accountNo + ") c ";
            query = query + " on (a.appNo = c.appNo and a.workNo = c.workNo and a.MenuNo = c.MenuNo and a.DeptNo = c.DeptNo  and b.requestStatusCode = c.MyApproveDepth) "; //and b.requestStatusCode = c.MyApproveDepth 추가

            if (MyApproveDepth == 2) //2차 승인권자의 경우는 1차 승인이 완료된 경우에만 승인이 가능 하기 때문에 로직 추가 
            {
                query = query + " inner join  (select approveIdx from  " + t2_Log + " where FinalApproveDepth = 0 and approvedYN ='Y')  x 	   on a.approveIdx = x.approveIdx  ";
            }
            query = query + " inner join [accountMaster].[dbo].[userMaster] y on a.requestedBy = y.userID  ";
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

            PQMS_STAFF_ApproveRequestCheckListGrid_Assessment.DataSource = null;

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    PQMS_STAFF_ApproveRequestCheckListGrid_Assessment.DataSource = dt;
                }
            }
            Conn.Close();

        }

        private void get_data_tobe_approved_RoelPaper()
        {
            //직무기술서
            Conn = new OleDbConnection(unitCommon.connect_string);
            string[] frmText = this.Text.Split('-');            
            string query = "";

            string t1 = "";
            string t2_Log = "";

            //t1 = "PQMS_STAFF_ROLE_PAPER_FINAL";
            //t2_Log = "PQMS_STAFF_ROLE_PAPER_FINAL_APPROVE_LOG";

            t1 = "PQMS_STAFF_ROLE_PAPER";
            t2_Log = "PQMS_STAFF_ROLE_PAPER_APPROVE_LOG";

            //PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.Columns[10].Visible = true;


            query = query + "SELECT a.IDX , a.approveIdx , substring(a.requestDate, 0,12)requestDate , b.*, a.CurrentApproveDepth, a.FinalApproveDepth, c.accountNo, c.MyApproveDepth, c.MaxApproveDepth, a.requestedBy , y.firstName ";
            query = query + " ,(CASE WHEN c.MyApproveDepth  = '1'  THEN '검토' WHEN c.MyApproveDepth = '2' THEN '승인'  ELSE ''  END) AS 'approvedMyApproveDepth' ";
            query = query + " FROM [" + t2_Log + "] a   ";
            query = query + " inner join [" + t1 + "] b on (a.approveIdx = b.idx)   ";
            query = query + " inner join (select * from [accountMaster].[dbo].[approveRole_V1] where accountNo = " + accountNo + ") c ";
            query = query + " on (a.appNo = c.appNo and a.workNo = c.workNo and a.MenuNo = c.MenuNo and a.DeptNo = c.DeptNo  and b.requestStatusCode = c.MyApproveDepth) "; //and b.requestStatusCode = c.MyApproveDepth 추가

            if (MyApproveDepth == 2) //2차 승인권자의 경우는 1차 승인이 완료된 경우에만 승인이 가능 하기 때문에 로직 추가 
            {
                query = query + " inner join  (select approveIdx from  " + t2_Log + " where FinalApproveDepth = 0 and approvedYN ='Y')  x 	   on a.approveIdx = x.approveIdx  ";
            }
            query = query + " inner join [accountMaster].[dbo].[userMaster] y on a.requestedBy = y.userID  ";
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

            PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper.DataSource = null;

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper.DataSource = dt;
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
            query = query + " approveStatusCode = 2" + ","; //1:approved, 0:not approved
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


        private void final_EduReport2(string s_eduFile = "", string s_opinion = "", string s_staffcode = "", string sIDX="", string s_resultfile="")
        {
            //승인 완료 후 파일 재생성 
            string rpt = s_eduFile;
            string sDateTime_yyyyMMdd = DateTime.Now.ToString("yyyy-MM-dd");

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

            DataTable dt_training = new DataTable();

            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = $" SELECT  a.*,  b.approveComment Coment, b.approveDate, d.firstName  " +
                $" FROM PQMS_STAFF_TRAINING a " +
                $" left outer join PQMS_STAFF_TRAINING_APPROVE_LOG b on a.IDX = b.approveIdx and CurrentApproveDepth = 1  " +
                $" left outer join accountMaster.dbo.accountMaster c on b.approvedBy = c.userID and c.appno = 3  " +
                $" left outer join accountMaster.dbo.userMaster d on d.userID = c.userID   " +
                $" WHERE a.STAFF_CODE='{s_staffcode}' and a.IDX='{sIDX}' ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_training.Load(reader);
            }
            Conn.Close();


            string tr_templeate = @"\\10.153.4.98\DI\PQMS\Template\EduReport\CQP-6021-F09 (01) 교육훈련 보고서.docx";

            if (dt_training.Rows.Count > 0)
            {
                Document document = new Document();                
                FontStyle(document);

                document.LoadFromFile(tr_templeate, Spire.Doc.FileFormat.Docx, "ANYANG"); //템플릿에 암호 설정
                document.RemoveEncryption();

                document.Replace("txt01", dt_training.Rows[0]["STAFF_TRAIN_EDU"].ToString(), false, true);
                document.Replace("txt02", dt_training.Rows[0]["STAFF_TRAIN_GUBUN"].ToString(), false, true);
                document.Replace("txt03", dt_training.Rows[0]["STAFF_TRAIN_ORG"].ToString(), false, true);
                document.Replace("txt04", dt_training.Rows[0]["STAFF_TRAIN_TRAINER"].ToString(), false, true);

                if (dt_training.Rows[0]["STAFF_TRAIN_DATE"].ToString().Trim() == dt_training.Rows[0]["STAFF_TRAIN_DATE_TO"].ToString().Trim()) // 두 날짜가 동일하면 하나만 표시 
                {
                    document.Replace("txt05", dt_training.Rows[0]["STAFF_TRAIN_DATE"].ToString(), false, true);
                }
                else
                {
                    document.Replace("txt05", dt_training.Rows[0]["STAFF_TRAIN_DATE"].ToString() + " ~ " + dt_training.Rows[0]["STAFF_TRAIN_DATE_TO"].ToString(), false, true);
                }
                document.Replace("txt06", dt_training.Rows[0]["STAFF_TRAIN_HOUR"].ToString(), false, true);
                document.Replace("txt07", dt_training.Rows[0]["STAFF_TRAIN_ATTENDEE"].ToString(), false, true);
                document.Replace("txt08", dt_training.Rows[0]["STAFF_TRAIN_GOAL"].ToString(), false, true);
                document.Replace("txt09", dt_training.Rows[0]["STAFF_TRAIN_SUMMARY"].ToString(), false, true);
                document.Replace("txt10", dt_training.Rows[0]["STAFF_TRAIN_CONTENTS"].ToString(), false, true);
                document.Replace("txt11", dt_training.Rows[0]["STAFF_TRAIN_RESULT"].ToString(), false, true);
                document.Replace("txt13", dt_training.Rows[0]["STAFF_TRAIN_WRITER"].ToString() + "/" + dt_training.Rows[0]["STAFF_TRAIN_WRITE_DATE"].ToString(), false, true);
                document.Replace("txt14", dt_training.Rows[0]["STAFF_TRAIN_REVIEWER"].ToString() + "/" + dt_training.Rows[0]["STAFF_TRAIN_REVIEW_DATE"].ToString(), false, true);


                string s_ApproverName = get_ApproverName();

                string tmp = s_ApproverName.ToString() + "/" + sDateTime_yyyyMMdd.ToString(); //승인자이름 / 날짜 
                document.Replace("txt_ApproverName_Date", tmp, false, true);
                document.Replace("txt12_Opinion_Coments", s_opinion, false, true);
                document.SaveToFile(rpt); // pdf 로 다시 저장 


                if (s_resultfile != "" && Path.GetExtension(s_resultfile).ToString().ToUpper() == ".PDF") // 훈련 증빙이 있고 증빙파일이 PDF 형식이면  교육훈련 보고서에 추가 
                {

                    //pdf파일이 증빙에 있으면 두개의 파일 합치기 ..
                    String[] files = new String[] { rpt, s_resultfile };
                    string outputFile = rpt;
                    PdfDocumentBase doc = PdfDocument.MergeFiles(files);
                    doc.Save(outputFile, Spire.Pdf.FileFormat.PDF);
                    
                }

            }

        }

        private void final_EduReport(string s_eduFile="", string s_opinion="")
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

            //// DOC로 변환한 파일 에서 데이터 정보 수정 
            Document document = new Document();
            document.LoadFromFile(s_full);
            FontStyle(document);

            string s_ApproverName = get_ApproverName();

            string tmp = s_ApproverName.ToString() + "/" + sDateTime_yyyyMMdd.ToString(); //승인자이름 / 날짜 
            document.Replace("txt_ApproverName_Date", tmp, false, true);


            //TableCell targetCell = FindTableCellWithText(document, "txt12_Opinion_Coments");
            //if (targetCell != null)
            //{
            //    targetCell.Width = s_opinion.Length * 20; // 적절한 너비를 설정하세요.
            //}



            //Table table = null;
            //foreach (Section section in document.Sections)
            //{
            //    foreach (Table tbl in section.Tables)
            //    {
            //        if (tbl.Title == "tb01")
            //        {
            //            table = tbl;
            //            break;
            //        }
            //    }
            //    if (table != null)
            //        break;
            //}

            //Paragraph para = table.Rows[7].Cells[2].Paragraphs[0]; //SGS파일번호 
            //para.Text = s_opinion.ToString();


            document.Replace("txt12_Opinion_Coments", s_opinion, false, true);
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

        private TableCell FindTableCellWithText(Document doc, string searchText)
        {
            foreach (Section section in doc.Sections)
            {
                foreach (DocumentObject docObject in section.Body.ChildObjects)
                {
                    if (docObject is Paragraph)
                    {
                        Paragraph paragraph = docObject as Paragraph;
                        // Paragraph 내에서 텍스트를 찾기
                        if (paragraph.Text.Contains(searchText))
                        {
                            // 텍스트를 찾으면 해당 TableCell 반환
                            return paragraph.Owner as TableCell;
                        }
                    }
                }
            }
            return null; // 텍스트가 없으면 null 반환
        }

        private void final_RolePaper(string sAppType="", string s_filepath="") 
        {
            string rpt = s_filepath;

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

        private void final_ROLE(string s_filepath="") //임명장
        {
            string rpt = s_filepath;
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
            string s_ApproverPositon = get_ApproverPosition();

            //승인자 정보 입력
            document.Replace("Txt09", s_ApproverPositon.ToString(), false, true);  //승인자 포지션
            document.Replace("Txt10", s_ApproverName.ToString(), false, true);  //승인자 이름 

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

        private void final_Assessment(string s_filepath="") //자격부여평가보고서
        {
            string rpt = s_filepath;
       
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
                t2_log ="PQMS_STAFF_ROLE_PAPER_APPROVE_LOG";
                //t2_log = "PQMS_STAFF_ROLE_PAPER_FINAL_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                t2_log ="PQMS_STAFF_ROLE_APPROVE_LOG";
            }
            else if (Form2_Tab_Info_Now.sTabName == "시험수행능력평가")
            {
                t2_log= "PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG";
            }            
            else if (Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")
            {
                t2_log = "PQMS_STAFF_ASSESSMENT_REPORT_APPROVE_LOG";
            }
            //else if (Form2_Tab_Info_Now.sTabName == "조직도")
            //{
            //    t2_log = "PQMS_STAFF_ORG_CHART_APPROVE_LOG";
            //}
            //else if (Form2_Tab_Info_Now.sTabName == "수정변경요청")
            //{
            //    t2_log = "PQMS_STAFF_EDITREQUEST_APPROVE_LOG";
            //}


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
            query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved //2승인거절 
            query = query + " approveComment = N'" + txtRequestContent.Text + "'";
            query = query + " where IDX = " + idxToBeApproved + "";
            cmd = new OleDbCommand(query, Conn);
            cmd.ExecuteNonQuery();
            Conn.Close();

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
            Conn.Close();
        }              

        private static bool CheckFile_Close(string networkFilePath)
        {
            try
            {

                FileInfo fileInfo = new FileInfo(networkFilePath);
                if (fileInfo.Exists)
                {
                    using (FileStream fs = File.Open(networkFilePath, FileMode.Open, FileAccess.Write))
                    {
                        // If the file can be opened with write access, it is closed immediately.
                        fs.Close();
                        return true;
                    }
                }
                else
                {
                    return true;
                }                
            }
            catch (IOException)
            {
                // If an IOException occurs, it means the file is still in use or inaccessible.
                return false;
            }
        }


        private void btnApprove_Click_ALL(object sender, EventArgs e)
        {
            int cnt = 0;
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetSelectedRows())//임명장
            {
                cnt = cnt + 1;
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetSelectedRows())//직무기술서
            {
                cnt = cnt + 1;
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetSelectedRows()) //자격부여평가보고서
            {
                cnt = cnt + 1;
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetSelectedRows()) //시험수행능력평가
            {
                cnt = cnt + 1;
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetSelectedRows())//교육보고서
            {
                cnt = cnt + 1;
            }

            if (cnt == 0)
            {
                MessageBox.Show("선택된 승인건이 없습니다. ");
                return;
            }




            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetSelectedRows())//임명장
            {
                MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"MaxApproveDepth").ToString());

                if (MyApproveDepth < FinalApproveDepth) //1차 검토
                {
                    Form2_Tab_Info_Now.sTabName = "임명장";

                    txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"IDX").ToString();
                    txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"approveIdx").ToString();
                    txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"approveComment").ToString();

                    idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"approveIdx").ToString());
                    MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                    FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                    requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"DeptNo").ToString();
                    requestedby = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"requestedBy").ToString();

                    s_rIDX = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"IDX").ToString();
                    save_approved("PQMS_STAFF_ROLE", "PQMS_STAFF_ROLE_APPROVE_LOG");
                    send_email();

                    MessageBox.Show("임명장! 1차 검토 완료");
                }
                else //2차 승인
                {
                    Form2_Tab_Info_Now.sTabName = "임명장";
                    string filePath = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"STAFF_ROLE_FILE").ToString();
                    if (CheckFile_Close(filePath))
                    {
                        txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"IDX").ToString();
                        txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"approveIdx").ToString();
                        txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"approveComment").ToString();

                        idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"approveIdx").ToString());
                        MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                        FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                        requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"DeptNo").ToString();
                        requestedby = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"requestedBy").ToString();

                        s_rIDX = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"IDX").ToString();
                        s_filepath = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"STAFF_ROLE_FILE").ToString();

                        save_approved("PQMS_STAFF_ROLE", "PQMS_STAFF_ROLE_APPROVE_LOG");
                        final_approve("PQMS_STAFF_ROLE");
                        final_ROLE(s_filepath);
                    }
                }
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetSelectedRows())//직무기술서
            {
                MyApproveDepth =  Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"MaxApproveDepth").ToString());

                if (MyApproveDepth < FinalApproveDepth) //1차 검토자
                {
                    Form2_Tab_Info_Now.sTabName = "직무기술서";
                    //사용중인 파일이 있는지 확인해서 진행해야함.
                    string filePath = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"STAFF_RP_FILE").ToString();
                    if (CheckFile_Close(filePath))
                    {
                        txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"IDX").ToString();
                        txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"approveIdx").ToString();
                        txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"approveComment").ToString();

                        idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"approveIdx").ToString());
                        MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                        FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                        requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"DeptNo").ToString();
                        requestedby = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"requestedBy").ToString();

                        s_rpIDX = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"IDX").ToString();
                        s_filepath = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"STAFF_RP_FILE").ToString();

                        save_approved("PQMS_STAFF_ROLE_PAPER", "PQMS_STAFF_ROLE_PAPER_APPROVE_LOG");
                        final_RolePaper("검토", s_filepath);
                        send_email();
                    }
                    else
                    {
                        MessageBox.Show("직무기술서! 사용중인 파일이 있습니다. 잠시후 다시 시도하세요.");
                        return;
                    }
                    MessageBox.Show("직무기술서! 1차 검토 완료");
                }
                else //2차 승인
                {
                    Form2_Tab_Info_Now.sTabName = "직무기술서";

                    //사용중인 파일이 있는지 확인해서 진행해야함.
                    string filePath = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"STAFF_RP_FILE").ToString();
                    if (CheckFile_Close(filePath))
                    {
                        txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"IDX").ToString();
                        txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"approveIdx").ToString();
                        txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"approveComment").ToString();

                        idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"approveIdx").ToString());
                        MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                        FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                        requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"DeptNo").ToString();
                        requestedby = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"requestedBy").ToString();

                        s_rpIDX = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"IDX").ToString();
                        s_filepath = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"STAFF_RP_FILE").ToString();

                        //save_approved("PQMS_STAFF_ROLE_PAPER_FINAL", "PQMS_STAFF_ROLE_PAPER_FINAL_APPROVE_LOG");
                        //final_approve("PQMS_STAFF_ROLE_PAPER_FINAL");
                        save_approved("PQMS_STAFF_ROLE_PAPER", "PQMS_STAFF_ROLE_PAPER_APPROVE_LOG");
                        final_approve("PQMS_STAFF_ROLE_PAPER");
                        final_RolePaper("승인", s_filepath); //레포트 재생성
                    }
                    else
                    {
                        MessageBox.Show("직무기술서! 사용중인 파일이 있습니다. 잠시후 다시 시도하세요.");
                        return;
                    }
                    MessageBox.Show("직무기술서! 최종 승인 완료");
                }                
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetSelectedRows()) //자격부여평가보고서
            {
                MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                if (MyApproveDepth < FinalApproveDepth) //1차 검토
                {
                    Form2_Tab_Info_Now.sTabName = "자격부여평가보고서";
                    txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"IDX").ToString();
                    txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"approveIdx").ToString();
                    txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"approveComment").ToString();

                    idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"approveIdx").ToString());
                    MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                    FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                    requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"DeptNo").ToString();
                    requestedby = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"requestedBy").ToString();

                    s_filepath = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"FINAL_FILE").ToString();
                    save_approved("PQMS_STAFF_ASSESSMENT_REPORT", "PQMS_STAFF_ASSESSMENT_REPORT_APPROVE_LOG");
                    send_email();
                    MessageBox.Show("자격부여평가보고서! 1차 검토 완료");
                }
                else //2차 승인
                {

                    Form2_Tab_Info_Now.sTabName = "자격부여평가보고서";
                    string filePath = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"FINAL_FILE").ToString();
                    if (CheckFile_Close(filePath))
                    {
                        txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"IDX").ToString();
                        txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"approveIdx").ToString();
                        txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"approveComment").ToString();

                        idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"approveIdx").ToString());
                        MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                        FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                        requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"DeptNo").ToString();
                        requestedby = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"requestedBy").ToString();

                        s_filepath = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"FINAL_FILE").ToString();

                        save_approved("PQMS_STAFF_ASSESSMENT_REPORT", "PQMS_STAFF_ASSESSMENT_REPORT_APPROVE_LOG");
                        final_approve("PQMS_STAFF_ASSESSMENT_REPORT");
                        final_Assessment(s_filepath); //자격부여평가보고서 파일 승인데이터 
                    }
                    else
                    {
                        MessageBox.Show("자격부여평가보고서! 사용중인 파일이 있습니다. 잠시후 다시 시도하세요.");
                        return;
                    }
                    MessageBox.Show("자격부여평가보고서! 최종 승인 완료");
                }                
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetSelectedRows()) //시험수행능력평가
            {
                Form2_Tab_Info_Now.sTabName = "시험수행능력평가";

                txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"IDX").ToString();
                txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"approveIdx").ToString();
                txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"approveComment").ToString();

                idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"approveIdx").ToString());
                MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"DeptNo").ToString();
                requestedby = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"requestedBy").ToString();

                save_approved("PQMS_STAFF_RP_EACH_LIST", "PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG");
                final_approve("PQMS_STAFF_RP_EACH_LIST");

                MessageBox.Show("시험수행능력평가! 최종 승인 완료");
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetSelectedRows())//교육보고서
            {
                Form2_Tab_Info_Now.sTabName = "교육보고서";

                //사용중인 파일이 있는지 확인해서 진행해야함.
                string filePath = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"STAFF_TRAIN_REPORT_FILE").ToString();
                string s_opinion = "";
                string s_result_file = "";
                if (CheckFile_Close(filePath))
                {
                    txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"IDX").ToString();
                    txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"approveIdx").ToString();
                    txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"approveComment").ToString();

                    idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"approveIdx").ToString());
                    MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                    FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                    requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"DeptNo").ToString();
                    requestedby = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"requestedBy").ToString();

                    s_eduFile = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"STAFF_TRAIN_REPORT_FILE").ToString();
                    s_staffcode = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"STAFF_CODE").ToString();

                    s_opinion = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id, "Opinion").ToString();
                    s_result_file = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id, "STAFF_TRAIN_RESULT_DIR_FILE").ToString(); 

                    save_approved("PQMS_STAFF_TRAINING", "PQMS_STAFF_TRAINING_APPROVE_LOG");
                    final_approve("PQMS_STAFF_TRAINING");

                    //참석자 테이블에 있는 STAFF_CODE PQMS_STAFF_TRAINING 테이블이 INSERT 
                    create_Traning_Attendee();

                    //승인 완료후 승인 레포트에 승인일자 넣기 위해 파일 재생성 
                    final_EduReport2(s_eduFile, s_opinion, s_staffcode, txtToBeApproved.Text, s_result_file);
                }
                else
                {
                    MessageBox.Show("교육보고서! 사용중인 파일이 있습니다. 잠시후 다시 시도하세요.");
                    return;
                }
                MessageBox.Show("교육보고서! 최종 승인 완료");
            }

            MyApproveDepth = get_my_approve_depth();
            // get_data_tobe_approved();
            btnAppRequest_Click(sender, e);

            MessageBox.Show("승인처리완료");

        }

        private void button2_Click_ALL(object sender, EventArgs e)
        {
            int cnt = 0;
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetSelectedRows())//임명장
            {
                cnt = cnt + 1;
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetSelectedRows())//직무기술서
            {
                cnt = cnt + 1;
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetSelectedRows()) //자격부여평가보고서
            {
                cnt = cnt + 1;
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetSelectedRows()) //시험수행능력평가
            {
                cnt = cnt + 1;
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetSelectedRows())//교육보고서
            {
                cnt = cnt + 1;
            }

            if (cnt == 0)
            {
                MessageBox.Show("선택된 반려건이 없습니다. ");
                return;
            }



            //반려
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetSelectedRows())//임명장
            {
                txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"IDX").ToString();
                txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"approveIdx").ToString();
                txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"approveComment").ToString();

                idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"approveIdx").ToString());
                MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"DeptNo").ToString();
                requestedby = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"requestedBy").ToString();

                s_rIDX = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(id,"IDX").ToString();
                save_rejected("PQMS_STAFF_ROLE_FINAL", "PQMS_STAFF_ROLE_FINAL_APPROVE_LOG");                
            }

            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetSelectedRows()) //직무기술서
            {
                txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"IDX").ToString();
                txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"approveIdx").ToString();
                txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"approveComment").ToString();

                idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"approveIdx").ToString());
                MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"DeptNo").ToString();
                requestedby = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"requestedBy").ToString();

                s_rpIDX = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"IDX").ToString();
                s_filepath = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(id,"RP_FINAL_FILE").ToString();
                //save_rejected("PQMS_STAFF_ROLE_PAPER_FINAL", "PQMS_STAFF_ROLE_PAPER_FINAL_APPROVE_LOG");
                save_rejected("PQMS_STAFF_ROLE_PAPER", "PQMS_STAFF_ROLE_PAPER_APPROVE_LOG");               

            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetSelectedRows()) //자격부여평가보고서
            {

                txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"IDX").ToString();
                txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"approveIdx").ToString();
                txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"approveComment").ToString();

                idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"approveIdx").ToString());
                MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"DeptNo").ToString();
                requestedby = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"requestedBy").ToString();

                s_filepath = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(id,"FINAL_FILE").ToString();
                save_rejected("PQMS_STAFF_ASSESSMENT_REPORT", "PQMS_STAFF_ASSESSMENT_REPORT_APPROVE_LOG");
               
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetSelectedRows()) //시험수행능력평가
            {
                txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"IDX").ToString();
                txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"approveIdx").ToString();
                txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"approveComment").ToString();

                idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"approveIdx").ToString());
                MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"DeptNo").ToString();
                requestedby = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(id,"requestedBy").ToString();

                save_rejected("PQMS_STAFF_RP_EACH_LIST", "PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG");                
            }
            foreach (int id in PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetSelectedRows())//교육보고서
            {
                txtidxNo.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"IDX").ToString();
                txtToBeApproved.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"approveIdx").ToString();
                txtRequestContent.Text = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"approveComment").ToString();

                idxToBeApproved = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"approveIdx").ToString());
                MyApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"MyApproveDepth").ToString());
                FinalApproveDepth = Convert.ToInt32(PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"MaxApproveDepth").ToString());
                requesterDeptCode = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"DeptNo").ToString();
                requestedby = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"requestedBy").ToString();

                s_eduFile = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"STAFF_TRAIN_REPORT_FILE").ToString();
                s_staffcode = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(id,"STAFF_CODE").ToString();
                save_rejected("PQMS_STAFF_TRAINING", "PQMS_STAFF_TRAINING_APPROVE_LOG");
              
            }
            
            MyApproveDepth = get_my_approve_depth();
            // get_data_tobe_approved();
            btnAppRequest_Click(sender, e);


            MessageBox.Show("반려 처리완료");

        }

        private void PQMS_STAFF_ApproveRequestCheckListGrid_Role_View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_ROLE_FILE")
            {
                if (!PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(e.RowHandle, "STAFF_ROLE_FILE").Equals(DBNull.Value) && PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(e.RowHandle, "STAFF_ROLE_FILE").ToString().Trim() != "")                
                {
                    string strFile = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetRowCellValue(e.RowHandle, "STAFF_ROLE_FILE").ToString();
                    FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                    if (fileInfo.Exists)
                    {
                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        e.Cache.FillRectangle(SystemBrushes.Control, e.Bounds);
                        e.Appearance.DrawString(e.Cache, "파일열기", e.Bounds);
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void PQMS_STAFF_ApproveRequestCheckListGrid_Role_View_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.Caption.Equals("임명장"))
            {
                string strFile = PQMS_STAFF_ApproveRequestCheckListGrid_Role_View.GetFocusedDataRow()["STAFF_ROLE_FILE"].ToString();
                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일열기 버튼 생성 
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_RP_FILE")
            {
                if (!PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(e.RowHandle, "STAFF_RP_FILE").Equals(DBNull.Value) && PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(e.RowHandle, "STAFF_RP_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetRowCellValue(e.RowHandle, "STAFF_RP_FILE").ToString();
                    FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일열기 버튼 생성 
                    if (fileInfo.Exists)
                    {
                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        e.Cache.FillRectangle(SystemBrushes.Control, e.Bounds);
                        e.Appearance.DrawString(e.Cache, "파일열기", e.Bounds);
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }

        }

        private void PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.Caption.Equals("직무기술서"))
            {
                string strFile = PQMS_STAFF_ApproveRequestCheckListGrid_RolePaper_View.GetFocusedDataRow()["STAFF_RP_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "FINAL_FILE")
            {
                if (!PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(e.RowHandle, "FINAL_FILE").Equals(DBNull.Value) && PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(e.RowHandle, "FINAL_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetRowCellValue(e.RowHandle, "FINAL_FILE").ToString();
                    FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일열기 버튼 생성 
                    if (fileInfo.Exists)
                    {
                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        e.Cache.FillRectangle(SystemBrushes.Control, e.Bounds);
                        e.Appearance.DrawString(e.Cache, "파일열기", e.Bounds);
                        e.Handled = true;
                    }
                    else
                    {                     
                        e.Handled = true;
                    }

                }
            }
        }

        private void PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.Caption.Equals("자격부여평가보고서"))
            {
                string strFile = PQMS_STAFF_ApproveRequestCheckListGridGridGrid_Assessment_View.GetFocusedDataRow()["FINAL_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void PQMS_STAFF_ApproveRequestCheckListGrid_Training_View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_TRAIN_REPORT_FILE")
            {
                if (!PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_REPORT_FILE").Equals(DBNull.Value) && PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_REPORT_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_REPORT_FILE").ToString();
                    FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일열기 버튼 생성 
                    if (fileInfo.Exists)
                    {
                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        e.Cache.FillRectangle(SystemBrushes.Control, e.Bounds);
                        e.Appearance.DrawString(e.Cache, "파일열기", e.Bounds);
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void PQMS_STAFF_ApproveRequestCheckListGrid_Training_View_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.Caption.Equals("교육보고서"))
            {
                string strFile = PQMS_STAFF_ApproveRequestCheckListGrid_Training_View.GetFocusedDataRow()["STAFF_TRAIN_REPORT_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "FILE_PATH")
            {
                if (!PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(e.RowHandle, "FILE_PATH").Equals(DBNull.Value) && PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(e.RowHandle, "FILE_PATH").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetRowCellValue(e.RowHandle, "FILE_PATH").ToString();
                    FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일열기 버튼 생성 
                    if (fileInfo.Exists)
                    {
                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        e.Cache.FillRectangle(SystemBrushes.Control, e.Bounds);
                        e.Appearance.DrawString(e.Cache, "파일열기", e.Bounds);
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.Caption.Equals("시험수행능력평가"))
            {
                string strFile = PQMS_STAFF_ApproveRequestCheckListGrid_EachList_View.GetFocusedDataRow()["FILE_PATH"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }


    


    }
}

