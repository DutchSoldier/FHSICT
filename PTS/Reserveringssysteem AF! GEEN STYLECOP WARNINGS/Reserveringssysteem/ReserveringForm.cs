//Reservering Form

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

    public partial class ReserveringForm : Form
    {
        private int reserveringsNummer;
        private bool viewmode; //Geeft aan of ReserveringForm geopend is voor het toevoegen van een nieuwe reservering of het wijzigen van een bestaande reservering.
        private int personen;
        private List<Kampeerplek> kampeerplaatsen = new List<Kampeerplek>(); //Bevat alle kampeerplaatsen met hun informatie
        private List<string> bezetteKampeerplaatsen = new List<string>(); //Bevat de plaatsnummers van de reeds gereserveerde plaatsen
        private ToolTip tooltip = new ToolTip(); //Tooltip object waarmee de gegevens van de plaatsen worden weergegeven
        private string kampeerplaats; //Zorgt ervoor dat een tooltip niet gaat flikkeren als de muis op een kampeerplek blijft staan

        /// <summary>
        /// De constructor laad alle velden, stelt de Form in voor wijzigen of toevoegen van een reservering en laad alle knoppen op de plattegrond.
        /// </summary>
        /// <param name="reserveringsNummer">Reserveringsnummer van de aangemaakte of te wijzingen reservering</param>
        /// <param name="viewmode">Wanneer true is dit Form ingesteld voor toevoegen reservering.</param>
        public ReserveringForm(int reserveringsNummer, bool viewmode)
        {
            this.InitializeComponent();

            this.reserveringsNummer = reserveringsNummer;
            this.viewmode = viewmode;
            this.LoadVelden();
            this.SetViewMode(viewmode);
            this.LoadKampeerplaatsen();
        }

        /// <summary>
        /// Deze functie zorgt ervoor dat de gegevens voor de Kampeerplek knoppen op de plattegrond herladen worden. 
        /// </summary>
        private void LoadKampeerplaatsen()
        {
            this.kampeerplaatsen = this.GetButtonsForMap();
            this.bezetteKampeerplaatsen = this.GetBezetteButtonsForMap();
            this.campingPanel.Invalidate();
        }

        /// <summary>
        /// Hiermee worden de knoppen op de plattegrond getekend. Bezette plaatsen worden rood getekend en beschikbare plaatsen blauw.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CampingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 7, FontStyle.Regular);
            StringFormat formatString = new StringFormat();
            formatString.Alignment = StringAlignment.Center;
            formatString.LineAlignment = StringAlignment.Center;

            foreach (Kampeerplek kp in this.kampeerplaatsen)
            {
                int width = 25;
                int height = 15;
                RectangleF displayRectangle = new RectangleF(new PointF(kp.X - width / 2, kp.Y - height / 2), new Size(width, height));

                if (this.bezetteKampeerplaatsen.Contains(kp.PlaatsNummer))
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
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                {
                    Application.Exit();
                }
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
            this.tbNaam.ReadOnly = viewmode;
            this.tbRekening.ReadOnly = viewmode;
            this.tbPostcode.ReadOnly = viewmode;
            this.tbEmail.ReadOnly = viewmode;
            this.tbSofinummer.ReadOnly = viewmode;
            this.tbTelefoon.ReadOnly = viewmode;
            this.tbWoonplaats.ReadOnly = viewmode;
            this.tbStraat.ReadOnly = viewmode;
            if (!viewmode)
            {
                this.btnBevestig.Text = "Wijzig reservering";
            }
        }

        /// <summary>
        /// Deze functie zet de informatie uit de database in de daarvoor bestemde tekstvelden.
        /// </summary>
        private void LoadVelden()
        {
            this.tbReserveringsNummer.Text = this.reserveringsNummer.ToString();
            try
            {
                List<Kampeerplek> plaatsen = DatabaseKoppeling.GetReserveringPlaatsen(this.reserveringsNummer);
                foreach (Kampeerplek pl in plaatsen)
                {
                    ListViewItem tempItem = new ListViewItem(pl.PlaatsNummer.ToString(), 0);
                    tempItem.Name = pl.PlaatsNummer.ToString();
                    tempItem.SubItems.Add(pl.Prijs.ToString());

                    this.listViewPlaatsen.Items.Add(tempItem);
                }
                this.lblPrijs.Text = "€ " + DatabaseKoppeling.GetReserveringPrijs(this.reserveringsNummer).ToString();
                this.personen = DatabaseKoppeling.GetAantalPersonen(this.reserveringsNummer);
                this.nudAantal.Value = this.personen;
                BetalendeKlant klant = DatabaseKoppeling.GetKlantBetalend(this.reserveringsNummer);
                this.tbNaam.Text = klant.Naam;
                this.tbRekening.Text = klant.Rekeningnummer;
                this.tbPostcode.Text = klant.Postcode;
                this.tbEmail.Text = klant.Email;
                this.tbSofinummer.Text = klant.Sofi;
                this.tbTelefoon.Text = klant.Telefoon.ToString();
                this.tbWoonplaats.Text = klant.Woonplaats;
                this.tbStraat.Text = klant.Straat;
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
        private void BtnVerwijderPlek_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listViewPlaatsen.FocusedItem.Name != null)
                {
                    DatabaseKoppeling.RemovePlaats(this.listViewPlaatsen.FocusedItem.Name);
                    this.listViewPlaatsen.Items.RemoveAt(this.listViewPlaatsen.FocusedItem.Index);
                    this.lblPrijs.Text = "€ " + DatabaseKoppeling.GetReserveringPrijs(this.reserveringsNummer).ToString();
                    this.LoadKampeerplaatsen();
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
        private void BtnBevestig_Click(object sender, EventArgs e)
        {
            try
            {
                //zorgt ervoor dat betalende klant alleen geupdate wordt als er op wijzigen is geklikt.
                if (!this.viewmode) 
                {
                    BetalendeKlant klant = new BetalendeKlant(this.tbNaam.Text, this.tbSofinummer.Text, this.tbEmail.Text, this.tbTelefoon.Text, this.tbWoonplaats.Text, this.tbStraat.Text, this.tbRekening.Text, this.tbPostcode.Text, this.reserveringsNummer);
                    DatabaseKoppeling.UpdateKlantBetalend(klant);
                }

                if (this.nudAantal.Value > this.personen)
                {
                    //create zoveel extra personen als het verschil is
                    int verschil = (int)this.nudAantal.Value - this.personen;
                    for (int i = 0; i < verschil; i++)
                    {
                        string vrijRFID = DatabaseKoppeling.GetVrijRFID();
                        Klant klant = new Klant(vrijRFID, this.reserveringsNummer);
                        DatabaseKoppeling.AddKlant(klant);
                    }
                }
                else
                {
                    //Verwijder zoveel personen als het verschil is
                    int verschil = this.personen - (int)this.nudAantal.Value;
                    for (int i = 0; i < verschil; i++)
                    {
                        string rfid = DatabaseKoppeling.GetRFIDReservering(this.reserveringsNummer);
                        if (rfid != null)
                        {
                            DatabaseKoppeling.RemoveKlant(rfid);
                        }
                    }
                }

                SendMail mail = new SendMail();
                List<Persoon> inloggegevens = DatabaseKoppeling.GetInlogGegevens(this.reserveringsNummer);
                string body = mail.Mailbody(this.reserveringsNummer, this.tbNaam.Text, (int)this.nudAantal.Value, this.lblPrijs.Text, this.tbRekening.Text, inloggegevens);
                mail.VerzendMail("info@ICT4Events.nl", this.tbEmail.Text, "Bevestiging Reservering", body, "smtp1.fontys.nl");

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
        private void CampingPanel_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Kampeerplek kp in this.kampeerplaatsen)
	        {
                int width = 25;
                int height = 15;
                RectangleF displayRectangle = new RectangleF(new PointF(kp.X - width / 2, kp.Y - height / 2), new Size(width, height));
                if (displayRectangle.Contains(e.Location))
                {
                    if (!this.bezetteKampeerplaatsen.Contains(kp.PlaatsNummer))
                    {
                        try
                        {
                            DatabaseKoppeling.AddReserveringPlaats(this.reserveringsNummer, kp.PlaatsNummer);
                            ListViewItem tempItem = new ListViewItem(kp.PlaatsNummer.ToString(), 0);
                            tempItem.Name = kp.PlaatsNummer.ToString();
                            tempItem.SubItems.Add(kp.Prijs.ToString());

                            this.listViewPlaatsen.Items.Add(tempItem);
                            this.lblPrijs.Text = "€ " + DatabaseKoppeling.GetReserveringPrijs(this.reserveringsNummer).ToString();
                            this.LoadKampeerplaatsen();
                        }
                        catch (Oracle.DataAccess.Client.OracleException)
                        {
                            MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.LoadKampeerplaatsen();
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
        private void CampingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Kampeerplek kp in this.kampeerplaatsen)
            {
                int width = 25;
                int height = 15;
                RectangleF displayRectangle = new RectangleF(new PointF(kp.X - width / 2, kp.Y - height / 2), new Size(width, height));
                if (displayRectangle.Contains(this.campingPanel.PointToClient(Cursor.Position)) && this.kampeerplaats != kp.PlaatsNummer)
                {
                    this.kampeerplaats = kp.PlaatsNummer;
                    this.tooltip.Show(kp.PlekInfo(), this.campingPanel, kp.X, kp.Y + 10, 2000);
                }
            }
        }

        private void ReserveringForm_Load(object sender, EventArgs e)
        {
            this.tbNaam.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbEmail.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbPostcode.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbRekening.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbSofinummer.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbStraat.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbTelefoon.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbWoonplaats.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.tbReserveringsNummer.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.listViewPlaatsen.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.lblPrijs.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.btnVerwijderPlek.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.btnBevestig.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.nudAantal.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
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
