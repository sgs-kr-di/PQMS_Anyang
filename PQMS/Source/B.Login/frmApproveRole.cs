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
    public partial class frmApproveRole : Form
    {
        public frmApproveRole()
        {
            InitializeComponent();
        }
        
        private OleDbConnection Conn;

        public string connect_string =
                          "Provider=SQLOLEDB.1;User ID=dev01;pwd=dev010207;data source=KRSEC001;Persist Security Info=True;initial catalog=accountMaster";

        private void btnUpd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("준비중!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("준비중!");
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            string dupChk = "";
            Conn = new OleDbConnection(connect_string);

            string query = " select approveRoleNo " +
                         "     from approveRole " +
                         "    where groupNo = '" + txtGroupNo.Text.Trim() + "' " +
                         "      and roleDepth = '" + txtRoleDepth.Text.Trim() + "' ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
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

                if (rdoDisuse.Checked)
                {
                    disuseChecker = "admin";
                    disuseDate = "getdate()";
                }

                query =
                    " insert into approveRole     " +
                    "  ( " +
                    "   groupNo         ," +
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
                    " '" + txtGroupNo.Text + "', " +
                    " '" + txtRoleDepth.Text + "', " +
                    " 'admin', " +
                    " getdate(), " +
                    " '', " +
                    " ''," +
                    " '" + Convert.ToInt32(rdoDisuse.Checked) + "', " +
                    " '" + disuseChecker + "', " +
                    disuseDate +
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
    }
}
