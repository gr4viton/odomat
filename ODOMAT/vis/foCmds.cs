using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vis {
    public partial class foCmds : Form {
        public foCmds() {
            InitializeComponent();
        }

        private void foCmds_Load(object sender, EventArgs e) {
            lvCmds.Columns.Add("CMD", 100, HorizontalAlignment.Center);
            lvCmds.Columns.Add("Description", 500, HorizontalAlignment.Left);
            lvCmds.Columns.Add("Example", 503, HorizontalAlignment.Left);

            var it = new ListViewItem(new[] { "GC", "Get config" });
            lvCmds.Items.Add(it);

            it = new ListViewItem(new[] { "SB", "Set base and wheel radiuses, 3 doubles", "^SB_b_rL_rR$" });
            lvCmds.Items.Add(it);
            it = new ListViewItem(new[] { "SX", "Set x,y,th, 3 doubles", "^SX_x_y_th$" });
            lvCmds.Items.Add(it);
            it = new ListViewItem(new[] { "SS", "Set START_x,y,th, 3 doubles", "^SS_x_y_th$" });
            lvCmds.Items.Add(it);

            it = new ListViewItem(new[] { "SQ", "Set Q11 Q22 Q33, 3 doubles", "^SS_Q11_Q22_Q33$" });
            lvCmds.Items.Add(it);

            it = new ListViewItem(new[] { "ST", "Set TL, TR, 2 doubles", "^SX_TL_TR$" });
            lvCmds.Items.Add(it);

            it = new ListViewItem(new[] { "SE", "Set eL, eR, 2 doubles", "^SX_eL_eR$" });
            lvCmds.Items.Add(it);

            it = new ListViewItem(new[] { "WS", "Simulate PPS in SIM_Loop", "" });
            lvCmds.Items.Add(it);
            it = new ListViewItem(new[] { "HS", "Do not Simulate PPS in SIM_Loop", "" });
            lvCmds.Items.Add(it);
            it = new ListViewItem(new[] { "WE", "Simulate ENC in SIM_Loop", "" });
            lvCmds.Items.Add(it);
            it = new ListViewItem(new[] { "HE", "Do not Simulate ENC in SIM_Loop", "" });
            lvCmds.Items.Add(it);

            it = new ListViewItem(new[] { "DS", "Set Debug SSimulate PPS delay, positive int XX", "^SS_XX_$" });
            lvCmds.Items.Add(it);
            //it = new ListViewItem(new[] { "SA", "Set relative", "^SB_b_rL_rR$" });
            //lvCmds.Items.Add(it);
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void lvCmds_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
