using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace InterfaceKit_full.SensorExamples
{
    public partial class Sensor1108 : UserControl
    {
        public int sensorValue;
        public Sensor1108()
        {
            InitializeComponent();
        }

        public void changeDisplay(int val)
        {
            double tmp = (500 - val);
            textBox1.Text = tmp.ToString() + "Φ";
        }

    }
}
