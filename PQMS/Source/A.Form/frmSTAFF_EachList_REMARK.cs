using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PQMS.C.Unit;
using System.Data.OleDb;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;



namespace PQMS
{
    public partial class frmSTAFF_EachList_REMARK : MetroFramework.Forms.MetroForm
    {        

        public frmSTAFF_EachList_REMARK()
        {
            InitializeComponent();     
        }

        private void frmSTAFF_EachList_REMARK_Load(object sender, EventArgs e)
        {
            txtSTAFF_EACHLIST_REMARK.ForeColor = System.Drawing.SystemColors.WindowText;
            txtSTAFF_EACHLIST_REMARK.Text = Form2STAFF_EACHLIST_REMARK.sSTAFF_EACHLIST_REMARK;
            if (Form2STAFF_EACHLIST_REMARK.sSTAFF_EACHLIST_REMARK == null || Form2STAFF_EACHLIST_REMARK.sSTAFF_EACHLIST_REMARK == "")
            {
                txtSTAFF_EACHLIST_REMARK.ForeColor = System.Drawing.SystemColors.WindowFrame;
                txtSTAFF_EACHLIST_REMARK.Text = "지침서번호: CQW - 7021 - 0001 , 기타내용";
            }
        }

        private void btnInsertEachList_Remark_Metro_Click(object sender, EventArgs e)
        {
            Form2STAFF_EACHLIST_REMARK.sSTAFF_EACHLIST_REMARK = txtSTAFF_EACHLIST_REMARK.Text;
            this.Close();
        }

        private void btnInsertEachListREMARK_Click(object sender, EventArgs e)
        {
            Form2STAFF_EACHLIST_REMARK.sSTAFF_EACHLIST_REMARK = txtSTAFF_EACHLIST_REMARK.Text;
            this.Close();
        }

        private void txtSTAFF_EACHLIST_REMARK_Click(object sender, EventArgs e)
        {

            txtSTAFF_EACHLIST_REMARK.ForeColor = System.Drawing.SystemColors.WindowText;

            if (txtSTAFF_EACHLIST_REMARK.Text == "지침서번호: CQW - 7021 - 0001 , 기타내용")
            {
                txtSTAFF_EACHLIST_REMARK.Text = "";
            }
        }
    }
}
