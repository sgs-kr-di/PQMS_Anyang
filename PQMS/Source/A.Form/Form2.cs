using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using GroupDocs.Merger;

using Spire.Doc;
using System.IO;
using System.Data.OleDb;
using PQMS.C.Unit;
using System.Drawing;
using DevExpress.Data;

using Ulee.Utils;
using ComboBox = System.Windows.Forms.ComboBox;
using System.Data;
using System.Diagnostics;
using Spire.Doc.Documents;
using Spire.Xls;
//using DevExpress.XtraPrinting;

namespace PQMS
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

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

        private Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridDataSet Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridSet;
        private Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridDataSet Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridSet;
        private Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridDataSet Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridSet;
        private Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridDataSet Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridSet;

        private Form2_ApproveInfo_DataSet Form2_ApproveInfo_Set;
        private Form2PQMS_STAFF_Workspace_DataSet Form2PQMS_STAFF_Workspace_Set;
        
        private GridBookmark MainPageBookmark;
        public List<Form2PQMS_STAFF_EDUPageRow> PQMS_STAFF_EDUPageRow;
        public List<Form2PQMS_STAFF_MainPageRow> PQMS_STAFF_MainPageRows;
        public List<Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow> PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRows;
        public List<Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow> PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRows;

        private frmRepositoryInfo FrmRepositoryInfo;
       

        public Form2()
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

            Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridSet = new Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridSet = new Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridSet = new Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridDataSet(AppRes.DB.Connect, null, null);

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

            //p2Bookmark = new GridBookmark(PQMS_STAFF_EDUGridView);
            //PQMS_STAFF_EDUPageRow = new List<Form2PQMS_STAFF_EDUPageRow>();
            //PQMS_STAFF_EDUGrid.DataSource = PQMS_STAFF_EDUPageRow;
            //AppHelper.SetGridEvenRow(PQMS_STAFF_EDUGridView);

            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmb_Main_ORGCode);

            if (Form1PQMS_Repo.sRepo != null)
            {
                if (Form1PQMS_Repo.sRepo == "0003")
                {
                    cmb_Main_ORGCode.SelectedIndex = 4;
                }
                else
                {
                    cmb_Main_ORGCode.SelectedIndex = 6;
                }
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
        }

        private void get_folder_data7(ComboBox tCmb) //jhm
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select a.ORG_NAME+'_'+b.EDU_NAME, a.ORG_CODE, b.EDU_CODE from PQMS_ORG a ";
            query += "inner join PQMS_EDU b on a.ORG_CODE = b.EDU_ORG_CODE and a.SITE_CODE = b.SITE_CODE and a.REPOSITORY_CODE = b.REPOSITORY_CODE and a.WS_CODE = b.WS_CODE order by a.ORG_CODE, b.EDU_CODE";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    tCmb.Items.Clear();

                    while (reader.Read())
                    {
                        tCmb.Items.Add(reader.GetValue(0).ToString() + "/" + reader.GetValue(1).ToString() + "/" + reader.GetValue(2).ToString());
                    }
                }
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

        private void CAll_PQMS_EACH_LIST() 
        {
            // 개인별업무자료 조회 - '사번'이 Key
            try
            {
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Select();

                if (Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_EACH_LISTMainGrid, Form2PQMS_ROLE2_EACH_LIST_MainGridSet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("개인별업무자료 조회 실패!" + f.Message.ToString());
            }
        }

        //private void Call_PQMS_Main_Staff()
        //{
        //    if (string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName) == true)
        //    {
        //        MessageBox.Show("조직도를 먼저 선택해주세요.");
        //        return;
        //    }

        //    string rdbValue = "";
        //    string sgroupcode1 ="";
        //    bool bRdbStaffResignationValue = false;

        //    if (rdbKOLAS.Checked)
        //    {
        //        rdbValue = "0001";
        //    }
        //    else
        //    {
        //        rdbValue = "0002";
        //    }

        //    if (rdbSTAFF_RESIGNATION_DATE_YES.Checked)
        //    {
        //        bRdbStaffResignationValue = true;
        //    }
        //    else
        //    {
        //        bRdbStaffResignationValue = false;
        //    }

        //    try
        //    {
        //        AppHelper.RefreshGridData(PQMS_STAFF_AllGridView);

        //        if (rdbValue.Equals("0001"))
        //        {
        //            // 컬럼 보이기
        //            PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = true;
        //            PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = true;
        //            PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = true;
        //            PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = false;

        //            Form2Set.Select_StaffKolasTopTeam(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue);
        //            if (Form2Set.RowCount > 0)
        //            {
        //                AppHelper.SetGridDataSource(PQMS_STAFF_AllGrid, Form2Set);
        //                //MessageBox.Show("KOLAS 조회 성공!");
        //            }
        //            else
        //            {
        //                //MessageBox.Show("조회된 값이 없습니다.");
        //            }
        //        }
        //        else
        //        {
        //            // 컬럼 안보이기
        //            PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = false;
        //            PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = false;
        //            PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = false;
        //            PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = true;

        //            Form2Set.Select_StaffFoodTopTeam(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue);
        //            if (Form2Set.RowCount > 0)
        //            {
        //                AppHelper.SetGridDataSource(PQMS_STAFF_AllGrid, Form2Set);
        //                //MessageBox.Show("식약처 조회 성공!");
        //            }
        //            else
        //            {
        //                //MessageBox.Show("조회된 값이 없습니다.");
        //            }
        //        }
        //    }
        //    catch (Exception f)
        //    {
        //        MessageBox.Show("조회 실패!" + Environment.NewLine + f.Message.ToString());
        //    }
        //}

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
      
            rdbValue = cmb_Main_ORGCode.Text.Substring(0, 4);
            if(cmbMain_Group1Code.Text != null && cmbMain_Group1Code.Text != "")
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


            try
            {
                AppHelper.RefreshGridData(PQMS_STAFF_AllGridView);

                if (rdbValue.Equals("0001"))
                {
                    // 컬럼 보이기
                    PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = false;

                    Form2Set.Select_StaffKolasTopTeam(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue, cmbGroup1codeValue);
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
                    PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = true;

                    Form2Set.Select_StaffFoodTopTeam(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue, cmbGroup1codeValue);
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


            try
            {
                AppHelper.RefreshGridData(PQMS_STAFF_AllGridView);

                if (rdbValue.Equals("0001"))
                {
                    // 컬럼 보이기
                    PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = true;
                    PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = false;

                    Form2Set.Select_StaffKolasTopTeam_User(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue, cmbGroup1codeValue);
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
                    PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = false;
                    PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = true;

                    Form2Set.Select_StaffFoodTopTeam_User(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue, cmbGroup1codeValue);
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

        //private void Call_PQMS_Main_Staff_User()
        //{
        //    if (string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName) == true)
        //    {
        //        MessageBox.Show("조직도를 먼저 선택해주세요.");
        //        return;
        //    }

        //    string rdbValue = "";
        //    bool bRdbStaffResignationValue = false;

        //    if (rdbKOLAS.Checked)
        //    {
        //        rdbValue = "0001";
        //    }
        //    else
        //    {
        //        rdbValue = "0002";
        //    }

        //    if (rdbSTAFF_RESIGNATION_DATE_YES.Checked)
        //    {
        //        bRdbStaffResignationValue = true;
        //    }
        //    else
        //    {
        //        bRdbStaffResignationValue = false;
        //    }

        //    try
        //    {
        //        AppHelper.RefreshGridData(PQMS_STAFF_AllGridView);

        //        if (rdbValue.Equals("0001"))
        //        {
        //            // 컬럼 보이기
        //            PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = true;
        //            PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = true;
        //            PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = true;
        //            PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = false;

        //            Form2Set.Select_StaffKolasTopTeam_User(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue);
        //            if (Form2Set.RowCount > 0)
        //            {
        //                AppHelper.SetGridDataSource(PQMS_STAFF_AllGrid, Form2Set);
        //                //MessageBox.Show("KOLAS 조회 성공!");
        //            }
        //            else
        //            {
        //                //MessageBox.Show("조회된 값이 없습니다.");
        //            }
        //        }
        //        else
        //        {
        //            // 컬럼 안보이기
        //            PQMS_STAFF_AllGridView.Bands["gridBand2"].Visible = false;
        //            PQMS_STAFF_AllGridView.Bands["gridBand3"].Visible = false;
        //            PQMS_STAFF_AllGridView.Bands["gridBand7"].Visible = false;
        //            PQMS_STAFF_AllGridView.Bands["gridBand11"].Visible = true;

        //            Form2Set.Select_StaffFoodTopTeam_User(FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName, rdbValue, bRdbStaffResignationValue);
        //            if (Form2Set.RowCount > 0)
        //            {
        //                AppHelper.SetGridDataSource(PQMS_STAFF_AllGrid, Form2Set);
        //                //MessageBox.Show("식약처 조회 성공!");
        //            }
        //            else
        //            {
        //                //MessageBox.Show("조회된 값이 없습니다.");
        //            }
        //        }
        //    }
        //    catch (Exception f)
        //    {
        //        MessageBox.Show("조회 실패!" + Environment.NewLine + f.Message.ToString());
        //    }
        //}

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
        private void Call_PQMS_Main_Role(string sSTAFF_CODE = "")
        {
            // 직무자료
            Form2PQMS_STAFF_ROLESet.sSTAFF_CODE = sSTAFF_CODE;

            // 직무자료 조회 - '사번'이 Key
            try
            {
                Form2PQMS_STAFF_ROLESet.SelectSTAFF_ROLE();

                if (Form2Set.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_ROLEGrid, Form2PQMS_STAFF_ROLESet);
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

        private void Call_PQMS_Info_Role(string sSTAFF_CODE = "")
        {
            // 직무자료
            Form2PQMS_STAFF_ROLEGridInfoSet.sSTAFF_CODE = sSTAFF_CODE;

            // 직무자료 조회 - '사번'이 Key
            try
            {
                Form2PQMS_STAFF_ROLEGridInfoSet.SelectSTAFF_ROLE();

                if (Form2Set.Empty == false)
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

        private void Call_PQMS_STAFF_TRAINING()
        {
            // 교육보고서 조회 - '사번'이 Key
            // Main 화면에서 사번 값을 받아옴
            try
            {
                //jhm
                get_folder_data7(cmbEduOrg2);

                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Select();

                if (Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(Form2PQMS_STAFF_TRAINING_MainGrid, Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet);
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
                    AppHelper.SetGridDataSource(Form2PQMS_STAFF_TRAINING_InfoGrid, Form2PQMS_PQMS_STAFF_TRAINING_InfoGridSet);
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

        private void Call_PQMS_STAFF_ROLE_PAPER() 
        {
            // 직무기술서 조회 - '사번'이 Key
            try
            {
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.Select();

                if (Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_ROLE_PAPERMainGrid, Form2PQMS_STAFF_ROLE_PAPER_MainGridSet);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("직무기술서 조회 실패!" + Environment.NewLine + f.Message.ToString());
            }
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
                        tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
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
                        tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
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
                        tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                    }
                }
            }

            Conn.Close();

        }

        private void get_folder_data6(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


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
                        tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
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
                Form2Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
                Form2Set.sSTAFF_NAME = txtSTAFF_NAME.Text;
                Form2Set.sSTAFF_TEAM = Form2PQMS_STAFF_Workspace_Set.sSTAFF_TEAM;
                Form2Set.sSTAFF_JOIN_DATE = txtSTAFF_JOIN_DATE.Text;
                Form2Set.sSTAFF_MAJOR = txtSTAFF_MAJOR.Text;
                Form2Set.sSTAFF_SCHOOL = txtSTAFF_SCHOOL.Text;
                Form2Set.sSTAFF_RESIGNATION_DATE = txtSTAFF_RESIGNATION_DATE.Text;
                Form2Set.sSTAFF_EMPNO = txtSTAFF_EMPNO.Text;
                Form2Set.sSTAFF_ACCOUNTNO = txtSTAFF_ACCOUNTNO.Text;


                //Form2Set.sSTAFF_ACCOUNTNO = Form2PQMS_LoginInfo.sAccountNo 


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
                Form2Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
                Form2Set.sSTAFF_NAME = txtSTAFF_NAME.Text;
                Form2Set.sSTAFF_TEAM = Form2PQMS_STAFF_Workspace_Set.sSTAFF_TEAM;
                Form2Set.sSTAFF_JOIN_DATE = txtSTAFF_JOIN_DATE.Text;
                Form2Set.sSTAFF_MAJOR = txtSTAFF_MAJOR.Text;
                Form2Set.sSTAFF_SCHOOL = txtSTAFF_SCHOOL.Text;
                Form2Set.sSTAFF_RESIGNATION_DATE = txtSTAFF_RESIGNATION_DATE.Text;
                Form2Set.sSTAFF_EMPNO = txtSTAFF_EMPNO.Text;
                Form2Set.sSTAFF_ACCOUNTNO = txtSTAFF_ACCOUNTNO.Text;

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
            cmbMainCertiRole.Text = txtMainCertiRoleCode.Text + " " + txtMainMidCertiRole.Text;

            // 대분야
            txtMainCertiBigOrgCode.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["GROUP1_CODE"].ToString();
            txtMainCertiBigOrgName.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["GROUP1_NAME"].ToString();
            cmbMainCertiBigOrgName.Text = txtMainCertiBigOrgCode.Text + " " + txtMainCertiBigOrgName.Text;

            // 중분야
            txtMainCertiMidOrgCode.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["GROUP2_CODE"].ToString();
            txtMainCertiMidOrgName.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["GROUP2_NAME"].ToString();
            cmbMainCertiMidOrgName.Text = txtMainCertiMidOrgCode.Text + " " + txtMainCertiMidOrgName.Text;

            // 분야코드
            txtMainCertiOrgCode.Text = txtMainCertiBigOrgCode.Text + "-" + txtMainCertiMidOrgCode.Text;

            // 직무코드
            cmbMainCertiRoleCode.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["ROLE_CODE"].ToString();
            cmbMainCertiRoleName.Text = cmbMainCertiRoleCode.Text + " " + PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["ROLE_NAME"].ToString();

            // 자격증 정보
            txtSTAFF_CERTI_ROLE.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_ROLE"].ToString();
            txtSTAFF_CERTI_NAME.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_NAME"].ToString();
            txtSTAFF_CERTI_DATE.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_ROLE_DATE"].ToString();
            txtSTAFF_CERTI_FILE.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_FILE"].ToString();

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
            Form2PQMS_STAFF_ROLESet.iIDX = Convert.ToInt32(PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["IDX"]);
            txtSTAFF_CODE_ROLE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_CODE"].ToString();
            //txtSTAFF_ROLE_DATE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_DATE"].ToString();
            txtSTAFF_ROLE_CLASS.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CLASS"].ToString();
            txtSTAFF_ROLE_ORG_CODE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_ORG_CODE"].ToString();
            //txtSTAFF_ROLE_CODE_no.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CODE"].ToString();
            cmbSTAFF_ROLE_CODE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CODE"].ToString();
            txtSTAFF_ROLE_NAME.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_NAME"].ToString();
            cmbSTAFF_ROLE_STATUS.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_STATUS"].ToString();
            //txtSTAFF_ROLE_STATUS_no.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_STATUS"].ToString();
            //txtSTAFF_ROLE_GIVEN_CLASS_no.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_GIVEN_CLASS"].ToString();
            cmbSTAFF_ROLE_GIVEN_CLASS.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_GIVEN_CLASS"].ToString();
            cmbSTAFF_ROLE_CERTI.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CERTI"].ToString();
            //txtSTAFF_ROLE_CERTI_no.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CERTI"].ToString();
            txtSTAFF_ROLE_INSTEAD.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_INSTEAD"].ToString();

            dtpOrder.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_DATE"].ToString();

            txtOrgName.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["ORG_NAME"].ToString();
            cmbFolder.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["ORG_CODE"].ToString() + " " + PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["ORG_NAME"].ToString(); ;

            txtBig.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP1_NAME"].ToString();
            txtMid.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_NAME"].ToString();

            txtGroup1Code.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP1_CODE"].ToString();
            txtGroup2Code.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["GROUP2_CODE"].ToString();

            cmbGroup1.Text = txtGroup1Code.Text + " " + txtBig.Text;
            cmbGroup2.Text = txtGroup2Code.Text + " " + txtMid.Text;

            cmbRole.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CODE"].ToString() + " " + PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_NAME"].ToString();

            txtSTAFF_ROLE_STAFF_ROLE_NOTE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_NOTE"].ToString();

            txtSTAFF_ROLE_QUALITY_DIR_FILE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_QUALITY_DIR_FILE"].ToString();
            txtSTAFF_ROLE_TEST_DIR_FILE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_TEST_DIR_FILE"].ToString();


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

                    document.LoadFromFile(rpt);
                    document.SaveToFile(savefile);
                    document.Close();

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

                // $" ('{sSTAFF_CODE}', '{sSTAFF_ROLE_ORG_CODE}', '{sROLE_CODE}', '{sSTAFF_ROLE_CLASS}', '{sSTAFF_CERTI_ROLE}', '{sSTAFF_CERTI_NAME}', '{sSTAFF_CERTI_DATE}', '{sSTAFF_CERTI_FILE}'); ";
                Form2PQMS_STAFF_CERTISet.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");

                Call_PQMS_Main_Certi(PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());
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

                            document.LoadFromFile(rpt);
                            document.SaveToFile(savefile);
                            document.Close();

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

                        document.LoadFromFile(rpt);
                        document.SaveToFile(savefile);
                        document.Close();

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

                Form2PQMS_STAFF_CERTISet.Update(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("수정 완료!");

                Call_PQMS_Main_Certi(PQMS_STAFF_CERTIMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());
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

                MessageBox.Show("삭제 완료!");

                Call_PQMS_Main_Certi(PQMS_STAFF_CERTIMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());
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



            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                if (string.IsNullOrEmpty(txtGroup1Code.Text) == false || string.IsNullOrEmpty(txtGroup2Code.Text) == false)
                {
                    if (string.IsNullOrEmpty(txtSTAFF_ROLE_QUALITY_DIR_FILE.Text) == false)
                    {
                        //File.Copy(rpt, savefile, overwrite: true);

                        Document document = new Document();

                        string rpt = txtSTAFF_ROLE_QUALITY_DIR_FILE.Text;
                        string sfileName = Path.GetFileNameWithoutExtension(rpt);
                        string sExtensionName = Path.GetExtension(rpt);
                        string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                        string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");


                        string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "품질평가" + @"\" + sDateTime_yyyyMM;

                        DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                        if (file_di.Exists == false)
                        {
                            Directory.CreateDirectory(savrfilepath);
                        }
                        string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                        document.LoadFromFile(rpt);
                        document.SaveToFile(savefile);
                        document.Close();

                        txtSTAFF_ROLE_QUALITY_DIR_FILE.Text = savefile;
                        
                    }

                    if (string.IsNullOrEmpty(txtSTAFF_ROLE_TEST_DIR_FILE.Text) == false)
                    {
                        //File.Copy(rpt, savefile, overwrite: true);

                        Document document = new Document();

                        string rpt = txtSTAFF_ROLE_TEST_DIR_FILE.Text;
                        string sfileName = Path.GetFileNameWithoutExtension(rpt);
                        string sExtensionName = Path.GetExtension(rpt);
                        string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                        string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                        string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "시험평가" + @"\" + sDateTime_yyyyMM;
                        DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                        if (file_di.Exists == false)
                        {
                            Directory.CreateDirectory(savrfilepath);
                        }

                        string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                        document.LoadFromFile(rpt);
                        document.SaveToFile(savefile);
                        document.Close();

                        txtSTAFF_ROLE_TEST_DIR_FILE.Text = savefile;
                        
                    }

                    Form2PQMS_STAFF_ROLESet.sSTAFF_CODE = txtSTAFF_CODE_ROLE.Text;
                    //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_DATE = txtSTAFF_ROLE_DATE.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_DATE = dtpOrder.Text;
                    //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS = txtSTAFF_ROLE_CLASS.Text;
                    Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS = txtGroup1Code.Text + "-" + txtGroup2Code.Text;
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

                    MessageBox.Show("입력 완료!");
                    Call_PQMS_Main_Role(Form2PQMS_STAFF_ROLESet.sSTAFF_CODE);
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
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                if (string.IsNullOrEmpty(txtSTAFF_ROLE_QUALITY_DIR_FILE.Text) == false)
                {
                    if (txtSTAFF_ROLE_QUALITY_DIR_FILE.Text.ToString().ToUpper().Contains(unitCommon.sFileServerName) == true)
                    {
                        FileInfo fi = new FileInfo(txtSTAFF_ROLE_QUALITY_DIR_FILE.Text);
                        if (fi.Exists == false) //
                        {
                            Document document = new Document();

                            string rpt = txtSTAFF_ROLE_QUALITY_DIR_FILE.Text;
                            string sfileName = Path.GetFileNameWithoutExtension(rpt);
                            string sExtensionName = Path.GetExtension(rpt);
                            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");
                            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");


                            string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "품질평가" + @"\" + sDateTime_yyyyMM;

                            DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                            if (file_di.Exists == false)
                            {
                                Directory.CreateDirectory(savrfilepath);
                            }
                            string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                            document.LoadFromFile(rpt);
                            document.SaveToFile(savefile);
                            document.Close();

                            txtSTAFF_ROLE_QUALITY_DIR_FILE.Text = savefile;
                        }
                    }
                    else
                    {
                        Document document = new Document();

                        string rpt = txtSTAFF_ROLE_QUALITY_DIR_FILE.Text;
                        string sfileName = Path.GetFileNameWithoutExtension(rpt);
                        string sExtensionName = Path.GetExtension(rpt);
                        string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");


                        string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "품질평가" + @"\" + sDateTime_yyyyMM;

                        DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                        if (file_di.Exists == false)
                        {
                            Directory.CreateDirectory(savrfilepath);
                        }
                        string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                        document.LoadFromFile(rpt);
                        document.SaveToFile(savefile);
                        document.Close();

                        txtSTAFF_ROLE_QUALITY_DIR_FILE.Text = savefile;
                    }    
                }

                if (string.IsNullOrEmpty(txtSTAFF_ROLE_TEST_DIR_FILE.Text) == false)
                {

                    if (txtSTAFF_ROLE_TEST_DIR_FILE.Text.ToString().ToUpper().Contains(unitCommon.sFileServerName) == true)
                    {
                        FileInfo fi = new FileInfo(txtSTAFF_ROLE_TEST_DIR_FILE.Text);
                        if (fi.Exists == false) //
                        {
                            Document document = new Document();

                            string rpt = txtSTAFF_ROLE_TEST_DIR_FILE.Text;
                            string sfileName = Path.GetFileNameWithoutExtension(rpt);
                            string sExtensionName = Path.GetExtension(rpt);
                            string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                            string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "시험평가" + @"\" + sDateTime_yyyyMM;
                            DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                            if (file_di.Exists == false)
                            {
                                Directory.CreateDirectory(savrfilepath);
                            }

                            string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                            document.LoadFromFile(rpt);
                            document.SaveToFile(savefile);
                            document.Close();

                            txtSTAFF_ROLE_TEST_DIR_FILE.Text = savefile;
                        }
                    }
                    else
                    {

                        Document document = new Document();

                        string rpt = txtSTAFF_ROLE_TEST_DIR_FILE.Text;
                        string sfileName = Path.GetFileNameWithoutExtension(rpt);
                        string sExtensionName = Path.GetExtension(rpt);
                        string sDateTime_yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");

                        string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
                        string savrfilepath = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Result\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + "시험평가" + @"\" + sDateTime_yyyyMM;
                        DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
                        if (file_di.Exists == false)
                        {
                            Directory.CreateDirectory(savrfilepath);
                        }

                        string savefile = savrfilepath + @"\" + sfileName + "_" + sDateTime_yyyyMMddHHmmss + sExtensionName;

                        document.LoadFromFile(rpt);
                        document.SaveToFile(savefile);
                        document.Close();

                        txtSTAFF_ROLE_TEST_DIR_FILE.Text = savefile;
                    }
                }


                //Grid의 Row Cell 클릭하면 IDX 값 변수에 저장됨. iIDX
                //Form2PQMS_STAFF_ROLESet.iIDX = 1;
                Form2PQMS_STAFF_ROLESet.sSTAFF_CODE = txtSTAFF_CODE_ROLE.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_DATE = dtpOrder.Text;
                //Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS = txtSTAFF_ROLE_CLASS.Text;
                Form2PQMS_STAFF_ROLESet.sSTAFF_ROLE_CLASS = txtGroup1Code.Text + "-" + txtGroup2Code.Text;
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

                MessageBox.Show("수정 완료!");
                Call_PQMS_Main_Role(Form2PQMS_STAFF_ROLESet.sSTAFF_CODE);
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
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2PQMS_STAFF_ROLESet.sSTAFF_CODE = txtSTAFF_CODE_ROLE.Text;

                Form2PQMS_STAFF_ROLESet.Delete(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("삭제 완료!");
                Call_PQMS_Main_Role(Form2PQMS_STAFF_ROLESet.sSTAFF_CODE);
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

            // 직원자료
            Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();

            // 교육자료
            Form2PQMS_STAFF_MainEDUSet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();

            // 자격증자료
            Form2PQMS_STAFF_MainCERTISet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();

            // 직무자료
            Form2PQMS_STAFF_MainROLESet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();

            // 직무기술서
            Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();

            // 개인별업무목록
            Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();

            // 개인별업무목록_현황
            Form2PQMS_ROLE2_EACH_LIST_InfoGridSet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();

            // 교육보고서
            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();

            // 교육보고서 - 현황
            Form2PQMS_PQMS_STAFF_TRAINING_InfoGridSet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();

            // 전직장정보
            Form2PQMS_StaffInfo.sStaffCode = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();

            // 사원 팀정보
            Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_TEAM").ToString();

            // 교육보고서
            //Form2PQMS_StaffInfo.sStaffCode = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();

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

            //// 직무자료 조회 - '사번'이 Key
            //try
            //{
            //    Form2PQMS_STAFF_MainROLESet.SelectSTAFF_ROLE();

            //    if (Form2Set.Empty == false)
            //    {
            //        AppHelper.SetGridDataSource(PQMS_STAFF_ROLEMainGrid, Form2PQMS_STAFF_MainROLESet);
            //    }
            //    else
            //    {

            //    }
            //}
            //catch (Exception f)
            //{
            //    MessageBox.Show("직무자료 조회 실패!" + f.Message.ToString());
            //}

            //// 개인별업무자료 조회 - '사번'이 Key
            CAll_PQMS_EACH_LIST();

            //// 개인별업무자료 조회 - '사번'이 Key
            //try
            //{
            //    Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Select();

            //    if (Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Empty == false)
            //    {
            //        AppHelper.SetGridDataSource(PQMS_ROLE2_EACH_LISTMainGrid, Form2PQMS_ROLE2_EACH_LIST_MainGridSet);
            //    }
            //    else
            //    {

            //    }
            //}
            //catch (Exception f)
            //{
            //    MessageBox.Show("개인별업무자료 조회 실패!" + f.Message.ToString());
            //}

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

            // 교육 조회
            Call_PQMS_Main_Edu(PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString());

            // 교육자료 - 현황조회
            Call_PQMS_Main_Edu(PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString());

            // 자격증자료 조회
            Call_PQMS_Main_Certi(PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString());

            // 직무자료 조회
            Call_PQMS_Main_Role(PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString());

            // 직무자료 현황조회
            Call_PQMS_Info_Role(PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString());

            // 교육보고서 조회
            Call_PQMS_STAFF_TRAINING();

            // 교육보고서 현황 조회
            Call_PQMS_STAFF_TRAINING_Info();

            // 직무기술서 조회
            Call_PQMS_STAFF_ROLE_PAPER();

            if (! Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("FOOD")) 
            {
                //교육 Tab Page로 이동
                tabControl1.SelectedTab = tabControl1.TabPages[1];
            }

            // 직무기술서 조회
            Call_PQMS_STAFF_ROLE_PAPER();
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

        public void EnablebtnLookUpData()
        {

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
                this.tabControl1.TabPages.Remove(this.tabPage2);
            }
            catch (Exception f)
            {
                //string test = f.ToString();
                //AppRes.DB.RollbackTrans();
                MessageBox.Show("Load Form2 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder);
        }

        private void btnGroup1_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtSTAFF_ROLE_ORG_CODE.Text, cmbGroup1);
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
            txtSTAFF_ROLE_ORG_CODE.Text = cmbFolder.Text.Substring(0, 4);
            txtOrgName.Text = cmbFolder.Text.Substring(5, cmbFolder.Text.Length - 5);
        }

        private void cmbGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGroup1Code.Text = cmbGroup1.Text.Substring(0, 4);
            txtBig.Text = cmbGroup1.Text.Substring(5, cmbGroup1.Text.Length - 5);

            txtSTAFF_ROLE_CLASS.Text = txtGroup1Code.Text + "-" + txtGroup2Code.Text;
        }

        private void cmbGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGroup2Code.Text = cmbGroup2.Text.Substring(0, 4);
            txtMid.Text = cmbGroup2.Text.Substring(5, cmbGroup2.Text.Length - 5);

            txtSTAFF_ROLE_CLASS.Text = txtGroup1Code.Text + "-" + txtGroup2Code.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            get_folder_data6("PQMS_ROLE", "ROLE_CODE", "ROLE_NAME", cmbRole);
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSTAFF_ROLE_CODE.Text = cmbRole.Text.Substring(0, 4);
            txtSTAFF_ROLE_NAME.Text = cmbRole.Text.Substring(5, cmbRole.Text.Length - 5);
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
                //Call_PQMS_Main_Staff_User();
                Call_PQMS_Main_Staff_User_Ver2();                
            }
            else 
            {
                // Call_PQMS_Main_Staff();                
                Call_PQMS_Main_Staff_Ver2();
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

            txtSTAFF_CODE_CERTI.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString(); //자격증자료
            txtSTAFF_CODE_ROLE.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString(); //직무자료
            txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString(); //직무기술서
            txtSTAFF_CODE_PQMS_STAFF_TRAINING.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString(); //교육보고서
            txtIdx_EACH_LIST_STAFF_CODE.Text = PQMS_STAFFMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString(); //개별업무

            //txtSTAFF_EMPNO.Text = 

            
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
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbMainCertiRole);
        }

        private void btnMainCertiBigOrg_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtMainCertiRoleCode.Text, cmbMainCertiBigOrgName);
        }

        private void btnMainCertiMidOrg_Click(object sender, EventArgs e)
        {
            get_folder_data3("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbMainCertiMidOrgName);
        }

        private void cmbMainCertiRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMainCertiRoleCode.Text = cmbMainCertiRole.Text.Substring(0, 4);
            txtMainMidCertiRole.Text = cmbMainCertiRole.Text.Substring(5, cmbMainCertiRole.Text.Length - 5);
        }

        private void cmbMainCertiBigOrgName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMainCertiBigOrgCode.Text = cmbMainCertiBigOrgName.Text.Substring(0, 4);
            txtMainCertiBigOrgName.Text = cmbMainCertiBigOrgName.Text.Substring(5, cmbMainCertiBigOrgName.Text.Length - 5);

            txtMainCertiOrgCode.Text = txtMainCertiBigOrgCode.Text + "-" + txtMainCertiMidOrgCode.Text;
        }

        private void cmbMainCertiMidOrgName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMainCertiMidOrgCode.Text = cmbMainCertiMidOrgName.Text.Substring(0, 4);
            txtMainCertiMidOrgName.Text = cmbMainCertiMidOrgName.Text.Substring(5, cmbMainCertiMidOrgName.Text.Length - 5);

            txtMainCertiOrgCode.Text = txtMainCertiBigOrgCode.Text +"-"+txtMainCertiMidOrgCode.Text;
        }

        private void btnMainCertiRoleCode_Click(object sender, EventArgs e)
        {
            get_folder_data4("PQMS_ROLE", "ROLE_CODE", "ROLE_NAME", cmbMainCertiRoleName);
        }

        private void cmbMainCertiRoleCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMainCertiRoleCode.Text = cmbMainCertiRoleName.Text.Substring(0, 4);
            cmbMainCertiRoleName.Text = cmbMainCertiRoleName.Text.Substring(5, cmbMainCertiRoleName.Text.Length - 5);
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

                    document.LoadFromFile(rpt);
                    document.SaveToFile(savefile);
                    document.Close();

                    txtROLE2_EACH_LIST_AttachFile.Text = savefile;
                    Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sATTACH_FILE = savefile;
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
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_REMARK = txtMainREMARK_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sTest_FIELD = txtTestField.Text;  //jhm0711
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sSTAFF_CODE = txtIdx_EACH_LIST_STAFF_CODE.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sATTACH_FILE = txtROLE2_EACH_LIST_AttachFile.Text;


                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");

                CAll_PQMS_EACH_LIST();
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패! " + Environment.NewLine + f.Message);
            }
        }

        private void btnROLE2_EACH_LISTUpdate_Click(object sender, EventArgs e)
        {
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

                            document.LoadFromFile(rpt);
                            document.SaveToFile(savefile);
                            document.Close();

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

                        document.LoadFromFile(rpt);
                        document.SaveToFile(savefile);
                        document.Close();

                        txtROLE2_EACH_LIST_AttachFile.Text = savefile;
                        Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sATTACH_FILE = savefile;
                    }                    
                }


                //Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sSITE_CODE = Form1PQMS_Repo.sSiteCode;
                //Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sREPOSITORY_CODE = Form1PQMS_Repo.sRepo;
                //Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sWS_CODE = Form1PQMS_Repo.sWS;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.iIDX = Convert.ToInt32(PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("IDX"));
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sROLE_CODE = txtMainROLE_CODE_EACH_LIST.Text;
                //Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sROLE_CODE = txtMainROLE_CODE_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_NO = txtMainLIST_NO_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_WORKDATE = txtMainWORKDATE_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP1 = txtMainLIST_GROUP1_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP2 = txtMainLIST_GROUP2_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_CONTENTS1 = txtMainLIST_CONTENTS1_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_CHKDATE = txtChkOrder_EACH_LIST.Text;
                //Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_CHKSIGN = txtMainLIST_CHKSIGN_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_TECHNICAL_MANAGER = txtMainTECHNICAL_MANAGER_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sLIST_REMARK = txtMainREMARK_EACH_LIST.Text;
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sTest_FIELD = txtTestField.Text; //jhm0711

                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Update(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("수정 완료!");

                CAll_PQMS_EACH_LIST();
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("수정 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void btnROLE2_EACH_LISTDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.iIDX = Convert.ToInt32(PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("IDX"));
                Form2PQMS_ROLE2_EACH_LIST_MainGridSet.Delete(trans);
                AppRes.DB.CommitTrans();

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
            
            txtIdx_EACH_LIST_GiSool.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("IDX").ToString();
            //txtMainROLE_CODE_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("ROLE_CODE").ToString();
            //txtSTAFF_ROLE_ORG_CODE_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("ORG_CODE").ToString();
            txtMainLIST_NO_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_NO").ToString();
            txtMainWORKDATE_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_WORKDATE").ToString();
            //txtMainLIST_GROUP1_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_GROUP1").ToString();
            //txtMainLIST_GROUP2_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_GROUP2").ToString();
            txtMainLIST_CONTENTS1_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_CONTENTS1").ToString();
            //txtChkOrder_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_CHKDATE").ToString();
            //txtMainLIST_CHKSIGN_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_CHKSIGN").ToString();
            //txtMainTECHNICAL_MANAGER_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_TECHNICAL_MANAGER").ToString();
            txtMainREMARK_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_REMARK").ToString();
            
            txtTestField.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("TEST_FIELD").ToString();

            //txtOrgName_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("ORG_NAME").ToString();
            //cmbFolder_EACH_LIST.Text = txtSTAFF_ROLE_ORG_CODE_EACH_LIST.Text + " " + txtOrgName_EACH_LIST.Text;

            //txtBig_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("GROUP1_NAME").ToString();
            //cmbMainGroup1_EACH_LIST.Text = txtMainLIST_GROUP1_EACH_LIST.Text + " " + txtBig_EACH_LIST.Text;

            //txtMid_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("GROUP2_NAME").ToString();
            //cmbMainGroup2_EACH_LIST.Text = txtMainLIST_GROUP2_EACH_LIST.Text + " " + txtMid_EACH_LIST.Text;

            txtROLE2_EACH_LIST_AttachFile.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("ATTACH_FILE").ToString();


            Form2_GridIdx.sIDX = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("IDX").ToString();

            if (e.Column.Caption.Equals("첨부파일"))
            {
                string strFile = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedDataRow()["ATTACH_FILE"].ToString();

                FileInfo fileInfo = new FileInfo(strFile); //해당경로에 파일이 있으면 파일 열기
                if (fileInfo.Exists)
                {
                    Process.Start(strFile);
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

        private void btnInsertPQMS_STAFF_TRAINING_Click(object sender, EventArgs e)
        {
            if (txtSTAFF_CODE_PQMS_STAFF_TRAINING.Text == "")
            {
                MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                return;
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

                    document.LoadFromFile(rpt);
                    document.SaveToFile(savefile);
                    document.Close();

                    txtSTAFF_TRAIN_RESULT_DIR_FILE.Text = savefile;
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT_DIR_FILE = savefile;
                }

                //Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE = txtSTAFF_CODE.Text;                   //Main(기본자료)에서 받아오는 값
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_COURSE = cmbEduOrg2.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_GUBUN = txtSTAFF_TRAIN_GUBUN.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_ORG = txtSTAFF_TRAIN_ORG.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_TRAINER = txtSTAFF_TRAIN_TRAINER.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_DATE = dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_FROM.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_DATE_TO = dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_TO.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_HOUR = txtSTAFF_TRAIN_HOUR.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_ATTENDEE = txtSTAFF_TRAIN_ATTENDEE.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_GOAL = txtSTAFF_TRAIN_GOAL.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_SUMMARY = txtSTAFF_TRAIN_SUMMARY.Text;
                //Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_CONTENTS = txtSTAFF_TRAIN_CONTENTS.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_CONTENTS = Form2STAFF_TRAIN_CONTENTS.sSTAFF_TRAIN_CONTENTS;

                //jhm
                if (string.IsNullOrEmpty(txtSTAFF_TRAIN_RESULT.Text) == true)
                {
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT = "N/A";
                }
                else
                {
                    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT = txtSTAFF_TRAIN_RESULT.Text;
                }

                //if (string.IsNullOrEmpty(txtSTAFF_TRAIN_RESULT.Text) == true)
                //{
                //    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT = "N/A";
                //}
                //else 
                //{
                //    Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT = txtSTAFF_TRAIN_RESULT.Text;
                //}

                
                //Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT_DIR_FILE = txtSTAFF_TRAIN_RESULT_DIR_FILE.Text; 위의 파일 업로드에서 입력됨.

                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEW = txtSTAFF_TRAIN_REVIEW.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_WRITER = txtSTAFF_TRAIN_WRITER.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_WRITE_DATE = txtSTAFF_TRAIN_WRITE_DATE.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEWER = txtSTAFF_TRAIN_REVIEWER.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEW_DATE = txtSTAFF_TRAIN_REVIEW_DATE.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_APPROVER = txtSTAFF_TRAIN_APPROVER.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_APPROVAL_DATE = txtSTAFF_TRAIN_APPROVAL_DATE.Text;

                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_EDU = cmbEduOrg2.SelectedItem.ToString();

                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");

                Form2STAFF_TRAIN_CONTENTS.sSTAFF_TRAIN_CONTENTS = "";

                Call_PQMS_STAFF_TRAINING();

                //// 교육자료 조회
                //Call_PQMS_Main_Edu(PQMS_STAFF_EDUMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
            }

            
        }

        private void btnUpdatePQMS_STAFF_TRAINING_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                if (string.IsNullOrEmpty(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text) == false)
                {
                    if (txtSTAFF_TRAIN_RESULT_DIR_FILE.Text.ToString().ToUpper().Contains(unitCommon.sFileServerName) == true)
                    {
                        FileInfo fi = new FileInfo(txtSTAFF_TRAIN_RESULT_DIR_FILE.Text);
                        if (fi.Exists == false) //
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

                            document.LoadFromFile(rpt);
                            document.SaveToFile(savefile);
                            document.Close();

                            txtSTAFF_TRAIN_RESULT_DIR_FILE.Text = savefile;
                            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT_DIR_FILE = savefile;
                        }
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

                        document.LoadFromFile(rpt);
                        document.SaveToFile(savefile);
                        document.Close();

                        txtSTAFF_TRAIN_RESULT_DIR_FILE.Text = savefile;
                        Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT_DIR_FILE = savefile;
                    }                            
                }

                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.iIDX = Convert.ToInt32(txtIdx_PQMS_STAFF_TRAINING_EduBogo.Text);
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_COURSE = cmbEduOrg2.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_GUBUN = txtSTAFF_TRAIN_GUBUN.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_ORG = txtSTAFF_TRAIN_ORG.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_TRAINER = txtSTAFF_TRAIN_TRAINER.Text;               
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_DATE = dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_FROM.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_DATE_TO = dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_TO.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_HOUR = txtSTAFF_TRAIN_HOUR.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_ATTENDEE = txtSTAFF_TRAIN_ATTENDEE.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_GOAL = txtSTAFF_TRAIN_GOAL.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_SUMMARY = txtSTAFF_TRAIN_SUMMARY.Text;
                //Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_CONTENTS = txtSTAFF_TRAIN_CONTENTS.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_CONTENTS = Form2STAFF_TRAIN_CONTENTS.sSTAFF_TRAIN_CONTENTS;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT = txtSTAFF_TRAIN_RESULT.Text;
                //Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_RESULT_DIR_FILE = txtSTAFF_TRAIN_RESULT_DIR_FILE.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEW = txtSTAFF_TRAIN_REVIEW.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_WRITER = txtSTAFF_TRAIN_WRITER.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_WRITE_DATE = txtSTAFF_TRAIN_WRITE_DATE.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEWER = txtSTAFF_TRAIN_REVIEWER.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_REVIEW_DATE = txtSTAFF_TRAIN_REVIEW_DATE.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_APPROVER = txtSTAFF_TRAIN_APPROVER.Text;
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_TRAIN_APPROVAL_DATE = txtSTAFF_TRAIN_APPROVAL_DATE.Text;

                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Update(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("수정 완료!");

                Call_PQMS_STAFF_TRAINING();
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
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.iIDX = Convert.ToInt32(txtIdx_PQMS_STAFF_TRAINING_EduBogo.Text);
                Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.Delete(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("삭제 완료!");

                Call_PQMS_STAFF_TRAINING();
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void Form2PQMS_STAFF_TRAINING_MainGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            try
            {
                txtIdx_PQMS_STAFF_TRAINING_EduBogo.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("IDX").ToString();
                //Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.iIDX = Convert.ToInt32(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("IDX"));
                txtSTAFF_CODE_PQMS_STAFF_TRAINING.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();
                txtSTAFF_TRAIN_COURSE.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_COURSE").ToString();
                txtSTAFF_TRAIN_GUBUN.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_GUBUN").ToString();
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

                Form2STAFF_TRAIN_CONTENTS.sSTAFF_TRAIN_CONTENTS = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_CONTENTS").ToString();

                // 교육보고서에 사용되는 변수
                Form2PQMS_StaffInfo.sPQMS_STAFF_TRAINING_IDX = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("IDX").ToString();

                //jhm
                cmbEduOrg2.SelectedItem = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_EDU").ToString();

                DateTime DT_TO = DateTime.Parse(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE_TO").ToString());
                dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_TO.Value = DT_TO;

                //dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_TO.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE_TO").ToString();
                //txtSTAFF_TRAIN_DATE_TO.Text = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE_TO").ToString();
                DateTime DT_FROM = DateTime.Parse(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE").ToString());
                dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_FROM.Value = DT_FROM;
                //DateTime DT_TO = DateTime.Parse(Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_DATE_TO").ToString());
                //dtpSTAFF_TRAIN_DATE_PQMS_STAFF_TRAINING_TO.Value = DT_TO;

                Form2_GridIdx.sIDX = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("IDX").ToString();


                
                if (e.Column.Caption.Equals("훈련결과증빙"))
                {
                    string strFile = Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedDataRow()["STAFF_TRAIN_RESULT_DIR_FILE"].ToString();

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

        private void btnInsertPQMS_STAFF_ROLE_PAPER_Click(object sender, EventArgs e)
        {
            if (txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text == "")
            {
                MessageBox.Show("관리번호가 없습니다.\n 부서 선택 후 자료검색탭에서 사용자 선택 후 다시 입력 하세요");
                return;
            }

            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_DATE = dtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS = txtRPGroup1Code.Text + "-" + txtRPGroup2Code.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_ORG_CODE = txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CODE = txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_APPROVER = txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_APPROVE_DATE = dtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_SUPPORTER = txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_WRITER = txtSTAFF_RP_WRITER_PQMS_STAFF_ROLE_PAPER.Text; //jhm0708
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_WRITE_DATE = dtSTAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER.Text; //jhm0708

                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");

                btnSelectPQMS_STAFF_ROLE_PAPER.PerformClick();

                //// 교육자료 조회
                //Call_PQMS_Main_Edu(PQMS_STAFF_EDUMainGridView.GetFocusedDataRow()["STAFF_CODE"].ToString());
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void btnUpdatePQMS_STAFF_ROLE_PAPER_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.iIDX = Convert.ToInt32(txtIDX_PQMS_STAFF_ROLE_PAPER.Text);
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_DATE = dtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CLASS = txtRPGroup1Code.Text + "-" + txtRPGroup2Code.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_ORG_CODE = txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_CODE = txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_APPROVER = txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_APPROVE_DATE = dtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_SUPPORTER = txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.Text;
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_WRITER = txtSTAFF_RP_WRITER_PQMS_STAFF_ROLE_PAPER.Text; //jhm0708
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_RP_WRITE_DATE = dtSTAFF_RP_WRITE_DATE_PQMS_STAFF_ROLE_PAPER.Text; //jhm0708

                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.Update(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("수정 완료!");

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
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.iIDX = Convert.ToInt32(txtIDX_PQMS_STAFF_ROLE_PAPER.Text);

                Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.Delete(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("삭제 완료!");

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

            try { 
                txtIDX_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("IDX").ToString();
                txtSTAFF_CODE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();
                txtSTAFF_RP_DATE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_DATE").ToString();
                txtSTAFF_RP_CLASS_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_CLASS").ToString();
                txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_ORG_CODE").ToString();
                txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_CODE").ToString();
                txtSTAFF_RP_APPROVER_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_APPROVER").ToString();
                txtSTAFF_RP_APPROVE_DATE_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_APPROVE_DATE").ToString();
                txtSTAFF_RP_SUPPORTER_PQMS_STAFF_ROLE_PAPER.Text = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("STAFF_RP_SUPPORTER").ToString();

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

                Form2PQMS_StaffInfo.sPQMS_STAFF_ROLE_PAPER_IDX = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("IDX").ToString();
                Form2_GridIdx.sIDX = PQMS_STAFF_ROLE_PAPERMainGridView.GetFocusedRowCellValue("IDX").ToString();

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
            Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE;

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
                childEduReport.WindowState = FormWindowState.Normal;
                childEduReport.ShowDialog();
            }
        }

        private void btnEduHistoryDaejang_Click(object sender, EventArgs e)
        {
            //CreateDoc_trainingHistory();

            //Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE;

            //if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
            //{
            //    MessageBox.Show("사원을 선택해주세요.");
            //    return;
            //}

            //string sFormName = "frmEduHistoryDaejang";
            //frmEduHistoryDaejang childEduHistoryDaejang = new frmEduHistoryDaejang();

            //if (unitCommon.YNFrom(sFormName))
            //{
            //    childEduHistoryDaejang.Dispose();     // 창 리소스 제거
            //}
            //else
            //{
            //    //childRepositoryInfo.MdiParent = this;
            //    //Form2PQMS_TabName.sTabName = "자료검색";
            //    childEduHistoryDaejang.WindowState = FormWindowState.Normal;
            //    childEduHistoryDaejang.ShowDialog();

            //    // 조직 선택이 되어 있을때만 활성화
            //    //if (!string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearchJaryoNodeName))
            //    //{
            //    //    btnLookUpData.Enabled = true;
            //    //}
            //}
        }

        private void btnStaff_ROLE_PAER_Click(object sender, EventArgs e)
        {
            Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE;

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
            Form2 form22 = new Form2();

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
            Form2 form22 = new Form2();

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
        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            Form2 form22 = new Form2();

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
        }

        private void tabPage8_Enter(object sender, EventArgs e)
        {
            Form2 form22 = new Form2();

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
        }

        private void pnlFrm2Right_Paint(object sender, PaintEventArgs e)
        {

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
                fd.Filter = "word files (*.docx)|*.docx|word files (*.doc)|*.doc"; //필터 설정
                //fd.FilterIndex = 2; //1번 선택시 txt , 2번 선택시 *.*

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
                fd.Filter = "word files (*.docx)|*.docx|word files (*.doc)|*.doc"; //필터 설정
                //fd.FilterIndex = 2; //1번 선택시 txt , 2번 선택시 *.*

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
                fd.Filter = "word files (*.docx)|*.docx|word files (*.doc)|*.doc"; //필터 설정
                //fd.FilterIndex = 2; //1번 선택시 txt , 2번 선택시 *.*

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
                childfrmPQMS_STAFF_PRE_JOB_INFO.WindowState = FormWindowState.Normal;
                childfrmPQMS_STAFF_PRE_JOB_INFO.ShowDialog();
            }

            Call_STAFF_Main_Info(Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE);
            Call_STAFF_Main_Pre_Info(Form2PQMS_STAFF_MainPreSTAFFSet.sSTAFF_CODE);
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
                   $" where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' AND REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' AND WS_CODE = '" + Form1PQMS_Repo.sWS + "' ";

            OleDbCommand cmd = new OleDbCommand(sql, Conn);

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

        private void cmbRolePaper_SelectedIndexChanged(object sender, EventArgs e) //jhm0708
        {
            txtSTAFF_RP_CODE_PQMS_STAFF_ROLE_PAPER.Text = cmbRolePaper.Text.Substring(0, 4);
            txtSTAFF_RP_NAME_PQMS_STAFF_ROLE_PAPER.Text = cmbRolePaper.Text.Substring(5, cmbRolePaper.Text.Length - 5);
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
                fd.Filter = "word files (*.docx)|*.docx|word files (*.doc)|*.doc"; //필터 설정
                //fd.FilterIndex = 2; //1번 선택시 txt , 2번 선택시 *.*

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
                    exportExcel(Form2PQMS_STAFF_TRAINING_InfoGrid);
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
                    Form2PQMS_STAFF_TRAINING_InfoGridView.ExportToXlsx(filePath4, xlsxOptions);
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
                Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_STAFF_ROLE_PAPER_MainGridSet.sSTAFF_CODE;
            }
            else if (Form2_Tab_Info_Now.sTabName == "개별업무목록")
            {
                Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_ROLE2_EACH_LIST_MainGridSet.sSTAFF_CODE;
            }
            else if (Form2_Tab_Info_Now.sTabName == "직무자료")
            {
                Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_STAFF_ROLESet.sSTAFF_CODE;
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

            string sFormName = "frmApproveRequest";
            //frmApproveRequest childEduReport = new frmApproveRequest();
            //frmApproveRequestVer2 childfrmApproveRequestVer2 = new frmApproveRequestVer2(this);

            //if (unitCommon.YNFrom(sFormName))
            //{
            //    childfrmApproveRequestVer2.Dispose();     // 창 리소스 제거
            //}
            //else
            //{
            //    childfrmApproveRequestVer2.WindowState = FormWindowState.Normal;
            //    childfrmApproveRequestVer2.ShowDialog();
            //}

           // Call_PQMS_STAFF_TRAINING();
        }

        private void btnApproveReqSelect_Click(object sender, EventArgs e)
        {
            //Form2PQMS_StaffInfo.sStaffCode = "0002";
            Form2PQMS_StaffInfo.sStaffCode = Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet.sSTAFF_CODE;

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

            //string sFormName = "frmApproveRequestCheck";
            string sFormName = "frmApproveRequestCheckVer2";
            frmApproveRequestCheckVer2 childfrmApproveRequestCheckVer2 = new frmApproveRequestCheckVer2();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrmApproveRequestCheckVer2.Dispose();     // 창 리소스 제거
            }
            else
            {
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
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbRPORGCODE);
        }

        private void cmbRPORGCODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSTAFF_RP_CLASS_PQMS_STAFF_ROLE_PAPER.Text = cmbRPORGCODE.Text.Substring(0, 4);
            txtSTAFF_RP_CLASS_PQMS_STAFF_ROLE_PAPER_NAME.Text = cmbRPORGCODE.Text.Substring(5, cmbRPORGCODE.Text.Length-5); ;
        }

        private void btnRPGroup1Code_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtSTAFF_RP_CLASS_PQMS_STAFF_ROLE_PAPER.Text, cmbRPGroup1Code);
        }

        private void cmbRPGroup1Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRPGroup1Code.Text = cmbRPGroup1Code.Text.Substring(0, 4);
            txtRPGroup1Name.Text = cmbRPGroup1Code.Text.Substring(5, cmbRPGroup1Code.Text.Length - 5);


            txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text = txtRPGroup1Code.Text + "-" + txtRPGroup2Code.Text;
            
            
        }

        private void btnRPGroup2Code_Click(object sender, EventArgs e)
        {
            get_folder_data5("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", txtSTAFF_RP_CLASS_PQMS_STAFF_ROLE_PAPER.Text, txtRPGroup1Code.Text,  cmbRPGroup2Code);
        }

        private void cmbRPGroup2Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRPGroup2Code.Text = cmbRPGroup2Code.Text.Substring(0, 4);
            txtRPGroup2Name.Text = cmbRPGroup2Code.Text.Substring(5, cmbRPGroup2Code.Text.Length - 5);
            
            txtSTAFF_RP_ORG_CODE_PQMS_STAFF_ROLE_PAPER.Text = txtRPGroup1Code.Text + "-" + txtRPGroup2Code.Text;
            
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

            if (cmb_Main_ORGCode.Text == "0002 식약처" || cmb_Main_ORGCode.Text == "0003 농산물품질관리원")
            {
                PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "법정실무";
            }
            else            
            {
                PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "운영실무";
            }

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

            if (cmb_Main_ORGCode.Text == "0002 식약처" || cmb_Main_ORGCode.Text == "0003 농산물품질관리원")
            {
                PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "법정실무";
            }
            else
            {
                PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "운영실무";
            }

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

            if (cmb_Main_ORGCode.Text == "0002 식약처" || cmb_Main_ORGCode.Text == "0003 농산물품질관리원")
            {
                PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "법정실무";
            }
            else
            {
                PQMS_STAFF_AllGridView.Bands["gridBand1"].Caption = "운영실무";
            }

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

        private void Form2PQMS_STAFF_TRAINING_InfoGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption.Equals("훈련결과증빙"))
            {
                string strFile = Form2PQMS_STAFF_TRAINING_InfoGridView.GetFocusedDataRow()["STAFF_TRAIN_RESULT_DIR_FILE"].ToString();
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
                            if(tmp2>0) // 교육예정일이 3개월 전이면 노란색 
                            {
                                e.Appearance.BackColor = Color.Yellow;
                            }
                        }
                    }
                }
            }
        }

        private void txtMainREMARK_EACH_LIST_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Staff_Role_StaffCode_Click(object sender, EventArgs e)
        {
            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
            {

                string sql = " Select staff_code from PQMS_STAFF where  account_no = '"+ Form2PQMS_LoginInfo.sAccountNo +"'";
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
            Call_PQMS_STAFF_ROLE_PAPER();
        }

        private void btnROLE2_EACH_LISTSearch_Click(object sender, EventArgs e)
        {
            CALL_PQMS_ROLE2_EACH();
        }

        private void CALL_PQMS_ROLE2_EACH()
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
                MessageBox.Show("개인별업무자료 - 현황조회 실패!" + f.Message.ToString());
            }
        }

        private void PQMS_STAFF_AllGrid_Click(object sender, EventArgs e)
        {

        }
    }
}