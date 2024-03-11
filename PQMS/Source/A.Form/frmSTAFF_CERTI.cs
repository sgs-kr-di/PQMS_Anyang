using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using Spire.Doc;
using System.IO;
using System.Data.OleDb;
using PQMS.C.Unit;
using System.Drawing;
using ComboBox = System.Windows.Forms.ComboBox;
using System.Data;
using System.Diagnostics;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Xls;
using DevExpress.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace PQMS
{
    public partial class frmSTAFF_CERTI : MetroFramework.Forms.MetroForm
    {

        private UnitCommon unitCommon;
        private OleDbConnection Conn;
        private Dictionary<string, string> comboBoxData = new Dictionary<string, string>();
        private Form2PQMS_STAFF_CERTIGridDataSet Form2PQMS_STAFF_CERTISet;

        public frmSTAFF_CERTI()
        {
            InitializeComponent();
            Form2PQMS_STAFF_CERTISet = new Form2PQMS_STAFF_CERTIGridDataSet(AppRes.DB.Connect, null, null);

            unitCommon = new UnitCommon();
        }

        private void frmSTAFF_CERTI_Load(object sender, EventArgs e)
        {
            // get_folder_certi_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbMainCertiRole);
            Call_PQMS_Main_Certi(Form2PQMS_StaffInfo.sStaffCode);
            txtSTAFF_CODE_CERTI.Text = Form2PQMS_StaffInfo.sStaffCode;
        }


        private void get_folder_certi_data(string tTable, string tField1, string tField2, ComboBox tCmb)        //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2
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
                        //tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());

                        string text = reader[tField2].ToString(); // 
                        string value = reader[tField1].ToString(); //

                        comboBoxData[text] = value;

                        tCmb.Items.Add(text);
                    }
                }
                tCmb.Items.Add("기타");
            }

            Conn.Close();
        }

        private void get_folder_data2_type2(string tTable, string tField1, string tField2, string tField3, string tField4, System.Windows.Forms.ComboBox tCmb)        //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + "  where " + tField3 + " = '" + tField4 + "'";
            query = query + " and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
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
                        string text = reader[tField2].ToString(); // 
                        string value = reader[tField1].ToString(); //

                        comboBoxData[text] = value;

                        tCmb.Items.Add(text);
                    }
                }
            }

            Conn.Close();

        }

        private void get_folder_data3(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)        //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + "  where GROUP2_ORG_CODE = '" + txtMainCertiRoleCode.Text + "'";
            query = query + "    and GROUP2_GROUP1_CODE = '" + txtMainCertiBigOrgCode.Text + "'";
            query = query + " and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
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
                        // tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());


                        string text = reader[tField2].ToString(); // 
                        string value = reader[tField1].ToString(); //

                        comboBoxData[text] = value;

                        tCmb.Items.Add(text);
                    }
                }
            }

            Conn.Close();

        }

        private void get_folder_data4(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)       //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where ROLE_ORG_CODE = '" + txtMainCertiRoleCode.Text + "'";
            query = query + " and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            query = query + " order by " + tField1 + "," + tField2;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    tCmb.Items.Clear();

                    while (reader.Read())
                    {
                        //tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                        string text = reader[tField2].ToString(); // 
                        string value = reader[tField1].ToString(); //

                        comboBoxData[text] = value;

                        tCmb.Items.Add(text);
                    }
                }
            }

            Conn.Close();

        }

        private void cmbMainCertiBigOrgName_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedText = cmbMainCertiBigOrgName.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                txtMainCertiBigOrgCode.Text = comboBoxData[selectedText];
                txtMainCertiBigOrgName.Text = selectedText.ToString();
            }
            txtMainCertiOrgCode.Text = txtMainCertiBigOrgCode.Text + "-" + txtMainCertiMidOrgCode.Text;

            get_folder_data3("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbMainCertiMidOrgName);
        }

        private void cmbMainCertiMidOrgName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbMainCertiMidOrgName.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                txtMainCertiMidOrgCode.Text = comboBoxData[selectedText];
                txtMainCertiMidOrgName.Text = selectedText.ToString();
            }

            txtMainCertiOrgCode.Text = txtMainCertiBigOrgCode.Text + "-" + txtMainCertiMidOrgCode.Text;

            get_folder_data4("PQMS_ROLE", "ROLE_CODE", "ROLE_NAME", cmbMainCertiRoleName);
        }

        private void cmbMainCertiRoleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbMainCertiRoleName.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                cmbMainCertiRoleCode.Text = comboBoxData[selectedText];
                cmbMainCertiRoleName.Text = selectedText.ToString();
            }
        }

        private void btnAttachmentCerti_Click(object sender, EventArgs e)
        {
            string fileContent = string.Empty;
            string filePath = string.Empty;

            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //내문서로 기본폴더 설정
                //fd.Filter = "word files (*.docx)|*.docx|word files (*.doc)|*.doc"; //필터 설정
                //fd.FilterIndex = 2; //1번 선택시 txt , 2번 선택시 *.*
                fd.FilterIndex = 2;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    filePath = fd.FileName; //전체 경로와 파일명 //선택한 파일명은 fd.SafeFileName
                    txtSTAFF_CERTI_FILE.Text = filePath;
                }
            }
        }

        private void btnOpenCerti_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSTAFF_CERTI_FILE.Text) == false)
            {
                Process.Start(txtSTAFF_CERTI_FILE.Text);
            }
        }

        private void PQMS_STAFF_CERTIGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            // IDX
            Form2PQMS_STAFF_CERTISet.iIDX = Convert.ToInt32(PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["IDX"]);

            // 사번
            txtSTAFF_CODE_CERTI.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CODE"].ToString();

            // 직무기관
            txtMainCertiRoleCode.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["ORG_CODE"].ToString();
            txtMainMidCertiRole.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["ORG_NAME"].ToString();
            //cmbMainCertiRole.Text = txtMainCertiRoleCode.Text + " " + txtMainMidCertiRole.Text;
            cmbMainCertiRole.Text = txtMainMidCertiRole.Text;

            // 대분야
            txtMainCertiBigOrgCode.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["GROUP1_CODE"].ToString();
            txtMainCertiBigOrgName.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["GROUP1_NAME"].ToString();
            //cmbMainCertiBigOrgName.Text = txtMainCertiBigOrgCode.Text + " " + txtMainCertiBigOrgName.Text;
            cmbMainCertiBigOrgName.Text = txtMainCertiBigOrgName.Text;

            // 중분야
            txtMainCertiMidOrgCode.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["GROUP2_CODE"].ToString();
            txtMainCertiMidOrgName.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["GROUP2_NAME"].ToString();
            //cmbMainCertiMidOrgName.Text = txtMainCertiMidOrgCode.Text + " " + txtMainCertiMidOrgName.Text;
            cmbMainCertiMidOrgName.Text = txtMainCertiMidOrgName.Text;

            // 분야코드
            txtMainCertiOrgCode.Text = txtMainCertiBigOrgCode.Text + "-" + txtMainCertiMidOrgCode.Text;

            // 직무코드
            cmbMainCertiRoleCode.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["ROLE_CODE"].ToString();
            //cmbMainCertiRoleName.Text = cmbMainCertiRoleCode.Text + " " + PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["ROLE_NAME"].ToString();
            cmbMainCertiRoleName.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["ROLE_NAME"].ToString();

            // 자격증 정보
            txtSTAFF_CERTI_ROLE.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_ROLE"].ToString();
            txtSTAFF_CERTI_NAME.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_NAME"].ToString();
            txtSTAFF_CERTI_DATE.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_ROLE_DATE"].ToString();
            txtSTAFF_CERTI_FILE.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_FILE"].ToString();

            txtSTAFF_CERTI_NUMBER.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_NUMBER"].ToString();

            //if (e.Column.FieldName.Equals("사본첨부"))
            if (e.Column.Caption.Equals("사본첨부"))
            {
                string strFile = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void btnStaffcertiInsert_Click(object sender, EventArgs e)
        {
            if (txtSTAFF_CODE_CERTI.Text == "")
            {
                MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                return;
            }

            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                if (string.IsNullOrEmpty(txtSTAFF_CERTI_FILE.Text) == false)
                {
                    //File.Copy(rpt, savefile, overwrite: true);

                    Document document = new Document();

                    string rpt = txtSTAFF_CERTI_FILE.Text;
                    string sfileName = Path.GetFileNameWithoutExtension(rpt);
                    string sExtensionName = Path.GetExtension(rpt);
                    string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                    string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                    string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "자격증자료" + @"\" + sDateTime_yyyyMM;

                    DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                    if (file_di.Exists == false)
                    {
                        Directory.CreateDirectory(savrfilepath);
                    }

                    string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;
                    File.Copy(rpt, savefile, true);

                    //document.LoadFromFile(rpt);
                    //document.SaveToFile(savefile);
                    //document.Close();

                    txtSTAFF_CERTI_FILE.Text = savefile;
                }

                Form2PQMS_STAFF_CERTISet.sSTAFF_CODE = txtSTAFF_CODE_CERTI.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_ROLE_ORG_CODE = txtMainCertiRoleCode.Text;
                //Form2PQMS_STAFF_CERTISet.sROLE_CODE = txtMainCertiOrgCode.Text;
                Form2PQMS_STAFF_CERTISet.sROLE_CODE = cmbMainCertiRoleCode.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_ROLE_CLASS = (txtMainCertiBigOrgCode.Text + "-" + txtMainCertiMidOrgCode.Text).Trim();
                Form2PQMS_STAFF_CERTISet.sSTAFF_CERTI_ROLE = txtSTAFF_CERTI_ROLE.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_CERTI_NAME = txtSTAFF_CERTI_NAME.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_CERTI_DATE = txtSTAFF_CERTI_DATE.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_CERTI_FILE = txtSTAFF_CERTI_FILE.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_CERTI_NUMBER = txtSTAFF_CERTI_NUMBER.Text;

                // $" ('{sSTAFF_CODE}', '{sSTAFF_ROLE_ORG_CODE}', '{sROLE_CODE}', '{sSTAFF_ROLE_CLASS}', '{sSTAFF_CERTI_ROLE}', '{sSTAFF_CERTI_NAME}', '{sSTAFF_CERTI_DATE}', '{sSTAFF_CERTI_FILE}'); ";
                Form2PQMS_STAFF_CERTISet.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");

                Field_Reset("txtSTAFF_CODE_CERTI");
                Call_PQMS_Main_Certi(txtSTAFF_CODE_CERTI.Text);

            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
            }

            Call_PQMS_Main_Certi(Form2PQMS_STAFF_CERTISet.sSTAFF_CODE);
        }

        private void btnStaffcertiUpdate_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                if (string.IsNullOrEmpty(txtSTAFF_CERTI_FILE.Text) == false)
                {
                    FileInfo fi = new FileInfo(txtSTAFF_CERTI_FILE.Text);

                    if (txtSTAFF_CERTI_FILE.Text.ToString().ToUpper().Contains(unitCommon.sFileServerName) == true)
                    {
                        if (fi.Exists == false) //
                        {
                            //File.Copy(rpt, savefile, overwrite: true);

                            Document document = new Document();

                            string rpt = txtSTAFF_CERTI_FILE.Text;
                            string sfileName = Path.GetFileNameWithoutExtension(rpt);
                            string sExtensionName = Path.GetExtension(rpt);
                            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                            string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "자격증자료" + @"\" + sDateTime_yyyyMM;
                            DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                            if (file_di.Exists == false)
                            {
                                Directory.CreateDirectory(savrfilepath);
                            }

                            string savefile = savrfilepath + @"\" + sfileName + "_수정된" + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                            File.Copy(rpt, savefile, true);

                            //document.LoadFromFile(rpt);
                            //document.SaveToFile(savefile);
                            //document.Close();

                            txtSTAFF_CERTI_FILE.Text = savefile;
                        }
                    }
                    else
                    {
                        Document document = new Document();

                        string rpt = txtSTAFF_CERTI_FILE.Text;
                        string sfileName = Path.GetFileNameWithoutExtension(rpt);
                        string sExtensionName = Path.GetExtension(rpt);
                        string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                        string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                        string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "자격증자료" + @"\" + sDateTime_yyyyMM;
                        DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                        if (file_di.Exists == false)
                        {
                            Directory.CreateDirectory(savrfilepath);
                        }

                        string savefile = savrfilepath + @"\" + sfileName + "_수정된" + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;


                        File.Copy(rpt, savefile, true);

                        //document.LoadFromFile(rpt);
                        //document.SaveToFile(savefile);
                        //document.Close();

                        txtSTAFF_CERTI_FILE.Text = savefile;
                    }
                }

                Form2PQMS_STAFF_CERTISet.sSTAFF_CODE = txtSTAFF_CODE_CERTI.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_ROLE_ORG_CODE = txtMainCertiRoleCode.Text;
                Form2PQMS_STAFF_CERTISet.sROLE_CODE = cmbMainCertiRoleCode.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_ROLE_CLASS = (txtMainCertiBigOrgCode.Text + "-" + txtMainCertiMidOrgCode.Text).Trim();
                Form2PQMS_STAFF_CERTISet.sSTAFF_CERTI_ROLE = txtSTAFF_CERTI_ROLE.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_CERTI_NAME = txtSTAFF_CERTI_NAME.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_CERTI_DATE = txtSTAFF_CERTI_DATE.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_CERTI_FILE = txtSTAFF_CERTI_FILE.Text;
                Form2PQMS_STAFF_CERTISet.sSTAFF_CERTI_NUMBER = txtSTAFF_CERTI_NUMBER.Text;

                Form2PQMS_STAFF_CERTISet.Update(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("수정 완료!");
                Field_Reset("txtSTAFF_CODE_CERTI");

                Call_PQMS_Main_Certi(txtSTAFF_CODE_CERTI.Text);

            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("수정 실패!" + Environment.NewLine + f.Message);
            }

            Call_PQMS_Main_Certi(Form2PQMS_STAFF_CERTISet.sSTAFF_CODE);
        }

        private void btnStaffcertiDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2PQMS_STAFF_CERTISet.sSTAFF_CODE = txtSTAFF_CODE_CERTI.Text;

                Form2PQMS_STAFF_CERTISet.Delete(trans);
                AppRes.DB.CommitTrans();

                //서버에서 파일삭제
                if (File.Exists(txtSTAFF_CERTI_FILE.Text))
                {
                    File.Delete(txtSTAFF_CERTI_FILE.Text);
                }
                MessageBox.Show("삭제 완료!");

                Field_Reset("txtSTAFF_CODE_CERTI");
                Call_PQMS_Main_Certi(txtSTAFF_CODE_CERTI.Text);
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
            }

            Call_PQMS_Main_Certi(Form2PQMS_STAFF_CERTISet.sSTAFF_CODE);
        }

        private void btnStaffcertiSearch_Click(object sender, EventArgs e)
        {
            Call_PQMS_Main_Certi(Form2PQMS_STAFF_CERTISet.sSTAFF_CODE);
        }

        private void Field_Reset(string s_txtStaffCode)
        {
           
        }

        private void Call_PQMS_Main_Certi(string sSTAFF_CODE = "")
        {
            Form2PQMS_STAFF_CERTISet.sSTAFF_CODE = sSTAFF_CODE;

            get_folder_certi_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbMainCertiRole); //자격증자료 직무기관코드

            // 자격증자료 조회 - '사번'이 Key
            try
            {
                get_folder_certi_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbMainCertiRole); //자격증자료 직무기관코드 

                Form2PQMS_STAFF_CERTISet.SelectSTAFF_CERTI();

                if (Form2PQMS_STAFF_CERTISet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_CERTIGrid, Form2PQMS_STAFF_CERTISet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("자격증자료 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }

            //자격증 Tab Page로 이동
            //tabControl1.SelectedTab = tabControl1.TabPages[3];
        }

        private void cmbMainCertiRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMainCertiRole.Text == "기타")
            {
                txtMainCertiRoleCode.Text = "";
                txtMainMidCertiRole.Text = "";
            }
            else
            {
                // txtMainCertiRoleCode.Text = cmbMainCertiRole.Text.Substring(0, 4);
                //txtMainMidCertiRole.Text = cmbMainCertiRole.Text.Substring(5, cmbMainCertiRole.Text.Length - 5);

                string selectedText = cmbMainCertiRole.SelectedItem.ToString();

                if (comboBoxData.ContainsKey(selectedText))
                {
                    txtMainCertiRoleCode.Text = comboBoxData[selectedText];
                    txtMainMidCertiRole.Text = selectedText.ToString();
                }
            }
            get_folder_data2_type2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtMainCertiRoleCode.Text, cmbMainCertiBigOrgName);
        }

        private void PQMS_STAFF_CERTIGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_CERTI_FILE")
            {
                if (PQMS_STAFF_CERTIGridView.GetRowCellValue(e.RowHandle, "STAFF_CERTI_FILE").ToString().Trim() != "")
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Cache.FillRectangle(SystemBrushes.Control, e.Bounds);
                    e.Appearance.DrawString(e.Cache, "파일열기", e.Bounds);
                    e.Handled = true;
                }
            }
        }
    }
}
