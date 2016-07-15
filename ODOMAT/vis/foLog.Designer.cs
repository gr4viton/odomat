namespace vis {
    partial class foLog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.spcLog = new System.Windows.Forms.SplitContainer();
            this.tbLog = new System.Windows.Forms.TabControl();
            this.tpText = new System.Windows.Forms.TabPage();
            this.txLog = new System.Windows.Forms.TextBox();
            this.tpDGV = new System.Windows.Forms.TabPage();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.tpConfig = new System.Windows.Forms.TabPage();
            this.gbSave = new System.Windows.Forms.GroupBox();
            this.gbCSVfile = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txCsvFormat = new System.Windows.Forms.TextBox();
            this.lbCsvFormat = new System.Windows.Forms.Label();
            this.pnCsvPath = new System.Windows.Forms.Panel();
            this.txCsvPath = new System.Windows.Forms.TextBox();
            this.btnCsvPathChange = new System.Windows.Forms.Button();
            this.gbInsert = new System.Windows.Forms.GroupBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txInsert = new System.Windows.Forms.TextBox();
            this.cbIgnoreMessages = new System.Windows.Forms.CheckBox();
            this.cxContinuous = new System.Windows.Forms.CheckBox();
            this.btnSaveMore = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnSaveTextLog = new System.Windows.Forms.Button();
            this.pnName = new System.Windows.Forms.Panel();
            this.rb10 = new System.Windows.Forms.RadioButton();
            this.rb09 = new System.Windows.Forms.RadioButton();
            this.rb08 = new System.Windows.Forms.RadioButton();
            this.rb07 = new System.Windows.Forms.RadioButton();
            this.rb06 = new System.Windows.Forms.RadioButton();
            this.rb05 = new System.Windows.Forms.RadioButton();
            this.rb04 = new System.Windows.Forms.RadioButton();
            this.rb03 = new System.Windows.Forms.RadioButton();
            this.rb02 = new System.Windows.Forms.RadioButton();
            this.rb01 = new System.Windows.Forms.RadioButton();
            this.gbTexPath = new System.Windows.Forms.GroupBox();
            this.pnTxtPath = new System.Windows.Forms.Panel();
            this.txTxtPath = new System.Windows.Forms.TextBox();
            this.btnTxtPathChange = new System.Windows.Forms.Button();
            this.sfdTEXT = new System.Windows.Forms.SaveFileDialog();
            this.sfdCSV = new System.Windows.Forms.SaveFileDialog();
            this.ofdLoad = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.spcLog)).BeginInit();
            this.spcLog.Panel1.SuspendLayout();
            this.spcLog.Panel2.SuspendLayout();
            this.spcLog.SuspendLayout();
            this.tbLog.SuspendLayout();
            this.tpText.SuspendLayout();
            this.tpDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.tpConfig.SuspendLayout();
            this.gbSave.SuspendLayout();
            this.gbCSVfile.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnCsvPath.SuspendLayout();
            this.gbInsert.SuspendLayout();
            this.pnName.SuspendLayout();
            this.gbTexPath.SuspendLayout();
            this.pnTxtPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcLog
            // 
            this.spcLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcLog.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcLog.Location = new System.Drawing.Point(0, 0);
            this.spcLog.Name = "spcLog";
            this.spcLog.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcLog.Panel1
            // 
            this.spcLog.Panel1.Controls.Add(this.tbLog);
            // 
            // spcLog.Panel2
            // 
            this.spcLog.Panel2.Controls.Add(this.gbInsert);
            this.spcLog.Panel2.Controls.Add(this.cbIgnoreMessages);
            this.spcLog.Panel2.Controls.Add(this.cxContinuous);
            this.spcLog.Panel2.Controls.Add(this.btnSaveMore);
            this.spcLog.Panel2.Controls.Add(this.btnLoad);
            this.spcLog.Panel2.Controls.Add(this.btnClearLog);
            this.spcLog.Panel2.Controls.Add(this.btnSaveTextLog);
            this.spcLog.Panel2.Controls.Add(this.pnName);
            this.spcLog.Size = new System.Drawing.Size(790, 188);
            this.spcLog.SplitterDistance = 127;
            this.spcLog.TabIndex = 0;
            // 
            // tbLog
            // 
            this.tbLog.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tbLog.Controls.Add(this.tpText);
            this.tbLog.Controls.Add(this.tpDGV);
            this.tbLog.Controls.Add(this.tpConfig);
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(0, 0);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.SelectedIndex = 0;
            this.tbLog.Size = new System.Drawing.Size(790, 127);
            this.tbLog.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbLog.TabIndex = 1;
            // 
            // tpText
            // 
            this.tpText.Controls.Add(this.txLog);
            this.tpText.Location = new System.Drawing.Point(4, 4);
            this.tpText.Name = "tpText";
            this.tpText.Padding = new System.Windows.Forms.Padding(3);
            this.tpText.Size = new System.Drawing.Size(725, 119);
            this.tpText.TabIndex = 0;
            this.tpText.Text = "Text-log";
            this.tpText.UseVisualStyleBackColor = true;
            // 
            // txLog
            // 
            this.txLog.AcceptsReturn = true;
            this.txLog.BackColor = System.Drawing.SystemColors.Window;
            this.txLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txLog.Font = new System.Drawing.Font("Agency FB", 10.76635F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txLog.Location = new System.Drawing.Point(3, 3);
            this.txLog.Multiline = true;
            this.txLog.Name = "txLog";
            this.txLog.ReadOnly = true;
            this.txLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txLog.Size = new System.Drawing.Size(719, 113);
            this.txLog.TabIndex = 0;
            this.txLog.TextChanged += new System.EventHandler(this.txLog_TextChanged);
            // 
            // tpDGV
            // 
            this.tpDGV.Controls.Add(this.dgvLog);
            this.tpDGV.Location = new System.Drawing.Point(4, 4);
            this.tpDGV.Name = "tpDGV";
            this.tpDGV.Padding = new System.Windows.Forms.Padding(3);
            this.tpDGV.Size = new System.Drawing.Size(725, 119);
            this.tpDGV.TabIndex = 1;
            this.tpDGV.Text = "Table-log";
            this.tpDGV.UseVisualStyleBackColor = true;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToOrderColumns = true;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(3, 3);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.Size = new System.Drawing.Size(719, 113);
            this.dgvLog.TabIndex = 2;
            // 
            // tpConfig
            // 
            this.tpConfig.Controls.Add(this.gbSave);
            this.tpConfig.Location = new System.Drawing.Point(4, 4);
            this.tpConfig.Name = "tpConfig";
            this.tpConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfig.Size = new System.Drawing.Size(725, 119);
            this.tpConfig.TabIndex = 2;
            this.tpConfig.Text = "Configuration";
            this.tpConfig.UseVisualStyleBackColor = true;
            // 
            // gbSave
            // 
            this.gbSave.Controls.Add(this.gbCSVfile);
            this.gbSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbSave.Location = new System.Drawing.Point(508, 3);
            this.gbSave.Name = "gbSave";
            this.gbSave.Size = new System.Drawing.Size(214, 113);
            this.gbSave.TabIndex = 3;
            this.gbSave.TabStop = false;
            this.gbSave.Text = "Save log";
            // 
            // gbCSVfile
            // 
            this.gbCSVfile.AutoSize = true;
            this.gbCSVfile.Controls.Add(this.panel1);
            this.gbCSVfile.Controls.Add(this.pnCsvPath);
            this.gbCSVfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCSVfile.Location = new System.Drawing.Point(3, 16);
            this.gbCSVfile.Name = "gbCSVfile";
            this.gbCSVfile.Size = new System.Drawing.Size(208, 53);
            this.gbCSVfile.TabIndex = 9;
            this.gbCSVfile.TabStop = false;
            this.gbCSVfile.Text = "CSV file";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txCsvFormat);
            this.panel1.Controls.Add(this.lbCsvFormat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 17);
            this.panel1.TabIndex = 12;
            // 
            // txCsvFormat
            // 
            this.txCsvFormat.BackColor = System.Drawing.Color.Black;
            this.txCsvFormat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txCsvFormat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txCsvFormat.ForeColor = System.Drawing.Color.White;
            this.txCsvFormat.Location = new System.Drawing.Point(39, 0);
            this.txCsvFormat.Name = "txCsvFormat";
            this.txCsvFormat.ReadOnly = true;
            this.txCsvFormat.Size = new System.Drawing.Size(159, 13);
            this.txCsvFormat.TabIndex = 11;
            this.txCsvFormat.Text = "{0}|{1}|{2}";
            this.txCsvFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbCsvFormat
            // 
            this.lbCsvFormat.AutoSize = true;
            this.lbCsvFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbCsvFormat.Location = new System.Drawing.Point(0, 0);
            this.lbCsvFormat.Name = "lbCsvFormat";
            this.lbCsvFormat.Size = new System.Drawing.Size(39, 13);
            this.lbCsvFormat.TabIndex = 12;
            this.lbCsvFormat.Text = "Format";
            // 
            // pnCsvPath
            // 
            this.pnCsvPath.AutoSize = true;
            this.pnCsvPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnCsvPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCsvPath.Controls.Add(this.txCsvPath);
            this.pnCsvPath.Controls.Add(this.btnCsvPathChange);
            this.pnCsvPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCsvPath.Location = new System.Drawing.Point(3, 16);
            this.pnCsvPath.Name = "pnCsvPath";
            this.pnCsvPath.Size = new System.Drawing.Size(202, 17);
            this.pnCsvPath.TabIndex = 9;
            // 
            // txCsvPath
            // 
            this.txCsvPath.BackColor = System.Drawing.Color.Black;
            this.txCsvPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txCsvPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txCsvPath.ForeColor = System.Drawing.Color.White;
            this.txCsvPath.Location = new System.Drawing.Point(0, 0);
            this.txCsvPath.Name = "txCsvPath";
            this.txCsvPath.ReadOnly = true;
            this.txCsvPath.Size = new System.Drawing.Size(171, 13);
            this.txCsvPath.TabIndex = 10;
            this.txCsvPath.Text = "C:\\ODO\\odolog.csv";
            this.txCsvPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCsvPathChange
            // 
            this.btnCsvPathChange.AutoSize = true;
            this.btnCsvPathChange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCsvPathChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCsvPathChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCsvPathChange.Location = new System.Drawing.Point(171, 0);
            this.btnCsvPathChange.Name = "btnCsvPathChange";
            this.btnCsvPathChange.Size = new System.Drawing.Size(27, 13);
            this.btnCsvPathChange.TabIndex = 9;
            this.btnCsvPathChange.Text = "=";
            this.btnCsvPathChange.UseVisualStyleBackColor = true;
            this.btnCsvPathChange.Click += new System.EventHandler(this.btnCsvPathChange_Click);
            // 
            // gbInsert
            // 
            this.gbInsert.AutoSize = true;
            this.gbInsert.Controls.Add(this.btnInsert);
            this.gbInsert.Controls.Add(this.txInsert);
            this.gbInsert.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbInsert.Location = new System.Drawing.Point(505, 17);
            this.gbInsert.Name = "gbInsert";
            this.gbInsert.Size = new System.Drawing.Size(159, 40);
            this.gbInsert.TabIndex = 14;
            this.gbInsert.TabStop = false;
            this.gbInsert.Text = "Insert line";
            // 
            // btnInsert
            // 
            this.btnInsert.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInsert.Location = new System.Drawing.Point(3, 16);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(59, 21);
            this.btnInsert.TabIndex = 14;
            this.btnInsert.Text = "insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txInsert
            // 
            this.txInsert.BackColor = System.Drawing.Color.Black;
            this.txInsert.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txInsert.Dock = System.Windows.Forms.DockStyle.Right;
            this.txInsert.ForeColor = System.Drawing.Color.White;
            this.txInsert.Location = new System.Drawing.Point(62, 16);
            this.txInsert.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.txInsert.Name = "txInsert";
            this.txInsert.Size = new System.Drawing.Size(94, 13);
            this.txInsert.TabIndex = 13;
            this.txInsert.Text = "MERENI";
            this.txInsert.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txInsert_KeyDown);
            // 
            // cbIgnoreMessages
            // 
            this.cbIgnoreMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbIgnoreMessages.Location = new System.Drawing.Point(387, 0);
            this.cbIgnoreMessages.Name = "cbIgnoreMessages";
            this.cbIgnoreMessages.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.cbIgnoreMessages.Size = new System.Drawing.Size(277, 17);
            this.cbIgnoreMessages.TabIndex = 7;
            this.cbIgnoreMessages.Text = "Ignore Messages";
            this.cbIgnoreMessages.UseVisualStyleBackColor = true;
            this.cbIgnoreMessages.CheckedChanged += new System.EventHandler(this.cbIgnoreMessages_CheckedChanged);
            // 
            // cxContinuous
            // 
            this.cxContinuous.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cxContinuous.Enabled = false;
            this.cxContinuous.Location = new System.Drawing.Point(387, 0);
            this.cxContinuous.Name = "cxContinuous";
            this.cxContinuous.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.cxContinuous.Size = new System.Drawing.Size(277, 57);
            this.cxContinuous.TabIndex = 5;
            this.cxContinuous.Text = "Continuous log saving";
            this.cxContinuous.UseVisualStyleBackColor = true;
            // 
            // btnSaveMore
            // 
            this.btnSaveMore.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveMore.Enabled = false;
            this.btnSaveMore.Location = new System.Drawing.Point(664, 0);
            this.btnSaveMore.Name = "btnSaveMore";
            this.btnSaveMore.Size = new System.Drawing.Size(51, 57);
            this.btnSaveMore.TabIndex = 2;
            this.btnSaveMore.Text = "Save &CSV";
            this.btnSaveMore.UseVisualStyleBackColor = true;
            this.btnSaveMore.Click += new System.EventHandler(this.btnSaveMore_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLoad.Enabled = false;
            this.btnLoad.Location = new System.Drawing.Point(715, 0);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 57);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "&Load txt";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClearLog.Location = new System.Drawing.Point(345, 0);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(42, 57);
            this.btnClearLog.TabIndex = 0;
            this.btnClearLog.Text = "&Erase";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnSaveTextLog
            // 
            this.btnSaveTextLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaveTextLog.Location = new System.Drawing.Point(299, 0);
            this.btnSaveTextLog.Name = "btnSaveTextLog";
            this.btnSaveTextLog.Size = new System.Drawing.Size(46, 57);
            this.btnSaveTextLog.TabIndex = 1;
            this.btnSaveTextLog.Text = "&Save Text";
            this.btnSaveTextLog.UseVisualStyleBackColor = true;
            this.btnSaveTextLog.Click += new System.EventHandler(this.btnSaveTextLog_Click);
            // 
            // pnName
            // 
            this.pnName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnName.Controls.Add(this.rb10);
            this.pnName.Controls.Add(this.rb09);
            this.pnName.Controls.Add(this.rb08);
            this.pnName.Controls.Add(this.rb07);
            this.pnName.Controls.Add(this.rb06);
            this.pnName.Controls.Add(this.rb05);
            this.pnName.Controls.Add(this.rb04);
            this.pnName.Controls.Add(this.rb03);
            this.pnName.Controls.Add(this.rb02);
            this.pnName.Controls.Add(this.rb01);
            this.pnName.Controls.Add(this.gbTexPath);
            this.pnName.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnName.Location = new System.Drawing.Point(0, 0);
            this.pnName.Name = "pnName";
            this.pnName.Size = new System.Drawing.Size(299, 57);
            this.pnName.TabIndex = 6;
            // 
            // rb10
            // 
            this.rb10.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb10.AutoSize = true;
            this.rb10.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb10.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rb10.FlatAppearance.BorderSize = 5;
            this.rb10.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.rb10.Location = new System.Drawing.Point(261, 36);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(29, 19);
            this.rb10.TabIndex = 12;
            this.rb10.TabStop = true;
            this.rb10.Text = "10";
            this.rb10.UseVisualStyleBackColor = true;
            // 
            // rb09
            // 
            this.rb09.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb09.AutoSize = true;
            this.rb09.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb09.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rb09.FlatAppearance.BorderSize = 5;
            this.rb09.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.rb09.Location = new System.Drawing.Point(232, 36);
            this.rb09.Name = "rb09";
            this.rb09.Size = new System.Drawing.Size(29, 19);
            this.rb09.TabIndex = 11;
            this.rb09.TabStop = true;
            this.rb09.Text = "09";
            this.rb09.UseVisualStyleBackColor = true;
            // 
            // rb08
            // 
            this.rb08.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb08.AutoSize = true;
            this.rb08.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb08.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rb08.FlatAppearance.BorderSize = 5;
            this.rb08.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.rb08.Location = new System.Drawing.Point(203, 36);
            this.rb08.Name = "rb08";
            this.rb08.Size = new System.Drawing.Size(29, 19);
            this.rb08.TabIndex = 10;
            this.rb08.TabStop = true;
            this.rb08.Text = "08";
            this.rb08.UseVisualStyleBackColor = true;
            this.rb08.CheckedChanged += new System.EventHandler(this.rbXX_CheckedChanged);
            // 
            // rb07
            // 
            this.rb07.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb07.AutoSize = true;
            this.rb07.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb07.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rb07.FlatAppearance.BorderSize = 5;
            this.rb07.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.rb07.Location = new System.Drawing.Point(174, 36);
            this.rb07.Name = "rb07";
            this.rb07.Size = new System.Drawing.Size(29, 19);
            this.rb07.TabIndex = 9;
            this.rb07.TabStop = true;
            this.rb07.Text = "07";
            this.rb07.UseVisualStyleBackColor = true;
            this.rb07.CheckedChanged += new System.EventHandler(this.rbXX_CheckedChanged);
            // 
            // rb06
            // 
            this.rb06.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb06.AutoSize = true;
            this.rb06.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb06.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rb06.FlatAppearance.BorderSize = 5;
            this.rb06.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.rb06.Location = new System.Drawing.Point(145, 36);
            this.rb06.Name = "rb06";
            this.rb06.Size = new System.Drawing.Size(29, 19);
            this.rb06.TabIndex = 8;
            this.rb06.TabStop = true;
            this.rb06.Text = "06";
            this.rb06.UseVisualStyleBackColor = true;
            this.rb06.CheckedChanged += new System.EventHandler(this.rbXX_CheckedChanged);
            // 
            // rb05
            // 
            this.rb05.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb05.AutoSize = true;
            this.rb05.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb05.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rb05.FlatAppearance.BorderSize = 5;
            this.rb05.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.rb05.Location = new System.Drawing.Point(116, 36);
            this.rb05.Name = "rb05";
            this.rb05.Size = new System.Drawing.Size(29, 19);
            this.rb05.TabIndex = 7;
            this.rb05.TabStop = true;
            this.rb05.Text = "05";
            this.rb05.UseVisualStyleBackColor = true;
            this.rb05.CheckedChanged += new System.EventHandler(this.rbXX_CheckedChanged);
            // 
            // rb04
            // 
            this.rb04.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb04.AutoSize = true;
            this.rb04.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb04.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rb04.FlatAppearance.BorderSize = 5;
            this.rb04.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.rb04.Location = new System.Drawing.Point(87, 36);
            this.rb04.Name = "rb04";
            this.rb04.Size = new System.Drawing.Size(29, 19);
            this.rb04.TabIndex = 6;
            this.rb04.TabStop = true;
            this.rb04.Text = "04";
            this.rb04.UseVisualStyleBackColor = true;
            this.rb04.CheckedChanged += new System.EventHandler(this.rbXX_CheckedChanged);
            // 
            // rb03
            // 
            this.rb03.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb03.AutoSize = true;
            this.rb03.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb03.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rb03.FlatAppearance.BorderSize = 5;
            this.rb03.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.rb03.Location = new System.Drawing.Point(58, 36);
            this.rb03.Name = "rb03";
            this.rb03.Size = new System.Drawing.Size(29, 19);
            this.rb03.TabIndex = 5;
            this.rb03.TabStop = true;
            this.rb03.Text = "03";
            this.rb03.UseVisualStyleBackColor = true;
            this.rb03.CheckedChanged += new System.EventHandler(this.rbXX_CheckedChanged);
            // 
            // rb02
            // 
            this.rb02.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb02.AutoSize = true;
            this.rb02.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb02.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rb02.FlatAppearance.BorderSize = 5;
            this.rb02.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.rb02.Location = new System.Drawing.Point(29, 36);
            this.rb02.Name = "rb02";
            this.rb02.Size = new System.Drawing.Size(29, 19);
            this.rb02.TabIndex = 4;
            this.rb02.TabStop = true;
            this.rb02.Text = "02";
            this.rb02.UseVisualStyleBackColor = true;
            this.rb02.CheckedChanged += new System.EventHandler(this.rbXX_CheckedChanged);
            // 
            // rb01
            // 
            this.rb01.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb01.AutoSize = true;
            this.rb01.Dock = System.Windows.Forms.DockStyle.Left;
            this.rb01.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rb01.FlatAppearance.BorderSize = 5;
            this.rb01.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.rb01.Location = new System.Drawing.Point(0, 36);
            this.rb01.Name = "rb01";
            this.rb01.Size = new System.Drawing.Size(29, 19);
            this.rb01.TabIndex = 3;
            this.rb01.TabStop = true;
            this.rb01.Text = "01";
            this.rb01.UseVisualStyleBackColor = true;
            this.rb01.CheckedChanged += new System.EventHandler(this.rbXX_CheckedChanged);
            // 
            // gbTexPath
            // 
            this.gbTexPath.AutoSize = true;
            this.gbTexPath.Controls.Add(this.pnTxtPath);
            this.gbTexPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTexPath.Location = new System.Drawing.Point(0, 0);
            this.gbTexPath.Name = "gbTexPath";
            this.gbTexPath.Size = new System.Drawing.Size(297, 36);
            this.gbTexPath.TabIndex = 2;
            this.gbTexPath.TabStop = false;
            this.gbTexPath.Text = "TextLog file";
            // 
            // pnTxtPath
            // 
            this.pnTxtPath.AutoSize = true;
            this.pnTxtPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnTxtPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnTxtPath.Controls.Add(this.txTxtPath);
            this.pnTxtPath.Controls.Add(this.btnTxtPathChange);
            this.pnTxtPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTxtPath.Location = new System.Drawing.Point(3, 16);
            this.pnTxtPath.Name = "pnTxtPath";
            this.pnTxtPath.Size = new System.Drawing.Size(291, 17);
            this.pnTxtPath.TabIndex = 10;
            // 
            // txTxtPath
            // 
            this.txTxtPath.BackColor = System.Drawing.Color.Black;
            this.txTxtPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txTxtPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txTxtPath.ForeColor = System.Drawing.Color.White;
            this.txTxtPath.Location = new System.Drawing.Point(0, 0);
            this.txTxtPath.Name = "txTxtPath";
            this.txTxtPath.Size = new System.Drawing.Size(260, 13);
            this.txTxtPath.TabIndex = 11;
            this.txTxtPath.Text = "C:\\ODO\\odolog.txt";
            this.txTxtPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txTxtPath.TextChanged += new System.EventHandler(this.txTxtPath_TextChanged);
            this.txTxtPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txTxtPath_KeyDown);
            // 
            // btnTxtPathChange
            // 
            this.btnTxtPathChange.AutoSize = true;
            this.btnTxtPathChange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTxtPathChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTxtPathChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTxtPathChange.Location = new System.Drawing.Point(260, 0);
            this.btnTxtPathChange.Name = "btnTxtPathChange";
            this.btnTxtPathChange.Size = new System.Drawing.Size(27, 13);
            this.btnTxtPathChange.TabIndex = 12;
            this.btnTxtPathChange.Text = "=";
            this.btnTxtPathChange.UseVisualStyleBackColor = true;
            // 
            // sfdTEXT
            // 
            this.sfdTEXT.DefaultExt = "txt";
            this.sfdTEXT.FileName = "odolog.txt";
            this.sfdTEXT.Filter = "*.txt|*.txt";
            this.sfdTEXT.InitialDirectory = "C:\\ODO\\";
            this.sfdTEXT.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdTxtPath_FileOk);
            // 
            // sfdCSV
            // 
            this.sfdCSV.DefaultExt = "csv";
            this.sfdCSV.FileName = "odolog.csv";
            this.sfdCSV.Filter = "*.csv|*.csv";
            this.sfdCSV.InitialDirectory = "C:\\ODO\\";
            this.sfdCSV.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdCsvPath_FileOk);
            // 
            // ofdLoad
            // 
            this.ofdLoad.FileName = "odomsg.txt";
            this.ofdLoad.InitialDirectory = "C:\\ODO";
            this.ofdLoad.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdLoad_FileOk);
            // 
            // foLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 188);
            this.Controls.Add(this.spcLog);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(0, 512);
            this.Name = "foLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.foLog_FormClosing);
            this.Load += new System.EventHandler(this.foLog_Load);
            this.spcLog.Panel1.ResumeLayout(false);
            this.spcLog.Panel2.ResumeLayout(false);
            this.spcLog.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcLog)).EndInit();
            this.spcLog.ResumeLayout(false);
            this.tbLog.ResumeLayout(false);
            this.tpText.ResumeLayout(false);
            this.tpText.PerformLayout();
            this.tpDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.tpConfig.ResumeLayout(false);
            this.gbSave.ResumeLayout(false);
            this.gbSave.PerformLayout();
            this.gbCSVfile.ResumeLayout(false);
            this.gbCSVfile.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnCsvPath.ResumeLayout(false);
            this.pnCsvPath.PerformLayout();
            this.gbInsert.ResumeLayout(false);
            this.gbInsert.PerformLayout();
            this.pnName.ResumeLayout(false);
            this.pnName.PerformLayout();
            this.gbTexPath.ResumeLayout(false);
            this.gbTexPath.PerformLayout();
            this.pnTxtPath.ResumeLayout(false);
            this.pnTxtPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnSaveMore;
        private System.Windows.Forms.Button btnSaveTextLog;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TabControl tbLog;
        private System.Windows.Forms.TabPage tpText;
        private System.Windows.Forms.TextBox txLog;
        private System.Windows.Forms.TabPage tpDGV;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.TabPage tpConfig;
        private System.Windows.Forms.GroupBox gbSave;
        private System.Windows.Forms.GroupBox gbCSVfile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txCsvFormat;
        private System.Windows.Forms.Label lbCsvFormat;
        private System.Windows.Forms.Panel pnCsvPath;
        private System.Windows.Forms.TextBox txCsvPath;
        private System.Windows.Forms.Button btnCsvPathChange;
        private System.Windows.Forms.CheckBox cxContinuous;
        private System.Windows.Forms.SaveFileDialog sfdTEXT;
        private System.Windows.Forms.SaveFileDialog sfdCSV;
        private System.Windows.Forms.OpenFileDialog ofdLoad;
        private System.Windows.Forms.Panel pnName;
        private System.Windows.Forms.CheckBox cbIgnoreMessages;
        private System.Windows.Forms.GroupBox gbTexPath;
        private System.Windows.Forms.Panel pnTxtPath;
        public System.Windows.Forms.TextBox txTxtPath;
        private System.Windows.Forms.Button btnTxtPathChange;
        private System.Windows.Forms.RadioButton rb08;
        private System.Windows.Forms.RadioButton rb07;
        private System.Windows.Forms.RadioButton rb06;
        private System.Windows.Forms.RadioButton rb05;
        private System.Windows.Forms.RadioButton rb04;
        private System.Windows.Forms.RadioButton rb03;
        private System.Windows.Forms.RadioButton rb02;
        private System.Windows.Forms.RadioButton rb01;
        private System.Windows.Forms.RadioButton rb10;
        private System.Windows.Forms.RadioButton rb09;
        private System.Windows.Forms.GroupBox gbInsert;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txInsert;

    }
}