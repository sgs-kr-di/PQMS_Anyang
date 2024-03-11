
namespace PQMS
{
    partial class frmAllFileOpen
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
            this.btn_AllFileOpen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRoleCode = new System.Windows.Forms.ComboBox();
            this.txtRoleCode = new System.Windows.Forms.TextBox();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.txtSTAFF_CODE = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_AllFileOpen
            // 
            this.btn_AllFileOpen.Location = new System.Drawing.Point(12, 12);
            this.btn_AllFileOpen.Name = "btn_AllFileOpen";
            this.btn_AllFileOpen.Size = new System.Drawing.Size(283, 39);
            this.btn_AllFileOpen.TabIndex = 325;
            this.btn_AllFileOpen.Text = "파일열기";
            this.btn_AllFileOpen.UseVisualStyleBackColor = true;
            this.btn_AllFileOpen.Click += new System.EventHandler(this.btn_AllFileOpen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 338;
            this.label1.Text = "직무명 :";
            // 
            // cmbRoleCode
            // 
            this.cmbRoleCode.FormattingEnabled = true;
            this.cmbRoleCode.Location = new System.Drawing.Point(76, 65);
            this.cmbRoleCode.Name = "cmbRoleCode";
            this.cmbRoleCode.Size = new System.Drawing.Size(201, 21);
            this.cmbRoleCode.TabIndex = 342;
            this.cmbRoleCode.SelectedIndexChanged += new System.EventHandler(this.cmbRoleCode_SelectedIndexChanged);
            // 
            // txtRoleCode
            // 
            this.txtRoleCode.Location = new System.Drawing.Point(26, 22);
            this.txtRoleCode.Name = "txtRoleCode";
            this.txtRoleCode.Size = new System.Drawing.Size(88, 20);
            this.txtRoleCode.TabIndex = 355;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(198, 22);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(88, 20);
            this.txtRoleName.TabIndex = 356;
            // 
            // txtSTAFF_CODE
            // 
            this.txtSTAFF_CODE.Location = new System.Drawing.Point(213, 22);
            this.txtSTAFF_CODE.Name = "txtSTAFF_CODE";
            this.txtSTAFF_CODE.Size = new System.Drawing.Size(64, 20);
            this.txtSTAFF_CODE.TabIndex = 357;
            // 
            // frmAllFileOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(313, 95);
            this.Controls.Add(this.btn_AllFileOpen);
            this.Controls.Add(this.txtSTAFF_CODE);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.txtRoleCode);
            this.Controls.Add(this.cmbRoleCode);
            this.Controls.Add(this.label1);
            this.Name = "frmAllFileOpen";
            this.Text = "모든파일열기";
            this.Load += new System.EventHandler(this.frmAllFileOpen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_AllFileOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRoleCode;
        private System.Windows.Forms.TextBox txtRoleCode;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.TextBox txtSTAFF_CODE;
    }
}