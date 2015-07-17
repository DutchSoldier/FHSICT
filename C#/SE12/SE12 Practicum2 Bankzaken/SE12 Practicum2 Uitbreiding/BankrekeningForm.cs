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
            lSaldo1.Text = "€" + (bankrekeningLinks.Saldo).ToString();

            lRekeningNummer2.Text = bankrekeningRechts.Rekeningnummer.ToString();
            lNaam2.Text = bankrekeningRechts.Naam;
            lSaldo2.Text = "€" + (bankrekeningRechts.Saldo).ToString();
        }

        private void UpdateTransactie(Bankrekening rekening1, decimal bedrag, string type, Bankrekening rekening2)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add(DateTime.Now.ToString());
            lvi.SubItems.Add(rekening1.Rekeningnummer.ToString());
            lvi.SubItems.Add(bedrag.ToString());
            lvi.SubItems.Add(type);
            if (rekening2 != null)
            {
                lvi.SubItems.Add(rekening2.Rekeningnummer.ToString());
            }
            listView1.Items.Add(lvi);
        }

        private void bOpnemen1_Click(object sender, EventArgs e)
        {
            decimal euro = Convert.ToDecimal(numMoney1.Value);
            decimal cent = (Convert.ToDecimal(numCents1.Value) / 100) + 0.00M;
            decimal bedrag = euro + cent;
            decimal valuta = bedrag * Convert.ToDecimal(numValuta.Value);

            if ((bankrekeningLinks.Saldo - valuta) >= 0 && valuta != 0)
            {
                bankrekeningLinks.NeemOp(valuta);
                UpdateTransactie(bankrekeningLinks, valuta, "Opname", null);
                UpdateLabels();
            }
            else if (valuta == 0)
            {
                MessageBox.Show("0 is geen geldige waarde", "Fout");
            }
            else
            {
                MessageBox.Show("Te weinig saldo", "Fout");
            }
        }

        private void bStorten1_Click(object sender, EventArgs e)
        {
            decimal euro = Convert.ToDecimal(numMoney1.Value);
            decimal cent = (Convert.ToDecimal(numCents1.Value) / 100) + 0.00M;
            decimal bedrag = euro + cent;
            decimal valuta = bedrag * Convert.ToDecimal(numValuta.Value);

            if (valuta != 0)
            {
                bankrekeningLinks.Stort(valuta);
                UpdateTransactie(bankrekeningLinks, valuta, "Storting", null);
                UpdateLabels();
            }
            else
            {
                MessageBox.Show("Selecteer een bedrag om optenemen", "Fout");
            }
        }

        private void bOpnemen2_Click(object sender, EventArgs e)
        {
            decimal euro = Convert.ToDecimal(numMoney2.Value);
            decimal cent = (Convert.ToDecimal(numCents2.Value) / 100) + 0.00M;
            decimal bedrag = euro + cent;
            decimal valuta = bedrag * Convert.ToDecimal(numValuta.Value);

            if ((bankrekeningRechts.Saldo - valuta) >= 0 && valuta != 0)
            {
                bankrekeningRechts.NeemOp(valuta);
                UpdateTransactie(bankrekeningRechts, valuta, "Opname", null);
                UpdateLabels();
            }
            else if (valuta == 0)
            {
                MessageBox.Show("0 is geen geldige waarde", "Fout");
            }
            else
            {
                MessageBox.Show("Te weinig saldo", "Fout");
            }
        }

        private void bStorten2_Click(object sender, EventArgs e)
        {
            decimal euro = Convert.ToDecimal(numMoney2.Value);
            decimal cent = (Convert.ToDecimal(numCents2.Value) / 100) + 0.00M;
            decimal bedrag = euro + cent;
            decimal valuta = bedrag * Convert.ToDecimal(numValuta.Value);

            if (valuta != 0)
            {
                bankrekeningRechts.Stort(valuta);
                UpdateTransactie(bankrekeningRechts, valuta, "Storting", null);
                UpdateLabels();
            }
            else
            {
                MessageBox.Show("Selecteer een bedrag om optenemen", "Fout");
            }
        }

        private void bOverboeking1Naar2_Click(object sender, EventArgs e)
        {
            decimal euro = Convert.ToDecimal(numMoney1.Value);
            decimal cent = (Convert.ToDecimal(numCents1.Value) / 100) + 0.00M;
            decimal bedrag = euro + cent;
            decimal valuta = bedrag * Convert.ToDecimal(numValuta.Value);

            if ((bankrekeningLinks.Saldo - valuta) >= 0 && valuta != 0)
            {
                bankrekeningLinks.MaakOverNaar(bankrekeningRechts, valuta);
                UpdateTransactie(bankrekeningLinks, valuta, "Overboeking", bankrekeningRechts);
                UpdateLabels();
            }
            else if (valuta == 0)
            {
                MessageBox.Show("0 is geen geldige waarde", "Fout");
            }
            else
            {
                MessageBox.Show("Te weinig saldo", "Fout");
            }
        }

        private void bOverboeken2Naar1_Click(object sender, EventArgs e)
        {
            decimal euro = Convert.ToDecimal(numMoney2.Value);
            decimal cent = (Convert.ToDecimal(numCents2.Value) / 100) + 0.00M;
            decimal bedrag = euro + cent;
            decimal valuta = bedrag * Convert.ToDecimal(numValuta.Value);

            if ((bankrekeningRechts.Saldo - valuta) >= 0 && valuta != 0)
            {
                bankrekeningRechts.MaakOverNaar(bankrekeningLinks, valuta);
                UpdateTransactie(bankrekeningRechts, valuta, "Overboeking", bankrekeningLinks);
                UpdateLabels();
            }
            else if (valuta == 0)
            {
                MessageBox.Show("0 is geen geldige waarde", "Fout");
            }
            else
            {
                MessageBox.Show("Te weinig saldo", "Fout");
            }
        }
    }
}
