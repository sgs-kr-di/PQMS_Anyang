
namespace userManagement
{
    partial class frmMenuRole
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
            this.lblRole = new System.Windows.Forms.Label();
            this.btnIns = new System.Windows.Forms.Button();
            this.lblDisuse = new System.Windows.Forms.Label();
            this.lblAppId = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.lblMenuName = new System.Windows.Forms.Label();
            this.chkSearch = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.chkDownload = new System.Windows.Forms.CheckBox();
            this.chkUpload = new System.Windows.Forms.CheckBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.chkDisuse = new System.Windows.Forms.CheckBox();
            this.dgvMenuRoleMaster = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSel = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.cmbAppId = new System.Windows.Forms.ComboBox();
            this.cmbGroupNo = new System.Windows.Forms.ComboBox();
            this.cmbMenuNo = new System.Windows.Forms.ComboBox();
            this.lblMenuNo = new System.Windows.Forms.Label();
            this.txtSelectedMenuNo = new System.Windows.Forms.TextBox();
            this.lblGroupNo = new System.Windows.Forms.Label();
            this.txtSelectedGroupNo = new System.Windows.Forms.TextBox();
            this.lblMenurole = new System.Windows.Forms.Label();
            this.txtSelectedMenuRoleNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuRoleMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(666, 78);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(37, 15);
            this.lblRole.TabIndex = 75;
            this.lblRole.Text = "Role";
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(222, 25);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(75, 30);
            this.btnIns.TabIndex = 72;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // lblDisuse
            // 
            this.lblDisuse.AutoSize = true;
            this.lblDisuse.Location = new System.Drawing.Point(974, 80);
            this.lblDisuse.Name = "lblDisuse";
            this.lblDisuse.Size = new System.Drawing.Size(52, 15);
            this.lblDisuse.TabIndex = 70;
            this.lblDisuse.Text = "Disuse";
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(24, 79);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(54, 15);
            this.lblAppId.TabIndex = 68;
            this.lblAppId.Text = "APP ID";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(24, 116);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(88, 15);
            this.lblGroupName.TabIndex = 64;
            this.lblGroupName.Text = "Group Name";
            // 
            // lblMenuName
            // 
            this.lblMenuName.AutoSize = true;
            this.lblMenuName.Location = new System.Drawing.Point(24, 154);
            this.lblMenuName.Name = "lblMenuName";
            this.lblMenuName.Size = new System.Drawing.Size(84, 15);
            this.lblMenuName.TabIndex = 66;
            this.lblMenuName.Text = "Menu Name";
            // 
            // chkSearch
            // 
            this.chkSearch.AutoSize = true;
            this.chkSearch.Location = new System.Drawing.Point(707, 112);
            this.chkSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSearch.Name = "chkSearch";
            this.chkSearch.Size = new System.Drawing.Size(75, 19);
            this.chkSearch.TabIndex = 76;
            this.chkSearch.Text = "Search";
            this.chkSearch.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(801, 112);
            this.chkUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(75, 19);
            this.chkUpdate.TabIndex = 77;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(904, 111);
            this.chkDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(70, 19);
            this.chkDelete.TabIndex = 78;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkExcel
            // 
            this.chkExcel.AutoSize = true;
            this.chkExcel.Location = new System.Drawing.Point(707, 160);
            this.chkExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkExcel.Name = "chkExcel";
            this.chkExcel.Size = new System.Drawing.Size(66, 19);
            this.chkExcel.TabIndex = 79;
            this.chkExcel.Text = "Excel";
            this.chkExcel.UseVisualStyleBackColor = true;
            // 
            // chkDownload
            // 
            this.chkDownload.AutoSize = true;
            this.chkDownload.Location = new System.Drawing.Point(801, 160);
            this.chkDownload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDownload.Name = "chkDownload";
            this.chkDownload.Size = new System.Drawing.Size(94, 19);
            this.chkDownload.TabIndex = 80;
            this.chkDownload.Text = "Download";
            this.chkDownload.UseVisualStyleBackColor = true;
            // 
            // chkUpload
            // 
            this.chkUpload.AutoSize = true;
            this.chkUpload.Location = new System.Drawing.Point(904, 160);
            this.chkUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkUpload.Name = "chkUpload";
            this.chkUpload.Size = new System.Drawing.Size(75, 19);
            this.chkUpload.TabIndex = 81;
            this.chkUpload.Text = "Upload";
            this.chkUpload.UseVisualStyleBackColor = true;
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(707, 75);
            this.chkVisible.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(70, 19);
            this.chkVisible.TabIndex = 82;
            this.chkVisible.Text = "Visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // chkDisuse
            // 
            this.chkDisuse.AutoSize = true;
            this.chkDisuse.Location = new System.Drawing.Point(1031, 78);
            this.chkDisuse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDisuse.Name = "chkDisuse";
            this.chkDisuse.Size = new System.Drawing.Size(74, 19);
            this.chkDisuse.TabIndex = 272;
            this.chkDisuse.Text = "Disuse";
            this.chkDisuse.UseVisualStyleBackColor = true;
            // 
            // dgvMenuRoleMaster
            // 
            this.dgvMenuRoleMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuRoleMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvMenuRoleMaster.Location = new System.Drawing.Point(14, 206);
            this.dgvMenuRoleMaster.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvMenuRoleMaster.MultiSelect = false;
            this.dgvMenuRoleMaster.Name = "dgvMenuRoleMaster";
            this.dgvMenuRoleMaster.ReadOnly = true;
            this.dgvMenuRoleMaster.RowHeadersWidth = 51;
            this.dgvMenuRoleMaster.RowTemplate.Height = 24;
            this.dgvMenuRoleMaster.Size = new System.Drawing.Size(1390, 538);
            this.dgvMenuRoleMaster.TabIndex = 273;
            this.dgvMenuRoleMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuRoleMaster_CellClick);
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
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(65, 25);
            this.btnSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(75, 30);
            this.btnSel.TabIndex = 276;
            this.btnSel.Text = "조회";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(370, 25);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(75, 30);
            this.btnUpd.TabIndex = 274;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(505, 25);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 275;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(894, 35);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(64, 20);
            this.lblMode.TabIndex = 277;
            this.lblMode.Text = "MODE";
            // 
            // cmbAppId
            // 
            this.cmbAppId.FormattingEnabled = true;
            this.cmbAppId.Location = new System.Drawing.Point(117, 71);
            this.cmbAppId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbAppId.Name = "cmbAppId";
            this.cmbAppId.Size = new System.Drawing.Size(532, 23);
            this.cmbAppId.TabIndex = 279;
            this.cmbAppId.SelectedIndexChanged += new System.EventHandler(this.cmbAppId_SelectedIndexChanged);
            // 
            // cmbGroupNo
            // 
            this.cmbGroupNo.FormattingEnabled = true;
            this.cmbGroupNo.Location = new System.Drawing.Point(117, 111);
            this.cmbGroupNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGroupNo.Name = "cmbGroupNo";
            this.cmbGroupNo.Size = new System.Drawing.Size(532, 23);
            this.cmbGroupNo.TabIndex = 278;
            this.cmbGroupNo.SelectedIndexChanged += new System.EventHandler(this.cmbGroupNo_SelectedIndexChanged);
            // 
            // cmbMenuNo
            // 
            this.cmbMenuNo.FormattingEnabled = true;
            this.cmbMenuNo.Location = new System.Drawing.Point(117, 151);
            this.cmbMenuNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMenuNo.Name = "cmbMenuNo";
            this.cmbMenuNo.Size = new System.Drawing.Size(532, 23);
            this.cmbMenuNo.TabIndex = 280;
            this.cmbMenuNo.SelectedIndexChanged += new System.EventHandler(this.cmbMenuNo_SelectedIndexChanged);
            // 
            // lblMenuNo
            // 
            this.lblMenuNo.AutoSize = true;
            this.lblMenuNo.Location = new System.Drawing.Point(1118, 111);
            this.lblMenuNo.Name = "lblMenuNo";
            this.lblMenuNo.Size = new System.Drawing.Size(66, 15);
            this.lblMenuNo.TabIndex = 288;
            this.lblMenuNo.Text = "Menu No";
            this.lblMenuNo.Visible = false;
            // 
            // txtSelectedMenuNo
            // 
            this.txtSelectedMenuNo.Enabled = false;
            this.txtSelectedMenuNo.Location = new System.Drawing.Point(1207, 105);
            this.txtSelectedMenuNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedMenuNo.Name = "txtSelectedMenuNo";
            this.txtSelectedMenuNo.Size = new System.Drawing.Size(179, 25);
            this.txtSelectedMenuNo.TabIndex = 287;
            this.txtSelectedMenuNo.Visible = false;
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(1118, 71);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(67, 15);
            this.lblGroupNo.TabIndex = 284;
            this.lblGroupNo.Text = "group No";
            this.lblGroupNo.Visible = false;
            // 
            // txtSelectedGroupNo
            // 
            this.txtSelectedGroupNo.Enabled = false;
            this.txtSelectedGroupNo.Location = new System.Drawing.Point(1207, 64);
            this.txtSelectedGroupNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedGroupNo.Name = "txtSelectedGroupNo";
            this.txtSelectedGroupNo.Size = new System.Drawing.Size(179, 25);
            this.txtSelectedGroupNo.TabIndex = 283;
            this.txtSelectedGroupNo.Visible = false;
            // 
            // lblMenurole
            // 
            this.lblMenurole.AutoSize = true;
            this.lblMenurole.Location = new System.Drawing.Point(1103, 151);
            this.lblMenurole.Name = "lblMenurole";
            this.lblMenurole.Size = new System.Drawing.Size(101, 15);
            this.lblMenurole.TabIndex = 290;
            this.lblMenurole.Text = "Menu Role No";
            this.lblMenurole.Visible = false;
            // 
            // txtSelectedMenuRoleNo
            // 
            this.txtSelectedMenuRoleNo.Enabled = false;
            this.txtSelectedMenuRoleNo.Location = new System.Drawing.Point(1207, 145);
            this.txtSelectedMenuRoleNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedMenuRoleNo.Name = "txtSelectedMenuRoleNo";
            this.txtSelectedMenuRoleNo.Size = new System.Drawing.Size(179, 25);
            this.txtSelectedMenuRoleNo.TabIndex = 289;
            this.txtSelectedMenuRoleNo.Visible = false;
            // 
            // frmMenuRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 746);
            this.Controls.Add(this.lblMenurole);
            this.Controls.Add(this.txtSelectedMenuRoleNo);
            this.Controls.Add(this.lblMenuNo);
            this.Controls.Add(this.txtSelectedMenuNo);
            this.Controls.Add(this.lblGroupNo);
            this.Controls.Add(this.txtSelectedGroupNo);
            this.Controls.Add(this.cmbMenuNo);
            this.Controls.Add(this.cmbAppId);
            this.Controls.Add(this.cmbGroupNo);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvMenuRoleMaster);
            this.Controls.Add(this.chkDisuse);
            this.Controls.Add(this.chkVisible);
            this.Controls.Add(this.chkUpload);
            this.Controls.Add(this.chkDownload);
            this.Controls.Add(this.chkExcel);
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this.chkSearch);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.btnIns);
            this.Controls.Add(this.lblDisuse);
            this.Controls.Add(this.lblAppId);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.lblMenuName);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMenuRole";
            this.Text = "Menu Role";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuRoleMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.Label lblDisuse;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Label lblMenuName;
        private System.Windows.Forms.CheckBox chkSearch;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkExcel;
        private System.Windows.Forms.CheckBox chkDownload;
        private System.Windows.Forms.CheckBox chkUpload;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.CheckBox chkDisuse;
        private System.Windows.Forms.DataGridView dgvMenuRoleMaster;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cmbAppId;
        private System.Windows.Forms.ComboBox cmbGroupNo;
        private System.Windows.Forms.ComboBox cmbMenuNo;
        private System.Windows.Forms.Label lblMenuNo;
        private System.Windows.Forms.TextBox txtSelectedMenuNo;
        private System.Windows.Forms.Label lblGroupNo;
        private System.Windows.Forms.TextBox txtSelectedGroupNo;
        private System.Windows.Forms.Label lblMenurole;
        private System.Windows.Forms.TextBox txtSelectedMenuRoleNo;
    }
}