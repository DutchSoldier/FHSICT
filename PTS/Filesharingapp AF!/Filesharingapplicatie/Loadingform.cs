using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Filesharingapplicatie
{
    public partial class Loadingform : Form
    {
        Thread processThread;
        public Loadingform(Thread processThread)
        {
            InitializeComponent();
            lbl_text.Text = "Verwerken...";
            this.processThread = processThread;
        }   // Constructor

        private void Loadingform_Shown(object sender, EventArgs e)
        {
            while (processThread.ThreadState == ThreadState.Running)
            {
                Application.DoEvents();
            }
            Thread.Sleep(1000);
            this.Close();
        }   // zolang de thread bezig is moet deze form blijven bestaan
    }
}
