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

namespace PQMS
{
    public partial class frmGroupMemberMaster : MetroFramework.Forms.MetroForm
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

        public frmGroupMemberMaster()
        {
            InitializeComponent();
        }

        private OleDbConnection Conn;
        private OleDbConnection Conn1;

        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";

        private void btnIns_Click(object sender, EventArgs e)
        {
            string dupChk = "";
            int tgroupMemberNo = 0;
            Conn = new OleDbConnection(connect_string);

            string query = " select groupMemberNo " +
                         "     from groupMemberMaster " +
                         "    where groupMemberNo = '" + txtGroupMemberNo.Text.Trim() + "'; "; 

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        dupChk = "nok";
                        tgroupMemberNo = Convert.ToInt32(reader.GetValue(0).ToString()); 
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
                insert_new();
            }
            else
            {
                //delete_menuRole();
                update_old(tgroupMemberNo);
            }

            MessageBox.Show("지정 완료!");
            Get_Data("앱별그룹별");

            foreach (Control ControlTextBoxClear in this.Controls)
            {
                if (typeof(TextBox) == ControlTextBoxClear.GetType())
                {
                    (ControlTextBoxClear as TextBox).Text = "";
                }
            }

            txtAppNo.Text = "3";
            txtAppId.Text = "PQMS";


        }

        private void update_old(int tgroupMemberNo)
        {
            string query = "";
            Conn = new OleDbConnection(connect_string);

            query =
                " update groupMemberMaster " +
                "  set groupNo = " + txtGroupNo.Text.Trim() + "  " +
                " 	where groupMemberNo   = " + tgroupMemberNo + ";";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

        }

        private void delete_menuRole()
        {
            string query = "";

            Conn = new OleDbConnection(connect_string);

            query = " select t4.menuRoleNo " +
            " from accountMaster as t1 with(nolock)" +
            "                       inner join groupmembermaster as t2 with(nolock)" +
            "                                on (t1.accountNo = t2.accountNo" +
            "                                    and t1.disuse <> '1'" +
            "                                    and t2.disuse <> '1')" +
            "                       inner join groupmaster as t3 with(nolock)" +
            "                                on (t2.groupNo = t3.groupNo" +
            "                                    and t3.disuse <> '1')" +
            "                       inner join menurole as t4 with(nolock)" +
            "                               on (t3.groupNo = t4.groupNo" +
            "                                     and t4.disuse <> '1')" +
            "                       inner join menumaster as t5 with(nolock)" +
            "                                 on (t4.menuno = t5.menuNo" +
            "                                      and t5.disuse <> '1')" +
            "  where t1.appID = '" + txtAppId.Text + "'" +
            "  and t1.loginID = '" + txtLoginID.Text +  "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        delete_row(reader.GetValue(0).ToString());
                    }
                }
            }

            Conn.Close();
        }

        private void delete_row(string tMenuRoleNo)
        {
            string query = "";
            Conn1 = new OleDbConnection(connect_string);

            query =
                " delete from menuRole " +
                " 	where menuRoleNo   = " + tMenuRoleNo + ";"; 

            OleDbCommand cmd = new OleDbCommand(query, Conn1);

            Conn1.Open();
            cmd.ExecuteNonQuery();
            Conn1.Close();
        }

        private void insert_new()
        {
            String disuseChecker = "";
            String disuseDate = "''";

            if (rdoDisuse.Checked)
            {
                disuseChecker = "admin";
                disuseDate = "getdate()";
            }

            string query = "";
            Conn = new OleDbConnection(connect_string);

            query =
                " insert into groupMemberMaster     " +
                "  (groupNo        ,  " +
                " 	accountNo      ,  " +
                " 	registeredBy  ,  " +
                " 	registeredDate,  " +
                " 	modifiedBy    ,  " +
                " 	ModifiedDate,     " +
                "   Disuse                 , " +
                "   DisusedBy              , " +
                "   DisusedDate              " +
                " )                           " +
                " Values                      " +
                " (                           " +
                " '" + txtGroupNo.Text + "',   " +
                " '" + txtAccountNo.Text + "',   " +
                " 'admin', " +
                " getdate(), " +
                " '', " +
                " '', " +
                " '" + Convert.ToInt32(rdoDisuse.Checked) + "', " +
                " '" + disuseChecker + "', " +
                disuseDate +
                " )";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("준비중!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 삭제하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Conn = new OleDbConnection(connect_string);
                string query = "";

                query = "DELETE ";
                query = query + " FROM groupMemberMaster ";
                query = query + " WHERE groupNo = '" + txtGroupNo.Text.Trim() + "'";
                query = query + " and accountNo = '" + txtAccountNo.Text.Trim() + "'";

                OleDbCommand cmd = new OleDbCommand(query, Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            else
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Get_Data("전체");
        }

        private void Get_Data(string idx)
        {
            Conn = new OleDbConnection(connect_string);

            ////dgvUserRequestStatus.Rows.Clear();

            string query = "";



            if (idx == "전체")
            {
                query = " select a.groupMemberNo, b.groupNo, b.groupName, a.accountNo, c.logInID ";
                query = query + " from groupMemberMaster a inner join groupMaster b on (a.groupNo = b.groupNo) ";
                query = query + "                          inner join accountMaster c on (a.accountNo = c.accountNo) ";
                query = query + " where  1 = 1 ";
                query = query + "  order by b.groupNo, a.accountNo";

            }
            else if (idx == "앱별")
            {
                if (txtAppNo.Text != "")
                {
                    query = " select a.groupMemberNo, b.groupNo, b.groupName, a.accountNo, c.logInID ";
                    query = query + " from groupMemberMaster a inner join groupMaster b on (a.groupNo = b.groupNo) ";
                    query = query + "                          inner join accountMaster c on (a.accountNo = c.accountNo) ";
                    query = query + " where  1 = 1 ";
                    query = query + "   and b.appId = '" + txtAppId.Text + "'";
                    query = query + "  order by b.groupNo, a.accountNo";

                }
                else
                {
                    MessageBox.Show("앱을 선택하세요.");
                    return;
                }
            }
            else if (idx == "앱별그룹별")
            {
                if (txtAppNo.Text != "" && txtGroupNo.Text != "")
                {
                    query = " select a.groupMemberNo, b.groupNo, b.groupName, a.accountNo, c.logInID ";
                    query = query + " from groupMemberMaster a inner join groupMaster b on (a.groupNo = b.groupNo) ";
                    query = query + "                          inner join accountMaster c on (a.accountNo = c.accountNo) ";
                    query = query + " where  1 = 1 ";
                    query = query + "   and b.appId = '" + txtAppId.Text + "'";
                    query = query + "   and a.groupNo = " + txtGroupNo.Text + "";
                    query = query + "  order by b.groupNo, a.accountNo";
                }
                else
                {
                    MessageBox.Show("메뉴 그룹을 선택하세요.");
                    return;
                }
            }

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            //그리드 클리어
            dgvUserRequestStatus.DataSource = null;
            dgvUserRequestStatus.Columns.Clear();
            dgvUserRequestStatus.Rows.Clear();
            dgvUserRequestStatus.Refresh();

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

        private void button1_Click(object sender, EventArgs e)
        {
            get_ws_template(cmbGroupNo, "Y");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            get_ws_template1(cmbAccoutNo, "Y");
        }

        private void get_ws_template(ComboBox tCmb, string tWSK)
        {
            //tField1 = 검색테이블
            //tField2 = 검색필드1
            //tField3 = 검색필드2



            Conn = new OleDbConnection(connect_string);

            string query = "";

            query = "  select groupNo , groupName from groupMaster ";
            query = query + " where appId  = '" + txtAppId.Text + "'";
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

        private void get_ws_template1(ComboBox tCmb, string tWSK)
        {
            //tField1 = 검색테이블
            //tField2 = 검색필드1
            //tField3 = 검색필드2



            Conn = new OleDbConnection(connect_string);

            string query = "";

            query = "  select a.accountNo , a.logInID from accountMaster  a  ";
            query = query + " inner join accountStaffDept b on a.accountNo = b.accountNo ";
            query = query + " where a.appId  = '" + txtAppId.Text + "'";
            query = query + "  and b.SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE='" + Form1PQMS_Repo.sWS + "' ";
            query = query + "  order by a.accountNo ";

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

        private void cmbAccoutNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAccountNo.Text = cmbAccoutNo.Text.Substring(0, cmbAccoutNo.Text.IndexOf(' '));
            txtLoginID.Text = cmbAccoutNo.Text.Substring(cmbAccoutNo.Text.IndexOf(' ') + 1, cmbAccoutNo.Text.Length - cmbAccoutNo.Text.IndexOf(' ') - 1);

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
            txtAppId.Text = cmbAppID.Text.Substring(cmbAppID.Text.IndexOf(' ') + 1, cmbAppID.Text.Length - cmbAppID.Text.IndexOf(' ') - 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Get_Data("앱별");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Get_Data("앱별그룹별");
        }

        private void txtGroupNo_TextChanged(object sender, EventArgs e)
        {
            //Get_Data("앱별그룹별");
        }

        private void dgvUserRequestStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                txtGroupMemberNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtGroupNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtAccountNo.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                txtLoginID.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
            }
        }
    }
}
