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
    public partial class frmEduHistoryDaejang : Form
    {
        private UnitCommon unitCommon;
        private OleDbConnection Conn;
        private string s_title = "";

        private Form2_Anyang parentForm;

        public frmEduHistoryDaejang(Form2_Anyang parent)
        {
            InitializeComponent();
            Initialize();
            unitCommon = new UnitCommon();

            s_title = this.Text.ToString();

            this.parentForm = parent;
        }

        private void Initialize()
        {
                  
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

        private string file_open()
        {
            string fileName = OpenFile();
            //string fileName = "E:\\T42\\WORK\\request\\오로라\\테스트\\복사본 KI2015019.xls";
            string plainText = string.Empty;
            string ext = System.IO.Path.GetExtension(fileName).ToUpper();
            string directoryPath = string.Empty;
            //txtPhoto.Text = fileName;
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

        private void get_folder_data2(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            query = query + " and REPORT_NAME ='" + s_title + "'";
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

        private void button7_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_report", "REPORT_NO", "REPORT_NAME", cmbReport);
        }

        private void cmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = " select distinct REPORT_FILE, RESULT_FOLDER from PQMS_REPORT";
            query = query + " WHERE REPORT_NO = '" + cmbReport.Text.Substring(0, 4) + "'";
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

        private void btnEduHistoryDaejangGo_Click(object sender, EventArgs e)
        {
            if (txtRoleName.Text == "" )
            {
                MessageBox.Show("직무명을  입력 하세요.");
                txtRoleName.Focus();
                return;
            }
            else
            {

                string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                string savrfilepath = txtResultFolder.Text + @"\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "교육훈련이력" + @"\" + sDateTime_yyyyMM;

                DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                if (file_di.Exists == false)
                {
                    Directory.CreateDirectory(savrfilepath);
                }

                if (unitCommon.CreateDoc_trainingHistory(txtTemplate.Text, Form2PQMS_StaffInfo.sStaffCode, Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX, savrfilepath, txtRoleName.Text) == 0) // 파일 생성 성공
                {
                    // 교육훈련보고서 버튼 생상 변경 처리
                    MessageBox.Show("교육훈련이력 생성완료.");
                    parentForm.Change_btn3_ColorChange();
                    
                }
                this.Close();
            }            
        }

        private void frmEduHistoryDaejang_Load(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_report", "REPORT_NO", "REPORT_NAME", cmbReport);
            cmbReport.SelectedIndex = 0;
        }

        private void cmbRolePaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoleName.Text = cmbRolePaper.Text;
        }
    }
}
