
namespace userManagement
{
    partial class frmGroupMemberMaster_org
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
            this.lblLoginId = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.lblDisuse = new System.Windows.Forms.Label();
            this.dgvGroupMaster = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSel = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.chkDisuse = new System.Windows.Forms.CheckBox();
            this.cmbGroupName = new System.Windows.Forms.ComboBox();
            this.cmbAppId = new System.Windows.Forms.ComboBox();
            this.lblAppId = new System.Windows.Forms.Label();
            this.cmbLoginId = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblGroupNo = new System.Windows.Forms.Label();
            this.txtSelectedGroupNo = new System.Windows.Forms.TextBox();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.txtSelectedAccountNo = new System.Windows.Forms.TextBox();
            this.lblMemberNo = new System.Windows.Forms.Label();
            this.txtSelectedMemberNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoginId
            // 
            this.lblLoginId.AutoSize = true;
            this.lblLoginId.Location = new System.Drawing.Point(25, 125);
            this.lblLoginId.Name = "lblLoginId";
            this.lblLoginId.Size = new System.Drawing.Size(51, 12);
            this.lblLoginId.TabIndex = 37;
            this.lblLoginId.Text = "Login ID";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(25, 92);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(77, 12);
            this.lblGroupName.TabIndex = 39;
            this.lblGroupName.Text = "Group Name";
            // 
            // lblDisuse
            // 
            this.lblDisuse.AutoSize = true;
            this.lblDisuse.Location = new System.Drawing.Point(25, 157);
            this.lblDisuse.Name = "lblDisuse";
            this.lblDisuse.Size = new System.Drawing.Size(44, 12);
            this.lblDisuse.TabIndex = 61;
            this.lblDisuse.Text = "Disuse";
            // 
            // dgvGroupMaster
            // 
            this.dgvGroupMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvGroupMaster.Location = new System.Drawing.Point(12, 214);
            this.dgvGroupMaster.MultiSelect = false;
            this.dgvGroupMaster.Name = "dgvGroupMaster";
            this.dgvGroupMaster.ReadOnly = true;
            this.dgvGroupMaster.RowHeadersWidth = 51;
            this.dgvGroupMaster.RowTemplate.Height = 24;
            this.dgvGroupMaster.Size = new System.Drawing.Size(1066, 314);
            this.dgvGroupMaster.TabIndex = 245;
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
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(27, 21);
            this.btnSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(66, 24);
            this.btnSel.TabIndex = 249;
            this.btnSel.Text = "조회";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(286, 21);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(66, 24);
            this.btnUpd.TabIndex = 247;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(445, 21);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 24);
            this.btnSave.TabIndex = 248;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(155, 21);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(66, 24);
            this.btnIns.TabIndex = 246;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // chkDisuse
            // 
            this.chkDisuse.AutoSize = true;
            this.chkDisuse.Location = new System.Drawing.Point(115, 154);
            this.chkDisuse.Name = "chkDisuse";
            this.chkDisuse.Size = new System.Drawing.Size(63, 16);
            this.chkDisuse.TabIndex = 250;
            this.chkDisuse.Text = "Disuse";
            this.chkDisuse.UseVisualStyleBackColor = true;
            // 
            // cmbGroupName
            // 
            this.cmbGroupName.FormattingEnabled = true;
            this.cmbGroupName.Location = new System.Drawing.Point(116, 87);
            this.cmbGroupName.Name = "cmbGroupName";
            this.cmbGroupName.Size = new System.Drawing.Size(466, 20);
            this.cmbGroupName.TabIndex = 251;
            this.cmbGroupName.SelectedIndexChanged += new System.EventHandler(this.cmbGroupName_SelectedIndexChanged);
            // 
            // cmbAppId
            // 
            this.cmbAppId.FormattingEnabled = true;
            this.cmbAppId.Location = new System.Drawing.Point(116, 55);
            this.cmbAppId.Name = "cmbAppId";
            this.cmbAppId.Size = new System.Drawing.Size(466, 20);
            this.cmbAppId.TabIndex = 253;
            this.cmbAppId.SelectedIndexChanged += new System.EventHandler(this.cmbAppId_SelectedIndexChanged);
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(25, 61);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(72, 12);
            this.lblAppId.TabIndex = 252;
            this.lblAppId.Text = "APP ID 선택";
            // 
            // cmbLoginId
            // 
            this.cmbLoginId.FormattingEnabled = true;
            this.cmbLoginId.Location = new System.Drawing.Point(116, 119);
            this.cmbLoginId.Name = "cmbLoginId";
            this.cmbLoginId.Size = new System.Drawing.Size(466, 20);
            this.cmbLoginId.TabIndex = 254;
            this.cmbLoginId.SelectedIndexChanged += new System.EventHandler(this.cmbLoginId_SelectedIndexChanged);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(727, 23);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(53, 16);
            this.lblMode.TabIndex = 255;
            this.lblMode.Text = "MODE";
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(670, 64);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(57, 12);
            this.lblGroupNo.TabIndex = 258;
            this.lblGroupNo.Text = "group No";
            // 
            // txtSelectedGroupNo
            // 
            this.txtSelectedGroupNo.Location = new System.Drawing.Point(747, 58);
            this.txtSelectedGroupNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedGroupNo.Name = "txtSelectedGroupNo";
            this.txtSelectedGroupNo.Size = new System.Drawing.Size(157, 21);
            this.txtSelectedGroupNo.TabIndex = 257;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(670, 108);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(71, 12);
            this.lblAccountNo.TabIndex = 260;
            this.lblAccountNo.Text = "Account No";
            // 
            // txtSelectedAccountNo
            // 
            this.txtSelectedAccountNo.Location = new System.Drawing.Point(747, 103);
            this.txtSelectedAccountNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedAccountNo.Name = "txtSelectedAccountNo";
            this.txtSelectedAccountNo.Size = new System.Drawing.Size(157, 21);
            this.txtSelectedAccountNo.TabIndex = 259;
            // 
            // lblMemberNo
            // 
            this.lblMemberNo.AutoSize = true;
            this.lblMemberNo.Location = new System.Drawing.Point(670, 148);
            this.lblMemberNo.Name = "lblMemberNo";
            this.lblMemberNo.Size = new System.Drawing.Size(72, 12);
            this.lblMemberNo.TabIndex = 262;
            this.lblMemberNo.Text = "Member No";
            // 
            // txtSelectedMemberNo
            // 
            this.txtSelectedMemberNo.Location = new System.Drawing.Point(747, 143);
            this.txtSelectedMemberNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSelectedMemberNo.Name = "txtSelectedMemberNo";
            this.txtSelectedMemberNo.Size = new System.Drawing.Size(157, 21);
            this.txtSelectedMemberNo.TabIndex = 261;
            // 
            // frmGroupMemberMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 589);
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
            this.Controls.Add(this.dgvGroupMaster);
            this.Controls.Add(this.lblDisuse);
            this.Controls.Add(this.lblLoginId);
            this.Controls.Add(this.lblGroupName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmGroupMemberMaster";
            this.Text = "Group Member Master";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLoginId;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Label lblDisuse;
        private System.Windows.Forms.DataGridView dgvGroupMaster;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.CheckBox chkDisuse;
        private System.Windows.Forms.ComboBox cmbGroupName;
        private System.Windows.Forms.ComboBox cmbAppId;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.ComboBox cmbLoginId;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblGroupNo;
        private System.Windows.Forms.TextBox txtSelectedGroupNo;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.TextBox txtSelectedAccountNo;
        private System.Windows.Forms.Label lblMemberNo;
        private System.Windows.Forms.TextBox txtSelectedMemberNo;
    }
}