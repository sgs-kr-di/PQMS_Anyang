
namespace PQMS
{
    partial class frmRolePaperPeriodicInspection
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
            this.btnRP_PeriodicInspection = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRolePaper = new System.Windows.Forms.ComboBox();
            this.cmbApprove2 = new System.Windows.Forms.ComboBox();
            this.cmbApprove1 = new System.Windows.Forms.ComboBox();
            this.txtAccountNo1 = new System.Windows.Forms.TextBox();
            this.txtLoginID1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountNo2 = new System.Windows.Forms.TextBox();
            this.txtLoginID2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRoleCode = new System.Windows.Forms.TextBox();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRP_PeriodicInspection
            // 
            this.btnRP_PeriodicInspection.Location = new System.Drawing.Point(12, 12);
            this.btnRP_PeriodicInspection.Name = "btnRP_PeriodicInspection";
            this.btnRP_PeriodicInspection.Size = new System.Drawing.Size(283, 39);
            this.btnRP_PeriodicInspection.TabIndex = 325;
            this.btnRP_PeriodicInspection.Text = "정기정검 요청";
            this.btnRP_PeriodicInspection.UseVisualStyleBackColor = true;
            this.btnRP_PeriodicInspection.Click += new System.EventHandler(this.btnRP_PeriodicInspection_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 338;
            this.label1.Text = "직무명 :";
            // 
            // cmbRolePaper
            // 
            this.cmbRolePaper.FormattingEnabled = true;
            this.cmbRolePaper.Location = new System.Drawing.Point(76, 65);
            this.cmbRolePaper.Name = "cmbRolePaper";
            this.cmbRolePaper.Size = new System.Drawing.Size(201, 21);
            this.cmbRolePaper.TabIndex = 342;
            this.cmbRolePaper.SelectedIndexChanged += new System.EventHandler(this.cmbRolePaper_SelectedIndexChanged);
            // 
            // cmbApprove2
            // 
            this.cmbApprove2.FormattingEnabled = true;
            this.cmbApprove2.Location = new System.Drawing.Point(76, 122);
            this.cmbApprove2.Name = "cmbApprove2";
            this.cmbApprove2.Size = new System.Drawing.Size(201, 21);
            this.cmbApprove2.TabIndex = 348;
            // 
            // cmbApprove1
            // 
            this.cmbApprove1.FormattingEnabled = true;
            this.cmbApprove1.Location = new System.Drawing.Point(76, 95);
            this.cmbApprove1.Name = "cmbApprove1";
            this.cmbApprove1.Size = new System.Drawing.Size(201, 21);
            this.cmbApprove1.TabIndex = 352;
            this.cmbApprove1.SelectedIndexChanged += new System.EventHandler(this.cmbApprove1_SelectedIndexChanged);
            // 
            // txtAccountNo1
            // 
            this.txtAccountNo1.Location = new System.Drawing.Point(81, 95);
            this.txtAccountNo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAccountNo1.Name = "txtAccountNo1";
            this.txtAccountNo1.ReadOnly = true;
            this.txtAccountNo1.Size = new System.Drawing.Size(41, 20);
            this.txtAccountNo1.TabIndex = 353;
            // 
            // txtLoginID1
            // 
            this.txtLoginID1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLoginID1.Location = new System.Drawing.Point(120, 95);
            this.txtLoginID1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoginID1.Name = "txtLoginID1";
            this.txtLoginID1.ReadOnly = true;
            this.txtLoginID1.Size = new System.Drawing.Size(138, 20);
            this.txtLoginID1.TabIndex = 354;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 351;
            this.label2.Text = "검토자  :";
            // 
            // txtAccountNo2
            // 
            this.txtAccountNo2.Location = new System.Drawing.Point(82, 123);
            this.txtAccountNo2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAccountNo2.Name = "txtAccountNo2";
            this.txtAccountNo2.ReadOnly = true;
            this.txtAccountNo2.Size = new System.Drawing.Size(41, 20);
            this.txtAccountNo2.TabIndex = 349;
            // 
            // txtLoginID2
            // 
            this.txtLoginID2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLoginID2.Location = new System.Drawing.Point(119, 123);
            this.txtLoginID2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoginID2.Name = "txtLoginID2";
            this.txtLoginID2.ReadOnly = true;
            this.txtLoginID2.Size = new System.Drawing.Size(138, 20);
            this.txtLoginID2.TabIndex = 350;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 347;
            this.label6.Text = "승인권자  :";
            // 
            // txtRoleCode
            // 
            this.txtRoleCode.Location = new System.Drawing.Point(26, 22);
            this.txtRoleCode.Name = "txtRoleCode";
            this.txtRoleCode.Size = new System.Drawing.Size(88, 20);
            this.txtRoleCode.TabIndex = 355;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(198, 22);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(88, 20);
            this.txtRoleName.TabIndex = 356;
            // 
            // frmRolePaperPeriodicInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(308, 163);
            this.Controls.Add(this.btnRP_PeriodicInspection);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.txtRoleCode);
            this.Controls.Add(this.cmbApprove2);
            this.Controls.Add(this.cmbApprove1);
            this.Controls.Add(this.txtAccountNo1);
            this.Controls.Add(this.txtLoginID1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAccountNo2);
            this.Controls.Add(this.txtLoginID2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbRolePaper);
            this.Controls.Add(this.label1);
            this.Name = "frmRolePaperPeriodicInspection";
            this.Text = "정기점검";
            this.Load += new System.EventHandler(this.frmRolePaperPeriodicInspection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRP_PeriodicInspection;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRolePaper;
        private System.Windows.Forms.ComboBox cmbApprove2;
        private System.Windows.Forms.ComboBox cmbApprove1;
        private System.Windows.Forms.TextBox txtAccountNo1;
        private System.Windows.Forms.TextBox txtLoginID1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccountNo2;
        private System.Windows.Forms.TextBox txtLoginID2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRoleCode;
        private System.Windows.Forms.TextBox txtRoleName;
    }
}