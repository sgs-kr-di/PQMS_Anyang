
namespace userManagement
{
    partial class frmAccountMaster
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtAppId = new System.Windows.Forms.TextBox();
            this.lblAppId = new System.Windows.Forms.Label();
            this.txtLogInId = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblLogInId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.lblApprovedBy = new System.Windows.Forms.Label();
            this.txtRequestStatus = new System.Windows.Forms.TextBox();
            this.lblRequestStatus = new System.Windows.Forms.Label();
            this.rdoDisuse = new System.Windows.Forms.RadioButton();
            this.lblDisuse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(130, 160);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(466, 21);
            this.txtPassword.TabIndex = 36;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(44, 162);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(62, 12);
            this.lblPassword.TabIndex = 35;
            this.lblPassword.Text = "Password";
            // 
            // txtAppId
            // 
            this.txtAppId.Location = new System.Drawing.Point(130, 128);
            this.txtAppId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppId.Name = "txtAppId";
            this.txtAppId.Size = new System.Drawing.Size(466, 21);
            this.txtAppId.TabIndex = 34;
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(44, 130);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(37, 12);
            this.lblAppId.TabIndex = 33;
            this.lblAppId.Text = "AppId";
            // 
            // txtLogInId
            // 
            this.txtLogInId.Location = new System.Drawing.Point(130, 61);
            this.txtLogInId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLogInId.Name = "txtLogInId";
            this.txtLogInId.Size = new System.Drawing.Size(466, 21);
            this.txtLogInId.TabIndex = 32;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblLogInId
            // 
            this.lblLogInId.AutoSize = true;
            this.lblLogInId.Location = new System.Drawing.Point(44, 65);
            this.lblLogInId.Name = "lblLogInId";
            this.lblLogInId.Size = new System.Drawing.Size(47, 12);
            this.lblLogInId.TabIndex = 31;
            this.lblLogInId.Text = "LogInID";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(130, 95);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(466, 21);
            this.txtUserId.TabIndex = 28;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(44, 97);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(41, 12);
            this.lblUserId.TabIndex = 27;
            this.lblUserId.Text = "userID";
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(229, 30);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(66, 18);
            this.btnUpd.TabIndex = 26;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(403, 30);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(66, 18);
            this.btnDel.TabIndex = 25;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(44, 30);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(66, 18);
            this.btnIns.TabIndex = 24;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.Location = new System.Drawing.Point(129, 221);
            this.txtApprovedBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.Size = new System.Drawing.Size(466, 21);
            this.txtApprovedBy.TabIndex = 38;
            // 
            // lblApprovedBy
            // 
            this.lblApprovedBy.AutoSize = true;
            this.lblApprovedBy.Location = new System.Drawing.Point(43, 224);
            this.lblApprovedBy.Name = "lblApprovedBy";
            this.lblApprovedBy.Size = new System.Drawing.Size(73, 12);
            this.lblApprovedBy.TabIndex = 37;
            this.lblApprovedBy.Text = "ApprovedBy";
            // 
            // txtRequestStatus
            // 
            this.txtRequestStatus.Location = new System.Drawing.Point(130, 191);
            this.txtRequestStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRequestStatus.Name = "txtRequestStatus";
            this.txtRequestStatus.Size = new System.Drawing.Size(466, 21);
            this.txtRequestStatus.TabIndex = 40;
            // 
            // lblRequestStatus
            // 
            this.lblRequestStatus.AutoSize = true;
            this.lblRequestStatus.Location = new System.Drawing.Point(42, 193);
            this.lblRequestStatus.Name = "lblRequestStatus";
            this.lblRequestStatus.Size = new System.Drawing.Size(82, 12);
            this.lblRequestStatus.TabIndex = 39;
            this.lblRequestStatus.Text = "requestStatus";
            // 
            // rdoDisuse
            // 
            this.rdoDisuse.AutoSize = true;
            this.rdoDisuse.Location = new System.Drawing.Point(164, 252);
            this.rdoDisuse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoDisuse.Name = "rdoDisuse";
            this.rdoDisuse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoDisuse.Size = new System.Drawing.Size(31, 16);
            this.rdoDisuse.TabIndex = 42;
            this.rdoDisuse.TabStop = true;
            this.rdoDisuse.Text = "Y";
            this.rdoDisuse.UseVisualStyleBackColor = true;
            // 
            // lblDisuse
            // 
            this.lblDisuse.AutoSize = true;
            this.lblDisuse.Location = new System.Drawing.Point(44, 252);
            this.lblDisuse.Name = "lblDisuse";
            this.lblDisuse.Size = new System.Drawing.Size(44, 12);
            this.lblDisuse.TabIndex = 41;
            this.lblDisuse.Text = "Disuse";
            // 
            // frmAccountMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 529);
            this.Controls.Add(this.rdoDisuse);
            this.Controls.Add(this.lblDisuse);
            this.Controls.Add(this.txtRequestStatus);
            this.Controls.Add(this.lblRequestStatus);
            this.Controls.Add(this.txtApprovedBy);
            this.Controls.Add(this.lblApprovedBy);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtAppId);
            this.Controls.Add(this.lblAppId);
            this.Controls.Add(this.txtLogInId);
            this.Controls.Add(this.lblLogInId);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnIns);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAccountMaster";
            this.Text = "AccountMaster";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtAppId;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.TextBox txtLogInId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblLogInId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.Label lblApprovedBy;
        private System.Windows.Forms.TextBox txtRequestStatus;
        private System.Windows.Forms.Label lblRequestStatus;
        private System.Windows.Forms.RadioButton rdoDisuse;
        private System.Windows.Forms.Label lblDisuse;
    }
}