
namespace userManagement
{
    partial class frmChoiceApprover
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvApprover = new System.Windows.Forms.DataGridView();
            this.txtApproveNoTest = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprover)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvApprover
            // 
            this.dgvApprover.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApprover.Location = new System.Drawing.Point(12, 73);
            this.dgvApprover.Name = "dgvApprover";
            this.dgvApprover.RowTemplate.Height = 23;
            this.dgvApprover.Size = new System.Drawing.Size(480, 317);
            this.dgvApprover.TabIndex = 0;
            this.dgvApprover.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApprover_CellContentClick);
            // 
            // txtApproveNoTest
            // 
            this.txtApproveNoTest.Location = new System.Drawing.Point(44, 22);
            this.txtApproveNoTest.Name = "txtApproveNoTest";
            this.txtApproveNoTest.Size = new System.Drawing.Size(253, 21);
            this.txtApproveNoTest.TabIndex = 1;
            // 
            // frmChoiceApprover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 447);
            this.Controls.Add(this.txtApproveNoTest);
            this.Controls.Add(this.dgvApprover);
            this.Name = "frmChoiceApprover";
            this.Text = "Choice Approver";
            this.Load += new System.EventHandler(this.frmChoiceApprover_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvApprover;
        private System.Windows.Forms.TextBox txtApproveNoTest;
    }
}