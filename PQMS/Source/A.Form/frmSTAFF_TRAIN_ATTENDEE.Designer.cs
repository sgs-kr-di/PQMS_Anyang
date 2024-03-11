
namespace PQMS
{
    partial class frmSTAFF_TRAIN_ATTENDEE
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInsertTrain_ATTENDEE_Metro = new MetroFramework.Controls.MetroButton();
            this.btnInsertTrainContents = new DevExpress.XtraEditors.SimpleButton();
            this.PQMS_STAFF_TRAIN_STAFFLISTGrid = new DevExpress.XtraGrid.GridControl();
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_Dept = new System.Windows.Forms.ComboBox();
            this.PQMS_STAFF_TRAIN_ATTENDEEGrid = new DevExpress.XtraGrid.GridControl();
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_IN = new System.Windows.Forms.Button();
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_OUT = new System.Windows.Forms.Button();
            this.txt_SearchName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_TRAIN_STAFFLISTGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_TRAIN_STAFFLISTGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_TRAIN_ATTENDEEGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_TRAIN_ATTENDEEGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInsertTrain_ATTENDEE_Metro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnInsertTrain_ATTENDEE_Metro
            // 
            this.btnInsertTrain_ATTENDEE_Metro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInsertTrain_ATTENDEE_Metro.Location = new System.Drawing.Point(0, 0);
            this.btnInsertTrain_ATTENDEE_Metro.Name = "btnInsertTrain_ATTENDEE_Metro";
            this.btnInsertTrain_ATTENDEE_Metro.Size = new System.Drawing.Size(770, 30);
            this.btnInsertTrain_ATTENDEE_Metro.TabIndex = 1;
            this.btnInsertTrain_ATTENDEE_Metro.Text = "저장";
            this.btnInsertTrain_ATTENDEE_Metro.UseSelectable = true;
            this.btnInsertTrain_ATTENDEE_Metro.Click += new System.EventHandler(this.btnInsertTrain_ATTENDEE_Metro_Click);
            // 
            // btnInsertTrainContents
            // 
            this.btnInsertTrainContents.Location = new System.Drawing.Point(569, 24);
            this.btnInsertTrainContents.Name = "btnInsertTrainContents";
            this.btnInsertTrainContents.Size = new System.Drawing.Size(218, 30);
            this.btnInsertTrainContents.TabIndex = 0;
            this.btnInsertTrainContents.Text = "저장";
            this.btnInsertTrainContents.Visible = false;
            // 
            // PQMS_STAFF_TRAIN_STAFFLISTGrid
            // 
            this.PQMS_STAFF_TRAIN_STAFFLISTGrid.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_STAFF_TRAIN_STAFFLISTGrid.Location = new System.Drawing.Point(23, 123);
            this.PQMS_STAFF_TRAIN_STAFFLISTGrid.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_STAFF_TRAIN_STAFFLISTGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_STAFF_TRAIN_STAFFLISTGrid.MainView = this.PQMS_STAFF_TRAIN_STAFFLISTGridView;
            this.PQMS_STAFF_TRAIN_STAFFLISTGrid.Name = "PQMS_STAFF_TRAIN_STAFFLISTGrid";
            this.PQMS_STAFF_TRAIN_STAFFLISTGrid.Size = new System.Drawing.Size(322, 323);
            this.PQMS_STAFF_TRAIN_STAFFLISTGrid.TabIndex = 356;
            this.PQMS_STAFF_TRAIN_STAFFLISTGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView});
            // 
            // PQMS_STAFF_TRAIN_STAFFLISTGridView
            // 
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.Row.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn9,
            this.gridColumn4});
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.CustomizationFormBounds = new System.Drawing.Rectangle(1070, 394, 210, 186);
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.GridControl = this.PQMS_STAFF_TRAIN_STAFFLISTGrid;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Name = "PQMS_STAFF_TRAIN_STAFFLISTGridView";
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsBehavior.Editable = false;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsCustomization.AllowFilter = false;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsHint.ShowFooterHints = false;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsSelection.InvertSelection = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsSelection.MultiSelect = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsView.RowAutoHeight = true;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsView.ShowGroupPanel = false;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsView.ShowIndicator = false;
            this.PQMS_STAFF_TRAIN_STAFFLISTGridView.Tag = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "이름";
            this.gridColumn1.FieldName = "STAFF_NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "사번";
            this.gridColumn3.FieldName = "STAFF_EMPNO";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "부서";
            this.gridColumn9.FieldName = "FOLDER_NAME";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            this.gridColumn9.Width = 120;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "관리코드";
            this.gridColumn4.FieldName = "STAFF_CODE";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // cmb_Dept
            // 
            this.cmb_Dept.FormattingEnabled = true;
            this.cmb_Dept.Items.AddRange(new object[] {
            "재직자",
            "퇴직자"});
            this.cmb_Dept.Location = new System.Drawing.Point(23, 96);
            this.cmb_Dept.Name = "cmb_Dept";
            this.cmb_Dept.Size = new System.Drawing.Size(157, 21);
            this.cmb_Dept.TabIndex = 357;
            this.cmb_Dept.SelectedIndexChanged += new System.EventHandler(this.cmb_Dept_SelectedIndexChanged);
            // 
            // PQMS_STAFF_TRAIN_ATTENDEEGrid
            // 
            this.PQMS_STAFF_TRAIN_ATTENDEEGrid.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_STAFF_TRAIN_ATTENDEEGrid.Location = new System.Drawing.Point(469, 123);
            this.PQMS_STAFF_TRAIN_ATTENDEEGrid.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_STAFF_TRAIN_ATTENDEEGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_STAFF_TRAIN_ATTENDEEGrid.MainView = this.PQMS_STAFF_TRAIN_ATTENDEEGridView;
            this.PQMS_STAFF_TRAIN_ATTENDEEGrid.Name = "PQMS_STAFF_TRAIN_ATTENDEEGrid";
            this.PQMS_STAFF_TRAIN_ATTENDEEGrid.Size = new System.Drawing.Size(321, 323);
            this.PQMS_STAFF_TRAIN_ATTENDEEGrid.TabIndex = 358;
            this.PQMS_STAFF_TRAIN_ATTENDEEGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView});
            // 
            // PQMS_STAFF_TRAIN_ATTENDEEGridView
            // 
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.Row.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn10});
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.CustomizationFormBounds = new System.Drawing.Rectangle(1070, 394, 210, 186);
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.GridControl = this.PQMS_STAFF_TRAIN_ATTENDEEGrid;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Name = "PQMS_STAFF_TRAIN_ATTENDEEGridView";
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsBehavior.Editable = false;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsCustomization.AllowFilter = false;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsHint.ShowFooterHints = false;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsSelection.InvertSelection = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsSelection.MultiSelect = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsView.RowAutoHeight = true;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsView.ShowGroupPanel = false;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.OptionsView.ShowIndicator = false;
            this.PQMS_STAFF_TRAIN_ATTENDEEGridView.Tag = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "이름";
            this.gridColumn5.FieldName = "STAFF_NAME";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "사번";
            this.gridColumn7.FieldName = "STAFF_EMPNO";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "부서";
            this.gridColumn8.FieldName = "FOLDER_NAME";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 120;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "관리코드";
            this.gridColumn10.FieldName = "STAFF_CODE";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // btnPQMS_STAFF_TRAIN_ATTENDEE_IN
            // 
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_IN.Location = new System.Drawing.Point(375, 223);
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_IN.Name = "btnPQMS_STAFF_TRAIN_ATTENDEE_IN";
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_IN.Size = new System.Drawing.Size(60, 23);
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_IN.TabIndex = 359;
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_IN.Text = ">>>";
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_IN.UseVisualStyleBackColor = true;
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_IN.Click += new System.EventHandler(this.btnPQMS_STAFF_TRAIN_ATTENDEE_IN_Click);
            // 
            // btnPQMS_STAFF_TRAIN_ATTENDEE_OUT
            // 
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_OUT.Location = new System.Drawing.Point(375, 252);
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_OUT.Name = "btnPQMS_STAFF_TRAIN_ATTENDEE_OUT";
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_OUT.Size = new System.Drawing.Size(60, 23);
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_OUT.TabIndex = 360;
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_OUT.Text = "<<<";
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_OUT.UseVisualStyleBackColor = true;
            this.btnPQMS_STAFF_TRAIN_ATTENDEE_OUT.Click += new System.EventHandler(this.btnPQMS_STAFF_TRAIN_ATTENDEE_OUT_Click);
            // 
            // txt_SearchName
            // 
            this.txt_SearchName.Location = new System.Drawing.Point(237, 97);
            this.txt_SearchName.Name = "txt_SearchName";
            this.txt_SearchName.Size = new System.Drawing.Size(108, 20);
            this.txt_SearchName.TabIndex = 361;
            this.txt_SearchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SearchName_KeyDown);
            // 
            // frmSTAFF_TRAIN_ATTENDEE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 469);
            this.Controls.Add(this.txt_SearchName);
            this.Controls.Add(this.btnPQMS_STAFF_TRAIN_ATTENDEE_OUT);
            this.Controls.Add(this.btnPQMS_STAFF_TRAIN_ATTENDEE_IN);
            this.Controls.Add(this.PQMS_STAFF_TRAIN_ATTENDEEGrid);
            this.Controls.Add(this.cmb_Dept);
            this.Controls.Add(this.PQMS_STAFF_TRAIN_STAFFLISTGrid);
            this.Controls.Add(this.btnInsertTrainContents);
            this.Controls.Add(this.panel1);
            this.Name = "frmSTAFF_TRAIN_ATTENDEE";
            this.Text = "참석자";
            this.Load += new System.EventHandler(this.frmSTAFF_TRAIN_ATTENDEE_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_TRAIN_STAFFLISTGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_TRAIN_STAFFLISTGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_TRAIN_ATTENDEEGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_TRAIN_ATTENDEEGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnInsertTrainContents;
        private MetroFramework.Controls.MetroButton btnInsertTrain_ATTENDEE_Metro;
        private DevExpress.XtraGrid.GridControl PQMS_STAFF_TRAIN_STAFFLISTGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_STAFF_TRAIN_STAFFLISTGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.ComboBox cmb_Dept;
        private DevExpress.XtraGrid.GridControl PQMS_STAFF_TRAIN_ATTENDEEGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_STAFF_TRAIN_ATTENDEEGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private System.Windows.Forms.Button btnPQMS_STAFF_TRAIN_ATTENDEE_IN;
        private System.Windows.Forms.Button btnPQMS_STAFF_TRAIN_ATTENDEE_OUT;
        private System.Windows.Forms.TextBox txt_SearchName;
    }
}