
namespace PQMS
{
    partial class frmApproveRequestVer2
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
            this.txtRequestContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAccountNo2 = new System.Windows.Forms.TextBox();
            this.txtLoginID2 = new System.Windows.Forms.TextBox();
            this.cmbApprove2 = new System.Windows.Forms.ComboBox();
            this.btnApprove2 = new System.Windows.Forms.Button();
            this.txtidxNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnApproveGo = new System.Windows.Forms.Button();
            this.txtAccountNo1 = new System.Windows.Forms.TextBox();
            this.txtLoginID1 = new System.Windows.Forms.TextBox();
            this.cmbApprove1 = new System.Windows.Forms.ComboBox();
            this.btnApprove1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PQMS_STAFF_ROLE_CHECKGrid = new DevExpress.XtraGrid.GridControl();
            this.PQMS_STAFF_ROLE_CHECKGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_ROLE_CHECKGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_ROLE_CHECKGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtRequestContent
            // 
            this.txtRequestContent.Location = new System.Drawing.Point(116, 138);
            this.txtRequestContent.Margin = new System.Windows.Forms.Padding(2);
            this.txtRequestContent.Multiline = true;
            this.txtRequestContent.Name = "txtRequestContent";
            this.txtRequestContent.Size = new System.Drawing.Size(448, 43);
            this.txtRequestContent.TabIndex = 341;
            this.txtRequestContent.Text = "승인해 주세요";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 340;
            this.label3.Text = "승인요청내용 :";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(159, 58);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(282, 20);
            this.txtTitle.TabIndex = 339;
            // 
            // txtAccountNo2
            // 
            this.txtAccountNo2.Location = new System.Drawing.Point(116, 111);
            this.txtAccountNo2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAccountNo2.Name = "txtAccountNo2";
            this.txtAccountNo2.ReadOnly = true;
            this.txtAccountNo2.Size = new System.Drawing.Size(41, 20);
            this.txtAccountNo2.TabIndex = 337;
            // 
            // txtLoginID2
            // 
            this.txtLoginID2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLoginID2.Location = new System.Drawing.Point(158, 111);
            this.txtLoginID2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoginID2.Name = "txtLoginID2";
            this.txtLoginID2.ReadOnly = true;
            this.txtLoginID2.Size = new System.Drawing.Size(138, 20);
            this.txtLoginID2.TabIndex = 338;
            // 
            // cmbApprove2
            // 
            this.cmbApprove2.FormattingEnabled = true;
            this.cmbApprove2.Location = new System.Drawing.Point(115, 110);
            this.cmbApprove2.Name = "cmbApprove2";
            this.cmbApprove2.Size = new System.Drawing.Size(201, 21);
            this.cmbApprove2.TabIndex = 336;
            this.cmbApprove2.SelectedIndexChanged += new System.EventHandler(this.cmbApprove2_SelectedIndexChanged);
            // 
            // btnApprove2
            // 
            this.btnApprove2.Location = new System.Drawing.Point(509, 108);
            this.btnApprove2.Name = "btnApprove2";
            this.btnApprove2.Size = new System.Drawing.Size(55, 22);
            this.btnApprove2.TabIndex = 335;
            this.btnApprove2.Text = "찾기";
            this.btnApprove2.UseVisualStyleBackColor = true;
            this.btnApprove2.Visible = false;
            this.btnApprove2.Click += new System.EventHandler(this.btnApprove2_Click);
            // 
            // txtidxNo
            // 
            this.txtidxNo.Location = new System.Drawing.Point(115, 58);
            this.txtidxNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtidxNo.Name = "txtidxNo";
            this.txtidxNo.Size = new System.Drawing.Size(40, 20);
            this.txtidxNo.TabIndex = 334;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 332;
            this.label6.Text = "승인요청자료번호 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 333;
            this.label5.Text = "승인권자  :";
            // 
            // btnApproveGo
            // 
            this.btnApproveGo.Location = new System.Drawing.Point(12, 12);
            this.btnApproveGo.Name = "btnApproveGo";
            this.btnApproveGo.Size = new System.Drawing.Size(553, 39);
            this.btnApproveGo.TabIndex = 331;
            this.btnApproveGo.Text = "승인요청";
            this.btnApproveGo.UseVisualStyleBackColor = true;
            this.btnApproveGo.Click += new System.EventHandler(this.btnApproveGo_Click);
            // 
            // txtAccountNo1
            // 
            this.txtAccountNo1.Location = new System.Drawing.Point(115, 83);
            this.txtAccountNo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAccountNo1.Name = "txtAccountNo1";
            this.txtAccountNo1.ReadOnly = true;
            this.txtAccountNo1.Size = new System.Drawing.Size(41, 20);
            this.txtAccountNo1.TabIndex = 345;
            // 
            // txtLoginID1
            // 
            this.txtLoginID1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLoginID1.Location = new System.Drawing.Point(159, 83);
            this.txtLoginID1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoginID1.Name = "txtLoginID1";
            this.txtLoginID1.ReadOnly = true;
            this.txtLoginID1.Size = new System.Drawing.Size(138, 20);
            this.txtLoginID1.TabIndex = 346;
            // 
            // cmbApprove1
            // 
            this.cmbApprove1.FormattingEnabled = true;
            this.cmbApprove1.Location = new System.Drawing.Point(115, 83);
            this.cmbApprove1.Name = "cmbApprove1";
            this.cmbApprove1.Size = new System.Drawing.Size(201, 21);
            this.cmbApprove1.TabIndex = 344;
            this.cmbApprove1.SelectedIndexChanged += new System.EventHandler(this.cmbApprove1_SelectedIndexChanged);
            // 
            // btnApprove1
            // 
            this.btnApprove1.Location = new System.Drawing.Point(510, 82);
            this.btnApprove1.Name = "btnApprove1";
            this.btnApprove1.Size = new System.Drawing.Size(55, 22);
            this.btnApprove1.TabIndex = 343;
            this.btnApprove1.Text = "찾기";
            this.btnApprove1.UseVisualStyleBackColor = true;
            this.btnApprove1.Visible = false;
            this.btnApprove1.Click += new System.EventHandler(this.btnApprove1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 342;
            this.label1.Text = "검토자  :";
            // 
            // PQMS_STAFF_ROLE_CHECKGrid
            // 
            this.PQMS_STAFF_ROLE_CHECKGrid.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_STAFF_ROLE_CHECKGrid.Location = new System.Drawing.Point(12, 197);
            this.PQMS_STAFF_ROLE_CHECKGrid.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_STAFF_ROLE_CHECKGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_STAFF_ROLE_CHECKGrid.MainView = this.PQMS_STAFF_ROLE_CHECKGridView;
            this.PQMS_STAFF_ROLE_CHECKGrid.Name = "PQMS_STAFF_ROLE_CHECKGrid";
            this.PQMS_STAFF_ROLE_CHECKGrid.Size = new System.Drawing.Size(553, 290);
            this.PQMS_STAFF_ROLE_CHECKGrid.TabIndex = 356;
            this.PQMS_STAFF_ROLE_CHECKGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_STAFF_ROLE_CHECKGridView});
            this.PQMS_STAFF_ROLE_CHECKGrid.Visible = false;
            // 
            // PQMS_STAFF_ROLE_CHECKGridView
            // 
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.Row.Options.UseFont = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ROLE_CHECKGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.PQMS_STAFF_ROLE_CHECKGridView.CustomizationFormBounds = new System.Drawing.Rectangle(1070, 394, 210, 186);
            this.PQMS_STAFF_ROLE_CHECKGridView.GridControl = this.PQMS_STAFF_ROLE_CHECKGrid;
            this.PQMS_STAFF_ROLE_CHECKGridView.Name = "PQMS_STAFF_ROLE_CHECKGridView";
            this.PQMS_STAFF_ROLE_CHECKGridView.OptionsBehavior.Editable = false;
            this.PQMS_STAFF_ROLE_CHECKGridView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_STAFF_ROLE_CHECKGridView.OptionsHint.ShowFooterHints = false;
            this.PQMS_STAFF_ROLE_CHECKGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_STAFF_ROLE_CHECKGridView.OptionsSelection.InvertSelection = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.OptionsSelection.MultiSelect = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.PQMS_STAFF_ROLE_CHECKGridView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_STAFF_ROLE_CHECKGridView.OptionsView.RowAutoHeight = true;
            this.PQMS_STAFF_ROLE_CHECKGridView.OptionsView.ShowGroupPanel = false;
            this.PQMS_STAFF_ROLE_CHECKGridView.OptionsView.ShowIndicator = false;
            this.PQMS_STAFF_ROLE_CHECKGridView.Tag = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "기관";
            this.gridColumn1.FieldName = "ORG_NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 120;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "대분류";
            this.gridColumn2.FieldName = "GROUP1_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "중분류";
            this.gridColumn3.FieldName = "GROUP2_NAME";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 120;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "직무코드";
            this.gridColumn4.FieldName = "STAFF_ROLE_CODE";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 60;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "직무명";
            this.gridColumn5.FieldName = "STAFF_ROLE_NAME";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 80;
            // 
            // frmApproveRequestVer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 190);
            this.Controls.Add(this.cmbApprove2);
            this.Controls.Add(this.cmbApprove1);
            this.Controls.Add(this.PQMS_STAFF_ROLE_CHECKGrid);
            this.Controls.Add(this.txtAccountNo1);
            this.Controls.Add(this.txtLoginID1);
            this.Controls.Add(this.btnApprove1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRequestContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtAccountNo2);
            this.Controls.Add(this.txtLoginID2);
            this.Controls.Add(this.btnApprove2);
            this.Controls.Add(this.txtidxNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnApproveGo);
            this.Name = "frmApproveRequestVer2";
            this.Load += new System.EventHandler(this.frmApproveRequestVer2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_ROLE_CHECKGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_ROLE_CHECKGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtRequestContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAccountNo2;
        private System.Windows.Forms.TextBox txtLoginID2;
        private System.Windows.Forms.ComboBox cmbApprove2;
        private System.Windows.Forms.Button btnApprove2;
        private System.Windows.Forms.TextBox txtidxNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnApproveGo;
        private System.Windows.Forms.TextBox txtAccountNo1;
        private System.Windows.Forms.TextBox txtLoginID1;
        private System.Windows.Forms.ComboBox cmbApprove1;
        private System.Windows.Forms.Button btnApprove1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl PQMS_STAFF_ROLE_CHECKGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_STAFF_ROLE_CHECKGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}