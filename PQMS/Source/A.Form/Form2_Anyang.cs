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
using System.Linq;
using Spire.Pdf;
//using DevExpress.XtraPrinting;

namespace PQMS
{
    public partial class Form2_Anyang : MetroFramework.Forms.MetroForm
    {

        private OleDbConnection Conn;

        private Dictionary<string, string> comboBoxData = new Dictionary<string, string>();

        //private Form2 Form2_form;
        private Form2DataSet Form2Set;
        private Form2PQMS_STAFF_STAFFDataSet Form2PQMS_STAFF_MainSTAFFSet;
        private Form2PQMS_STAFF_PreSTAFFDataSet Form2PQMS_STAFF_MainPreSTAFFSet;

        private Form2PQMS_STAFF_EDUMainDataSet Form2PQMS_STAFF_MainEDUSet;
        private Form2PQMS_STAFF_CERTIMainDataSet Form2PQMS_STAFF_MainCERTISet;
        private Form2PQMS_STAFF_ROLEMainDataSet Form2PQMS_STAFF_MainROLESet;

        private Form2PQMS_STAFF_EDUDataSet Form2PQMS_STAFF_EDUSet;
        private Form2PQMS_STAFF_CERTIGridDataSet Form2PQMS_STAFF_CERTISet;
        private Form2PQMS_STAFF_ROLEGridDataSet Form2PQMS_STAFF_ROLESet;
        private Form2PQMS_STAFF_ROLEGridInfoDataSet Form2PQMS_STAFF_ROLEGridInfoSet;

        private Form2PQMS_STAFF_ROLE_Form13_DataSet Form2PQMS_STAFF_ROLE_Form13Set;
        private Form2PQMS_ORG_Form5_DataSet Form2PQMS_ORG_Form5Set;
        private Form2_MEASUREMENT_UNCERTAINTY_DataSet Form2_MEASUREMENT_UNCERTAINTY_MainSTAFFSet;
        private Form2_CONSERVATIVE_EDUCATION_DataSet Form2_CONSERVATIVE_EDUCATION_MainSTAFFSet;

        private Form2PQMS_ROLE2_EACH_LIST_MainGridDataSet Form2PQMS_ROLE2_EACH_LIST_MainGridSet;
        private Form2PQMS_ROLE2_EACH_LIST_InfoGridDataSet Form2PQMS_ROLE2_EACH_LIST_InfoGridSet;

        private Form2PQMS_PQMS_STAFF_TRAINING_MainGridDataSet Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet;
        private Form2PQMS_PQMS_STAFF_TRAINING_InfoGridDataSet Form2PQMS_PQMS_STAFF_TRAINING_InfoGridSet;

        private Form2PQMS_STAFF_ROLE_PAPER_MainGridDataSet Form2PQMS_STAFF_ROLE_PAPER_MainGridSet;
        private Form2PQMS_STAFF_ROLE_PAPER_FinalGridDataSet Form2PQMS_STAFF_ROLE_PAPER_FinalGridSet;
        private Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_DataSet Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set;


        private PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridDataSet Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet;


        private Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridDataSet Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridSet;
        private Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridDataSet Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridSet;
        private Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridDataSet Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridSet;
        private Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridDataSet Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridSet;

        private Form2_ApproveInfo_DataSet Form2_ApproveInfo_Set;
        private Form2PQMS_STAFF_Workspace_DataSet Form2PQMS_STAFF_Workspace_Set;

        private Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridDataSet Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridSet;
        private Form2PQMS_STAFF_ASSESSMENT_MainGridDataSet Form2PQMS_STAFF_ASSESSMENT_MainGridSet;

        private GridBookmark MainPageBookmark;
        public List<Form2PQMS_STAFF_EDUPageRow> PQMS_STAFF_EDUPageRow;
        public List<Form2PQMS_STAFF_MainPageRow> PQMS_STAFF_MainPageRows;
        public List<Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow> PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRows;
        public List<Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow> PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRows;

        private UnitCommon unitCommon;
        private frmRepositoryInfo FrmRepositoryInfo;


        public Form2_Anyang()
        {
            InitializeComponent();
            Initialize();
            unitCommon = new UnitCommon();
        }

        private void Initialize()
        {
            //Form2_form = new Form2();
            Form2Set = new Form2DataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_MainSTAFFSet = new Form2PQMS_STAFF_STAFFDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_MainPreSTAFFSet = new Form2PQMS_STAFF_PreSTAFFDataSet(AppRes.DB.Connect, null, null);

            Form2PQMS_STAFF_MainEDUSet = new Form2PQMS_STAFF_EDUMainDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_MainCERTISet = new Form2PQMS_STAFF_CERTIMainDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_MainROLESet = new Form2PQMS_STAFF_ROLEMainDataSet(AppRes.DB.Connect, null, null);

            Form2PQMS_STAFF_EDUSet = new Form2PQMS_STAFF_EDUDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_CERTISet = new Form2PQMS_STAFF_CERTIGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_ROLESet = new Form2PQMS_STAFF_ROLEGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_ROLEGridInfoSet = new Form2PQMS_STAFF_ROLEGridInfoDataSet(AppRes.DB.Connect, null, null);

            Form2PQMS_STAFF_ROLE_Form13Set = new Form2PQMS_STAFF_ROLE_Form13_DataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_ORG_Form5Set = new Form2PQMS_ORG_Form5_DataSet(AppRes.DB.Connect, null, null);
            Form2_MEASUREMENT_UNCERTAINTY_MainSTAFFSet = new Form2_MEASUREMENT_UNCERTAINTY_DataSet(AppRes.DB.Connect, null, null);
            Form2_CONSERVATIVE_EDUCATION_MainSTAFFSet = new Form2_CONSERVATIVE_EDUCATION_DataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_ROLE_PAPER_MainGridSet = new Form2PQMS_STAFF_ROLE_PAPER_MainGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridSet = new Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridDataSet(AppRes.DB.Connect, null, null);

            Form2PQMS_STAFF_ROLE_PAPER_FinalGridSet = new Form2PQMS_STAFF_ROLE_PAPER_FinalGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set = new Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_DataSet(AppRes.DB.Connect, null, null);


            Form2PQMS_STAFF_ASSESSMENT_MainGridSet = new Form2PQMS_STAFF_ASSESSMENT_MainGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridSet = new Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridDataSet(AppRes.DB.Connect, null, null);


            Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridSet = new Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridSet = new Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridSet = new Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridDataSet(AppRes.DB.Connect, null, null);


            Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet = new PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridDataSet(AppRes.DB.Connect, null, null);


            Form2_ApproveInfo_Set = new Form2_ApproveInfo_DataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_Workspace_Set = new Form2PQMS_STAFF_Workspace_DataSet(AppRes.DB.Connect, null, null);

            PQMS_STAFF_MainPageRows = new List<Form2PQMS_STAFF_MainPageRow>();
            PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRows = new List<Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow>();
            PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRows = new List<Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow>();

            MainPageBookmark = new GridBookmark(PQMS_STAFF_AllGridView);

            unitCommon = new UnitCommon();
            FrmRepositoryInfo = new frmRepositoryInfo();

            Form2PQMS_ROLE2_EACH_LIST_MainGridSet = new Form2PQMS_ROLE2_EACH_LIST_MainGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_ROLE2_EACH_LIST_InfoGridSet = new Form2PQMS_ROLE2_EACH_LIST_InfoGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet = new Form2PQMS_PQMS_STAFF_TRAINING_MainGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_PQMS_STAFF_TRAINING_InfoGridSet = new Form2PQMS_PQMS_STAFF_TRAINING_InfoGridDataSet(AppRes.DB.Connect, null, null);

            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmb_Main_ORGCode);

            if (Form1PQMS_Repo.sRepo != null)
            {
                cmb_Main_ORGCode.SelectedIndex = 6;
            }
            cmbMain_StaffStatus.SelectedIndex = 0;
        }

        public void Food_Mgr_Mode()
        {
            this.tabControl1.TabPages.Remove(this.tabPage1);
            this.tabControl1.TabPages.Remove(this.tabPage2);
            this.tabControl1.TabPages.Remove(this.tabPage3);
            this.tabControl1.TabPages.Remove(this.tabPage4);
            this.tabControl1.TabPages.Remove(this.tabPage5);
            this.tabControl1.TabPages.Remove(this.tabPage7);
            this.tabControl1.TabPages.Remove(this.tabPage8);
            this.tabControl1.TabPages.Remove(this.tabPage10);
        }

