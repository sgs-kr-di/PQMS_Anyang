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

namespace PQMS
{
    public partial class Form11 : Form
    {
        private Form11DataSet Form11Set;

        public Form11()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Form11Set = new Form11DataSet(AppRes.DB.Connect, null, null);
        }

        private void btnTeamInsert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form11Set.sTEAM_CODE = txtTEAM_CODE.Text;
                Form11Set.sTEAM_NAME = txtTEAM_NAME.Text;
                Form11Set.sTEAM_NAME2 = txtTEAM_NAME2.Text;

                Form11Set.Insert(trans);
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

        private void btnTeamUpdate_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form11Set.sTEAM_CODE = txtTEAM_CODE.Text;
                Form11Set.sTEAM_NAME = txtTEAM_NAME.Text;
                Form11Set.sTEAM_NAME2 = txtTEAM_NAME2.Text;

                Form11Set.Update(trans);
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

        private void btnTeamDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form11Set.sTEAM_CODE = txtTEAM_CODE.Text;

                Form11Set.Delete(trans);
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
            Form11Set.sTEAM_CODE = txtTEAM_CODE.Text;
            try
            {
                Form11Set.Select();
            
                if (Form11Set.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_TEAMGrid, Form11Set);
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

        private void PQMS_TEAMGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtTEAM_CODE.Text = PQMS_TEAMGridView.GetFocusedDataRow()["TEAM_CODE"].ToString();
            txtTEAM_NAME.Text = PQMS_TEAMGridView.GetFocusedDataRow()["TEAM_NAME"].ToString();
            txtTEAM_NAME2.Text = PQMS_TEAMGridView.GetFocusedDataRow()["TEAM_NAME2"].ToString();
        }
    }
}