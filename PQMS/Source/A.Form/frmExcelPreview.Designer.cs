namespace PQMS
{
    partial class frmExcelPreview
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
            this.officeViewer1 = new Spire.OfficeViewer.Forms.OfficeViewer();
            this.SuspendLayout();
            // 
            // officeViewer1
            // 
            this.officeViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.officeViewer1.Location = new System.Drawing.Point(0, 0);
            this.officeViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.officeViewer1.Name = "officeViewer1";
            this.officeViewer1.Size = new System.Drawing.Size(1226, 701);
            this.officeViewer1.TabIndex = 1;
            this.officeViewer1.Text = "officeViewer1";
            // 
            // frmExcelPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 701);
            this.Controls.Add(this.officeViewer1);
            this.Name = "frmExcelPreview";
            this.Text = "frmExcelPreview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Spire.OfficeViewer.Forms.OfficeViewer officeViewer1;
    }
}