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

namespace userManagement
{
    public partial class frmUserMaster : Form
    {
        public frmUserMaster()
        {
            InitializeComponent();
        }

        private OleDbConnection Conn;

        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";

        private void btnIns_Click(object sender, EventArgs e)
        {
            string dupChk = "";
            Conn = new OleDbConnection(connect_string);

            string query = " select userid " +
                            "     from userMaster " +
                            "    where userid = '" + txtUserId.Text.Trim() + "' ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        dupChk = "nok";
                        MessageBox.Show("아이디 중복!");
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
                query =
                    " insert into userMaster     " +
                    " (userID                 ,  " +
                    " 	firstName              ,  " +
                    " 	lastName               ,  " +
                    " 	companyId              ,  " +
                    " 	department             ,  " +
                    " 	empID                  ,  " +
                    " 	address1               ,  " +
                    " 	address2               ,  " +
                    " 	email                  ,  " +
                    " 	email_verification_code,  " +
                    " 	phone                  ,  " +
                    " 	phone_verification_code,  " +
                    " 	registeredBy           ,  " +
                    " 	registeredDate         ,  " +
                    "   modifiedBy             , " +
                    "   ModifiedDate             " +
                    " )                          " +
                    " Values                     " +
                    " (                          " +
                    " '" + txtUserId.Text + "', "   +
                    " '" + txtfirstName.Text + "', " +
                    " '" + txtLastName.Text + "', " +
                    " '" + txtCompany.Text + "', " +
                    " '" + txtDepartment.Text + "', " +
                    " '" + txtEmplId.Text + "', " +
                    " '" + txtAddress1.Text + "', " +
                    " '" + txtAddress2.Text + "', " +
                    " '" + txtEmail.Text + "', " +
                    " '', "+
                    " '" + txtPhone.Text + "', "+
                    " '', "+
                    " 'admin', "+
                    " getdate(), "+
                    " '', "+
                    " ''" +
                    " )";

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

        private void btnUpd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("준비중!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("준비중!");
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            Conn = new OleDbConnection(connect_string);

            string query = " select userid, firstName, lastName " +
                            "     from userMaster "; //+
                            //"    where userid = '" + txtUserId.Text.Trim() + "' ";

            DataSet ds = new System.Data.DataSet();
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            int wRowNo = 0;
            int i = 0;            

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {                    
                    dgvUserMaster.ColumnCount = reader.FieldCount;
                    

                    for (i = 0; i < reader.FieldCount; i++)
                    {
                        dgvUserMaster.Columns[i].HeaderText = reader.GetName(i).ToString();
                        if (i == 1)
                        {
                            //dgvUserRequestStatus.Columns[i].Width = 40;
                            //dgvUserRequestStatus.Columns[i].Visible = false;

                            dgvUserMaster.Columns[i].Width = 100;
                            //dgvUserMaster.Columns[i].Visible = true;
                        }
                        else
                        {
                            if (i == 2)
                            {
                                dgvUserMaster.Columns[i].Width = 300;
                            }
                            else
                            {
                                dgvUserMaster.Columns[i].Width = 500;
                            }
                        }
                    }
                    while (reader.Read())
                    {
                        dgvUserMaster.RowCount = wRowNo + 1;

                        for (i = 0; i < reader.FieldCount; i++)
                        {                            
                            dgvUserMaster.Rows[wRowNo].Cells[i].Value = reader.GetValue(i);
                        }
                        wRowNo = wRowNo + 1;
                        dgvUserMaster.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();
                    }
                }
                else 
                {
                    MessageBox.Show("데이터 없음");
                }
            }
            Conn.Close();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            frmAccountManager frmAccountManager = new frmAccountManager();
            frmAccountManager.Show();
        }

    }
}
