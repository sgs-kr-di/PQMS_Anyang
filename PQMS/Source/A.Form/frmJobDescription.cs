using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using PQMS.C.Unit;
using System.Data.SqlClient;
using Spire.Doc;
using System.IO;

namespace PQMS
{
    public partial class frmJobDescription : Form
    {
        private FormJobDesc_ROLE2_AllGridDataSet FormJobDesc_ROLE2_AllGridSet;
        private FormJobDesc_ROLE2_MainGridDataSet FormJobDesc_ROLE2_MainGridSet;
        private FormJobDesc_ROLE2_RNR_MainGridDataSet FormJobDesc_ROLE2_RNR_MainGridSet;
        private FormJobDesc_ROLE2_DOCU_MainGridDataSet FormJobDesc_ROLE2_DOCU_MainGridSet;
        private FormJobDesc_ROLE2_EACH_LIST_MainGridDataSet FormJobDesc_ROLE2_EACH_LIST_MainGridSet;

        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        private string select_sSITE_CODE="";

        public frmJobDescription()
        {
            InitializeComponent();
            Initialize();
            unitCommon = new UnitCommon();
        }

        private void Initialize()
        {
            FormJobDesc_ROLE2_AllGridSet = new FormJobDesc_ROLE2_AllGridDataSet(AppRes.DB.Connect, null, null);
            FormJobDesc_ROLE2_MainGridSet = new FormJobDesc_ROLE2_MainGridDataSet(AppRes.DB.Connect, null, null);
            FormJobDesc_ROLE2_RNR_MainGridSet = new FormJobDesc_ROLE2_RNR_MainGridDataSet(AppRes.DB.Connect, null, null);
            FormJobDesc_ROLE2_DOCU_MainGridSet = new FormJobDesc_ROLE2_DOCU_MainGridDataSet(AppRes.DB.Connect, null, null);
            FormJobDesc_ROLE2_EACH_LIST_MainGridSet = new FormJobDesc_ROLE2_EACH_LIST_MainGridDataSet(AppRes.DB.Connect, null, null);
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

        private void get_folder_data(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2

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

        private void get_folder_data3(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)
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

        private void pnlFrm2Right_Resize(object sender, EventArgs e)
        {
            PQMS_ROLE2_AllGrid.Size = new Size(pnlFrm2Right.Width - 30, pnlFrm2Right.Height - 110);
        }

        private void btnLookUpData_Click(object sender, EventArgs e)
        {
            try 
            {
                //FormJobDesc_ROLE2_AllGridSet.Select(Form1PQMS_Repo.sSiteCode, Form1PQMS_Repo.sRepo, Form1PQMS_Repo.sWS);
                if (string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearch_ROLE2_WS_CODE_NodeName) == false)
                {
                    FormJobDesc_ROLE2_AllGridSet.Select(Form1PQMS_Repo.sSiteCode, Form1PQMS_Repo.sRepo, FormRepositoryInfoPQMS_TreeName.sSearch_ROLE2_WS_CODE_NodeName);
                }
                else
                {
                    FormJobDesc_ROLE2_AllGridSet.Select(Form1PQMS_Repo.sSiteCode, Form1PQMS_Repo.sRepo, Form1PQMS_Repo.sWS);
                }

                if (FormJobDesc_ROLE2_AllGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_AllGrid, FormJobDesc_ROLE2_AllGridSet);
                    MessageBox.Show("조회 성공!");
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message.ToString());
            }
            
        }

        private void Update_Search()
        {
            
        }


        private void PQMS_ROLE2_AllGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            select_sSITE_CODE= PQMS_ROLE2_AllGridView.GetFocusedDataRow()["SITE_CODE"].ToString(); 

            FormJobDesc_ROLE2_MainGridSet.sSITE_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["SITE_CODE"].ToString();
            FormJobDesc_ROLE2_MainGridSet.sREPOSITORY_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["REPOSITORY_CODE"].ToString();
            FormJobDesc_ROLE2_MainGridSet.sWS_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["WS_CODE"].ToString();

