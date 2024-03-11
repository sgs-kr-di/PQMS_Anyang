
namespace PQMS
{
    partial class frmApproveRequestCheck
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
            this.button4 = new System.Windows.Forms.Button();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.txtLoginID = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtRequestContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvUserRequestStatus = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtApproveComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtToBeApproved = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).BeginInit();
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
            this.btnEduReportGo.Size = new System.Drawing.Size(178, 39);
            this.btnEduReportGo.TabIndex = 6;
            this.btnEduReportGo.Text = "승인요청내역확인";
            this.btnEduReportGo.UseVisualStyleBackColor = true;
            this.btnEduReportGo.Click += new System.EventHandler(this.btnEduReportGo_Click);
            // 
            // txtidxNo
            // 
            this.txtidxNo.Location = new System.Drawing.Point(119, 62);
            this.txtidxNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtidxNo.Name = "txtidxNo";
            this.txtidxNo.Size = new System.Drawing.Size(40, 20);
            this.txtidxNo.TabIndex = 323;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
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
            this.cmbApprover.Location = new System.Drawing.Point(305, 110);
            this.cmbApprover.Name = "cmbApprover";
            this.cmbApprover.Size = new System.Drawing.Size(201, 21);
            this.cmbApprover.TabIndex = 325;
            this.cmbApprover.SelectedIndexChanged += new System.EventHandler(this.cmbApprover_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(512, 110);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 23);
            this.button4.TabIndex = 324;
            this.button4.Text = "S";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Location = new System.Drawing.Point(117, 110);
            this.txtAccountNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(41, 20);
            this.txtAccountNo.TabIndex = 326;
            // 
            // txtLoginID
            // 
            this.txtLoginID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLoginID.Location = new System.Drawing.Point(161, 110);
            this.txtLoginID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(138, 20);
            this.txtLoginID.TabIndex = 327;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(162, 85);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(282, 20);
            this.txtTitle.TabIndex = 328;
            // 
            // txtRequestContent
            // 
            this.txtRequestContent.Location = new System.Drawing.Point(117, 135);
            this.txtRequestContent.Margin = new System.Windows.Forms.Padding(2);
            this.txtRequestContent.Name = "txtRequestContent";
            this.txtRequestContent.Size = new System.Drawing.Size(426, 20);
            this.txtRequestContent.TabIndex = 330;
            this.txtRequestContent.Text = "승인해 주세요";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 329;
            this.label3.Text = "승인요청내용 :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 39);
            this.button1.TabIndex = 331;
            this.button1.Text = "승인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(290, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 39);
            this.button2.TabIndex = 332;
            this.button2.Text = "반려";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvUserRequestStatus
            // 
            this.dgvUserRequestStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserRequestStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvUserRequestStatus.Location = new System.Drawing.Point(13, 195);
            this.dgvUserRequestStatus.Name = "dgvUserRequestStatus";
            this.dgvUserRequestStatus.RowTemplate.Height = 24;
            this.dgvUserRequestStatus.Size = new System.Drawing.Size(914, 279);
            this.dgvUserRequestStatus.TabIndex = 333;
            this.dgvUserRequestStatus.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserRequestStatus_CellClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FillWeight = 10F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "A";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // txtApproveComment
            // 
            this.txtApproveComment.Location = new System.Drawing.Point(117, 159);
            this.txtApproveComment.Margin = new System.Windows.Forms.Padding(2);
            this.txtApproveComment.Name = "txtApproveComment";
            this.txtApproveComment.Size = new System.Drawing.Size(426, 20);
            this.txtApproveComment.TabIndex = 335;
            this.txtApproveComment.Text = "승인해 주세요";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 334;
            this.label1.Text = "승인/보류 내용 :";
            // 
            // txtToBeApproved
            // 
            this.txtToBeApproved.Location = new System.Drawing.Point(119, 85);
            this.txtToBeApproved.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtToBeApproved.Name = "txtToBeApproved";
            this.txtToBeApproved.Size = new System.Drawing.Size(41, 20);
            this.txtToBeApproved.TabIndex = 326;
            this.txtToBeApproved.TextChanged += new System.EventHandler(this.txtToBeApproved_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 336;
            this.label2.Text = "승인대상자료번호 :";
            // 
            // frmApproveRequestCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(939, 501);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtApproveComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUserRequestStatus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRequestContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtToBeApproved);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.txtLoginID);
            this.Controls.Add(this.cmbApprover);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtidxNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnEduReportGo);
            this.Name = "frmApproveRequestCheck";
            this.Load += new System.EventHandler(this.frmApproveRequestCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).EndInit();
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
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.TextBox txtLoginID;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtRequestContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvUserRequestStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox txtApproveComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtToBeApproved;
        private System.Windows.Forms.Label label2;
    }
}