using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Diertjes
{
    public partial class Form1 : Form
    {
        
        Diertje Dier;
        List<Diertje> diertjes = new List<Diertje>();
       

        public Form1()
        {
            InitializeComponent();
        }


        private void Lopen_Click(object sender, EventArgs e)
        {
            Dier.Lopen();
        }

        private void schijten_Click(object sender, EventArgs e)
        {
            Dier.Schijten();
        }

        private void schaften_Click(object sender, EventArgs e)
        {
            Dier.Schaften();
        }

        private void BtnVoegToe_Click(object sender, EventArgs e)
        {
            Dier = new Diertje(TbNaam.Text, Convert.ToInt32(Nleeftijd.Value), true);
            diertjes.Add(Dier);
        }

        private void BtnDierenZien_Click(object sender, EventArgs e)
        {
            LbDieren.Items.Clear();
            foreach (Diertje d in diertjes)
            {
                LbDieren.Items.Add(d.naam);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            foreach(string s in LbDieren.Items)
            {
                BestandStroom.SaveDierNamen(s);
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LbDieren.Items.Clear();
            foreach (string b in BestandStroom.GetDierNamen())
            {
                LbDieren.Items.Add(b);
            }
        } 
    }
}
