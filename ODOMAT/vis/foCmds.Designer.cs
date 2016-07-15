namespace vis {
    partial class foCmds {
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
            this.lvCmds = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvCmds
            // 
            this.lvCmds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCmds.GridLines = true;
            this.lvCmds.Location = new System.Drawing.Point(0, 0);
            this.lvCmds.Name = "lvCmds";
            this.lvCmds.Size = new System.Drawing.Size(802, 402);
            this.lvCmds.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCmds.TabIndex = 0;
            this.lvCmds.UseCompatibleStateImageBehavior = false;
            this.lvCmds.View = System.Windows.Forms.View.Details;
            this.lvCmds.SelectedIndexChanged += new System.EventHandler(this.lvCmds_SelectedIndexChanged);
            // 
            // foCmds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 402);
            this.Controls.Add(this.lvCmds);
            this.Name = "foCmds";
            this.Text = "PCMSG Commands";
            this.Load += new System.EventHandler(this.foCmds_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvCmds;

    }
}