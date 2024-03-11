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
using Spire.Doc;
using System.IO;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Diagnostics;
using PQMS.C.Unit;

namespace PQMS
{
    public partial class frmRolePaper : Form
    {        
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        private static readonly List<string> wordExtensions = new List<string> { ".DOC", ".DOCX" };

        DataTable USERINFO = new DataTable();
        DataTable RNR = new DataTable();
        DataTable DOCU = new DataTable();
        DataTable DOCU2 = new DataTable();
        DataTable ADDRR = new DataTable();
        DataTable EACHLIST = new DataTable();
        DataTable dt_DATE = new DataTable();
        DataTable dt_Version = new DataTable();
        


        private string tmpstr = "";
        private string tmpidx = "";
        private string tmpreason = "";
        private string tmpgroupname2 = "";
        private string tmp_RP_CAREER = "";

        private int iEachCnt = 0;
        private string sEachCon = "";
        private string sEachTest = "";

        public frmRolePaper()
        {
            InitializeComponent();
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


        private void get_folder_data2(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2

        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            query = query + " and REPORT_NAME ='" + Form2_Tab_Info_Now.sTabName + "'";
            query = query + "      order by " + tField1 + "," + tField2;

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

        private void show_file(string tFileNM)
        {
            string tPath = "";
            string tFile = "";
            string tPathFile = "";

          
            tPathFile = tFileNM;

            //Create word document
            Document document = new Document();

            string ext = System.IO.Path.GetExtension(tFile);

            if (File.Exists(@tPathFile) == true)
            {               
                {
                    try
                    {
                        //System.Diagnostics.Process.Start(@tPath + "\\" + tFile);
                        System.Diagnostics.Process.Start(@tPathFile);

                    }
                    catch { }
                }
            }
            else
            {
                MessageBox.Show("File not exist");
            }

        }

        private string file_open(System.Windows.Forms.TextBox tb1)
        {
            string fileName = OpenFile();
            //string fileName = "E:\\T42\\WORK\\request\\오로라\\테스트\\복사본 KI2015019.xls";
            string plainText = string.Empty;
            string ext = System.IO.Path.GetExtension(fileName).ToUpper();
            string directoryPath = string.Empty;
            tb1.Text = fileName;

            if (fileName.Length > 0)
            {
                return fileName;
            }

            return string.Empty;
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

        private void creatDataTable_Anyang(string sStaffCode = "", string sidx = "", string sRPCode="", string sEACHIDX ="")
        {           



            //1.인적사항)
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = " select t1.STAFF_NAME, t1.STAFF_JOIN_DATE, t1.STAFF_SCHOOL, t1.STAFF_MAJOR, t2.STAFF_RP_SUPPORTER , t2.STAFF_RP_APPROVER, t1.STAFF_TEAM, x.FOLDER_NAME , y.ROLE_VERSION, y.ROLE_NAME" +
                    " ,t2.STAFF_RP_FRISTDATE ,t2.STAFF_RP_CAREER	,t2.STAFF_RP_REASON " +
                    " from[dbo].[PQMS_STAFF] as t1 with(nolock) " +
                    " inner join PQMS_STAFF_ROLE_PAPER as t2 with(nolock)  on t1.STAFF_CODE = t2.STAFF_CODE " +
                    " inner join K_WORKSPACE x on x.SITE_CODE + '-' + x.REPOSITORY_CODE + '-' + x.WS_CODE + '-' + x.FOLDER_CODE = t1.STAFF_TEAM " +
                    " inner join PQMS_ROLE2_CODE y on t2.STAFF_RP_CODE = y.ROLE_CODE and x.SITE_CODE = y.SITE_CODE and x.REPOSITORY_CODE = y.REPOSITORY_CODE and x.WS_CODE = y.WS_CODE " + 
                    $" where t1.STAFF_CODE = '{sStaffCode}' and t2.IDX = '{sidx}'";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            USERINFO.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                USERINFO.Load(reader);
            }
            Conn.Close();

            //버전정보 
            query = " select isnull(MAX(RP_VERSION),0) +1 'Version'  from PQMS_STAFF_ROLE_PAPER_FINAL where STAFF_CODE = '" + Form2PQMS_StaffInfo.sStaffCode + "' and rp_org_code = '" + Form2PQMS_StaffInfo.sPMQ_STAFF_ROLE_PAPER_ORG_CODE + "' and RP_CODE= '"+sRPCode+"'";
            Conn = new OleDbConnection(unitCommon.connect_string);
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            dt_Version.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_Version.Load(reader);
            }
            Conn.Close();


            // 2.주요직무에대한 책임과 역할
            Conn = new OleDbConnection(unitCommon.connect_string);
            query = " select  " +
                    "  t3.DOCU_CONTENTS1 " +
                    " + case when DOCU_CONTENTS2<> '' then char(13) + char(10) +t3.DOCU_CONTENTS2   else '' end " +
                    " + case when DOCU_CONTENTS3<> '' then char(13) + char(10) +t3.DOCU_CONTENTS3   else '' end " +
                    " + case when DOCU_CONTENTS4<> '' then char(13) + char(10) +t3.DOCU_CONTENTS4   else '' end " +
                    " + case when DOCU_CONTENTS5<> '' then char(13) + char(10) +t3.DOCU_CONTENTS5   else '' end " +
                    " + case when DOCU_CONTENTS6<> '' then char(13) + char(10) +t3.DOCU_CONTENTS6   else '' end " +
                    " + case when DOCU_CONTENTS7<> '' then char(13) + char(10) +t3.DOCU_CONTENTS7   else '' end " +
                    " + case when DOCU_CONTENTS8<> '' then char(13) + char(10) +t3.DOCU_CONTENTS8   else '' end " +
                    " + case when DOCU_CONTENTS9<> '' then char(13) + char(10) +t3.DOCU_CONTENTS9   else '' end " +
                    " + case when DOCU_CONTENTS10<> '' then char(13) + char(10)+t3.DOCU_CONTENTS10  else '' end as DOCU_CONTENTS " +
                    "  , RTRIM(t3.DOCU_CODE) +' '+ t3.DOCU_CODENAME as DOCU_NAME " +
                    " from[dbo].[PQMS_STAFF] as t1 with(nolock) " +
                    " inner join PQMS_STAFF_ROLE_PAPER as t2 with(nolock) " +
                    " on t1.STAFF_CODE = t2.STAFF_CODE " +
                    " inner join PQMS_ROLE2_DOCU as t3 with(nolock) " +
                    " on t2.STAFF_RP_CODE = t3.ROLE_CODE and t1.SITE_CODE = t3.SITE_CODE and t1.REPOSITORY_CODE = t3.REPOSITORY_CODE and t1.WS_CODE = t3.WS_CODE " +
                    $" where t1.STAFF_CODE = '{sStaffCode}' and t2.IDX = '{sidx}'" +
                    " Order by t3.DOCU_NO ";

            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            DOCU.Reset();            
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                DOCU.Load(reader);
            }
            Conn.Close();
            /// 2.주요직무에대한 책임과 역할 하단에 개발업무목록 추가되는 부분 
            if (sEACHIDX == "")
            {
                sEACHIDX = "0";
            }
            Conn = new OleDbConnection(unitCommon.connect_string);
            query = " select  LIST_CONTENTS1, LIST_REMARK from PQMS_STAFF_RP_EACH_LIST " +
                    $" where STAFF_CODE = '{sStaffCode}' and IDX in  ( " + sEACHIDX + ") ";

            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            DOCU2.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                DOCU2.Load(reader);
            }
            Conn.Close();


