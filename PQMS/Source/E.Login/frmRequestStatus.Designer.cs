
namespace userManagement
{
    partial class frmRequestStatus
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
            this.btnSel = new System.Windows.Forms.Button();
            this.dgvUserRequestStatus = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.lblApp = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbApp = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtApproveNoTest = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(10, 12);
            this.btnSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(57, 29);
            this.btnSel.TabIndex = 25;
            this.btnSel.Text = "조회";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // dgvUserRequestStatus
            // 
            this.dgvUserRequestStatus.AllowUserToAddRows = false;
            this.dgvUserRequestStatus.AllowUserToDeleteRows = false;
            this.dgvUserRequestStatus.AllowUserToOrderColumns = true;
            this.dgvUserRequestStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserRequestStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk});
            this.dgvUserRequestStatus.Location = new System.Drawing.Point(10, 232);
            this.dgvUserRequestStatus.Name = "dgvUserRequestStatus";
            this.dgvUserRequestStatus.ReadOnly = true;
            this.dgvUserRequestStatus.RowTemplate.Height = 23;
            this.dgvUserRequestStatus.Size = new System.Drawing.Size(1011, 407);
            this.dgvUserRequestStatus.TabIndex = 26;
            this.dgvUserRequestStatus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserRequestStatus_CellContentClick);
            // 
            // chk
            // 
            this.chk.Frozen = true;
            this.chk.HeaderText = "chk";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            this.chk.Width = 50;
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(88, 12);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(57, 29);
            this.btnApprove.TabIndex = 27;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(167, 12);
            this.btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(57, 29);
            this.btn.TabIndex = 28;
            this.btn.Text = "Reject";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(247, 12);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 29);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(73, 105);
            this.txtComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(400, 108);
            this.txtComments.TabIndex = 31;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Location = new System.Drawing.Point(10, 130);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(56, 13);
            this.lblComments.TabIndex = 30;
            this.lblComments.Text = "Comments";
            // 
            // lblApp
            // 
            this.lblApp.AutoSize = true;
            this.lblApp.Location = new System.Drawing.Point(9, 77);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(28, 13);
            this.lblApp.TabIndex = 32;
            this.lblApp.Text = "APP";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(245, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 33;
            this.lblStatus.Text = "Status";
            // 
            // cmbApp
            // 
            this.cmbApp.FormattingEnabled = true;
            this.cmbApp.Location = new System.Drawing.Point(73, 69);
            this.cmbApp.Name = "cmbApp";
            this.cmbApp.Size = new System.Drawing.Size(104, 21);
            this.cmbApp.TabIndex = 34;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(320, 70);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(104, 21);
            this.cmbStatus.TabIndex = 35;
            // 
            // txtApproveNoTest
            // 
            this.txtApproveNoTest.Location = new System.Drawing.Point(586, 64);
            this.txtApproveNoTest.Name = "txtApproveNoTest";
            this.txtApproveNoTest.Size = new System.Drawing.Size(241, 20);
            this.txtApproveNoTest.TabIndex = 36;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(617, 113);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 72);
            this.textBox1.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "체크아이디";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRequestStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 685);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtApproveNoTest);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbApp);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblApp);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.dgvUserRequestStatus);
            this.Controls.Add(this.btnSel);
            this.Name = "frmRequestStatus";
            this.Text = "RequestStatus";
            this.Load += new System.EventHandler(this.frmRequestStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.DataGridView dgvUserRequestStatus;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbApp;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.TextBox txtApproveNoTest;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}