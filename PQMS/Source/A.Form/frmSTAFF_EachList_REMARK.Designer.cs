
namespace PQMS
{
    partial class frmSTAFF_EachList_REMARK
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInsertEachList_Remark_Metro = new MetroFramework.Controls.MetroButton();
            this.btnInsertEachListREMARK = new DevExpress.XtraEditors.SimpleButton();
            this.txtSTAFF_EACHLIST_REMARK = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInsertEachList_Remark_Metro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnInsertEachList_Remark_Metro
            // 
            this.btnInsertEachList_Remark_Metro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInsertEachList_Remark_Metro.Location = new System.Drawing.Point(0, 0);
            this.btnInsertEachList_Remark_Metro.Name = "btnInsertEachList_Remark_Metro";
            this.btnInsertEachList_Remark_Metro.Size = new System.Drawing.Size(770, 30);
            this.btnInsertEachList_Remark_Metro.TabIndex = 1;
            this.btnInsertEachList_Remark_Metro.Text = "저장";
            this.btnInsertEachList_Remark_Metro.UseSelectable = true;
            this.btnInsertEachList_Remark_Metro.Click += new System.EventHandler(this.btnInsertEachList_Remark_Metro_Click);
            // 
            // btnInsertEachListREMARK
            // 
            this.btnInsertEachListREMARK.Location = new System.Drawing.Point(569, 24);
            this.btnInsertEachListREMARK.Name = "btnInsertEachListREMARK";
            this.btnInsertEachListREMARK.Size = new System.Drawing.Size(218, 30);
            this.btnInsertEachListREMARK.TabIndex = 0;
            this.btnInsertEachListREMARK.Text = "저장";
            this.btnInsertEachListREMARK.Visible = false;
            this.btnInsertEachListREMARK.Click += new System.EventHandler(this.btnInsertEachListREMARK_Click);
            // 
            // txtSTAFF_EACHLIST_REMARK
            // 
            this.txtSTAFF_EACHLIST_REMARK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSTAFF_EACHLIST_REMARK.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSTAFF_EACHLIST_REMARK.Location = new System.Drawing.Point(20, 90);
            this.txtSTAFF_EACHLIST_REMARK.Multiline = true;
            this.txtSTAFF_EACHLIST_REMARK.Name = "txtSTAFF_EACHLIST_REMARK";
            this.txtSTAFF_EACHLIST_REMARK.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSTAFF_EACHLIST_REMARK.Size = new System.Drawing.Size(770, 359);
            this.txtSTAFF_EACHLIST_REMARK.TabIndex = 2;
            this.txtSTAFF_EACHLIST_REMARK.Text = "지침서번호: CQW-7021-0001 , 기타내용";
            this.txtSTAFF_EACHLIST_REMARK.Click += new System.EventHandler(this.txtSTAFF_EACHLIST_REMARK_Click);
            // 
            // frmSTAFF_EachList_REMARK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 469);
            this.Controls.Add(this.txtSTAFF_EACHLIST_REMARK);
            this.Controls.Add(this.btnInsertEachListREMARK);
            this.Controls.Add(this.panel1);
            this.Name = "frmSTAFF_EachList_REMARK";
            this.Text = "비고 (관련지침 및 절차)";
            this.Load += new System.EventHandler(this.frmSTAFF_EachList_REMARK_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnInsertEachListREMARK;
        private MetroFramework.Controls.MetroButton btnInsertEachList_Remark_Metro;
        private System.Windows.Forms.TextBox txtSTAFF_EACHLIST_REMARK;
    }
}