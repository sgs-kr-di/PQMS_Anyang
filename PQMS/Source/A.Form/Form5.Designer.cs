
namespace PQMS
{
    partial class Form5
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
            this.txtORG_NAME = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtORG_CODE = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.btnOrgDelete = new System.Windows.Forms.Button();
            this.btnOrgUpdate = new System.Windows.Forms.Button();
            this.btnOrgInsert = new System.Windows.Forms.Button();
            this.PQMS_ORGGrid = new DevExpress.XtraGrid.GridControl();
            this.PQMS_ORGGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ORG_CODEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORG_CODETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ORG_NAMEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORG_NAMETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnLookUpData = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.cmbFolder = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_ORGGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_ORGGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ORG_CODETextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ORG_NAMETextEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtORG_NAME
            // 
            this.txtORG_NAME.Location = new System.Drawing.Point(97, 135);
            this.txtORG_NAME.Name = "txtORG_NAME";
            this.txtORG_NAME.Size = new System.Drawing.Size(165, 20);
            this.txtORG_NAME.TabIndex = 51;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 135);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(57, 13);
            this.Label1.TabIndex = 50;
            this.Label1.Text = "기관이름 :";
            // 
            // txtORG_CODE
            // 
            this.txtORG_CODE.Location = new System.Drawing.Point(97, 109);
            this.txtORG_CODE.Name = "txtORG_CODE";
            this.txtORG_CODE.Size = new System.Drawing.Size(165, 20);
            this.txtORG_CODE.TabIndex = 49;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(12, 109);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(79, 13);
            this.Label15.TabIndex = 48;
            this.Label15.Text = "기관관리번호 :";
            // 
            // btnOrgDelete
            // 
            this.btnOrgDelete.Location = new System.Drawing.Point(216, 62);
            this.btnOrgDelete.Name = "btnOrgDelete";
            this.btnOrgDelete.Size = new System.Drawing.Size(75, 23);
            this.btnOrgDelete.TabIndex = 108;
            this.btnOrgDelete.Text = "삭제";
            this.btnOrgDelete.UseVisualStyleBackColor = true;
            this.btnOrgDelete.Click += new System.EventHandler(this.btnOrgDelete_Click);
            // 
            // btnOrgUpdate
            // 
            this.btnOrgUpdate.Location = new System.Drawing.Point(114, 62);
            this.btnOrgUpdate.Name = "btnOrgUpdate";
            this.btnOrgUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnOrgUpdate.TabIndex = 109;
            this.btnOrgUpdate.Text = "수정";
            this.btnOrgUpdate.UseVisualStyleBackColor = true;
            this.btnOrgUpdate.Click += new System.EventHandler(this.btnOrgUpdate_Click);
            // 
            // btnOrgInsert
            // 
            this.btnOrgInsert.Location = new System.Drawing.Point(16, 62);
            this.btnOrgInsert.Name = "btnOrgInsert";
            this.btnOrgInsert.Size = new System.Drawing.Size(75, 23);
            this.btnOrgInsert.TabIndex = 110;
            this.btnOrgInsert.Text = "저장";
            this.btnOrgInsert.UseVisualStyleBackColor = true;
            this.btnOrgInsert.Click += new System.EventHandler(this.btnOrgInsert_Click);
            // 
            // PQMS_ORGGrid
            // 
            this.PQMS_ORGGrid.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_ORGGrid.Location = new System.Drawing.Point(15, 205);
            this.PQMS_ORGGrid.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_ORGGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_ORGGrid.MainView = this.PQMS_ORGGridView;
            this.PQMS_ORGGrid.Name = "PQMS_ORGGrid";
            this.PQMS_ORGGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ORG_CODETextEdit,
            this.ORG_NAMETextEdit});
            this.PQMS_ORGGrid.Size = new System.Drawing.Size(771, 193);
            this.PQMS_ORGGrid.TabIndex = 239;
            this.PQMS_ORGGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_ORGGridView});
            // 
            // PQMS_ORGGridView
            // 
            this.PQMS_ORGGridView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ORGGridView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_ORGGridView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_ORGGridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ORGGridView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_ORGGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ORGGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_ORGGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ORGGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_ORGGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ORGGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_ORGGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ORGGridView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_ORGGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ORGGridView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_ORGGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ORGGridView.Appearance.Row.Options.UseFont = true;
            this.PQMS_ORGGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ORGGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_ORGGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ORGGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_ORGGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ORG_CODEColumn,
            this.ORG_NAMEColumn});
            this.PQMS_ORGGridView.CustomizationFormBounds = new System.Drawing.Rectangle(1920, 580, 210, 186);
            this.PQMS_ORGGridView.GridControl = this.PQMS_ORGGrid;
            this.PQMS_ORGGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.PQMS_ORGGridView.Name = "PQMS_ORGGridView";
            this.PQMS_ORGGridView.OptionsBehavior.Editable = false;
            this.PQMS_ORGGridView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_ORGGridView.OptionsHint.ShowFooterHints = false;
            this.PQMS_ORGGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_ORGGridView.OptionsSelection.InvertSelection = true;
            this.PQMS_ORGGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.PQMS_ORGGridView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_ORGGridView.OptionsView.RowAutoHeight = true;
            this.PQMS_ORGGridView.OptionsView.ShowGroupPanel = false;
            this.PQMS_ORGGridView.OptionsView.ShowIndicator = false;
            this.PQMS_ORGGridView.Tag = 1;
            this.PQMS_ORGGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.PQMS_ORGGridView_RowCellClick);
            // 
            // ORG_CODEColumn
            // 
            this.ORG_CODEColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ORG_CODEColumn.AppearanceCell.Options.UseFont = true;
            this.ORG_CODEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.ORG_CODEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ORG_CODEColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ORG_CODEColumn.AppearanceHeader.Options.UseFont = true;
            this.ORG_CODEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.ORG_CODEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ORG_CODEColumn.Caption = "기관관리번호";
            this.ORG_CODEColumn.ColumnEdit = this.ORG_CODETextEdit;
            this.ORG_CODEColumn.FieldName = "ORG_CODE";
            this.ORG_CODEColumn.Name = "ORG_CODEColumn";
            this.ORG_CODEColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ORG_CODEColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.ORG_CODEColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ORG_CODEColumn.OptionsColumn.AllowMove = false;
            this.ORG_CODEColumn.OptionsColumn.AllowShowHide = false;
            this.ORG_CODEColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ORG_CODEColumn.OptionsColumn.FixedWidth = true;
            this.ORG_CODEColumn.OptionsFilter.AllowAutoFilter = false;
            this.ORG_CODEColumn.OptionsFilter.AllowFilter = false;
            this.ORG_CODEColumn.Visible = true;
            this.ORG_CODEColumn.VisibleIndex = 0;
            this.ORG_CODEColumn.Width = 96;
            // 
            // ORG_CODETextEdit
            // 
            this.ORG_CODETextEdit.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ORG_CODETextEdit.Appearance.Options.UseFont = true;
            this.ORG_CODETextEdit.Appearance.Options.UseTextOptions = true;
            this.ORG_CODETextEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ORG_CODETextEdit.AppearanceFocused.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ORG_CODETextEdit.AppearanceFocused.Options.UseFont = true;
            this.ORG_CODETextEdit.AppearanceFocused.Options.UseTextOptions = true;
            this.ORG_CODETextEdit.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ORG_CODETextEdit.AutoHeight = false;
            this.ORG_CODETextEdit.MaxLength = 20;
            this.ORG_CODETextEdit.Name = "ORG_CODETextEdit";
            // 
            // ORG_NAMEColumn
            // 
            this.ORG_NAMEColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ORG_NAMEColumn.AppearanceCell.Options.UseFont = true;
            this.ORG_NAMEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.ORG_NAMEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ORG_NAMEColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ORG_NAMEColumn.AppearanceHeader.Options.UseFont = true;
            this.ORG_NAMEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.ORG_NAMEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ORG_NAMEColumn.Caption = "기관이름";
            this.ORG_NAMEColumn.ColumnEdit = this.ORG_NAMETextEdit;
            this.ORG_NAMEColumn.FieldName = "ORG_NAME";
            this.ORG_NAMEColumn.Name = "ORG_NAMEColumn";
            this.ORG_NAMEColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ORG_NAMEColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.ORG_NAMEColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ORG_NAMEColumn.OptionsColumn.AllowMove = false;
            this.ORG_NAMEColumn.OptionsColumn.AllowShowHide = false;
            this.ORG_NAMEColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ORG_NAMEColumn.OptionsColumn.FixedWidth = true;
            this.ORG_NAMEColumn.OptionsFilter.AllowAutoFilter = false;
            this.ORG_NAMEColumn.OptionsFilter.AllowFilter = false;
            this.ORG_NAMEColumn.Visible = true;
            this.ORG_NAMEColumn.VisibleIndex = 1;
            this.ORG_NAMEColumn.Width = 102;
            // 
            // ORG_NAMETextEdit
            // 
            this.ORG_NAMETextEdit.AutoHeight = false;
            this.ORG_NAMETextEdit.Name = "ORG_NAMETextEdit";
            // 
            // btnLookUpData
            // 
            this.btnLookUpData.Location = new System.Drawing.Point(15, 174);
            this.btnLookUpData.Name = "btnLookUpData";
            this.btnLookUpData.Size = new System.Drawing.Size(64, 25);
            this.btnLookUpData.TabIndex = 238;
            this.btnLookUpData.Text = "조회";
            this.btnLookUpData.UseVisualStyleBackColor = true;
            this.btnLookUpData.Click += new System.EventHandler(this.btnLookUpData_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(377, 108);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(55, 22);
            this.button10.TabIndex = 250;
            this.button10.Text = "찾기";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // cmbFolder
            // 
            this.cmbFolder.FormattingEnabled = true;
            this.cmbFolder.Location = new System.Drawing.Point(268, 109);
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(104, 21);
            this.cmbFolder.TabIndex = 249;
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.cmbFolder);
            this.Controls.Add(this.PQMS_ORGGrid);
            this.Controls.Add(this.btnLookUpData);
            this.Controls.Add(this.btnOrgDelete);
            this.Controls.Add(this.btnOrgUpdate);
            this.Controls.Add(this.btnOrgInsert);
            this.Controls.Add(this.txtORG_NAME);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtORG_CODE);
            this.Controls.Add(this.Label15);
            this.Name = "Form5";
            this.Text = "주관기관관리";
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_ORGGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_ORGGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ORG_CODETextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ORG_NAMETextEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtORG_NAME;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtORG_CODE;
        internal System.Windows.Forms.Label Label15;
        private System.Windows.Forms.Button btnOrgDelete;
        private System.Windows.Forms.Button btnOrgUpdate;
        private System.Windows.Forms.Button btnOrgInsert;
        private DevExpress.XtraGrid.GridControl PQMS_ORGGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_ORGGridView;
        private DevExpress.XtraGrid.Columns.GridColumn ORG_CODEColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ORG_CODETextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn ORG_NAMEColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ORG_NAMETextEdit;
        private System.Windows.Forms.Button btnLookUpData;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox cmbFolder;
    }
}