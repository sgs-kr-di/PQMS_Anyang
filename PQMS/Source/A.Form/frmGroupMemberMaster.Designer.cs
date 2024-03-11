
namespace PQMS
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
            this.txtGroupNo = new System.Windows.Forms.TextBox();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.lblGroupId = new System.Windows.Forms.Label();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.rdoDisuse = new System.Windows.Forms.RadioButton();
            this.lblDisuse = new System.Windows.Forms.Label();
            this.dgvUserRequestStatus = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbGroupNo = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cmbAccoutNo = new System.Windows.Forms.ComboBox();
            this.txtAppNo = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.cmbAppID = new System.Windows.Forms.ComboBox();
            this.txtAppId = new System.Windows.Forms.TextBox();
            this.lblAppId = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.txtLoginID = new System.Windows.Forms.TextBox();
            this.txtGroupMemberNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtGroupNo.Location = new System.Drawing.Point(92, 167);
            this.txtGroupNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(181, 20);
            this.txtGroupNo.TabIndex = 40;
            this.txtGroupNo.TextChanged += new System.EventHandler(this.txtGroupNo_TextChanged);
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Location = new System.Drawing.Point(92, 193);
            this.txtAccountNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(74, 20);
            this.txtAccountNo.TabIndex = 38;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(22, 197);
            this.lblAccountNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(61, 13);
            this.lblAccountNo.TabIndex = 37;
            this.lblAccountNo.Text = "AccountNo";
            // 
            // lblGroupId
            // 
            this.lblGroupId.AutoSize = true;
            this.lblGroupId.Location = new System.Drawing.Point(22, 171);
            this.lblGroupId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGroupId.Name = "lblGroupId";
            this.lblGroupId.Size = new System.Drawing.Size(68, 13);
            this.lblGroupId.TabIndex = 39;
            this.lblGroupId.Text = "Menu Code :";
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(182, 62);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(56, 19);
            this.btnUpd.TabIndex = 35;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Visible = false;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(86, 62);
            this.btnDel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(56, 19);
            this.btnDel.TabIndex = 34;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(22, 62);
            this.btnIns.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(56, 19);
            this.btnIns.TabIndex = 33;
            this.btnIns.Text = "저장";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // rdoDisuse
            // 
            this.rdoDisuse.AutoSize = true;
            this.rdoDisuse.Location = new System.Drawing.Point(308, 242);
            this.rdoDisuse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoDisuse.Name = "rdoDisuse";
            this.rdoDisuse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoDisuse.Size = new System.Drawing.Size(32, 17);
            this.rdoDisuse.TabIndex = 62;
            this.rdoDisuse.TabStop = true;
            this.rdoDisuse.Text = "Y";
            this.rdoDisuse.UseVisualStyleBackColor = true;
            this.rdoDisuse.Visible = false;
            // 
            // lblDisuse
            // 
            this.lblDisuse.AutoSize = true;
            this.lblDisuse.Location = new System.Drawing.Point(246, 242);
            this.lblDisuse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisuse.Name = "lblDisuse";
            this.lblDisuse.Size = new System.Drawing.Size(39, 13);
            this.lblDisuse.TabIndex = 61;
            this.lblDisuse.Text = "Disuse";
            this.lblDisuse.Visible = false;
            // 
            // dgvUserRequestStatus
            // 
            this.dgvUserRequestStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserRequestStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvUserRequestStatus.Location = new System.Drawing.Point(12, 304);
            this.dgvUserRequestStatus.Name = "dgvUserRequestStatus";
            this.dgvUserRequestStatus.RowHeadersWidth = 51;
            this.dgvUserRequestStatus.RowTemplate.Height = 24;
            this.dgvUserRequestStatus.Size = new System.Drawing.Size(1209, 300);
            this.dgvUserRequestStatus.TabIndex = 242;
            this.dgvUserRequestStatus.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserRequestStatus_CellClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FillWeight = 10F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "A";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(427, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 26);
            this.button2.TabIndex = 241;
            this.button2.Text = "전체자료조회";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(755, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 26);
            this.button1.TabIndex = 244;
            this.button1.Text = "S";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbGroupNo
            // 
            this.cmbGroupNo.FormattingEnabled = true;
            this.cmbGroupNo.Location = new System.Drawing.Point(501, 166);
            this.cmbGroupNo.Name = "cmbGroupNo";
            this.cmbGroupNo.Size = new System.Drawing.Size(248, 21);
            this.cmbGroupNo.TabIndex = 243;
            this.cmbGroupNo.SelectedIndexChanged += new System.EventHandler(this.cmbGroupNo_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(755, 188);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 26);
            this.button3.TabIndex = 246;
            this.button3.Text = "S";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmbAccoutNo
            // 
            this.cmbAccoutNo.FormattingEnabled = true;
            this.cmbAccoutNo.Location = new System.Drawing.Point(501, 193);
            this.cmbAccoutNo.Name = "cmbAccoutNo";
            this.cmbAccoutNo.Size = new System.Drawing.Size(248, 21);
            this.cmbAccoutNo.TabIndex = 245;
            this.cmbAccoutNo.SelectedIndexChanged += new System.EventHandler(this.cmbAccoutNo_SelectedIndexChanged);
            // 
            // txtAppNo
            // 
            this.txtAppNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAppNo.Enabled = false;
            this.txtAppNo.Location = new System.Drawing.Point(92, 141);
            this.txtAppNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppNo.Name = "txtAppNo";
            this.txtAppNo.Size = new System.Drawing.Size(44, 20);
            this.txtAppNo.TabIndex = 254;
            this.txtAppNo.Text = "3";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(755, 134);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(43, 26);
            this.button4.TabIndex = 253;
            this.button4.Text = "S";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmbAppID
            // 
            this.cmbAppID.Enabled = false;
            this.cmbAppID.FormattingEnabled = true;
            this.cmbAppID.Location = new System.Drawing.Point(501, 139);
            this.cmbAppID.Name = "cmbAppID";
            this.cmbAppID.Size = new System.Drawing.Size(248, 21);
            this.cmbAppID.TabIndex = 252;
            this.cmbAppID.SelectedIndexChanged += new System.EventHandler(this.cmbAppID_SelectedIndexChanged);
            // 
            // txtAppId
            // 
            this.txtAppId.Enabled = false;
            this.txtAppId.Location = new System.Drawing.Point(142, 141);
            this.txtAppId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppId.Name = "txtAppId";
            this.txtAppId.Size = new System.Drawing.Size(290, 20);
            this.txtAppId.TabIndex = 250;
            this.txtAppId.Text = "PQMS";
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(21, 142);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(37, 13);
            this.lblAppId.TabIndex = 251;
            this.lblAppId.Text = "AppID";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(544, 242);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(69, 26);
            this.button5.TabIndex = 255;
            this.button5.Text = "앱별조회";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(62, 272);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 26);
            this.button6.TabIndex = 256;
            this.button6.Text = "앱별그룹별조회";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtLoginID
            // 
            this.txtLoginID.Location = new System.Drawing.Point(172, 193);
            this.txtLoginID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(312, 20);
            this.txtLoginID.TabIndex = 257;
            // 
            // txtGroupMemberNo
            // 
            this.txtGroupMemberNo.Location = new System.Drawing.Point(118, 113);
            this.txtGroupMemberNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGroupMemberNo.Name = "txtGroupMemberNo";
            this.txtGroupMemberNo.Size = new System.Drawing.Size(91, 20);
            this.txtGroupMemberNo.TabIndex = 259;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 258;
            this.label1.Text = "groupMemberNo :";
            // 
            // frmGroupMemberMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 632);
            this.Controls.Add(this.txtGroupMemberNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLoginID);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtAppNo);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cmbAppID);
            this.Controls.Add(this.txtAppId);
            this.Controls.Add(this.lblAppId);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cmbAccoutNo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbGroupNo);
            this.Controls.Add(this.dgvUserRequestStatus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rdoDisuse);
            this.Controls.Add(this.lblDisuse);
            this.Controls.Add(this.txtGroupNo);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.lblGroupId);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnIns);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmGroupMemberMaster";
            this.Text = "Group Member Master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroupNo;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.Label lblGroupId;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.RadioButton rdoDisuse;
        private System.Windows.Forms.Label lblDisuse;
        private System.Windows.Forms.DataGridView dgvUserRequestStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbGroupNo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmbAccoutNo;
        private System.Windows.Forms.TextBox txtAppNo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cmbAppID;
        private System.Windows.Forms.TextBox txtAppId;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtLoginID;
        private System.Windows.Forms.TextBox txtGroupMemberNo;
        private System.Windows.Forms.Label label1;
    }
}