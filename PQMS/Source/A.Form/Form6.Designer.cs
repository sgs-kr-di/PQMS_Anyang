
namespace PQMS
{
    partial class Form6
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
            this.txtEDU_NAME = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtEDU_CODE = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtEDU_ORG_CODE = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.btnEduDelete = new System.Windows.Forms.Button();
            this.btnEduUpdate = new System.Windows.Forms.Button();
            this.btnEduInsert = new System.Windows.Forms.Button();
            this.PQMS_EDUGrid = new DevExpress.XtraGrid.GridControl();
            this.PQMS_EDUGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EDU_ORG_CODEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EDU_ORG_CODETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.EDU_CODEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EDU_CODETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.EDU_NAMEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EDU_NAMETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnLookUpData = new System.Windows.Forms.Button();
            this.txtOrgName = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.cmbFolder = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDUGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDUGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDU_ORG_CODETextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDU_CODETextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDU_NAMETextEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEDU_NAME
            // 
            this.txtEDU_NAME.Location = new System.Drawing.Point(133, 166);
            this.txtEDU_NAME.Name = "txtEDU_NAME";
            this.txtEDU_NAME.Size = new System.Drawing.Size(275, 20);
            this.txtEDU_NAME.TabIndex = 59;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(20, 166);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(46, 13);
            this.Label2.TabIndex = 58;
            this.Label2.Text = "교육명 :";
            // 
            // txtEDU_CODE
            // 
            this.txtEDU_CODE.Location = new System.Drawing.Point(133, 140);
            this.txtEDU_CODE.Name = "txtEDU_CODE";
            this.txtEDU_CODE.Size = new System.Drawing.Size(275, 20);
            this.txtEDU_CODE.TabIndex = 57;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(20, 140);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(107, 13);
            this.Label1.TabIndex = 56;
            this.Label1.Text = "교육 주관기관 번호 :";
            // 
            // txtEDU_ORG_CODE
            // 
            this.txtEDU_ORG_CODE.Location = new System.Drawing.Point(133, 111);
            this.txtEDU_ORG_CODE.Name = "txtEDU_ORG_CODE";
            this.txtEDU_ORG_CODE.Size = new System.Drawing.Size(63, 20);
            this.txtEDU_ORG_CODE.TabIndex = 55;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(20, 114);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(93, 13);
            this.Label15.TabIndex = 54;
            this.Label15.Text = "교육명 관리번호 :";
            // 
            // btnEduDelete
            // 
            this.btnEduDelete.Location = new System.Drawing.Point(223, 80);
            this.btnEduDelete.Name = "btnEduDelete";
            this.btnEduDelete.Size = new System.Drawing.Size(75, 23);
            this.btnEduDelete.TabIndex = 111;
            this.btnEduDelete.Text = "삭제";
            this.btnEduDelete.UseVisualStyleBackColor = true;
            this.btnEduDelete.Click += new System.EventHandler(this.btnEduDelete_Click);
            // 
            // btnEduUpdate
            // 
            this.btnEduUpdate.Location = new System.Drawing.Point(121, 80);
            this.btnEduUpdate.Name = "btnEduUpdate";
            this.btnEduUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnEduUpdate.TabIndex = 112;
            this.btnEduUpdate.Text = "수정";
            this.btnEduUpdate.UseVisualStyleBackColor = true;
            this.btnEduUpdate.Click += new System.EventHandler(this.btnEduUpdate_Click);
            // 
            // btnEduInsert
            // 
            this.btnEduInsert.Location = new System.Drawing.Point(23, 80);
            this.btnEduInsert.Name = "btnEduInsert";
            this.btnEduInsert.Size = new System.Drawing.Size(75, 23);
            this.btnEduInsert.TabIndex = 113;
            this.btnEduInsert.Text = "저장";
            this.btnEduInsert.UseVisualStyleBackColor = true;
            this.btnEduInsert.Click += new System.EventHandler(this.btnEduInsert_Click);
            // 
            // PQMS_EDUGrid
            // 
            this.PQMS_EDUGrid.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_EDUGrid.Location = new System.Drawing.Point(23, 232);
            this.PQMS_EDUGrid.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_EDUGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_EDUGrid.MainView = this.PQMS_EDUGridView;
            this.PQMS_EDUGrid.Name = "PQMS_EDUGrid";
            this.PQMS_EDUGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.EDU_ORG_CODETextEdit,
            this.EDU_CODETextEdit,
            this.EDU_NAMETextEdit});
            this.PQMS_EDUGrid.Size = new System.Drawing.Size(771, 193);
            this.PQMS_EDUGrid.TabIndex = 239;
            this.PQMS_EDUGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_EDUGridView});
            // 
            // PQMS_EDUGridView
            // 
            this.PQMS_EDUGridView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDUGridView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_EDUGridView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_EDUGridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDUGridView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_EDUGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDUGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_EDUGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDUGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_EDUGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDUGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_EDUGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDUGridView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_EDUGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDUGridView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_EDUGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDUGridView.Appearance.Row.Options.UseFont = true;
            this.PQMS_EDUGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDUGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_EDUGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDUGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_EDUGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.EDU_ORG_CODEColumn,
            this.EDU_CODEColumn,
            this.EDU_NAMEColumn});
            this.PQMS_EDUGridView.CustomizationFormBounds = new System.Drawing.Rectangle(1920, 580, 210, 186);
            this.PQMS_EDUGridView.GridControl = this.PQMS_EDUGrid;
            this.PQMS_EDUGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.PQMS_EDUGridView.Name = "PQMS_EDUGridView";
            this.PQMS_EDUGridView.OptionsBehavior.Editable = false;
            this.PQMS_EDUGridView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_EDUGridView.OptionsHint.ShowFooterHints = false;
            this.PQMS_EDUGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_EDUGridView.OptionsSelection.InvertSelection = true;
            this.PQMS_EDUGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.PQMS_EDUGridView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_EDUGridView.OptionsView.RowAutoHeight = true;
            this.PQMS_EDUGridView.OptionsView.ShowGroupPanel = false;
            this.PQMS_EDUGridView.OptionsView.ShowIndicator = false;
            this.PQMS_EDUGridView.Tag = 1;
            this.PQMS_EDUGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.PQMS_EDUGridView_RowCellClick);
            // 
            // EDU_ORG_CODEColumn
            // 
            this.EDU_ORG_CODEColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDU_ORG_CODEColumn.AppearanceCell.Options.UseFont = true;
            this.EDU_ORG_CODEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.EDU_ORG_CODEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EDU_ORG_CODEColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDU_ORG_CODEColumn.AppearanceHeader.Options.UseFont = true;
            this.EDU_ORG_CODEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.EDU_ORG_CODEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EDU_ORG_CODEColumn.Caption = "교육 주관기관";
            this.EDU_ORG_CODEColumn.ColumnEdit = this.EDU_ORG_CODETextEdit;
            this.EDU_ORG_CODEColumn.FieldName = "EDU_ORG_CODE";
            this.EDU_ORG_CODEColumn.Name = "EDU_ORG_CODEColumn";
            this.EDU_ORG_CODEColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.EDU_ORG_CODEColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.EDU_ORG_CODEColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.EDU_ORG_CODEColumn.OptionsColumn.AllowMove = false;
            this.EDU_ORG_CODEColumn.OptionsColumn.AllowShowHide = false;
            this.EDU_ORG_CODEColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.EDU_ORG_CODEColumn.OptionsColumn.FixedWidth = true;
            this.EDU_ORG_CODEColumn.OptionsFilter.AllowAutoFilter = false;
            this.EDU_ORG_CODEColumn.OptionsFilter.AllowFilter = false;
            this.EDU_ORG_CODEColumn.Visible = true;
            this.EDU_ORG_CODEColumn.VisibleIndex = 0;
            this.EDU_ORG_CODEColumn.Width = 120;
            // 
            // EDU_ORG_CODETextEdit
            // 
            this.EDU_ORG_CODETextEdit.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDU_ORG_CODETextEdit.Appearance.Options.UseFont = true;
            this.EDU_ORG_CODETextEdit.Appearance.Options.UseTextOptions = true;
            this.EDU_ORG_CODETextEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EDU_ORG_CODETextEdit.AppearanceFocused.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDU_ORG_CODETextEdit.AppearanceFocused.Options.UseFont = true;
            this.EDU_ORG_CODETextEdit.AppearanceFocused.Options.UseTextOptions = true;
            this.EDU_ORG_CODETextEdit.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EDU_ORG_CODETextEdit.AutoHeight = false;
            this.EDU_ORG_CODETextEdit.MaxLength = 20;
            this.EDU_ORG_CODETextEdit.Name = "EDU_ORG_CODETextEdit";
            // 
            // EDU_CODEColumn
            // 
            this.EDU_CODEColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDU_CODEColumn.AppearanceCell.Options.UseFont = true;
            this.EDU_CODEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.EDU_CODEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EDU_CODEColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDU_CODEColumn.AppearanceHeader.Options.UseFont = true;
            this.EDU_CODEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.EDU_CODEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EDU_CODEColumn.Caption = "교육명 관리번호";
            this.EDU_CODEColumn.ColumnEdit = this.EDU_CODETextEdit;
            this.EDU_CODEColumn.FieldName = "EDU_CODE";
            this.EDU_CODEColumn.Name = "EDU_CODEColumn";
            this.EDU_CODEColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.EDU_CODEColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.EDU_CODEColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.EDU_CODEColumn.OptionsColumn.AllowMove = false;
            this.EDU_CODEColumn.OptionsColumn.AllowShowHide = false;
            this.EDU_CODEColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.EDU_CODEColumn.OptionsColumn.FixedWidth = true;
            this.EDU_CODEColumn.OptionsFilter.AllowAutoFilter = false;
            this.EDU_CODEColumn.OptionsFilter.AllowFilter = false;
            this.EDU_CODEColumn.Visible = true;
            this.EDU_CODEColumn.VisibleIndex = 1;
            this.EDU_CODEColumn.Width = 102;
            // 
            // EDU_CODETextEdit
            // 
            this.EDU_CODETextEdit.AutoHeight = false;
            this.EDU_CODETextEdit.Name = "EDU_CODETextEdit";
            // 
            // EDU_NAMEColumn
            // 
            this.EDU_NAMEColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDU_NAMEColumn.AppearanceCell.Options.UseFont = true;
            this.EDU_NAMEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.EDU_NAMEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EDU_NAMEColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDU_NAMEColumn.AppearanceHeader.Options.UseFont = true;
            this.EDU_NAMEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.EDU_NAMEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EDU_NAMEColumn.Caption = "교육명";
            this.EDU_NAMEColumn.ColumnEdit = this.EDU_NAMETextEdit;
            this.EDU_NAMEColumn.FieldName = "EDU_NAME";
            this.EDU_NAMEColumn.Name = "EDU_NAMEColumn";
            this.EDU_NAMEColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.EDU_NAMEColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.EDU_NAMEColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.EDU_NAMEColumn.OptionsColumn.AllowMove = false;
            this.EDU_NAMEColumn.OptionsColumn.AllowShowHide = false;
            this.EDU_NAMEColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.EDU_NAMEColumn.OptionsColumn.FixedWidth = true;
            this.EDU_NAMEColumn.OptionsFilter.AllowAutoFilter = false;
            this.EDU_NAMEColumn.OptionsFilter.AllowFilter = false;
            this.EDU_NAMEColumn.Visible = true;
            this.EDU_NAMEColumn.VisibleIndex = 2;
            this.EDU_NAMEColumn.Width = 250;
            // 
            // EDU_NAMETextEdit
            // 
            this.EDU_NAMETextEdit.AutoHeight = false;
            this.EDU_NAMETextEdit.Name = "EDU_NAMETextEdit";
            // 
            // btnLookUpData
            // 
            this.btnLookUpData.Location = new System.Drawing.Point(23, 201);
            this.btnLookUpData.Name = "btnLookUpData";
            this.btnLookUpData.Size = new System.Drawing.Size(64, 25);
            this.btnLookUpData.TabIndex = 238;
            this.btnLookUpData.Text = "조회";
            this.btnLookUpData.UseVisualStyleBackColor = true;
            this.btnLookUpData.Click += new System.EventHandler(this.btnLookUpData_Click);
            // 
            // txtOrgName
            // 
            this.txtOrgName.Location = new System.Drawing.Point(202, 111);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Size = new System.Drawing.Size(96, 20);
            this.txtOrgName.TabIndex = 248;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(414, 109);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(55, 22);
            this.button10.TabIndex = 247;
            this.button10.Text = "찾기";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // cmbFolder
            // 
            this.cmbFolder.FormattingEnabled = true;
            this.cmbFolder.Location = new System.Drawing.Point(304, 111);
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(104, 21);
            this.cmbFolder.TabIndex = 246;
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 459);
            this.Controls.Add(this.txtOrgName);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.cmbFolder);
            this.Controls.Add(this.PQMS_EDUGrid);
            this.Controls.Add(this.btnLookUpData);
            this.Controls.Add(this.btnEduDelete);
            this.Controls.Add(this.btnEduUpdate);
            this.Controls.Add(this.btnEduInsert);
            this.Controls.Add(this.txtEDU_NAME);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtEDU_CODE);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtEDU_ORG_CODE);
            this.Controls.Add(this.Label15);
            this.Name = "Form6";
            this.Text = "교육명 관리";
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDUGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDUGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDU_ORG_CODETextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDU_CODETextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDU_NAMETextEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtEDU_NAME;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtEDU_CODE;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtEDU_ORG_CODE;
        internal System.Windows.Forms.Label Label15;
        private System.Windows.Forms.Button btnEduDelete;
        private System.Windows.Forms.Button btnEduUpdate;
        private System.Windows.Forms.Button btnEduInsert;
        private DevExpress.XtraGrid.GridControl PQMS_EDUGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_EDUGridView;
        private DevExpress.XtraGrid.Columns.GridColumn EDU_ORG_CODEColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit EDU_ORG_CODETextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn EDU_CODEColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit EDU_CODETextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn EDU_NAMEColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit EDU_NAMETextEdit;
        private System.Windows.Forms.Button btnLookUpData;
        internal System.Windows.Forms.TextBox txtOrgName;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox cmbFolder;
    }
}