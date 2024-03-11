using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.OleDb;
using PQMS.C.Unit;
using System.Data;
using System.Data.SqlClient;

namespace PQMS
{
    public partial class frmMasterApproveRole : Form
    {
        private UnitCommon unitCommon;
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

        public string DeptCode = "";
        public int DeptNo = 0;
        public string[] words;

        public frmMasterApproveRole()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }

        private OleDbConnection Conn;

        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";

        private void btnUpd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("준비중!");

            Conn = new OleDbConnection(connect_string);

            if (txtAcctApprRoleNo.Text != "")
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(txtAcctApprRoleNo.Text + "번 자료를 수정하시겠습니까?", "수정 작업", buttons);
                if (result == DialogResult.Yes)
                {
                    string query = "";
                    query = "update approveRole_V1 set ";
                    query = query + " accountNo = '" + txtAccountNo.Text + "'";
                    query = query + ", appNo = '" + txtAppNo.Text + "'";
                    query = query + ", deptNo = '" + txtDeptNo.Text + "'";
                    query = query + ", menuNo = '" + txtMenuNo.Text + "'";
                    query = query + ", workNo = '" + txtWorkNo.Text + "'";
                    query = query + ", MyApproveDepth = '" + txtRoleDepth.Text + "'";
                    query = query + ", MaxApproveDepth = '" + txtMaxDepth.Text + "'";
                    query = query + ", modifiedBy = '" + loginId + "'";
                    query = query + ", ModifiedDate = " + " getdate() " + "";
                    query = query + ", Disuse = '" + txtDisUse.Text + "'";
                    query = query + ", DisusedBy = '" + loginId + "'";
                    query = query + ", DisusedDate = " + " getdate() " + "";
                    query = query + " where approveRoleNo = " + txtAcctApprRoleNo.Text + "";

                    OleDbCommand cmd = new OleDbCommand(query, Conn);

                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();

                    MessageBox.Show("수정 완료!");
                }
                else
                {
                    // Do something  
                }
            }
            else
            {
                MessageBox.Show("삭제 자료 확인");
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Conn = new OleDbConnection(connect_string);

            if (txtAcctApprRoleNo.Text != "")
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(txtAcctApprRoleNo.Text + "번 자료를 삭제하시겠습니까?", "삭제 작업", buttons);
                if (result == DialogResult.Yes)
                {
                    string query = "";
                    query = "delete from approveRole_V1 where approveRoleNo = " + txtAcctApprRoleNo.Text + "";

                    OleDbCommand cmd = new OleDbCommand(query, Conn);

                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();

                    MessageBox.Show("삭제 완료!");
                }
                else
                {
                    // Do something  
                }
            }
            else
            {
                MessageBox.Show("삭제 자료 확인");
            }
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            string dupChk = "";
            Conn = new OleDbConnection(connect_string);

            string query = "";
            query = " select approveRoleNo ";
            query = query + "     from approveRole_V1 ";
            query = query + "    where accountNo = '" + txtAccountNo.Text.Trim() + "' ";
            query = query + " and appNo = " + txtAppNo.Text + " ";
            query = query + " and deptNo = '" + txtDeptNo.Text + "' ";
            query = query + " and menuNo = " + txtMenuNo.Text + " ";
            query = query + " and workNo = " + txtWorkNo.Text + " ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        //dupChk = "ok";
                        dupChk = "nok";
                        MessageBox.Show("데이터 중복!");
                    }
                }
                else
                {
                    dupChk = "ok";
                }
            }

            Conn.Close();

            dupChk = "ok";

            if (dupChk == "ok")
            {

                String disuseChecker = "";
                String disuseDate = "''";

                if (txtDisUse.Text == "1")
                {
                    disuseChecker = loginId;
                    disuseDate = "getdate()";
                }

                query = " insert into approveRole_V1 values (";
                query = query + " " + txtAccountNo.Text + ", ";
                query = query + " " + txtAppNo.Text + ", ";
                query = query + " '" + txtDeptNo.Text + "', ";
                query = query + " " + txtMenuNo.Text + ", ";
                query = query + " " + txtWorkNo.Text + ", ";
                query = query + " " + txtRoleDepth.Text + ", ";
                query = query + " " + txtMaxDepth.Text + ", ";
                query = query + " '" + loginId + "'," ;
                query = query + " getdate() " + ",";
                query = query + " '" + "" + "', ";
                query = query + " '" + "" + "', ";
                query = query + " '" + txtDisUse.Text + "', ";
                query = query + " '" + disuseChecker + "', ";
                query = query + " " + disuseDate + ")";

                cmd = new OleDbCommand(query, Conn);

                Conn.Open();
                cmd.ExecuteNonQuery();
                Conn.Close();

                MessageBox.Show("등록 완료!");


                foreach (Control ControlTextBoxClear in this.Controls)
                {
                    if (typeof(TextBox) == ControlTextBoxClear.GetType())
                    {
                        (ControlTextBoxClear as TextBox).Text = "";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAppNo.Text != "")
            {
                Get_Data(txtAppNo.Text);
                txtDeptName.Text = "";
            }
            else
            {
                MessageBox.Show("승인 대상 앱을 선택하세요.");
            }
        }

        private void Get_Data(string tVal1)
        {
            Conn = new OleDbConnection(unitCommon.connect_string);            

            string query = "";


            query = query + " select a.accountNo, x.STAFF_CODE, x.STAFF_NAME, a.logInID,   d.WorkName , d.WorkNo, b.MyApproveDepth,  ";
            query = query + " (CASE WHEN b.MyApproveDepth = '1' THEN '검토자' WHEN b.MyApproveDepth = '2' THEN '승인자' END) AS 'approved_Setting' ";
            query = query + " ,substring(x.STAFF_TEAM, 17, 5), y.FOLDER_CODE, y.FOLDER_NAME, b.approveRoleNo ";
            query = query + " from[accountMaster].[dbo].[accountMaster] a ";
            query = query + " inner join[accountMaster].[dbo].[approveRole_V1] b on a.accountNo = b.accountNo ";
            query = query + " inner join[accountMaster].[dbo].[userMaster] c on a.userID = c.userID ";
            query = query + " inner join[accountMaster].[dbo].[appMaster_Work] d on b.workNo = d.WorkNo ";
            query = query + " inner join PQMS_STAFF x on a.accountNo = x.ACCOUNT_NO  and x.SITE_CODE = '"+ Form1PQMS_Repo.sSiteCode+ "' and x.REPOSITORY_CODE = '"+ Form1PQMS_Repo.sRepo+ "' and x.WS_CODE = '"+ Form1PQMS_Repo.sWS+ "' ";
            query = query + " inner join K_WORKSPACE y on x.SITE_CODE = y.SITE_CODE and x.REPOSITORY_CODE = y.REPOSITORY_CODE and x.WS_CODE = y.WS_CODE and substring(x.STAFF_TEAM , 17,5) = y.FOLDER_CODE ";
            query = query + " where b.appNo = '3'";
            if (txtWorkNo.Text != "")
            {
                query = query + " and d.WorkNo= '" + txtWorkNo.Text + "' ";
            }
            query = query + "order by b.MyApproveDepth , d.WorkName ";


            //query = "select a.approveRoleNo as 자료번호, a.accountNo as 로그인계정번호, b.userID as 사용자계정, c.firstName, c.lastName,  ";
            //query = query + " a.appNo as 앱코드, e.appName as 앱이름, d.MenuNo as 메뉴코드, d.MenuName as 메뉴이름, ";
            //query = query + " f.WorkNo as 업무코드, f.WorkName as 업무이름,";
            //query = query + " a.DeptNo as 부서코드, '' as 부서이름, a.MyApproveDepth as 승인차수, a.MaxApproveDepth as 최종승인차수,a.disuse";
            //query = query + " from approveRole_V1 a ";
            //query = query + "  left outer join accountMaster b on a.accountNo = b.accountNo ";
            //query = query + "  left outer join userMaster c on b.userID = c.userID ";
            //query = query + "  left outer join appMaster e on a.appNo = e.appNo ";
            //query = query + "  left outer join appMaster_Menu d on a.appNo = d.appNo and a.MenuNo = d.MenuNo ";
            //query = query + "  left outer join appMaster_Work f on a.appNo = f.appNo and a.WorkNo = f.WorkNo ";
            //query = query + " where e.appNo = " + tVal1;
            //query = query + " order by a.accountNo, b.userID, c.firstName, c.lastName ";

            //query = query + "  where menuno = '" + ;

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

       
        private void dgvUserRequestStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= -1 && e.RowIndex >= 0 && e.RowIndex < dgvUserRequestStatus.RowCount - 1)
            {
                txtAcctApprRoleNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[1].Value.ToString();
                Get_Data2();
                get_tree_name();
            }
            else
            {
                //txtUserId.Text = dgvUserRequestStatus.Rows[e.RowIndex].HeaderCell.Value.ToString();

                //show_file(dgvFieldInputValue.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim());
            }
        }

        private void Get_Data2()
        {
            Conn = new OleDbConnection(connect_string);

            ////dgvUserRequestStatus.Rows.Clear();

            string query = "";

            query = "select a.approveRoleNo as 자료번호, a.accountNo as 로그인계정번호, b.logInID as 로그인계정, b.userID, c.firstName, c.lastName,  ";
            query = query + " a.appNo as 앱코드, e.appName as 앱이름, d.MenuNo as 메뉴코드, d.MenuName as 메뉴이름, ";
            query = query + " f.WorkNo as 업무코드, f.WorkName as 업무이름,";
            query = query + " a.DeptNo as 부서코드, '' as 부서이름, a.MyApproveDepth as 승인차수, a.MaxApproveDepth as 최종승인차수, a.disuse";
            query = query + " from approveRole_V1 a ";
            query = query + "  left outer join accountMaster b on a.accountNo = b.accountNo ";
            query = query + "  left outer join userMaster c on b.userID = c.userID ";
            query = query + "  left outer join appMaster e on a.appNo = e.appNo ";
            query = query + "  left outer join appMaster_Menu d on a.appNo = d.appNo and a.MenuNo = d.MenuNo ";
            query = query + "  left outer join appMaster_Work f on a.appNo = f.appNo and a.WorkNo = f.WorkNo ";
            //query = query + "  left outer join appMaster_Dept g on a.appNo = f.appNo and a.DeptNo = g.DeptNo ";
            query = query + " where e.appNo = " + txtAppNo.Text;
            query = query + "   and a.approveRoleNo = " + Convert.ToInt32(txtAcctApprRoleNo.Text);

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        txtAccountNo.Text = reader.GetValue(1).ToString();
                        txtLoginID.Text = reader.GetValue(2).ToString();
                        txtUserID.Text = reader.GetValue(3).ToString();
                        txtAppNo.Text = reader.GetValue(6).ToString();
                        txtAppID.Text = reader.GetValue(6).ToString();
                        txtMenuNo.Text = reader.GetValue(8).ToString();
                        txtMenuName.Text = reader.GetValue(9).ToString();
                        txtWorkNo.Text = reader.GetValue(10).ToString();
                        txtWorkName.Text = reader.GetValue(11).ToString();
                        txtDeptNo.Text = reader.GetValue(12).ToString();
                        txtDeptName.Text = reader.GetValue(13).ToString();
                        txtRoleDepth.Text = reader.GetValue(14).ToString();
                        txtMaxDepth.Text = reader.GetValue(15).ToString();
                        if (reader.GetValue(16).ToString() == "true")
                        {
                            txtDisUse.Text = "1";
                        }
                        else
                        {
                            txtDisUse.Text = "0";
                        }
                    }
                }
            }

            Conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDisUse.Text = cmbAble.Text.Substring(0, 1);
        }

        private void Get_Data3(string tVal1)
        {
            Conn = new OleDbConnection(connect_string);

            ////dgvData.Rows.Clear();

            string query = "";

            query = " select t1.accountNo, t1.loginID, t1.userID, t1.appNo, t1.appID, t1.appID, t2.STAFF_NAME  ";
            query = query + " from accountMaster t1  ";
            query = query + " inner join NEW_PQMS.DBO.PQMS_STAFF t2 on t1.accountNo = t2.ACCOUNT_NO  ";
            query = query + "  where t1.appNo = '" + txtAppNo.Text + "'";
            query = query + "    and t1.disuse = '0'";
            if (tVal1 != "")
            {
                query = query + "    and t1.loginID like '%" + tVal1 + "%'";
            }
            query = query + "  order by t1.accountNo";

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
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtAppNo.Text != "")
            {
                dgvData.Visible = true;
                Get_Data3(txtLoginID.Text);
            }
            else
            {
                MessageBox.Show("승인할 수 있는 앱을 선택하세요.");
            }
               
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                txtLoginID.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtUserID.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtAppNo.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAppID.Text = dgvData.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            else
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            get_ws_template3("appMaster_Menu", "MenuNo", "MenuName", cmbMenuNo, "Y");
        }

        private void get_ws_template3(string tTable, string tF1, string tF2, ComboBox tCmb, string tWSK)
        {
            //tField1 = 검색테이블
            //tField2 = 검색필드1
            //tField3 = 검색필드2



            Conn = new OleDbConnection(connect_string);

            string query = "";


            if (tTable == "appMaster_Work")
            {
                query = " select t1." + tF1 + ", t1." + tF2;
                query = query + " from " + tTable + " t1 ";
                query = query + "  where t1.appNo = '" + txtAppNo.Text + "'";
                query = query + " and t1.WorkNo not in (1, 6,7) ";
                query = query + "  order by t1." + tF1 + "";
            }
            else
            {
                query = " select t1." + tF1 + ", t1." + tF2;
                query = query + " from " + tTable + " t1 inner join appMaster t2 on (t1.appNo = t2.appNo) ";
                query = query + "  where t2.appNo = '" + txtAppNo.Text + "'";
                query = query + "  order by t1." + tF1 + "";
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




        private void Get_Data4()
        {
            Conn = new OleDbConnection(connect_string);

            ////dgvData.Rows.Clear();

            string query = "";

            query = " select t1.menuNo, t1.menuName ";
            query = query + " from menuMaster t1 inner join appMaster t2 on (t1.appID = t2.appID) ";
            query = query + "  where t2.appNo = '" + txtAppNo.Text + "'";
            query = query + "  order by t1.menuNo";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            dgvData.RowCount = 300;

            int i;
            int wRowNo = 0;

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
            }

            Conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            get_ws_template2(cmbAppID, "Y");
        }

        private void get_ws_template2(ComboBox tCmb, string tWSK)
        {
            //tField1 = 검색테이블
            //tField2 = 검색필드1
            //tField3 = 검색필드2



            Conn = new OleDbConnection(connect_string);

            string query = "";

            query = "  select  appNo , appID from appMaster ";
            query = query + "      order by appNo ";

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

        private void cmbAppID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAppNo.Text = cmbAppID.Text.Substring(0, cmbAppID.Text.IndexOf(' '));
            txtAppID.Text = cmbAppID.Text.Substring(cmbAppID.Text.IndexOf(' ') + 1, cmbAppID.Text.Length - cmbAppID.Text.IndexOf(' ') - 1);

        }

        private void cmbMenuNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMenuNo.Text = cmbMenuNo.Text.Substring(0, cmbMenuNo.Text.IndexOf(' '));
            txtMenuName.Text = cmbMenuNo.Text.Substring(cmbMenuNo.Text.IndexOf(' ') + 1, cmbMenuNo.Text.Length - cmbMenuNo.Text.IndexOf(' ') - 1);

        }

        private void frmMasterApproveRole_Load(object sender, EventArgs e)
        {
            dgvUserRequestStatus.AllowUserToAddRows = false;
            dgvData.AllowUserToAddRows = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            get_ws_template3("appMaster_Work", "WorkNo", "WorkName", cmbWork, "Y");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            get_ws_template3("appMaster_Dept", "DeptNo", "DeptName", cmbDept, "Y");

        }

        private void cmbWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWorkNo.Text = cmbWork.Text.Substring(0, cmbWork.Text.IndexOf(' '));
            txtWorkName.Text = cmbWork.Text.Substring(cmbWork.Text.IndexOf(' ') + 1, cmbWork.Text.Length - cmbWork.Text.IndexOf(' ') - 1);
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDeptNo.Text = cmbDept.Text.Substring(0, cmbDept.Text.IndexOf(' '));
            txtDeptName.Text = cmbDept.Text.Substring(cmbDept.Text.IndexOf(' ') + 1, cmbDept.Text.Length - cmbDept.Text.IndexOf(' ') - 1);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtRoleDepth.Text == "")
            {
                txtRoleDepth.Text = "0";
            }
            txtRoleDepth.Text = (Convert.ToInt32(txtRoleDepth.Text) + 1).ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtRoleDepth.Text == "" || Convert.ToInt32(txtRoleDepth.Text) < 0)
            {
                txtRoleDepth.Text = "0";
            }
            txtRoleDepth.Text = (Convert.ToInt32(txtRoleDepth.Text) - 1).ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DeptCode = txtDeptNo.Text;

            string[] words = DeptCode.Split('-');
            string tDeptCode = "";
            int i = 0;
            for (i = words.Length; i > -1; i--)
            {
                tDeptCode = "";
                for (int j = 0; j < i; j++)
                {
                    tDeptCode = tDeptCode + words[j] + "-";
                }
                MessageBox.Show(tDeptCode.Substring(0, tDeptCode.Length - 1));
                DeptNo = get_dept_no(tDeptCode.Substring(0,tDeptCode.Length -1));

                if (DeptNo > 0)
                {
                    MessageBox.Show(DeptNo.ToString());
                    break;
                }
            }
        }

        private int get_dept_no(string deptID)
        {
            Conn = new OleDbConnection(connect_string);

            string query = "";

            query = "SELECT DeptNo ";
            query = query + " FROM [accountMaster].[dbo].[appMaster_Dept] ";
            query = query + " where appNo = " + Convert.ToInt32(txtAppNo.Text) + "";
            query = query + "   and DeptName = '" + deptID + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        DeptNo = Convert.ToInt32(reader.GetValue(0).ToString());
                    }
                }
                else
                {
                    DeptNo = 0;
                }
            }
            Conn.Close();

            return DeptNo;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (txtAppNo.Text != "")
            {
                get_comb_data("K_SITE", "SITE_CODE", "SITE_NAME", "", "", cmbSiteCode2);
            }
            else
            {
                MessageBox.Show("앱코드 확인");
            }
        }

        private void get_comb_data(string tTable, string tField1, string tField2, string tField3, string tField4, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2
        //tField4 = 조건필드
        //tField5 = 조건값

        {
            Conn = new OleDbConnection(connect_string);

            string query = "";

            if (tField3 == "")
            {
                query = " select " + tField1 + "," + tField2 + " from " + tTable;
                query = query + " where appNo = " + txtAppNo.Text;
                query = query + "      order by " + tField1;
            }
            else
            {
                query = " select " + tField1 + "," + tField2 + " from " + tTable;
                query = query + " where appNo = " + txtAppNo.Text;
                query = query + "   and " + tField3 + " = '" + tField4 + "'";
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

        private void button11_Click(object sender, EventArgs e)
        {
            if (txtAppNo.Text != "" && cmbSiteCode2.Text != "")
            {
                get_comb_data("K_REPOSITORY", "REPOSITORY_CODE", "REPOSITORY_NAME", "SITE_CODE", cmbSiteCode2.Text.Substring(0, 4), cmbRepo);
            }
            else
            {
                MessageBox.Show("앱코드, 국가코드 확인");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtAppNo.Text != "" && cmbSiteCode2.Text != "" && cmbRepo.Text != "")
            {
                get_ws_data("K_WORKSPACE", "WS_CODE", "WS_NAME", cmbWS);
            }
            else
            {
                MessageBox.Show("앱코드, 국가코드 확인, 도시코드 확인");
            }

        }
        private void get_ws_data(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where appNo  = " + txtAppNo.Text + "";
            query = query + "   and SITE_CODE  = '" + cmbSiteCode2.Text.Substring(0,4) + "'";
            query = query + "   and REPOSITORY_CODE  = '" + cmbRepo.Text.Substring(0,4) + "'";
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

        private void cmbSiteCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDeptNo.Text = cmbSiteCode2.Text.Substring(0, 4);
            //txtDeptName.Text = cmbSiteCode2.Text.Substring(5, cmbSiteCode2.Text.Length - 5);
        }

        private void cmbRepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDeptNo.Text = txtDeptNo.Text + "-" + cmbRepo.Text.Substring(0, 4);
            //txtDeptName.Text = txtDeptName.Text + "-" + cmbRepo.Text.Substring(5, cmbRepo.Text.Length - 5);
        }

        private void cmbWS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDeptNo.Text = txtDeptNo.Text + "-" + cmbWS.Text.Substring(0, 5);
            //txtDeptName.Text = txtDeptName.Text + "-" + cmbWS.Text.Substring(6, cmbWS.Text.Length - 6);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (txtAppNo.Text != "" && cmbSiteCode2.Text != "" && cmbRepo.Text != "" && cmbWS.Text != "")
            {
                Get_Upload_Data(0);
                LoadTreeViewFromDB4(dgvOrg, trvItems);
                panel4.Visible = true;
            }
            else
            {
                MessageBox.Show("앱코드, 국가코드, 도시코드, 지점코드 확인 바랍니다.");
            }
        }
        private void Get_Upload_Data(int k)
        {
            string query = "";
            //query = "select * ";
            //query = query + " from Organization";

            if (k == 0)
            {
                query = " select [SITE_CODE],[REPOSITORY_CODE],[WS_CODE],[WS_NAME],[FOLDER_CODE],[FOLDER_NAME],";
                query = query + "  [BOARD_CODE],[BOARD_NAME],[GROUP_CODE],[GROUP_NAME],[SUBGROUP_CODE],[SUBGROUP_NAME] ";
                query = query + " from K_WORKSPACE ";
                query = query + "  where 1= 1 ";
                query = query + "  and appNo = " + txtAppNo.Text + "";
                query = query + "  and SITE_CODE = '" + cmbSiteCode2.Text.Substring(0,4) + "'";
                query = query + "  and REPOSITORY_CODE = '" + cmbRepo.Text.Substring(0,4) + "'";
                query = query + "  and WS_CODE = '" + cmbWS.Text.Substring(0,5) + "'";
                query = query + "      order by  SITE_CODE, REPOSITORY_CODE, WS_CODE, FOLDER_CODE, BOARD_CODE, GROUP_CODE, SUBGROUP_CODE";

            }

            Conn = new OleDbConnection(connect_string);

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
                    nodekey = nodekey + "-" + row.Cells[4].Value.ToString();
                    nodekey = nodekey + "-" + row.Cells[6].Value.ToString();
                    nodekey = nodekey + "-" + row.Cells[8].Value.ToString();
                    nodekey = nodekey + "-" + row.Cells[10].Value.ToString();

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

            txtNodeLevel.Text = e.Node.Level.ToString();
            txtNodeName.Text = e.Node.Name.ToString();
            txtNodeText.Text = e.Node.Text.ToString();

            txtDeptNo.Text = cmbSiteCode2.Text.Substring(0, 4);
            txtDeptNo.Text = txtDeptNo.Text + "-" + cmbRepo.Text.Substring(0, 4);
            txtDeptNo.Text = txtDeptNo.Text + "-" + e.Node.Name.ToString();
            if (txtNodeLevel.Text != "4") //설정된 마지막 노드 레벨
            {
                txtDeptNo.Text = txtDeptNo.Text.Substring(0, txtDeptNo.Text.IndexOf(" ") - 1);
            }
            get_tree_name();

            //txtDeptName.Text = e.Node.Text.ToString(); ;

            //txtDescription.Text = txtSiteName.Text + "-" + txtRepoName.Text + "-" + txtWSName.Text + "-" + e.Node.Text.ToString();


            panel4.Visible = false;

        }

        private void get_tree_name()
        {
            txtDeptName.Text = "";

            DeptCode = txtDeptNo.Text;

            words = DeptCode.Split('-');
            for (int i = 0; i < words.Length; i++)
            {
                //i=0 : 국가
                //i=1 : 도시
                //i=2 : 지점
                if (i == 0)
                {
                    txtDeptName.Text = txtDeptName.Text + get_dept_name2_tree(words[i], "K_SITE", "SITE_NAME", i);
                }
                if (i == 1)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name2_tree(words[i], "K_REPOSITORY", "REPOSITORY_NAME", i);
                }

                if (i == 2)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name_tree(words[i], "WS_NAME", i);
                }
                if (i == 3)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name_tree(words[i], "FOLDER_NAME", i);
                }
                if (i == 4)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name_tree(words[i], "BOARD_NAME", i);
                }
                if (i == 5)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name_tree(words[i], "GROUP_NAME", i);
                }
                if (i == 6)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name_tree(words[i], "SUBGROUP_NAME", i);
                }
            }

        }

        private void get_tree_name2(string tval1, int trow1,int tcol1)
        {
            DeptCode = tval1;
            txtDeptName.Text = "";
            words = DeptCode.Split('-');
            for (int i = 0; i < words.Length; i++)
            {
                //i=0 : 국가
                //i=1 : 도시
                //i=2 : 지점
                if (i == 0)
                {
                    txtDeptName.Text = txtDeptName.Text + get_dept_name2_tree(words[i], "K_SITE", "SITE_NAME", i);
                }
                if (i == 1)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name2_tree(words[i], "K_REPOSITORY", "REPOSITORY_NAME", i);
                }

                if (i == 2)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name_tree(words[i], "WS_NAME", i);
                }
                if (i == 3)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name_tree(words[i], "FOLDER_NAME", i);
                }
                if (i == 4)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name_tree(words[i], "BOARD_NAME", i);
                }
                if (i == 5)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name_tree(words[i], "GROUP_NAME", i);
                }
                if (i == 6)
                {
                    txtDeptName.Text = txtDeptName.Text + "-" + get_dept_name_tree(words[i], "SUBGROUP_NAME", i);
                }

                dgvUserRequestStatus.Rows[trow1].Cells[tcol1 + 2].Value = txtDeptName.Text;
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            get_tree_name();
        }
        private string get_dept_name_tree(string deptID, string tFd1, int j)
        {
            Conn = new OleDbConnection(connect_string);

            string DeptName = "";
            string query = "";

            query = "SELECT " + tFd1 +"";
            query = query + " FROM [accountMaster].[dbo].[K_WORKSPACE] ";
            query = query + " where appNo = " + Convert.ToInt32(txtAppNo.Text) + "";
            query = query + "   and SITE_CODE = '" + words[0] + "'";
            query = query + "   and REPOSITORY_CODE = '" + words[1] + "'";
            if (j == 2)
            {
                query = query + "   and WS_CODE = '" + words[j] + "'";
            }
            if (j == 3)
            {
                query = query + "   and WS_CODE = '" + words[j-1] + "'";
                query = query + "   and FOLDER_CODE = '" + words[j] + "'";
            }
            if (j == 4)
            {
                query = query + "   and FOLDER_CODE = '" + words[j-1] + "'";
                query = query + "   and BOARD_CODE = '" + words[j] + "'";
            }
            if (j == 5)
            {
                query = query + "   and FOLDER_CODE = '" + words[j-2] + "'";
                query = query + "   and BOARD_CODE = '" + words[j-1] + "'";
                query = query + "   and GROUP_CODE = '" + words[j] + "'";
            }
            if (j == 6)
            {
                query = query + "   and FOLDER_CODE = '" + words[j-3] + "'";
                query = query + "   and BOARD_CODE = '" + words[j-2] + "'";
                query = query + "   and GROUP_CODE = '" + words[j-1] + "'";
                query = query + "   and SUBGROUP_CODE = '" + words[j] + "'";
            }

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        DeptName = reader.GetValue(0).ToString();
                    }
                }
                else
                {
                    DeptName = "";
                }
            }
            Conn.Close();

            return DeptName;
        }

        private string get_dept_name2_tree(string deptID, string ttable, string tFd1, int j)
        {
            Conn = new OleDbConnection(connect_string);

            string DeptName = "";
            string query = "";

            query = "SELECT " + tFd1 + "";
            query = query + " FROM [accountMaster].[dbo]." + ttable ;
            query = query + " where appNo = " + Convert.ToInt32(txtAppNo.Text) + "";
            if (j == 0)
            {
                query = query + "   and SITE_CODE = '" + words[j] + "'";
            }
            if (j == 1)
            {
                query = query + "   and SITE_CODE = '" + words[j-1] + "'";
                query = query + "   and REPOSITORY_CODE = '" + words[j] + "'";
            }

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        DeptName = reader.GetValue(0).ToString();
                    }
                }
                else
                {
                    DeptName = "";
                }
            }
            Conn.Close();

            return DeptName;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            refresh_rtn();
        }

        private void refresh_rtn()
        {
            foreach (Control ControlTextBoxClear in this.Controls)
            {
                if (typeof(TextBox) == ControlTextBoxClear.GetType())
                {
                    (ControlTextBoxClear as TextBox).Text = "";
                }
            }

            txtAppNo.Text  = "";
            txtAppID.Text = "";
            txtAccountNo.Text = "";
            txtLoginID.Text = "";
            txtMenuNo.Text = "";
            txtMenuName.Text = "";
            txtWorkNo.Text = "";
            txtWorkName.Text = "";
            txtDeptNo.Text = "";
            txtDeptName.Text = "";
            txtRoleDepth.Text = "1";
            txtDisUse.Text = "0";


        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (txtMaxDepth.Text == "")
            {
                txtMaxDepth.Text = "0";
            }
            txtMaxDepth.Text = (Convert.ToInt32(txtMaxDepth.Text) + 1).ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (txtMaxDepth.Text == "" || Convert.ToInt32(txtMaxDepth.Text) < 0)
            {
                txtMaxDepth.Text = "0";
            }
            txtMaxDepth.Text = (Convert.ToInt32(txtMaxDepth.Text) - 1).ToString();
        }

        private void txtDisUse_TextChanged(object sender, EventArgs e)
        {

        }

        private void PQMS_Approve_SettingListView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtAcctApprRoleNo.Text = PQMS_Approve_SettingListView.GetFocusedRowCellValue("approveRoleNo").ToString();
            txtAccountNo.Text = PQMS_Approve_SettingListView.GetFocusedRowCellValue("accountNo").ToString();
            txtLoginID.Text = PQMS_Approve_SettingListView.GetFocusedRowCellValue("logInID").ToString();

        }
    }
}
