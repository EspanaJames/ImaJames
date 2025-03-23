using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imajames
{
    public partial class IMAJAMES : Form
    {
        private Timer clock;
        public IMAJAMES()
        {
            InitializeComponent();
            BarLoad();
            
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool setProcessDPIAware();
        private void BarLoad()
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            clock = new Timer();
            clock.Interval = 150;
            clock.Tick += openLandingPage;
            clock.Start();
        }
        private void openLandingPage(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 5; 
            }
            else
            {
                clock.Stop();
                imageManipulator call = new imageManipulator();
                call.Show();
                this.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
