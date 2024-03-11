
namespace userManagement
{
    partial class frmGroupMaster
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
            this.txtRoleCode = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.lblRoleCode = new System.Windows.Forms.Label();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.lblDeptId = new System.Windows.Forms.Label();
            this.lblDisuse = new System.Windows.Forms.Label();
            this.lblRoleType = new System.Windows.Forms.Label();
            this.btnSel = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.dgvGroupMaster = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkDisuse = new System.Windows.Forms.CheckBox();
            this.cmbAppId = new System.Windows.Forms.ComboBox();
            this.lblAppId = new System.Windows.Forms.Label();
            this.lblAppNoSelected = new System.Windows.Forms.Label();
            this.txtSelectedAppNo = new System.Windows.Forms.TextBox();
            this.cmbDeptName = new System.Windows.Forms.ComboBox();
            this.lblDeptNoSelected = new System.Windows.Forms.Label();
            this.txtSelectedDeptNo = new System.Windows.Forms.TextBox();
            this.cmbRoleType = new System.Windows.Forms.ComboBox();
            this.lblGroupNo = new System.Windows.Forms.Label();
            this.txtSelectedGroupNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRoleCode
            // 
            this.txtRoleCode.Location = new System.Drawing.Point(109, 128);
            this.txtRoleCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRoleCode.Name = "txtRoleCode";
            this.txtRoleCode.Size = new System.Drawing.Size(312, 21);
            this.txtRoleCode.TabIndex = 5;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(110, 55);
            this.txtGroupName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(312, 21);
            this.txtGroupName.TabIndex = 2;
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(12, 57);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(73, 12);
            this.lblGroupName.TabIndex = 50;
            this.lblGroupName.Text = "GroupName";
            // 
            // lblRoleCode
            // 
            this.lblRoleCode.AutoSize = true;
            this.lblRoleCode.Location = new System.Drawing.Point(12, 133);
            this.lblRoleCode.Name = "lblRoleCode";
            this.lblRoleCode.Size = new System.Drawing.Size(60, 12);
            this.lblRoleCode.TabIndex = 52;
            this.lblRoleCode.Text = "RoleCode";
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(273, 11);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(66, 24);
            this.btnUpd.TabIndex = 8;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(432, 11);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 24);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(142, 11);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(66, 24);
            this.btnIns.TabIndex = 7;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // lblDeptId
            // 
            this.lblDeptId.AutoSize = true;
            this.lblDeptId.Location = new System.Drawing.Point(454, 101);
            this.lblDeptId.Name = "lblDeptId";
            this.lblDeptId.Size = new System.Drawing.Size(80, 12);
            this.lblDeptId.TabIndex = 57;
            this.lblDeptId.Text = "DEPT ID 선택";
            // 
            // lblDisuse
            // 
            this.lblDisuse.AutoSize = true;
            this.lblDisuse.Location = new System.Drawing.Point(457, 60);
            this.lblDisuse.Name = "lblDisuse";
            this.lblDisuse.Size = new System.Drawing.Size(44, 12);
            this.lblDisuse.TabIndex = 59;
            this.lblDisuse.Text = "Disuse";
            // 
            // lblRoleType
            // 
            this.lblRoleType.AutoSize = true;
            this.lblRoleType.Location = new System.Drawing.Point(456, 135);
            this.lblRoleType.Name = "lblRoleType";
            this.lblRoleType.Size = new System.Drawing.Size(59, 12);
            this.lblRoleType.TabIndex = 63;
            this.lblRoleType.Text = "RoleType";
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(14, 11);
            this.btnSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(66, 24);
            this.btnSel.TabIndex = 242;
            this.btnSel.Text = "조회";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(886, 19);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(53, 16);
            this.lblMode.TabIndex = 245;
            this.lblMode.Text = "MODE";
            // 
            // dgvGroupMaster
            // 
            this.dgvGroupMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvGroupMaster.Location = new System.Drawing.Point(28, 195);
            this.dgvGroupMaster.MultiSelect = false;
            this.dgvGroupMaster.Name = "dgvGroupMaster";
            this.dgvGroupMaster.ReadOnly = true;
            this.dgvGroupMaster.RowHeadersWidth = 51;
            this.dgvGroupMaster.RowTemplate.Height = 24;
            this.dgvGroupMaster.Size = new System.Drawing.Size(1066, 314);
            this.dgvGroupMaster.TabIndex = 244;
            this.dgvGroupMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupMaster_CellClick);
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // chkDisuse
            // 
            this.chkDisuse.AutoSize = true;
            this.chkDisuse.Location = new System.Drawing.Point(539, 58);
            this.chkDisuse.Name = "chkDisuse";
            this.chkDisuse.Size = new System.Drawing.Size(63, 16);
            this.chkDisuse.TabIndex = 246;
            this.chkDisuse.Text = "Disuse";
            this.chkDisuse.UseVisualStyleBackColor = true;
            // 
            // cmbAppId
            // 
            this.cmbAppId.FormattingEnabled = true;
            this.cmbAppId.Location = new System.Drawing.Point(110, 91);
            this.cmbAppId.Name = "cmbAppId";
            this.cmbAppId.Size = new System.Drawing.Size(311, 20);
            this.cmbAppId.TabIndex = 248;
            this.cmbAppId.SelectedIndexChanged += new System.EventHandler(this.cmbAppId_SelectedIndexChanged);
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(12, 97);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(72, 12);
            this.lblAppId.TabIndex = 247;
            this.lblAppId.Text = "APP ID 선택";
            // 
            // lblAppNoSelected
            // 
            this.lblAppNoSelected.AutoSize = true;
            this.lblAppNoSelected.Location = new System.Drawing.Point(832, 64);
            this.lblAppNoSelected.Name = "lblAppNoSelected";
            this.lblAppNoSelected.Size = new System.Drawing.Size(51, 12);
            this.lblAppNoSelected.TabIndex = 250;
            this.lblAppNoSelected.Text = "APP NO";
            this.lblAppNoSelected.Visible = false;
            // 
            // txtSelectedAppNo
            // 
            this.txtSelectedAppNo.Enabled = false;
            this.txtSelectedAppNo.Location = new System.Drawing.Point(894, 59);
            this.txtSelectedAppNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedAppNo.Name = "txtSelectedAppNo";
            this.txtSelectedAppNo.Size = new System.Drawing.Size(148, 21);
            this.txtSelectedAppNo.TabIndex = 249;
            this.txtSelectedAppNo.Visible = false;
            // 
            // cmbDeptName
            // 
            this.cmbDeptName.FormattingEnabled = true;
            this.cmbDeptName.Location = new System.Drawing.Point(539, 96);
            this.cmbDeptName.Name = "cmbDeptName";
            this.cmbDeptName.Size = new System.Drawing.Size(268, 20);
            this.cmbDeptName.TabIndex = 251;
            this.cmbDeptName.SelectedIndexChanged += new System.EventHandler(this.cmbDeptId_SelectedIndexChanged);
            // 
            // lblDeptNoSelected
            // 
            this.lblDeptNoSelected.AutoSize = true;
            this.lblDeptNoSelected.Location = new System.Drawing.Point(832, 100);
            this.lblDeptNoSelected.Name = "lblDeptNoSelected";
            this.lblDeptNoSelected.Size = new System.Drawing.Size(57, 12);
            this.lblDeptNoSelected.TabIndex = 253;
            this.lblDeptNoSelected.Text = "DEPT No";
            this.lblDeptNoSelected.Visible = false;
            // 
            // txtSelectedDeptNo
            // 
            this.txtSelectedDeptNo.Enabled = false;
            this.txtSelectedDeptNo.Location = new System.Drawing.Point(894, 95);
            this.txtSelectedDeptNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedDeptNo.Name = "txtSelectedDeptNo";
            this.txtSelectedDeptNo.Size = new System.Drawing.Size(148, 21);
            this.txtSelectedDeptNo.TabIndex = 252;
            this.txtSelectedDeptNo.Visible = false;
            // 
            // cmbRoleType
            // 
            this.cmbRoleType.FormattingEnabled = true;
            this.cmbRoleType.Location = new System.Drawing.Point(539, 134);
            this.cmbRoleType.Name = "cmbRoleType";
            this.cmbRoleType.Size = new System.Drawing.Size(268, 20);
            this.cmbRoleType.TabIndex = 254;
            this.cmbRoleType.SelectedIndexChanged += new System.EventHandler(this.cmbRoleType_SelectedIndexChanged);
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(832, 131);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(57, 12);
            this.lblGroupNo.TabIndex = 256;
            this.lblGroupNo.Text = "group No";
            this.lblGroupNo.Visible = false;
            // 
            // txtSelectedGroupNo
            // 
            this.txtSelectedGroupNo.Enabled = false;
            this.txtSelectedGroupNo.Location = new System.Drawing.Point(894, 126);
            this.txtSelectedGroupNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedGroupNo.Name = "txtSelectedGroupNo";
            this.txtSelectedGroupNo.Size = new System.Drawing.Size(157, 21);
            this.txtSelectedGroupNo.TabIndex = 255;
            this.txtSelectedGroupNo.Visible = false;
            // 
            // frmGroupMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 529);
            this.Controls.Add(this.lblGroupNo);
            this.Controls.Add(this.txtSelectedGroupNo);
            this.Controls.Add(this.cmbRoleType);
            this.Controls.Add(this.lblDeptNoSelected);
            this.Controls.Add(this.txtSelectedDeptNo);
            this.Controls.Add(this.cmbDeptName);
            this.Controls.Add(this.lblAppNoSelected);
            this.Controls.Add(this.txtSelectedAppNo);
            this.Controls.Add(this.cmbAppId);
            this.Controls.Add(this.lblAppId);
            this.Controls.Add(this.chkDisuse);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.dgvGroupMaster);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.lblRoleType);
            this.Controls.Add(this.lblDisuse);
            this.Controls.Add(this.lblDeptId);
            this.Controls.Add(this.txtRoleCode);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.lblRoleCode);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnIns);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmGroupMaster";
            this.Text = "Group Master";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtRoleCode;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Label lblRoleCode;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.Label lblDeptId;
        private System.Windows.Forms.Label lblDisuse;
        private System.Windows.Forms.Label lblRoleType;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.DataGridView dgvGroupMaster;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.CheckBox chkDisuse;
        private System.Windows.Forms.ComboBox cmbAppId;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.Label lblAppNoSelected;
        private System.Windows.Forms.TextBox txtSelectedAppNo;
        private System.Windows.Forms.ComboBox cmbDeptName;
        private System.Windows.Forms.Label lblDeptNoSelected;
        private System.Windows.Forms.TextBox txtSelectedDeptNo;
        private System.Windows.Forms.ComboBox cmbRoleType;
        private System.Windows.Forms.Label lblGroupNo;
        private System.Windows.Forms.TextBox txtSelectedGroupNo;
    }
}