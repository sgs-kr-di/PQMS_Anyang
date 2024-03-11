﻿using System;
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
    public partial class frmAccountManager : Form
    {
        public frmAccountManager()
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

            string query = " select accountNo " +
                         "     from accountMaster " +
                         "    where logInID = '" + txtLogInId.Text.Trim() + "' " +
                         "      and appID  = '" + txtAppId.Text.Trim() + "' ";

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

                String disuseChecker = "";
                String disuseDate = "''";

                if (rdoDisuse.Checked)
                {
                    disuseChecker = "admin";
                    disuseDate = "getdate()";
                }

                query =
                    " insert into accountMaster     " +
                    "  ( "  +
                    " 	logInID      ,  " +
                    " 	userID      ,  " +
                    " 	appID         ,  " +
                    " 	password      ,  " +
                    " 	requestStatusCode,  " +
                    " 	registeredBy  ,  " +
                    " 	registeredDate,  " +
                    " 	approvedBy    ,  " +
                    " 	approvedDate,     " +
                    " 	modifiedBy    ,  " +
                    "   ModifiedDate           , " +
                    "   Disuse                 , " +
                    "   DisusedBy              , " +
                    "   DisusedDate              " +
                    " )                           " +
                    " Values                      " +
                    " (                           " +
                    " '" + txtLogInId.Text + "', " +
                    " '" + txtUserId.Text + "', " +
                    " '" + txtAppId.Text + "', " +
                    " '" + txtPassword.Text + "', " +
                    " '" + txtRequestStatus.Text + "', " +
                    " 'admin', " +
                    " getdate(), " +
                    " '" + txtApprovedBy.Text + "', " +
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
