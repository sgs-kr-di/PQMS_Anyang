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
using System.Data.SqlClient;

namespace userManagement
{
    public partial class frmChoiceApprover : Form
    {
        public frmChoiceApprover()
        {
            InitializeComponent();
        }

        public String approveNo = string.Empty;

        public frmChoiceApprover(String approveNo)
        {
            InitializeComponent();
            this.approveNo = approveNo;
        }

        private OleDbConnection Conn;

        public string connect_string =
                          "data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster;User ID=dev01;Password=dev010207";

        private DataTable dt = new DataTable();

        private void frmChoiceApprover_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("logInID", typeof(string));

            dgvApprover.DataSource = dt;

            dt.Clear();
            using (SqlConnection conn = new SqlConnection(connect_string))
            {
                StringBuilder sql = new StringBuilder();

                sql.Append(@"   select t4.logInID
                                from [dbo].[approveRole] as t1
                                inner join groupmaster as t2
                                on t1.groupno = t2.groupno
                                inner join groupmembermaster as t3
                                on t2.groupno = t3.groupno
                                inner join accountMaster as t4
                                on t3.accountNo = t4.accountNo
                                where t4.appid ='USERMANAGEMENT'
                                and roledepth = 
				                                (
				                                select roledepth
				                                from [dbo].[approveRole] as t1
				                                inner join groupmaster as t2
				                                on t1.groupno = t2.groupno
				                                inner join groupmembermaster as t3
				                                on t2.groupno = t3.groupno
				                                inner join accountMaster as t4
				                                on t3.accountNo = t4.accountNo
				                                where t4.logInID = 'dongha.lee@sgs.com' and t4.appid ='USERMANAGEMENT'
				                                ) - 1
                              ");
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
                else
                {
                    //현재 내가 최상위자 일때
                    approveNoProcess(this.approveNo, true);
                }

                reader.Close();
                conn.Close();
            }
        }

        private void dgvApprover_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex + ", " + e.RowIndex);

            String approver = String.Empty;

            if (e.ColumnIndex > -1 && e.RowIndex != -1)
            {
                approver = dgvApprover.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();

                txtApproveNoTest.Text = this.approveNo;
                txtApproveNoTest.Text += ", " + approver;
            }

            approveNoProcess(approver, false);


        }

        private void approveNoProcess(String approver, Boolean approveFinal)
        {
            Conn = new OleDbConnection(connect_string);
            String query = String.Empty;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            if (approveFinal)
            {
                cmd = new OleDbCommand(query, Conn);

                query = " update accountMaster set approvedBy = ";



                Conn.Open();
                cmd.ExecuteNonQuery();
                Conn.Close();
            }

            cmd = new OleDbCommand(query, Conn);

            //query =
            //        " insert into accountMaster     " +
            //        "  ( " +
            //        " 	logInID      ,  " +
            //        " 	userID      ,  " +
            //        " 	appID         ,  " +
            //        " 	password      ,  " +
            //        " 	requestStatus ,  " +
            //        " 	registeredBy  ,  " +
            //        " 	registeredDate,  " +
            //        " 	approvedBy    ,  " +
            //        " 	approvedDate,     " +
            //        " 	modifiedBy    ,  " +
            //        "   ModifiedDate           , " +
            //        "   Disuse                 , " +
            //        "   DisusedBy              , " +
            //        "   DisusedDate              " +
            //        " )                           " +
            //        " Values                      " +
            //        " (                           " +
            //        " '" + txtLogInId.Text + "', " +
            //        " '" + txtUserId.Text + "', " +
            //        " '" + txtAppId.Text + "', " +
            //        " '" + txtPassword.Text + "', " +
            //        " '" + txtRequestStatus.Text + "', " +
            //        " 'admin', " +
            //        " getdate(), " +
            //        " '" + txtApprovedBy.Text + "', " +
            //        " getdate(), " +
            //        " '', " +
            //        " ''," +
            //        " '" + Convert.ToInt32(rdoDisuse.Checked) + "', " +
            //        " '" + disuseChecker + "', " +
            //        disuseDate +
            //        " )";

            cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();
        }
    }
}