            FormJobDesc_ROLE2_RNR_MainGridSet.sSITE_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["SITE_CODE"].ToString();
            FormJobDesc_ROLE2_RNR_MainGridSet.sREPOSITORY_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["REPOSITORY_CODE"].ToString();
            FormJobDesc_ROLE2_RNR_MainGridSet.sWS_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["WS_CODE"].ToString();

            FormJobDesc_ROLE2_DOCU_MainGridSet.sSITE_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["SITE_CODE"].ToString();
            FormJobDesc_ROLE2_DOCU_MainGridSet.sREPOSITORY_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["REPOSITORY_CODE"].ToString();
            FormJobDesc_ROLE2_DOCU_MainGridSet.sWS_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["WS_CODE"].ToString();


            FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sSITE_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["SITE_CODE"].ToString();
            FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sREPOSITORY_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["REPOSITORY_CODE"].ToString();
            FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sWS_CODE = PQMS_ROLE2_AllGridView.GetFocusedDataRow()["WS_CODE"].ToString();


            // 기본자료 조회 - 'SITE CODE'가 Key
            try
            {
                FormJobDesc_ROLE2_MainGridSet.Select();

                if (FormJobDesc_ROLE2_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_CODE_MainGrid, FormJobDesc_ROLE2_MainGridSet);                    
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message.ToString());
            }

