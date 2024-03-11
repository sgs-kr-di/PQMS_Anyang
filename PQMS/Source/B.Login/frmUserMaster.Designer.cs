
namespace userManagement
{
    partial class frmUserMaster
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
            this.components = new System.ComponentModel.Container();
            this.btnIns = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtfirstName = new System.Windows.Forms.TextBox();
            this.lblfirstName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmplId = new System.Windows.Forms.TextBox();
            this.lblEmplId = new System.Windows.Forms.Label();
            this.btnSel = new System.Windows.Forms.Button();
            this.dgvUserMaster = new System.Windows.Forms.DataGridView();
            this.btnAcc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(137, 22);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(66, 27);
            this.btnIns.TabIndex = 0;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(379, 22);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(66, 27);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(255, 22);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(66, 27);
            this.btnUpd.TabIndex = 2;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(27, 55);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(41, 12);
            this.lblUserId.TabIndex = 3;
            this.lblUserId.Text = "userID";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(100, 53);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(466, 21);
            this.txtUserId.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtfirstName
            // 
            this.txtfirstName.Location = new System.Drawing.Point(100, 87);
            this.txtfirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfirstName.Name = "txtfirstName";
            this.txtfirstName.Size = new System.Drawing.Size(466, 21);
            this.txtfirstName.TabIndex = 7;
            // 
            // lblfirstName
            // 
            this.lblfirstName.AutoSize = true;
            this.lblfirstName.Location = new System.Drawing.Point(27, 90);
            this.lblfirstName.Name = "lblfirstName";
            this.lblfirstName.Size = new System.Drawing.Size(59, 12);
            this.lblfirstName.TabIndex = 6;
            this.lblfirstName.Text = "firstName";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(665, 87);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(466, 21);
            this.txtLastName.TabIndex = 9;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(592, 93);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(63, 12);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "LastName";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(100, 118);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(466, 21);
            this.txtCompany.TabIndex = 11;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(27, 120);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(60, 12);
            this.lblCompany.TabIndex = 10;
            this.lblCompany.Text = "Company";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(665, 125);
            this.txtDepartment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(466, 21);
            this.txtDepartment.TabIndex = 13;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(592, 127);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(69, 12);
            this.lblDepartment.TabIndex = 12;
            this.lblDepartment.Text = "Department";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(99, 222);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(466, 21);
            this.txtAddress1.TabIndex = 17;
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Location = new System.Drawing.Point(26, 227);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(58, 12);
            this.lblAddress1.TabIndex = 14;
            this.lblAddress1.Text = "Address1";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(665, 224);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(466, 21);
            this.txtAddress2.TabIndex = 19;
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(592, 227);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(58, 12);
            this.lblAddress2.TabIndex = 16;
            this.lblAddress2.Text = "Address2";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 179);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(466, 21);
            this.txtEmail.TabIndex = 21;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(27, 183);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(37, 12);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(666, 176);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(466, 21);
            this.txtPhone.TabIndex = 23;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(593, 180);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 12);
            this.lblPhone.TabIndex = 20;
            this.lblPhone.Text = "Phone";
            // 
            // txtEmplId
            // 
            this.txtEmplId.Location = new System.Drawing.Point(100, 147);
            this.txtEmplId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmplId.Name = "txtEmplId";
            this.txtEmplId.Size = new System.Drawing.Size(466, 21);
            this.txtEmplId.TabIndex = 15;
            // 
            // lblEmplId
            // 
            this.lblEmplId.AutoSize = true;
            this.lblEmplId.Location = new System.Drawing.Point(27, 152);
            this.lblEmplId.Name = "lblEmplId";
            this.lblEmplId.Size = new System.Drawing.Size(45, 12);
            this.lblEmplId.TabIndex = 22;
            this.lblEmplId.Text = "EmplID";
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(29, 22);
            this.btnSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(66, 27);
            this.btnSel.TabIndex = 24;
            this.btnSel.Text = "조회";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // dgvUserMaster
            // 
            this.dgvUserMaster.AllowUserToAddRows = false;
            this.dgvUserMaster.AllowUserToDeleteRows = false;
            this.dgvUserMaster.AllowUserToOrderColumns = true;
            this.dgvUserMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserMaster.Location = new System.Drawing.Point(29, 284);
            this.dgvUserMaster.Name = "dgvUserMaster";
            this.dgvUserMaster.ReadOnly = true;
            this.dgvUserMaster.RowTemplate.Height = 23;
            this.dgvUserMaster.Size = new System.Drawing.Size(1219, 325);
            this.dgvUserMaster.TabIndex = 25;
            // 
            // btnAcc
            // 
            this.btnAcc.Location = new System.Drawing.Point(1065, 22);
            this.btnAcc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAcc.Name = "btnAcc";
            this.btnAcc.Size = new System.Drawing.Size(121, 34);
            this.btnAcc.TabIndex = 26;
            this.btnAcc.Text = "App 계정 관리";
            this.btnAcc.UseVisualStyleBackColor = true;
            this.btnAcc.Click += new System.EventHandler(this.btnAcc_Click);
            // 
            // frmUserMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1284, 621);
            this.Controls.Add(this.btnAcc);
            this.Controls.Add(this.dgvUserMaster);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.txtEmplId);
            this.Controls.Add(this.lblEmplId);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.lblAddress2);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.lblAddress1);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtfirstName);
            this.Controls.Add(this.lblfirstName);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnIns);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmUserMaster";
            this.Text = "UserMaster";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtfirstName;
        private System.Windows.Forms.Label lblfirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtEmplId;
        private System.Windows.Forms.Label lblEmplId;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.DataGridView dgvUserMaster;
        private System.Windows.Forms.Button btnAcc;
    }
}