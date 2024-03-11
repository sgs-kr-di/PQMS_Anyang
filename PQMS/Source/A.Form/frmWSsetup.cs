using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using System.Runtime.InteropServices;
using System.Collections;

using System.Xml;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Xls;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Globalization;

using System.Data.OleDb;

using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;


namespace PQMS
{
    public partial class frmWSsetup : MetroFramework.Forms.MetroForm
    {
        private UnitCommon unitCommon;
        private OleDbConnection Conn;

        public string equip_query = "";
        public string chgpart = "";
        public System.Windows.Forms.TextBox tobj;
        public int j = 0;
        public int wRowNo = 0;
        public string wpwd;
        
        public frmWSsetup()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            get_comb_data("K_SITE", "SITE_CODE", "SITE_NAME", "", "", cmbSiteCode);
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

        private void button8_Click(object sender, EventArgs e)
        {
            get_comb_data("K_REPOSITORY", "REPOSITORY_CODE", "REPOSITORY_NAME", "SITE_CODE", txtSiteCode.Text, cmbRepo);
        }

        private void cmbRepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRepoCode.Text = cmbRepo.Text.Substring(0, 4);
            txtRepoName.Text = cmbRepo.Text.Substring(5, cmbRepo.Text.Length - 5);
        }

        private void txtWPCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtWSName_TextChanged(object sender, EventArgs e)
        {
            chgpart = "";
            chgpart = "WS_NAME";
            tobj = txtWSName;
        }

        private void txtSubGroupCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubGroupName_TextChanged(object sender, EventArgs e)
        {
            chgpart = "";
            chgpart = "SUBGROUP_NAME";
            tobj = txtSubGroupName;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            get_ws_data("K_WORKSPACE", "WS_CODE", "WS_NAME", cmbWS);

            //get_ws_template(cmbWS, "Y");

        }

