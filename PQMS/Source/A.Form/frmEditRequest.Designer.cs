
namespace PQMS
{
    partial class frmEditRequest
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtStaffCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContents = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGubun = new System.Windows.Forms.ComboBox();
            this.btn_ApproveReqSelect = new System.Windows.Forms.Button();
            this.btn_ApproveRequest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.PQMS_EDIT_RequestListGrid = new DevExpress.XtraGrid.GridControl();
            this.PQMS_EDIT_RequestListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.button9 = new System.Windows.Forms.Button();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.dtpRequestDate = new System.Windows.Forms.DateTimePicker();
            this.label42 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDX = new System.Windows.Forms.TextBox();
            this.btnGubun = new System.Windows.Forms.Button();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDIT_RequestListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDIT_RequestListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 312;
            this.label3.Text = "관리번호 :";
            // 
            // txtStaffCode
            // 
            this.txtStaffCode.Location = new System.Drawing.Point(119, 116);
            this.txtStaffCode.Name = "txtStaffCode";
            this.txtStaffCode.ReadOnly = true;
            this.txtStaffCode.Size = new System.Drawing.Size(70, 20);
            this.txtStaffCode.TabIndex = 311;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 328;
            this.label8.Text = "구분 :";
            // 
            // txtContents
            // 
            this.txtContents.Location = new System.Drawing.Point(119, 197);
            this.txtContents.Multiline = true;
            this.txtContents.Name = "txtContents";
            this.txtContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContents.Size = new System.Drawing.Size(631, 115);
            this.txtContents.TabIndex = 331;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 330;
            this.label1.Text = "수정요청 내용 :";
            // 
            // cmbGubun
            // 
            this.cmbGubun.FormattingEnabled = true;
            this.cmbGubun.Location = new System.Drawing.Point(119, 171);
            this.cmbGubun.Name = "cmbGubun";
            this.cmbGubun.Size = new System.Drawing.Size(208, 21);
            this.cmbGubun.TabIndex = 449;
            // 
            // btn_ApproveReqSelect
            // 
            this.btn_ApproveReqSelect.Location = new System.Drawing.Point(323, 63);
            this.btn_ApproveReqSelect.Name = "btn_ApproveReqSelect";
            this.btn_ApproveReqSelect.Size = new System.Drawing.Size(94, 23);
            this.btn_ApproveReqSelect.TabIndex = 452;
            this.btn_ApproveReqSelect.Text = "승인요청확인";
            this.btn_ApproveReqSelect.UseVisualStyleBackColor = true;
            this.btn_ApproveReqSelect.Click += new System.EventHandler(this.btn_ApproveReqSelect_Click);
            // 
            // btn_ApproveRequest
            // 
            this.btn_ApproveRequest.Location = new System.Drawing.Point(242, 63);
            this.btn_ApproveRequest.Name = "btn_ApproveRequest";
            this.btn_ApproveRequest.Size = new System.Drawing.Size(75, 23);
            this.btn_ApproveRequest.TabIndex = 451;
            this.btn_ApproveRequest.Text = "승인요청";
            this.btn_ApproveRequest.UseVisualStyleBackColor = true;
            this.btn_ApproveRequest.Click += new System.EventHandler(this.btn_ApproveRequest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(33, 63);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.TabIndex = 450;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(172, 63);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 23);
            this.btnDelete.TabIndex = 454;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(102, 63);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 23);
            this.btnEdit.TabIndex = 453;
            this.btnEdit.Text = "수정";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // PQMS_EDIT_RequestListGrid
            // 
            this.PQMS_EDIT_RequestListGrid.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_EDIT_RequestListGrid.Location = new System.Drawing.Point(33, 346);
            this.PQMS_EDIT_RequestListGrid.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_EDIT_RequestListGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_EDIT_RequestListGrid.MainView = this.PQMS_EDIT_RequestListView;
            this.PQMS_EDIT_RequestListGrid.Margin = new System.Windows.Forms.Padding(0);
            this.PQMS_EDIT_RequestListGrid.Name = "PQMS_EDIT_RequestListGrid";
            this.PQMS_EDIT_RequestListGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5,
            this.repositoryItemTextEdit6});
            this.PQMS_EDIT_RequestListGrid.Size = new System.Drawing.Size(774, 283);
            this.PQMS_EDIT_RequestListGrid.TabIndex = 457;
            this.PQMS_EDIT_RequestListGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_EDIT_RequestListView});
            // 
            // PQMS_EDIT_RequestListView
            // 
            this.PQMS_EDIT_RequestListView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDIT_RequestListView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_EDIT_RequestListView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_EDIT_RequestListView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDIT_RequestListView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_EDIT_RequestListView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDIT_RequestListView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_EDIT_RequestListView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDIT_RequestListView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_EDIT_RequestListView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDIT_RequestListView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_EDIT_RequestListView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDIT_RequestListView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_EDIT_RequestListView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDIT_RequestListView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_EDIT_RequestListView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDIT_RequestListView.Appearance.Row.Options.UseFont = true;
            this.PQMS_EDIT_RequestListView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDIT_RequestListView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_EDIT_RequestListView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_EDIT_RequestListView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_EDIT_RequestListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.PQMS_EDIT_RequestListView.CustomizationFormBounds = new System.Drawing.Rectangle(1070, 394, 210, 186);
            this.PQMS_EDIT_RequestListView.GridControl = this.PQMS_EDIT_RequestListGrid;
            this.PQMS_EDIT_RequestListView.Name = "PQMS_EDIT_RequestListView";
            this.PQMS_EDIT_RequestListView.OptionsBehavior.Editable = false;
            this.PQMS_EDIT_RequestListView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_EDIT_RequestListView.OptionsHint.ShowFooterHints = false;
            this.PQMS_EDIT_RequestListView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_EDIT_RequestListView.OptionsSelection.InvertSelection = true;
            this.PQMS_EDIT_RequestListView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.PQMS_EDIT_RequestListView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_EDIT_RequestListView.OptionsView.RowAutoHeight = true;
            this.PQMS_EDIT_RequestListView.OptionsView.ShowGroupPanel = false;
            this.PQMS_EDIT_RequestListView.OptionsView.ShowIndicator = false;
            this.PQMS_EDIT_RequestListView.Tag = 1;
            this.PQMS_EDIT_RequestListView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.PQMS_EDIT_RequestListView_RowCellClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "순번";
            this.gridColumn2.FieldName = "IDX";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "관리번호";
            this.gridColumn1.FieldName = "STAFF_CODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "이름";
            this.gridColumn3.FieldName = "STAFF_NAME";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = " 요청일자";
            this.gridColumn4.FieldName = "STAFF_EDITREQUEST_DATE";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "구분";
            this.gridColumn5.FieldName = "STAFF_EDITREQUEST_GUBUN";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "요청내용";
            this.gridColumn6.FieldName = "STAFF_EDITREQUEST_CONTENTS";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
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
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(33, 318);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(157, 25);
            this.button9.TabIndex = 458;
            this.button9.Text = "수정요청 리스트 조회";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(195, 116);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(132, 20);
            this.txtStaffName.TabIndex = 459;
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.CustomFormat = "yyyy-MM-dd";
            this.dtpRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequestDate.Location = new System.Drawing.Point(119, 144);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.Size = new System.Drawing.Size(208, 20);
            this.dtpRequestDate.TabIndex = 461;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(29, 150);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(57, 13);
            this.label42.TabIndex = 460;
            this.label42.Text = "요청일자 :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(542, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 22);
            this.button2.TabIndex = 463;
            this.button2.Text = "찾기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbStaff
            // 
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(332, 115);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(204, 21);
            this.cmbStaff.TabIndex = 462;
            this.cmbStaff.SelectedIndexChanged += new System.EventHandler(this.cmbStaff_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 465;
            this.label2.Text = "순번 :";
            // 
            // txtIDX
            // 
            this.txtIDX.Location = new System.Drawing.Point(119, 92);
            this.txtIDX.Name = "txtIDX";
            this.txtIDX.ReadOnly = true;
            this.txtIDX.Size = new System.Drawing.Size(70, 20);
            this.txtIDX.TabIndex = 464;
            // 
            // btnGubun
            // 
            this.btnGubun.Location = new System.Drawing.Point(333, 171);
            this.btnGubun.Name = "btnGubun";
            this.btnGubun.Size = new System.Drawing.Size(55, 22);
            this.btnGubun.TabIndex = 466;
            this.btnGubun.Text = "찾기";
            this.btnGubun.UseVisualStyleBackColor = true;
            this.btnGubun.Click += new System.EventHandler(this.btnGubun_Click);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "승인여부";
            this.gridColumn7.FieldName = "approvedYN_Korea";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // frmEditRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 661);
            this.Controls.Add(this.btnGubun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIDX);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.dtpRequestDate);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.PQMS_EDIT_RequestListGrid);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btn_ApproveReqSelect);
            this.Controls.Add(this.btn_ApproveRequest);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbGubun);
            this.Controls.Add(this.txtContents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStaffCode);
            this.Name = "frmEditRequest";
            this.Text = "수정변경요청 - frmEditRequest";
            this.Load += new System.EventHandler(this.frmEditRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDIT_RequestListGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_EDIT_RequestListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtStaffCode;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtContents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbGubun;
        private System.Windows.Forms.Button btn_ApproveReqSelect;
        private System.Windows.Forms.Button btn_ApproveRequest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private DevExpress.XtraGrid.GridControl PQMS_EDIT_RequestListGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_EDIT_RequestListView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit6;
        private System.Windows.Forms.Button button9;
        internal System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.DateTimePicker dtpRequestDate;
        internal System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbStaff;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtIDX;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.Button btnGubun;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}