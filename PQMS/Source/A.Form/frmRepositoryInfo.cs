using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PQMS.C.Unit;

namespace PQMS
{
    public partial class frmRepositoryInfo : MetroFramework.Forms.MetroForm
    {   
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        public frmRepositoryInfo()
        {
            InitializeComponent();
            Initialize(); 
            unitCommon = new UnitCommon();
        }

        public void Initialize()
        {
           
        }

        private void Get_Data(string tTable)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            dgvData.Rows.Clear();

            string query = "";

            query = " select * from " + tTable;
            query = query + "  where 1= 1 ";
            //query = query + "  and SITE_CODE = '" + txtSiteCode.Text + "'";
            //query = query + "  and REPOSITORY_CODE = '" + txtSiteCode.Text + "'";
            //query = query + "  and WS_CODE = '" + txtWSCode.Text + "'";
            query = query + "  and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "'";
            query = query + "  and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'";
            query = query + "  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            query = query + "  and isnull(BOARD_CODE,'') ='' ";
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
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";
            //query = "select * ";
            //query = query + " from Organization";

            if (k == 0)
            {
                query = " select * from K_WORKSPACE ";
                query = query + "  where 1= 1 ";                
                query = query + "  and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "'";
                query = query + "  and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'";
                query = query + "  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
                query = query + "  and isnull(BOARD_CODE,'') ='' ";
                query = query + "      order by  SITE_CODE, REPOSITORY_CODE, WS_CODE, FOLDER_CODE, BOARD_CODE, GROUP_CODE, SUBGROUP_CODE";

            }

            if (k == 1)
            {
                //query = " select CODE_PK, P_CODE, CODE_SEQ, CODE_NO, CODE_NAME, CODE_LEVEL from GUIDE_DB06 ";
                //query = query + " where CODE_PK <> 0 ";
                //query = query + " order by CODE_SEQ ";
            }

            

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

        private void btnFindRepository_Click(object sender, EventArgs e)
        {
            Get_Data("K_WORKSPACE");
            Get_Upload_Data(0);
            LoadTreeViewFromDB4(dgvOrg, trvItems);
        }

        private void frmRepositoryInfo_Load(object sender, EventArgs e)
        {
            btnFindRepository.PerformClick();
        }

        private void trvItems_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (Form2PQMS_TabName.sTabName.Equals("자료검색"))
            {
                if (!string.IsNullOrEmpty(e.Node.Name.Trim()))
                {
                    FormRepositoryInfoPQMS_TreeName.sSearchJaryoNodeName = e.Node.Name.Trim();
                    this.Close();                    
                }
            }
            else if (Form2PQMS_TabName.sTabName.Equals("기본자료"))
            {
                if (!string.IsNullOrEmpty(e.Node.Name.Trim()))
                {
                    FormRepositoryInfoPQMS_TreeName.sSearchGibonNodeName = e.Node.Text.Trim();
                    this.Close();
                }
            }
        }
    }
}
