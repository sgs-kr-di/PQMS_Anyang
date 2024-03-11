using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

using PQMS.C.Unit;


namespace PQMS
{
    public partial class frmUserIdRequest : MetroFramework.Forms.MetroForm
    {

        private string nM1;
        private string nM2;
        private string nM3;
        private string nM4;

        public string loginId
        {
            get { return nM1; }
            set { nM1 = value; }
        }

        public string userId
        {
            get { return nM2; }
            set { nM2 = value; }
        }

        public string appId
        {
            get { return nM3; }
            set { nM3 = value; }
        }

        public string accountNo
        {
            get { return nM4; }
            set { nM4 = value; }
        }

        public frmUserIdRequest()
        {
            InitializeComponent();
        }

        private OleDbConnection Conn;

        //public string connect_string =
        //                  "data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster;User ID=dev01;Password=dev010207";

        public string connect_string =
                        "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";


        private DataTable dt = new DataTable();
        private DataView dv;


        private void frmUserIdRequest_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = textBox1.Text + "loginId : " + Form2PQMS_LoginInfo.sloginId + (char)10;
            textBox1.Text = textBox1.Text + "userId : " + Form2PQMS_LoginInfo.sUserId + (char)10;
            textBox1.Text = textBox1.Text + "accountNo : " + Form2PQMS_LoginInfo.sAccountNo + (char)10;
            textBox1.Text = textBox1.Text + "appId : " + Form2PQMS_LoginInfo.sAppId + (char)10;

            txtAppID2.Text = Form2PQMS_LoginInfo.sAppId;

            get_approval_right1();
            get_approval_right2();
            get_max_role_depth();
        }

