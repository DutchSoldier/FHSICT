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
            //todo
             this.Text = "DEMO, software made by the DEMO-MAKER"; //verwijderen; is voor genereren demo
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

         private void btCreeerBoekingskantoor_Click(object sender, EventArgs e)
        {
             //todo, opdracht 3b

         }
        
        private void btToonAlleSprekers_Click(object sender, EventArgs e)
        {
            //todo, opdracht 3c

        }
        
        private void btVoegSprekerToe_Click(object sender, EventArgs e)
        {
            //todo, opdracht 3d

        }

        private void btVoegTopicAanSprekerToe_Click(object sender, EventArgs e)
        {
            //todo, opdracht 3e

        }

        private void btToonAlleSprekersOver_Click(object sender, EventArgs e)
        {
            //todo, opdracht 3f

        }
    }
}
