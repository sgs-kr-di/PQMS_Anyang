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
    public partial class frmPQMS_STAFF_Dept_Part : MetroFramework.Forms.MetroForm
    {
        private OleDbConnection Conn;
        private UnitCommon unitCommon;
        public int wRowNo = 0;

        private string sFolderCode = "";
                        
        public frmPQMS_STAFF_Dept_Part()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }        

        private void save_item()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";
            string masterYN = "";

            if (rdo_PartMaster_Y.Checked == true)
            {
                masterYN = "Y";
            }
            else
            {
                masterYN = "";
            }

            query = "INSERT INTO PQMS_STAFF_TEAM_PART  ( SITE_CODE,	REPOSITORY_CODE, WS_CODE, STAFF_CODE, FOLDER_CODE, BOARD_CODE, GROUP_CODE, SUBGROUP_CODE, STAFF_TEAM_PART_MASTER ) VALUES (";
            query = query + "'" + Form1PQMS_Repo.sSiteCode + "',";
            query = query + "'" + Form1PQMS_Repo.sRepo + "',";
            query = query + "'" + Form1PQMS_Repo.sWS + "',";
            query = query + "'" + txtSTAFF_CODE.Text + "',";
            query = query + "'" + sFolderCode + "',";
            query = query + "'" + txt_DEPTPARTCODE.Text + "',";
            query = query + "'',"; //GroupCode
            query = query + "'',"; //SubGroupCode
            query = query + "'" + masterYN + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();
        }

        private void dele_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "delete from PQMS_STAFF_TEAM_PART  ";
            query = query + " WHERE STAFF_CODE = '" + txtSTAFF_CODE.Text.Trim() + "'" + " AND IDX = '" + txtIDX.Text.Trim() + "'" ;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();
        }

      

        private void btnSelectPreInfo_Click(object sender, EventArgs e)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            query = "   select b.IDX, b.STAFF_CODE, a.STAFF_NAME, b.FOLDER_CODE, c.FOLDER_NAME, b.BOARD_CODE, c.BOARD_NAME, b.STAFF_TEAM_PART_MASTER ";
            query = query + " from PQMS_STAFF a ";
            query = query + " inner join PQMS_STAFF_team_PART b on a.STAFF_CODE = b.staff_code ";
            query = query + " left outer join K_WORKSPACE c on c.SITE_CODE = b.SITE_CODE ";
            query = query + " and c.REPOSITORY_CODE = b.REPOSITORY_CODE  and c.WS_CODE = b.WS_CODE  and c.FOLDER_CODE = b.FOLDER_CODE  and c.BOARD_CODE = b.BOARD_CODE ";
            query = query + " where a.STAFF_CODE = '" + txtSTAFF_CODE.Text + "'";
            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            DataTable dt = new DataTable();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    PQMS_STAFF_DeptPart.DataSource = dt;
                }
            }
            Conn.Close();
        }        

        private void btnInsertPreJobInfo_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("저장하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (rdo_PartMaster_Y.Checked == false && rdo_PartMaster_N.Checked == false)
                {
                    MessageBox.Show("팀장/파트장 여부를 선택하세요.");
                    return;
                }
                try
                {
                    save_item();
                    MessageBox.Show("저장 완료");

                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("저장 실패!" + Environment.NewLine + f.Message);
                }
            }
            btnSelectPreInfo_Click(sender, e);

            btnSelectPreInfo.PerformClick();
        }

        private void btnDeletePreJobInfo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dele_rtn();
                    MessageBox.Show("삭제 완료");
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("삭제 실패!"+ Environment.NewLine + f.Message);
                }
            }
            btnSelectPreInfo_Click(sender, e);
            btnSelectPreInfo.PerformClick();
        }


        private void frmPQMS_STAFF_PRE_JOB_INFO_Load(object sender, EventArgs e)
        {

            txtSTAFF_CODE.Text = Form2PQMS_StaffInfo.sStaffCode;
            txtSTAFF_TEAM.Text = Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM;

            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = " select FOLDER_CODE from K_WORKSPACE  ";
            query = query + " where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "'";
            query = query + " and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'";
            query = query + " and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            query = query + " and FOLDER_Name ='" + txtSTAFF_TEAM.Text + "'";
            query = query + " and isnull(BOARD_CODE, '' ) = '' ";
            
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {                   
                    while (reader.Read())
                    {
                        sFolderCode = (reader.GetValue(0).ToString());
                    }
                }
            }
            Conn.Close();

            btnSelectPreInfo.PerformClick();
        }

        private void btn_DEPTPART_Click(object sender, EventArgs e)
        {
            string query = "";
            Conn = new OleDbConnection(unitCommon.connect_string);

            query = " select BOARD_CODE, BOARD_NAME  from K_WORKSPACE  ";
            query = query + " where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "'";
            query = query + " and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'";
            query = query + " and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            query = query + " and FOLDER_Name ='"+txtSTAFF_TEAM.Text+"'";
            query = query + " and isnull(BOARD_CODE, '' ) != '' ";
            

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    cmb_DEPTPART.Items.Clear();                    
                    while (reader.Read())
                    {
                        cmb_DEPTPART.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                    }
                }
            }
            Conn.Close();
        }

        private void cmb_DEPTPART_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_DEPTPARTCODE.Text = cmb_DEPTPART.Text.Substring(0, 5);
            txt_DEPTPARTNAME.Text = cmb_DEPTPART.Text.Substring(6, cmb_DEPTPART.Text.Length - 6);
        }

        private void PQMS_STAFF_DeptPartView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txt_DEPTPARTCODE.Text = PQMS_STAFF_DeptPartView.GetFocusedDataRow()["BOARD_CODE"].ToString();
            txt_DEPTPARTNAME.Text = PQMS_STAFF_DeptPartView.GetFocusedDataRow()["BOARD_NAME"].ToString();
            txtIDX.Text = PQMS_STAFF_DeptPartView.GetFocusedDataRow()["IDX"].ToString(); 

            if (PQMS_STAFF_DeptPartView.GetFocusedDataRow()["STAFF_TEAM_PART_MASTER"].ToString() != "")
            {
                rdo_PartMaster_Y.Checked = true;
            }
        }
    }
}