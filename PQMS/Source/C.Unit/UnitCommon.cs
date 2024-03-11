using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using Spire.Doc;
using Spire.Doc.Documents;
using System.Data.OleDb;
using System.IO;
using Spire.Pdf;
using System.Drawing;


namespace PQMS
{
    class UnitCommon
    {
        // 생성자
        public UnitCommon()
        {
            
        }
        private OleDbConnection Conn;
        public string connect_string = "Provider=SQLOLEDB.1;User ID=pqms;pwd=PQMS;data source=KRSEC001;Persist Security Info=True;initial catalog=NEW_PQMS";
        public string sFileServerName = "10.153.4.98";

        DataTable USERINFO = new DataTable();
        DataTable DOCU = new DataTable();
        DataTable DOCU2 = new DataTable();
        DataTable ADDRR = new DataTable();
        DataTable EACHLIST = new DataTable();
        DataTable dt_DATE = new DataTable();
        DataTable dt_Version = new DataTable();

        private string tmp_RP_CAREER = "";
        private string tmpstr = "";

        public bool YNFrom(string formname)
        {
            foreach (Form frm in Application.OpenForms)//열려 있는 폼 수 만큼 반복
            {
                if (frm.Name == formname)//매게변수로 받아온 이름의 폼이 열려있으면 frm리턴, 아니면 null리턴
                    return true;
            }
            return false;
        }

