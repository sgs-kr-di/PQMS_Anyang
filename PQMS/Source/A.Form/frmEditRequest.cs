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
using System.Globalization;
using PQMS.C.Unit;
using Spire.Doc;
using System.IO;
using System.Diagnostics;


namespace PQMS
{
    public partial class frmEditRequest : MetroFramework.Forms.MetroForm
    {
        private UnitCommon unitCommon;
        private OleDbConnection Conn;
        private UnitSMTP unitSMTP;

        public frmEditRequest()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();        

            
        }

        private void frmEditRequest_Load(object sender, EventArgs e)
        {
            //cmbGubun.Items.Clear();
            //cmbGubun.Items.Add("임명장");
            //cmbGubun.Items.Add("교육보고서");
            //cmbGubun.Items.Add("직무기술서");
            //cmbGubun.Items.Add("직무자료");
            //cmbGubun.Items.Add("조직도");

            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER")) //사용자 
            {
                Conn = new OleDbConnection(unitCommon.connect_string);
                string query = "";
                query = "select* from PQMS_STAFF ";
                query = query + "where ACCOUNT_NO = " + Form2PQMS_LoginInfo.sAccountNo;

                OleDbCommand cmd = new OleDbCommand(query, Conn);                
                Conn.Open();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dbtable = new DataTable();
                    dbtable.Load(reader);

                    if (dbtable.Rows.Count > 0)
                    {
                        Form2PQMS_StaffInfo.sStaffCode = dbtable.Rows[0][0].ToString();
                    }

                    
                    txtStaffCode.Text = Form2PQMS_StaffInfo.sStaffCode;
                }
                Conn.Close();

            }
            else//admin
            { 
            }

