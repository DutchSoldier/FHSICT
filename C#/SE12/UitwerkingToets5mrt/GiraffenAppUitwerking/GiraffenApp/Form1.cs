using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiraffenApp
{
    public partial class Form1 : Form
    {
        private Stamboom stb;
        public Form1()
        {
            InitializeComponent();
            stb = new Stamboom("beestenboel van OKP");
            this.Text = stb.Naam + "made by okp";
            
 
        }

        private void btToonStamboom_Click(object sender, EventArgs e)
        {
            lbInfo.Items.Clear();
            lbInfo.Items.Add(stb.Naam);
            foreach (Giraffe g in stb.Giraffen)
            {
                lbInfo.Items.Add(g.AlsString()); 
            }

           

        }

        private void btZoekOpNaam_Click(object sender, EventArgs e)
        {
            lbInfo.Items.Clear();
            Giraffe g = stb.GetGiraffe(tbNaam.Text);
            if (g != null) lbInfo.Items.Add(g.AlsString());
            else lbInfo.Items.Add("niet gevonden");

        }

        private void btVoegToe_Click(object sender, EventArgs e)
        {
            bool gelukt = stb.AddGiraffe(tbNaam.Text, Convert.ToInt32(tbGeboortejaar.Text));
            if (gelukt) MessageBox.Show("gelukt");
            else MessageBox.Show("Niet gelukt");

        }

        private void btKenVaderToe_Click(object sender, EventArgs e)
        {
            Giraffe kind = stb.GetGiraffe(tbNaam.Text);
            Giraffe vader = stb.GetGiraffe(tbNaamVader.Text);
            if (kind != null && vader != null)
            {
                kind.NaamVader = vader.Naam;
            }
            else MessageBox.Show("Minstens een van de namen komt niet voor");
        }

        private void btToonMoederlijn_Click(object sender, EventArgs e)
        {
            Giraffe g = stb.GetGiraffe(tbNaam.Text);
            lbInfo.Items.Clear();

            while (g != null)
            {
                lbInfo.Items.Add(g.AlsString());
                String moeder = g.NaamMoeder;
                g = stb.GetGiraffe(moeder);
            }
        }

       private void btVulMetTestGegevens_Click(object sender, EventArgs e)
        {
            stb.VuMetTestGegevens();
        }
    }
}