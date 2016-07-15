using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace vis {
    public partial class C_colors {
        public Color back;
        public C_colors() {
            back = Color.White;
        }
    }
    public partial class C_pens {
        public Pen robot;
        // trajectory
        public Pen line;
        // grid
        public Pen main_axes;
        public Pen main_grid;
        public Pen sub_grid;
        public C_pens() {
            robot = new Pen(Color.Green, 1);
            line = new Pen(Color.Red, 1);
            main_axes = new Pen(Color.Black, 1);
            main_grid = new Pen(Color.SlateBlue, 1);
            sub_grid = new Pen(Color.SkyBlue, 1);
        }
    }

    public partial class C_GUI_Mouse {
        // variables
        public bool lPressed { get; set; }
        public Point lastPos { get; set; }
        public Point clickAt { get; set; }

        public C_GUI_Mouse() {
            lPressed = false;
            lastPos = new Point(0, 0);
            clickAt = new Point(0, 0);
        }
    }
    public partial class C_robot {
        private double _x;
        private double _y;
        private double _th;

        public double x {
            get { return _x; }
            set { lastx = _x; _x = value; }
        }
        public double y {
            get { return _y; }
            set { lasty = _y; _y = value; }
        }

        public Int32 xI {
            get { return Convert.ToInt32(_x); }
            set { }
        }
        public Int32 yI {
            get { return Convert.ToInt32(_y); }
            set { }
        }

        public double th {
            get { return _th; }
            set {
                /*// correct _th e <0,2pi>
                if (value > 2 * Math.PI)
                    _th = value % (2*Math.PI);
                if (value < -2 * Math.PI)
                    _th = value % (2*Math.PI);
                if (_th < 0)
                    _th += 2 * Math.PI;
                 */
                //its corrected in the stm already
                _th = value;
            }
        }

        public double lastx; // the ones before actual odo,y
        public double lasty;


        public Int32 lastxI {
            get { return Convert.ToInt32(lastx); }
            set { }
        }
        public Int32 lastyI {
            get { return Convert.ToInt32(lasty); }
            set { }
        }

        public double b;
        public double rL;
        public double rR;
        public double phiL; // for drawing the robot rectangle
        public double phiR;
        public double scaleL;
        public double scaleR;

        public double axeA;
        public double axeB;
        public double axePsi;
        public string unit;


        public C_robot() {
            _x = _y = _th = 0;
            unit = "m";
            b = 0.675; rL = 0.1; rR = 0.1;
            axeA = axeB = axePsi = 0;
            phiL = Math.Atan2(b, 2 * rL); phiR = Math.Atan2(b, 2 * rR);
            scaleL = Math.Sqrt(b * b / 4 + rL * rL); scaleR = Math.Sqrt(b * b / 4 + rR * rR);
        }
        public C_robot(double a_b) {
            _x = _y = _th = 0;
            unit = "m";
            b = a_b; rL = 0.1; rR = 0.1;
            axeA = axeB = axePsi = 0;
            phiL = Math.Atan2(b, 2 * rL);
            phiR = Math.Atan2(b, 2 * rR);
        }

        public C_robot(double a_b, double a_rBoth) {
            _x = _y = _th = 0;
            unit = "m";
            b = a_b; rL = a_rBoth; rR = a_rBoth;
            axeA = axeB = axePsi = 0;
            phiL = Math.Atan2(b, 2 * rL); phiR = Math.Atan2(b, 2 * rR);
            scaleL = Math.Sqrt(b * b / 4 + rL * rL); scaleR = Math.Sqrt(b * b / 4 + rR * rR);
        }
        public C_robot(double a_b, double a_rL, double a_rR) {
            _x = _y = _th = 0;
            unit = "m";
            b = a_b; rL = a_rL; rR = a_rR;
            axeA = axeB = axePsi = 0;
            phiL = Math.Atan2(b, 2 * rL); phiR = Math.Atan2(b, 2 * rR);
            scaleL = Math.Sqrt(b * b / 4 + rL * rL); scaleR = Math.Sqrt(b * b / 4 + rR * rR);
        }

        public void UPDATE_abs(Point a_pos) {
            x = a_pos.X; y = a_pos.Y;
        }
        public void UPDATE_abs(PointF a_pos) {
            x = a_pos.X; y = a_pos.Y;
        }
        public void UPDATE_abs(double a_x, double a_y) {
            x = a_x; y = a_y;
        }
        public void UPDATE_rel(Point a_pos) {
            x = x + a_pos.X; y = y + a_pos.Y;
        }
        public void UPDATE_rel(PointF a_pos) {
            x = x + a_pos.X; y = y + a_pos.Y;
        }
        public void UPDATE_rel(double a_x, double a_y) {
            x = x + a_x; y = y +a_y;
        }
    }
    public partial class C_draw {
        // rendering config
        private bool _antialias;
        public bool renderRelative;

        // bitmaps
        public Bitmap creature;
        public Bitmap imaLines;
        public Bitmap imaAll;
        public Bitmap imaGrid;

        // graphics
        public Graphics graMap;
        public Graphics graLines;
        public Graphics graAll;
        public Graphics graGrid;

        // HUD
        /*
        private int _gridCell;
        public int gridCell {
            get {
                return _gridCell;
            }
            set {
                _gridCell = value;
                INIT_Grid();
            }
        }*/

        public double main_grid_step;
        public double sub_grid_step;

        // other
        public Rectangle area;
        public int w; // of imas
        public int h;
        //public Pen[] pens;
        C_pens pens;
        C_colors cols;

        public C_robot r;
        public Point origin;
        public bool first_income;

        private int robot_diam;


        // for drawing geometry
        public Point[] ABCD;

        public double zoom;

        public double ppu; //pixels per unit


        public C_draw(int a_w, int a_h) {
            //w & h should be of the screen ?? =no

            // other
            r = new C_robot(0.675, 0.1);

            ABCD = new Point[4];

            //pens = new Pen[3];
            pens = new C_pens();
            cols = new C_colors();

            // rendering
            _antialias = true;
            renderRelative = false;

            //bitmaps
            w = a_w;
            h = a_h;
            creature = new Bitmap(@"D:/VIEW/FLAT/PIC/ng_stuff/user_avatar/agnry_faic.gif");
            imaLines = new Bitmap(w, h);
            imaGrid = new Bitmap(w, h);
            imaAll = new Bitmap(w, h);

            //origin = new Point(w/2, h/2);
            origin = new Point(512, 384);
            origin = new Point(312, 284);

            // graphics
            graGrid = Graphics.FromImage(imaGrid);
            graLines = Graphics.FromImage(imaLines);
            graAll = Graphics.FromImage(imaAll);

            // HUD
            robot_diam = 42;
            first_income = true;
            //gridCell = 100;

            zoom = 1;
            ppu = 1500; //px/m
            ppu = 500;
            ppu = 300; 
            ppu = 20; // 1000px / 50m - dir in 
            ppu = 77; // 1000px / 15m
            ppu = 256;

            //grid
            main_grid_step = 1 * ppu;
            sub_grid_step = 0.1 * ppu;

            DRAW_Grid();
            //INIT_Grid();
            //UPDATE_antialias();
            //graMap.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        }



        public void DRAW_Grid() {
            int linesx, linesy;
            double offsetx, offsety;

            main_grid_step = 1 * ppu;
            sub_grid_step = 0.1 * ppu;

            //sub grid
            linesx = (int)(w / sub_grid_step) +1;
            linesy = (int)(h / sub_grid_step) +1;
            offsetx = (origin.X) - (int)(origin.X / sub_grid_step) * sub_grid_step;
            offsety = (origin.Y) - (int)(origin.Y / sub_grid_step) * sub_grid_step;

            for (int x = 0; x < linesx; x++) {
                graLines.DrawLine(pens.sub_grid,
                    (int)(offsetx + x * sub_grid_step), 0,
                    (int)(offsetx + x * sub_grid_step), h);
            }
            for (int y = 0; y < linesy; y++) {
                graLines.DrawLine(pens.sub_grid,
                    0, (int)(offsety + y * sub_grid_step),
                    w, (int)(offsety + y * sub_grid_step));
            }

            // main grid
            linesx = (int)(w / main_grid_step) + 1;
            linesy = (int)(h / main_grid_step) + 1;
            offsetx = (origin.X) - (int)(origin.X / main_grid_step) * main_grid_step;
            offsety = (origin.Y) - (int)(origin.Y / main_grid_step) * main_grid_step;

            for (int x = 0; x < linesx; x++) {
                graLines.DrawLine(pens.main_grid,
                    (int)(offsetx + x * main_grid_step), 0,
                    (int)(offsetx + x * main_grid_step), h);
            }
            for (int y = 0; y < linesy; y++) {
                graLines.DrawLine(pens.main_grid,
                    0, (int)(offsety + y * main_grid_step),
                    w, (int)(offsety + y * main_grid_step));
            }

            // main axes
            graLines.DrawLine(pens.main_axes, 0, origin.Y, w, origin.Y);
            graLines.DrawLine(pens.main_axes, origin.X, 0, origin.X, h);

        }




        public Bitmap DRAW_imaAll() {
            double Zx = (r.x) * ppu + origin.X;
            double Zy = (r.y) * ppu + origin.Y;

            // part of trajectory
            if (!first_income) {
                graLines.DrawLine(
                    pens.line,
                    (int)(Zx), (int)(Zy),
                    (int)((r.lastx) * ppu + origin.X),
                    (int)((r.lasty) * ppu + origin.Y)
                    );
            }
            else
                first_income = false;

            graAll.Clear(cols.back);

            //graLines.Clear(cols.back);

            // draw grid
            graAll.DrawImage(imaGrid, 0, 0);

            // draw trajectory into All
            graAll.DrawImage(imaLines, 0, 0);

            // draw robot on position
            DRAW_Robot(Zx, Zy);


            return imaAll;
        }
        //int transl = 0;
        public void DRAW_ErrorEllipse(float Zx, float Zy, float A, float B, float psi) {

            if (A != 0 && B != 0) {
                A = A * 10000;
                B = B * 10000;
                // Set world transform of graphics object to translate.
                //if (transl <= 0) {
                //    graAll.TranslateTransform(Zx, Zy);
                //    transl++;
                //}
                // Then to rotate, appending rotation matrix.
                graAll.RotateTransform(-psi, MatrixOrder.Prepend);
                // Draw translated, rotated ellipse to screen.

                graAll.DrawEllipse(new Pen(Color.Blue, 3), Zx -A / 2, Zy-B / 2, A, B);
                graAll.RotateTransform(psi, MatrixOrder.Prepend);
                //graAll.TranslateTransform(-Zx, -Zy); transl--;
            }
        }
        public void DRAW_Robot(double Zx, double Zy) {
            //%  2rL
            //% 3___2
            //% | S_|  b
            //% |___|
            //% 0   1
            //%  2rR

            //scale = sqrt(b*b + r*r);
            //phi = atn2(b/2, r)

            ABCD[0].X = Convert.ToInt32(Zx + (r.scaleL * Math.Sin(r.th - r.phiL + Math.PI)) * ppu);
            ABCD[0].Y = Convert.ToInt32(Zy - (r.scaleL * Math.Cos(r.th - r.phiL + Math.PI)) * ppu);
            ABCD[1].X = Convert.ToInt32(Zx + (r.scaleL * Math.Sin(r.th + r.phiL)) * ppu);
            ABCD[1].Y = Convert.ToInt32(Zy - (r.scaleL * Math.Cos(r.th + r.phiL)) * ppu);

            ABCD[2].X = Convert.ToInt32(Zx + (r.scaleR * Math.Sin(r.th - r.phiR)) * ppu);
            ABCD[2].Y = Convert.ToInt32(Zy - (r.scaleR * Math.Cos(r.th - r.phiR)) * ppu);
            ABCD[3].X = Convert.ToInt32(Zx + (r.scaleR * Math.Sin(r.th + r.phiR - Math.PI)) * ppu);
            ABCD[3].Y = Convert.ToInt32(Zy - (r.scaleR * Math.Cos(r.th + r.phiR - Math.PI)) * ppu);

            graAll.DrawPolygon(pens.robot, ABCD);


            //Bitmap imaRobot = new Bitmap(robot_diam, robot_diam);
            //robot circle
            Rectangle circ = new Rectangle(
                (int)(Zx) - robot_diam / 2,
                (int)(Zy) - robot_diam / 2,
                robot_diam,
                robot_diam);
            graAll.DrawEllipse(pens.robot, circ);

            // Error elipse
            //DRAW_ErrorEllipse((float)Zx, (float)Zy, (float)r.axeA, (float)r.axeB, (float)r.axePsi);


            // GraphicsObject.RenderingOrigin = new Point(100, 200);


            // front nose line

            graAll.DrawLine(pens.robot, (int)Zx, (int)Zy,
                    (int)(Zx + r.rR * ppu * Math.Sin(r.th)),
                    (int)(Zy - r.rR * ppu * Math.Cos(r.th))
                );


            // left diagonal radius
            graAll.DrawLine(pens.robot, (int)Zx, (int)Zy, ABCD[2].X, ABCD[2].Y);


            //graAll.DrawImage(creature, abs_pos);
        }

        public void REDRAW() {
            SET_antialias(_antialias);
            //DRAW_Grid();
            graMap.DrawImage(
                DRAW_imaAll(),
                new Point(0, 0)
                );
        }



        public void ERASE_trajectory() {
            //graLines.Clear(cols.back);
            //DRAW_Grid();
            graLines.Clear(cols.back);
            DRAW_Grid();
            //graAll.DrawImage(imaGrid, 0, 0);
            REDRAW();
            //graGrid.Clear(cols.back);
        }

        public void SET_antialias(bool a_antialias) {
            _antialias = a_antialias;
            UPDATE_antialias();
        }

        public void UPDATE_antialias() {
            switch (_antialias) {
                case (true):
                    graLines.SmoothingMode =
                        graAll.SmoothingMode =
                        graMap.SmoothingMode =
                        System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    break;
                case (false):
                    graLines.SmoothingMode =
                        graAll.SmoothingMode =
                        graMap.SmoothingMode =
                        System.Drawing.Drawing2D.SmoothingMode.None;
                    break;
            }
        }
    }

    public partial class C_GUI {
        public C_draw draw { get; set; }
        //public C_log com { get; set; }
        public C_GUI_Mouse mouse { get; set; }


        public C_GUI(int w, int h) {
            draw = new C_draw(w, h);
            mouse = new C_GUI_Mouse();
            //  com = new C_log();
        }
        /*
        public C_GUI() {
            //draw = new C_draw();
            mouse = new C_GUI_Mouse();
            //draw.UPDATE_FromConfig(this,e.antialias)
        }*/
    }
}
