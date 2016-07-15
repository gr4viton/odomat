using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.IO.Ports;
using System.IO;

using System.Threading;
/*
using System.Globalization;
using System.Collections; // for enumerators when applying multiple filters
*/


namespace vis {

    public enum E_GUI_MainState {
        loading = -1,
        ready = 0,
        port_ScanningPorts,
        port_CouldOpenPort,
        recieved_stmmsg,
        error
    }
    public partial class foMain : Form {
        C_GUI GUI;
        foLog fLog;
        foCmds fCmds;
        //foConfig fConfig;

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #region STATES
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        E_GUI_MainState state = E_GUI_MainState.loading;
        const int MSG_LEN = 400;
        bool PROG_QUITTING = false;



        void SET_state(E_GUI_MainState a) {
            if (a == state) return;
            state = a;
            switch (a) {
                case (E_GUI_MainState.loading):
                    sslMain.Text = "Loading";
                    break;
                case (E_GUI_MainState.ready):
                    sslMain.Text = "Ready for everything";
                    break;
                case (E_GUI_MainState.recieved_stmmsg):
                    sslMain.Text = "Recieved odomsg -> Computing";
                    break;
                case (E_GUI_MainState.error):
                    sslMain.Text = "Fatal error has occured please restart the program";
                    break;/*
                case (E_GUI_MainState.):
                    tslMain.Text = "";
                    break;
                case (E_GUI_MainState.):
                    tslMain.Text = "";
                    break;
                case (E_GUI_MainState.):
                    tslMain.Text = "";
                    break;*/
            }
        }

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #endregion STATES
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #region foMAIN
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        public foMain() {
            InitializeComponent();
        }

        private void foMain_Load(object sender, EventArgs e) {
            SET_state(E_GUI_MainState.loading);
            //GUI = new C_GUI(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //GUI = new C_GUI();
            GUI = new C_GUI(pbMap.Width, pbMap.Height);

            fLog = new foLog();
            fCmds = new foCmds();
            //fConfig = new foConfig();

            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height - 176 - 40);
            //176

            fLog.Size = new Size(Screen.PrimaryScreen.Bounds.Width, 176);
            fLog.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - 176 - 40);

            fLog.Show();
            //fConfig.Show();


            //events for config
            //fConfig.ConfigChange += GUI.draw.UPDATE_FromConfig;
            //fConfig.ConfigChange += fLog.log

            fLog.log.ODOParseComplete += ODOParseComplete_EventHandler;
            fLog.log.ACTParseComplete += ACTParseComplete_EventHandler;
            //fLog.ConfigShow += ConfigShow_EventHandler;
            fLog.NewLogLoaded += NewLogLoaded_EventHandler;

            // init draw
            GUI.draw.graMap = pbMap.CreateGraphics();

            timSim.Enabled = true;

