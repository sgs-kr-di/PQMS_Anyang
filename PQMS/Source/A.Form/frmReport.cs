using System;
using System.Windows.Forms;
using System.Data.OleDb;
using PQMS.C.Unit;

namespace PQMS
{
    public partial class frmReport : MetroFramework.Forms.MetroForm
    {
      
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        public string equip_query = "";
        public int j = 0;
        public int wRowNo = 0;
        public string wpwd;

        public frmReport()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save_item();
        }
        
        private void save_item()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "INSERT INTO PQMS_REPORT VALUES ( ";
            query = query + "'" + Form1PQMS_Repo.sSiteCode +"', ";
            query = query + "'" + Form1PQMS_Repo.sRepo + "', ";
            query = query + "'" + Form1PQMS_Repo.sWS + "', ";
            query = query + "'" + txtReportNo.Text.Trim()  + "', ";
            query = query + "N'" + txtReportName.Text.Trim() + "', ";
            query = query + "N'" + txtReportFile.Text.Trim() + "', ";
            query = query + "N'" + txtResultFolder.Text.Trim() + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();

            MessageBox.Show(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modi_rtn();
        }

        private void Modi_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE PQMS_REPORT  SET ";
            query = query + " REPORT_NAME  = N'" + txtReportName.Text.Trim() + "',";
            query = query + " REPORT_FILE  = N'" + txtReportFile.Text.Trim() + "',";
            query = query + " RESULT_FOLDER  = N'" + txtResultFolder.Text.Trim() + "'";
            query = query + " WHERE REPORT_NO = '" + txtReportNo.Text.Trim() + "'";
            query = query + " and SITE_CODE= '" + Form1PQMS_Repo.sSiteCode + "' and	REPOSITORY_CODE='" + Form1PQMS_Repo.sRepo + "'  and 	WS_CODE='" + Form1PQMS_Repo.sWS + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dele_rtn();
        }

        private void dele_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "delete from PQMS_REPORT  ";
            query = query + " WHERE REPORT_NO = '" + txtReportNo.Text.Trim() + "'";
            query = query + " and SITE_CODE= '" + Form1PQMS_Repo.sSiteCode + "' and	REPOSITORY_CODE='" + Form1PQMS_Repo.sRepo + "'  and 	WS_CODE='" + Form1PQMS_Repo.sWS + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Get_Data("PQMS_REPORT","REPORT_NO");
        }

        private void Get_Data(string tTable, string tField)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            dgvData.Rows.Clear();

            string query = "";

            query = " select REPORT_NO,	REPORT_NAME,	REPORT_FILE,	RESULT_FOLDER from " + tTable;
            query = query + " where SITE_CODE= '"+ Form1PQMS_Repo.sSiteCode + "' and	REPOSITORY_CODE='" + Form1PQMS_Repo.sRepo + "'  and 	WS_CODE='" + Form1PQMS_Repo.sWS+ "'  ";
            query = query + "      order by " + tField ;

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
                                dgvData.Columns[i].Width = 200;
                            }
                            else
                            {
                                dgvData.Columns[i].Width = 500;
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
                dgvData.RowCount = wRowNo + 1 ;
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
                txtReportNo.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtReportName.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtReportFile.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                txtResultFolder.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
            }

        }
    }
}
