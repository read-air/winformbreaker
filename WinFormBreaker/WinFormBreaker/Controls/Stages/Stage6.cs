using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormBreaker.Controls.Stages {
    public partial class Stage6 : GamePanel {
        public Stage6() {
            InitializeComponent();
            
        }

        private void progressBarBlock1_ProgressChanged(object sender, EventArgs e) {
            if (!this.lblPercentage.IsDisposed) {
                this.lblPercentage.Text = $"{this.progressBarBlock1.Value * 5}%";
            }
        }

        private void progressBarBlock1_Broken(object sender, EventArgs e) {
            if (!this.lblPercentage.IsDisposed) {
                this.lblPercentage.Text = "100%";
            }
        }
    }
}