        private void ConverTotable(DataTable dt, Table tb)
        {
            //convert dt to tb
            int firstdatarow;

            firstdatarow = tb.Rows.Count - 1;
            tb.Rows[0].IsHeader = true;
            TableRow firstrow = tb.Rows[firstdatarow].Clone();
            TableRow tr;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (j == 0)
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
                    Paragraph pr = tbc.Paragraphs[0];
                    pr.AppendText(dt.Rows[j][i].ToString());
                }
            }
        }

        public void CreateDoc_training(string sDirInput = "", string sStaff_code = "", string sIDX = "", string sDirOutput = "" , string sEduFile="")
        {
            DataTable dt_training = new DataTable();

            Conn = new OleDbConnection(connect_string);
            
            string query = $" SELECT  a.*,  b.approveComment Coment, b.approveDate, d.firstName  " +
                $" FROM PQMS_STAFF_TRAINING a " + 
                $" left outer join PQMS_STAFF_TRAINING_APPROVE_LOG b on a.IDX = b.approveIdx and CurrentApproveDepth = 1  " +
                $" left outer join accountMaster.dbo.accountMaster c on b.approvedBy = c.userID and c.appno = 3  " +
                $" left outer join accountMaster.dbo.userMaster d on d.userID = c.userID   " +
                $" WHERE a.STAFF_CODE='{sStaff_code}' and a.IDX='{sIDX}' ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_training.Load(reader);
            }
            Conn.Close();



            if (dt_training.Rows.Count > 0)
            {
                Document document = new Document();
                string rpt = @sDirInput;
                string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                //document.LoadFromFile(rpt);

                document.LoadFromFile(rpt, Spire.Doc.FileFormat.Docx, "ANYANG"); //템플릿에 암호 설정
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
                    document.Replace("txt05", dt_training.Rows[0]["STAFF_TRAIN_DATE"].ToString()+" ~ "+ dt_training.Rows[0]["STAFF_TRAIN_DATE_TO"].ToString(), false, true);
                }

                
                document.Replace("txt06", dt_training.Rows[0]["STAFF_TRAIN_HOUR"].ToString(), false, true);
                document.Replace("txt07", dt_training.Rows[0]["STAFF_TRAIN_ATTENDEE"].ToString(), false, true);
                document.Replace("txt08", dt_training.Rows[0]["STAFF_TRAIN_GOAL"].ToString(), false, true);
                document.Replace("txt09", dt_training.Rows[0]["STAFF_TRAIN_SUMMARY"].ToString(), false, true);
                document.Replace("txt10", dt_training.Rows[0]["STAFF_TRAIN_CONTENTS"].ToString(), false, true);                
                document.Replace("txt11", dt_training.Rows[0]["STAFF_TRAIN_RESULT"].ToString(), false, true);
                // document.Replace("txt12", dt_training.Rows[0]["STAFF_TRAIN_REVIEW"].ToString(), false, true);
                //document.Replace("txt12", dt_training.Rows[0]["Coment"].ToString(), false, true);
                document.Replace("txt13", dt_training.Rows[0]["STAFF_TRAIN_WRITER"].ToString() + "/" + dt_training.Rows[0]["STAFF_TRAIN_WRITE_DATE"].ToString(), false, true);
                document.Replace("txt14", dt_training.Rows[0]["STAFF_TRAIN_REVIEWER"].ToString() + "/" + dt_training.Rows[0]["STAFF_TRAIN_REVIEW_DATE"].ToString(), false, true);
                //document.Replace("txt15", dt_training.Rows[0]["STAFF_TRAIN_APPROVER"].ToString() + "/" + dt_training.Rows[0]["STAFF_TRAIN_APPROVAL_DATE"].ToString(), false, true);


                //승인완료 시점에 데이트 입력을 위해 주석 
                //if (DBNull.Value.Equals(dt_training.Rows[0]["approveDate"]) == true)
                //{
                //    document.Replace("txt15", dt_training.Rows[0]["FirstName"].ToString() + "/" , false, true);
                //}
                //else
                //{
                //    document.Replace("txt15", dt_training.Rows[0]["FirstName"].ToString() + "/" + dt_training.Rows[0]["approveDate"].ToString().Substring(0, 10), false, true);
                //}

                string final_file = @sDirOutput + @"\" + @Path.GetFileNameWithoutExtension(sDirInput) + "_" + sDateTime_yyyyMMddHHmmss + ".pdf";

                document.SaveToFile(final_file);

                if (sEduFile != "" && Path.GetExtension(sEduFile).ToString().ToUpper() == ".PDF") // 훈련 증빙이 있고 증빙파일이 PDF 형식이면  교육훈련 보고서에 추가 
                {
                    
                    //pdf파일이 증빙에 있으면 두개의 파일 합치기 ..
                    String[] files = new String[] { final_file, sEduFile };
                    string outputFile = final_file;
                    PdfDocumentBase doc = PdfDocument.MergeFiles(files);
                    doc.Save(outputFile, Spire.Pdf.FileFormat.PDF);

                    Process.Start(outputFile);
                }
                else
                {
                    Process.Start(final_file);
                }
                

               // Process.Start(final_file);

                query = "update PQMS_STAFF_TRAINING set " +
                       $" STAFF_TRAIN_REPORT_FILE = N'" + final_file + "' " +
                       $" where  STAFF_CODE='{sStaff_code}' and IDX='{sIDX}' ";
                cmd = new OleDbCommand(query, Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            else
            {
                MessageBox.Show("INVALID STAFFCODE");
            }
        }

        public int CreateDoc_EachListHistory(string sDirInput = "", string sStaff_code = "", string sIDX = "", string sDirOutput = "", string sRoleName="", string sOrderby="")
        {
            int i_return = 0;
            Document document = new Document();
            string rpt = @sDirInput;
            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //document.LoadFromFile(rpt);


            document.LoadFromFile(rpt, Spire.Doc.FileFormat.Docx, "ANYANG"); //템플릿에 암호 설정
            document.RemoveEncryption();

            DataTable dt_Staff = new DataTable();
            Conn = new OleDbConnection(connect_string);
            string query_staff = "select * " +
                " FROM [PQMS_STAFF] AS a " +
                $"WHERE a.STAFF_CODE='{sStaff_code}' ";

            OleDbCommand cmd = new OleDbCommand(query_staff, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_Staff.Load(reader);
            }
            Conn.Close();

            if (dt_Staff.Rows.Count > 0)
            {
                document.Replace("txt01", dt_Staff.Rows[0]["STAFF_NAME"].ToString(), false, true);
                //document.Replace("txt02", sRoleName , false, true); //피평가자 직무
            }           

            //if (sOrderby == "업무진행일")
            //{
            //    sOrderby = "Order by a.LIST_WORKDATE";
            //}
            //else
            //{
            //    sOrderby = "Order by a.LIST_NO";
            //}

            sOrderby = "Order by a.LIST_WORKDATE";

            DataTable dt_eachlistHis = new DataTable();
            string query = $" SELECT a.LIST_WORKDATE, a.LIST_CONTENTS1, a.LIST_METHODS, a.LIST_RESULT, a.LIST_CHANGE,  d.STAFF_NAME ,a.LIST_REMARK " +
                $" FROM PQMS_STAFF_RP_EACH_LIST a " +
                $" LEFT OUTER JOIN PQMS_STAFF_RP_EACH_LIST_APPROVE_LOG b on a.idx = b.approveIdx and b.CurrentApproveDepth = 1 " +
                $" LEFT OUTER JOIN [accountMaster].dbo.accountmaster  c on b.approvedBy = c.userID and c.appID='PQMS' " +
                $" LEFT OUTER JOIN PQMS_STAFF d on c.accountNo = d.ACCOUNT_NO " +
                $" WHERE a.STAFF_CODE='{sStaff_code}' and  EACHLIST_PAPER = 'Y' " + sOrderby; // 직무기술서 체크 해제된 내용만 들어가야함. //선택된 정렬 순으로 정렬 될 수 있게 수정 

            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_eachlistHis.Load(reader);
            }
            Conn.Close();

            int cnt = dt_eachlistHis.Rows.Count;
            if (cnt > 0)
            {
                Table tb = (Table)document.Sections[0].Tables[0];
                //TableRow imgrow = tb.Rows[1].Clone();

                //Row Data tb Insert 
                ConverTotable(dt_eachlistHis, tb);

                string final_file = @sDirOutput + @"\" + @Path.GetFileNameWithoutExtension(sDirInput) + "_" + sDateTime_yyyyMMddHHmmss + ".pdf";
                               
                //string query_insert = " INSERT INTO PQMS_STAFF_RP_EACH_LIST_FOLDER (STAFF_CODE, FILE_PATH ) Values (  " +
                //                        $" '{sStaff_code}', '{final_file}' )";

                //cmd = new OleDbCommand(query_insert, Conn);
                //Conn.Open();
                //cmd.ExecuteNonQuery();
                //Conn.Close();

                document.SaveToFile(final_file);
                Process.Start(final_file);



                //생성되어 있는 파일이 있으면 삭제 후 재생성 DB도 업데이트 처리                 
                DataTable dt_file = new DataTable();
                string file_query = $" SELECT * FROM PQMS_STAFF_RP_EACH_LIST_FOLDER " +
                            $" WHERE STAFF_CODE='{sStaff_code}' ";
                cmd = new OleDbCommand(file_query, Conn);
                Conn.Open();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    dt_file.Load(reader);
                }
                Conn.Close();

                if (dt_file.Rows.Count == 1) //파일 있으니 업데이트 
                {
                    //서버에서 파일 삭제 
                    if (File.Exists(dt_file.Rows[0]["FILE_PATH"].ToString()))
                    {
                        File.Delete(dt_file.Rows[0]["FILE_PATH"].ToString());
                    }

                    string query_Update = " UPDATE PQMS_STAFF_RP_EACH_LIST_FOLDER SET FILE_PATH = '" + final_file + "'" +
                                          $" WHERE STAFF_CODE='{sStaff_code}' ";

                    cmd = new OleDbCommand(query_Update, Conn);
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();

                }
                else // 파일 없으니 인서트 
                {
                    string query_insert = " INSERT INTO PQMS_STAFF_RP_EACH_LIST_FOLDER (STAFF_CODE, FILE_PATH ) Values (  " +
                                    $" '{ sStaff_code}', '{final_file}' )";

                    cmd = new OleDbCommand(query_insert, Conn);
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                }
            }
            else
            {
                i_return = 1; //오류
                MessageBox.Show("INVALID STAFFCODE");
            }
            return i_return;
        }

        public int CreateDoc_trainingFolder(string sDirInput = "", string sStaff_code = "", string sIDX = "", string sDirOutput = "", string sRoleName = "", string sApproverName = "", string sRoleCode = "")
        {
            int i_return = 0;

            Document document = new Document();
            string rpt = @sDirInput;
            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //document.LoadFromFile(rpt);

            document.LoadFromFile(rpt, Spire.Doc.FileFormat.Docx, "ANYANG"); //템플릿에 암호 설정
            document.RemoveEncryption();

            DataTable dt_Staff = new DataTable();
            Conn = new OleDbConnection(connect_string);
            string query_staff = " select a.STAFF_NAME, b.FOLDER_NAME  " +
                                 " FROM [PQMS_STAFF] a " +
                                 " INNER JOIN [K_WORKSPACE] b on a.SITE_CODE = b.SITE_CODE and a.REPOSITORY_CODE = b.REPOSITORY_CODE and a.WS_CODE = b.WS_CODE and SUBSTRING(a.STAFF_TEAM, 17,5) = b.FOLDER_CODE  and isnull(b.BOARD_CODE,'') =''" +
                                $" WHERE STAFF_CODE='{sStaff_code}' ";

            OleDbCommand cmd = new OleDbCommand(query_staff, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_Staff.Load(reader);
            }
            Conn.Close();

            if (dt_Staff.Rows.Count > 0)
            {
                document.Replace("txt01", dt_Staff.Rows[0]["STAFF_NAME"].ToString(), false, true); //직무자명
                document.Replace("txt02", dt_Staff.Rows[0]["FOLDER_NAME"].ToString(), false, true); //소속실험실                
                document.Replace("txt03", sRoleName, false, true); //직무명
                document.Replace("txt04", sApproverName, false, true); //상급보고자
            }

            DataTable dt_trainingHis = new DataTable();
            //string query = $" select substring(a.RP_CREATE_DATE,1, 10) 'CREATEDATE', 'V'+a.RP_VERSION+'.0' as 'VERSION', a.RP_REASON , c.firstName + ' / '+  substring(b.approveDate,1,10) 'APPROVE' " +
            //    $" from PQMS_STAFF_ROLE_PAPER_FINAL a " +
            //    $" left outer join PQMS_STAFF_ROLE_PAPER_FINAL_APPROVE_LOG b on a.idx = b.approveIdx and b.FinalApproveDepth=2" +
            //    $" left outer join accountMaster.dbo.userMaster c on b.approvedBy = c.userID " +
            //    $" WHERE STAFF_CODE='{sStaff_code}' ";

            string query = $"select substring(a.STAFF_RP_WRITE_DATE,1, 10) 'CREATEDATE' " +
            $" , 'V.' + convert(char(5), e.RP_VERSION) as 'VERSION' " +
            $" , a.STAFF_RP_REASON  RP_REASON " +
            $" , c.firstName + ' / ' + substring(b.approveDate, 1, 10) 'APPROVE' " +
            $" from PQMS_STAFF_ROLE_PAPER a " +
            $" inner join PQMS_STAFF_ROLE_PAPER_VER e on a.STAFF_CODE = e.STAFF_CODE and a.STAFF_RP_ORG_CODE = e.RP_ORG_CODE and a.STAFF_RP_CODE = e.RP_CODE and a.IDX = e.RP_IDX  " +
            $" left outer join PQMS_STAFF_ROLE_PAPER_APPROVE_LOG b on a.idx = b.approveIdx and b.FinalApproveDepth = 2 " +
            $" left outer join accountMaster.dbo.userMaster c on b.approvedBy = c.userID " +
            $" WHERE a.STAFF_CODE = '{sStaff_code}' and a.STAFF_RP_CODE ='{sRoleCode}' " +
            $" order by e.RP_VERSION ";
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_trainingHis.Load(reader);
            }
            Conn.Close();
            int cnt = dt_trainingHis.Rows.Count;

            if (cnt > 0)
            {
                Table tb = (Table)document.Sections[0].Tables[0];
                //TableRow imgrow = tb.Rows[1].Clone();

                //Row Data tb Insert 
                ConverTotable(dt_trainingHis, tb);

                string final_file = @sDirOutput + @"\" + @Path.GetFileNameWithoutExtension(sDirInput) + "_" + sDateTime_yyyyMMddHHmmss + ".pdf";

                string query_insert = " INSERT INTO PQMS_STAFF_ROLEPAPER_TRANING_FOLDER (STAFF_CODE, ROLE_CODE,RP_APPROVER_NAME, FILE_PATH ) Values (  " +
                                        $" '{ sStaff_code}', '{sRoleCode}', '{sApproverName}', '{final_file}' )";

                cmd = new OleDbCommand(query_insert, Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();
                Conn.Close();

                document.SaveToFile(final_file);     
                Process.Start(final_file);     
            }
            else
            {
                //MessageBox.Show("INVALID STAFFCODE");
                i_return = 1; //오류
                MessageBox.Show("생성된 직무기술서 없음.");                
            }
            return i_return;
        }


        public int CreateDoc_trainingHistory(string sDirInput = "", string sStaff_code = "", string sIDX = "", string sDirOutput = "", string sRoleName = "")
        {
            int i_return = 0;
            Document document = new Document();
            string rpt = @sDirInput;
            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //document.LoadFromFile(rpt);

            document.LoadFromFile(rpt, Spire.Doc.FileFormat.Docx, "ANYANG"); //템플릿에 암호 설정
            document.RemoveEncryption();

            DataTable dt_Staff = new DataTable();
            Conn = new OleDbConnection(connect_string);
            
            string query_staff = " select a.STAFF_NAME,a.STAFF_JOIN_DATE,  b.FOLDER_NAME  " +
                                 " FROM [PQMS_STAFF] a " +
                                 " INNER JOIN [K_WORKSPACE] b on a.SITE_CODE = b.SITE_CODE and a.REPOSITORY_CODE = b.REPOSITORY_CODE and a.WS_CODE = b.WS_CODE and SUBSTRING(a.STAFF_TEAM, 17,5) = b.FOLDER_CODE " +
                                $" WHERE STAFF_CODE='{sStaff_code}' ";


            OleDbCommand cmd = new OleDbCommand(query_staff, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_Staff.Load(reader);
            }
            Conn.Close();

            if (dt_Staff.Rows.Count > 0)
            {
                document.Replace("txt01", dt_Staff.Rows[0]["STAFF_NAME"].ToString(), false, true); 
                document.Replace("txt02", dt_Staff.Rows[0]["FOLDER_NAME"].ToString(), false, true); //소속실험실
                document.Replace("txt03", sRoleName, false, true); 
                document.Replace("txt04", dt_Staff.Rows[0]["STAFF_JOIN_DATE"].ToString(), false, true); //입사일
            }

            DataTable dt_trainingHis = new DataTable();
            string query = $" SELECT STAFF_TRAIN_GUBUN, STAFF_TRAIN_EDU, STAFF_TRAIN_ORG+'/'+STAFF_TRAIN_TRAINER STAFF_TRAIN_ORF_TRAINER, STAFF_TRAIN_DATE  , '' , '' " +
                           $" FROM PQMS_STAFF_TRAINING " +
                           $" WHERE STAFF_CODE='{sStaff_code}' "; 
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_trainingHis.Load(reader);
            }
            Conn.Close();

            int cnt = dt_trainingHis.Rows.Count;

            if (cnt > 0)
            {
                Table tb = (Table)document.Sections[0].Tables[0];
                //TableRow imgrow = tb.Rows[1].Clone();

                //Row Data tb Insert 
                ConverTotable(dt_trainingHis, tb);
                string final_file = @sDirOutput + @"\" + @Path.GetFileNameWithoutExtension(sDirInput) + "_" + sDateTime_yyyyMMddHHmmss + ".pdf";

                document.SaveToFile(final_file);
                Process.Start(final_file);

                //생성되어 있는 파일이 있으면 삭제 .. 후 DB도 업데이트 
                DataTable dt_file = new DataTable();
                string file_query = $" SELECT * FROM PQMS_STAFF_TRAINING_HISTORY_FOLDER " +                            
                            $" WHERE STAFF_CODE='{sStaff_code}' ";
                cmd = new OleDbCommand(file_query, Conn);
                Conn.Open();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    dt_file.Load(reader);
                }
                Conn.Close();
                if (dt_file.Rows.Count == 1) //파일 있으니 업데이트 
                {
                    //서버에서 파일 삭제 
                    if (File.Exists(dt_file.Rows[0]["FILE_PATH"].ToString()))
                    {
                        File.Delete(dt_file.Rows[0]["FILE_PATH"].ToString());
                    }

                    string query_Update = " UPDATE PQMS_STAFF_TRAINING_HISTORY_FOLDER SET FILE_PATH = '" + final_file + "'" +
                                          $" WHERE STAFF_CODE='{sStaff_code}' ";

                    cmd = new OleDbCommand(query_Update, Conn);
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                }
                else // 파일 없으니 인서트 
                {
                    string query_insert = " INSERT INTO PQMS_STAFF_TRAINING_HISTORY_FOLDER (STAFF_CODE, FILE_PATH ) Values (  " +
                                    $" '{ sStaff_code}', '{final_file}' )";

                    cmd = new OleDbCommand(query_insert, Conn);
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                }        
            }
            else
            {
                i_return = 1; //오류
                MessageBox.Show("INVALID STAFFCODE");
            }
            return i_return;
        }

        public void CreateDoc_Role(string sDirInput = "", string sStaff_code = "", string sDirOutput = "", string r_IDX = "", string r_CODE = "", string r_org_code="")
        {
            DataTable USERINFO = new DataTable();
            Conn = new OleDbConnection(connect_string);
            string query = $" select b.STAFF_NAME, b.STAFF_EMPNO, a.STAFF_ROLE_NAME , a.STAFF_ROLE_DATE, c.FOLDER_NAME, " +
                            $" f.GROUP2_CODE,                  COALESCE(f.GROUP2_NAME, '') AS GROUP2_NAME,      " +
                            $" d2.GROUP2_CODE AS GROUP2_CODE_2, COALESCE(d2.GROUP2_NAME, '') AS GROUP2_NAME_2,  " +
                            $" d3.GROUP2_CODE AS GROUP2_CODE_3, COALESCE(d3.GROUP2_NAME, '') AS GROUP2_NAME_3,  " +
                            $" d4.GROUP2_CODE AS GROUP2_CODE_4, COALESCE(d4.GROUP2_NAME, '') AS GROUP2_NAME_4,  " +
                            $" d5.GROUP2_CODE AS GROUP2_CODE_5, COALESCE(d5.GROUP2_NAME, '') AS GROUP2_NAME_5,  " +
                            $" d6.GROUP2_CODE AS GROUP2_CODE_6, COALESCE(d6.GROUP2_NAME, '') AS GROUP2_NAME_6,  " +
                            $" CONCAT( g.GROUP1_NAME + ' / ', NULLIF(f.GROUP2_NAME, ''), NULLIF(', ' + d2.GROUP2_NAME, ''), NULLIF(', ' + d3.GROUP2_NAME, ''), NULLIF(', ' + d4.GROUP2_NAME, ''), NULLIF(', ' + d5.GROUP2_NAME, ''), NULLIF(', ' + d6.GROUP2_NAME, '') ) AS 'GROUP_NAME'" +
                            $" from[PQMS_STAFF_ROLE] a" +
                            $" inner join PQMS_STAFF b on a.STAFF_CODE = b.STAFF_CODE" +
                            $" inner join K_WORKSPACE c on b.STAFF_TEAM = c.SITE_CODE + '-' + c.REPOSITORY_CODE + '-' + c.WS_CODE + '-' + c.FOLDER_CODE  and isnull(c.BOARD_CODE, '') = ''" +
                            $" INNER JOIN[PQMS_GROUP1] AS g  ON a.STAFF_ROLE_ORG_CODE = g.GROUP1_ORG_CODE and left(a.STAFF_ROLE_CLASS,4) = g.GROUP1_CODE " +
                            $" INNER JOIN[PQMS_GROUP2] AS F  on(F.GROUP2_GROUP1_CODE + '-' + F.GROUP2_CODE) = a.STAFF_ROLE_CLASS and f.[GROUP2_ORG_CODE] = a.STAFF_ROLE_ORG_CODE " +
                            $" left outer join PQMS_GROUP2 d2 on a.STAFF_ROLE_ORG_CODE = d2.GROUP2_ORG_CODE and g.GROUP1_CODE = d2.GROUP2_GROUP1_CODE and right(a.STAFF_ROLE_CLASS_2,4)= d2.GROUP2_CODE " +
                            $" left outer join PQMS_GROUP2 d3 on a.STAFF_ROLE_ORG_CODE = d3.GROUP2_ORG_CODE and g.GROUP1_CODE = d3.GROUP2_GROUP1_CODE and right(a.STAFF_ROLE_CLASS_3,4)= d3.GROUP2_CODE " +
                            $" left outer join PQMS_GROUP2 d4 on a.STAFF_ROLE_ORG_CODE = d4.GROUP2_ORG_CODE and g.GROUP1_CODE = d4.GROUP2_GROUP1_CODE and right(a.STAFF_ROLE_CLASS_4,4)= d4.GROUP2_CODE " +
                            $" left outer join PQMS_GROUP2 d5 on a.STAFF_ROLE_ORG_CODE = d5.GROUP2_ORG_CODE and g.GROUP1_CODE = d5.GROUP2_GROUP1_CODE and right(a.STAFF_ROLE_CLASS_5,4)= d5.GROUP2_CODE " +
                            $" left outer join PQMS_GROUP2 d6 on a.STAFF_ROLE_ORG_CODE = d6.GROUP2_ORG_CODE and g.GROUP1_CODE = d6.GROUP2_GROUP1_CODE and right(a.STAFF_ROLE_CLASS_6,4)= d6.GROUP2_CODE " +
                            $" WHERE a.STAFF_CODE='{sStaff_code}' and a.IDX = '{r_IDX}'";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                USERINFO.Load(reader);
            }
            Conn.Close();

            if (USERINFO.Rows.Count > 0)
            {
                Document document = new Document();                
                string rpt = sDirInput;
                
                document.LoadFromFile(rpt, Spire.Doc.FileFormat.Docx, "ANYANG"); //템플릿에 암호 설정
                document.RemoveEncryption();

                FontStyle(document);

                //CONFIG파일 없이 프로그램에 작성. //jhm
                document.Replace("txt01", USERINFO.Rows[0]["STAFF_NAME"].ToString(), false, true);
                document.Replace("txt02", USERINFO.Rows[0]["FOLDER_NAME"].ToString(), false, true);
                document.Replace("txt03", USERINFO.Rows[0]["STAFF_EMPNO"].ToString(), false, true);
                document.Replace("txt04", USERINFO.Rows[0]["STAFF_ROLE_DATE"].ToString(), false, true);
                document.Replace("txt05", USERINFO.Rows[0]["GROUP_NAME"].ToString(), false, true);                
                document.Replace("txt08", USERINFO.Rows[0]["STAFF_ROLE_NAME"].ToString(), false, true);

                //document.Replace("txt09", APPINFO.Rows[0]["STAFF_POSITION"].ToString(), false, true); //직책
                //document.Replace("txt10", APPINFO.Rows[0]["STAFF_NAME"].ToString(), false, true);

                string final_file = @sDirOutput + @"\" + @Path.GetFileNameWithoutExtension(sDirInput) + "_" + sStaff_code + "(" + r_IDX + ")" + ".pdf";
                //PR_Final(filePath, sRPCode);

                MessageBox.Show("임명장 발행완료!");
                document.SaveToFile(final_file);
                Conn = new OleDbConnection(connect_string);
                query = "update PQMS_STAFF_ROLE set " +
                          $" STAFF_ROLE_FILE = N'" + final_file + "' " +
                          $" where  STAFF_CODE='{sStaff_code}' and IDX='{r_IDX}' ";
                cmd = new OleDbCommand(query, Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();
                Conn.Close();

                Process.Start(final_file);

            }
        }



        public void CreateDoc_RP(string sDirInput = "", string sStaff_code = "", string sDirOutput = "", string rp_IDX = "", string rp_RP_CODE = "", string each_IDX="", string tr_IDX="", string sorg_CODE = "", string s_Group2_Name_Final="")
        {
            
            Document document = new Document();

            document.LoadFromFile(sDirInput, Spire.Doc.FileFormat.Docx, "ANYANG"); //템플릿에 암호 설정
            document.RemoveEncryption();

            FontStyle(document);


            // creatDataTable_Anyang(Form2PQMS_StaffInfo.sStaffCode, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX);
            creatDataTable_Anyang(sStaff_code, rp_IDX, rp_RP_CODE, each_IDX, tr_IDX, sorg_CODE);

     
            DirectoryInfo file_di = new DirectoryInfo(sDirOutput);
            if (file_di.Exists == false)
            {
                Directory.CreateDirectory(sDirOutput);
            }

            Replace_Anyang(document, sDirInput, sDirOutput, rp_RP_CODE, sorg_CODE, sStaff_code, rp_IDX, s_Group2_Name_Final);           
        }

        //private DataTable RP_Version_Check(string s_STAFF_CODE, string s_ORG_CODE,  string s_RP_CODE)
        //{
        //    DataTable resultTable = new DataTable();
        //    try
        //    {
        //        using (OleDbConnection connection = new OleDbConnection(connect_string))
        //        {
        //            connection.Open();

        //            // Check if the record exists
        //            string selectQuery = "SELECT COUNT(*) FROM PQMS_STAFF_ROLE_PAPER_VER WHERE STAFF_CODE = @StaffCode AND RP_ORG_CODE = @ORGCode AND RP_CODE = @RpCode";
        //            using (OleDbCommand selectCommand = new OleDbCommand(selectQuery, connection))
        //            {
        //                selectCommand.Parameters.AddWithValue("@StaffCode", s_STAFF_CODE);
        //                selectCommand.Parameters.AddWithValue("@ORGCode", s_ORG_CODE);
        //                selectCommand.Parameters.AddWithValue("@RpCode", s_RP_CODE);

        //                int recordCount = (int)selectCommand.ExecuteScalar();

        //                if (recordCount == 0)
        //                {
        //                    // If record doesn't exist, insert a new one
        //                    string insertQuery = "INSERT INTO PQMS_STAFF_ROLE_PAPER_VER (STAFF_CODE,RP_ORG_CODE, RP_CODE, RP_VERSION, RP_DATE) VALUES (@StaffCode,@ORGCode, @RpCode, 1, FORMAT(GETDATE(), 'yyyy-MM-dd') )";
        //                    using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection))
        //                    {
        //                        insertCommand.Parameters.AddWithValue("@StaffCode", s_STAFF_CODE);
        //                        selectCommand.Parameters.AddWithValue("@ORGCode", s_ORG_CODE);
        //                        insertCommand.Parameters.AddWithValue("@RpCode", s_RP_CODE);

        //                        insertCommand.ExecuteNonQuery();
        //                    }
        //                }
        //                else
        //                {
        //                    // If record exists, update RP_VERSION to 1 if it is null
        //                    string updateQuery = "UPDATE PQMS_STAFF_ROLE_PAPER_VER SET RP_VERSION = IIF(RP_VERSION IS NULL, 1, RP_VERSION), RP_UP_DATE= FORMAT(GETDATE(), 'yyyy-MM-dd')  WHERE STAFF_CODE = @StaffCode  AND RP_ORG_CODE = @ORGCode AND RP_CODE = @RpCode";
        //                    using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection))
        //                    {
        //                        updateCommand.Parameters.AddWithValue("@StaffCode", s_STAFF_CODE);
        //                        selectCommand.Parameters.AddWithValue("@ORGCode", s_ORG_CODE);
        //                        updateCommand.Parameters.AddWithValue("@RpCode", s_RP_CODE);

        //                        updateCommand.ExecuteNonQuery();
        //                    }
        //                }                     
        //            }

        //            string selectAfterUpdateQuery = "SELECT MAX(RP_CODE) FROM PQMS_STAFF_ROLE_PAPER_VER WHERE STAFF_CODE = @StaffCode AND RP_ORG_CODE = @ORGCode AND RP_CODE = @RpCode";
        //            using (OleDbCommand selectAfterUpdateCommand = new OleDbCommand(selectAfterUpdateQuery, connection))
        //            {
        //                selectAfterUpdateCommand.Parameters.AddWithValue("@StaffCode", s_STAFF_CODE);
        //                selectAfterUpdateCommand.Parameters.AddWithValue("@ORGCode", s_ORG_CODE);
        //                selectAfterUpdateCommand.Parameters.AddWithValue("@RpCode", s_RP_CODE);

        //                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectAfterUpdateCommand))
        //                {
        //                    adapter.Fill(resultTable);
        //                }
        //            }
        //        }                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}");
        //    }

        //    return resultTable;
        //}

        private DataTable RP_Version_Check(string s_STAFF_CODE, string s_sidx,  string s_ORG_CODE, string s_RP_CODE)
        {
            DataTable resultTable = new DataTable();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connect_string))
                {
                    connection.Open();

                    // Check if the record exists
                    DataTable dt = new DataTable();
                    string selectQuery = "SELECT MAX(RP_VERSION) FROM PQMS_STAFF_ROLE_PAPER_VER WHERE STAFF_CODE = '" + s_STAFF_CODE + "' AND RP_ORG_CODE = '"+ s_ORG_CODE + "' AND RP_CODE = '"+ s_RP_CODE + "'";
                    using (OleDbCommand selectCommand = new OleDbCommand(selectQuery, connection))
                    {
                        using (OleDbDataReader reader = selectCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }                       
                        if (dt.Rows[0][0] == DBNull.Value || Convert.ToInt32(dt.Rows[0][0].ToString()) < 1) 
                        {
                            // If record doesn't exist, insert a new one
                            string insertQuery = "INSERT INTO PQMS_STAFF_ROLE_PAPER_VER (STAFF_CODE, RP_ORG_CODE, RP_CODE, RP_VERSION, RP_DATE, RP_IDX) VALUES ( '" + s_STAFF_CODE + "' , '" + s_ORG_CODE + "',  '" + s_RP_CODE + "', 1, FORMAT(GETDATE(), 'yyyy-MM-dd'), '"+ s_sidx + "')";
                            using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection))
                            {
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            int rp_verion = Convert.ToInt32(dt.Rows[0][0].ToString())  + 1 ;

                            // If record exists, update RP_VERSION to 1 if it is null
                            string updateQuery = "INSERT INTO PQMS_STAFF_ROLE_PAPER_VER (STAFF_CODE, RP_ORG_CODE, RP_CODE, RP_VERSION, RP_DATE, RP_IDX) VALUES ( '" + s_STAFF_CODE + "' , '" + s_ORG_CODE + "',  '" + s_RP_CODE + "', "+ rp_verion + ", FORMAT(GETDATE(), 'yyyy-MM-dd'), '" + s_sidx + "')";
                            using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection))
                            {  
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    
                    string selectAfterUpdateQuery = "SELECT MAX(RP_VERSION) RP_VERSION FROM PQMS_STAFF_ROLE_PAPER_VER WHERE STAFF_CODE = '" + s_STAFF_CODE + "' AND RP_ORG_CODE = '" + s_ORG_CODE + "' AND RP_CODE = '" + s_RP_CODE + "'";
                    using (OleDbCommand selectCommand2 = new OleDbCommand(selectAfterUpdateQuery, connection))
                    {
                        using (OleDbDataReader reader = selectCommand2.ExecuteReader())
                        {
                            resultTable.Load(reader);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return resultTable;
        }

        private void creatDataTable_Anyang(string sStaffCode = "", string sidx = "", string sRPCode = "", string sEACHIDX = "", string sTRIDX = "", string sORGCode="")
        {                        
            //1.인적사항)
            Conn = new OleDbConnection(connect_string);
            string query = "";

            query = " select t1.STAFF_NAME, t1.STAFF_JOIN_DATE, t1.STAFF_SCHOOL, t1.STAFF_MAJOR, t2.STAFF_RP_SUPPORTER , t2.STAFF_RP_APPROVER, t1.STAFF_TEAM, x.FOLDER_NAME , y.ROLE_VERSION, y.ROLE_NAME" +
                    " ,t2.STAFF_RP_FRISTDATE ,t2.STAFF_RP_CAREER	,t2.STAFF_RP_REASON " +
                    " from[dbo].[PQMS_STAFF] as t1 with(nolock) " +
                    " inner join PQMS_STAFF_ROLE_PAPER as t2 with(nolock)  on t1.STAFF_CODE = t2.STAFF_CODE " +
                    " inner join K_WORKSPACE x on x.SITE_CODE + '-' + x.REPOSITORY_CODE + '-' + x.WS_CODE + '-' + x.FOLDER_CODE = t1.STAFF_TEAM and isnull(BOARD_CODE,'') ='' " +
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
            //query = " select isnull(MAX(RP_VERSION),0) +1 'Version'  from PQMS_STAFF_ROLE_PAPER_FINAL where STAFF_CODE = '" + sStaffCode + "' and rp_org_code = '" + sORGCode + "' and RP_CODE= '" + sRPCode + "'";
            //query = " select isnull(MAX(RP_VERSION),0) +1 'Version'  from PQMS_STAFF_ROLE_PAPER where STAFF_CODE = '" + sStaffCode + "' and RP_CODE= '" + sRPCode + "'";
            //Conn = new OleDbConnection(connect_string);
            //cmd = new OleDbCommand(query, Conn);
            //Conn.Open();
            //dt_Version.Reset();
            //using (OleDbDataReader reader = cmd.ExecuteReader())
            //{
            //    dt_Version.Load(reader);
            //}
            //Conn.Close();
            dt_Version = RP_Version_Check(sStaffCode, sidx, sORGCode, sRPCode);



            // 2.주요직무에대한 책임과 역할
            Conn = new OleDbConnection(connect_string);
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
            Conn = new OleDbConnection(connect_string);
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

            if (sTRIDX == "")
            {
                sTRIDX = "0";
            }
           
            //3.업무수행에필요한 교육훈련 테이블
            Conn = new OleDbConnection(connect_string);
            query = " SELECT STAFF_TRAIN_EDU , STAFF_TRAIN_DATE +'~'+STAFF_TRAIN_DATE_TO , STAFF_TRAIN_ORG FROM PQMS_STAFF_TRAINING " +
                    $" where STAFF_CODE = '{sStaffCode}' and IDX in  ( " + sTRIDX + ")  " +
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
            Conn = new OleDbConnection(connect_string);
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
            Conn = new OleDbConnection(connect_string);
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

        private void Replace_Anyang(Document document, string sDirInput = "", string sDirOutput = "", string sRPCode = "", string sORGCode="", string sStaff_code="", string rp_IDX="", string s_Group2_Name_Final="")
        {
            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            if (USERINFO.Rows.Count > 0)
            {
                document.Replace("txt01", USERINFO.Rows[0]["FOLDER_NAME"].ToString(), false, true);  //소속(팀)
                document.Replace("txt02", USERINFO.Rows[0]["STAFF_JOIN_DATE"].ToString(), false, true);  //입사년월
                document.Replace("txt03", USERINFO.Rows[0]["STAFF_NAME"].ToString(), false, true); //이름
                document.Replace("txt04", USERINFO.Rows[0]["STAFF_SCHOOL"].ToString() + "/" + USERINFO.Rows[0]["STAFF_MAJOR"].ToString(), false, true); //학력/전공
                document.Replace("txt05", USERINFO.Rows[0]["STAFF_RP_SUPPORTER"].ToString(), false, true); //대리인
                document.Replace("txt06", USERINFO.Rows[0]["STAFF_RP_APPROVER"].ToString(), false, true); //승인자                
                document.Replace("txt08", USERINFO.Rows[0]["ROLE_NAME"].ToString(), false, true); //담당역할
                document.Replace("txt09", USERINFO.Rows[0]["STAFF_RP_CAREER"].ToString(), false, true); //주요경력                
                //document.Replace("txt09", tmp_RP_CAREER, false, true); //주요경력                
                document.Replace("txt11", USERINFO.Rows[0]["STAFF_RP_FRISTDATE"].ToString(), false, true); //최초자격인증일                
                document.Replace("txt10", s_Group2_Name_Final, false, true); //자격분야

            }

            //버전 
            if (dt_Version.Rows.Count > 0)
            {
                document.Replace("txt07", "V" + dt_Version.Rows[0]["RP_VERSION"].ToString() + ".0", false, true); //버전
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
                document.Replace("TxtWriteDate", dt_DATE.Rows[0]["STAFF_RP_WRITER"].ToString() + "/" + dt_DATE.Rows[0]["STAFF_RP_DATE"].ToString(), false, true);


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

            string final_file = @sDirOutput + @"\" + @Path.GetFileNameWithoutExtension(sDirInput) + "_" + sStaff_code + "(" + rp_IDX + ")" + ".pdf";
            //PR_Final(filePath, sRPCode);

            MessageBox.Show("직무기술서 발행완료!");
            document.SaveToFile(final_file);
            Conn = new OleDbConnection(connect_string);
            string query = "update PQMS_STAFF_ROLE_PAPER set " +
                      $" STAFF_RP_FILE = N'" + final_file + "' " +
                      $" where  STAFF_CODE='{sStaff_code}' and IDX='{rp_IDX}' ";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

            Process.Start(final_file);

        }


        private void textAppendWithClone(DataTable dt, Document document, String TableName)
        {
            int firstdatarow = 0;
            foreach (Section sec in document.Sections)
                foreach (Table tb in sec.Tables)
                    if (tb.Title == TableName)
                    {
                        tb.Rows[0].IsHeader = true;
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

                                //테이블 보더 굵기 조절 - row 안됨 cell 단위로만 된다함 ㅡㅡ
                                if (o == 0)
                                    tbc.CellFormat.Borders.Top.LineWidth = 1.5f;
                                else if (o == dt.Rows.Count - 1)
                                    tbc.CellFormat.Borders.Bottom.LineWidth = 1.5f;
                            }
                        }
                    }
        }

        private void textAppendWithClone_Add_each(DataTable dt, Document document, String TableName)
        {
            int firstdatarow = 0;
            foreach (Section sec in document.Sections)
                foreach (Table tb in sec.Tables)
                    if (tb.Title == TableName)
                    {
                        tb.Rows[0].IsHeader = true;
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
                        tb.Rows[0].IsHeader = true;
                        firstdatarow = tb.Rows.Count - 1;
                        TableRow firstrow = tb.Rows[firstdatarow].Clone();
                        TableRow tr;
                        int rowindex;
                        for (int o = 0; o < dt.Rows.Count + 2; o++)
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



    }
}

