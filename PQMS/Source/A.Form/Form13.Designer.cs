
namespace PQMS
{
    partial class Form13
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
            this.txtROLE_CODE = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtROLE_ORG_CODE = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtROLE_NAME = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEduValidateDelete = new System.Windows.Forms.Button();
            this.btnEduValidateUpdate = new System.Windows.Forms.Button();
            this.btnRoleInsert = new System.Windows.Forms.Button();
            this.PQMS_ROLEGrid = new DevExpress.XtraGrid.GridControl();
            this.PQMS_ROLEGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ROLE_ORG_CODEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ROLE_ORG_CODETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ROLE_CODEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ROLE_CODETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ROLE_NAMEColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ROLE_NAMETextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnLookUpData = new System.Windows.Forms.Button();
            this.txtOrgName = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.cmbFolder = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_ROLEGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_ROLEGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROLE_ORG_CODETextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROLE_CODETextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROLE_NAMETextEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtROLE_CODE
            // 
            this.txtROLE_CODE.Location = new System.Drawing.Point(119, 124);
            this.txtROLE_CODE.Name = "txtROLE_CODE";
            this.txtROLE_CODE.Size = new System.Drawing.Size(165, 20);
            this.txtROLE_CODE.TabIndex = 55;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 131);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(79, 13);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "직무관리번호 :";
            // 
            // txtROLE_ORG_CODE
            // 
            this.txtROLE_ORG_CODE.Location = new System.Drawing.Point(119, 98);
            this.txtROLE_ORG_CODE.Name = "txtROLE_ORG_CODE";
            this.txtROLE_ORG_CODE.Size = new System.Drawing.Size(69, 20);
            this.txtROLE_ORG_CODE.TabIndex = 53;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(12, 101);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(101, 13);
            this.Label15.TabIndex = 52;
            this.Label15.Text = "직무주관기관번호 :";
            // 
            // txtROLE_NAME
            // 
            this.txtROLE_NAME.Location = new System.Drawing.Point(119, 150);
            this.txtROLE_NAME.Name = "txtROLE_NAME";
            this.txtROLE_NAME.Size = new System.Drawing.Size(165, 20);
            this.txtROLE_NAME.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "직무명 :";
            // 
            // btnEduValidateDelete
            // 
            this.btnEduValidateDelete.Location = new System.Drawing.Point(215, 64);
            this.btnEduValidateDelete.Name = "btnEduValidateDelete";
            this.btnEduValidateDelete.Size = new System.Drawing.Size(75, 23);
            this.btnEduValidateDelete.TabIndex = 117;
            this.btnEduValidateDelete.Text = "삭제";
            this.btnEduValidateDelete.UseVisualStyleBackColor = true;
            this.btnEduValidateDelete.Click += new System.EventHandler(this.btnEduValidateDelete_Click);
            // 
            // btnEduValidateUpdate
            // 
            this.btnEduValidateUpdate.Location = new System.Drawing.Point(113, 64);
            this.btnEduValidateUpdate.Name = "btnEduValidateUpdate";
            this.btnEduValidateUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnEduValidateUpdate.TabIndex = 118;
            this.btnEduValidateUpdate.Text = "수정";
            this.btnEduValidateUpdate.UseVisualStyleBackColor = true;
            this.btnEduValidateUpdate.Click += new System.EventHandler(this.btnEduValidateUpdate_Click);
            // 
            // btnRoleInsert
            // 
            this.btnRoleInsert.Location = new System.Drawing.Point(15, 64);
            this.btnRoleInsert.Name = "btnRoleInsert";
            this.btnRoleInsert.Size = new System.Drawing.Size(75, 23);
            this.btnRoleInsert.TabIndex = 119;
            this.btnRoleInsert.Text = "입력";
            this.btnRoleInsert.UseVisualStyleBackColor = true;
            this.btnRoleInsert.Click += new System.EventHandler(this.btnRoleInsert_Click);
            // 
            // PQMS_ROLEGrid
            // 
            this.PQMS_ROLEGrid.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_ROLEGrid.Location = new System.Drawing.Point(15, 241);
            this.PQMS_ROLEGrid.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_ROLEGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_ROLEGrid.MainView = this.PQMS_ROLEGridView;
            this.PQMS_ROLEGrid.Name = "PQMS_ROLEGrid";
            this.PQMS_ROLEGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ROLE_ORG_CODETextEdit,
            this.ROLE_CODETextEdit,
            this.ROLE_NAMETextEdit});
            this.PQMS_ROLEGrid.Size = new System.Drawing.Size(771, 193);
            this.PQMS_ROLEGrid.TabIndex = 239;
            this.PQMS_ROLEGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_ROLEGridView});
            // 
            // PQMS_ROLEGridView
            // 
            this.PQMS_ROLEGridView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ROLEGridView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_ROLEGridView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_ROLEGridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ROLEGridView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_ROLEGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ROLEGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_ROLEGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ROLEGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_ROLEGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ROLEGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_ROLEGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ROLEGridView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_ROLEGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ROLEGridView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_ROLEGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ROLEGridView.Appearance.Row.Options.UseFont = true;
            this.PQMS_ROLEGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ROLEGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_ROLEGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_ROLEGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_ROLEGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ROLE_ORG_CODEColumn,
            this.ROLE_CODEColumn,
            this.ROLE_NAMEColumn});
            this.PQMS_ROLEGridView.CustomizationFormBounds = new System.Drawing.Rectangle(1920, 580, 210, 186);
            this.PQMS_ROLEGridView.GridControl = this.PQMS_ROLEGrid;
            this.PQMS_ROLEGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.PQMS_ROLEGridView.Name = "PQMS_ROLEGridView";
            this.PQMS_ROLEGridView.OptionsBehavior.Editable = false;
            this.PQMS_ROLEGridView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_ROLEGridView.OptionsHint.ShowFooterHints = false;
            this.PQMS_ROLEGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_ROLEGridView.OptionsSelection.InvertSelection = true;
            this.PQMS_ROLEGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.PQMS_ROLEGridView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_ROLEGridView.OptionsView.RowAutoHeight = true;
            this.PQMS_ROLEGridView.OptionsView.ShowGroupPanel = false;
            this.PQMS_ROLEGridView.OptionsView.ShowIndicator = false;
            this.PQMS_ROLEGridView.Tag = 1;
            this.PQMS_ROLEGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.PQMS_ROLEGridView_RowCellClick);
            // 
            // ROLE_ORG_CODEColumn
            // 
            this.ROLE_ORG_CODEColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROLE_ORG_CODEColumn.AppearanceCell.Options.UseFont = true;
            this.ROLE_ORG_CODEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.ROLE_ORG_CODEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ROLE_ORG_CODEColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROLE_ORG_CODEColumn.AppearanceHeader.Options.UseFont = true;
            this.ROLE_ORG_CODEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.ROLE_ORG_CODEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ROLE_ORG_CODEColumn.Caption = "직무주관기관번호";
            this.ROLE_ORG_CODEColumn.ColumnEdit = this.ROLE_ORG_CODETextEdit;
            this.ROLE_ORG_CODEColumn.FieldName = "ROLE_ORG_CODE";
            this.ROLE_ORG_CODEColumn.Name = "ROLE_ORG_CODEColumn";
            this.ROLE_ORG_CODEColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ROLE_ORG_CODEColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.ROLE_ORG_CODEColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ROLE_ORG_CODEColumn.OptionsColumn.AllowMove = false;
            this.ROLE_ORG_CODEColumn.OptionsColumn.AllowShowHide = false;
            this.ROLE_ORG_CODEColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ROLE_ORG_CODEColumn.OptionsColumn.FixedWidth = true;
            this.ROLE_ORG_CODEColumn.OptionsFilter.AllowAutoFilter = false;
            this.ROLE_ORG_CODEColumn.OptionsFilter.AllowFilter = false;
            this.ROLE_ORG_CODEColumn.Visible = true;
            this.ROLE_ORG_CODEColumn.VisibleIndex = 0;
            this.ROLE_ORG_CODEColumn.Width = 122;
            // 
            // ROLE_ORG_CODETextEdit
            // 
            this.ROLE_ORG_CODETextEdit.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROLE_ORG_CODETextEdit.Appearance.Options.UseFont = true;
            this.ROLE_ORG_CODETextEdit.Appearance.Options.UseTextOptions = true;
            this.ROLE_ORG_CODETextEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ROLE_ORG_CODETextEdit.AppearanceFocused.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROLE_ORG_CODETextEdit.AppearanceFocused.Options.UseFont = true;
            this.ROLE_ORG_CODETextEdit.AppearanceFocused.Options.UseTextOptions = true;
            this.ROLE_ORG_CODETextEdit.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ROLE_ORG_CODETextEdit.AutoHeight = false;
            this.ROLE_ORG_CODETextEdit.MaxLength = 20;
            this.ROLE_ORG_CODETextEdit.Name = "ROLE_ORG_CODETextEdit";
            // 
            // ROLE_CODEColumn
            // 
            this.ROLE_CODEColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROLE_CODEColumn.AppearanceCell.Options.UseFont = true;
            this.ROLE_CODEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.ROLE_CODEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ROLE_CODEColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROLE_CODEColumn.AppearanceHeader.Options.UseFont = true;
            this.ROLE_CODEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.ROLE_CODEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ROLE_CODEColumn.Caption = "직무관리번호";
            this.ROLE_CODEColumn.ColumnEdit = this.ROLE_CODETextEdit;
            this.ROLE_CODEColumn.FieldName = "ROLE_CODE";
            this.ROLE_CODEColumn.Name = "ROLE_CODEColumn";
            this.ROLE_CODEColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ROLE_CODEColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.ROLE_CODEColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ROLE_CODEColumn.OptionsColumn.AllowMove = false;
            this.ROLE_CODEColumn.OptionsColumn.AllowShowHide = false;
            this.ROLE_CODEColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ROLE_CODEColumn.OptionsColumn.FixedWidth = true;
            this.ROLE_CODEColumn.OptionsFilter.AllowAutoFilter = false;
            this.ROLE_CODEColumn.OptionsFilter.AllowFilter = false;
            this.ROLE_CODEColumn.Visible = true;
            this.ROLE_CODEColumn.VisibleIndex = 1;
            this.ROLE_CODEColumn.Width = 102;
            // 
            // ROLE_CODETextEdit
            // 
            this.ROLE_CODETextEdit.AutoHeight = false;
            this.ROLE_CODETextEdit.Name = "ROLE_CODETextEdit";
            // 
            // ROLE_NAMEColumn
            // 
            this.ROLE_NAMEColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROLE_NAMEColumn.AppearanceCell.Options.UseFont = true;
            this.ROLE_NAMEColumn.AppearanceCell.Options.UseTextOptions = true;
            this.ROLE_NAMEColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ROLE_NAMEColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROLE_NAMEColumn.AppearanceHeader.Options.UseFont = true;
            this.ROLE_NAMEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.ROLE_NAMEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ROLE_NAMEColumn.Caption = "직무명";
            this.ROLE_NAMEColumn.ColumnEdit = this.ROLE_NAMETextEdit;
            this.ROLE_NAMEColumn.FieldName = "ROLE_NAME";
            this.ROLE_NAMEColumn.MaxWidth = 90;
            this.ROLE_NAMEColumn.Name = "ROLE_NAMEColumn";
            this.ROLE_NAMEColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ROLE_NAMEColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.ROLE_NAMEColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ROLE_NAMEColumn.OptionsColumn.AllowMove = false;
            this.ROLE_NAMEColumn.OptionsColumn.AllowShowHide = false;
            this.ROLE_NAMEColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ROLE_NAMEColumn.OptionsColumn.FixedWidth = true;
            this.ROLE_NAMEColumn.OptionsFilter.AllowAutoFilter = false;
            this.ROLE_NAMEColumn.OptionsFilter.AllowFilter = false;
            this.ROLE_NAMEColumn.Visible = true;
            this.ROLE_NAMEColumn.VisibleIndex = 2;
            this.ROLE_NAMEColumn.Width = 90;
            // 
            // ROLE_NAMETextEdit
            // 
            this.ROLE_NAMETextEdit.AutoHeight = false;
            this.ROLE_NAMETextEdit.Name = "ROLE_NAMETextEdit";
            // 
            // btnLookUpData
            // 
            this.btnLookUpData.Location = new System.Drawing.Point(15, 210);
            this.btnLookUpData.Name = "btnLookUpData";
            this.btnLookUpData.Size = new System.Drawing.Size(64, 25);
            this.btnLookUpData.TabIndex = 238;
            this.btnLookUpData.Text = "조회";
            this.btnLookUpData.UseVisualStyleBackColor = true;
            this.btnLookUpData.Click += new System.EventHandler(this.btnLookUpData_Click);
            // 
            // txtOrgName
            // 
            this.txtOrgName.Location = new System.Drawing.Point(194, 98);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Size = new System.Drawing.Size(90, 20);
            this.txtOrgName.TabIndex = 245;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(399, 96);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(55, 22);
            this.button10.TabIndex = 244;
            this.button10.Text = "찾기";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // cmbFolder
            // 
            this.cmbFolder.FormattingEnabled = true;
            this.cmbFolder.Location = new System.Drawing.Point(290, 97);
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(104, 21);
            this.cmbFolder.TabIndex = 243;
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtOrgName);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.cmbFolder);
            this.Controls.Add(this.PQMS_ROLEGrid);
            this.Controls.Add(this.btnLookUpData);
            this.Controls.Add(this.btnEduValidateDelete);
            this.Controls.Add(this.btnEduValidateUpdate);
            this.Controls.Add(this.btnRoleInsert);
            this.Controls.Add(this.txtROLE_NAME);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtROLE_CODE);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtROLE_ORG_CODE);
            this.Controls.Add(this.Label15);
            this.Name = "Form13";
            this.Text = "직무코드관리";
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_ROLEGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_ROLEGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROLE_ORG_CODETextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROLE_CODETextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROLE_NAMETextEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtROLE_CODE;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtROLE_ORG_CODE;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.TextBox txtROLE_NAME;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEduValidateDelete;
        private System.Windows.Forms.Button btnEduValidateUpdate;
        private System.Windows.Forms.Button btnRoleInsert;
        private DevExpress.XtraGrid.GridControl PQMS_ROLEGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_ROLEGridView;
        private DevExpress.XtraGrid.Columns.GridColumn ROLE_ORG_CODEColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ROLE_ORG_CODETextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn ROLE_CODEColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ROLE_CODETextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn ROLE_NAMEColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ROLE_NAMETextEdit;
        private System.Windows.Forms.Button btnLookUpData;
        internal System.Windows.Forms.TextBox txtOrgName;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox cmbFolder;
    }
}