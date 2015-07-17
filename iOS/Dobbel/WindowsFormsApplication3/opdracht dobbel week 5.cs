using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bGooi_Click(object sender, EventArgs e)
        {
            worpenlistbox.Items.Clear();
            int aantalWorpen = Convert.ToInt32(numericUpDownWorpen.Value);

            Random random = new Random();
            for (int i = 1; i < aantalWorpen; i++)
            {
                int getal = random.Next(Convert.ToInt32(numericUpDownOgen.Value+1));
                worpenlistbox.Items.Add(getal.ToString());
            }
        }
    }
}