        private void get_approval_right1()
        {
            Conn = new OleDbConnection(connect_string);

            ////dgvUserRequestStatus.Rows.Clear();

            string query = "";

            query = " select t1.accountNo, t2.userId, t1.roleDepth from accountApproveRole t1 ";
            query = query + "  inner join accountMaster t2 on (t1.accountNo = t2.accountNo) ";
            query = query + "    where t1.menuNo = (select menuNo from menuMaster where appID = '" + Form2PQMS_LoginInfo.sAppId + "'";
            query = query + "    and menuName = '" + this.Tag + "')";
            query = query + "    order by t1.roleDepth ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            dgvApprovalUser.RowCount = 300;

            int i = 0;
            int wRowNo = 0;
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dgvApprovalUser.ColumnCount = reader.FieldCount + 1;

                    while (reader.Read())
                    {
                        //txtRoleDepth.Text = reader.GetValue(1).ToString();

                        dgvApprovalUser.Rows[wRowNo].Cells[0].Value = false;
                        for (i = 0; i < reader.FieldCount; i++)
                        {
                            dgvApprovalUser.Rows[wRowNo].Cells[i + 1].Value = reader.GetValue(i);
                        }
                        wRowNo = wRowNo + 1;
                        dgvApprovalUser.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();
                    }
                }
            }
            if (wRowNo > 0)
            {
                dgvApprovalUser.RowCount = wRowNo + 1;
            }
            else
            {
                dgvApprovalUser.RowCount = 1;
            }
            Conn.Close();
        }

        private void get_approval_right2()
        {
            Conn = new OleDbConnection(connect_string);

            ////dgvUserRequestStatus.Rows.Clear();

            string query = "";

            query = " select accountNo, menuno, roleDepth from accountApproveRole";
            query = query + "  where accountNo = '" + Form2PQMS_LoginInfo.sAccountNo + "'";
            query = query + "    and menuNo = (select menuNo from menuMaster where appID = '" + Form2PQMS_LoginInfo.sAppId + "'";
            query = query + "    and menuName = '" + this.Tag + "')";


            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        txtAccountNo2.Text = reader.GetValue(0).ToString();
                        txtMenuNo.Text = reader.GetValue(1).ToString();
                        txtRoleDepth.Text = reader.GetValue(2).ToString();
                    }
                }
            }
            Conn.Close();
        }

        private void get_max_role_depth()
        {
            Conn = new OleDbConnection(connect_string);

            ////dgvUserRequestStatus.Rows.Clear();

            string query = "";

            query = " select max(t1.roleDepth) from accountApproveRole t1 ";
            query = query + "  inner join accountMaster t2 on (t1.accountNo = t2.accountNo) ";
            query = query + "    where t1.menuNo = (select menuNo from menuMaster where appID = '" + Form2PQMS_LoginInfo.sAppId + "'";
            query = query + "    and menuName = '" + this.Tag + "')";
            //query = query + "    order by t1.roleDepth ";


            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        txtMaxRoleDepth.Text = reader.GetValue(0).ToString();
                    }
                }
            }
            Conn.Close();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            dt.Clear();
            using (SqlConnection conn = new SqlConnection(connect_string))
            {
                StringBuilder sql = new StringBuilder();

                sql.Append(@"select t1.approveNo, t1.userID, t1.logInID, t1.appID, t1.approveStatusCode, t2.userID as registeredBy, t1.registeredDate
                             from approveInfo as t1 with(nolock)
                             left join accountMaster as t2 with(nolock)
                             on t1.registeredBy = t2.accountNo");
                             //where t1.appid = @appID and t1.approveStatusCode = @status");

                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql.ToString();
                
                //cmd.Parameters.AddWithValue("@appID", cmbApp.Text);
                //cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
                conn.Close();
            }


        }

        String approveNo = string.Empty;

        private void dgvUserRequestStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex != -1)
            {
                txtApproveNO.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtuserID.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                txtLoginId.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                txtAppID.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                txtTargetNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
                txtASCode.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[8].Value.ToString().Trim();
                txtRequestTo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[9].Value.ToString().Trim();
                txtRegisteredBy.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[10].Value.ToString().Trim();
                txtRegisteredDate.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[12].Value.ToString().Trim();
                txtfirstname.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtempid.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[19].Value.ToString().Trim();
                //txtApproveNoTest.Text = approveNo;
            }

            //MessageBox.Show(e.ColumnIndex + ", " + e.RowIndex);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            save_item();
            save_dept(); 
            Modi_rtn(); // equestTo = '1' 로 처리함으로써, 해당 승인차수에서 승인된 것으로 처리 코자 함

            if (txtMaxRoleDepth.Text == txtRoleDepth.Text)
            {
                final_approve();
                MessageBox.Show("승인완료!");
            }
        }

        private void final_approve()
        {
            Conn = new OleDbConnection(connect_string);
            string query = "";

            query = "UPDATE accountMaster  SET ";
            query = query + " requestStatusCode = 'approved'";
            query = query + " WHERE accountNo = '" + txtTargetNo.Text.Trim() + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        
        private void Modi_rtn()
        {
            Conn = new OleDbConnection(connect_string);
            string query = "";

            query = "UPDATE accountApproveInfo  SET ";
            query = query + " RequestTo = '1'";
            query = query + " WHERE approveNo = '" + txtApproveNO.Text.Trim() + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void save_dept() // 사용자와 dept 연결 
        {
            Conn = new OleDbConnection(connect_string);
            string query = "";
            string sql = "";


            query = "INSERT INTO accountStaffDept (accountNo, appNo, SITE_CODE, REPOSITORY_CODE, WS_CODE, FOLDER_CODE ) VALUES ( ";
            query = query + "'" + txtTargetNo.Text.Trim() + "',";
            query = query + "'3',";
            query = query + "'" + Form1PQMS_Repo.sSiteCode + "',";
            query = query + "'" + Form1PQMS_Repo.sRepo + "',";
            query = query + "'" + Form1PQMS_Repo.sWS + "',";
            query = query + "'" + Form1PQMS_Repo.sSTAFF_Folder + "'";         
            query = query + "  )";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();

            string sTeam = Form1PQMS_Repo.sSiteCode+"-"+Form1PQMS_Repo.sRepo+"-" + Form1PQMS_Repo.sWS+"-"+ Form1PQMS_Repo.sSTAFF_Folder;

            sql = $"insert into  [NEW_PQMS].dbo.PQMS_STAFF  (SITE_CODE, REPOSITORY_CODE, WS_CODE, STAFF_CODE, STAFF_EMPNO, STAFF_NAME, ACCOUNT_NO , STAFF_TEAM )  values " +
                  $" ('{Form1PQMS_Repo.sSiteCode}','{Form1PQMS_Repo.sRepo}','{Form1PQMS_Repo.sWS}', ( select  (FORMAT(max(STAFF_CODE) + 1, '0000')) from  [NEW_PQMS].dbo.PQMS_STAFF ) ,'" +txtempid.Text+"', '" + txtfirstname.Text + "', '" + txtTargetNo.Text + "', '"+ sTeam + "')  "; //jhm0711

            cmd = new OleDbCommand(sql, Conn);
            cmd.ExecuteNonQuery();

            sql = $" insert into [NEW_PQMS].dbo.PQMS_STAFF_ROLE " +
                  $" (STAFF_CODE,	STAFF_ROLE_DATE,	STAFF_ROLE_CLASS,	STAFF_ROLE_ORG_CODE,	STAFF_ROLE_CODE,	STAFF_ROLE_NAME	,STAFF_ROLE_STATUS,  STAFF_ROLE_GIVEN_CLASS,	STAFF_ROLE_CERTI,	STAFF_ROLE_INSTEAD,	STAFF_ROLE_UPPER_REPORT ,STAFF_ROLE_NOTE,	STAFF_ROLE_QUALITY_SCORE,	STAFF_ROLE_TEST_SCORE, STAFF_ROLE_QUALITY_DIR_FILE,	STAFF_ROLE_TEST_DIR_FILE )" +
                  $" values " +
                  $" ( (select  STAFF_CODE from  [NEW_PQMS].dbo.PQMS_STAFF where STAFF_EMPNO='" +txtempid.Text+ "'), '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '1001-2001', '0007', 'R001'," +
                  $" 'SGS_Korea 직원', 'Y', 'Y', 'Y', '', '', '', '', '', '', ''); ";

            cmd = new OleDbCommand(sql, Conn);            
            cmd.ExecuteNonQuery();

            Conn.Close();

        }
        private void save_item()
        {
            Conn = new OleDbConnection(connect_string);
            string query = "";

            query = "INSERT INTO accountApproveInfo VALUES ( ";
            query = query + "'" + txtuserID.Text.Trim() + "',";
            query = query + "'" + txtLoginId.Text.Trim() + "',";
            query = query + "'" + txtAppID.Text.Trim() + "',";
            query = query + "'" + txtMenuNo.Text.Trim() + "',";
            query = query + "'" + txtTargetNo.Text.Trim() + "',";
            query = query + "'" + txtRoleDepth.Text.Trim() + "',";
            query = query + "'',";
            query = query + "'" + Form2PQMS_LoginInfo.sUserId + "',";
            query = query + " getdate() )";
            
            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();

            //MessageBox.Show(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = textBox1.Text + "loginId : " + loginId + (char)10;
            textBox1.Text = textBox1.Text + "userId : " + userId + (char)10;
            textBox1.Text = textBox1.Text + "accountNo : " + accountNo + (char)10;
            textBox1.Text = textBox1.Text + "appId : " + accountNo + (char)10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtRoleDepth.Text != "" && txtAppID2.Text != "" && txtMenuNo.Text != "")
            {
                Get_Data();
            }
            else
            {
                MessageBox.Show("Role Depth 확인");
                txtRoleDepth.Focus();
            }
        }

        private void Get_Data()
        {
            Conn = new OleDbConnection(connect_string);

            ////dgvUserRequestStatus.Rows.Clear();

            string query = "";

            query = " select b.firstName, * ";
            query = query + " from accountApproveinfo  a ";
            query = query + "  inner join userMaster b on a.userID = b.userID ";
            query = query + "  where approveStatusCode = '" + (Convert.ToDecimal(txtRoleDepth.Text) - 1).ToString() + "'";
            query = query + "    and (RequestTo = '' or  RequestTo is null)";
            query = query + "    and appID = '" + txtAppID2.Text + "'";
            query = query + "    and menuno = '" + txtMenuNo.Text + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            dgvUserRequestStatus.RowCount = 100;

            int i;
            int wRowNo = 0;

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dgvUserRequestStatus.ColumnCount = reader.FieldCount + 1;

                    for (i = 1; i < reader.FieldCount + 1; i++)
                    {
                        dgvUserRequestStatus.Columns[i].HeaderText = reader.GetName(i - 1).ToString();
                        if (i == 1)
                        {
                            //dgvUserRequestStatus.Columns[i].Width = 40;
                            //dgvUserRequestStatus.Columns[i].Visible = false;

                            dgvUserRequestStatus.Columns[i].Width = 100;
                            dgvUserRequestStatus.Columns[i].Visible = true;
                        }
                        else
                        {
                            if (i == 2)
                            {
                                dgvUserRequestStatus.Columns[i].Width = 100;
                            }
                            else
                            {
                                dgvUserRequestStatus.Columns[i].Width = 100;
                            }
                        }
                    }

                    while (reader.Read())
                    {
                        dgvUserRequestStatus.Rows[wRowNo].Cells[0].Value = false;
                        for (i = 0; i < reader.FieldCount; i++)
                        {
                            dgvUserRequestStatus.Rows[wRowNo].Cells[i + 1].Value = reader.GetValue(i);
                        }
                        wRowNo = wRowNo + 1;
                        dgvUserRequestStatus.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();

                    }
                }
            }
            if (wRowNo > 0)
            {
                dgvUserRequestStatus.RowCount = wRowNo + 1;
            }
            else
            {
                dgvUserRequestStatus.RowCount = 1;
            }

            Conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        /*
                private void btnSel_Click(object sender, EventArgs e)
                {

                    string query = " select userid, loginId, requestStatus " +
                                   " from accountMaster";

                    if(cmbStatus.Text.Trim() != "" && cmbApp.Text.Trim() != "")
                    {
                        query += "   where ";
                    }

                    if (cmbStatus.Text.Trim() != "")
                    {
                        query += "          requestStatus = '" + cmbStatus.Text.Trim() + "' ";
                    }            
                    if (cmbApp.Text.Trim() != "")
                    {
                        if (cmbStatus.Text.Trim() != "")
                        {
                            query += "  and ";
                        }
                        query += "          appID = '" + cmbApp.Text.Trim() + "' ";
                    }

                    //DataSet ds = new System.Data.DataSet();
                    Conn = new OleDbConnection(connect_string);
                    OleDbCommand cmd = new OleDbCommand(query, Conn);
                    Conn.Open();

                    int wRowNo = 0;
                    int i = 0;

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            dgvUserRequestStatus.ColumnCount = reader.FieldCount + 1;


                            for (i = 0; i < reader.FieldCount + 1; i++)
                            {
                                dgvUserRequestStatus.Columns[i].HeaderText = reader.GetName(i-1).ToString();
                                if (i == 1)
                                {
                                    //dgvUserRequestStatus.Columns[i].Width = 40;
                                    //dgvUserRequestStatus.Columns[i].Visible = false;

                                    dgvUserRequestStatus.Columns[i].Width = 100;
                                    dgvUserRequestStatus.Columns[i].Visible = true;
                                }
                                else
                                {
                                    if (i == 2)
                                    {
                                        dgvUserRequestStatus.Columns[i].Width = 400;
                                    }
                                    else
                                    {
                                        dgvUserRequestStatus.Columns[i].Width = 400;
                                    }
                                }
                            }
                            while (reader.Read())
                            {
                                //dgvUserRequestStatus.RowCount = wRowNo + 1;

                                dgvUserRequestStatus.Rows[wRowNo].Cells[0].Value = false;

                                for (i = 0; i < reader.FieldCount; i++)
                                {
                                    dgvUserRequestStatus.Rows[wRowNo].Cells[i+1].Value = reader.GetValue(i);
                                }
                                wRowNo = wRowNo + 1;
                                dgvUserRequestStatus.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("데이터 없음");
                        }
                    }
                    if (wRowNo > 0)
                    {
                        dgvUserRequestStatus.RowCount = wRowNo + 1;
                    }
                    else
                    {
                        dgvUserRequestStatus.RowCount = 1;
                    }
                    Conn.Close();
                }
        */
    }    
}