            button9_Click(sender, e);

        }

        private void get_folder_data(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2

        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
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

        private void btn_ApproveRequest_Click(object sender, EventArgs e)
        {
            Form2PQMS_StaffInfo.sStaffCode = txtStaffCode.Text;
            Form2_Tab_Info_Now.sMenuName = "부서관리";
            Form2_Tab_Info_Now.sTabName = "수정변경요청";

            string query = " select STAFF_TEAM  from PQMS_STAFF where STAFF_CODE = '" + txtStaffCode.Text + "' ";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                DataTable dbtable = new DataTable();
                dbtable.Load(reader);

                Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM = dbtable.Rows[0][0].ToString();
            }
            Conn.Close();


            string sFormName = "frmApproveRequestVer2";
            frmApproveRequestVer2 childfrm = new frmApproveRequestVer2(null);

            if (unitCommon.YNFrom(sFormName))
            {
                childfrm.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrm.WindowState = FormWindowState.Normal;
                childfrm.ShowDialog();
            }

        }

        private void btn_ApproveReqSelect_Click(object sender, EventArgs e)
        {

            Form2PQMS_StaffInfo.sStaffCode = txtStaffCode.Text;
            Form2_Tab_Info_Now.sMenuName = "부서관리";
            Form2_Tab_Info_Now.sTabName = "수정변경요청";

            string sFormName = "frmApproveRequestCheckVer2";
            frmApproveRequestCheckVer2 childfrm = new frmApproveRequestCheckVer2();

            if (unitCommon.YNFrom(sFormName))
            {
                childfrm.Dispose();     // 창 리소스 제거
            }
            else
            {
                childfrm.WindowState = FormWindowState.Normal;
                childfrm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            get_folder_data3("PQMS_STAFF", "STAFF_CODE", "STAFF_NAME", cmbStaff);
        }

        private void get_folder_data3(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where substring(staff_team,0,5) = '" + Form1PQMS_Repo.sSiteCode + "'";
            query = query + "   and substring(staff_team,6,4) = '" + Form1PQMS_Repo.sRepo + "'";
            query = query + "   and substring(staff_team,11,5) = '" + Form1PQMS_Repo.sWS + "'";

            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER")) //사용자 
            {
                query = query + " and "+ tField1 + " = '" + txtStaffCode.Text + "'";
            }


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

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStaffCode.Text = cmbStaff.Text.Substring(0, 4);
            txtStaffName.Text = cmbStaff.Text.Substring(5, cmbStaff.Text.Length - 5);
        }

        private void PQMS_EDIT_RequestListView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {            
            txtIDX.Text = PQMS_EDIT_RequestListView.GetFocusedRowCellValue("IDX").ToString().Trim();
            txtStaffCode.Text = PQMS_EDIT_RequestListView.GetFocusedRowCellValue("STAFF_CODE").ToString().Trim();
            txtStaffName.Text = PQMS_EDIT_RequestListView.GetFocusedRowCellValue("STAFF_NAME").ToString().Trim();
            txtContents.Text = PQMS_EDIT_RequestListView.GetFocusedRowCellValue("STAFF_EDITREQUEST_CONTENTS").ToString().Trim();
            dtpRequestDate.Text = PQMS_EDIT_RequestListView.GetFocusedRowCellValue("STAFF_EDITREQUEST_DATE").ToString().Trim();            
            cmbGubun.Text = PQMS_EDIT_RequestListView.GetFocusedRowCellValue("STAFF_EDITREQUEST_GUBUN").ToString().Trim();

            Form2_GridIdx.sIDX = PQMS_EDIT_RequestListView.GetFocusedRowCellValue("IDX").ToString();

            string query = " select STAFF_TEAM  from PQMS_STAFF where STAFF_CODE = '" + txtStaffCode.Text + "' ";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                DataTable dbtable = new DataTable();
                dbtable.Load(reader);

                Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM = dbtable.Rows[0][0].ToString();
            }
            Conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save_item();
            button9_Click(sender, e);
        }

        private void save_item()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "INSERT INTO PQMS_STAFF_EDITREQUEST (STAFF_CODE, STAFF_NAME, STAFF_EDITREQUEST_DATE, STAFF_EDITREQUEST_GUBUN, STAFF_EDITREQUEST_CONTENTS) VALUES ( ";
            query = query + "'" + txtStaffCode.Text.Trim() + "',";
            query = query + "N'" + txtStaffName.Text.Trim() + "',";
            query = query + "N'" + dtpRequestDate.Text.Trim() + "',";
            query = query + "N'" + cmbGubun.Text.Trim() + "',";            
            query = query + "N'" + txtContents.Text.Trim() + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

            MessageBox.Show("저장완료!");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Modi_rtn();
            button9_Click(sender, e);
        }

        private void Modi_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "UPDATE PQMS_STAFF_EDITREQUEST  SET ";
            query = query + " STAFF_CODE  = '" + txtStaffCode.Text.Trim() + "',";
            query = query + " STAFF_NAME  = N'" + txtStaffName.Text.Trim() + "',";
            query = query + " STAFF_EDITREQUEST_DATE  = N'" + dtpRequestDate.Text.Trim() + "',";
            query = query + " STAFF_EDITREQUEST_GUBUN  = N'" + cmbGubun.Text.Trim() + "',";
            query = query + " STAFF_EDITREQUEST_CONTENTS  = N'" + txtContents.Text.Trim() + "'";            
            query = query + " WHERE IDX = '" + txtIDX.Text.Trim() + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

            MessageBox.Show("수정완료!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dele_rtn();
            button9_Click(sender, e);
        }

        private void dele_rtn()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "delete from PQMS_STAFF_EDITREQUEST  ";
            query = query + " WHERE IDX = '" + txtIDX.Text.Trim() + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

            MessageBox.Show("삭제완료!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = " SELECT a.*, ";
            query = query + "(CASE WHEN a.approveStatusCode IS NULL THEN '신청전' ";
            query = query + " WHEN approveStatusCode = '0' THEN '승인대기' ";
            query = query + " WHEN approveStatusCode = '1' THEN '승인완료' ";
            query = query + " ELSE '반려' ";
            query = query + " END) AS 'approvedYN_Korea'";
            query = query + " from PQMS_STAFF_EDITREQUEST a";
            query = query + "  inner join PQMS_STAFF b on a.STAFF_CODE = b.STAFF_CODE  ";
            query = query + " and b.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE = '" + Form1PQMS_Repo.sWS + "' ";

            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("USER")) //사용자 이면 자기가 올린 내용만 확인
            {
                query = query + " where STAFF_CODE ='" + txtStaffCode.Text + "'";
            }

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            DataTable dt = new DataTable();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    PQMS_EDIT_RequestListGrid.DataSource = dt;
                }
            }
            Conn.Close();
        }

        private void btnGubun_Click(object sender, EventArgs e)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select WorkNo, WorkName from [accountMaster].dbo.[appMaster_Work] ";
            query = query + " where WorkNo <> 7 ";
            query = query + "      order by 1 ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    cmbGubun.Items.Clear();

                    while (reader.Read())
                    {
                        //cmbGubun.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                        cmbGubun.Items.Add(reader.GetValue(1).ToString());
                    }
                }
            }

            Conn.Close();
        }
    }
}
