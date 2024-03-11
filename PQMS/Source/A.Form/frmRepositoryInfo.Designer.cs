
namespace PQMS
{
    partial class frmRepositoryInfo
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
            this.trvItems = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindRepository = new System.Windows.Forms.Button();
            this.txtRowCnt = new System.Windows.Forms.TextBox();
            this.dgvOrg = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrg)).BeginInit();
            this.SuspendLayout();
            // 
            // trvItems
            // 
            this.trvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvItems.Location = new System.Drawing.Point(0, 0);
            this.trvItems.Margin = new System.Windows.Forms.Padding(10);
            this.trvItems.Name = "trvItems";
            this.trvItems.Size = new System.Drawing.Size(293, 340);
            this.trvItems.TabIndex = 242;
            this.trvItems.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvItems_NodeMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.trvItems);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 340);
            this.panel1.TabIndex = 243;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvData);
            this.panel2.Controls.Add(this.btnFindRepository);
            this.panel2.Controls.Add(this.txtRowCnt);
            this.panel2.Controls.Add(this.dgvOrg);
            this.panel2.Location = new System.Drawing.Point(380, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 141);
            this.panel2.TabIndex = 258;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvData.Location = new System.Drawing.Point(0, 38);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(293, 62);
            this.dgvData.TabIndex = 257;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FillWeight = 10F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "A";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // btnFindRepository
            // 
            this.btnFindRepository.Location = new System.Drawing.Point(0, 7);
            this.btnFindRepository.Name = "btnFindRepository";
            this.btnFindRepository.Size = new System.Drawing.Size(75, 23);
            this.btnFindRepository.TabIndex = 243;
            this.btnFindRepository.Text = "새로고침";
            this.btnFindRepository.UseVisualStyleBackColor = true;
            this.btnFindRepository.Click += new System.EventHandler(this.btnFindRepository_Click);
            // 
            // txtRowCnt
            // 
            this.txtRowCnt.Location = new System.Drawing.Point(81, 10);
            this.txtRowCnt.Name = "txtRowCnt";
            this.txtRowCnt.Size = new System.Drawing.Size(77, 20);
            this.txtRowCnt.TabIndex = 247;
            // 
            // dgvOrg
            // 
            this.dgvOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrg.Location = new System.Drawing.Point(165, 10);
            this.dgvOrg.Name = "dgvOrg";
            this.dgvOrg.RowTemplate.Height = 24;
            this.dgvOrg.Size = new System.Drawing.Size(45, 22);
            this.dgvOrg.TabIndex = 246;
            // 
            // frmRepositoryInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 420);
            this.Controls.Add(this.panel1);
            this.Name = "frmRepositoryInfo";
            this.Text = "조직 찾기";
            this.Load += new System.EventHandler(this.frmRepositoryInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFindRepository;
        private System.Windows.Forms.TextBox txtRowCnt;
        private System.Windows.Forms.DataGridView dgvOrg;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Panel panel2;
    }
}