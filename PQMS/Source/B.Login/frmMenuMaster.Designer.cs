
namespace userManagement
{
    partial class frmMenuMaster
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
            this.lblDisuse = new System.Windows.Forms.Label();
            this.lblAppId = new System.Windows.Forms.Label();
            this.txtParentMenuId = new System.Windows.Forms.TextBox();
            this.txtMenuId = new System.Windows.Forms.TextBox();
            this.lblMenuId = new System.Windows.Forms.Label();
            this.lblParentId = new System.Windows.Forms.Label();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.txtMenuName = new System.Windows.Forms.TextBox();
            this.lblMenuName = new System.Windows.Forms.Label();
            this.cmbAppId = new System.Windows.Forms.ComboBox();
            this.txtAppNo = new System.Windows.Forms.TextBox();
            this.lblAppNo = new System.Windows.Forms.Label();
            this.lblAppIdSelected = new System.Windows.Forms.Label();
            this.txtSelectedAppId = new System.Windows.Forms.TextBox();
            this.chkDisuse = new System.Windows.Forms.CheckBox();
            this.btnSel = new System.Windows.Forms.Button();
            this.dgvMenuMaster = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblMenuNo = new System.Windows.Forms.Label();
            this.txtMenuNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDisuse
            // 
            this.lblDisuse.AutoSize = true;
            this.lblDisuse.Location = new System.Drawing.Point(12, 173);
            this.lblDisuse.Name = "lblDisuse";
            this.lblDisuse.Size = new System.Drawing.Size(44, 12);
            this.lblDisuse.TabIndex = 57;
            this.lblDisuse.Text = "Disuse";
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(12, 53);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(72, 12);
            this.lblAppId.TabIndex = 55;
            this.lblAppId.Text = "APP ID 선택";
            // 
            // txtParentMenuId
            // 
            this.txtParentMenuId.Location = new System.Drawing.Point(112, 109);
            this.txtParentMenuId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtParentMenuId.Name = "txtParentMenuId";
            this.txtParentMenuId.Size = new System.Drawing.Size(269, 21);
            this.txtParentMenuId.TabIndex = 54;
            // 
            // txtMenuId
            // 
            this.txtMenuId.Location = new System.Drawing.Point(112, 78);
            this.txtMenuId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMenuId.Name = "txtMenuId";
            this.txtMenuId.Size = new System.Drawing.Size(269, 21);
            this.txtMenuId.TabIndex = 52;
            // 
            // lblMenuId
            // 
            this.lblMenuId.AutoSize = true;
            this.lblMenuId.Location = new System.Drawing.Point(12, 81);
            this.lblMenuId.Name = "lblMenuId";
            this.lblMenuId.Size = new System.Drawing.Size(52, 12);
            this.lblMenuId.TabIndex = 51;
            this.lblMenuId.Text = "Menu ID";
            // 
            // lblParentId
            // 
            this.lblParentId.AutoSize = true;
            this.lblParentId.Location = new System.Drawing.Point(12, 113);
            this.lblParentId.Name = "lblParentId";
            this.lblParentId.Size = new System.Drawing.Size(92, 12);
            this.lblParentId.TabIndex = 53;
            this.lblParentId.Text = "Parent Menu ID";
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(244, 11);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(66, 24);
            this.btnUpd.TabIndex = 61;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(379, 11);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 24);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(124, 11);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(66, 24);
            this.btnIns.TabIndex = 59;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // txtMenuName
            // 
            this.txtMenuName.Location = new System.Drawing.Point(112, 141);
            this.txtMenuName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(269, 21);
            this.txtMenuName.TabIndex = 63;
            // 
            // lblMenuName
            // 
            this.lblMenuName.AutoSize = true;
            this.lblMenuName.Location = new System.Drawing.Point(12, 145);
            this.lblMenuName.Name = "lblMenuName";
            this.lblMenuName.Size = new System.Drawing.Size(75, 12);
            this.lblMenuName.TabIndex = 62;
            this.lblMenuName.Text = "Menu Name";
            // 
            // cmbAppId
            // 
            this.cmbAppId.FormattingEnabled = true;
            this.cmbAppId.Location = new System.Drawing.Point(112, 45);
            this.cmbAppId.Name = "cmbAppId";
            this.cmbAppId.Size = new System.Drawing.Size(269, 20);
            this.cmbAppId.TabIndex = 64;
            this.cmbAppId.SelectedIndexChanged += new System.EventHandler(this.cmbAppName_SelectedIndexChanged);
            // 
            // txtAppNo
            // 
            this.txtAppNo.Location = new System.Drawing.Point(454, 77);
            this.txtAppNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppNo.Name = "txtAppNo";
            this.txtAppNo.Size = new System.Drawing.Size(157, 21);
            this.txtAppNo.TabIndex = 56;
            this.txtAppNo.Visible = false;
            // 
            // lblAppNo
            // 
            this.lblAppNo.AutoSize = true;
            this.lblAppNo.Location = new System.Drawing.Point(392, 82);
            this.lblAppNo.Name = "lblAppNo";
            this.lblAppNo.Size = new System.Drawing.Size(49, 12);
            this.lblAppNo.TabIndex = 65;
            this.lblAppNo.Text = "APP No";
            this.lblAppNo.Visible = false;
            // 
            // lblAppIdSelected
            // 
            this.lblAppIdSelected.AutoSize = true;
            this.lblAppIdSelected.Location = new System.Drawing.Point(392, 51);
            this.lblAppIdSelected.Name = "lblAppIdSelected";
            this.lblAppIdSelected.Size = new System.Drawing.Size(44, 12);
            this.lblAppIdSelected.TabIndex = 67;
            this.lblAppIdSelected.Text = "APP ID";
            this.lblAppIdSelected.Visible = false;
            // 
            // txtSelectedAppId
            // 
            this.txtSelectedAppId.Location = new System.Drawing.Point(454, 46);
            this.txtSelectedAppId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedAppId.Name = "txtSelectedAppId";
            this.txtSelectedAppId.Size = new System.Drawing.Size(325, 21);
            this.txtSelectedAppId.TabIndex = 66;
            this.txtSelectedAppId.Visible = false;
            // 
            // chkDisuse
            // 
            this.chkDisuse.AutoSize = true;
            this.chkDisuse.Location = new System.Drawing.Point(112, 173);
            this.chkDisuse.Name = "chkDisuse";
            this.chkDisuse.Size = new System.Drawing.Size(63, 16);
            this.chkDisuse.TabIndex = 240;
            this.chkDisuse.Text = "Disuse";
            this.chkDisuse.UseVisualStyleBackColor = true;
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(14, 11);
            this.btnSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(66, 24);
            this.btnSel.TabIndex = 241;
            this.btnSel.Text = "조회";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // dgvMenuMaster
            // 
            this.dgvMenuMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvMenuMaster.Location = new System.Drawing.Point(12, 195);
            this.dgvMenuMaster.MultiSelect = false;
            this.dgvMenuMaster.Name = "dgvMenuMaster";
            this.dgvMenuMaster.ReadOnly = true;
            this.dgvMenuMaster.RowHeadersWidth = 51;
            this.dgvMenuMaster.RowTemplate.Height = 24;
            this.dgvMenuMaster.Size = new System.Drawing.Size(1066, 314);
            this.dgvMenuMaster.TabIndex = 242;
            this.dgvMenuMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuMaster_CellClick);
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
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(870, 19);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(53, 16);
            this.lblMode.TabIndex = 243;
            this.lblMode.Text = "MODE";
            // 
            // lblMenuNo
            // 
            this.lblMenuNo.AutoSize = true;
            this.lblMenuNo.Location = new System.Drawing.Point(392, 112);
            this.lblMenuNo.Name = "lblMenuNo";
            this.lblMenuNo.Size = new System.Drawing.Size(57, 12);
            this.lblMenuNo.TabIndex = 245;
            this.lblMenuNo.Text = "Menu No";
            this.lblMenuNo.Visible = false;
            // 
            // txtMenuNo
            // 
            this.txtMenuNo.Location = new System.Drawing.Point(454, 107);
            this.txtMenuNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMenuNo.Name = "txtMenuNo";
            this.txtMenuNo.Size = new System.Drawing.Size(157, 21);
            this.txtMenuNo.TabIndex = 244;
            this.txtMenuNo.Visible = false;
            // 
            // frmMenuMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 567);
            this.Controls.Add(this.lblMenuNo);
            this.Controls.Add(this.txtMenuNo);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.dgvMenuMaster);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.chkDisuse);
            this.Controls.Add(this.lblAppIdSelected);
            this.Controls.Add(this.txtSelectedAppId);
            this.Controls.Add(this.lblAppNo);
            this.Controls.Add(this.cmbAppId);
            this.Controls.Add(this.txtMenuName);
            this.Controls.Add(this.lblMenuName);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnIns);
            this.Controls.Add(this.lblDisuse);
            this.Controls.Add(this.txtAppNo);
            this.Controls.Add(this.lblAppId);
            this.Controls.Add(this.txtParentMenuId);
            this.Controls.Add(this.txtMenuId);
            this.Controls.Add(this.lblMenuId);
            this.Controls.Add(this.lblParentId);
            this.Name = "frmMenuMaster";
            this.Text = "Menu Master";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDisuse;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.TextBox txtParentMenuId;
        private System.Windows.Forms.TextBox txtMenuId;
        private System.Windows.Forms.Label lblMenuId;
        private System.Windows.Forms.Label lblParentId;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.TextBox txtMenuName;
        private System.Windows.Forms.Label lblMenuName;
        private System.Windows.Forms.ComboBox cmbAppId;
        private System.Windows.Forms.TextBox txtAppNo;
        private System.Windows.Forms.Label lblAppNo;
        private System.Windows.Forms.Label lblAppIdSelected;
        private System.Windows.Forms.TextBox txtSelectedAppId;
        private System.Windows.Forms.CheckBox chkDisuse;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.DataGridView dgvMenuMaster;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblMenuNo;
        private System.Windows.Forms.TextBox txtMenuNo;
    }
}