
namespace userManagement
{
    partial class frmGroupMemberMaster
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
            this.lblMemberNo = new System.Windows.Forms.Label();
            this.txtSelectedMemberNo = new System.Windows.Forms.TextBox();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.txtSelectedAccountNo = new System.Windows.Forms.TextBox();
            this.lblGroupNo = new System.Windows.Forms.Label();
            this.txtSelectedGroupNo = new System.Windows.Forms.TextBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.cmbLoginId = new System.Windows.Forms.ComboBox();
            this.cmbAppId = new System.Windows.Forms.ComboBox();
            this.lblAppId = new System.Windows.Forms.Label();
            this.cmbGroupName = new System.Windows.Forms.ComboBox();
            this.chkDisuse = new System.Windows.Forms.CheckBox();
            this.btnSel = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnIns = new System.Windows.Forms.Button();
            this.dgvGroupMemberMaster = new System.Windows.Forms.DataGridView();
            this.lblDisuse = new System.Windows.Forms.Label();
            this.lblLoginId = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.cmbGroupType = new System.Windows.Forms.ComboBox();
            this.lblGroupType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupMemberMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMemberNo
            // 
            this.lblMemberNo.AutoSize = true;
            this.lblMemberNo.Location = new System.Drawing.Point(668, 118);
            this.lblMemberNo.Name = "lblMemberNo";
            this.lblMemberNo.Size = new System.Drawing.Size(72, 12);
            this.lblMemberNo.TabIndex = 282;
            this.lblMemberNo.Text = "Member No";
            // 
            // txtSelectedMemberNo
            // 
            this.txtSelectedMemberNo.Enabled = false;
            this.txtSelectedMemberNo.Location = new System.Drawing.Point(746, 113);
            this.txtSelectedMemberNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedMemberNo.Name = "txtSelectedMemberNo";
            this.txtSelectedMemberNo.Size = new System.Drawing.Size(157, 21);
            this.txtSelectedMemberNo.TabIndex = 281;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(668, 58);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(71, 12);
            this.lblAccountNo.TabIndex = 280;
            this.lblAccountNo.Text = "Account No";
            // 
            // txtSelectedAccountNo
            // 
            this.txtSelectedAccountNo.Enabled = false;
            this.txtSelectedAccountNo.Location = new System.Drawing.Point(746, 53);
            this.txtSelectedAccountNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedAccountNo.Name = "txtSelectedAccountNo";
            this.txtSelectedAccountNo.Size = new System.Drawing.Size(157, 21);
            this.txtSelectedAccountNo.TabIndex = 279;
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(668, 86);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(57, 12);
            this.lblGroupNo.TabIndex = 278;
            this.lblGroupNo.Text = "group No";
            // 
            // txtSelectedGroupNo
            // 
            this.txtSelectedGroupNo.Enabled = false;
            this.txtSelectedGroupNo.Location = new System.Drawing.Point(746, 80);
            this.txtSelectedGroupNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedGroupNo.Name = "txtSelectedGroupNo";
            this.txtSelectedGroupNo.Size = new System.Drawing.Size(157, 21);
            this.txtSelectedGroupNo.TabIndex = 277;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(728, 23);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(53, 16);
            this.lblMode.TabIndex = 276;
            this.lblMode.Text = "MODE";
            // 
            // cmbLoginId
            // 
            this.cmbLoginId.FormattingEnabled = true;
            this.cmbLoginId.Location = new System.Drawing.Point(117, 86);
            this.cmbLoginId.Name = "cmbLoginId";
            this.cmbLoginId.Size = new System.Drawing.Size(466, 20);
            this.cmbLoginId.TabIndex = 275;
            this.cmbLoginId.SelectedIndexChanged += new System.EventHandler(this.cmbLoginId_SelectedIndexChanged);
            // 
            // cmbAppId
            // 
            this.cmbAppId.FormattingEnabled = true;
            this.cmbAppId.Location = new System.Drawing.Point(117, 55);
            this.cmbAppId.Name = "cmbAppId";
            this.cmbAppId.Size = new System.Drawing.Size(466, 20);
            this.cmbAppId.TabIndex = 274;
            this.cmbAppId.SelectedIndexChanged += new System.EventHandler(this.cmbAppId_SelectedIndexChanged);
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(26, 61);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(72, 12);
            this.lblAppId.TabIndex = 273;
            this.lblAppId.Text = "APP ID 선택";
            // 
            // cmbGroupName
            // 
            this.cmbGroupName.FormattingEnabled = true;
            this.cmbGroupName.Location = new System.Drawing.Point(117, 151);
            this.cmbGroupName.Name = "cmbGroupName";
            this.cmbGroupName.Size = new System.Drawing.Size(466, 20);
            this.cmbGroupName.TabIndex = 272;
            this.cmbGroupName.SelectedIndexChanged += new System.EventHandler(this.cmbGroupName_SelectedIndexChanged);
            // 
            // chkDisuse
            // 
            this.chkDisuse.AutoSize = true;
            this.chkDisuse.Location = new System.Drawing.Point(116, 179);
            this.chkDisuse.Name = "chkDisuse";
            this.chkDisuse.Size = new System.Drawing.Size(63, 16);
            this.chkDisuse.TabIndex = 271;
            this.chkDisuse.Text = "Disuse";
            this.chkDisuse.UseVisualStyleBackColor = true;
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(28, 21);
            this.btnSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(66, 24);
            this.btnSel.TabIndex = 270;
            this.btnSel.Text = "조회";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(287, 21);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(66, 24);
            this.btnUpd.TabIndex = 268;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(446, 21);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 24);
            this.btnSave.TabIndex = 269;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FillWeight = 10F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "A";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(156, 21);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(66, 24);
            this.btnIns.TabIndex = 267;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // dgvGroupMemberMaster
            // 
            this.dgvGroupMemberMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupMemberMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvGroupMemberMaster.Location = new System.Drawing.Point(13, 214);
            this.dgvGroupMemberMaster.MultiSelect = false;
            this.dgvGroupMemberMaster.Name = "dgvGroupMemberMaster";
            this.dgvGroupMemberMaster.ReadOnly = true;
            this.dgvGroupMemberMaster.RowHeadersWidth = 51;
            this.dgvGroupMemberMaster.RowTemplate.Height = 24;
            this.dgvGroupMemberMaster.Size = new System.Drawing.Size(1215, 371);
            this.dgvGroupMemberMaster.TabIndex = 266;
            this.dgvGroupMemberMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupMemberMaster_CellClick);
            // 
            // lblDisuse
            // 
            this.lblDisuse.AutoSize = true;
            this.lblDisuse.Location = new System.Drawing.Point(26, 182);
            this.lblDisuse.Name = "lblDisuse";
            this.lblDisuse.Size = new System.Drawing.Size(44, 12);
            this.lblDisuse.TabIndex = 265;
            this.lblDisuse.Text = "Disuse";
            // 
            // lblLoginId
            // 
            this.lblLoginId.AutoSize = true;
            this.lblLoginId.Location = new System.Drawing.Point(26, 92);
            this.lblLoginId.Name = "lblLoginId";
            this.lblLoginId.Size = new System.Drawing.Size(51, 12);
            this.lblLoginId.TabIndex = 263;
            this.lblLoginId.Text = "Login ID";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(26, 156);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(77, 12);
            this.lblGroupName.TabIndex = 264;
            this.lblGroupName.Text = "Group Name";
            // 
            // cmbGroupType
            // 
            this.cmbGroupType.FormattingEnabled = true;
            this.cmbGroupType.Location = new System.Drawing.Point(117, 117);
            this.cmbGroupType.Name = "cmbGroupType";
            this.cmbGroupType.Size = new System.Drawing.Size(466, 20);
            this.cmbGroupType.TabIndex = 284;
            this.cmbGroupType.SelectedIndexChanged += new System.EventHandler(this.cmbGroupType_SelectedIndexChanged);
            // 
            // lblGroupType
            // 
            this.lblGroupType.AutoSize = true;
            this.lblGroupType.Location = new System.Drawing.Point(26, 122);
            this.lblGroupType.Name = "lblGroupType";
            this.lblGroupType.Size = new System.Drawing.Size(72, 12);
            this.lblGroupType.TabIndex = 283;
            this.lblGroupType.Text = "Group Type";
            // 
            // frmGroupMemberMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 597);
            this.Controls.Add(this.cmbGroupType);
            this.Controls.Add(this.lblGroupType);
            this.Controls.Add(this.lblMemberNo);
            this.Controls.Add(this.txtSelectedMemberNo);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.txtSelectedAccountNo);
            this.Controls.Add(this.lblGroupNo);
            this.Controls.Add(this.txtSelectedGroupNo);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.cmbLoginId);
            this.Controls.Add(this.cmbAppId);
            this.Controls.Add(this.lblAppId);
            this.Controls.Add(this.cmbGroupName);
            this.Controls.Add(this.chkDisuse);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnIns);
            this.Controls.Add(this.dgvGroupMemberMaster);
            this.Controls.Add(this.lblDisuse);
            this.Controls.Add(this.lblLoginId);
            this.Controls.Add(this.lblGroupName);
            this.Name = "frmGroupMemberMaster";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupMemberMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMemberNo;
        private System.Windows.Forms.TextBox txtSelectedMemberNo;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.TextBox txtSelectedAccountNo;
        private System.Windows.Forms.Label lblGroupNo;
        private System.Windows.Forms.TextBox txtSelectedGroupNo;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cmbLoginId;
        private System.Windows.Forms.ComboBox cmbAppId;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.ComboBox cmbGroupName;
        private System.Windows.Forms.CheckBox chkDisuse;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.DataGridView dgvGroupMemberMaster;
        private System.Windows.Forms.Label lblDisuse;
        private System.Windows.Forms.Label lblLoginId;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.ComboBox cmbGroupType;
        private System.Windows.Forms.Label lblGroupType;
    }
}