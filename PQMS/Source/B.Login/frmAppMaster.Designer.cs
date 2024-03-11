
namespace userManagement
{
    partial class frmAppMaster
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
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.txtAppId = new System.Windows.Forms.TextBox();
            this.lblappId = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.lblDisuse = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSel = new System.Windows.Forms.Button();
            this.dgvAppMaster = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkDisuse = new System.Windows.Forms.CheckBox();
            this.lblMode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(123, 94);
            this.txtAppName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(466, 21);
            this.txtAppName.TabIndex = 45;
            this.txtAppName.UseWaitCursor = true;
            // 
            // txtAppId
            // 
            this.txtAppId.Location = new System.Drawing.Point(123, 64);
            this.txtAppId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppId.Name = "txtAppId";
            this.txtAppId.Size = new System.Drawing.Size(466, 21);
            this.txtAppId.TabIndex = 43;
            // 
            // lblappId
            // 
            this.lblappId.AutoSize = true;
            this.lblappId.Location = new System.Drawing.Point(46, 66);
            this.lblappId.Name = "lblappId";
            this.lblappId.Size = new System.Drawing.Size(37, 12);
            this.lblappId.TabIndex = 42;
            this.lblappId.Text = "appID";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Location = new System.Drawing.Point(46, 98);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(61, 12);
            this.lblAppName.TabIndex = 44;
            this.lblAppName.Text = "AppName";
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(341, 25);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(66, 24);
            this.btnUpd.TabIndex = 39;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(481, 25);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 26);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(190, 25);
            this.btnIns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(66, 24);
            this.btnIns.TabIndex = 37;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // lblDisuse
            // 
            this.lblDisuse.AutoSize = true;
            this.lblDisuse.Location = new System.Drawing.Point(46, 163);
            this.lblDisuse.Name = "lblDisuse";
            this.lblDisuse.Size = new System.Drawing.Size(44, 12);
            this.lblDisuse.TabIndex = 46;
            this.lblDisuse.Text = "Disuse";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(123, 128);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(466, 21);
            this.txtDescription.TabIndex = 49;
            this.txtDescription.UseWaitCursor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(46, 132);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(68, 12);
            this.lblDescription.TabIndex = 48;
            this.lblDescription.Text = "Description";
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(58, 25);
            this.btnSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(66, 24);
            this.btnSel.TabIndex = 50;
            this.btnSel.Text = "조회";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // dgvAppMaster
            // 
            this.dgvAppMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvAppMaster.Location = new System.Drawing.Point(49, 219);
            this.dgvAppMaster.MultiSelect = false;
            this.dgvAppMaster.Name = "dgvAppMaster";
            this.dgvAppMaster.ReadOnly = true;
            this.dgvAppMaster.RowHeadersWidth = 51;
            this.dgvAppMaster.RowTemplate.Height = 24;
            this.dgvAppMaster.Size = new System.Drawing.Size(1066, 314);
            this.dgvAppMaster.TabIndex = 237;
            this.dgvAppMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppMaster_CellClick);
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
            this.chkDisuse.Location = new System.Drawing.Point(123, 163);
            this.chkDisuse.Name = "chkDisuse";
            this.chkDisuse.Size = new System.Drawing.Size(63, 16);
            this.chkDisuse.TabIndex = 239;
            this.chkDisuse.Text = "Disuse";
            this.chkDisuse.UseVisualStyleBackColor = true;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(699, 27);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(53, 16);
            this.lblMode.TabIndex = 240;
            this.lblMode.Text = "MODE";
            // 
            // frmAppMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 698);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.chkDisuse);
            this.Controls.Add(this.dgvAppMaster);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDisuse);
            this.Controls.Add(this.txtAppName);
            this.Controls.Add(this.txtAppId);
            this.Controls.Add(this.lblappId);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnIns);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAppMaster";
            this.Text = "App Master";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.TextBox txtAppId;
        private System.Windows.Forms.Label lblappId;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.Label lblDisuse;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.DataGridView dgvAppMaster;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.CheckBox chkDisuse;
        private System.Windows.Forms.Label lblMode;
    }
}