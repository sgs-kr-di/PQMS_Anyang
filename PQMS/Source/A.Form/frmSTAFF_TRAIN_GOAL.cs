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

namespace PQMS
{
    public partial class frmSTAFF_TRAIN_GOAL : MetroFramework.Forms.MetroForm
    {
        public frmSTAFF_TRAIN_GOAL()
        {
            InitializeComponent();
        }

        private void btnInsertTrainObjective_Click(object sender, EventArgs e)
        {
            Form2STAFF_TRAIN_GOAL.sSTAFF_TRAIN_GOAL = txtSTAFF_TRAIN_GOAL.Text;
            this.Close();
        }

        private void frmSTAFF_TRAIN_OBJECT_Load(object sender, EventArgs e)
        {
            txtSTAFF_TRAIN_GOAL.Text = Form2STAFF_TRAIN_GOAL.sSTAFF_TRAIN_GOAL;
            //Form2PQMS_STAFF_TRAINING_MainGridView.GetFocusedRowCellValue("STAFF_TRAIN_CONTENTS").ToString()
        }

        private void btnInsertTrainObjective_Metro_Click(object sender, EventArgs e)
        {
            Form2STAFF_TRAIN_GOAL.sSTAFF_TRAIN_GOAL = txtSTAFF_TRAIN_GOAL.Text;
            this.Close();
        }
    }
}
