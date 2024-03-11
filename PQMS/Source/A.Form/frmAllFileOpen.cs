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
using System.Data.SqlClient;
using Spire.Pdf;
using System.Diagnostics;

namespace PQMS
{
    public partial class frmAllFileOpen : Form
    {
        private UnitCommon unitCommon;
        private UnitSMTP unitSMTP;

        private OleDbConnection Conn;
        private Dictionary<string, string> comboBoxData = new Dictionary<string, string>();
        private Form2_Anyang parentForm;
      

        public frmAllFileOpen(Form2_Anyang parent)
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
        }

        private void frmAllFileOpen_Load(object sender, EventArgs e)
        {
            txtSTAFF_CODE.Text = Form2PQMS_StaffInfo.sStaffCode;
            get_folder_RoleCode(cmbRoleCode);
        }


        private void get_folder_RoleCode(System.Windows.Forms.ComboBox tCmb) //jhm0708
        {

            Conn = new OleDbConnection(unitCommon.connect_string);
            string sql = $" SELECT ROLE_CODE , ROLE_NAME " +
                   $" FROM PQMS_ROLE2_CODE " +
                   $" where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' AND REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' AND WS_CODE = '" + Form1PQMS_Repo.sWS + "' " +
                   $" ORDER BY  CASE WHEN ROLE_CODE = 'P006' THEN 0 " +
                   $" WHEN ROLE_CODE = 'P001' THEN 1 " +
                   $" WHEN ROLE_CODE = 'P002' THEN 2 " +
                   $" WHEN ROLE_CODE = 'P003' THEN 3 " +
                   $" WHEN ROLE_CODE = 'P009' THEN 4 " +
                   $" WHEN ROLE_CODE = 'P004' THEN 5 " +
                   $" WHEN ROLE_CODE = 'P010' THEN 6 " +
                   $" ELSE 7 END, ROLE_CODE ASC ";
            OleDbCommand cmd = new OleDbCommand(sql, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    tCmb.Items.Clear();

                    while (reader.Read())
                    {
                        //tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                        string text = reader["ROLE_NAME"].ToString(); // A를 Text로 사용
                        string value = reader["ROLE_CODE"].ToString(); // B를 Value로 사용

                        comboBoxData[text] = value;
                        tCmb.Items.Add(text);
                    }
                }
            }
            Conn.Close();
        }

        private void btn_AllFileOpen_Click(object sender, EventArgs e)
        {

            if (cmbRoleCode.Text == "")
            {
                MessageBox.Show("직무명을 선택하세요");
                return;
            }

            if (txtRoleCode.Text == "P006") // 실무자 
            {
                string query = "";
                if (txtSTAFF_CODE.Text != "")
                {
                    //서약서 
                    query = " SELECT STAFF_FILE from PQMS_STAFF " +
                            " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";
                    OleDbCommand cmd = new OleDbCommand(query, Conn);
                    Conn.Open();

                    string sFile_STAFF_FILE = "";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sFile_STAFF_FILE = reader.GetValue(0).ToString();
                            }
                        }
                    }
                    Conn.Close();

                    //교육훈련이력기록
                    query = " SELECT FILE_PATH FROM PQMS_STAFF_TRAINING_HISTORY_FOLDER " +
                                    " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";

                    cmd = new OleDbCommand(query, Conn);
                    Conn.Open();

                    string sFile_TR = "";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sFile_TR = reader.GetValue(0).ToString();
                            }
                        }
                    }
                    Conn.Close();
                    //시험수행능력평가이력
                    query = " SELECT FILE_PATH FROM PQMS_STAFF_RP_EACH_LIST_FOLDER " +
                                    " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";

                    cmd = new OleDbCommand(query, Conn);
                    Conn.Open();
                    string sFile_EACH = "";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sFile_EACH = reader.GetValue(0).ToString();
                            }
                        }
                    }
                    Conn.Close();
                    //직무기술서 
                    query = " select top 1 Max(b.RP_VERSION), a.STAFF_RP_FILE from PQMS_STAFF_ROLE_PAPER a  " +
                            " inner join PQMS_STAFF_ROLE_PAPER_ver b on a.STAFF_CODE = b.STAFF_CODE and a.IDX = b.RP_IDX " +
                            " where a.STAFF_CODE = '" + txtSTAFF_CODE.Text + "' " +
                            " and STAFF_RP_CODE = '" + txtRoleCode.Text + "' " +
                            " group by a.STAFF_RP_FILE " +
                            " order by 1 desc";
                    cmd = new OleDbCommand(query, Conn);
                    Conn.Open();
                    string sFile_ROLE_PAPER = "";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sFile_ROLE_PAPER = reader.GetValue(1).ToString();
                            }
                        }
                    }
                    Conn.Close();
                    //자격부여평가보고서 
                    query = " SELECT FINAL_FILE FROM PQMS_STAFF_ASSESSMENT_REPORT " +
                                  " WHERE STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";

                    cmd = new OleDbCommand(query, Conn);
                    Conn.Open();

                    string sFile_ASSESSMENT = "";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sFile_ASSESSMENT = reader.GetValue(0).ToString();
                            }
                        }
                    }
                    Conn.Close();

                    //임명장
                    query = " SELECT STAFF_ROLE_FILE FROM PQMS_STAFF_ROLE " +
                            " WHERE STAFF_CODE = '" + txtSTAFF_CODE.Text + "' " +
                            " AND STAFF_ROLE_CODE = '" + txtRoleCode.Text + "'" +
                            " AND STAFF_ROLE_ORG_CODE !='0007' ";

                    cmd = new OleDbCommand(query, Conn);
                    Conn.Open();
                    string sFile_ROLE_FILE = "";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sFile_ROLE_FILE = reader.GetValue(0).ToString();
                            }
                        }
                    }
                    Conn.Close();

                    //트래이닝폴더관리 
                    query = " SELECT FILE_PATH FROM PQMS_STAFF_ROLEPAPER_TRANING_FOLDER " +
                                    " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' " +
                                    "  AND ROLE_CODE = '" + txtRoleCode.Text + "'";


                    cmd = new OleDbCommand(query, Conn);
                    Conn.Open();

                    string sFile_TRANING_FOLDER = "";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sFile_TRANING_FOLDER = reader.GetValue(0).ToString();
                            }
                        }
                    }
                    Conn.Close();
                    //  @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\RolePaper\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "직무기술서" + @"\" + sDateTime_yyyyMM_RP_Report;

                    string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                    string mergedFilePath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "ALL_FILE" + @"\" + sDateTime_yyyyMM;

                    DirectoryInfo file_di = new DirectoryInfo(mergedFilePath);
                    if (file_di.Exists == false)
                    {
                        Directory.CreateDirectory(mergedFilePath);
                    }

                    string savefile = mergedFilePath + @"\ALLFile_" + txtSTAFF_CODE.Text + ".pdf";

                    MergePDFFiles(savefile, sFile_TRANING_FOLDER, sFile_STAFF_FILE, sFile_ROLE_FILE, sFile_TR, sFile_EACH, sFile_ROLE_PAPER, sFile_ASSESSMENT);
                    Process.Start(savefile);
                }
            }
            else // 실무자 외에 다른 직무
            {
                string query = "";
                if (txtSTAFF_CODE.Text != "")
                {
                    //서약서 
                    query = " SELECT STAFF_FILE from PQMS_STAFF " +
                            " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";
                    OleDbCommand cmd = new OleDbCommand(query, Conn);
                    Conn.Open();

                    string sFile_STAFF_FILE = "";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sFile_STAFF_FILE = reader.GetValue(0).ToString();
                            }
                        }
                    }
                    Conn.Close();                                    
                   
                    //직무기술서 
                    query = " select top 1 Max(b.RP_VERSION), a.STAFF_RP_FILE from PQMS_STAFF_ROLE_PAPER a  " +
                            " inner join PQMS_STAFF_ROLE_PAPER_ver b on a.STAFF_CODE = b.STAFF_CODE and a.IDX = b.RP_IDX " +
                            " where a.STAFF_CODE = '" + txtSTAFF_CODE.Text + "' " +
                            " and STAFF_RP_CODE = '" + txtRoleCode.Text + "' " +
                            " group by a.STAFF_RP_FILE " +
                            " order by 1 desc";
                    cmd = new OleDbCommand(query, Conn);
                    Conn.Open();
                    string sFile_ROLE_PAPER = "";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sFile_ROLE_PAPER = reader.GetValue(1).ToString();
                            }
                        }
                    }
                    Conn.Close();
                    

                    //임명장
                    query = " SELECT STAFF_ROLE_FILE FROM PQMS_STAFF_ROLE " +
                            " WHERE STAFF_CODE = '" + txtSTAFF_CODE.Text + "' " +
                            " AND STAFF_ROLE_CODE = '" + txtRoleCode.Text + "'" +
                            " AND STAFF_ROLE_ORG_CODE !='0007' ";

                    cmd = new OleDbCommand(query, Conn);
                    Conn.Open();
                    string sFile_ROLE_FILE = "";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sFile_ROLE_FILE = reader.GetValue(0).ToString();
                            }
                        }
                    }
                    Conn.Close();

                    //트래이닝폴더관리 
                    query = " SELECT FILE_PATH FROM PQMS_STAFF_ROLEPAPER_TRANING_FOLDER " +
                                    " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' " +
                                    "  AND ROLE_CODE = '" + txtRoleCode.Text + "'";

                    cmd = new OleDbCommand(query, Conn);
                    Conn.Open();

                    string sFile_TRANING_FOLDER = "";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                sFile_TRANING_FOLDER = reader.GetValue(0).ToString();
                            }
                        }
                    }
                    Conn.Close();
                    //  @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\RolePaper\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "직무기술서" + @"\" + sDateTime_yyyyMM_RP_Report;

                    string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                    string mergedFilePath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "ALL_FILE" + @"\" + sDateTime_yyyyMM;

                    DirectoryInfo file_di = new DirectoryInfo(mergedFilePath);
                    if (file_di.Exists == false)
                    {
                        Directory.CreateDirectory(mergedFilePath);
                    }

                    string savefile = mergedFilePath + @"\ALLFile_" + txtSTAFF_CODE.Text + ".pdf";

                    MergePDFFiles(savefile, sFile_TRANING_FOLDER, sFile_STAFF_FILE, sFile_ROLE_FILE, sFile_ROLE_PAPER);
                    Process.Start(savefile);
                }
            }           
        }
        static void MergePDFFiles(string outputFilePath, params string[] inputFilePaths)
        {
            // 새로운 PDF 문서 생성
            PdfDocument newDocument = new PdfDocument();

            // 각 파일로부터 PDF 문서를 불러와 병합
            foreach (string inputFilePath in inputFilePaths)
            {
                if (File.Exists(inputFilePath) && Path.GetExtension(inputFilePath).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    PdfDocument doc = new PdfDocument();
                    doc.LoadFromFile(inputFilePath);
                    newDocument.AppendPage(doc);
                }
                //else
                //{
                //    Console.WriteLine($"경로에 존재하지 않거나 PDF 파일이 아닌 파일이 있습니다: {inputFilePath}");
                //}
            }

            // 결과를 새로운 파일로 저장
            newDocument.SaveToFile(outputFilePath, Spire.Pdf.FileFormat.PDF);
        }

        private void cmbRoleCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbRoleCode.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                txtRoleCode.Text = comboBoxData[selectedText];
                txtRoleName.Text = selectedText.ToString();
            }
        }
    }

}
