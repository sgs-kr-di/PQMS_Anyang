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
    public partial class frmApproveRequest : Form
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
        public int approveDepth = 0;

        public frmApproveRequest()
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
                    get_first_approver(tDeptCode.Substring(0, tDeptCode.Length - 1));
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


        private void frmApproveRequest_Load(object sender, EventArgs e)
        {
            this.Text = Form2_Tab_Info_Now.sMenuName + "-" + Form2_Tab_Info_Now.sTabName + "-" + "승인요청";

            txtTitle.Text = Form2_Tab_Info_Now.sTabName;
            set_approve_parameter();
            //frmApproveRequest test = new frmApproveRequest();

            
            //get_approve_param(); //승인관련변수할당 -> userManagement -> 승인업무정리 참조

            //get_approval_right1();
            //get_approval_right2();
            //get_max_role_depth();
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
            query = query + " FROM[accountMaster].[dbo].[approveRole_V1] a inner join[accountMaster].[dbo].[accountMaster] b ";
            query = query + " on (a.accountNo = b.accountNo)";
            query = query + " inner join[accountMaster].[dbo].[userMaster] c on (b.userID = c.userID) ";
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
                        cmbApprover.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() +" "+ reader.GetValue(3).ToString());
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

            query = " select isnull(max(MaxApproveDepth),0) from [accountMaster].[dbo].[approveRole_V1] ";
            query = query + "    where appNo = " + appNo;
            query = query + "    and menuNo = " + MenuNo;
            query = query + "    and workNo = " + WorkNo;
            query = query + "    and deptNo = '" + requesterDeptCode +"'";

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

      
        private void btnEduReportGo_Click(object sender, EventArgs e)
        {
            if (approvechek() == 0)
            {
                save_item2();
                MessageBox.Show("승인 요청 완료");
            }
            else
            {
                MessageBox.Show("이미 승인 요청 되었습니다.");
            }
        }

        private int approvechek()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            int tchk = 0;
            string query = "";

            if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                query = "SELECT  isnull(requestStatusCode,0) FROM PQMS_STAFF_TRAINING ";
                query = query + " where IDX = " + txtidxNo.Text + "";
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                query = "SELECT  isnull(requestStatusCode,0) FROM PQMS_STAFF_ROLE_PAPER ";
                query = query + " where IDX = " + txtidxNo.Text + "";
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                query = "SELECT  isnull(requestStatusCode,0) FROM PQMS_STAFF_ROLE_APPOINT ";
                query = query + " where IDX = " + txtidxNo.Text + "";
            }
            else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
            {
                query = "SELECT  isnull(requestStatusCode,0) FROM PQMS_STAFF_RP_EACH_LIST ";
                query = query + " where IDX = " + txtidxNo.Text + "";
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무자료")
            {
                query = "SELECT  isnull(requestStatusCode,0) FROM PQMS_STAFF_ROLE ";
                query = query + " where IDX = " + txtidxNo.Text + "";
            }


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

        private void save_item2()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            /*
            select * from appMaster_Dept
            select * from appMaster_Work
            select * from appMaster_Menu
            */

            if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                query = " update PQMS_STAFF_TRAINING set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX = " + txtidxNo.Text + "";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();
                cmd.ExecuteNonQuery();
                //Conn.Close();

                query = " insert into PQMS_STAFF_TRAINING_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + txtidxNo.Text + ",";
                query = query + "" + appNo + ",";
                query = query + "'" + requesterDeptCode + "',";
                query = query + "" + WorkNo + ",";
                query = query + "" + MenuNo + ",";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "0" + ",";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + approveDepth + ","; //target/final approve depth
                query = query + "'" + Form2PQMS_LoginInfo.sloginId + "',";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'',";
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "')";

                cmd = new OleDbCommand(query, Conn);                
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                query = " update PQMS_STAFF_ROLE_PAPER set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX = " + txtidxNo.Text + "";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();
                cmd.ExecuteNonQuery();
                //Conn.Close();

                query = " insert into PQMS_STAFF_ROLE_PAPER_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + txtidxNo.Text + ",";
                query = query + "" + appNo + ",";
                query = query + "'" + requesterDeptCode + "',";
                query = query + "" + WorkNo + ",";
                query = query + "" + MenuNo + ",";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "0" + ",";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + approveDepth + ","; //target/final approve depth
                query = query + "'" + Form2PQMS_LoginInfo.sloginId + "',";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'',";
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "')";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {
                query = " update PQMS_STAFF_ROLE_APPOINT set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX = " + txtidxNo.Text + "";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();
                cmd.ExecuteNonQuery();
                //Conn.Close();

                query = " insert into PQMS_STAFF_ROLE_APPOINT_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + txtidxNo.Text + ",";
                query = query + "" + appNo + ",";
                query = query + "'" + requesterDeptCode + "',";
                query = query + "" + WorkNo + ",";
                query = query + "" + MenuNo + ",";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "0" + ",";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + approveDepth + ","; //target/final approve depth
                query = query + "'" + Form2PQMS_LoginInfo.sloginId + "',";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'',";
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "')";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
            {
                query = " update PQMS_STAFF_RP_EACH_LIST set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX = " + txtidxNo.Text + "";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();
                cmd.ExecuteNonQuery();
                //Conn.Close();

                query = " insert into PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + txtidxNo.Text + ",";
                query = query + "" + appNo + ",";
                query = query + "'" + requesterDeptCode + "',";
                query = query + "" + WorkNo + ",";
                query = query + "" + MenuNo + ",";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "0" + ",";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + approveDepth + ","; //target/final approve depth
                query = query + "'" + Form2PQMS_LoginInfo.sloginId + "',";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'',";
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "')";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무자료")
            {
                query = " update PQMS_STAFF_ROLE set ";
                query = query + " appNo = " + appNo + ",";
                query = query + " DeptNo = '" + requesterDeptCode + "',";
                query = query + " WorkNo = " + WorkNo + ",";
                query = query + " MenuNo = " + MenuNo + ",";
                query = query + " requestStatusCode = 1" + ",";  //1: requested, 0/null:not requested
                query = query + " approveStatusCode = 0" + ","; //1:approved, 0:not approved
                query = query + " approveComment = N'" + txtRequestContent.Text + "'";
                query = query + " where IDX = " + txtidxNo.Text + "";

                OleDbCommand cmd = new OleDbCommand(query, Conn);

                Conn.Open();
                cmd.ExecuteNonQuery();
                //Conn.Close();

                query = " insert into PQMS_STAFF_ROLE_APPROVE_LOG ";
                query = query + " (approveIdx, appNo, DeptNo, WorkNo, MenuNo, requestTo, CurrentApproveDepth, ";
                query = query + " FinalApproveDepth, requestedBy, approvedYN, approvedby, requestDate) values (";
                query = query + "" + txtidxNo.Text + ",";
                query = query + "" + appNo + ",";
                query = query + "'" + requesterDeptCode + "',";
                query = query + "" + WorkNo + ",";
                query = query + "" + MenuNo + ",";
                query = query + "'" + txtLoginID.Text + "',";
                query = query + "0" + ",";  //currnet approve depth - 0:not approved, 1: 1st approved, 2: 2nd approved 
                query = query + "" + approveDepth + ","; //target/final approve depth
                query = query + "'" + Form2PQMS_LoginInfo.sloginId + "',";
                query = query + "'N',"; //N:Not approved, Y:approved
                query = query + "'',";
                query = query + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "')";

                cmd = new OleDbCommand(query, Conn);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }

            //MessageBox.Show(query);
        }


        private void cmbApprover_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] tapprover = cmbApprover.Text.Split(' ');
            txtAccountNo.Text = tapprover[0];
            txtLoginID.Text = tapprover[1];
        }
    }
}
