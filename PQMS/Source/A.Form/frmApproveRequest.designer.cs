
namespace PQMS
{
    partial class frmApproveRequest
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnEduReportGo = new System.Windows.Forms.Button();
            this.txtidxNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbApprover = new System.Windows.Forms.ComboBox();
            this.btnApprover = new System.Windows.Forms.Button();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.txtLoginID = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtRequestContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnEduReportGo
            // 
            this.btnEduReportGo.Location = new System.Drawing.Point(15, 12);
            this.btnEduReportGo.Name = "btnEduReportGo";
            this.btnEduReportGo.Size = new System.Drawing.Size(906, 39);
            this.btnEduReportGo.TabIndex = 6;
            this.btnEduReportGo.Text = "승인요청";
            this.btnEduReportGo.UseVisualStyleBackColor = true;
            this.btnEduReportGo.Click += new System.EventHandler(this.btnEduReportGo_Click);
            // 
            // txtidxNo
            // 
            this.txtidxNo.Location = new System.Drawing.Point(118, 62);
            this.txtidxNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtidxNo.Name = "txtidxNo";
            this.txtidxNo.Size = new System.Drawing.Size(40, 20);
            this.txtidxNo.TabIndex = 323;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 314;
            this.label5.Text = "승인권자  :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 314;
            this.label6.Text = "승인요청자료번호 :";
            this.label6.Click += new System.EventHandler(this.label5_Click);
            // 
            // cmbApprover
            // 
            this.cmbApprover.FormattingEnabled = true;
            this.cmbApprover.Location = new System.Drawing.Point(305, 91);
            this.cmbApprover.Name = "cmbApprover";
            this.cmbApprover.Size = new System.Drawing.Size(201, 21);
            this.cmbApprover.TabIndex = 325;
            this.cmbApprover.SelectedIndexChanged += new System.EventHandler(this.cmbApprover_SelectedIndexChanged);
            // 
            // btnApprover
            // 
            this.btnApprover.Location = new System.Drawing.Point(512, 91);
            this.btnApprover.Name = "btnApprover";
            this.btnApprover.Size = new System.Drawing.Size(55, 22);
            this.btnApprover.TabIndex = 324;
            this.btnApprover.Text = "찾기";
            this.btnApprover.UseVisualStyleBackColor = true;
            this.btnApprover.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Location = new System.Drawing.Point(117, 91);
            this.txtAccountNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(41, 20);
            this.txtAccountNo.TabIndex = 326;
            // 
            // txtLoginID
            // 
            this.txtLoginID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLoginID.Location = new System.Drawing.Point(161, 91);
            this.txtLoginID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(138, 20);
            this.txtLoginID.TabIndex = 327;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(162, 62);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(282, 20);
            this.txtTitle.TabIndex = 328;
            // 
            // txtRequestContent
            // 
            this.txtRequestContent.Location = new System.Drawing.Point(117, 117);
            this.txtRequestContent.Margin = new System.Windows.Forms.Padding(2);
            this.txtRequestContent.Name = "txtRequestContent";
            this.txtRequestContent.Size = new System.Drawing.Size(426, 20);
            this.txtRequestContent.TabIndex = 330;
            this.txtRequestContent.Text = "승인해 주세요";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 329;
            this.label3.Text = "승인요청내용 :";
            // 
            // frmApproveRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(934, 189);
            this.Controls.Add(this.txtRequestContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.txtLoginID);
            this.Controls.Add(this.cmbApprover);
            this.Controls.Add(this.btnApprover);
            this.Controls.Add(this.txtidxNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnEduReportGo);
            this.Name = "frmApproveRequest";
            this.Load += new System.EventHandler(this.frmApproveRequest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnEduReportGo;
        private System.Windows.Forms.TextBox txtidxNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbApprover;
        private System.Windows.Forms.Button btnApprover;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.TextBox txtLoginID;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtRequestContent;
        private System.Windows.Forms.Label label3;
    }
}