
namespace PQMS
{
    partial class frmApproveRequestCheckVer2
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtApproveComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRequestContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtToBeApproved = new System.Windows.Forms.TextBox();
            this.txtidxNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEduReportGo = new System.Windows.Forms.Button();
            this.dgvUserRequestStatus = new System.Windows.Forms.DataGridView();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.txtLoginID = new System.Windows.Forms.TextBox();
            this.cmbApprover = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.PQMS_STAFF_ApproveRequestCheckListGrid = new DevExpress.XtraGrid.GridControl();
            this.PQMS_STAFF_ApproveRequestCheckListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STAFF_TEAMMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.STAFF_NAMEMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.STAFF_CODEMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.STAFF_SCHOOLMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.STAFF_MAJORMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.STAFF_JOIN_DATEMainTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_ApproveRequestCheckListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_ApproveRequestCheckListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_TEAMMainTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_NAMEMainTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_CODEMainTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_SCHOOLMainTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_MAJORMainTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_JOIN_DATEMainTextEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 353;
            this.label2.Text = "승인대상자료번호 :";
            // 
            // txtApproveComment
            // 
            this.txtApproveComment.Location = new System.Drawing.Point(116, 133);
            this.txtApproveComment.Margin = new System.Windows.Forms.Padding(2);
            this.txtApproveComment.Name = "txtApproveComment";
            this.txtApproveComment.Size = new System.Drawing.Size(426, 20);
            this.txtApproveComment.TabIndex = 352;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 351;
            this.label1.Text = "승인/보류 내용 :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(287, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 39);
            this.button2.TabIndex = 350;
            this.button2.Text = "반려";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 39);
            this.button1.TabIndex = 349;
            this.button1.Text = "승인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRequestContent
            // 
            this.txtRequestContent.Location = new System.Drawing.Point(116, 109);
            this.txtRequestContent.Margin = new System.Windows.Forms.Padding(2);
            this.txtRequestContent.Name = "txtRequestContent";
            this.txtRequestContent.Size = new System.Drawing.Size(426, 20);
            this.txtRequestContent.TabIndex = 348;
            this.txtRequestContent.Text = "승인해 주세요";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 347;
            this.label3.Text = "승인요청내용 :";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(159, 85);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(282, 20);
            this.txtTitle.TabIndex = 346;
            // 
            // txtToBeApproved
            // 
            this.txtToBeApproved.Location = new System.Drawing.Point(116, 85);
            this.txtToBeApproved.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtToBeApproved.Name = "txtToBeApproved";
            this.txtToBeApproved.Size = new System.Drawing.Size(41, 20);
            this.txtToBeApproved.TabIndex = 344;
            // 
            // txtidxNo
            // 
            this.txtidxNo.Location = new System.Drawing.Point(116, 62);
            this.txtidxNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtidxNo.Name = "txtidxNo";
            this.txtidxNo.Size = new System.Drawing.Size(40, 20);
            this.txtidxNo.TabIndex = 340;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 338;
            this.label6.Text = "승인요청자료번호 :";
            // 
            // btnEduReportGo
            // 
            this.btnEduReportGo.Location = new System.Drawing.Point(12, 12);
            this.btnEduReportGo.Name = "btnEduReportGo";
            this.btnEduReportGo.Size = new System.Drawing.Size(178, 39);
            this.btnEduReportGo.TabIndex = 337;
            this.btnEduReportGo.Text = "승인요청내역확인";
            this.btnEduReportGo.UseVisualStyleBackColor = true;
            this.btnEduReportGo.Click += new System.EventHandler(this.btnEduReportGo_Click);
            // 
            // dgvUserRequestStatus
            // 
            this.dgvUserRequestStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserRequestStatus.Location = new System.Drawing.Point(12, 250);
            this.dgvUserRequestStatus.Name = "dgvUserRequestStatus";
            this.dgvUserRequestStatus.Size = new System.Drawing.Size(293, 116);
            this.dgvUserRequestStatus.TabIndex = 354;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Location = new System.Drawing.Point(326, 231);
            this.txtAccountNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(41, 20);
            this.txtAccountNo.TabIndex = 358;
            // 
            // txtLoginID
            // 
            this.txtLoginID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLoginID.Location = new System.Drawing.Point(370, 231);
            this.txtLoginID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(138, 20);
            this.txtLoginID.TabIndex = 359;
            // 
            // cmbApprover
            // 
            this.cmbApprover.FormattingEnabled = true;
            this.cmbApprover.Location = new System.Drawing.Point(514, 231);
            this.cmbApprover.Name = "cmbApprover";
            this.cmbApprover.Size = new System.Drawing.Size(201, 21);
            this.cmbApprover.TabIndex = 357;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(721, 231);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 23);
            this.button4.TabIndex = 356;
            this.button4.Text = "S";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 355;
            this.label5.Text = "승인권자  :";
            // 
            // PQMS_STAFF_ApproveRequestCheckListGrid
            // 
            this.PQMS_STAFF_ApproveRequestCheckListGrid.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.PQMS_STAFF_ApproveRequestCheckListGrid.Location = new System.Drawing.Point(9, 173);
            this.PQMS_STAFF_ApproveRequestCheckListGrid.LookAndFeel.SkinName = "DevExpress Style";
            this.PQMS_STAFF_ApproveRequestCheckListGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PQMS_STAFF_ApproveRequestCheckListGrid.MainView = this.PQMS_STAFF_ApproveRequestCheckListView;
            this.PQMS_STAFF_ApproveRequestCheckListGrid.Margin = new System.Windows.Forms.Padding(0);
            this.PQMS_STAFF_ApproveRequestCheckListGrid.Name = "PQMS_STAFF_ApproveRequestCheckListGrid";
            this.PQMS_STAFF_ApproveRequestCheckListGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.STAFF_TEAMMainTextEdit,
            this.STAFF_NAMEMainTextEdit,
            this.STAFF_CODEMainTextEdit,
            this.STAFF_SCHOOLMainTextEdit,
            this.STAFF_MAJORMainTextEdit,
            this.STAFF_JOIN_DATEMainTextEdit});
            this.PQMS_STAFF_ApproveRequestCheckListGrid.Size = new System.Drawing.Size(782, 268);
            this.PQMS_STAFF_ApproveRequestCheckListGrid.TabIndex = 456;
            this.PQMS_STAFF_ApproveRequestCheckListGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PQMS_STAFF_ApproveRequestCheckListView});
            // 
            // PQMS_STAFF_ApproveRequestCheckListView
            // 
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.EvenRow.Options.UseFont = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.FixedLine.Options.UseFont = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.FocusedCell.Options.UseFont = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.FocusedRow.Options.UseFont = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.HeaderPanel.Options.UseFont = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.OddRow.Options.UseFont = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.Preview.Options.UseFont = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.Row.Options.UseFont = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.SelectedRow.Options.UseFont = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQMS_STAFF_ApproveRequestCheckListView.Appearance.ViewCaption.Options.UseFont = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn10,
            this.gridColumn11});
            this.PQMS_STAFF_ApproveRequestCheckListView.CustomizationFormBounds = new System.Drawing.Rectangle(1070, 394, 210, 186);
            this.PQMS_STAFF_ApproveRequestCheckListView.GridControl = this.PQMS_STAFF_ApproveRequestCheckListGrid;
            this.PQMS_STAFF_ApproveRequestCheckListView.Name = "PQMS_STAFF_ApproveRequestCheckListView";
            this.PQMS_STAFF_ApproveRequestCheckListView.OptionsBehavior.Editable = false;
            this.PQMS_STAFF_ApproveRequestCheckListView.OptionsHint.ShowColumnHeaderHints = false;
            this.PQMS_STAFF_ApproveRequestCheckListView.OptionsHint.ShowFooterHints = false;
            this.PQMS_STAFF_ApproveRequestCheckListView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.PQMS_STAFF_ApproveRequestCheckListView.OptionsSelection.InvertSelection = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.PQMS_STAFF_ApproveRequestCheckListView.OptionsView.ColumnAutoWidth = false;
            this.PQMS_STAFF_ApproveRequestCheckListView.OptionsView.RowAutoHeight = true;
            this.PQMS_STAFF_ApproveRequestCheckListView.OptionsView.ShowGroupPanel = false;
            this.PQMS_STAFF_ApproveRequestCheckListView.OptionsView.ShowIndicator = false;
            this.PQMS_STAFF_ApproveRequestCheckListView.Tag = 1;
            this.PQMS_STAFF_ApproveRequestCheckListView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.PQMS_STAFF_ApproveRequestCheckListView_RowCellClick);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "순번";
            this.gridColumn9.FieldName = "IDX";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "승인대상자료번호";
            this.gridColumn1.FieldName = "approveIdx";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 128;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "요청자";
            this.gridColumn2.FieldName = "requestedBy";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "요청일자";
            this.gridColumn3.FieldName = "requestDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "요청내용";
            this.gridColumn4.FieldName = "approveComment";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "MyApproveDepth";
            this.gridColumn5.FieldName = "MyApproveDepth";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "FinalApproveDepth";
            this.gridColumn6.FieldName = "MaxApproveDepth";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "requestDeptCode";
            this.gridColumn7.FieldName = "DeptNo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "교육보고서";
            this.gridColumn8.FieldName = "STAFF_TRAIN_REPORT_FILE";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "자격부여평가보고서";
            this.gridColumn10.FieldName = "FINAL_FILE";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 80;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "직무기술서";
            this.gridColumn11.FieldName = "RP_FINAL_FILE";
            this.gridColumn11.Name = "gridColumn11";
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
            // frmApproveRequestCheckVer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PQMS_STAFF_ApproveRequestCheckListGrid);
            this.Controls.Add(this.dgvUserRequestStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtApproveComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRequestContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtToBeApproved);
            this.Controls.Add(this.txtidxNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnEduReportGo);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.txtLoginID);
            this.Controls.Add(this.cmbApprover);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Name = "frmApproveRequestCheckVer2";
            this.Load += new System.EventHandler(this.frmApproveRequestCheckVer2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRequestStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_ApproveRequestCheckListGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PQMS_STAFF_ApproveRequestCheckListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_TEAMMainTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_NAMEMainTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_CODEMainTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_SCHOOLMainTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_MAJORMainTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFF_JOIN_DATEMainTextEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApproveComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRequestContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtToBeApproved;
        private System.Windows.Forms.TextBox txtidxNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEduReportGo;
        private System.Windows.Forms.DataGridView dgvUserRequestStatus;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.TextBox txtLoginID;
        private System.Windows.Forms.ComboBox cmbApprover;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.GridControl PQMS_STAFF_ApproveRequestCheckListGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PQMS_STAFF_ApproveRequestCheckListView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_TEAMMainTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_NAMEMainTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_CODEMainTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_SCHOOLMainTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_MAJORMainTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit STAFF_JOIN_DATEMainTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
    }
}