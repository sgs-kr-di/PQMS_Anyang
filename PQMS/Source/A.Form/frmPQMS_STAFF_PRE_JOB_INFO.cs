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
    public partial class frmPQMS_STAFF_PRE_JOB_INFO : MetroFramework.Forms.MetroForm
    {
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        public int wRowNo = 0;
                
        public frmPQMS_STAFF_PRE_JOB_INFO()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }        

        private void Get_Data(string tTable, string tField, string tSTAFF_CODE)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            dgvData.Rows.Clear();

            string query = "";

            query = " select * from " + tTable;
            query = query + " where STAFF_CODE = '" + tSTAFF_CODE + "'";
            query = query + " order by " + tField;

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
                                dgvData.Columns[i].Width = 100;
                            }
                            else if (i == 5)
                            {
                                dgvData.Columns[i].Width = 150;
                            }
                            else
                            {
                                dgvData.Columns[i].Width = 100;
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
                dgvData.ColumnCount = 7;
            }

            Conn.Close();
            dgvData.Columns[1].HeaderText = "순번";
            dgvData.Columns[2].HeaderText = "사번";
            dgvData.Columns[3].HeaderText = "기관명";
            dgvData.Columns[4].HeaderText = "근무부서";
            dgvData.Columns[5].HeaderText = "근무기간";
            dgvData.Columns[6].HeaderText = "비고";

        }

        private void save_item()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "INSERT INTO PQMS_STAFF_PRE_JOB_INFO  ( STAFF_CODE, STAFF_PRE_REPOSITORY_NAME, STAFF_PRE_WS_NAME, STAFF_PRE_WORK_DATE, STAFF_PRE_WORK_REMARK ) VALUES (";
            query = query + "'" + txtSTAFF_CODE.Text.Trim() + "',";
            query = query + "'" + txtSTAFF_PRE_REPOSITORY_NAME.Text.Trim() + "',";
            query = query + "'" + txtSTAFF_PRE_WS_NAME.Text.Trim() + "',";
            query = query + "'" + txtSTAFF_PRE_WORK_DATE.Text.Trim() + "',";
            query = query + "'" + txtSTAFF_PRE_WORK_REMARK.Text.Trim() + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void dele_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "delete from PQMS_STAFF_PRE_JOB_INFO  ";
            query = query + " WHERE STAFF_CODE = '" + txtSTAFF_CODE.Text.Trim() + "'" + " AND IDX = '" + txtIDX.Text.Trim() + "'" ;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.RowIndex < wRowNo)
            {
                txtIDX.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtSTAFF_CODE.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtSTAFF_PRE_REPOSITORY_NAME.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                txtSTAFF_PRE_WS_NAME.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                txtSTAFF_PRE_WORK_DATE.Text = dgvData.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
            }
        }

        private void btnSelectPreInfo_Click(object sender, EventArgs e)
        {
            Get_Data("PQMS_STAFF_PRE_JOB_INFO", "STAFF_CODE", Form2PQMS_StaffInfo.sStaffCode);
        }        

        private void btnInsertPreJobInfo_Click(object sender, EventArgs e)
        {
            save_item();
            Get_Data("PQMS_STAFF_PRE_JOB_INFO", "STAFF_CODE", Form2PQMS_StaffInfo.sStaffCode);
        }

        private void btnDeletePreJobInfo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dele_rtn();                    
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("삭제 실패!"+ Environment.NewLine + f.Message);
                }
            }
            else
            {

            }

            Get_Data("PQMS_STAFF_PRE_JOB_INFO", "STAFF_CODE", Form2PQMS_StaffInfo.sStaffCode);
        }

        private void dgvData_Resize(object sender, EventArgs e)
        {
            dgvData.Size = new Size(panel3.Width - 30, panel3.Height - 110);
        }

        private void frmPQMS_STAFF_PRE_JOB_INFO_Load(object sender, EventArgs e)
        {

            txtSTAFF_CODE.Text = Form2PQMS_StaffInfo.sStaffCode;

            btnSelectPreInfo.PerformClick();
        }
    }
}