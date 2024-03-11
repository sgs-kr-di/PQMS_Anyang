﻿using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using PQMS.C.Unit;

namespace PQMS
{
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        private Form5DataSet Form5Set;
        private OleDbConnection Conn;
        private UnitCommon unitCommon;

        public Form5()
        {
            InitializeComponent();
            Initialize();
            unitCommon = new UnitCommon();
        }

        private void Initialize()
        {
            Form5Set = new Form5DataSet(AppRes.DB.Connect, null, null);
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

        private void btnOrgInsert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form5Set.sORG_CODE = txtORG_CODE.Text;
                Form5Set.sORG_NAME = txtORG_NAME.Text;

                Form5Set.Insert(trans);
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

        private void btnOrgUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("수정하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();

                try
                {
                    Form5Set.sORG_CODE = txtORG_CODE.Text;
                    Form5Set.sORG_NAME = txtORG_NAME.Text;

                    Form5Set.Update(trans);
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

        private void btnOrgDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "Message Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlTransaction trans = AppRes.DB.BeginTrans();

                try
                {
                    Form5Set.sORG_CODE = txtORG_CODE.Text;

                    Form5Set.Delete(trans);
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
            else
            {

            }
        }

        private void btnLookUpData_Click(object sender, EventArgs e)
        {
            Form5Set.sORG_CODE = txtORG_CODE.Text;
            try
            {
                Form5Set.Select();

                if (Form5Set.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_ORGGrid, Form5Set);
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

        private void PQMS_ORGGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtORG_CODE.Text = PQMS_ORGGridView.GetFocusedDataRow()["ORG_CODE"].ToString();
            txtORG_NAME.Text = PQMS_ORGGridView.GetFocusedDataRow()["ORG_NAME"].ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder);
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtORG_CODE.Text = cmbFolder.Text.Substring(0, 4);
            txtORG_NAME.Text = cmbFolder.Text.Substring(5, cmbFolder.Text.Length - 5);
        }
    }
}
