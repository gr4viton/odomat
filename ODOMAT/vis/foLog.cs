using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using System.IO;

namespace vis {
    public partial class foLog : Form {

        bool changing_default_directory;
        public foLog() {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                this.Hide();
                e.Cancel = true;
            }
        }





        public event EventHandler<EventArgs> ConfigShow;
        public event EventHandler<NewLogLoadedEventArgs> NewLogLoaded;

        public class NewLogLoadedEventArgs : EventArgs {
            public bool erase_trajectory;
            public NewLogLoadedEventArgs(bool a_erase_trajectory) {
                a_erase_trajectory = erase_trajectory;
            }
        }

        protected virtual void OnConfigShow(EventArgs e) {
            if (ConfigShow != null) ConfigShow(this, e);
        }

        protected virtual void OnNewLogLoaded(NewLogLoadedEventArgs e) {
            if (NewLogLoaded != null) NewLogLoaded(this, e);
        }

        public C_log log;

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        public void ODOM_AddMsg(string stmmsg) {
            //if (txLog.Text != "")
            if (cbIgnoreMessages.Checked == false) {
                txLog.AppendText(Environment.NewLine);
                txLog.AppendText(stmmsg);
            }
            //txLog.Text += Environment.NewLine;

            // new thread
            log.Parse(stmmsg);

            /*
            txLog.AppendText(
                Environment.NewLine +
                " ODO = " + log.odo.lastValid +
                Environment.NewLine +
                " X = " + (log.odo as C_MsgOdoPart).pos.X.ToString() +
                "; " +
                " Y = " + (log.odo as C_MsgOdoPart).pos.Y.ToString() +
                "; " +
                " A = " + (log.odo as C_MsgOdoPart).ang.ToString() +
                "; " +
                " CONF = " + log.conf.lastValid +
                Environment.NewLine +
                " isRelative = " + log.conf.isRelative.ToString() +
                Environment.NewLine +
                " UTC = " + log.utc.lastValid +
                Environment.NewLine +
                "----------------------------"
                );
            */


        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        private void foLog_Load(object sender, EventArgs e) {
            log = new C_log();
            changing_default_directory = false;
        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void foLog_FormClosing(object sender, FormClosingEventArgs e) {

        }

        private void txLog_TextChanged(object sender, EventArgs e) {

        }

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        // SAVE & LOAD
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        private void sfdCsvPath_FileOk(object sender, CancelEventArgs e) {
            // button =
            if (changing_default_directory == true) {
                if (System.IO.Directory.Exists(sfdCSV.FileName)) {
                    txCsvPath.Text = sfdCSV.FileName;
                }
                changing_default_directory = false;
            }
            //button save
            else {
                // rozparsovane uložit
            }

        }

        private void sfdTxtPath_FileOk(object sender, CancelEventArgs e) {
            // button =
            if (changing_default_directory == true) {
                if (System.IO.Directory.Exists(sfdCSV.FileName)) {
                    txCsvPath.Text = sfdCSV.FileName;
                }
                changing_default_directory = false;
            }
            //button save
            else {
                LOG_SAVE();
            }

        }
        public void LOG_SAVE() {
            if( File.Exists( sfdTEXT.FileName ) )
                if (DialogResult.No == MessageBox.Show(
                    "The file with the name \"" +sfdTEXT.FileName
                    + "\" exists,\r\nDo you want to rewrite it?","ORLY", MessageBoxButtons.YesNo) )
                    return;


            using (StreamWriter outfile = new StreamWriter(sfdTEXT.FileName)) {
                outfile.Write(txLog.Text);
            }
        }
        private void ofdLoad_FileOk(object sender, CancelEventArgs e) {

        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        // BTNs
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        private void btnTxtPathChange_Click(object sender, EventArgs e) {
            if (System.IO.Directory.Exists(txTxtPath.Text)) {
                sfdTEXT.InitialDirectory = System.IO.Path.GetDirectoryName(txTxtPath.Text);
                sfdTEXT.RestoreDirectory = true;
            }
            changing_default_directory = true;
            sfdTEXT.ShowDialog();
        }

        private void btnCsvPathChange_Click(object sender, EventArgs e) {
            if (System.IO.Directory.Exists(txCsvPath.Text)) {
                sfdCSV.InitialDirectory = System.IO.Path.GetDirectoryName(txCsvPath.Text);
                sfdCSV.RestoreDirectory = true;
            }
            changing_default_directory = true;
            sfdCSV.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            /*
            DialogResult m = MessageBox.Show(
                "This would erase your current log. \nDo you really want to load other log?",
                "ORLY?", MessageBoxButtons.YesNo);
             */
            DialogResult m = ofdLoad.ShowDialog();
            if (m == System.Windows.Forms.DialogResult.OK) {

                String line;
                try {
                    using (StreamReader sr = new StreamReader(ofdLoad.FileName)) {
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

                txLog.Text = "";
                txLog.Text = line;


                DialogResult me = MessageBox.Show(
                    "Do you want to erase the previous trajectory?", "Trajectory erase",
                    MessageBoxButtons.YesNo);
                if (me == System.Windows.Forms.DialogResult.Yes)
                    OnNewLogLoaded(new NewLogLoadedEventArgs(true));
                else
                    OnNewLogLoaded(new NewLogLoadedEventArgs(false));


                TextReader read = new System.IO.StringReader(txLog.Text);
                int rows = 100;
                
                
                //string[] text1 = new string[rows];
                for (int r = 1; r < rows; r++) {
                    line = read.ReadLine();
                    if (line.Length > 0)
                    ODOM_AddMsg( line.Remove(line.Length - 2) );
                }

                /*
                using (StringReader reader = new StringReader(txLog.Text)) {
                    line = string.Empty;
                    do {
                        line = reader.ReadLine();
                        if (line != null) {
                            // do something with the line
                            ODOM_AddMsg(line);
                        }

                    } while (line != null);
                }*/

            }


        }

        private void btnSaveMore_Click(object sender, EventArgs e) {
            sfdCSV.ShowDialog();
        }

        private void btnSaveTextLog_Click(object sender, EventArgs e) {
            //LOG_SAVE();
            if (DialogResult.Yes == sfdTEXT.ShowDialog()) {

                using (StreamWriter outfile = new StreamWriter(sfdTEXT.FileName)) {
                    outfile.Write(txLog.Text);
                }
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e) {
            if (MessageBox.Show(
                "Do you really want to erase the contents of log?",
                "ORLY?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                txLog.Text = "";
        }

        private void cbIgnoreMessages_CheckedChanged(object sender, EventArgs e) {
            if (cbIgnoreMessages.Checked == true) {
                cbIgnoreMessages.BackColor = Color.Red;
            }else{
                cbIgnoreMessages.BackColor = Color.Gray;
            }
        }

        private void txTxtPath_TextChanged(object sender, EventArgs e) {
            txTxtPath.BackColor = Color.DarkRed;
        }

        private void txTxtPath_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                txTxtPath.Text = Path.GetFullPath(txTxtPath.Text);
                txTxtPath.BackColor = Color.Black ;
            }
        }

        private void LOG_DIRECTORY(string folder) {
            txTxtPath.Text = Path.GetFullPath(  "C:\\ODO\\" + folder + "\\" + Path.GetFileName( txTxtPath.Text ));
            txTxtPath.BackColor = Color.Black;
            txInsert.Text = "MERENI" + folder;
        }
        private void rbXX_CheckedChanged(object sender, EventArgs e) {
            LOG_DIRECTORY((sender as RadioButton).Text);
        }

        private void txInsert_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                txLog.AppendText(Environment.NewLine);
                txLog.AppendText(txInsert.Text);
                txLog.AppendText(Environment.NewLine);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e) {

            txLog.AppendText(Environment.NewLine);
            txLog.AppendText(txInsert.Text);
            txLog.AppendText(Environment.NewLine);
        }


    }


    public partial class C_MsgPart {
        public char ch; // delimiter
        public int iO; // index of delimiter in odomsg
        public string str; // cutted part of string
        public string lastValid; // last valid cutted part of string
        //public double value; // double value after conversion

        public C_MsgPart(char a_ch) {
            str = lastValid = "?";
            ch = a_ch;
            iO = 0;
        }
        public void CUT(string msg, int i1, int i2) {
            i2 = i2 - i1 + 1;
            if (i2 > 0) {
                str = msg.Substring(i1, i2);
                lastValid = str;
            }
            else
                str = "<";
        }

        /*
        public void OnlyNumbers() {
            //but what about the decimal point :D
            current = new string(lastValid.TakeWhile(c => Char.IsDigit(c)).ToArray());
            lastValid = current;
        }*/
        /*
        public virtual int PartSubstr(string msg, int iEND) {
            iPART = msg.IndexOf(delimiter);
            if (iPART != msg.LastIndexOf(delimiter))
                // if there are more delimODO -> bad
                current = "!";

            else {
                if (iPART >= 0) {
                    iEND -= (iPART + 1);
                    if (iEND <= 0) // to 
                        current = "<"; // later this will be catched and "error" written elsewhere
                    else {
                        current = msg.Substring(iPART + 1, iEND);
                        lastValid = current;
                    }
                    iEND = iPART;
                }
                else {
                    current = "?";
                }
            }
            return iEND;
        }
        */
    }

    public partial class C_log {
        public char lastReceivedChar { get; set; }
        public bool notProcessed { get; set; }
        public string lastMsg { get; set; }


        //tydle tri budou getem dolovat z fronty uložených logů
        public double th { get; set; }
        public double posAx { get; set; } // absolute
        public double posAy { get; set; }
        public double posRx { get; set; } // relative
        public double posRy { get; set; }

        private int i;
        private int j;

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        // ODOMSG

        // ^SI%LRXYAP:;<=>$ all
        // ******XYAP:;<=>* doubles
        // *********P:;<=>* prob
        // *SI*LR********** ints

        private const int ODOsum_parts = 16;       // ^SI%LRXYAP:;<=>$ all
        private const int ODOsum_doubles = 9;      // ******XYAP:;<=>* doubles
        private const int ODOsum_prob = 6;         // *********P:;<=>* prob
        private const int ODOsum_ints = 4;         // *SI*LR********** ints

        public C_MsgPart[] odo; // parts

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        // ACTUALMSG

        //ATT,START_x,START_y,START_th,Q11,Q22,Q33,rL,b,rR,TL,TR,EL,ER,iter_type,iter_trig.sum_treshold

        // _XYAP:;<=>MNEFIT$ all
        // *XYAP:;<=>MNEF*** doubles
        // **************IT* ints

        private const int ACTsum_parts = 17;       // _XYAP:;<=>MNEFIT$ all
        private const int ACTsum_doubles = 13;      // *XYAP:;<=>MNEF*** doubles
        private const int ACTsum_ints = 2;         // **************IT* ints

        public C_MsgPart[] act; // parts

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        public double[] d; // double values after conversion
        public int[] ints; // int values after conversion
        public bool parseComplete;

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #region events
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        public event EventHandler<ODOParseCompleteEventArgs> ODOParseComplete;

        public class ODOParseCompleteEventArgs : EventArgs {
            public bool isRelative;
            public double x;
            public double y;
            public double th;
            public double[] P;
            public int steps;
            public int iters;
            public int tL;
            public int tR;
            public char unit;

            public ODOParseCompleteEventArgs(double[] a_d, int[] a_ints, char a_unit, bool a_isRelative) {
                isRelative = a_isRelative;
                unit = a_unit;

                x = a_d[0];
                y = -a_d[1];
                th = -a_d[2];
                P = new double[ODOsum_prob];
                int i = 3;
                for (; i < ODOsum_doubles; i++)
                    P[i - 3] = a_d[i];

                steps = a_ints[0];
                iters = a_ints[1];

                tL = a_ints[2];
                tR = a_ints[3];

                /*
                string format_xy = "0.0000";
                string format_th = "0.0000";
                string format_P = "0.00";
                string str;

                str = a_d[0].ToString(format_xy) + "\r\n";
                str = str + a_d[1].ToString(format_xy) + "\r\n";
                str = str + (a_d[2] * 180 / 2 / Math.PI).ToString(format_th) + "°" + "\r\n";
                str = str + 
                   a_d[3].ToString(format_P) + "|" + a_d[4].ToString(format_P) + "|" + a_d[5].ToString(format_P)
                   + "\r\n" +
                   a_d[4].ToString(format_P) + "|" + a_d[6].ToString(format_P) + "|" + a_d[7].ToString(format_P)
                   + "\r\n" +
                   a_d[5].ToString(format_P) + "|" + a_d[7].ToString(format_P) + "|" + a_d[8].ToString(format_P)
                   ;
                MessageBox.Show(str);
                 */
            }
        }

        protected virtual void OnODOParseComplete(ODOParseCompleteEventArgs e) {
            if (ODOParseComplete != null) ODOParseComplete(this, e);
        }

        //ACT
        public event EventHandler<ACTParseCompleteEventArgs> ACTParseComplete;

        public class ACTParseCompleteEventArgs : EventArgs {
            public double START_x;
            public double START_y;
            public double START_th;
            public double Q11;
            public double Q22;
            public double Q33;
            public double rL;
            public double b;
            public double rR;
            public double TL;
            public double TR;
            public double eL;
            public double eR;

            public int iter_type;
            public int iter_trigger;

            public ACTParseCompleteEventArgs(double[] a_d, int[] a_ints) {
                START_x = a_d[0];
                START_y = a_d[1];
                START_th = a_d[2];
                Q11 = a_d[3];
                Q22 = a_d[4];
                Q33 = a_d[5];
                rL = a_d[6];
                b = a_d[7];
                rR = a_d[8];
                TL = a_d[9];
                TR = a_d[10];
                eL = a_d[11];
                eR = a_d[12];

                iter_type = a_ints[0];
                iter_trigger = a_ints[1];
            }
        }

        protected virtual void OnACTParseComplete(ACTParseCompleteEventArgs e) {
            if (ACTParseComplete != null) ACTParseComplete(this, e);
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        #endregion events
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        public void Parse(string stmmsg) {
            //int i;
            //int j = 0;
            parseComplete = false;

            PARSE(stmmsg);

            parseComplete = true;
        }
        
        public void PARSE(string stmmsg) {

            int a = stmmsg.IndexOf('_');
            if (a >= 0) {
                PARSE_actualmsg(stmmsg.Substring(a));
                //PARSE_odomsg(stmmsg.Substring(0, stmmsg.Length - a + 1));               
            }
            else {
                PARSE_odomsg(stmmsg);           
            }

        }

        public void PARSE_actualmsg(string actualmsg) {
            /* FORMAT
             * 		printf("%c%.*s%c%.*e%c%.*e%c%.*g%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%i%c%i%c\r\n",
						'_', 									// %c
						ATT_LEN, msg->ATT, 						// %.*s
						'X', 									// %c
						DBL_DIG, rob->START_x, 					// %.*e
						'Y', 									// %c
						DBL_DIG, rob->START_y,					// %.*e
						'A', 									// %c
						DBL_DIG, rob->START_th,					// %.*g
						'P', 									// %c
						DBL_DIG, rob->Q11, 						// %.*e
						':', 									// %c
						DBL_DIG, rob->Q22, 						// %.*e
						';', 									// %c
						DBL_DIG, rob->Q33, 						// %.*e
						'<', 									// %c
						DBL_DIG, rob->rL, 						// %.*e
						'=', 									// %c
						DBL_DIG, rob->b, 						// %.*e
						'>', 									// %c
						DBL_DIG, rob->rR, 						// %.*e
						'M', 									// %c
						DBL_DIG, rob->TL, 						// %.*e
						'N', 									// %c
						DBL_DIG, rob->TR, 						// %.*e
						'E', 									// %c
						DBL_DIG, rob->eL, 						// %.*e
						'F', 									// %c
						DBL_DIG, rob->eR, 						// %.*e
						'I', 									// %c
						rob->iter_type, 						// %i
						'T', 									// %c
						rob->iter_trig.sum_treshold,			// %i
						'$' 									// %c
						);
             */
            d = new double[ACTsum_doubles];
            ints = new int[ACTsum_ints];
            // find delimiter indexes in odomsg
            //string str = "";
            for (i = 0; i < ACTsum_parts - 1; i++) {
                act[i].iO = actualmsg.LastIndexOf(act[i].ch);
                //str = str + odo[i].iO.ToString() + " | ";
            }
            //MessageBox.Show(str);
            // cut individual msg parts (not the last)
            for (i = 0; i < ACTsum_parts - 2; i++) {
                if (act[i].iO < 0) //not present
                    continue;
                else {
                    j = i + 1;
                    while (j < ACTsum_parts - 1) {
                        if (act[j].iO < 0)
                            j = j + 1;
                        else
                            break;
                    }
                    act[i].CUT(actualmsg, (act[i].iO + 1), (act[j].iO - 1));
                }
            }

            // _XYAP:;<=>MNEFIT$ all
            // *XYAP:;<=>MNEF*** doubles
            // **************IT* ints

            // convert strings to doubles 
            double resD = 0;
            // from [1], and (not the last)
            for (i = 1; i < 1 + ACTsum_doubles; i++) {
                if (double.TryParse(
                    act[i].lastValid, System.Globalization.NumberStyles.Any,
                    CultureInfo.InvariantCulture, out resD)
                )
                    d[i - 1] = resD;
            }

            // **************IT* ints
            int resI = 0;
            for (i = 14; i < 14 + ACTsum_ints; i++) {
                if (int.TryParse(act[i].lastValid, out resI))
                    ints[i - 14] = resI;
            }


            //OnODOParseComplete(new ODOParseCompleteEventArgs(odo.pos, odo.ang, conf.isRelative, prob.P));
            OnACTParseComplete(new ACTParseCompleteEventArgs(d, ints));
        }

        public void PARSE_odomsg(string odomsg) {
            d = new double[ODOsum_doubles];
            ints = new int[ODOsum_ints];
            // find delimiter indexes in odomsg
            //string str = "";
            for (i = 0; i < ODOsum_parts; i++) {
                odo[i].iO = odomsg.LastIndexOf(odo[i].ch);
                //str = str + odo[i].iO.ToString() + " | ";
            }
            //MessageBox.Show(str);
            // cut individual msg parts (not the last)
            for (i = 0; i < ODOsum_parts - 1; i++) {
                if (odo[i].iO < 0) //not present
                    continue;
                else {
                    j = i + 1;
                    while (j<ODOsum_parts-1) {
                        if (odo[j].iO < 0)
                            j = j + 1;
                        else
                            break;
                    }
                    odo[i].CUT(odomsg, (odo[i].iO + 1), (odo[j].iO - 1));
                }
            }

            // ^SI%LRXYAP:;<=>$ all
            // ******XYAP:;<=>* doubles
            // *********P:;<=>* prob

            // convert strings to doubles 
            double resD = 0;
            // from [6], and (not the last)
            for (i = 6; i < ODOsum_parts - 1; i++) {
                if (double.TryParse(
                    odo[i].lastValid, System.Globalization.NumberStyles.Any,
                    CultureInfo.InvariantCulture, out resD)
                )
                    d[i - 6] = resD;
            }

            // *SI*LR********** ints
            int resI = 0;
            for (i = 1; i < 3; i++) {
                if ( int.TryParse( odo[i].lastValid, out resI) )
                    ints[i - 1] = resI;
            }
            for (i = 4; i < 6; i++) {
                if (int.TryParse(odo[i].lastValid, out resI))
                    ints[i - 2] = resI;
            }

            //bool isRelative = false;
            bool isRelative = true;
            if(odo[3].lastValid[1] == 'a')
                isRelative = false;
            char unit = odo[3].lastValid[0];

            //OnODOParseComplete(new ODOParseCompleteEventArgs(odo.pos, odo.ang, conf.isRelative, prob.P));
            OnODOParseComplete(new ODOParseCompleteEventArgs(d, ints, unit, isRelative));
        }

        public C_log() {

            parseComplete = true;
            i = j = 0;
            odo = new C_MsgPart[ODOsum_parts];
            //string delimODO = "^%XYAPQRSTU$";
            string delimODO = "^SI%LRXYAP:;<=>$";
            for (i = 0; i < ODOsum_parts; i++) {
                odo[i] = new C_MsgPart(delimODO[i]);
            }


            act = new C_MsgPart[ACTsum_parts];
            string delimACT = "_XYAP:;<=>MNEFIT$";
            for (i = 0; i < ODOsum_parts; i++) {
                act[i] = new C_MsgPart(delimACT[i]);
            }

            d = new double[ODOsum_doubles];
            ints = new int[ODOsum_ints];
            lastReceivedChar = '\0';
            notProcessed = false;
            lastMsg = "";
            //th = 120;
            //posA = new PointF();
            //posR = new PointF();
            //posR = new PointF(2, 2);
        }
    }
}
