namespace PQMS
{
    partial class frmWSsetup
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSiteCode = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbSiteCode = new System.Windows.Forms.ComboBox();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.cmbRepo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRepoName = new System.Windows.Forms.TextBox();
            this.txtRepoCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWSCode = new System.Windows.Forms.TextBox();
            this.txtWSName = new System.Windows.Forms.TextBox();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.txtFolderCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoardName = new System.Windows.Forms.TextBox();
            this.txtBoardCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtGroupCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSubGroupName = new System.Windows.Forms.TextBox();
            this.txtSubGroupCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.cmbWS = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.cmbFolder = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.cmbBoard = new System.Windows.Forms.ComboBox();
            this.button12 = new System.Windows.Forms.Button();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.button13 = new System.Windows.Forms.Button();
            this.cmbSubGroup = new System.Windows.Forms.ComboBox();
            this.trvItems = new System.Windows.Forms.TreeView();
            this.button15 = new System.Windows.Forms.Button();
            this.dgvOrg = new System.Windows.Forms.DataGridView();
            this.txtRowCnt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNodeName = new System.Windows.Forms.TextBox();
            this.txtNodeText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNodeLevel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button44 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Country :";
            // 
            // txtSiteCode
            // 
            this.txtSiteCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSiteCode.Location = new System.Drawing.Point(275, 146);
            this.txtSiteCode.Name = "txtSiteCode";
            this.txtSiteCode.Size = new System.Drawing.Size(95, 20);
            this.txtSiteCode.TabIndex = 33;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(327, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 25);
            this.button3.TabIndex = 32;
            this.button3.Text = "부서전체삭제";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 25);
            this.button2.TabIndex = 31;
            this.button2.Text = "부서이름수정";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 25);
            this.button1.TabIndex = 30;
            this.button1.Text = "부서신규입력";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbSiteCode
            // 
            this.cmbSiteCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbSiteCode.FormattingEnabled = true;
            this.cmbSiteCode.Location = new System.Drawing.Point(127, 146);
            this.cmbSiteCode.Name = "cmbSiteCode";
            this.cmbSiteCode.Size = new System.Drawing.Size(104, 21);
            this.cmbSiteCode.TabIndex = 36;
            this.cmbSiteCode.SelectedIndexChanged += new System.EventHandler(this.cmbSiteCode_SelectedIndexChanged);
            // 
            // txtSiteName
            // 
            this.txtSiteName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSiteName.Location = new System.Drawing.Point(374, 145);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(134, 20);
            this.txtSiteName.TabIndex = 33;
            // 
            // cmbRepo
            // 
            this.cmbRepo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbRepo.FormattingEnabled = true;
            this.cmbRepo.Location = new System.Drawing.Point(127, 176);
            this.cmbRepo.Name = "cmbRepo";
            this.cmbRepo.Size = new System.Drawing.Size(104, 21);
            this.cmbRepo.TabIndex = 40;
            this.cmbRepo.SelectedIndexChanged += new System.EventHandler(this.cmbRepo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "City :";
            // 
            // txtRepoName
            // 
            this.txtRepoName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRepoName.Location = new System.Drawing.Point(374, 175);
            this.txtRepoName.Name = "txtRepoName";
            this.txtRepoName.Size = new System.Drawing.Size(134, 20);
            this.txtRepoName.TabIndex = 37;
            // 
            // txtRepoCode
            // 
            this.txtRepoCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRepoCode.Location = new System.Drawing.Point(275, 176);
            this.txtRepoCode.Name = "txtRepoCode";
            this.txtRepoCode.Size = new System.Drawing.Size(95, 20);
            this.txtRepoCode.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "1차부서 :";
            // 
            // txtWSCode
            // 
            this.txtWSCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtWSCode.Location = new System.Drawing.Point(275, 204);
            this.txtWSCode.Name = "txtWSCode";
            this.txtWSCode.Size = new System.Drawing.Size(95, 20);
            this.txtWSCode.TabIndex = 42;
            this.txtWSCode.TextChanged += new System.EventHandler(this.txtWPCode_TextChanged);
            // 
            // txtWSName
            // 
            this.txtWSName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtWSName.Location = new System.Drawing.Point(374, 204);
            this.txtWSName.Name = "txtWSName";
            this.txtWSName.Size = new System.Drawing.Size(134, 20);
            this.txtWSName.TabIndex = 44;
            this.txtWSName.TextChanged += new System.EventHandler(this.txtWSName_TextChanged);
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(374, 230);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(134, 20);
            this.txtFolderName.TabIndex = 48;
            this.txtFolderName.TextChanged += new System.EventHandler(this.txtFolderName_TextChanged);
            // 
            // txtFolderCode
            // 
            this.txtFolderCode.Location = new System.Drawing.Point(275, 230);
            this.txtFolderCode.Name = "txtFolderCode";
            this.txtFolderCode.Size = new System.Drawing.Size(95, 20);
            this.txtFolderCode.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "2차부서 :";
            // 
            // txtBoardName
            // 
            this.txtBoardName.Location = new System.Drawing.Point(374, 258);
            this.txtBoardName.Name = "txtBoardName";
            this.txtBoardName.Size = new System.Drawing.Size(134, 20);
            this.txtBoardName.TabIndex = 52;
            this.txtBoardName.TextChanged += new System.EventHandler(this.txtBoardName_TextChanged);
            // 
            // txtBoardCode
            // 
            this.txtBoardCode.Location = new System.Drawing.Point(275, 258);
            this.txtBoardCode.Name = "txtBoardCode";
            this.txtBoardCode.Size = new System.Drawing.Size(95, 20);
            this.txtBoardCode.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "3차 부서 :";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(374, 287);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(134, 20);
            this.txtGroupName.TabIndex = 56;
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.Location = new System.Drawing.Point(275, 287);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(95, 20);
            this.txtGroupCode.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 301);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "4차 부서 :";
            // 
            // txtSubGroupName
            // 
            this.txtSubGroupName.Location = new System.Drawing.Point(374, 317);
            this.txtSubGroupName.Name = "txtSubGroupName";
            this.txtSubGroupName.Size = new System.Drawing.Size(134, 20);
            this.txtSubGroupName.TabIndex = 60;
            this.txtSubGroupName.TextChanged += new System.EventHandler(this.txtSubGroupName_TextChanged);
            // 
            // txtSubGroupCode
            // 
            this.txtSubGroupCode.Location = new System.Drawing.Point(275, 317);
            this.txtSubGroupCode.Name = "txtSubGroupCode";
            this.txtSubGroupCode.Size = new System.Drawing.Size(95, 20);
            this.txtSubGroupCode.TabIndex = 58;
            this.txtSubGroupCode.TextChanged += new System.EventHandler(this.txtSubGroupCode_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 331);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "5차 부서 :";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(236, 148);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(24, 23);
            this.button7.TabIndex = 62;
            this.button7.Text = "S";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(236, 175);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(23, 22);
            this.button8.TabIndex = 63;
            this.button8.Text = "S";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(236, 203);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(23, 22);
            this.button9.TabIndex = 65;
            this.button9.Text = "S";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // cmbWS
            // 
            this.cmbWS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbWS.FormattingEnabled = true;
            this.cmbWS.Location = new System.Drawing.Point(127, 204);
            this.cmbWS.Name = "cmbWS";
            this.cmbWS.Size = new System.Drawing.Size(104, 21);
            this.cmbWS.TabIndex = 64;
            this.cmbWS.SelectedIndexChanged += new System.EventHandler(this.cmbWS_SelectedIndexChanged);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(236, 231);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(23, 22);
            this.button10.TabIndex = 67;
            this.button10.Text = "S";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // cmbFolder
            // 
            this.cmbFolder.FormattingEnabled = true;
            this.cmbFolder.Location = new System.Drawing.Point(127, 232);
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(104, 21);
            this.cmbFolder.TabIndex = 66;
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(236, 259);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(23, 22);
            this.button11.TabIndex = 69;
            this.button11.Text = "S";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // cmbBoard
            // 
            this.cmbBoard.FormattingEnabled = true;
            this.cmbBoard.Location = new System.Drawing.Point(127, 260);
            this.cmbBoard.Name = "cmbBoard";
            this.cmbBoard.Size = new System.Drawing.Size(104, 21);
            this.cmbBoard.TabIndex = 68;
            this.cmbBoard.SelectedIndexChanged += new System.EventHandler(this.cmbBoard_SelectedIndexChanged);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(236, 287);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(23, 22);
            this.button12.TabIndex = 71;
            this.button12.Text = "S";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // cmbGroup
            // 
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(127, 288);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(104, 21);
            this.cmbGroup.TabIndex = 70;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(236, 321);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(23, 22);
            this.button13.TabIndex = 73;
            this.button13.Text = "S";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // cmbSubGroup
            // 
            this.cmbSubGroup.FormattingEnabled = true;
            this.cmbSubGroup.Location = new System.Drawing.Point(127, 322);
            this.cmbSubGroup.Name = "cmbSubGroup";
            this.cmbSubGroup.Size = new System.Drawing.Size(104, 21);
            this.cmbSubGroup.TabIndex = 72;
            this.cmbSubGroup.SelectedIndexChanged += new System.EventHandler(this.cmbSubGroup_SelectedIndexChanged);
            // 
            // trvItems
            // 
            this.trvItems.Location = new System.Drawing.Point(23, 391);
            this.trvItems.Name = "trvItems";
            this.trvItems.Size = new System.Drawing.Size(493, 217);
            this.trvItems.TabIndex = 240;
            this.trvItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvItems_AfterSelect);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(26, 360);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(94, 25);
            this.button15.TabIndex = 241;
            this.button15.Text = "Tree 조회";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // dgvOrg
            // 
            this.dgvOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrg.Location = new System.Drawing.Point(532, 145);
            this.dgvOrg.Name = "dgvOrg";
            this.dgvOrg.RowTemplate.Height = 24;
            this.dgvOrg.Size = new System.Drawing.Size(594, 284);
            this.dgvOrg.TabIndex = 242;
            // 
            // txtRowCnt
            // 
            this.txtRowCnt.Location = new System.Drawing.Point(374, 360);
            this.txtRowCnt.Name = "txtRowCnt";
            this.txtRowCnt.Size = new System.Drawing.Size(77, 20);
            this.txtRowCnt.TabIndex = 243;
            this.txtRowCnt.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(537, 438);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 244;
            this.label4.Text = "Node Name :";
            // 
            // txtNodeName
            // 
            this.txtNodeName.Location = new System.Drawing.Point(612, 435);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(120, 20);
            this.txtNodeName.TabIndex = 245;
            // 
            // txtNodeText
            // 
            this.txtNodeText.Location = new System.Drawing.Point(612, 464);
            this.txtNodeText.Name = "txtNodeText";
            this.txtNodeText.Size = new System.Drawing.Size(120, 20);
            this.txtNodeText.TabIndex = 247;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 467);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 246;
            this.label5.Text = "Node Text :";
            // 
            // txtNodeLevel
            // 
            this.txtNodeLevel.Location = new System.Drawing.Point(612, 493);
            this.txtNodeLevel.Name = "txtNodeLevel";
            this.txtNodeLevel.Size = new System.Drawing.Size(120, 20);
            this.txtNodeLevel.TabIndex = 249;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(537, 497);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 248;
            this.label9.Text = "Node Level :";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.*";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button44
            // 
            this.button44.Location = new System.Drawing.Point(250, 88);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(62, 25);
            this.button44.TabIndex = 250;
            this.button44.Text = "부서삭제";
            this.button44.UseVisualStyleBackColor = true;
            this.button44.Click += new System.EventHandler(this.button44_Click);
            // 
            // frmWSsetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 641);
            this.Controls.Add(this.button44);
            this.Controls.Add(this.txtNodeLevel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNodeText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNodeName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRowCnt);
            this.Controls.Add(this.dgvOrg);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.trvItems);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.cmbSubGroup);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.cmbBoard);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.cmbFolder);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.cmbWS);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.txtSubGroupName);
            this.Controls.Add(this.txtSubGroupCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.txtGroupCode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBoardName);
            this.Controls.Add(this.txtBoardCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.txtFolderCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtWSName);
            this.Controls.Add(this.txtWSCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRepo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRepoName);
            this.Controls.Add(this.txtRepoCode);
            this.Controls.Add(this.cmbSiteCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.txtSiteCode);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmWSsetup";
            this.Text = "WorkSpace 관리 - frmWSsetup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSiteCode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbSiteCode;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.ComboBox cmbRepo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRepoName;
        private System.Windows.Forms.TextBox txtRepoCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWSCode;
        private System.Windows.Forms.TextBox txtWSName;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.TextBox txtFolderCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoardName;
        private System.Windows.Forms.TextBox txtBoardCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtGroupCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSubGroupName;
        private System.Windows.Forms.TextBox txtSubGroupCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox cmbWS;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox cmbFolder;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox cmbBoard;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ComboBox cmbSubGroup;
        private System.Windows.Forms.TreeView trvItems;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.DataGridView dgvOrg;
        private System.Windows.Forms.TextBox txtRowCnt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.TextBox txtNodeText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNodeLevel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button44;
    }
}