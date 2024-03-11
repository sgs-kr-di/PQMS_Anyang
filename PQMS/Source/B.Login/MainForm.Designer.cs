
namespace userManagement
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.user001ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.User0010001ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RequestStatus0010002ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserIdRequest0010003ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BaseCode002ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppMaster0020001ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountMaster0020002ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeptMaster0020004ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CodeMaster0020005ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMaster0020006ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Group003ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Group0030001ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupMember0030002ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Role004ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRole0040001ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApproveRole0040002ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtStaffID2 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.btnPwChangeCancel = new System.Windows.Forms.Button();
            this.btnPwChangeSubmit = new System.Windows.Forms.Button();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtOldpwd = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAccRequst = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPwChange = new System.Windows.Forms.Button();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.txtStaffPWD = new System.Windows.Forms.TextBox();
            this.txtStaffID = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRegCheck = new System.Windows.Forms.Label();
            this.btnRegCheckCancel = new System.Windows.Forms.Button();
            this.btnRegCheck = new System.Windows.Forms.Button();
            this.txtLogInId = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblLoginId = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.user001ToolStripMenuItem,
            this.BaseCode002ToolStripMenuItem,
            this.Group003ToolStripMenuItem,
            this.Role004ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(976, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // user001ToolStripMenuItem
            // 
            this.user001ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.User0010001ToolStripMenuItem,
            this.RequestStatus0010002ToolStripMenuItem,
            this.UserIdRequest0010003ToolStripMenuItem});
            this.user001ToolStripMenuItem.Name = "user001ToolStripMenuItem";
            this.user001ToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.user001ToolStripMenuItem.Text = "User";
            // 
            // User0010001ToolStripMenuItem
            // 
            this.User0010001ToolStripMenuItem.Name = "User0010001ToolStripMenuItem";
            this.User0010001ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.User0010001ToolStripMenuItem.Text = "User";
            this.User0010001ToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem1_Click);
            // 
            // RequestStatus0010002ToolStripMenuItem
            // 
            this.RequestStatus0010002ToolStripMenuItem.Name = "RequestStatus0010002ToolStripMenuItem";
            this.RequestStatus0010002ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.RequestStatus0010002ToolStripMenuItem.Text = "Request Status";
            this.RequestStatus0010002ToolStripMenuItem.Click += new System.EventHandler(this.requestStatusToolStripMenuItem_Click);
            // 
            // UserIdRequest0010003ToolStripMenuItem
            // 
            this.UserIdRequest0010003ToolStripMenuItem.Name = "UserIdRequest0010003ToolStripMenuItem";
            this.UserIdRequest0010003ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.UserIdRequest0010003ToolStripMenuItem.Text = "UserIdRequest";
            this.UserIdRequest0010003ToolStripMenuItem.Click += new System.EventHandler(this.userIdRequestToolStripMenuItem_Click);
            // 
            // BaseCode002ToolStripMenuItem
            // 
            this.BaseCode002ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AppMaster0020001ToolStripMenuItem,
            this.AccountMaster0020002ToolStripMenuItem,
            this.DeptMaster0020004ToolStripMenuItem,
            this.CodeMaster0020005ToolStripMenuItem,
            this.MenuMaster0020006ToolStripMenuItem});
            this.BaseCode002ToolStripMenuItem.Name = "BaseCode002ToolStripMenuItem";
            this.BaseCode002ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.BaseCode002ToolStripMenuItem.Text = "BaseCode";
            // 
            // AppMaster0020001ToolStripMenuItem
            // 
            this.AppMaster0020001ToolStripMenuItem.Name = "AppMaster0020001ToolStripMenuItem";
            this.AppMaster0020001ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.AppMaster0020001ToolStripMenuItem.Text = "App Master";
            this.AppMaster0020001ToolStripMenuItem.Click += new System.EventHandler(this.appMasterToolStripMenuItem_Click);
            // 
            // AccountMaster0020002ToolStripMenuItem
            // 
            this.AccountMaster0020002ToolStripMenuItem.Enabled = false;
            this.AccountMaster0020002ToolStripMenuItem.Name = "AccountMaster0020002ToolStripMenuItem";
            this.AccountMaster0020002ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.AccountMaster0020002ToolStripMenuItem.Text = "Account Master";
            this.AccountMaster0020002ToolStripMenuItem.Click += new System.EventHandler(this.accountToolStripMenuItem_Click);
            // 
            // DeptMaster0020004ToolStripMenuItem
            // 
            this.DeptMaster0020004ToolStripMenuItem.Name = "DeptMaster0020004ToolStripMenuItem";
            this.DeptMaster0020004ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.DeptMaster0020004ToolStripMenuItem.Text = "Dept Master";
            this.DeptMaster0020004ToolStripMenuItem.Click += new System.EventHandler(this.deptMasterToolStripMenuItem_Click);
            // 
            // CodeMaster0020005ToolStripMenuItem
            // 
            this.CodeMaster0020005ToolStripMenuItem.Name = "CodeMaster0020005ToolStripMenuItem";
            this.CodeMaster0020005ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.CodeMaster0020005ToolStripMenuItem.Text = "Code Master";
            this.CodeMaster0020005ToolStripMenuItem.Click += new System.EventHandler(this.codeMasterToolStripMenuItem_Click);
            // 
            // MenuMaster0020006ToolStripMenuItem
            // 
            this.MenuMaster0020006ToolStripMenuItem.Name = "MenuMaster0020006ToolStripMenuItem";
            this.MenuMaster0020006ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.MenuMaster0020006ToolStripMenuItem.Text = "Menu Master";
            this.MenuMaster0020006ToolStripMenuItem.Click += new System.EventHandler(this.menuMasterToolStripMenuItem_Click);
            // 
            // Group003ToolStripMenuItem
            // 
            this.Group003ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Group0030001ToolStripMenuItem,
            this.GroupMember0030002ToolStripMenuItem});
            this.Group003ToolStripMenuItem.Name = "Group003ToolStripMenuItem";
            this.Group003ToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.Group003ToolStripMenuItem.Text = "Group";
            // 
            // Group0030001ToolStripMenuItem
            // 
            this.Group0030001ToolStripMenuItem.Name = "Group0030001ToolStripMenuItem";
            this.Group0030001ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.Group0030001ToolStripMenuItem.Text = "Group";
            this.Group0030001ToolStripMenuItem.Click += new System.EventHandler(this.groupToolStripMenuItem1_Click);
            // 
            // GroupMember0030002ToolStripMenuItem
            // 
            this.GroupMember0030002ToolStripMenuItem.Name = "GroupMember0030002ToolStripMenuItem";
            this.GroupMember0030002ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.GroupMember0030002ToolStripMenuItem.Text = "Group Member";
            this.GroupMember0030002ToolStripMenuItem.Click += new System.EventHandler(this.groupMemberToolStripMenuItem_Click);
            // 
            // Role004ToolStripMenuItem
            // 
            this.Role004ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuRole0040001ToolStripMenuItem,
            this.ApproveRole0040002ToolStripMenuItem});
            this.Role004ToolStripMenuItem.Name = "Role004ToolStripMenuItem";
            this.Role004ToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.Role004ToolStripMenuItem.Text = "Role";
            // 
            // MenuRole0040001ToolStripMenuItem
            // 
            this.MenuRole0040001ToolStripMenuItem.Name = "MenuRole0040001ToolStripMenuItem";
            this.MenuRole0040001ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.MenuRole0040001ToolStripMenuItem.Text = "Menu Role";
            this.MenuRole0040001ToolStripMenuItem.Click += new System.EventHandler(this.menuRoleToolStripMenuItem_Click);
            // 
            // ApproveRole0040002ToolStripMenuItem
            // 
            this.ApproveRole0040002ToolStripMenuItem.Name = "ApproveRole0040002ToolStripMenuItem";
            this.ApproveRole0040002ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.ApproveRole0040002ToolStripMenuItem.Text = "Approve Role";
            this.ApproveRole0040002ToolStripMenuItem.Click += new System.EventHandler(this.approveRoleToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtStaffID2);
            this.panel2.Controls.Add(this.label55);
            this.panel2.Controls.Add(this.btnPwChangeCancel);
            this.panel2.Controls.Add(this.btnPwChangeSubmit);
            this.panel2.Controls.Add(this.txtNewPwd);
            this.panel2.Controls.Add(this.txtOldpwd);
            this.panel2.Controls.Add(this.label53);
            this.panel2.Controls.Add(this.label54);
            this.panel2.Location = new System.Drawing.Point(329, 244);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 181);
            this.panel2.TabIndex = 18;
            this.panel2.Visible = false;
            // 
            // txtStaffID2
            // 
            this.txtStaffID2.Location = new System.Drawing.Point(194, 19);
            this.txtStaffID2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtStaffID2.Name = "txtStaffID2";
            this.txtStaffID2.Size = new System.Drawing.Size(149, 20);
            this.txtStaffID2.TabIndex = 13;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(96, 25);
            this.label55.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(76, 13);
            this.label55.TabIndex = 12;
            this.label55.Text = "사용자아이디:";
            // 
            // btnPwChangeCancel
            // 
            this.btnPwChangeCancel.Location = new System.Drawing.Point(209, 109);
            this.btnPwChangeCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPwChangeCancel.Name = "btnPwChangeCancel";
            this.btnPwChangeCancel.Size = new System.Drawing.Size(103, 25);
            this.btnPwChangeCancel.TabIndex = 11;
            this.btnPwChangeCancel.Text = "취소";
            this.btnPwChangeCancel.UseVisualStyleBackColor = true;
            this.btnPwChangeCancel.Click += new System.EventHandler(this.btnPwChangeCancel_Click);
            // 
            // btnPwChangeSubmit
            // 
            this.btnPwChangeSubmit.Location = new System.Drawing.Point(98, 109);
            this.btnPwChangeSubmit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPwChangeSubmit.Name = "btnPwChangeSubmit";
            this.btnPwChangeSubmit.Size = new System.Drawing.Size(103, 25);
            this.btnPwChangeSubmit.TabIndex = 10;
            this.btnPwChangeSubmit.Text = "확인";
            this.btnPwChangeSubmit.UseVisualStyleBackColor = true;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(194, 71);
            this.txtNewPwd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(149, 20);
            this.txtNewPwd.TabIndex = 9;
            this.txtNewPwd.UseSystemPasswordChar = true;
            // 
            // txtOldpwd
            // 
            this.txtOldpwd.Location = new System.Drawing.Point(194, 45);
            this.txtOldpwd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOldpwd.Name = "txtOldpwd";
            this.txtOldpwd.Size = new System.Drawing.Size(149, 20);
            this.txtOldpwd.TabIndex = 8;
            this.txtOldpwd.UseSystemPasswordChar = true;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(96, 77);
            this.label53.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(87, 13);
            this.label53.TabIndex = 7;
            this.label53.Text = "변경후패스워드:";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(96, 51);
            this.label54.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(87, 13);
            this.label54.TabIndex = 6;
            this.label54.Text = "변경전패스워드:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAccRequst);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnPwChange);
            this.panel1.Controls.Add(this.btnLogIn);
            this.panel1.Controls.Add(this.txtStaffPWD);
            this.panel1.Controls.Add(this.txtStaffID);
            this.panel1.Controls.Add(this.label51);
            this.panel1.Controls.Add(this.label52);
            this.panel1.Location = new System.Drawing.Point(329, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 181);
            this.panel1.TabIndex = 17;
            // 
            // btnAccRequst
            // 
            this.btnAccRequst.Location = new System.Drawing.Point(275, 101);
            this.btnAccRequst.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAccRequst.Name = "btnAccRequst";
            this.btnAccRequst.Size = new System.Drawing.Size(103, 25);
            this.btnAccRequst.TabIndex = 13;
            this.btnAccRequst.Text = "계정신청";
            this.btnAccRequst.UseVisualStyleBackColor = true;
            this.btnAccRequst.Click += new System.EventHandler(this.btnAccRequst_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(107, 101);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 25);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPwChange
            // 
            this.btnPwChange.Location = new System.Drawing.Point(167, 101);
            this.btnPwChange.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPwChange.Name = "btnPwChange";
            this.btnPwChange.Size = new System.Drawing.Size(103, 25);
            this.btnPwChange.TabIndex = 11;
            this.btnPwChange.Text = "패스워드변경";
            this.btnPwChange.UseVisualStyleBackColor = true;
            this.btnPwChange.Click += new System.EventHandler(this.btnPwChange_Click);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(42, 100);
            this.btnLogIn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(55, 25);
            this.btnLogIn.TabIndex = 10;
            this.btnLogIn.Text = "로그인";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // txtStaffPWD
            // 
            this.txtStaffPWD.Location = new System.Drawing.Point(194, 62);
            this.txtStaffPWD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtStaffPWD.Name = "txtStaffPWD";
            this.txtStaffPWD.Size = new System.Drawing.Size(149, 20);
            this.txtStaffPWD.TabIndex = 9;
            this.txtStaffPWD.Text = "1234";
            this.txtStaffPWD.UseSystemPasswordChar = true;
            this.txtStaffPWD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStaffPWD_KeyPress);
            // 
            // txtStaffID
            // 
            this.txtStaffID.Location = new System.Drawing.Point(194, 36);
            this.txtStaffID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtStaffID.Name = "txtStaffID";
            this.txtStaffID.Size = new System.Drawing.Size(149, 20);
            this.txtStaffID.TabIndex = 8;
            this.txtStaffID.Text = "mike.jin@sgs.com";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(96, 68);
            this.label51.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(54, 13);
            this.label51.TabIndex = 7;
            this.label51.Text = "패스워드:";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(96, 42);
            this.label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(76, 13);
            this.label52.TabIndex = 6;
            this.label52.Text = "사용자아이디:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblRegCheck);
            this.panel3.Controls.Add(this.btnRegCheckCancel);
            this.panel3.Controls.Add(this.btnRegCheck);
            this.panel3.Controls.Add(this.txtLogInId);
            this.panel3.Controls.Add(this.txtUserId);
            this.panel3.Controls.Add(this.lblLoginId);
            this.panel3.Controls.Add(this.lblUserId);
            this.panel3.Location = new System.Drawing.Point(329, 433);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(453, 181);
            this.panel3.TabIndex = 19;
            this.panel3.Visible = false;
            // 
            // lblRegCheck
            // 
            this.lblRegCheck.AutoSize = true;
            this.lblRegCheck.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRegCheck.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblRegCheck.Location = new System.Drawing.Point(18, 16);
            this.lblRegCheck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegCheck.Name = "lblRegCheck";
            this.lblRegCheck.Size = new System.Drawing.Size(421, 16);
            this.lblRegCheck.TabIndex = 12;
            this.lblRegCheck.Text = "가입 여부 조회(아이디는 이메일 주소를 입력 하세요!)";
            // 
            // btnRegCheckCancel
            // 
            this.btnRegCheckCancel.Location = new System.Drawing.Point(209, 109);
            this.btnRegCheckCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRegCheckCancel.Name = "btnRegCheckCancel";
            this.btnRegCheckCancel.Size = new System.Drawing.Size(103, 25);
            this.btnRegCheckCancel.TabIndex = 11;
            this.btnRegCheckCancel.Text = "취소";
            this.btnRegCheckCancel.UseVisualStyleBackColor = true;
            this.btnRegCheckCancel.Click += new System.EventHandler(this.btnRegCheckCancel_Click);
            // 
            // btnRegCheck
            // 
            this.btnRegCheck.Location = new System.Drawing.Point(98, 109);
            this.btnRegCheck.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRegCheck.Name = "btnRegCheck";
            this.btnRegCheck.Size = new System.Drawing.Size(103, 25);
            this.btnRegCheck.TabIndex = 10;
            this.btnRegCheck.Text = "확인";
            this.btnRegCheck.UseVisualStyleBackColor = true;
            this.btnRegCheck.Click += new System.EventHandler(this.btnRegCheck_Click);
            // 
            // txtLogInId
            // 
            this.txtLogInId.Location = new System.Drawing.Point(140, 71);
            this.txtLogInId.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLogInId.Name = "txtLogInId";
            this.txtLogInId.Size = new System.Drawing.Size(202, 20);
            this.txtLogInId.TabIndex = 9;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(140, 45);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(202, 20);
            this.txtUserId.TabIndex = 8;
            this.txtUserId.Visible = false;
            // 
            // lblLoginId
            // 
            this.lblLoginId.AutoSize = true;
            this.lblLoginId.Location = new System.Drawing.Point(88, 77);
            this.lblLoginId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoginId.Name = "lblLoginId";
            this.lblLoginId.Size = new System.Drawing.Size(48, 13);
            this.lblLoginId.TabIndex = 7;
            this.lblLoginId.Text = "LogIn ID";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(92, 51);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(43, 13);
            this.lblUserId.TabIndex = 6;
            this.lblUserId.Text = "User ID";
            this.lblUserId.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 622);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem user001ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem User0010001ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BaseCode002ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Group003ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AccountMaster0020002ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeptMaster0020004ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AppMaster0020001ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Group0030001ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GroupMember0030002ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CodeMaster0020005ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RequestStatus0010002ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtStaffID2;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Button btnPwChangeCancel;
        private System.Windows.Forms.Button btnPwChangeSubmit;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtOldpwd;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAccRequst;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPwChange;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.TextBox txtStaffPWD;
        private System.Windows.Forms.TextBox txtStaffID;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRegCheckCancel;
        private System.Windows.Forms.Button btnRegCheck;
        private System.Windows.Forms.TextBox txtLogInId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblLoginId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblRegCheck;
        private System.Windows.Forms.ToolStripMenuItem MenuMaster0020006ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Role004ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuRole0040001ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ApproveRole0040002ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserIdRequest0010003ToolStripMenuItem;
    }
}

