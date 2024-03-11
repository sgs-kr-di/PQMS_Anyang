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

namespace PQMS
{
    public partial class frmApproveRequestCheck : Form
    {
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


        public frmApproveRequestCheck()
        {
            InitializeComponent();
            Initialize();
            unitCommon = new UnitCommon();
        }

        private void Initialize() 
        {
            unitCommon = new UnitCommon();
        }        

        private string OpenFile()
        {
            openFileDialog1.Filter = "*.*|*.*";
            //openFileDialog1.Filter = "Photo (*.jpeg*)|*.jpg*";
            openFileDialog1.Title = "Choose a file ";

            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }

            return string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmbApprover.Items.Clear();
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
                    get_next_approver(tDeptCode.Substring(0, tDeptCode.Length - 1));
                }

                //if (cmbApprover.Items. != "")
                //{
                //    MessageBox.Show(DeptNo.ToString());
                //    break;
                //}
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmApproveRequestCheck_Load(object sender, EventArgs e)
        {
            this.Text = Form2_Tab_Info_Now.sMenuName + "-" + Form2_Tab_Info_Now.sTabName + "-" + "승인요청확인및승인";

            txtTitle.Text = Form2_Tab_Info_Now.sTabName;
            set_approve_parameter();
            //get_approve_param(); //승인관련변수할당 -> userManagement -> 승인업무정리 참조

            
            //get_approval_right1();
            //get_approval_right2();
            //get_max_role_depth();
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
            //MyApproveDepth = get_my_approve_depth();

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
            tApproveDepth = MyApproveDepth + 1;

            string query = "";
            query = " SELECT a.accountNo, b.logInID, b.userID, c.firstName ";
            query = query + " FROM [accountMaster].[dbo].[approveRole_V1] a inner join [accountMaster].[dbo].[accountMaster] b ";
            query = query + " on (a.accountNo = b.accountNo)";
            query = query + " inner join [accountMaster].[dbo].[userMaster] c on (b.userID = c.userID) ";
            query = query + " where a.appNo = " + appNo; //+ appNo
            query = query + "    and a.menuNo = " + MenuNo; //appNo + MenuNo;
            query = query + "    and a.workNo = " + WorkNo; //appNo + WorkNo;
            query = query + "    and a.deptNo = '" + approverDept + "'";
            query = query + "    and a.MyApproveDepth = " + tApproveDepth ;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        cmbApprover.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() +" "+ reader.GetValue(3).ToString());
                    }
                }
            }

            Conn.Close();

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
            query = query + "    and deptNo = '" + requesterDeptCode + "'" ;

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

            query = " select isnull(max(MaxApproveDepth),0) from [accountMaster].[dbo].[approveRole_V1] ";
            query = query + "    where accountNo = " + accountNo;
            query = query + "    and appNo = " + appNo;
            query = query + "    and menuNo = " + MenuNo;
            query = query + "    and workNo = " + WorkNo;
            query = query + "    and deptNo = " + requesterDeptCode;

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

        //private int get_dept_no2(string deptID)
        //{
        //    Conn = new OleDbConnection(unitCommon.connect_string);

        //    string query = "";

        //    query = "SELECT  ";
        //    query = query + " FROM [accountMaster].[dbo].[appMaster_Dept] ";
        //    query = query + " where appNo = " + appNo + "";
        //    query = query + "   and DeptName = '" + deptID + "'";

        //    OleDbCommand cmd = new OleDbCommand(query, Conn);

        //    Conn.Open();

        //    using (OleDbDataReader reader = cmd.ExecuteReader())
        //    {
        //        if (reader.HasRows == true)
        //        {
        //            while (reader.Read())
        //            {
        //                DeptNo = Convert.ToInt32(reader.GetValue(0).ToString());
        //            }
        //        }
        //        else
        //        {
        //            DeptNo = 0;
        //        }
        //    }
        //    Conn.Close();

        //    return DeptNo;
        //}

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

            if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                query = query + "SELECT a.IDX, b.*, a.CurrentApproveDepth, a.FinalApproveDepth, c.accountNo, c.MyApproveDepth, c.MaxApproveDepth, a.requestedBy ";
                query = query + " FROM [PQMS_STAFF_TRAINING_APPROVE_LOG] a   ";
                query = query + " inner join [PQMS_STAFF_TRAINING] b on (a.approveIdx = b.idx)   ";
                query = query + " inner join (select * from [accountMaster].[dbo].[approveRole_V1] where accountNo = " + accountNo + ") c ";
                query = query + " on (a.appNo = c.appNo and a.workNo = c.workNo and a.MenuNo = c.MenuNo and a.DeptNo = c.DeptNo) ";
                query = query + " where a.appNo = " + appNo;
                query = query + " and a.workNo = " + WorkNo;
                query = query + " and a.MenuNo = " + MenuNo;
                //query = query + "and a.DeptNo = '" + requesterDeptCode + "'" ; //approvedBy(승인권자는 어떤 부서든지 승인할 수 있기 때문에, 특정 부서만 조회할 필요없음
                query = query + " and a.requestTo = '" + approvedby + "'"; //모든 승인 요청 과정에 승인권자를 지정하도록 한다. 만약 승인권자의 지정없이 부서별로 승인이 가능하도록 하려면, 반드시 해당 부서의 팀장이나 상위부서의 팀장만을 승인권자로 설정해서 처리 토록 한다.
                query = query + " and a.CurrentApproveDepth < c.MyApproveDepth ";
                query = query + " and a.approvedYN != 'Y' ";
                query = query + " and (a.rejectDate is null or a.rejectDate = '')";
                query = query + " and b.approveStatusCode = 0   ";
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                query = query + "SELECT a.IDX, b.*, a.CurrentApproveDepth, a.FinalApproveDepth, c.accountNo, c.MyApproveDepth, c.MaxApproveDepth, a.requestedBy ";
                query = query + " FROM [PQMS_STAFF_ROLE_PAPER_APPROVE_LOG] a   ";
                query = query + " inner join [PQMS_STAFF_ROLE_PAPER] b on (a.approveIdx = b.idx)   ";
                query = query + " inner join (select * from [accountMaster].[dbo].[approveRole_V1] where accountNo = " + accountNo + ") c ";
                query = query + " on (a.appNo = c.appNo and a.workNo = c.workNo and a.MenuNo = c.MenuNo and a.DeptNo = c.DeptNo) ";
                query = query + " where a.appNo = " + appNo;
                query = query + " and a.workNo = " + WorkNo;
                query = query + " and a.MenuNo = " + MenuNo;
                //query = query + "and a.DeptNo = '" + requesterDeptCode + "'" ; //approvedBy(승인권자는 어떤 부서든지 승인할 수 있기 때문에, 특정 부서만 조회할 필요없음
                query = query + " and a.requestTo = '" + approvedby + "'"; //모든 승인 요청 과정에 승인권자를 지정하도록 한다. 만약 승인권자의 지정없이 부서별로 승인이 가능하도록 하려면, 반드시 해당 부서의 팀장이나 상위부서의 팀장만을 승인권자로 설정해서 처리 토록 한다.
                query = query + " and a.CurrentApproveDepth < c.MyApproveDepth ";
                query = query + " and a.approvedYN != 'Y' ";
                query = query + " and (a.rejectDate is null or a.rejectDate = '')";
                query = query + " and b.approveStatusCode = 0   ";
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                query = query + "SELECT a.IDX, b.*, a.CurrentApproveDepth, a.FinalApproveDepth, c.accountNo, c.MyApproveDepth, c.MaxApproveDepth, a.requestedBy ";
                query = query + " FROM [PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG] a   ";
                query = query + " inner join [PQMS_STAFF_ROLE_APPOINT] b on (a.approveIdx = b.idx)   ";
                query = query + " inner join (select * from [accountMaster].[dbo].[approveRole_V1] where accountNo = " + accountNo + ") c ";
                query = query + " on (a.appNo = c.appNo and a.workNo = c.workNo and a.MenuNo = c.MenuNo and a.DeptNo = c.DeptNo) ";
                query = query + " where a.appNo = " + appNo;
                query = query + " and a.workNo = " + WorkNo;
                query = query + " and a.MenuNo = " + MenuNo;
                //query = query + "and a.DeptNo = '" + requesterDeptCode + "'" ; //approvedBy(승인권자는 어떤 부서든지 승인할 수 있기 때문에, 특정 부서만 조회할 필요없음
                query = query + " and a.requestTo = '" + approvedby + "'"; //모든 승인 요청 과정에 승인권자를 지정하도록 한다. 만약 승인권자의 지정없이 부서별로 승인이 가능하도록 하려면, 반드시 해당 부서의 팀장이나 상위부서의 팀장만을 승인권자로 설정해서 처리 토록 한다.
                query = query + " and a.CurrentApproveDepth < c.MyApproveDepth ";
                query = query + " and a.approvedYN != 'Y' ";
                query = query + " and (a.rejectDate is null or a.rejectDate = '')";
                query = query + " and b.approveStatusCode = 0   ";
            }
            else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
            {
                query = query + "SELECT a.IDX, b.*, a.CurrentApproveDepth, a.FinalApproveDepth, c.accountNo, c.MyApproveDepth, c.MaxApproveDepth, a.requestedBy ";
                query = query + " FROM [PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG] a   ";
                query = query + " inner join [PQMS_STAFF_RP_EACH_LIST] b on (a.approveIdx = b.idx)   ";
                query = query + " inner join (select * from [accountMaster].[dbo].[approveRole_V1] where accountNo = " + accountNo + ") c ";
                query = query + " on (a.appNo = c.appNo and a.workNo = c.workNo and a.MenuNo = c.MenuNo and a.DeptNo = c.DeptNo) ";
                query = query + " where a.appNo = " + appNo;
                query = query + " and a.workNo = " + WorkNo;
                query = query + " and a.MenuNo = " + MenuNo;
                //query = query + "and a.DeptNo = '" + requesterDeptCode + "'" ; //approvedBy(승인권자는 어떤 부서든지 승인할 수 있기 때문에, 특정 부서만 조회할 필요없음
                query = query + " and a.requestTo = '" + approvedby + "'"; //모든 승인 요청 과정에 승인권자를 지정하도록 한다. 만약 승인권자의 지정없이 부서별로 승인이 가능하도록 하려면, 반드시 해당 부서의 팀장이나 상위부서의 팀장만을 승인권자로 설정해서 처리 토록 한다.
                query = query + " and a.CurrentApproveDepth < c.MyApproveDepth ";
                query = query + " and a.approvedYN != 'Y' ";
                query = query + " and (a.rejectDate is null or a.rejectDate = '')";
                query = query + " and b.approveStatusCode = 0   ";

            }
            else if (Form2_Tab_Info_Now.sTabName == "직무자료")
            {
                query = query + "SELECT a.IDX, b.*, a.CurrentApproveDepth, a.FinalApproveDepth, c.accountNo, c.MyApproveDepth, c.MaxApproveDepth, a.requestedBy ";
                query = query + " FROM [PQMS_STAFF_ROLE_APPROVE_LOG] a   ";
                query = query + " inner join [PQMS_STAFF_ROLE] b on (a.approveIdx = b.idx)   ";
                query = query + " inner join (select * from [accountMaster].[dbo].[approveRole_V1] where accountNo = " + accountNo + ") c ";
                query = query + " on (a.appNo = c.appNo and a.workNo = c.workNo and a.MenuNo = c.MenuNo and a.DeptNo = c.DeptNo) ";
                query = query + " where a.appNo = " + appNo;
                query = query + " and a.workNo = " + WorkNo;
                query = query + " and a.MenuNo = " + MenuNo;
                //query = query + "and a.DeptNo = '" + requesterDeptCode + "'" ; //approvedBy(승인권자는 어떤 부서든지 승인할 수 있기 때문에, 특정 부서만 조회할 필요없음
                query = query + " and a.requestTo = '" + approvedby + "'"; //모든 승인 요청 과정에 승인권자를 지정하도록 한다. 만약 승인권자의 지정없이 부서별로 승인이 가능하도록 하려면, 반드시 해당 부서의 팀장이나 상위부서의 팀장만을 승인권자로 설정해서 처리 토록 한다.
                query = query + " and a.CurrentApproveDepth < c.MyApproveDepth ";
                query = query + " and a.approvedYN != 'Y' ";
                query = query + " and (a.rejectDate is null or a.rejectDate = '')";
                query = query + " and b.approveStatusCode = 0  ";
            }


            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            dgvUserRequestStatus.RowCount = 100;

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


        private int approvechek()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            int tchk = 0;
            string query = "";

            query = "SELECT  isnull(requestStatusCode,0) FROM PQMS_STAFF_TRAINING ";
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

        private void save_item2(string tapprove)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = " insert into PQMS_STAFF_TRAINING_APPROVE_LOG ";
            query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
            query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
            query = query + "" + txtidxNo.Text + ", ";
            query = query + "" + appNo + ", ";
            query = query + "'" + requesterDeptCode + "', ";
            query = query + "" + WorkNo + ", ";
            query = query + "" + MenuNo + ", ";
            query = query + "'" + txtLoginID.Text + "',";
            query = query + "" + MyApproveDepth + ", ";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
            query = query + "" + FinalApproveDepth + ","; //target/final approve depth
            query = query + "'" + requestedby + "', ";
            if (tapprove == "approved")
            {
                query = query + "'Y',"; //N:Not approved, Y:approved
            }
            else
            {
                query = query + "'N',"; //N:Not approved, Y:approved
            }
            query = query + "'" + approvedby + "', ";
            query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";

            if (tapprove == "approved")
            {
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
                query = query + "'', ";
            }
            else
            {
                query = query + "'', ";
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            }

            query = query + "N'" + txtApproveComment.Text + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            query = " update PQMS_STAFF_TRAINING set ";
            query = query + " appNo = " + appNo + ",";
            query = query + " DeptNo = '" + requesterDeptCode + "',";
            query = query + " WorkNo = " + WorkNo + ",";
            query = query + " MenuNo = " + MenuNo + ",";
            query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested
            query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
            query = query + " approveComment = N'" + txtRequestContent.Text + "'";
            query = query + " where IDX = " + txtidxNo.Text + "";


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();

            //MessageBox.Show(query);
        }


        private void save_approved_each_list()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " update PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG set ";
            query = query + " approvedBy = '" + approvedby + "',";
            query = query + " approveDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "',";
            query = query + " approvedYN = 'Y'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();
            if (MyApproveDepth != FinalApproveDepth)
            {
                query = " insert into PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
                query = query + "" + idxToBeApproved + ", ";
                query = query + "" + appNo + ", ";
                query = query + "'" + requesterDeptCode + "', ";
                query = query + "" + WorkNo + ", ";
                query = query + "" + MenuNo + ", ";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "" + MyApproveDepth + ", ";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + FinalApproveDepth + ","; //target/final approve depth
                query = query + "'" + requestedby + "', ";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'', "; //approvedby
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
                query = query + "'', ";
                query = query + "'', ";
                query = query + "N'')"; //approveComment
            }
            else
            {
                query = " insert into PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
                query = query + "" + idxToBeApproved + ", ";
                query = query + "" + appNo + ", ";
                query = query + "'" + requesterDeptCode + "', ";
                query = query + "" + WorkNo + ", ";
                query = query + "" + MenuNo + ", ";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "" + MyApproveDepth + ", ";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + FinalApproveDepth + ","; //target/final approve depth
                query = query + "'" + requestedby + "', ";
                query = query + "'Y',"; //N:Not approved, Y:approved
                query = query + "'" + approvedby + "', "; //approvedby
                query = query + "'', "; //requestDate
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', "; //approveDate
                query = query + "'', "; //rejectDate
                query = query + "N'" + txtApproveComment.Text + "')"; //approveComment
            }


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            query = " update PQMS_STAFF_RP_EACH_LIST set ";
            query = query + " appNo = " + appNo + ",";
            query = query + " DeptNo = '" + requesterDeptCode + "',";
            query = query + " WorkNo = " + WorkNo + ",";
            query = query + " MenuNo = " + MenuNo + ",";
            query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested
            query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
            query = query + " approveComment = N'" + txtRequestContent.Text + "'";
            query = query + " where IDX = " + idxToBeApproved + "";


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();
            cmd.ExecuteNonQuery();

            Conn.Close();

            //MessageBox.Show(query);
        }


        private void save_approved_role_appoint()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " update PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG set ";
            query = query + " approvedBy = '" + approvedby + "',";
            query = query + " approveDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "',";
            query = query + " approvedYN = 'Y'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();
            if (MyApproveDepth != FinalApproveDepth)
            {
                query = " insert into PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
                query = query + "" + idxToBeApproved + ", ";
                query = query + "" + appNo + ", ";
                query = query + "'" + requesterDeptCode + "', ";
                query = query + "" + WorkNo + ", ";
                query = query + "" + MenuNo + ", ";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "" + MyApproveDepth + ", ";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + FinalApproveDepth + ","; //target/final approve depth
                query = query + "'" + requestedby + "', ";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'', "; //approvedby
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
                query = query + "'', ";
                query = query + "'', ";
                query = query + "N'')"; //approveComment
            }
            else
            {
                query = " insert into PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
                query = query + "" + idxToBeApproved + ", ";
                query = query + "" + appNo + ", ";
                query = query + "'" + requesterDeptCode + "', ";
                query = query + "" + WorkNo + ", ";
                query = query + "" + MenuNo + ", ";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "" + MyApproveDepth + ", ";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + FinalApproveDepth + ","; //target/final approve depth
                query = query + "'" + requestedby + "', ";
                query = query + "'Y',"; //N:Not approved, Y:approved
                query = query + "'" + approvedby + "', "; //approvedby
                query = query + "'', "; //requestDate
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', "; //approveDate
                query = query + "'', "; //rejectDate
                query = query + "N'" + txtApproveComment.Text + "')"; //approveComment
            }


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            query = " update PQMS_STAFF_ROLE_APPOINT set ";
            query = query + " appNo = " + appNo + ",";
            query = query + " DeptNo = '" + requesterDeptCode + "',";
            query = query + " WorkNo = " + WorkNo + ",";
            query = query + " MenuNo = " + MenuNo + ",";
            query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested
            query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
            query = query + " approveComment = N'" + txtRequestContent.Text + "'";
            query = query + " where IDX = " + idxToBeApproved + "";


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();
            cmd.ExecuteNonQuery();

            Conn.Close();

            //MessageBox.Show(query);
        }

        private void save_approved_role()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " update PQMS_STAFF_ROLE_APPROVE_LOG set ";
            query = query + " approvedBy = '" + approvedby + "',";
            query = query + " approveDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "',";
            query = query + " approvedYN = 'Y'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();
            if (MyApproveDepth != FinalApproveDepth)
            {
                query = " insert into PQMS_STAFF_ROLE_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
                query = query + "" + idxToBeApproved + ", ";
                query = query + "" + appNo + ", ";
                query = query + "'" + requesterDeptCode + "', ";
                query = query + "" + WorkNo + ", ";
                query = query + "" + MenuNo + ", ";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "" + MyApproveDepth + ", ";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + FinalApproveDepth + ","; //target/final approve depth
                query = query + "'" + requestedby + "', ";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'', "; //approvedby
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
                query = query + "'', ";
                query = query + "'', ";
                query = query + "N'')"; //approveComment
            }
            else
            {
                query = " insert into PQMS_STAFF_ROLE_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
                query = query + "" + idxToBeApproved + ", ";
                query = query + "" + appNo + ", ";
                query = query + "'" + requesterDeptCode + "', ";
                query = query + "" + WorkNo + ", ";
                query = query + "" + MenuNo + ", ";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "" + MyApproveDepth + ", ";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + FinalApproveDepth + ","; //target/final approve depth
                query = query + "'" + requestedby + "', ";
                query = query + "'Y',"; //N:Not approved, Y:approved
                query = query + "'" + approvedby + "', "; //approvedby
                query = query + "'', "; //requestDate
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', "; //approveDate
                query = query + "'', "; //rejectDate
                query = query + "N'" + txtApproveComment.Text + "')"; //approveComment
            }


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            query = " update PQMS_STAFF_ROLE set ";
            query = query + " appNo = " + appNo + ",";
            query = query + " DeptNo = '" + requesterDeptCode + "',";
            query = query + " WorkNo = " + WorkNo + ",";
            query = query + " MenuNo = " + MenuNo + ",";
            query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested
            query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
            query = query + " approveComment = N'" + txtRequestContent.Text + "'";
            query = query + " where IDX = " + idxToBeApproved + "";


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();
            cmd.ExecuteNonQuery();

            Conn.Close();

            //MessageBox.Show(query);
        }

        private void save_approved_role_paper()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " update PQMS_STAFF_ROLE_PAPER_APPROVE_LOG set ";
            query = query + " approvedBy = '" + approvedby + "',";
            query = query + " approveDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "',";
            query = query + " approvedYN = 'Y'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();
            if (MyApproveDepth != FinalApproveDepth)
            {
                query = " insert into PQMS_STAFF_ROLE_PAPER_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
                query = query + "" + idxToBeApproved + ", ";
                query = query + "" + appNo + ", ";
                query = query + "'" + requesterDeptCode + "', ";
                query = query + "" + WorkNo + ", ";
                query = query + "" + MenuNo + ", ";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "" + MyApproveDepth + ", ";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + FinalApproveDepth + ","; //target/final approve depth
                query = query + "'" + requestedby + "', ";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'', "; //approvedby
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
                query = query + "'', ";
                query = query + "'', ";
                query = query + "N'')"; //approveComment
            }
            else
            {
                query = " insert into PQMS_STAFF_ROLE_PAPER_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
                query = query + "" + idxToBeApproved + ", ";
                query = query + "" + appNo + ", ";
                query = query + "'" + requesterDeptCode + "', ";
                query = query + "" + WorkNo + ", ";
                query = query + "" + MenuNo + ", ";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "" + MyApproveDepth + ", ";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + FinalApproveDepth + ","; //target/final approve depth
                query = query + "'" + requestedby + "', ";
                query = query + "'Y',"; //N:Not approved, Y:approved
                query = query + "'" + approvedby + "', "; //approvedby
                query = query + "'', "; //requestDate
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', "; //approveDate
                query = query + "'', "; //rejectDate
                query = query + "N'" + txtApproveComment.Text + "')"; //approveComment
            }


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            query = " update PQMS_STAFF_ROLE_PAPER set ";
            query = query + " appNo = " + appNo + ",";
            query = query + " DeptNo = '" + requesterDeptCode + "',";
            query = query + " WorkNo = " + WorkNo + ",";
            query = query + " MenuNo = " + MenuNo + ",";
            query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested
            query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
            query = query + " approveComment = N'" + txtRequestContent.Text + "'";
            query = query + " where IDX = " + idxToBeApproved + "";


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();
            cmd.ExecuteNonQuery();

            Conn.Close();

            //MessageBox.Show(query);
        }

        private void save_approved()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " update PQMS_STAFF_TRAINING_APPROVE_LOG set ";
            query = query + " approvedBy = '" + approvedby + "',";
            query = query + " approveDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "',";
            query = query + " approvedYN = 'Y'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();
            if (MyApproveDepth != FinalApproveDepth)
            {
                query = " insert into PQMS_STAFF_TRAINING_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
                query = query + "" + idxToBeApproved + ", ";
                query = query + "" + appNo + ", ";
                query = query + "'" + requesterDeptCode + "', ";
                query = query + "" + WorkNo + ", ";
                query = query + "" + MenuNo + ", ";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "" + MyApproveDepth + ", ";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + FinalApproveDepth + ","; //target/final approve depth
                query = query + "'" + requestedby + "', ";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'', "; //approvedby
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
                query = query + "'', ";
                query = query + "'', ";
                query = query + "N'')"; //approveComment
            }
            else
            {
                query = " insert into PQMS_STAFF_TRAINING_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
                query = query + "" + idxToBeApproved + ", ";
                query = query + "" + appNo + ", ";
                query = query + "'" + requesterDeptCode + "', ";
                query = query + "" + WorkNo + ", ";
                query = query + "" + MenuNo + ", ";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "" + MyApproveDepth + ", ";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + FinalApproveDepth + ","; //target/final approve depth
                query = query + "'" + requestedby + "', ";
                query = query + "'Y',"; //N:Not approved, Y:approved
                query = query + "'" + approvedby + "', "; //approvedby
                query = query + "'', "; //requestDate
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', "; //approveDate
                query = query + "'', "; //rejectDate
                query = query + "N'" + txtApproveComment.Text + "')"; //approveComment
            }


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            query = " update PQMS_STAFF_TRAINING set ";
            query = query + " appNo = " + appNo + ",";
            query = query + " DeptNo = '" + requesterDeptCode + "',";
            query = query + " WorkNo = " + WorkNo + ",";
            query = query + " MenuNo = " + MenuNo + ",";
            query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested
            query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
            query = query + " approveComment = N'" + txtRequestContent.Text + "'";
            query = query + " where IDX = " + idxToBeApproved + "";


            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();
            cmd.ExecuteNonQuery();

            Conn.Close();

            //MessageBox.Show(query);
        }

        private void save_rejected()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = " insert into PQMS_STAFF_TRAINING_APPROVE_LOG ";
            query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
            query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
            query = query + "" + idxToBeApproved + ", ";
            query = query + "" + appNo + ", ";
            query = query + "'" + requesterDeptCode + "', ";
            query = query + "" + WorkNo + ", ";
            query = query + "" + MenuNo + ", ";
            query = query + "'" + requestedby + "',"; //승인 요청자에게 승인 보류 처리 함
            query = query + "0, ";  //MyApproveDepth //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
            query = query + "0,"; //FinalApproveDepth //target/final approve depth
            query = query + "'" + approvedby + "', ";
            query = query + "'N',"; //N:Not approved, Y:approved
            query = query + "'', "; //approvedby = '' 처리
            query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            query = query + "'', ";
            query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            query = query + "N'" + txtApproveComment.Text + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            query = " update PQMS_STAFF_TRAINING_APPROVE_LOG set ";
            query = query + " rejectDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();

            cmd.ExecuteNonQuery();

            //Conn.Close();


            query = " update PQMS_STAFF_TRAINING set ";
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


        private void save_rejected_role_appoint()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = " insert into PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG ";
            query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
            query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
            query = query + "" + idxToBeApproved + ", ";
            query = query + "" + appNo + ", ";
            query = query + "'" + requesterDeptCode + "', ";
            query = query + "" + WorkNo + ", ";
            query = query + "" + MenuNo + ", ";
            query = query + "'" + requestedby + "',"; //승인 요청자에게 승인 보류 처리 함
            query = query + "0, ";  //MyApproveDepth //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
            query = query + "0,"; //FinalApproveDepth //target/final approve depth
            query = query + "'" + approvedby + "', ";
            query = query + "'N',"; //N:Not approved, Y:approved
            query = query + "'', "; //approvedby = '' 처리
            query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            query = query + "'', ";
            query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            query = query + "N'" + txtApproveComment.Text + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            query = " update PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG set ";
            query = query + " rejectDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();

            cmd.ExecuteNonQuery();

            //Conn.Close();


            query = " update PQMS_STAFF_ROLE_APPOINT set ";
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

        private void save_rejected_role_paper()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = " insert into PQMS_STAFF_ROLE_PAPER_APPROVE_LOG ";
            query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
            query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
            query = query + "" + idxToBeApproved + ", ";
            query = query + "" + appNo + ", ";
            query = query + "'" + requesterDeptCode + "', ";
            query = query + "" + WorkNo + ", ";
            query = query + "" + MenuNo + ", ";
            query = query + "'" + requestedby + "',"; //승인 요청자에게 승인 보류 처리 함
            query = query + "0, ";  //MyApproveDepth //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
            query = query + "0,"; //FinalApproveDepth //target/final approve depth
            query = query + "'" + approvedby + "', ";
            query = query + "'N',"; //N:Not approved, Y:approved
            query = query + "'', "; //approvedby = '' 처리
            query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            query = query + "'', ";
            query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            query = query + "N'" + txtApproveComment.Text + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            query = " update PQMS_STAFF_ROLE_PAPER_APPROVE_LOG set ";
            query = query + " rejectDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();

            cmd.ExecuteNonQuery();

            //Conn.Close();


            query = " update PQMS_STAFF_ROLE_PAPER set ";
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
        private void save_rejected_role()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = " insert into PQMS_STAFF_ROLE_APPROVE_LOG ";
            query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
            query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
            query = query + "" + idxToBeApproved + ", ";
            query = query + "" + appNo + ", ";
            query = query + "'" + requesterDeptCode + "', ";
            query = query + "" + WorkNo + ", ";
            query = query + "" + MenuNo + ", ";
            query = query + "'" + requestedby + "',"; //승인 요청자에게 승인 보류 처리 함
            query = query + "0, ";  //MyApproveDepth //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
            query = query + "0,"; //FinalApproveDepth //target/final approve depth
            query = query + "'" + approvedby + "', ";
            query = query + "'N',"; //N:Not approved, Y:approved
            query = query + "'', "; //approvedby = '' 처리
            query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            query = query + "'', ";
            query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            query = query + "N'" + txtApproveComment.Text + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            query = " update PQMS_STAFF_ROLE_APPROVE_LOG set ";
            query = query + " rejectDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();

            cmd.ExecuteNonQuery();

            //Conn.Close();


            query = " update PQMS_STAFF_ROLE set ";
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

        private void save_rejected_each_list()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = " insert into PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG ";
            query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
            query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate, approveDate, rejectDate, approveComment) values (";
            query = query + "" + idxToBeApproved + ", ";
            query = query + "" + appNo + ", ";
            query = query + "'" + requesterDeptCode + "', ";
            query = query + "" + WorkNo + ", ";
            query = query + "" + MenuNo + ", ";
            query = query + "'" + requestedby + "',"; //승인 요청자에게 승인 보류 처리 함
            query = query + "0, ";  //MyApproveDepth //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
            query = query + "0,"; //FinalApproveDepth //target/final approve depth
            query = query + "'" + approvedby + "', ";
            query = query + "'N',"; //N:Not approved, Y:approved
            query = query + "'', "; //approvedby = '' 처리
            query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            query = query + "'', ";
            query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', ";
            query = query + "N'" + txtApproveComment.Text + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            //Conn.Close();

            query = " update PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG set ";
            query = query + " rejectDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "'";
            query = query + " where IDX = " + txtidxNo.Text + "";

            cmd = new OleDbCommand(query, Conn);

            //Conn.Open();

            cmd.ExecuteNonQuery();

            //Conn.Close();


            query = " update PQMS_STAFF_RP_EACH_LIST set ";
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

        private void cmbApprover_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] tapprover = cmbApprover.Text.Split(' ');
            txtAccountNo.Text = tapprover[0];
            txtLoginID.Text = tapprover[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            requestedby = approvedby; //현재 승인권자가 상위 승인권자에게 승인 요청하는 요청자로서 처리
            //approvedby = approvedby;

            if (MyApproveDepth < FinalApproveDepth)
            {
                if(txtAccountNo.Text == "")
                {
                    MessageBox.Show("상위 승인권자 지정 바랍니다.");
                }
                else
                {

                    if (Form2_Tab_Info_Now.sTabName == "교육보고서")
                    {
                        save_approved();
                    }
                    else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
                    {
                        save_approved_role_paper();
                    }
                    else if (Form2_Tab_Info_Now.sTabName == "임명장")
                    {
                        save_approved_role_appoint();
                    }
                    else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
                    {
                        save_approved_each_list();
                    }
                    else if (Form2_Tab_Info_Now.sTabName == "직무자료")
                    {
                        save_approved_role();
                    }


                    MessageBox.Show(MyApproveDepth.ToString() + " 차 승인 완료");
                }
            }
            else
            {              

                if (Form2_Tab_Info_Now.sTabName == "교육보고서")
                {
                    save_approved();
                    final_approve();
                }
                else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
                {
                    save_approved_role_paper();
                    final_approve_role_paper();
                }
                else if (Form2_Tab_Info_Now.sTabName == "임명장")
                {
                    save_approved_role_appoint();
                    final_approve_role_appint();
                }
                else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
                {
                    save_approved_each_list();
                    final_approve_each_list();
                }
                else if (Form2_Tab_Info_Now.sTabName == "직무자료")
                {
                    save_approved_role();
                    final_approve_role();
                }

                MessageBox.Show("최종 승인 완료");
            }
        }

        private void final_approve()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE PQMS_STAFF_TRAINING SET ";
            query = query + " approveStatusCode = 1";
            query = query + " WHERE IDX = " + idxToBeApproved + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void final_approve_role_appint()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE PQMS_STAFF_ROLE_APPOINT SET ";
            query = query + " approveStatusCode = 1";
            query = query + " WHERE IDX = " + idxToBeApproved + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }
        private void final_approve_role_paper()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE PQMS_STAFF_ROLE_PAPER SET ";
            query = query + " approveStatusCode = 1";
            query = query + " WHERE IDX = " + idxToBeApproved + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void final_approve_role()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE PQMS_STAFF_ROLE SET ";
            query = query + " approveStatusCode = 1";
            query = query + " WHERE IDX = " + idxToBeApproved + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void final_approve_each_list()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE PQMS_STAFF_RP_EACH_LIST SET ";
            query = query + " approveStatusCode = 1";
            query = query + " WHERE IDX = " + idxToBeApproved + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //requestedby = approvedby;
            //approvedby = approvedby;

            


            if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                save_rejected();
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                save_rejected_role_paper();    
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                save_rejected_role_appoint();
            }
            else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
            {
                save_rejected_each_list();
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무자료")
            {
                save_rejected_role();
            }

            MessageBox.Show(MyApproveDepth.ToString() + " 차 반려 처리 완료");
        }


        private void dgvUserRequestStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex != -1)
            {               

                if (Form2_Tab_Info_Now.sTabName == "교육보고서")
                {
                    txtidxNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                    idxToBeApproved = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                    //txtTitle.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                    MyApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[35].Value.ToString().Trim());
                    FinalApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[36].Value.ToString().Trim());
                    requesterDeptCode = dgvUserRequestStatus.Rows[e.RowIndex].Cells[26].Value.ToString().Trim();
                    requestedby = dgvUserRequestStatus.Rows[e.RowIndex].Cells[37].Value.ToString().Trim();
                }
                else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
                {
                    txtidxNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                    idxToBeApproved = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                    //txtTitle.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                    MyApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[23].Value.ToString().Trim());
                    FinalApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[24].Value.ToString().Trim());
                    requesterDeptCode = dgvUserRequestStatus.Rows[e.RowIndex].Cells[14].Value.ToString().Trim();
                    requestedby = dgvUserRequestStatus.Rows[e.RowIndex].Cells[25].Value.ToString().Trim();
                }
                else if (Form2_Tab_Info_Now.sTabName == "임명장")
                {
                    txtidxNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                    idxToBeApproved = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                    //txtTitle.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                    MyApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[22].Value.ToString().Trim());
                    FinalApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[23].Value.ToString().Trim());
                    requesterDeptCode = dgvUserRequestStatus.Rows[e.RowIndex].Cells[13].Value.ToString().Trim();
                    requestedby = dgvUserRequestStatus.Rows[e.RowIndex].Cells[24].Value.ToString().Trim();


                    string query = " select STAFF_TEAM  from PQMS_STAFF where STAFF_CODE = '" + dgvUserRequestStatus.Rows[e.RowIndex].Cells[4].Value.ToString().Trim() + "' ";
                    OleDbCommand cmd = new OleDbCommand(query, Conn);
                    Conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dbtable = new DataTable();
                        dbtable.Load(reader);

                        Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM = dbtable.Rows[0][0].ToString();
                    }
                    Conn.Close();


                }
                else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
                {
                    txtidxNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                    idxToBeApproved = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                    //txtTitle.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                    MyApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[28].Value.ToString().Trim());
                    FinalApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[29].Value.ToString().Trim());
                    requesterDeptCode = dgvUserRequestStatus.Rows[e.RowIndex].Cells[19].Value.ToString().Trim();
                    requestedby = dgvUserRequestStatus.Rows[e.RowIndex].Cells[30].Value.ToString().Trim();
                }
                else if (Form2_Tab_Info_Now.sTabName == "직무자료")
                {
                    txtidxNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                    idxToBeApproved = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                    //txtTitle.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                    MyApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[29].Value.ToString().Trim());
                    FinalApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[30].Value.ToString().Trim());
                    requesterDeptCode = dgvUserRequestStatus.Rows[e.RowIndex].Cells[20].Value.ToString().Trim();
                    requestedby = dgvUserRequestStatus.Rows[e.RowIndex].Cells[31].Value.ToString().Trim();
                }



                //txtidxNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                //idxToBeApproved = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[2].Value.ToString().Trim());
                //txtTitle.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                //MyApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[35].Value.ToString().Trim());
                //FinalApproveDepth = Convert.ToInt32(dgvUserRequestStatus.Rows[e.RowIndex].Cells[36].Value.ToString().Trim());
                //requesterDeptCode = dgvUserRequestStatus.Rows[e.RowIndex].Cells[26].Value.ToString().Trim();
                //requestedby = dgvUserRequestStatus.Rows[e.RowIndex].Cells[37].Value.ToString().Trim();


                txtToBeApproved.Text = idxToBeApproved.ToString();
            }
        }

        private void txtToBeApproved_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