        private void get_folder_data7(ComboBox tCmb) //jhm
        {

            //내부외부 구분 - 콤보박스 데이터 추가  및 textbox 기본값 세팅 
            cmbSTAFF_TRAIN_GUBUN.Items.Clear();
            cmbSTAFF_TRAIN_GUBUN.Items.Add("Internal");
            cmbSTAFF_TRAIN_GUBUN.Items.Add("External");


            cmbSTAFF_TRAIN_RESULT.Items.Clear();
            cmbSTAFF_TRAIN_RESULT.Items.Add("교육자료첨부");
            cmbSTAFF_TRAIN_RESULT.Items.Add("수료증첨부");
            cmbSTAFF_TRAIN_RESULT.Items.Add("기타");


            cmbSTAFF_TRAIN_ORG.Items.Clear();
            cmbSTAFF_TRAIN_ORG.Items.Add("KTR");
            cmbSTAFF_TRAIN_ORG.Items.Add("KOTICA");
            cmbSTAFF_TRAIN_ORG.Items.Add("KTL");
            cmbSTAFF_TRAIN_ORG.Items.Add("식약처");
            cmbSTAFF_TRAIN_ORG.Items.Add("직접입력");


            //txtSTAFF_TRAIN_RESULT.Text = "교육자료첨부, 수료증첨부";

            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select a.ORG_NAME+'_'+b.EDU_NAME, a.ORG_CODE, b.EDU_CODE from PQMS_ORG a ";
            query += "inner join PQMS_EDU b on a.ORG_CODE = b.EDU_ORG_CODE and a.SITE_CODE = b.SITE_CODE and a.REPOSITORY_CODE = b.REPOSITORY_CODE and a.WS_CODE = b.WS_CODE ";
            query += " where a.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and a.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and a.WS_CODE = '" + Form1PQMS_Repo.sWS + "' order by a.ORG_CODE, b.EDU_CODE ";


            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    tCmb.Items.Clear();

                    while (reader.Read())
                    {
                        //tCmb.Items.Add(reader.GetValue(0).ToString() + "/" + reader.GetValue(1).ToString() + "/" + reader.GetValue(2).ToString());
                        //tCmb.Items.Add(reader.GetValue(0).ToString() + "/" + reader.GetValue(1).ToString() + "/" + reader.GetValue(2).ToString());

                        string text = reader.GetValue(0).ToString(); // 
                        string value = reader.GetValue(1).ToString() + "/" + reader.GetValue(2).ToString(); //

                        comboBoxData[text] = value;

                        tCmb.Items.Add(text);
                    }
                }
                tCmb.Items.Add("기타");
            }
            Conn.Close();
        }

        private void Call_listStaff_ROLE()
        {
            Form2PQMS_STAFF_ROLE_Form13Set.listSTAFF_ROLE = new Dictionary<string, string>();
            Form2PQMS_STAFF_ROLE_Form13Set.Select();

            for (int i = 0; i < Form2PQMS_STAFF_ROLE_Form13Set.GetRowCount(); i++)
            {
                Form2PQMS_STAFF_ROLE_Form13Set.Fetch(i);

                Form2PQMS_STAFF_ROLE_Form13Set.listSTAFF_ROLE.Add(i.ToString(), Form2PQMS_STAFF_ROLE_Form13Set.sROLE_CODE);
            }

            cmbSTAFF_EDU_ORG_CODE.DataSource = new BindingSource(Form2PQMS_STAFF_ROLE_Form13Set.listSTAFF_ROLE, null);
            cmbSTAFF_EDU_ORG_CODE.DisplayMember = "Value";
        }

        private void Call_list_PQMS_ORG()
        {
            Form2PQMS_ORG_Form5Set.listPQMS_ORG_CODE = new Dictionary<string, string>();
            Form2PQMS_ORG_Form5Set.listPQMS_ORG_NAME = new Dictionary<string, string>();
            Form2PQMS_ORG_Form5Set.Select();

            for (int i = 0; i < Form2PQMS_ORG_Form5Set.GetRowCount(); i++)
            {
                Form2PQMS_ORG_Form5Set.Fetch(i);
                Form2PQMS_ORG_Form5Set.listPQMS_ORG_CODE.Add(i.ToString(), Form2PQMS_ORG_Form5Set.sORG_CODE);
                Form2PQMS_ORG_Form5Set.listPQMS_ORG_NAME.Add(i.ToString(), Form2PQMS_ORG_Form5Set.sORG_NAME);
            }

            cmbSTAFF_EDU_ORG_CODE.DataSource = new BindingSource(Form2PQMS_ORG_Form5Set.listPQMS_ORG_CODE, null);
            cmbSTAFF_EDU_ORG_CODE.DisplayMember = "Value";

            cmbSTAFF_EDU_EXEC_ORG.DataSource = new BindingSource(Form2PQMS_ORG_Form5Set.listPQMS_ORG_NAME, null);
            cmbSTAFF_EDU_EXEC_ORG.DisplayMember = "Value";
        }




        private void CALL_PQMS_RP_TRANING_FILDER()
        {
            //트래이닝폴더관리 조회 사번이 key 
            try
            {
                Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.Select();

                if (Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE_PAPER_TRANING_FOLDER_MainGrid, Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet);
                    AppHelper.SetGridDataSource(PQMS_STAFF_TR_FOLDER_InfoGrid, Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet);

                    btn_9.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    btn_9.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("트래이닝폴더관리 조회 실패!" + f.Message.ToString());
            }
        }


        public void CAll_PQMS_EACH_LIST()
        {
            // 개인별업무자료 조회 - '사번'이 Key
            try
            {
                Form2PQMS_ROLE2_EACH_LIST_InfoGridSet.Select();

                if (Form2PQMS_ROLE2_EACH_LIST_InfoGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_EACH_LISTMainGrid, Form2PQMS_ROLE2_EACH_LIST_InfoGridSet);
                    btn_5.BackColor = Color.FromArgb(0, 192, 0); //버튼색상변경 
                }
                else
                {
                    btn_5.BackColor = Color.FromArgb(255, 192, 192); //버튼색상변경 
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("시험수행능력평가 조회 실패!" + f.Message.ToString());
            }
        }


        private void Call_PQMS_Main_Staff_Ver2()
        {
            if (string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName) == true)
            {
                MessageBox.Show("조직도를 먼저 선택해주세요.");
                return;
            }

            string rdbValue = "";
            string cmbGroup1codeValue = "";
            bool bRdbStaffResignationValue = false;
            string sSort = "";

            rdbValue = cmb_Main_ORGCode.Text.Substring(0, 4);
            if (cmbMain_Group1Code.Text != null && cmbMain_Group1Code.Text != "")
            {
                cmbGroup1codeValue = cmbMain_Group1Code.Text.Substring(0, 4);
            }

            if (cmbMain_StaffStatus.Text == "재직자")
            {
                bRdbStaffResignationValue = false;
            }
            else
            {
                bRdbStaffResignationValue = true;
            }

            if (cmbSTAFFSORT.Text == "관리번호")
            {
                sSort = "STAFF_CODE";
            }
            else if (cmbSTAFFSORT.Text == "성명")
            {
                sSort = "STAFF_NAME";
            }
            else if (cmbSTAFFSORT.Text == "사번")
            {
                sSort = "STAFF_EMPNO";
            }

            try
            {
                AppHelper.RefreshGridData(PQMS_STAFF_AllGridView);

                if (rdbValue.Equals("0001"))
                {
                    // 컬럼 보이기
                    PQMS_STAFF_AllGridView.Bands["gridBand1"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = false;

                    Form2Set.Select_StaffKolasTopTeam(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue, cmbGroup1codeValue, sSort);
                    if (Form2Set.RowCount > 0)
                    {
                        AppHelper.SetGridDataSource(PQMS_STAFF_AllGrid, Form2Set);
                        //MessageBox.Show("KOLAS 조회 성공!");
                    }
                    else
                    {
                        //MessageBox.Show("조회된 값이 없습니다.");
                    }
                }
                else
                {
                    //// 컬럼 안보이기
                    PQMS_STAFF_AllGridView.Bands["gridBand1"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = true;

                    Form2Set.Select_StaffFoodTopTeam(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue, cmbGroup1codeValue, sSort);
                    if (Form2Set.RowCount > 0)
                    {
                        AppHelper.SetGridDataSource(PQMS_STAFF_AllGrid, Form2Set);
                        //MessageBox.Show("식약처 조회 성공!");
                    }
                    else
                    {
                        //MessageBox.Show("조회된 값이 없습니다.");
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
        }

        private void Call_PQMS_Main_Staff_User_Ver2()
        {
            if (string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName) == true)
            {
                MessageBox.Show("조직도를 먼저 선택해주세요.");
                return;
            }

            string rdbValue = "";
            string cmbGroup1codeValue = "";
            bool bRdbStaffResignationValue = false;
            string sSort = "";

            rdbValue = cmb_Main_ORGCode.Text.Substring(0, 4);
            if (cmbMain_Group1Code.Text != null && cmbMain_Group1Code.Text != "")
            {
                cmbGroup1codeValue = cmbMain_Group1Code.Text.Substring(0, 4);
            }

            if (cmbMain_StaffStatus.Text == "재직자")
            {
                bRdbStaffResignationValue = false;
            }
            else
            {
                bRdbStaffResignationValue = true;
            }

            if (cmbSTAFFSORT.Text == "관리번호")
            {
                sSort = "STAFF_CODE";
            }
            else if (cmbSTAFFSORT.Text == "성명")
            {
                sSort = "STAFF_NAME";
            }
            else if (cmbSTAFFSORT.Text == "사번")
            {
                sSort = "STAFF_EMPNO";
            }

            try
            {
                AppHelper.RefreshGridData(PQMS_STAFF_AllGridView);

                if (rdbValue.Equals("0001"))
                {
                    // 컬럼 보이기
                    PQMS_STAFF_AllGridView.Bands["gridBand1"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = false;

                    Form2Set.Select_StaffKolasTopTeam_User(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue, cmbGroup1codeValue, sSort);
                    if (Form2Set.RowCount > 0)
                    {
                        AppHelper.SetGridDataSource(PQMS_STAFF_AllGrid, Form2Set);
                        //MessageBox.Show("KOLAS 조회 성공!");
                    }
                    else
                    {
                        //MessageBox.Show("조회된 값이 없습니다.");
                    }
                }
                else
                {
                    // 컬럼 안보이기
                    PQMS_STAFF_AllGridView.Bands["gridBand1"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = true;

                    Form2Set.Select_StaffFoodTopTeam_User(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue, cmbGroup1codeValue, sSort);
                    if (Form2Set.RowCount > 0)
                    {
                        AppHelper.SetGridDataSource(PQMS_STAFF_AllGrid, Form2Set);
                        //MessageBox.Show("식약처 조회 성공!");
                    }
                    else
                    {
                        //MessageBox.Show("조회된 값이 없습니다.");
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
        }

        private void exportExcel(DevExpress.XtraGrid.GridControl GridName)
        {
            string fileName = "";

            SaveFileDialog saveFile = new SaveFileDialog();

            // 다이얼 로그가 Open되었을 때 최초의 경로 설정
            //saveFile.InitialDirectory = @"C:";   

            // 다이얼 로그의 제목
            saveFile.Title = "Excel 저장 위치 지정";

            // 기본 확장자
            saveFile.DefaultExt = "xlsx";

            // 파일 목록 필터링
            saveFile.Filter = "Xlsx files(*.xlsx)|*.xlsx";

            // OK버튼을 눌렀을때의 동작
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                // 경로와 파일명을 fileName에 저장
                fileName = saveFile.FileName.ToString();
            }
            else
            {
                return;
            }

            if (string.IsNullOrEmpty(fileName) == false)
            {
                DevExpress.XtraPrinting.XlsxExportOptionsEx xlsxOptions = new DevExpress.XtraPrinting.XlsxExportOptionsEx();

                // 라인출력
                xlsxOptions.ShowGridLines = false;
                //xlsxOptions.BandedLayoutMode = default;
                //xlsxOptions.ShowColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
                //xlsxOptions.ShowBandHeaders = DevExpress.Utils.DefaultBoolean.False;

                // sheet 명
                xlsxOptions.SheetName = "자료검색";
                xlsxOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG;    // ExportType

                GridName.ExportToXlsx(@fileName, xlsxOptions);
                Process.Start(@fileName);
            }
        }

        private void exportDocx(DevExpress.XtraGrid.GridControl GridName)
        {
            string fileName = "";
            Document document = new Document();

            SaveFileDialog saveFile = new SaveFileDialog();

            // 다이얼 로그가 Open되었을 때 최초의 경로 설정
            //saveFile.InitialDirectory = @"C:";   

            // 다이얼 로그의 제목
            saveFile.Title = "Excel 저장 위치 지정";

            // 기본 확장자
            saveFile.DefaultExt = "xlsx";

            // 파일 목록 필터링
            saveFile.Filter = "Xlsx files(*.xls)|*.xlsx";

            // OK버튼을 눌렀을때의 동작
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                // 경로와 파일명을 fileName에 저장
                fileName = saveFile.FileName.ToString();
            }

            if (string.IsNullOrEmpty(fileName) == false)
            {
                GridName.ExportToDocx(@fileName);
                Process.Start(@fileName);
            }
        }

        private void Call_PQMS_Main_Edu(string sSTAFF_CODE = "")
        {
            // 교육자료
            Form2PQMS_STAFF_EDUSet.sSTAFF_CODE = sSTAFF_CODE;

            // 교육자료 조회 - '사번'이 Key
            try
            {
                Form2PQMS_STAFF_EDUSet.SelectSTAFF_EDU();

                if (Form2PQMS_STAFF_EDUSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_EDUGrid, Form2PQMS_STAFF_EDUSet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("교육자료 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
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

        private void Call_PQMS_Info_Certi(string sSTAFF_CODE = "")
        {
            Form2PQMS_STAFF_CERTISet.sSTAFF_CODE = sSTAFF_CODE;

            // 자격증자료 조회 - '사번'이 Key
            try
            {
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

        // 
        public void Call_PQMS_Main_Role(string sSTAFF_CODE = "")
        {
            // 직무자료
            Form2PQMS_STAFF_ROLESet.sSTAFF_CODE = sSTAFF_CODE;

            //get_folder_data_type2("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder); //직무자료 직무기관코드
            get_folder_data_type2_notin_ORG_CODE("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder); //직무자료 직무기관코드

            // 직무자료 조회 - '사번'이 Key
            try
            {
                Form2PQMS_STAFF_ROLESet.SelectSTAFF_ROLE();

                if (Form2PQMS_STAFF_ROLESet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_ROLEGrid, Form2PQMS_STAFF_ROLESet);

                    //그리드의 데이터 확인해서 SGSKOREA인경우는 임명장버튼 색상 변경 안되게 처리     
                    int rowCount = PQMS_STAFF_ROLEGridView.RowCount; //
                    if (rowCount > 1)
                    {
                        btn_8.BackColor = Color.FromArgb(0, 192, 0);
                    }
                    else
                    {
                        btn_8.BackColor = Color.FromArgb(255, 192, 192);
                    }
                    
                }
                else
                {
                    btn_8.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("직무자료 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
        }

        private void Call_PQMS_Info_Role(string sSTAFF_CODE = "")
        {
            // 직무자료
            Form2PQMS_STAFF_ROLEGridInfoSet.sSTAFF_CODE = sSTAFF_CODE;

            // 직무자료 조회 - '사번'이 Key
            try
            {
                Form2PQMS_STAFF_ROLEGridInfoSet.SelectSTAFF_ROLE();

                if (Form2PQMS_STAFF_ROLEGridInfoSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_ROLE_InfoGrid, Form2PQMS_STAFF_ROLEGridInfoSet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("직무자료 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
        }

        public void Call_PQMS_STAFF_TRAINING()
        {
            // 교육보고서 조회 - '사번'이 Key
            // Main 화면에서 사번 값을 받아옴
            try
            {
                get_folder_data7(cmbEduOrg2);//교육과정 가져오기

                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Select();
                
                if (Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(Form2PQMS_STAFF_TRAINING_MainGrid, Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet);

                    //교육보고서 데이터 있으면 상단 버튼 색상 변경 
                    btn_3.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    //교육보고서 데이터 없으면 상단 버튼 색상 변경 
                    btn_3.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("교육보고서 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
        }

        private void Call_PQMS_STAFF_TRAINING_Info()
        {
            // 교육보고서 조회 - '사번'이 Key
            // Main 화면에서 사번 값을 받아옴
            try
            {
                //jhm
                //get_folder_data7(cmbEduOrg2);

                Form2PQMS_PQMS_STAFF_TRAINING_InfoGridSet.Select();

                if (Form2PQMS_PQMS_STAFF_TRAINING_InfoGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_TRAINING_InfoGrid, Form2PQMS_PQMS_STAFF_TRAINING_InfoGridSet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("교육보고서 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
        }

        public void Call_PQMS_STAFF_ROLE_PAPER()
        {
            get_folder_RolePaper(cmbRolePaper); // 직무기술서 코드
            get_folder_data_type2_notin_ORG_CODE("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbRPORGCODE); //직무기술서 직무기관코드 


            txtSTAFF_RP_CAREER.Text = "한국에스지에스(년/월/일 ~ 현재)";
            txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.Text = "업무대리인 이름 기입";
            txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.Text = "기술책임자";

            // 직무기술서 조회 - '사번'이 Key
            try
            {
                //직무기술서 그리드..
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.Select();
                if (Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_ROLE_PAPERMainGrid, Form2PQMS_STAFF_ROLE_PAPER_MainGridSet);
                    AppHelper.SetGridDataSource(PQMS_STAFF_ROLE_PAPER_InfoGrid, Form2PQMS_STAFF_ROLE_PAPER_MainGridSet); // 현황정보 직무기술서 

                    //직무기술서 있을경우 Index 색상 변경  
                    btn_6.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    //직무기술서 없을경우 Index 색상 변경  
                    btn_6.BackColor = Color.FromArgb(255, 192, 192);
                }


                //////직무기술서 오른쪽 그리드     
                ////Form2PQMS_STAFF_ROLE_PAPER_FinalGridSet.Select();
                ////if (Form2PQMS_STAFF_ROLE_PAPER_FinalGridSet.Empty == false)
                ////{
                ////    AppHelper.SetGridDataSource(PQMS_STAFF_ROLE_PAPERFinalGrid, Form2PQMS_STAFF_ROLE_PAPER_FinalGridSet);
                ////}
                PQMS_STAFF_ROLE_PAPERFinalGridView.Columns.View.FocusInvalidRow(); // 첫 로드시 포커스 없어서 style적용 되지 않도록 

                //직무기술서 수행평가이력 리스트 가져오기 
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Select_RP();
                if (Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_RP_ROLE2_EACH_LISTGrid, Form2PQMS_ROLE2_EACH_LIST_MainGridSet);
                }
                // 직무기술서 교육보고서 자료 가져오기  
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Select();
                if (Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(Form2PQMS_STAFF_RP_TRAINING_Grid, Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet);
                }


            }
            catch (Exception f)
            {
                MessageBox.Show("직무기술서 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
        }




        private void get_folder_certi_data(string tTable, string tField1, string tField2, ComboBox tCmb)
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


        private void get_folder_data_type2_notin_ORG_CODE(string tTable, string tField1, string tField2, ComboBox tCmb)//tField1 = 검색테이블         //tField2 = 검색필드1        //tField3 = 검색필드2       
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            query = query + " AND   ORG_CODE not in ('0006', '0007' ) ";          
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


        private void get_folder_data_type2(string tTable, string tField1, string tField2, ComboBox tCmb)//tField1 = 검색테이블         //tField2 = 검색필드1        //tField3 = 검색필드2       
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

            if (tCmb.ToString() == "cmbFolder" || tCmb.ToString() == "cmbRPORGCODE")
            {
                query = query + " AND   ORG_CODE not in ('0006', '0007' ) "; 
            }
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


        private void get_folder_data5_type2(string tTable, string tField1, string tField2, string torgcode, string tgroup1code, System.Windows.Forms.ComboBox tCmb)        //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where GROUP2_ORG_CODE = '" + torgcode + "'";
            query = query + " and GROUP2_GROUP1_CODE = '" + tgroup1code + "'";
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
                        string text = reader[tField2].ToString(); // 
                        string value = reader[tField1].ToString(); //

                        comboBoxData[text] = value;

                        tCmb.Items.Add(text);
                    }
                }
            }

            Conn.Close();

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

        private void get_folder_data2(string tTable, string tField1, string tField2, string tField3, string tField4, System.Windows.Forms.ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2
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
                        tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                    }
                }
            }

            Conn.Close();

        }

        private void get_folder_data3(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


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

        private void get_folder_data5(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + "  where GROUP2_ORG_CODE = '" + txtSTAFF_ROLE_ORG_CODE.Text + "'";
            query = query + "  and GROUP2_GROUP1_CODE = '" + txtGroup1Code.Text + "'";
            query = query + "  and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            query = query + "  order by " + tField1 + "," + tField2;

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


        private void get_folder_data5(string tTable, string tField1, string tField2, string torgcode, string tgroup1code, System.Windows.Forms.ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where GROUP2_ORG_CODE = '" + torgcode + "'";
            query = query + " and GROUP2_GROUP1_CODE = '" + tgroup1code + "'";
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
                        tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                    }
                }
            }

            Conn.Close();

        }


        private void get_folder_data2_Gisool(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + "  where GROUP2_ORG_CODE = '" + txtSTAFF_ROLE_ORG_CODE_EACH_LIST.Text + "'";
            query = query + "    and GROUP2_GROUP1_CODE = '" + txtMainLIST_GROUP1_EACH_LIST.Text + "'";
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

        private string OpenFile()
        {
            openFileDialog1.Filter = "*.*|*.*";
            //openFileDialog1.Filter = "Photo (*.jpeg*)|*.jpg*";
            openFileDialog1.Title = "Choose a file or ";

            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }

            return string.Empty;
        }

        private void get_folder_data4(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


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

        private void get_folder_data6_type2(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)        //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2

        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where ROLE_ORG_CODE = '" + txtSTAFF_ROLE_ORG_CODE.Text + "'";
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

        private void SetToMain()
        {
            PQMS_STAFF_MainPageRows.Clear();
            for (int i = 0; i < Form2Set.RowCount; i++)
            {
                Form2Set.Fetch(i);

                Form2PQMS_STAFF_MainPageRow PQMS_STAFF_MainPageRow = new Form2PQMS_STAFF_MainPageRow();
                PQMS_STAFF_MainPageRow.sSTAFF_CODE = Form2Set.sSTAFF_CODE;
                PQMS_STAFF_MainPageRow.sSTAFF_TEAM = Form2Set.sSTAFF_TEAM;
                PQMS_STAFF_MainPageRow.sSTAFF_NAME = Form2Set.sSTAFF_NAME;
                PQMS_STAFF_MainPageRow.sSTAFF_ROLE_NAME = Form2Set.sSTAFF_ROLE_NAME;
                PQMS_STAFF_MainPageRow.sSTAFF_ROLE_CLASS = Form2Set.sSTAFF_ROLE_CLASS;
                PQMS_STAFF_MainPageRow.sPQMS_STAFF_EDU_TO = Form2Set.sSTAFF_EDU_TO;
                PQMS_STAFF_MainPageRow.sSTAFF_EDU_TO_MEASUREMENT_UNCERTAINTY = Form2Set.sSTAFF_EDU_TO_MEASUREMENT_UNCERTAINTY;
                PQMS_STAFF_MainPageRow.sSTAFF_EDU_TO_CONSERVATIVE_EDUCATION = Form2Set.sSTAFF_EDU_TO_CONSERVATIVE_EDUCATION;
                PQMS_STAFF_MainPageRows.Add(PQMS_STAFF_MainPageRow);
            }

            STAFF_CODEAllColumn.SortOrder = ColumnSortOrder.Ascending;
        }

        private void SetTo_MEASUREMENT_UNCERTAINTY()
        {
            PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRows.Clear();
            for (int i = 0; i < Form2_MEASUREMENT_UNCERTAINTY_MainSTAFFSet.RowCount; i++)
            {
                Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow = new Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow();
                Form2_MEASUREMENT_UNCERTAINTY_MainSTAFFSet.Fetch(i);

                Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow.sSTAFF_CODE = Form2_MEASUREMENT_UNCERTAINTY_MainSTAFFSet.sSTAFF_CODE;
                Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow.sSTAFF_EDU_TO = Form2_MEASUREMENT_UNCERTAINTY_MainSTAFFSet.sSTAFF_EDU_TO;
                PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRows.Add(Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow);
            }
        }

        private void SetTo_CONSERVATIVE_EDUCATION()
        {
            Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow = new Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow();

            PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRows.Clear();
            for (int i = 0; i < Form2_CONSERVATIVE_EDUCATION_MainSTAFFSet.RowCount; i++)
            {
                Form2_CONSERVATIVE_EDUCATION_MainSTAFFSet.Fetch(i);

                Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow.sSTAFF_CODE = Form2_CONSERVATIVE_EDUCATION_MainSTAFFSet.sSTAFF_CODE;
                Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow.sSTAFF_EDU_TO = Form2_CONSERVATIVE_EDUCATION_MainSTAFFSet.sSTAFF_EDU_TO;
                PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRows.Add(Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow);
            }
        }

        private void ConverTotable(DataTable dt, Table tb)
        {
            //convert dt to tb
            int firstdatarow;

            firstdatarow = tb.Rows.Count - 1;
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

        public void Call_STAFF_Main_Info(string sStaff_cdoe = "")
        {
            try
            {
                Form2PQMS_STAFF_MainSTAFFSet.SelectSTAFF_STAFF(sStaff_cdoe);

                //Form2PQMS_STAFF_MainSTAFFSet.SelectSTAFF_Workspace();

                if (Form2PQMS_STAFF_MainSTAFFSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_MainGrid, Form2PQMS_STAFF_MainSTAFFSet);
                    
                    int rowCount = PQMS_STAFFMainGridView.RowCount;

                    if (rowCount >= 1)
                    {
                        btn_1.BackColor = Color.FromArgb(0, 192, 0);
                    }
                    else
                    {
                        btn_1.BackColor = Color.FromArgb(255, 192, 192);
                    }

                }
                else
                {
                    btn_1.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("기본자료 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
        }
        public void Call_STAFF_Main_Pre_Info(string sStaff_cdoe = "")
        {
            try
            {
                Form2PQMS_STAFF_MainPreSTAFFSet.SelectSTAFF_PreSTAFF(sStaff_cdoe);

                //Form2PQMS_STAFF_MainSTAFFSet.SelectSTAFF_Workspace();

                if (Form2PQMS_STAFF_MainPreSTAFFSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_PreSTAFFMainGrid, Form2PQMS_STAFF_MainPreSTAFFSet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("기본자료 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
        }

        public void Call_STAFF_Main_Tab_Now_Info(string sStaff_cdoe = "")
        {
            try
            {
                Form2PQMS_STAFF_MainSTAFFSet.SelectSTAFF_STAFF(sStaff_cdoe);

                //Form2PQMS_STAFF_MainSTAFFSet.SelectSTAFF_Workspace();

                if (Form2PQMS_STAFF_MainSTAFFSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_InfoMainGrid, Form2PQMS_STAFF_MainSTAFFSet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("기본자료 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
        }

        private void btnStaffInsert_Click(object sender, EventArgs e)
        {
            if (txtSTAFF_EMPNO.Text == "")
            {
                MessageBox.Show("EmpNo가 입력되지 않았습니다. D&I 관리자에게 문의하세요.");
                return;
            }
            if (txtSTAFF_TEAM.Text == "")
            {
                MessageBox.Show("부서를 선택하세요.");
                return;
            }

            Form2PQMS_STAFF_Workspace_Set.sFOLDERNAME = txtSTAFF_TEAM.Text;
            Form2PQMS_STAFF_Workspace_Set.SelectSTAFF_STAFFTEAM();
            Form2PQMS_STAFF_Workspace_Set.Fetch();

            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {

                //서약서파일 추가

                if (string.IsNullOrEmpty(txtSTAFF_File.Text) == false)
                {

                    string rpt = txtSTAFF_File.Text;
                    string sfileName = Path.GetFileNameWithoutExtension(rpt);
                    string sExtensionName = Path.GetExtension(rpt);
                    string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                    string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                    string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "서약서" + @"\" + sDateTime_yyyyMM;

                    DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                    if (file_di.Exists == false)
                    {
                        Directory.CreateDirectory(savrfilepath);
                    }

                    string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;
                    File.Copy(rpt, savefile, true);

                    txtSTAFF_File.Text = savefile;

                }

                Form2Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
                Form2Set.sSTAFF_NAME = txtSTAFF_NAME.Text;
                Form2Set.sSTAFF_TEAM = Form2PQMS_STAFF_Workspace_Set.sSTAFF_TEAM;
                Form2Set.sSTAFF_JOIN_DATE = txtSTAFF_JOIN_DATE.Text;
                Form2Set.sSTAFF_MAJOR = txtSTAFF_MAJOR.Text;
                Form2Set.sSTAFF_SCHOOL = txtSTAFF_SCHOOL.Text;
                Form2Set.sSTAFF_RESIGNATION_DATE = txtSTAFF_RESIGNATION_DATE.Text;
                Form2Set.sSTAFF_EMPNO = txtSTAFF_EMPNO.Text;
                Form2Set.sSTAFF_ACCOUNTNO = txtSTAFF_ACCOUNTNO.Text;
                Form2Set.sSTAFF_FILE = txtSTAFF_File.Text;

                Form2Set.Insert(trans);
                //Form2Set.Insert_role(trans); //ROLE 강제입력 
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");

                //// 교육자료 조회
                //Call_PQMS_Main_Edu(PQMS_STAFF_EDUMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void btnStaffUpdate_Click(object sender, EventArgs e)
        {
            Form2PQMS_STAFF_Workspace_Set.sFOLDERNAME = txtSTAFF_TEAM.Text;
            Form2PQMS_STAFF_Workspace_Set.SelectSTAFF_STAFFTEAM();
            Form2PQMS_STAFF_Workspace_Set.Fetch();

            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                if (string.IsNullOrEmpty(txtSTAFF_File.Text) == false)
                {
                    FileInfo fi = new FileInfo(txtSTAFF_File.Text);

                    if (txtSTAFF_File.Text.ToString().ToUpper().Contains(unitCommon.sFileServerName) == true)
                    {
                        if (fi.Exists == false) //
                        {
                            string rpt = txtSTAFF_File.Text;
                            string sfileName = Path.GetFileNameWithoutExtension(rpt);
                            string sExtensionName = Path.GetExtension(rpt);
                            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                            string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "서약서" + @"\" + sDateTime_yyyyMM;
                            DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                            if (file_di.Exists == false)
                            {
                                Directory.CreateDirectory(savrfilepath);
                            }

                            string savefile = savrfilepath + @"\" + sfileName + "_수정된" + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                            File.Copy(rpt, savefile, true);


                            txtSTAFF_File.Text = savefile;
                        }
                    }
                    else
                    {
                        string rpt = txtSTAFF_File.Text;
                        string sfileName = Path.GetFileNameWithoutExtension(rpt);
                        string sExtensionName = Path.GetExtension(rpt);
                        string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                        string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                        string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "서약서" + @"\" + sDateTime_yyyyMM;
                        DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                        if (file_di.Exists == false)
                        {
                            Directory.CreateDirectory(savrfilepath);
                        }

                        string savefile = savrfilepath + @"\" + sfileName + "_수정된" + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                        File.Copy(rpt, savefile, true);

                        txtSTAFF_File.Text = savefile;
                    }
                }

                Form2Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
                Form2Set.sSTAFF_NAME = txtSTAFF_NAME.Text;
                Form2Set.sSTAFF_TEAM = Form2PQMS_STAFF_Workspace_Set.sSTAFF_TEAM;
                Form2Set.sSTAFF_JOIN_DATE = txtSTAFF_JOIN_DATE.Text;
                Form2Set.sSTAFF_MAJOR = txtSTAFF_MAJOR.Text;
                Form2Set.sSTAFF_SCHOOL = txtSTAFF_SCHOOL.Text;
                Form2Set.sSTAFF_RESIGNATION_DATE = txtSTAFF_RESIGNATION_DATE.Text;
                Form2Set.sSTAFF_EMPNO = txtSTAFF_EMPNO.Text;
                Form2Set.sSTAFF_ACCOUNTNO = txtSTAFF_ACCOUNTNO.Text;
                Form2Set.sSTAFF_FILE = txtSTAFF_File.Text;


                Form2Set.Update(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("수정 완료!");
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("수정 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void btnStaffDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2Set.sSTAFF_CODE = txtSTAFF_CODE.Text;

                Form2Set.Delete(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("삭제 완료!");
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Site, Repository, WorkSpace 확인!");
            //Get_Data("K_WORKSPACE");
            Get_Upload_Data(0);
            LoadTreeViewFromDB4(dgvOrg, trvItems);
        }

        public void Call_Get_Data(string tTable)
        {
            Get_Data(tTable);
            Get_Upload_Data(0);
            LoadTreeViewFromDB4(dgvOrg, trvItems);
        }

        private void Get_Data(string tTable)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            dgvData.Rows.Clear();

            string query = "";

            query = " select * from " + tTable;
            query = query + "  where 1= 1 ";
            query = query + "  and SITE_CODE = '" + txtSiteCode.Text + "'";
            query = query + "  and REPOSITORY_CODE = '" + txtSiteCode.Text + "'";
            query = query + "  and WS_CODE = '" + txtWSCode.Text + "'";
            query = query + "      order by  SITE_CODE, REPOSITORY_CODE, WS_CODE, FOLDER_CODE, BOARD_CODE, GROUP_CODE, SUBGROUP_CODE";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            dgvData.RowCount = 100;

            int i, wRowNo;
            wRowNo = 0;

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dgvData.ColumnCount = reader.FieldCount + 1;

                    for (i = 1; i < reader.FieldCount + 1; i++)
                    {
                        dgvData.Columns[i].HeaderText = reader.GetName(i - 1).ToString();
                        if (i == 1)
                        {
                            //dgvData.Columns[i].Width = 40;
                            //dgvData.Columns[i].Visible = false;

                            dgvData.Columns[i].Width = 100;
                            dgvData.Columns[i].Visible = true;
                        }
                        else
                        {
                            if (i == 2)
                            {
                                dgvData.Columns[i].Width = 400;
                            }
                            else
                            {
                                dgvData.Columns[i].Width = 400;
                            }
                        }
                    }

                    while (reader.Read())
                    {
                        dgvData.Rows[wRowNo].Cells[0].Value = false;
                        for (i = 0; i < reader.FieldCount; i++)
                        {
                            dgvData.Rows[wRowNo].Cells[i + 1].Value = reader.GetValue(i);
                        }
                        wRowNo = wRowNo + 1;
                        dgvData.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();

                    }
                }
            }
            if (wRowNo > 0)
            {
                dgvData.RowCount = wRowNo + 1;
            }
            else
            {
                dgvData.RowCount = 1;
            }

            Conn.Close();
        }

        private void Get_Upload_Data(int k)
        {
            string query = "";
            //query = "select * ";
            //query = query + " from Organization";

            //if (k == 0)
            //{
            //    query = " select * from K_WORKSPACE ";
            //    query = query + "  where 1= 1 ";
            //    query = query + "  and SITE_CODE = '" + txtSiteCode.Text + "'";
            //    query = query + "  and REPOSITORY_CODE = '" + txtRepoCode.Text + "'";
            //    query = query + "  and WS_CODE = '" + txtWSCode.Text + "'";
            //    query = query + "      order by  SITE_CODE, REPOSITORY_CODE, WS_CODE, FOLDER_CODE, BOARD_CODE, GROUP_CODE, SUBGROUP_CODE";

            //}

            if (k == 0)
            {
                query = " select * from K_WORKSPACE ";
                query = query + "  where 1= 1 ";
                //query = query + "  and SITE_CODE = '" + txtSiteCode.Text + "'";
                //query = query + "  and REPOSITORY_CODE = '" + txtRepoCode.Text + "'";
                //query = query + "  and WS_CODE = '" + txtWSCode.Text + "'";
                query = query + "  and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "'";
                query = query + "  and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'";
                query = query + "  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
                query = query + "  and isnull(BOARD_CODE, '' ) ='' ";
                query = query + "      order by  SITE_CODE, REPOSITORY_CODE, WS_CODE, FOLDER_CODE, BOARD_CODE, GROUP_CODE, SUBGROUP_CODE";

            }

            if (k == 1)
            {
                //query = " select CODE_PK, P_CODE, CODE_SEQ, CODE_NO, CODE_NAME, CODE_LEVEL from GUIDE_DB06 ";
                //query = query + " where CODE_PK <> 0 ";
                //query = query + " order by CODE_SEQ ";
            }

            Conn = new OleDbConnection(unitCommon.connect_string);

            OleDbCommand cmd = new OleDbCommand(query, Conn);


            Conn.Open();

            dgvOrg.Rows.Clear();
            dgvOrg.RowCount = 1000;

            int wRowNo, i;
            wRowNo = 0;

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dgvOrg.ColumnCount = reader.FieldCount;

                for (i = 0; i < reader.FieldCount; i++)
                {
                    dgvOrg.Columns[i].HeaderText = reader.GetName(i).ToString();
                    dgvOrg.Columns[i].Width = 120;
                }

                while (reader.Read())
                {
                    for (i = 0; i < reader.FieldCount; i++)
                    {
                        dgvOrg.Rows[wRowNo].Cells[i].Value = reader.GetValue(i);
                    }
                    //dgvOrg.Rows[wRowNo].Cells[0].Value = wRowNo;

                    wRowNo = wRowNo + 1;
                    dgvOrg.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();

                }
            }
            if (wRowNo > 0)
            {
                dgvOrg.RowCount = wRowNo + 1;
            }
            else
            {
                dgvOrg.RowCount = 1;
            }

            Conn.Close();

            txtRowCnt.Text = Convert.ToString(dgvOrg.RowCount - 1);

        }

        private void LoadTreeViewFromDB4(DataGridView dgv, TreeView trv)
        {
            trv.Nodes.Clear();

            Dictionary<int, TreeNode> parents =
                new Dictionary<int, TreeNode>();

            string nodekey = "";
            string nodetext = "";

            int level = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Index < Convert.ToInt32(txtRowCnt.Text))
                {
                    //nodekey = row.Index.ToString();
                    nodekey = row.Cells[2].Value.ToString();
                    nodekey = nodekey + row.Cells[4].Value.ToString();
                    nodekey = nodekey + row.Cells[6].Value.ToString();
                    nodekey = nodekey + row.Cells[8].Value.ToString();
                    nodekey = nodekey + row.Cells[10].Value.ToString();

                    //nodetext
                    if (row.Cells[3].Value.ToString().Trim() != "") nodetext = row.Cells[3].Value.ToString();
                    if (row.Cells[5].Value.ToString().Trim() != "") nodetext = row.Cells[5].Value.ToString();
                    if (row.Cells[7].Value.ToString().Trim() != "") nodetext = row.Cells[7].Value.ToString();
                    if (row.Cells[9].Value.ToString().Trim() != "") nodetext = row.Cells[9].Value.ToString();
                    if (row.Cells[11].Value.ToString().Trim() != "") nodetext = row.Cells[11].Value.ToString();

                    if (row.Cells[2].Value.ToString().Trim() != "") level = 0;
                    if (row.Cells[4].Value.ToString().Trim() != "") level = 1;
                    if (row.Cells[6].Value.ToString().Trim() != "") level = 2;
                    if (row.Cells[8].Value.ToString().Trim() != "") level = 3;
                    if (row.Cells[10].Value.ToString().Trim() != "") level = 4;

                }
                // See how many tabs are at the start of the line.
                if (row.Index == 0)
                {
                    parents[level] = trv.Nodes.Add(nodekey, nodetext);
                }
                if (row.Index != 0 && row.Index < Convert.ToInt32(txtRowCnt.Text))
                {
                    parents[level] = parents[level - 1].Nodes.Add(nodekey, nodetext);
                    parents[level].EnsureVisible();
                }
            }

            if (trv.Nodes.Count > 0) trv.Nodes[0].EnsureVisible();
        }

        private void trvItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtNodeLevel.Text = e.Node.Level.ToString();
            txtNodeName.Text = e.Node.Name.ToString();
            txtNodeText.Text = e.Node.Text.ToString();


            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            get_comb_data("K_SITE", "SITE_CODE", "SITE_NAME", "", "", cmbSiteCode);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            get_comb_data("K_REPOSITORY", "REPOSITORY_CODE", "REPOSITORY_NAME", "SITE_CODE", txtSiteCode.Text, cmbRepo);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //get_ws_data("K_WORKSPACE", "WS_CODE", "WS_NAME", cmbWS, );
            get_ws_data("K_WORKSPACE", "WS_CODE", "WS_NAME", cmbWS, txtSiteCode.Text, txtRepoCode.Text);
        }

        public void Call_get_ws_data(string tTable, string tField1, string tField2, ComboBox tCmb, string sSiteCode, string sRepoCode)
        {
            get_ws_data(tTable, tField1, tField2, tCmb, sSiteCode, sRepoCode);
        }

        private void get_ws_data(string tTable, string tField1, string tField2, ComboBox tCmb, string sSiteCode, string sRepoCode)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE  = '" + sSiteCode + "'";
            query = query + "   and REPOSITORY_CODE  = '" + sRepoCode + "'";
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

        public void Call_get_comb_data(string tTable, string tField1, string tField2, string tField3, string tField4, ComboBox tCmb)
        {
            get_comb_data(tTable, tField1, tField2, tField3, tField4, tCmb);
        }


        private void get_comb_data(string tTable, string tField1, string tField2, string tField3, string tField4, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2
        //tField4 = 조건필드
        //tField5 = 조건값

        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            if (tField3 == "")
            {
                query = " select " + tField1 + "," + tField2 + " from " + tTable;
                query = query + "      order by " + tField1;
            }
            else
            {
                query = " select " + tField1 + "," + tField2 + " from " + tTable;
                query = query + " where " + tField3 + " = '" + tField4 + "'";
                query = query + "      order by " + tField3 + "," + tField1;
            }


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

        private void cmbSiteCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSiteCode.Text = cmbSiteCode.Text.Substring(0, 4);
            txtSiteName.Text = cmbSiteCode.Text.Substring(5, cmbSiteCode.Text.Length - 5);
        }

        private void cmbRepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRepoCode.Text = cmbRepo.Text.Substring(0, 4);
            txtRepoName.Text = cmbRepo.Text.Substring(5, cmbRepo.Text.Length - 5);
        }

        private void cmbWS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWSCode.Text = cmbWS.Text.Substring(0, 5);
            txtWSName.Text = cmbWS.Text.Substring(6, cmbWS.Text.Length - 6);
        }

        private void btnLookUpData_Click(object sender, EventArgs e)
        {
            string rdbValue = "";

            if (rdbKOLAS.Checked)
            {
                rdbValue = "0001";
            }
            else
            {
                rdbValue = "0002";
            }

            try
            {
                AppHelper.RefreshGridData(PQMS_STAFF_AllGridView);

                if (rdbValue.Equals("0001"))
                {
                    Form2Set.Select_StaffKolasTopTeam(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue);
                    if (Form2Set.RowCount > 0)
                    {
                        AppHelper.SetGridDataSource(PQMS_STAFF_AllGrid, Form2Set);
                        MessageBox.Show("KOLAS 조회 성공!");
                    }
                    else
                    {
                        MessageBox.Show("조회된 값이 없습니다.");
                    }
                }
                else
                {
                    Form2Set.Select_StaffFoodTopTeam(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue);
                    if (Form2Set.RowCount > 0)
                    {
                        AppHelper.SetGridDataSource(PQMS_STAFF_AllGrid, Form2Set);
                        MessageBox.Show("식약처 조회 성공!");
                    }
                    else
                    {
                        MessageBox.Show("조회된 값이 없습니다.");
                    }
                }


            }
            catch (Exception f)
            {
                MessageBox.Show("조회 실패!" + f.Message.ToString());
            }

            //try
            //{
            //    Form2Set.Select_StaffTeam(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue);
            //    Form2_MEASUREMENT_UNCERTAINTY_MainSTAFFSet.Select_Top_MEASUREMENT_UNCERTAINTY();
            //    Form2_CONSERVATIVE_EDUCATION_MainSTAFFSet.Select_Top_CONSERVATIVE_EDUCATION();

            //    SetToMain();
            //    SetTo_MEASUREMENT_UNCERTAINTY();
            //    SetTo_CONSERVATIVE_EDUCATION();

            //    for (int i = 0; i < PQMS_STAFF_MainPageRows.Count; i++)
            //    {
            //        for (int j = 0; j < PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRows.Count; j++)
            //        {
            //            if (PQMS_STAFF_MainPageRows[i].sSTAFF_CODE.ToString().Equals(PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRows[j].sSTAFF_CODE.ToString()))
            //            {
            //                PQMS_STAFF_MainPageRows[i].sSTAFF_EDU_TO_MEASUREMENT_UNCERTAINTY = PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRows[j].sSTAFF_EDU_TO.ToString();
            //            }
            //        }
            //    }

            //    for (int i = 0; i < PQMS_STAFF_MainPageRows.Count; i++)
            //    {
            //        for (int j = 0; j < PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRows.Count; j++)
            //        {
            //            if (PQMS_STAFF_MainPageRows[i].sSTAFF_CODE.ToString().Equals(PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRows[j].sSTAFF_CODE.ToString()))
            //            {
            //                PQMS_STAFF_MainPageRows[i].sSTAFF_EDU_TO_CONSERVATIVE_EDUCATION = PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRows[j].sSTAFF_EDU_TO.ToString();
            //            }
            //        }
            //    }

            //    AppHelper.RefreshGridData(PQMS_STAFF_AllGridView);
            //    PQMS_STAFF_AllGrid.DataSource = PQMS_STAFF_MainPageRows;
            //    AppHelper.SetGridEvenRow(PQMS_STAFF_AllGridView);

            //    if (PQMS_STAFF_AllGridView.RowCount > 0)
            //    {
            //        //AppHelper.SetGridDataSource(PQMS_STAFF_AllGrid, PQMS_STAFF_MainPageRows);
            //        MessageBox.Show("조회 성공!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("조회된 값이 없습니다.");
            //    }
            //}
            //catch (Exception f)
            //{
            //    MessageBox.Show("조회 실패!" + f.Message.ToString());
            //}

            //btnLookUpData.Enabled = false;
        }

        private void PQMS_STAFFGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtSTAFF_CODE.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString();
            txtSTAFF_NAME.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_NAME"].ToString();
            txtSTAFF_TEAM.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["FOLDER_NAME"].ToString();
            txtSTAFF_JOIN_DATE.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_JOIN_DATE"].ToString();
            txtSTAFF_MAJOR.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_MAJOR"].ToString();
            txtSTAFF_SCHOOL.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_SCHOOL"].ToString();
            txtSTAFF_RESIGNATION_DATE.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_RESIGNATION_DATE"].ToString();
            txtSTAFF_EMPNO.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_EMPNO"].ToString();
            txtSTAFF_ACCOUNTNO.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["ACCOUNT_NO"].ToString();
            txtSTAFF_File.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_FILE"].ToString();


            if (PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_JOIN_DATE"].ToString().Trim() != "")
            {
                DateTime DT_Date = DateTime.Parse(PQMS_STAFFMainGridView.GetFocusedRowCellValue("STAFF_JOIN_DATE").ToString());
                dtSTAFF_JOIN_DATE.Value = DT_Date;
            }

            if (PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_RESIGNATION_DATE"].ToString().Trim() != "")
            {
                DateTime DT_Date = DateTime.Parse(PQMS_STAFFMainGridView.GetFocusedRowCellValue("STAFF_RESIGNATION_DATE").ToString());
                dtSTAFF_RESIGNATION_DATE.Value = DT_Date;
            }


            if (e.Column.Caption.Equals("서약서"))
            {
                string strFile = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }



        }

        private void PQMS_STAFF_EDUGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            Form2PQMS_STAFF_EDUSet.iIDX = Convert.ToInt32(PQMS_STAFF_EDUGridView.GetFocusedDataRow()["IDX"]);
            txtSTAFFCODE_EDU.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_CODE"].ToString();
            txtSTAFF_EDU_CLASS.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_CLASS"].ToString();
            txtEduOrgName.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["ORG_NAME"].ToString();
            txtEduName.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["EDU_NAME"].ToString();
            cmbSTAFF_EDU_EXEC_ORG.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_EXEC_ORG"].ToString();
            txtSTAFF_EDU_REPORT.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_REPORT"].ToString();
            txtSTAFF_EDU_FROM.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_FROM"].ToString();
            txtSTAFF_EDU_TO.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_TO"].ToString();
            txtSTAFF_EDU_HOURS.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_HOURS"].ToString();
            txtSTAFF_EDU_COMP_CERTI.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_COMP_CERTI"].ToString();
            txtSTAFF_EDU_PASS_CERTI.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_PASS_CERTI"].ToString();
            txtSTAFF_EDU_APPROVE_DATE.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_APPROVE"].ToString();
            txtSTAFF_EDU_APPRVAL.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_APPRVAL"].ToString();
            txtSTAFF_EDU_APPROVE.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_APPROVE"].ToString();
            txtSTAFF_EDU_STATUS.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_STATUS"].ToString();

            cmbSTAFF_EDU_ORG_CODE.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["EDU_ORG_CODE"].ToString();
            cmbEduOrg.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["EDU_ORG_CODE"].ToString() + " " + PQMS_STAFF_EDUGridView.GetFocusedDataRow()["ORG_NAME"].ToString();

            cmbEdu1.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["EDU_CODE"].ToString() + " " + PQMS_STAFF_EDUGridView.GetFocusedDataRow()["EDU_NAME"].ToString();
            txtSTAFF_EDU_CODE.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["EDU_CODE"].ToString();
        }

        private void PQMS_STAFF_CERTIGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
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

        private void PQMS_STAFF_ROLEGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_ROLE_APPROVE_STATUS = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["approveStatusCode"].ToString();

            Form2PQMS_STAFF_ROLESet.iIDX = Convert.ToInt32(PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["IDX"]);
            txtSTAFF_CODE_ROLE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_CODE"].ToString();
            txtSTAFF_ROLE_CLASS.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CLASS"].ToString();
            txtSTAFF_ROLE_ORG_CODE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_ORG_CODE"].ToString();
            cmbSTAFF_ROLE_CODE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CODE"].ToString();
            txtSTAFF_ROLE_NAME.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_NAME"].ToString();
            //cmbSTAFF_ROLE_STATUS.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_STATUS"].ToString();
            //cmbSTAFF_ROLE_GIVEN_CLASS.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_GIVEN_CLASS"].ToString();
            //cmbSTAFF_ROLE_CERTI.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CERTI"].ToString();
            //txtSTAFF_ROLE_INSTEAD.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_INSTEAD"].ToString();
            dtpOrder.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_DATE"].ToString();
            txtOrgName.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["ORG_NAME"].ToString();
            //cmbFolder.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["ORG_CODE"].ToString() + " " + PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["ORG_NAME"].ToString(); 

            cmbFolder.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["ORG_NAME"].ToString();

            txtBig.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP1_NAME"].ToString();
            txtMid.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_NAME"].ToString();

            txtGroup1Code.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP1_CODE"].ToString();
            txtGroup2Code.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_CODE"].ToString();

            //cmbGroup1.Text = txtGroup1Code.Text + " " + txtBig.Text;
            //cmbGroup2.Text = txtGroup2Code.Text + " " + txtMid.Text;

            //cmbRole.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CODE"].ToString() + " " + PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_NAME"].ToString();


            cmbGroup1.Text = txtBig.Text;
            cmbGroup2.Text = txtMid.Text;

            cmbRole.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_NAME"].ToString();


            //txtSTAFF_ROLE_STAFF_ROLE_NOTE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_NOTE"].ToString();

            //txtSTAFF_ROLE_QUALITY_DIR_FILE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_QUALITY_DIR_FILE"].ToString();
            //txtSTAFF_ROLE_TEST_DIR_FILE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_TEST_DIR_FILE"].ToString();

            Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_FILE= PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_FILE"].ToString();


            //자격부여코드이름
            if (PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CLASS_2"].ToString().Length == 9)
            {
                panel_R_2.Visible = true;
                panel_R_2.Location = new Point(cmbFolder.Location.X, cmbGroup2.Location.Y + 25);
                panel_R_LIST.Location = new Point(label158.Location.X - 15, cmbGroup2.Location.Y + 50);
                btn_ADD_R_1.Text = "-";

                txtGroup2Code_2.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_CODE_2"].ToString();
                cmbGroup2_2.Text= PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_NAME_2"].ToString(); 

            }
            if (PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CLASS_3"].ToString().Length == 9)
            {
                panel_R_3.Visible = true;
                panel_R_3.Location = new Point(panel_R_2.Location.X, panel_R_2.Location.Y + 25);
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_2.Location.Y + 50);
                btn_ADD_R_2.Text = "-";
                txtGroup2Code_3.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_CODE_3"].ToString();
                cmbGroup2_3.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_NAME_3"].ToString();
            }
            if (PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CLASS_4"].ToString().Length == 9)
            {
                panel_R_4.Visible = true;
                panel_R_4.Location = new Point(panel_R_3.Location.X, panel_R_3.Location.Y + 25);
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_3.Location.Y + 50);
                btn_ADD_R_3.Text = "-";
                txtGroup2Code_4.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_CODE_4"].ToString();
                cmbGroup2_4.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_NAME_4"].ToString();
            }
            if (PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CLASS_5"].ToString().Length == 9)
            {
                panel_R_5.Visible = true;
                panel_R_5.Location = new Point(panel_R_4.Location.X, panel_R_4.Location.Y + 25);
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_4.Location.Y + 50);
                btn_ADD_R_4.Text = "-";
                txtGroup2Code_5.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_CODE_5"].ToString();
                cmbGroup2_5.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_NAME_5"].ToString();

            }
            if (PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CLASS_6"].ToString().Length == 9)
            {
                panel_R_6.Visible = true;
                panel_R_6.Location = new Point(panel_R_5.Location.X, panel_R_5.Location.Y + 25);
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_5.Location.Y + 50);
                btn_ADD_R_5.Text = "-";
                txtGroup2Code_6.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_CODE_6"].ToString();
                cmbGroup2_6.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_NAME_6"].ToString();
            }

            Form2_GridIdx.sIDX = PQMS_STAFF_ROLEGridView.GetFocusedRowCellValue("IDX").ToString();


            if (e.Column.Caption.Equals("임명장보기"))
            {
                string strFile = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }


        }

        private void btnStaffEduInsert_Click(object sender, EventArgs e)
        {
            if (txtSTAFFCODE_EDU.Text == "")
            {
                MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                return;

            }


            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2PQMS_STAFF_EDUSet.sSTAFF_CODE = txtSTAFFCODE_EDU.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_CLASS = txtSTAFF_EDU_CLASS.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_ORG_CODE = cmbSTAFF_EDU_ORG_CODE.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_CODE = txtSTAFF_EDU_CODE.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_EXEC_ORG = cmbSTAFF_EDU_EXEC_ORG.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_FROM = txtSTAFF_EDU_FROM.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_TO = txtSTAFF_EDU_TO.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_HOURS = txtSTAFF_EDU_HOURS.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_COMP_CERTI = txtSTAFF_EDU_COMP_CERTI.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_PASS_CERTI = txtSTAFF_EDU_PASS_CERTI.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_REPORT = txtSTAFF_EDU_REPORT.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_APPROVE_DATE = txtSTAFF_EDU_APPROVE_DATE.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_APPRVAL = txtSTAFF_EDU_APPRVAL.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_APPROVE = txtSTAFF_EDU_APPROVE.Text;
                Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_STATUS = txtSTAFF_EDU_STATUS.Text;

                Form2PQMS_STAFF_EDUSet.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");

                // 교육자료 조회
                //Call_PQMS_Main_Edu(PQMS_STAFF_EDUMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void btnStaffEduUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("수정하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();

                try
                {
                    Form2PQMS_STAFF_EDUSet.sSTAFF_CODE = txtSTAFFCODE_EDU.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_CLASS = txtSTAFF_EDU_CLASS.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_ORG_CODE = cmbSTAFF_EDU_ORG_CODE.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_CODE = txtSTAFF_EDU_CODE.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_EXEC_ORG = cmbSTAFF_EDU_EXEC_ORG.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_FROM = txtSTAFF_EDU_FROM.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_TO = txtSTAFF_EDU_TO.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_HOURS = txtSTAFF_EDU_HOURS.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_COMP_CERTI = txtSTAFF_EDU_COMP_CERTI.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_PASS_CERTI = txtSTAFF_EDU_PASS_CERTI.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_REPORT = txtSTAFF_EDU_REPORT.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_APPROVE_DATE = txtSTAFF_EDU_APPROVE_DATE.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_APPRVAL = txtSTAFF_EDU_APPRVAL.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_APPROVE = txtSTAFF_EDU_APPROVE.Text;
                    Form2PQMS_STAFF_EDUSet.sSTAFF_EDU_STATUS = txtSTAFF_EDU_STATUS.Text;

                    Form2PQMS_STAFF_EDUSet.Update(trans);
                    AppRes.DB.CommitTrans();

                    // 교육자료 조회
                    //Call_PQMS_Main_Edu(PQMS_STAFF_EDUMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("수정 실패!" + Environment.NewLine + f.Message);
                }
            }
            else
            {

            }
        }

        private void btnStaffEduDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("수정하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();

                try
                {
                    Form2PQMS_STAFF_EDUSet.sSTAFF_CODE = txtSTAFFCODE_EDU.Text;

                    Form2PQMS_STAFF_EDUSet.Delete(trans);
                    AppRes.DB.CommitTrans();

                    // 교육자료 조회
                    //Call_PQMS_Main_Edu(PQMS_STAFF_EDUMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
                }
            }
            else
            {

            }
        }

        private void PQMS_STAFF_EDUMainGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            // 교육자료 조회
            //Call_PQMS_Main_Edu(PQMS_STAFF_EDUMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());

            //교육 Tab Page로 이동
            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }

        private void PQMS_STAFF_CERTIMainGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            Call_PQMS_Main_Certi(PQMS_STAFF_CERTIMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());

            //자격증 Tab Page로 이동
            tabControl1.SelectedTab = tabControl1.TabPages[3];
        }

        private void PQMS_STAFF_ROLEMainGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            //Call_PQMS_Main_Role(PQMS_STAFF_ROLEMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());

            //직무 Tab Page로 이동
            tabControl1.SelectedTab = tabControl1.TabPages[4];
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
        private void Field_Reset(string s_txtStaffCode)
        {
            //텍스트박스 값 지우기 
            TabPage selectedTab = tabControl1.SelectedTab;
            foreach (Control x in selectedTab.Controls)
            {
                if (x is System.Windows.Forms.TextBox)
                {
                    System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)x;
                    if (textBox.Name == s_txtStaffCode)
                    {
                    }
                    else
                    {
                        textBox.Text = string.Empty;
                    }
                }
                else if (x is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)x;
                    comboBox.Text = "";
                    comboBox.Items.Clear();

                }
                else if (x is DateTimePicker)
                {
                    DateTimePicker dateTimePicker = (DateTimePicker)x;
                    DateTime dt_TODATE = DateTime.Now;

                    dateTimePicker.Text = dt_TODATE.ToString();
                }
            }
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

        private void btnStaffroleInsert_Click(object sender, EventArgs e)
        {
            if (txtSTAFF_CODE_ROLE.Text == "")
            {
                MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                return;
            }
            if (cmbFolder.Text == "" || cmbGroup1.Text=="" || cmbGroup2.Text == "")
            {
                MessageBox.Show("자격분야를 선택하세요.");
                return;
            }
            if (cmbRole.Text == "")
            {
                MessageBox.Show("자격명을 선택하세요.");
                return;
            }


            SqlTransaction trans = AppRes.DB.BeginTrans();
            try
            {
                if (string.IsNullOrEmpty(txtGroup1Code.Text) == false || string.IsNullOrEmpty(txtGroup2Code.Text) == false)
                {
                    //if (string.IsNullOrEmpty(txtSTAFF_ROLE_QUALITY_DIR_FILE.Text) == false)
                    //{
                    //    //File.Copy(rpt, savefile, overwrite: true);

                    //    Document document = new Document();
                    //    string rpt = txtSTAFF_ROLE_QUALITY_DIR_FILE.Text;
                    //    string sfileName = Path.GetFileNameWithoutExtension(rpt);
                    //    string sExtensionName = Path.GetExtension(rpt);
                    //    string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                    //    string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                    //    string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "품질평가" + @"\" + sDateTime_yyyyMM;

                    //    DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                    //    if (file_di.Exists == false)
                    //    {
                    //        Directory.CreateDirectory(savrfilepath);
                    //    }
                    //    string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                    //    File.Copy(rpt, savefile, true);

                    //    //document.LoadFromFile(rpt);
                    //    //document.SaveToFile(savefile);
                    //    //document.Close();

                    //    txtSTAFF_ROLE_QUALITY_DIR_FILE.Text = savefile;

                    //}

                    //if (string.IsNullOrEmpty(txtSTAFF_ROLE_TEST_DIR_FILE.Text) == false)
                    //{
                    //    //File.Copy(rpt, savefile, overwrite: true);

                    //    Document document = new Document();

                    //    string rpt = txtSTAFF_ROLE_TEST_DIR_FILE.Text;
                    //    string sfileName = Path.GetFileNameWithoutExtension(rpt);
                    //    string sExtensionName = Path.GetExtension(rpt);
                    //    string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                    //    string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                    //    string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "시험평가" + @"\" + sDateTime_yyyyMM;
                    //    DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                    //    if (file_di.Exists == false)
                    //    {
                    //        Directory.CreateDirectory(savrfilepath);
                    //    }

                    //    string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                    //    File.Copy(rpt, savefile, true);//파일저장

                    //    //document.LoadFromFile(rpt);
                    //    //document.SaveToFile(savefile);
                    //    //document.Close();

                    //    txtSTAFF_ROLE_TEST_DIR_FILE.Text = savefile;

                    //}

                    Form2PQMS_STAFF_ROLESet.sSTAFF_CODE = txtSTAFF_CODE_ROLE.Text;
                    //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_DATE = txtSTAFF_ROLE_DATE.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_DATE = dtpOrder.Text;
                    //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS = txtSTAFF_ROLE_CLASS.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS = txtGroup1Code.Text + "-" + txtGroup2Code.Text;


                    if (panel_R_2.Visible == true)
                    {
                        Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_2 = txtGroup1Code.Text + "-" + txtGroup2Code_2.Text;
                    }
                    if (panel_R_3.Visible == true)
                    {

                        Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_3 = txtGroup1Code.Text + "-" + txtGroup2Code_3.Text;
                    }
                    if (panel_R_4.Visible == true)
                    {
                        Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_4 = txtGroup1Code.Text + "-" + txtGroup2Code_4.Text;
                    }
                    if (panel_R_5.Visible == true)
                    {
                        Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_5 = txtGroup1Code.Text + "-" + txtGroup2Code_5.Text;
                    }
                    if (panel_R_6.Visible == true)
                    {
                        Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_6 = txtGroup1Code.Text + "-" + txtGroup2Code_6.Text;
                    }                    

                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_ORG_CODE = txtSTAFF_ROLE_ORG_CODE.Text;
                    //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CODE = txtSTAFF_ROLE_CODE_no.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CODE = cmbSTAFF_ROLE_CODE.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_NAME = txtSTAFF_ROLE_NAME.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_STATUS = cmbSTAFF_ROLE_STATUS.Text;
                    //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_STATUS = txtSTAFF_ROLE_STATUS_no.Text;
                    //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_GIVEN_CLASS = txtSTAFF_ROLE_GIVEN_CLASS_no.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_GIVEN_CLASS = cmbSTAFF_ROLE_GIVEN_CLASS.Text;
                    //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CERTI = txtSTAFF_ROLE_CODE_no.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CERTI = cmbSTAFF_ROLE_CERTI.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_INSTEAD = txtSTAFF_ROLE_INSTEAD.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_UPPER_REPORT = txtSTAFF_ROLE_UPPER_REPORT.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_NOTE = txtSTAFF_ROLE_STAFF_ROLE_NOTE.Text;

                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_QUALITY_SCORE = txtSTAFF_ROLE_QUALITY_SCORE.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_TEST_SCORE = txtSTAFF_ROLE_TEST_SCORE.Text;

                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_QUALITY_DIR_FILE = txtSTAFF_ROLE_QUALITY_DIR_FILE.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_TEST_DIR_FILE = txtSTAFF_ROLE_TEST_DIR_FILE.Text;

                    Form2PQMS_STAFF_ROLESet.Insert(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("임명장 입력 완료!");


                    string RP_idx_query = " SELECT IDX, STAFF_ROLE_CODE, STAFF_ROLE_ORG_CODE FROM [PQMS_STAFF_ROLE] " +
                    " WHERE IDX = (SELECT MAX(IDX) FROM PQMS_STAFF_ROLE WHERE STAFF_CODE = '" + txtSTAFF_CODE_ROLE.Text + "')";

                    OleDbCommand cmd = new OleDbCommand(RP_idx_query, Conn);
                    Conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_IDX = reader.GetValue(0).ToString();
                                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_CODE = reader.GetValue(1).ToString();
                                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE = reader.GetValue(2).ToString();
                            }
                        }
                    }
                    Conn.Close();

                    string R_templeate = @"\\10.153.4.98\DI\PQMS\Template\RolePaper\CQP-6021-F05 (01) 임명장.docx";
                    string sDateTime_yyyyMM_R_Report = DateTime.Now.ToString("yyyyMM");
                    string savrfilepath_R_Report = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\RolePaper\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "직무기술서" + @"\" + sDateTime_yyyyMM_R_Report;

                    DirectoryInfo file_di_tr_Report = new DirectoryInfo(savrfilepath_R_Report);
                    if (file_di_tr_Report.Exists == false)
                    {
                        Directory.CreateDirectory(savrfilepath_R_Report);
                    }

                    // 임명장 생서 처리
                    unitCommon.CreateDoc_Role(R_templeate, Form2PQMS_StaffInfo.sStaffCode, savrfilepath_R_Report, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_IDX, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_CODE, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE);

                    Field_Reset("txtSTAFF_CODE_ROLE");
                    Call_PQMS_Main_Role(txtSTAFF_CODE_ROLE.Text);
                    btnStaffrolenew_Click(sender, e);

                    Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_IDX = "";
                    Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_CODE = "";
                    Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE = "";


                }
                else
                {
                    MessageBox.Show("대분류, 중분류를 입력해주세요!");
                }
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void btnStaffroleUpdate_Click(object sender, EventArgs e)
        {
            if (Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_ROLE_APPROVE_STATUS == "1")
            {
                MessageBox.Show("승인완료된 데이터는 수정 할 수 없습니다. ");
                return;
            }

            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                //if (string.IsNullOrEmpty(txtSTAFF_ROLE_QUALITY_DIR_FILE.Text) == false)
                //{
                //    if (txtSTAFF_ROLE_QUALITY_DIR_FILE.Text.ToString().ToUpper().Contains(unitCommon.sFileServerName) == true)
                //    {
                //        FileInfo fi = new FileInfo(txtSTAFF_ROLE_QUALITY_DIR_FILE.Text);
                //        if (fi.Exists == false) //
                //        {
                //            Document document = new Document();

                //            string rpt = txtSTAFF_ROLE_QUALITY_DIR_FILE.Text;
                //            string sfileName = Path.GetFileNameWithoutExtension(rpt);
                //            string sExtensionName = Path.GetExtension(rpt);
                //            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");
                //            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");


                //            string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "품질평가" + @"\" + sDateTime_yyyyMM;

                //            DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                //            if (file_di.Exists == false)
                //            {
                //                Directory.CreateDirectory(savrfilepath);
                //            }
                //            string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;


                //            File.Copy(rpt, savefile, true);

                //            //document.LoadFromFile(rpt);
                //            //document.SaveToFile(savefile);
                //            //document.Close();

                //            txtSTAFF_ROLE_QUALITY_DIR_FILE.Text = savefile;
                //        }
                //    }
                //    else
                //    {
                //        Document document = new Document();

                //        string rpt = txtSTAFF_ROLE_QUALITY_DIR_FILE.Text;
                //        string sfileName = Path.GetFileNameWithoutExtension(rpt);
                //        string sExtensionName = Path.GetExtension(rpt);
                //        string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");
                //        string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");


                //        string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "품질평가" + @"\" + sDateTime_yyyyMM;

                //        DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                //        if (file_di.Exists == false)
                //        {
                //            Directory.CreateDirectory(savrfilepath);
                //        }
                //        string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                //        File.Copy(rpt, savefile, true);


                //        //document.LoadFromFile(rpt);
                //        //document.SaveToFile(savefile);
                //        //document.Close();

                //        txtSTAFF_ROLE_QUALITY_DIR_FILE.Text = savefile;
                //    }
                //}

                //if (string.IsNullOrEmpty(txtSTAFF_ROLE_TEST_DIR_FILE.Text) == false)
                //{

                //    if (txtSTAFF_ROLE_TEST_DIR_FILE.Text.ToString().ToUpper().Contains(unitCommon.sFileServerName) == true)
                //    {
                //        FileInfo fi = new FileInfo(txtSTAFF_ROLE_TEST_DIR_FILE.Text);
                //        if (fi.Exists == false) //
                //        {
                //            Document document = new Document();

                //            string rpt = txtSTAFF_ROLE_TEST_DIR_FILE.Text;
                //            string sfileName = Path.GetFileNameWithoutExtension(rpt);
                //            string sExtensionName = Path.GetExtension(rpt);
                //            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                //            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                //            string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "시험평가" + @"\" + sDateTime_yyyyMM;
                //            DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                //            if (file_di.Exists == false)
                //            {
                //                Directory.CreateDirectory(savrfilepath);
                //            }

                //            string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                //            File.Copy(rpt, savefile, true);
                //            //document.LoadFromFile(rpt);
                //            //document.SaveToFile(savefile);
                //            //document.Close();

                //            txtSTAFF_ROLE_TEST_DIR_FILE.Text = savefile;
                //        }
                //    }
                //    else
                //    {

                //        Document document = new Document();

                //        string rpt = txtSTAFF_ROLE_TEST_DIR_FILE.Text;
                //        string sfileName = Path.GetFileNameWithoutExtension(rpt);
                //        string sExtensionName = Path.GetExtension(rpt);
                //        string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                //        string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                //        string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "시험평가" + @"\" + sDateTime_yyyyMM;
                //        DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                //        if (file_di.Exists == false)
                //        {
                //            Directory.CreateDirectory(savrfilepath);
                //        }

                //        string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                //        File.Copy(rpt, savefile, true);
                //        //document.LoadFromFile(rpt);
                //        //document.SaveToFile(savefile);
                //        //document.Close();

                //        txtSTAFF_ROLE_TEST_DIR_FILE.Text = savefile;
                //    }
                //}


                //Grid의 Row Cell 클릭하면 IDX 값 변수에 저장됨. iIDX
                //Form2PQMS_STAFF_ROLESet.iIDX = 1;
                Form2PQMS_STAFF_ROLESet.sSTAFF_CODE = txtSTAFF_CODE_ROLE.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_DATE = dtpOrder.Text;
                //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS = txtSTAFF_ROLE_CLASS.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS = txtGroup1Code.Text + "-" + txtGroup2Code.Text;


                if (panel_R_2.Visible == true)
                {
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_2 = txtGroup1Code.Text + "-" + txtGroup2Code_2.Text;
                }
                else
                {
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_2 = "";
                }
                if (panel_R_3.Visible == true)
                {
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_3 = txtGroup1Code.Text + "-" + txtGroup2Code_3.Text;
                }
                else
                {
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_3 = "";
                }
                if (panel_R_4.Visible == true)
                {
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_4 = txtGroup1Code.Text + "-" + txtGroup2Code_4.Text;
                }
                else
                {
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_4 = "";
                }
                if (panel_R_5.Visible == true)
                {
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_5 = txtGroup1Code.Text + "-" + txtGroup2Code_5.Text;
                }
                else
                {
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_5 = "";
                }
                if (panel_R_6.Visible == true)
                {
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_6 = txtGroup1Code.Text + "-" + txtGroup2Code_6.Text;
                }
                else
                {
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS_6 = "";
                }


                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_ORG_CODE = txtSTAFF_ROLE_ORG_CODE.Text;
                //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CODE = txtSTAFF_ROLE_CODE_no.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CODE = cmbSTAFF_ROLE_CODE.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_NAME = txtSTAFF_ROLE_NAME.Text;
                //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_STATUS = txtSTAFF_ROLE_STATUS_no.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_STATUS = cmbSTAFF_ROLE_STATUS.Text;
                //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_GIVEN_CLASS = txtSTAFF_ROLE_GIVEN_CLASS_no.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_GIVEN_CLASS = cmbSTAFF_ROLE_GIVEN_CLASS.Text;
                //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CERTI = txtSTAFF_ROLE_CERTI_no.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CERTI = cmbSTAFF_ROLE_CERTI.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_INSTEAD = txtSTAFF_ROLE_INSTEAD.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_UPPER_REPORT = txtSTAFF_ROLE_UPPER_REPORT.Text;

                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_QUALITY_SCORE = txtSTAFF_ROLE_QUALITY_SCORE.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_TEST_SCORE = txtSTAFF_ROLE_TEST_SCORE.Text;

                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_QUALITY_DIR_FILE = txtSTAFF_ROLE_QUALITY_DIR_FILE.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_TEST_DIR_FILE = txtSTAFF_ROLE_TEST_DIR_FILE.Text;

                Form2PQMS_STAFF_ROLESet.Update(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("임명장 수정 완료!");
                //임명장 파일 삭제하고 재생성 해야함.                 
                if (File.Exists(Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_FILE))
                {
                    File.Delete(Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_FILE);
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_FILE = "";
                }

                //파일 다시생성 
                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_IDX = Form2PQMS_STAFF_ROLESet.iIDX.ToString();
                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_CODE = cmbSTAFF_ROLE_CODE.Text;
                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE = txtSTAFF_ROLE_ORG_CODE.Text;

                string R_templeate = @"\\10.153.4.98\DI\PQMS\Template\RolePaper\CQP-6021-F05 (01) 임명장.docx";
                string sDateTime_yyyyMM_R_Report = DateTime.Now.ToString("yyyyMM");
                string savrfilepath_R_Report = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\RolePaper\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "직무기술서" + @"\" + sDateTime_yyyyMM_R_Report;


                // 임명장 생서 처리
                unitCommon.CreateDoc_Role(R_templeate, Form2PQMS_StaffInfo.sStaffCode, savrfilepath_R_Report, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_IDX, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_CODE, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE);

                Field_Reset("txtSTAFF_CODE_ROLE");
                Call_PQMS_Main_Role(txtSTAFF_CODE_ROLE.Text);
                btnStaffrolenew_Click(sender, e);

                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_IDX = "";
                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_CODE = "";
                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE = "";
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("수정 실패!" + Environment.NewLine + f.Message);
            }

            // iIDX 값 초기화
            Form2PQMS_STAFF_ROLESet.iIDX = 0;
        }

        private void btnStaffroleDelete_Click(object sender, EventArgs e)
        {
            if (Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_ROLE_APPROVE_STATUS == "1")
            {
                MessageBox.Show("승인완료된 데이터는 삭제 할 수 없습니다. ");
                return;
            }
            // SGSKorea는 기초데이터로 삭제 할수 없습니다. 
            if (txtSTAFF_ROLE_ORG_CODE.Text == "0007" && cmbSTAFF_ROLE_CODE.Text == "R001")
            {
                MessageBox.Show("SGS_Korea 기초데이터로 삭제 할수 없습니다. ");
                return;
            }

            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2PQMS_STAFF_ROLESet.sSTAFF_CODE = txtSTAFF_CODE_ROLE.Text;

                Form2PQMS_STAFF_ROLESet.Delete(trans);
                AppRes.DB.CommitTrans();

                ////서버에서 파일삭제
                //if (File.Exists(txtSTAFF_ROLE_QUALITY_DIR_FILE.Text))
                //{
                //    File.Delete(txtSTAFF_ROLE_QUALITY_DIR_FILE.Text);
                //}
                ////서버에서 파일삭제
                //if (File.Exists(txtSTAFF_ROLE_TEST_DIR_FILE.Text))
                //{
                //    File.Delete(txtSTAFF_ROLE_TEST_DIR_FILE.Text);
                //}

                //임명장파일 삭제 
                if (File.Exists(Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_FILE))
                {
                    File.Delete(Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_FILE);
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_FILE = "";
                }                

                MessageBox.Show("삭제 완료!");
                Field_Reset("txtSTAFF_CODE_ROLE");
                Call_PQMS_Main_Role(txtSTAFF_CODE_ROLE.Text);
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
            }

            // iIDX 값 초기화
            Form2PQMS_STAFF_ROLESet.iIDX = 0;

        }

        private void PQMS_STAFF_AllGridView_RowCellClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //그리드의 선택된 cell의 데이터 가져오기
            // 직원자료
            //Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("sSTAFF_CODE").ToString();
            //// 교육자료
            //Form2PQMS_STAFF_MainEDUSet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("sSTAFF_CODE").ToString();
            //// 자격증자료
            //Form2PQMS_STAFF_MainCERTISet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("sSTAFF_CODE").ToString();
            //// 직무자료
            //Form2PQMS_STAFF_MainROLESet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("sSTAFF_CODE").ToString();
            //자료목록에서 선택된 사용자 변경됐으니까 모든 탭의 모든 입력창 리셋             
            for (int i = 1; i < tabControl1.TabCount; i++)
            {
                TabPage selectedTab = tabControl1.TabPages[i];
                foreach (Control x in selectedTab.Controls)
                {
                    if (x is System.Windows.Forms.TextBox)
                    {
                        System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)x;
                        textBox.Text = string.Empty;
                    }
                    else if (x is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)x;
                        comboBox.Text = "";
                        comboBox.Items.Clear();

                    }
                    //else if (x is DateTimePicker)
                    //{
                    //    DateTimePicker dateTimePicker = (DateTimePicker)x;
                    //    DateTime dt_TODATE = DateTime.Now;

                    //    dateTimePicker.Text = dt_TODATE.ToString();
                    //}
                }
            }


            string tmp_Staff_Code = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();
            string tmp_Staff_Name = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_NAME").ToString();


            // 직원자료
            Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE = tmp_Staff_Code;

            // 교육자료
            Form2PQMS_STAFF_MainEDUSet.sSTAFF_CODE = tmp_Staff_Code;

            // 자격증자료
            Form2PQMS_STAFF_MainCERTISet.sSTAFF_CODE = tmp_Staff_Code;

            // 직무자료
            Form2PQMS_STAFF_MainROLESet.sSTAFF_CODE = tmp_Staff_Code;
            Form2PQMS_STAFF_ROLESet.sSTAFF_CODE = tmp_Staff_Code;

            // 직무기술서- 왼쪽 그리드
            Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_CODE = tmp_Staff_Code;
            //직무기술서 - 오른쪽 그리드
            Form2PQMS_STAFF_ROLE_PAPER_FinalGridSet.sSTAFF_CODE = tmp_Staff_Code;

            // 개인별업무목록
            Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sSTAFF_CODE = tmp_Staff_Code;

            // 개인별업무목록_현황
            Form2PQMS_ROLE2_EACH_LIST_InfoGridSet.sSTAFF_CODE = tmp_Staff_Code;

            // 교육보고서
            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE = tmp_Staff_Code;

            // 교육보고서 - 현황
            Form2PQMS_PQMS_STAFF_TRAINING_InfoGridSet.sSTAFF_CODE = tmp_Staff_Code;
            //자격부여평가보고서 
            Form2PQMS_STAFF_ASSESSMENT_MainGridSet.sSTAFF_CODE = tmp_Staff_Code;

            //트래이닝폴더관리 
            Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.sSTAFF_CODE = tmp_Staff_Code;


            // 전직장정보
            Form2PQMS_StaffInfo.sStaffCode = tmp_Staff_Code;
            Form2PQMS_StaffInfo.sStaffName = tmp_Staff_Name;

            // 사원 팀정보
            Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_TEAM").ToString();

            // 교육보고서
            //Form2PQMS_StaffInfo.sStaffCode = tmp_Staff_Code;

            // 기본자료 조회 - '사번'이 Key
            Call_STAFF_Main_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);

            // 기본자료 조회 - '사번'이 Key
            Call_STAFF_Main_Tab_Now_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);

            // 기본자료 조회 - '사번'이 Key
            Call_STAFF_Main_Pre_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);

            //// 교육자료 조회 - '사번'이 Key
            //try
            //{
            //    Form2PQMS_STAFF_MainEDUSet.SelectSTAFF_EDU();

            //    if (Form2PQMS_STAFF_MainEDUSet.Empty == false)
            //    {
            //        //AppHelper.SetGridDataSource(PQMS_STAFF_EDUMainGrid, Form2PQMS_STAFF_MainEDUSet);
            //    }
            //    else
            //    {

            //    }
            //}
            //catch (Exception f)
            //{
            //    MessageBox.Show("교육자료 조회 실패!" + f.Message.ToString());
            //}

            // 자격증자료 조회 - '사번'이 Key
            try
            {
                Form2PQMS_STAFF_MainCERTISet.SelectSTAFF_CERTI();

                if (Form2PQMS_STAFF_MainCERTISet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_CERTIMainGrid, Form2PQMS_STAFF_MainCERTISet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("자격증자료 조회 실패!" + f.Message.ToString());
            }
                     

            //// 개인별업무자료 조회 - '사번'이 Key
            CAll_PQMS_EACH_LIST();
                   

            // 개별업무자료 - 현황조회 - '사번'이 Key
            try
            {
                Form2PQMS_ROLE2_EACH_LIST_InfoGridSet.Select();

                if (Form2PQMS_ROLE2_EACH_LIST_InfoGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_EACH_LISTInfoGrid, Form2PQMS_ROLE2_EACH_LIST_InfoGridSet);
                    btn_5.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    btn_5.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("개인별업무자료 - 현황조회 실패!" + f.Message.ToString());
            }


            //트래이닝폴더관리 가져오기 
            try
            {
                Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.Select();

                if (Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE_PAPER_TRANING_FOLDER_MainGrid, Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet);
                    AppHelper.SetGridDataSource(PQMS_STAFF_TR_FOLDER_InfoGrid, Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet);

                    btn_9.BackColor = Color.FromArgb(0, 192, 0);

                }
                else
                {
                    btn_9.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("트래이닝폴더관리 - 조회 실패!" + f.Message.ToString());
            }

            // 교육 조회
            Call_PQMS_Main_Edu(tmp_Staff_Code);

            // 교육자료 - 현황조회
            Call_PQMS_Main_Edu(tmp_Staff_Code);

            // 자격증자료 조회
            Call_PQMS_Main_Certi(tmp_Staff_Code);

            // 직무자료 조회
            Call_PQMS_Main_Role(tmp_Staff_Code);

            // 직무자료 현황조회
            Call_PQMS_Info_Role(tmp_Staff_Code);

            // 교육보고서 조회
            Call_PQMS_STAFF_TRAINING();

            // 교육보고서 현황 조회
            Call_PQMS_STAFF_TRAINING_Info();

            // 직무기술서 조회
            Call_PQMS_STAFF_ROLE_PAPER();

            //자격부여평가보고서
            Call_PQMS_STAFF_ASSESSMENT();

            if (!Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("FOOD"))
            {
                //교육 Tab Page로 이동
                tabControl1.SelectedTab = tabControl1.TabPages[1];
            }

            

        }

        private void chg_btn(string tmp_Staff_Code)
        {

            //교육훈련이력기록 있으면 상단 버튼 생상 변경 
            DataTable dt_file = new DataTable();
            string query = " SELECT FILE_PATH FROM PQMS_STAFF_TRAINING_HISTORY_FOLDER " +
                        " WHERE  STAFF_CODE = '" + tmp_Staff_Code + "' ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_file.Load(reader);
            }
            Conn.Close();

            if (dt_file.Rows.Count == 1)
            {
                btn_3.BackColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                btn_3.BackColor = Color.FromArgb(255, 192, 192);
            }


            //수행능력평가이력  있으면 상단 버튼 색상 변경 
            dt_file = new DataTable();
            query = " SELECT FILE_PATH FROM PQMS_STAFF_RP_EACH_LIST_FOLDER " +
                       " WHERE  STAFF_CODE = '" + tmp_Staff_Code + "' ";

            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt_file.Load(reader);
            }
            Conn.Close();

            if (dt_file.Rows.Count >= 1)
            {
                btn_5.BackColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                btn_5.BackColor = Color.FromArgb(255, 192, 192);
            }
        }

        
        private void btnAttachmentCerti_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "jpg";
            openFile.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                foreach (string filename in openFile.FileNames)
                {
                    this.txtSTAFF_CERTI_FILE.Text = filename;
                }
            }
        }


        private void pnlFrm2Right_Resize(object sender, EventArgs e)
        {
            //panel1.Left = pnlFrm2Right.Width - 1350;
            //btnLookUpData.Left = pnlFrm2Right.Width - 1350;
            //btnFindRepository.Left = pnlFrm2Right.Width - 1270;
            PQMS_STAFF_AllGrid.Size = new Size(pnlFrm2Right.Width - 30, pnlFrm2Right.Height - 200);
        }

        private void btnFindRepository_Click(object sender, EventArgs e)
        {
            string sFormName = "frmRepositoryInfo";
            frmRepositoryInfo childRepositoryInfo = new frmRepositoryInfo();

            if (unitCommon.YNFrom(sFormName))
            {
                childRepositoryInfo.Dispose();     // 창 리소스 제거
            }
            else
            {
                //childRepositoryInfo.MdiParent = this;
                Form2PQMS_TabName.sTabName = "자료검색";
                childRepositoryInfo.WindowState = FormWindowState.Normal;
                childRepositoryInfo.ShowDialog();

                // 조직 선택이 되어 있을때만 활성화
                if (!string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchJaryoNodeName))
                {
                    btnLookUpData.Enabled = true;
                }
            }
        }

        private void btnFindRepositoryGibon_Click(object sender, EventArgs e)
        {
            string sFormName = "frmRepositoryInfo";
            frmRepositoryInfo childRepositoryInfo = new frmRepositoryInfo();

            if (unitCommon.YNFrom(sFormName))
            {
                childRepositoryInfo.Dispose();     // 창 리소스 제거
            }
            else
            {
                Form2PQMS_TabName.sTabName = "기본자료";
                childRepositoryInfo.WindowState = FormWindowState.Normal;
                childRepositoryInfo.ShowDialog();

                // 조직 선택이 되어 있을때만 활성화
                if (!string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName))
                {
                    txtSTAFF_TEAM.Text = FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                Call_listStaff_ROLE();
                Call_list_PQMS_ORG();
                Get_Upload_Data(0);
                LoadTreeViewFromDB4(dgvOrg, trvItems);
                this.tabControl1.TabPages.Remove(this.tabPage2); //교육자료 탭 삭제
                this.tabControl1.TabPages.Remove(this.tabPage3); //자격증자료 탭 삭제 

                //폼로드시 콤보박스 로드 
                get_folder_certi_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbMainCertiRole); //자격증자료 직무기관코드
                get_folder_data_type2_notin_ORG_CODE("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder); //직무자료 직무기관코드
                get_folder_data_type2_notin_ORG_CODE("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbRPORGCODE); //직무기술서 직무기관코드 
                get_folder_data7(cmbEduOrg2); //굑육보고서> 교육과정


                if (Form2PQMS_LoginInfo.sloginId != "Anyang@sgs.com" && Form2PQMS_LoginInfo.sloginId != "admin_anyang@sgs.com")
                {
                    Login_Load();
                }
            }
            catch (Exception f)
            {
                //string test = f.ToString();
                //AppRes.DB.RollbackTrans();
                MessageBox.Show("Load Form2 실패!" + Environment.NewLine + f.Message);
            }

            //if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
            //{
            //    btnRP_PERIODICINSPECTION.Enabled = false;
            //}


        }

        private void button10_Click(object sender, EventArgs e)
        {
            get_folder_data_type2_notin_ORG_CODE("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder);
        }

        private void btnGroup1_Click(object sender, EventArgs e)
        {
            get_folder_data2_type2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtSTAFF_ROLE_ORG_CODE.Text, cmbGroup1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            get_folder_data5("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbGroup2);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            txtTemplate.Text = file_open();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            show_file(txtTemplate.Text.Trim());
        }

        private void dtpOrder_ValueChanged(object sender, EventArgs e)
        {
            txtSTAFF_ROLE_DATE.Text = dtpOrder.Text;
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtSTAFF_ROLE_ORG_CODE.Text = cmbFolder.Text.Substring(0, 4);
            //txtOrgName.Text = cmbFolder.Text.Substring(5, cmbFolder.Text.Length - 5);

            string selectedText = cmbFolder.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                txtSTAFF_ROLE_ORG_CODE.Text = comboBoxData[selectedText];
                txtOrgName.Text = selectedText.ToString();
            }

            get_folder_data2_type2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtSTAFF_ROLE_ORG_CODE.Text, cmbGroup1);
        }



        private void cmbGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtGroup1Code.Text = cmbGroup1.Text.Substring(0, 4);
            //txtBig.Text = cmbGroup1.Text.Substring(5, cmbGroup1.Text.Length - 5);

            string selectedText = cmbGroup1.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                txtGroup1Code.Text = comboBoxData[selectedText];
                txtBig.Text = selectedText.ToString();
            }

            txtSTAFF_ROLE_CLASS.Text = txtGroup1Code.Text + "-" + txtGroup2Code.Text;

            get_folder_data5("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbGroup2);
            get_folder_data5("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbGroup2_2);
            get_folder_data5("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbGroup2_3);
            get_folder_data5("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbGroup2_4);
            get_folder_data5("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbGroup2_5);
            get_folder_data5("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbGroup2_6);
        }

        private void cmbGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    txtGroup2Code.Text = cmbGroup2.Text.Substring(0, 4);
            //    txtMid.Text = cmbGroup2.Text.Substring(5, cmbGroup2.Text.Length - 5);

            string selectedText = cmbGroup2.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                txtGroup2Code.Text = comboBoxData[selectedText];
                txtMid.Text = selectedText.ToString();
            }


            txtSTAFF_ROLE_CLASS.Text = txtGroup1Code.Text + "-" + txtGroup2Code.Text;

            get_folder_data6_type2("PQMS_ROLE", "ROLE_CODE", "ROLE_NAME", cmbRole);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            get_folder_data6_type2("PQMS_ROLE", "ROLE_CODE", "ROLE_NAME", cmbRole);
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbSTAFF_ROLE_CODE.Text = cmbRole.Text.Substring(0, 4);
            //txtSTAFF_ROLE_NAME.Text = cmbRole.Text.Substring(5, cmbRole.Text.Length - 5);

            string selectedText = cmbRole.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                cmbSTAFF_ROLE_CODE.Text = comboBoxData[selectedText];
                txtSTAFF_ROLE_NAME.Text = selectedText.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbEduOrg);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_EDU", "EDU_CODE", "EDU_NAME", "EDU_ORG_CODE", cmbSTAFF_EDU_ORG_CODE.Text, cmbEdu1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtSTAFF_EDU_REPORT.Text = file_open();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            show_file(txtSTAFF_EDU_REPORT.Text.Trim());
        }

        private void dtpEduFrom_ValueChanged(object sender, EventArgs e)
        {
            txtSTAFF_EDU_FROM.Text = dtpEduFrom.Text;
        }

        private void dtpEduTo_ValueChanged(object sender, EventArgs e)
        {
            txtSTAFF_EDU_TO.Text = dtpEduTo.Text;
        }

        private void dtpEduApprove_ValueChanged(object sender, EventArgs e)
        {
            txtSTAFF_EDU_APPROVE_DATE.Text = dtpEduApprove.Text;
        }

        private void cmbEduApprove_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSTAFF_EDU_APPROVE.Text = cmbEduApprove.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txtSTAFF_EDU_COMP_CERTI.Text = file_open();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            show_file(txtSTAFF_EDU_COMP_CERTI.Text.Trim());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            txtSTAFF_EDU_PASS_CERTI.Text = file_open();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            show_file(txtSTAFF_EDU_PASS_CERTI.Text.Trim());
        }

        private void cmbEduOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSTAFF_EDU_ORG_CODE.Text = cmbEduOrg.Text.Substring(0, 4);
            txtEduOrgName.Text = cmbEduOrg.Text.Substring(5, cmbEduOrg.Text.Length - 5);
        }

        private void cmbEdu1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSTAFF_EDU_CODE.Text = cmbEdu1.Text.Substring(0, 4);
            txtEduName.Text = cmbEdu1.Text.Substring(5, cmbEdu1.Text.Length - 5);
        }

        private void cmbEduGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSTAFF_EDU_CLASS.Text = cmbEduGubun.Text;
        }

        private void trvItems_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName = e.Node.Name.Trim();

            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
            {
                Call_PQMS_Main_Staff_User_Ver2(); //사용자
            }
            else
            {
                Call_PQMS_Main_Staff_Ver2(); //관리자 OR 심사원 OR DEPT(파트장)
            }

            txtSTAFF_EMPNO.Text = Form2PQMS_LoginInfo.sEmpNo;
            txtSTAFF_ACCOUNTNO.Text = Form2PQMS_LoginInfo.sAccountNo;

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
            //{
            //    txtSTAFF_EMPNO.Text = Form2PQMS_LoginInfo.sEmpNo;
            //    txtSTAFF_ACCOUNTNO.Text = Form2PQMS_LoginInfo.sAccountNo;
            //}


            txtSTAFF_EMPNO.Text = Form2PQMS_LoginInfo.sEmpNo;
            txtSTAFF_ACCOUNTNO.Text = Form2PQMS_LoginInfo.sAccountNo;

            if (PQMS_STAFFMainGridView.RowCount <= 0) return;

            txtSTAFF_CODE.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString();
            txtSTAFF_NAME.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_NAME"].ToString();
            txtSTAFF_TEAM.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["FOLDER_NAME"].ToString();
            txtSTAFF_JOIN_DATE.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_JOIN_DATE"].ToString();
            txtSTAFF_MAJOR.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_MAJOR"].ToString();
            txtSTAFF_SCHOOL.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_SCHOOL"].ToString();
            txtSTAFF_EMPNO.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_EMPNO"].ToString();
            txtSTAFF_ACCOUNTNO.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["ACCOUNT_NO"].ToString();
            txtSTAFF_File.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_FILE"].ToString();

            txtSTAFF_CODE_CERTI.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString(); //자격증자료
            txtSTAFF_CODE_ROLE.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString(); //직무자료
            txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString(); //직무기술서
            txtSTAFF_CODE_PQMS_STAFF_TRAINING.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString(); //교육보고서
            txtIdx_EACH_LIST_STAFF_CODE.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString(); //개별업무
            txtSTAFF_CODE_ASSESSMENT.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString(); //자격부여평가보고서

            //txtSTAFF_EMPNO.Text = 

            if (PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_JOIN_DATE"].ToString().Trim() != "")
            {
                DateTime DT_Date = DateTime.Parse(PQMS_STAFFMainGridView.GetFocusedRowCellValue("STAFF_JOIN_DATE").ToString());
                dtSTAFF_JOIN_DATE.Value = DT_Date;
            }

            if (PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_RESIGNATION_DATE"].ToString().Trim() != "")
            {
                DateTime DT_Date = DateTime.Parse(PQMS_STAFFMainGridView.GetFocusedRowCellValue("STAFF_RESIGNATION_DATE").ToString());
                dtSTAFF_RESIGNATION_DATE.Value = DT_Date;
            }


        }

        private void rdbFood_CheckedChanged(object sender, EventArgs e)
        {
            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
            {
                //Call_PQMS_Main_Staff_User();
                Call_PQMS_Main_Staff_User_Ver2();
            }
            else
            {
                //Call_PQMS_Main_Staff();
                Call_PQMS_Main_Staff_Ver2();
            }
        }

        private void btnMainCertiRole_Click(object sender, EventArgs e)
        {
            get_folder_certi_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbMainCertiRole);
        }



        private void btnMainCertiBigOrg_Click(object sender, EventArgs e)
        {
            get_folder_data2_type2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtMainCertiRoleCode.Text, cmbMainCertiBigOrgName);
        }

        private void btnMainCertiMidOrg_Click(object sender, EventArgs e)
        {
            get_folder_data3("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbMainCertiMidOrgName);
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

        private void cmbMainCertiBigOrgName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtMainCertiBigOrgCode.Text = cmbMainCertiBigOrgName.Text.Substring(0, 4);
            //txtMainCertiBigOrgName.Text = cmbMainCertiBigOrgName.Text.Substring(5, cmbMainCertiBigOrgName.Text.Length - 5);


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
            //txtMainCertiMidOrgCode.Text = cmbMainCertiMidOrgName.Text.Substring(0, 4);
            //txtMainCertiMidOrgName.Text = cmbMainCertiMidOrgName.Text.Substring(5, cmbMainCertiMidOrgName.Text.Length - 5);


            string selectedText = cmbMainCertiMidOrgName.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                txtMainCertiMidOrgCode.Text = comboBoxData[selectedText];
                txtMainCertiMidOrgName.Text = selectedText.ToString();
            }

            txtMainCertiOrgCode.Text = txtMainCertiBigOrgCode.Text + "-" + txtMainCertiMidOrgCode.Text;

            get_folder_data4("PQMS_ROLE", "ROLE_CODE", "ROLE_NAME", cmbMainCertiRoleName);

        }

        private void btnMainCertiRoleCode_Click(object sender, EventArgs e)
        {
            get_folder_data4("PQMS_ROLE", "ROLE_CODE", "ROLE_NAME", cmbMainCertiRoleName);
        }

        private void cmbMainCertiRoleCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbMainCertiRoleCode.Text = cmbMainCertiRoleName.Text.Substring(0, 4);
            //cmbMainCertiRoleName.Text = cmbMainCertiRoleName.Text.Substring(5, cmbMainCertiRoleName.Text.Length - 5);


            string selectedText = cmbMainCertiRoleName.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                cmbMainCertiRoleCode.Text = comboBoxData[selectedText];
                cmbMainCertiRoleName.Text = selectedText.ToString();
            }

        }

        private void rdbSTAFF_RESIGNATION_DATE_NO_CheckedChanged(object sender, EventArgs e)
        {
            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
            {
                //Call_PQMS_Main_Staff_User();
                Call_PQMS_Main_Staff_User_Ver2();
            }
            else
            {
                //Call_PQMS_Main_Staff();
                Call_PQMS_Main_Staff_Ver2();
            }
        }

        private void btnROLE2_EACH_LISTInsert_Click(object sender, EventArgs e)
        {
            if (txtIdx_EACH_LIST_STAFF_CODE.Text == "")
            {
                MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                return;
            }

            if (EACHLIST_VALIDATION() == 0)
            {
                return;
            }

            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                if (string.IsNullOrEmpty(txtROLE2_EACH_LIST_AttachFile.Text) == false) //첨부파일이 있으면 저장 
                {
                    //File.Copy(rpt, savefile, overwrite: true);

                    Document document = new Document();

                    string rpt = txtROLE2_EACH_LIST_AttachFile.Text;
                    string sfileName = Path.GetFileNameWithoutExtension(rpt);
                    string sExtensionName = Path.GetExtension(rpt);
                    string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                    string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                    string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "개별업무자료" + @"\" + sDateTime_yyyyMM;

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

                    txtROLE2_EACH_LIST_AttachFile.Text = savefile;
                    Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sATTACH_FILE = savefile;
                }

                if (txtMainWORKDATE_EACH_LIST.Text == "")
                {
                    txtMainWORKDATE_EACH_LIST.Text = dtpChkOrder_EACH_LIST.Text;
                }

                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sSITE_CODE = Form1PQMS_Repo.sSiteCode;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sREPOSITORY_CODE = Form1PQMS_Repo.sRepo;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sWS_CODE = Form1PQMS_Repo.sWS;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sROLE_CODE = txtMainROLE_CODE_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_NO = txtMainLIST_NO_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_WORKDATE = txtMainWORKDATE_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP1 = txtMainLIST_GROUP1_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP2 = txtMainLIST_GROUP2_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_CONTENTS1 = txtMainLIST_CONTENTS1_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_CHKDATE = txtChkOrder_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_CHKSIGN = txtMainLIST_CHKSIGN_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_TECHNICAL_MANAGER = txtMainTECHNICAL_MANAGER_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_REMARK = Form2STAFF_EACHLIST_REMARK.sSTAFF_EACHLIST_REMARK;//txtMainREMARK_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sTest_FIELD = txtTestField.Text;  //jhm0711
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sSTAFF_CODE = txtIdx_EACH_LIST_STAFF_CODE.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sATTACH_FILE = txtROLE2_EACH_LIST_AttachFile.Text;

                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_MOTHODS = txtEACH_LIST_METHODS.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_RESULT = txtEACH_LIST_RESULT.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_CHAGE = txtEHCH_LIST_CHANGE.Text;

                if (chk_ROLE_PAPER.Checked == true)
                {
                    Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sROLE_PAPER = "Y";
                }
                else
                {
                    Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sROLE_PAPER = "";
                }

                if (chk_EACHLIST_PAPER.Checked == true)
                {
                    Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sEACHLIST_PAPER = "Y";
                }
                else
                {
                    Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sEACHLIST_PAPER = "";
                }


                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");

                CAll_PQMS_EACH_LIST();

                Field_Reset("txtIdx_EACH_LIST_STAFF_CODE");
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패! " + Environment.NewLine + f.Message);
            }
        }

        private void btnROLE2_EACH_LISTUpdate_Click(object sender, EventArgs e)
        {
            if (Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_EACHLIST_APPROVE_STATUS == "1")
            {
                MessageBox.Show("승인완료된 데이터는 수정 할 수 없습니다. ");
                return;
            }

            if (EACHLIST_VALIDATION() == 0)
            {
                return;
            }

            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {

                if (string.IsNullOrEmpty(txtROLE2_EACH_LIST_AttachFile.Text) == false)
                {
                    if (txtROLE2_EACH_LIST_AttachFile.Text.ToString().ToUpper().Contains(unitCommon.sFileServerName) == true)
                    {
                        FileInfo fi = new FileInfo(txtROLE2_EACH_LIST_AttachFile.Text);
                        if (fi.Exists == false) //
                        {
                            Document document = new Document();

                            string rpt = txtROLE2_EACH_LIST_AttachFile.Text;
                            string sfileName = Path.GetFileNameWithoutExtension(rpt);
                            string sExtensionName = Path.GetExtension(rpt);
                            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                            string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "개별업무자료" + @"\" + sDateTime_yyyyMM;

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

                            txtROLE2_EACH_LIST_AttachFile.Text = savefile;
                            Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sATTACH_FILE = savefile;
                        }
                    }
                    else
                    {
                        Document document = new Document();

                        string rpt = txtROLE2_EACH_LIST_AttachFile.Text;
                        string sfileName = Path.GetFileNameWithoutExtension(rpt);
                        string sExtensionName = Path.GetExtension(rpt);
                        string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                        string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                        string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "개별업무자료" + @"\" + sDateTime_yyyyMM;

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

                        txtROLE2_EACH_LIST_AttachFile.Text = savefile;
                        Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sATTACH_FILE = savefile;
                    }
                }

                if (txtMainWORKDATE_EACH_LIST.Text == "")
                {
                    txtMainWORKDATE_EACH_LIST.Text = dtpChkOrder_EACH_LIST.Text;
                }

                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.iIDX = Convert.ToInt32(PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("IDX"));
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sROLE_CODE = txtMainROLE_CODE_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_NO = txtMainLIST_NO_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_WORKDATE = txtMainWORKDATE_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP1 = txtMainLIST_GROUP1_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP2 = txtMainLIST_GROUP2_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_CONTENTS1 = txtMainLIST_CONTENTS1_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_CHKDATE = txtChkOrder_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_TECHNICAL_MANAGER = txtMainTECHNICAL_MANAGER_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_REMARK = Form2STAFF_EACHLIST_REMARK.sSTAFF_EACHLIST_REMARK;//txtMainREMARK_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sTest_FIELD = txtTestField.Text; //jhm0711

                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_MOTHODS = txtEACH_LIST_METHODS.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_RESULT = txtEACH_LIST_RESULT.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_CHAGE = txtEHCH_LIST_CHANGE.Text;

                if (chk_ROLE_PAPER.Checked == true)
                {
                    Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sROLE_PAPER = "Y";
                }
                else
                {
                    Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sROLE_PAPER = "";
                }

                if (chk_EACHLIST_PAPER.Checked == true)
                {
                    Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sEACHLIST_PAPER = "Y";
                }
                else
                {
                    Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sEACHLIST_PAPER = "";
                }

                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Update(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("수정 완료!");

                CAll_PQMS_EACH_LIST();
                Field_Reset("txtIdx_EACH_LIST_STAFF_CODE");
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("수정 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void btnROLE2_EACH_LISTDelete_Click(object sender, EventArgs e)
        {
            if (Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_EACHLIST_APPROVE_STATUS == "1")
            {
                MessageBox.Show("승인완료된 데이터는 삭제 할 수 없습니다. ");
                return;
            }

            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.iIDX = Convert.ToInt32(PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("IDX"));
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Delete(trans);
                AppRes.DB.CommitTrans();

                //서버에서 파일삭제
                if (File.Exists(txtROLE2_EACH_LIST_AttachFile.Text))
                {
                    File.Delete(txtROLE2_EACH_LIST_AttachFile.Text);
                }
                MessageBox.Show("삭제 완료!");

                CAll_PQMS_EACH_LIST();
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void PQMS_ROLE2_EACH_LISTMainGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtMainLIST_CONTENTS1_EACH_LIST.ForeColor = System.Drawing.SystemColors.WindowText;
            txtEHCH_LIST_CHANGE.ForeColor = System.Drawing.SystemColors.WindowText;

            Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_EACHLIST_APPROVE_STATUS = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("approveStatusCode").ToString();

            txtIdx_EACH_LIST_GiSool.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("IDX").ToString();
            txtMainLIST_NO_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_NO").ToString();
            txtMainWORKDATE_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_WORKDATE").ToString();


            if (PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_WORKDATE").ToString().Trim() != "")
            {
                DateTime DT_Date = DateTime.Parse(PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_WORKDATE").ToString());
                dtpOrder_EACH_LIST.Value = DT_Date;
            }            

            txtMainLIST_CONTENTS1_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_CONTENTS1").ToString();
            txtMainREMARK_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_REMARK").ToString();
            Form2STAFF_EACHLIST_REMARK.sSTAFF_EACHLIST_REMARK = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_REMARK").ToString();

            txtTestField.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("TEST_FIELD").ToString();
            txtROLE2_EACH_LIST_AttachFile.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("ATTACH_FILE").ToString();

            txtEACH_LIST_METHODS.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_METHODS").ToString();
            cmbEACH_LIST_METHODS.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_METHODS").ToString();

            txtEACH_LIST_RESULT.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_RESULT").ToString();
            cmbEACH_LIST_RESULT.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_RESULT").ToString();

            txtEHCH_LIST_CHANGE.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_CHANGE").ToString();


            if (PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("ROLE_PAPER").ToString() == "Y")
            {
                chk_ROLE_PAPER.Checked = true;
            }
            else
            {
                chk_ROLE_PAPER.Checked = false;
            }


            if (PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("EACHLIST_PAPER").ToString() == "Y")
            {
                chk_EACHLIST_PAPER.Checked = true;
            }
            else
            {
                chk_EACHLIST_PAPER.Checked = false;
            }


            Form2_GridIdx.sIDX = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("IDX").ToString();

            if (e.Column.Caption.Equals("첨부파일"))
            {
                string strFile = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedDataRow()["ATTACH_FILE"].ToString();

                if (!string.IsNullOrEmpty(strFile)) // Check if the file path is not empty or null
                {
                    FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                    if (fileInfo.Exists)
                    {
                        Process.Start(strFile);
                    }
                }                    
            }

        }

        private void btnGigwanCode_EACH_LIST_Click(object sender, EventArgs e)
        {
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder_EACH_LIST);
        }

        private void cmbFolder_EACH_LIST_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSTAFF_ROLE_ORG_CODE_EACH_LIST.Text = cmbFolder_EACH_LIST.Text.Substring(0, 4);
            txtOrgName_EACH_LIST.Text = cmbFolder_EACH_LIST.Text.Substring(5, cmbFolder_EACH_LIST.Text.Length - 5);
        }

        private void btnGroup1_EACH_LIST_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtSTAFF_ROLE_ORG_CODE_EACH_LIST.Text, cmbMainGroup1_EACH_LIST);
        }

        private void cmbMainGroup1_EACH_LIST_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMainLIST_GROUP1_EACH_LIST.Text = cmbMainGroup1_EACH_LIST.Text.Substring(0, 4);
            txtBig_EACH_LIST.Text = cmbMainGroup1_EACH_LIST.Text.Substring(5, cmbMainGroup1_EACH_LIST.Text.Length - 5);
        }

        private void btnGroup2_EACH_LIST_Click(object sender, EventArgs e)
        {
            get_folder_data2_Gisool("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbMainGroup2_EACH_LIST);
        }

        private void cmbMainGroup2_EACH_LIST_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMainLIST_GROUP2_EACH_LIST.Text = cmbMainGroup2_EACH_LIST.Text.Substring(0, 4);
            txtMid_EACH_LIST.Text = cmbMainGroup2_EACH_LIST.Text.Substring(5, cmbMainGroup2_EACH_LIST.Text.Length - 5);
        }

        private void dtpOrder_EACH_LIST_ValueChanged(object sender, EventArgs e)
        {
            txtMainWORKDATE_EACH_LIST.Text = dtpOrder_EACH_LIST.Text;
        }

        private void btnSign_EACH_LIST_Click(object sender, EventArgs e)
        {
            txtMainLIST_CHKSIGN_EACH_LIST.Text = file_open();
        }

        private void btnOpenSign_EACH_LIST_Click(object sender, EventArgs e)
        {
            show_file(txtMainLIST_CHKSIGN_EACH_LIST.Text.Trim());
        }

        private void dtpChkOrder_EACH_LIST_ValueChanged(object sender, EventArgs e)
        {
            txtChkOrder_EACH_LIST.Text = dtpChkOrder_EACH_LIST.Text;
        }

        private int EACHLIST_VALIDATION()
        {
            if (txtMainLIST_CONTENTS1_EACH_LIST.Text == "")
            {
                MessageBox.Show("평가항목(시험항목)및 주요 업무내용을 입력하세요.");
                txtMainLIST_CONTENTS1_EACH_LIST.Focus();
                return 0;
            }
           else if (cmbEACH_LIST_METHODS.Text == "")
            {
                MessageBox.Show("평가방법을 선택하세요.");
                cmbEACH_LIST_METHODS.Focus();
                return 0;
            }
            else if(cmbEACH_LIST_RESULT.Text == "")
            {
                MessageBox.Show("평가결과를 선택하세요.");
                cmbEACH_LIST_RESULT.Focus();
                return 0;
            }
            else if(txtEHCH_LIST_CHANGE.Text == "")
            {
                MessageBox.Show("자격부여 또는 변경을 입력하세요.");
                txtEHCH_LIST_CHANGE.Focus();
                return 0;
            }            
            else if (Form2STAFF_EACHLIST_REMARK.sSTAFF_EACHLIST_REMARK == "" || Form2STAFF_EACHLIST_REMARK.sSTAFF_EACHLIST_REMARK == null)
            {
                MessageBox.Show("비고(관련절차 및 지침)을 입력 하세요.");
                btnInsertPQMS_STAFF_EACHLIST_REMARK.Focus();
                return 0;
            }
            return 1;
        }

        private int TRAINIG_VALIDATION()
        {
            if (cmbEduOrg2.Text == "")
            { 
                MessageBox.Show("교육과정을 선택하세요.");
                cmbEduOrg2.Focus();
                return 0;                
            }
            else if (cmbSTAFF_TRAIN_GUBUN.Text == "")
            {
                MessageBox.Show("내부/외부구분 을 선택하세요");
                cmbSTAFF_TRAIN_GUBUN.Focus();
                return 0;
            }
            else if (txtSTAFF_TRAIN_ORG.Text == "")
            {
                MessageBox.Show("교육기관을 입력하세요");
                txtSTAFF_TRAIN_ORG.Focus();
                return 0;
            }            
            else if (txtSTAFF_TRAIN_TRAINER.Text == "")
            {
                MessageBox.Show("교육자를 입력하세요");
                txtSTAFF_TRAIN_TRAINER.Focus();
                return 0;
            }
            else if (txtSTAFF_TRAIN_RESULT.Text == "결과 및 교육자료 입력하세요")
            {
                MessageBox.Show("");
                txtSTAFF_TRAIN_RESULT.Focus();
                return 0;
            }
           

            else if (Form2STAFF_TRAIN_ATTENDEE.sSTAFF_TRAINING_ATTENDEE == "" || Form2STAFF_TRAIN_ATTENDEE.sSTAFF_TRAINING_ATTENDEE == null)
            {
                if (MessageBox.Show("참석자 없이 입력하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //참석자가 없으면 내이름만 작성자만 참석자로 저장
                    Form2STAFF_TRAIN_ATTENDEE.sSTAFF_TRAINING_ATTENDEE = txtSTAFF_NAME.Text;
                }
                else
                {                    
                    btnSTAFF_TRAIN_ATTENDEE.Focus();
                    return 0;
                }                
            }

            else if (Form2STAFF_TRAIN_CONTENTS.sSTAFF_TRAIN_CONTENTS == "" || Form2STAFF_TRAIN_CONTENTS.sSTAFF_TRAIN_CONTENTS == null)
            {
                MessageBox.Show("Contents 내용을 입력하세요");
                btnInsertPQMS_STAFF_TRAINING_STAFF_TRAIN_CONTENTS.Focus();
                return 0;
            }
            else if (Form2STAFF_TRAIN_GOAL.sSTAFF_TRAIN_GOAL == "" || Form2STAFF_TRAIN_GOAL.sSTAFF_TRAIN_GOAL == null)
            {
                MessageBox.Show("내용요약을 입력하세요");
                btnInsertSTAFF_TRAIN_GOAL.Focus();
                return 0;
            }
            else if (Form2STAFF_TRAIN_OBJECTIVE.sSTAFF_TRAIN_OBJECTIVE == "" || Form2STAFF_TRAIN_OBJECTIVE.sSTAFF_TRAIN_OBJECTIVE == null)
            {
                MessageBox.Show("주제를 입력하세요");
                btnInsertSTAFF_TRAIN_SUMMARY.Focus();
                return 0;
            }

            return 1;

        }

        private void btnInsertPQMS_STAFF_TRAINING_Click(object sender, EventArgs e)
        {
            //if (Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX == "" || Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX == null) // 수정데이터가 아닌경우만 해당 이벤트 진행 
            //{
                if (TRAINIG_VALIDATION() == 0)
                {
                    return;
                }

                if (txtSTAFF_CODE_PQMS_STAFF_TRAINING.Text == "")
                {
                    MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                    return;
                }

                if (string.IsNullOrEmpty(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text) == false && File.Exists(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text)) // 파일명이 있고 
                {
                    //파일 사이즈 구하기 
                    FileInfo info = new FileInfo(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text);

                    if (info.Length > 5242880) // 5MB제한
                    {
                        MessageBox.Show("교육훈련결과 첨부파일의 용량은 5MB를 초과 할 수 없습니다.");
                        return;
                    }
                }

                SqlTransaction trans = AppRes.DB.BeginTrans();
                try
                {
                    if (string.IsNullOrEmpty(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text) == false)
                    {
                        //File.Copy(rpt, savefile, overwrite: true);

                        Document document = new Document();

                        string rpt = txtSTAFF_TRAIN_RESULT_DIR_FILE.Text;

                        string sfileName = Path.GetFileNameWithoutExtension(rpt);
                        string sExtensionName = Path.GetExtension(rpt);
                        string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                        string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                        string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "교육훈련결과" + @"\" + sDateTime_yyyyMM;

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

                        txtSTAFF_TRAIN_RESULT_DIR_FILE.Text = savefile;
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT_DIR_FILE = savefile;
                    }

                    //Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE = txtSTAFF_CODE.Text;                   //Main(기본자료)에서 받아오는 값                          

                    //교육과정이 기타이면 그대로 입력 아니면 코드값만 입력 
                    if (cmbEduOrg2.Text == "기타")
                    {
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_COURSE = cmbEduOrg2.Text;
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_EDU = txteduETC.Text; // 텍스트 박스 값 입력 

                    }
                    else
                    {
                        string selectedText = cmbEduOrg2.SelectedItem.ToString();
                        if (comboBoxData.ContainsKey(selectedText))
                        {
                            string selectedValue = comboBoxData[selectedText];
                            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_COURSE = selectedValue;
                            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_EDU = selectedText;
                        }
                    }

                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_GUBUN = txtSTAFF_TRAIN_GUBUN.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_ORG = txtSTAFF_TRAIN_ORG.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_TRAINER = txtSTAFF_TRAIN_TRAINER.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_DATE = dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_FROM.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_DATE_TO = dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_TO.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_HOUR = txtSTAFF_TRAIN_HOUR.Text;
                    //Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_ATTENDEE = txtSTAFF_TRAIN_ATTENDEE.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_GOAL = Form2STAFF_TRAIN_GOAL.sSTAFF_TRAIN_GOAL;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_SUMMARY = Form2STAFF_TRAIN_OBJECTIVE.sSTAFF_TRAIN_OBJECTIVE;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_CONTENTS = Form2STAFF_TRAIN_CONTENTS.sSTAFF_TRAIN_CONTENTS;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_ATTENDEE = Form2STAFF_TRAIN_ATTENDEE.sSTAFF_TRAINING_ATTENDEE;




                    //jhm
                    if (string.IsNullOrEmpty(txtSTAFF_TRAIN_RESULT.Text) == true)
                    {
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT = "N/A";
                    }
                    else
                    {
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT = txtSTAFF_TRAIN_RESULT.Text;
                    }

                    if (txtSTAFF_TRAIN_WRITE_DATE.Text == "")
                    {
                        txtSTAFF_TRAIN_WRITE_DATE.Text = dtSTAFF_TRAIN_WRITE_DATE.Text;
                    }
                    if (txtSTAFF_TRAIN_APPROVAL_DATE.Text == "")
                    {
                        txtSTAFF_TRAIN_APPROVAL_DATE.Text = dtSTAFF_TRAIN_APPROVAL_DATE.Text;
                    }


                    if (txtSTAFF_TRAIN_WRITER.Text == "")
                    {
                        txtSTAFF_TRAIN_WRITER.Text = Form2PQMS_StaffInfo.sStaffName;
                    }


                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEW = txtSTAFF_TRAIN_REVIEW.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_WRITER = txtSTAFF_TRAIN_WRITER.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_WRITE_DATE = txtSTAFF_TRAIN_WRITE_DATE.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEWER = txtSTAFF_TRAIN_REVIEWER.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEW_DATE = txtSTAFF_TRAIN_REVIEW_DATE.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_APPROVER = txtSTAFF_TRAIN_APPROVER.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_APPROVAL_DATE = txtSTAFF_TRAIN_APPROVAL_DATE.Text;

                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Insert(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("입력 완료!");                    

                    //보고서 파일 자동생성 
                    string sDateTime_yyyyMM_tr_Report = DateTime.Now.ToString("yyyyMM");
                    string savrfilepath_tr_Report = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\EduReport\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "교육보고서" + @"\" + sDateTime_yyyyMM_tr_Report;

                    DirectoryInfo file_di_tr_Report = new DirectoryInfo(savrfilepath_tr_Report);
                    if (file_di_tr_Report.Exists == false)
                    {
                        Directory.CreateDirectory(savrfilepath_tr_Report);
                    }

                    DataTable dt_training = new DataTable();
                    string tr_idx_query = " SELECT IDX, STAFF_TRAIN_RESULT_DIR_FILE FROM PQMS_STAFF_TRAINING " +
                        " WHERE IDX = (SELECT MAX(IDX) FROM PQMS_STAFF_TRAINING WHERE STAFF_CODE = '" + txtSTAFF_CODE_PQMS_STAFF_TRAINING.Text + "')";

                    OleDbCommand cmd = new OleDbCommand(tr_idx_query, Conn);
                    Conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX = reader.GetValue(0).ToString();
                                Form2PQMS_StaffInfo.sPQMS_STAFF_EDU_FILE = reader.GetValue(1).ToString();

                                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.iIDX = Convert.ToInt32(reader.GetValue(0).ToString());
                            }

                        }
                    }
                    Conn.Close();
                    //참석자 테이블에 데이터 인서트 해야함
                    //Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE
                    if (Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE != null)
                    {
                        foreach (DataRow row in Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE.Rows)
                        {
                            trans = AppRes.DB.BeginTrans();
                            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.s_STAFF_TRAIN_ATTENDEE_STAFF_CODE = row["STAFF_CODE"].ToString();
                            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.s_STAFF_TRAIN_ATTENDEE_STAFF_EMPNO = row["STAFF_EMPNO"].ToString();
                            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.s_STAFF_TRAIN_ATTENDEE_FOLDER_NAME = row["FOLDER_NAME"].ToString();
                            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.s_STAFF_TRAIN_ATTENDEE_STAFF_NAME = row["STAFF_NAME"].ToString();

                            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Insert_Attendee(trans);
                            AppRes.DB.CommitTrans();
                        }
                    }

                    Form2STAFF_TRAIN_CONTENTS.sSTAFF_TRAIN_CONTENTS = "";
                    Form2STAFF_TRAIN_OBJECTIVE.sSTAFF_TRAIN_OBJECTIVE = "";
                    Form2STAFF_TRAIN_GOAL.sSTAFF_TRAIN_GOAL = "";
                    Form2STAFF_TRAIN_ATTENDEE.sSTAFF_TRAINING_ATTENDEE = "";
                    Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE = null;
                    Field_Reset("txtSTAFF_CODE_PQMS_STAFF_TRAINING");


                    string tr_templeate = @"\\10.153.4.98\DI\PQMS\Template\EduReport\CQP-6021-F09 (01) 교육훈련 보고서.docx";

                    unitCommon.CreateDoc_training(tr_templeate, Form2PQMS_StaffInfo.sStaffCode, Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX, savrfilepath_tr_Report, Form2PQMS_StaffInfo.sPQMS_STAFF_EDU_FILE);
                    Call_PQMS_STAFF_TRAINING();// 교육보고서 다시 로드 
                    Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX = "";
                    Form2PQMS_StaffInfo.sPQMS_STAFF_EDU_FILE = "";

                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
                }
            //}
            //else
            //{
            //    MessageBox.Show("데이터 수정은 상단 수정 버튼을 클릭하세요");
            //    return;
            //}            
        }

        private void btnUpdatePQMS_STAFF_TRAINING_Click(object sender, EventArgs e)
        {
           
            if (Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_EDU_APPROVE_STATUS == "1")
            {
                MessageBox.Show("승인완료된 데이터는 수정 할 수 없습니다. ");
                return;
            }

            if (TRAINIG_VALIDATION() == 0)
            {
                return;
            }            

            if (string.IsNullOrEmpty(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text) == false && File.Exists(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text)) // 파일명이 있고 
            {
                //파일 사이즈 구하기 
                FileInfo info = new FileInfo(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text);

                if (info.Length > 5242880) // 5MB제한
                {
                    MessageBox.Show("교육훈련결과 첨부파일의 용량은 5MB를 초과 할 수 없습니다.");
                    return;
                }
            }

            SqlTransaction trans = AppRes.DB.BeginTrans();
            try
            {
                if (string.IsNullOrEmpty(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text) == false)
                {
                    if (txtSTAFF_TRAIN_RESULT_DIR_FILE.Text.ToString().ToUpper().Contains(unitCommon.sFileServerName) == true) // 이미 서버에 첨부된 파일이 있음
                    {
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT_DIR_FILE = txtSTAFF_TRAIN_RESULT_DIR_FILE.Text;
                    }
                    else
                    {
                        Document document = new Document();

                        string rpt = txtSTAFF_TRAIN_RESULT_DIR_FILE.Text;
                        string sfileName = Path.GetFileNameWithoutExtension(rpt);
                        string sExtensionName = Path.GetExtension(rpt);
                        string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                        string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                        string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "교육훈련결과" + @"\" + sDateTime_yyyyMM;

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

                        txtSTAFF_TRAIN_RESULT_DIR_FILE.Text = savefile;
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT_DIR_FILE = savefile;
                    }
                }

                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.iIDX = Convert.ToInt32(txtIdx_PQMS_STAFF_TRAINING_EduBogo.Text);
                //Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_COURSE = cmbEduOrg2.Text;

                //교육과정이 기타이면 그대로 입력 아니면 코드값만 입력 
                if (cmbEduOrg2.Text == "기타")
                {
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_COURSE = cmbEduOrg2.Text;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_EDU = txteduETC.Text; // 텍스트 박스 값 입력 
                }
                else
                {                    
                    string selectedText = cmbEduOrg2.SelectedItem.ToString();

                    if (comboBoxData.ContainsKey(selectedText))
                    {
                        string selectedValue = comboBoxData[selectedText];
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_COURSE = selectedValue;
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_EDU = selectedText;
                    }
                }

                if (txtSTAFF_TRAIN_WRITE_DATE.Text == "")
                {
                    txtSTAFF_TRAIN_WRITE_DATE.Text = dtSTAFF_TRAIN_WRITE_DATE.Text;
                }
                if (txtSTAFF_TRAIN_APPROVAL_DATE.Text == "")
                {
                    txtSTAFF_TRAIN_APPROVAL_DATE.Text = dtSTAFF_TRAIN_APPROVAL_DATE.Text;
                }

                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_GUBUN = txtSTAFF_TRAIN_GUBUN.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_ORG = txtSTAFF_TRAIN_ORG.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_TRAINER = txtSTAFF_TRAIN_TRAINER.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_DATE = dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_FROM.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_DATE_TO = dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_TO.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_HOUR = txtSTAFF_TRAIN_HOUR.Text;
                //Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_ATTENDEE = txtSTAFF_TRAIN_ATTENDEE.Text;                
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_ATTENDEE = Form2STAFF_TRAIN_ATTENDEE.sSTAFF_TRAINING_ATTENDEE;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_GOAL = Form2STAFF_TRAIN_GOAL.sSTAFF_TRAIN_GOAL;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_SUMMARY = Form2STAFF_TRAIN_OBJECTIVE.sSTAFF_TRAIN_OBJECTIVE;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_CONTENTS = Form2STAFF_TRAIN_CONTENTS.sSTAFF_TRAIN_CONTENTS;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT = txtSTAFF_TRAIN_RESULT.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEW = txtSTAFF_TRAIN_REVIEW.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_WRITER = txtSTAFF_TRAIN_WRITER.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_WRITE_DATE = txtSTAFF_TRAIN_WRITE_DATE.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEWER = txtSTAFF_TRAIN_REVIEWER.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEW_DATE = txtSTAFF_TRAIN_REVIEW_DATE.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_APPROVER = txtSTAFF_TRAIN_APPROVER.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_APPROVAL_DATE = txtSTAFF_TRAIN_APPROVAL_DATE.Text;

                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Update(trans);
                AppRes.DB.CommitTrans();
                //참석자 명단 수정 시작 
                trans = AppRes.DB.BeginTrans();
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Delete_Attendee(trans); // 착석자 명단 삭제 
                AppRes.DB.CommitTrans();
                // 참석자 명단 재 인서트 
                if (Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE != null)
                {
                    foreach (DataRow row in Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE.Rows)
                    {
                        trans = AppRes.DB.BeginTrans();
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.s_STAFF_TRAIN_ATTENDEE_STAFF_CODE = row["STAFF_CODE"].ToString();
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.s_STAFF_TRAIN_ATTENDEE_STAFF_EMPNO = row["STAFF_EMPNO"].ToString();
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.s_STAFF_TRAIN_ATTENDEE_FOLDER_NAME = row["FOLDER_NAME"].ToString();
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.s_STAFF_TRAIN_ATTENDEE_STAFF_NAME = row["STAFF_NAME"].ToString();

                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Insert_Attendee(trans);
                        AppRes.DB.CommitTrans();
                    }
                }
                

                MessageBox.Show("수정 완료!");

                //보고서파일삭제 및 재생성
                //파일삭제 Form2PQMS_StaffInfo.sPQMS_STAFF_TR_FILE
                if (File.Exists(Form2PQMS_StaffInfo.sPQMS_STAFF_TR_FILE))
                {
                    File.Delete(Form2PQMS_StaffInfo.sPQMS_STAFF_TR_FILE);
                }
                string sDateTime_yyyyMM_tr_Report = DateTime.Now.ToString("yyyyMM");
                string savrfilepath_tr_Report = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\EduReport\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "교육보고서" + @"\" + sDateTime_yyyyMM_tr_Report;

                DirectoryInfo file_di_tr_Report = new DirectoryInfo(savrfilepath_tr_Report);
                if (file_di_tr_Report.Exists == false)
                {
                    Directory.CreateDirectory(savrfilepath_tr_Report);
                }

                Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.iIDX.ToString();
                Form2PQMS_StaffInfo.sPQMS_STAFF_EDU_FILE = txtSTAFF_TRAIN_RESULT_DIR_FILE.Text;

                string tr_templeate = @"\\10.153.4.98\DI\PQMS\Template\EduReport\CQP-6021-F09 (01) 교육훈련 보고서.docx";

                unitCommon.CreateDoc_training(tr_templeate, Form2PQMS_StaffInfo.sStaffCode, Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX, savrfilepath_tr_Report, Form2PQMS_StaffInfo.sPQMS_STAFF_EDU_FILE);

                Field_Reset("txtSTAFF_CODE_PQMS_STAFF_TRAINING");
                Call_PQMS_STAFF_TRAINING();// 교육보고서 다시 로드 
                Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX = "";
                Form2PQMS_StaffInfo.sPQMS_STAFF_EDU_FILE = "";
                
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("수정 실패!" + Environment.NewLine + f.Message);
            }


        }

        private void btnSelectPQMS_STAFF_TRAINING_Click(object sender, EventArgs e)
        {
            Call_PQMS_STAFF_TRAINING();
        }

        private void btnDeletePQMS_STAFF_TRAINING_Click(object sender, EventArgs e)
        {
            if (Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_EDU_APPROVE_STATUS == "1")
            {
                MessageBox.Show("승인완료된 데이터는 삭제 할 수 없습니다. ");
                return;
            }


            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.iIDX = Convert.ToInt32(txtIdx_PQMS_STAFF_TRAINING_EduBogo.Text);
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Delete(trans);
                AppRes.DB.CommitTrans();

                //서버에서파일삭제
                if (File.Exists(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text))
                {
                    File.Delete(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text);
                }
                //서버에서 파일삭제
                if (File.Exists(Form2PQMS_StaffInfo.sPQMS_STAFF_TR_FILE))
                {
                    File.Delete(Form2PQMS_StaffInfo.sPQMS_STAFF_TR_FILE);
                }

                MessageBox.Show("삭제 완료!");

                Field_Reset("txtSTAFF_CODE_PQMS_STAFF_TRAINING");
                Call_PQMS_STAFF_TRAINING();
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void Form2PQMS_STAFF_TRAINING_Attendee_Select()
        {            
            //참석자 명단 가져오는 SELECT 문 시작                 
            string tr_Attendee = " SELECT * FROM PQMS_STAFF_TRAINING_ATTENDEE " +
                                 " WHERE H_IDX = " + Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("IDX").ToString();
                        
            OleDbCommand cmd = new OleDbCommand(tr_Attendee, Conn);
            Conn.Open();
            Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE = new DataTable();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {                    
                    Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE.Load(reader);                    
                }
            }
            Conn.Close();
        }


        private void Form2PQMS_STAFF_TRAINING_MainGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            try
            {               

                Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_EDU_APPROVE_STATUS = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("approveStatusCode").ToString();

                txtIdx_PQMS_STAFF_TRAINING_EduBogo.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("IDX").ToString();
                //Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.iIDX = Convert.ToInt32(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("IDX"));
                txtSTAFF_CODE_PQMS_STAFF_TRAINING.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();
                txtSTAFF_TRAIN_COURSE.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_COURSE").ToString();
                txtSTAFF_TRAIN_GUBUN.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_GUBUN").ToString();
                cmbSTAFF_TRAIN_GUBUN.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_GUBUN").ToString();
                txtSTAFF_TRAIN_ORG.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_ORG").ToString();
                txtSTAFF_TRAIN_TRAINER.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_TRAINER").ToString();
                txtSTAFF_TRAIN_DATE_FROM.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE").ToString();
                txtSTAFF_TRAIN_HOUR.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_HOUR").ToString();
                txtSTAFF_TRAIN_ATTENDEE.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_ATTENDEE").ToString();
                txtSTAFF_TRAIN_GOAL.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_GOAL").ToString();
                txtSTAFF_TRAIN_SUMMARY.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_SUMMARY").ToString();
                //txtSTAFF_TRAIN_CONTENTS.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_CONTENTS").ToString();
                txtSTAFF_TRAIN_RESULT.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_RESULT").ToString();
                txtSTAFF_TRAIN_RESULT_DIR_FILE.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_RESULT_DIR_FILE").ToString();
                txtSTAFF_TRAIN_REVIEW.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_REVIEW").ToString();
                txtSTAFF_TRAIN_WRITER.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_WRITER").ToString();
                txtSTAFF_TRAIN_WRITE_DATE.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_WRITE_DATE").ToString();
                txtSTAFF_TRAIN_REVIEWER.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_REVIEWER").ToString();
                txtSTAFF_TRAIN_REVIEW_DATE.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_REVIEW_DATE").ToString();
                txtSTAFF_TRAIN_APPROVER.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_APPROVER").ToString();
                txtSTAFF_TRAIN_APPROVAL_DATE.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_APPROVAL_DATE").ToString();


                Form2STAFF_TRAIN_ATTENDEE.sSTAFF_TRAINING_ATTENDEE = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_ATTENDEE").ToString();
                Form2STAFF_TRAIN_GOAL.sSTAFF_TRAIN_GOAL = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_GOAL").ToString();
                Form2STAFF_TRAIN_CONTENTS.sSTAFF_TRAIN_CONTENTS = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_CONTENTS").ToString();
                Form2STAFF_TRAIN_OBJECTIVE.sSTAFF_TRAIN_OBJECTIVE = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_SUMMARY").ToString();

                // 교육보고서에 사용되는 변수
                Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("IDX").ToString();
                Form2PQMS_StaffInfo.sPQMS_STAFF_EDU_FILE = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_RESULT_DIR_FILE").ToString();

                if (Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_RESULT").ToString() == "교육자료첨부")
                {
                    txtSTAFF_TRAIN_RESULT.Visible = false;
                    cmbSTAFF_TRAIN_RESULT.Text = "교육자료첨부";
                }
                else if (Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_RESULT").ToString() == "수료증첨부")
                {
                    txtSTAFF_TRAIN_RESULT.Visible = false;
                    cmbSTAFF_TRAIN_RESULT.Text = "수료증첨부";
                }
                else
                {
                    txtSTAFF_TRAIN_RESULT.Visible = true;
                    cmbSTAFF_TRAIN_RESULT.Text = "기타";
                }

                if (Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_ORG").ToString() == "KTR")
                {
                    txtSTAFF_TRAIN_ORG.Visible = false;
                    cmbSTAFF_TRAIN_ORG.Text = "KTR";
                }
                else if (Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_ORG").ToString() == "KOTICA")
                {
                    txtSTAFF_TRAIN_ORG.Visible = false;
                    cmbSTAFF_TRAIN_ORG.Text = "KOTICA";
                }
                else if (Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_ORG").ToString() == "KTL")
                {
                    txtSTAFF_TRAIN_ORG.Visible = false;
                    cmbSTAFF_TRAIN_ORG.Text = "KTL";
                }
                else if (Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_ORG").ToString() == "식약처")
                {
                    txtSTAFF_TRAIN_ORG.Visible = false;
                    cmbSTAFF_TRAIN_ORG.Text = "식약처";
                }
                else
                {
                    txtSTAFF_TRAIN_ORG.Visible = true;
                    cmbSTAFF_TRAIN_ORG.Text = "직접입력";
                }

                //jhm
                if (Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_COURSE").ToString() == "기타")
                {
                    txteduETC.Visible = true;
                    cmbEduOrg2.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_COURSE").ToString();
                    txteduETC.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_EDU").ToString();
                }
                else
                {
                    txteduETC.Visible = false;
                    cmbEduOrg2.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_EDU").ToString();
                    txteduETC.Text = "";
                }

                if(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE_TO").ToString().Trim() != "")
                {
                    DateTime DT_TO = DateTime.Parse(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE_TO").ToString());
                    dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_TO.Value = DT_TO;
                }

                if(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE").ToString().Trim() != "")
                {
                    DateTime DT_FROM = DateTime.Parse(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE").ToString());
                    dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_FROM.Value = DT_FROM;
                }
                               

                //dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_TO.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE_TO").ToString();
                //txtSTAFF_TRAIN_DATE_TO.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE_TO").ToString();
                //DateTime DT_TO = DateTime.Parse(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE_TO").ToString());
                //dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_TO.Value = DT_TO;

                if(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_WRITE_DATE").ToString().Trim() != "")
                {
                    DateTime dt_write = DateTime.Parse(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_WRITE_DATE").ToString());
                    dtSTAFF_TRAIN_WRITE_DATE.Value = dt_write;
                }
                if(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_APPROVAL_DATE").ToString().Trim() != "")
                {
                    DateTime dt_approval = DateTime.Parse(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_APPROVAL_DATE").ToString());
                    dtSTAFF_TRAIN_WRITE_DATE.Value = dt_approval;
                }               

                Form2_GridIdx.sIDX = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("IDX").ToString();
                Form2PQMS_StaffInfo.sPQMS_STAFF_TR_FILE = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_REPORT_FILE").ToString();


                //참석자 명단 테이블 
                Form2PQMS_STAFF_TRAINING_Attendee_Select();


                if (e.Column.Caption.Equals("훈련결과증빙"))
                {
                    string strFile = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedDataRow()["STAFF_TRAIN_RESULT_DIR_FILE"].ToString();

                    FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                    if (fileInfo.Exists)
                    {
                        Process.Start(strFile);
                    }
                }
                if (e.Column.Caption.Equals("교육보고서"))
                {
                    string strFile = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedDataRow()["STAFF_TRAIN_REPORT_FILE"].ToString();

                    FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                    if (fileInfo.Exists)
                    {
                        Process.Start(strFile);
                    }
                }               
            }
            catch (Exception f)
            {                
                MessageBox.Show(f.Message + Environment.NewLine + f.Source);
            }
        }

        private void dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_ValueChanged(object sender, EventArgs e)
        {
            txtSTAFF_TRAIN_DATE_FROM.Text = dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_FROM.Text;
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
                


        private void btnInsertPQMS_STAFF_ROLE_PAPER_Click(object sender, EventArgs e)
        {
            

            if (txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text == "")
            {
                MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                return;
            }

            if (cmbRolePaper.Text == "")
            {
                MessageBox.Show("담당역할을 선택하세요. ");
                return;
            }

            if (cmbRPORGCODE.Text == "" || cmbRPGroup1Code.Text==""|| cmbRPGroup2Code.Text=="")
            {
                MessageBox.Show("자격분야를 선택하세요. ");
                return;
            }


            //if (txtROLE_PAPER_FINAL.Text == "Y")
            //{
            //    MessageBox.Show("기술서가 생성된 항목으로 수정 할 수 없습니다.");
            //    return;
            //}

            SqlTransaction trans = AppRes.DB.BeginTrans();
            try
            {

                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_DATE = dtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS = txtRPGroup1Code.Text + "-" + txtRPGroup2Code.Text;

                if (panel_RP_2.Visible == true)
                { 
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_2 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_2.Text;
                }
                if (panel_RP_3.Visible == true)
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_3 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_3.Text;
                }
                if (panel_RP_4.Visible == true)
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_4 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_4.Text;
                }
                if (panel_RP_5.Visible == true)
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_5 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_5.Text;
                }
                if (panel_RP_6.Visible == true)
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_6 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_6.Text;
                }

                if (txtSTAFF_RP_WRITER_PQMS_STAFF_ROLE_PAPER.Text == "")
                {
                    txtSTAFF_RP_WRITER_PQMS_STAFF_ROLE_PAPER.Text = Form2PQMS_StaffInfo.sStaffName; 
                }


                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_ORG_CODE = txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CODE = txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_APPROVER = txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_APPROVE_DATE = dtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_SUPPORTER = txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_WRITER = txtSTAFF_RP_WRITER_PQMS_STAFF_ROLE_PAPER.Text; //jhm0708
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_WRITE_DATE = dtSTAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER.Text; //jhm0708
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_FIRSTDATE = dtSTAFF_RP_FIRSTDATE.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CAREER = txtSTAFF_RP_CAREER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_REASON = txtSTAFF_RP_REASON.Text;

                string each_IDX = "";
                string tr_IDX = "";
                //수행능력평가 이력 체크한 리스트 
                foreach (int id in PQMS_RP_ROLE2_EACH_LISTGridView.GetSelectedRows())
                {
                    each_IDX = each_IDX + ", " + PQMS_RP_ROLE2_EACH_LISTGridView.GetRowCellValue(id, "IDX").ToString();
                }
                //교육보고수 이력 체크한 리스트 
                foreach (int id in Form2PQMS_STAFF_RP_TRAINING_GridView.GetSelectedRows())
                {
                    tr_IDX = tr_IDX + ", " + Form2PQMS_STAFF_RP_TRAINING_GridView.GetRowCellValue(id, "IDX").ToString();
                }

                if (each_IDX.Length <= 0 && txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text == "P006")
                {
                    MessageBox.Show("수행평가이력을 체크하세요.");
                    AppRes.DB.RollbackTrans();
                    return;
                }

                if (txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text == "P008") // 직무가 기타 
                { 

                }
                else
                {
                    if (tr_IDX.Length <= 0)
                    {
                        MessageBox.Show("교육훈련이력을 체크하세요.");
                        AppRes.DB.RollbackTrans();
                        return;
                    }
                }
                

                if (each_IDX != "")
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_EACHLIST_IDX = each_IDX.Substring(2);
                }
                else
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_EACHLIST_IDX = "";
                }

                if (tr_IDX != "")
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_TRANING_IDX = tr_IDX.Substring(2);
                }
                else
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_TRANING_IDX = "";
                }
                               


                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.Insert(trans);
                AppRes.DB.CommitTrans();
                MessageBox.Show("직무기술서 입력 완료!");
                Field_Reset("txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER");

                //직무기술서 파일 자동 생성 시작                 
                string RP_templeate = @"\\10.153.4.98\DI\PQMS\Template\RolePaper\CQP-6021-F02 (01) 직무기술서.docx";
                                
                string RP_idx_query = " SELECT IDX, STAFF_RP_CODE, STAFF_RP_ORG_CODE FROM PQMS_STAFF_ROLE_PAPER " +
                    " WHERE IDX = (SELECT MAX(IDX) FROM PQMS_STAFF_ROLE_PAPER WHERE STAFF_CODE = '" + txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text + "')";

                OleDbCommand cmd = new OleDbCommand(RP_idx_query, Conn);
                Conn.Open();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX = reader.GetValue(0).ToString();                            
                            Form2PQMS_StaffInfo.sPQMS_STAFF_RP_CODE = reader.GetValue(1).ToString();
                            Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE = reader.GetValue(2).ToString();
                        }
                    }
                }
                Conn.Close();

                //저장된 자격분야 확인 해서 넘겨주기 ..
                string s_qyery = " SELECT     d.GROUP2_NAME   , isnull(d2.GROUP2_NAME,'') as GROUP2_NAME_2  ,isnull(d3.GROUP2_NAME,'') as GROUP2_NAME_3 , isnull(d4.GROUP2_NAME,'') as GROUP2_NAME_4  , isnull(d5.GROUP2_NAME,'') as GROUP2_NAME_5  , isnull(d6.GROUP2_NAME, '') as GROUP2_NAME_6 " +
                                " FROM[PQMS_STAFF_ROLE_PAPER] AS a" +
                                " inner join PQMS_ORG b on a.STAFF_RP_ORG_CODE = b.ORG_CODE and b.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and b.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and b.WS_CODE = '"+Form1PQMS_Repo.sWS+"'" +
                                " inner join PQMS_GROUP1 c on a.STAFF_RP_ORG_CODE = c.GROUP1_ORG_CODE and left(a.STAFF_RP_CLASS,4) = c.GROUP1_CODE and c.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and c.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and c.WS_CODE = '"+Form1PQMS_Repo.sWS+"'" +
                                " inner join PQMS_GROUP2 d on a.STAFF_RP_ORG_CODE = d.GROUP2_ORG_CODE and c.GROUP1_CODE = d.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS,4)= d.GROUP2_CODE   and d.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and d.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and d.WS_CODE = '"+Form1PQMS_Repo.sWS+"'" +
                                " left outer join PQMS_GROUP2 d2 on a.STAFF_RP_ORG_CODE = d2.GROUP2_ORG_CODE and c.GROUP1_CODE = d2.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_2,4)= d2.GROUP2_CODE   and d2.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and d2.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and d2.WS_CODE = '"+Form1PQMS_Repo.sWS+"'" +
                                " left outer join PQMS_GROUP2 d3 on a.STAFF_RP_ORG_CODE = d3.GROUP2_ORG_CODE and c.GROUP1_CODE = d3.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_3,4)= d3.GROUP2_CODE   and d3.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and d3.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and d3.WS_CODE = '"+Form1PQMS_Repo.sWS+"'" +
                                " left outer join PQMS_GROUP2 d4 on a.STAFF_RP_ORG_CODE = d4.GROUP2_ORG_CODE and c.GROUP1_CODE = d4.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_4,4)= d4.GROUP2_CODE   and d4.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and d4.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and d4.WS_CODE = '"+Form1PQMS_Repo.sWS+"'" +
                                " left outer join PQMS_GROUP2 d5 on a.STAFF_RP_ORG_CODE = d5.GROUP2_ORG_CODE and c.GROUP1_CODE = d5.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_5,4)= d5.GROUP2_CODE   and d5.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and d5.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and d5.WS_CODE = '"+Form1PQMS_Repo.sWS+"'" +
                                " left outer join PQMS_GROUP2 d6 on a.STAFF_RP_ORG_CODE = d6.GROUP2_ORG_CODE and c.GROUP1_CODE = d6.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_6,4)= d6.GROUP2_CODE   and d6.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and d6.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and d6.WS_CODE = '"+Form1PQMS_Repo.sWS+"'" +
                                " inner join PQMS_ROLE2_CODE e on a.STAFF_RP_CODE = e.ROLE_CODE and e.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and e.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and e.WS_CODE = '"+Form1PQMS_Repo.sWS+"'" +
                                " where a.STAFF_CODE = '" + txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text + "' and a.IDX = '"+ Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX  + "'";

                cmd = new OleDbCommand(s_qyery, Conn);
                Conn.Open();
                string[] s_Group2_Name = new string[6];
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        { 
                            s_Group2_Name[0] = reader.GetValue(0).ToString();
                            s_Group2_Name[1] = reader.GetValue(1).ToString();
                            s_Group2_Name[2] = reader.GetValue(2).ToString();
                            s_Group2_Name[3] = reader.GetValue(3).ToString();
                            s_Group2_Name[4] = reader.GetValue(4).ToString();
                            s_Group2_Name[5] = reader.GetValue(5).ToString();
                        }                        
                    }
                }
                Conn.Close();

                string s_Group2_Name_Final="";
                for (int i = 0; i < 6; i++)
                {
                    if (s_Group2_Name[i].Length > 0)
                    {
                        s_Group2_Name_Final = s_Group2_Name_Final + ", " + s_Group2_Name[i];
                    }
                }

                //보고서 파일 자동생성 
                string sDateTime_yyyyMM_RP_Report = DateTime.Now.ToString("yyyyMM");
                string savrfilepath_RP_Report = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\RolePaper\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "직무기술서" + @"\" + sDateTime_yyyyMM_RP_Report;

                DirectoryInfo file_di_tr_Report = new DirectoryInfo(savrfilepath_RP_Report);
                if (file_di_tr_Report.Exists == false)
                {
                    Directory.CreateDirectory(savrfilepath_RP_Report);
                }

                unitCommon.CreateDoc_RP(RP_templeate, Form2PQMS_StaffInfo.sStaffCode, savrfilepath_RP_Report, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX, Form2PQMS_StaffInfo.sPQMS_STAFF_RP_CODE, Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_EACHLIST_IDX, Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_TRANING_IDX, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE, s_Group2_Name_Final.Substring(2));

                btnNEWPQMS_STAFF_ROLE_PAPER_Click(sender, e);
                btnSelectPQMS_STAFF_ROLE_PAPER.PerformClick();

            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void btnUpdatePQMS_STAFF_ROLE_PAPER_Click(object sender, EventArgs e)
        {
            if (Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_ROLE_PAPER_APPROVE_STATUS == "1")
            {
                MessageBox.Show("승인완료된 데이터는 수정 할 수 없습니다. ");
                return;
            }
            if (txtROLE_PAPER_FINAL.Text == "Y")
            {
                MessageBox.Show("직무기술서가 생성된 자료는 수정 할 수 없습니다. 직무기술서를 삭제 후 수정이 가능합니다.");
                return;
            }
            SqlTransaction trans = AppRes.DB.BeginTrans();
            try
            {
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.iIDX = Convert.ToInt32(txtIDX_PQMS_STAFF_ROLE_PAPER.Text);
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_DATE = dtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS = txtRPGroup1Code.Text + "-" + txtRPGroup2Code.Text;

                if (panel_RP_2.Visible == true)
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_2 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_2.Text;
                }
                else
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_2 = "";
                }
                if (panel_RP_3.Visible == true)
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_3 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_3.Text;
                }
                else
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_3 = "";
                }
                if (panel_RP_4.Visible == true)
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_4 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_4.Text;
                }
                else
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_4 = "";
                }
                if (panel_RP_5.Visible == true)
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_5 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_5.Text;
                }
                else
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_5 = "";
                }
                if (panel_RP_6.Visible == true)
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_6 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_6.Text;
                }
                else
                {
                    Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_6 = "";
                }

                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_ORG_CODE = txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CODE = txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_APPROVER = txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_APPROVE_DATE = dtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_SUPPORTER = txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_WRITER = txtSTAFF_RP_WRITER_PQMS_STAFF_ROLE_PAPER.Text; //jhm0708
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_WRITE_DATE = dtSTAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER.Text; //jhm0708

                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_FIRSTDATE = dtSTAFF_RP_FIRSTDATE.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CAREER = txtSTAFF_RP_CAREER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_REASON = txtSTAFF_RP_REASON.Text;


                string each_IDX = "";
                string tr_IDX = "";
                //수행능력평가 이력 체크한 리스트 
                foreach (int id in PQMS_RP_ROLE2_EACH_LISTGridView.GetSelectedRows())
                {
                    each_IDX = each_IDX + ", " + PQMS_RP_ROLE2_EACH_LISTGridView.GetRowCellValue(id, "IDX").ToString();
                }

                //교육보고수 이력 체크한 리스트 
                foreach (int id in Form2PQMS_STAFF_RP_TRAINING_GridView.GetSelectedRows())
                {
                    tr_IDX = tr_IDX + ", " + Form2PQMS_STAFF_RP_TRAINING_GridView.GetRowCellValue(id, "IDX").ToString();
                }

                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_EACHLIST_IDX = each_IDX.Substring(2);
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_TRANING_IDX = tr_IDX.Substring(2);


                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.Update(trans);
                AppRes.DB.CommitTrans();
                MessageBox.Show("직무기술서 수정 완료!");
                Field_Reset("txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER");


                //서버에서 직무기술서  파일삭제
                if (File.Exists(Form2PQMS_StaffInfo.sPQMS_STAFF_RP_FILE))
                {
                    File.Delete(Form2PQMS_StaffInfo.sPQMS_STAFF_RP_FILE);
                }

                //파일 삭제 후 재생성 로직 시작 
                //직무기술서 파일 자동 생성 시작                 
                string RP_templeate = @"\\10.153.4.98\DI\PQMS\Template\RolePaper\CQP-6021-F02 (01) 직무기술서.docx";

                string RP_idx_query = " SELECT IDX, STAFF_RP_CODE, STAFF_RP_ORG_CODE FROM PQMS_STAFF_ROLE_PAPER " +
                    " WHERE IDX = (SELECT MAX(IDX) FROM PQMS_STAFF_ROLE_PAPER WHERE STAFF_CODE = '" + txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text + "')";

                OleDbCommand cmd = new OleDbCommand(RP_idx_query, Conn);
                Conn.Open();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX = reader.GetValue(0).ToString();
                            Form2PQMS_StaffInfo.sPQMS_STAFF_RP_CODE = reader.GetValue(1).ToString();
                            Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE = reader.GetValue(2).ToString();
                        }
                    }
                }
                Conn.Close();

                //저장된 자격분야 확인 해서 넘겨주기 ..
                string s_qyery = " SELECT     d.GROUP2_NAME   , isnull(d2.GROUP2_NAME,'') as GROUP2_NAME_2  ,isnull(d3.GROUP2_NAME,'') as GROUP2_NAME_3 , isnull(d4.GROUP2_NAME,'') as GROUP2_NAME_4  , isnull(d5.GROUP2_NAME,'') as GROUP2_NAME_5  , isnull(d6.GROUP2_NAME, '') as GROUP2_NAME_6 " +
                                " FROM[PQMS_STAFF_ROLE_PAPER] AS a" +
                                " inner join PQMS_ORG b on a.STAFF_RP_ORG_CODE = b.ORG_CODE and b.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                " inner join PQMS_GROUP1 c on a.STAFF_RP_ORG_CODE = c.GROUP1_ORG_CODE and left(a.STAFF_RP_CLASS,4) = c.GROUP1_CODE and c.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and c.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and c.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                " inner join PQMS_GROUP2 d on a.STAFF_RP_ORG_CODE = d.GROUP2_ORG_CODE and c.GROUP1_CODE = d.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS,4)= d.GROUP2_CODE   and d.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                " left outer join PQMS_GROUP2 d2 on a.STAFF_RP_ORG_CODE = d2.GROUP2_ORG_CODE and c.GROUP1_CODE = d2.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_2,4)= d2.GROUP2_CODE   and d2.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d2.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d2.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                " left outer join PQMS_GROUP2 d3 on a.STAFF_RP_ORG_CODE = d3.GROUP2_ORG_CODE and c.GROUP1_CODE = d3.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_3,4)= d3.GROUP2_CODE   and d3.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d3.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d3.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                " left outer join PQMS_GROUP2 d4 on a.STAFF_RP_ORG_CODE = d4.GROUP2_ORG_CODE and c.GROUP1_CODE = d4.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_4,4)= d4.GROUP2_CODE   and d4.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d4.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d4.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                " left outer join PQMS_GROUP2 d5 on a.STAFF_RP_ORG_CODE = d5.GROUP2_ORG_CODE and c.GROUP1_CODE = d5.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_5,4)= d5.GROUP2_CODE   and d5.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d5.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d5.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                " left outer join PQMS_GROUP2 d6 on a.STAFF_RP_ORG_CODE = d6.GROUP2_ORG_CODE and c.GROUP1_CODE = d6.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_6,4)= d6.GROUP2_CODE   and d6.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d6.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d6.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                " inner join PQMS_ROLE2_CODE e on a.STAFF_RP_CODE = e.ROLE_CODE and e.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and e.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and e.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                " where a.STAFF_CODE = '" + txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text + "' and a.IDX = '" + Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX + "'";

                cmd = new OleDbCommand(s_qyery, Conn);
                Conn.Open();
                string[] s_Group2_Name = new string[6];
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            s_Group2_Name[0] = reader.GetValue(0).ToString();
                            s_Group2_Name[1] = reader.GetValue(1).ToString();
                            s_Group2_Name[2] = reader.GetValue(2).ToString();
                            s_Group2_Name[3] = reader.GetValue(3).ToString();
                            s_Group2_Name[4] = reader.GetValue(4).ToString();
                            s_Group2_Name[5] = reader.GetValue(5).ToString();
                        }
                    }
                }
                Conn.Close();

                string s_Group2_Name_Final = "";
                for (int i = 0; i < 6; i++)
                {
                    if (s_Group2_Name[i].Length > 0)
                    {
                        s_Group2_Name_Final = s_Group2_Name_Final + ", " + s_Group2_Name[i];
                    }
                }

                //보고서 파일 자동생성 
                string sDateTime_yyyyMM_RP_Report = DateTime.Now.ToString("yyyyMM");
                string savrfilepath_RP_Report = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\RolePaper\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "직무기술서" + @"\" + sDateTime_yyyyMM_RP_Report;

                DirectoryInfo file_di_tr_Report = new DirectoryInfo(savrfilepath_RP_Report);
                if (file_di_tr_Report.Exists == false)
                {
                    Directory.CreateDirectory(savrfilepath_RP_Report);
                }

                unitCommon.CreateDoc_RP(RP_templeate, Form2PQMS_StaffInfo.sStaffCode, savrfilepath_RP_Report, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX, Form2PQMS_StaffInfo.sPQMS_STAFF_RP_CODE, Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_EACHLIST_IDX, Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_TRANING_IDX, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE, s_Group2_Name_Final.Substring(2));

                btnNEWPQMS_STAFF_ROLE_PAPER_Click(sender, e);
                btnSelectPQMS_STAFF_ROLE_PAPER.PerformClick();
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("수정 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void btnDeletePQMS_STAFF_ROLE_PAPER_Click(object sender, EventArgs e)
        {
            if (Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_ROLE_PAPER_APPROVE_STATUS == "1")
            {
                MessageBox.Show("승인완료된 데이터는 삭제 할 수 없습니다. ");
                return;
            }
            if (txtROLE_PAPER_FINAL.Text == "Y")
            {
                MessageBox.Show("직무기술서가 생성된 자료는 삭제 할 수 없습니다. 직무기술서를 삭제 후 삭제가 가능합니다.");
                return;
            }

            SqlTransaction trans = AppRes.DB.BeginTrans();
            try
            {
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.iIDX = Convert.ToInt32(txtIDX_PQMS_STAFF_ROLE_PAPER.Text);
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.Delete(trans);
                AppRes.DB.CommitTrans();

                //서버에서 직무기술서  파일삭제
                if (File.Exists(Form2PQMS_StaffInfo.sPQMS_STAFF_RP_FILE))
                {
                    File.Delete(Form2PQMS_StaffInfo.sPQMS_STAFF_RP_FILE);
                }

                MessageBox.Show("삭제 완료!");
                
                btnNEWPQMS_STAFF_ROLE_PAPER_Click(sender, e);
                btnSelectPQMS_STAFF_ROLE_PAPER.PerformClick();
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            try
            {
                Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_ROLE_PAPER_APPROVE_STATUS = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("approveStatusCode").ToString();
                txtIDX_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("IDX").ToString();
                txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();
                txtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_DATE").ToString();
                txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_ORG_CODE").ToString();
                txtSTAFF_RP_CLASS_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_CLASS").ToString();
                txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_APPROVER").ToString();
                txtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_APPROVE_DATE").ToString();
                txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_SUPPORTER").ToString();
                txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER_NAME.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["ORG_NAME"].ToString();
                //cmbRPORGCODE.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["ORG_CODE"].ToString() + " " + PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["ORG_NAME"].ToString();

                cmbRPORGCODE.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["ORG_NAME"].ToString();

                //jhm0708
                txtSTAFF_RP_WRITER_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_WRITER").ToString();
                txtSTAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_WRITE_DATE").ToString();

                //jhm0708
                DateTime dt_STAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER = DateTime.Parse(txtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER.Text);
                dtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER.Value = dt_STAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER;
                DateTime dt_STAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER = DateTime.Parse(txtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER.Text);
                dtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER.Value = dt_STAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER;
                DateTime dt_STAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER = DateTime.Parse(txtSTAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER.Text);
                dtSTAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER.Value = dt_STAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER;

                DateTime dt_STAFF_RP_FIRSTDATE = DateTime.Parse(PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_FRISTDATE").ToString());
                dtSTAFF_RP_FIRSTDATE.Value = dt_STAFF_RP_FIRSTDATE;

                txtSTAFF_RP_CAREER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_CAREER").ToString();
                txtSTAFF_RP_REASON.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_REASON").ToString();

                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("IDX").ToString();
                Form2_GridIdx.sIDX = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("IDX").ToString();
                Form2PQMS_StaffInfo.sPQMS_STAFF_RP_FILE = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_FILE").ToString();

                txtROLE_PAPER_FINAL.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_FINAL").ToString();

                txtRPGroup1Code.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP1_CODE"].ToString();
                txtRPGroup2Code.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_CODE"].ToString();
                txtRPGroup1Name.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP1_NAME"].ToString();
                txtRPGroup2Name.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_NAME"].ToString();

                //cmbRPGroup1Code.Text = txtRPGroup1Code.Text + " " + txtRPGroup1Name.Text;
                //cmbRPGroup2Code.Text = txtRPGroup2Code.Text + " " + txtRPGroup2Name.Text;

                cmbRPGroup1Code.Text = txtRPGroup1Name.Text;
                cmbRPGroup2Code.Text = txtRPGroup2Name.Text;

                txtRPGroup2Code_2.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_CODE_2"].ToString();
                txtRPGroup2Name_2.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_NAME_2"].ToString();

                txtRPGroup2Code_3.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_CODE_3"].ToString();
                txtRPGroup2Name_3.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_NAME_3"].ToString();

                txtRPGroup2Code_4.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_CODE_4"].ToString();
                txtRPGroup2Name_4.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_NAME_4"].ToString();

                txtRPGroup2Code_5.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_CODE_5"].ToString();
                txtRPGroup2Name_5.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_NAME_5"].ToString();

                txtRPGroup2Code_6.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_CODE_6"].ToString();
                txtRPGroup2Name_6.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["GROUP2_NAME_6"].ToString();



                //자격부여코드이름..ㅋㅋ휴 ...
                if (PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["STAFF_RP_CLASS_2"].ToString().Length == 9)
                {                                      
                    panel_RP_2.Visible = true;
                    panel_RP_2.Location = new Point(cmbRPORGCODE.Location.X, cmbRPGroup2Code.Location.Y+25) ;
                    panel_RP_LIST.Location = new Point(label10.Location.X-3, cmbRPGroup2Code.Location.Y + 50);
                    btn_ADD_1.Text = "-";
                    cmbRPGroup2Code_2.Text = txtRPGroup2Name_2.Text;
                }
                if (PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["STAFF_RP_CLASS_3"].ToString().Length == 9)
                {
                    panel_RP_3.Visible = true;
                    panel_RP_3.Location = new Point(panel_RP_2.Location.X, panel_RP_2.Location.Y+25);
                    panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_2.Location.Y + 50);
                    btn_ADD_2.Text = "-";
                    cmbRPGroup2Code_3.Text = txtRPGroup2Name_3.Text;
                }
                if (PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["STAFF_RP_CLASS_4"].ToString().Length == 9)
                {
                    panel_RP_4.Visible = true;
                    panel_RP_4.Location = new Point(panel_RP_3.Location.X, panel_RP_3.Location.Y + 25);
                    panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_3.Location.Y + 50);
                    btn_ADD_3.Text = "-";
                    cmbRPGroup2Code_4.Text = txtRPGroup2Name_4.Text;
                }
                if (PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["STAFF_RP_CLASS_5"].ToString().Length == 9)
                {
                    panel_RP_5.Visible = true;
                    panel_RP_5.Location = new Point(panel_RP_4.Location.X, panel_RP_4.Location.Y + 25);
                    panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_5.Location.Y + 50);
                    btn_ADD_4.Text = "-";
                    cmbRPGroup2Code_5.Text = txtRPGroup2Name_5.Text;
                }
                if (PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["STAFF_RP_CLASS_6"].ToString().Length == 9)
                {
                    panel_RP_6.Visible = true;
                    panel_RP_6.Location = new Point(panel_RP_5.Location.X, panel_RP_5.Location.Y + 25);
                    panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_5.Location.Y + 50);
                    btn_ADD_5.Text = "-";
                    cmbRPGroup2Code_6.Text = txtRPGroup2Name_6.Text;
                }

                txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_CODE").ToString();
                txtSTAFF_RP_NAME_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["ROLE_NAME"].ToString();
                //cmbRolePaper.Text = txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text + " " + txtSTAFF_RP_NAME_PQMS_STAFF_ROLE_PAPER.Text;
                cmbRolePaper.Text = txtSTAFF_RP_NAME_PQMS_STAFF_ROLE_PAPER.Text;

                PQMS_RP_ROLE2_EACH_LISTGridView.ClearSelection();
                //수행능력평가이력 체크박스 선택 
                string[] each_IDX = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_EACHLIST_IDX").ToString().Split(',');                
                for (int i = 0; i < each_IDX.Length; i++)
                {
                    each_IDX[i] = each_IDX[i].Replace(" ", ""); // Remove spaces
                }
                for (int i = 0; i < PQMS_RP_ROLE2_EACH_LISTGridView.RowCount; i++)
                {
                    object dataValue = PQMS_RP_ROLE2_EACH_LISTGridView.GetRowCellValue(i, "IDX");

                    if (dataValue != null && each_IDX.Contains(dataValue.ToString().Trim()))
                    {
                        PQMS_RP_ROLE2_EACH_LISTGridView.SelectRow(i);
                    }
                }
                Form2PQMS_STAFF_RP_TRAINING_GridView.ClearSelection();
                //교육보고수 체크박스 선택 
                string[] tr_IDX = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_TRANING_IDX").ToString().Split(',');
                for (int i = 0; i < tr_IDX.Length; i++)
                {
                    tr_IDX[i] = tr_IDX[i].Replace(" ", ""); // Remove spaces
                }
                for (int i = 0; i < Form2PQMS_STAFF_RP_TRAINING_GridView.RowCount; i++)
                {
                    object dataValue = Form2PQMS_STAFF_RP_TRAINING_GridView.GetRowCellValue(i, "IDX");

                    if (dataValue != null && tr_IDX.Contains(dataValue.ToString().Trim()))
                    {
                        Form2PQMS_STAFF_RP_TRAINING_GridView.SelectRow(i);
                    }
                }
                if (e.Column.Caption.Equals("직무기술서"))
                {
                    string strFile = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedDataRow()["STAFF_RP_FILE"].ToString();
                    FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                    if (fileInfo.Exists)
                    {
                        Process.Start(strFile);
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message + Environment.NewLine + f.Source);
            }
        }

        private void btnSelectPQMS_STAFF_ROLE_PAPER_Click(object sender, EventArgs e)
        {
            Call_PQMS_STAFF_ROLE_PAPER();
        }

        private void btnEduReport_Click(object sender, EventArgs e)
        {
            //Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE;
            Form2PQMS_StaffInfo.sStaffCode = txtSTAFF_CODE_PQMS_STAFF_TRAINING.Text;

            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
            {
                MessageBox.Show("사원을 선택해주세요.");
                return;
            }

            string sFormName = "frmEduReport";
            frmEduReport childEduReport = new frmEduReport();

            if (unitCommon.YNFrom(sFormName))
            {
                childEduReport.Dispose();     // 창 리소스 제거
            }
            else
            {
                childEduReport.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 
                childEduReport.WindowState = FormWindowState.Normal;
                childEduReport.ShowDialog();
            }
        }

        private void btnEduHistoryDaejang_Click(object sender, EventArgs e)
        {
            //CreateDoc_trainingHistory();

            Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE;

            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
            {
                MessageBox.Show("사원을 선택해주세요.");
                return;
            }

            string sFormName = "frmEduHistoryDaejang";
            frmEduHistoryDaejang childEduHistoryDaejang = new frmEduHistoryDaejang(this);

            if (unitCommon.YNFrom(sFormName))
            {
                childEduHistoryDaejang.Dispose();     // 창 리소스 제거
            }
            else
            {
                childEduHistoryDaejang.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 
                childEduHistoryDaejang.WindowState = FormWindowState.Normal;
                childEduHistoryDaejang.ShowDialog();
            }
        }


  

        private void btnStaff_ROLE_PAER_Click(object sender, EventArgs e)
        {
            Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE;
            Form2PQMS_StaffInfo.sPMQ_STAFF_ROLE_PAPER_ORG_CODE = txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text;

            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
            {
                MessageBox.Show("사원을 선택해주세요.");
                return;
            }

            string sFormName = "frmRolePaper";
            frmRolePaper childRolePaper = new frmRolePaper();

            if (unitCommon.YNFrom(sFormName))
            {
                childRolePaper.Dispose();     // 창 리소스 제거
            }
            else
            {
                childRolePaper.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 
                childRolePaper.WindowState = FormWindowState.Normal;
                childRolePaper.ShowDialog();
            }
        }

        private void btnInsertApproveInfo_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2_ApproveInfo_Set.smenuNo = txtMenuNo.Text;
                if (string.IsNullOrEmpty(txtIdx_PQMS_STAFF_TRAINING_EduBogo.Text) == false)
                {
                    Form2_ApproveInfo_Set.Insert_approveMaster(tabPage8.Text, txtIdx_PQMS_STAFF_TRAINING_EduBogo.Text, trans);
                    Form2_ApproveInfo_Set.Insert_ApproveInfo(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("입력 완료!");
                }
                else
                {
                    MessageBox.Show("표의 정보를 선택해주세요.");
                }

            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            Form2_Anyang form22 = new Form2_Anyang();

            Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridSet.smenuName = form22.Text;
            Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridSet.stabName = form22.tabPage4.Text;

            Form2_Tab_Info_Now.sMenuName = form22.Text;
            Form2_Tab_Info_Now.sTabName = form22.tabPage4.Text;

            Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridSet.sAppID = Form2PQMS_LoginInfo.sAppId;

            // {smenuName}' and appID = '{sAppID}'";
            Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridSet.Select();
            Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridSet.Fetch();

            txtMenuNo.Text = Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridSet.sMenuNo;
            txtMenuName.Text = Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridSet.smenuName;
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            Form2_Anyang form22 = new Form2_Anyang();

            Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridSet.smenuName = form22.Text;
            Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridSet.stabName = form22.tabPage5.Text;

            Form2_Tab_Info_Now.sMenuName = form22.Text;
            Form2_Tab_Info_Now.sTabName = form22.tabPage5.Text;

            Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridSet.sAppID = Form2PQMS_LoginInfo.sAppId;

            // {smenuName}' and appID = '{sAppID}'";
            Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridSet.Select();
            Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridSet.Fetch();

            txtMenuNo.Text = Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridSet.sMenuNo;
            txtMenuName.Text = Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridSet.smenuName;

            Call_PQMS_STAFF_ROLE_PAPER();
        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            Form2_Anyang form22 = new Form2_Anyang();

            Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridSet.smenuName = form22.Text;
            Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridSet.stabName = form22.tabPage7.Text;

            Form2_Tab_Info_Now.sMenuName = form22.Text;
            Form2_Tab_Info_Now.sTabName = form22.tabPage7.Text;

            Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridSet.sAppID = Form2PQMS_LoginInfo.sAppId;

            // {smenuName}' and appID = '{sAppID}'";
            Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridSet.Select();
            Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridSet.Fetch();

            txtMenuNo.Text = Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridSet.sMenuNo;
            txtMenuName.Text = Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridSet.smenuName;

            cmbEACH_LIST_METHODS.Items.Clear();
            cmbEACH_LIST_METHODS.Items.Add("PT");
            cmbEACH_LIST_METHODS.Items.Add("비교시험");
            cmbEACH_LIST_METHODS.Items.Add("유효성검증");
            cmbEACH_LIST_METHODS.Items.Add("기타");

            cmbEACH_LIST_RESULT.Items.Clear();
            cmbEACH_LIST_RESULT.Items.Add("적합");
            cmbEACH_LIST_RESULT.Items.Add("부적합");

            txtEACH_LIST_ROLE_TYPE.Text = "실무자";
            txtEHCH_LIST_CHANGE.Text = "적합한 결과에 따른 최종(현재) 자격이 부여된 시험항목을 나열";
            txtMainLIST_CONTENTS1_EACH_LIST.Text = "IEC 62321-6 : 2015 , Determination of certain substances in electrotechnical products - Part 6: Polybrominated biphenyls and polybrominated diphenyl ethers in polymers by gas chromatograhy -mass spectometry (GC-MS) ,규격이 없을 시 항목 기재";           
        }

        private void tabPage8_Enter(object sender, EventArgs e)
        {
            Form2_Anyang form22 = new Form2_Anyang();

            Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridSet.smenuName = form22.Text;
            Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridSet.stabName = form22.tabPage8.Text;

            Form2_Tab_Info_Now.sMenuName = form22.Text;
            Form2_Tab_Info_Now.sTabName = form22.tabPage8.Text;

            Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridSet.sAppID = Form2PQMS_LoginInfo.sAppId;

            // {smenuName}' and appID = '{sAppID}'";
            Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridSet.Select();
            Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridSet.Fetch();

            txtMenuNo.Text = Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridSet.sMenuNo;
            txtMenuName.Text = Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridSet.smenuName;

            txtSTAFF_TRAIN_WRITER.Text = Form2PQMS_StaffInfo.sStaffName;

        }

        private void tabPage10_Enter(object sender, EventArgs e)
        {
            Form2_Anyang form22 = new Form2_Anyang();

            Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridSet.smenuName = form22.Text;
            Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridSet.stabName = form22.tabPage10.Text;

            Form2_Tab_Info_Now.sMenuName = form22.Text;
            Form2_Tab_Info_Now.sTabName = form22.tabPage10.Text;

            Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridSet.sAppID = Form2PQMS_LoginInfo.sAppId;

            // {smenuName}' and appID = '{sAppID}'";
            Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridSet.Select();
            Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridSet.Fetch();

            txtMenuNo.Text = Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridSet.sMenuNo;
            txtMenuName.Text = Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridSet.smenuName;
        }

        private void btnInsertPQMS_STAFF_TRAINING_STAFF_TRAIN_CONTENTS_Click(object sender, EventArgs e)
        {
            string sFormName = "frmSTAFF_TRAIN_CONTENTS";
            frmSTAFF_TRAIN_CONTENTS childfrmSTAFF_TRAIN_CONTENTS = new frmSTAFF_TRAIN_CONTENTS();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrmSTAFF_TRAIN_CONTENTS.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmSTAFF_TRAIN_CONTENTS.WindowState = FormWindowState.Normal;
                childfrmSTAFF_TRAIN_CONTENTS.ShowDialog();

                // 조직 선택이 되어 있을때만 활성화
                //if (!string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName))
                //{
                //    txtSTAFF_TEAM.Text = FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName;
                //}
            }
        }

        private void btnInsertSTAFF_TRAIN_RESULT_Click(object sender, EventArgs e)
        {
            string fileContent = string.Empty;
            string filePath = string.Empty;

            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //바탕화면으로 기본폴더 설정
                fd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //필터 설정
                fd.FilterIndex = 2; //1번 선택시 txt , 2번 선택시 *.*

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    filePath = fd.FileName; //전체 경로와 파일명 //선택한 파일명은 fd.SafeFileName
                    txtSTAFF_TRAIN_RESULT.Text = filePath;
                }
            }
        }

        private void btnAttachmentSTAFF_ROLE_QUALITY_SCORE_Click(object sender, EventArgs e)
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
                    txtSTAFF_ROLE_QUALITY_DIR_FILE.Text = filePath;
                }
            }
        }

        private void btnAttachmentSTAFF_ROLE_TEST_SCORE_Click(object sender, EventArgs e)
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
                    txtSTAFF_ROLE_TEST_DIR_FILE.Text = filePath;
                }
            }
        }

        private void btnOpenSTAFF_ROLE_QUALITY_SCORE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSTAFF_ROLE_QUALITY_DIR_FILE.Text) == false)
            {
                Process.Start(txtSTAFF_ROLE_QUALITY_DIR_FILE.Text);
            }
        }

        private void btnOpenSTAFF_ROLE_TEST_SCORE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSTAFF_ROLE_TEST_DIR_FILE.Text) == false)
            {
                Process.Start(txtSTAFF_ROLE_TEST_DIR_FILE.Text);
            }
        }

        private void btnAttachmentSTAFF_TRAIN_RESULT_Click(object sender, EventArgs e)
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
                    txtSTAFF_TRAIN_RESULT_DIR_FILE.Text = filePath;
                }
            }
        }

        private void btnOpenSTAFF_TRAIN_RESULT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text) == false)
            {
                Process.Start(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text);
            }
        }

        private void btnInsertPQMS_STAFF_PRE_JOB_INFO_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode))
            {
                return;
            }

            string sFormName = "frmPQMS_STAFF_PRE_JOB_INFO";
            frmPQMS_STAFF_PRE_JOB_INFO childfrmPQMS_STAFF_PRE_JOB_INFO = new frmPQMS_STAFF_PRE_JOB_INFO();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrmPQMS_STAFF_PRE_JOB_INFO.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmPQMS_STAFF_PRE_JOB_INFO.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 

                childfrmPQMS_STAFF_PRE_JOB_INFO.WindowState = FormWindowState.Normal;
                childfrmPQMS_STAFF_PRE_JOB_INFO.ShowDialog();
            }

            Call_STAFF_Main_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);
            Call_STAFF_Main_Pre_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);
        }

        private void btnExportXlsx_Click(object sender, EventArgs e)
        {
            try
            {
                exportExcel(PQMS_STAFF_AllGrid);
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message + Environment.NewLine + f.Source);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            get_folder_RolePaper(cmbRolePaper);
        }

        private void get_folder_RolePaper(System.Windows.Forms.ComboBox tCmb) //jhm0708
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

        private void cmbRolePaper_SelectedIndexChanged(object sender, EventArgs e) //jhm0708
        {
            //txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text = cmbRolePaper.Text.Substring(0, 4);
            //txtSTAFF_RP_NAME_PQMS_STAFF_ROLE_PAPER.Text = cmbRolePaper.Text.Substring(5, cmbRolePaper.Text.Length - 5);

            string selectedText = cmbRolePaper.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text = comboBoxData[selectedText];
                txtSTAFF_RP_NAME_PQMS_STAFF_ROLE_PAPER.Text = selectedText.ToString();
            }
        }

        private void dtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER_ValueChanged(object sender, EventArgs e) //jhm0708
        {
            txtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER.Text = dtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER.Text;
        }

        private void dtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER_ValueChanged(object sender, EventArgs e) //jhm0708
        {
            txtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER.Text = dtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER.Text;
        }

        private void dtSTAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER_ValueChanged(object sender, EventArgs e) //jhm0708
        {
            txtSTAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER.Text = dtSTAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER.Text;
        }

        private void btnAttachmentCerti_Click_1(object sender, EventArgs e)
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

        private void btnExport현황Xlsx_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmb현황.Text) == true)
                {
                    return;
                }
                else if (cmb현황.Text.Equals("인원정보"))
                {
                    exportExcel(PQMS_STAFF_InfoMainGrid);
                }
                else if (cmb현황.Text.Equals("직무자료"))
                {
                    exportExcel(PQMS_STAFF_ROLE_InfoGrid);
                }
                else if (cmb현황.Text.Equals("자격증자료"))
                {
                    exportExcel(PQMS_STAFF_CERTIMainGrid);
                }
                else if (cmb현황.Text.Equals("교육자료"))
                {
                    exportExcel(PQMS_STAFF_TRAINING_InfoGrid);
                }
                else if (cmb현황.Text.Equals("개인별업무목록"))
                {
                    exportExcel(PQMS_ROLE2_EACH_LISTInfoGrid);
                }
                else if (cmb현황.Text.Equals("모두"))
                {
                    DevExpress.XtraPrinting.XlsxExportOptionsEx xlsxOptions = new DevExpress.XtraPrinting.XlsxExportOptionsEx();

                    // 라인출력
                    xlsxOptions.ShowGridLines = false;

                    // sheet 명
                    xlsxOptions.SheetName = "현황정보";
                    xlsxOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG;    // ExportType

                    string rpt = @"";

                    SaveFileDialog saveFile = new SaveFileDialog();

                    // 다이얼 로그가 Open되었을 때 최초의 경로 설정
                    //saveFile.InitialDirectory = @"C:";   

                    // 다이얼 로그의 제목
                    saveFile.Title = "Excel 저장 위치 지정";

                    // 기본 확장자
                    saveFile.DefaultExt = "xlsx";

                    // 파일 목록 필터링
                    saveFile.Filter = "Xlsx files(*.xlsx)|*.xlsx";

                    // OK버튼을 눌렀을때의 동작
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        // 경로와 파일명을 fileName에 저장
                        rpt = saveFile.FileName.ToString();
                    }
                    else
                    {
                        return;
                    }

                    string sfileName = Path.GetFileNameWithoutExtension(rpt);
                    string sExtensionName = Path.GetExtension(rpt);
                    string sDirName = Path.GetDirectoryName(rpt);
                    //string sDirFileName = Path.GetFullPath(rpt);

                    //Merge selective pages
                    string filePath = @sDirName + @"/" + sfileName + "_1" + sExtensionName;
                    string filePath2 = @sDirName + @"/" + sfileName + "_11" + sExtensionName;
                    string filePath3 = @sDirName + @"/" + sfileName + "_111" + sExtensionName;
                    string filePath4 = @sDirName + @"/" + sfileName + "_1111" + sExtensionName;
                    string filePath5 = @sDirName + @"/" + sfileName + "_11111" + sExtensionName;
                    string filePathOut = @sDirName + @"/" + sfileName + sExtensionName;

                    PQMS_STAFF_InfoMainGridView.ExportToXlsx(filePath, xlsxOptions);
                    PQMS_STAFF_ROLE_InfoGridView.ExportToXlsx(filePath2, xlsxOptions);
                    PQMS_STAFF_CERTIMainGridView.ExportToXlsx(filePath3, xlsxOptions);
                    PQMS_STAFF_TRAINING_InfoGridView.ExportToXlsx(filePath4, xlsxOptions);
                    PQMS_ROLE2_EACH_LISTInfoGridView.ExportToXlsx(filePath5, xlsxOptions);

                    string[] inputFiles = { filePath, filePath2, filePath3, filePath4, filePath5 };

                    //Initialize a new Workbook object
                    Workbook newWorkbook = new Workbook();

                    //Clear the default worksheets
                    newWorkbook.Worksheets.Clear();

                    //Initialize another temporary Workbook object
                    Workbook tempWorkbook = new Workbook();

                    //Loop through the string array
                    foreach (string file in inputFiles)
                    {
                        //Load the current workbook
                        tempWorkbook.LoadFromFile(file);

                        //Loop through the worksheets in the current workbook
                        foreach (Worksheet sheet in tempWorkbook.Worksheets)
                        {
                            //Copy each worksheet from the current workbook to the new workbook
                            int a = tempWorkbook.Worksheets[0].LastRow;
                            int b = tempWorkbook.Worksheets[0].LastColumn;

                            sheet.Range[1, 1, a, b].Borders.LineStyle = LineStyleType.Thin;
                        }
                    }

                    Workbook MerBook = new Workbook();
                    MerBook.LoadFromFile(filePath);
                    Worksheet MerSheet = MerBook.Worksheets[0];

                    Workbook SouBook1 = new Workbook();
                    SouBook1.LoadFromFile(filePath2);
                    {
                        int a = SouBook1.Worksheets[0].LastRow;
                        int b = SouBook1.Worksheets[0].LastColumn;
                        SouBook1.Worksheets[0].Range[1, 1, a, b].Copy(MerSheet.Range[MerSheet.LastRow + 2, 1, a + MerSheet.LastRow, b]);
                    }

                    Workbook SouBook2 = new Workbook();
                    SouBook2.LoadFromFile(filePath3);
                    {
                        int c = SouBook2.Worksheets[0].LastRow;
                        int d = SouBook2.Worksheets[0].LastColumn;
                        SouBook2.Worksheets[0].Range[1, 1, c, d].Copy(MerSheet.Range[MerSheet.LastRow + 2, 1, c + MerSheet.LastRow, d]);
                    }

                    Workbook SouBook3 = new Workbook();
                    SouBook3.LoadFromFile(filePath4);
                    {
                        int g = SouBook3.Worksheets[0].LastRow;
                        int f = SouBook3.Worksheets[0].LastColumn;
                        SouBook3.Worksheets[0].Range[1, 1, g, f].Copy(MerSheet.Range[MerSheet.LastRow + 2, 1, g + MerSheet.LastRow, f]);
                    }

                    Workbook SouBook4 = new Workbook();
                    SouBook4.LoadFromFile(filePath5);
                    {
                        int h = SouBook4.Worksheets[0].LastRow;
                        int l = SouBook4.Worksheets[0].LastColumn;
                        SouBook4.Worksheets[0].Range[1, 1, h, l].Copy(MerSheet.Range[MerSheet.LastRow + 2, 1, h + MerSheet.LastRow, l]);
                    }

                    //Loop through the string array
                    //Delete Tempfiles
                    foreach (string file in inputFiles)
                    {
                        File.Delete(file);
                    }

                    MerBook.SaveToFile(filePathOut, ExcelVersion.Version2016);
                    Process.Start(filePathOut);
                }
                else
                {
                    MessageBox.Show("화면의 표를 선택해 주세요.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message + Environment.NewLine + f.Source);
            }
        }
        private void btnInsertApproveRequest_Click(object sender, EventArgs e)
        {
            //Form2PQMS_StaffInfo.sStaffCode = "0002";  
            if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE;
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_STAFF_ROLE_PAPER_FinalGridSet.sSTAFF_CODE;
            }
            else if (Form2_Tab_Info_Now.sTabName == "시험수행능력평가")
            {
                Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sSTAFF_CODE;
            }
            else if (Form2_Tab_Info_Now.sTabName == "임명장")
            {

                Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_STAFF_ROLESet.sSTAFF_CODE;
                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE = txtSTAFF_ROLE_ORG_CODE.Text;
                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_CODE = cmbSTAFF_ROLE_CODE.Text;

                if (txtSTAFF_ROLE_ORG_CODE.Text == "0007")
                {
                    MessageBox.Show("승인요청 할수 없는 기본자료 입니다. ");
                    return;
                }
            }
            else if (Form2_Tab_Info_Now.sTabName == "자격부여평가보고서")
            {
                Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_STAFF_ASSESSMENT_MainGridSet.sSTAFF_CODE;
            }
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
            if (Form2_Tab_Info_Now.sTabName == "직무기술서")
            {
                if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX) == true || string.IsNullOrEmpty(Form2_GridIdx.sIDX) == true)
                {
                    MessageBox.Show("직무기술서 선택 후 승인 요청해야 합니다.");
                    return;
                }
            }
            else if (Form2_Tab_Info_Now.sTabName == "교육보고서")
            {
                if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sPQMS_STAFF_TR_FILE) == true || string.IsNullOrEmpty(Form2_GridIdx.sIDX) == true)
                {
                    MessageBox.Show("교육보고서를 생성 후 승인 요청 해야합니다.");
                    return;
                }
            }
            string sFormName = "frmApproveRequestVer2";
            //frmApproveRequest childEduReport = new frmApproveRequest();
            frmApproveRequestVer2 childfrmApproveRequestVer2 = new frmApproveRequestVer2(this);
            if (unitCommon.YNFrom(sFormName))
            {
                childfrmApproveRequestVer2.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmApproveRequestVer2.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 
                childfrmApproveRequestVer2.WindowState = FormWindowState.Normal;                
                childfrmApproveRequestVer2.Size = new Size(607, 230);                
                childfrmApproveRequestVer2.ShowDialog();
            }
            // Call_PQMS_STAFF_TRAINING();
            Call_PQMS_STAFF_ASSESSMENT();//자격부여평가보고서
        }

        private void btnApproveReqSelect_Click(object sender, EventArgs e)
        {
            Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE;
            string sFormName = "frmApproveRequestCheckVer2";
            frmApproveRequestCheckVer2 childfrmApproveRequestCheckVer2 = new frmApproveRequestCheckVer2();
            if (unitCommon.YNFrom(sFormName))
            {
                childfrmApproveRequestCheckVer2.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmApproveRequestCheckVer2.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 
                childfrmApproveRequestCheckVer2.WindowState = FormWindowState.Normal;
                childfrmApproveRequestCheckVer2.ShowDialog();
            }
            // Call_PQMS_STAFF_TRAINING();
        }

        private void btnRPETC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode))
            {
                return;
            }

            string sFormName = "frmPQMS_STAFFP_RP_ETC";
            frmPQMS_STAFFP_RP_ETC childfrmPQMS_STAFFP_RP_ETC = new frmPQMS_STAFFP_RP_ETC();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrmPQMS_STAFFP_RP_ETC.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmPQMS_STAFFP_RP_ETC.WindowState = FormWindowState.Normal;
                childfrmPQMS_STAFFP_RP_ETC.ShowDialog();
            }

            //Call_STAFF_Main_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);
            //Call_STAFF_Main_Pre_Info(Form2PQMS_STAFF_MainPreSTAFFSet.sSTAFF_CODE);
        }

        private void btnRPORGCODE_Click(object sender, EventArgs e)
        {
            get_folder_data_type2_notin_ORG_CODE("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbRPORGCODE);
        }

        private void cmbRPORGCODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text = cmbRPORGCODE.Text.Substring(0, 4);
            // txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER_NAME.Text = cmbRPORGCODE.Text.Substring(5, cmbRPORGCODE.Text.Length-5); ;


            string selectedText = cmbRPORGCODE.SelectedItem.ToString();


            if (comboBoxData.ContainsKey(selectedText))
            {
                string selectedValue = comboBoxData[selectedText];

                txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text = selectedValue;
                txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER_NAME.Text = selectedText;

            }

            get_folder_data2_type2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text, cmbRPGroup1Code);
        }

        private void btnRPGroup1Code_Click(object sender, EventArgs e)
        {
            get_folder_data2_type2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text, cmbRPGroup1Code);
        }

        private void cmbRPGroup1Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtRPGroup1Code.Text = cmbRPGroup1Code.Text.Substring(0, 4);
            //txtRPGroup1Name.Text = cmbRPGroup1Code.Text.Substring(5, cmbRPGroup1Code.Text.Length - 5);           

            string selectedText = cmbRPGroup1Code.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                string selectedValue = comboBoxData[selectedText];

                txtRPGroup1Code.Text = selectedValue;
                txtRPGroup1Name.Text = selectedText;
            }

            txtSTAFF_RP_CLASS_PQMS_STAFF_ROLE_PAPER.Text = txtRPGroup1Code.Text + "-" + txtRPGroup2Code.Text;


            get_folder_data5_type2("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text, txtRPGroup1Code.Text, cmbRPGroup2Code);
            get_folder_data5_type2("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text, txtRPGroup1Code.Text, cmbRPGroup2Code_2);
            get_folder_data5_type2("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text, txtRPGroup1Code.Text, cmbRPGroup2Code_3);
            get_folder_data5_type2("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text, txtRPGroup1Code.Text, cmbRPGroup2Code_4);
            get_folder_data5_type2("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text, txtRPGroup1Code.Text, cmbRPGroup2Code_5);
            get_folder_data5_type2("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text, txtRPGroup1Code.Text, cmbRPGroup2Code_6);


           
        }

        private void btnRPGroup2Code_Click(object sender, EventArgs e)
        {
            get_folder_data5_type2("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text, txtRPGroup1Code.Text, cmbRPGroup2Code);
        }

        private void cmbRPGroup2Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtRPGroup2Code.Text = cmbRPGroup2Code.Text.Substring(0, 4);
            //txtRPGroup2Name.Text = cmbRPGroup2Code.Text.Substring(5, cmbRPGroup2Code.Text.Length - 5);


            string selectedText = cmbRPGroup2Code.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                string selectedValue = comboBoxData[selectedText];

                txtRPGroup2Code.Text = selectedValue;
                txtRPGroup2Name.Text = selectedText;
            }

            txtSTAFF_RP_CLASS_PQMS_STAFF_ROLE_PAPER.Text = txtRPGroup1Code.Text + "-" + txtRPGroup2Code.Text;


        }

        private void btnEACH_LIST_Group1Code_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtSTAFF_ROLE_ORG_CODE_EACH_LIST.Text, cmbEACH_LIST_Group1Code);
        }

        private void cmbEACH_LIST_Group1Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEACH_LIST_Group1Code.Text = cmbEACH_LIST_Group1Code.Text.Substring(0, 4);
            txtEACH_LIST_Group1Name.Text = cmbEACH_LIST_Group1Code.Text.Substring(5, cmbEACH_LIST_Group1Code.Text.Length - 5);

            txtEACH_LIST_GROUP.Text = txtEACH_LIST_Group1Code.Text + "-" + txtEACH_LIST_GROUP.Text.Substring(5, 4);
        }

        private void btnEACH_LIST_Group2Code_Click(object sender, EventArgs e)
        {
            get_folder_data5("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", txtSTAFF_ROLE_ORG_CODE_EACH_LIST.Text, txtEACH_LIST_Group1Code.Text, cmbEACH_LIST_Group2Code);
        }

        private void cmbEACH_LIST_Group2Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEACH_LIST_Group2Code.Text = cmbEACH_LIST_Group2Code.Text.Substring(0, 4);
            txtEACH_LIST_Group2Name.Text = cmbEACH_LIST_Group2Code.Text.Substring(5, cmbEACH_LIST_Group2Code.Text.Length - 5);

            txtEACH_LIST_GROUP.Text = txtEACH_LIST_GROUP.Text.Substring(0, 4) + "-" + txtEACH_LIST_Group2Code.Text;

        }

        private void cmb_Main_ORGCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbMain_Group1Code.Text = "";
            cmbMain_Group1Code.Items.Clear();
            get_folder_data2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", cmb_Main_ORGCode.Text.Substring(0, 4), cmbMain_Group1Code);


            if (Form2PQMS_LoginInfo.sGroupName != null)
            {
                if (string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName) != true)
                {
                    if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
                    {
                        //Call_PQMS_Main_Staff_User();
                        Call_PQMS_Main_Staff_User_Ver2();
                    }
                    else
                    {
                        //Call_PQMS_Main_Staff();
                        Call_PQMS_Main_Staff_Ver2();
                    }
                }
            }


            //if (cmb_Main_ORGCode.Text == "0002 식약처" || cmb_Main_ORGCode.Text == "0003 농산물품질관리원")
            //{
            //    PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "법정실무";
            //}
            //else            
            //{
            //    PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "운영실무";
            //}

        }

        private void btnROLE2_EACH_LIST_AttachFile_Select_Click(object sender, EventArgs e)
        {
            string fileContent = string.Empty;
            string filePath = string.Empty;

            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //내문서로 기본폴더 설정
                                                                                                        //  fd.Filter = "word files (*.docx)|*.docx|word files (*.doc)|*.doc"; //필터 설정
                                                                                                        //fd.FilterIndex = 2; //1번 선택시 txt , 2번 선택시 *.*
                fd.FilterIndex = 2;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    filePath = fd.FileName; //전체 경로와 파일명 //선택한 파일명은 fd.SafeFileName
                    txtROLE2_EACH_LIST_AttachFile.Text = filePath;
                }
            }
        }

        private void btnROLE2_EACH_LIST_AttachFile_Open_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtROLE2_EACH_LIST_AttachFile.Text) == false)
            {
                Process.Start(txtROLE2_EACH_LIST_AttachFile.Text);
            }
        }

        private void cmbMain_StaffStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Form2PQMS_LoginInfo.sGroupName != null)
            {

                if (string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName) != true)
                {

                    if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
                    {
                        //Call_PQMS_Main_Staff_User();
                        Call_PQMS_Main_Staff_User_Ver2();
                    }
                    else
                    {
                        //Call_PQMS_Main_Staff();
                        Call_PQMS_Main_Staff_Ver2();
                    }

                }
            }

            //if (cmb_Main_ORGCode.Text == "0002 식약처" || cmb_Main_ORGCode.Text == "0003 농산물품질관리원")
            //{
            //    PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "법정실무";
            //}
            //else
            //{
            //    PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "운영실무";
            //}

        }

        private void cmbMain_Group1Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Form2PQMS_LoginInfo.sGroupName != null)
            {
                if (string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName) != true)
                {

                    if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
                    {
                        //Call_PQMS_Main_Staff_User();
                        Call_PQMS_Main_Staff_User_Ver2();
                    }
                    else
                    {
                        //Call_PQMS_Main_Staff();
                        Call_PQMS_Main_Staff_Ver2();
                    }
                }
            }

            //if (cmb_Main_ORGCode.Text == "0002 식약처" || cmb_Main_ORGCode.Text == "0003 농산물품질관리원")
            //{
            //    PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "법정실무";
            //}
            //else
            //{
            //    PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "운영실무";
            //}

        }

        private void PQMS_STAFF_ROLE_InfoGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption.Equals("임명장보기"))
            {
                string strFile = PQMS_STAFF_ROLE_InfoGridView.GetFocusedDataRow()["STAFF_ROLE_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }


        private void PQMS_STAFF_CERTIMainGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption.Equals("사본첨부"))
            {
                string strFile = PQMS_STAFF_CERTIMainGridView.GetFocusedDataRow()["STAFF_CERTI_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void PQMS_STAFF_TRAINING_InfoGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption.Equals("훈련결과증빙"))
            {
                string strFile = PQMS_STAFF_TRAINING_InfoGridView.GetFocusedDataRow()["STAFF_TRAIN_RESULT_DIR_FILE"].ToString();
                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }

            if (e.Column.Caption.Equals("교육보고서"))
            {
                string strFile = PQMS_STAFF_TRAINING_InfoGridView.GetFocusedDataRow()["STAFF_TRAIN_REPORT_FILE"].ToString();
                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void PQMS_ROLE2_EACH_LISTInfoGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption.Equals("첨부파일"))
            {
                string strFile = PQMS_ROLE2_EACH_LISTInfoGridView.GetFocusedDataRow()["ATTACH_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }
        private void PQMS_STAFF_AllGridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (PQMS_STAFF_AllGridView != null)
            {

                if (cmb_Main_ORGCode.Text.Substring(0, 4) == "0002")
                {
                    //운영실무와 불확도 둘중 하나만 없어도 교육예정일은 삭제 
                    if (PQMS_STAFF_AllGridView.GetDataRow(e.RowHandle)["STAFF_EDU_TO_1"].ToString() == "" || PQMS_STAFF_AllGridView.GetDataRow(e.RowHandle)["STAFF_EDU_TO_2"].ToString() == "")
                    {

                        PQMS_STAFF_AllGridView.SetRowCellValue(e.RowHandle, "NEXTEDU", null);
                        //PQMS_STAFF_AllGridView.GetDataRow(e.RowHandle)["NEXTEDU"] = "";
                        //
                        //MessageBox.Show("s");
                    }
                }



                DateTime dt_TODATE = DateTime.Now;
                if (e.Column.FieldName.Equals("NEXTEDU"))
                {
                    if (PQMS_STAFF_AllGridView.GetDataRow(e.RowHandle)["NEXTEDU"].ToString() != "")
                    {
                        //MessageBox.Show(PQMS_STAFF_AllGridView.GetDataRow(e.RowHandle)["NEXTEDU"].ToString());
                        DateTime dt_GRID = Convert.ToDateTime(PQMS_STAFF_AllGridView.GetDataRow(e.RowHandle)["NEXTEDU"].ToString());
                        int tmp = DateTime.Compare(dt_TODATE, dt_GRID);
                        if (tmp > 0) //교육예정일이 지나면 빨간색 
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                        else
                        {
                            DateTime dt_3month = dt_GRID.AddMonths(-3);//3달전 
                            int tmp2 = DateTime.Compare(dt_TODATE, dt_3month);
                            if (tmp2 > 0) // 교육예정일이 3개월 전이면 노란색 
                            {
                                e.Appearance.BackColor = Color.Yellow;
                            }
                        }
                    }
                }
            }
        }


        private void btn_Staff_Role_StaffCode_Click(object sender, EventArgs e)
        {
            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
            {

                string sql = " Select staff_code from PQMS_STAFF where  account_no = '" + Form2PQMS_LoginInfo.sAccountNo + "'";
                OleDbCommand cmd = new OleDbCommand(sql, Conn);
                Conn.Open();
                DataTable dt = new DataTable();

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        dt.Load(reader);

                        txtSTAFF_CODE_ROLE.Text = dt.Rows[0][0].ToString();
                    }
                }
                Conn.Close();
            }

        }

        private void btnStaffSearch_Click(object sender, EventArgs e)
        {

            if (txtSTAFF_CODE.Text == "")
            {
                MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                return;
            }

            Call_STAFF_Main_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);

            // 기본자료 조회 - '사번'이 Key
            Call_STAFF_Main_Tab_Now_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);

            // 기본자료 조회 - '사번'이 Key
            Call_STAFF_Main_Pre_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);
        }

        private void CALL_PQMS_CERTI() //자격증정보 
        {
            // 자격증자료 조회 - '사번'이 Key
            try
            {
                Form2PQMS_STAFF_MainCERTISet.SelectSTAFF_CERTI();

                if (Form2PQMS_STAFF_MainCERTISet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_CERTIMainGrid, Form2PQMS_STAFF_MainCERTISet);
                }
                else
                {
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("자격증자료 조회 실패!" + f.Message.ToString());
            }
        }

        private void btnStaffcertiSearch_Click(object sender, EventArgs e)
        {
            CALL_PQMS_CERTI();
        }

        private void btnStaffroleSearch_Click(object sender, EventArgs e)
        {
            Call_PQMS_Main_Role(txtSTAFF_CODE_ROLE.Text);
        }

        private void btnROLE2_EACH_LISTSearch_Click(object sender, EventArgs e)
        {
            CALL_PQMS_ROLE2_EACH();
            CAll_PQMS_EACH_LIST();
        }

        public void CALL_PQMS_ROLE2_EACH()
        {
            // 개별업무자료 - 현황조회 - '사번'이 Key
            try
            {
                Form2PQMS_ROLE2_EACH_LIST_InfoGridSet.Select();

                if (Form2PQMS_ROLE2_EACH_LIST_InfoGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_EACH_LISTInfoGrid, Form2PQMS_ROLE2_EACH_LIST_InfoGridSet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("시험수행능력평가 - 현황조회 실패!" + f.Message.ToString());
            }
        }

        private void btnSTAFFFile_Click(object sender, EventArgs e)
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
                    txtSTAFF_File.Text = filePath;
                }
            }
        }

        private void btnSTAFFFileShow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSTAFF_File.Text) == false)
            {
                Process.Start(txtSTAFF_File.Text);
            }
        }

        private void btnROLE2_EACH_LIST_PAPER_Click(object sender, EventArgs e)
        {
            Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE;

            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
            {
                MessageBox.Show("사원을 선택해주세요.");
                return;
            }

            string sFormName = "frmEachListPaperHistory";
            frmEachListPaperHistory childEachListPaperHistory = new frmEachListPaperHistory(this);

            if (unitCommon.YNFrom(sFormName))
            {
                childEachListPaperHistory.Dispose();     // 창 리소스 제거
            }
            else
            {
                childEachListPaperHistory.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 
                childEachListPaperHistory.WindowState = FormWindowState.Normal;
                childEachListPaperHistory.ShowDialog();
            }
        }

        private void cmbEduOrg2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEduOrg2.Text == "기타")
            {
                txteduETC.Visible = true;
            }
            else
            {
                txteduETC.Visible = false;
            }
        }

        private void PQMS_STAFF_ROLE_PAPERFinalGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set.sIDX = PQMS_STAFF_ROLE_PAPERFinalGridView.GetFocusedRowCellValue("IDX").ToString();
            Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set.sAPPROVE_STATUS_CODE = PQMS_STAFF_ROLE_PAPERFinalGridView.GetFocusedRowCellValue("approveStatusCode").ToString();
            Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set.sRPIDX = PQMS_STAFF_ROLE_PAPERFinalGridView.GetFocusedRowCellValue("PQMS_STAFF_ROLE_PAPER_IDX").ToString();

            Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX = PQMS_STAFF_ROLE_PAPERFinalGridView.GetFocusedRowCellValue("IDX").ToString();
            Form2_GridIdx.sIDX = PQMS_STAFF_ROLE_PAPERFinalGridView.GetFocusedRowCellValue("IDX").ToString();
            Form2_GridIdx.sRPIDX = PQMS_STAFF_ROLE_PAPERFinalGridView.GetFocusedRowCellValue("PQMS_STAFF_ROLE_PAPER_IDX").ToString();

            // Make the grid read-only.
            PQMS_STAFF_ROLE_PAPERFinalGridView.OptionsBehavior.Editable = false;

            Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set.sRP_FINAL_FILE = PQMS_STAFF_ROLE_PAPERFinalGridView.GetFocusedDataRow()["RP_FINAL_FILE"].ToString();

            if (e.Column.Caption.Equals("직무기술서"))
            {
                string strFile = PQMS_STAFF_ROLE_PAPERFinalGridView.GetFocusedDataRow()["RP_FINAL_FILE"].ToString();
                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void PQMS_STAFF_ROLE_PAPERFinalGridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            // 직무기술서 > 왼쪽 직무기술서의 선택된 로우 Style >> 
            GridView view = sender as GridView;

            if (e.RowHandle < 0) return;

            if (view.IsRowSelected(e.RowHandle) || view.FocusedRowHandle == e.RowHandle)
            {
                e.Appearance.BackColor = System.Drawing.Color.SkyBlue;
                e.Appearance.ForeColor = System.Drawing.Color.White;
                e.HighPriority = true;
            }
        }

        private void btnStaff_RP_TRAININGFOLDER_Click(object sender, EventArgs e)
        {
            Form2PQMS_StaffInfo.sStaffCode = txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text;

            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
            {
                MessageBox.Show("사원을 선택해주세요.");
                return;
            }

            string sFormName = "frmRolePaperTraining";
            frmRolePaperTraining childRolePaperTraining = new frmRolePaperTraining(this);

            if (unitCommon.YNFrom(sFormName))
            {
                childRolePaperTraining.Dispose();     // 창 리소스 제거
            }
            else
            {
                childRolePaperTraining.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 
                childRolePaperTraining.WindowState = FormWindowState.Normal;
                childRolePaperTraining.ShowDialog();
            }
        }

        private void btnStaffrole_AssessmentReport_Click(object sender, EventArgs e)
        {
            Form2PQMS_StaffInfo.sStaffCode = txtSTAFF_CODE_ROLE.Text;

            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
            {
                MessageBox.Show("사원을 선택해주세요.");
                return;
            }

            string sFormName = "frmRoleAssessmentReport";
            frmRoleAssessmentReport childRoleAssessmentReport = new frmRoleAssessmentReport(this);

            if (unitCommon.YNFrom(sFormName))
            {
                childRoleAssessmentReport.Dispose();     // 창 리소스 제거
            }
            else
            {
                childRoleAssessmentReport.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 
                childRoleAssessmentReport.WindowState = FormWindowState.Normal;
                childRoleAssessmentReport.ShowDialog();
            }
            Call_PQMS_STAFF_ASSESSMENT();
        }

        private void btnRP_PERIODICINSPECTION_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set.sIDX) == true)
            {
                MessageBox.Show("정기점검 승인 할 직무기술서를 선택해주세요.(오른쪽)");
                return;
            }

            if (MessageBox.Show("정기정검 직무기술서 승인 하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();
                try
                {
                    Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set.Insert(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("확인 완료!");
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("확인 실패!" + Environment.NewLine + f.Message);
                }
            }
            else
            {

            }
        }

        private void btnFindRepository_Part_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode))
            {
                return;
            }

            Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM = txtSTAFF_TEAM.Text;

            string sFormName = "frmPQMS_STAFF_Dept_Part";
            frmPQMS_STAFF_Dept_Part childfrmPQMS_STAFF_Dept_Part = new frmPQMS_STAFF_Dept_Part();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrmPQMS_STAFF_Dept_Part.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmPQMS_STAFF_Dept_Part.WindowState = FormWindowState.Normal;
                childfrmPQMS_STAFF_Dept_Part.ShowDialog();
            }

            Call_STAFF_Main_Info(Form2PQMS_StaffInfo.sStaffCode);
            Call_STAFF_Main_Pre_Info(Form2PQMS_StaffInfo.sStaffCode);
        }

        private void cmbSTAFFSORT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
            {
                //Call_PQMS_Main_Staff_User();
                Call_PQMS_Main_Staff_User_Ver2();
            }
            else
            {
                // Call_PQMS_Main_Staff();                
                Call_PQMS_Main_Staff_Ver2(); //관리자 OR 심사원 OR DEPT
            }
        }

        private void btnDeletePQMS_STAFF_ROLE_PAPER_FINAL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX) == true || string.IsNullOrEmpty(Form2_GridIdx.sIDX) == true)
            {
                MessageBox.Show("삭제 할 직무기술서를 선택해주세요.(오른쪽");
                return;
            }

            //if (Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set.sAPPROVE_STATUS_CODE != "")
            //{
            //    MessageBox.Show("승인요청/승인완료  직무기술서는 삭제 할 수 없습니다.");
            //    return;
            //}

            if (MessageBox.Show("선택된 직무기술서 삭제 하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();
                try
                {
                    Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set.Delete_ROLE_PAPER_FINAL(trans);

                    //서버에서 파일삭제
                    if (File.Exists(Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set.sRP_FINAL_FILE))
                    {
                        File.Delete(Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_Set.sRP_FINAL_FILE);
                    }

                    AppRes.DB.CommitTrans();
                    MessageBox.Show("삭제 완료!");
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
                }

                Call_PQMS_STAFF_ROLE_PAPER();
            }
        }

        private void PQMS_STAFF_InfoMainGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.Caption.Equals("서약서"))
            {
                string strFile = PQMS_STAFF_InfoMainGridView.GetFocusedDataRow()["STAFF_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void btnStaffrole_AssessmentReport_delete_Click(object sender, EventArgs e)
        {
            if (Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_ROLE_APPROVE_STATUS == "1")
            {
                MessageBox.Show("승인완료된 데이터는 삭제 할 수 없습니다. ");
                return;
            }
            if (Form2PQMS_STAFF_ASSESSMENT_MainGridSet.iIDX <= 0)
            {
                MessageBox.Show("삭제 할 데이터를 선택하세요. ");
                return;
            }

            SqlTransaction trans = AppRes.DB.BeginTrans();
            try
            {
                Form2PQMS_STAFF_ASSESSMENT_MainGridSet.sSTAFF_CODE = txtSTAFF_CODE_ASSESSMENT.Text;
                Form2PQMS_STAFF_ASSESSMENT_MainGridSet.Delete(trans);

                //파일삭제
                if (File.Exists(Form2PQMS_STAFF_ASSESSMENT_MainGridSet.sFINAL_FILE))
                {
                    File.Delete(Form2PQMS_STAFF_ASSESSMENT_MainGridSet.sFINAL_FILE);
                }

                AppRes.DB.CommitTrans();
                MessageBox.Show("삭제 완료!");
                Call_PQMS_STAFF_ASSESSMENT();
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
            }

            // iIDX 값 초기화
            Form2PQMS_STAFF_ROLESet.iIDX = 0;
        }
        public void Call_PQMS_STAFF_ASSESSMENT() //자격부여평가보고서
        {
            try
            {
                //자격부여평가보고서              
                Form2PQMS_STAFF_ASSESSMENT_MainGridSet.Select();
                if (Form2PQMS_STAFF_ASSESSMENT_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_ASSESSMENTMainGrid, Form2PQMS_STAFF_ASSESSMENT_MainGridSet);
                    btn_7.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    btn_7.BackColor = Color.FromArgb(255, 192, 192);
                }

                PQMS_STAFF_ASSESSMENTMainGridView.Columns.View.FocusInvalidRow(); // 첫 로드시 포커스 없어서 style적용 되지 않도록 

            }
            catch (Exception f)
            {
                MessageBox.Show("자격부여보고서 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
        }

        private void PQMS_STAFF_ASSESSMENTMainGridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.RowHandle < 0) return;

            if (view.IsRowSelected(e.RowHandle) || view.FocusedRowHandle == e.RowHandle)
            {
                e.Appearance.BackColor = System.Drawing.Color.SkyBlue;
                e.Appearance.ForeColor = System.Drawing.Color.White;
                e.HighPriority = true;
            }
        }

        private void PQMS_STAFF_ASSESSMENTMainGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            Form2_GridIdx.sIDX = PQMS_STAFF_ASSESSMENTMainGridView.GetFocusedDataRow()["IDX"].ToString();
            Form2PQMS_STAFF_APPROVE_STATE.sSTAFF_ROLE_APPROVE_STATUS = PQMS_STAFF_ASSESSMENTMainGridView.GetFocusedDataRow()["approveStatusCode"].ToString();
            Form2PQMS_STAFF_ASSESSMENT_MainGridSet.iIDX = Convert.ToInt32(PQMS_STAFF_ASSESSMENTMainGridView.GetFocusedDataRow()["IDX"].ToString());
            Form2PQMS_STAFF_ASSESSMENT_MainGridSet.sFINAL_FILE = PQMS_STAFF_ASSESSMENTMainGridView.GetFocusedDataRow()["FINAL_FILE"].ToString();


            if (e.Column.Caption.Equals("자격부여평가보고서"))
            {
                string strFile = PQMS_STAFF_ASSESSMENTMainGridView.GetFocusedDataRow()["FINAL_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }
        private void btn_9_Click(object sender, EventArgs e) //9.트래이닝폴더관리
        {
            tabControl1.SelectedTab = tabControl1.TabPages[7];

            //if (txtSTAFF_CODE.Text != "")
            //{
            //    string query = " SELECT FILE_PATH FROM PQMS_STAFF_ROLEPAPER_TRANING_FOLDER " +
            //                    " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";

            //    OleDbCommand cmd = new OleDbCommand(query, Conn);
            //    Conn.Open();

            //    string sFile = "";
            //    using (OleDbDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.HasRows == true)
            //        {
            //            while (reader.Read())
            //            {
            //                sFile = reader.GetValue(0).ToString();                            
            //            }
            //        }
            //    }

            //    Conn.Close();
            //    if (string.IsNullOrEmpty(sFile) == false)
            //    {
            //        FileInfo fileInfo = new FileInfo(sFile);
            //        if (fileInfo.Exists)
            //        {
            //            Process.Start(sFile);
            //        }
            //        else
            //        {
            //            MessageBox.Show("생성된 트래이닝폴더관리 파일이 없습니다. 파일 생성 후 이용해 주세요.");                        
            //            btnStaff_RP_TRAININGFOLDER_Click(sender, e);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("생성된 트래이닝폴더관리 파일이 없습니다. 파일 생성 후 이용해 주세요.");
            //        btnStaff_RP_TRAININGFOLDER_Click(sender, e);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
            //    return;
            //}
        }
        private void btn_1_2_Click(object sender, EventArgs e) //1.인원정보입력 2.서약서
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];

            //if (string.IsNullOrEmpty(txtSTAFF_File.Text) == false)
            //{
            //    FileInfo fileInfo = new FileInfo(txtSTAFF_File.Text);
            //    if (fileInfo.Exists)
            //    {
            //        Process.Start(txtSTAFF_File.Text);
            //    }
            //    else
            //    {
            //        MessageBox.Show("서약서 파일의 경로를 찾지 못했습니다.");
            //        return;
            //    }
            //}
            //else 
            //{
            //    MessageBox.Show("등록된 서약서가 없습니다.");
            //    return;
            //}
        }

        private void btn_8_Click(object sender, EventArgs e)//3.직무자료 - 임명장
        {
            tabControl1.SelectedTab = tabControl1.TabPages[6];


            //if (txtSTAFF_CODE.Text != "")
            //{
            //    string query = " SELECT STAFF_ROLE_FILE FROM PQMS_STAFF_ROLE_APPOINT " +
            //                   " WHERE STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";

            //    OleDbCommand cmd = new OleDbCommand(query, Conn);
            //    Conn.Open();

            //    string sFile = "";
            //    using (OleDbDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.HasRows == true)
            //        {
            //            while (reader.Read())
            //            {
            //                sFile = reader.GetValue(0).ToString();
            //            }
            //        }
            //    }
            //    Conn.Close();
            //    if (string.IsNullOrEmpty(sFile) == false)
            //    {
            //        FileInfo fileInfo = new FileInfo(sFile);
            //        if (fileInfo.Exists)
            //        {
            //            Process.Start(sFile);
            //        }
            //        else
            //        {
            //            MessageBox.Show("생성된 임명장이 없습니다.");
            //            return;
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
            //    return;
            //}

        }

        private void btn_6_Click(object sender, EventArgs e) //6.직무기술서
        {
            tabControl1.SelectedTab = tabControl1.TabPages[4];
        }

        private void btn_7_Click(object sender, EventArgs e)//7.자격부여평가보고서
        {
            tabControl1.SelectedTab = tabControl1.TabPages[5];
        }

        private void btn_5_Click(object sender, EventArgs e)//5.시험수행능력
        {
            tabControl1.SelectedTab = tabControl1.TabPages[3];

            //if (txtSTAFF_CODE.Text != "")
            //{
            //    string query = " SELECT FILE_PATH FROM PQMS_STAFF_RP_EACH_LIST_FOLDER " +
            //                    " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";

            //    OleDbCommand cmd = new OleDbCommand(query, Conn);
            //    Conn.Open();

            //    string sFile = "";
            //    using (OleDbDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.HasRows == true)
            //        {
            //            while (reader.Read())
            //            {
            //                sFile = reader.GetValue(0).ToString();
            //            }
            //        }
            //    }

            //    Conn.Close();
            //    if (string.IsNullOrEmpty(sFile) == false)
            //    {
            //        FileInfo fileInfo = new FileInfo(sFile);
            //        if (fileInfo.Exists)
            //        {
            //            Process.Start(sFile);
            //        }
            //        else
            //        {
            //            MessageBox.Show("생성된 시험수행능력평가이력 파일이 없습니다. 파일 생성 후 이용해 주세요.");
            //            btnROLE2_EACH_LIST_PAPER_Click(sender, e);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("생성된 시험수행능력평가이력 파일이 없습니다. 파일 생성 후 이용해 주세요.");
            //        btnROLE2_EACH_LIST_PAPER_Click(sender, e);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
            //    return;
            //}
        }

        private void btn_3_4_Click(object sender, EventArgs e)//7.교육이력
        {
            tabControl1.SelectedTab = tabControl1.TabPages[2];

            //if (txtSTAFF_CODE.Text != "")
            //{
            //    string query = " SELECT FILE_PATH FROM PQMS_STAFF_TRAINING_HISTORY_FOLDER " +
            //                    " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";

            //    OleDbCommand cmd = new OleDbCommand(query, Conn);
            //    Conn.Open();

            //    string sFile = "";
            //    using (OleDbDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.HasRows == true)
            //        {
            //            while (reader.Read())
            //            {
            //                sFile = reader.GetValue(0).ToString();
            //            }
            //        }
            //    }

            //    Conn.Close();
            //    if (string.IsNullOrEmpty(sFile) == false)
            //    {
            //        FileInfo fileInfo = new FileInfo(sFile);
            //        if (fileInfo.Exists)
            //        {
            //            Process.Start(sFile);
            //        }
            //        else
            //        {
            //            MessageBox.Show("생성된 교육훈련이력기록 파일이 없습니다. 파일 생성 후 이용해 주세요.");
            //            btnEduHistoryDaejang_Click(sender, e);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("생성된 교육훈련이력기록 파일이 없습니다. 파일 생성 후 이용해 주세요.");
            //        btnEduHistoryDaejang_Click(sender, e);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
            //    return;
            //}

        }

        //private void btn_8_Click(object sender, EventArgs e)//8.교육보고서
        //{
        //    tabControl1.SelectedTab = tabControl1.TabPages[6];
        //}

   
        private void dtSTAFF_JOIN_DATE_ValueChanged(object sender, EventArgs e)
        {
            txtSTAFF_JOIN_DATE.Text = dtSTAFF_JOIN_DATE.Text;
        }

        private void dtSTAFF_RESIGNATION_DATE_ValueChanged(object sender, EventArgs e)
        {
            txtSTAFF_RESIGNATION_DATE.Text = dtSTAFF_RESIGNATION_DATE.Text;
        }



        private void Login_Load()
        {

            //자료목록에서 선택된 사용자 변경됐으니까 모든 탭의 모든 입력창 리셋             
            //for (int i = 1; i < tabControl1.TabCount; i++)
            //{
            //    TabPage selectedTab = tabControl1.TabPages[i];
            //    foreach (Control x in selectedTab.Controls)
            //    {
            //        if (x is System.Windows.Forms.TextBox)
            //        {
            //            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)x;
            //            textBox.Text = string.Empty;
            //        }
            //        else if (x is ComboBox)
            //        {
            //            ComboBox comboBox = (ComboBox)x;
            //            comboBox.Text = "";
            //            comboBox.Items.Clear();

            //        }
            //        //else if (x is DateTimePicker)
            //        //{
            //        //    DateTimePicker dateTimePicker = (DateTimePicker)x;
            //        //    DateTime dt_TODATE = DateTime.Now;

            //        //    dateTimePicker.Text = dt_TODATE.ToString();
            //        //}
            //    }
            //}


            string tmp_Staff_Code = "";
            string tmp_Staff_Team = "";
            string tmp_Staff_Name = "";
            string query = " SELECT STAFF_CODE, STAFF_TEAM, STAFF_NAME FROM PQMS_STAFF WHERE STAFF_EMPNO = " + Form2PQMS_LoginInfo.sEmpNo;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        tmp_Staff_Code = reader.GetValue(0).ToString(); // 
                        tmp_Staff_Team = reader.GetValue(1).ToString(); // 
                        tmp_Staff_Name = reader.GetValue(2).ToString(); // 
                    }
                }
            }

            Conn.Close();

            // 직원자료
            Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE = tmp_Staff_Code;

            // 교육자료
            Form2PQMS_STAFF_MainEDUSet.sSTAFF_CODE = tmp_Staff_Code;

            // 자격증자료
            Form2PQMS_STAFF_MainCERTISet.sSTAFF_CODE = tmp_Staff_Code;

            // 직무자료
            Form2PQMS_STAFF_MainROLESet.sSTAFF_CODE = tmp_Staff_Code;
            Form2PQMS_STAFF_ROLESet.sSTAFF_CODE = tmp_Staff_Code;

            // 직무기술서- 왼쪽 그리드
            Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_CODE = tmp_Staff_Code;
            //직무기술서 - 오른쪽 그리드
            Form2PQMS_STAFF_ROLE_PAPER_FinalGridSet.sSTAFF_CODE = tmp_Staff_Code;

            // 개인별업무목록
            Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sSTAFF_CODE = tmp_Staff_Code;

            // 개인별업무목록_현황
            Form2PQMS_ROLE2_EACH_LIST_InfoGridSet.sSTAFF_CODE = tmp_Staff_Code;

            // 교육보고서
            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE = tmp_Staff_Code;

            // 교육보고서 - 현황
            Form2PQMS_PQMS_STAFF_TRAINING_InfoGridSet.sSTAFF_CODE = tmp_Staff_Code;
            //자격부여평가보고서 
            Form2PQMS_STAFF_ASSESSMENT_MainGridSet.sSTAFF_CODE = tmp_Staff_Code;

            //트래이닝폴더관리 
            Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.sSTAFF_CODE = tmp_Staff_Code;

            // 전직장정보
            Form2PQMS_StaffInfo.sStaffCode = tmp_Staff_Code;
            Form2PQMS_StaffInfo.sStaffName = tmp_Staff_Name;

            // 사원 팀정보
            Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM = tmp_Staff_Team;

            // 교육보고서
            //Form2PQMS_StaffInfo.sStaffCode = tmp_Staff_Code;

            // 기본자료 조회 - '사번'이 Key
            Call_STAFF_Main_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);

            // 기본자료 조회 - '사번'이 Key
            Call_STAFF_Main_Tab_Now_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);

            // 기본자료 조회 - '사번'이 Key
            Call_STAFF_Main_Pre_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);

            // 교육자료 조회 - '사번'이 Key
            try
            {
                Form2PQMS_STAFF_MainEDUSet.SelectSTAFF_EDU();

                if (Form2PQMS_STAFF_MainEDUSet.Empty == false)
                {
                    //AppHelper.SetGridDataSource(PQMS_STAFF_EDUMainGrid, Form2PQMS_STAFF_MainEDUSet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("교육자료 조회 실패!" + f.Message.ToString());
            }

            // 자격증자료 조회 - '사번'이 Key
            try
            {
                Form2PQMS_STAFF_MainCERTISet.SelectSTAFF_CERTI();

                if (Form2PQMS_STAFF_MainCERTISet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_CERTIMainGrid, Form2PQMS_STAFF_MainCERTISet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("자격증자료 조회 실패!" + f.Message.ToString());
            }


            //// 개인별업무자료 조회 - '사번'이 Key
            CAll_PQMS_EACH_LIST();


            // 개별업무자료 - 현황조회 - '사번'이 Key
            try
            {
                Form2PQMS_ROLE2_EACH_LIST_InfoGridSet.Select();

                if (Form2PQMS_ROLE2_EACH_LIST_InfoGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_EACH_LISTInfoGrid, Form2PQMS_ROLE2_EACH_LIST_InfoGridSet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("개인별업무자료 - 현황조회 실패!" + f.Message.ToString());
            }


            //트래이닝폴더관리 가져오기 
            try
            {
                Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.Select();

                if (Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE_PAPER_TRANING_FOLDER_MainGrid, Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet);
                    AppHelper.SetGridDataSource(PQMS_STAFF_TR_FOLDER_InfoGrid, Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet);


                    btn_9.BackColor = Color.FromArgb(0, 192, 0);

                }
                else
                {
                    btn_9.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("트래이닝폴더관리 - 조회 실패!" + f.Message.ToString());
            }

            // 교육 조회
            Call_PQMS_Main_Edu(tmp_Staff_Code);

            // 교육자료 - 현황조회
            Call_PQMS_Main_Edu(tmp_Staff_Code);

            // 자격증자료 조회
            Call_PQMS_Main_Certi(tmp_Staff_Code);

            // 직무자료 조회
            Call_PQMS_Main_Role(tmp_Staff_Code);

            // 직무자료 현황조회
            Call_PQMS_Info_Role(tmp_Staff_Code);

            // 교육보고서 조회
            Call_PQMS_STAFF_TRAINING();

            // 교육보고서 현황 조회
            Call_PQMS_STAFF_TRAINING_Info();

            // 직무기술서 조회
            Call_PQMS_STAFF_ROLE_PAPER();

            //자격부여평가보고서
            Call_PQMS_STAFF_ASSESSMENT();

            if (!Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("FOOD"))
            {
                //교육 Tab Page로 이동
                tabControl1.SelectedTab = tabControl1.TabPages[1];
            }

            chg_btn(tmp_Staff_Code); //교육훈련이력기록, 수행능력평가이력 버튼 색 변경 
        }

        private void btn_10_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabControl1.TabPages[8];
            DataTable dt_R = new DataTable();
            //임명장 종류 확인 
            string query = " SELECT DISTINCT(STAFF_ROLE_CODE) FROM PQMS_STAFF_ROLE " +
                           " WHERE STAFF_CODE = '" + txtSTAFF_CODE.Text + "' " +
                           " AND STAFF_ROLE_ORG_CODE  != '0007' "; // SGS직웜코드는 삭제 
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();            
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt_R.Load(reader);
                }
            }
            Conn.Close();

            //직무기술서 종류 확인 
            DataTable dt_RP = new DataTable();
            query = " SELECT DISTINCT(STAFF_RP_CODE) FROM PQMS_STAFF_ROLE_PAPER " +
                    " WHERE STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";                           
            cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt_RP.Load(reader);
                }
            }
            Conn.Close();
                       

            if (dt_R.Rows.Count >=2 || dt_RP.Rows.Count>=2)
            {

                Form2PQMS_StaffInfo.sStaffCode = txtSTAFF_CODE_ROLE.Text;

                if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
                {
                    MessageBox.Show("사원을 선택해주세요.");
                    return;
                }

                string sFormName = "frmAllFileOpen";
                frmAllFileOpen childfrmAllFileOpen = new frmAllFileOpen(this);

                if (unitCommon.YNFrom(sFormName))
                {
                    childfrmAllFileOpen.Dispose();     // 창 리소스 제거
                }
                else
                {
                    childfrmAllFileOpen.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 
                    childfrmAllFileOpen.WindowState = FormWindowState.Normal;
                    childfrmAllFileOpen.ShowDialog();
                }
            }
            else
            {

                //서약서 
                string sFile_STAFF_FILE = "";
                if (string.IsNullOrEmpty(txtSTAFF_File.Text) == false)
                {
                     sFile_STAFF_FILE = txtSTAFF_File.Text;
                }
               
                if (txtSTAFF_CODE.Text != "")
                {
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
                            " group by a.STAFF_RP_FILE " + 
                            " order by 1 desc" ;
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
                                    " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";

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

                    MergePDFFiles(savefile, sFile_TRANING_FOLDER, sFile_STAFF_FILE, sFile_ROLE_FILE ,sFile_TR, sFile_EACH, sFile_ROLE_PAPER, sFile_ASSESSMENT);
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





        private void cmbSTAFF_TRAIN_GUBUN_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSTAFF_TRAIN_GUBUN.Text = cmbSTAFF_TRAIN_GUBUN.Text;
        }

        private void btnInsertSTAFF_TRAIN_SUMMARY_Click(object sender, EventArgs e)
        {
            string sFormName = "frmSTAFF_TRAIN_OBJECT";
            frmSTAFF_TRAIN_OBJECT childfrmSTAFF_TRAIN_OBJECT = new frmSTAFF_TRAIN_OBJECT();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrmSTAFF_TRAIN_OBJECT.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmSTAFF_TRAIN_OBJECT.WindowState = FormWindowState.Normal;
                childfrmSTAFF_TRAIN_OBJECT.ShowDialog();

                // 조직 선택이 되어 있을때만 활성화
                //if (!string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName))
                //{
                //    txtSTAFF_TEAM.Text = FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName;
                //}
            }
        }

        private void btnInsertSTAFF_TRAIN_GOAL_Click(object sender, EventArgs e)
        {
            string sFormName = "frmSTAFF_TRAIN_GOAL";
            frmSTAFF_TRAIN_GOAL childfrmSTAFF_TRAIN_GOAL = new frmSTAFF_TRAIN_GOAL();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrmSTAFF_TRAIN_GOAL.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmSTAFF_TRAIN_GOAL.WindowState = FormWindowState.Normal;
                childfrmSTAFF_TRAIN_GOAL.ShowDialog();

                // 조직 선택이 되어 있을때만 활성화
                //if (!string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName))
                //{
                //    txtSTAFF_TEAM.Text = FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName;
                //}
            }
        }

        private void txtSTAFF_TRAIN_RESULT_Click(object sender, EventArgs e)
        {

            //txtSTAFF_TRAIN_RESULT.ForeColor = System.Drawing.SystemColors.WindowText;

            //if (txtSTAFF_TRAIN_RESULT.Text == "교육자료첨부, 수료증첨부")
            //{
            //    txtSTAFF_TRAIN_RESULT.Text = "";
            //}            
        }

        private void Form2PQMS_STAFF_TRAINING_MainGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_TRAIN_RESULT_DIR_FILE")
            {
                if (!Form2PQMS_STAFF_TRAINING_MainGridView.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_RESULT_DIR_FILE").Equals(DBNull.Value) && Form2PQMS_STAFF_TRAINING_MainGridView.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_RESULT_DIR_FILE").ToString().Trim() != "")                
                {
                    string strFile = Form2PQMS_STAFF_TRAINING_MainGridView.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_RESULT_DIR_FILE").ToString();
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

            if (e.Column.FieldName == "STAFF_TRAIN_REPORT_FILE")
            {
                if (!Form2PQMS_STAFF_TRAINING_MainGridView.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_REPORT_FILE").Equals(DBNull.Value))
                {
                    string strFile = Form2PQMS_STAFF_TRAINING_MainGridView.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_REPORT_FILE").ToString();
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

        private void btnEduHistoryDaejang_Open_Click(object sender, EventArgs e)
        {
            if (txtSTAFF_CODE.Text != "")
            {
                string query = " SELECT FILE_PATH FROM PQMS_STAFF_TRAINING_HISTORY_FOLDER " +
                                " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";

                OleDbCommand cmd = new OleDbCommand(query, Conn);
                Conn.Open();

                string sFile = "";
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            sFile = reader.GetValue(0).ToString();
                        }
                    }
                }

                Conn.Close();
                if (string.IsNullOrEmpty(sFile) == false)
                {
                    FileInfo fileInfo = new FileInfo(sFile);
                    if (fileInfo.Exists)
                    {
                        Process.Start(sFile);
                    }
                    else
                    {
                        MessageBox.Show("생성된 교육훈련이력기록 파일이 없습니다. 파일 생성 후 이용해 주세요.");
                        btnEduHistoryDaejang_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("생성된 교육훈련이력기록 파일이 없습니다. 파일 생성 후 이용해 주세요.");
                    btnEduHistoryDaejang_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                return;
            }
        }

        private void dtSTAFF_TRAIN_WRITE_DATE_ValueChanged(object sender, EventArgs e)
        {
            txtSTAFF_TRAIN_WRITE_DATE.Text = dtSTAFF_TRAIN_WRITE_DATE.Text;
        }

        private void dtSTAFF_TRAIN_APPROVAL_DATE_ValueChanged(object sender, EventArgs e)
        {
            txtSTAFF_TRAIN_APPROVAL_DATE.Text = dtSTAFF_TRAIN_APPROVAL_DATE.Text;
        }

        private void btnNew_PQMS_STAFF_TRAINING_Click(object sender, EventArgs e)
        {                      

            Field_Reset("txtSTAFF_CODE_PQMS_STAFF_TRAINING");
            get_folder_data7(cmbEduOrg2); //굑육보고서> 교육과정

            txteduETC.Visible = false;
                

            Form2STAFF_TRAIN_ATTENDEE.sSTAFF_TRAINING_ATTENDEE = "";
            Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE = null;

            Form2STAFF_TRAIN_CONTENTS.sSTAFF_TRAIN_CONTENTS = "";
            Form2STAFF_TRAIN_OBJECTIVE.sSTAFF_TRAIN_OBJECTIVE = "";
            Form2STAFF_TRAIN_GOAL.sSTAFF_TRAIN_GOAL = "";
            Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX = "";
            Form2PQMS_StaffInfo.sPQMS_STAFF_EDU_FILE = "";

            //    TabPage selectedTab = tabControl1.TabPages[6];
            //    foreach (Control x in selectedTab.Controls)
            //    {
            //        if (x is System.Windows.Forms.TextBox)
            //        {
            //            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)x;
            //            textBox.Text = string.Empty;
            //        }
            //        else if (x is ComboBox)
            //        {
            //            ComboBox comboBox = (ComboBox)x;
            //            comboBox.Text = "";
            //            //comboBox.Items.Clear();
            //        }                  
            //    }
            //    txteduETC.Visible = false;

        }

        public void Change_btn9_ColorChange()
        {
            btn_9.BackColor = Color.FromArgb(0, 192, 0);
            CALL_PQMS_RP_TRANING_FILDER();            
        }
        public void Change_btn5_ColorChange()
        {
            btn_5.BackColor = Color.FromArgb(0, 192, 0);
        }
        public void Change_btn7_ColorChange()
        {
            btn_7.BackColor = Color.FromArgb(0, 192, 0);
        }
        public void Change_btn3_ColorChange()
        {
            btn_3.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnSTAFF_TRAIN_ATTENDEE_Click(object sender, EventArgs e)
        {
            string sFormName = "frmSTAFF_TRAIN_ATTENDEE";
            frmSTAFF_TRAIN_ATTENDEE childfrmSTAFF_TRAIN_ATTENDEE = new frmSTAFF_TRAIN_ATTENDEE();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrmSTAFF_TRAIN_ATTENDEE.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmSTAFF_TRAIN_ATTENDEE.WindowState = FormWindowState.Normal;
                childfrmSTAFF_TRAIN_ATTENDEE.ShowDialog();

                // 조직 선택이 되어 있을때만 활성화
                //if (!string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName))
                //{
                //    txtSTAFF_TEAM.Text = FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName;
                //}
            }
        }

        private void cmbEACH_LIST_METHODS_SelectedValueChanged(object sender, EventArgs e)
        {
            txtEACH_LIST_METHODS.Text = cmbEACH_LIST_METHODS.Text;
        }

        private void cmbEACH_LIST_RESULT_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEACH_LIST_RESULT.Text = cmbEACH_LIST_RESULT.Text;
        }

        private void btnInsertPQMS_STAFF_EACHLIST_REMARK_Click(object sender, EventArgs e)
        {
            string sFormName = "frmSTAFF_EachList_REMARK";
            frmSTAFF_EachList_REMARK childfrmSTAFF_EachList_REMARK = new frmSTAFF_EachList_REMARK();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrmSTAFF_EachList_REMARK.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmSTAFF_EachList_REMARK.WindowState = FormWindowState.Normal;
                childfrmSTAFF_EachList_REMARK.ShowDialog();                
            }

        }

        private void btnROLE2_EACH_LIST_NEW_Click(object sender, EventArgs e)
        {
            Field_Reset("txtIdx_EACH_LIST_STAFF_CODE");

            cmbEACH_LIST_METHODS.Items.Add("PT");
            cmbEACH_LIST_METHODS.Items.Add("비교시험");
            cmbEACH_LIST_METHODS.Items.Add("유효성검증");
            cmbEACH_LIST_METHODS.Items.Add("기타");

            cmbEACH_LIST_RESULT.Items.Add("적합");
            cmbEACH_LIST_RESULT.Items.Add("부적합");

            chk_ROLE_PAPER.Checked = true;
            chk_EACHLIST_PAPER.Checked = true;

            txtEHCH_LIST_CHANGE.ForeColor = System.Drawing.SystemColors.WindowFrame;
            txtMainLIST_CONTENTS1_EACH_LIST.ForeColor = System.Drawing.SystemColors.WindowFrame;

            txtEACH_LIST_ROLE_TYPE.Text = "실무자";
            txtEHCH_LIST_CHANGE.Text = "적합한 결과에 따른 최종(현재) 자격이 부여된 시험항목을 나열";
            txtMainLIST_CONTENTS1_EACH_LIST.Text = "IEC 62321-6 : 2015 , Determination of certain substances in electrotechnical products - Part 6: Polybrominated biphenyls and polybrominated diphenyl ethers in polymers by gas chromatograhy -mass spectometry (GC-MS) ,규격이 없을 시 항목 기재";


            Form2STAFF_EACHLIST_REMARK.sSTAFF_EACHLIST_REMARK = "";           


        }

        private void txtEHCH_LIST_CHANGE_Click(object sender, EventArgs e)
        {

            txtEHCH_LIST_CHANGE.ForeColor = System.Drawing.SystemColors.WindowText;

            if (txtEHCH_LIST_CHANGE.Text == "적합한 결과에 따른 최종(현재) 자격이 부여된 시험항목을 나열")
            {
                txtEHCH_LIST_CHANGE.Text = "";
            }

        }

        private void txtMainLIST_CONTENTS1_EACH_LIST_Click(object sender, EventArgs e)
        {

            txtMainLIST_CONTENTS1_EACH_LIST.ForeColor = System.Drawing.SystemColors.WindowText;

            if (txtMainLIST_CONTENTS1_EACH_LIST.Text == "IEC 62321-6 : 2015 , Determination of certain substances in electrotechnical products - Part 6: Polybrominated biphenyls and polybrominated diphenyl ethers in polymers by gas chromatograhy -mass spectometry (GC-MS) ,규격이 없을 시 항목 기재")
            {
                txtMainLIST_CONTENTS1_EACH_LIST.Text = "";
            }

        }

        private void PQMS_ROLE2_EACH_LISTMainGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "ATTACH_FILE")
            {                
                if (!PQMS_ROLE2_EACH_LISTMainGridView.GetRowCellValue(e.RowHandle, "ATTACH_FILE").Equals(DBNull.Value) && PQMS_ROLE2_EACH_LISTMainGridView.GetRowCellValue(e.RowHandle, "ATTACH_FILE").ToString().Trim() != "")                    
                {
                    string strFile = PQMS_ROLE2_EACH_LISTMainGridView.GetRowCellValue(e.RowHandle, "ATTACH_FILE").ToString();
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

        private void btnROLE2_EACH_LIST_PAPER_OPEN_Click(object sender, EventArgs e)
        {

            if (txtSTAFF_CODE.Text != "")
            {
                string query = " SELECT FILE_PATH FROM PQMS_STAFF_RP_EACH_LIST_FOLDER " +
                                " WHERE  STAFF_CODE = '" + txtSTAFF_CODE.Text + "' ";

                OleDbCommand cmd = new OleDbCommand(query, Conn);
                Conn.Open();

                string sFile = "";
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            sFile = reader.GetValue(0).ToString();
                        }
                    }
                }

                Conn.Close();
                if (string.IsNullOrEmpty(sFile) == false)
                {
                    FileInfo fileInfo = new FileInfo(sFile);
                    if (fileInfo.Exists)
                    {
                        Process.Start(sFile);
                    }
                    else
                    {
                        MessageBox.Show("생성된 수행능력평가이력 파일이 없습니다. 파일 생성 후 이용해 주세요.");
                        btnROLE2_EACH_LIST_PAPER_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("생성된 수행능력평가이력 파일이 없습니다. 파일 생성 후 이용해 주세요.");
                    btnROLE2_EACH_LIST_PAPER_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                return;
            }
        }

        private void btn_ApproveReqSelect_ALL_Click(object sender, EventArgs e)
        {
            Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE;
            string sFormName = "frmApproveRequestCheckALL";
            frmApproveRequestCheckALL childfrmApproveRequestCheckALL = new frmApproveRequestCheckALL();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrmApproveRequestCheckALL.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmApproveRequestCheckALL.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 
                childfrmApproveRequestCheckALL.WindowState = FormWindowState.Normal;
                childfrmApproveRequestCheckALL.ShowDialog();
            }
        }

        private void btn_STAFF_certiInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode))
            {
                return;
            }

            string sFormName = "frmSTAFF_CERTI";
            frmSTAFF_CERTI childfrmSTAFF_CERTI = new frmSTAFF_CERTI();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrmSTAFF_CERTI.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrmSTAFF_CERTI.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 

                childfrmSTAFF_CERTI.WindowState = FormWindowState.Normal;
                childfrmSTAFF_CERTI.ShowDialog();
            }

            CALL_PQMS_CERTI();

            //Call_STAFF_Main_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);
            //Call_STAFF_Main_Pre_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);


        }

        private void btnNEWPQMS_STAFF_ROLE_PAPER_Click(object sender, EventArgs e)
        {
            Field_Reset("txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER");

            //그리드 선택사항 클리어 
            PQMS_RP_ROLE2_EACH_LISTGridView.ClearSelection();
            Form2PQMS_STAFF_RP_TRAINING_GridView.ClearSelection();

            get_folder_RolePaper(cmbRolePaper); // 직무기술서 코드
            get_folder_data_type2_notin_ORG_CODE("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbRPORGCODE); //직무기술서 직무기관코드 

            txtSTAFF_RP_CAREER.ForeColor = System.Drawing.SystemColors.WindowFrame;
            txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.ForeColor = System.Drawing.SystemColors.WindowFrame;
            txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.ForeColor = System.Drawing.SystemColors.WindowFrame;

            txtSTAFF_RP_CAREER.Text = "한국에스지에스(년/월/일 ~ 현재)";
            txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.Text = "업무대리인 이름 기입";
            txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.Text = "기술책임자";

            panel_RP_LIST.Location = new Point(label10.Location.X - 3, cmbRPGroup2Code.Location.Y + 25);

            btn_ADD_1.Text = "+";
            btn_ADD_2.Text = "+";
            btn_ADD_3.Text = "+";
            btn_ADD_4.Text = "+";
            btn_ADD_5.Text = "+";
            
            panel_RP_2.Visible = false;
            panel_RP_3.Visible = false;
            panel_RP_4.Visible = false;
            panel_RP_5.Visible = false;
            panel_RP_6.Visible = false;

            
        }

        private void txtSTAFF_RP_CAREER_Click(object sender, EventArgs e)
        {
            txtSTAFF_RP_CAREER.ForeColor = System.Drawing.SystemColors.WindowText;

            if (txtSTAFF_RP_CAREER.Text == "한국에스지에스(년/월/일 ~ 현재)")
            {
                txtSTAFF_RP_CAREER.Text = "";
            }
        }

        private void txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER_Click(object sender, EventArgs e)
        {
            txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.ForeColor = System.Drawing.SystemColors.WindowText;

            if (txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.Text == "업무대리인 이름 기입")
            {
                txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.Text = "";
            }
        }

        private void txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER_Click(object sender, EventArgs e)
        {
            txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.ForeColor = System.Drawing.SystemColors.WindowText;

            if (txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.Text == "기술책임자")
            {
                txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.Text = "";
            }
        }     

        private void btn_ADD_1_Click(object sender, EventArgs e)
        {
            if (panel_RP_2.Visible == false)
            {
                panel_RP_2.Visible = true;
                panel_RP_2.Location = new Point(cmbRPORGCODE.Location.X, cmbRPGroup2Code.Location.Y + 25);
                panel_RP_LIST.Location = new Point(label10.Location.X-3, cmbRPGroup2Code.Location.Y + 50);
                btn_ADD_1.Text = "-";
            }
            else
            {
                panel_RP_2.Visible = false;
                panel_RP_3.Visible = false;
                panel_RP_4.Visible = false;
                panel_RP_5.Visible = false;
                panel_RP_6.Visible = false;

                panel_RP_LIST.Location = new Point(label10.Location.X-3, cmbRPGroup2Code.Location.Y + 25);
                btn_ADD_1.Text = "+";
                btn_ADD_2.Text = "+";
                btn_ADD_3.Text = "+";
                btn_ADD_4.Text = "+";
                btn_ADD_5.Text = "+";
            }
        }

        private void btn_ADD_2_Click(object sender, EventArgs e)
        {
            if (panel_RP_3.Visible == false)
            {
                panel_RP_3.Visible = true;
                panel_RP_3.Location = new Point(panel_RP_2.Location.X, panel_RP_2.Location.Y + 25);
                panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_2.Location.Y + 50);
                btn_ADD_2.Text = "-";
            }
            else
            {
                panel_RP_3.Visible = false;
                panel_RP_4.Visible = false;
                panel_RP_5.Visible = false;
                panel_RP_6.Visible = false;
                panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_2.Location.Y + 25);
                btn_ADD_2.Text = "+";
                btn_ADD_3.Text = "+";
                btn_ADD_4.Text = "+";
                btn_ADD_5.Text = "+";
            }
        }

        private void btn_ADD_3_Click(object sender, EventArgs e)
        {
            if (panel_RP_4.Visible == false)
            {
                panel_RP_4.Visible = true;
                panel_RP_4.Location = new Point(panel_RP_3.Location.X, panel_RP_3.Location.Y + 25);
                panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_3.Location.Y + 50);
                btn_ADD_3.Text = "-";
            }
            else
            {
                panel_RP_4.Visible = false;
                panel_RP_5.Visible = false;
                panel_RP_6.Visible = false;
                panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_3.Location.Y + 25);
                btn_ADD_3.Text = "+";
                btn_ADD_4.Text = "+";
                btn_ADD_5.Text = "+";
            }
        }

        private void btn_ADD_4_Click(object sender, EventArgs e)
        {
            if (panel_RP_5.Visible == false)
            {
                panel_RP_5.Visible = true;
                panel_RP_5.Location = new Point(panel_RP_4.Location.X, panel_RP_4.Location.Y + 25);
                panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_5.Location.Y + 50);
                btn_ADD_4.Text = "-";
            }
            else
            {
                panel_RP_5.Visible = false;
                panel_RP_6.Visible = false;
                panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_5.Location.Y + 25);
                btn_ADD_4.Text = "+";
                btn_ADD_5.Text = "+";
            }
        }

        private void btn_ADD_5_Click(object sender, EventArgs e)
        {
            if (panel_RP_6.Visible == false)
            {
                panel_RP_6.Visible = true;
                panel_RP_6.Location = new Point(panel_RP_5.Location.X, panel_RP_5.Location.Y + 25);
                panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_5.Location.Y + 50);
                btn_ADD_5.Text = "-";
            }
            else
            {
                panel_RP_6.Visible = false;
                panel_RP_LIST.Location = new Point(label10.Location.X-3, panel_RP_5.Location.Y + 25);
                btn_ADD_5.Text = "+";
            }
        }

        private void cmbRPGroup2Code_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbRPGroup2Code_2.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                string selectedValue = comboBoxData[selectedText];

                txtRPGroup2Code_2.Text = selectedValue;                
            }
        }

        private void cmbRPGroup2Code_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbRPGroup2Code_3.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                string selectedValue = comboBoxData[selectedText];

                txtRPGroup2Code_3.Text = selectedValue;                
            }
        }
        private void cmbRPGroup2Code_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbRPGroup2Code_4.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                string selectedValue = comboBoxData[selectedText];

                txtRPGroup2Code_4.Text = selectedValue;                
            }
        }
        private void cmbRPGroup2Code_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbRPGroup2Code_5.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                string selectedValue = comboBoxData[selectedText];

                txtRPGroup2Code_5.Text = selectedValue;                
            }
        }

        private void cmbRPGroup2Code_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbRPGroup2Code_6.SelectedItem.ToString();

            if (comboBoxData.ContainsKey(selectedText))
            {
                string selectedValue = comboBoxData[selectedText];

                txtRPGroup2Code_6.Text = selectedValue;                
            }
        }

        private void PQMS_STAFF_ROLE_PAPERMainGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_RP_FILE")
            {
                if (!PQMS_STAFF_ROLE_PAPERMainGridView.GetRowCellValue(e.RowHandle, "STAFF_RP_FILE").Equals(DBNull.Value) && PQMS_STAFF_ROLE_PAPERMainGridView.GetRowCellValue(e.RowHandle, "STAFF_RP_FILE").ToString().Trim() != "")                
                {
                    string strFile = PQMS_STAFF_ROLE_PAPERMainGridView.GetRowCellValue(e.RowHandle, "STAFF_RP_FILE").ToString();
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

        private void btnInsertPQMS_STAFF_ROLE_PAPER_VERUP_Click(object sender, EventArgs e)
        {
            if (txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text == "")
            {
                MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                return;
            }

            if (txtIDX_PQMS_STAFF_ROLE_PAPER.Text.Length > 0)
            {
                if (MessageBox.Show("선택된 직무기술서 Version을 변경 하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlTransaction trans = AppRes.DB.BeginTrans();
                    try
                    {
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_DATE = dtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER.Text;
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS = txtRPGroup1Code.Text + "-" + txtRPGroup2Code.Text;

                        if (panel_RP_2.Visible == true)
                        {
                            Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_2 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_2.Text;
                        }
                        if (panel_RP_3.Visible == true)
                        {
                            Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_3 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_3.Text;
                        }
                        if (panel_RP_4.Visible == true)
                        {
                            Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_4 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_4.Text;
                        }
                        if (panel_RP_5.Visible == true)
                        {
                            Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_5 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_5.Text;
                        }
                        if (panel_RP_6.Visible == true)
                        {
                            Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS_6 = txtRPGroup1Code.Text + "-" + txtRPGroup2Code_6.Text;
                        }

                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_ORG_CODE = txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text;
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CODE = txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text;
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_APPROVER = txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.Text;
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_APPROVE_DATE = dtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER.Text;
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_SUPPORTER = txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.Text;
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_WRITER = txtSTAFF_RP_WRITER_PQMS_STAFF_ROLE_PAPER.Text; //jhm0708
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_WRITE_DATE = dtSTAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER.Text; //jhm0708
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_FIRSTDATE = dtSTAFF_RP_FIRSTDATE.Text;
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CAREER = txtSTAFF_RP_CAREER.Text;
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_REASON = txtSTAFF_RP_REASON.Text;

                        string each_IDX = "";
                        string tr_IDX = "";
                        //수행능력평가 이력 체크한 리스트 
                        foreach (int id in PQMS_RP_ROLE2_EACH_LISTGridView.GetSelectedRows())
                        {
                            each_IDX = each_IDX + ", " + PQMS_RP_ROLE2_EACH_LISTGridView.GetRowCellValue(id, "IDX").ToString();
                        }
                        //교육보고수 이력 체크한 리스트 
                        foreach (int id in Form2PQMS_STAFF_RP_TRAINING_GridView.GetSelectedRows())
                        {
                            tr_IDX = tr_IDX + ", " + Form2PQMS_STAFF_RP_TRAINING_GridView.GetRowCellValue(id, "IDX").ToString();
                        }

                        if (each_IDX.Length <= 0)
                        {
                            MessageBox.Show("수행평가이력을 체크하세요.");
                            AppRes.DB.RollbackTrans();
                            return;
                        }
                        if (tr_IDX.Length <= 0)
                        {
                            MessageBox.Show("교육훈련이력을 체크하세요.");
                            AppRes.DB.RollbackTrans();
                            return;
                        }

                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_EACHLIST_IDX = each_IDX.Substring(2);
                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_TRANING_IDX = tr_IDX.Substring(2);


                        Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.Insert(trans);
                        AppRes.DB.CommitTrans();
                        MessageBox.Show("직무기술서 Version 변경 입력 완료!");
                        Field_Reset("txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER");

                        //직무기술서 파일 자동 생성 시작                 
                        string RP_templeate = @"\\10.153.4.98\DI\PQMS\Template\RolePaper\CQP-6021-F02 (01) 직무기술서.docx";

                        string RP_idx_query = " SELECT IDX, STAFF_RP_CODE, STAFF_RP_ORG_CODE FROM PQMS_STAFF_ROLE_PAPER " +
                            " WHERE IDX = (SELECT MAX(IDX) FROM PQMS_STAFF_ROLE_PAPER WHERE STAFF_CODE = '" + txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text + "')";

                        OleDbCommand cmd = new OleDbCommand(RP_idx_query, Conn);
                        Conn.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows == true)
                            {
                                while (reader.Read())
                                {
                                    Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX = reader.GetValue(0).ToString();
                                    Form2PQMS_StaffInfo.sPQMS_STAFF_RP_CODE = reader.GetValue(1).ToString();
                                    Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE = reader.GetValue(2).ToString();
                                }
                            }
                        }
                        Conn.Close();

                        //저장된 자격분야 확인 해서 넘겨주기 ..
                        string s_qyery = " SELECT     d.GROUP2_NAME   , isnull(d2.GROUP2_NAME,'') as GROUP2_NAME_2  ,isnull(d3.GROUP2_NAME,'') as GROUP2_NAME_3 , isnull(d4.GROUP2_NAME,'') as GROUP2_NAME_4  , isnull(d5.GROUP2_NAME,'') as GROUP2_NAME_5  , isnull(d6.GROUP2_NAME, '') as GROUP2_NAME_6 " +
                                        " FROM[PQMS_STAFF_ROLE_PAPER] AS a" +
                                        " inner join PQMS_ORG b on a.STAFF_RP_ORG_CODE = b.ORG_CODE and b.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                        " inner join PQMS_GROUP1 c on a.STAFF_RP_ORG_CODE = c.GROUP1_ORG_CODE and left(a.STAFF_RP_CLASS,4) = c.GROUP1_CODE and c.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and c.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and c.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                        " inner join PQMS_GROUP2 d on a.STAFF_RP_ORG_CODE = d.GROUP2_ORG_CODE and c.GROUP1_CODE = d.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS,4)= d.GROUP2_CODE   and d.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                        " left outer join PQMS_GROUP2 d2 on a.STAFF_RP_ORG_CODE = d2.GROUP2_ORG_CODE and c.GROUP1_CODE = d2.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_2,4)= d2.GROUP2_CODE   and d2.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d2.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d2.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                        " left outer join PQMS_GROUP2 d3 on a.STAFF_RP_ORG_CODE = d3.GROUP2_ORG_CODE and c.GROUP1_CODE = d3.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_3,4)= d3.GROUP2_CODE   and d3.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d3.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d3.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                        " left outer join PQMS_GROUP2 d4 on a.STAFF_RP_ORG_CODE = d4.GROUP2_ORG_CODE and c.GROUP1_CODE = d4.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_4,4)= d4.GROUP2_CODE   and d4.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d4.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d4.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                        " left outer join PQMS_GROUP2 d5 on a.STAFF_RP_ORG_CODE = d5.GROUP2_ORG_CODE and c.GROUP1_CODE = d5.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_5,4)= d5.GROUP2_CODE   and d5.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d5.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d5.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                        " left outer join PQMS_GROUP2 d6 on a.STAFF_RP_ORG_CODE = d6.GROUP2_ORG_CODE and c.GROUP1_CODE = d6.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_6,4)= d6.GROUP2_CODE   and d6.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and d6.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and d6.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                        " inner join PQMS_ROLE2_CODE e on a.STAFF_RP_CODE = e.ROLE_CODE and e.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and e.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and e.WS_CODE = '" + Form1PQMS_Repo.sWS + "'" +
                                        " where a.STAFF_CODE = '" + txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text + "' and a.IDX = '" + Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX + "'";

                        cmd = new OleDbCommand(s_qyery, Conn);
                        Conn.Open();
                        string[] s_Group2_Name = new string[6];
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows == true)
                            {
                                while (reader.Read())
                                {
                                    s_Group2_Name[0] = reader.GetValue(0).ToString();
                                    s_Group2_Name[1] = reader.GetValue(1).ToString();
                                    s_Group2_Name[2] = reader.GetValue(2).ToString();
                                    s_Group2_Name[3] = reader.GetValue(3).ToString();
                                    s_Group2_Name[4] = reader.GetValue(4).ToString();
                                    s_Group2_Name[5] = reader.GetValue(5).ToString();
                                }
                            }
                        }
                        Conn.Close();

                        string s_Group2_Name_Final = "";
                        for (int i = 0; i < 6; i++)
                        {
                            if (s_Group2_Name[i].Length > 0)
                            {
                                s_Group2_Name_Final = s_Group2_Name_Final + ", " + s_Group2_Name[i];
                            }
                        }

                        //보고서 파일 자동생성 
                        string sDateTime_yyyyMM_RP_Report = DateTime.Now.ToString("yyyyMM");
                        string savrfilepath_RP_Report = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\RolePaper\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "직무기술서" + @"\" + sDateTime_yyyyMM_RP_Report;

                        DirectoryInfo file_di_tr_Report = new DirectoryInfo(savrfilepath_RP_Report);
                        if (file_di_tr_Report.Exists == false)
                        {
                            Directory.CreateDirectory(savrfilepath_RP_Report);
                        }

                        unitCommon.CreateDoc_RP(RP_templeate, Form2PQMS_StaffInfo.sStaffCode, savrfilepath_RP_Report, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX, Form2PQMS_StaffInfo.sPQMS_STAFF_RP_CODE, Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_EACHLIST_IDX, Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_TRANING_IDX, Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_ORG_CODE, s_Group2_Name_Final.Substring(2));

                        btnNEWPQMS_STAFF_ROLE_PAPER_Click(sender, e);
                        btnSelectPQMS_STAFF_ROLE_PAPER.PerformClick();

                    }
                    catch (Exception f)
                    {
                        AppRes.DB.RollbackTrans();
                        MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
                    }
                }
            }

            

        }

        private void PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.Caption.Equals("트래이닝폴더관리파일"))
            {
                string strFile = PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridView.GetFocusedDataRow()["FILE_PATH"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }

            Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.iIDX = Convert.ToInt32(PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridView.GetFocusedDataRow()["IDX"].ToString());
            Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.sRP_CODE=PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridView.GetFocusedDataRow()["ROLE_CODE"].ToString();
            Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.sFINAL_FILE = PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridView.GetFocusedDataRow()["FILE_PATH"].ToString();
        }

        private void btnRP_PERIODICINSPECTION_Click_1(object sender, EventArgs e)
        {
            Form2PQMS_StaffInfo.sStaffCode = txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text;

            string sFormName = "frmRolePaperPeriodicInspection";
            frmRolePaperPeriodicInspection childRolePaperPeriodicInspection = new frmRolePaperPeriodicInspection(this);

            if (unitCommon.YNFrom(sFormName))
            {
                childRolePaperPeriodicInspection.Dispose();     // 창 리소스 제거
            }
            else
            {
                childRolePaperPeriodicInspection.StartPosition = FormStartPosition.CenterParent; //자식창위치 부모창의 센터로 고정 
                childRolePaperPeriodicInspection.WindowState = FormWindowState.Normal;
                childRolePaperPeriodicInspection.ShowDialog();
            }
        }

        private void btnStaff_RP_TRAININGFOLDER_DELETE_Click(object sender, EventArgs e)
        {
            if (Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.iIDX <= 0)
            {
                MessageBox.Show("삭제 할 트래이닝폴더를 선택하세요. ");
                return;
            }
            if (MessageBox.Show("선택된 트래이닝폴더관리를 삭제 하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                SqlTransaction trans = AppRes.DB.BeginTrans();
                try
                {
                    Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.Delete(trans);

                    //파일삭제
                    if (File.Exists(Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.sFINAL_FILE))
                    {
                        File.Delete(Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.sFINAL_FILE);
                    }

                    AppRes.DB.CommitTrans();
                    MessageBox.Show("트래이닝 폴더관리 삭제 완료!");
                    CALL_PQMS_RP_TRANING_FILDER();


                    Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.iIDX = 0;
                    Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.sRP_CODE = "";
                    Form2PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridSet.sFINAL_FILE = "";
                    // iIDX 값 초기화
                    Form2PQMS_STAFF_ROLESet.iIDX = 0;


                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
                }
            }    
        }


        private void PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "FILE_PATH")
            {
                object filePathValue = PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridView.GetRowCellValue(e.RowHandle, "FILE_PATH");

                if (filePathValue != null && filePathValue != DBNull.Value && filePathValue.ToString().Trim() != "")
                {
                    string strFile = PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridView.GetRowCellValue(e.RowHandle, "FILE_PATH").ToString();
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

                //if (!PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridView.GetRowCellValue(e.RowHandle, "FILE_PATH").Equals(DBNull.Value) && PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridView.GetRowCellValue(e.RowHandle, "FILE_PATH").ToString().Trim() != "")
                //{                 
                //    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //    e.Cache.FillRectangle(SystemBrushes.Control, e.Bounds);
                //    e.Appearance.DrawString(e.Cache, "파일열기", e.Bounds);
                //    e.Handled = true;
                //}
            }
        }

        private void btn_ADD_R_1_Click(object sender, EventArgs e)
        {
            if (panel_R_2.Visible == false)
            {
                panel_R_2.Visible = true;
                panel_R_2.Location = new Point(cmbFolder.Location.X, cmbGroup2.Location.Y + 25);
                panel_R_LIST.Location = new Point(label158.Location.X - 15, cmbGroup2.Location.Y + 50);
                btn_ADD_R_1.Text = "-";
            }
            else
            {
                panel_R_2.Visible = false;
                panel_R_3.Visible = false;
                panel_R_4.Visible = false;
                panel_R_5.Visible = false;
                panel_R_6.Visible = false;

                panel_R_LIST.Location = new Point(label158.Location.X - 15, cmbGroup2.Location.Y + 25);
                btn_ADD_R_1.Text = "+";
                btn_ADD_R_2.Text = "+";
                btn_ADD_R_3.Text = "+";
                btn_ADD_R_4.Text = "+";
                btn_ADD_R_5.Text = "+";
            }
        }

        private void btn_ADD_R_2_Click(object sender, EventArgs e)
        {
            if (panel_R_3.Visible == false)
            {
                panel_R_3.Visible = true;
                panel_R_3.Location = new Point(panel_R_2.Location.X, panel_R_2.Location.Y + 25);
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_2.Location.Y + 50);
                btn_ADD_R_2.Text = "-";
            }
            else
            {
                panel_R_3.Visible = false;
                panel_R_4.Visible = false;
                panel_R_5.Visible = false;
                panel_R_6.Visible = false;
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_2.Location.Y + 25);
                btn_ADD_R_2.Text = "+";
                btn_ADD_R_3.Text = "+";
                btn_ADD_R_4.Text = "+";
                btn_ADD_R_5.Text = "+";
            }
        }

        private void btn_ADD_R_3_Click(object sender, EventArgs e)
        {
            if (panel_R_4.Visible == false)
            {
                panel_R_4.Visible = true;
                panel_R_4.Location = new Point(panel_R_3.Location.X, panel_R_3.Location.Y + 25);
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_3.Location.Y + 50);
                btn_ADD_3.Text = "-";
            }
            else
            {
                panel_R_4.Visible = false;
                panel_R_5.Visible = false;
                panel_R_6.Visible = false;
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_3.Location.Y + 25);
                btn_ADD_R_3.Text = "+";
                btn_ADD_R_4.Text = "+";
                btn_ADD_R_5.Text = "+";
            }
        }

        private void btn_ADD_R_4_Click(object sender, EventArgs e)
        {
            if (panel_R_5.Visible == false)
            {
                panel_R_5.Visible = true;
                panel_R_5.Location = new Point(panel_R_4.Location.X, panel_R_4.Location.Y + 25);
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_5.Location.Y + 50);
                btn_ADD_R_4.Text = "-";
            }
            else
            {
                panel_R_5.Visible = false;
                panel_R_6.Visible = false;
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_5.Location.Y + 25);
                btn_ADD_R_4.Text = "+";
                btn_ADD_R_5.Text = "+";
            }
        }

        private void btn_ADD_R_5_Click(object sender, EventArgs e)
        {
            if (panel_R_6.Visible == false)
            {
                panel_R_6.Visible = true;
                panel_R_6.Location = new Point(panel_R_5.Location.X, panel_R_5.Location.Y + 25);
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_5.Location.Y + 50);
                btn_ADD_R_5.Text = "-";
            }
            else
            {
                panel_R_6.Visible = false;
                panel_R_LIST.Location = new Point(label158.Location.X - 15, panel_R_5.Location.Y + 25);
                btn_ADD_R_5.Text = "+";
            }
        }

        private void cmbSTAFF_TRAIN_RESULT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSTAFF_TRAIN_RESULT.Text == "기타")
            {
                txtSTAFF_TRAIN_RESULT.Visible = true;
            }
            else
            {
                txtSTAFF_TRAIN_RESULT.Visible = false;
                txtSTAFF_TRAIN_RESULT.Text = cmbSTAFF_TRAIN_RESULT.Text;
            }
        }

        private void PQMS_STAFF_ASSESSMENTMainGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "FINAL_FILE")
            {
                //if (PQMS_ROLE2_EACH_LISTMainGridView.GetRowCellValue(e.RowHandle, "ATTACH_FILE").ToString().Trim() != "")
                if (!PQMS_STAFF_ASSESSMENTMainGridView.GetRowCellValue(e.RowHandle, "FINAL_FILE").Equals(DBNull.Value) && PQMS_STAFF_ASSESSMENTMainGridView.GetRowCellValue(e.RowHandle, "FINAL_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_ASSESSMENTMainGridView.GetRowCellValue(e.RowHandle, "FINAL_FILE").ToString();
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

        private void PQMS_STAFF_ROLEGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_ROLE_FILE")
            {
                //if (PQMS_ROLE2_EACH_LISTMainGridView.GetRowCellValue(e.RowHandle, "ATTACH_FILE").ToString().Trim() != "")
                if (!PQMS_STAFF_ROLEGridView.GetRowCellValue(e.RowHandle, "STAFF_ROLE_FILE").Equals(DBNull.Value) && PQMS_STAFF_ROLEGridView.GetRowCellValue(e.RowHandle, "STAFF_ROLE_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_ROLEGridView.GetRowCellValue(e.RowHandle, "STAFF_ROLE_FILE").ToString();
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

        private void btnStaffrolenew_Click(object sender, EventArgs e)
        {
            Field_Reset("txtSTAFF_CODE_ROLE");
            Call_PQMS_Main_Role(txtSTAFF_CODE_ROLE.Text);

            cmbRole.Text = "";
            cmbRole.Items.Clear();
                        
            panel_R_LIST.Location = new Point(label158.Location.X - 15, cmbGroup2.Location.Y + 25);

            btn_ADD_R_1.Text = "+";
            btn_ADD_R_2.Text = "+";
            btn_ADD_R_3.Text = "+";
            btn_ADD_R_4.Text = "+";
            btn_ADD_R_5.Text = "+";

            panel_R_2.Visible = false;
            panel_R_3.Visible = false;
            panel_R_4.Visible = false;
            panel_R_5.Visible = false;
            panel_R_6.Visible = false;
        }

        private void cmbGroup2_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbGroup2_2.SelectedItem.ToString();
            if (comboBoxData.ContainsKey(selectedText))
            {
                txtGroup2Code_2.Text = comboBoxData[selectedText];                
            }

        }

        private void cmbGroup2_3_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedText = cmbGroup2_3.SelectedItem.ToString();
            if (comboBoxData.ContainsKey(selectedText))
            {
                txtGroup2Code_3.Text = comboBoxData[selectedText];
            }

        }

        private void cmbGroup2_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbGroup2_4.SelectedItem.ToString();
            if (comboBoxData.ContainsKey(selectedText))
            {
                txtGroup2Code_4.Text = comboBoxData[selectedText];
            }
        }

        private void cmbGroup2_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbGroup2_5.SelectedItem.ToString();
            if (comboBoxData.ContainsKey(selectedText))
            {
                txtGroup2Code_5.Text = comboBoxData[selectedText];
            }

        }

        private void cmbGroup2_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cmbGroup2_6.SelectedItem.ToString();
            if (comboBoxData.ContainsKey(selectedText))
            {
                txtGroup2Code_6.Text = comboBoxData[selectedText];
            }
        }

      

        private void btn_12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[8];
        }

        private void PQMS_STAFFMainGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_FILE")
            {
                //if (PQMS_ROLE2_EACH_LISTMainGridView.GetRowCellValue(e.RowHandle, "ATTACH_FILE").ToString().Trim() != "")
                if (!PQMS_STAFFMainGridView.GetRowCellValue(e.RowHandle, "STAFF_FILE").Equals(DBNull.Value) && PQMS_STAFFMainGridView.GetRowCellValue(e.RowHandle, "STAFF_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFFMainGridView.GetRowCellValue(e.RowHandle, "STAFF_FILE").ToString();
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
                    btn_2.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    btn_2.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
        }

        private void PQMS_STAFF_InfoMainGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_FILE")
            {
                //if (PQMS_ROLE2_EACH_LISTMainGridView.GetRowCellValue(e.RowHandle, "ATTACH_FILE").ToString().Trim() != "")
                if (!PQMS_STAFF_InfoMainGridView.GetRowCellValue(e.RowHandle, "STAFF_FILE").Equals(DBNull.Value) && PQMS_STAFF_InfoMainGridView.GetRowCellValue(e.RowHandle, "STAFF_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_InfoMainGridView.GetRowCellValue(e.RowHandle, "STAFF_FILE").ToString();
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

        private void PQMS_STAFF_CERTIMainGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_CERTI_FILE")
            {                
                if (!PQMS_STAFF_CERTIMainGridView.GetRowCellValue(e.RowHandle, "STAFF_CERTI_FILE").Equals(DBNull.Value) && PQMS_STAFF_CERTIMainGridView.GetRowCellValue(e.RowHandle, "STAFF_CERTI_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_CERTIMainGridView.GetRowCellValue(e.RowHandle, "STAFF_CERTI_FILE").ToString();
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

        
        private void PQMS_STAFF_TRAINING_InfoGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_TRAIN_RESULT_DIR_FILE")
            {
                if (!PQMS_STAFF_TRAINING_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_RESULT_DIR_FILE").Equals(DBNull.Value) && PQMS_STAFF_TRAINING_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_RESULT_DIR_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_TRAINING_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_RESULT_DIR_FILE").ToString();
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

            if (e.Column.FieldName == "STAFF_TRAIN_REPORT_FILE")
            {
                if (!PQMS_STAFF_TRAINING_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_REPORT_FILE").Equals(DBNull.Value) && PQMS_STAFF_TRAINING_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_REPORT_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_TRAINING_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_TRAIN_REPORT_FILE").ToString();
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

        private void PQMS_ROLE2_EACH_LISTInfoGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "ATTACH_FILE")
            {
                if (!PQMS_ROLE2_EACH_LISTInfoGridView.GetRowCellValue(e.RowHandle, "ATTACH_FILE").Equals(DBNull.Value) && PQMS_ROLE2_EACH_LISTInfoGridView.GetRowCellValue(e.RowHandle, "ATTACH_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_ROLE2_EACH_LISTInfoGridView.GetRowCellValue(e.RowHandle, "ATTACH_FILE").ToString();
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

        private void PQMS_STAFF_ROLE_InfoGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_ROLE_FILE")
            {
                if (!PQMS_STAFF_ROLE_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_ROLE_FILE").Equals(DBNull.Value) && PQMS_STAFF_ROLE_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_ROLE_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_ROLE_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_ROLE_FILE").ToString();
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

        private void PQMS_STAFF_ROLE_PAPER_InfoGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "STAFF_RP_FILE")
            {
                if (!PQMS_STAFF_ROLE_PAPER_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_RP_FILE").Equals(DBNull.Value) && PQMS_STAFF_ROLE_PAPER_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_RP_FILE").ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_ROLE_PAPER_InfoGridView.GetRowCellValue(e.RowHandle, "STAFF_RP_FILE").ToString();
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

        private void PQMS_STAFF_ROLE_PAPER_InfoGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.Caption.Equals("직무기술서"))
            {
                string strFile = PQMS_STAFF_ROLE_PAPER_InfoGridView.GetFocusedDataRow()["STAFF_RP_FILE"].ToString();
                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void PQMS_STAFF_TR_FOLDER_InfoGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "FILE_PATH")
            {
                object filePathValue = PQMS_STAFF_TR_FOLDER_InfoGridView.GetRowCellValue(e.RowHandle, "FILE_PATH");

                if (filePathValue != null && filePathValue != DBNull.Value && filePathValue.ToString().Trim() != "")
                {
                    string strFile = PQMS_STAFF_TR_FOLDER_InfoGridView.GetRowCellValue(e.RowHandle, "FILE_PATH").ToString();
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

        private void PQMS_STAFF_TR_FOLDER_InfoGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.Caption.Equals("트래이닝폴더관리파일"))
            {
                string strFile = PQMS_STAFF_TR_FOLDER_InfoGridView.GetFocusedDataRow()["FILE_PATH"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
                }
            }
        }

        private void cmbSTAFF_TRAIN_ORG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSTAFF_TRAIN_ORG.Text == "직접입력")
            {
                txtSTAFF_TRAIN_ORG.Visible = true;
            }
            else
            {
                txtSTAFF_TRAIN_ORG.Visible = false;
                txtSTAFF_TRAIN_ORG.Text = cmbSTAFF_TRAIN_ORG.Text;
            }
            

        }

        private void btnStaffrole_AssessmentReport_Search_Click(object sender, EventArgs e)
        {
            Call_PQMS_STAFF_ASSESSMENT();
        }
    }
}
