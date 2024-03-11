using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PQMS.C.Unit;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;



namespace PQMS
{
    public partial class frmApproveSetting : MetroFramework.Forms.MetroForm
    {
        private UnitCommon unitCommon;
        private UnitSMTP unitSMTP;

        private OleDbConnection Conn;
        public string conn_str = "Data Source=KRSEC001;Initial catalog=NEW_PQMS;User ID=pqms;Password=PQMS;Connection Timeout=600;";

        private int appNo = 0;

        public frmApproveSetting()
        {
            InitializeComponent(); 
            unitCommon = new UnitCommon();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            // get_folder_data3("PQMS_STAFF", "STAFF_CODE", "STAFF_NAME", cmbStaff);
            dgvData.Visible = true;
            Get_Data3(txtLoginID.Text);


        }


        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvData.Visible = false;
            if (e.RowIndex == -1)
            {
            }
            else if (e.ColumnIndex > -1)
            {
                txtAccountNo.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLoginID.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUserID.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAppNo.Text = "3";
                txtAppID.Text = dgvData.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            else
            {
            }
        }


        private void Get_Data3(string tVal1)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            ////dgvData.Rows.Clear();

            string query = "";

            query = " select a.accountNo, b.firstName, a.loginID, a.userID, a.appID  ";
            query = query + " from[accountMaster].[dbo].accountMaster a ";
            query = query + " inner join[accountMaster].[dbo].userMaster b on a.userID = b.userID ";
            query = query + " inner join[accountMaster].[dbo].accountStaffDept c on a.accountNo = c.accountNo and c.appNo = '3' ";
            query = query + " and c.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and c.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and c.WS_CODE='" + Form1PQMS_Repo.sWS + "' ";
            query = query + " where a.appID = 'PQMS' and a.disuse = '0' ";
            if (tVal1 != "")
            {
                query = query + "    and a.loginID like '%" + tVal1 + "%'";
            }
            query = query + " group by a.accountNo, b.firstName, a.loginID, a.userID, a.appID ";
            query = query + " order by a.accountNo ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            dgvData.Rows.Clear();

            int i;
            int wRowNo = 0;

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dgvData.RowCount = 3000;
                    dgvData.ColumnCount = reader.FieldCount + 1;

                    for (i = 1; i < reader.FieldCount + 1; i++)
                    {
                        dgvData.Columns[i].HeaderText = reader.GetName(i - 1).ToString();
                        if (i == 1)
                        {                            
                            dgvData.Columns[i].Width = 100;
                            dgvData.Columns[i].Visible = true;
                        }
                        else
                        {
                            if (i == 2)
                            {
                                dgvData.Columns[i].Width = 100;
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
                dgvData.RowCount = wRowNo;
            }
            else
            {
                dgvData.RowCount = 1;
            }

            txtArowNo.Text = wRowNo.ToString();

            Conn.Close();

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
                query = query + " and " + tField1 + " = '" + txtStaffCode.Text + "'";
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
        private int get_appno(string tVal)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";
            int tappno = 0;
            query = "SELECT  appNo FROM [accountMaster].[dbo].[appMaster] ";
            query = query + " where appID = '" + tVal + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        tappno = Convert.ToInt32(reader.GetValue(0).ToString());
                    }
                }
            }
            Conn.Close();

