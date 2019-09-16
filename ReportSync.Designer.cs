﻿namespace ReportSync
{
    partial class ReportSync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportSync));
            this.btnSourceLoad = new System.Windows.Forms.Button();
            this.rptSourceTree = new System.Windows.Forms.TreeView();
            this.btnDownload = new System.Windows.Forms.Button();
            this.dlgDest = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDest = new System.Windows.Forms.Button();
            this.btnDestLoad = new System.Windows.Forms.Button();
            this.rptDestTree = new System.Windows.Forms.TreeView();
            this.btnSync = new System.Windows.Forms.Button();
            this.lblDestPass = new System.Windows.Forms.Label();
            this.lblDestUser = new System.Windows.Forms.Label();
            this.lblDestUrl = new System.Windows.Forms.Label();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSrcUrl = new System.Windows.Forms.Label();
            this.chkSaveSource = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSourcePassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourceUser = new System.Windows.Forms.TextBox();
            this.txtSourceUrl = new System.Windows.Forms.TextBox();
            this.pbSource = new System.Windows.Forms.ProgressBar();
            this.grpDest = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkSaveDest = new System.Windows.Forms.CheckBox();
            this.txtDestUrl = new System.Windows.Forms.TextBox();
            this.txtDestPassword = new System.Windows.Forms.TextBox();
            this.txtDestUser = new System.Windows.Forms.TextBox();
            this.pbDest = new System.Windows.Forms.ProgressBar();
            this.lblDest = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtLocalPath = new System.Windows.Forms.TextBox();
            this.bwDownload = new System.ComponentModel.BackgroundWorker();
            this.bwUpload = new System.ComponentModel.BackgroundWorker();
            this.bwSync = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpSync = new System.Windows.Forms.GroupBox();
            this.radConn = new System.Windows.Forms.RadioButton();
            this.btnUpdateConn = new System.Windows.Forms.Button();
            this.radSync = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpConn = new System.Windows.Forms.GroupBox();
            this.cmbRptDSName = new System.Windows.Forms.ComboBox();
            this.btnLoadDSNames = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRptDsPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRptUserName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapDataSourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutReportSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.bwUpdateConn = new System.ComponentModel.BackgroundWorker();
            this.convertRdlTo2012ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopySrcCredentials = new System.Windows.Forms.Button();
            this.grpSource.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpDest.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpSync.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpConn.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSourceLoad
            // 
            this.btnSourceLoad.Location = new System.Drawing.Point(173, 55);
            this.btnSourceLoad.Name = "btnSourceLoad";
            this.btnSourceLoad.Size = new System.Drawing.Size(55, 20);
            this.btnSourceLoad.TabIndex = 4;
            this.btnSourceLoad.Text = "Load";
            this.btnSourceLoad.UseVisualStyleBackColor = true;
            this.btnSourceLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // rptSourceTree
            // 
            this.rptSourceTree.CheckBoxes = true;
            this.rptSourceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptSourceTree.Location = new System.Drawing.Point(3, 101);
            this.rptSourceTree.Name = "rptSourceTree";
            this.rptSourceTree.Size = new System.Drawing.Size(284, 336);
            this.rptSourceTree.TabIndex = 5;
            this.rptSourceTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.rptSourceTree_AfterCheck);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(301, 14);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(65, 21);
            this.btnDownload.TabIndex = 7;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDest
            // 
            this.btnDest.Location = new System.Drawing.Point(268, 14);
            this.btnDest.Name = "btnDest";
            this.btnDest.Size = new System.Drawing.Size(24, 21);
            this.btnDest.TabIndex = 6;
            this.btnDest.Text = "...";
            this.btnDest.UseVisualStyleBackColor = true;
            this.btnDest.Click += new System.EventHandler(this.btnDest_Click);
            // 
            // btnDestLoad
            // 
            this.btnDestLoad.Location = new System.Drawing.Point(170, 55);
            this.btnDestLoad.Name = "btnDestLoad";
            this.btnDestLoad.Size = new System.Drawing.Size(57, 20);
            this.btnDestLoad.TabIndex = 11;
            this.btnDestLoad.Text = "Load";
            this.btnDestLoad.UseVisualStyleBackColor = true;
            this.btnDestLoad.Click += new System.EventHandler(this.btnDestLoad_Click);
            // 
            // rptDestTree
            // 
            this.rptDestTree.CheckBoxes = true;
            this.rptDestTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptDestTree.Location = new System.Drawing.Point(3, 101);
            this.rptDestTree.Name = "rptDestTree";
            this.rptDestTree.Size = new System.Drawing.Size(285, 336);
            this.rptDestTree.TabIndex = 13;
            this.rptDestTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.rptDestTree_AfterCheck);
            this.rptDestTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.rptDestTree_NodeMouseClick);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(433, 14);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(41, 21);
            this.btnSync.TabIndex = 13;
            this.btnSync.Text = "&Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // lblDestPass
            // 
            this.lblDestPass.AutoSize = true;
            this.lblDestPass.Location = new System.Drawing.Point(3, 59);
            this.lblDestPass.Name = "lblDestPass";
            this.lblDestPass.Size = new System.Drawing.Size(53, 13);
            this.lblDestPass.TabIndex = 16;
            this.lblDestPass.Text = "Password";
            // 
            // lblDestUser
            // 
            this.lblDestUser.AutoSize = true;
            this.lblDestUser.Location = new System.Drawing.Point(3, 33);
            this.lblDestUser.Name = "lblDestUser";
            this.lblDestUser.Size = new System.Drawing.Size(29, 13);
            this.lblDestUser.TabIndex = 17;
            this.lblDestUser.Text = "User";
            // 
            // lblDestUrl
            // 
            this.lblDestUrl.AutoSize = true;
            this.lblDestUrl.Location = new System.Drawing.Point(3, 7);
            this.lblDestUrl.Name = "lblDestUrl";
            this.lblDestUrl.Size = new System.Drawing.Size(20, 13);
            this.lblDestUrl.TabIndex = 18;
            this.lblDestUrl.Text = "Url";
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.rptSourceTree);
            this.grpSource.Controls.Add(this.panel2);
            this.grpSource.Controls.Add(this.pbSource);
            this.grpSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSource.Location = new System.Drawing.Point(0, 0);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(290, 463);
            this.grpSource.TabIndex = 19;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source SSRS web service";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCopySrcCredentials);
            this.panel2.Controls.Add(this.lblSrcUrl);
            this.panel2.Controls.Add(this.chkSaveSource);
            this.panel2.Controls.Add(this.btnSourceLoad);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtSourcePassword);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtSourceUser);
            this.panel2.Controls.Add(this.txtSourceUrl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 85);
            this.panel2.TabIndex = 23;
            // 
            // lblSrcUrl
            // 
            this.lblSrcUrl.AutoSize = true;
            this.lblSrcUrl.Location = new System.Drawing.Point(6, 7);
            this.lblSrcUrl.Name = "lblSrcUrl";
            this.lblSrcUrl.Size = new System.Drawing.Size(20, 13);
            this.lblSrcUrl.TabIndex = 19;
            this.lblSrcUrl.Text = "Url";
            // 
            // chkSaveSource
            // 
            this.chkSaveSource.AutoSize = true;
            this.chkSaveSource.Checked = true;
            this.chkSaveSource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveSource.Location = new System.Drawing.Point(174, 32);
            this.chkSaveSource.Name = "chkSaveSource";
            this.chkSaveSource.Size = new System.Drawing.Size(51, 17);
            this.chkSaveSource.TabIndex = 22;
            this.chkSaveSource.Text = "Save";
            this.chkSaveSource.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Password";
            // 
            // txtSourcePassword
            // 
            this.txtSourcePassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourcePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSourcePassword.Location = new System.Drawing.Point(67, 55);
            this.txtSourcePassword.Name = "txtSourcePassword";
            this.txtSourcePassword.PasswordChar = '*';
            this.txtSourcePassword.Size = new System.Drawing.Size(100, 20);
            this.txtSourcePassword.TabIndex = 3;
            this.txtSourcePassword.Text = global::ReportSync.Properties.Settings.Default.SourcePassword;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "User";
            // 
            // txtSourceUser
            // 
            this.txtSourceUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourceUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSourceUser.Location = new System.Drawing.Point(67, 29);
            this.txtSourceUser.Name = "txtSourceUser";
            this.txtSourceUser.Size = new System.Drawing.Size(100, 20);
            this.txtSourceUser.TabIndex = 2;
            this.txtSourceUser.Text = global::ReportSync.Properties.Settings.Default.SourceUser;
            // 
            // txtSourceUrl
            // 
            this.txtSourceUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourceUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSourceUrl.Location = new System.Drawing.Point(35, 4);
            this.txtSourceUrl.Name = "txtSourceUrl";
            this.txtSourceUrl.Size = new System.Drawing.Size(193, 20);
            this.txtSourceUrl.TabIndex = 1;
            this.txtSourceUrl.Text = global::ReportSync.Properties.Settings.Default.SourceUrl;
            // 
            // pbSource
            // 
            this.pbSource.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbSource.Location = new System.Drawing.Point(3, 437);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(284, 23);
            this.pbSource.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbSource.TabIndex = 22;
            // 
            // grpDest
            // 
            this.grpDest.Controls.Add(this.rptDestTree);
            this.grpDest.Controls.Add(this.panel3);
            this.grpDest.Controls.Add(this.pbDest);
            this.grpDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDest.Location = new System.Drawing.Point(0, 0);
            this.grpDest.Name = "grpDest";
            this.grpDest.Size = new System.Drawing.Size(291, 463);
            this.grpDest.TabIndex = 29;
            this.grpDest.TabStop = false;
            this.grpDest.Text = "Destination SSRS web service";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblDestUrl);
            this.panel3.Controls.Add(this.chkSaveDest);
            this.panel3.Controls.Add(this.btnDestLoad);
            this.panel3.Controls.Add(this.lblDestPass);
            this.panel3.Controls.Add(this.txtDestUrl);
            this.panel3.Controls.Add(this.txtDestPassword);
            this.panel3.Controls.Add(this.txtDestUser);
            this.panel3.Controls.Add(this.lblDestUser);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 85);
            this.panel3.TabIndex = 24;
            // 
            // chkSaveDest
            // 
            this.chkSaveDest.AutoSize = true;
            this.chkSaveDest.Checked = true;
            this.chkSaveDest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveDest.Location = new System.Drawing.Point(174, 32);
            this.chkSaveDest.Name = "chkSaveDest";
            this.chkSaveDest.Size = new System.Drawing.Size(51, 17);
            this.chkSaveDest.TabIndex = 22;
            this.chkSaveDest.Text = "Save";
            this.chkSaveDest.UseVisualStyleBackColor = true;
            // 
            // txtDestUrl
            // 
            this.txtDestUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "DestUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDestUrl.Location = new System.Drawing.Point(27, 4);
            this.txtDestUrl.Name = "txtDestUrl";
            this.txtDestUrl.Size = new System.Drawing.Size(200, 20);
            this.txtDestUrl.TabIndex = 8;
            this.txtDestUrl.Text = global::ReportSync.Properties.Settings.Default.DestUrl;
            // 
            // txtDestPassword
            // 
            this.txtDestPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "DestPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDestPassword.Location = new System.Drawing.Point(65, 55);
            this.txtDestPassword.Name = "txtDestPassword";
            this.txtDestPassword.PasswordChar = '*';
            this.txtDestPassword.Size = new System.Drawing.Size(100, 20);
            this.txtDestPassword.TabIndex = 10;
            this.txtDestPassword.Text = global::ReportSync.Properties.Settings.Default.DestPassword;
            // 
            // txtDestUser
            // 
            this.txtDestUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "DestUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDestUser.Location = new System.Drawing.Point(65, 30);
            this.txtDestUser.Name = "txtDestUser";
            this.txtDestUser.Size = new System.Drawing.Size(100, 20);
            this.txtDestUser.TabIndex = 9;
            this.txtDestUser.Text = global::ReportSync.Properties.Settings.Default.DestUser;
            // 
            // pbDest
            // 
            this.pbDest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbDest.Location = new System.Drawing.Point(3, 437);
            this.pbDest.Name = "pbDest";
            this.pbDest.Size = new System.Drawing.Size(285, 23);
            this.pbDest.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbDest.TabIndex = 23;
            // 
            // lblDest
            // 
            this.lblDest.AutoSize = true;
            this.lblDest.Location = new System.Drawing.Point(1, 17);
            this.lblDest.Name = "lblDest";
            this.lblDest.Size = new System.Drawing.Size(57, 13);
            this.lblDest.TabIndex = 21;
            this.lblDest.Text = "Local path";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(372, 14);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(55, 21);
            this.btnUpload.TabIndex = 12;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "LocalPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLocalPath.Location = new System.Drawing.Point(62, 14);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(197, 20);
            this.txtLocalPath.TabIndex = 5;
            this.txtLocalPath.Text = global::ReportSync.Properties.Settings.Default.LocalPath;
            // 
            // bwDownload
            // 
            this.bwDownload.WorkerReportsProgress = true;
            // 
            // bwUpload
            // 
            this.bwUpload.WorkerReportsProgress = true;
            // 
            // bwSync
            // 
            this.bwSync.WorkerReportsProgress = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpSync);
            this.panel1.Controls.Add(this.radConn);
            this.panel1.Controls.Add(this.btnUpdateConn);
            this.panel1.Controls.Add(this.radSync);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 487);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 90);
            this.panel1.TabIndex = 22;
            // 
            // grpSync
            // 
            this.grpSync.Controls.Add(this.btnDownload);
            this.grpSync.Controls.Add(this.btnDest);
            this.grpSync.Controls.Add(this.btnSync);
            this.grpSync.Controls.Add(this.lblDest);
            this.grpSync.Controls.Add(this.btnUpload);
            this.grpSync.Controls.Add(this.txtLocalPath);
            this.grpSync.Location = new System.Drawing.Point(97, 6);
            this.grpSync.Name = "grpSync";
            this.grpSync.Size = new System.Drawing.Size(476, 41);
            this.grpSync.TabIndex = 20;
            this.grpSync.TabStop = false;
            // 
            // radConn
            // 
            this.radConn.AutoSize = true;
            this.radConn.Location = new System.Drawing.Point(12, 56);
            this.radConn.Name = "radConn";
            this.radConn.Size = new System.Drawing.Size(88, 17);
            this.radConn.TabIndex = 23;
            this.radConn.TabStop = true;
            this.radConn.Text = "Update Conn";
            this.radConn.UseVisualStyleBackColor = true;
            this.radConn.CheckedChanged += new System.EventHandler(this.radConn_CheckedChanged);
            // 
            // btnUpdateConn
            // 
            this.btnUpdateConn.Enabled = false;
            this.btnUpdateConn.Location = new System.Drawing.Point(434, 56);
            this.btnUpdateConn.Name = "btnUpdateConn";
            this.btnUpdateConn.Size = new System.Drawing.Size(138, 23);
            this.btnUpdateConn.TabIndex = 26;
            this.btnUpdateConn.Text = "Update Connections";
            this.btnUpdateConn.UseVisualStyleBackColor = true;
            this.btnUpdateConn.Click += new System.EventHandler(this.btnUpdateConn_Click);
            // 
            // radSync
            // 
            this.radSync.AutoSize = true;
            this.radSync.Checked = true;
            this.radSync.Location = new System.Drawing.Point(13, 21);
            this.radSync.Name = "radSync";
            this.radSync.Size = new System.Drawing.Size(49, 17);
            this.radSync.TabIndex = 22;
            this.radSync.TabStop = true;
            this.radSync.Text = "Sync";
            this.radSync.UseVisualStyleBackColor = true;
            this.radSync.CheckedChanged += new System.EventHandler(this.radSync_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpConn);
            this.splitContainer1.Panel2.Controls.Add(this.grpDest);
            this.splitContainer1.Size = new System.Drawing.Size(585, 463);
            this.splitContainer1.SplitterDistance = 290;
            this.splitContainer1.TabIndex = 23;
            // 
            // grpConn
            // 
            this.grpConn.Controls.Add(this.cmbRptDSName);
            this.grpConn.Controls.Add(this.btnLoadDSNames);
            this.grpConn.Controls.Add(this.label5);
            this.grpConn.Controls.Add(this.label4);
            this.grpConn.Controls.Add(this.txtRptDsPwd);
            this.grpConn.Controls.Add(this.label3);
            this.grpConn.Controls.Add(this.txtRptUserName);
            this.grpConn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConn.Location = new System.Drawing.Point(0, 0);
            this.grpConn.Name = "grpConn";
            this.grpConn.Size = new System.Drawing.Size(291, 463);
            this.grpConn.TabIndex = 29;
            this.grpConn.TabStop = false;
            this.grpConn.Text = "Update Connections";
            this.grpConn.Visible = false;
            // 
            // cmbRptDSName
            // 
            this.cmbRptDSName.FormattingEnabled = true;
            this.cmbRptDSName.Location = new System.Drawing.Point(49, 122);
            this.cmbRptDSName.Name = "cmbRptDSName";
            this.cmbRptDSName.Size = new System.Drawing.Size(179, 21);
            this.cmbRptDSName.TabIndex = 33;
            // 
            // btnLoadDSNames
            // 
            this.btnLoadDSNames.Location = new System.Drawing.Point(234, 120);
            this.btnLoadDSNames.Name = "btnLoadDSNames";
            this.btnLoadDSNames.Size = new System.Drawing.Size(39, 23);
            this.btnLoadDSNames.TabIndex = 32;
            this.btnLoadDSNames.Text = "Load Ds Names";
            this.btnLoadDSNames.UseVisualStyleBackColor = true;
            this.btnLoadDSNames.Visible = false;
            this.btnLoadDSNames.Click += new System.EventHandler(this.btnLoadDSNames_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Data Source Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Password";
            // 
            // txtRptDsPwd
            // 
            this.txtRptDsPwd.Location = new System.Drawing.Point(51, 201);
            this.txtRptDsPwd.Name = "txtRptDsPwd";
            this.txtRptDsPwd.Size = new System.Drawing.Size(177, 20);
            this.txtRptDsPwd.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Username";
            // 
            // txtRptUserName
            // 
            this.txtRptUserName.Location = new System.Drawing.Point(51, 162);
            this.txtRptUserName.Name = "txtRptUserName";
            this.txtRptUserName.Size = new System.Drawing.Size(177, 20);
            this.txtRptUserName.TabIndex = 25;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(111, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapDataSourcesToolStripMenuItem,
            this.convertRdlTo2012ToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // mapDataSourcesToolStripMenuItem
            // 
            this.mapDataSourcesToolStripMenuItem.Name = "mapDataSourcesToolStripMenuItem";
            this.mapDataSourcesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mapDataSourcesToolStripMenuItem.Text = "Map DataSources";
            this.mapDataSourcesToolStripMenuItem.Click += new System.EventHandler(this.mapDataSourcesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.aboutReportSyncToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.contentsToolStripMenuItem.Text = "Contents (Online)";
            this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
            // 
            // aboutReportSyncToolStripMenuItem
            // 
            this.aboutReportSyncToolStripMenuItem.Name = "aboutReportSyncToolStripMenuItem";
            this.aboutReportSyncToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.aboutReportSyncToolStripMenuItem.Text = "About ReportSync";
            this.aboutReportSyncToolStripMenuItem.Click += new System.EventHandler(this.aboutReportSyncToolStripMenuItem_Click);
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.FileName = "ReportSync.rsn";
            this.dlgSaveFile.Filter = "ReportSync Files | *.rsn";
            this.dlgSaveFile.Title = "Save ReportSync selection";
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "ReportSync.rsn";
            this.dlgOpenFile.Filter = "ReportSync Files | *.rsn";
            this.dlgOpenFile.Title = "Open ReportSync file";
            // 
            // bwUpdateConn
            // 
            this.bwUpdateConn.WorkerReportsProgress = true;
            // 
            // convertRdlTo2012ToolStripMenuItem
            // 
            this.convertRdlTo2012ToolStripMenuItem.Name = "convertRdlTo2012ToolStripMenuItem";
            this.convertRdlTo2012ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.convertRdlTo2012ToolStripMenuItem.Text = "Convert rdl to 2012";
            this.convertRdlTo2012ToolStripMenuItem.Click += new System.EventHandler(this.convertRdlTo2012ToolStripMenuItem_Click);
            // 
            // btnCopySrcCredentials
            // 
            this.btnCopySrcCredentials.Image = global::ReportSync.Properties.Resources.rightarrow;
            this.btnCopySrcCredentials.Location = new System.Drawing.Point(248, 18);
            this.btnCopySrcCredentials.Name = "btnCopySrcCredentials";
            this.btnCopySrcCredentials.Size = new System.Drawing.Size(23, 42);
            this.btnCopySrcCredentials.TabIndex = 23;
            this.btnCopySrcCredentials.UseVisualStyleBackColor = true;
            this.btnCopySrcCredentials.Click += new System.EventHandler(this.btnCopySrcCredentials_Click);
            // 
            // ReportSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 577);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReportSync";
            this.Text = "ReportSync";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportSync_FormClosed);
            this.grpSource.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpDest.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpSync.ResumeLayout(false);
            this.grpSync.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grpConn.ResumeLayout(false);
            this.grpConn.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceUrl;
        private System.Windows.Forms.Button btnSourceLoad;
        private System.Windows.Forms.TextBox txtSourceUser;
        private System.Windows.Forms.TextBox txtSourcePassword;
        private System.Windows.Forms.TreeView rptSourceTree;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.FolderBrowserDialog dlgDest;
        private System.Windows.Forms.TextBox txtLocalPath;
        private System.Windows.Forms.Button btnDest;
        private System.Windows.Forms.TextBox txtDestUrl;
        private System.Windows.Forms.TextBox txtDestUser;
        private System.Windows.Forms.TextBox txtDestPassword;
        private System.Windows.Forms.Button btnDestLoad;
        private System.Windows.Forms.TreeView rptDestTree;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Label lblDestPass;
        private System.Windows.Forms.Label lblDestUser;
        private System.Windows.Forms.Label lblDestUrl;
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.Label lblSrcUrl;
        private System.Windows.Forms.GroupBox grpDest;
        private System.Windows.Forms.Label lblDest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.CheckBox chkSaveSource;
        private System.Windows.Forms.CheckBox chkSaveDest;
        private System.Windows.Forms.ProgressBar pbSource;
        private System.Windows.Forms.ProgressBar pbDest;
        private System.ComponentModel.BackgroundWorker bwDownload;
        private System.ComponentModel.BackgroundWorker bwUpload;
        private System.ComponentModel.BackgroundWorker bwSync;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutReportSyncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapDataSourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.RadioButton radConn;
        private System.Windows.Forms.RadioButton radSync;
        private System.Windows.Forms.GroupBox grpConn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateConn;
        private System.Windows.Forms.TextBox txtRptDsPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRptUserName;
        private System.Windows.Forms.GroupBox grpSync;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker bwUpdateConn;
        private System.Windows.Forms.Button btnLoadDSNames;
        private System.Windows.Forms.ComboBox cmbRptDSName;
        private System.Windows.Forms.Button btnCopySrcCredentials;
        private System.Windows.Forms.ToolStripMenuItem convertRdlTo2012ToolStripMenuItem;
    }
}

