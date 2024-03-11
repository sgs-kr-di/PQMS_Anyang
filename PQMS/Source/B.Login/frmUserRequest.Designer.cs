
namespace userManagement
{
    partial class frmUserRequest
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
            this.btnAcc = new System.Windows.Forms.Button();
            this.txtEmplId = new System.Windows.Forms.TextBox();
            this.lblEmplId = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblfirstName = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.lblLoginId = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtAppId = new System.Windows.Forms.TextBox();
            this.lblAppId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAcc
            // 
            this.btnAcc.Location = new System.Drawing.Point(1220, 17);
            this.btnAcc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAcc.Name = "btnAcc";
            this.btnAcc.Size = new System.Drawing.Size(138, 42);
            this.btnAcc.TabIndex = 51;
            this.btnAcc.Text = "App 계정 관리";
            this.btnAcc.UseVisualStyleBackColor = true;
            this.btnAcc.Visible = false;
            this.btnAcc.Click += new System.EventHandler(this.btnAcc_Click);
            // 
            // txtEmplId
            // 
            this.txtEmplId.Location = new System.Drawing.Point(115, 262);
            this.txtEmplId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmplId.Name = "txtEmplId";
            this.txtEmplId.Size = new System.Drawing.Size(532, 25);
            this.txtEmplId.TabIndex = 41;
            this.txtEmplId.Tag = "noMandantory";
            // 
            // lblEmplId
            // 
            this.lblEmplId.AutoSize = true;
            this.lblEmplId.Location = new System.Drawing.Point(32, 269);
            this.lblEmplId.Name = "lblEmplId";
            this.lblEmplId.Size = new System.Drawing.Size(51, 15);
            this.lblEmplId.TabIndex = 48;
            this.lblEmplId.Text = "EmplID";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(800, 261);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(532, 25);
            this.txtPhone.TabIndex = 49;
            this.txtPhone.Tag = "mandantory";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.Color.Red;
            this.lblPhone.Location = new System.Drawing.Point(679, 266);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(110, 15);
            this.lblPhone.TabIndex = 46;
            this.lblPhone.Text = "* Mobile Phone";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(115, 309);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(532, 25);
            this.txtEmail.TabIndex = 47;
            this.txtEmail.Tag = "mandantory";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.Red;
            this.lblEmail.Location = new System.Drawing.Point(32, 315);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 15);
            this.lblEmail.TabIndex = 44;
            this.lblEmail.Text = "* Email";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(799, 363);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(532, 25);
            this.txtAddress2.TabIndex = 45;
            this.txtAddress2.Tag = "noMandantory";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(678, 367);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(68, 15);
            this.lblAddress2.TabIndex = 42;
            this.lblAddress2.Text = "Address2";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(114, 362);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(532, 25);
            this.txtAddress1.TabIndex = 43;
            this.txtAddress1.Tag = "noMandantory";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Location = new System.Drawing.Point(31, 368);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(68, 15);
            this.lblAddress1.TabIndex = 40;
            this.lblAddress1.Text = "Address1";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(799, 220);
            this.txtDepartment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(532, 25);
            this.txtDepartment.TabIndex = 39;
            this.txtDepartment.Tag = "noMandantory";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(678, 223);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(80, 15);
            this.lblDepartment.TabIndex = 38;
            this.lblDepartment.Text = "Department";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(115, 220);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(532, 25);
            this.txtCompany.TabIndex = 37;
            this.txtCompany.Tag = "noMandantory";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(32, 223);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(69, 15);
            this.lblCompany.TabIndex = 36;
            this.lblCompany.Text = "Company";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(799, 175);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(532, 25);
            this.txtLastName.TabIndex = 35;
            this.txtLastName.Tag = "mandantory";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.ForeColor = System.Drawing.Color.Red;
            this.lblLastName.Location = new System.Drawing.Point(678, 182);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(88, 15);
            this.lblLastName.TabIndex = 34;
            this.lblLastName.Text = "* Last Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(115, 176);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(532, 25);
            this.txtFirstName.TabIndex = 33;
            this.txtFirstName.Tag = "mandantory";
            // 
            // lblfirstName
            // 
            this.lblfirstName.AutoSize = true;
            this.lblfirstName.ForeColor = System.Drawing.Color.Red;
            this.lblfirstName.Location = new System.Drawing.Point(32, 179);
            this.lblfirstName.Name = "lblfirstName";
            this.lblfirstName.Size = new System.Drawing.Size(83, 15);
            this.lblfirstName.TabIndex = 32;
            this.lblfirstName.Text = "* first Name";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(115, 88);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(532, 25);
            this.txtUserId.TabIndex = 31;
            this.txtUserId.Tag = "mandantory";
            this.txtUserId.Visible = false;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.ForeColor = System.Drawing.Color.Red;
            this.lblUserId.Location = new System.Drawing.Point(32, 93);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(65, 15);
            this.lblUserId.TabIndex = 30;
            this.lblUserId.Text = "* user ID";
            this.lblUserId.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(134, 25);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(34, 26);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(75, 34);
            this.btnIns.TabIndex = 27;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // txtLoginId
            // 
            this.txtLoginId.Location = new System.Drawing.Point(115, 129);
            this.txtLoginId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(532, 25);
            this.txtLoginId.TabIndex = 53;
            this.txtLoginId.Tag = "mandantory";
            // 
            // lblLoginId
            // 
            this.lblLoginId.AutoSize = true;
            this.lblLoginId.ForeColor = System.Drawing.Color.Red;
            this.lblLoginId.Location = new System.Drawing.Point(32, 134);
            this.lblLoginId.Name = "lblLoginId";
            this.lblLoginId.Size = new System.Drawing.Size(68, 15);
            this.lblLoginId.TabIndex = 52;
            this.lblLoginId.Text = "* login ID";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(800, 132);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(532, 25);
            this.txtPassword.TabIndex = 55;
            this.txtPassword.Tag = "mandantory";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.Red;
            this.lblPassword.Location = new System.Drawing.Point(679, 134);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(84, 15);
            this.lblPassword.TabIndex = 54;
            this.lblPassword.Text = "* Password";
            // 
            // txtAppId
            // 
            this.txtAppId.Location = new System.Drawing.Point(800, 93);
            this.txtAppId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppId.Name = "txtAppId";
            this.txtAppId.Size = new System.Drawing.Size(532, 25);
            this.txtAppId.TabIndex = 57;
            this.txtAppId.Tag = "mandantory";
            this.txtAppId.Visible = false;
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.ForeColor = System.Drawing.Color.Red;
            this.lblAppId.Location = new System.Drawing.Point(679, 98);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(62, 15);
            this.lblAppId.TabIndex = 56;
            this.lblAppId.Text = "* App ID";
            this.lblAppId.Visible = false;
            // 
            // frmUserRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 776);
            this.Controls.Add(this.txtAppId);
            this.Controls.Add(this.lblAppId);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtLoginId);
            this.Controls.Add(this.lblLoginId);
            this.Controls.Add(this.btnAcc);
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
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblfirstName);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnIns);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmUserRequest";
            this.Text = "User Request";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAcc;
        private System.Windows.Forms.TextBox txtEmplId;
        private System.Windows.Forms.Label lblEmplId;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblfirstName;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.TextBox txtLoginId;
        private System.Windows.Forms.Label lblLoginId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtAppId;
        private System.Windows.Forms.Label lblAppId;
    }
}