            //3.업무수행에필요한 교육훈련 테이블
            Conn = new OleDbConnection(unitCommon.connect_string);
            query = " SELECT STAFF_TRAIN_EDU , STAFF_TRAIN_DATE +'~'+STAFF_TRAIN_DATE_TO , STAFF_TRAIN_ORG FROM PQMS_STAFF_TRAINING " +                    
                    $" where STAFF_CODE = '{sStaffCode}' and STAFF_TRAIN_COURSE <> '기타' " +
                    " Order by STAFF_TRAIN_DATE "; //교육기간으로 데이터 정렬 처리

            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            ADDRR.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                ADDRR.Load(reader);
            }
            Conn.Close();


            //4. 특정 또는 추가 직무기술
            Conn = new OleDbConnection(unitCommon.connect_string);
            query = "  SELECT RR_NAME, RR_CONTENTS from  PQMS_STAFF_RP_ADDITIONAL_RR " +
                    $" where STAFF_CODE = '{sStaffCode}'" +
                    " Order by 1 ";

            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            EACHLIST.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                EACHLIST.Load(reader);
            }
            Conn.Close();


            //5. 승인 날짜 테이블
            Conn = new OleDbConnection(unitCommon.connect_string);
            query = " select  * from PQMS_STAFF_ROLE_PAPER " +
                   $" where idx = '{sidx}' ";
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            dt_DATE.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_DATE.Load(reader);
            }
            Conn.Close();


        }


        private void createDataTable(string sStaffCode = "", string sidx = "")
        {
            //직무 기술서 1번 테이블
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = " select t1.STAFF_NAME, t1.STAFF_JOIN_DATE, t2.STAFF_RP_SUPPORTER " +
                    " from[dbo].[PQMS_STAFF] as t1 with(nolock)" +
                    " inner join PQMS_STAFF_ROLE_PAPER as t2 with(nolock) " +
                    " on t1.STAFF_CODE = t2.STAFF_CODE " +
                    $" where t1.STAFF_CODE = '{sStaffCode}' and t2.IDX = '{sidx}'";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            USERINFO.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                USERINFO.Load(reader);
            }
            Conn.Close();

            //직무 기술서 2번 테이블
            Conn = new OleDbConnection(unitCommon.connect_string);
            query = " select t3.ROLE_CONTENTS " +
                    " from[dbo].[PQMS_STAFF] as t1 with(nolock) " +
                    " inner join PQMS_STAFF_ROLE_PAPER as t2 with(nolock) " +
                    " on t1.STAFF_CODE = t2.STAFF_CODE " +
                    " inner join PQMS_ROLE2_RNR as t3 with(nolock) " +
                    " on t2.STAFF_RP_CODE = t3.ROLE_CODE " +
                   $" where t1.STAFF_CODE = '{sStaffCode}' and t2.IDX = '{sidx}' ";
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            RNR.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                RNR.Load(reader);

            }
            Conn.Close();

            //직무기술서 3번 테이블
            Conn = new OleDbConnection(unitCommon.connect_string);
            query = " select t3.DOCU_CODE, t3.DOCU_CODENAME, " +
                    " t3.DOCU_CONTENTS1 " +
                    " + case when DOCU_CONTENTS2<> '' then char(13) + char(10) +t3.DOCU_CONTENTS2   else '' end " +
                    " + case when DOCU_CONTENTS3<> '' then char(13) + char(10) +t3.DOCU_CONTENTS3   else '' end " +
                    " + case when DOCU_CONTENTS4<> '' then char(13) + char(10) +t3.DOCU_CONTENTS4   else '' end " +
                    " + case when DOCU_CONTENTS5<> '' then char(13) + char(10) +t3.DOCU_CONTENTS5   else '' end " +
                    " + case when DOCU_CONTENTS6<> '' then char(13) + char(10) +t3.DOCU_CONTENTS6   else '' end " +
                    " + case when DOCU_CONTENTS7<> '' then char(13) + char(10) +t3.DOCU_CONTENTS7   else '' end " +
                    " + case when DOCU_CONTENTS8<> '' then char(13) + char(10) +t3.DOCU_CONTENTS8   else '' end " +
                    " + case when DOCU_CONTENTS9<> '' then char(13) + char(10) +t3.DOCU_CONTENTS9   else '' end " +
                    " + case when DOCU_CONTENTS10<> '' then char(13) + char(10)+t3.DOCU_CONTENTS10  else '' end as DOCU_CONTENTS " +
                    " from[dbo].[PQMS_STAFF] as t1 with(nolock) " +
                    " inner join PQMS_STAFF_ROLE_PAPER as t2 with(nolock) " +
                    " on t1.STAFF_CODE = t2.STAFF_CODE " +
                    " inner join PQMS_ROLE2_DOCU as t3 with(nolock) " +
                    " on t2.STAFF_RP_CODE = t3.ROLE_CODE " +
                   $" where t1.STAFF_CODE = '{sStaffCode}' and t2.IDX = '{sidx}'";
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            DOCU.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                DOCU.Load(reader);
            }
            Conn.Close();

            //직무 기술서 4번 테이블
            Conn = new OleDbConnection(unitCommon.connect_string);
            query = " select t2.rr_name, t2.rr_contents " +
                    " from[dbo].[PQMS_STAFF] as t1 with(nolock) " +
                    " inner join PQMS_STAFF_RP_ADDITIONAL_RR as t2 with(nolock) " +
                    " on t1.STAFF_CODE = t2.STAFF_CODE " +
                   $" where t1.STAFF_CODE = '{sStaffCode}' ";
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            ADDRR.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                ADDRR.Load(reader);
            }
            Conn.Close();

            //직무 기술서 5번 테이블
            Conn = new OleDbConnection(unitCommon.connect_string);
            query = " select LIST_NO, LIST_WORKDATE, '' AS CATEGORY, LIST_CONTENTS1, " +
                    "        LIST_TECHNICAL_MANAGER + char(13) + char(10) + LIST_CHKDATE + ' ' + LIST_CHKSIGN," +
                    "        LIST_REMARK " +
                    " from[dbo].[PQMS_STAFF] as t1 with(nolock) " +
                    " inner join PQMS_STAFF_RP_EACH_LIST as t2 with(nolock) " +
                    " on t1.STAFF_CODE = t2.STAFF_CODE " +
                   $" where t1.STAFF_CODE = '{sStaffCode}'";
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            EACHLIST.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                EACHLIST.Load(reader);
            }
            Conn.Close();


            //jhm 승인 날짜 
            Conn = new OleDbConnection(unitCommon.connect_string);
            query = " select  * from PQMS_STAFF_ROLE_PAPER " +
                   $" where idx = '{sidx}' ";
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            dt_DATE.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_DATE.Load(reader);
            }
            Conn.Close();

        }

        private void Replace_Anyang(Document document, string sDirInput = "", string sDirOutput = "", string sRPCode="")
        {            
            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            if (USERINFO.Rows.Count > 0)
            {
                document.Replace("txt01", USERINFO.Rows[0]["FOLDER_NAME"].ToString(), false, true);  //소속(팀)
                document.Replace("txt02", USERINFO.Rows[0]["STAFF_JOIN_DATE"].ToString(), false, true);  //입사년월
                document.Replace("txt03", USERINFO.Rows[0]["STAFF_NAME"].ToString(), false, true); //이름
                document.Replace("txt04", USERINFO.Rows[0]["STAFF_SCHOOL"].ToString() +"/" + USERINFO.Rows[0]["STAFF_MAJOR"].ToString(), false, true); //학력/전공
                document.Replace("txt05", USERINFO.Rows[0]["STAFF_RP_SUPPORTER"].ToString(), false, true); //대리인
                document.Replace("txt06", USERINFO.Rows[0]["STAFF_RP_APPROVER"].ToString(), false, true); //승인자                
                document.Replace("txt08", USERINFO.Rows[0]["ROLE_NAME"].ToString(), false, true); //담당역할
                //document.Replace("txt09", USERINFO.Rows[0]["STAFF_RP_CAREER"].ToString(), false, true); //주요경력                
                document.Replace("txt09", tmp_RP_CAREER, false, true); //주요경력                
                document.Replace("txt11", USERINFO.Rows[0]["STAFF_RP_FRISTDATE"].ToString(), false, true); //최초자격인증일

                if (tmpstr != "")
                {
                    document.Replace("txt10", tmpstr.Substring(2, tmpstr.Length-2) , false, true); //자격분야
                }           
            }

            //버전 
            if (dt_Version.Rows.Count > 0)
            {
                document.Replace("txt07", "V" + dt_Version.Rows[0]["Version"].ToString()+".0", false, true); //버전
            }          

            //2번 
            if (DOCU.Rows.Count > 0)
            {
                textAppendWithClone_Add(DOCU, document, "tb00");
                textAppendWithClone_Add_each(DOCU2, document, "tb00");
                /// textAppend(document, "tb00"); //개별업무목록  ///
            }

            //3번
            if (ADDRR.Rows.Count > 0)
            {
                textAppendWithClone(ADDRR, document, "tb01");
            }

            //4번
            if (EACHLIST.Rows.Count > 0)
            {
                textAppendWithClone(EACHLIST, document, "tb02");
            }

            //5번승인일자 테이블 
            if (dt_DATE.Rows.Count > 0)
            {
                document.Replace("TxtWriteDate", dt_DATE.Rows[0]["STAFF_RP_WRITER"].ToString() +"/"+ dt_DATE.Rows[0]["STAFF_RP_DATE"].ToString(), false, true);              


                //검토 승인은 승인시 데이터로 수정 하기 위해서 처리 안함. 
                //document.Replace("TxtApprove1", "", false, true);

                //if (dt_DATE.Rows[0]["STAFF_RP_APPROVE_DATE"].ToString() != null)
                //{
                //    document.Replace("TxtApprove2", dt_DATE.Rows[0]["STAFF_RP_APPROVER"].ToString() + "/" + dt_DATE.Rows[0]["STAFF_RP_APPROVE_DATE"].ToString(), false, true);
                //}
                //else
                //{
                //    document.Replace("TxtApprove2", dt_DATE.Rows[0]["STAFF_RP_APPROVER"].ToString()+"/", false, true);
                //}                    
            }

            string filePath = @sDirOutput + @"\" + @Path.GetFileNameWithoutExtension(sDirInput) + "_" + Form2PQMS_StaffInfo.sStaffCode + "(" + tmpidx.Substring(2, tmpidx.Length - 2) + ")" + ".pdf";
            PR_Final(filePath, sRPCode);

            MessageBox.Show("발행완료!");
            document.SaveToFile(filePath);            
            Process.Start(filePath);

        }

        private void PR_Final(string filePath, string rpcode)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";
            query = "update PQMS_STAFF_ROLE_PAPER set ";
            query = query + " STAFF_RP_FILE = N'" + filePath + "', ";
            query = query + " STAFF_RP_FINAL = 'Y' ";
            query = query + " where IDX in (" + tmpidx.Substring(2, tmpidx.Length-2) + ")" ;
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

            query = "insert into PQMS_STAFF_ROLE_PAPER_FINAL (STAFF_CODE, PQMS_STAFF_ROLE_PAPER_IDX, RP_ORG_CODE, RP_CODE, RP_FINAL_FILE , RP_VERSION, RP_CREATE_DATE,  RP_REASON, RP_GROUP_NAME2) Values ( " +
                     " '" + Form2PQMS_StaffInfo.sStaffCode + "', '" + tmpidx.Substring(2, tmpidx.Length - 2) + "', '" + Form2PQMS_StaffInfo.sPMQ_STAFF_ROLE_PAPER_ORG_CODE + "', '"+ rpcode + "', '" + filePath + "' , " +
                     " ( select isnull(MAX(RP_VERSION),0) + 1  from PQMS_STAFF_ROLE_PAPER_FINAL where STAFF_CODE='" + Form2PQMS_StaffInfo.sStaffCode + "' and rp_org_code='" + Form2PQMS_StaffInfo.sPMQ_STAFF_ROLE_PAPER_ORG_CODE + "' and RP_CODE='"+ rpcode + "' ), " +
                     " '"+ DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss")  + "', '" + tmpreason +"' , '"+tmpgroupname2+"' )";


            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

        }

        private void textAppend(Document document, String TableName)
        {
            int firstdatarow = 0;

            foreach (Section sec in document.Sections)
                foreach (Table tb in sec.Tables)
                    if (tb.Title == TableName)
                    {
                        firstdatarow = tb.Rows.Count - 1;
                        TableCell trc0 = tb.Rows[firstdatarow].Cells[0];
                        TableCell trc1= tb.Rows[firstdatarow].Cells[1];
                        trc0.ChildObjects.Clear();
                        trc1.ChildObjects.Clear();
                        
                        Paragraph pr0 = trc0.AddParagraph();                           
                        pr0.ApplyStyle("kr");
                        pr0.AppendText(sEachCon);

                        Paragraph pr1 = trc1.AddParagraph();
                        pr1.ApplyStyle("kr");
                        pr1.AppendText(sEachTest);

                    }
        }

        private void textAppendWithClone_Add_each(DataTable dt, Document document, String TableName)
        {
            int firstdatarow = 0;
            foreach (Section sec in document.Sections)
                foreach (Table tb in sec.Tables)
                    if (tb.Title == TableName)
                    {
                        firstdatarow = tb.Rows.Count - 1;
                        TableRow firstrow = tb.Rows[firstdatarow].Clone();
                        TableRow tr;
                        int rowindex;
                        for (int o = 0; o < dt.Rows.Count; o++)
                        {
                            if (o == 0)
                            {
                                tr = tb.Rows[firstdatarow];
                            }
                            else
                            {
                                rowindex = tb.Rows.Add(firstrow.Clone());
                                tr = tb.Rows[rowindex];
                            }

                            for (int i = 0; i < tr.Cells.Count; i++)
                            {
                                TableCell tbc = tr.Cells[i];

                                if (o < dt.Rows.Count) //dt테이블 데이터 입력 
                                {
                                    for (int x = 0; x < dt.Rows[o][i].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None).ToArray().Length; x++)
                                    {
                                        string st = dt.Rows[o][i].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None).ToArray()[x];
                                        if (x == 0)
                                        {
                                            Paragraph pr = tbc.Paragraphs[0];
                                            pr.AppendText(st);
                                            pr.ApplyStyle("kr");
                                        }
                                        else
                                        {
                                            Paragraph newpr = tbc.AddParagraph();
                                            newpr.AppendText(st);
                                            newpr.ApplyStyle("kr");
                                        }
                                    }
                                }

                                //테이블 보더 굵기 조절 - row 안됨 cell 단위로만 된다함 ㅡㅡ
                                //if (o == 0)
                                //    tbc.CellFormat.Borders.Top.LineWidth = 3f;
                                //else 

                                if (o == dt.Rows.Count - 1)
                                    tbc.CellFormat.Borders.Bottom.LineWidth = 1.5f;
                                else
                                {


                                    //tbc.CellFormat.Borders.Bottom.LineWidth = 5f;
                                    //tbc.CellFormat.Borders.Top.BorderType = Spire.Doc.Documents.BorderStyle.None;
                                    //tbc.CellFormat.Borders.Bottom.BorderType = Spire.Doc.Documents.BorderStyle.None; 

                                }
                                   

                            }
                        }
                    }
        }


        private void textAppendWithClone_Add(DataTable dt, Document document, String TableName)
        {
            int firstdatarow = 0;
            foreach (Section sec in document.Sections)
                foreach (Table tb in sec.Tables)
                    if (tb.Title == TableName)
                    {
                        firstdatarow = tb.Rows.Count - 1;
                        TableRow firstrow = tb.Rows[firstdatarow].Clone();
                        TableRow tr;
                        int rowindex;
                        for (int o = 0; o < dt.Rows.Count + 2 ; o++)
                        {
                            if (o == 0)
                            {
                                tr = tb.Rows[firstdatarow];
                            }
                            else
                            {
                                rowindex = tb.Rows.Add(firstrow.Clone());
                                tr = tb.Rows[rowindex];
                            }

                            for (int i = 0; i < tr.Cells.Count; i++)
                            {
                                TableCell tbc = tr.Cells[i];

                                if (o < dt.Rows.Count) //dt테이블 데이터 입력 
                                {
                                    for (int x = 0; x < dt.Rows[o][i].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None).ToArray().Length; x++)
                                    {
                                        string st = dt.Rows[o][i].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None).ToArray()[x];
                                        if (x == 0)
                                        {
                                            Paragraph pr = tbc.Paragraphs[0];
                                            pr.AppendText(st);
                                            pr.ApplyStyle("kr");
                                        }
                                        else
                                        {
                                            Paragraph newpr = tbc.AddParagraph();
                                            newpr.AppendText(st);
                                            newpr.ApplyStyle("kr");
                                        }
                                    }
                                }

                                //테이블 보더 굵기 조절 - row 안됨 cell 단위로만 된다함 ㅡㅡ
                                //if (o == 0)
                                //    tbc.CellFormat.Borders.Top.LineWidth = 1.5f;
                                //else if (o == dt.Rows.Count + 1)
                                //    tbc.CellFormat.Borders.Bottom.LineWidth = 1.5f;
                            }
                        }
                    }
        }


        private void textAppendWithClone(DataTable dt, Document document, String TableName)
        {
            int firstdatarow = 0;
            foreach (Section sec in document.Sections)
                foreach (Table tb in sec.Tables)
                    if (tb.Title == TableName)
                    {
                        firstdatarow = tb.Rows.Count - 1;
                        TableRow firstrow = tb.Rows[firstdatarow].Clone();
                        TableRow tr;
                        int rowindex;
                        for (int o = 0; o < dt.Rows.Count; o++)
                        {
                            if (o == 0)
                            {
                                tr = tb.Rows[firstdatarow];
                            }
                            else
                            {
                                rowindex = tb.Rows.Add(firstrow.Clone());
                                tr = tb.Rows[rowindex];
                            }

                            for (int i = 0; i < tr.Cells.Count; i++)
                            {
                                TableCell tbc = tr.Cells[i];
                                //tbc.ChildObjects.Clear();
                                //Paragraph pr = tbc.Paragraphs[0];
                                //pr.ApplyStyle("kr");

                                for(int x =0;x< dt.Rows[o][i].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None).ToArray().Length;x++)
                                {
                                    string st = dt.Rows[o][i].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None).ToArray()[x];
                                    if (x==0)
                                    {
                                        Paragraph pr = tbc.Paragraphs[0];
                                        pr.AppendText(st);
                                        pr.ApplyStyle("kr");
                                    }
                                    else
                                    {
                                        Paragraph newpr = tbc.AddParagraph();
                                        newpr.AppendText(st);
                                        newpr.ApplyStyle("kr");
                                    }                               
                                }

                                //테이블 보더 굵기 조절 - row 안됨 cell 단위로만 된다함 ㅡㅡ
                                if (o == 0)
                                    tbc.CellFormat.Borders.Top.LineWidth = 1.5f;
                                else if (o == dt.Rows.Count - 1)
                                    tbc.CellFormat.Borders.Bottom.LineWidth = 1.5f;
                            }
                        }
                    }
        }

        private void btnRolePaper_Click(object sender, EventArgs e)
        {           

            //List<string> list_idx = new List<string>();
            int cnt = 0;
            string tmp_rpcode = "";
            tmpstr = "";
            tmpidx = "";
            tmpreason = "";
            tmpgroupname2 = "";
            tmp_RP_CAREER = "";

            string rp_IDX = "";
            string rp_RP_CODE = "";

            string each_IDX = "";
            

            //기술서
            foreach (int id in PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetSelectedRows())
            {
                if (cnt == 0)
                {
                    tmp_rpcode = PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "STAFF_RP_CODE").ToString();
                    
                    rp_IDX = PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "IDX").ToString();
                    rp_RP_CODE = PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "STAFF_RP_CODE").ToString();

                    tmp_RP_CAREER = PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "STAFF_RP_CAREER").ToString();

                }
                else
                {
                    if (tmp_rpcode != PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "STAFF_RP_CODE").ToString())
                    {
                        MessageBox.Show("기술서 코드가 다릅니다.");
                        return;
                    }

                    if (tmp_RP_CAREER != PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "STAFF_RP_CAREER").ToString())
                    {
                        tmp_RP_CAREER = tmp_RP_CAREER + "\r\n" + PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "STAFF_RP_CAREER").ToString();
                    }

                }
                cnt = cnt + 1;
                //list_idx.Add(PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "IDX").ToString() as string);
                tmpstr = tmpstr + ", " + PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "GROUP2_NAME").ToString();
                tmpidx = tmpidx + ", " + PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "IDX").ToString();
                tmpreason = tmpreason + " "  + PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "STAFF_RP_REASON").ToString();

                tmpgroupname2= tmpgroupname2 + "\r\n" + PQMS_STAFF_ROLE_PAPER_CHECKGridView.GetRowCellValue(id, "GROUP2_NAME").ToString();
            }


            //개별업무
            foreach (int id in PQMS_STAFF_ROLE_PAPER_EACHLISTGridView.GetSelectedRows())
            {
                if (sEachCon != "")
                {
                    sEachCon += "\r\n";
                }
                if (sEachTest != "")
                {
                    sEachTest += "\r\n";
                }
                if (each_IDX != "")
                {
                    each_IDX += ",";
                }

                iEachCnt = +1;
                sEachCon += PQMS_STAFF_ROLE_PAPER_EACHLISTGridView.GetRowCellValue(id, "LIST_CONTENTS1").ToString().Replace("\r\n",""); //업무내요
                sEachTest += PQMS_STAFF_ROLE_PAPER_EACHLISTGridView.GetRowCellValue(id, "TEST_FIELD").ToString().Replace("\r\n", ""); //시헙문야

                each_IDX += PQMS_STAFF_ROLE_PAPER_EACHLISTGridView.GetRowCellValue(id, "IDX").ToString();
            }

            sEachCon = sEachCon.Replace("\r\n\r\n", "\r\n");
            sEachTest = sEachTest.Replace("\r\n\r", "\r\n");
              
            if (cnt <= 0)
            {
                MessageBox.Show("왼쪽 하단 그리드에서 체크박스를 선택 하세요.");
                return;
            }


            ////기책은 없어도 됨... 
            //if (iEachCnt <= 0)
            //{
            //    MessageBox.Show("오른쪽 하단 그리드에서 체크박스를 선택 하세요.");
            //    return;
            //}

            //if (MessageBox.Show("수정하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{

            //}
          

            //안양
            Document document = new Document();
            //document.LoadFromFile(txtTemplate.Text);

            document.LoadFromFile(txtTemplate.Text, Spire.Doc.FileFormat.Docx, "ANYANG"); //템플릿에 암호 설정
            document.RemoveEncryption();

            FontStyle(document);

            // creatDataTable_Anyang(Form2PQMS_StaffInfo.sStaffCode, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX);
            creatDataTable_Anyang(Form2PQMS_StaffInfo.sStaffCode, rp_IDX, rp_RP_CODE, each_IDX);

            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
            string savrfilepath = txtResultFolder.Text + @"\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "직무기술서" + @"\" + sDateTime_yyyyMM;

            DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
            if (file_di.Exists == false)
            {
                Directory.CreateDirectory(savrfilepath);
            }

            Replace_Anyang(document, txtTemplate.Text, savrfilepath, rp_RP_CODE);
           
        }


        private void button7_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_report", "REPORT_NO", "REPORT_NAME", cmbReport);
        }

        private void cmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct REPORT_FILE, RESULT_FOLDER from PQMS_REPORT";
            query = query + "   WHERE REPORT_NO = '" + cmbReport.Text.Substring(0, 4) + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    txtTemplate.Text = "";

                    while (reader.Read())
                    {
                        txtTemplate.Text = reader.GetValue(0).ToString();
                        txtResultFolder.Text = reader.GetValue(1).ToString();
                    }
                }
            }

            Conn.Close();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            show_file(txtTemplate.Text.Trim());
        }

        private void button22_Click(object sender, EventArgs e)
        {
            file_open(txtTemplate);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            show_file(txtOrgChart.Text.Trim());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            file_open(txtOrgChart);
        }

        private void frmRolePaper_Load(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_report", "REPORT_NO", "REPORT_NAME", cmbReport);

            cmbReport.SelectedIndex = 0;

            DataTable dt = new DataTable();
            DataTable dt_each = new DataTable();


            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = " select A.IDX, A.STAFF_RP_ORG_CODE, x.ORG_NAME,  A.STAFF_RP_CLASS, A.STAFF_RP_CODE ,B.GROUP1_NUM, B.GROUP1_NAME , B.GROUP1_CODE ,C.GROUP2_NAME, C.GROUP2_CODE , A.STAFF_RP_CODE , A.STAFF_RP_REASON, A.STAFF_RP_CAREER" +
                    " from PQMS_STAFF_ROLE_PAPER A  " +
                    " inner join PQMS_ORG X on A.STAFF_RP_ORG_CODE = x.ORG_CODE and  X.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and 	X.REPOSITORY_CODE='" + Form1PQMS_Repo.sRepo + "' and X.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
                    " inner join PQMS_GROUP1 B on B.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and 	B.REPOSITORY_CODE='" + Form1PQMS_Repo.sRepo + "' and	B.WS_CODE='" + Form1PQMS_Repo.sWS + "' and a.STAFF_RP_ORG_CODE = B.GROUP1_ORG_CODE and left(a.STAFF_RP_CLASS, 4) = B.GROUP1_CODE " +
                    " inner join PQMS_GROUP2 C on C.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and 	C.REPOSITORY_CODE='" + Form1PQMS_Repo.sRepo + "' and	C.WS_CODE='" + Form1PQMS_Repo.sWS + "' and a.STAFF_RP_ORG_CODE = C.GROUP2_ORG_CODE and left(a.STAFF_RP_CLASS, 4) = c.GROUP2_GROUP1_CODE and RIGHT(a.STAFF_RP_CLASS,4)= c.GROUP2_CODE " +
                    $" where A.STAFF_CODE = '"+ Form2PQMS_StaffInfo.sStaffCode + "' and A.STAFF_RP_ORG_CODE= '"+ Form2PQMS_StaffInfo.sPMQ_STAFF_ROLE_PAPER_ORG_CODE + "'  and ( A.STAFF_RP_FINAL is null or A.STAFF_RP_FINAL <> 'Y') ";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            dt.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }
            Conn.Close();

            PQMS_STAFF_ROLE_PAPER_CHECKGrid.DataSource = null;
            if (dt.Rows.Count > 0)
            {
                PQMS_STAFF_ROLE_PAPER_CHECKGrid.DataSource = dt;
            }

            //하단그리드 >> 개별업무목록 
            query = $"  select IDX, LIST_CONTENTS1 , TEST_FIELD from  PQMS_STAFF_RP_EACH_LIST " +
            $" where STAFF_CODE = '{Form2PQMS_StaffInfo.sStaffCode}' and ROLE_PAPER= 'Y' ";

            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            dt_each.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_each.Load(reader);
            }
            Conn.Close();

            PQMS_STAFF_ROLE_PAPER_EACHLISTGrid.DataSource = null;
            if (dt_each.Rows.Count > 0)
            {
                PQMS_STAFF_ROLE_PAPER_EACHLISTGrid.DataSource = dt_each;
            }


        }
    }
}
