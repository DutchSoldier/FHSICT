using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace WindowsFormsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                label1.Text = textBox1.Text + " " + textBox2.Text;
            }
            else
            {
                label1.Text = textBox2.Text + " " + textBox1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("sup");
        }
    }
}
