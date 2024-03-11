
namespace PQMS
{
    partial class Form8
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
            this.Label6 = new System.Windows.Forms.Label();
            this.txtVALI_ENABLE = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtEDU_ORG_CODE = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtVALI_PERIOD = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtVALI_DATE = new System.Windows.Forms.TextBox();
            this.btnEduValidateInsert = new System.Windows.Forms.Button();
            this.btnEduValidateUpdate = new System.Windows.Forms.Button();
            this.btnEduValidateDelete = new System.Windows.Forms.Button();
            this.btnLookUpData = new System.Windows.Forms.Button();
            this.EDU_ORG_CODETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.VALI_PERIODTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.VALI_DATETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.VALI_ENABLETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.PQMS_EDU_VALI_DATEGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EDU_ORG_CODEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VALI_PERIODColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VALI_DATEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VALI_ENABLEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQMS_EDU_VALI_DATEGrid = new DevExpress.XtraGrid.GridControl();
            this.cmbFolder = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.txtOrgName = new System.Windows.Forms.TextBox();
            this.cmbValiTerm = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbDateFormat = new System.Windows.Forms.ComboBox();
            this.cmbYN = new System.Windows.Forms.ComboBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtEDU_CODE = new System.Windows.Forms.TextBox();
            this.txtEDU_NAME = new System.Windows.Forms.TextBox();
            this.cmbGroup1 = new System.Windows.Forms.ComboBox();
            this.btnGroup1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EDU_ORG_CODETextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VALI_PERIODTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VALI_DATETextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VALI_ENABLETextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDU_VALI_DATEGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDU_VALI_DATEGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(23, 192);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(57, 13);
            this.Label6.TabIndex = 78;
            this.Label6.Text = "관리여부 :";
            // 
            // txtVALI_ENABLE
            // 
            this.txtVALI_ENABLE.Location = new System.Drawing.Point(136, 192);
            this.txtVALI_ENABLE.Name = "txtVALI_ENABLE";
            this.txtVALI_ENABLE.Size = new System.Drawing.Size(63, 20);
            this.txtVALI_ENABLE.TabIndex = 79;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(23, 97);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(57, 13);
            this.Label7.TabIndex = 80;
            this.Label7.Text = "기관코드 :";
            // 
            // txtEDU_ORG_CODE
            // 
            this.txtEDU_ORG_CODE.Location = new System.Drawing.Point(136, 97);
            this.txtEDU_ORG_CODE.Name = "txtEDU_ORG_CODE";
            this.txtEDU_ORG_CODE.Size = new System.Drawing.Size(63, 20);
            this.txtEDU_ORG_CODE.TabIndex = 81;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(23, 130);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(57, 13);
            this.Label8.TabIndex = 82;
            this.Label8.Text = "유효기간 :";
            // 
            // txtVALI_PERIOD
            // 
            this.txtVALI_PERIOD.Location = new System.Drawing.Point(136, 127);
            this.txtVALI_PERIOD.Name = "txtVALI_PERIOD";
            this.txtVALI_PERIOD.Size = new System.Drawing.Size(63, 20);
            this.txtVALI_PERIOD.TabIndex = 83;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(23, 162);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(57, 13);
            this.Label9.TabIndex = 84;
            this.Label9.Text = "유효일자 :";
            // 
            // txtVALI_DATE
            // 
            this.txtVALI_DATE.Location = new System.Drawing.Point(136, 159);
            this.txtVALI_DATE.Name = "txtVALI_DATE";
            this.txtVALI_DATE.Size = new System.Drawing.Size(63, 20);
            this.txtVALI_DATE.TabIndex = 85;
            // 
            // btnEduValidateInsert
            // 
            this.btnEduValidateInsert.Location = new System.Drawing.Point(26, 63);
            this.btnEduValidateInsert.Name = "btnEduValidateInsert";
            this.btnEduValidateInsert.Size = new System.Drawing.Size(75, 23);
            this.btnEduValidateInsert.TabIndex = 116;
            this.btnEduValidateInsert.Text = "입력";
            this.btnEduValidateInsert.UseVisualStyleBackColor = true;
            this.btnEduValidateInsert.Click += new System.EventHandler(this.btnEduValidateInsert_Click);
            // 
            // btnEduValidateUpdate
            // 
            this.btnEduValidateUpdate.Location = new System.Drawing.Point(124, 63);
            this.btnEduValidateUpdate.Name = "btnEduValidateUpdate";
            this.btnEduValidateUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnEduValidateUpdate.TabIndex = 115;
            this.btnEduValidateUpdate.Text = "수정";
            this.btnEduValidateUpdate.UseVisualStyleBackColor = true;
            this.btnEduValidateUpdate.Click += new System.EventHandler(this.btnEduValidateUpdate_Click);
            // 
            // btnEduValidateDelete
            // 
            this.btnEduValidateDelete.Location = new System.Drawing.Point(226, 63);
            this.btnEduValidateDelete.Name = "btnEduValidateDelete";
            this.btnEduValidateDelete.Size = new System.Drawing.Size(75, 23);
            this.btnEduValidateDelete.TabIndex = 114;
            this.btnEduValidateDelete.Text = "삭제";
            this.btnEduValidateDelete.UseVisualStyleBackColor = true;
            this.btnEduValidateDelete.Click += new System.EventHandler(this.btnEduValidateDelete_Click);
            // 
            // btnLookUpData
            // 
            this.btnLookUpData.Location = new System.Drawing.Point(28, 239);
            this.btnLookUpData.Name = "btnLookUpData";
            this.btnLookUpData.Size = new System.Drawing.Size(64, 25);
            this.btnLookUpData.TabIndex = 240;
            this.btnLookUpData.Text = "조회";
            this.btnLookUpData.UseVisualStyleBackColor = true;
            this.btnLookUpData.Click += new System.EventHandler(this.btnLookUpData_Click);
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
            // VALI_PERIODTextEdit
            // 
            this.VALI_PERIODTextEdit.AutoHeight = false;
            this.VALI_PERIODTextEdit.Name = "VALI_PERIODTextEdit";
            // 
            // VALI_DATETextEdit
            // 
            this.VALI_DATETextEdit.AutoHeight = false;
            this.VALI_DATETextEdit.Name = "VALI_DATETextEdit";
            // 
            // VALI_ENABLETextEdit
            // 
            this.VALI_ENABLETextEdit.AutoHeight = false;
            this.VALI_ENABLETextEdit.Name = "VALI_ENABLETextEdit";
            // 
            // PQMS_EDU_VALI_DATEGridView
            // 
            this.PQMS_EDU_VALI_DATEGridView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDU_VALI_DATEGridView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_EDU_VALI_DATEGridView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_EDU_VALI_DATEGridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDU_VALI_DATEGridView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_EDU_VALI_DATEGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDU_VALI_DATEGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_EDU_VALI_DATEGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDU_VALI_DATEGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_EDU_VALI_DATEGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDU_VALI_DATEGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_EDU_VALI_DATEGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDU_VALI_DATEGridView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_EDU_VALI_DATEGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDU_VALI_DATEGridView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_EDU_VALI_DATEGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDU_VALI_DATEGridView.Appearance.Row.Options.UseFont = true;
            this.PQMS_EDU_VALI_DATEGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDU_VALI_DATEGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_EDU_VALI_DATEGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDU_VALI_DATEGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_EDU_VALI_DATEGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.EDU_ORG_CODEColumn,
            this.VALI_PERIODColumn,
            this.VALI_DATEColumn,
            this.VALI_ENABLEColumn});
            this.PQMS_EDU_VALI_DATEGridView.CustomizationFormBounds = new System.Drawing.Rectangle(1920, 580, 210, 186);
            this.PQMS_EDU_VALI_DATEGridView.GridControl = this.PQMS_EDU_VALI_DATEGrid;
            this.PQMS_EDU_VALI_DATEGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.PQMS_EDU_VALI_DATEGridView.Name = "PQMS_EDU_VALI_DATEGridView";
            this.PQMS_EDU_VALI_DATEGridView.OptionsBehavior.Editable = false;
            this.PQMS_EDU_VALI_DATEGridView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_EDU_VALI_DATEGridView.OptionsHint.ShowFooterHints = false;
            this.PQMS_EDU_VALI_DATEGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_EDU_VALI_DATEGridView.OptionsSelection.InvertSelection = true;
            this.PQMS_EDU_VALI_DATEGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.PQMS_EDU_VALI_DATEGridView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_EDU_VALI_DATEGridView.OptionsView.RowAutoHeight = true;
            this.PQMS_EDU_VALI_DATEGridView.OptionsView.ShowGroupPanel = false;
            this.PQMS_EDU_VALI_DATEGridView.OptionsView.ShowIndicator = false;
            this.PQMS_EDU_VALI_DATEGridView.Tag = 1;
            this.PQMS_EDU_VALI_DATEGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.PQMS_EDU_VALI_DATEGridView_RowCellClick);
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
            this.EDU_ORG_CODEColumn.Caption = "기관코드";
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
            this.EDU_ORG_CODEColumn.Width = 92;
            // 
            // VALI_PERIODColumn
            // 
            this.VALI_PERIODColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VALI_PERIODColumn.AppearanceCell.Options.UseFont = true;
            this.VALI_PERIODColumn.AppearanceCell.Options.UseTextOptions = true;
            this.VALI_PERIODColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VALI_PERIODColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VALI_PERIODColumn.AppearanceHeader.Options.UseFont = true;
            this.VALI_PERIODColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.VALI_PERIODColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VALI_PERIODColumn.Caption = "유효기간";
            this.VALI_PERIODColumn.ColumnEdit = this.VALI_PERIODTextEdit;
            this.VALI_PERIODColumn.FieldName = "VALI_PERIOD";
            this.VALI_PERIODColumn.Name = "VALI_PERIODColumn";
            this.VALI_PERIODColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.VALI_PERIODColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.VALI_PERIODColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.VALI_PERIODColumn.OptionsColumn.AllowMove = false;
            this.VALI_PERIODColumn.OptionsColumn.AllowShowHide = false;
            this.VALI_PERIODColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.VALI_PERIODColumn.OptionsColumn.FixedWidth = true;
            this.VALI_PERIODColumn.OptionsFilter.AllowAutoFilter = false;
            this.VALI_PERIODColumn.OptionsFilter.AllowFilter = false;
            this.VALI_PERIODColumn.Visible = true;
            this.VALI_PERIODColumn.VisibleIndex = 1;
            this.VALI_PERIODColumn.Width = 102;
            // 
            // VALI_DATEColumn
            // 
            this.VALI_DATEColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VALI_DATEColumn.AppearanceCell.Options.UseFont = true;
            this.VALI_DATEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.VALI_DATEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VALI_DATEColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VALI_DATEColumn.AppearanceHeader.Options.UseFont = true;
            this.VALI_DATEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.VALI_DATEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VALI_DATEColumn.Caption = "유효일자";
            this.VALI_DATEColumn.ColumnEdit = this.VALI_DATETextEdit;
            this.VALI_DATEColumn.FieldName = "VALI_DATE";
            this.VALI_DATEColumn.MaxWidth = 90;
            this.VALI_DATEColumn.Name = "VALI_DATEColumn";
            this.VALI_DATEColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.VALI_DATEColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.VALI_DATEColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.VALI_DATEColumn.OptionsColumn.AllowMove = false;
            this.VALI_DATEColumn.OptionsColumn.AllowShowHide = false;
            this.VALI_DATEColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.VALI_DATEColumn.OptionsColumn.FixedWidth = true;
            this.VALI_DATEColumn.OptionsFilter.AllowAutoFilter = false;
            this.VALI_DATEColumn.OptionsFilter.AllowFilter = false;
            this.VALI_DATEColumn.Visible = true;
            this.VALI_DATEColumn.VisibleIndex = 2;
            this.VALI_DATEColumn.Width = 90;
            // 
            // VALI_ENABLEColumn
            // 
            this.VALI_ENABLEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.VALI_ENABLEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VALI_ENABLEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.VALI_ENABLEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VALI_ENABLEColumn.Caption = "관리여부";
            this.VALI_ENABLEColumn.ColumnEdit = this.VALI_ENABLETextEdit;
            this.VALI_ENABLEColumn.FieldName = "VALI_ENABLE";
            this.VALI_ENABLEColumn.Name = "VALI_ENABLEColumn";
            this.VALI_ENABLEColumn.Visible = true;
            this.VALI_ENABLEColumn.VisibleIndex = 3;
            // 
            // PQMS_EDU_VALI_DATEGrid
            // 
            this.PQMS_EDU_VALI_DATEGrid.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_EDU_VALI_DATEGrid.Location = new System.Drawing.Point(28, 270);
            this.PQMS_EDU_VALI_DATEGrid.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_EDU_VALI_DATEGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_EDU_VALI_DATEGrid.MainView = this.PQMS_EDU_VALI_DATEGridView;
            this.PQMS_EDU_VALI_DATEGrid.Name = "PQMS_EDU_VALI_DATEGrid";
            this.PQMS_EDU_VALI_DATEGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.EDU_ORG_CODETextEdit,
            this.VALI_PERIODTextEdit,
            this.VALI_DATETextEdit,
            this.VALI_ENABLETextEdit});
            this.PQMS_EDU_VALI_DATEGrid.Size = new System.Drawing.Size(771, 193);
            this.PQMS_EDU_VALI_DATEGrid.TabIndex = 241;
            this.PQMS_EDU_VALI_DATEGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_EDU_VALI_DATEGridView});
            // 
            // cmbFolder
            // 
            this.cmbFolder.FormattingEnabled = true;
            this.cmbFolder.Location = new System.Drawing.Point(307, 97);
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(104, 21);
            this.cmbFolder.TabIndex = 249;
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(417, 97);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(55, 22);
            this.button10.TabIndex = 250;
            this.button10.Text = "찾기";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // txtOrgName
            // 
            this.txtOrgName.Location = new System.Drawing.Point(205, 97);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Size = new System.Drawing.Size(96, 20);
            this.txtOrgName.TabIndex = 251;
            // 
            // cmbValiTerm
            // 
            this.cmbValiTerm.FormattingEnabled = true;
            this.cmbValiTerm.Items.AddRange(new object[] {
            "1년",
            "6개월",
            "3개월",
            "2개월"});
            this.cmbValiTerm.Location = new System.Drawing.Point(205, 126);
            this.cmbValiTerm.Name = "cmbValiTerm";
            this.cmbValiTerm.Size = new System.Drawing.Size(96, 21);
            this.cmbValiTerm.TabIndex = 256;
            this.cmbValiTerm.SelectedIndexChanged += new System.EventHandler(this.cmbValiTerm_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy년 mm월 dd일";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(205, 159);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(206, 20);
            this.dateTimePicker1.TabIndex = 258;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cmbDateFormat
            // 
            this.cmbDateFormat.FormattingEnabled = true;
            this.cmbDateFormat.Items.AddRange(new object[] {
            "yyyy-mm-dd",
            "yyyy년 mm월 dd일"});
            this.cmbDateFormat.Location = new System.Drawing.Point(417, 159);
            this.cmbDateFormat.Name = "cmbDateFormat";
            this.cmbDateFormat.Size = new System.Drawing.Size(104, 21);
            this.cmbDateFormat.TabIndex = 259;
            // 
            // cmbYN
            // 
            this.cmbYN.FormattingEnabled = true;
            this.cmbYN.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cmbYN.Location = new System.Drawing.Point(205, 192);
            this.cmbYN.Name = "cmbYN";
            this.cmbYN.Size = new System.Drawing.Size(206, 21);
            this.cmbYN.TabIndex = 260;
            this.cmbYN.SelectedIndexChanged += new System.EventHandler(this.cmbYN_SelectedIndexChanged);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(202, 239);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(93, 13);
            this.Label15.TabIndex = 261;
            this.Label15.Text = "교육명 관리번호 :";
            this.Label15.Visible = false;
            // 
            // txtEDU_CODE
            // 
            this.txtEDU_CODE.Location = new System.Drawing.Point(313, 236);
            this.txtEDU_CODE.Name = "txtEDU_CODE";
            this.txtEDU_CODE.Size = new System.Drawing.Size(63, 20);
            this.txtEDU_CODE.TabIndex = 262;
            this.txtEDU_CODE.Visible = false;
            // 
            // txtEDU_NAME
            // 
            this.txtEDU_NAME.Location = new System.Drawing.Point(382, 236);
            this.txtEDU_NAME.Name = "txtEDU_NAME";
            this.txtEDU_NAME.Size = new System.Drawing.Size(165, 20);
            this.txtEDU_NAME.TabIndex = 263;
            this.txtEDU_NAME.Visible = false;
            // 
            // cmbGroup1
            // 
            this.cmbGroup1.FormattingEnabled = true;
            this.cmbGroup1.Location = new System.Drawing.Point(553, 236);
            this.cmbGroup1.Name = "cmbGroup1";
            this.cmbGroup1.Size = new System.Drawing.Size(208, 21);
            this.cmbGroup1.TabIndex = 264;
            this.cmbGroup1.Visible = false;
            this.cmbGroup1.SelectedIndexChanged += new System.EventHandler(this.cmbGroup1_SelectedIndexChanged);
            // 
            // btnGroup1
            // 
            this.btnGroup1.Location = new System.Drawing.Point(767, 236);
            this.btnGroup1.Name = "btnGroup1";
            this.btnGroup1.Size = new System.Drawing.Size(23, 22);
            this.btnGroup1.TabIndex = 265;
            this.btnGroup1.Text = "S";
            this.btnGroup1.UseVisualStyleBackColor = true;
            this.btnGroup1.Visible = false;
            this.btnGroup1.Click += new System.EventHandler(this.btnGroup1_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 483);
            this.Controls.Add(this.btnGroup1);
            this.Controls.Add(this.cmbGroup1);
            this.Controls.Add(this.txtEDU_NAME);
            this.Controls.Add(this.txtEDU_CODE);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.cmbYN);
            this.Controls.Add(this.cmbDateFormat);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cmbValiTerm);
            this.Controls.Add(this.txtOrgName);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.cmbFolder);
            this.Controls.Add(this.PQMS_EDU_VALI_DATEGrid);
            this.Controls.Add(this.btnLookUpData);
            this.Controls.Add(this.btnEduValidateDelete);
            this.Controls.Add(this.btnEduValidateUpdate);
            this.Controls.Add(this.btnEduValidateInsert);
            this.Controls.Add(this.txtVALI_DATE);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtVALI_PERIOD);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtEDU_ORG_CODE);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.txtVALI_ENABLE);
            this.Controls.Add(this.Label6);
            this.Name = "Form8";
            this.Text = "보수교육 유효기간 관리기준";
            ((System.ComponentModel.ISupportInitialize)(this.EDU_ORG_CODETextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VALI_PERIODTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VALI_DATETextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VALI_ENABLETextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDU_VALI_DATEGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDU_VALI_DATEGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtVALI_ENABLE;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtEDU_ORG_CODE;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtVALI_PERIOD;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtVALI_DATE;
        private System.Windows.Forms.Button btnEduValidateInsert;
        private System.Windows.Forms.Button btnEduValidateUpdate;
        private System.Windows.Forms.Button btnEduValidateDelete;
        private System.Windows.Forms.Button btnLookUpData;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit EDU_ORG_CODETextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit VALI_PERIODTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit VALI_DATETextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit VALI_ENABLETextEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_EDU_VALI_DATEGridView;
        private DevExpress.XtraGrid.Columns.GridColumn EDU_ORG_CODEColumn;
        private DevExpress.XtraGrid.Columns.GridColumn VALI_PERIODColumn;
        private DevExpress.XtraGrid.Columns.GridColumn VALI_DATEColumn;
        private DevExpress.XtraGrid.Columns.GridColumn VALI_ENABLEColumn;
        private DevExpress.XtraGrid.GridControl PQMS_EDU_VALI_DATEGrid;
        private System.Windows.Forms.ComboBox cmbFolder;
        private System.Windows.Forms.Button button10;
        internal System.Windows.Forms.TextBox txtOrgName;
        private System.Windows.Forms.ComboBox cmbValiTerm;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmbDateFormat;
        private System.Windows.Forms.ComboBox cmbYN;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.TextBox txtEDU_CODE;
        internal System.Windows.Forms.TextBox txtEDU_NAME;
        private System.Windows.Forms.ComboBox cmbGroup1;
        private System.Windows.Forms.Button btnGroup1;
    }
}