
namespace PQMS
{
    partial class Form11
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
            this.txtTEAM_NAME2 = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtTEAM_NAME = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtTEAM_CODE = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnTeamDelete = new System.Windows.Forms.Button();
            this.btnTeamUpdate = new System.Windows.Forms.Button();
            this.btnTeamInsert = new System.Windows.Forms.Button();
            this.PQMS_TEAMGrid = new DevExpress.XtraGrid.GridControl();
            this.PQMS_TEAMGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TEAM_CODEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEAM_CODETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TEAM_NAMEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEAM_NAMETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TEAM_NAME2Column = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEAM_NAME2TextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnLookUpData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_TEAMGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_TEAMGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEAM_CODETextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEAM_NAMETextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEAM_NAME2TextEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTEAM_NAME2
            // 
            this.txtTEAM_NAME2.Location = new System.Drawing.Point(125, 120);
            this.txtTEAM_NAME2.Name = "txtTEAM_NAME2";
            this.txtTEAM_NAME2.Size = new System.Drawing.Size(165, 20);
            this.txtTEAM_NAME2.TabIndex = 97;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(12, 123);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(46, 13);
            this.Label8.TabIndex = 96;
            this.Label8.Text = "소속명 :";
            // 
            // txtTEAM_NAME
            // 
            this.txtTEAM_NAME.Location = new System.Drawing.Point(125, 87);
            this.txtTEAM_NAME.Name = "txtTEAM_NAME";
            this.txtTEAM_NAME.Size = new System.Drawing.Size(165, 20);
            this.txtTEAM_NAME.TabIndex = 95;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(12, 87);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(46, 13);
            this.Label7.TabIndex = 94;
            this.Label7.Text = "부서명 :";
            // 
            // txtTEAM_CODE
            // 
            this.txtTEAM_CODE.Location = new System.Drawing.Point(125, 52);
            this.txtTEAM_CODE.Name = "txtTEAM_CODE";
            this.txtTEAM_CODE.Size = new System.Drawing.Size(165, 20);
            this.txtTEAM_CODE.TabIndex = 93;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(12, 52);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(57, 13);
            this.Label6.TabIndex = 92;
            this.Label6.Text = "부서코드 :";
            // 
            // btnTeamDelete
            // 
            this.btnTeamDelete.Location = new System.Drawing.Point(215, 12);
            this.btnTeamDelete.Name = "btnTeamDelete";
            this.btnTeamDelete.Size = new System.Drawing.Size(75, 23);
            this.btnTeamDelete.TabIndex = 105;
            this.btnTeamDelete.Text = "삭제";
            this.btnTeamDelete.UseVisualStyleBackColor = true;
            this.btnTeamDelete.Click += new System.EventHandler(this.btnTeamDelete_Click);
            // 
            // btnTeamUpdate
            // 
            this.btnTeamUpdate.Location = new System.Drawing.Point(113, 12);
            this.btnTeamUpdate.Name = "btnTeamUpdate";
            this.btnTeamUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnTeamUpdate.TabIndex = 106;
            this.btnTeamUpdate.Text = "수정";
            this.btnTeamUpdate.UseVisualStyleBackColor = true;
            this.btnTeamUpdate.Click += new System.EventHandler(this.btnTeamUpdate_Click);
            // 
            // btnTeamInsert
            // 
            this.btnTeamInsert.Location = new System.Drawing.Point(15, 12);
            this.btnTeamInsert.Name = "btnTeamInsert";
            this.btnTeamInsert.Size = new System.Drawing.Size(75, 23);
            this.btnTeamInsert.TabIndex = 107;
            this.btnTeamInsert.Text = "입력";
            this.btnTeamInsert.UseVisualStyleBackColor = true;
            this.btnTeamInsert.Click += new System.EventHandler(this.btnTeamInsert_Click);
            // 
            // PQMS_TEAMGrid
            // 
            this.PQMS_TEAMGrid.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_TEAMGrid.Location = new System.Drawing.Point(15, 209);
            this.PQMS_TEAMGrid.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_TEAMGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_TEAMGrid.MainView = this.PQMS_TEAMGridView;
            this.PQMS_TEAMGrid.Name = "PQMS_TEAMGrid";
            this.PQMS_TEAMGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TEAM_CODETextEdit,
            this.TEAM_NAMETextEdit,
            this.TEAM_NAME2TextEdit});
            this.PQMS_TEAMGrid.Size = new System.Drawing.Size(771, 193);
            this.PQMS_TEAMGrid.TabIndex = 239;
            this.PQMS_TEAMGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_TEAMGridView});
            // 
            // PQMS_TEAMGridView
            // 
            this.PQMS_TEAMGridView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_TEAMGridView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_TEAMGridView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_TEAMGridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_TEAMGridView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_TEAMGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_TEAMGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_TEAMGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_TEAMGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_TEAMGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_TEAMGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_TEAMGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_TEAMGridView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_TEAMGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_TEAMGridView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_TEAMGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_TEAMGridView.Appearance.Row.Options.UseFont = true;
            this.PQMS_TEAMGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_TEAMGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_TEAMGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_TEAMGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_TEAMGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TEAM_CODEColumn,
            this.TEAM_NAMEColumn,
            this.TEAM_NAME2Column});
            this.PQMS_TEAMGridView.CustomizationFormBounds = new System.Drawing.Rectangle(1710, 580, 210, 186);
            this.PQMS_TEAMGridView.GridControl = this.PQMS_TEAMGrid;
            this.PQMS_TEAMGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.PQMS_TEAMGridView.Name = "PQMS_TEAMGridView";
            this.PQMS_TEAMGridView.OptionsBehavior.Editable = false;
            this.PQMS_TEAMGridView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_TEAMGridView.OptionsHint.ShowFooterHints = false;
            this.PQMS_TEAMGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_TEAMGridView.OptionsSelection.InvertSelection = true;
            this.PQMS_TEAMGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.PQMS_TEAMGridView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_TEAMGridView.OptionsView.RowAutoHeight = true;
            this.PQMS_TEAMGridView.OptionsView.ShowGroupPanel = false;
            this.PQMS_TEAMGridView.OptionsView.ShowIndicator = false;
            this.PQMS_TEAMGridView.Tag = 1;
            this.PQMS_TEAMGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.PQMS_TEAMGridView_RowCellClick);
            // 
            // TEAM_CODEColumn
            // 
            this.TEAM_CODEColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEAM_CODEColumn.AppearanceCell.Options.UseFont = true;
            this.TEAM_CODEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.TEAM_CODEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEAM_CODEColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEAM_CODEColumn.AppearanceHeader.Options.UseFont = true;
            this.TEAM_CODEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.TEAM_CODEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEAM_CODEColumn.Caption = "부서코드";
            this.TEAM_CODEColumn.ColumnEdit = this.TEAM_CODETextEdit;
            this.TEAM_CODEColumn.FieldName = "TEAM_CODE";
            this.TEAM_CODEColumn.Name = "TEAM_CODEColumn";
            this.TEAM_CODEColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.TEAM_CODEColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.TEAM_CODEColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TEAM_CODEColumn.OptionsColumn.AllowMove = false;
            this.TEAM_CODEColumn.OptionsColumn.AllowShowHide = false;
            this.TEAM_CODEColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.TEAM_CODEColumn.OptionsColumn.FixedWidth = true;
            this.TEAM_CODEColumn.OptionsFilter.AllowAutoFilter = false;
            this.TEAM_CODEColumn.OptionsFilter.AllowFilter = false;
            this.TEAM_CODEColumn.Visible = true;
            this.TEAM_CODEColumn.VisibleIndex = 0;
            this.TEAM_CODEColumn.Width = 96;
            // 
            // TEAM_CODETextEdit
            // 
            this.TEAM_CODETextEdit.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEAM_CODETextEdit.Appearance.Options.UseFont = true;
            this.TEAM_CODETextEdit.Appearance.Options.UseTextOptions = true;
            this.TEAM_CODETextEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEAM_CODETextEdit.AppearanceFocused.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEAM_CODETextEdit.AppearanceFocused.Options.UseFont = true;
            this.TEAM_CODETextEdit.AppearanceFocused.Options.UseTextOptions = true;
            this.TEAM_CODETextEdit.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEAM_CODETextEdit.AutoHeight = false;
            this.TEAM_CODETextEdit.MaxLength = 20;
            this.TEAM_CODETextEdit.Name = "TEAM_CODETextEdit";
            // 
            // TEAM_NAMEColumn
            // 
            this.TEAM_NAMEColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEAM_NAMEColumn.AppearanceCell.Options.UseFont = true;
            this.TEAM_NAMEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.TEAM_NAMEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEAM_NAMEColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEAM_NAMEColumn.AppearanceHeader.Options.UseFont = true;
            this.TEAM_NAMEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.TEAM_NAMEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEAM_NAMEColumn.Caption = "부서명";
            this.TEAM_NAMEColumn.ColumnEdit = this.TEAM_NAMETextEdit;
            this.TEAM_NAMEColumn.FieldName = "TEAM_NAME";
            this.TEAM_NAMEColumn.Name = "TEAM_NAMEColumn";
            this.TEAM_NAMEColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.TEAM_NAMEColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.TEAM_NAMEColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TEAM_NAMEColumn.OptionsColumn.AllowMove = false;
            this.TEAM_NAMEColumn.OptionsColumn.AllowShowHide = false;
            this.TEAM_NAMEColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.TEAM_NAMEColumn.OptionsColumn.FixedWidth = true;
            this.TEAM_NAMEColumn.OptionsFilter.AllowAutoFilter = false;
            this.TEAM_NAMEColumn.OptionsFilter.AllowFilter = false;
            this.TEAM_NAMEColumn.Visible = true;
            this.TEAM_NAMEColumn.VisibleIndex = 1;
            this.TEAM_NAMEColumn.Width = 102;
            // 
            // TEAM_NAMETextEdit
            // 
            this.TEAM_NAMETextEdit.AutoHeight = false;
            this.TEAM_NAMETextEdit.Name = "TEAM_NAMETextEdit";
            // 
            // TEAM_NAME2Column
            // 
            this.TEAM_NAME2Column.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEAM_NAME2Column.AppearanceCell.Options.UseFont = true;
            this.TEAM_NAME2Column.AppearanceCell.Options.UseTextOptions = true;
            this.TEAM_NAME2Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEAM_NAME2Column.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEAM_NAME2Column.AppearanceHeader.Options.UseFont = true;
            this.TEAM_NAME2Column.AppearanceHeader.Options.UseTextOptions = true;
            this.TEAM_NAME2Column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEAM_NAME2Column.Caption = "소속명";
            this.TEAM_NAME2Column.ColumnEdit = this.TEAM_NAME2TextEdit;
            this.TEAM_NAME2Column.FieldName = "TEAM_NAME2";
            this.TEAM_NAME2Column.MaxWidth = 90;
            this.TEAM_NAME2Column.Name = "TEAM_NAME2Column";
            this.TEAM_NAME2Column.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.TEAM_NAME2Column.OptionsColumn.AllowIncrementalSearch = false;
            this.TEAM_NAME2Column.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TEAM_NAME2Column.OptionsColumn.AllowMove = false;
            this.TEAM_NAME2Column.OptionsColumn.AllowShowHide = false;
            this.TEAM_NAME2Column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.TEAM_NAME2Column.OptionsColumn.FixedWidth = true;
            this.TEAM_NAME2Column.OptionsFilter.AllowAutoFilter = false;
            this.TEAM_NAME2Column.OptionsFilter.AllowFilter = false;
            this.TEAM_NAME2Column.Visible = true;
            this.TEAM_NAME2Column.VisibleIndex = 2;
            this.TEAM_NAME2Column.Width = 90;
            // 
            // TEAM_NAME2TextEdit
            // 
            this.TEAM_NAME2TextEdit.AutoHeight = false;
            this.TEAM_NAME2TextEdit.Name = "TEAM_NAME2TextEdit";
            // 
            // btnLookUpData
            // 
            this.btnLookUpData.Location = new System.Drawing.Point(15, 178);
            this.btnLookUpData.Name = "btnLookUpData";
            this.btnLookUpData.Size = new System.Drawing.Size(64, 25);
            this.btnLookUpData.TabIndex = 238;
            this.btnLookUpData.Text = "조회";
            this.btnLookUpData.UseVisualStyleBackColor = true;
            this.btnLookUpData.Click += new System.EventHandler(this.btnLookUpData_Click);
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PQMS_TEAMGrid);
            this.Controls.Add(this.btnLookUpData);
            this.Controls.Add(this.btnTeamDelete);
            this.Controls.Add(this.btnTeamUpdate);
            this.Controls.Add(this.btnTeamInsert);
            this.Controls.Add(this.txtTEAM_NAME2);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtTEAM_NAME);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.txtTEAM_CODE);
            this.Controls.Add(this.Label6);
            this.Name = "Form11";
            this.Text = "조직관리";
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_TEAMGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_TEAMGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEAM_CODETextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEAM_NAMETextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEAM_NAME2TextEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtTEAM_NAME2;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtTEAM_NAME;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtTEAM_CODE;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Button btnTeamDelete;
        private System.Windows.Forms.Button btnTeamUpdate;
        private System.Windows.Forms.Button btnTeamInsert;
        private DevExpress.XtraGrid.GridControl PQMS_TEAMGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_TEAMGridView;
        private DevExpress.XtraGrid.Columns.GridColumn TEAM_CODEColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit TEAM_CODETextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn TEAM_NAMEColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit TEAM_NAMETextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn TEAM_NAME2Column;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit TEAM_NAME2TextEdit;
        private System.Windows.Forms.Button btnLookUpData;
    }
}