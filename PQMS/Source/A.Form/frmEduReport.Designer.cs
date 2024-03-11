
namespace PQMS
{
    partial class frmEduReport
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtDirEduReport = new System.Windows.Forms.TextBox();
            this.btnSearchEduReport = new System.Windows.Forms.Button();
            this.txtReplaceName = new System.Windows.Forms.TextBox();
            this.btnEduReportGo2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEduReportGo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResultFolder = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.cmbReport = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrgChart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtDirEduReport
            // 
            this.txtDirEduReport.Location = new System.Drawing.Point(92, 332);
            this.txtDirEduReport.Name = "txtDirEduReport";
            this.txtDirEduReport.Size = new System.Drawing.Size(498, 20);
            this.txtDirEduReport.TabIndex = 0;
            this.txtDirEduReport.Visible = false;
            // 
            // btnSearchEduReport
            // 
            this.btnSearchEduReport.Location = new System.Drawing.Point(596, 332);
            this.btnSearchEduReport.Name = "btnSearchEduReport";
            this.btnSearchEduReport.Size = new System.Drawing.Size(75, 23);
            this.btnSearchEduReport.TabIndex = 1;
            this.btnSearchEduReport.Text = "찾아보기";
            this.btnSearchEduReport.UseVisualStyleBackColor = true;
            this.btnSearchEduReport.Visible = false;
            this.btnSearchEduReport.Click += new System.EventHandler(this.btnSearchEduReport_Click);
            // 
            // txtReplaceName
            // 
            this.txtReplaceName.Location = new System.Drawing.Point(92, 294);
            this.txtReplaceName.Name = "txtReplaceName";
            this.txtReplaceName.Size = new System.Drawing.Size(498, 20);
            this.txtReplaceName.TabIndex = 2;
            this.txtReplaceName.Visible = false;
            // 
            // btnEduReportGo2
            // 
            this.btnEduReportGo2.Location = new System.Drawing.Point(596, 294);
            this.btnEduReportGo2.Name = "btnEduReportGo2";
            this.btnEduReportGo2.Size = new System.Drawing.Size(75, 23);
            this.btnEduReportGo2.TabIndex = 3;
            this.btnEduReportGo2.Text = "교육보고서";
            this.btnEduReportGo2.UseVisualStyleBackColor = true;
            this.btnEduReportGo2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "실행 문서 :";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "변경할 이름 :";
            this.label2.Visible = false;
            // 
            // btnEduReportGo
            // 
            this.btnEduReportGo.Location = new System.Drawing.Point(15, 12);
            this.btnEduReportGo.Name = "btnEduReportGo";
            this.btnEduReportGo.Size = new System.Drawing.Size(921, 39);
            this.btnEduReportGo.TabIndex = 6;
            this.btnEduReportGo.Text = "생성";
            this.btnEduReportGo.UseVisualStyleBackColor = true;
            this.btnEduReportGo.Click += new System.EventHandler(this.btnEduReportGo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 324;
            this.label4.Text = "결과폴더 :";
            // 
            // txtResultFolder
            // 
            this.txtResultFolder.Location = new System.Drawing.Point(102, 90);
            this.txtResultFolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtResultFolder.Name = "txtResultFolder";
            this.txtResultFolder.ReadOnly = true;
            this.txtResultFolder.Size = new System.Drawing.Size(535, 20);
            this.txtResultFolder.TabIndex = 323;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(896, 127);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(40, 22);
            this.button7.TabIndex = 322;
            this.button7.Text = "찾기";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // cmbReport
            // 
            this.cmbReport.FormattingEnabled = true;
            this.cmbReport.Location = new System.Drawing.Point(642, 66);
            this.cmbReport.Name = "cmbReport";
            this.cmbReport.Size = new System.Drawing.Size(294, 21);
            this.cmbReport.TabIndex = 321;
            this.cmbReport.SelectedIndexChanged += new System.EventHandler(this.cmbReport_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(561, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 22);
            this.button4.TabIndex = 320;
            this.button4.Text = "열기";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(516, 22);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 22);
            this.button5.TabIndex = 319;
            this.button5.Text = "찾기";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(642, 65);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(40, 22);
            this.button23.TabIndex = 318;
            this.button23.Text = "열기";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(596, 65);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(40, 22);
            this.button22.TabIndex = 317;
            this.button22.Text = "찾기";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 316;
            this.label3.Text = "결과파일 :";
            // 
            // txtOrgChart
            // 
            this.txtOrgChart.Location = new System.Drawing.Point(112, 22);
            this.txtOrgChart.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrgChart.Name = "txtOrgChart";
            this.txtOrgChart.Size = new System.Drawing.Size(399, 20);
            this.txtOrgChart.TabIndex = 315;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 314;
            this.label5.Text = "양식파일 :";
            // 
            // txtTemplate
            // 
            this.txtTemplate.Location = new System.Drawing.Point(102, 66);
            this.txtTemplate.Margin = new System.Windows.Forms.Padding(2);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.ReadOnly = true;
            this.txtTemplate.Size = new System.Drawing.Size(535, 20);
            this.txtTemplate.TabIndex = 313;
            // 
            // frmEduReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(939, 161);
            this.Controls.Add(this.txtTemplate);
            this.Controls.Add(this.btnEduReportGo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResultFolder);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.cmbReport);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOrgChart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEduReportGo2);
            this.Controls.Add(this.txtReplaceName);
            this.Controls.Add(this.btnSearchEduReport);
            this.Controls.Add(this.txtDirEduReport);
            this.Name = "frmEduReport";
            this.Text = "교육훈련보고서";
            this.Load += new System.EventHandler(this.frmEduReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtDirEduReport;
        private System.Windows.Forms.Button btnSearchEduReport;
        private System.Windows.Forms.TextBox txtReplaceName;
        private System.Windows.Forms.Button btnEduReportGo2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEduReportGo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResultFolder;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox cmbReport;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrgChart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTemplate;
    }
}