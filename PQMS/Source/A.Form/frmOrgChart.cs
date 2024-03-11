using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Xls;
using Spire.Xls.Core.Spreadsheet.Shapes;
using System.Data.OleDb;
using System.Globalization;
using PQMS.C.Unit;

namespace PQMS
{
    public partial class frmOrgChart : MetroFramework.Forms.MetroForm
    {

        private UnitCommon unitCommon;
        private OleDbConnection Conn;
        
        private int MAX_idx;
        public string equip_query = "";        
        public int j = 0;
        public int wRowNo = 0;
        public string wpwd;
        

        public frmOrgChart()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }
          

        private void save_item()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);             

            string query = "";

            query = "INSERT INTO PQMS_STAFF_ORG_CHART (ORG_CODE, ORG_NAME, GROUP1_CODE, GROUP1_NAME, STAFF_CODE, RESULT_CHART_FILE) VALUES ( ";
            query = query + "'" + txtOrgCode.Text.Trim() + "',";
            query = query + "N'" + txtOrgName.Text.Trim() + "',";
            query = query + "'" + txtGroup1Code.Text.Trim() + "',";
            query = query + "N'" + txtGroup1Name.Text.Trim() + "',";
            //query = query + "N'" + txtStaffName.Text.Trim() + "',";            
            query = query + "'',";
            query = query + "N'" + txtOrgChart.Text.Trim() + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery(); 
            Conn.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {           
            System.Diagnostics.Process.Start(txtOrgChart.Text);       
        }


        private void button3_Click(object sender, EventArgs e)
        {            
            frmPDFPreview frmPDFPreview3 = new frmPDFPreview(txtOrgChart.Text);
            frmPDFPreview3.Show();
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

        private void button6_Click(object sender, EventArgs e)
        {
           // Get_Data();
        }

        private DataTable Get_Date_ORG(string sORGCode)
        {

            DataTable dt = new DataTable();
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = query + "  select a.idx, a.STAFF_CODE, b.STAFF_NAME, replace(a.STAFF_ROLE_CODE+a.STAFF_ROLE_CLASS, '-','') as 'ROLE_GUBUN', a.STAFF_ROLE_NAME ";
            query = query + " from PQMS_STAFF_ROLE a ";
            query = query + " inner join PQMS_STAFF b on a.STAFF_CODE = b.STAFF_CODE ";
            query = query + " where a.STAFF_ROLE_ORG_CODE = '"+ sORGCode + "' ";
            query = query + " order by a.STAFF_ROLE_CLASS, a.STAFF_ROLE_CODE ";


            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                }
            }
            Conn.Close();
            return dt;
        }

        private DataTable Get_Data_Dept(string sDeptCode)
        {
            DataTable dt = new DataTable();

            Conn = new OleDbConnection(unitCommon.connect_string);          
            string query = "";
            if (sDeptCode == "00000") //부서전체
            {                
                query = query + " select  b.idx, b.STAFF_CODE, b.STAFF_NAME, a.FOLDER_CODE, c.FOLDER_NAME, a.BOARD_CODE, a.STAFF_TEAM_PART_MASTER ";
                query = query + " from  PQMS_STAFF_team_PART a  ";
                query = query + " inner join PQMS_STAFF b on a.STAFF_CODE = b.STAFF_CODE  ";
                query = query + " inner join K_WORKSPACE c on a.SITE_CODE = c.SITE_CODE and a.REPOSITORY_CODE = c.REPOSITORY_CODE and a.WS_CODE = c.WS_CODE and a.FOLDER_CODE = c.FOLDER_CODE  and isnull(c.Board_Code, '')=''  ";
                query = query + " where a.STAFF_TEAM_PART_MASTER='Y'   ";
                query = query + " order by a.FOLDER_CODE  ";
            }
            else
            {
                query = query + " select  b.idx, b.STAFF_CODE, a.STAFF_NAME, b.FOLDER_CODE, c.FOLDER_NAME, b.BOARD_CODE, c.BOARD_NAME, b.STAFF_TEAM_PART_MASTER " + "\n";
                query = query + " from PQMS_STAFF a " + "\n";
                query = query + "  inner join PQMS_STAFF_team_PART b on a.STAFF_CODE = b.staff_code " + "\n";
                query = query + "  left outer join K_WORKSPACE c on c.SITE_CODE = b.SITE_CODE " + "\n";
                query = query + "  and c.REPOSITORY_CODE = b.REPOSITORY_CODE " + "\n";
                query = query + "  and c.WS_CODE = b.WS_CODE " + "\n";
                query = query + "  and c.FOLDER_CODE = b.FOLDER_CODE " + "\n";
                query = query + "  and c.BOARD_CODE = b.BOARD_CODE " + "\n";
                query = query + " where " + "\n";                
                query = query + " a.STAFF_TEAM = '" + Form1PQMS_Repo.sSiteCode + "-" + Form1PQMS_Repo.sRepo + "-" + Form1PQMS_Repo.sWS + "-" + sDeptCode + "'";                
            }        

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
           
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);                                   
                }
            }                       
            Conn.Close();
            return dt;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmborg);
            cmbGroup1.Items.Clear();
            txtGroup1Code.Text = "";
            txtGroup1Name.Text = "";
        }

        private void get_folder_data(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;

            if (tTable == "PQMS_ORG")
            {
                query = query + " where ORG_CODE not in ('0003','0006','0007')";
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
                        tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                    }
                }
            }
            Conn.Close();
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOrgCode.Text = cmborg.Text.Substring(0, 4);
            txtOrgName.Text = cmborg.Text.Substring(5, cmborg.Text.Length - 5);
            txtOrgChart.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\OrgChart";

            txtGroup1Code.Text = "";
            txtGroup1Name.Text = "";
            cmbGroup1.Items.Clear();

            if (cmborg.Text.Substring(0, 4) == "0001")
            {
                txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\17025_조직도.xlsx";
            }
            else if (cmborg.Text.Substring(0, 4) == "0002")
            {
                txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\17020_조직도.xlsx";
            }
            else if (cmborg.Text.Substring(0, 4) == "0004")
            {
                txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\측정분석기관_조직도.xlsx";
            }
            else if (cmborg.Text.Substring(0, 4) == "0005")
            {
                txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\건축자제_조직도.xlsx";                
            }
        }

        private void frmRoleOrgChart_Load(object sender, EventArgs e)
        {
            dgvData.AllowUserToAddRows = false;

            //폼 로드시 부서가 디폴트 선택 
            rdo_Dept.Checked = true;
            panel1.Enabled = true;
            panel2.Enabled = false;
        }

        private void btnGroup1_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtOrgCode.Text, cmbGroup1);
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

        private void cmbGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGroup1Code.Text = cmbGroup1.Text.Substring(0, 4);
            txtGroup1Name.Text = cmbGroup1.Text.Substring(5, cmbGroup1.Text.Length - 5);

            if (cmborg.Text.Substring(0, 4) == "0002")
            {
                if (txtGroup1Code.Text != "" )
                {
                    txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_HN_식약처_중분류.xlsx";
                }
            }
            else if (cmborg.Text.Substring(0, 4) == "0003")
            {
                if (txtGroup1Code.Text != "0001")
                {
                    txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_HN_농산물품질관리원_안정성검사.xlsx";
                }
                if (txtGroup1Code.Text != "0002")
                {
                    txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_HN_농산물품질관리원_검정기관.xlsx";
                }
            }

        }

        private void btn_Chart_ApproveRequest_Click(object sender, EventArgs e)
        {
            //Form2PQMS_StaffInfo.sStaffCode = txtStaffCode.Text;
            Form2_Tab_Info_Now.sMenuName = "부서관리";
            Form2_Tab_Info_Now.sTabName = "조직도";

            Form2_GridIdx.sIDX = txtIDX.Text;

            //Form2PQMS_LoginInfo.sloginId

            //Form2PQMS_StaffInfo.sStaffCode = "0002";

            //선택된 임명장의 사번의 팀 정보 가져오기 


            Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM = "0001-0003-00001";// 의왕지점

            //if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
            //{
            //    MessageBox.Show("사원을 선택해주세요.");
            //    return;
            //}

            if (string.IsNullOrEmpty(Form2_GridIdx.sIDX) == true)
            {
                MessageBox.Show("표를 선택해주세요.");
                return;
            }

            string sFormName = "frmApproveRequest";
            frmApproveRequestVer2 childFrm = new frmApproveRequestVer2(null);

            if (unitCommon.YNFrom(sFormName))
            {
                childFrm.Dispose();     // 창 리소스 제거
            }
            else
            {
                childFrm.WindowState = FormWindowState.Normal;
                childFrm.ShowDialog();
            }
        }

        private void btn_Chart_ApproveReqSelect_Click(object sender, EventArgs e)
        {
            //Form2PQMS_StaffInfo.sStaffCode = txtStaffCode.Text;
            Form2_Tab_Info_Now.sMenuName = "부서관리";
            Form2_Tab_Info_Now.sTabName = "조직도";

            string sFormName = "frmApproveRequestCheck";
            frmApproveRequestCheckVer2 childFrm = new frmApproveRequestCheckVer2();

            if (unitCommon.YNFrom(sFormName))
            {
                childFrm.Dispose();     // 창 리소스 제거
            }
            else
            {
                childFrm.WindowState = FormWindowState.Normal;
                childFrm.ShowDialog();
            }
        }

        private void btn_Chart_Search_Click(object sender, EventArgs e)
        {
            string query = "";
            Conn = new OleDbConnection(unitCommon.connect_string);

            query = "select * ," +
                $" (CASE WHEN approveStatusCode IS NULL THEN '신청전' " +                                
                $" WHEN approveStatusCode = '0' THEN '승인대기' " +                                      
                $" WHEN approveStatusCode = '1' THEN '승인완료' " +                                      
                $" ELSE '반려' " +                                                                       
                $" END) AS 'approvedYN_Korea' " +                                                          
                "from PQMS_STAFF_ORG_CHART";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            DataTable dt = new DataTable();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    gridChartList.DataSource = dt;                    
                }
            }
        }

        private void PQMS_PreSTAFFMainGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtIDX.Text = gridChartListView.GetFocusedDataRow()["IDX"].ToString();
            txtOrgCode.Text = gridChartListView.GetFocusedDataRow()["ORG_CODE"].ToString();
            txtOrgName.Text = gridChartListView.GetFocusedDataRow()["ORG_NAME"].ToString();
            txtGroup1Code.Text = gridChartListView.GetFocusedDataRow()["GROUP1_CODE"].ToString();
            txtGroup1Name.Text = gridChartListView.GetFocusedDataRow()["GROUP1_NAME"].ToString();
            txtOrgChart.Text = gridChartListView.GetFocusedDataRow()["RESULT_CHART_FILE"].ToString();
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            string query = "";
            Conn = new OleDbConnection(unitCommon.connect_string);

            query = " select FOLDER_CODE, FOLDER_NAME from K_WORKSPACE ";
            query = query + "  where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "'";
            query = query + "  and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'";
            query = query + "  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            query = query + "  and isnull(BOARD_CODE, '' ) ='' and isnull(FOLDER_CODE, '' ) != ''  and FOLDER_NAME !='Inspectors Pool / TFS' ";
            query = query + "  order by  SITE_CODE, REPOSITORY_CODE, WS_CODE, FOLDER_CODE, BOARD_CODE, GROUP_CODE, SUBGROUP_CODE";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    cmbDept.Items.Clear();

                    cmbDept.Items.Add("00000 안양_전체");
                    while (reader.Read())
                    {
                        cmbDept.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                    }
                }
            }
            Conn.Close();
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDeptCode.Text = cmbDept.Text.Substring(0, 5);
            txtDeptName.Text = cmbDept.Text.Substring(6, cmbDept.Text.Length - 6);

            if (txtDeptCode.Text == "00000")//부서전체
            {
                txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_AY_전체.xlsx";
            }
            else
            {   
                txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_AY_부서.xlsx";                
            }
            txtOrgChart.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\OrgChart";
        }


        private void Create_Dept()
        {
            DataTable dt = new DataTable();
            Workbook workbook = new Workbook();
           
            if (txtDeptCode.Text == "00000") // 부서전체 
            {
                dt = Get_Data_Dept(txtDeptCode.Text);
                workbook.LoadFromFile(txtTemplate.Text);
                string sheetName = "Anyang";

                Worksheet worksheet = workbook.Worksheets[sheetName];
                SetNameAndTitle_ALL(workbook, worksheet, dt); //부서전체 

                for (int i = 1; i < cmbDept.Items.Count; i++) //각 부서별 시트 작업 
                {
                    string sDeptCode = cmbDept.Items[i].ToString().Substring(0, 5);
                    string sDeptName = cmbDept.Items[i].ToString().Substring(6, cmbDept.Items[i].ToString().Length - 6);

                    dt = Get_Data_Dept(sDeptCode);

                    //workbook.LoadFromFile(txtTemplate.Text);
                    sheetName = sDeptName.Replace("&", "").Replace("/", "").Replace("  ", " ");

                    worksheet = workbook.Worksheets[sheetName];
                    SetNameAndTitle(workbook, worksheet, dt); //부서별                
                }
            }
            else //특정부서만 
            {
                dt = Get_Data_Dept(txtDeptCode.Text);

                workbook.LoadFromFile(txtTemplate.Text);
                string sheetName = txtDeptName.Text.Replace("&", "").Replace("/", "").Replace("  ", " ");

                Worksheet worksheet = workbook.Worksheets[sheetName];
                SetNameAndTitle(workbook, worksheet, dt); //부서별                
                RemoveSheets(sheetName, workbook); // 나머지 시트 삭제                     
            }

            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
            string savrfilepath = txtOrgChart.Text + @"\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + sDateTime_yyyyMM;

            DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
            if (file_di.Exists == false)
            {
                Directory.CreateDirectory(savrfilepath);
            }
            string filePath = @savrfilepath + @"\" + @Path.GetFileNameWithoutExtension(txtTemplate.Text) + "_" + txtDeptName.Text.Replace("&", "").Replace("/", "").Replace("  ", " ") + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            workbook.SaveToFile(filePath);
            txtOrgChart.Text = filePath;
            Process.Start(filePath);           
        }

        private void Create_ORGCode()
        {
            DataTable dt = new DataTable();
            Workbook workbook = new Workbook();

            dt= Get_Date_ORG(txtOrgCode.Text);

            workbook.LoadFromFile(txtTemplate.Text);
            string sheetName = txtOrgName.Text.Replace("/", " ");

            Worksheet worksheet = workbook.Worksheets[sheetName];
            SetORGNameAndTitle(workbook, worksheet, dt); //기관별

            string sDateTime_yyyyMM = DateTime.Now.ToString("yyyyMM");
            string savrfilepath = txtOrgChart.Text + @"\" + Form1PQMS_Repo.sSiteCode_Name + @"\" + Form1PQMS_Repo.sRepo_Name + @"\" + Form1PQMS_Repo.sWS_Name + @"\" + sDateTime_yyyyMM;

            DirectoryInfo file_di = new DirectoryInfo(savrfilepath);
            if (file_di.Exists == false)
            {
                Directory.CreateDirectory(savrfilepath);
            }

            string filePath = @savrfilepath + @"\" + @Path.GetFileNameWithoutExtension(txtTemplate.Text) + "_" + txtDeptName.Text.Replace("&", "").Replace("/", "").Replace("  ", " ") + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            workbook.SaveToFile(filePath);
            txtOrgChart.Text = filePath;
            Process.Start(filePath);

        }

        private void SetORGNameAndTitle(Workbook workbook, Worksheet worksheet, DataTable team) //기관별
        {   
            List<DataTable> parts = team.AsEnumerable().GroupBy(r => r["ROLE_GUBUN"]).Select(g => g.CopyToDataTable()).ToList();

            foreach (DataTable part in parts)
            {                
                string cellNameForstaff = part.Rows[0]["ROLE_GUBUN"].ToString().Replace(" ", "").Replace("/", "").Replace("&", "");
                string staffNameList = "";
                foreach (DataRow dtr in part.Rows)
                {   
                    if (staffNameList != "")
                    { 
                        staffNameList += "\n";
                    }
                    staffNameList += dtr["STAFF_NAME"].ToString();
                }
                if (workbook.NameRanges.GetByName(cellNameForstaff) != null && staffNameList != "")
                {
                    CellRange cellForStaff = worksheet.Range[cellNameForstaff];
                    cellForStaff.Text = staffNameList;
                }
            }
        }



        private void btnOrgChartCreate_Click(object sender, EventArgs e)
        {
            txtOrgChart.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\OrgChart";

            if (rdo_Dept.Checked == true) //부서별
            {
                if (txtDeptCode.Text == "")
                {
                    MessageBox.Show("부서코드를 선택하세요.");
                    return;
                }
                else
                {
                    Create_Dept();
                }                
            }
            else if(rdo_ORG.Checked == true) //직무별
            {
                if (txtOrgCode.Text == "")
                {
                    MessageBox.Show("기관코드를 선택하세요.");
                    return;
                }
                else
                {
                    Create_ORGCode();
                }                
            }

            


        }

        private void RemoveSheets(string sheetName, Workbook workbook)
        {
            foreach (Worksheet worksheet in workbook.Worksheets.ToList())
            {
                if (worksheet.Name != sheetName)
                {
                    workbook.Worksheets.Remove(worksheet);
                }
            }
        }


        private void SetNameAndTitle_ALL(Workbook workbook, Worksheet worksheet, DataTable team) //부서전체
        {
            string teamManagerName = "";            
            List<DataTable> parts = team.AsEnumerable().GroupBy(r => r["FOLDER_NAME"]).Select(g => g.CopyToDataTable()).ToList();

            foreach (DataTable part in parts)
            {
                string cellNameForTM = part.Rows[0]["FOLDER_NAME"].ToString().Replace(" ", "").Replace("/", "").Replace("&", "") + "_Team_Master";
                string cellNameForPM = part.Rows[0]["FOLDER_NAME"].ToString().Replace(" ", "").Replace("/", "").Replace("&", "") + "_Part_Master";                
                string partManagerNameList = "";             
                
                foreach (DataRow dtr in part.Rows)
                {
                    if (dtr["BOARD_CODE"].ToString().Trim() == "" )  //팀장
                    {
                        teamManagerName = dtr["STAFF_NAME"].ToString();
                    }
                    else
                    {
                        if (dtr["STAFF_TEAM_PART_MASTER"].ToString() != "") //파트장
                        {
                            if (partManagerNameList != "")
                            { partManagerNameList += "\n"; }
                            partManagerNameList += dtr["STAFF_NAME"].ToString();
                        }
                    }
                }
                if (workbook.NameRanges.GetByName(cellNameForPM) != null && partManagerNameList != "")
                {
                    CellRange cellForPM = worksheet.Range[cellNameForPM];
                    cellForPM.Text = partManagerNameList;
                }

                if (workbook.NameRanges.GetByName(cellNameForTM) != null && teamManagerName != "")
                {
                    CellRange cellForTM = worksheet.Range[cellNameForTM];
                    cellForTM.Text = teamManagerName;
                }
            }           
        }

        private void SetNameAndTitle(Workbook workbook, Worksheet worksheet, DataTable team) //부서별
        {
            string teamManagerName = "";
            string cellNameForTM = team.AsEnumerable().Where(r=>r["FOLDER_NAME"].ToString()!="").First()["FOLDER_NAME"].ToString().Replace(" ", "").Replace("/", "").Replace("&","") + "_Manager_Name";
            List<DataTable> parts = team.AsEnumerable().GroupBy(r => r["BOARD_NAME"]).Select(g => g.CopyToDataTable()).ToList();


            foreach (DataTable part in parts)
            {
                string cellNameForPM = part.Rows[0]["BOARD_NAME"].ToString().Replace(" ", "").Replace("/", "").Replace("&", "") + "_PartMaster_Name";
                string cellNameForstaff = part.Rows[0]["BOARD_NAME"].ToString().Replace(" ", "").Replace("/", "").Replace("&", "") + "_Staff_Name";
                string partManagerNameList = "";
                string staffNameList = "";
                foreach (DataRow dtr in part.Rows)
                {
                    if (dtr["FOLDER_NAME"].ToString() == "" && dtr["BOARD_NAME"].ToString() == "")  //팀장
                    {
                        teamManagerName = dtr["STAFF_NAME"].ToString();
                    }
                    else
                    {
                        if (dtr["STAFF_TEAM_PART_MASTER"].ToString() != "") //파트장
                        {
                            if (partManagerNameList != "")
                            { partManagerNameList += "\n"; }
                            partManagerNameList += dtr["STAFF_NAME"].ToString();
                        }
                        else //스태프
                        {
                            if (staffNameList != "")
                            { staffNameList += "\n"; }
                            staffNameList += dtr["STAFF_NAME"].ToString();
                        }
                    }
                }
                if (workbook.NameRanges.GetByName(cellNameForPM) != null && partManagerNameList != "")
                {
                    CellRange cellForPM = worksheet.Range[cellNameForPM];
                    cellForPM.Text = partManagerNameList;
                }
                if (workbook.NameRanges.GetByName(cellNameForstaff) != null && staffNameList != "")
                {
                    CellRange cellForStaff = worksheet.Range[cellNameForstaff];
                    cellForStaff.Text = staffNameList;
                }
            }

            if (workbook.NameRanges.GetByName(cellNameForTM) != null && teamManagerName != "")
            {
                CellRange cellForTM = worksheet.Range[cellNameForTM];
                cellForTM.Text = teamManagerName;
            }
        }

        private void rdo_Dept_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel2.Enabled = false;
        }

        private void rdo_ORG_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel2.Enabled = true;
        }
    }
}