            GUI_Port_LoadPorts();
            pbPaper.Visible = true;
            SET_state(E_GUI_MainState.ready);
        }

        private void foMain_FormClosing(object sender, FormClosingEventArgs e) {
            GUI_Port_Close();
        }

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #endregion // foMAIN
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #region EVENT_HANDLERS
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        /*
        private void ConfigShow_EventHandler(object sender, EventArgs e) {
            fConfig.Show();
        }*/
        private void NewLogLoaded_EventHandler(object sender, foLog.NewLogLoadedEventArgs e) {
            GUI.draw.first_income = true;
            if (e.erase_trajectory)
                GUI.draw.ERASE_trajectory();
        }
        private void ACTParseComplete_EventHandler(object sender, C_log.ACTParseCompleteEventArgs e) {
            string format_xy = "0.00000";
            string format_th = "0.0000";
            string format_P = "0.0#e0";
            //string format_P = " 0.0#e0;-0.0#e0";
            txAct.Text =
                "base; rL; rR; " + "\r\n" +
                e.b.ToString(format_xy) +  ";" + e.rL.ToString(format_xy) + ";" +e.rR.ToString(format_xy) + "\r\n" +
                "TL; TR=" + "\r\n" +
                e.TL.ToString() + "; " + e.TR.ToString() + "\r\n" +
                "eL; eR=" + "\r\n" +
                e.eL.ToString() + "; " + e.eR.ToString() + "\r\n" +
                "iter_type: " + ((char)(e.iter_type)).ToString() + "\r\n" +
                "iter_trigger: " + e.iter_trigger + "\r\n" +
                "Q11; Q22; Q33=" + "\r\n" +
                e.Q11.ToString(format_P) + "; " + e.Q22.ToString(format_P) + "; " + e.Q33.ToString(format_P) + "\r\n" +
                "START_xyth=" + "\r\n" +
                e.START_x.ToString(format_xy) + "; " + e.START_y.ToString(format_xy) + "; " + e.START_th.ToString(format_th) + "\r\n" +
                "";


        }



        private void ODOParseComplete_EventHandler(object sender, C_log.ODOParseCompleteEventArgs e) {
            //fLog.log.th = e.ang + Math.PI / 2;//Math.PI * e.ang / 180;
            GUI.draw.r.th = e.th + Math.PI / 2;

            if (e.isRelative) {
                //fLog.log.posR = new PointF(e.pos.X, e.pos.Y);
                GUI.draw.r.UPDATE_rel(e.x, e.y);
            }
            else {
                //fLog.log.posA = new PointF(e.pos.X, e.pos.Y);
                GUI.draw.r.UPDATE_abs(e.x, e.y);
            }

            if (GUI.draw.renderRelative) {
                pbMap.Left = pbPaper.Width / 2 - (GUI.draw.origin.X + (int)(GUI.draw.r.xI * GUI.draw.ppu));
                pbMap.Top = pbPaper.Height / 2 - (GUI.draw.origin.Y + (int)(GUI.draw.r.yI * GUI.draw.ppu));
            }

            GUI.draw.graMap.DrawImage(
                GUI.draw.DRAW_imaAll(), new Point()
                );

            // new thread
            //actualize HUD txs
            //lb
            /*
            txPosX.Text = (fLog.log.posA.X + fLog.log.posR.X).ToString("0.0000");
            txPosY.Text = (fLog.log.posA.Y + fLog.log.posR.Y).ToString("0.0000");
            txAngle.Text = fLog.log.th.ToString("0.0000");
             */

            string format_xy = "0.00000";
            string format_th = "0.00000";
            //string format_P = "0.0#e0";
            string format_P = " 0.0#e0;-0.0#e0";
            txPosX.Text = GUI.draw.r.x.ToString(format_xy);
            txPosY.Text = GUI.draw.r.y.ToString(format_xy);
            txAngle.Text = (e.th * 180 / 2 / Math.PI).ToString(format_th) + "°";
            txProb.Text =
                e.P[0].ToString(format_P) + "|" + e.P[1].ToString(format_P) + "|" + e.P[2].ToString(format_P)
                + "\r\n" +
                e.P[1].ToString(format_P) + "|" + e.P[3].ToString(format_P) + "|" + e.P[4].ToString(format_P)
                + "\r\n" +
                e.P[2].ToString(format_P) + "|" + e.P[4].ToString(format_P) + "|" + e.P[5].ToString(format_P)
                ;
            txIters.Text = e.iters.ToString();
            txSteps.Text = e.steps.ToString();

            //eigenvectors -> not that simple
            /*
            GUI.draw.r.axeA = e.P[0];
            GUI.draw.r.axeB = e.P[3];
            */

            /*
            string str = e.odo.ToString(format_xy) + " , " + e.odo.ToString(format_xy);
            MessageBox.Show(str);
             */
            txUnits.Text = e.unit.ToString();

            /*GUI.draw.UPDATE_lastLine_abs(new Point(
                Convert.ToInt32(e.pos.X),
                Convert.ToInt32(e.pos.Y)
                ));
             */
            //GUI.draw.
        }

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #endregion EVENT_HANDLERS
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #region ODOM
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        // delegate for thread safe reacting on serial dataReceive
        delegate void ODOM_ProcessMsg_Callback(string text);

        private void ODOM_ProcessMsg(string msg) {
            if (this.txLast.InvokeRequired) {
                try {
                    ODOM_ProcessMsg_Callback d = new ODOM_ProcessMsg_Callback(ODOM_ProcessMsg);
                    this.Invoke(d, new object[] { msg });
                }
                catch { }
            }
            else {
                //msg = txIn.Text;

                fLog.ODOM_AddMsg(msg);
                // only ODOMSG into txLast
                if (msg[0] == '^')
                    txLast.Text = msg;
            }
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #endregion ODOM
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #region srpOdo
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        private void srpOdo_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {
            fLog.log.notProcessed = true;
            if (PROG_QUITTING)
                System.Threading.Thread.Yield();

            try {
                char[] stmmsg = new char[MSG_LEN];
                char ch = '0';
                int i = 0;

                while ((srpOdo.IsOpen) && (srpOdo.ReadBufferSize != 0) && (ch != '$') && (ch != '\n') && (i < MSG_LEN)) {
                    //while ((srpOdo.IsOpen) && (srpOdo.ReadBufferSize != 0) && (ch != '\n') && (i < MSG_LEN)) {
                    ch = (char)srpOdo.ReadByte();
                    stmmsg[i++] = ch;
                    fLog.log.lastReceivedChar = ch;
                }
                i = 0;
                string str = new string(stmmsg);
                if (str.IndexOf('^') >= 0 || str.IndexOf('_') >= 0) {
                    fLog.log.lastMsg = str;
                    if (fLog.log.lastMsg == "") fLog.log.lastMsg = "nothing";

                    //ODOM_ProcessMsg();
                    // new thread
                    ODOM_ProcessMsg(fLog.log.lastMsg);

                    SET_state(E_GUI_MainState.recieved_stmmsg);
                    //txLast.Text = fLog.log.lastMsg;
                    fLog.log.notProcessed = false;
                }
            }
            catch (Exception ex) {
                ODOM_ProcessMsg("exception = " + ex.Message);
                SET_state(E_GUI_MainState.error);

            }
        }

        private void srpOdo_ErrorReceived(object sender, SerialErrorReceivedEventArgs e) {
            //SerialError.
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #endregion srpOdo
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #region GUI_Port
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        // simplifies the checking rutine
        private bool GUI_Port_isPortOpened() {
            if (srpOdo.IsOpen) {
                return (true);
            }
            else {
                MessageBox.Show("Connection to serial port is not established");
                return (false);
            }
        }

        private bool GUI_Port_isPortOpened2() {
            if (srpOdo.IsOpen) {
                return (true);
            }
            else {
                return (false);
            }
        }
        private bool GUI_Port_isPortLoaded() {
            if (cbPorts.Items.Count > 0) {
                return (true);
            }
            else {
                MessageBox.Show("No COM port found");
                return (false);
            }
        }


        private void GUI_Port_LoadPorts() {
            string[] allPorts;
            try {/*
                mainState = E_GUI_All_MainState.port_ScanningPorts;
                GUI.SC.portState = E_PortState.notConnected;
                GUI_SC_UpdateToolStrips();
                */

                cbPorts.Items.Clear();
                allPorts = SerialPort.GetPortNames();

                foreach (string port in allPorts) {
                    cbPorts.Items.Add(port);
                }

                cbPorts.SelectedIndex = 0;
            }
            catch (Exception)//Win32Exception)
            {/*
                MessageBox.Show(fStringResources.msg_port_NoCOMPortFound.Text);
                GUI.SC.portState = E_PortState.noPortsFound;
                GUI_SC_UpdateToolStrips();
              */
            }
        }

        private void GUI_Port_Connect() {
            if (!GUI_Port_isPortLoaded()) return;
            if (srpOdo.IsOpen) {

                DialogResult me = MessageBox.Show(
                    "The port " + srpOdo.PortName +
                    " is already opened, please close it and than try again!",
                    srpOdo.PortName + "is opened elsewhere",
                    MessageBoxButtons.RetryCancel);
                if (me == System.Windows.Forms.DialogResult.Cancel)
                    return;
                else {
                    GUI_Port_Connect();
                    return;
                }
            }
            sslMain.Text = "Trying to connect (" + srpOdo + ")";
            try {
                srpOdo.BaudRate = Convert.ToInt32(cbBaud.Text);
                srpOdo.PortName = cbPorts.Text;
                srpOdo.Open();

                if (srpOdo.IsOpen) {
                    cbPorts.Enabled = false;
                    cbBaud.Enabled = false;
                    btnSendConfigFile.Enabled = true;
                    btnRescanPorts.Enabled = false;
                    btnConnect.Text = "&Close connection";
                    sslMain.Text = "Port " + cbPorts.Text + " opened, waiting for incoming data";
                    //btnConnect.Enabled = false;
                }
            }
            catch (Exception) {
                /*
                MessageBox.Show(fStringResources.msg_port_CannotOpenPort + cbPorts.Text);
                mainState = E_GUI_All_MainState.port_CouldOpenPort;
                sslMainStatus.Text = sslMainStatus.Text + cbPorts.Text;
                 */

            }
        }
        private void GUI_Port_Close_fnc() {
            //srpOdo.DiscardInBuffer();
            //srpOdo.DiscardOutBuffer();
            srpOdo.Close();
            Thread.Yield();
            PROG_QUITTING = false;
        }
        private void GUI_Port_Close() {
            GUI.draw.first_income = true;
            PROG_QUITTING = true;
            Thread dexter = new Thread(new ThreadStart(GUI_Port_Close_fnc)); // the serial_killer
            dexter.Start();

            System.Threading.Thread.Sleep(500);
            if (!GUI_Port_isPortOpened2()) {
                cbPorts.Enabled = true;
                cbBaud.Enabled = true;
                btnRescanPorts.Enabled = true;
                btnSendConfigFile.Enabled = false;
                btnConnect.Text = "&Connect";
                sslMain.Text = "Port closed";
                PROG_QUITTING = false;
            }
        }



        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #endregion GUI_ports
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #region btn
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        private void btnRescanPorts_Click(object sender, EventArgs e) {
            GUI_Port_LoadPorts();
        }

        private void btnConnect_Click(object sender, EventArgs e) {
            if (btnRescanPorts.Enabled == true)
                GUI_Port_Connect();
            else
                GUI_Port_Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            //fLog.log.lastMsg = "Nope";
            if (timSim.Enabled == true)
                timSim.Enabled = false;
            else
                timSim.Enabled = true;
            //ODOM_ProcessMsg();
        }

        private void btnSend_Click(object sender, EventArgs e) {
            GUI_PCMSG_SEND(txSend.Text);
        }

        private void tsmLogger_Click(object sender, EventArgs e) {
            fLog.Show();
        }

        private void btnRedraw_Click(object sender, EventArgs e) {
            GUI.draw.REDRAW();
        }
        private void btnErase_Click(object sender, EventArgs e) {
            GUI.draw.ERASE_trajectory();
        }

        private void trbZoomMax_ValueChanged_1(object sender, EventArgs e) {
            // zoomRatio update
            double val = trbZoomMax.Value;
            //GUI.draw.zoom = Math.Pow(2, ((val - 1) / 100 - 4)); ;
            //GUI_Zoom();
            GUI.draw.ppu = Math.Ceiling(Math.Pow(2, ((val - 1) / 10)));
            GUI.draw.ERASE_trajectory();
            txPPU.Text = GUI.draw.ppu.ToString();
        }


        // spcRight hiding
        private void ttmConfig_Click(object sender, EventArgs e) {
            spcRight.Panel1Collapsed = false;
        }
        private void btnHide_Click(object sender, EventArgs e) {
            spcRight.Panel1Collapsed = true;
        }

        private void SendConfigFile_Click(object sender, EventArgs e) {
            DialogResult m = ofdConfigFile.ShowDialog();
            if (m == System.Windows.Forms.DialogResult.OK) {

                String line;
                try {
                    using (StreamReader sr = new StreamReader(ofdConfigFile.FileName)) {
                        line = sr.ReadToEnd();
                        //Console.WriteLine(line);
                    }
                }
                catch (Exception ex) {

                    MessageBox.Show("The file could not be read: " + ex.Message);

                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(ex.Message);
                    return;
                }

                line = GUI_PCMSG_corrector(line);
                DialogResult me = MessageBox.Show(
                    "Do you really want to send this PCMSG? \n" + line, "ORLY?",
                    MessageBoxButtons.YesNo);
                if (me == System.Windows.Forms.DialogResult.Yes) {
                    srpOdo.WriteLine(line);
                }
            }


        }

        private void btnResetRobotPos_Click(object sender, EventArgs e) {
            GUI.draw.r.x = 0;
            GUI.draw.r.y = 0;
        }

        private void btnSaveImg_Click(object sender, EventArgs e) {

            /*string filename = Path.GetFullPath(fLog.txTxtPath.Text);
            filename = filename.Substring(0,filename.Length -3) + "png";
            filename = Path.GetFullPath(filename);

            if( File.Exists( filename ) )
                if (DialogResult.No == MessageBox.Show(
                    "The file with the name \"" +filename
                    + "\" exists,\r\nDo you want to rewrite it?","ORLY", MessageBoxButtons.YesNo) )
                    btnSaveAsImg_Click(sender,e);
                    //GUI.draw.imaAll.Save(filename.Substring(0,filename.Length -4) + "I" +".png");

            GUI.draw.imaAll.Save(filename);
            */
            if (DialogResult.Yes == sfdImage.ShowDialog()) {
                GUI.draw.imaAll.Save(sfdImage.FileName, System.Drawing.Imaging.ImageFormat.Png);
                //bmp1.Save("c:\\button.gif", System.Drawing.Imaging.ImageFormat.Gif);
            }
        }

        private void btnSaveAsImg_Click(object sender, EventArgs e) {
            sfdImage.FileName = Path.GetFullPath(fLog.txTxtPath.Text);
            if (DialogResult.Yes == sfdImage.ShowDialog()) 
            {
                GUI.draw.imaAll.Save(sfdImage.FileName);
            }

        }

        private void txSend_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                GUI_PCMSG_SEND(txSend.Text);
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #endregion btn
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #region mouse
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        private void GUI_Zoom() {
            pbMap.SizeMode = PictureBoxSizeMode.StretchImage;
            pbMap.Size = new System.Drawing.Size(
                (int)((double)GUI.draw.w * GUI.draw.zoom),
                (int)((double)GUI.draw.h * GUI.draw.zoom)
                );
        }

        private void GUI_GE_sslCursor(int curX, int curY) {

            sslCursor.Text = string.Format("[{0} | {1}] px = [{2} | {3}] {4}",
                curX - GUI.draw.origin.X, curY - GUI.draw.origin.Y,
                ((curX - GUI.draw.origin.X) / GUI.draw.ppu).ToString("0.000"),
                ((curY - GUI.draw.origin.Y) / GUI.draw.ppu).ToString("0.000"),
                GUI.draw.r.unit
                );
            //sslCursor.Text = string.Format("Position: {0}, {1};  ClickAt: {2}, {3}",
            //curX, curY, GUI.Mouse.ClickAt.X, GUI.Mouse.ClickAt.Y);
        }

        private void GUI_GE_MouseUp() {
            GUI.mouse.lPressed = false;
        }

        private void pbMap_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                GUI.mouse.clickAt = new Point(e.X, e.Y);
                GUI.mouse.lPressed = true;
            }
            else if (e.Button == MouseButtons.Right) {
                if (GUI.draw.origin.X == e.X && GUI.draw.origin.Y == e.Y) GUI.draw.ERASE_trajectory();
                GUI.draw.origin.X = e.X;
                GUI.draw.origin.Y = e.Y;

            }
            GUI.draw.REDRAW();
        }

        private void pbMap_MouseMove(object sender, MouseEventArgs e) {
            GUI_GE_sslCursor(e.X, e.Y);
            if (GUI.mouse.lPressed) {
                pbMap.Left += e.X - GUI.mouse.clickAt.X;
                pbMap.Top += e.Y - GUI.mouse.clickAt.Y;
            }
            //GUI.draw.REDRAW();

        }
        private void pbMap_MouseUp(object sender, MouseEventArgs e) {
            GUI_GE_MouseUp();
            GUI.draw.REDRAW();
        }


        private void pbPaper_MouseUp(object sender, MouseEventArgs e) {
            GUI_GE_MouseUp();
        }

        private void pbPaper_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                GUI.mouse.clickAt = new Point(
                    e.X - pbMap.Location.X,
                    e.Y - pbMap.Location.Y);
                GUI.mouse.lPressed = true;
            }
        }
        private void pbPaper_MouseMove(object sender, MouseEventArgs e) {
            if (GUI.mouse.lPressed) {
                pbMap.Left = e.X - GUI.mouse.clickAt.X;
                pbMap.Top = e.Y - GUI.mouse.clickAt.Y;
            }
        }

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #endregion //mouse
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #region VIEW

        private void cxAntialias_CheckedChanged(object sender, EventArgs e) {
            GUI.draw.SET_antialias(cxAntialias.Checked);
        }

        private void rbRenderAbsolute_CheckedChanged(object sender, EventArgs e) {
            GUI.draw.renderRelative = false;
        }

        private void rbRenderRelative_CheckedChanged(object sender, EventArgs e) {
            GUI.draw.renderRelative = true;
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #endregion // VIEW
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #region GUI_PCMSG
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        string GUI_PCMSG_corrector(string line) {
            if (line[line.Length - 1] != '$') {
                line = line + "$";
            }
            return line;
        }

        void GUI_PCMSG_SEND(string cmd) {
            if (!srpOdo.IsOpen) return;
            srpOdo.Write(cmd);
            txLastCmd.AppendText("\r\n" + cmd);
        }
        #endregion

        private void trbZoomMax_Scroll(object sender, EventArgs e) {

        }

        private void txPPU_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                GUI_GE_PPU_String(txPPU.Text);
            }
        }
        void GUI_GE_PPU_String(string str) {
            int resI = 0;
            if (int.TryParse(str, out resI)) {
                GUI.draw.ppu = resI;
                GUI.draw.ERASE_trajectory();
            }
        }
        private void txSend_TextChanged(object sender, EventArgs e) {

        }

        private void txPPU_TextChanged(object sender, EventArgs e) {

        }

        private void txIters_TextChanged(object sender, EventArgs e) {
            int resI = 0;
            if (int.TryParse(txIters.Text, out resI)) {
                if (resI > 1)
                    txIters.BackColor = Color.DarkRed;
                else
                    txIters.BackColor = Color.Black;
            }
        }

        private void txSteps_TextChanged(object sender, EventArgs e) {

            int resI = 0;
            if (int.TryParse(txSteps.Text, out resI)) {
                if (resI > 16000)
                    txSteps.BackColor = Color.DarkRed;
                else
                    txSteps.BackColor = Color.Black;
            }
        }

        private void sfdImage_FileOk(object sender, CancelEventArgs e) {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            string str = "Obslužný a vizualizační program pro odometrický modul enviromentálně mapujícího robotu envMap" +
                "Daniel Davídek, 2013";
            MessageBox.Show(str,"FEKT VUT Brno 2013");
        }

        private void commandListToolStripMenuItem_Click(object sender, EventArgs e) {
            fCmds.Show();
        }

        private void btnCmdList_Click(object sender, EventArgs e) {
            fCmds.Show();
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%











    }


}


