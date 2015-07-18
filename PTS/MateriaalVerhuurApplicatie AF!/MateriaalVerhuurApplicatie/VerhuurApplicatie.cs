using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MateriaalVerhuurApplicatie
{
    public partial class VerhuurApplicatie : Form
    {
        /// <summary>
        /// Hier worden alle gebruikte lists en een tooltip aangemaakt die later in deze klasse worden gebruikt.
        /// </summary>
        List<Materiaal> materialen = DatabaseKoppeling.getMateriaal();
        List<Uitlening> lening = new List<Uitlening>();
        List<Uitlening> uitgeleend = new List<Uitlening>();
        List<Uitlening> personen = new List<Uitlening>();
        ToolTip tooltip = new ToolTip();
       

        public VerhuurApplicatie()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dit is de eventhandler voor het functioneren van de tooltips.
        /// </summary>
        /// <param name="sender">Het UI element waarover help wordt opgevraagt.</param>
        /// <param name="hlpevent"></param>
        void View_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control requestingControl = (Control)sender;
            tooltip.ToolTipIcon = ToolTipIcon.Info;
            tooltip.ToolTipTitle = requestingControl.Text;
            tooltip.UseAnimation = true;
            tooltip.Show(requestingControl.Tag.ToString(), requestingControl, 5000);
            hlpevent.Handled = true;
        }

        private void MateriaalInfo_Click(object sender, EventArgs e)
        {
            RefreshListboxes();
        }

        private void listBoxMaterialen_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(DatabaseKoppeling.GetHoeveelheidMateriaal(materialen[listBoxMaterialen.SelectedIndex]));
            textBox2.Text = "€" + materialen[listBoxMaterialen.SelectedIndex].Prijs.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxReserveringsNr.Text == "")
            {
                MessageBox.Show("Vul een geldig reserveringsnummer in.");
                return;
            }
            buttonReserveren.Enabled = true;
            buttonannuleren.Enabled = true;
            btcancel.Enabled = true;
            RefreshListboxes();
        }

        /// <summary>
        /// Deze methode zorgt ervoor dat alle Listboxes worden leeggemaakt, de waardes worden geupdate en de listboxes weer opgevuld worden met de correcte waardes.
        /// </summary>
        private void RefreshListboxes()
        {
            List<Materiaal> materialen = DatabaseKoppeling.getMateriaal();

            // Clear alle listboxes
            ListboxDoorKlantGehuurd.Items.Clear();
            listboxBeschikbaarMateriaal.Items.Clear();
            listBoxVerhuurdMateriaal.Items.Clear();
            listBoxMaterialen.Items.Clear();
            listBoxVerhuurdAan.Items.Clear();
            //

            //Alle listboxes weer opvullen
            uitgeleend = DatabaseKoppeling.getAantalUitgeleend();
            for (int i = 0; i < uitgeleend.Count(); i++)
            {
                listBoxVerhuurdMateriaal.Items.Add(uitgeleend[i].Type);   
            }
            for (int i = 0; i < materialen.Count(); i++)
            {
                if (DatabaseKoppeling.GetHoeveelheidMateriaal(materialen[i]) >= 1)
                {
                    listboxBeschikbaarMateriaal.Items.Add(materialen[i].Type + ", " + DatabaseKoppeling.GetHoeveelheidMateriaal(materialen[i]) + " stuks," + materialen[i].Prijs + " €");
                }
                listBoxMaterialen.Items.Add(materialen[i].Type);
            }
            try
            {
                lening = DatabaseKoppeling.getUitlening(Convert.ToInt32(textBoxReserveringsNr.Text));
                for (int i = 0; i < lening.Count(); i++)
                {
                    ListboxDoorKlantGehuurd.Items.Add(lening[i].Type + ", " + lening[i].Aantal + " stuks");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < personen.Count(); i++)
            {
                listBoxVerhuurdAan.Items.Add(personen[i].Reserveringsnummer + " " + DatabaseKoppeling.GetPersoonByReserveringsnr(personen[i].Reserveringsnummer));
            }
        }

        private void ListboxDoorKlantGehuurd_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Zet de DateTimePicker waardes die bij de uitlening horen.
            try
            {
                dateTimePicker1.Value = lening[ListboxDoorKlantGehuurd.SelectedIndex].Datum_uitgeleend;
                dateTimePicker2.Value = lening[ListboxDoorKlantGehuurd.SelectedIndex].Datum_ingeleverd;
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

        private void buttonReserveren_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("De einddatum ligt voor de begindatum!");
                return;
            }
            else
            {
                //Maak een nieuwe reservering aan.
                try
                {
                    Materiaal nieuwmat = new Materiaal(materialen[listboxBeschikbaarMateriaal.SelectedIndex].Type, materialen[listboxBeschikbaarMateriaal.SelectedIndex].Prijs, materialen[listboxBeschikbaarMateriaal.SelectedIndex].Aantal);

                    DatabaseKoppeling.addUitlening(Convert.ToInt32(textBoxReserveringsNr.Text), nieuwmat, dateTimePicker1.Value, dateTimePicker2.Value, ListboxDoorKlantGehuurd);
                    RefreshListboxes();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Selecteer het materiaal dat je wilt reserveren.");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Voer wel een geldig reserveringsnummer in!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Voer een geldig reserveringsnummer in.");
                }

            }
        }

        private void buttonannuleren_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseKoppeling.removeUitlening(lening[ListboxDoorKlantGehuurd.SelectedIndex], Convert.ToInt32(textBoxReserveringsNr.Text));
                lening.Remove(lening[ListboxDoorKlantGehuurd.SelectedIndex]);
                RefreshListboxes();
            }
            catch (Exception)
            {
            }
        }

        private void listBoxVerhuurdMateriaal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                personen = DatabaseKoppeling.getPersonenBijUitlening(listBoxVerhuurdMateriaal.SelectedItem.ToString());
                RefreshListboxes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseKoppeling.RemoveGeheleUitlening(Convert.ToInt32(textBoxReserveringsNr.Text));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            RefreshListboxes();
        }

        /// <summary>
        /// Geef alle HelpRequested methodes van de UI elementen een nieuw HelpEventHandler. Deze eventhandler is eerder in de code gemaakt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerhuurApplicatie_Load(object sender, EventArgs e)
        {
            //Alle eventhandlers voor de tooltips
            button1.HelpRequested += new HelpEventHandler(View_HelpRequested);
            btcancel.HelpRequested +=new HelpEventHandler(View_HelpRequested);
            buttonannuleren.HelpRequested += new HelpEventHandler(View_HelpRequested);
            ListboxDoorKlantGehuurd.HelpRequested += new HelpEventHandler(View_HelpRequested);
            listboxBeschikbaarMateriaal.HelpRequested += new HelpEventHandler(View_HelpRequested);
            listBoxVerhuurdAan.HelpRequested += new HelpEventHandler(View_HelpRequested);
            listBoxVerhuurdMateriaal.HelpRequested += new HelpEventHandler(View_HelpRequested);
            listBoxMaterialen.HelpRequested += new HelpEventHandler(View_HelpRequested);
            dateTimePicker1.HelpRequested += new HelpEventHandler(View_HelpRequested);
            dateTimePicker2.HelpRequested += new HelpEventHandler(View_HelpRequested);
            //

            //Laad Listboxes
            RefreshListboxes();
            //
        }

        private void Verhuren_Click(object sender, EventArgs e)
        {

        }
    }
}
