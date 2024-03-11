
namespace userManagement
{
    partial class frmUserIdRequest
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
            this.button2 = new System.Windows.Forms.Button();
            this.dgvUserRequestStatus = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtuserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(441, 14);
            this.btnSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(57, 29);
            this.btnSel.TabIndex = 25;
            this.btnSel.Text = "조회_old";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.txtApproveNoTest.Location = new System.Drawing.Point(486, 68);
            this.txtApproveNoTest.Name = "txtApproveNoTest";
            this.txtApproveNoTest.Size = new System.Drawing.Size(97, 20);
            this.txtApproveNoTest.TabIndex = 36;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(815, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 72);
            this.textBox1.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(719, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "체크아이디";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 26);
            this.button2.TabIndex = 39;
            this.button2.Text = "조회";
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
            this.dgvUserRequestStatus.Location = new System.Drawing.Point(24, 245);
            this.dgvUserRequestStatus.Name = "dgvUserRequestStatus";
            this.dgvUserRequestStatus.RowTemplate.Height = 24;
            this.dgvUserRequestStatus.Size = new System.Drawing.Size(914, 193);
            this.dgvUserRequestStatus.TabIndex = 236;
            this.dgvUserRequestStatus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserRequestStatus_CellContentClick);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.txtuserID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(521, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 118);
            this.panel1.TabIndex = 239;
            // 
            // txtuserID
            // 
            this.txtuserID.Location = new System.Drawing.Point(68, 11);
            this.txtuserID.Name = "txtuserID";
            this.txtuserID.Size = new System.Drawing.Size(205, 20);
            this.txtuserID.TabIndex = 240;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 239;
            this.label1.Text = "User ID :";
            // 
            // frmUserIdRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 685);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvUserRequestStatus);
            this.Controls.Add(this.button2);
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
            this.Controls.Add(this.btnSel);
            this.Name = "frmUserIdRequest";
            this.Text = "RequestStatus";
            this.Load += new System.EventHandler(this.frmUserIdRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbApp;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtApproveNoTest;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvUserRequestStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtuserID;
        private System.Windows.Forms.Label label1;
    }
}