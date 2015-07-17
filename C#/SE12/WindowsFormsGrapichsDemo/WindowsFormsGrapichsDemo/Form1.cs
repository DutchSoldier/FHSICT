using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsGrapichsDemo
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics graphics = e.Graphics;

            int breedte = ClientRectangle.Width;
            int hoogte = ClientRectangle.Height;
            
            graphics.DrawEllipse(Pens.Black, breedte/2-75/2, hoogte/2-75/2, 75, 75);
            graphics.DrawEllipse(Pens.Blue , 0, 0, 75, 75);
            graphics.DrawEllipse(Pens.Purple, 0, hoogte-75, 75, 75);
            graphics.DrawEllipse(Pens.Green, breedte-75, hoogte-75, 75, 75);
            graphics.DrawEllipse(Pens.Red, breedte-75, 0, 75, 75);
            graphics.DrawLine(Pens.Black, 0, 0, breedte, hoogte);
            graphics.DrawLine(Pens.Black, 0, hoogte, breedte, 0);

            
        }

        

        public void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            label1.Text = "X: " + e.X + " Y: " + e.Y;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            

        } 
    }
}
