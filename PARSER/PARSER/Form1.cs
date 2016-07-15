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

namespace parser {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }

        private void button1_Click(object sender, EventArgs e) {
            txLog.Text = "";
            tx2.Text = "";
            if (DialogResult.OK == ofd.ShowDialog()) {

                String line;
                try {
                    using (StreamReader sr = new StreamReader(ofd.FileName)) {
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


                TextReader reader = new System.IO.StringReader(txLog.Text);
                //int rows = read.;

                while ((line = reader.ReadLine()) != null) {
                    //line = reader.ReadLine();
                    if (line.Length > 0)
                        parser.odolog.PARSE(line.Remove(line.Length - 2));
                }

            }
        }

        private void button3_Click(object sender, EventArgs e) {
            txLog.Text = "";
            tx2.Text = "";
            if (DialogResult.OK == ofd.ShowDialog()) {

                String line;
                try {
                    using (StreamReader sr = new StreamReader(ofd.FileName)) {
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


                TextReader reader = new System.IO.StringReader(txLog.Text);
                //int rows = read.;

                while ((line = reader.ReadLine()) != null) {
                    //line = reader.ReadLine();
                    if (line.Length > 0)
                        parser.gpslog.PARSE(line);
                }

            }
        }


        private void Form1_Load(object sender, EventArgs e) {
            //log = new C_log();
            parser = new C_Parser();
            //C_log.ODOParseCompleteEventArgs += ODOParseComplete_EventHandler;
            parser.odolog.ODOParseComplete += ODOParseComplete_EventHandler;
            parser.gpslog.GPSParseComplete += GPSParseComplete_EventHandler;
            lastUTC = "";
        }
        double i = 0;
        public string lastUTC;
        private void ODOParseComplete_EventHandler(object sender, C_odolog.ODOParseCompleteEventArgs e) {
            
            e.UTC = e.UTC.Substring(1);

            // add decimal point with half of second
            int x = String.Compare(lastUTC, e.UTC, true);
            if ( x == 0)                i = 5;
            else                i = 0;

            string hhmmss =
                e.UTC[13].ToString() + e.UTC[14].ToString() +
                e.UTC[16].ToString() + e.UTC[17].ToString() +
                e.UTC[19].ToString() + e.UTC[20].ToString() + "." +
                i.ToString() + "0"
                ;
            lastUTC = e.UTC;

            tx2.AppendText(
                e.steps + " " +
                hhmmss + " " +
                e.iters.ToString() + " " +
            e.tL.ToString() + " " +
            e.tR.ToString() + "\r\n");

        }
        double AVR_tim = 0;
        double VGK_tim = 0;
        double last_UP;
        double last_N;
        double last_E;
        double last_Y;
        double last_T;
        private void GPSParseComplete_EventHandler(object sender, C_gpslog.GPSParseCompleteEventArgs e) {
            
            if (e.isVGK){
                VGK_tim = e.UTCtim;
                last_E = e.east;
                last_N = e.north;
                last_UP = e.up;
            }
            else{
                AVR_tim = e.UTCtim;
                last_Y = e.yaw;
                last_T = e.tilt;
            }
            /*
            txUTC.AppendText(
                e.isVGK.ToString() + " " +
                e.UTCtim.ToString() + "\r\n"
                );*/
            if (VGK_tim == AVR_tim) {
                //string hhmmss = e.UTCtim;


                string format1 = "0.0000";
                tx2.AppendText(
                    VGK_tim.ToString(format1) + " " +
                    last_E.ToString(format1) + " " +
                    last_N.ToString(format1) + " " +
                    last_UP.ToString(format1) + " " +
                    last_Y.ToString(format1) + " " +
                    last_T.ToString(format1) + "\r\n");
                    

             
            }
        }



        //C_log log;   
        C_Parser parser;

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
        }

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        public partial class C_odolog {
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
                public string UTC;

                public ODOParseCompleteEventArgs(double[] a_d, int[] a_ints, char a_unit, bool a_isRelative, string a_UTC) {
                    isRelative = a_isRelative;
                    unit = a_unit;
                    UTC = a_UTC;

                    x = a_d[0];
                    y = a_d[1];
                    th = a_d[2];
                    P = new double[ODOsum_prob];
                    int i = 3;
                    for (; i < ODOsum_doubles; i++)
                        P[i - 3] = a_d[i];

                    steps = a_ints[0];
                    iters = a_ints[1];

                    tL = a_ints[2];
                    tR = a_ints[3];

                }
            }

            protected virtual void OnODOParseComplete(ODOParseCompleteEventArgs e) {
                if (ODOParseComplete != null) ODOParseComplete(this, e);
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

                PARSE_odomsg(stmmsg);

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
                        while (j < ODOsum_parts - 1) {
                            if (odo[j].iO < 0)
                                j = j + 1;
                            else break;
                        }
                        odo[i].CUT(odomsg, (odo[i].iO + 1), (odo[j].iO - 1));
                    }
                }

                /*
                 * 
                 */
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
                    if (int.TryParse(odo[i].lastValid, out resI))
                        ints[i - 1] = resI;
                }
                for (i = 4; i < 6; i++) {
                    if (int.TryParse(odo[i].lastValid, out resI))
                        ints[i - 2] = resI;
                }

                //bool isRelative = false;
                bool isRelative = true;
                if (odo[3].lastValid[1] == 'a')
                    isRelative = false;
                char unit = odo[3].lastValid[0];

                //OnODOParseComplete(new ODOParseCompleteEventArgs(odo.pos, odo.ang, conf.isRelative, prob.P));
                OnODOParseComplete(new ODOParseCompleteEventArgs(d, ints, unit, isRelative, odo[0].lastValid));
            }

            public C_odolog() {

                parseComplete = true;
                i = j = 0;
                odo = new C_MsgPart[ODOsum_parts];
                //string delimODO = "^%XYAPQRSTU$";
                string delimODO = "^SI%LRXYAP:;<=>$";
                for (i = 0; i < ODOsum_parts; i++) {
                    odo[i] = new C_MsgPart(delimODO[i]);
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






        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        public partial class C_gpslog {
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

            private const int ODOsum_parts = 10;       // ^SI%LRXYAP:;<=>$ all
            private const int ODOsum_doubles = 3;      // ******XYAP:;<=>* doubles

            public C_MsgPart[] odo; // parts

            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            public double[] d; // double values after conversion
            public int[] ints; // int values after conversion
            public bool parseComplete;

            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            #region events
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            public event EventHandler<GPSParseCompleteEventArgs> GPSParseComplete;

            public class GPSParseCompleteEventArgs : EventArgs {
                public bool isVGK; //else AVR
                public double UTCtim;
                public double east;
                public double north;
                public double up;
                public double yaw;
                public double tilt;

                public GPSParseCompleteEventArgs(double[] a_d, bool a_isVGK, double a_UTC) {
                    UTCtim = a_UTC;
                    east = a_d[0];
                    north = a_d[1];
                    up = a_d[2];
                    yaw = a_d[0];
                    tilt = a_d[1];
                    isVGK = a_isVGK;
                }
            }

            protected virtual void OnGPSParseComplete(GPSParseCompleteEventArgs e) {
                if (GPSParseComplete != null) GPSParseComplete(this, e);
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

            public void PARSE(string gpsmsg) {

                bool isVGK = false;

                d = new double[ODOsum_doubles];

                int len = gpsmsg.Length;
                //if (len != 70 && len != 64)
                if (len < 64 || len > 72)
                    return;

                // find delimiter indexes in odomsg
                //string str = "";
                i = gpsmsg.IndexOf(",,,");

                if (i != -1) {
                    char[] array = gpsmsg.ToCharArray();
                    array[i + 1] = '0';
                    array[i + 2] = '0';
                    gpsmsg = new string (array);
                }

                string[] strs = gpsmsg.Split(',');


                int lenS = strs.Length;
                if (lenS != 11)
                    return;

                if (strs[1].Equals("VGK"))
                    isVGK = true;
                
                if (strs[1].Equals("AVR"))
                    isVGK = false;

                // convert strings to doubles 
                double resD = 0;
                double UTCtim = 0;

                if (double.TryParse(
                        strs[2], System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture, out resD)
                    )
                    UTCtim = resD;

                if (isVGK) {

                    if (double.TryParse(
                        strs[4], System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture, out resD)
                    )
                        d[0] = resD;
                    if (double.TryParse(
                        strs[5], System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture, out resD)
                    )
                        d[1] = resD;
                    if (double.TryParse(
                        strs[6], System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture, out resD)
                    )
                        d[2] = resD;
                }
                else {
                    if (double.TryParse(
                        strs[3], System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture, out resD)
                    )
                        d[0] = resD;
                    if (double.TryParse(
                        strs[5], System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture, out resD)
                    )
                        d[1] = resD;
                }


                //OnODOParseComplete(new ODOParseCompleteEventArgs(odo.pos, odo.ang, conf.isRelative, prob.P));
                OnGPSParseComplete(new GPSParseCompleteEventArgs(d, isVGK, UTCtim));
            }

            public C_gpslog() {

                parseComplete = true;
                i = j = 0;
                d = new double[ODOsum_doubles];
                lastReceivedChar = '\0';
                notProcessed = false;
                lastMsg = "";
                //th = 120;
                //posA = new PointF();
                //posR = new PointF();
                //posR = new PointF(2, 2);
            }
        }

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        public partial class C_Parser {
            public C_odolog odolog;
            public C_gpslog gpslog;

            public C_Parser() {
                odolog = new C_odolog();
                gpslog = new C_gpslog();
            }
        }

        private void txLog_TextChanged(object sender, EventArgs e) {

        }

        private void tx2_TextChanged(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            sfd.FileName = "odolog_parsed.txt";
            if (DialogResult.OK == sfd.ShowDialog()) {

                using (StreamWriter outfile = new StreamWriter(sfd.FileName)) {
                    outfile.Write(tx2.Text);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            sfd.FileName = "gpslog_parsed.txt";
            if (DialogResult.OK == sfd.ShowDialog()) {

                using (StreamWriter outfile = new StreamWriter(sfd.FileName)) {
                    outfile.Write(tx2.Text);
                }
            }
        }

    }

}
