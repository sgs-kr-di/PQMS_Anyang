using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Collections;

using System.Xml;
using System.Reflection;
using System.IO;
using System.Globalization;

using System.Data.OleDb;

using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;


namespace userManagement
{
    public partial class frmUserIdRequest : Form
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
            textBox1.Text = textBox1.Text + "loginId : " + loginId + (char)10 + (char)13;
            textBox1.Text = textBox1.Text + "userId : " + userId + (char)10 + (char)13;
            textBox1.Text = textBox1.Text + "accountNo : " + accountNo + (char)10 + (char)13;
            textBox1.Text = textBox1.Text + "appId : " + accountNo + (char)10 + (char)13;

            get_approval_right();

        }

        private void get_approval_right()
        {

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
                txtuserID.Text = dgvUserRequestStatus.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                //txtApproveNoTest.Text = approveNo;
            }

            //MessageBox.Show(e.ColumnIndex + ", " + e.RowIndex);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            Modi_rtn();
            save_item();
        }

        private void Modi_rtn()
        {
            Conn = new OleDbConnection(connect_string);
            string query = "";

            ////query = "UPDATE K_SITE  SET ";
            ////query = query + " SITE_NAME  = N'" + txtSiteName.Text.Trim() + "'";
            ////query = query + " WHERE SITE_CODE = '" + txtSiteCode.Text.Trim() + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        private void save_item()
        {
            Conn = new OleDbConnection(connect_string);
            string query = "";

            //query = "INSERT INTO K_SITE VALUES ( ";
            //query = query + "'" + txtSiteCode.Text.Trim() + "',";
            //query = query + "N'" + txtSiteName.Text.Trim() + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();

            MessageBox.Show(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = textBox1.Text + "loginId : " + loginId + (char)10 + (char)13;
            textBox1.Text = textBox1.Text + "userId : " + userId + (char)10 + (char)13;
            textBox1.Text = textBox1.Text + "accountNo : " + accountNo + (char)10 + (char)13;
            textBox1.Text = textBox1.Text + "appId : " + accountNo + (char)10 + (char)13;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Get_Data();
        }

        private void Get_Data()
        {
            Conn = new OleDbConnection(connect_string);

            ////dgvUserRequestStatus.Rows.Clear();

            string query = "";

            query = " select * ";
            query = query + " from usermaster ";
            query = query + "  where userId not in (select userId from accountMaster)";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            dgvUserRequestStatus.RowCount = 10;

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