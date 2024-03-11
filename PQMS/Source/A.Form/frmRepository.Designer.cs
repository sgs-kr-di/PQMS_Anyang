namespace PQMS
{
    partial class frmRepository
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
            this.txtRepoName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRepoCode = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSiteCode = new System.Windows.Forms.TextBox();
            this.cmbSiteCode = new System.Windows.Forms.ComboBox();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.txtRepoClass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRepoName
            // 
            this.txtRepoName.Location = new System.Drawing.Point(124, 194);
            this.txtRepoName.Name = "txtRepoName";
            this.txtRepoName.Size = new System.Drawing.Size(134, 20);
            this.txtRepoName.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Repository Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Repository Code :";
            // 
            // txtRepoCode
            // 
            this.txtRepoCode.Location = new System.Drawing.Point(124, 164);
            this.txtRepoCode.Name = "txtRepoCode";
            this.txtRepoCode.Size = new System.Drawing.Size(134, 20);
            this.txtRepoCode.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(194, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 25);
            this.button3.TabIndex = 15;
            this.button3.Text = "삭제";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(107, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 25);
            this.button2.TabIndex = 14;
            this.button2.Text = "수정";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 25);
            this.button1.TabIndex = 13;
            this.button1.Text = "입력";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Site Code :";
            // 
            // txtSiteCode
            // 
            this.txtSiteCode.Location = new System.Drawing.Point(317, 128);
            this.txtSiteCode.Name = "txtSiteCode";
            this.txtSiteCode.Size = new System.Drawing.Size(134, 20);
            this.txtSiteCode.TabIndex = 21;
            // 
            // cmbSiteCode
            // 
            this.cmbSiteCode.FormattingEnabled = true;
            this.cmbSiteCode.Location = new System.Drawing.Point(124, 129);
            this.cmbSiteCode.Name = "cmbSiteCode";
            this.cmbSiteCode.Size = new System.Drawing.Size(145, 21);
            this.cmbSiteCode.TabIndex = 23;
            this.cmbSiteCode.SelectedIndexChanged += new System.EventHandler(this.cmbSiteCode_SelectedIndexChanged);
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(456, 128);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(134, 20);
            this.txtSiteName.TabIndex = 24;
            // 
            // txtRepoClass
            // 
            this.txtRepoClass.Location = new System.Drawing.Point(124, 223);
            this.txtRepoClass.Name = "txtRepoClass";
            this.txtRepoClass.Size = new System.Drawing.Size(134, 20);
            this.txtRepoClass.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Repository 구분 :";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteCustomSource.AddRange(new string[] {
            "Public",
            "Private"});
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Public",
            "Private"});
            this.comboBox2.Location = new System.Drawing.Point(274, 223);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(145, 21);
            this.comboBox2.TabIndex = 27;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(272, 131);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(21, 20);
            this.button4.TabIndex = 28;
            this.button4.Text = "S";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvData.Location = new System.Drawing.Point(30, 289);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(495, 193);
            this.dgvData.TabIndex = 236;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FillWeight = 10F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "A";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(30, 258);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(64, 25);
            this.button5.TabIndex = 237;
            this.button5.Text = "조회";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmRepository
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 514);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.txtRepoClass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.cmbSiteCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSiteCode);
            this.Controls.Add(this.txtRepoName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRepoCode);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmRepository";
            this.Padding = new System.Windows.Forms.Padding(17, 65, 17, 22);
            this.Text = "Repository 관리 - frmRepository";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtRepoName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRepoCode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSiteCode;
        private System.Windows.Forms.ComboBox cmbSiteCode;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.TextBox txtRepoClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button button5;
    }
}