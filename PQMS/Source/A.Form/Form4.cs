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

namespace PQMS
{
    public partial class Form4 : Form
    {
        private Form4DataSet Form4Set;

        public Form4()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Form4Set = new Form4DataSet(AppRes.DB.Connect, null, null);
        }

        private void btnStaffcertiInsert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form4Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
                Form4Set.sSTAFF_CERTI_ROLE = txtSTAFF_CERTI_ROLE.Text;
                Form4Set.sSTAFF_CERTI_NAME = txtSTAFF_CERTI_NAME.Text;
                Form4Set.sSTAFF_CERTI_DATE = txtSTAFF_CERTI_DATE.Text;
                Form4Set.sSTAFF_CERTI_FILE = txtSTAFF_CERTI_FILE.Text;

                Form4Set.Insert(trans);
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

        private void btnStaffcertiUpdate_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form4Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
                Form4Set.sSTAFF_CERTI_ROLE = txtSTAFF_CERTI_ROLE.Text;
                Form4Set.sSTAFF_CERTI_NAME = txtSTAFF_CERTI_NAME.Text;
                Form4Set.sSTAFF_CERTI_DATE = txtSTAFF_CERTI_DATE.Text;
                Form4Set.sSTAFF_CERTI_FILE = txtSTAFF_CERTI_FILE.Text;

                Form4Set.Update(trans);
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

        private void btnStaffcertiDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form4Set.sSTAFF_CODE = txtSTAFF_CODE.Text;

                Form4Set.Delete(trans);
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
            Form4Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
            try
            {
                Form4Set.Select();

                if (Form4Set.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_CERTIGrid, Form4Set);
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

        private void PQMS_STAFF_CERTIGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtSTAFF_CODE.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CODE"].ToString();
            txtSTAFF_CERTI_ROLE.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_ROLE"].ToString();
            txtSTAFF_CERTI_NAME.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_NAME"].ToString();
            txtSTAFF_CERTI_DATE.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_DATE"].ToString();
            txtSTAFF_CERTI_FILE.Text = PQMS_STAFF_CERTIGridView.GetFocusedDataRow()["STAFF_CERTI_FILE"].ToString();
        }
    }
}
