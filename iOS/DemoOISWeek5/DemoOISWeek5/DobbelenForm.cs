using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoOISWeek5
{
    public partial class DobbelenForm : Form
    {
        public DobbelenForm()
        {
            InitializeComponent();
        }

        private void btGooien_Click(object sender, EventArgs e)
        {
            worpenListBox.Items.Clear();
            int aantalWorpen = Convert.ToInt32(aantalNumericUpDown.Value);
            Random random = new Random();

            for (int i = 0; i < aantalWorpen; i++)
            {
                int getal = random.Next(1, 7);
                worpenListBox.Items.Add(getal.ToString());
            }
        }

       
    }
}
