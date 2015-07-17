using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace OpdrachtDierenasiel1
{
    /// <summary>
    /// Een windows application om inheritance te testen.
    /// Als voorbeeld nemen we de classes Hond en Kat, die erven van de class Huisdier.
    /// </summary>
    public partial class FormDierenasiel : Form
    {
        private Huisdier h;
        private List<Huisdier> gereserveerd;
        private List<Huisdier> beschikbaar;
        private string chipNummer;


        /// <summary>
        /// Deze constructor creeert een applicatie. 
        /// <p>De variabele h (van het type Huisdier) is gelijk aan null.</p>
        /// </summary>
        public FormDierenasiel()
        {
            InitializeComponent();
            h = null;
            gereserveerd = new List<Huisdier>();
            beschikbaar = new List<Huisdier>();



        }

        /// <summary>
        /// Afhankelijk van of de radiobutton "hond" of "kat" is aangevinkt,
        /// wordt "h = new Hond(...);" of  "h = new Kat(...);" uitgevoerd. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaakDier_Click(object sender, EventArgs e)
        {
            //moet je nog maken
            if (rdBtnHond.Checked)
            {
                h = new Hond(tbChipnummer.Text, Convert.ToInt32(tbGeboortedag.Text), tbRoepnaam.Text, cbGereserveerd.Checked, Convert.ToInt32(tbDag.Text), Convert.ToInt32(tbMaand.Text), Convert.ToInt32(tbJaar.Text));
                if (h.gereserveerd == true)
                {
                    gereserveerd.Add(h);
                }
                else
                {
                    beschikbaar.Add(h);
                }

            }

            if (rdBtnKat.Checked)
            {


                h = new Kat(tbChipnummer.Text, Convert.ToInt32(tbGeboortedag.Text), tbRoepnaam.Text, cbGereserveerd.Checked, tbExtraInfo.Text);
                if (h.gereserveerd == true)
                {
                    gereserveerd.Add(h);
                }
                else
                {
                    beschikbaar.Add(h);
                }
            }
        }

        /// <summary>
        /// Informatie over huisdier h verschijnt op het scherm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeefInfo_Click(object sender, EventArgs e)
        {
            //moet je nog maken
            RefreshListboxes();
        }

        private void rdBtnHond_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnHond.Checked)
            {
                lDag.Visible = true;
                lMaand.Visible = true;
                lJaar.Visible = true;
                tbDag.Visible = true;
                tbMaand.Visible = true;
                tbJaar.Visible = true;
                lExtraInfo.Visible = false;
                tbExtraInfo.Visible = false;
            }

            if (rdBtnKat.Checked)
            {
                lDag.Visible = false;
                lMaand.Visible = false;
                lJaar.Visible = false;
                tbDag.Visible = false;
                tbMaand.Visible = false;
                tbJaar.Visible = false;
                lExtraInfo.Visible = true;
                tbExtraInfo.Visible = true;
            }
        }

        private void bReserveer_Click(object sender, EventArgs e)
        {
            if (lbGereserveerd.SelectedItem != null)
            {
                searchChip(chipNummer);
                foreach (Huisdier h in gereserveerd)
                {
                    if (chipNummer == h.Chipnummer)
                    {
                        lbGereserveerd.SelectedItem = h;

                        if (h.gereserveerd == true)
                        {
                            h.gereserveerd = false;
                            beschikbaar.Add(h);
                            gereserveerd.Remove(h);
                        }
                    }
                }
            }
            if (lbBeschikbaar.SelectedItem != null)
            {
                searchChip(chipNummer);
                foreach (Huisdier h in beschikbaar)
                {
                    if (chipNummer == h.Chipnummer)
                    {
                        lbGereserveerd.SelectedItem = h;

                        if (h.gereserveerd == false)
                        {
                            h.gereserveerd = true;
                            gereserveerd.Add(h);
                            beschikbaar.Remove(h);
                        }
                    }
                }
                RefreshListboxes();
            }
        }

        private void lbNietGereserveerd_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbGereserveerd.ClearSelected();
        }

        private void lbGereserveerd_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbBeschikbaar.ClearSelected();
        }

        private void RefreshListboxes()
        {
            lbGereserveerd.Items.Clear();
            lbBeschikbaar.Items.Clear();
            foreach (Huisdier h in gereserveerd)
            {
                if (h.gereserveerd == true)
                {
                    lbGereserveerd.Items.Add(h.GetInfo());
                }
            }
            foreach (Huisdier h in beschikbaar)
            {
                if (h.gereserveerd == false)
                {
                    lbBeschikbaar.Items.Add(h.GetInfo());
                }
            }
        }

        private void bVerwijder_Click(object sender, EventArgs e)
        {
            if (lbGereserveerd.SelectedItem != null)
            {
                lbGereserveerd.SelectedItem = h;
                gereserveerd.Remove(h);
            }

            if (lbBeschikbaar.SelectedItem != null)
            {
                lbBeschikbaar.SelectedItem = h;
                beschikbaar.Remove(h);
            }
            RefreshListboxes();
        }

        private void searchChip(string chipNummer)
        {
            int start;
            if (lbGereserveerd.SelectedItem != null)
            {
                string s = Convert.ToString(lbGereserveerd.SelectedItem);
                start = s.IndexOf(":");
                chipNummer = s.Substring(start + 2, 5);
            }
            if (lbBeschikbaar.SelectedItem != null)
            {
                string s = Convert.ToString(lbBeschikbaar.SelectedItem);
                start = s.IndexOf(":");
                chipNummer = s.Substring(start + 2, 5);
            }
        }

        private void bttextbestand_Click(object sender, EventArgs e)
        {
            try
            {

                int i = lbBeschikbaar.Items.Count;
                int p = lbGereserveerd.Items.Count;

                object[] obj = new object[i];
                object[] obje = new object[p];

                lbGereserveerd.Items.CopyTo(obje, 0);
                lbBeschikbaar.Items.CopyTo(obj, 0);

                i = obj.Length;
                p = obje.Length;

                FileDialog oDialog = new SaveFileDialog();

                oDialog.DefaultExt = "log";

                oDialog.FileName = "Lijst met dieren";

                if (oDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@oDialog.FileName))
                    {
                        for (int w = 0; w < 1; w++)
                        {
                            file.WriteLine("Niet gereserveerd");
                            foreach (string line in obj)
                            {
                                file.WriteLine(line);
                            }
                            {
                                file.WriteLine("Gereserveerd");
                                foreach (string regel in obje)
                                {
                                    file.WriteLine(regel);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("" + exp);
            }
        }
    }
}




