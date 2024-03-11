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
    public partial class frmPQMS_STAFFP_RP_ETC : MetroFramework.Forms.MetroForm
    {

        private OleDbConnection Conn;
        private UnitCommon unitCommon;
        public int wRowNo = 0;
        

        public frmPQMS_STAFFP_RP_ETC()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }

        private void frmPQMS_STAFFP_RP_ETC_Load(object sender, EventArgs e)
        {
            txtSTAFF_CODE.Text = Form2PQMS_StaffInfo.sStaffCode;
            Get_Data("PQMS_STAFF_RP_ADDITIONAL_RR", "STAFF_CODE", Form2PQMS_StaffInfo.sStaffCode);
        }
        private void Get_Data(string tTable, string tField, string tSTAFF_CODE)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            dgvData.Rows.Clear();

            string query = "";

            query = " select IDX, STAFF_CODE, RR_NAME,	RR_CONTENTS from " + tTable;
            //query = " select RR_NAME,	RR_CONTENTS from " + tTable;
            query = query + " where STAFF_CODE = '" + tSTAFF_CODE + "'";
            query = query + " order by " + tField;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            dgvData.RowCount = 10;

            int i;
            wRowNo = 0;

            DataTable dt = new DataTable();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    PQMS_STAFF_RP_ADDITIONAL_RR_Grid.DataSource = dt;
                }
            }
            
            Conn.Close();            

        }

        private void btnSelectRPETC_Click(object sender, EventArgs e)
        {
            Get_Data("PQMS_STAFF_RP_ADDITIONAL_RR", "STAFF_CODE", Form2PQMS_StaffInfo.sStaffCode);
        }

        private void btnInsertRPETC_Click(object sender, EventArgs e)
        {
            save_item();
            Get_Data("PQMS_STAFF_RP_ADDITIONAL_RR", "STAFF_CODE", Form2PQMS_StaffInfo.sStaffCode);
        }

        private void btnDeleteRPETC_Click(object sender, EventArgs e)
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
                    MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
                }
            }
            else
            {
            }

            Get_Data("PQMS_STAFF_RP_ADDITIONAL_RR", "STAFF_CODE", Form2PQMS_StaffInfo.sStaffCode);
        }

        private void dele_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "delete from PQMS_STAFF_RP_ADDITIONAL_RR  ";
            query = query + " WHERE STAFF_CODE = '" + txtSTAFF_CODE.Text.Trim() + "'" + " AND IDX = '" + txtIDX.Text.Trim() + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void update_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";
            query = "update PQMS_STAFF_RP_ADDITIONAL_RR  set ";
            query = query + " RR_NAME = '"+txtSTAFF_PR_ETC_NAME.Text+"', RR_CONTENTS = '"+txtSTAFF_PR_ETC_CONTENT.Text+ "'";
            query = query + " WHERE STAFF_CODE = '" + txtSTAFF_CODE.Text.Trim() + "'" + " AND IDX = '" + txtIDX.Text.Trim() + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void save_item()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "INSERT INTO PQMS_STAFF_RP_ADDITIONAL_RR VALUES ( ";
            query = query + "'" + txtSTAFF_CODE.Text.Trim() + "', '0001','0003','0001','',";
            query = query + "'" + txtSTAFF_PR_ETC_NAME.Text.Trim() + "',";
            query = query + "'" + txtSTAFF_PR_ETC_CONTENT.Text.Trim() + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }
        private void dgvData_Resize(object sender, EventArgs e)
        {
            dgvData.Size = new Size(panel3.Width - 30, panel3.Height - 110);
        }
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.RowIndex < wRowNo)
            {
                txtIDX.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtSTAFF_CODE.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtSTAFF_PR_ETC_NAME.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                txtSTAFF_PR_ETC_CONTENT.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                //txtSTAFF_PRE_WORK_DATE.Text = dgvData.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
            }
        }

        private void btnUpdateRPETC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("수정하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    update_rtn();
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("수정 실패!" + Environment.NewLine + f.Message);
                }
            }
            else
            {
            }

            Get_Data("PQMS_STAFF_RP_ADDITIONAL_RR", "STAFF_CODE", Form2PQMS_StaffInfo.sStaffCode);
        }

        private void txtSTAFF_PR_ETC_NAME_Click(object sender, EventArgs e)
        {
            txtSTAFF_PR_ETC_NAME.ForeColor = System.Drawing.SystemColors.WindowText;

            if (txtSTAFF_PR_ETC_NAME.Text == "건축자재 오염물질 방출 시험")
            {
                txtSTAFF_PR_ETC_NAME.Text = "";
            }
        }

        private void txtSTAFF_PR_ETC_CONTENT_Click(object sender, EventArgs e)
        {
            txtSTAFF_PR_ETC_CONTENT.ForeColor = System.Drawing.SystemColors.WindowText;

            if (txtSTAFF_PR_ETC_CONTENT.Text == "폼알데하이드 분석 / 대기환경기사")
            {
                txtSTAFF_PR_ETC_CONTENT.Text = "";
            }
        }

        private void PQMS_STAFF_RP_ADDITIONAL_RR_GridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;


            txtSTAFF_PR_ETC_NAME.ForeColor = System.Drawing.SystemColors.WindowText;
            txtSTAFF_PR_ETC_CONTENT.ForeColor = System.Drawing.SystemColors.WindowText;


            txtIDX.Text = PQMS_STAFF_RP_ADDITIONAL_RR_GridView.GetFocusedRowCellValue("IDX").ToString().Trim();
            txtSTAFF_CODE.Text = PQMS_STAFF_RP_ADDITIONAL_RR_GridView.GetFocusedRowCellValue("STAFF_CODE").ToString().Trim();
            txtSTAFF_PR_ETC_NAME.Text = PQMS_STAFF_RP_ADDITIONAL_RR_GridView.GetFocusedRowCellValue("RR_NAME").ToString().Trim();
            txtSTAFF_PR_ETC_CONTENT.Text = PQMS_STAFF_RP_ADDITIONAL_RR_GridView.GetFocusedRowCellValue("RR_CONTENTS").ToString().Trim();
        }
    }
}
