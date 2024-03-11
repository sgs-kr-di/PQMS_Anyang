
namespace userManagement
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtAppId = new System.Windows.Forms.TextBox();
            this.lblAppId = new System.Windows.Forms.Label();
            this.txtLogInId = new System.Windows.Forms.TextBox();
            this.lblLogInId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(115, 167);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(466, 21);
            this.txtPassword.TabIndex = 53;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(29, 169);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(62, 12);
            this.lblPassword.TabIndex = 52;
            this.lblPassword.Text = "Password";
            // 
            // txtAppId
            // 
            this.txtAppId.Location = new System.Drawing.Point(115, 135);
            this.txtAppId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppId.Name = "txtAppId";
            this.txtAppId.Size = new System.Drawing.Size(466, 21);
            this.txtAppId.TabIndex = 51;
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(29, 137);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(38, 12);
            this.lblAppId.TabIndex = 50;
            this.lblAppId.Text = "AppID";
            // 
            // txtLogInId
            // 
            this.txtLogInId.Location = new System.Drawing.Point(115, 102);
            this.txtLogInId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLogInId.Name = "txtLogInId";
            this.txtLogInId.Size = new System.Drawing.Size(466, 21);
            this.txtLogInId.TabIndex = 49;
            // 
            // lblLogInId
            // 
            this.lblLogInId.AutoSize = true;
            this.lblLogInId.Location = new System.Drawing.Point(29, 106);
            this.lblLogInId.Name = "lblLogInId";
            this.lblLogInId.Size = new System.Drawing.Size(47, 12);
            this.lblLogInId.TabIndex = 48;
            this.lblLogInId.Text = "LogInID";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(115, 70);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(466, 21);
            this.txtUserId.TabIndex = 47;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(29, 75);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(41, 12);
            this.lblUserId.TabIndex = 46;
            this.lblUserId.Text = "userID";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(118, 39);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 18);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(29, 39);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(66, 18);
            this.btnIns.TabIndex = 43;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // frmAccountRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 529);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtAppId;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.TextBox txtLogInId;
        private System.Windows.Forms.Label lblLogInId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnIns;
    }
}