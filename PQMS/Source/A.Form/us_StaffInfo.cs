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
using Spire.Doc.Fields;
using Spire.Xls;

namespace PQMS
{
    public partial class us_StaffInfo : UserControl
    {
        frmStaffInfoAll fm;
        private Form2DataSet Form2Set;
        private Form2PQMS_STAFF_PreSTAFFDataSet Form2PQMS_STAFF_MainPreSTAFFSet;
        private Form2PQMS_STAFF_STAFFDataSet Form2PQMS_STAFF_MainSTAFFSet;
        private Form2PQMS_STAFF_Workspace_DataSet Form2PQMS_STAFF_Workspace_Set;
        private UnitCommon unitCommon;

        public us_StaffInfo(frmStaffInfoAll frm)
        {
            InitializeComponent();
            fm = frm;
            Initialize();
        }

        private void Initialize()
        {
            Form2Set = new Form2DataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_MainSTAFFSet = new Form2PQMS_STAFF_STAFFDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_MainPreSTAFFSet = new Form2PQMS_STAFF_PreSTAFFDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_Workspace_Set = new Form2PQMS_STAFF_Workspace_DataSet(AppRes.DB.Connect, null, null);

            unitCommon = new UnitCommon();
        }

        private void us_StaffInfo_Load(object sender, EventArgs e)
        {
            if (Form2PQMS_StaffInfo.sStaffCode != "")
            {
                // 기본자료 조회 - '사번'이 Key
                Call_STAFF_Main_Info(Form2PQMS_StaffInfo.sStaffCode);

                // 기본자료 조회 - '사번'이 Key
                Call_STAFF_Main_Pre_Info(Form2PQMS_StaffInfo.sStaffCode);


                //조회 완료 후 
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
        }

        public void Call_STAFF_Main_Info(string sStaff_cdoe = "")
        {
            try
            {
                Form2PQMS_STAFF_MainSTAFFSet.SelectSTAFF_STAFF(sStaff_cdoe);

               
                if (Form2PQMS_STAFF_MainSTAFFSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_MainGrid, Form2PQMS_STAFF_MainSTAFFSet);
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

                if (Form2PQMS_STAFF_MainPreSTAFFSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_PreSTAFFMainGrid, Form2PQMS_STAFF_MainPreSTAFFSet);
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
                MessageBox.Show("EmpNo가 입력되지 않았습니다. 관리자에게 문의하세요.");
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

                Form2Set.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");
                Call_STAFF_Main_Info(Form2PQMS_StaffInfo.sStaffCode);

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
                Call_STAFF_Main_Info(Form2PQMS_StaffInfo.sStaffCode);
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
                Call_STAFF_Main_Info(Form2PQMS_StaffInfo.sStaffCode);
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
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

        private void PQMS_STAFFMainGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
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
    }
}
