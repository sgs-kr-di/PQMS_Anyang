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
    public partial class us_StaffListAll : MetroFramework.Forms.MetroForm
    {
        frmStaffInfoAll fm;
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        private Form2PQMS_STAFF_ROLE_Form13_DataSet Form2PQMS_STAFF_ROLE_Form13Set;
        private Form2PQMS_ORG_Form5_DataSet Form2PQMS_ORG_Form5Set;

        public us_StaffListAll(frmStaffInfoAll frm)
        {
            InitializeComponent();
            Initialize();
            fm = frm;
            unitCommon = new UnitCommon();
        }

        private void Initialize()
        {
            Form2PQMS_STAFF_ROLE_Form13Set = new Form2PQMS_STAFF_ROLE_Form13_DataSet(AppRes.DB.Connect, null, null);
            Form2PQMS_ORG_Form5Set = new Form2PQMS_ORG_Form5_DataSet(AppRes.DB.Connect, null, null);

        }

        private void us_StaffListAll_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    Call_listStaff_ROLE();
            //    Call_list_PQMS_ORG();
            //    Get_Upload_Data(0);
            //    LoadTreeViewFromDB4(dgvOrg, trvItems);
            //}
            //catch (Exception f)
            //{
            //    MessageBox.Show("Load Form2 실패!" + Environment.NewLine + f.Message);
            //}           
        }

        private void LoadTreeViewFromDB4(DataGridView dgv, TreeView trv)
        {
            //trv.Nodes.Clear();

            //Dictionary<int, TreeNode> parents =
            //    new Dictionary<int, TreeNode>();

            //string nodekey = "";
            //string nodetext = "";

            //int level = 0;

            //foreach (DataGridViewRow row in dgv.Rows)
            //{
            //    if (row.Index < Convert.ToInt32(txtRowCnt.Text))
            //    {
            //        //nodekey = row.Index.ToString();
            //        nodekey = row.Cells[2].Value.ToString();
            //        nodekey = nodekey + row.Cells[4].Value.ToString();
            //        nodekey = nodekey + row.Cells[6].Value.ToString();
            //        nodekey = nodekey + row.Cells[8].Value.ToString();
            //        nodekey = nodekey + row.Cells[10].Value.ToString();

            //        //nodetext
            //        if (row.Cells[3].Value.ToString().Trim() != "") nodetext = row.Cells[3].Value.ToString();
            //        if (row.Cells[5].Value.ToString().Trim() != "") nodetext = row.Cells[5].Value.ToString();
            //        if (row.Cells[7].Value.ToString().Trim() != "") nodetext = row.Cells[7].Value.ToString();
            //        if (row.Cells[9].Value.ToString().Trim() != "") nodetext = row.Cells[9].Value.ToString();
            //        if (row.Cells[11].Value.ToString().Trim() != "") nodetext = row.Cells[11].Value.ToString();

            //        if (row.Cells[2].Value.ToString().Trim() != "") level = 0;
            //        if (row.Cells[4].Value.ToString().Trim() != "") level = 1;
            //        if (row.Cells[6].Value.ToString().Trim() != "") level = 2;
            //        if (row.Cells[8].Value.ToString().Trim() != "") level = 3;
            //        if (row.Cells[10].Value.ToString().Trim() != "") level = 4;

            //    }
            //    // See how many tabs are at the start of the line.
            //    if (row.Index == 0)
            //    {
            //        parents[level] = trv.Nodes.Add(nodekey, nodetext);
            //    }
            //    if (row.Index != 0 && row.Index < Convert.ToInt32(txtRowCnt.Text))
            //    {
            //        parents[level] = parents[level - 1].Nodes.Add(nodekey, nodetext);
            //        parents[level].EnsureVisible();
            //    }
            //}

            //if (trv.Nodes.Count > 0) trv.Nodes[0].EnsureVisible();
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
        }

        //private void Get_Upload_Data(int k)
        //{
        //    string query = "";

        //    if (k == 0)
        //    {
        //        query = " select * from K_WORKSPACE ";
        //        query = query + "  where 1= 1 ";
        //        query = query + "  and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "'";
        //        query = query + "  and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'";
        //        query = query + "  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
        //        query = query + "      order by  SITE_CODE, REPOSITORY_CODE, WS_CODE, FOLDER_CODE, BOARD_CODE, GROUP_CODE, SUBGROUP_CODE";

        //    }

        //    Conn = new OleDbConnection(unitCommon.connect_string);
        //    OleDbCommand cmd = new OleDbCommand(query, Conn);


        //    Conn.Open();

        //    dgvOrg.Rows.Clear();
        //    dgvOrg.RowCount = 1000;

        //    int wRowNo, i;
        //    wRowNo = 0;

        //    using (OleDbDataReader reader = cmd.ExecuteReader())
        //    {
        //        dgvOrg.ColumnCount = reader.FieldCount;

        //        for (i = 0; i < reader.FieldCount; i++)
        //        {
        //            dgvOrg.Columns[i].HeaderText = reader.GetName(i).ToString();
        //            dgvOrg.Columns[i].Width = 120;
        //        }

        //        while (reader.Read())
        //        {
        //            for (i = 0; i < reader.FieldCount; i++)
        //            {
        //                dgvOrg.Rows[wRowNo].Cells[i].Value = reader.GetValue(i);
        //            }

        //            wRowNo = wRowNo + 1;
        //            dgvOrg.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();

        //        }
        //    }
        //    if (wRowNo > 0)
        //    {
        //        dgvOrg.RowCount = wRowNo + 1;
        //    }
        //    else
        //    {
        //        dgvOrg.RowCount = 1;
        //    }

        //    Conn.Close();

        //    txtRowCnt.Text = Convert.ToString(dgvOrg.RowCount - 1);

        //}

    }
}
