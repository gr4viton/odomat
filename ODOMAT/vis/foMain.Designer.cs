namespace vis {
    partial class foMain {
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
            this.components = new System.ComponentModel.Container();
            this.srpOdo = new System.IO.Ports.SerialPort(this.components);
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.sslMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslSeparator = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslCursor = new System.Windows.Forms.ToolStripStatusLabel();
            this.timSim = new System.Windows.Forms.Timer(this.components);
            this.txLast = new System.Windows.Forms.TextBox();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.gbView = new System.Windows.Forms.GroupBox();
            this.lbZoomMin = new System.Windows.Forms.Label();
            this.lbZoomMax = new System.Windows.Forms.Label();
            this.lbZoomOne = new System.Windows.Forms.Label();
            this.trbZoomMax = new System.Windows.Forms.TrackBar();
            this.lbPPU2 = new System.Windows.Forms.Label();
            this.btnErase = new System.Windows.Forms.Button();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.gbHUD = new System.Windows.Forms.GroupBox();
            this.pbProbCov = new System.Windows.Forms.PictureBox();
            this.lbProb = new System.Windows.Forms.Label();
            this.txUnits = new System.Windows.Forms.TextBox();
            this.lbUnit = new System.Windows.Forms.Label();
            this.txPosX = new System.Windows.Forms.TextBox();
            this.txPosY = new System.Windows.Forms.TextBox();
            this.lbPos = new System.Windows.Forms.Label();
            this.txAngle = new System.Windows.Forms.TextBox();
            this.lbAng = new System.Windows.Forms.Label();
            this.gbPortcontrol = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRescanPorts = new System.Windows.Forms.Button();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.lbSelectPort = new System.Windows.Forms.Label();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLogger = new System.Windows.Forms.ToolStripMenuItem();
            this.ttmConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spcRight = new System.Windows.Forms.SplitContainer();
            this.btnResetRobotPos = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSaveImageAs = new System.Windows.Forms.Button();
            this.btnSaveImg = new System.Windows.Forms.Button();
            this.txPPU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbRender = new System.Windows.Forms.GroupBox();
            this.rbRenderRelative = new System.Windows.Forms.RadioButton();
            this.rbRenderAbsolute = new System.Windows.Forms.RadioButton();
            this.cxAntialias = new System.Windows.Forms.CheckBox();
            this.cxErrorEllipses = new System.Windows.Forms.CheckBox();
            this.gbHUD2 = new System.Windows.Forms.GroupBox();
            this.gbActual = new System.Windows.Forms.GroupBox();
            this.txAct = new System.Windows.Forms.TextBox();
            this.txProb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txIters = new System.Windows.Forms.TextBox();
            this.lbIters = new System.Windows.Forms.Label();
            this.txSteps = new System.Windows.Forms.TextBox();
            this.lbStep = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txLastCmd = new System.Windows.Forms.TextBox();
            this.lbLastCmd = new System.Windows.Forms.Label();
            this.btnSendConfigFile = new System.Windows.Forms.Button();
            this.btnCmdList = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbBaud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHide = new System.Windows.Forms.Button();
            this.pbPaper = new System.Windows.Forms.Panel();
            this.txIn = new System.Windows.Forms.TextBox();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.ofdConfigFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.commandListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSend = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txSend = new System.Windows.Forms.TextBox();
            this.ssMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.pnLeft.SuspendLayout();
            this.gbView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbZoomMax)).BeginInit();
            this.gbHUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProbCov)).BeginInit();
            this.gbPortcontrol.SuspendLayout();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcRight)).BeginInit();
            this.spcRight.Panel1.SuspendLayout();
            this.spcRight.Panel2.SuspendLayout();
            this.spcRight.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbRender.SuspendLayout();
            this.gbHUD2.SuspendLayout();
            this.gbActual.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pbPaper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.gbSend.SuspendLayout();
            this.SuspendLayout();
            // 
            // srpOdo
            // 
            this.srpOdo.BaudRate = 19200;
            this.srpOdo.PortName = "COM10";
            this.srpOdo.StopBits = System.IO.Ports.StopBits.Two;
            this.srpOdo.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.srpOdo_ErrorReceived);
            this.srpOdo.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.srpOdo_DataReceived);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslMain,
            this.sslSeparator,
            this.sslCursor});
            this.ssMain.Location = new System.Drawing.Point(0, 628);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(1057, 22);
            this.ssMain.TabIndex = 1;
            this.ssMain.Text = "statusStrip1";
            // 
            // sslMain
            // 
            this.sslMain.Name = "sslMain";
            this.sslMain.Size = new System.Drawing.Size(110, 17);
            this.sslMain.Text = "Ready for everything";
            // 
            // sslSeparator
            // 
            this.sslSeparator.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Top;
            this.sslSeparator.Name = "sslSeparator";
            this.sslSeparator.Size = new System.Drawing.Size(886, 17);
            this.sslSeparator.Spring = true;
            // 
            // sslCursor
            // 
            this.sslCursor.Name = "sslCursor";
            this.sslCursor.Size = new System.Drawing.Size(46, 17);
            this.sslCursor.Text = "(0, 0)px";
            // 
            // timSim
            // 
            this.timSim.Interval = 1000;
            // 
            // txLast
            // 
            this.txLast.BackColor = System.Drawing.Color.Black;
            this.txLast.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txLast.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txLast.ForeColor = System.Drawing.Color.White;
            this.txLast.Location = new System.Drawing.Point(0, 615);
            this.txLast.Name = "txLast";
            this.txLast.ReadOnly = true;
            this.txLast.Size = new System.Drawing.Size(1057, 13);
            this.txLast.TabIndex = 5;
            this.txLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.pnLeft);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.spcRight);
            this.spcMain.Size = new System.Drawing.Size(1057, 615);
            this.spcMain.SplitterDistance = 92;
            this.spcMain.TabIndex = 6;
            // 
            // pnLeft
            // 
            this.pnLeft.AutoScroll = true;
            this.pnLeft.AutoSize = true;
            this.pnLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnLeft.Controls.Add(this.gbView);
            this.pnLeft.Controls.Add(this.gbHUD);
            this.pnLeft.Controls.Add(this.gbPortcontrol);
            this.pnLeft.Controls.Add(this.msMain);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(92, 615);
            this.pnLeft.TabIndex = 64;
            // 
            // gbView
            // 
            this.gbView.Controls.Add(this.lbZoomMin);
            this.gbView.Controls.Add(this.lbZoomMax);
            this.gbView.Controls.Add(this.lbZoomOne);
            this.gbView.Controls.Add(this.trbZoomMax);
            this.gbView.Controls.Add(this.lbPPU2);
            this.gbView.Controls.Add(this.btnErase);
            this.gbView.Controls.Add(this.btnRedraw);
            this.gbView.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbView.Location = new System.Drawing.Point(0, 301);
            this.gbView.Name = "gbView";
            this.gbView.Size = new System.Drawing.Size(92, 299);
            this.gbView.TabIndex = 69;
            this.gbView.TabStop = false;
            this.gbView.Text = "View";
            // 
            // lbZoomMin
            // 
            this.lbZoomMin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbZoomMin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbZoomMin.Location = new System.Drawing.Point(3, 283);
            this.lbZoomMin.Name = "lbZoomMin";
            this.lbZoomMin.Size = new System.Drawing.Size(54, 13);
            this.lbZoomMin.TabIndex = 74;
            this.lbZoomMin.Text = "32";
            this.lbZoomMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbZoomMax
            // 
            this.lbZoomMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbZoomMax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbZoomMax.Location = new System.Drawing.Point(3, 75);
            this.lbZoomMax.Name = "lbZoomMax";
            this.lbZoomMax.Size = new System.Drawing.Size(54, 21);
            this.lbZoomMax.TabIndex = 72;
            this.lbZoomMax.Text = "2048";
            this.lbZoomMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbZoomOne
            // 
            this.lbZoomOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbZoomOne.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbZoomOne.Location = new System.Drawing.Point(3, 75);
            this.lbZoomOne.Name = "lbZoomOne";
            this.lbZoomOne.Size = new System.Drawing.Size(54, 221);
            this.lbZoomOne.TabIndex = 73;
            this.lbZoomOne.Text = "256";
            this.lbZoomOne.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trbZoomMax
            // 
            this.trbZoomMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.trbZoomMax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trbZoomMax.Location = new System.Drawing.Point(57, 75);
            this.trbZoomMax.Maximum = 111;
            this.trbZoomMax.Minimum = 51;
            this.trbZoomMax.Name = "trbZoomMax";
            this.trbZoomMax.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trbZoomMax.Size = new System.Drawing.Size(32, 221);
            this.trbZoomMax.TabIndex = 71;
            this.trbZoomMax.TickFrequency = 10;
            this.trbZoomMax.Value = 71;
            this.trbZoomMax.ValueChanged += new System.EventHandler(this.trbZoomMax_ValueChanged_1);
            // 
            // lbPPU2
            // 
            this.lbPPU2.AutoSize = true;
            this.lbPPU2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbPPU2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPPU2.Location = new System.Drawing.Point(3, 62);
            this.lbPPU2.Name = "lbPPU2";
            this.lbPPU2.Size = new System.Drawing.Size(61, 13);
            this.lbPPU2.TabIndex = 69;
            this.lbPPU2.Text = "[pixels/unit]";
            // 
            // btnErase
            // 
            this.btnErase.AutoSize = true;
            this.btnErase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnErase.Location = new System.Drawing.Point(3, 39);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(86, 23);
            this.btnErase.TabIndex = 75;
            this.btnErase.Text = "&Erase";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // btnRedraw
            // 
            this.btnRedraw.AutoSize = true;
            this.btnRedraw.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRedraw.Location = new System.Drawing.Point(3, 16);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(86, 23);
            this.btnRedraw.TabIndex = 68;
            this.btnRedraw.Text = "Re&draw";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // gbHUD
            // 
            this.gbHUD.AutoSize = true;
            this.gbHUD.Controls.Add(this.pbProbCov);
            this.gbHUD.Controls.Add(this.lbProb);
            this.gbHUD.Controls.Add(this.txUnits);
            this.gbHUD.Controls.Add(this.lbUnit);
            this.gbHUD.Controls.Add(this.txPosX);
            this.gbHUD.Controls.Add(this.txPosY);
            this.gbHUD.Controls.Add(this.lbPos);
            this.gbHUD.Controls.Add(this.txAngle);
            this.gbHUD.Controls.Add(this.lbAng);
            this.gbHUD.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHUD.Location = new System.Drawing.Point(0, 123);
            this.gbHUD.Name = "gbHUD";
            this.gbHUD.Size = new System.Drawing.Size(92, 178);
            this.gbHUD.TabIndex = 66;
            this.gbHUD.TabStop = false;
            this.gbHUD.Text = "HUD";
            // 
            // pbProbCov
            // 
            this.pbProbCov.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pbProbCov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProbCov.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbProbCov.Location = new System.Drawing.Point(3, 120);
            this.pbProbCov.Name = "pbProbCov";
            this.pbProbCov.Size = new System.Drawing.Size(86, 55);
            this.pbProbCov.TabIndex = 79;
            this.pbProbCov.TabStop = false;
            // 
            // lbProb
            // 
            this.lbProb.AutoSize = true;
            this.lbProb.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbProb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbProb.Location = new System.Drawing.Point(3, 107);
            this.lbProb.Name = "lbProb";
            this.lbProb.Size = new System.Drawing.Size(88, 13);
            this.lbProb.TabIndex = 75;
            this.lbProb.Text = "Prob-covariance:";
            // 
            // txUnits
            // 
            this.txUnits.BackColor = System.Drawing.Color.Black;
            this.txUnits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txUnits.Dock = System.Windows.Forms.DockStyle.Top;
            this.txUnits.ForeColor = System.Drawing.Color.White;
            this.txUnits.Location = new System.Drawing.Point(3, 94);
            this.txUnits.Name = "txUnits";
            this.txUnits.ReadOnly = true;
            this.txUnits.Size = new System.Drawing.Size(86, 13);
            this.txUnits.TabIndex = 74;
            this.txUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbUnit
            // 
            this.lbUnit.AutoSize = true;
            this.lbUnit.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbUnit.Location = new System.Drawing.Point(3, 81);
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.Size = new System.Drawing.Size(34, 13);
            this.lbUnit.TabIndex = 73;
            this.lbUnit.Text = "Units:";
            // 
            // txPosX
            // 
            this.txPosX.BackColor = System.Drawing.Color.Black;
            this.txPosX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txPosX.Dock = System.Windows.Forms.DockStyle.Top;
            this.txPosX.ForeColor = System.Drawing.Color.White;
            this.txPosX.Location = new System.Drawing.Point(3, 68);
            this.txPosX.Name = "txPosX";
            this.txPosX.ReadOnly = true;
            this.txPosX.Size = new System.Drawing.Size(86, 13);
            this.txPosX.TabIndex = 72;
            this.txPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txPosY
            // 
            this.txPosY.BackColor = System.Drawing.Color.Black;
            this.txPosY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txPosY.Dock = System.Windows.Forms.DockStyle.Top;
            this.txPosY.ForeColor = System.Drawing.Color.White;
            this.txPosY.Location = new System.Drawing.Point(3, 55);
            this.txPosY.Name = "txPosY";
            this.txPosY.ReadOnly = true;
            this.txPosY.Size = new System.Drawing.Size(86, 13);
            this.txPosY.TabIndex = 71;
            this.txPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPos
            // 
            this.lbPos.AutoSize = true;
            this.lbPos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbPos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPos.Location = new System.Drawing.Point(3, 42);
            this.lbPos.Name = "lbPos";
            this.lbPos.Size = new System.Drawing.Size(118, 13);
            this.lbPos.TabIndex = 69;
            this.lbPos.Text = "Position (X,Y) {abs+rel}:";
            // 
            // txAngle
            // 
            this.txAngle.BackColor = System.Drawing.Color.Black;
            this.txAngle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txAngle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txAngle.ForeColor = System.Drawing.Color.White;
            this.txAngle.Location = new System.Drawing.Point(3, 29);
            this.txAngle.Name = "txAngle";
            this.txAngle.ReadOnly = true;
            this.txAngle.Size = new System.Drawing.Size(86, 13);
            this.txAngle.TabIndex = 6;
            this.txAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbAng
            // 
            this.lbAng.AutoSize = true;
            this.lbAng.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbAng.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAng.Location = new System.Drawing.Point(3, 16);
            this.lbAng.Name = "lbAng";
            this.lbAng.Size = new System.Drawing.Size(65, 13);
            this.lbAng.TabIndex = 68;
            this.lbAng.Text = "Angle {abs}:";
            // 
            // gbPortcontrol
            // 
            this.gbPortcontrol.AutoSize = true;
            this.gbPortcontrol.Controls.Add(this.btnConnect);
            this.gbPortcontrol.Controls.Add(this.btnRescanPorts);
            this.gbPortcontrol.Controls.Add(this.cbPorts);
            this.gbPortcontrol.Controls.Add(this.lbSelectPort);
            this.gbPortcontrol.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPortcontrol.Location = new System.Drawing.Point(0, 24);
            this.gbPortcontrol.Name = "gbPortcontrol";
            this.gbPortcontrol.Size = new System.Drawing.Size(92, 99);
            this.gbPortcontrol.TabIndex = 64;
            this.gbPortcontrol.TabStop = false;
            this.gbPortcontrol.Text = "Port Control";
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConnect.Location = new System.Drawing.Point(3, 73);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(86, 23);
            this.btnConnect.TabIndex = 35;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnRescanPorts
            // 
            this.btnRescanPorts.AutoSize = true;
            this.btnRescanPorts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRescanPorts.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRescanPorts.Location = new System.Drawing.Point(3, 50);
            this.btnRescanPorts.Name = "btnRescanPorts";
            this.btnRescanPorts.Size = new System.Drawing.Size(86, 23);
            this.btnRescanPorts.TabIndex = 57;
            this.btnRescanPorts.Text = "&Rescan ports";
            this.btnRescanPorts.UseVisualStyleBackColor = true;
            this.btnRescanPorts.Click += new System.EventHandler(this.btnRescanPorts_Click);
            // 
            // cbPorts
            // 
            this.cbPorts.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(3, 29);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(86, 21);
            this.cbPorts.TabIndex = 36;
            // 
            // lbSelectPort
            // 
            this.lbSelectPort.AutoSize = true;
            this.lbSelectPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSelectPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbSelectPort.Location = new System.Drawing.Point(3, 16);
            this.lbSelectPort.Name = "lbSelectPort";
            this.lbSelectPort.Size = new System.Drawing.Size(61, 13);
            this.lbSelectPort.TabIndex = 37;
            this.lbSelectPort.Text = "Select port:";
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiView});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(92, 24);
            this.msMain.TabIndex = 67;
            this.msMain.Text = "menuStrip1";
            // 
            // tsiView
            // 
            this.tsiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLogger,
            this.ttmConfig,
            this.commandListToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.tsiView.Name = "tsiView";
            this.tsiView.Size = new System.Drawing.Size(45, 20);
            this.tsiView.Text = "Sho&w";
            // 
            // tsmLogger
            // 
            this.tsmLogger.Name = "tsmLogger";
            this.tsmLogger.Size = new System.Drawing.Size(107, 22);
            this.tsmLogger.Text = "&Logger";
            this.tsmLogger.Click += new System.EventHandler(this.tsmLogger_Click);
            // 
            // ttmConfig
            // 
            this.ttmConfig.Name = "ttmConfig";
            this.ttmConfig.Size = new System.Drawing.Size(107, 22);
            this.ttmConfig.Text = "&Config";
            this.ttmConfig.Click += new System.EventHandler(this.ttmConfig_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // spcRight
            // 
            this.spcRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcRight.Location = new System.Drawing.Point(0, 0);
            this.spcRight.Name = "spcRight";
            // 
            // spcRight.Panel1
            // 
            this.spcRight.Panel1.AutoScroll = true;
            this.spcRight.Panel1.Controls.Add(this.btnResetRobotPos);
            this.spcRight.Panel1.Controls.Add(this.groupBox3);
            this.spcRight.Panel1.Controls.Add(this.gbHUD2);
            this.spcRight.Panel1.Controls.Add(this.groupBox2);
            this.spcRight.Panel1.Controls.Add(this.groupBox1);
            this.spcRight.Panel1.Controls.Add(this.btnHide);
            // 
            // spcRight.Panel2
            // 
            this.spcRight.Panel2.Controls.Add(this.pbPaper);
            this.spcRight.Size = new System.Drawing.Size(961, 615);
            this.spcRight.SplitterDistance = 200;
            this.spcRight.TabIndex = 22;
            this.spcRight.Tag = "200";
            // 
            // btnResetRobotPos
            // 
            this.btnResetRobotPos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnResetRobotPos.Location = new System.Drawing.Point(0, 741);
            this.btnResetRobotPos.Name = "btnResetRobotPos";
            this.btnResetRobotPos.Size = new System.Drawing.Size(188, 23);
            this.btnResetRobotPos.TabIndex = 72;
            this.btnResetRobotPos.Text = "reset robot position";
            this.btnResetRobotPos.UseVisualStyleBackColor = true;
            this.btnResetRobotPos.Click += new System.EventHandler(this.btnResetRobotPos_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.btnSaveImageAs);
            this.groupBox3.Controls.Add(this.btnSaveImg);
            this.groupBox3.Controls.Add(this.txPPU);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.gbRender);
            this.groupBox3.Controls.Add(this.cxAntialias);
            this.groupBox3.Controls.Add(this.cxErrorEllipses);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 563);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 178);
            this.groupBox3.TabIndex = 70;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View";
            // 
            // btnSaveImageAs
            // 
            this.btnSaveImageAs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSaveImageAs.Location = new System.Drawing.Point(3, 152);
            this.btnSaveImageAs.Name = "btnSaveImageAs";
            this.btnSaveImageAs.Size = new System.Drawing.Size(182, 23);
            this.btnSaveImageAs.TabIndex = 78;
            this.btnSaveImageAs.Text = "Save image As..";
            this.btnSaveImageAs.UseVisualStyleBackColor = true;
            this.btnSaveImageAs.Click += new System.EventHandler(this.btnSaveAsImg_Click);
            // 
            // btnSaveImg
            // 
            this.btnSaveImg.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSaveImg.Location = new System.Drawing.Point(3, 129);
            this.btnSaveImg.Name = "btnSaveImg";
            this.btnSaveImg.Size = new System.Drawing.Size(182, 23);
            this.btnSaveImg.TabIndex = 77;
            this.btnSaveImg.Text = "Save image";
            this.btnSaveImg.UseVisualStyleBackColor = true;
            this.btnSaveImg.Click += new System.EventHandler(this.btnSaveImg_Click);
            // 
            // txPPU
            // 
            this.txPPU.BackColor = System.Drawing.Color.Black;
            this.txPPU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txPPU.Dock = System.Windows.Forms.DockStyle.Top;
            this.txPPU.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txPPU.Location = new System.Drawing.Point(3, 116);
            this.txPPU.Name = "txPPU";
            this.txPPU.Size = new System.Drawing.Size(182, 13);
            this.txPPU.TabIndex = 10;
            this.txPPU.Text = "100";
            this.txPPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txPPU.TextChanged += new System.EventHandler(this.txPPU_TextChanged);
            this.txPPU.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txPPU_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "PPU [pixels/unit]:";
            // 
            // gbRender
            // 
            this.gbRender.AutoSize = true;
            this.gbRender.Controls.Add(this.rbRenderRelative);
            this.gbRender.Controls.Add(this.rbRenderAbsolute);
            this.gbRender.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRender.Location = new System.Drawing.Point(3, 50);
            this.gbRender.Name = "gbRender";
            this.gbRender.Size = new System.Drawing.Size(182, 53);
            this.gbRender.TabIndex = 1;
            this.gbRender.TabStop = false;
            this.gbRender.Text = "Render";
            // 
            // rbRenderRelative
            // 
            this.rbRenderRelative.AutoSize = true;
            this.rbRenderRelative.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbRenderRelative.Location = new System.Drawing.Point(3, 33);
            this.rbRenderRelative.Name = "rbRenderRelative";
            this.rbRenderRelative.Size = new System.Drawing.Size(176, 17);
            this.rbRenderRelative.TabIndex = 0;
            this.rbRenderRelative.Text = "Relative to robot - First person";
            this.rbRenderRelative.UseVisualStyleBackColor = true;
            this.rbRenderRelative.CheckedChanged += new System.EventHandler(this.rbRenderRelative_CheckedChanged);
            // 
            // rbRenderAbsolute
            // 
            this.rbRenderAbsolute.AutoSize = true;
            this.rbRenderAbsolute.Checked = true;
            this.rbRenderAbsolute.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbRenderAbsolute.Location = new System.Drawing.Point(3, 16);
            this.rbRenderAbsolute.Name = "rbRenderAbsolute";
            this.rbRenderAbsolute.Size = new System.Drawing.Size(176, 17);
            this.rbRenderAbsolute.TabIndex = 1;
            this.rbRenderAbsolute.TabStop = true;
            this.rbRenderAbsolute.Text = "Absolute to ground - Stationary";
            this.rbRenderAbsolute.UseVisualStyleBackColor = true;
            this.rbRenderAbsolute.CheckedChanged += new System.EventHandler(this.rbRenderAbsolute_CheckedChanged);
            // 
            // cxAntialias
            // 
            this.cxAntialias.AutoSize = true;
            this.cxAntialias.Checked = true;
            this.cxAntialias.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cxAntialias.Dock = System.Windows.Forms.DockStyle.Top;
            this.cxAntialias.Location = new System.Drawing.Point(3, 33);
            this.cxAntialias.Name = "cxAntialias";
            this.cxAntialias.Size = new System.Drawing.Size(182, 17);
            this.cxAntialias.TabIndex = 8;
            this.cxAntialias.Text = "Antialiasing";
            this.cxAntialias.UseVisualStyleBackColor = true;
            this.cxAntialias.CheckedChanged += new System.EventHandler(this.cxAntialias_CheckedChanged);
            // 
            // cxErrorEllipses
            // 
            this.cxErrorEllipses.AutoSize = true;
            this.cxErrorEllipses.Checked = true;
            this.cxErrorEllipses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cxErrorEllipses.Dock = System.Windows.Forms.DockStyle.Top;
            this.cxErrorEllipses.Enabled = false;
            this.cxErrorEllipses.Location = new System.Drawing.Point(3, 16);
            this.cxErrorEllipses.Name = "cxErrorEllipses";
            this.cxErrorEllipses.Size = new System.Drawing.Size(182, 17);
            this.cxErrorEllipses.TabIndex = 9;
            this.cxErrorEllipses.Text = "Error ellipses";
            this.cxErrorEllipses.UseVisualStyleBackColor = true;
            // 
            // gbHUD2
            // 
            this.gbHUD2.AutoSize = true;
            this.gbHUD2.Controls.Add(this.gbActual);
            this.gbHUD2.Controls.Add(this.txProb);
            this.gbHUD2.Controls.Add(this.label1);
            this.gbHUD2.Controls.Add(this.txIters);
            this.gbHUD2.Controls.Add(this.lbIters);
            this.gbHUD2.Controls.Add(this.txSteps);
            this.gbHUD2.Controls.Add(this.lbStep);
            this.gbHUD2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHUD2.Location = new System.Drawing.Point(0, 247);
            this.gbHUD2.Name = "gbHUD2";
            this.gbHUD2.Size = new System.Drawing.Size(188, 316);
            this.gbHUD2.TabIndex = 67;
            this.gbHUD2.TabStop = false;
            this.gbHUD2.Text = "HUD";
            // 
            // gbActual
            // 
            this.gbActual.AutoSize = true;
            this.gbActual.Controls.Add(this.txAct);
            this.gbActual.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbActual.Location = new System.Drawing.Point(3, 127);
            this.gbActual.Name = "gbActual";
            this.gbActual.Size = new System.Drawing.Size(182, 186);
            this.gbActual.TabIndex = 78;
            this.gbActual.TabStop = false;
            this.gbActual.Text = "Actual config";
            // 
            // txAct
            // 
            this.txAct.BackColor = System.Drawing.Color.Black;
            this.txAct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txAct.Dock = System.Windows.Forms.DockStyle.Top;
            this.txAct.Font = new System.Drawing.Font("Lucida Console", 8.074766F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txAct.ForeColor = System.Drawing.Color.White;
            this.txAct.Location = new System.Drawing.Point(3, 16);
            this.txAct.Multiline = true;
            this.txAct.Name = "txAct";
            this.txAct.ReadOnly = true;
            this.txAct.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txAct.Size = new System.Drawing.Size(176, 167);
            this.txAct.TabIndex = 77;
            // 
            // txProb
            // 
            this.txProb.BackColor = System.Drawing.Color.Black;
            this.txProb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txProb.Dock = System.Windows.Forms.DockStyle.Top;
            this.txProb.Font = new System.Drawing.Font("Lucida Console", 8.074766F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txProb.ForeColor = System.Drawing.Color.White;
            this.txProb.Location = new System.Drawing.Point(3, 81);
            this.txProb.Multiline = true;
            this.txProb.Name = "txProb";
            this.txProb.ReadOnly = true;
            this.txProb.Size = new System.Drawing.Size(182, 46);
            this.txProb.TabIndex = 77;
            this.txProb.Text = " 0 0 0 \r\n 0 0 0 \r\n 0 0 0 ";
            this.txProb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Prob-covariance:";
            // 
            // txIters
            // 
            this.txIters.BackColor = System.Drawing.Color.Black;
            this.txIters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txIters.Dock = System.Windows.Forms.DockStyle.Top;
            this.txIters.ForeColor = System.Drawing.Color.White;
            this.txIters.Location = new System.Drawing.Point(3, 55);
            this.txIters.Name = "txIters";
            this.txIters.ReadOnly = true;
            this.txIters.Size = new System.Drawing.Size(182, 13);
            this.txIters.TabIndex = 82;
            this.txIters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txIters.TextChanged += new System.EventHandler(this.txIters_TextChanged);
            // 
            // lbIters
            // 
            this.lbIters.AutoSize = true;
            this.lbIters.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbIters.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbIters.Location = new System.Drawing.Point(3, 42);
            this.lbIters.Name = "lbIters";
            this.lbIters.Size = new System.Drawing.Size(119, 13);
            this.lbIters.TabIndex = 81;
            this.lbIters.Text = "#of iters between 1PPS";
            // 
            // txSteps
            // 
            this.txSteps.BackColor = System.Drawing.Color.Black;
            this.txSteps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txSteps.Dock = System.Windows.Forms.DockStyle.Top;
            this.txSteps.ForeColor = System.Drawing.Color.White;
            this.txSteps.Location = new System.Drawing.Point(3, 29);
            this.txSteps.Name = "txSteps";
            this.txSteps.ReadOnly = true;
            this.txSteps.Size = new System.Drawing.Size(182, 13);
            this.txSteps.TabIndex = 79;
            this.txSteps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txSteps.TextChanged += new System.EventHandler(this.txSteps_TextChanged);
            // 
            // lbStep
            // 
            this.lbStep.AutoSize = true;
            this.lbStep.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbStep.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbStep.Location = new System.Drawing.Point(3, 16);
            this.lbStep.Name = "lbStep";
            this.lbStep.Size = new System.Drawing.Size(85, 13);
            this.lbStep.TabIndex = 80;
            this.lbStep.Text = "Steps from RST:";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.gbSend);
            this.groupBox2.Controls.Add(this.txLastCmd);
            this.groupBox2.Controls.Add(this.lbLastCmd);
            this.groupBox2.Controls.Add(this.btnSendConfigFile);
            this.groupBox2.Controls.Add(this.btnCmdList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 171);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PCMSG";
            // 
            // txLastCmd
            // 
            this.txLastCmd.BackColor = System.Drawing.Color.Black;
            this.txLastCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txLastCmd.Dock = System.Windows.Forms.DockStyle.Top;
            this.txLastCmd.ForeColor = System.Drawing.Color.White;
            this.txLastCmd.Location = new System.Drawing.Point(3, 75);
            this.txLastCmd.Multiline = true;
            this.txLastCmd.Name = "txLastCmd";
            this.txLastCmd.ReadOnly = true;
            this.txLastCmd.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txLastCmd.Size = new System.Drawing.Size(182, 31);
            this.txLastCmd.TabIndex = 75;
            // 
            // lbLastCmd
            // 
            this.lbLastCmd.AutoSize = true;
            this.lbLastCmd.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbLastCmd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbLastCmd.Location = new System.Drawing.Point(3, 62);
            this.lbLastCmd.Name = "lbLastCmd";
            this.lbLastCmd.Size = new System.Drawing.Size(72, 13);
            this.lbLastCmd.TabIndex = 76;
            this.lbLastCmd.Text = "last PCMSGs:";
            // 
            // btnSendConfigFile
            // 
            this.btnSendConfigFile.AutoSize = true;
            this.btnSendConfigFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSendConfigFile.Enabled = false;
            this.btnSendConfigFile.Location = new System.Drawing.Point(3, 39);
            this.btnSendConfigFile.Name = "btnSendConfigFile";
            this.btnSendConfigFile.Size = new System.Drawing.Size(182, 23);
            this.btnSendConfigFile.TabIndex = 6;
            this.btnSendConfigFile.Text = "Send Config &File";
            this.btnSendConfigFile.UseVisualStyleBackColor = true;
            this.btnSendConfigFile.Click += new System.EventHandler(this.SendConfigFile_Click);
            // 
            // btnCmdList
            // 
            this.btnCmdList.AutoSize = true;
            this.btnCmdList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCmdList.Location = new System.Drawing.Point(3, 16);
            this.btnCmdList.Name = "btnCmdList";
            this.btnCmdList.Size = new System.Drawing.Size(182, 23);
            this.btnCmdList.TabIndex = 5;
            this.btnCmdList.Text = "PCMSG Command &List";
            this.btnCmdList.UseVisualStyleBackColor = true;
            this.btnCmdList.Click += new System.EventHandler(this.btnCmdList_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.cbBaud);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 53);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port Control";
            // 
            // cbBaud
            // 
            this.cbBaud.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Items.AddRange(new object[] {
            "9600",
            "19200"});
            this.cbBaud.Location = new System.Drawing.Point(3, 29);
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(182, 21);
            this.cbBaud.TabIndex = 38;
            this.cbBaud.Text = "19200";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Baudrate:";
            // 
            // btnHide
            // 
            this.btnHide.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHide.Location = new System.Drawing.Point(0, 0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(188, 23);
            this.btnHide.TabIndex = 71;
            this.btnHide.Text = "<<  &Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // pbPaper
            // 
            this.pbPaper.AutoScroll = true;
            this.pbPaper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pbPaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPaper.Controls.Add(this.txIn);
            this.pbPaper.Controls.Add(this.pbMap);
            this.pbPaper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPaper.Location = new System.Drawing.Point(0, 0);
            this.pbPaper.Name = "pbPaper";
            this.pbPaper.Padding = new System.Windows.Forms.Padding(3);
            this.pbPaper.Size = new System.Drawing.Size(757, 615);
            this.pbPaper.TabIndex = 21;
            this.pbPaper.Visible = false;
            this.pbPaper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPaper_MouseDown);
            this.pbPaper.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPaper_MouseMove);
            this.pbPaper.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPaper_MouseUp);
            // 
            // txIn
            // 
            this.txIn.Location = new System.Drawing.Point(128, 661);
            this.txIn.Name = "txIn";
            this.txIn.Size = new System.Drawing.Size(654, 20);
            this.txIn.TabIndex = 24;
            this.txIn.Text = "^UTC 80.01.01 00:00:00 ??%ma 1X-5.350624086002955e-02Y-6.707316494976341e-01A2.98" +
                "238390800254P11b22c33d44e55f66$\r\n";
            this.txIn.Visible = false;
            // 
            // pbMap
            // 
            this.pbMap.BackColor = System.Drawing.Color.White;
            this.pbMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMap.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbMap.Location = new System.Drawing.Point(6, 6);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(1600, 1600);
            this.pbMap.TabIndex = 23;
            this.pbMap.TabStop = false;
            this.pbMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseDown);
            this.pbMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseMove);
            this.pbMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseUp);
            // 
            // ofdConfigFile
            // 
            this.ofdConfigFile.FileName = "config.ini";
            // 
            // sfdImage
            // 
            this.sfdImage.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdImage_FileOk);
            // 
            // commandListToolStripMenuItem
            // 
            this.commandListToolStripMenuItem.Name = "commandListToolStripMenuItem";
            this.commandListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.commandListToolStripMenuItem.Text = "Comman&d List";
            this.commandListToolStripMenuItem.Click += new System.EventHandler(this.commandListToolStripMenuItem_Click);
            // 
            // gbSend
            // 
            this.gbSend.AutoSize = true;
            this.gbSend.Controls.Add(this.btnSend);
            this.gbSend.Controls.Add(this.txSend);
            this.gbSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSend.Location = new System.Drawing.Point(3, 106);
            this.gbSend.Name = "gbSend";
            this.gbSend.Size = new System.Drawing.Size(182, 62);
            this.gbSend.TabIndex = 77;
            this.gbSend.TabStop = false;
            this.gbSend.Text = "Sending:";
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = true;
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSend.Location = new System.Drawing.Point(3, 36);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(176, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "&Send - Click more times";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txSend
            // 
            this.txSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.txSend.Location = new System.Drawing.Point(3, 16);
            this.txSend.Name = "txSend";
            this.txSend.Size = new System.Drawing.Size(176, 20);
            this.txSend.TabIndex = 4;
            this.txSend.Text = "^GC$";
            this.txSend.TextChanged += new System.EventHandler(this.txSend_TextChanged);
            // 
            // foMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 650);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.txLast);
            this.Controls.Add(this.ssMain);
            this.Name = "foMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ODOMAT 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.foMain_FormClosing);
            this.Load += new System.EventHandler(this.foMain_Load);
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.pnLeft.ResumeLayout(false);
            this.pnLeft.PerformLayout();
            this.gbView.ResumeLayout(false);
            this.gbView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbZoomMax)).EndInit();
            this.gbHUD.ResumeLayout(false);
            this.gbHUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProbCov)).EndInit();
            this.gbPortcontrol.ResumeLayout(false);
            this.gbPortcontrol.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.spcRight.Panel1.ResumeLayout(false);
            this.spcRight.Panel1.PerformLayout();
            this.spcRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcRight)).EndInit();
            this.spcRight.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbRender.ResumeLayout(false);
            this.gbRender.PerformLayout();
            this.gbHUD2.ResumeLayout(false);
            this.gbHUD2.PerformLayout();
            this.gbActual.ResumeLayout(false);
            this.gbActual.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pbPaper.ResumeLayout(false);
            this.pbPaper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.gbSend.ResumeLayout(false);
            this.gbSend.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort srpOdo;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.Timer timSim;
        private System.Windows.Forms.ToolStripStatusLabel sslMain;
        private System.Windows.Forms.TextBox txLast;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.GroupBox gbPortcontrol;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRescanPorts;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Label lbSelectPort;
        private System.Windows.Forms.GroupBox gbHUD;
        private System.Windows.Forms.Label lbAng;
        private System.Windows.Forms.TextBox txAngle;
        private System.Windows.Forms.Label lbPos;
        private System.Windows.Forms.TextBox txPosX;
        private System.Windows.Forms.TextBox txPosY;
        private System.Windows.Forms.TextBox txUnits;
        private System.Windows.Forms.Label lbUnit;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsiView;
        private System.Windows.Forms.ToolStripMenuItem tsmLogger;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.Panel pbPaper;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.GroupBox gbView;
        private System.Windows.Forms.Label lbZoomMin;
        private System.Windows.Forms.Label lbZoomMax;
        private System.Windows.Forms.Label lbZoomOne;
        private System.Windows.Forms.TrackBar trbZoomMax;
        private System.Windows.Forms.Label lbPPU2;
        private System.Windows.Forms.ToolStripStatusLabel sslSeparator;
        private System.Windows.Forms.ToolStripStatusLabel sslCursor;
        private System.Windows.Forms.Label lbProb;
        private System.Windows.Forms.TextBox txIn;
        private System.Windows.Forms.PictureBox pbProbCov;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.SplitContainer spcRight;
        private System.Windows.Forms.GroupBox gbHUD2;
        private System.Windows.Forms.TextBox txProb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofdConfigFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSendConfigFile;
        private System.Windows.Forms.Button btnCmdList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbRender;
        private System.Windows.Forms.RadioButton rbRenderRelative;
        private System.Windows.Forms.RadioButton rbRenderAbsolute;
        private System.Windows.Forms.CheckBox cxAntialias;
        private System.Windows.Forms.ToolStripMenuItem ttmConfig;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.CheckBox cxErrorEllipses;
        private System.Windows.Forms.Button btnResetRobotPos;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.TextBox txLastCmd;
        private System.Windows.Forms.Label lbLastCmd;
        private System.Windows.Forms.TextBox txPPU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveImg;
        private System.Windows.Forms.GroupBox gbActual;
        private System.Windows.Forms.TextBox txAct;
        private System.Windows.Forms.TextBox txIters;
        private System.Windows.Forms.Label lbIters;
        private System.Windows.Forms.TextBox txSteps;
        private System.Windows.Forms.Label lbStep;
        private System.Windows.Forms.Button btnSaveImageAs;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandListToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txSend;

    }
}

