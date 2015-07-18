//Verhuurapplicatie

namespace MateriaalVerhuurApplicatie
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public partial class VerhuurApplicatie : Form
    {
        /// <summary>
        /// Hier worden alle gebruikte lists en een tooltip aangemaakt die later in deze klasse worden gebruikt.
        /// </summary>
        private List<Materiaal> materialen = DatabaseKoppeling.GetMateriaal();
        private List<Uitlening> lening = new List<Uitlening>();
        private List<Uitlening> uitgeleend = new List<Uitlening>();
        private List<Uitlening> personen = new List<Uitlening>();
        private ToolTip tooltip = new ToolTip();
       
        public VerhuurApplicatie()
        {
            this.InitializeComponent();
            this.RefreshListboxes();
        }

        /// <summary>
        /// Dit is de eventhandler voor het functioneren van de tooltips.
        /// </summary>
        /// <param name="sender">Het UI element waarover help wordt opgevraagt.</param>
        /// <param name="hlpevent"></param>
        public void View_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control requestingControl = (Control)sender;
            this.tooltip.ToolTipIcon = ToolTipIcon.Info;
            this.tooltip.ToolTipTitle = requestingControl.Text;
            this.tooltip.UseAnimation = true;
            this.tooltip.Show(requestingControl.Tag.ToString(), requestingControl, 5000);
            hlpevent.Handled = true;
        }

        private void MateriaalInfo_Click(object sender, EventArgs e)
        {
            this.RefreshListboxes();
        }

        private void ListBoxMaterialen_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = Convert.ToString(DatabaseKoppeling.GetHoeveelheidMateriaal(this.materialen[this.listBoxMaterialen.SelectedIndex]));
            this.textBox2.Text = "€" + this.materialen[this.listBoxMaterialen.SelectedIndex].Prijs.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.textBoxReserveringsNr.Text == string.Empty)
            {
                MessageBox.Show("Vul een geldig reserveringsnummer in.");
                return;
            }
            this.buttonReserveren.Enabled = true;
            this.buttonannuleren.Enabled = true;
            this.btcancel.Enabled = true;
            this.RefreshListboxes();
        }

        /// <summary>
        /// Deze methode zorgt ervoor dat alle Listboxes worden leeggemaakt, de waardes worden geupdate en de listboxes weer opgevuld worden met de correcte waardes.
        /// </summary>
        private void RefreshListboxes()
        {
            List<Materiaal> materialen = DatabaseKoppeling.GetMateriaal();

            // Clear alle listboxes
            this.listboxDoorKlantGehuurd.Items.Clear();
            this.listboxBeschikbaarMateriaal.Items.Clear();
            this.listBoxVerhuurdMateriaal.Items.Clear();
            this.listBoxMaterialen.Items.Clear();
            this.listBoxVerhuurdAan.Items.Clear();

            //Alle listboxes weer opvullen
            this.uitgeleend = DatabaseKoppeling.GetAantalUitgeleend();
            for (int i = 0; i < this.uitgeleend.Count(); i++)
            {
                this.listBoxVerhuurdMateriaal.Items.Add(this.uitgeleend[i].Type);   
            }
            for (int i = 0; i < materialen.Count(); i++)
            {
                if (DatabaseKoppeling.GetHoeveelheidMateriaal(materialen[i]) >= 1)
                {
                    this.listboxBeschikbaarMateriaal.Items.Add(materialen[i].Type + ", " + DatabaseKoppeling.GetHoeveelheidMateriaal(materialen[i]) + " stuks," + materialen[i].Prijs + " €");
                }
                this.listBoxMaterialen.Items.Add(materialen[i].Type);
            }
            try
            {
                this.lening = DatabaseKoppeling.GetUitlening(Convert.ToInt32(this.textBoxReserveringsNr.Text));
                for (int i = 0; i < this.lening.Count(); i++)
                {
                    this.listboxDoorKlantGehuurd.Items.Add(this.lening[i].Type + ", " + this.lening[i].Aantal + " stuks");
                }
                
            }
            catch
            {
                    Application.Exit();
            }

            for (int i = 0; i < this.personen.Count(); i++)
            {
                this.listBoxVerhuurdAan.Items.Add(this.personen[i].Reserveringsnummer + " " + DatabaseKoppeling.GetPersoonByReserveringsnr(this.personen[i].Reserveringsnummer));
            }
        }

        private void ListboxDoorKlantGehuurd_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Zet de DateTimePicker waardes die bij de uitlening horen.
            try
            {
                this.dateTimePicker1.Value = this.lening[this.listboxDoorKlantGehuurd.SelectedIndex].Datum_uitgeleend;
                this.dateTimePicker2.Value = this.lening[this.listboxDoorKlantGehuurd.SelectedIndex].Datum_ingeleverd;
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

        private void ButtonReserveren_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
            {
                MessageBox.Show("De einddatum ligt voor de begindatum!");
                return;
            }
            else
            {
                //Maak een nieuwe reservering aan.
                try
                {
                    Materiaal nieuwmat = new Materiaal(this.materialen[this.listboxBeschikbaarMateriaal.SelectedIndex].Type, this.materialen[this.listboxBeschikbaarMateriaal.SelectedIndex].Prijs, this.materialen[this.listboxBeschikbaarMateriaal.SelectedIndex].Aantal);

                    DatabaseKoppeling.AddUitlening(Convert.ToInt32(this.textBoxReserveringsNr.Text), nieuwmat, this.dateTimePicker1.Value, this.dateTimePicker2.Value, this.listboxDoorKlantGehuurd);
                    this.RefreshListboxes();
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

        private void Buttonannuleren_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseKoppeling.RemoveUitlening(this.lening[this.listboxDoorKlantGehuurd.SelectedIndex], Convert.ToInt32(this.textBoxReserveringsNr.Text));
                this.lening.Remove(this.lening[this.listboxDoorKlantGehuurd.SelectedIndex]);
                this.RefreshListboxes();
            }
            catch (Exception)
            {
            }
        }

        private void ListBoxVerhuurdMateriaal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.personen = DatabaseKoppeling.GetPersonenBijUitlening(this.listBoxVerhuurdMateriaal.SelectedItem.ToString());
                this.RefreshListboxes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void Btcancel_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseKoppeling.RemoveGeheleUitlening(Convert.ToInt32(this.textBoxReserveringsNr.Text));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            this.RefreshListboxes();
        }

        /// <summary>
        /// Geef alle HelpRequested methodes van de UI elementen een nieuw HelpEventHandler. Deze eventhandler is eerder in de code gemaakt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerhuurApplicatie_Load(object sender, EventArgs e)
        {
            //Alle eventhandlers voor de tooltips
            this.button1.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.btcancel.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.buttonannuleren.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.listboxDoorKlantGehuurd.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.listboxBeschikbaarMateriaal.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.listBoxVerhuurdAan.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.listBoxVerhuurdMateriaal.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.listBoxMaterialen.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.dateTimePicker1.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.dateTimePicker2.HelpRequested += new HelpEventHandler(this.View_HelpRequested);

            //Laad Listboxes
            this.RefreshListboxes();
        }

        private void Verhuren_Click(object sender, EventArgs e)
        {

        }
    }
}
