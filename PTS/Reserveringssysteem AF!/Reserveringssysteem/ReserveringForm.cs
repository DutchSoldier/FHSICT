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
    public partial class ReserveringForm : Form
    {
        private int reserveringsNummer;
        private bool viewmode; //Geeft aan of ReserveringForm geopend is voor het toevoegen van een nieuwe reservering of het wijzigen van een bestaande reservering.
        private int personen;
        List<Kampeerplek> kampeerplaatsen = new List<Kampeerplek>(); //Bevat alle kampeerplaatsen met hun informatie
        List<string> bezetteKampeerplaatsen = new List<string>(); //Bevat de plaatsnummers van de reeds gereserveerde plaatsen
        ToolTip tooltip = new ToolTip(); //Tooltip object waarmee de gegevens van de plaatsen worden weergegeven
        private string kampeerplaats; //Zorgt ervoor dat een tooltip niet gaat flikkeren als de muis op een kampeerplek blijft staan

        /// <summary>
        /// De constructor laad alle velden, stelt de Form in voor wijzigen of toevoegen van een reservering en laad alle knoppen op de plattegrond.
        /// </summary>
        /// <param name="reserveringsNummer">Reserveringsnummer van de aangemaakte of te wijzingen reservering</param>
        /// <param name="viewmode">Wanneer true is dit Form ingesteld voor toevoegen reservering.</param>
        public ReserveringForm(int reserveringsNummer, bool viewmode)
        {
            InitializeComponent();

            this.reserveringsNummer = reserveringsNummer;
            this.viewmode = viewmode;
            LoadVelden();
            SetViewMode(viewmode);
            LoadKampeerplaatsen();
        }

        /// <summary>
        /// Deze functie zorgt ervoor dat de gegevens voor de Kampeerplek knoppen op de plattegrond herladen worden. 
        /// </summary>
        private void LoadKampeerplaatsen()
        {
            kampeerplaatsen = GetButtonsForMap();
            bezetteKampeerplaatsen = GetBezetteButtonsForMap();
            campingPanel.Invalidate();
        }

        /// <summary>
        /// Hiermee worden de knoppen op de plattegrond getekend. Bezette plaatsen worden rood getekend en beschikbare plaatsen blauw.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void campingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 7, FontStyle.Regular);
            StringFormat formatString = new StringFormat();
            formatString.Alignment = StringAlignment.Center;
            formatString.LineAlignment = StringAlignment.Center;

            foreach (Kampeerplek kp in kampeerplaatsen)
            {
                int width = 25;
                int height = 15;
                RectangleF displayRectangle = new RectangleF(new PointF(kp.X - width / 2, kp.Y - height / 2), new Size(width, height));

                if (bezetteKampeerplaatsen.Contains(kp.PlaatsNummer))
                {
                    graphics.FillEllipse(Brushes.Red, displayRectangle);
                }
                else
                {
                    graphics.FillEllipse(Brushes.Blue, displayRectangle);
                }
                graphics.DrawString(kp.PlaatsNummer, font, Brushes.White, displayRectangle, formatString);
            }
        }

        /// <summary>
        /// Haalt alle kampeerplaatsen en hun gegevens op uit de database.
        /// </summary>
        /// <returns>Geeft een lijst met Kampeerplek objecten terug.</returns>
        private List<Kampeerplek> GetButtonsForMap()
        {
            List<Kampeerplek> kampeerplekken = new List<Kampeerplek>();

            try
            {
                kampeerplekken = DatabaseKoppeling.GetKampeerplekken();
            }
            catch (Oracle.DataAccess.Client.OracleException)
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return kampeerplekken;
        }

        /// <summary>
        /// Haalt alle bezette kampeerplaatsen op uit de database.
        /// </summary>
        /// <returns>Geeft een lijst met bezette plaatsnummers terug.</returns>
        private List<string> GetBezetteButtonsForMap()
        {
            List<string> kampeerplekken = new List<string>();

            try
            {
                kampeerplekken = DatabaseKoppeling.GetAlleGereserveerdePlaatsen();
            }
            catch (Oracle.DataAccess.Client.OracleException)
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return kampeerplekken;
        }

        /// <summary>
        /// Stelt het Form in voor het toevoegen van een nieuwe reservering of het wijzigen van een bestaande reservering.
        /// </summary>
        /// <param name="viewmode">Waneer true is het Form ingesteld op reservering toevoegen.</param>
        private void SetViewMode(bool viewmode)
        {
            tbNaam.ReadOnly = viewmode;
            tbRekening.ReadOnly = viewmode;
            tbPostcode.ReadOnly = viewmode;
            tbEmail.ReadOnly = viewmode;
            tbSofinummer.ReadOnly = viewmode;
            tbTelefoon.ReadOnly = viewmode;
            tbWoonplaats.ReadOnly = viewmode;
            tbStraat.ReadOnly = viewmode;
            if (!viewmode)
            {
                btnBevestig.Text = "Wijzig reservering";
            }
        }

        /// <summary>
        /// Deze functie zet de informatie uit de database in de daarvoor bestemde tekstvelden.
        /// </summary>
        private void LoadVelden()
        {
            tbReserveringsNummer.Text = reserveringsNummer.ToString();
            try
            {
                List<Kampeerplek> plaatsen = DatabaseKoppeling.GetReserveringPlaatsen(reserveringsNummer);
                foreach (Kampeerplek pl in plaatsen)
                {
                    ListViewItem tempItem = new ListViewItem(pl.PlaatsNummer.ToString(), 0);
                    tempItem.Name = pl.PlaatsNummer.ToString();
                    tempItem.SubItems.Add(pl.Prijs.ToString());

                    listViewPlaatsen.Items.Add(tempItem);
                }
                lblPrijs.Text = "€ " + DatabaseKoppeling.GetReserveringPrijs(reserveringsNummer).ToString();
                personen = DatabaseKoppeling.GetAantalPersonen(reserveringsNummer);
                nudAantal.Value = personen;
                BetalendeKlant klant = DatabaseKoppeling.GetKlantBetalend(reserveringsNummer);
                tbNaam.Text = klant.Naam;
                tbRekening.Text = klant.Rekeningnummer;
                tbPostcode.Text = klant.Postcode;
                tbEmail.Text = klant.Email;
                tbSofinummer.Text = klant.Rijbewijsnummer;
                tbTelefoon.Text = klant.Telefoon.ToString();
                tbWoonplaats.Text = klant.Woonplaats;
                tbStraat.Text = klant.Straat;
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
        /// Deze knop verwijderd een plaats uit de reservering. Deze wordt ook direct verwijderd uit de 
        /// database zodat deze meteen weer kan worden gebruikt in een andere reservering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerwijderPlek_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewPlaatsen.FocusedItem.Name != null)
                {
                    DatabaseKoppeling.RemovePlaats(listViewPlaatsen.FocusedItem.Name);
                    listViewPlaatsen.Items.RemoveAt(listViewPlaatsen.FocusedItem.Index);
                    lblPrijs.Text = "€ " + DatabaseKoppeling.GetReserveringPrijs(reserveringsNummer).ToString();
                    LoadKampeerplaatsen();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Selecteer eerst een kampeerplaats!", "Melding", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        /// Deze knop bevestigd de reservering. En voegt het aantal personen voor de reservering 
        /// toe aan de DB of verwijderd ze als het er minder zijn geworden. Als het Form in de 
        /// wijzig modes staat worden de BetalendeKlant gegevens geupdat in de DB.
        /// LET OP: vul hier de juiste smtp server in! Voor fontys: smtp1.fontys.nl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBevestig_Click(object sender, EventArgs e)
        {
            try
            {
                if (!viewmode) //zorgt ervoor dat betalende klant alleen geupdate wordt als er op wijzigen is geklikt.
                {
                    BetalendeKlant klant = new BetalendeKlant(tbNaam.Text, tbSofinummer.Text, tbEmail.Text, tbTelefoon.Text, tbWoonplaats.Text, tbStraat.Text, tbRekening.Text, tbPostcode.Text, reserveringsNummer);
                    DatabaseKoppeling.UpdateKlantBetalend(klant);
                }

                if (nudAantal.Value > personen)
                {
                    //create zoveel extra personen als het verschil is
                    int verschil = (int)nudAantal.Value - personen;
                    for (int i = 0; i < verschil; i++)
                    {
                        string vrijRFID = DatabaseKoppeling.GetVrijRFID();
                        Klant klant = new Klant(vrijRFID, reserveringsNummer);
                        DatabaseKoppeling.AddKlant(klant);
                    }
                }
                else
                {
                    //Verwijder zoveel personen als het verschil is
                    int verschil = personen - (int)nudAantal.Value;
                    for (int i = 0; i < verschil; i++)
                    {
                        string rfid = DatabaseKoppeling.GetRFIDReservering(reserveringsNummer);
                        if (rfid != null)
                        {
                            DatabaseKoppeling.RemoveKlant(rfid);
                        }
                    }
                }

                SendMail mail = new SendMail();
                List<Persoon> inloggegevens = DatabaseKoppeling.GetInlogGegevens(reserveringsNummer);
                string body = mail.Mailbody(reserveringsNummer, tbNaam.Text, (int)nudAantal.Value, lblPrijs.Text, tbRekening.Text, inloggegevens);
                mail.VerzendMail("info@ICT4Events.nl", tbEmail.Text, "Bevestiging Reservering", body, "smtp1.fontys.nl");

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
        /// Hiermee worden de kampeerplaats knoppen op de plattegrond aanklikbaar. Een aangeklikte plaats wordt 
        /// direct opgeslagen in de database zodat je geen conflicten krijgt als er meerdere instanties van de 
        /// reserveringsapp draaien die dezelfde plaats willen reserveren. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void campingPanel_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Kampeerplek kp in kampeerplaatsen)
	        {
                int width = 25;
                int height = 15;
                RectangleF displayRectangle = new RectangleF(new PointF(kp.X - width / 2, kp.Y - height / 2), new Size(width, height));
                if (displayRectangle.Contains(e.Location))
                {
                    if (!bezetteKampeerplaatsen.Contains(kp.PlaatsNummer))
                    {
                        try
                        {
                            DatabaseKoppeling.AddReserveringPlaats(reserveringsNummer, kp.PlaatsNummer);
                            ListViewItem tempItem = new ListViewItem(kp.PlaatsNummer.ToString(), 0);
                            tempItem.Name = kp.PlaatsNummer.ToString();
                            tempItem.SubItems.Add(kp.Prijs.ToString());

                            listViewPlaatsen.Items.Add(tempItem);
                            lblPrijs.Text = "€ " + DatabaseKoppeling.GetReserveringPrijs(reserveringsNummer).ToString();
                            LoadKampeerplaatsen();
                        }
                        catch (Oracle.DataAccess.Client.OracleException)
                        {
                            MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LoadKampeerplaatsen();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Deze kampeerplaats is reeds bezet.", "Melding", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
	        }
        }

        /// <summary>
        /// Hiermee worden de tooltips voor de kampeerplaatsknoppen op de plattegrond zichtbaar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void campingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Kampeerplek kp in kampeerplaatsen)
            {
                int width = 25;
                int height = 15;
                RectangleF displayRectangle = new RectangleF(new PointF(kp.X - width / 2, kp.Y - height / 2), new Size(width, height));
                if (displayRectangle.Contains(campingPanel.PointToClient(Cursor.Position)) && kampeerplaats != kp.PlaatsNummer)
                {
                    kampeerplaats = kp.PlaatsNummer;
                    tooltip.Show(kp.PlekInfo(), campingPanel, kp.X, kp.Y + 10, 2000);
                }
            }
        }

        private void ReserveringForm_Load(object sender, EventArgs e)
        {
            tbNaam.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbEmail.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbPostcode.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbRekening.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbSofinummer.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbStraat.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbTelefoon.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbWoonplaats.HelpRequested += new HelpEventHandler(View_HelpRequested);
            tbReserveringsNummer.HelpRequested += new HelpEventHandler(View_HelpRequested);
            listViewPlaatsen.HelpRequested += new HelpEventHandler(View_HelpRequested);
            lblPrijs.HelpRequested += new HelpEventHandler(View_HelpRequested);
            btnVerwijderPlek.HelpRequested += new HelpEventHandler(View_HelpRequested);
            btnBevestig.HelpRequested += new HelpEventHandler(View_HelpRequested);
            nudAantal.HelpRequested += new HelpEventHandler(View_HelpRequested);
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
