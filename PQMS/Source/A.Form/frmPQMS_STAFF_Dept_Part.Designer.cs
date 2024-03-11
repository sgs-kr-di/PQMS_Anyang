
namespace PQMS
{
    partial class frmPQMS_STAFF_Dept_Part
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
            this.btnSelectPreInfo = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeletePreJobInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsertPreJobInfo = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_DEPTPARTNAME = new System.Windows.Forms.TextBox();
            this.btn_DEPTPART = new System.Windows.Forms.Button();
            this.cmb_DEPTPART = new System.Windows.Forms.ComboBox();
            this.txt_DEPTPARTCODE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo_PartMaster_N = new System.Windows.Forms.RadioButton();
            this.rdo_PartMaster_Y = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtIDX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSTAFF_CODE = new System.Windows.Forms.TextBox();
            this.txtSTAFF_TEAM = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PQMS_STAFF_DeptPart = new DevExpress.XtraGrid.GridControl();
            this.PQMS_STAFF_DeptPartView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STAFF_TEAMMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.STAFF_NAMEMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.STAFF_CODEMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.STAFF_SCHOOLMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.STAFF_MAJORMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.STAFF_JOIN_DATEMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_DeptPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_DeptPartView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_TEAMMainTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_NAMEMainTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_CODEMainTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_SCHOOLMainTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_MAJORMainTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_JOIN_DATEMainTextEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectPreInfo
            // 
            this.btnSelectPreInfo.Location = new System.Drawing.Point(174, 3);
            this.btnSelectPreInfo.Name = "btnSelectPreInfo";
            this.btnSelectPreInfo.Size = new System.Drawing.Size(75, 25);
            this.btnSelectPreInfo.TabIndex = 275;
            this.btnSelectPreInfo.Text = "조회";
            this.btnSelectPreInfo.Click += new System.EventHandler(this.btnSelectPreInfo_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.btnDeletePreJobInfo);
            this.panel2.Controls.Add(this.btnInsertPreJobInfo);
            this.panel2.Controls.Add(this.btnSelectPreInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 30);
            this.panel2.TabIndex = 273;
            // 
            // btnDeletePreJobInfo
            // 
            this.btnDeletePreJobInfo.Location = new System.Drawing.Point(93, 3);
            this.btnDeletePreJobInfo.Name = "btnDeletePreJobInfo";
            this.btnDeletePreJobInfo.Size = new System.Drawing.Size(75, 25);
            this.btnDeletePreJobInfo.TabIndex = 1;
            this.btnDeletePreJobInfo.Text = "삭제";
            this.btnDeletePreJobInfo.Click += new System.EventHandler(this.btnDeletePreJobInfo_Click);
            // 
            // btnInsertPreJobInfo
            // 
            this.btnInsertPreJobInfo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnInsertPreJobInfo.Appearance.Options.UseForeColor = true;
            this.btnInsertPreJobInfo.Location = new System.Drawing.Point(12, 3);
            this.btnInsertPreJobInfo.Name = "btnInsertPreJobInfo";
            this.btnInsertPreJobInfo.Size = new System.Drawing.Size(75, 25);
            this.btnInsertPreJobInfo.TabIndex = 0;
            this.btnInsertPreJobInfo.Text = "저장";
            this.btnInsertPreJobInfo.Click += new System.EventHandler(this.btnInsertPreJobInfo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_DEPTPARTNAME);
            this.panel1.Controls.Add(this.btn_DEPTPART);
            this.panel1.Controls.Add(this.cmb_DEPTPART);
            this.panel1.Controls.Add(this.txt_DEPTPARTCODE);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdo_PartMaster_N);
            this.panel1.Controls.Add(this.rdo_PartMaster_Y);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.txtSTAFF_TEAM);
            this.panel1.Location = new System.Drawing.Point(12, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 104);
            this.panel1.TabIndex = 272;
            // 
            // txt_DEPTPARTNAME
            // 
            this.txt_DEPTPARTNAME.Location = new System.Drawing.Point(194, 43);
            this.txt_DEPTPARTNAME.Name = "txt_DEPTPARTNAME";
            this.txt_DEPTPARTNAME.Size = new System.Drawing.Size(149, 20);
            this.txt_DEPTPARTNAME.TabIndex = 305;
            // 
            // btn_DEPTPART
            // 
            this.btn_DEPTPART.Location = new System.Drawing.Point(514, 42);
            this.btn_DEPTPART.Name = "btn_DEPTPART";
            this.btn_DEPTPART.Size = new System.Drawing.Size(38, 22);
            this.btn_DEPTPART.TabIndex = 304;
            this.btn_DEPTPART.Text = "찾기";
            this.btn_DEPTPART.UseVisualStyleBackColor = true;
            this.btn_DEPTPART.Click += new System.EventHandler(this.btn_DEPTPART_Click);
            // 
            // cmb_DEPTPART
            // 
            this.cmb_DEPTPART.FormattingEnabled = true;
            this.cmb_DEPTPART.Location = new System.Drawing.Point(349, 43);
            this.cmb_DEPTPART.Name = "cmb_DEPTPART";
            this.cmb_DEPTPART.Size = new System.Drawing.Size(159, 21);
            this.cmb_DEPTPART.TabIndex = 303;
            this.cmb_DEPTPART.SelectedIndexChanged += new System.EventHandler(this.cmb_DEPTPART_SelectedIndexChanged);
            // 
            // txt_DEPTPARTCODE
            // 
            this.txt_DEPTPARTCODE.Location = new System.Drawing.Point(102, 43);
            this.txt_DEPTPARTCODE.Name = "txt_DEPTPARTCODE";
            this.txt_DEPTPARTCODE.Size = new System.Drawing.Size(86, 20);
            this.txt_DEPTPARTCODE.TabIndex = 302;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 278;
            this.label1.Text = "팀장/파트장 :";
            // 
            // rdo_PartMaster_N
            // 
            this.rdo_PartMaster_N.AutoSize = true;
            this.rdo_PartMaster_N.Location = new System.Drawing.Point(155, 76);
            this.rdo_PartMaster_N.Name = "rdo_PartMaster_N";
            this.rdo_PartMaster_N.Size = new System.Drawing.Size(33, 17);
            this.rdo_PartMaster_N.TabIndex = 277;
            this.rdo_PartMaster_N.TabStop = true;
            this.rdo_PartMaster_N.Text = "N";
            this.rdo_PartMaster_N.UseVisualStyleBackColor = true;
            // 
            // rdo_PartMaster_Y
            // 
            this.rdo_PartMaster_Y.AutoSize = true;
            this.rdo_PartMaster_Y.Location = new System.Drawing.Point(102, 76);
            this.rdo_PartMaster_Y.Name = "rdo_PartMaster_Y";
            this.rdo_PartMaster_Y.Size = new System.Drawing.Size(32, 17);
            this.rdo_PartMaster_Y.TabIndex = 276;
            this.rdo_PartMaster_Y.TabStop = true;
            this.rdo_PartMaster_Y.Text = "Y";
            this.rdo_PartMaster_Y.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 274;
            this.label6.Text = "Part :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 270;
            this.label4.Text = "순번 :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(11, 17);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(35, 13);
            this.Label2.TabIndex = 260;
            this.Label2.Text = "부서 :";
            // 
            // txtIDX
            // 
            this.txtIDX.Location = new System.Drawing.Point(114, 365);
            this.txtIDX.Name = "txtIDX";
            this.txtIDX.ReadOnly = true;
            this.txtIDX.Size = new System.Drawing.Size(143, 20);
            this.txtIDX.TabIndex = 271;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(404, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 268;
            this.label9.Text = "관리번호 :";
            // 
            // txtSTAFF_CODE
            // 
            this.txtSTAFF_CODE.Location = new System.Drawing.Point(467, 361);
            this.txtSTAFF_CODE.Name = "txtSTAFF_CODE";
            this.txtSTAFF_CODE.ReadOnly = true;
            this.txtSTAFF_CODE.Size = new System.Drawing.Size(143, 20);
            this.txtSTAFF_CODE.TabIndex = 269;
            // 
            // txtSTAFF_TEAM
            // 
            this.txtSTAFF_TEAM.Location = new System.Drawing.Point(102, 14);
            this.txtSTAFF_TEAM.Name = "txtSTAFF_TEAM";
            this.txtSTAFF_TEAM.ReadOnly = true;
            this.txtSTAFF_TEAM.Size = new System.Drawing.Size(143, 20);
            this.txtSTAFF_TEAM.TabIndex = 263;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.PQMS_STAFF_DeptPart);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.txtSTAFF_CODE);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtIDX);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(20, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(654, 412);
            this.panel3.TabIndex = 276;
            // 
            // PQMS_STAFF_DeptPart
            // 
            this.PQMS_STAFF_DeptPart.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_STAFF_DeptPart.Location = new System.Drawing.Point(12, 155);
            this.PQMS_STAFF_DeptPart.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_STAFF_DeptPart.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_STAFF_DeptPart.MainView = this.PQMS_STAFF_DeptPartView;
            this.PQMS_STAFF_DeptPart.Margin = new System.Windows.Forms.Padding(0);
            this.PQMS_STAFF_DeptPart.Name = "PQMS_STAFF_DeptPart";
            this.PQMS_STAFF_DeptPart.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.STAFF_TEAMMainTextEdit,
            this.STAFF_NAMEMainTextEdit,
            this.STAFF_CODEMainTextEdit,
            this.STAFF_SCHOOLMainTextEdit,
            this.STAFF_MAJORMainTextEdit,
            this.STAFF_JOIN_DATEMainTextEdit});
            this.PQMS_STAFF_DeptPart.Size = new System.Drawing.Size(627, 244);
            this.PQMS_STAFF_DeptPart.TabIndex = 456;
            this.PQMS_STAFF_DeptPart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_STAFF_DeptPartView});
            // 
            // PQMS_STAFF_DeptPartView
            // 
            this.PQMS_STAFF_DeptPartView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_DeptPartView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_STAFF_DeptPartView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_STAFF_DeptPartView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_DeptPartView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_STAFF_DeptPartView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_DeptPartView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_STAFF_DeptPartView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_DeptPartView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_STAFF_DeptPartView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_DeptPartView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_STAFF_DeptPartView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_DeptPartView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_STAFF_DeptPartView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_DeptPartView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_STAFF_DeptPartView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_DeptPartView.Appearance.Row.Options.UseFont = true;
            this.PQMS_STAFF_DeptPartView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_DeptPartView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_STAFF_DeptPartView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_DeptPartView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_STAFF_DeptPartView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.PQMS_STAFF_DeptPartView.CustomizationFormBounds = new System.Drawing.Rectangle(1070, 394, 210, 186);
            this.PQMS_STAFF_DeptPartView.GridControl = this.PQMS_STAFF_DeptPart;
            this.PQMS_STAFF_DeptPartView.Name = "PQMS_STAFF_DeptPartView";
            this.PQMS_STAFF_DeptPartView.OptionsBehavior.Editable = false;
            this.PQMS_STAFF_DeptPartView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_STAFF_DeptPartView.OptionsHint.ShowFooterHints = false;
            this.PQMS_STAFF_DeptPartView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_STAFF_DeptPartView.OptionsSelection.InvertSelection = true;
            this.PQMS_STAFF_DeptPartView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.PQMS_STAFF_DeptPartView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_STAFF_DeptPartView.OptionsView.RowAutoHeight = true;
            this.PQMS_STAFF_DeptPartView.OptionsView.ShowGroupPanel = false;
            this.PQMS_STAFF_DeptPartView.OptionsView.ShowIndicator = false;
            this.PQMS_STAFF_DeptPartView.Tag = 1;
            this.PQMS_STAFF_DeptPartView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.PQMS_STAFF_DeptPartView_RowCellClick);
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "IDX";
            this.gridColumn4.FieldName = "IDX";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 49;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "부서";
            this.gridColumn1.FieldName = "FOLDER_NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "파트";
            this.gridColumn2.FieldName = "BOARD_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "팀장/파트장 여부";
            this.gridColumn3.FieldName = "STAFF_TEAM_PART_MASTER";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 120;
            // 
            // STAFF_TEAMMainTextEdit
            // 
            this.STAFF_TEAMMainTextEdit.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STAFF_TEAMMainTextEdit.Appearance.Options.UseFont = true;
            this.STAFF_TEAMMainTextEdit.Appearance.Options.UseTextOptions = true;
            this.STAFF_TEAMMainTextEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.STAFF_TEAMMainTextEdit.AppearanceFocused.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STAFF_TEAMMainTextEdit.AppearanceFocused.Options.UseFont = true;
            this.STAFF_TEAMMainTextEdit.AppearanceFocused.Options.UseTextOptions = true;
            this.STAFF_TEAMMainTextEdit.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.STAFF_TEAMMainTextEdit.AutoHeight = false;
            this.STAFF_TEAMMainTextEdit.MaxLength = 20;
            this.STAFF_TEAMMainTextEdit.Name = "STAFF_TEAMMainTextEdit";
            // 
            // STAFF_NAMEMainTextEdit
            // 
            this.STAFF_NAMEMainTextEdit.AutoHeight = false;
            this.STAFF_NAMEMainTextEdit.Name = "STAFF_NAMEMainTextEdit";
            // 
            // STAFF_CODEMainTextEdit
            // 
            this.STAFF_CODEMainTextEdit.AutoHeight = false;
            this.STAFF_CODEMainTextEdit.Name = "STAFF_CODEMainTextEdit";
            // 
            // STAFF_SCHOOLMainTextEdit
            // 
            this.STAFF_SCHOOLMainTextEdit.AutoHeight = false;
            this.STAFF_SCHOOLMainTextEdit.Name = "STAFF_SCHOOLMainTextEdit";
            // 
            // STAFF_MAJORMainTextEdit
            // 
            this.STAFF_MAJORMainTextEdit.AutoHeight = false;
            this.STAFF_MAJORMainTextEdit.Name = "STAFF_MAJORMainTextEdit";
            // 
            // STAFF_JOIN_DATEMainTextEdit
            // 
            this.STAFF_JOIN_DATEMainTextEdit.AutoHeight = false;
            this.STAFF_JOIN_DATEMainTextEdit.Name = "STAFF_JOIN_DATEMainTextEdit";
            // 
            // frmPQMS_STAFF_Dept_Part
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 492);
            this.Controls.Add(this.panel3);
            this.Name = "frmPQMS_STAFF_Dept_Part";
            this.Text = "팀 파트 정보";
            this.TransparencyKey = System.Drawing.Color.LightBlue;
            this.Load += new System.EventHandler(this.frmPQMS_STAFF_PRE_JOB_INFO_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_DeptPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_DeptPartView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_TEAMMainTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_NAMEMainTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_CODEMainTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_SCHOOLMainTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_MAJORMainTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_JOIN_DATEMainTextEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSelectPreInfo;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnDeletePreJobInfo;
        private DevExpress.XtraEditors.SimpleButton btnInsertPreJobInfo;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdo_PartMaster_N;
        private System.Windows.Forms.RadioButton rdo_PartMaster_Y;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtIDX;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtSTAFF_CODE;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl PQMS_STAFF_DeptPart;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_STAFF_DeptPartView;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_TEAMMainTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_NAMEMainTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_CODEMainTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_SCHOOLMainTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_MAJORMainTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_JOIN_DATEMainTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        internal System.Windows.Forms.TextBox txt_DEPTPARTNAME;
        private System.Windows.Forms.Button btn_DEPTPART;
        private System.Windows.Forms.ComboBox cmb_DEPTPART;
        internal System.Windows.Forms.TextBox txt_DEPTPARTCODE;
        internal System.Windows.Forms.TextBox txtSTAFF_TEAM;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}