            // 역할및책임 조회 - 'SITE CODE'가 Key
            try
            {
                FormJobDesc_ROLE2_RNR_MainGridSet.Select();

                if (FormJobDesc_ROLE2_RNR_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_RNRMainGrid, FormJobDesc_ROLE2_RNR_MainGridSet);
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message.ToString());
            }

            // 직무기술서 조회 - 'SITE CODE'가 Key
            try
            {
                FormJobDesc_ROLE2_DOCU_MainGridSet.Select();

                if (FormJobDesc_ROLE2_DOCU_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_DOCUMainGrid, FormJobDesc_ROLE2_DOCU_MainGridSet);
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message.ToString());
            }

            // 개별업무목록 조회 - 'SITE CODE'가 Key
            try
            {
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.Select();

                if (FormJobDesc_ROLE2_EACH_LIST_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_EACH_LISTMainGrid, FormJobDesc_ROLE2_EACH_LIST_MainGridSet);
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message.ToString());
            }

            //교육 Tab Page로 이동
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Get_Upload_Data(0);
            LoadTreeViewFromDB4(dgvOrg, trvItems);
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
            get_ws_data("K_WORKSPACE", "WS_CODE", "WS_NAME", cmbWS, txtSiteCode.Text, txtRepoCode.Text);
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

        private void trvItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtNodeLevel.Text = e.Node.Level.ToString();
            txtNodeName.Text = e.Node.Name.ToString();
            txtNodeText.Text = e.Node.Text.ToString();
        }

        private void trvItems_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // SITE CODE 추후에 사용할 예정 (트리에 추가되면)
            //FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName = e.Node.Name.Trim();

            //REPOSITORY_CODE
            //FormRepositoryInfoPQMS_TreeName.sSearch_ROLE2_REPOSITORY_CODE_NodeName = e.Node.Name.Trim().Substring(0,5);

            //WS_CODE
            FormRepositoryInfoPQMS_TreeName.sSearch_ROLE2_WS_CODE_NodeName = e.Node.Name.Trim().Substring(0,5);

            try
            {
                //FormJobDesc_ROLE2_AllGridSet.Select(Form1PQMS_Repo.sSiteCode, Form1PQMS_Repo.sRepo, Form1PQMS_Repo.sWS);
                if (string.IsNullOrEmpty(FormRepositoryInfoPQMS_TreeName.sSearch_ROLE2_WS_CODE_NodeName) == false)
                {
                    FormJobDesc_ROLE2_AllGridSet.Select(Form1PQMS_Repo.sSiteCode, Form1PQMS_Repo.sRepo, FormRepositoryInfoPQMS_TreeName.sSearch_ROLE2_WS_CODE_NodeName);
                }
                else
                {
                    FormJobDesc_ROLE2_AllGridSet.Select(Form1PQMS_Repo.sSiteCode, Form1PQMS_Repo.sRepo, Form1PQMS_Repo.sWS);
                }

                if (FormJobDesc_ROLE2_AllGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_AllGrid, FormJobDesc_ROLE2_AllGridSet);
                    //MessageBox.Show("조회 성공!");
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message.ToString());
            }
        }

        private void panel3_Resize(object sender, EventArgs e)
        {
            PQMS_ROLE2_CODE_MainGrid.Size = new Size(pnlFrmJobDescGibonRight.Width - 30, pnlFrmJobDescGibonRight.Height - 110);
        }

        private void PQMS_ROLE2_CODEMainGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtMainSITE_CODE.Text = PQMS_ROLE2_CODEMainGridView.GetFocusedRowCellValue("SITE_CODE").ToString();
            txtMainREPOSITORY_CODE.Text = PQMS_ROLE2_CODEMainGridView.GetFocusedRowCellValue("REPOSITORY_CODE").ToString();
            txtMainWS_CODE.Text = PQMS_ROLE2_CODEMainGridView.GetFocusedRowCellValue("WS_CODE").ToString();
            txtMainROLE_CODE.Text = PQMS_ROLE2_CODEMainGridView.GetFocusedRowCellValue("ROLE_CODE").ToString();
            txtMainROLE_DEPT_CODE.Text = PQMS_ROLE2_CODEMainGridView.GetFocusedRowCellValue("ROLE_DEPT_CODE").ToString();
            txtMainROLE_NAME.Text = PQMS_ROLE2_CODEMainGridView.GetFocusedRowCellValue("ROLE_NAME").ToString();
            txtMainROLE_VERSION.Text = PQMS_ROLE2_CODEMainGridView.GetFocusedRowCellValue("ROLE_VERSION").ToString();

            //역할및책임 Tab Page로 이동
            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }

        private void btnROLE2_CODEInsert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                FormJobDesc_ROLE2_MainGridSet.sSITE_CODE = txtMainSITE_CODE.Text;
                FormJobDesc_ROLE2_MainGridSet.sREPOSITORY_CODE = txtMainREPOSITORY_CODE.Text;
                FormJobDesc_ROLE2_MainGridSet.sWS_CODE = txtMainWS_CODE.Text;
                FormJobDesc_ROLE2_MainGridSet.sROLE_CODE = txtMainROLE_CODE.Text;
                FormJobDesc_ROLE2_MainGridSet.sROLE_DEPT_CODE = txtMainROLE_DEPT_CODE.Text;
                FormJobDesc_ROLE2_MainGridSet.sROLE_NAME = txtMainROLE_NAME.Text;
                FormJobDesc_ROLE2_MainGridSet.sROLE_VERSION = txtMainROLE_VERSION.Text;

                FormJobDesc_ROLE2_MainGridSet.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");
                FormJobDesc_ROLE2_MainGrid_Search();
            }
            catch (Exception f)
            {   
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패! " + Environment.NewLine + f.Message);
            }
        }

        private void panel3_Resize_1(object sender, EventArgs e)
        {
            PQMS_ROLE2_RNRMainGrid.Size = new Size(panel3.Width - 30, panel3.Height - 110);
        }

        private void btnROLE2_RNRInsert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                FormJobDesc_ROLE2_RNR_MainGridSet.sSITE_CODE = Form1PQMS_Repo.sSiteCode;
                FormJobDesc_ROLE2_RNR_MainGridSet.sREPOSITORY_CODE = Form1PQMS_Repo.sRepo;
                FormJobDesc_ROLE2_RNR_MainGridSet.sWS_CODE = Form1PQMS_Repo.sWS;
                FormJobDesc_ROLE2_RNR_MainGridSet.sROLE_CODE = txtMainROLE_CODE_RNR.Text;
                FormJobDesc_ROLE2_RNR_MainGridSet.sROLE_NO = txtMainROLE_NO_RNR.Text;
                FormJobDesc_ROLE2_RNR_MainGridSet.sROLE_CONTENTS = txtMainROLE_CONTENTS_RNR.Text;

                FormJobDesc_ROLE2_RNR_MainGridSet.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");
                FormJobDesc_ROLE2_RNR_MainGrid_Search();
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패! " + Environment.NewLine + f.Message);
            }
        }

        private void PQMS_ROLE2_RNRMainGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtMainROLE_CODE_RNR.Text = PQMS_ROLE2_RNRMainGridView.GetFocusedRowCellValue("ROLE_CODE").ToString();
            txtMainROLE_NO_RNR.Text = PQMS_ROLE2_RNRMainGridView.GetFocusedRowCellValue("ROLE_NO").ToString();
            txtMainROLE_CONTENTS_RNR.Text = PQMS_ROLE2_RNRMainGridView.GetFocusedRowCellValue("ROLE_CONTENTS").ToString();
        }

        private void btnROLE2_DOCUInsert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                FormJobDesc_ROLE2_DOCU_MainGridSet.sSITE_CODE = Form1PQMS_Repo.sSiteCode;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sREPOSITORY_CODE = Form1PQMS_Repo.sRepo;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sWS_CODE = Form1PQMS_Repo.sWS;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sROLE_CODE = txtMainROLE_CODE_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_NO = txtMainDOCU_NO_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CODE = txtMainDOCU_CODE_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CODENAME = txtMainDOCU_CODENAME_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS1 = txtMainDOCU_CONTNETS1_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS2 = txtMainDOCU_CONTNETS2_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS3 = txtMainDOCU_CONTNETS3_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS4 = txtMainDOCU_CONTNETS4_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS5 = txtMainDOCU_CONTNETS5_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS6 = txtMainDOCU_CONTNETS6_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS7 = txtMainDOCU_CONTNETS7_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS8 = txtMainDOCU_CONTNETS8_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS9 = txtMainDOCU_CONTNETS9_DOCU.Text;
                FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS10 = txtMainDOCU_CONTNETS10_DOCU.Text;

                FormJobDesc_ROLE2_DOCU_MainGridSet.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");
                FormJobDesc_ROLE2_DOCU_MainGrid_Search();
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패! " + Environment.NewLine + f.Message);
            }
        }

        private void PQMS_ROLE2_DOCUMainGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtMainROLE_CODE_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("ROLE_CODE").ToString();
            txtMainDOCU_NO_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_NO").ToString();
            txtMainDOCU_CODE_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CODE").ToString();
            txtMainDOCU_CODENAME_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CODENAME").ToString();
            txtMainDOCU_CONTNETS1_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CONTENTS1").ToString();
            txtMainDOCU_CONTNETS2_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CONTENTS2").ToString();
            txtMainDOCU_CONTNETS3_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CONTENTS3").ToString();
            txtMainDOCU_CONTNETS4_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CONTENTS4").ToString();
            txtMainDOCU_CONTNETS5_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CONTENTS5").ToString();
            txtMainDOCU_CONTNETS6_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CONTENTS6").ToString();
            txtMainDOCU_CONTNETS7_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CONTENTS7").ToString();
            txtMainDOCU_CONTNETS8_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CONTENTS8").ToString();
            txtMainDOCU_CONTNETS9_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CONTENTS9").ToString();
            txtMainDOCU_CONTNETS10_DOCU.Text = PQMS_ROLE2_DOCUMainGridView.GetFocusedRowCellValue("DOCU_CONTENTS10").ToString();
        }

        private void btnGroup1_EACH_LIST_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtSTAFF_ROLE_ORG_CODE_EACH_LIST.Text, cmbMainGroup1_EACH_LIST);
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

        private void cmbGroup1_EACH_LIST_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMainLIST_GROUP1_EACH_LIST.Text = cmbMainGroup1_EACH_LIST.Text.Substring(0, 4);
            txtBig_EACH_LIST.Text = cmbMainGroup1_EACH_LIST.Text.Substring(5, cmbMainGroup1_EACH_LIST.Text.Length - 5);
        }

        private void btnGroup2_EACH_LIST_Click(object sender, EventArgs e)
        {
            get_folder_data3("PQMS_GROUP2", "GROUP2_CODE", "GROUP2_NAME", cmbMainGroup2_EACH_LIST);
        }

        private void cmbGroup2_EACH_LIST_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMainLIST_GROUP2_EACH_LIST.Text = cmbMainGroup1_EACH_LIST.Text.Substring(0, 4);
            txtMid_EACH_LIST.Text = cmbMainGroup1_EACH_LIST.Text.Substring(5, cmbMainGroup1_EACH_LIST.Text.Length - 5);
        }

        private void btnSign_EACH_LIST_Click(object sender, EventArgs e)
        {
            txtMainLIST_CHKSIGN_EACH_LIST.Text = file_open();
        }

        private void btnOpenSign_EACH_LIST_Click(object sender, EventArgs e)
        {
            show_file(txtMainLIST_CHKSIGN_EACH_LIST.Text.Trim());
        }

        private void dtpOrder_ValueChanged(object sender, EventArgs e)
        {
            txtMainWORKDATE_EACH_LIST.Text = dtpOrder_EACH_LIST.Text;
        }

        private void dtpChkOrder_EACH_LIST_ValueChanged(object sender, EventArgs e)
        {
            txtChkOrder_EACH_LIST.Text = dtpChkOrder_EACH_LIST.Text;
        }

        private void btnROLE2_EACH_LISTInsert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sSITE_CODE = Form1PQMS_Repo.sSiteCode;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sREPOSITORY_CODE = Form1PQMS_Repo.sRepo;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sWS_CODE = Form1PQMS_Repo.sWS;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sROLE_CODE = txtMainROLE_CODE_EACH_LIST.Text;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_NO = txtMainLIST_NO_EACH_LIST.Text;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_WORKDATE = txtMainWORKDATE_EACH_LIST.Text;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP1 = txtMainLIST_GROUP1_EACH_LIST.Text;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP2 = txtMainLIST_GROUP2_EACH_LIST.Text;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_CONTENTS1 = txtMainLIST_CONTENTS1_EACH_LIST.Text;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_CHKDATE = txtChkOrder_EACH_LIST.Text;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_CHKSIGN = txtMainLIST_CHKSIGN_EACH_LIST.Text;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_TECHNICAL_MANAGER = txtMainTECHNICAL_MANAGER_EACH_LIST.Text;
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_REMARK = txtMainREMARK_EACH_LIST.Text;

                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");
                FormJobDesc_ROLE2_EACH_LIST_MainGrid_Search();
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패! " + Environment.NewLine + f.Message);
            }
        }

        private void PQMS_ROLE2_EACH_LISTMainGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
                        
            txtMainROLE_CODE_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("ROLE_CODE").ToString();
            txtMainLIST_NO_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_NO").ToString();
            txtMainWORKDATE_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_WORKDATE").ToString();
            txtMainLIST_GROUP1_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_GROUP1").ToString();
            txtMainLIST_GROUP2_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_GROUP2").ToString();
            txtMainLIST_CONTENTS1_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_CONTENTS1").ToString();
            txtChkOrder_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_CHKDATE").ToString();
            txtMainLIST_CHKSIGN_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_CHKSIGN").ToString();
            txtMainTECHNICAL_MANAGER_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_TECHNICAL_MANAGER").ToString();
            txtMainREMARK_EACH_LIST.Text = PQMS_ROLE2_EACH_LISTMainGridView.GetFocusedRowCellValue("LIST_REMARK").ToString();


            DateTime WORKDATE_EACH_LIST = DateTime.Parse(txtMainWORKDATE_EACH_LIST.Text);
            dtpOrder_EACH_LIST.Value = WORKDATE_EACH_LIST;
            DateTime ChkOrder_EACH_LIST = DateTime.Parse(txtChkOrder_EACH_LIST.Text);
            dtpChkOrder_EACH_LIST.Value = ChkOrder_EACH_LIST;

        }

        private void tabPage2_Resize(object sender, EventArgs e)
        {
            PQMS_ROLE2_DOCUMainGrid.Size = new Size(tabPage2.Width - 110, tabPage2.Height - 110);
        }

        private void frmJobDescription_Load(object sender, EventArgs e)
        {
            Get_Upload_Data(0);
            LoadTreeViewFromDB4(dgvOrg, trvItems);
        }

    

        private void btnROLE2_CODEUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("수정하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();

                try
                {
                    FormJobDesc_ROLE2_MainGridSet.sSITE_CODE = txtMainSITE_CODE.Text;
                    FormJobDesc_ROLE2_MainGridSet.sREPOSITORY_CODE = txtMainREPOSITORY_CODE.Text;
                    FormJobDesc_ROLE2_MainGridSet.sWS_CODE = txtMainWS_CODE.Text;
                    FormJobDesc_ROLE2_MainGridSet.sROLE_CODE = txtMainROLE_CODE.Text;
                    FormJobDesc_ROLE2_MainGridSet.sROLE_DEPT_CODE = txtMainROLE_DEPT_CODE.Text;
                    FormJobDesc_ROLE2_MainGridSet.sROLE_NAME = txtMainROLE_NAME.Text;
                    FormJobDesc_ROLE2_MainGridSet.sROLE_VERSION = txtMainROLE_VERSION.Text;

                    FormJobDesc_ROLE2_MainGridSet.Update(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("수정 완료!");
                    FormJobDesc_ROLE2_MainGrid_Search();
                }
                catch (Exception f)
                {
                    string test = f.ToString();
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("수정 실패!");
                }
            }

        }

        private void btnROLE2_CODEDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();

                try
                {
                    FormJobDesc_ROLE2_MainGridSet.sSITE_CODE = txtMainSITE_CODE.Text;
                    FormJobDesc_ROLE2_MainGridSet.sREPOSITORY_CODE = txtMainREPOSITORY_CODE.Text;
                    FormJobDesc_ROLE2_MainGridSet.sWS_CODE = txtMainWS_CODE.Text;
                    FormJobDesc_ROLE2_MainGridSet.sROLE_CODE = txtMainROLE_CODE.Text;
                    FormJobDesc_ROLE2_MainGridSet.sROLE_DEPT_CODE = txtMainROLE_DEPT_CODE.Text;
                    FormJobDesc_ROLE2_MainGridSet.sROLE_NAME = txtMainROLE_NAME.Text;
                    FormJobDesc_ROLE2_MainGridSet.sROLE_VERSION = txtMainROLE_VERSION.Text;

                    FormJobDesc_ROLE2_MainGridSet.Delete(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("삭제 완료!");
                    FormJobDesc_ROLE2_MainGrid_Search();
                }
                catch (Exception f)
                {
                    string test = f.ToString();
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("삭제 실패!");
                }
            }
            else
            {

            }
        }

        private void btnROLE2_RNRUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("수정하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();


                try
                {
                    FormJobDesc_ROLE2_RNR_MainGridSet.sSITE_CODE = Form1PQMS_Repo.sSiteCode;
                    FormJobDesc_ROLE2_RNR_MainGridSet.sREPOSITORY_CODE = Form1PQMS_Repo.sRepo;
                    FormJobDesc_ROLE2_RNR_MainGridSet.sWS_CODE = Form1PQMS_Repo.sWS;
                    FormJobDesc_ROLE2_RNR_MainGridSet.sROLE_CODE = txtMainROLE_CODE_RNR.Text;
                    FormJobDesc_ROLE2_RNR_MainGridSet.sROLE_NO = txtMainROLE_NO_RNR.Text;
                    FormJobDesc_ROLE2_RNR_MainGridSet.sROLE_CONTENTS = txtMainROLE_CONTENTS_RNR.Text;

                    FormJobDesc_ROLE2_RNR_MainGridSet.Update(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("수정 완료!");
                    FormJobDesc_ROLE2_RNR_MainGrid_Search();
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("수정 실패! " + Environment.NewLine + f.Message);
                }
            }
        }

        private void btnROLE2_RNRDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();

                try
                {
                    FormJobDesc_ROLE2_RNR_MainGridSet.sSITE_CODE = Form1PQMS_Repo.sSiteCode;
                    FormJobDesc_ROLE2_RNR_MainGridSet.sREPOSITORY_CODE = Form1PQMS_Repo.sRepo;
                    FormJobDesc_ROLE2_RNR_MainGridSet.sWS_CODE = Form1PQMS_Repo.sWS;
                    FormJobDesc_ROLE2_RNR_MainGridSet.sROLE_CODE = txtMainROLE_CODE_RNR.Text;
                    FormJobDesc_ROLE2_RNR_MainGridSet.sROLE_NO = txtMainROLE_NO_RNR.Text;
                    FormJobDesc_ROLE2_RNR_MainGridSet.sROLE_CONTENTS = txtMainROLE_CONTENTS_RNR.Text;

                    FormJobDesc_ROLE2_RNR_MainGridSet.Delete(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("삭제 완료!");
                    FormJobDesc_ROLE2_RNR_MainGrid_Search();
                }
                catch (Exception f)
                {
                    string test = f.ToString();
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("삭제 실패!");
                }
            }
            else
            {

            }
        }

        private void btnROLE2_DOCUUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("수정하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();

                try
                {
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sSITE_CODE = Form1PQMS_Repo.sSiteCode;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sREPOSITORY_CODE = Form1PQMS_Repo.sRepo;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sWS_CODE = Form1PQMS_Repo.sWS;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sROLE_CODE = txtMainROLE_CODE_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_NO = txtMainDOCU_NO_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CODE = txtMainDOCU_CODE_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CODENAME = txtMainDOCU_CODENAME_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS1 = txtMainDOCU_CONTNETS1_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS2 = txtMainDOCU_CONTNETS2_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS3 = txtMainDOCU_CONTNETS3_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS4 = txtMainDOCU_CONTNETS4_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS5 = txtMainDOCU_CONTNETS5_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS6 = txtMainDOCU_CONTNETS6_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS7 = txtMainDOCU_CONTNETS7_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS8 = txtMainDOCU_CONTNETS8_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS9 = txtMainDOCU_CONTNETS9_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS10 = txtMainDOCU_CONTNETS10_DOCU.Text;

                    FormJobDesc_ROLE2_DOCU_MainGridSet.Update(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("수정 완료!");
                    FormJobDesc_ROLE2_DOCU_MainGrid_Search();
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("수정 실패! " + Environment.NewLine + f.Message);
                }
            }
            else
            {

            }
        }

        private void btnROLE2_DOCUDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();

                try
                {
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sSITE_CODE = Form1PQMS_Repo.sSiteCode;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sREPOSITORY_CODE = Form1PQMS_Repo.sRepo;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sWS_CODE = Form1PQMS_Repo.sWS;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sROLE_CODE = txtMainROLE_CODE_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_NO = txtMainDOCU_NO_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CODE = txtMainDOCU_CODE_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CODENAME = txtMainDOCU_CODENAME_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS1 = txtMainDOCU_CONTNETS1_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS2 = txtMainDOCU_CONTNETS2_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS3 = txtMainDOCU_CONTNETS3_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS4 = txtMainDOCU_CONTNETS4_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS5 = txtMainDOCU_CONTNETS5_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS6 = txtMainDOCU_CONTNETS6_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS7 = txtMainDOCU_CONTNETS7_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS8 = txtMainDOCU_CONTNETS8_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS9 = txtMainDOCU_CONTNETS9_DOCU.Text;
                    FormJobDesc_ROLE2_DOCU_MainGridSet.sDOCU_CONTENTS10 = txtMainDOCU_CONTNETS10_DOCU.Text;

                    FormJobDesc_ROLE2_DOCU_MainGridSet.Delete(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("삭제 완료!");
                    FormJobDesc_ROLE2_DOCU_MainGrid_Search();
                }
                catch (Exception f)
                {
                    string test = f.ToString();
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("삭제 실패!");
                }
            }
            else
            {

            }
        }
        private void btnROLE2_EACH_LISTUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("수정하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                SqlTransaction trans = AppRes.DB.BeginTrans();

                try
                {
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sSITE_CODE = Form1PQMS_Repo.sSiteCode;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sREPOSITORY_CODE = Form1PQMS_Repo.sRepo;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sWS_CODE = Form1PQMS_Repo.sWS;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sROLE_CODE = txtMainROLE_CODE_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_NO = txtMainLIST_NO_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_WORKDATE = txtMainWORKDATE_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP1 = txtMainLIST_GROUP1_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP2 = txtMainLIST_GROUP2_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_CONTENTS1 = txtMainLIST_CONTENTS1_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_CHKDATE = txtChkOrder_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_CHKSIGN = txtMainLIST_CHKSIGN_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_TECHNICAL_MANAGER = txtMainTECHNICAL_MANAGER_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_REMARK = txtMainREMARK_EACH_LIST.Text;

                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.Update(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("수정 완료!");
                    FormJobDesc_ROLE2_EACH_LIST_MainGrid_Search();
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("수정 실패! " + Environment.NewLine + f.Message);
                }
            }
            else
            {
                
            }
        }
        private void btnROLE2_EACH_LISTDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                SqlTransaction trans = AppRes.DB.BeginTrans();

                try
                {
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sSITE_CODE = Form1PQMS_Repo.sSiteCode;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sREPOSITORY_CODE = Form1PQMS_Repo.sRepo;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sWS_CODE = Form1PQMS_Repo.sWS;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sROLE_CODE = txtMainROLE_CODE_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_NO = txtMainLIST_NO_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_WORKDATE = txtMainWORKDATE_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP1 = txtMainLIST_GROUP1_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_GROUP2 = txtMainLIST_GROUP2_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_CONTENTS1 = txtMainLIST_CONTENTS1_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_CHKDATE = txtChkOrder_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_CHKSIGN = txtMainLIST_CHKSIGN_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_TECHNICAL_MANAGER = txtMainTECHNICAL_MANAGER_EACH_LIST.Text;
                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sLIST_REMARK = txtMainREMARK_EACH_LIST.Text;

                    FormJobDesc_ROLE2_EACH_LIST_MainGridSet.Delete(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("삭제 완료!");
                    FormJobDesc_ROLE2_EACH_LIST_MainGrid_Search();
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("삭제 실패! " + Environment.NewLine + f.Message);
                }
            }
            else
            {

            }
        }


        private void FormJobDesc_ROLE2_MainGrid_Search()
        {
            FormJobDesc_ROLE2_MainGridSet.sSITE_CODE = select_sSITE_CODE;

            // 기본자료 조회 - 'SITE CODE'가 Key
            try
            {
                FormJobDesc_ROLE2_MainGridSet.Select();

                if (FormJobDesc_ROLE2_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_CODE_MainGrid, FormJobDesc_ROLE2_MainGridSet);
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message.ToString());
            }
        }

        private void FormJobDesc_ROLE2_RNR_MainGrid_Search()
        {
            FormJobDesc_ROLE2_RNR_MainGridSet.sSITE_CODE = select_sSITE_CODE;
            // 역할및책임 조회 - 'SITE CODE'가 Key
            try
            {
                FormJobDesc_ROLE2_RNR_MainGridSet.Select();

                if (FormJobDesc_ROLE2_RNR_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_RNRMainGrid, FormJobDesc_ROLE2_RNR_MainGridSet);
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message.ToString());
            }
        }

        private void FormJobDesc_ROLE2_DOCU_MainGrid_Search()
        {
            FormJobDesc_ROLE2_DOCU_MainGridSet.sSITE_CODE = select_sSITE_CODE;

            // 직무기술서 조회 - 'SITE CODE'가 Key
            try
            {
                FormJobDesc_ROLE2_DOCU_MainGridSet.Select();

                if (FormJobDesc_ROLE2_DOCU_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_DOCUMainGrid, FormJobDesc_ROLE2_DOCU_MainGridSet);
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message.ToString());
            }

        }

        private void FormJobDesc_ROLE2_EACH_LIST_MainGrid_Search()
        {
            FormJobDesc_ROLE2_EACH_LIST_MainGridSet.sSITE_CODE = select_sSITE_CODE;

            // 개별업무목록 조회 - 'SITE CODE'가 Key
            try
            {
                FormJobDesc_ROLE2_EACH_LIST_MainGridSet.Select();

                if (FormJobDesc_ROLE2_EACH_LIST_MainGridSet.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLE2_EACH_LISTMainGrid, FormJobDesc_ROLE2_EACH_LIST_MainGridSet);
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message.ToString());
            }

        }




    }
}