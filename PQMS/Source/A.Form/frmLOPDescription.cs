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
    public partial class frmLOPDescription : MetroFramework.Forms.MetroForm
    {
        public int wRowNo = 0;
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        public frmLOPDescription()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            save_item();
        }

        private void save_item()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "INSERT INTO PQMS_LOPDescription  ( SITE_CODE,	REPOSITORY_CODE,	WS_CODE,	Description1,	Description2 )VALUES  (  ";
            query = query + " '" + Form1PQMS_Repo.sSiteCode + "', ";
            query = query + " '" + Form1PQMS_Repo.sRepo + "', ";
            query = query + " '" + Form1PQMS_Repo.sWS + "', ";
            query = query + "'" + txtField1.Text.Trim() + "', '')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();

            MessageBox.Show("입력완료!");
            Get_Data("PQMS_LOPDescription", "IDX");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Modi_rtn();
        }

        private void Modi_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE PQMS_LOPDescription  SET ";
            query = query + " Description1  = '" + txtField1.Text.Trim() + "'";
            query = query + " WHERE IDX = '" + txtIDX.Text.Trim() + "'";
            query = query + " AND SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' AND REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  AND WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            
            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
            MessageBox.Show("수정완료");
            Get_Data("PQMS_LOPDescription", "IDX");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dele_rtn();
        }

        private void dele_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "delete from PQMS_LOPDescription  ";
            query = query + " WHERE IDX = '" + txtIDX.Text.Trim() + "'";
            query = query + " AND SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' AND REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  AND WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
            MessageBox.Show("삭제완료!");
            Get_Data("PQMS_LOPDescription", "IDX");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Get_Data("PQMS_LOPDescription", "IDX");
        }

        private void Get_Data(string tTable, string tField)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            dgvData.Rows.Clear();

            string query = "";

            query = " select IDX, Description1 from " + tTable;
            query = query + $" where  SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            query = query + "      order by " + tField;

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

                            //dgvData.Columns[i].Width = 100;
                            //dgvData.Columns[i].Visible = true;
                        }
                        else
                        {
                            if (i == 2)
                            {
                                dgvData.Columns[i].Width = 200;
                            }
                            else
                            {
                                dgvData.Columns[i].Width = 800;
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

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.RowIndex < wRowNo)
            {
                txtIDX.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtField1.Text= dgvData.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            }
        }
    }
}
