using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using Spire.Doc;
using System.IO;
using Spire.Doc.Documents;
using System.Diagnostics;
using PQMS.C.Unit;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace PQMS
{
    public partial class frmRoleAssessmentReport : Form
    {
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        DataTable USERINFO = new DataTable();
        DataTable dt_EDU1 = new DataTable();
        DataTable dt_EDU2 = new DataTable();
        DataTable dt_EDU3 = new DataTable();
        DataTable dt_PREJOB = new DataTable();
        private Form2_Anyang parentForm;

        public frmRoleAssessmentReport(Form2_Anyang parent)
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
            this.parentForm = parent;
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

            //tPath = "C:\\WORK\\FileServer";
            //tFile = lstAttached.SelectedItem.ToString();
            //txtSelected.Text = lstAttached.SelectedItem.ToString();

            //tPathFile = tPath + "\\" + tFile;
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
            //if (txtPhoto.Text != "")
            //{
            //    pic1.Load(txtPhoto.Text);
            //    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
            //}

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

        private void creatDataTable(string sStaffCode = "", string sidx = "", string sRPCode = "")
        {
            //1.인적사항)
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = " SELECT a.STAFF_NAME, a.STAFF_SCHOOL, a.STAFF_MAJOR, b.FOLDER_NAME FROM PQMS_STAFF a " +
                    " INNER JOIN   K_WORKSPACE b on b.SITE_CODE + '-' + b.REPOSITORY_CODE + '-' + b.WS_CODE + '-' + b.FOLDER_CODE = a.STAFF_TEAM " +
                   $" where a.STAFF_CODE = '{sStaffCode}' ";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            USERINFO.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                USERINFO.Load(reader);
            }
            Conn.Close();

            //교육사항 쿼리 
            query = " select a.STAFF_TRAIN_EDU, a.STAFF_TRAIN_ORG,   a.STAFF_TRAIN_DATE+'~'+a.STAFF_TRAIN_DATE_TO  as 'TRAIN_DATE' ,'' " +
                    " from[PQMS_STAFF_TRAINING] a " +
                   $" where STAFF_CODE = '{sStaffCode}' and substring(a.STAFF_TRAIN_COURSE, 1,4)= '0001' " +
                    " and substring(a.STAFF_TRAIN_COURSE, 6,4)  in ('E001', 'E002', 'E003', 'E004') " +
                    " order by a.STAFF_TRAIN_DATE "; // 교육기간으로 데이터 정렬 
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            dt_EDU1.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_EDU1.Load(reader);
            }
            Conn.Close();


            //근무경력 
            query = " SELECT  STAFF_PRE_REPOSITORY_NAME, STAFF_PRE_WS_NAME, STAFF_PRE_WORK_DATE, STAFF_PRE_WORK_REMARK   FROM PQMS_STAFF_PRE_JOB_INFO " +
                   $" where STAFF_CODe = '{sStaffCode}' ";
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            dt_PREJOB.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_PREJOB.Load(reader);
            }
            Conn.Close();

        }

        private void Replace(Document document, string sDirInput = "", string sDirOutput = "", string sEduName = "", string sGroupName = "", string sResultComment = "")
        {
            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string sDateTime_yyyyMMdd = DateTime.Now.ToString("yyyy-MM-dd");
            if (USERINFO.Rows.Count > 0)
            {
                document.Replace("txtDept", USERINFO.Rows[0]["FOLDER_NAME"].ToString(), false, true);  //소속(팀)
                document.Replace("txtName", USERINFO.Rows[0]["STAFF_NAME"].ToString(), false, true);  //이름
                document.Replace("txtSchool", USERINFO.Rows[0]["STAFF_SCHOOL"].ToString(), false, true); //학력
                document.Replace("txtMajor", USERINFO.Rows[0]["STAFF_MAJOR"].ToString(), false, true); //전공

                document.Replace("txtName", USERINFO.Rows[0]["STAFF_NAME"].ToString(), false, true);  //작성자
                document.Replace("txtWriteDate", sDateTime_yyyyMMdd.ToString(), false, true); //작성일자

            }
            else
            {
                document.Replace("txtDept", "", false, true);  //소속(팀)
                document.Replace("txtName", "", false, true);  //이름
                document.Replace("txtSchool", "", false, true); //학력
                document.Replace("txtMajor", "", false, true); //전공
            }

            document.Replace("txtEduName", sEduName.ToString(), false, true); //담당 시험분야의 기술정보 숙지 
            document.Replace("txtGroupName", sGroupName.ToString(), false, true); //해당분야 시험능력 ( 중분류 + 개별업무목록)
            document.Replace("txtResult", sResultComment.ToString(), false, true); //해당분야 시험능력 평가결과

            //교육사항
            if (dt_EDU1.Rows.Count > 0)
            {
                TB_EDU(dt_EDU1, document);
            }

            // 근무경력 
            if (dt_PREJOB.Rows.Count > 0)
            {
                TB_PRE_JOB(dt_PREJOB, document);
            }

            removeEmptyLine(document); //마지막 페이지 공백 제거 
            string filePath = @sDirOutput + @"\" + @Path.GetFileNameWithoutExtension(sDirInput) + "_" + Form2PQMS_StaffInfo.sStaffCode + "(" + sDateTime_yyyyMMddHHmmss + ")" + ".PDF";

            //PQMS_STAFF_ASSESSMENT_REPORT
            AssessmentReport_Final(Form2PQMS_StaffInfo.sStaffCode, filePath);


            document.SaveToFile(filePath);
            Process.Start(filePath);
            MessageBox.Show("자격부여평가 보고서 생성완료!");

            parentForm.Change_btn7_ColorChange();

            this.Close();
        }

        private void AssessmentReport_Final(string sStaffCode, string filePath)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";
            query = "insert into PQMS_STAFF_ASSESSMENT_REPORT  (STAFF_CODE, CREATE_DATE, FINAL_FILE) values  ( " +
                    "'" + sStaffCode + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "', '" + filePath + "' )";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();
        }
        private void TB_EDU(DataTable dt, Document document)
        {
            Table tb = document.Sections[0].Tables[0] as Table;
            foreach (TableRow tbr in tb.Rows)
            {
                if (tbr.Cells[0].Paragraphs[0].Text == "교육사항")
                {
                    int rowIndex = tbr.GetRowIndex() + 1;
                    TableRow targetRow;
                    TableRow copiedRow = tb.Rows[rowIndex].Clone();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            targetRow = tb.Rows[rowIndex];
                        }
                        else
                        {
                            rowIndex++;
                            targetRow = copiedRow.Clone();
                            // targetRow.Cells[1].Paragraphs[0].AppendText("inserted");
                            tb.Rows.Insert(rowIndex, targetRow);
                        }

                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            targetRow.Cells[j + 1].Paragraphs[0].AppendText(dt.Rows[i][j].ToString());
                        }
                    }
                    break;
                }
            }
        }

        private void TB_PRE_JOB(DataTable dt, Document document)
        {
            int firstdatarow = 7;
            Table tb = (Table)document.Sections[0].Tables[0];
            TableRow firstrow = tb.Rows[firstdatarow].Clone();
            TableRow tr;

            for (int o = 0; o < dt.Rows.Count; o++)
            {
                if (o == 0)
                {
                    tr = tb.Rows[firstdatarow];
                }
                else
                {
                    tr = firstrow.Clone();
                    firstdatarow++;
                    tb.Rows.Insert(firstdatarow, tr);
                }
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    TableCell tbc = tr.Cells[i + 1];
                    tbc.ChildObjects.Clear();
                    Paragraph prtext = tbc.AddParagraph();
                    prtext.AppendText(dt.Rows[o][i].ToString());
                }
            }
        }

        private void textAppend(DataTable dt, Document document, String TableName)
        {
            int firstdatarow = 0;

            foreach (Section sec in document.Sections)
            {
                foreach (Table tb in sec.Tables)
                {
                    if (tb.Title == TableName)
                    {

                        firstdatarow = tb.Rows.Count - 1;
                        TableCell trc = tb.Rows[firstdatarow].Cells[0];
                        trc.ChildObjects.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Paragraph pr = trc.AddParagraph();

                            /*
                            //스타일 먹이는 방법 1. prstyle 추가->
                            pr.ApplyStyle("kr");

                            //스타일 먹이는 방법 2.textrange 활용
                            TextRange tr = pr.AppendText(RNR.Rows[i][0].ToString());
                            tr.CharacterFormat.FontName = "";
                            tr.CharacterFormat.FontSize = 11;
                            */

                            pr.ApplyStyle("kr");
                            pr.AppendText(dt.Rows[i][0].ToString());
                        }
                        //TableRow firstrow = tb.Rows[firstdatarow].Clone(); //pr format때문에 필요함.
                        //for (int i = 0; i < RNR.Rows.Count; i++)
                        //{
                        //    TableRow tr;
                        //    if (i == 0)
                        //    {
                        //        tr = tb.Rows[firstdatarow];
                        //    }
                        //    else
                        //    {
                        //        tr = tb.AddRow(true);


                        //        //foreach (TableCell tbc in tr.Cells)
                        //        //{
                        //        //    tbc.CellFormat.Borders.Top.BorderType = tbc.CellFormat.Borders.Bottom.BorderType;
                        //        //    //첫번째 로우의 pr format(horizontalalignment,글씨체,크기등)을 다음에 오는 로우에도 유지하 기위해서 따로 첫 번째 로우의 형태를 복사
                        //        //    //이거 없으면 각 테이블 마다 pr format 하나하나 코드에 다 설정해줘야함.
                        //        //    tbc.ChildObjects.Add(firstrow.Cells[tbc.GetCellIndex()].Paragraphs[0].Clone());
                        //        //}
                        //    }
                        //    tr.Cells[0].ChildObjects.Clear();
                        //    Paragraph pr = tr.Cells[0].AddParagraph();
                        //    pr.AppendText(RNR.Rows[i][0].ToString()); ;
                        //}
                    }
                }
            }
        }
        private void textAppendWithClone(DataTable dt, Document document, String TableName)
        {
            int firstdatarow = 0;
            foreach (Section sec in document.Sections)
            {
                foreach (Table tb in sec.Tables)
                {
                    if (tb.Title == TableName)
                    {
                        firstdatarow = tb.Rows.Count - 1;
                        TableRow firstrow = tb.Rows[firstdatarow].Clone();
                        TableRow tr;
                        for (int o = 0; o < dt.Rows.Count; o++)
                        {
                            if (o == 0)
                            {
                                tr = tb.Rows[firstdatarow];
                            }
                            else
                            {
                                int rowindex = tb.Rows.Add(firstrow.Clone());
                                tr = tb.Rows[rowindex];
                            }

                            for (int i = 0; i < tr.Cells.Count; i++)
                            {
                                TableCell tbc = tr.Cells[i];
                                //tbc.ChildObjects.Clear();
                                //Paragraph pr = tbc.Paragraphs[0];
                                //pr.ApplyStyle("kr");

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

                                //pr.AppendText(dt.Rows[o][i].ToString().Replace("\r\n", ""));

                                //테이블 보더 굵기 조절 - row 안됨 cell 단위로만 된다함 ㅡㅡ
                                if (o == 0)
                                    tbc.CellFormat.Borders.Top.LineWidth = 1.5f;
                                else if (o == dt.Rows.Count - 1)
                                    tbc.CellFormat.Borders.Bottom.LineWidth = 1.5f;
                            }
                        }
                    }
                }

            }

        }

        private void removeEmptyLine(Document document)
        {
            //빈페이지 생성 방지하기 위해서 빈 라인 삭제하기

            Section sec = document.Sections[document.Sections.Count - 1];

            for (int i = sec.Body.ChildObjects.Count - 1; i > 0; i--)
            {
                if (sec.Body.ChildObjects[i].DocumentObjectType == DocumentObjectType.Paragraph)
                {
                    if (String.IsNullOrEmpty((sec.Body.ChildObjects[i] as Paragraph).Text.Trim()) || (sec.Body.ChildObjects[i] as Paragraph).Text.Trim() == "")
                    {
                        sec.Body.ChildObjects.Remove(sec.Body.ChildObjects[i]);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void btnRolePaper_Click(object sender, EventArgs e)
        {
            int iEduCnt = 0;
            string sEdu = "";

            int iRoleCnt = 0;
            string sRole = "";

            int iEachCnt = 0;
            string sEach = "";

            //교육명
            foreach (int id in PQMS_STAFF_ROLE_Assessment_TrainingGridView.GetSelectedRows())
            {
                if (sEdu != "")
                {
                    sEdu += "\r\n";
                }
                iEduCnt = +1;
                sEdu += PQMS_STAFF_ROLE_Assessment_TrainingGridView.GetRowCellValue(id, "STAFF_TRAIN_EDU").ToString(); //교육명
            }

            //중분류
            foreach (int id in PQMS_STAFF_ROLE_Assessment_GroupNameGridView.GetSelectedRows())
            {
                if (sRole != "")
                {
                    sRole += "\r\n";
                }
                iRoleCnt = +1;
                sRole += PQMS_STAFF_ROLE_Assessment_GroupNameGridView.GetRowCellValue(id, "GROUP_NAME").ToString(); //교육명
            }
            sRole = sRole.Replace("\r\n\r\n", "\r\n");


            //개별업무
            foreach (int id in PQMS_STAFF_ROLE_Assessment_EachListGridView.GetSelectedRows())
            {
                if (sEach != "")
                {
                    sEach += "\r\n";
                }
                iEachCnt = +1;
                sEach += PQMS_STAFF_ROLE_Assessment_EachListGridView.GetRowCellValue(id, "LIST_CONTENTS1").ToString(); //교육명
            }

            sEach = sEach.Replace("\r\n\r\n", "\r\n");

            if (iEduCnt <= 0)
            {
                MessageBox.Show(" 마지막 하단 그리드에서 체크박스를 선택 하세요.");
                return;
            }
            if (iRoleCnt <= 0)
            {
                MessageBox.Show(" 하단 오른쪽 그리드에서 체크박스를 선택 하세요.");
                return;
            }
            //if (iEachCnt <= 0)
            //{
            //    MessageBox.Show("하단  왼쪽 그리드에서 체크박스를 선택 하세요.");
            //    return;
            //}

            string role_each = sRole + "\r\n\r\n" + sEach;

            Document document = new Document();
            //document.LoadFromFile(txtTemplate.Text);

            document.LoadFromFile(txtTemplate.Text, Spire.Doc.FileFormat.Docx, "ANYANG"); //템플릿에 암호 설정
            document.RemoveEncryption();

            FontStyle(document);

            creatDataTable(Form2PQMS_StaffInfo.sStaffCode);

            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
            string savrfilepath = txtResultFolder.Text + @"\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "자격부여평가보고서" + @"\" + sDateTime_yyyyMM;

            DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
            if (file_di.Exists == false)
            {
                Directory.CreateDirectory(savrfilepath);
            }

            Replace(document, txtTemplate.Text, savrfilepath, sEdu, role_each, txtResultComment.Text);
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

            DataTable dt_edu = new DataTable();
            DataTable dt_group = new DataTable();
            DataTable dt_each = new DataTable();

            Conn = new OleDbConnection(unitCommon.connect_string);

            //왼쪽그리드 >> 교육리스트
            string sql = $" SELECT *,  a.STAFF_TRAIN_DATE + ' ~ '+ a.STAFF_TRAIN_DATE_TO as 'TRAIN_DATE' , " +
                $" (CASE WHEN approveStatusCode IS NULL THEN '신청전' " +
                $" WHEN approveStatusCode = '0' THEN '승인대기' " +
                $" WHEN approveStatusCode = '1' THEN '승인완료' " +
                $" ELSE '반려' " +
                $" END) AS 'approvedYN_Korea' " +
                $" FROM [PQMS_STAFF_TRAINING] as a" +                                                                                                                                                                                                          // 0714_hiel
                $" where a.STAFF_CODE = '{Form2PQMS_StaffInfo.sStaffCode}'";

            OleDbCommand cmd = new OleDbCommand(sql, Conn);
            Conn.Open();
            dt_edu.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_edu.Load(reader);
            }
            Conn.Close();

            PQMS_STAFF_ROLE_Assessment_TrainingGrid.DataSource = null;
            if (dt_edu.Rows.Count > 0)
            {
                PQMS_STAFF_ROLE_Assessment_TrainingGrid.DataSource = dt_edu;
            }

            PQMS_STAFF_ROLE_Assessment_TrainingGridView.Columns.View.FocusInvalidRow();


            //오른쪽그리드 >> 직무기술서 리스트 
            //sql = $" SELECT a.STAFF_RP_ORG_CODE, b.ORG_NAME, a.STAFF_RP_CODE, c.ROLE_NAME , a.STAFF_RP_FILE, " +
            //    $" a.STAFF_RP_CLASS	,a.STAFF_RP_CLASS_2	,a.STAFF_RP_CLASS_3	,a.STAFF_RP_CLASS_4	,a.STAFF_RP_CLASS_5,a.	STAFF_RP_CLASS_6 " +
            //    $" FROM PQMS_STAFF_ROLE_PAPER a " +
            //    $" inner join PQMS_ORG b on a.STAFF_RP_ORG_CODE = b.ORG_CODE and b.SITE_CODE='{Form1PQMS_Repo.sSiteCode}' and b.REPOSITORY_CODE='{Form1PQMS_Repo.sRepo}' and b.WS_CODE='{Form1PQMS_Repo.sWS}' " +
            //    $" inner join PQMS_ROLE2_CODE c on  c.SITE_CODE='{Form1PQMS_Repo.sSiteCode}' and c.REPOSITORY_CODE='{Form1PQMS_Repo.sRepo}' and c.WS_CODE='{Form1PQMS_Repo.sWS}'  and a.STAFF_RP_CODE = c.ROLE_CODE " +
            //    $" where a.STAFF_CODE = '{Form2PQMS_StaffInfo.sStaffCode}'";


            sql = $" SELECT a.* " +
            $" , b.ORG_NAME, a.STAFF_RP_FINAL, e.ROLE_NAME " +
            $" , d.GROUP2_CODE, COALESCE(d.GROUP2_NAME, '') AS GROUP2_NAME " +
            $" , d2.GROUP2_CODE AS GROUP2_CODE_2, COALESCE(d2.GROUP2_NAME, '') AS GROUP2_NAME_2 " +
            $" , d3.GROUP2_CODE AS GROUP2_CODE_3, COALESCE(d3.GROUP2_NAME, '') AS GROUP2_NAME_3 " +
            $" , d4.GROUP2_CODE AS GROUP2_CODE_4, COALESCE(d4.GROUP2_NAME, '') AS GROUP2_NAME_4 " +
            $" , d5.GROUP2_CODE AS GROUP2_CODE_5, COALESCE(d5.GROUP2_NAME, '') AS GROUP2_NAME_5 " +
            $" , d6.GROUP2_CODE AS GROUP2_CODE_6, COALESCE(d6.GROUP2_NAME, '') AS GROUP2_NAME_6 " +
            $" , CONCAT( c.GROUP1_NAME + ' / '," +
            $"     NULLIF(d.GROUP2_NAME, '')," +
            $"     NULLIF(', ' + d2.GROUP2_NAME, '')," +
            $"     NULLIF(', ' + d3.GROUP2_NAME, '')," +
            $"     NULLIF(', ' + d4.GROUP2_NAME, '')," +
            $"     NULLIF(', ' + d5.GROUP2_NAME, '')," +
            $"     NULLIF(', ' + d6.GROUP2_NAME, '')" +
            $" ) AS 'GROUP_NAME', x.RP_VERSION  " +
            $" FROM[PQMS_STAFF_ROLE_PAPER] AS a " +
            $" inner join PQMS_ORG b on a.STAFF_RP_ORG_CODE = b.ORG_CODE and b.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and b.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and b.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
            $" inner join PQMS_GROUP1 c on a.STAFF_RP_ORG_CODE = c.GROUP1_ORG_CODE and left(a.STAFF_RP_CLASS,4) = c.GROUP1_CODE and c.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and c.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and c.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
            $" inner join PQMS_GROUP2 d on a.STAFF_RP_ORG_CODE = d.GROUP2_ORG_CODE and c.GROUP1_CODE = d.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS,4)= d.GROUP2_CODE   and d.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
            $" left outer join PQMS_GROUP2 d2 on a.STAFF_RP_ORG_CODE = d2.GROUP2_ORG_CODE and c.GROUP1_CODE = d2.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_2,4)= d2.GROUP2_CODE   and d2.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d2.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d2.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
            $" left outer join PQMS_GROUP2 d3 on a.STAFF_RP_ORG_CODE = d3.GROUP2_ORG_CODE and c.GROUP1_CODE = d3.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_3,4)= d3.GROUP2_CODE   and d3.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d3.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d3.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
            $" left outer join PQMS_GROUP2 d4 on a.STAFF_RP_ORG_CODE = d4.GROUP2_ORG_CODE and c.GROUP1_CODE = d4.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_4,4)= d4.GROUP2_CODE   and d4.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d4.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d4.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
            $" left outer join PQMS_GROUP2 d5 on a.STAFF_RP_ORG_CODE = d5.GROUP2_ORG_CODE and c.GROUP1_CODE = d5.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_5,4)= d5.GROUP2_CODE   and d5.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d5.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d5.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
            $" left outer join PQMS_GROUP2 d6 on a.STAFF_RP_ORG_CODE = d6.GROUP2_ORG_CODE and c.GROUP1_CODE = d6.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_6,4)= d6.GROUP2_CODE   and d6.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d6.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d6.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
            $" inner join PQMS_ROLE2_CODE e on a.STAFF_RP_CODE = e.ROLE_CODE and e.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and e.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and e.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
            $" inner join PQMS_STAFF_ROLE_PAPER_VER x on a.STAFF_CODE = x.STAFF_CODE and a. STAFF_RP_ORG_CODE = x.RP_ORG_CODE and a.STAFF_RP_CODE = x.RP_CODE and a.idx = x.RP_IDX " +
            $" where a.STAFF_CODE = '{Form2PQMS_StaffInfo.sStaffCode}'";


            cmd = new OleDbCommand(sql, Conn);
            Conn.Open();
            dt_group.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_group.Load(reader);
            }
            Conn.Close();

            PQMS_STAFF_ROLE_Assessment_GroupNameGrid.DataSource = null;
            if (dt_group.Rows.Count > 0)
            {
                PQMS_STAFF_ROLE_Assessment_GroupNameGrid.DataSource = dt_group;
            }

            PQMS_STAFF_ROLE_Assessment_GroupNameGridView.Columns.View.FocusInvalidRow();


            //하단그리드 >> 개별업무목록 
            sql = $"  select LIST_CONTENTS1 , TEST_FIELD from  PQMS_STAFF_RP_EACH_LIST " +
            $" where STAFF_CODE = '{Form2PQMS_StaffInfo.sStaffCode}'";

            cmd = new OleDbCommand(sql, Conn);
            Conn.Open();
            dt_each.Reset();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_each.Load(reader);
            }
            Conn.Close();

            PQMS_STAFF_ROLE_Assessment_EachListGrid.DataSource = null;
            if (dt_each.Rows.Count > 0)
            {
                PQMS_STAFF_ROLE_Assessment_EachListGrid.DataSource = dt_each;
            }

            PQMS_STAFF_ROLE_Assessment_EachListGridView.Columns.View.FocusInvalidRow();


        }


        private void PQMS_STAFF_ROLE_Assessment_GroupNameGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.Caption.Equals("직무기술서"))
            {
                string strFile = PQMS_STAFF_ROLE_Assessment_GroupNameGridView.GetFocusedDataRow()["RP_FINAL_FILE"].ToString();
                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void PQMS_STAFF_ROLE_Assessment_GroupNameGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_RP_FILE")
            {
                //if (PQMS_ROLE2_EACH_LISTMainGridView.GetRowCellValue(e.RowHandle, "ATTACH_FILE").ToString().Trim() != "")
                if (!PQMS_STAFF_ROLE_Assessment_GroupNameGridView.GetRowCellValue(e.RowHandle, "STAFF_RP_FILE").Equals(DBNull.Value) && PQMS_STAFF_ROLE_Assessment_GroupNameGridView.GetRowCellValue(e.RowHandle, "STAFF_RP_FILE").ToString().Trim() != "")
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Cache.FillRectangle(SystemBrushes.Control, e.Bounds);
                    e.Appearance.DrawString(e.Cache, "파일열기", e.Bounds);
                    e.Handled = true;

                }
            }
        }

        private void txtResultComment_Click(object sender, EventArgs e)
        {
            txtResultComment.ForeColor = System.Drawing.SystemColors.WindowText;

            if (txtResultComment.Text == "Ex) 숙련도 결과확인, MDL/IDOC 확인 등 평가방법 기입")
            {
                txtResultComment.Text = "";
            }
        }
    }
}
