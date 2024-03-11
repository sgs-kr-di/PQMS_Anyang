using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Collections;

using System.Xml;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Xls;
using Word = Microsoft.Office.Interop.Word;
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
   
    public partial class frmRepository : MetroFramework.Forms.MetroForm
    {        
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        public string equip_query = "";        
        public int j = 0;
        public int wRowNo = 0;
        public string wpwd;
        
        public frmRepository()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            get_comb_data("K_SITE", "SITE_CODE");
        }

        private void get_comb_data(string tTable, string tField)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = " select * from " + tTable;
            query = query + "      order by " + tField;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    cmbSiteCode.Items.Clear();

                    while (reader.Read())
                    {
                        cmbSiteCode.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                    }
                }
            }

            Conn.Close();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Get_Data("K_REPOSITORY", "SITE_CODE" , "REPOSITORY_CODE");
        }

        private void Get_Data(string tTable, string tField1, string tField2)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            dgvData.Rows.Clear();

            string query = "";

            query = " select * from " + tTable;
            query = query + "  where 1= 1 ";
            if (txtSiteCode.Text.Trim()  != "")
            {
                query = query + "  and " + tField1 + " = '" + txtSiteCode.Text + "'";
            }
            query = query + "      order by " + tField1 + "," + tField2;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            dgvData.RowCount = 10;

            int i;
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

        private void button1_Click(object sender, EventArgs e)
        {
            save_item();
        }

        private void save_item()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "INSERT INTO K_REPOSITORY VALUES ( ";
            query = query + "'" + txtSiteCode.Text.Trim() + "',";
            query = query + "'" + txtRepoCode.Text.Trim() + "',";
            query = query + "N'" + txtRepoName.Text.Trim() + "',";
            query = query + "N'" + txtRepoClass.Text.Trim() + "')";
 
            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();

            MessageBox.Show(query);
        }
        private void Modi_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE K_REPOSITORY  SET ";
            query = query + " REPOSITORY_NAME  = N'" + txtRepoName.Text.Trim() + "',";
            query = query + " REPOSITORY_CLASS  = N'" + txtRepoClass.Text.Trim() + "'";
            query = query + " WHERE SITE_CODE = " + txtSiteCode.Text.Trim() + "";
            query = query + " AND REPOSITORY_CODE = " + txtRepoCode.Text.Trim() + "";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void dele_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "delete from K_REPOSITORY  ";
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

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();


        }

        private void clear_rtn()
        {
            cmbSiteCode.Text = "";
            txtRepoCode.Text = "";
            txtRepoName.Text = "";
            txtRepoClass.Text = "";
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Modi_rtn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dele_rtn();
            Get_Data("K_REPOSITORY", "SITE_CODE", "REPOSITORY_CODE");
            clear_rtn();
            MessageBox.Show("자료 삭제 완료");
        }


        private void cmbRepository_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSiteCode.Text = cmbSiteCode.Text.Substring(0, 4);
            txtSiteName.Text = cmbSiteCode.Text.Substring(5, 4);
        }

        private void get_cmb2_data(string tTable, string tField, string tValue, TextBox tObj)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = " select * from " + tTable;
            query = query + "  where " + tField + " = '" + tValue + "'";

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

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.RowIndex < wRowNo)
            {
                txtSiteCode.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtRepoCode.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtRepoName.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                txtRepoClass.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
            }

            get_cmb2_data("K_SITE", "SITE_CODE", txtSiteCode.Text, txtSiteName);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRepoClass.Text = comboBox2.Text;
        }

        private void cmbSiteCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSiteCode.Text = cmbSiteCode.Text.Substring(0, 4);
            txtSiteName.Text = cmbSiteCode.Text.Substring(5, 4);
        }
    }
}
