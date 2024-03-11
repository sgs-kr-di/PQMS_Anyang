
namespace PQMS
{
    partial class frmSTAFF_TRAIN_OBJECT
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
            this.txtSTAFF_TRAIN_OBJECTIVE = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInsertTrainOvjective_Metro = new MetroFramework.Controls.MetroButton();
            this.btnInsertTrainObjective = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSTAFF_TRAIN_OBJECTIVE
            // 
            this.txtSTAFF_TRAIN_OBJECTIVE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSTAFF_TRAIN_OBJECTIVE.Location = new System.Drawing.Point(0, 0);
            this.txtSTAFF_TRAIN_OBJECTIVE.Multiline = true;
            this.txtSTAFF_TRAIN_OBJECTIVE.Name = "txtSTAFF_TRAIN_OBJECTIVE";
            this.txtSTAFF_TRAIN_OBJECTIVE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSTAFF_TRAIN_OBJECTIVE.Size = new System.Drawing.Size(770, 359);
            this.txtSTAFF_TRAIN_OBJECTIVE.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInsertTrainOvjective_Metro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnInsertTrainOvjective_Metro
            // 
            this.btnInsertTrainOvjective_Metro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInsertTrainOvjective_Metro.Location = new System.Drawing.Point(0, 0);
            this.btnInsertTrainOvjective_Metro.Name = "btnInsertTrainOvjective_Metro";
            this.btnInsertTrainOvjective_Metro.Size = new System.Drawing.Size(770, 30);
            this.btnInsertTrainOvjective_Metro.TabIndex = 1;
            this.btnInsertTrainOvjective_Metro.Text = "저장";
            this.btnInsertTrainOvjective_Metro.UseSelectable = true;
            this.btnInsertTrainOvjective_Metro.Click += new System.EventHandler(this.btnInsertTrainObjective_Metro_Click);
            // 
            // btnInsertTrainObjective
            // 
            this.btnInsertTrainObjective.Location = new System.Drawing.Point(569, 24);
            this.btnInsertTrainObjective.Name = "btnInsertTrainObjective";
            this.btnInsertTrainObjective.Size = new System.Drawing.Size(218, 30);
            this.btnInsertTrainObjective.TabIndex = 0;
            this.btnInsertTrainObjective.Text = "저장";
            this.btnInsertTrainObjective.Visible = false;
            this.btnInsertTrainObjective.Click += new System.EventHandler(this.btnInsertTrainObjective_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSTAFF_TRAIN_OBJECTIVE);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 359);
            this.panel2.TabIndex = 2;
            // 
            // frmSTAFF_TRAIN_OBJECT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 469);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnInsertTrainObjective);
            this.Controls.Add(this.panel1);
            this.Name = "frmSTAFF_TRAIN_OBJECT";
            this.Text = "주제 (OBJECTIVE)";
            this.Load += new System.EventHandler(this.frmSTAFF_TRAIN_OBJECT_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSTAFF_TRAIN_OBJECTIVE;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnInsertTrainObjective;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroButton btnInsertTrainOvjective_Metro;
    }
}