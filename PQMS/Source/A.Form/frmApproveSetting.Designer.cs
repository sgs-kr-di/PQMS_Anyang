
namespace PQMS
{
    partial class frmApproveSetting
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
            this.btn_Search = new System.Windows.Forms.Button();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStaffCode = new System.Windows.Forms.TextBox();
            this.PQMS_Approve_SettingListGrid = new DevExpress.XtraGrid.GridControl();
            this.PQMS_Approve_SettingListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btn_ApproveSettingList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo_Approve1 = new System.Windows.Forms.RadioButton();
            this.rdo_Approve2 = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ApproveMenu = new System.Windows.Forms.Button();
            this.cmb_ApproveMenu = new System.Windows.Forms.ComboBox();
            this.txt_ApproveMenuNo = new System.Windows.Forms.TextBox();
            this.txt_ApproveMenuName = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLoginID = new System.Windows.Forms.TextBox();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.txtArowNo = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtAppNo = new System.Windows.Forms.TextBox();
            this.txtAppID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_Approve_SettingListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_Approve_SettingListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(478, 151);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(55, 22);
            this.btn_Search.TabIndex = 468;
            this.btn_Search.Text = "찾기";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // cmbStaff
            // 
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(489, 61);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(204, 21);
            this.cmbStaff.TabIndex = 467;
            this.cmbStaff.UseWaitCursor = true;
            this.cmbStaff.Visible = false;
            this.cmbStaff.SelectedIndexChanged += new System.EventHandler(this.cmbStaff_SelectedIndexChanged);
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(390, 61);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(93, 20);
            this.txtStaffName.TabIndex = 466;
            this.txtStaffName.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 465;
            this.label3.Text = "관리번호 :";
            // 
            // txtStaffCode
            // 
            this.txtStaffCode.Location = new System.Drawing.Point(320, 61);
            this.txtStaffCode.Name = "txtStaffCode";
            this.txtStaffCode.ReadOnly = true;
            this.txtStaffCode.Size = new System.Drawing.Size(64, 20);
            this.txtStaffCode.TabIndex = 464;
            this.txtStaffCode.Visible = false;
            // 
            // PQMS_Approve_SettingListGrid
            // 
            this.PQMS_Approve_SettingListGrid.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_Approve_SettingListGrid.Location = new System.Drawing.Point(9, 235);
            this.PQMS_Approve_SettingListGrid.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_Approve_SettingListGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_Approve_SettingListGrid.MainView = this.PQMS_Approve_SettingListView;
            this.PQMS_Approve_SettingListGrid.Margin = new System.Windows.Forms.Padding(0);
            this.PQMS_Approve_SettingListGrid.Name = "PQMS_Approve_SettingListGrid";
            this.PQMS_Approve_SettingListGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5,
            this.repositoryItemTextEdit6});
            this.PQMS_Approve_SettingListGrid.Size = new System.Drawing.Size(430, 283);
            this.PQMS_Approve_SettingListGrid.TabIndex = 469;
            this.PQMS_Approve_SettingListGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_Approve_SettingListView});
            // 
            // PQMS_Approve_SettingListView
            // 
            this.PQMS_Approve_SettingListView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_Approve_SettingListView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_Approve_SettingListView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_Approve_SettingListView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_Approve_SettingListView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_Approve_SettingListView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_Approve_SettingListView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_Approve_SettingListView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_Approve_SettingListView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_Approve_SettingListView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_Approve_SettingListView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_Approve_SettingListView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_Approve_SettingListView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_Approve_SettingListView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_Approve_SettingListView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_Approve_SettingListView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_Approve_SettingListView.Appearance.Row.Options.UseFont = true;
            this.PQMS_Approve_SettingListView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_Approve_SettingListView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_Approve_SettingListView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_Approve_SettingListView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_Approve_SettingListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4});
            this.PQMS_Approve_SettingListView.CustomizationFormBounds = new System.Drawing.Rectangle(1070, 394, 210, 186);
            this.PQMS_Approve_SettingListView.GridControl = this.PQMS_Approve_SettingListGrid;
            this.PQMS_Approve_SettingListView.Name = "PQMS_Approve_SettingListView";
            this.PQMS_Approve_SettingListView.OptionsBehavior.Editable = false;
            this.PQMS_Approve_SettingListView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_Approve_SettingListView.OptionsHint.ShowFooterHints = false;
            this.PQMS_Approve_SettingListView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_Approve_SettingListView.OptionsSelection.InvertSelection = true;
            this.PQMS_Approve_SettingListView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.PQMS_Approve_SettingListView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_Approve_SettingListView.OptionsView.RowAutoHeight = true;
            this.PQMS_Approve_SettingListView.OptionsView.ShowGroupPanel = false;
            this.PQMS_Approve_SettingListView.OptionsView.ShowIndicator = false;
            this.PQMS_Approve_SettingListView.Tag = 1;
            this.PQMS_Approve_SettingListView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.PQMS_Approve_SettingListView_RowCellClick);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "AccountNo";
            this.gridColumn6.FieldName = "accountNo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "관리번호";
            this.gridColumn5.FieldName = "STAFF_CODE";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "이름";
            this.gridColumn2.FieldName = "firstName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "userID";
            this.gridColumn1.FieldName = "logInID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "메뉴명";
            this.gridColumn3.FieldName = "WorkName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "승인권한";
            this.gridColumn4.FieldName = "approved_Setting";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemTextEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemTextEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTextEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemTextEdit1.AppearanceFocused.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemTextEdit1.AppearanceFocused.Options.UseFont = true;
            this.repositoryItemTextEdit1.AppearanceFocused.Options.UseTextOptions = true;
            this.repositoryItemTextEdit1.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.MaxLength = 20;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            // 
            // repositoryItemTextEdit6
            // 
            this.repositoryItemTextEdit6.AutoHeight = false;
            this.repositoryItemTextEdit6.Name = "repositoryItemTextEdit6";
            // 
            // btn_ApproveSettingList
            // 
            this.btn_ApproveSettingList.Location = new System.Drawing.Point(9, 196);
            this.btn_ApproveSettingList.Name = "btn_ApproveSettingList";
            this.btn_ApproveSettingList.Size = new System.Drawing.Size(157, 25);
            this.btn_ApproveSettingList.TabIndex = 470;
            this.btn_ApproveSettingList.Text = "승인권자 리스트 조회";
            this.btn_ApproveSettingList.UseVisualStyleBackColor = true;
            this.btn_ApproveSettingList.Click += new System.EventHandler(this.btn_ApproveSettingList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 471;
            this.label1.Text = "권한 :";
            // 
            // rdo_Approve1
            // 
            this.rdo_Approve1.AutoSize = true;
            this.rdo_Approve1.Location = new System.Drawing.Point(99, 101);
            this.rdo_Approve1.Name = "rdo_Approve1";
            this.rdo_Approve1.Size = new System.Drawing.Size(58, 17);
            this.rdo_Approve1.TabIndex = 472;
            this.rdo_Approve1.TabStop = true;
            this.rdo_Approve1.Text = "검토자";
            this.rdo_Approve1.UseVisualStyleBackColor = true;
            // 
            // rdo_Approve2
            // 
            this.rdo_Approve2.AutoSize = true;
            this.rdo_Approve2.Location = new System.Drawing.Point(190, 101);
            this.rdo_Approve2.Name = "rdo_Approve2";
            this.rdo_Approve2.Size = new System.Drawing.Size(58, 17);
            this.rdo_Approve2.TabIndex = 473;
            this.rdo_Approve2.TabStop = true;
            this.rdo_Approve2.Text = "승인자";
            this.rdo_Approve2.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(87, 58);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 23);
            this.btnDelete.TabIndex = 476;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(235, 57);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 23);
            this.btnEdit.TabIndex = 475;
            this.btnEdit.Text = "수정";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 58);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.TabIndex = 474;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 477;
            this.label2.Text = "메뉴명 :";
            // 
            // btn_ApproveMenu
            // 
            this.btn_ApproveMenu.Location = new System.Drawing.Point(478, 122);
            this.btn_ApproveMenu.Name = "btn_ApproveMenu";
            this.btn_ApproveMenu.Size = new System.Drawing.Size(55, 22);
            this.btn_ApproveMenu.TabIndex = 479;
            this.btn_ApproveMenu.Text = "찾기";
            this.btn_ApproveMenu.UseVisualStyleBackColor = true;
            this.btn_ApproveMenu.Click += new System.EventHandler(this.btn_ApproveMenu_Click);
            // 
            // cmb_ApproveMenu
            // 
            this.cmb_ApproveMenu.FormattingEnabled = true;
            this.cmb_ApproveMenu.Location = new System.Drawing.Point(268, 124);
            this.cmb_ApproveMenu.Name = "cmb_ApproveMenu";
            this.cmb_ApproveMenu.Size = new System.Drawing.Size(204, 21);
            this.cmb_ApproveMenu.TabIndex = 478;
            this.cmb_ApproveMenu.SelectedIndexChanged += new System.EventHandler(this.cmb_ApproveMenu_SelectedIndexChanged);
            // 
            // txt_ApproveMenuNo
            // 
            this.txt_ApproveMenuNo.Location = new System.Drawing.Point(99, 125);
            this.txt_ApproveMenuNo.Name = "txt_ApproveMenuNo";
            this.txt_ApproveMenuNo.ReadOnly = true;
            this.txt_ApproveMenuNo.Size = new System.Drawing.Size(64, 20);
            this.txt_ApproveMenuNo.TabIndex = 480;
            // 
            // txt_ApproveMenuName
            // 
            this.txt_ApproveMenuName.Location = new System.Drawing.Point(169, 125);
            this.txt_ApproveMenuName.Name = "txt_ApproveMenuName";
            this.txt_ApproveMenuName.ReadOnly = true;
            this.txt_ApproveMenuName.Size = new System.Drawing.Size(93, 20);
            this.txt_ApproveMenuName.TabIndex = 481;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvData.Location = new System.Drawing.Point(442, 179);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(346, 339);
            this.dgvData.TabIndex = 482;
            this.dgvData.Visible = false;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.FillWeight = 10F;
            this.dataGridViewCheckBoxColumn2.HeaderText = "A";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn2.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // txtLoginID
            // 
            this.txtLoginID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLoginID.Location = new System.Drawing.Point(169, 152);
            this.txtLoginID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(303, 20);
            this.txtLoginID.TabIndex = 483;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Location = new System.Drawing.Point(99, 152);
            this.txtAccountNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(64, 20);
            this.txtAccountNo.TabIndex = 484;
            // 
            // txtArowNo
            // 
            this.txtArowNo.Location = new System.Drawing.Point(346, 259);
            this.txtArowNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtArowNo.Name = "txtArowNo";
            this.txtArowNo.Size = new System.Drawing.Size(90, 20);
            this.txtArowNo.TabIndex = 485;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(489, 86);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(142, 20);
            this.txtUserID.TabIndex = 486;
            this.txtUserID.Visible = false;
            // 
            // txtAppNo
            // 
            this.txtAppNo.BackColor = System.Drawing.Color.Silver;
            this.txtAppNo.Location = new System.Drawing.Point(319, 86);
            this.txtAppNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppNo.Name = "txtAppNo";
            this.txtAppNo.Size = new System.Drawing.Size(41, 20);
            this.txtAppNo.TabIndex = 488;
            this.txtAppNo.Text = "3";
            // 
            // txtAppID
            // 
            this.txtAppID.BackColor = System.Drawing.Color.Silver;
            this.txtAppID.Location = new System.Drawing.Point(366, 86);
            this.txtAppID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppID.Name = "txtAppID";
            this.txtAppID.Size = new System.Drawing.Size(91, 20);
            this.txtAppID.TabIndex = 487;
            this.txtAppID.Text = "PQMS";
            // 
            // frmApproveSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.txtAppNo);
            this.Controls.Add(this.txtAppID);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.txtLoginID);
            this.Controls.Add(this.txt_ApproveMenuName);
            this.Controls.Add(this.txt_ApproveMenuNo);
            this.Controls.Add(this.btn_ApproveMenu);
            this.Controls.Add(this.cmb_ApproveMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rdo_Approve2);
            this.Controls.Add(this.rdo_Approve1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ApproveSettingList);
            this.Controls.Add(this.PQMS_Approve_SettingListGrid);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStaffCode);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.txtArowNo);
            this.Name = "frmApproveSetting";
            this.Text = "메뉴별 승인권자 설정";
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_Approve_SettingListGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_Approve_SettingListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ComboBox cmbStaff;
        internal System.Windows.Forms.TextBox txtStaffName;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtStaffCode;
        private DevExpress.XtraGrid.GridControl PQMS_Approve_SettingListGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_Approve_SettingListView;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit6;
        private System.Windows.Forms.Button btn_ApproveSettingList;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdo_Approve1;
        private System.Windows.Forms.RadioButton rdo_Approve2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ApproveMenu;
        private System.Windows.Forms.ComboBox cmb_ApproveMenu;
        internal System.Windows.Forms.TextBox txt_ApproveMenuNo;
        internal System.Windows.Forms.TextBox txt_ApproveMenuName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox txtLoginID;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.TextBox txtArowNo;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtAppNo;
        private System.Windows.Forms.TextBox txtAppID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}