
namespace userManagement
{
    partial class frmCodeMaster
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
            this.components = new System.ComponentModel.Container();
            this.btnIns = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.lblCodeCategory = new System.Windows.Forms.Label();
            this.txtCodeCategory = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCodeName = new System.Windows.Forms.TextBox();
            this.lblCodeName = new System.Windows.Forms.Label();
            this.txtFrom_Expiry_Date = new System.Windows.Forms.TextBox();
            this.lblFrom_Expiry_Date = new System.Windows.Forms.Label();
            this.txtTo_Expiry_Date = new System.Windows.Forms.TextBox();
            this.lblTo_Expiry_Date = new System.Windows.Forms.Label();
            this.lblDisuse = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rdoDisuse = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(31, 28);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(75, 23);
            this.btnIns.TabIndex = 0;
            this.btnIns.Text = "등록";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(442, 28);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(243, 28);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(75, 23);
            this.btnUpd.TabIndex = 2;
            this.btnUpd.Text = "수정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // lblCodeCategory
            // 
            this.lblCodeCategory.AutoSize = true;
            this.lblCodeCategory.Location = new System.Drawing.Point(31, 69);
            this.lblCodeCategory.Name = "lblCodeCategory";
            this.lblCodeCategory.Size = new System.Drawing.Size(101, 15);
            this.lblCodeCategory.TabIndex = 3;
            this.lblCodeCategory.Text = "CodeCategory";
            // 
            // txtCodeCategory
            // 
            this.txtCodeCategory.Location = new System.Drawing.Point(169, 66);
            this.txtCodeCategory.Name = "txtCodeCategory";
            this.txtCodeCategory.Size = new System.Drawing.Size(532, 25);
            this.txtCodeCategory.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(168, 109);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(532, 25);
            this.txtCode.TabIndex = 7;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(31, 112);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(42, 15);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "Code";
            // 
            // txtCodeName
            // 
            this.txtCodeName.Location = new System.Drawing.Point(168, 149);
            this.txtCodeName.Name = "txtCodeName";
            this.txtCodeName.Size = new System.Drawing.Size(532, 25);
            this.txtCodeName.TabIndex = 9;
            // 
            // lblCodeName
            // 
            this.lblCodeName.AutoSize = true;
            this.lblCodeName.Location = new System.Drawing.Point(31, 152);
            this.lblCodeName.Name = "lblCodeName";
            this.lblCodeName.Size = new System.Drawing.Size(78, 15);
            this.lblCodeName.TabIndex = 8;
            this.lblCodeName.Text = "CodeName";
            // 
            // txtFrom_Expiry_Date
            // 
            this.txtFrom_Expiry_Date.Location = new System.Drawing.Point(168, 187);
            this.txtFrom_Expiry_Date.Name = "txtFrom_Expiry_Date";
            this.txtFrom_Expiry_Date.Size = new System.Drawing.Size(532, 25);
            this.txtFrom_Expiry_Date.TabIndex = 11;
            // 
            // lblFrom_Expiry_Date
            // 
            this.lblFrom_Expiry_Date.AutoSize = true;
            this.lblFrom_Expiry_Date.Location = new System.Drawing.Point(31, 190);
            this.lblFrom_Expiry_Date.Name = "lblFrom_Expiry_Date";
            this.lblFrom_Expiry_Date.Size = new System.Drawing.Size(126, 15);
            this.lblFrom_Expiry_Date.TabIndex = 10;
            this.lblFrom_Expiry_Date.Text = "From_Expiry_Date";
            // 
            // txtTo_Expiry_Date
            // 
            this.txtTo_Expiry_Date.Location = new System.Drawing.Point(168, 227);
            this.txtTo_Expiry_Date.Name = "txtTo_Expiry_Date";
            this.txtTo_Expiry_Date.Size = new System.Drawing.Size(532, 25);
            this.txtTo_Expiry_Date.TabIndex = 13;
            // 
            // lblTo_Expiry_Date
            // 
            this.lblTo_Expiry_Date.AutoSize = true;
            this.lblTo_Expiry_Date.Location = new System.Drawing.Point(31, 230);
            this.lblTo_Expiry_Date.Name = "lblTo_Expiry_Date";
            this.lblTo_Expiry_Date.Size = new System.Drawing.Size(111, 15);
            this.lblTo_Expiry_Date.TabIndex = 12;
            this.lblTo_Expiry_Date.Text = "To_Expiry_Date";
            // 
            // lblDisuse
            // 
            this.lblDisuse.AutoSize = true;
            this.lblDisuse.Location = new System.Drawing.Point(30, 306);
            this.lblDisuse.Name = "lblDisuse";
            this.lblDisuse.Size = new System.Drawing.Size(52, 15);
            this.lblDisuse.TabIndex = 14;
            this.lblDisuse.Text = "Disuse";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(167, 266);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(532, 25);
            this.txtDescription.TabIndex = 15;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(30, 269);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 15);
            this.lblDescription.TabIndex = 22;
            this.lblDescription.Text = "Description";
            // 
            // rdoDisuse
            // 
            this.rdoDisuse.AutoSize = true;
            this.rdoDisuse.Location = new System.Drawing.Point(167, 306);
            this.rdoDisuse.Name = "rdoDisuse";
            this.rdoDisuse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoDisuse.Size = new System.Drawing.Size(36, 19);
            this.rdoDisuse.TabIndex = 23;
            this.rdoDisuse.TabStop = true;
            this.rdoDisuse.Text = "Y";
            this.rdoDisuse.UseVisualStyleBackColor = true;
            // 
            // frmCodeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.rdoDisuse);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDisuse);
            this.Controls.Add(this.txtTo_Expiry_Date);
            this.Controls.Add(this.lblTo_Expiry_Date);
            this.Controls.Add(this.txtFrom_Expiry_Date);
            this.Controls.Add(this.lblFrom_Expiry_Date);
            this.Controls.Add(this.txtCodeName);
            this.Controls.Add(this.lblCodeName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCodeCategory);
            this.Controls.Add(this.lblCodeCategory);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnIns);
            this.Name = "frmCodeMaster";
            this.Text = "CodeMaster";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Label lblCodeCategory;
        private System.Windows.Forms.TextBox txtCodeCategory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCodeName;
        private System.Windows.Forms.Label lblCodeName;
        private System.Windows.Forms.TextBox txtFrom_Expiry_Date;
        private System.Windows.Forms.Label lblFrom_Expiry_Date;
        private System.Windows.Forms.TextBox txtTo_Expiry_Date;
        private System.Windows.Forms.Label lblTo_Expiry_Date;
        private System.Windows.Forms.Label lblDisuse;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RadioButton rdoDisuse;
    }
}