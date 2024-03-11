
namespace PQMS
{
    partial class frmStaffInfoAll
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvOrg = new System.Windows.Forms.DataGridView();
            this.txtRowCnt = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrg)).BeginInit();
            this.SuspendLayout();
            // 
            // trvItems
            // 
            this.trvItems.Location = new System.Drawing.Point(23, 60);
            this.trvItems.Name = "trvItems";
            this.trvItems.Size = new System.Drawing.Size(211, 656);
            this.trvItems.TabIndex = 242;
            this.trvItems.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvItems_NodeMouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(240, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1049, 656);
            this.tabControl1.TabIndex = 243;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1041, 630);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "자료검색";
            this.tabPage1.UseVisualStyleBackColor = true;            
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1041, 630);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "인원정보";
            this.tabPage2.UseVisualStyleBackColor = true;            
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1041, 630);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1041, 630);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvOrg
            // 
            this.dgvOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrg.Location = new System.Drawing.Point(157, 82);
            this.dgvOrg.Name = "dgvOrg";
            this.dgvOrg.RowTemplate.Height = 24;
            this.dgvOrg.Size = new System.Drawing.Size(45, 22);
            this.dgvOrg.TabIndex = 245;
            this.dgvOrg.Visible = false;
            // 
            // txtRowCnt
            // 
            this.txtRowCnt.Location = new System.Drawing.Point(74, 82);
            this.txtRowCnt.Name = "txtRowCnt";
            this.txtRowCnt.Size = new System.Drawing.Size(77, 20);
            this.txtRowCnt.TabIndex = 246;
            this.txtRowCnt.Visible = false;
            // 
            // frmStaffInfoAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 736);
            this.Controls.Add(this.txtRowCnt);
            this.Controls.Add(this.dgvOrg);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.trvItems);
            this.Name = "frmStaffInfoAll";
            this.Text = "frmStaffInfoAll";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmStaffInfoAll_Load);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvItems;
        private System.Windows.Forms.DataGridView dgvOrg;
        private System.Windows.Forms.TextBox txtRowCnt;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
    }
}