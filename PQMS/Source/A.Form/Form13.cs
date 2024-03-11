using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using PQMS.C.Unit;

namespace PQMS
{
    public partial class Form13 : MetroFramework.Forms.MetroForm
    {
        private Form13DataSet Form13Set;
        
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        public Form13()
        {
            InitializeComponent();
            Initialize();

            unitCommon = new UnitCommon();
        }

        private void Initialize()
        {
            Form13Set = new Form13DataSet(AppRes.DB.Connect, null, null);
        }

        private void get_folder_data(string tTable, string tField1, string tField2, ComboBox tCmb)        //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + " where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
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

        private void btnRoleInsert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form13Set.sROLE_ORG_CODE = txtROLE_ORG_CODE.Text;
                Form13Set.sROLE_CODE = txtROLE_CODE.Text;
                Form13Set.sROLE_NAME = txtROLE_NAME.Text;

                Form13Set.Insert(trans);
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
                Form13Set.sROLE_ORG_CODE = txtROLE_ORG_CODE.Text;
                Form13Set.sROLE_CODE = txtROLE_CODE.Text;
                Form13Set.sROLE_NAME = txtROLE_NAME.Text;

                Form13Set.Update(trans);
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
                Form13Set.sROLE_ORG_CODE = txtROLE_ORG_CODE.Text;

                Form13Set.Delete(trans);
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
            Form13Set.sROLE_ORG_CODE = txtROLE_ORG_CODE.Text;
            try
            {
                Form13Set.Select();

                if (Form13Set.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ROLEGrid, Form13Set);
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

        private void PQMS_ROLEGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtROLE_ORG_CODE.Text = PQMS_ROLEGridView.GetFocusedDataRow()["ROLE_ORG_CODE"].ToString();
            txtROLE_CODE.Text = PQMS_ROLEGridView.GetFocusedDataRow()["ROLE_CODE"].ToString();
            txtROLE_NAME.Text = PQMS_ROLEGridView.GetFocusedDataRow()["ROLE_NAME"].ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder);
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtROLE_ORG_CODE.Text = cmbFolder.Text.Substring(0, 4);
            txtOrgName.Text = cmbFolder.Text.Substring(5, cmbFolder.Text.Length - 5);
        }
    }
}
