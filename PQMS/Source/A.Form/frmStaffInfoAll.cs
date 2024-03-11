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
    public partial class frmStaffInfoAll : MetroFramework.Forms.MetroForm
    {
        

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

   
        public List<Form2PQMS_STAFF_EDUPageRow> PQMS_STAFF_EDUPageRow;
        public List<Form2PQMS_STAFF_MainPageRow> PQMS_STAFF_MainPageRows;
        public List<Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow> PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRows;
        public List<Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow> PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRows;

        private OleDbConnection Conn;
        private UnitCommon unitCommon;
        private frmRepositoryInfo FrmRepositoryInfo;

        public frmStaffInfoAll()
        {
            InitializeComponent();
            Initialize();
            unitCommon = new UnitCommon();
        }
        private void Initialize()
        {
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

           // MainPageBookmark = new GridBookmark(PQMS_STAFF_AllGridView);

            unitCommon = new UnitCommon();
            FrmRepositoryInfo = new frmRepositoryInfo();

            Form2PQMS_ROLE2_EACH_LIST_MainGridSet = new Form2PQMS_ROLE2_EACH_LIST_MainGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_ROLE2_EACH_LIST_InfoGridSet = new Form2PQMS_ROLE2_EACH_LIST_InfoGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_PQMS_STAFF_TRAINING_MainGridSet = new Form2PQMS_PQMS_STAFF_TRAINING_MainGridDataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_PQMS_STAFF_TRAINING_InfoGridSet = new Form2PQMS_PQMS_STAFF_TRAINING_InfoGridDataSet(AppRes.DB.Connect, null, null);


            //get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmb_Main_ORGCode);

            //cmb_Main_ORGCode.SelectedIndex = 4;

           // cmbMain_StaffStatus.SelectedIndex = 0;

        }
        private void frmStaffInfoAll_Load(object sender, EventArgs e)
        {
            try
            {
                Call_listStaff_ROLE();
                Call_list_PQMS_ORG();
                Get_Upload_Data(0);
                LoadTreeViewFromDB4(dgvOrg, trvItems);                
            }
            catch (Exception f)
            {
                MessageBox.Show("Load Form2 실패!" + Environment.NewLine + f.Message);
            }

            usControls_Load();
        }

        private void usControls_Load()
        {

            //us_StaffList us_stafflist = new us_StaffList(this);
            //tabPage1.Controls.Add(us_stafflist);

            us_StaffListAll us_stafflistall = new us_StaffListAll(this);
            tabPage1.Controls.Add(us_stafflistall);
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


        private void Call_listStaff_ROLE()
        {
            Form2PQMS_STAFF_ROLE_Form13Set.listSTAFF_ROLE = new Dictionary<string, string>();
            Form2PQMS_STAFF_ROLE_Form13Set.Select();

            for (int i = 0; i < Form2PQMS_STAFF_ROLE_Form13Set.GetRowCount(); i++)
            {
                Form2PQMS_STAFF_ROLE_Form13Set.Fetch(i);

                Form2PQMS_STAFF_ROLE_Form13Set.listSTAFF_ROLE.Add(i.ToString(), Form2PQMS_STAFF_ROLE_Form13Set.sROLE_CODE);
            }

            //cmbSTAFF_EDU_ORG_CODE.DataSource = new BindingSource(Form2PQMS_STAFF_ROLE_Form13Set.listSTAFF_ROLE, null);
           // cmbSTAFF_EDU_ORG_CODE.DisplayMember = "Value";
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

            //cmbSTAFF_EDU_ORG_CODE.DataSource = new BindingSource(Form2PQMS_ORG_Form5Set.listPQMS_ORG_CODE, null);
            //cmbSTAFF_EDU_ORG_CODE.DisplayMember = "Value";

            //cmbSTAFF_EDU_EXEC_ORG.DataSource = new BindingSource(Form2PQMS_ORG_Form5Set.listPQMS_ORG_NAME, null);
           // cmbSTAFF_EDU_EXEC_ORG.DisplayMember = "Value";
        }

        private void Get_Upload_Data(int k)
        {
            string query = "";
 
            if (k == 0)
            {
                query = " select * from K_WORKSPACE ";
                query = query + "  where 1= 1 ";
                query = query + "  and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "'";
                query = query + "  and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'";
                query = query + "  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
                query = query + "      order by  SITE_CODE, REPOSITORY_CODE, WS_CODE, FOLDER_CODE, BOARD_CODE, GROUP_CODE, SUBGROUP_CODE";

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

        private void trvItems_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName = e.Node.Name.Trim();

            //us_StaffList us_stafflist = new us_StaffList(this);
            //tabPage1.Controls.Add(us_stafflist);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //if (tabControl1.SelectedTab == tabPage1)
            //{
            //    us_StaffList us_stafflist = new us_StaffList(this);
            //    tabPage1.Controls.Add(us_stafflist);
            //}

            //if (tabControl1.SelectedTab == tabPage2)
            //{
            //    us_StaffInfo us_staffinfo = new us_StaffInfo(this);
            //    tabPage2.Controls.Add(us_staffinfo);
            //}
        }

    }


}
