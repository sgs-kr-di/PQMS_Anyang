using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace userManagement
{
    public partial class frmCodeMaster : Form
    {
        public frmCodeMaster()
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

            string query = " select codeCategory " +
                         "     from CodeMaster with(nolock) " +
                         "    where codeCategory = '" + txtCodeCategory.Text.Trim() + "' " +
                         "          and code = '" + txtCode.Text.Trim() + "' " +
                         "          and Disuse = 0 ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        dupChk = "nok";
                        MessageBox.Show("코드 중복!");
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
                    " insert into CodeMaster     " +
                    " (codeCategory            , " +
                    " 	code                   , " +
                    " 	codeName               , " +
                    " 	from_Expiry_Date       , " +
                    " 	to_Expiry_Date         , " +
                    " 	description            , " +
                    " 	registeredBy           , " +
                    " 	registeredDate         , " +
                    "   modifiedBy             , " +
                    "   ModifiedDate           , " +
                    "   Disuse                 , " +
                    "   DisusedBy              , " +
                    "   DisusedDate              " +
                    " )                          " +
                    " Values                     " +
                    " (                          " +
                    " '" + txtCodeCategory.Text + "', " +
                    " '" + txtCode.Text + "', " +
                    " '" + txtCodeName.Text + "', " +
                    " '" + txtFrom_Expiry_Date.Text + "', " +
                    " '" + txtTo_Expiry_Date.Text + "', " +
                    " '" + txtDescription.Text + "', " +
                    " 'admin', " +
                    " getdate(), " +
                    " '', " +
                    " ''," +
                    " '" + Convert.ToInt32(rdoDisuse.Checked) + "', "  +
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

        private void btnUpd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("준비중!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("준비중!");
        }
    }
}
