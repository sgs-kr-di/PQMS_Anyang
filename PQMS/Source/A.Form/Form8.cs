using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using PQMS.C.Unit;


namespace PQMS
{
    public partial class Form8 : MetroFramework.Forms.MetroForm
    {
        private Form8DataSet Form8Set;
        private OleDbConnection Conn;
        private UnitCommon unitCommon;


        public Form8()
        {
            InitializeComponent();
            Initialize();
            unitCommon = new UnitCommon();
        }

        private void Initialize()
        {
            Form8Set = new Form8DataSet(AppRes.DB.Connect, null, null);
        }

        private void get_folder_data(string tTable, string tField1, string tField2, ComboBox tCmb) //tField1 = 검색테이블       //tField2 = 검색필드1       //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE= '" + Form1PQMS_Repo.sSiteCode + "' and	REPOSITORY_CODE='" + Form1PQMS_Repo.sRepo + "'  and 	WS_CODE='" + Form1PQMS_Repo.sWS + "'  ";
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

        private void get_folder_data2(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2


        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + "  where EDU_ORG_CODE = '" + txtEDU_ORG_CODE.Text + "'";
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

        private void btnEduValidateInsert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form8Set.sEDU_ORG_CODE = txtEDU_ORG_CODE.Text;
                Form8Set.sVALI_PERIOD = txtVALI_PERIOD.Text;
                Form8Set.sVALI_DATE = txtVALI_DATE.Text;
                Form8Set.sVALI_ENABLE = txtVALI_ENABLE.Text;

                Form8Set.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");
            }
            catch (Exception f)
            {
                string test = f.ToString();
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!");
            }
        }

        private void btnEduValidateUpdate_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form8Set.sEDU_ORG_CODE = txtEDU_ORG_CODE.Text;
                Form8Set.sVALI_PERIOD = txtVALI_PERIOD.Text;
                Form8Set.sVALI_DATE = txtVALI_DATE.Text;
                Form8Set.sVALI_ENABLE = txtVALI_ENABLE.Text;

                Form8Set.Update(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("수정 완료!");
            }
            catch (Exception f)
            {
                string test = f.ToString();
                AppRes.DB.RollbackTrans();
                MessageBox.Show("수정 실패!");
            }
        }

        private void btnEduValidateDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form8Set.sEDU_ORG_CODE = txtEDU_ORG_CODE.Text;

                Form8Set.Delete(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("삭제 완료!");
            }
            catch (Exception f)
            {
                string test = f.ToString();
                AppRes.DB.RollbackTrans();
                MessageBox.Show("삭제 실패!");
            }
        }

        private void btnLookUpData_Click(object sender, EventArgs e)
        {
            Form8Set.sEDU_ORG_CODE = txtEDU_ORG_CODE.Text;
            try
            {
                Form8Set.Select();

                if (Form8Set.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_EDU_VALI_DATEGrid, Form8Set);
                    MessageBox.Show("조회 성공!");
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("조회 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void PQMS_EDU_VALI_DATEGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtEDU_ORG_CODE.Text = PQMS_EDU_VALI_DATEGridView.GetFocusedDataRow()["EDU_ORG_CODE"].ToString();
            txtVALI_PERIOD.Text = PQMS_EDU_VALI_DATEGridView.GetFocusedDataRow()["VALI_PERIOD"].ToString();
            txtVALI_DATE.Text = PQMS_EDU_VALI_DATEGridView.GetFocusedDataRow()["VALI_DATE"].ToString();
            txtVALI_ENABLE.Text = PQMS_EDU_VALI_DATEGridView.GetFocusedDataRow()["VALI_ENABLE"].ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder);
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEDU_ORG_CODE.Text = cmbFolder.Text.Substring(0, 4);
            txtOrgName.Text = cmbFolder.Text.Substring(5, cmbFolder.Text.Length - 5);
        }

        private void cmbValiTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVALI_PERIOD.Text = cmbValiTerm.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = cmbDateFormat.Text;
            txtVALI_DATE.Text = dateTimePicker1.Text;
        }

        private void cmbYN_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVALI_ENABLE.Text = cmbYN.Text;
        }

        private void btnGroup1_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_EDU", "EDU_CODE", "EDU_NAME", cmbGroup1);
        }

        private void cmbGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEDU_CODE.Text = cmbGroup1.Text.Substring(0, 4);
            txtEDU_NAME.Text = cmbGroup1.Text.Substring(5, cmbGroup1.Text.Length - 5);
        }
    }
}