        private void get_ws_template(ComboBox tCmb, string tWSK)
        {
            //tField1 = 검색테이블
            //tField2 = 검색필드1
            //tField3 = 검색필드2



            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = "  select distinct a.WS_CODE, b.WS_NAME ";
            query = query + "  from K_WS_FIELD_VALUE a inner join K_WORKSPACE b  ";
            query = query + "   on(a.SITE_CODE = b.SITE_CODE  ";

            query = query + "      and a.REPOSITORY_CODE = b.REPOSITORY_CODE  ";

            query = query + "      and a.WS_CODE = b.WS_CODE)  ";
            query = query + "    inner join K_WS_FIELD c  ";
            query = query + "         on(a.SITE_CODE = c.SITE_CODE  ";

            query = query + "            and a.REPOSITORY_CODE = c.REPOSITORY_CODE  ";

            query = query + "             and a.WS_CODE = c.WS_CODE  ";

            query = query + "                and a.FIELD_ORDER1 = c.FIELD_ORDER1)  ";
            query = query + " where a.SITE_CODE  = '" + txtSiteCode.Text + "'";
            query = query + "   and a.REPOSITORY_CODE  = '" + txtRepoCode.Text + "'";
            query = query + "   and a.FIELD_ORDER1 = '001' ";
            query = query + "   and c.FIELD_NAME1 = 'IS_TEMPLATE' ";
            query = query + "   and a.FIELD_VALUE_NO = '001' ";
            query = query + "   and a.FIELD_VALUE = '" + tWSK + "' ";
            query = query + "   and a.FIELD_VALUE like '%' ";
            query = query + "      order by a.WS_CODE, b.WS_NAME ";

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


        private void get_ws_data(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE  = '" + txtSiteCode.Text + "'";
            query = query + "   and REPOSITORY_CODE  = '" + txtRepoCode.Text + "'";
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

        private void button10_Click(object sender, EventArgs e)
        {
            get_folder_data("K_WORKSPACE", "FOLDER_CODE", "FOLDER_NAME", cmbFolder);
        }

        private void get_folder_data(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE  = '" + txtSiteCode.Text + "'";
            query = query + "   and REPOSITORY_CODE  = '" + txtRepoCode.Text + "'";
            query = query + "   and WS_CODE  = '" + txtWSCode.Text + "'";
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

        private void button11_Click(object sender, EventArgs e)
        {
            get_board_data("K_WORKSPACE", "BOARD_CODE", "BOARD_NAME", cmbBoard);

        }

        private void get_board_data(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE  = '" + txtSiteCode.Text + "'";
            query = query + "   and REPOSITORY_CODE  = '" + txtRepoCode.Text + "'";
            query = query + "   and WS_CODE  = '" + txtWSCode.Text + "'";
            query = query + "   and FOLDER_CODE  = '" + txtFolderCode.Text + "'";
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

        private void button12_Click(object sender, EventArgs e)
        {
            get_group_data("K_WORKSPACE", "GROUP_CODE", "GROUP_NAME", cmbGroup);
        }

        private void get_group_data(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE  = '" + txtSiteCode.Text + "'";
            query = query + "   and REPOSITORY_CODE  = '" + txtRepoCode.Text + "'";
            query = query + "   and WS_CODE  = '" + txtWSCode.Text + "'";
            query = query + "   and FOLDER_CODE  = '" + txtFolderCode.Text + "'";
            query = query + "   and BOARD_CODE  = '" + txtBoardCode.Text + "'";
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

        private void button13_Click(object sender, EventArgs e)
        {
            get_subgroup_data("K_WORKSPACE", "SUBGROUP_CODE", "SUBGROUP_NAME", cmbSubGroup);
        }

        private void get_subgroup_data(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE  = '" + txtSiteCode.Text + "'";
            query = query + "   and REPOSITORY_CODE  = '" + txtRepoCode.Text + "'";
            query = query + "   and WS_CODE  = '" + txtWSCode.Text + "'";
            query = query + "   and FOLDER_CODE  = '" + txtFolderCode.Text + "'";
            query = query + "   and BOARD_CODE  = '" + txtBoardCode.Text + "'";
            query = query + "   and GROUP_CODE  = '" + txtGroupCode.Text + "'";
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

        private void cmbWS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWSCode.Text = cmbWS.Text.Substring(0, 5);
            txtWSName.Text = cmbWS.Text.Substring(6, cmbWS.Text.Length - 6);
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFolderCode.Text = cmbFolder.Text.Substring(0, 5);
            txtFolderName.Text = cmbFolder.Text.Substring(6, cmbFolder.Text.Length - 6);
        }

        private void cmbBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoardCode.Text = cmbBoard.Text.Substring(0, 5);
            txtBoardName.Text = cmbBoard.Text.Substring(6, cmbBoard.Text.Length - 6);
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGroupCode.Text = cmbGroup.Text.Substring(0, 5);
            txtGroupName.Text = cmbGroup.Text.Substring(6, cmbGroup.Text.Length - 6);
        }

        private void cmbSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSubGroupCode.Text = cmbSubGroup.Text.Substring(0, 5);
            txtSubGroupName.Text = cmbSubGroup.Text.Substring(6, cmbSubGroup.Text.Length - 6);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            save_item();
            if (txtWSCode.Text != "" && txtFolderCode.Text == "")
            {
                //save_field_istemplate();
                //save_field_value_istemplate();
            }
        }

        private void save_item()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "INSERT INTO K_WORKSPACE VALUES ( ";
            query = query + "'" + txtSiteCode.Text.Trim() + "',";
            query = query + "'" + txtRepoCode.Text.Trim() + "',";

            query = query + "'" + txtWSCode.Text.Trim() + "',";
            query = query + "N'" + txtWSName.Text.Trim() + "',";

            query = query + "'" + txtFolderCode.Text.Trim() + "',";
            query = query + "N'" + txtFolderName.Text.Trim() + "',";

            query = query + "'" + txtBoardCode.Text.Trim() + "',";
            query = query + "N'" + txtBoardName.Text.Trim() + "',";

            query = query + "'" + txtGroupCode.Text.Trim() + "',";
            query = query + "N'" + txtGroupName.Text.Trim() + "',";

            query = query + "'" + txtSubGroupCode.Text.Trim() + "',";
            query = query + "N'" + txtSubGroupName.Text.Trim() + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();

            MessageBox.Show(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modi_rtn(chgpart, tobj);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dele_rtn();
            //Get_Data("K_WORKSPACE");
            //clear_rtn();
            //MessageBox.Show("자료 삭제 완료");
        }

        private void Modi_rtn(string tField, System.Windows.Forms.TextBox obj)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE K_WORKSPACE  SET ";
            query = query + chgpart + " = N'" + obj.Text.Trim() + "'";

            query = query + " WHERE SITE_CODE = '" + txtSiteCode.Text.Trim() + "'";
            query = query + " AND REPOSITORY_CODE = '" + txtRepoCode.Text.Trim() + "'";

            if (chgpart == "WS_NAME")
            {
                query = query + "       and WS_CODE =  '" + txtWSCode.Text.Trim() + "'";
            }

            if (chgpart == "FOLDER_NAME")
            {
                query = query + "       and WS_CODE =  '" + txtWSCode.Text.Trim() + "'";
                query = query + "       and FOLDER_CODE =  '" + txtFolderCode.Text.Trim() + "'";
            }

            if (chgpart == "BOARD_NAME")
            {
                query = query + "       and WS_CODE =  '" + txtWSCode.Text.Trim() + "'";
                query = query + "       and FOLDER_CODE =  '" + txtFolderCode.Text.Trim() + "'";
                query = query + "       and BOARD_CODE =  '" + txtBoardCode.Text.Trim() + "'";
            }

            if (chgpart == "GROUP_NAME")
            {
                query = query + "       and WS_CODE =  '" + txtWSCode.Text.Trim() + "'";
                query = query + "       and FOLDER_CODE =  '" + txtFolderCode.Text.Trim() + "'";
                query = query + "       and BOARD_CODE =  '" + txtBoardCode.Text.Trim() + "'";
                query = query + "       and GROUP_CODE =  '" + txtGroupCode.Text.Trim() + "'";
            }

            if (chgpart == "SUBGROUP_NAME")
            {
                query = query + "       and WS_CODE =  '" + txtWSCode.Text.Trim() + "'";
                query = query + "       and FOLDER_CODE =  '" + txtFolderCode.Text.Trim() + "'";
                query = query + "       and BOARD_CODE =  '" + txtBoardCode.Text.Trim() + "'";
                query = query + "       and GROUP_CODE =  '" + txtGroupCode.Text.Trim() + "'";
                query = query + "       and SUBGROUP_CODE =  '" + txtSubGroupCode.Text.Trim() + "'";
            }

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void dele_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "delete from K_WORKSPACE  ";
            query = query + " WHERE 1=1";
            if (cmbSiteCode.Text != "")
            {
                query = query + "  and SITE_CODE = '" + txtSiteCode.Text.Trim().Substring(0, 4) + "'";
            }
            else
            {
                query = query + "  and SITE_CODE = ''";
            }
            query = query + " AND REPOSITORY_CODE = '" + txtRepoCode.Text.Trim() + "'";
            query = query + " AND WS_CODE = '" + txtWSCode.Text.Trim() + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();


        }

        private void clear_rtn()
        {
            //cmbSiteCode.Text = "";
            //cmbRepo.Text = "";
            cmbWS.Text = "";
            cmbFolder.Text = "";
            cmbBoard.Text = "";
            cmbGroup.Text = "";
            cmbSubGroup.Text = "";

            //txtSiteCode.Text = "";
            //txtRepoCode.Text = "";
            txtWSCode.Text = "";
            txtFolderCode.Text = "";
            txtBoardCode.Text = "";
            txtGroupCode.Text = "";
            txtSubGroupCode.Text = "";

            //txtSiteName.Text = "";
            //txtRepoName.Text = "";
            txtWSName.Text = "";
            txtFolderName.Text = "";
            txtBoardName.Text = "";
            txtGroupName.Text = "";
            txtSubGroupName.Text = "";

        }

        private void get_cmb2_data(string tTable, string tField, string tValue, System.Windows.Forms.TextBox tObj)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = " select distinct * from " + tTable;
            query = query + "  where SITE_CODE = '" + txtSiteCode.Text + "'";
            query = query + "    and " + tField + " = '" + tValue + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        tObj.Text = reader.GetValue(1).ToString();
                    }
                }
            }

            Conn.Close();
        }

        private void get_cmb3_data(string tTable, string tField, string tValue, System.Windows.Forms.TextBox tObj, string tField2, string tCond)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = " select distinct " + tField + "," + tField2 + " from " + tTable;
            query = query + tCond;
            query = query + "    and " + tField + " = '" + tValue + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        tObj.Text = reader.GetValue(1).ToString();
                    }
                }
            }

            Conn.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Get_Upload_Data(0);
            LoadTreeViewFromDB4(dgvOrg, trvItems);
        }

        private void Get_Upload_Data(int k)
        {
            string query = "";
            //query = "select * ";
            //query = query + " from Organization";

            if (k == 0)
            {
                query = " select * from K_WORKSPACE ";
                query = query + "  where 1= 1 ";
                query = query + "  and SITE_CODE = '" + txtSiteCode.Text + "'";
                query = query + "  and REPOSITORY_CODE = '" + txtRepoCode.Text + "'";
                query = query + "  and WS_CODE = '" + txtWSCode.Text + "'";
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
            string wCond = "";

            clear_rtn();

            txtNodeLevel.Text = e.Node.Level.ToString();
            txtNodeName.Text = e.Node.Name.ToString();
            txtNodeText.Text = e.Node.Text.ToString();

            //txtSiteCode.Text = "";
            //txtRepoCode.Text = "";
            if (txtNodeLevel.Text == "0")
            {
                txtWSCode.Text = txtNodeName.Text;
                txtWSName.Text = txtNodeText.Text;
            }

            if (txtNodeLevel.Text == "1")
            {
                txtWSCode.Text = txtNodeName.Text.Substring(0, 5);
                txtFolderCode.Text = txtNodeName.Text.Substring(5, 5);
                txtFolderName.Text = txtNodeText.Text;
            }

            if (txtNodeLevel.Text == "2")
            {
                txtWSCode.Text = txtNodeName.Text.Substring(0, 5);
                txtFolderCode.Text = txtNodeName.Text.Substring(5, 5);
                txtBoardCode.Text = txtNodeName.Text.Substring(10, 5);
                txtBoardName.Text = txtNodeText.Text;
            }

            if (txtNodeLevel.Text == "3")
            {
                txtWSCode.Text = txtNodeName.Text.Substring(0, 5);
                txtFolderCode.Text = txtNodeName.Text.Substring(5, 5);
                txtBoardCode.Text = txtNodeName.Text.Substring(10, 5);
                txtGroupCode.Text = txtNodeName.Text.Substring(15, 5);
                txtGroupName.Text = txtNodeText.Text;
            }

            if (txtNodeLevel.Text == "4")
            {
                txtWSCode.Text = txtNodeName.Text.Substring(0, 5);
                txtFolderCode.Text = txtNodeName.Text.Substring(5, 5);
                txtBoardCode.Text = txtNodeName.Text.Substring(10, 5);
                txtGroupCode.Text = txtNodeName.Text.Substring(15, 5);
                txtSubGroupCode.Text = txtNodeName.Text.Substring(20, 5);
                txtSubGroupName.Text = txtNodeText.Text;
            }

            if (txtWSCode.Text != "")
            {
                wCond = " where SITE_CODE = '" + txtSiteCode.Text + "'";
                wCond = wCond + " and REPOSITORY_CODE = '" + txtSiteCode.Text + "'";

                get_cmb3_data("K_WORKSPACE", "WS_CODE", txtWSCode.Text, txtWSName, "WS_NAME", wCond);
            }
            if (txtFolderCode.Text != "")
            {
                wCond = wCond + " and WS_CODE = '" + txtWSCode.Text + "'";
                get_cmb3_data("K_WORKSPACE", "FOLDER_CODE", txtFolderCode.Text, txtFolderName, "FOLDER_NAME", wCond);
            }

            if (txtBoardCode.Text != "")
            {
                wCond = wCond + " and FOLDER_CODE = '" + txtFolderCode.Text + "'";
                get_cmb3_data("K_WORKSPACE", "BOARD_CODE", txtBoardCode.Text, txtBoardName, "BOARD_NAME", wCond);
            }

            if (txtGroupCode.Text != "")
            {
                wCond = wCond + " and BOARD_CODE = '" + txtBoardCode.Text + "'";
                get_cmb3_data("K_WORKSPACE", "Group_CODE", txtGroupCode.Text, txtGroupName, "Group_NAME", wCond);
            }

            if (txtSubGroupCode.Text != "")
            {
                wCond = wCond + " and GROUP_CODE = '" + txtGroupCode.Text + "'";
                get_cmb3_data("K_WORKSPACE", "SUBGROUP_CODE", txtSubGroupCode.Text, txtSubGroupName, "SUBGROUP_NAME", wCond);
            }

            //clear_field_data();
            //Get_Field_Data("K_WS_FIELD");
            //Get_Field_Input("K_WS_FIELD");
            //Get_Field_Input_Name("K_WS_FIELD");
            //Get_Field_Input_Value("K_WS_FIELD_VALUE");
            //get_conf_temp_rtn();
            //docu_creation_job();
        }



        private void button19_Click(object sender, EventArgs e)
        {
            data_refresh_rtn();
        }


        private void data_refresh_rtn()
        {
            string wCond = "";
            if (txtNodeLevel.Text == "0")
            {
                txtWSCode.Text = txtNodeName.Text;
                txtWSName.Text = txtNodeText.Text;
            }

            if (txtNodeLevel.Text == "1")
            {
                txtWSCode.Text = txtNodeName.Text.Substring(0, 5);
                txtFolderCode.Text = txtNodeName.Text.Substring(5, 5);
                txtFolderName.Text = txtNodeText.Text;
            }

            if (txtNodeLevel.Text == "2")
            {
                txtWSCode.Text = txtNodeName.Text.Substring(0, 5);
                txtFolderCode.Text = txtNodeName.Text.Substring(5, 5);
                txtBoardCode.Text = txtNodeName.Text.Substring(10, 5);
                txtBoardName.Text = txtNodeText.Text;
            }

            if (txtNodeLevel.Text == "3")
            {
                txtWSCode.Text = txtNodeName.Text.Substring(0, 5);
                txtFolderCode.Text = txtNodeName.Text.Substring(5, 5);
                txtBoardCode.Text = txtNodeName.Text.Substring(10, 5);
                txtGroupCode.Text = txtNodeName.Text.Substring(15, 5);
                txtGroupName.Text = txtNodeText.Text;
            }

            if (txtNodeLevel.Text == "4")
            {
                txtWSCode.Text = txtNodeName.Text.Substring(0, 5);
                txtFolderCode.Text = txtNodeName.Text.Substring(5, 5);
                txtBoardCode.Text = txtNodeName.Text.Substring(10, 5);
                txtGroupCode.Text = txtNodeName.Text.Substring(15, 5);
                txtSubGroupCode.Text = txtNodeName.Text.Substring(20, 5);
                txtSubGroupName.Text = txtNodeText.Text;
            }

            if (txtWSCode.Text != "")
            {
                wCond = " where SITE_CODE = '" + txtSiteCode.Text + "'";
                wCond = wCond + " and REPOSITORY_CODE = '" + txtSiteCode.Text + "'";

                get_cmb3_data("K_WORKSPACE", "WS_CODE", txtWSCode.Text, txtWSName, "WS_NAME", wCond);
            }
            if (txtFolderCode.Text != "")
            {
                wCond = wCond + " and WS_CODE = '" + txtWSCode.Text + "'";
                get_cmb3_data("K_WORKSPACE", "FOLDER_CODE", txtFolderCode.Text, txtFolderName, "FOLDER_NAME", wCond);
            }

            if (txtBoardCode.Text != "")
            {
                wCond = wCond + " and FOLDER_CODE = '" + txtFolderCode.Text + "'";
                get_cmb3_data("K_WORKSPACE", "BOARD_CODE", txtBoardCode.Text, txtBoardName, "BOARD_NAME", wCond);
            }

            if (txtGroupCode.Text != "")
            {
                wCond = wCond + " and BOARD_CODE = '" + txtBoardCode.Text + "'";
                get_cmb3_data("K_WORKSPACE", "Group_CODE", txtGroupCode.Text, txtGroupName, "Group_NAME", wCond);
            }

            if (txtSubGroupCode.Text != "")
            {
                wCond = wCond + " and GROUP_CODE = '" + txtGroupCode.Text + "'";
                get_cmb3_data("K_WORKSPACE", "SUBGROUP_CODE", txtSubGroupCode.Text, txtSubGroupName, "SUBGROUP_NAME", wCond);
            }



        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            chgpart = "";
            chgpart = "GROUP_NAME";
            tobj = txtGroupName;
        }

        private void txtFolderName_TextChanged(object sender, EventArgs e)
        {
            chgpart = "";
            chgpart = "FOLDER_NAME";
            tobj = txtFolderName;
        }

        private void txtBoardName_TextChanged(object sender, EventArgs e)
        {
            chgpart = "";
            chgpart = "BOARD_NAME";
            tobj = txtBoardName;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            Node_Dele_rtn();
        }

        private void Node_Dele_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "DELETE FROM K_WORKSPACE ";
            query = query + " WHERE SITE_CODE = '" + txtSiteCode.Text.Trim() + "'";
            query = query + " AND REPOSITORY_CODE = '" + txtRepoCode.Text.Trim() + "'";
            query = query + "       and WS_CODE =  '" + txtWSCode.Text.Trim() + "'";
            query = query + "       and FOLDER_CODE =  '" + txtFolderCode.Text.Trim() + "'";
            query = query + "       and BOARD_CODE =  '" + txtBoardCode.Text.Trim() + "'";
            query = query + "       and GROUP_CODE =  '" + txtGroupCode.Text.Trim() + "'";
            query = query + "       and SUBGROUP_CODE =  '" + txtSubGroupCode.Text.Trim() + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

    }
}
