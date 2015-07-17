using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoOISWeek5_Deel2
{
    public partial class TellenForm : Form
    {
        public TellenForm()
        {
            InitializeComponent();
        }

        private void telButton_Click(object sender, EventArgs e)
        {
            tellenListBox.Items.Clear();

            int getal = Convert.ToInt32(getalNumericUpDown.Value);
            int teller = 0;


            while (teller < getal)
            {
                teller++;
                tellenListBox.Items.Add(teller.ToString());
            }
        }

    }
}
