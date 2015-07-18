//Form

namespace Reserveringssysteem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public partial class NieuweReserveringForm : Form
    {
        private int reserveringsNummer;
        private bool gelukt = false; //Geeft aan of deze stap van het aanmaken van een nieuwe reservering helemaal gelukt is.
        private ToolTip tooltip = new ToolTip();

        public NieuweReserveringForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Maakt het mogelijk om dit reserveringsnummer door te geven aan een ander form.
        /// </summary>
        public int ReserveringsNummer
        {
            get
            {
                return this.reserveringsNummer;
            }
        }

        /// <summary>
        /// Geeft aan dat de query gelukt is, zodat bij error en sluiten van dit form ReserveringForm niet geopend wordt.
        /// </summary>
        public bool Gelukt
        {
            get
            {
                return this.gelukt;
            }
        }

        /// <summary>
        /// Bevestigd een nieuwe reservering. De ingevulde gegevens worden weggeschreven naar de database. 
        /// En er wordt een nieuw reserveringsnummer aangemaakt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBevestig_Click(object sender, EventArgs e)
        {
            // query om laatste reserveringsnummer te krijgen
            // reserverings wegschrijven en betalende klant aanmaken
            // als dit gelukt is word het gekozen reserveringsnummer in de var gezet.
            // En dit form gesloten.

            try
            {
                this.reserveringsNummer = DatabaseKoppeling.GetNieuwReserveringsnummer();
                Reservering reservering = new Reservering(this.reserveringsNummer, "false");
                DatabaseKoppeling.AddReservering(reservering);
                string rfid = DatabaseKoppeling.GetVrijRFID();
                BetalendeKlant klant = new BetalendeKlant(rfid, this.tbNaam.Text, this.tbSofi.Text, this.tbEmail.Text, this.tbTelefoon.Text, this.tbWoonplaats.Text, this.tbStraat.Text, this.tbRekening.Text, this.tbPostcode.Text, this.reserveringsNummer);
                DatabaseKoppeling.AddBetalendeKlant(klant);
                this.gelukt = true;

                this.Close();
            }
            catch (Oracle.DataAccess.Client.OracleException)
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sluit het form af zonder iets op te slaan in de Database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAnnuleer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NieuweReserveringForm_Load(object sender, EventArgs e)
        {
            this.tbNaam.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbEmail.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbPostcode.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbRekening.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbSofi.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbStraat.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbTelefoon.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbWoonplaats.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.btnAnnuleer.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.btnBevestig.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
        }

        private void View_HelpRequested(object sender, HelpEventArgs e)
        {
            Control requestingControl = (Control)sender;
            this.tooltip.ToolTipIcon = ToolTipIcon.Info;
            this.tooltip.ToolTipTitle = requestingControl.Text;
            this.tooltip.UseAnimation = true;
            this.tooltip.Show(requestingControl.Tag.ToString(), requestingControl, 5000);
            e.Handled = true;
        }
    }
}
