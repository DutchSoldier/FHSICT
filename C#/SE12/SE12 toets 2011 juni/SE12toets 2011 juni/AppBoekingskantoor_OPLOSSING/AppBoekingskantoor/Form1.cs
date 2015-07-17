using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppBoekingskantoor
{
    public partial class Form1 : Form
    {
        private Boekingskantoor bk;

        public Form1()
        {
            InitializeComponent();
             this.Text = "DEMO, software made by the DEMO-MAKER"; 
        }

        public void vulBoekingskantoorMetWatSprekers()
        {
            bk.voegSprekerToe("Jenson Button", "jensi@f1.com", 800);
            bk.voegTopicAanSprekerToe("Jenson Button", "rockmuziek");
            bk.voegTopicAanSprekerToe("Jenson Button", "formula 1");
            bk.voegTopicAanSprekerToe("Jenson Button", "rally");

            bk.voegSprekerToe("Herman Brood", "herman@brood.nl", 300);
            bk.voegTopicAanSprekerToe("Herman Brood", "rockmuziek");
            bk.voegTopicAanSprekerToe("Herman Brood", "drugs");

            bk.voegSprekerToe("Marcel wintels", "mwintels@fontys.nl", 200);
            bk.voegTopicAanSprekerToe("Marcel wintels", "hbo-onderwijs");
            bk.voegTopicAanSprekerToe("Marcel wintels", "tevredenheid");
            bk.voegTopicAanSprekerToe("Marcel wintels", "rally");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {   //code voor opdracht 3a; 
            Graphics gr = e.Graphics;
            int x = this.ClientSize.Width - 50;
            int y = 30;
            gr.FillEllipse(Brushes.IndianRed, x, y, 40, 40);
            Pen myPen = new Pen(Color.Blue, 3);
            gr.DrawLine(myPen, x, 20, x + 20, 15);
            gr.DrawLine(myPen, x + 20, 15, x + 40, 20);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {   //code voor opdracht 3a; 
            this.Refresh();
        }

         private void btCreeerBoekingskantoor_Click(object sender, EventArgs e)
        {
             //todo, opdracht 3b
            bk = new Boekingskantoor("de gedreven sprekers");
            this.vulBoekingskantoorMetWatSprekers();
        }
        
        private void btToonAlleSprekers_Click(object sender, EventArgs e)
        {
            //todo, opdracht 3c
            lbInfo.Items.Clear();
            foreach (Spreker sp in bk.getAlleSprekers())
            {
                lbInfo.Items.Add(sp.alsString());
            }
        }
        
        private void btVoegSprekerToe_Click(object sender, EventArgs e)
        {
            //todo, opdracht 3d
            if (bk.voegSprekerToe(tbNaam.Text, tbEmail.Text, Convert.ToInt32(tbTarief.Text)))
            {
                MessageBox.Show("sucesvol toegevoegd.");
            }
            else
            {
                MessageBox.Show("niet toegevoegd; naam komt al voor.");
            }
        }

        private void btVoegTopicAanSprekerToe_Click(object sender, EventArgs e)
        {
            //todo, opdracht 3e
            if (bk.voegTopicAanSprekerToe(tbNaam.Text,tbTopics.Text))
            {
                MessageBox.Show("sucesvol toegevoegd.");
            }
            else
            {
                MessageBox.Show("niet toegevoegd; deze spreker bestaat niet.");
            }
        }

        private void btToonAlleSprekersOver_Click(object sender, EventArgs e)
        {
            //todo, opdracht 3f
            lbInfo.Items.Clear();
            foreach (Spreker sp in bk.GetAlleSprekersOver(tbTopics.Text))
            {
                lbInfo.Items.Add(sp.alsString());
            }
        }
    }
}
