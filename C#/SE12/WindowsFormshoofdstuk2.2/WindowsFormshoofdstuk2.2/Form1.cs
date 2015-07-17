using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormshoofdstuk2._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this is a comment
        string name = "Quentin";
        int x = 3;
        x = x * 17;
        double d = Math.PI / 2;
        MessageBox.Show("name is " + name + "\nx is " + x + "\nd is " + d);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Messagebox.Text) == 24)
            {
            MessageBox.Show("The value was 24.");
            }
            if (Convert.ToInt32(Messagebox.Text) == 24)
            {
            // You can have as many statements
            // as you want inside the brackets
            MessageBox.Show("The value was 24.");
            }
            else 
            {
            MessageBox.Show("The value wasn’t 24.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
