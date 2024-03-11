
namespace PQMS
{
    partial class frmPQMS_STAFF_PRE_JOB_INFO
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSTAFF_PRE_WORK_DATE = new System.Windows.Forms.TextBox();
            this.txtSTAFF_PRE_WS_NAME = new System.Windows.Forms.TextBox();
            this.txtSTAFF_PRE_REPOSITORY_NAME = new System.Windows.Forms.TextBox();
            this.txtSTAFF_CODE = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSTAFF_PRE_WORK_REMARK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDX = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeletePreJobInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsertPreJobInfo = new DevExpress.XtraEditors.SimpleButton();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelectPreInfo = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 107);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(57, 13);
            this.Label1.TabIndex = 259;
            this.Label1.Text = "근무기간 :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(10, 79);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 13);
            this.Label2.TabIndex = 260;
            this.Label2.Text = "근무부서 :";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(10, 49);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(46, 13);
            this.Label3.TabIndex = 261;
            this.Label3.Text = "기관명 :";
            // 
            // txtSTAFF_PRE_WORK_DATE
            // 
            this.txtSTAFF_PRE_WORK_DATE.Location = new System.Drawing.Point(73, 104);
            this.txtSTAFF_PRE_WORK_DATE.Name = "txtSTAFF_PRE_WORK_DATE";
            this.txtSTAFF_PRE_WORK_DATE.Size = new System.Drawing.Size(520, 20);
            this.txtSTAFF_PRE_WORK_DATE.TabIndex = 264;
            // 
            // txtSTAFF_PRE_WS_NAME
            // 
            this.txtSTAFF_PRE_WS_NAME.Location = new System.Drawing.Point(73, 76);
            this.txtSTAFF_PRE_WS_NAME.Name = "txtSTAFF_PRE_WS_NAME";
            this.txtSTAFF_PRE_WS_NAME.Size = new System.Drawing.Size(520, 20);
            this.txtSTAFF_PRE_WS_NAME.TabIndex = 263;
            // 
            // txtSTAFF_PRE_REPOSITORY_NAME
            // 
            this.txtSTAFF_PRE_REPOSITORY_NAME.Location = new System.Drawing.Point(73, 46);
            this.txtSTAFF_PRE_REPOSITORY_NAME.Name = "txtSTAFF_PRE_REPOSITORY_NAME";
            this.txtSTAFF_PRE_REPOSITORY_NAME.Size = new System.Drawing.Size(520, 20);
            this.txtSTAFF_PRE_REPOSITORY_NAME.TabIndex = 262;
            // 
            // txtSTAFF_CODE
            // 
            this.txtSTAFF_CODE.Location = new System.Drawing.Point(450, 17);
            this.txtSTAFF_CODE.Name = "txtSTAFF_CODE";
            this.txtSTAFF_CODE.ReadOnly = true;
            this.txtSTAFF_CODE.Size = new System.Drawing.Size(143, 20);
            this.txtSTAFF_CODE.TabIndex = 269;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(387, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 268;
            this.label9.Text = "관리번호 :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSTAFF_PRE_WORK_REMARK);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.txtIDX);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtSTAFF_CODE);
            this.panel1.Controls.Add(this.Label3);
            this.panel1.Controls.Add(this.txtSTAFF_PRE_REPOSITORY_NAME);
            this.panel1.Controls.Add(this.txtSTAFF_PRE_WORK_DATE);
            this.panel1.Controls.Add(this.txtSTAFF_PRE_WS_NAME);
            this.panel1.Location = new System.Drawing.Point(12, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 169);
            this.panel1.TabIndex = 272;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 272;
            this.label5.Text = "비고 :";
            // 
            // txtSTAFF_PRE_WORK_REMARK
            // 
            this.txtSTAFF_PRE_WORK_REMARK.Location = new System.Drawing.Point(72, 131);
            this.txtSTAFF_PRE_WORK_REMARK.Name = "txtSTAFF_PRE_WORK_REMARK";
            this.txtSTAFF_PRE_WORK_REMARK.Size = new System.Drawing.Size(520, 20);
            this.txtSTAFF_PRE_WORK_REMARK.TabIndex = 273;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 270;
            this.label4.Text = "순번 :";
            // 
            // txtIDX
            // 
            this.txtIDX.Location = new System.Drawing.Point(73, 17);
            this.txtIDX.Name = "txtIDX";
            this.txtIDX.ReadOnly = true;
            this.txtIDX.Size = new System.Drawing.Size(143, 20);
            this.txtIDX.TabIndex = 271;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.btnDeletePreJobInfo);
            this.panel2.Controls.Add(this.btnInsertPreJobInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 30);
            this.panel2.TabIndex = 273;
            // 
            // btnDeletePreJobInfo
            // 
            this.btnDeletePreJobInfo.Location = new System.Drawing.Point(93, 3);
            this.btnDeletePreJobInfo.Name = "btnDeletePreJobInfo";
            this.btnDeletePreJobInfo.Size = new System.Drawing.Size(75, 25);
            this.btnDeletePreJobInfo.TabIndex = 1;
            this.btnDeletePreJobInfo.Text = "삭제";
            this.btnDeletePreJobInfo.Click += new System.EventHandler(this.btnDeletePreJobInfo_Click);
            // 
            // btnInsertPreJobInfo
            // 
            this.btnInsertPreJobInfo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnInsertPreJobInfo.Appearance.Options.UseForeColor = true;
            this.btnInsertPreJobInfo.Location = new System.Drawing.Point(12, 3);
            this.btnInsertPreJobInfo.Name = "btnInsertPreJobInfo";
            this.btnInsertPreJobInfo.Size = new System.Drawing.Size(75, 25);
            this.btnInsertPreJobInfo.TabIndex = 0;
            this.btnInsertPreJobInfo.Text = "저장";
            this.btnInsertPreJobInfo.Click += new System.EventHandler(this.btnInsertPreJobInfo_Click);
            // 
            // dgvData
            // 
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvData.Location = new System.Drawing.Point(12, 243);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(612, 351);
            this.dgvData.TabIndex = 274;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.Resize += new System.EventHandler(this.dgvData_Resize);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FillWeight = 10F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // btnSelectPreInfo
            // 
            this.btnSelectPreInfo.Location = new System.Drawing.Point(12, 214);
            this.btnSelectPreInfo.Name = "btnSelectPreInfo";
            this.btnSelectPreInfo.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPreInfo.TabIndex = 275;
            this.btnSelectPreInfo.Text = "조회";
            this.btnSelectPreInfo.Click += new System.EventHandler(this.btnSelectPreInfo_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.btnSelectPreInfo);
            this.panel3.Controls.Add(this.dgvData);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(20, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(654, 620);
            this.panel3.TabIndex = 276;
            // 
            // frmPQMS_STAFF_PRE_JOB_INFO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 700);
            this.Controls.Add(this.panel3);
            this.Name = "frmPQMS_STAFF_PRE_JOB_INFO";
            this.Text = "이전 경력 정보";
            this.Load += new System.EventHandler(this.frmPQMS_STAFF_PRE_JOB_INFO_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtSTAFF_PRE_WORK_DATE;
        internal System.Windows.Forms.TextBox txtSTAFF_PRE_WS_NAME;
        internal System.Windows.Forms.TextBox txtSTAFF_PRE_REPOSITORY_NAME;
        internal System.Windows.Forms.TextBox txtSTAFF_CODE;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnInsertPreJobInfo;
        private System.Windows.Forms.DataGridView dgvData;
        private DevExpress.XtraEditors.SimpleButton btnDeletePreJobInfo;
        private DevExpress.XtraEditors.SimpleButton btnSelectPreInfo;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtIDX;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtSTAFF_PRE_WORK_REMARK;
    }
}