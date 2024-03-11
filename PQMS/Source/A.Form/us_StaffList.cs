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
    public partial class us_StaffList : UserControl
    {
        frmStaffInfoAll fm;
        private Form2DataSet Form2Set;
        private Form2PQMS_STAFF_STAFFDataSet Form2PQMS_STAFF_MainSTAFFSet;

        private OleDbConnection Conn;
        private UnitCommon unitCommon;



        public us_StaffList(frmStaffInfoAll frm)
        {
            InitializeComponent();
            Initialize();
            fm = frm;
            unitCommon = new UnitCommon();

        }
        private void Initialize()
        {
            Form2Set = new Form2DataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_STAFF_MainSTAFFSet = new Form2PQMS_STAFF_STAFFDataSet(AppRes.DB.Connect, null, null);


            cmb_Main_ORGCode.Items.Clear();
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmb_Main_ORGCode);


            if (FormRepositoryInfoPQMS_TreeName.sSearch_Org_Group_Code == null)
            {
                cmb_Main_ORGCode.SelectedIndex = 4;
            }

            cmbMain_StaffStatus.SelectedIndex = 0;
        }

        private void us_StaffList_Load(object sender, EventArgs e)
        {
            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER"))
            {
                Call_PQMS_Main_Staff_User_Ver2();
            }
            else
            {
                Call_PQMS_Main_Staff_Ver2();
            }

        }


        private void get_folder_data(string tTable, string tField1, string tField2, ComboBox tCmb)        //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
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

        private void get_folder_data2(string tTable, string tField1, string tField2, string tField3, string tField4, System.Windows.Forms.ComboBox tCmb)        //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + "  where " + tField3 + " = '" + tField4 + "'";
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


            if (cmb_Main_ORGCode.Text == "")
            {
                rdbValue = FormRepositoryInfoPQMS_TreeName.sSearch_Org_Group_Code.ToString().Substring(0, 4);
            }
            else
            {
                rdbValue = cmb_Main_ORGCode.Text.Substring(0, 4);
            }

            
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
                AppHelper.ResetGridDataSource(PQMS_STAFF_AllGrid);



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

            if (cmb_Main_ORGCode.Text == "")
            {
                rdbValue = FormRepositoryInfoPQMS_TreeName.sSearch_Org_Group_Code.ToString().Substring(0, 4);
            }
            else
            {
                rdbValue = cmb_Main_ORGCode.Text.Substring(0, 4);
            }

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
        private void cmb_Main_ORGCode_SelectedIndexChanged(object sender, EventArgs e)
        {         

            cmbMain_Group1Code.Text = "";
            cmbMain_Group1Code.Items.Clear();
            get_folder_data2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", cmb_Main_ORGCode.Text.Substring(0, 4), cmbMain_Group1Code);

            FormRepositoryInfoPQMS_TreeName.sSearch_Org_Group_Code = cmb_Main_ORGCode.Text;

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

        private void PQMS_STAFF_AllGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {   
            // 직원자료
            Form2PQMS_STAFF_MainSTAFFSet.sSTAFF_CODE = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();
            // 전직장정보
            Form2PQMS_StaffInfo.sStaffCode = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_CODE").ToString();
            // 사원 팀정보
            Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM = PQMS_STAFF_AllGridView.GetFocusedRowCellValue("STAFF_TEAM").ToString();

            us_StaffInfo us_staffinfo = new us_StaffInfo(fm);
            fm.tabPage2.Controls.Add(us_staffinfo);
            
            fm.tabControl1.SelectedTab = fm.tabPage2;
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
    }
}
