using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SE21_toets_april
{
    public partial class Form1 : Form
    {
        private Training tra;
        private List<ZwemTraining> zwemtraining;
        private List<HardloopTraining> hardlooptraining;
        Schoen schoen = new Schoen();
        Blessure blessure = new Blessure();
        Atleet atleet1 = new Atleet();
        public List<int> Gettrainingen = new List<int>();

        public Form1()
        {
            InitializeComponent();
            tra = null;
            zwemtraining = new List<ZwemTraining>();
            hardlooptraining = new List<HardloopTraining>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(schoen.ToString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(blessure.ToString);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int i = Gettrainingen.Count();
                

                object[] obj = new object[i];
                

                i = obj.Length;
                

                FileDialog oDialog = new SaveFileDialog();

                oDialog.DefaultExt = "log";

                oDialog.FileName = "Lijst met trainingen";

                if (oDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@oDialog.FileName))
                    {
                        for (int w = 0; w < 1; w++)
                        {
                            file.WriteLine("");
                            foreach (string line in obj)
                            {
                                file.WriteLine(line);
                            } 
                        }
                    }
                }
            }

            catch (Exception exp)
            {
                Console.WriteLine("" + exp);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                tra = new ZwemTraining(textBox1.Text, checkBox1.Checked, Convert.ToInt32(textBox2.Text));
            }
            if (radioButton2.Checked)
            {
                tra = new HardloopTraining(textBox3.Text);
            }
        }
    }
}
