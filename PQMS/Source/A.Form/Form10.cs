using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ulee.Controls;
using Ulee.Utils;
using System.Data.OleDb;
using PQMS.C.Unit;

namespace PQMS
{
    public partial class Form10 : MetroFramework.Forms.MetroForm
    {
        private Form10DataSet Form10Set;        
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        public Form10()
        {
            InitializeComponent();
            Initialize();

            unitCommon = new UnitCommon();
        }

        private void Initialize()
        {
            Form10Set = new Form10DataSet(AppRes.DB.Connect, null, null);
        }

        private void get_folder_data(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)        //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2
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

        private void get_folder_data2(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)        //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + "  where GROUP1_ORG_CODE = '" + txtGROUP2_ORG_CODE.Text + "'";
            query = query + "  and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
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

        private void btnGroup2Insert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form10Set.sGROUP2_ORG_CODE = txtGROUP2_ORG_CODE.Text;
                Form10Set.sGROUP2_GROUP1_CODE = txtGROUP2_GROUP1_CODE.Text;
                Form10Set.sGROUP2_CODE = txtGROUP2_CODE.Text;
                Form10Set.sGROUP2_NAME = txtGROUP2_NAME.Text;

                Form10Set.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void btnGroup2Update_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("수정하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();
                try
                {
                    Form10Set.sGROUP2_ORG_CODE = txtGROUP2_ORG_CODE.Text;
                    Form10Set.sGROUP2_GROUP1_CODE = txtGROUP2_GROUP1_CODE.Text;
                    Form10Set.sGROUP2_CODE = txtGROUP2_CODE.Text;
                    Form10Set.sGROUP2_NAME = txtGROUP2_NAME.Text;

                    Form10Set.Update(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("수정 완료!");
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("수정 실패!" + Environment.NewLine + f.Message);
                }
            }
            else
            {

            }
        }

        private void btnGroup2Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();
                try
                {
                    Form10Set.sGROUP2_ORG_CODE = txtGROUP2_ORG_CODE.Text;
                    Form10Set.sGROUP2_GROUP1_CODE = txtGROUP2_GROUP1_CODE.Text;
                    Form10Set.sGROUP2_CODE = txtGROUP2_CODE.Text;

                    Form10Set.Delete(trans);
                    AppRes.DB.CommitTrans();

                    MessageBox.Show("삭제 완료!");
                }
                catch (Exception f)
                {
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("삭제 실패!" + Environment.NewLine + f.Message);
                }
            }
            else
            {

            }
        }

        private void btnLookUpData_Click(object sender, EventArgs e)
        {
            Form10Set.sGROUP2_ORG_CODE = txtGROUP2_ORG_CODE.Text;

            try
            {
                Form10Set.Select();

                if (Form10Set.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_GROUP2Grid, Form10Set);
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

        private void PQMS_GROUP2GridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtGROUP2_ORG_CODE.Text = PQMS_GROUP2GridView.GetFocusedDataRow()["GROUP2_ORG_CODE"].ToString();
            txtGROUP2_GROUP1_CODE.Text = PQMS_GROUP2GridView.GetFocusedDataRow()["GROUP2_GROUP1_CODE"].ToString();
            txtGROUP2_CODE.Text = PQMS_GROUP2GridView.GetFocusedDataRow()["GROUP2_CODE"].ToString();
            txtGROUP2_NAME.Text = PQMS_GROUP2GridView.GetFocusedDataRow()["GROUP2_NAME"].ToString();

            // DataRow 형식으로 값 가져오기
            //DataRow row = PQMS_GROUP2GridView.GetDataRow(PQMS_GROUP2GridView.FocusedRowHandle);

            // DataRow Idex값 가져오기
            //var visibleidex = this.PQMS_GROUP2GridView.GetSelectedRows().ToList();
            //if (visibleidex[0] < 0) return;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder);
        }

        private void btnGroup1_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", cmbGroup1);
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGROUP2_ORG_CODE.Text = cmbFolder.Text.Substring(0, 4);
            txtOrgName.Text = cmbFolder.Text.Substring(5, cmbFolder.Text.Length - 5);
        }

        private void cmbGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGROUP2_GROUP1_CODE.Text = cmbGroup1.Text.Substring(0, 4);
            txtBig.Text = cmbGroup1.Text.Substring(5, cmbGroup1.Text.Length - 5);
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
    }
} 