            return tappno;
        }

        private void btn_ApproveSettingList_Click(object sender, EventArgs e)
        {
            appNo = get_appno(Form2PQMS_LoginInfo.sAppId);

            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = " select a.accountNo,x.STAFF_CODE, a.logInID, c.firstName ,  d.WorkName , d.WorkNo, b.MyApproveDepth, ";
            query = query + " (CASE WHEN b.MyApproveDepth = '1' THEN '검토자' WHEN b.MyApproveDepth = '2' THEN '승인자' END) AS 'approved_Setting'";
            query = query + " from  [accountMaster].[dbo].[accountMaster] a";
            query = query + " inner join [accountMaster].[dbo].[approveRole_V1] b on a.accountNo = b.accountNo";
            query = query + " inner join [accountMaster].[dbo].[userMaster] c on a.userID = c.userID";
            query = query + " inner join [accountMaster].[dbo].[appMaster_Work] d on b.workNo = d.WorkNo";
            //query = query + " left outer join PQMS_STAFF x on  a.accountNo = x.ACCOUNT_NO ";
            query = query + " inner join PQMS_STAFF x on  a.accountNo = x.ACCOUNT_NO ";
            query = query + " and x.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and x.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and x.WS_CODE='" + Form1PQMS_Repo.sWS + "' ";
            query = query + " where b.appNo = '"+ appNo + "' ";
            if (txt_ApproveMenuNo.Text != "")
            {
                query = query + " and d.WorkNo= '"+ txt_ApproveMenuNo.Text+ "'";
            }
            query = query + " group by a.accountNo,x.STAFF_CODE, a.logInID, c.firstName , d.WorkName, d.WorkNo, b.MyApproveDepth ";
            query = query + "  order by b.MyApproveDepth , d.WorkName";


            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            DataTable dt = new DataTable();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    PQMS_Approve_SettingListGrid.DataSource = dt;
                }
            }
            Conn.Close();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int RoleDepth = 0;
            if (rdo_Approve1.Checked == true)
            {
                RoleDepth = 1;
            }
            else if (rdo_Approve2.Checked == true)
            {
                RoleDepth = 2;
            }

            //Form1PQMS_Repo
            string query = "";

            query = " select SITE_CODE + '-' + REPOSITORY_CODE + '-' + WS_CODE + '-' + FOLDER_CODE ";
            query = query + " from K_WORKSPACE ";
            query = query + " where SITE_CODE = '"+ Form1PQMS_Repo .sSiteCode + "' ";
            query = query + " and REPOSITORY_CODE = '"+ Form1PQMS_Repo .sRepo + "' ";
            query = query + " and WS_CODE = '" + Form1PQMS_Repo.sWS  + "' ";
            query = query + " and FOLDER_CODE<>  '' ";
                       


            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            DataTable dt = new DataTable();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);                    
                }               
            }
            Conn.Close();



            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    query = " insert into [accountMaster].[dbo].approveRole_V1 values ";
                    query = query + "( ";
                    query = query + " '" + txtAccountNo.Text + "' , '" + txtAppNo.Text + "', ";
                    query = query + " '" + dt.Rows[i][0].ToString() + "', ";
                    query = query + "1,";
                    query = query + " " + txt_ApproveMenuNo.Text + ", ";
                    query = query + " " + RoleDepth + ", ";
                    query = query + " 2, ";
                    query = query + " '" + Form2PQMS_LoginInfo.sloginId + "',";
                    query = query + " getdate() " + ",";
                    query = query + " '" + "" + "', ";
                    query = query + " '" + "" + "', ";
                    query = query + " '0', ";
                    query = query + " '', ";
                    query = query + " '' )";


                    cmd = new OleDbCommand(query, Conn);

                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();

                }
                MessageBox.Show("저장완료!");

            }
        }

        private void btn_ApproveMenu_Click(object sender, EventArgs e)
        {
            appNo = get_appno(Form2PQMS_LoginInfo.sAppId);
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = " select WorkNo, WorkName from  [accountMaster].[dbo].[appMaster_Work] ";
            query = query + " where appNo  = '" + appNo + "' and WorkNo <> 1";     
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    cmb_ApproveMenu.Items.Clear();

                    while (reader.Read())
                    {
                        cmb_ApproveMenu.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                    }
                }
            }
            Conn.Close();
        }

        private void cmb_ApproveMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_ApproveMenuNo.Text = cmb_ApproveMenu.Text.Substring(0, 1);
            txt_ApproveMenuName.Text = cmb_ApproveMenu.Text.Substring(1, cmb_ApproveMenu.Text.Length - 1);
        }

        private void PQMS_Approve_SettingListView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txt_ApproveMenuName.Text = PQMS_Approve_SettingListView.GetFocusedRowCellValue("WorkName").ToString();
            txt_ApproveMenuNo.Text = PQMS_Approve_SettingListView.GetFocusedRowCellValue("WorkNo").ToString();

            txtAccountNo.Text = PQMS_Approve_SettingListView.GetFocusedRowCellValue("accountNo").ToString();
            txtLoginID.Text = PQMS_Approve_SettingListView.GetFocusedRowCellValue("logInID").ToString();

            txtStaffCode.Text = PQMS_Approve_SettingListView.GetFocusedRowCellValue("STAFF_CODE").ToString();
            txtStaffName.Text = PQMS_Approve_SettingListView.GetFocusedRowCellValue("firstName").ToString();

            if (PQMS_Approve_SettingListView.GetFocusedRowCellValue("MyApproveDepth").ToString() == "1")
            {
                rdo_Approve1.Checked = true;
            }
            else
            {
                rdo_Approve2.Checked = true;
            }
                

        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlConnection SQLConnection = new SqlConnection(conn_str);   
                
                int myDepth = 0;
                if (rdo_Approve1.Checked == true)
                {
                        myDepth = 1;
                }
                else if (rdo_Approve2.Checked == true)
                {
                        myDepth = 2;
                }

                string sql =
                    $" delete from [accountMaster].[dbo].[approveRole_V1] " +
                    $" where accountNo='"+txtAccountNo.Text+"' and menuNo='1' and workNo='"+txt_ApproveMenuNo.Text+"' and MyApproveDepth= " + myDepth ;

                SqlCommand SQLCommand = new SqlCommand(sql, SQLConnection);
                SQLConnection.Open();

                //transaction 클래스 인스턴스 생성
                SqlTransaction SQLTransction = SQLConnection.BeginTransaction();
                SQLCommand = new SqlCommand();

                SQLCommand.Connection = SQLConnection;
                SQLCommand.Transaction = SQLTransction;

                try
                {
                    SQLCommand.CommandText = sql;
                    SQLCommand.ExecuteNonQuery();

                    SQLTransction.Commit();
                       
                }
                catch (Exception ex)
                {
                    SQLTransction.Rollback();
                    ex.ToString();
                    MessageBox.Show(ex.ToString() +"삭제실패");
                }
                finally
                {
                    SQLConnection.Close();
                }
                MessageBox.Show("삭제 완료!");                               
            }
            



        }
    }
}
