
namespace userManagement
{
    partial class frmApproveRole
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
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.lblDisuse = new System.Windows.Forms.Label();
            this.txtAppId = new System.Windows.Forms.TextBox();
            this.lblAppId = new System.Windows.Forms.Label();
            this.txtRoleDepth = new System.Windows.Forms.TextBox();
            this.txtGroupNo = new System.Windows.Forms.TextBox();
            this.lblGroupNo = new System.Windows.Forms.Label();
            this.lblRoleDepth = new System.Windows.Forms.Label();
            this.rdoDisuse = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(214, 23);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(66, 18);
            this.btnUpd.TabIndex = 74;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(388, 23);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(66, 18);
            this.btnDel.TabIndex = 73;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(29, 23);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(66, 18);
            this.btnIns.TabIndex = 72;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // lblDisuse
            // 
            this.lblDisuse.AutoSize = true;
            this.lblDisuse.Location = new System.Drawing.Point(27, 185);
            this.lblDisuse.Name = "lblDisuse";
            this.lblDisuse.Size = new System.Drawing.Size(44, 12);
            this.lblDisuse.TabIndex = 70;
            this.lblDisuse.Text = "Disuse";
            // 
            // txtAppId
            // 
            this.txtAppId.Location = new System.Drawing.Point(127, 63);
            this.txtAppId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppId.Name = "txtAppId";
            this.txtAppId.Size = new System.Drawing.Size(269, 21);
            this.txtAppId.TabIndex = 80;
            this.txtAppId.Visible = false;
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(27, 66);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(44, 12);
            this.lblAppId.TabIndex = 79;
            this.lblAppId.Text = "APP ID";
            this.lblAppId.Visible = false;
            // 
            // txtRoleDepth
            // 
            this.txtRoleDepth.Location = new System.Drawing.Point(127, 122);
            this.txtRoleDepth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRoleDepth.Name = "txtRoleDepth";
            this.txtRoleDepth.Size = new System.Drawing.Size(269, 21);
            this.txtRoleDepth.TabIndex = 78;
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.Location = new System.Drawing.Point(127, 91);
            this.txtGroupNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(269, 21);
            this.txtGroupNo.TabIndex = 76;
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(27, 94);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(59, 12);
            this.lblGroupNo.TabIndex = 75;
            this.lblGroupNo.Text = "Group No";
            // 
            // lblRoleDepth
            // 
            this.lblRoleDepth.AutoSize = true;
            this.lblRoleDepth.Location = new System.Drawing.Point(27, 126);
            this.lblRoleDepth.Name = "lblRoleDepth";
            this.lblRoleDepth.Size = new System.Drawing.Size(66, 12);
            this.lblRoleDepth.TabIndex = 77;
            this.lblRoleDepth.Text = "Role Depth";
            // 
            // rdoDisuse
            // 
            this.rdoDisuse.AutoSize = true;
            this.rdoDisuse.Location = new System.Drawing.Point(127, 181);
            this.rdoDisuse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoDisuse.Name = "rdoDisuse";
            this.rdoDisuse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoDisuse.Size = new System.Drawing.Size(31, 16);
            this.rdoDisuse.TabIndex = 81;
            this.rdoDisuse.TabStop = true;
            this.rdoDisuse.Text = "Y";
            this.rdoDisuse.UseVisualStyleBackColor = true;
            // 
            // frmApproveRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rdoDisuse);
            this.Controls.Add(this.txtAppId);
            this.Controls.Add(this.lblAppId);
            this.Controls.Add(this.txtRoleDepth);
            this.Controls.Add(this.txtGroupNo);
            this.Controls.Add(this.lblGroupNo);
            this.Controls.Add(this.lblRoleDepth);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnIns);
            this.Controls.Add(this.lblDisuse);
            this.Name = "frmApproveRole";
            this.Text = "Approve Role";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.Label lblDisuse;
        private System.Windows.Forms.TextBox txtAppId;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.TextBox txtRoleDepth;
        private System.Windows.Forms.TextBox txtGroupNo;
        private System.Windows.Forms.Label lblGroupNo;
        private System.Windows.Forms.Label lblRoleDepth;
        private System.Windows.Forms.RadioButton rdoDisuse;
    }
}