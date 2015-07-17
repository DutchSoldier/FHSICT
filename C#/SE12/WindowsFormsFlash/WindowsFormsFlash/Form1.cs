using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsFlash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (Visible)
            {
                for (int c = 0; c < 254; c++)
                {
                    this.BackColor = Color.FromArgb(c, 255 - c, c);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(3);
                }
                for (int d = 254; d >= 0; d--)
                {
                    this.BackColor = Color.FromArgb(d, 255 - d, d);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(3);
                }
            }
        }
    }
}
