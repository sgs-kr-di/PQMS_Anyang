using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Collections;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Xls;
using Spire.Xls.Collections;
using Spire.Xls.Core.Spreadsheet.Shapes;
using System.Data.OleDb;
using System.Globalization;
using PQMS.C.Unit;

namespace PQMS
{
    public partial class frmLOP : MetroFramework.Forms.MetroForm
    {
        private UnitCommon unitCommon;
        private OleDbConnection Conn;

        public string equip_query = "";
        public int j = 0;
        public int wRowNo = 0;
        public string wpwd;
        

        public frmLOP()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTemplate.Text != "" && txtResultFolder.Text != "")
            {
                save_item();
                CreateDoc();               
            }
            else
            {
                MessageBox.Show("양식파일과 결과폴더를 선택하세요.");
            }          
        }

        private void CreateDoc()
        {
            DataTable USERINFO = new DataTable();
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = $"SELECT * FROM PQMS_STAFF_ROLE_APPOINT WHERE LOP_NO='{txtLOPNo.Text}'";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                USERINFO.Load(reader);

            }
            Conn.Close();

            DataTable APPINFO = new DataTable();
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query_Approve = $"select a.approvedBy , b.userID, b.accountNo, c.STAFF_NAME, c.STAFF_POSITION from PQMS_STAFF_ROLE_FINAL_APPROVE_LOG a " +
                $" inner join [accountmaster].dbo.accountMaster b on a.approvedBy = b.userID and appID='PQMS' " +
                $" inner join PQMS_STAFF c on b.accountNo = c.ACCOUNT_NO "+
                $" WHERE approveIdx='{txtLOPNo.Text}' and FinalApproveDepth = 2 ";
            cmd = new OleDbCommand(query_Approve, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                APPINFO.Load(reader);
            }
            Conn.Close();


            if (USERINFO.Rows.Count > 0 && APPINFO.Rows.Count > 0)
            {

                Document document = new Document();
                string rpt = @txtTemplate.Text;
                //document.LoadFromFile(rpt);

                document.LoadFromFile(rpt, Spire.Doc.FileFormat.Docx, "ANYANG"); //템플릿에 암호 설정
                document.RemoveEncryption();

                //CONFIG파일 없이 프로그램에 작성. //jhm
                document.Replace("txt01", USERINFO.Rows[0]["STAFF_NAME"].ToString(), false, true);
                document.Replace("txt02", USERINFO.Rows[0]["STAFF_ROLE_DEPT"].ToString(), false, true);
                document.Replace("txt03", USERINFO.Rows[0]["STAFF_SABUN"].ToString(), false, true);
                document.Replace("txt04", USERINFO.Rows[0]["STAFF_ROLE_APPOINT_DATE"].ToString(), false, true);
                document.Replace("txt05", USERINFO.Rows[0]["STAFF_ROLE_FIELD1"].ToString(), false, true);
                document.Replace("txt06", USERINFO.Rows[0]["STAFF_ROLE_FIELD2"].ToString(), false, true);
                document.Replace("txt07", USERINFO.Rows[0]["STAFF_ROLE_LAW"].ToString(), false, true);
                document.Replace("txt08", txtRoleName.Text, false, true);
                document.Replace("txt09", APPINFO.Rows[0]["STAFF_POSITION"].ToString(), false, true); //직책
                document.Replace("txt10", APPINFO.Rows[0]["STAFF_NAME"].ToString(), false, true);

                txtOrgChart.Text = txtResultFolder.Text  + "\\" + "임명장(" + txtStaffCode.Text + ")_"+txtLOPNo.Text+".pdf";
                document.SaveToFile(@txtOrgChart.Text);
                System.Diagnostics.Process.Start(@txtOrgChart.Text);
                
                
                MessageBox.Show("발행완료!");
            }
            else
            {
                MessageBox.Show("INVALID STAFFCODE");
            }
        }


        private DataTable convertoDt(DataGridView dgv1)
        {
            //Creating DataTable.
            DataTable dt = new DataTable();

            dt.Columns.Add("Name");
            dt.Columns.Add("Role");
            dt.Locale = CultureInfo.InvariantCulture;

            //Adding the Columns.
            //foreach (DataGridViewColumn column in dgv1.Columns)
            //{
            //    if (column.HeaderText == "Column2" || column.HeaderText == "Column4")
            //    {
            //        dt.Columns.Add(column.HeaderText, typeof(int));
            //    }
            //    else
            //    {
            //        dt.Columns.Add(column.HeaderText, typeof(string));
            //    }
            //    //dt.Columns.Add(column.HeaderText );
            //}

            //Adding the Header Rows.

            //dt.Rows.Add();
            //dt.Rows.Add();
            //for (int j = 0; j < dgv1.Columns.Count; j++)
            //{
            //    if (j == 1)
            //    {
            //        dt.Rows[0][j] = dgv1.Columns[j].HeaderText;
            //    }
            //}
            //Adding the Rows.
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                dt.Rows.Add();
               
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 1)  //체크박스, 사원코드 제외
                    {
                        //dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex-2] = cell.Value.ToString(); // 2개의 cell을 제오했기 때문
                        dt.Rows[row.Index][cell.ColumnIndex - 2] = cell.Value.ToString(); // 2개의 cell을 제외했기 때문
                    }
                }
            }
            DataView dav1 = new DataView(dt);
            //dav1.Sort = "Column2, Column5, Column4";
            dt = dav1.ToTable();
            //dt = dt.AsEnumerable().OrderBy(a => a.Field<string>("Column2")).OrderBy(a => a.Field<string>("Column5")).OrderBy(a => a.Field<string>("Column4")).CopyToDataTable(); 
            //Folder_table.AsEnumerable()
            //     .OrderBy(r => r.Field<DateTime>("FolderDateTime"))
            //.CopyToDataTable();

            return dt;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            get_folder_data3("PQMS_STAFF", "STAFF_CODE", "STAFF_NAME", cmbStaff);
        }

        

        private void button22_Click(object sender, EventArgs e)
        {
            file_open(txtTemplate);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            show_file(txtTemplate.Text.Trim());
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
                //if (ext.Equals(".DOCX") || ext.Equals(".DOC") || ext.Equals(".docx") || ext.Equals(".doc"))
                //{
                //    document.LoadFromFile(@tPath + "\\" + tFile);
                //    //Launching the MS Word file.
                //    WordDocViewer(@tPath + "\\" + tFile);
                //}
                //else if (ext.Equals(".XLSX") || ext.Equals(".XLS") || ext.Equals(".xls") || ext.Equals(".xlsx"))
                //{
                //    Workbook workbook = new Workbook();

                //    //Load workbook from disk.
                //    workbook.LoadFromFile(@tPath + "\\" + tFile);

                //    ExcelDocViewer(workbook.FileName);
                //}
                //else if (ext.Equals(".PDF") || ext.Equals(".pdf"))
                //{
                //    //Create a pdf document.
                //    PdfDocument doc = new PdfDocument();

                //    //Launching the Pdf file.
                //    PDFDocumentViewer(@tPath + "\\" + tFile);
                //}
                //else
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

        private string OpenFile()
        {
            openFileDialog1.Filter = "*.*|*.*";
            //openFileDialog1.Filter = "Photo (*.jpeg*)|*.jpg*";
            openFileDialog1.Title = "Choose a photo";

            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }

            return string.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            file_open(txtOrgChart);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            show_file(txtOrgChart.Text.Trim());
        }

        private void get_folder_data(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
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

        private void frmLOP_Load(object sender, EventArgs e)
        {
            //dgvData.AllowUserToAddRows = false;

            get_folder_data("PQMS_LOPDescription", "IDX", "Description1", cmbDesc1);
            get_folder_data("PQMS_LOPDescription", "IDX", "Description1", cmbDesc2);
            get_folder_data("PQMS_LOPDescription", "IDX", "Description1", cmbDesc3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_report", "REPORT_NO", "REPORT_NAME", cmbReport);
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

        private void get_folder_data3(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where substring(staff_team,0,5) = '" + Form1PQMS_Repo.sSiteCode + "'";
            query = query + "   and substring(staff_team,6,4) = '" + Form1PQMS_Repo.sRepo + "'";
            query = query + "   and substring(staff_team,11,5) = '" + Form1PQMS_Repo.sWS + "'";
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

        private void cmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct REPORT_FILE, RESULT_FOLDER from PQMS_REPORT";
            query = query + "   WHERE REPORT_NO = '" + cmbReport.Text.Substring(0, 4) + "'";
            query = query + " and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    txtTemplate.Text = "";

                    while (reader.Read())
                    {
                        txtTemplate.Text = reader.GetValue(0).ToString() ;
                        txtResultFolder.Text = reader.GetValue(1).ToString();
                    }
                }
            }

            Conn.Close();
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStaffCode.Text = cmbStaff.Text.Substring(0, 4);
            txtStaffName.Text = cmbStaff.Text.Substring(5, cmbStaff.Text.Length - 5);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            save_item();
        }

        private void save_item()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            txtOrgChart.Text = txtResultFolder.Text + "\\" + "임명장(" + txtStaffCode.Text + ")_" + txtLOPNo.Text + ".docx";

            query = "INSERT INTO PQMS_STAFF_ROLE_APPOINT (LOP_NO, STAFF_CODE, STAFF_NAME, STAFF_SABUN, STAFF_ROLE_DEPT, STAFF_ROLE_APPOINT_DATE, STAFF_ROLE_FIELD1, STAFF_ROLE_FIELD2, STAFF_ROLE_LAW, STAFF_ROLE_FILE	) VALUES ( ";
            query = query + "'" + txtLOPNo.Text.Trim() + "',";
            query = query + "'" + txtStaffCode.Text.Trim() + "',";   
            query = query + "N'" + txtStaffName.Text.Trim() + "',";
            query = query + "'" + txtSabun.Text.Trim() + "',";
            query = query + "N'" + txtDeptName.Text.Trim() + "',";
            query = query + "N'" + txtAppointDate.Text.Trim() + "',";
            query = query + "N'" + txtGroupName.Text.Trim() + "',"; //분야
            query = query + "'', ";
            query = query + "'', ";
            query = query + "N'" + txtOrgChart.Text.Trim()+"') ";

            query = query + " update PQMS_STAFF_ROLE set ";
            query = query + "  STAFF_ROLE_FILE = '" + txtOrgChart.Text.Trim() + "' ";
            query = query + " where IDX in ( "+ txtRIDX.Text.Substring(2, txtRIDX.Text.Length -2 ) +" ) ";


            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();

            Conn.Close();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Modi_rtn();
        }

        private void Modi_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE PQMS_STAFF_ROLE_APPOINT  SET ";
            query = query + " STAFF_CODE  = '" + txtSabun.Text.Trim() + "',";
            query = query + " STAFF_NAME  = N'" + txtStaffName.Text.Trim() + "',";
            query = query + " STAFF_ROLE_DEPT  = N'" + txtDeptName.Text.Trim() + "',";
            query = query + " STAFF_ROLE_APPOINT_DATE  = N'" + txtAppointDate.Text.Trim() + "',";
            query = query + " STAFF_ROLE_FIELD1  = N'" + txtField1.Text.Trim() + "',";
            query = query + " STAFF_ROLE_FIELD2  = N'" + txtField2.Text.Trim() + "',";
            query = query + " STAFF_ROLE_LAW  = N'" + txtLaw.Text.Trim() + "'";
            query = query + " WHERE LOP_NO = '" + txtLOPNo.Text.Trim() + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();


            MessageBox.Show("수정완료!");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dele_rtn();
        }

        private void dele_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "delete from PQMS_STAFF_ROLE_APPOINT  ";
            query = query + " WHERE LOP_NO = '" + txtLOPNo.Text.Trim() + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();

            MessageBox.Show("삭제완료!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Get_Data("PQMS_STAFF_ROLE_APPOINT", "IDX");

            PQMS_STAFF_RoleAppointListGrid.DataSource = null;

            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = "  select a.* from PQMS_STAFF_ROLE_APPOINT  a  inner join PQMS_STAFF b on a.STAFF_CODE = b.STAFF_CODE  ";
            query = query + " and b.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE='" + Form1PQMS_Repo.sWS + "' ";
            query = query + " order by a.idx ";


            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();            
            
            DataTable dt = new DataTable();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    PQMS_STAFF_RoleAppointListGrid.DataSource = dt;
                }
            }
            Conn.Close();

        }

        private void btn_LOA_ApproveRequest_Click(object sender, EventArgs e)
        {
            Form2PQMS_StaffInfo.sStaffCode = txtStaffCode.Text;
            Form2_Tab_Info_Now.sMenuName = "부서관리";
            Form2_Tab_Info_Now.sTabName = "임명장";


            //선택된 임명장의 사번의 팀 정보 가져오기 


            //Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM=

            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
            {
                MessageBox.Show("사원을 선택해주세요.");
                return;
            }

            if (string.IsNullOrEmpty(Form2_GridIdx.sIDX) == true)
            {
                MessageBox.Show("표를 선택해주세요.");
                return;
            }

            string sFormName = "frmApproveRequest";
            frmApproveRequest childEduReport = new frmApproveRequest();

            if (unitCommon.YNFrom(sFormName))
            {
                childEduReport.Dispose();     // 창 리소스 제거
            }
            else
            {
                childEduReport.WindowState = FormWindowState.Normal;
                childEduReport.ShowDialog();
            }
        }

        private void btn_LOA_ApproveReqSelect_Click(object sender, EventArgs e)
        {
           

            Form2PQMS_StaffInfo.sStaffCode = txtStaffCode.Text;
            Form2_Tab_Info_Now.sMenuName = "부서관리";
            Form2_Tab_Info_Now.sTabName = "임명장";


            //if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
            //{
            //    MessageBox.Show("사원을 선택해주세요.");
            //    return;
            //}

            //if (string.IsNullOrEmpty(Form2_GridIdx.sIDX) == true)
            //{
            //    MessageBox.Show("표를 선택해주세요.");
            //    return;
            //}

            string sFormName = "frmApproveRequestCheck";
            frmApproveRequestCheck childEduReport = new frmApproveRequestCheck();

            if (unitCommon.YNFrom(sFormName))
            {
                childEduReport.Dispose();     // 창 리소스 제거
            }
            else
            {
                childEduReport.WindowState = FormWindowState.Normal;
                childEduReport.ShowDialog();
            }
        }

        private void cmbDesc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtField1.Text = cmbDesc1.Text;
        }

        private void cmbDesc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtField2.Text = cmbDesc2.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PQMS_STAFF_RoleApproveListGrid.DataSource = null;

            Conn = new OleDbConnection(unitCommon.connect_string);          

            string query = "";

            query = " SELECT a.*, b.staff_empno, b.STAFF_NAME, c.approveDate,  d.FOLDER_NAME , a.PQMS_STAFF_ROLE_IDX FROM  PQMS_STAFF_ROLE_FINAL a ";
            query = query + " INNER JOIN pqms_staff b ON a.staff_code = b.staff_code ";
            query = query + " and b.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE='" + Form1PQMS_Repo.sWS + "' ";
            query = query + " inner join(select approveIdx, max(approveDate) approveDate from PQMS_STAFF_ROLE_FINAL_APPROVE_LOG  group by approveIdx ) c on a.idx = c.approveIdx ";
            query = query + " inner join K_WORKSPACE d on b.STAFF_TEAM = d.SITE_CODE +'-'+ d.REPOSITORY_CODE +'-'+ d.WS_CODE +'-'+ d.FOLDER_CODE  and isnull(d.BOARD_CODE, '') ='' ";
            query = query + " WHERE a.approvestatuscode = '1'  ";
            query = query + " and a.idx not in ( select LOP_NO from PQMS_STAFF_ROLE_APPOINT)  ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();          

            int i;
            wRowNo = 0;
            DataTable dt = new DataTable();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    PQMS_STAFF_RoleApproveListGrid.DataSource = dt;                    
                }
            }
           

            Conn.Close();


        }  

        private void cmbDesc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLaw.Text = cmbDesc3.Text;
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            if (txtTemplate.Text != "" && txtResultFolder.Text != "")
            {
                // save_item();
                ShowDoc();
            }
            else
            {
                MessageBox.Show("양식파일과 결과폴더를 선택하세요.");
            }
        }


        private void ShowDoc()
        {
            //DataTable USERINFO = new DataTable();
            //Conn = new OleDbConnection(unitCommon.connect_string);
            //string query = $"SELECT * FROM PQMS_STAFF_ROLE_APPOINT WHERE LOP_NO='{txtLOPNo.Text}'";
            //OleDbCommand cmd = new OleDbCommand(query, Conn);
            //Conn.Open();
            //using (OleDbDataReader reader = cmd.ExecuteReader())
            //{
            //    USERINFO.Load(reader);

            //}
            //Conn.Close();

            if (txtSabun.Text != "")
            {

                Document document = new Document();
                string rpt = @txtTemplate.Text;
                document.LoadFromFile(rpt);
                //CONFIG파일 없이 프로그램에 작성. //jhm
                document.Replace("txt01", txtStaffName.Text, false, true);
                document.Replace("txt02", txtDeptName.Text, false, true);
                document.Replace("txt03", txtSabun.Text, false, true);
                document.Replace("txt04", txtAppointDate.Text, false, true);
                document.Replace("txt05", txtField1.Text, false, true);
                document.Replace("txt06", txtField2.Text, false, true);
                document.Replace("txt07", txtLaw.Text, false, true);

                txtOrgChart.Text = txtResultFolder.Text + "\\" + "임명장(" + txtStaffCode.Text + ")_" + txtLOPNo.Text + ".pdf";
                document.SaveToFile(@txtOrgChart.Text);
                System.Diagnostics.Process.Start(@txtOrgChart.Text);
            }
            else
            {
                MessageBox.Show("INVALID STAFFCODE");
            }

        }

        private void PQMS_STAFF_RoleApproveListView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            
            txtLOPNo.Text = PQMS_STAFF_RoleApproveListView.GetFocusedRowCellValue("IDX").ToString().Trim();
            txtStaffCode.Text = PQMS_STAFF_RoleApproveListView.GetFocusedRowCellValue("STAFF_CODE").ToString().Trim();
            txtSabun.Text = PQMS_STAFF_RoleApproveListView.GetFocusedRowCellValue("staff_empno").ToString().Trim();
            txtStaffName.Text = PQMS_STAFF_RoleApproveListView.GetFocusedRowCellValue("STAFF_NAME").ToString().Trim();
            txtAppointDate.Text = PQMS_STAFF_RoleApproveListView.GetFocusedRowCellValue("approveDate").ToString().Trim().Substring(0, 10);
            txtDeptName.Text = PQMS_STAFF_RoleApproveListView.GetFocusedRowCellValue("FOLDER_NAME").ToString().Trim();
            txtRoleName.Text = PQMS_STAFF_RoleApproveListView.GetFocusedRowCellValue("STAFF_ROLE_NAME").ToString().Trim();
            txtGroupName.Text = PQMS_STAFF_RoleApproveListView.GetFocusedRowCellValue("PQMS_STAFF_ROLE_GROUPNAME").ToString().Trim();
            txtRIDX.Text = PQMS_STAFF_RoleApproveListView.GetFocusedRowCellValue("PQMS_STAFF_ROLE_IDX").ToString().Trim();
        }

        private void PQMS_STAFF_RoleAppointListView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption.Equals("임명장보기"))
            {
                string strFile = PQMS_STAFF_RoleAppointListView.GetFocusedDataRow()["STAFF_ROLE_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }

            txtLOPNo.Text = PQMS_STAFF_RoleAppointListView.GetFocusedRowCellValue("LOP_NO").ToString();
            txtStaffCode.Text = PQMS_STAFF_RoleAppointListView.GetFocusedRowCellValue("STAFF_CODE").ToString();
            txtStaffName.Text = PQMS_STAFF_RoleAppointListView.GetFocusedRowCellValue("STAFF_NAME").ToString();
            txtSabun.Text = PQMS_STAFF_RoleAppointListView.GetFocusedRowCellValue("STAFF_SABUN").ToString();
            txtDeptName.Text = PQMS_STAFF_RoleAppointListView.GetFocusedRowCellValue("STAFF_ROLE_DEPT").ToString();
            txtAppointDate.Text = PQMS_STAFF_RoleAppointListView.GetFocusedRowCellValue("STAFF_ROLE_APPOINT_DATE").ToString();
            txtField1.Text = PQMS_STAFF_RoleAppointListView.GetFocusedRowCellValue("STAFF_ROLE_FIELD1").ToString();
            txtField2.Text = PQMS_STAFF_RoleAppointListView.GetFocusedRowCellValue("STAFF_ROLE_FIELD2").ToString();
            txtLaw.Text = PQMS_STAFF_RoleAppointListView.GetFocusedRowCellValue("STAFF_ROLE_LAW").ToString(); 

            Form2_GridIdx.sIDX = PQMS_STAFF_RoleAppointListView.GetFocusedRowCellValue("IDX").ToString();

            string query = " select STAFF_TEAM  from PQMS_STAFF where STAFF_CODE = '" + txtStaffCode.Text + "' ";
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
    }
}
