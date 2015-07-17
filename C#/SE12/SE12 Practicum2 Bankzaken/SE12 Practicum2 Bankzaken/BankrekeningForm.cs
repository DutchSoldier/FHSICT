using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE12_Practicum2_Bankzaken
{
    public partial class BankrekeningForm : Form
    {
        //datavelden 
        private Bankrekening bankrekeningLinks;
        private Bankrekening bankrekeningRechts;

        public BankrekeningForm()
        {
            InitializeComponent();
            bankrekeningLinks = new Bankrekening("Duck, Dagobert");
            bankrekeningRechts = new Bankrekening("Gans, Gijs");
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            lRekeningNummer1.Text = bankrekeningLinks.Rekeningnummer.ToString();
            lNaam1.Text = bankrekeningLinks.Naam;
            decimal linksSaldo = Convert.ToDecimal(bankrekeningLinks.Saldo);
            lSaldo1.Text = "€" + (linksSaldo / 100).ToString();

            lRekeningNummer2.Text = bankrekeningRechts.Rekeningnummer.ToString();
            lNaam2.Text = bankrekeningRechts.Naam;
            decimal rechtsSaldo = Convert.ToDecimal(bankrekeningRechts.Saldo);
            lSaldo2.Text = "€" + (rechtsSaldo / 100).ToString();
        }

        private void bOpnemen1_Click(object sender, EventArgs e)
        {
            bankrekeningLinks.NeemOp((Convert.ToInt32(tbMoney1.Text) * 100) + Convert.ToInt32(tbCents1.Text));
            UpdateLabels();
        }

        private void bStorten1_Click(object sender, EventArgs e)
        {
            bankrekeningLinks.Stort((Convert.ToInt32(tbMoney1.Text) * 100) + Convert.ToInt32(tbCents1.Text));
            UpdateLabels();
        }

        private void bOpnemen2_Click(object sender, EventArgs e)
        {
            bankrekeningRechts.NeemOp((Convert.ToInt32(tbMoney2.Text) * 100) + Convert.ToInt32(tbCents2.Text));
            UpdateLabels();
        }

        private void bStorten2_Click(object sender, EventArgs e)
        {
            bankrekeningRechts.Stort((Convert.ToInt32(tbMoney2.Text) * 100) + Convert.ToInt32(tbCents2.Text));
            UpdateLabels();
        }

        private void bOverboeking1Naar2_Click(object sender, EventArgs e)
        {
            bankrekeningLinks.MaakOverNaar(bankrekeningRechts, ((Convert.ToInt32(tbMoney1.Text) * 100) + Convert.ToInt32(tbCents1.Text)));
            UpdateLabels();
        }

        private void bOverboeken2Naar1_Click(object sender, EventArgs e)
        {
            bankrekeningRechts.MaakOverNaar(bankrekeningLinks, ((Convert.ToInt32(tbMoney2.Text) * 100) + Convert.ToInt32(tbCents2.Text)));
            UpdateLabels();
        }


        //Add to the textbox's KeyPress event
        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
        }
    }
}
