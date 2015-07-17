using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsMilageCalculator
{
    public partial class Form1 : Form
    {
        int startingMileage;
        int endingMileage;
        double milesTraveled;
        double reimburseRate = 0.39;
        double amountOwed;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int startingMileage = Convert.ToInt32(numericUpDown1.Value);
            int endingMileage = Convert.ToInt32(numericUpDown2.Value);

            if (startingMileage >= endingMileage)
            {
                label4.Text = "The starting mileage must be less than the ending mileage";
            }
            else 
            {
            milesTraveled = endingMileage - startingMileage;
            amountOwed = milesTraveled * reimburseRate;
            label4.Text = "$" + amountOwed;
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int startingMileage = Convert.ToInt32(numericUpDown1.Value);
            int endingMileage = Convert.ToInt32(numericUpDown2.Value);
            milesTraveled = endingMileage - startingMileage;
            amountOwed = milesTraveled * reimburseRate;
            MessageBox.Show(milesTraveled + "Miles");  
        }
    }
}
