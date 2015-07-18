using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reserveringssysteem
{
    public partial class NieuweReserveringForm : Form
    {
        private int reserveringsNummer;
        private bool gelukt = false; //Geeft aan of deze stap van het aanmaken van een nieuwe reservering helemaal gelukt is.
        ToolTip tooltip = new ToolTip();

        /// <summary>
        /// Maakt het mogelijk om dit reserveringsnummer door te geven aan een ander form.
        /// </summary>
        public int ReserveringsNummer
        {
            get
            {
                return reserveringsNummer;
            }
        }

        /// <summary>
        /// Geeft aan dat de query gelukt is, zodat bij error en sluiten van dit form ReserveringForm niet geopend wordt.
        /// </summary>
        public bool Gelukt
        {
            get
            {
                return gelukt;
            }
        }

        public NieuweReserveringForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bevestigd een nieuwe reservering. De ingevulde gegevens worden weggeschreven naar de database. 
        /// En er wordt een nieuw reserveringsnummer aangemaakt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBevestig_Click(object sender, EventArgs e)
        {
            // query om laatste reserveringsnummer te krijgen
            // reserverings wegschrijven en betalende klant aanmaken
            // als dit gelukt is word het gekozen reserveringsnummer in de var gezet.
            // En dit form gesloten.

            try
            {
                reserveringsNummer = DatabaseKoppeling.GetNieuwReserveringsnummer();
                Reservering reservering = new Reservering(reserveringsNummer, "false");
                DatabaseKoppeling.AddReservering(reservering);
                string rfid = DatabaseKoppeling.GetVrijRFID();
                BetalendeKlant klant = new BetalendeKlant(rfid, tbNaam.Text, tbSofi.Text, tbEmail.Text, tbTelefoon.Text, tbWoonplaats.Text, tbStraat.Text, tbRekening.Text, tbPostcode.Text, reserveringsNummer);
                DatabaseKoppeling.AddBetalendeKlant(klant);
                gelukt = true;

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
        private void btnAnnuleer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NieuweReserveringForm_Load(object sender, EventArgs e)
        {
            tbNaam.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbEmail.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbPostcode.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbRekening.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbSofi.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbStraat.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbTelefoon.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbWoonplaats.HelpRequested += new HelpEventHandler(View_HelpRequested);
            btnAnnuleer.HelpRequested += new HelpEventHandler(View_HelpRequested);
            btnBevestig.HelpRequested += new HelpEventHandler(View_HelpRequested);
        }

        private void View_HelpRequested(object sender, HelpEventArgs e)
        {
            Control requestingControl = (Control)sender;
            tooltip.ToolTipIcon = ToolTipIcon.Info;
            tooltip.ToolTipTitle = requestingControl.Text;
            tooltip.UseAnimation = true;
            tooltip.Show(requestingControl.Tag.ToString(), requestingControl, 5000);
            e.Handled = true;
        }
    }
}
