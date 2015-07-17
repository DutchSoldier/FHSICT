using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notepad_Light
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KnopClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void KnopPaste_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void KnopCopy_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void KnopAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright (C) By Tom Broumels");
        }

        private void KnopSave_Click(object sender, EventArgs e)
        {
            if (OpslaanScherm.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(OpslaanScherm.FileName, textBox1.Text);
            }
        }

        private void KnopLoad_Click(object sender, EventArgs e)
        {
            if (openenScherm.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = System.IO.File.ReadAllText(openenScherm.FileName);
            }
        }
    }
}
