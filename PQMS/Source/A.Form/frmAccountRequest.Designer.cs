
namespace PQMS
{
    partial class frmAccountRequest
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
            this.dgvUserRequestStatus = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblLogInId = new System.Windows.Forms.Label();
            this.txtLogInId = new System.Windows.Forms.TextBox();
            this.lblAppId = new System.Windows.Forms.Label();
            this.txtAppId = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbAppID = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAppNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUserRequestStatus
            // 
            this.dgvUserRequestStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserRequestStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvUserRequestStatus.Location = new System.Drawing.Point(28, 276);
            this.dgvUserRequestStatus.Name = "dgvUserRequestStatus";
            this.dgvUserRequestStatus.RowTemplate.Height = 24;
            this.dgvUserRequestStatus.Size = new System.Drawing.Size(623, 201);
            this.dgvUserRequestStatus.TabIndex = 244;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 26);
            this.button2.TabIndex = 243;
            this.button2.Text = "조회";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(25, 42);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(57, 20);
            this.btnIns.TabIndex = 43;
            this.btnIns.Text = "신청";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(101, 42);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 20);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(25, 81);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(38, 13);
            this.lblUserId.TabIndex = 46;
            this.lblUserId.Text = "userID";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(99, 76);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(400, 20);
            this.txtUserId.TabIndex = 47;
            // 
            // lblLogInId
            // 
            this.lblLogInId.AutoSize = true;
            this.lblLogInId.Location = new System.Drawing.Point(25, 103);
            this.lblLogInId.Name = "lblLogInId";
            this.lblLogInId.Size = new System.Drawing.Size(45, 13);
            this.lblLogInId.TabIndex = 48;
            this.lblLogInId.Text = "LogInID";
            // 
            // txtLogInId
            // 
            this.txtLogInId.Location = new System.Drawing.Point(99, 100);
            this.txtLogInId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLogInId.Name = "txtLogInId";
            this.txtLogInId.Size = new System.Drawing.Size(400, 20);
            this.txtLogInId.TabIndex = 49;
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(26, 127);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(37, 13);
            this.lblAppId.TabIndex = 50;
            this.lblAppId.Text = "AppID";
            // 
            // txtAppId
            // 
            this.txtAppId.Location = new System.Drawing.Point(149, 127);
            this.txtAppId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppId.Name = "txtAppId";
            this.txtAppId.Size = new System.Drawing.Size(235, 20);
            this.txtAppId.TabIndex = 51;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(25, 155);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 52;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(99, 153);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(400, 20);
            this.txtPassword.TabIndex = 53;
            // 
            // cmbAppID
            // 
            this.cmbAppID.FormattingEnabled = true;
            this.cmbAppID.Location = new System.Drawing.Point(390, 127);
            this.cmbAppID.Name = "cmbAppID";
            this.cmbAppID.Size = new System.Drawing.Size(201, 21);
            this.cmbAppID.TabIndex = 251;
            this.cmbAppID.SelectedIndexChanged += new System.EventHandler(this.cmbAppID_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(597, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 26);
            this.button1.TabIndex = 252;
            this.button1.Text = "S";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAppNo
            // 
            this.txtAppNo.Location = new System.Drawing.Point(99, 127);
            this.txtAppNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppNo.Name = "txtAppNo";
            this.txtAppNo.Size = new System.Drawing.Size(44, 20);
            this.txtAppNo.TabIndex = 253;
            // 
            // frmAccountRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 573);
            this.Controls.Add(this.txtAppNo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbAppID);
            this.Controls.Add(this.dgvUserRequestStatus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtAppId);
            this.Controls.Add(this.lblAppId);
            this.Controls.Add(this.txtLogInId);
            this.Controls.Add(this.lblLogInId);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnIns);
            this.Name = "frmAccountRequest";
            this.Text = "Account Request";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvUserRequestStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblLogInId;
        private System.Windows.Forms.TextBox txtLogInId;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.TextBox txtAppId;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbAppID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAppNo;
    }
}