
namespace PQMS
{
    partial class frmSTAFF_TRAIN_CONTENTS
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
            this.txtSTAFF_TrainContents = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInsertTrainContents_Metro = new MetroFramework.Controls.MetroButton();
            this.btnInsertTrainContents = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSTAFF_TrainContents
            // 
            this.txtSTAFF_TrainContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSTAFF_TrainContents.Location = new System.Drawing.Point(0, 0);
            this.txtSTAFF_TrainContents.Multiline = true;
            this.txtSTAFF_TrainContents.Name = "txtSTAFF_TrainContents";
            this.txtSTAFF_TrainContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSTAFF_TrainContents.Size = new System.Drawing.Size(770, 359);
            this.txtSTAFF_TrainContents.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInsertTrainContents_Metro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnInsertTrainContents_Metro
            // 
            this.btnInsertTrainContents_Metro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInsertTrainContents_Metro.Location = new System.Drawing.Point(0, 0);
            this.btnInsertTrainContents_Metro.Name = "btnInsertTrainContents_Metro";
            this.btnInsertTrainContents_Metro.Size = new System.Drawing.Size(770, 30);
            this.btnInsertTrainContents_Metro.TabIndex = 1;
            this.btnInsertTrainContents_Metro.Text = "저장";
            this.btnInsertTrainContents_Metro.UseSelectable = true;
            this.btnInsertTrainContents_Metro.Click += new System.EventHandler(this.btnInsertTrainContents_Metro_Click);
            // 
            // btnInsertTrainContents
            // 
            this.btnInsertTrainContents.Location = new System.Drawing.Point(569, 24);
            this.btnInsertTrainContents.Name = "btnInsertTrainContents";
            this.btnInsertTrainContents.Size = new System.Drawing.Size(218, 30);
            this.btnInsertTrainContents.TabIndex = 0;
            this.btnInsertTrainContents.Text = "저장";
            this.btnInsertTrainContents.Visible = false;
            this.btnInsertTrainContents.Click += new System.EventHandler(this.btnInsertTrainContents_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSTAFF_TrainContents);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 359);
            this.panel2.TabIndex = 2;
            // 
            // frmSTAFF_TRAIN_CONTENTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 469);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnInsertTrainContents);
            this.Controls.Add(this.panel1);
            this.Name = "frmSTAFF_TRAIN_CONTENTS";
            this.Text = "교육 훈련 내용";
            this.Load += new System.EventHandler(this.frmSTAFF_TRAIN_CONTENTS_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSTAFF_TrainContents;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnInsertTrainContents;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroButton btnInsertTrainContents_Metro;
    }
}