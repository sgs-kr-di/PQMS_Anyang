
namespace userManagement
{
    partial class frmDeptMaster
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
            this.txtParentId = new System.Windows.Forms.TextBox();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.lblDeptName = new System.Windows.Forms.Label();
            this.lblParentId = new System.Windows.Forms.Label();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.treeDept = new System.Windows.Forms.TreeView();
            this.txtDeptId = new System.Windows.Forms.TextBox();
            this.lblDeptId = new System.Windows.Forms.Label();
            this.rdoDisuse = new System.Windows.Forms.RadioButton();
            this.lblDisuse = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtParentId
            // 
            this.txtParentId.Location = new System.Drawing.Point(463, 121);
            this.txtParentId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtParentId.Name = "txtParentId";
            this.txtParentId.Size = new System.Drawing.Size(269, 21);
            this.txtParentId.TabIndex = 45;
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(463, 90);
            this.txtDeptName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(269, 21);
            this.txtDeptName.TabIndex = 43;
            // 
            // lblDeptName
            // 
            this.lblDeptName.AutoSize = true;
            this.lblDeptName.Location = new System.Drawing.Point(390, 93);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(64, 12);
            this.lblDeptName.TabIndex = 42;
            this.lblDeptName.Text = "DeptName";
            // 
            // lblParentId
            // 
            this.lblParentId.AutoSize = true;
            this.lblParentId.Location = new System.Drawing.Point(390, 125);
            this.lblParentId.Name = "lblParentId";
            this.lblParentId.Size = new System.Drawing.Size(52, 12);
            this.lblParentId.TabIndex = 44;
            this.lblParentId.Text = "ParentID";
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(214, 18);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(66, 18);
            this.btnUpd.TabIndex = 39;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(388, 18);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(66, 18);
            this.btnDel.TabIndex = 38;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(29, 18);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(66, 18);
            this.btnIns.TabIndex = 37;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // treeDept
            // 
            this.treeDept.CheckBoxes = true;
            this.treeDept.Location = new System.Drawing.Point(29, 62);
            this.treeDept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeDept.Name = "treeDept";
            this.treeDept.Size = new System.Drawing.Size(357, 442);
            this.treeDept.TabIndex = 46;
            // 
            // txtDeptId
            // 
            this.txtDeptId.Location = new System.Drawing.Point(463, 62);
            this.txtDeptId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDeptId.Name = "txtDeptId";
            this.txtDeptId.Size = new System.Drawing.Size(269, 21);
            this.txtDeptId.TabIndex = 48;
            // 
            // lblDeptId
            // 
            this.lblDeptId.AutoSize = true;
            this.lblDeptId.Location = new System.Drawing.Point(390, 65);
            this.lblDeptId.Name = "lblDeptId";
            this.lblDeptId.Size = new System.Drawing.Size(41, 12);
            this.lblDeptId.TabIndex = 47;
            this.lblDeptId.Text = "DeptID";
            // 
            // rdoDisuse
            // 
            this.rdoDisuse.AutoSize = true;
            this.rdoDisuse.Location = new System.Drawing.Point(510, 155);
            this.rdoDisuse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoDisuse.Name = "rdoDisuse";
            this.rdoDisuse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoDisuse.Size = new System.Drawing.Size(31, 16);
            this.rdoDisuse.TabIndex = 50;
            this.rdoDisuse.TabStop = true;
            this.rdoDisuse.Text = "Y";
            this.rdoDisuse.UseVisualStyleBackColor = true;
            // 
            // lblDisuse
            // 
            this.lblDisuse.AutoSize = true;
            this.lblDisuse.Location = new System.Drawing.Point(390, 155);
            this.lblDisuse.Name = "lblDisuse";
            this.lblDisuse.Size = new System.Drawing.Size(44, 12);
            this.lblDisuse.TabIndex = 49;
            this.lblDisuse.Text = "Disuse";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("궁서체", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(392, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 15);
            this.label1.TabIndex = 51;
            this.label1.Text = "* BOSS Sector, CostCenter 기준으로 기입 할것";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDeptMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 529);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoDisuse);
            this.Controls.Add(this.lblDisuse);
            this.Controls.Add(this.txtDeptId);
            this.Controls.Add(this.lblDeptId);
            this.Controls.Add(this.treeDept);
            this.Controls.Add(this.txtParentId);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.lblDeptName);
            this.Controls.Add(this.lblParentId);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnIns);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDeptMaster";
            this.Text = "deptMaster";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtParentId;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label lblDeptName;
        private System.Windows.Forms.Label lblParentId;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.TreeView treeDept;
        private System.Windows.Forms.TextBox txtDeptId;
        private System.Windows.Forms.Label lblDeptId;
        private System.Windows.Forms.RadioButton rdoDisuse;
        private System.Windows.Forms.Label lblDisuse;
        private System.Windows.Forms.Label label1;
    }
}