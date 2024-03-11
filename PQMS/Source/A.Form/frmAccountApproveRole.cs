using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace userManagement
{
    public partial class frmAccountApproveRole : Form
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
             

        public frmAccountApproveRole()
        {
            InitializeComponent();
        }

        private OleDbConnection Conn;

        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";

     
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
                    query = "delete from accountApproveRole where accountApproveRoleNo = " + txtAcctApprRoleNo.Text + "";

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

            string query = " select accountApproveRoleNo " +
                         "     from accountApproveRole " +
                         "    where accountNo = " + txtAccountNo.Text.Trim() + " " +
                         "      and menuno = " + txtMemuNo.Text.Trim() + " ";

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

            if (dupChk == "ok")
            {

                String disuseChecker = "";
                String disuseDate = "''";

                if (txtDisUse.Text == "1")
                {
                    disuseChecker = loginId;
                    disuseDate = "getdate()";
                }

                query =
                    " insert into accountApproveRole     " +
                    "  ( " +
                    "   accountNo         ," +
                    "   menuno       ," +
                    "   roleDepth       ," +
                    " 	registeredBy    ," +
                    " 	registeredDate  ," +
                    " 	modifiedBy      ," +
                    "   ModifiedDate           , " +
                    "   Disuse                 , " +
                    "   DisusedBy              , " +
                    "   DisusedDate              " +
                    " )                           " +
                    " Values                      " +
                    " (                           " +
                    " " + txtAccountNo.Text + ", " +
                    " " + txtMemuNo.Text + ", " +
                    " '" + txtRoleDepth.Text + "', " +
                    " '" + loginId + "'," +
                    " getdate()," +
                    "''," +
                    "''," +
                    " '" + txtDisUse.Text + "', " +
                    " '" + disuseChecker + "', " +
                    disuseDate +
                    " )";

                cmd = new OleDbCommand(query, Conn);

                Conn.Open();
                cmd.ExecuteNonQuery();
                Conn.Close();

                MessageBox.Show("등록 완료!");


                //foreach (Control ControlTextBoxClear in this.Controls)
                //{
                //    if (typeof(TextBox) == ControlTextBoxClear.GetType())
                //    {
                //        (ControlTextBoxClear as TextBox).Text = "";
                //    }
                //}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAppNo.Text != "")
            {
                Get_Data(txtAppNo.Text);
            }
            else
            {
                MessageBox.Show("승인 대상 앱을 선택하세요.");
            }
        }

        private void Get_Data(string tVal1)
        {
            Conn = new OleDbConnection(connect_string);

            dgvUserRequestStatus.Rows.Clear();

            string query = "";

            query = query + " select b.ACCOUNT_NO, b.STAFF_NAME, c.userID  from accountApproveRole a ";
            query = query + " inner join accountMaster c on(a.accountNo = c.accountNo) ";
            query = query + " inner join NEW_PQMS.DBO.PQMS_STAFF b on a.accountNo = b.ACCOUNT_NO ";
            query = query + " order by  b.ACCOUNT_NO ";

            //query = "select a.accountApproveRoleNo as 자료번호, a.accountNo as 로그인계정번호, b.userID as 사용자계정, b.logInID 로그인계정, c.firstName, c.lastName,  ";
            //query = query + " d.appID as 앱코드, e.appName as 앱이름, d.parentMenuID as 상위메뉴코드, f.menuName as 상위메뉴이름, a.menuno as 메뉴코드, d.menuName as 메뉴이름, a.roleDepth as 승인차수";
            //query = query + " from accountApproveRole a ";
            //query = query + "  left outer join accountMaster b on a.accountNo = b.accountNo ";
            //query = query + "  left outer join userMaster c on b.userID = c.userID ";
            //query = query + "  left outer join menuMaster d on a.menuno = d.menuNo ";
            //query = query + " left outer join appMaster e on d.appID = e.appID ";
            //query = query + "  left outer join menuMaster f on(d.appID = f.appID and d.parentMenuID = f.menuID) ";
            //query = query + " where e.appNo = " + tVal1;
            //query = query + " order by a.accountNo, b.userID, b.logInID, c.firstName, c.lastName ";

            //query = query + "  where menuno = '" + ;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            dgvUserRequestStatus.RowCount = 300;

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
                        if (i == 1 )
                        {
                            //dgvUserRequestStatus.Columns[i].Width = 40;
                            //dgvUserRequestStatus.Columns[i].Visible = false;

                            dgvUserRequestStatus.Columns[i].Width = 60;
                            dgvUserRequestStatus.Columns[i].Visible = true;
                        }
                        else if (i == 2 )
                        {
                            dgvUserRequestStatus.Columns[i].Width = 80;
                            dgvUserRequestStatus.Columns[i].Visible = true;
                        }
                        else if (i >= 3 && i <= reader.FieldCount)
                        {
                            dgvUserRequestStatus.Columns[i].Width = 120;
                            dgvUserRequestStatus.Columns[i].Visible = true;
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

            txtWRowNo.Text = wRowNo.ToString();

            Conn.Close();
        }
              

        private void dgvUserRequestStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= -1 && e.RowIndex >= 0 && e.RowIndex < dgvUserRequestStatus.RowCount - 1)
            {
                txtAcctApprRoleNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[1].Value.ToString();
                Get_Data2();
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

            query = " select t1.accountNo, t2.logInID, t2.userId,t2.appID, t4.appNo, t4.appID, t3.menuNo, t3.menuName, t1.roleDepth, t1.Disuse from accountApproveRole t1 ";
            query = query + "  inner join accountMaster t2 on (t1.accountNo = t2.accountNo) ";
            query = query + "  inner join appMaster t4 on (t2.appID = t4.appID) ";
            query = query + "  inner join menuMaster t3 on (t1.menuNo = t3.menuNo) ";
            query = query + "    where t1.accountApproveRoleNo = " + Convert.ToInt32(txtAcctApprRoleNo.Text);

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        txtAccountNo.Text = reader.GetValue(0).ToString();
                        txtLoginID.Text = reader.GetValue(1).ToString();
                        txtUserID.Text = reader.GetValue(2).ToString();
                        txtAppNo.Text = reader.GetValue(4).ToString();
                        txtAppID.Text = reader.GetValue(5).ToString();
                        txtMemuNo.Text = reader.GetValue(6).ToString();
                        txtMenuName.Text = reader.GetValue(7).ToString();
                        txtRoleDepth.Text = reader.GetValue(8).ToString();
                        txtDisUse.Text = reader.GetValue(9).ToString();
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

            query = query + " select a.groupMemberNo, a.accountNo, c.logInID, c.userID , x.STAFF_NAME ";
            query = query + " from groupMemberMaster a ";
            query = query + " inner join accountMaster c on (a.accountNo = c.accountNo) ";
            query = query + " inner join NEW_PQMS.DBO.PQMS_STAFF x on a.accountNo = x.ACCOUNT_NO ";
            query = query + " where a.groupNo in (17, 33) ";
            query = query + " order by  a.accountNo ";

            //query = "             select a.groupMemberNo, b.groupNo, b.groupName, a.accountNo, c.logInID, c.userID ";
            //query = query + " from groupMemberMaster a inner join groupMaster b on(a.groupNo = b.groupNo) ";
            //query = query + "                          inner join accountMaster c on(a.accountNo = c.accountNo) ";
            //query = query + "                         where  1 = 1 ";
            //query = query + "                           and b.appId = '" + txtAppID.Text.Trim() + "'";
            //query = query + "                           and a.groupNo in ( 17, 33) "; //관리자 파트장(팀장)
            //query = query + "                          order by b.groupNo, a.accountNo ";

            //query = " select t1.accountNo, t1.loginID, t1.userID, t2.appNo, t2.appID, t2.appName ";
            //query = query + " from accountMaster t1 inner join appMaster t2 on (t1.appID = t2.appID) ";
            //query = query + "  where t2.appNo = '" + txtAppNo.Text + "'";
            //query = query + "    and t1.disuse = '0'";
            //if (tVal1 != "")
            //{
            //    query = query + "    and t1.loginID like '%" + tVal1 + "%'";
            //}
            //query = query + "  order by t1.accountNo";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();



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
                dgvData.RowCount = wRowNo + 1;
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
                Get_Data3(txtLoginID.Text);
            }
            else
            {
                MessageBox.Show("승인할 수 있는 앱을 선택하세요.");
            }

        }       

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
            }
            else if (e.ColumnIndex > -1)
            {

                txtAccountNo.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtLoginID.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUserID.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();

                //txtAccountNo.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
                //txtLoginID.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
                //txtUserID.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
                //txtAppNo.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString();
                //txtAppID.Text = dgvData.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            else
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            get_ws_template3(cmbMenuNo, "Y");
        }

        private void get_ws_template3(ComboBox tCmb, string tWSK)
        {
            //tField1 = 검색테이블
            //tField2 = 검색필드1
            //tField3 = 검색필드2



            Conn = new OleDbConnection(connect_string);

            string query = "";

            query = " select t1.menuNo, t1.menuName ";
            query = query + " from menuMaster t1 inner join appMaster t2 on (t1.appID = t2.appID) ";
            query = query + "  where t2.appNo = '" + txtAppNo.Text + "'";
            query = query + "  order by t1.menuNo";

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
            txtMemuNo.Text = cmbMenuNo.Text.Substring(0, cmbMenuNo.Text.IndexOf(' '));
            txtMenuName.Text = cmbMenuNo.Text.Substring(cmbMenuNo.Text.IndexOf(' ') + 1, cmbMenuNo.Text.Length - cmbMenuNo.Text.IndexOf(' ') - 1);

        }

        private void frmAccountApproveRole_Load(object sender, EventArgs e)
        {
            dgvUserRequestStatus.AllowUserToAddRows = false;
            dgvData.AllowUserToAddRows = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            get_ws_template(cmbGroupNo, "Y");
        }

        private void get_ws_template(ComboBox tCmb, string tWSK)
        {
            //tField1 = 검색테이블
            //tField2 = 검색필드1
            //tField3 = 검색필드2

            Conn = new OleDbConnection(connect_string);

            string query = "";

            query = "  select groupNo , groupName from groupMaster ";
            query = query + " where appId  = '" + txtAppID.Text + "'";
            query = query + "      order by groupNo ";

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

        private void cmbGroupNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGroupNo.Text = cmbGroupNo.Text.Substring(0, cmbGroupNo.Text.IndexOf(' '));
        }

      

    }
}
