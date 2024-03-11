using System;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Collections.Generic;
using System.Data;
using System.Drawing;

using DevExpress.Data;
using DevExpress.XtraEditors;
using PQMS.C.Unit;
using Ulee.Controls;
using System.Data.OleDb;

namespace PQMS
{
    public partial class Form9 : MetroFramework.Forms.MetroForm
    {
        private Form9DataSet Form9Set;
        private GridBookmark PQMS_GROUP1Bookmark;
        public List<Form9PagePQMS_GROUP1Rows> PQMS_GROUP1GridRows;

        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        public Form9()
        {
            InitializeComponent();
            Initialize();
            unitCommon = new UnitCommon();
        }


        private void Initialize()
        {
            Form9Set = new Form9DataSet(AppRes.DB.Connect, null, null);
            PQMS_GROUP1Bookmark = new GridBookmark(PQMS_GROUP1GridView);
            PQMS_GROUP1GridRows = new List<Form9PagePQMS_GROUP1Rows>();
            PQMS_GROUP1Grid.DataSource = PQMS_GROUP1GridRows;
            AppHelper.SetGridEvenRow(PQMS_GROUP1GridView);
        }

        private Form9PagePQMS_GROUP1Rows NewPQMS_GROUP1GridRows()
        {
            Form9PagePQMS_GROUP1Rows row = new Form9PagePQMS_GROUP1Rows();

            row.sGROUP1_ORG_CODE = "";
            row.sGROUP1_CODE = "";
            row.sGROUP1_NUM = "";
            row.sGROUP1_NAME = "";

            return row;
        }

        private void get_folder_data(string tTable, string tField1, string tField2, System.Windows.Forms.ComboBox tCmb)        //tField1 = 검색테이블        //tField2 = 검색필드1        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query +  $" where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'"; 
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

        private void btnGroup1Insert_Click(object sender, EventArgs e)
        {            
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {                
                Form9Set.sGROUP1_ORG_CODE = txtGROUP1_ORG_CODE.Text; ;
                Form9Set.sGROUP1_CODE = txtGROUP1_CODE.Text;
                Form9Set.sGROUP1_NUM = txtGROUP1_NUM.Text;
                Form9Set.sGROUP1_NAME = txtGROUP1_NAME.Text;

                Form9Set.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");
            }
            catch (Exception f)
            {
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void btnGroup1Update_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("수정하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();
                try
                {
                    Form9Set.sGROUP1_ORG_CODE = txtGROUP1_ORG_CODE.Text;
                    Form9Set.sGROUP1_CODE = txtGROUP1_CODE.Text;
                    Form9Set.sGROUP1_NUM = txtGROUP1_NUM.Text;
                    Form9Set.sGROUP1_NAME = txtGROUP1_NAME.Text;

                    Form9Set.Update(trans);
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

        private void btnGroup1Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();
                try
                {
                    Form9Set.sGROUP1_ORG_CODE = txtGROUP1_ORG_CODE.Text;
                    Form9Set.sGROUP1_CODE = txtGROUP1_CODE.Text;

                    Form9Set.Delete(trans);
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

        private void ReorderPQMS_GROUP1GridRows()
        {            
            for (int i = 0; i < PQMS_GROUP1GridRows.Count; i++)
            {
                //PQMS_GROUP1GridRows[i].No = i;
            }            
        }

        private void btnLookUpData_Click(object sender, EventArgs e)
        {
            Form9Set.sGROUP1_ORG_CODE = txtGROUP1_ORG_CODE.Text;
            try
            {
                Form9Set.Select();
            
                if (Form9Set.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_GROUP1Grid, Form9Set);
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

        private void PQMS_GROUP1RowMinusBtn_Click(object sender, EventArgs e)
        {
            /*
            int index = p5StuffGridView.FocusedRowHandle;

            if (index < 0) return;

            p5Bookmark.Get();
            P5Rows.RemoveAt(index);

            ReorderP5Rows();
            AppHelper.RefreshGridData(p5StuffGridView);

            p5Bookmark.Goto();

            p5StuffGrid.Focus();
            */
        }
        
        private void PQMS_GROUP1RowPlusBtn_Click(object sender, EventArgs e)
        {
            int index = PQMS_GROUP1GridView.FocusedRowHandle;

            PQMS_GROUP1Bookmark.Get();

            if ((index < 0) || (index == PQMS_GROUP1GridRows.Count - 1))
            {
                PQMS_GROUP1GridRows.Add(NewPQMS_GROUP1GridRows());
            }
            else
            {
                PQMS_GROUP1GridRows.Insert(index + 1, NewPQMS_GROUP1GridRows());
            }

            //ReorderPQMS_GROUP1GridRows();
            AppHelper.RefreshGridData(PQMS_GROUP1GridView);

            PQMS_GROUP1Bookmark.Goto();
            PQMS_GROUP1GridView.MoveBy(1);

            PQMS_GROUP1Grid.Focus();
        }

        private void PQMS_GROUP1GridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtGROUP1_ORG_CODE.Text = PQMS_GROUP1GridView.GetFocusedDataRow()["GROUP1_ORG_CODE"].ToString();
            txtGROUP1_CODE.Text = PQMS_GROUP1GridView.GetFocusedDataRow()["GROUP1_CODE"].ToString();
            txtGROUP1_NUM.Text = PQMS_GROUP1GridView.GetFocusedDataRow()["GROUP1_NUM"].ToString();
            txtGROUP1_NAME.Text = PQMS_GROUP1GridView.GetFocusedDataRow()["GROUP1_NAME"].ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder);
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGROUP1_ORG_CODE.Text = cmbFolder.Text.Substring(0, 4);
            txtOrgName.Text = cmbFolder.Text.Substring(5, cmbFolder.Text.Length - 5);
        }
    }
}
