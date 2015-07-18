//Menu Form
/*
   DialogResult dialogResult;
                dialogResult = MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                {
                    Application.Exit();
                }
 */
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

    public partial class MenuForm : Form
    {
        private int reserveringsNummer;
        private ToolTip tooltip = new ToolTip();

        public MenuForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Deze knop start een instantie van NieuweReserveringForm en als deze succesvol is doorlopen 
        /// (er is een reserveringsnummer aangemaakt) wordt de Form ReserveringForm geopend, 
        /// als deze weer gesloten wordt wordt de lijst met reserveringen geupdate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNieuw_Click(object sender, EventArgs e)
        {
            NieuweReserveringForm nieuweReserveringForm = new NieuweReserveringForm();
            nieuweReserveringForm.ShowDialog();
            this.reserveringsNummer = nieuweReserveringForm.ReserveringsNummer;

            if (this.reserveringsNummer != 0 && nieuweReserveringForm.Gelukt != false)
            {
                ReserveringForm reserveringForm = new ReserveringForm(this.reserveringsNummer, true);
                reserveringForm.ShowDialog();
                this.LoadReserveringen();
            }
        }

        /// <summary>
        /// Hiermee wordt de lijst met gemaakte reserveringen gevult. De gegevens worden 
        /// opgehaalt uit de Database en opgeslagen in een list met ReserveringView objecten.
        /// </summary>
        private void LoadReserveringen()
        {
            this.listViewReserveringen.Items.Clear();
            try
            {
                List<ReserveringView> reserveringen = DatabaseKoppeling.GetReserveringen();
                foreach (ReserveringView rv in reserveringen)
                {
                    ListViewItem tempItem = new ListViewItem(rv.Reserveringsnummer.ToString(), 0);
                    tempItem.Name = rv.Reserveringsnummer.ToString();
                    tempItem.SubItems.Add(rv.Naam).Name = rv.Naam;
                    tempItem.SubItems.Add(rv.Personen.ToString()).Name = rv.Personen.ToString();

                    this.listViewReserveringen.Items.Add(tempItem);
                }
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Deze knop herlaad de lijst met reserveringen handmatig, zodat wijzigingen 
        /// die in een andere instantie van dit programma zijn gemaakt ook zichtbaar worden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnVervers_Click(object sender, EventArgs e)
        {
            this.LoadReserveringen();
        }

        /// <summary>
        /// Deze knop opend een instantie van ReserveringForm in wijzig modes en 
        /// herlaad de lijst met reserveringen als de wijzing voltooid is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWijzig_Click(object sender, EventArgs e)
        {
            try
            {
                ReserveringForm reserveringForm = new ReserveringForm(Convert.ToInt32(this.listViewReserveringen.FocusedItem.Name), false);
                reserveringForm.ShowDialog();
                this.LoadReserveringen();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Selecteer eerst een reservering!", "Melding", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Deze knop verwijderd/Annuleert een reservering uit het systeem/Database. 
        /// De lijst met reserveringen wordt geherladen na de verwijdering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAnnuleer_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Wilt u reservering " + this.listViewReserveringen.FocusedItem.Name + " annuleren?", "Annuleren bevestigen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DatabaseKoppeling.RemoveReservering(Convert.ToInt32(this.listViewReserveringen.FocusedItem.Name));
                    this.LoadReserveringen();
                }
            }
            catch (Oracle.DataAccess.Client.OracleException)
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Selecteer eerst een reservering!", "Melding", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.LoadReserveringen();
            }
        }

        /// <summary>
        /// Hiermee wordt de lijst met reserveringen ingevult bij het opstarten van de applicatie. 
        /// En de help eventhandlers ingesteld.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuForm_Load(object sender, EventArgs e)
        {
            this.LoadReserveringen();
            this.btnNieuw.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.btnWijzig.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.btnAnnuleer.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.btnVervers.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.listViewReserveringen.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
            this.txtZoekString.HelpRequested += new HelpEventHandler(this.View_HelpRequested);
        }

        /// <summary>
        /// Deze functie zorgt ervoor dat de Help eventhandler een tooltip met informatie weergeeft.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_HelpRequested(object sender, HelpEventArgs e)
        {
            Control requestingControl = (Control)sender;
            this.tooltip.ToolTipIcon = ToolTipIcon.Info;
            this.tooltip.ToolTipTitle = requestingControl.Text;
            this.tooltip.UseAnimation = true;
            this.tooltip.Show(requestingControl.Tag.ToString(), requestingControl, 5000);
            e.Handled = true;
        }

        /// <summary>
        /// Hiermee worden de zoekresultaten voor de zoekwoorden gegenereerd en weergegeven.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtZoekString_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem foundItem = this.listViewReserveringen.FindItemWithText(this.txtZoekString.Text, true, 0, true);
                if (foundItem != null)
                {
                    this.listViewReserveringen.Items.Remove(foundItem);
                    this.listViewReserveringen.Items.Insert(0, foundItem);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.listViewReserveringen.Items.Add(string.Empty).SubItems.Add("Geen resultaten...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Haalt de default tekst "Zoek..." weg uit de zoekbox 
        /// en zet de kleur weer op zwart.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtZoekString_Enter(object sender, EventArgs e)
        {
            string defaultText = "Zoek...";

            if (this.txtZoekString.Text == defaultText)
            {
                this.txtZoekString.ForeColor = Color.Black;
                this.txtZoekString.Text = string.Empty;
            }
        }

        /// <summary>
        /// Als de zoekbox wordt verlaten wordt de default tekst "Zoek..." weer teruggezet 
        /// en de kleur van de tekst grijs gemaakt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtZoekString_Leave(object sender, EventArgs e)
        {
            string defaultText = "Zoek...";
            this.txtZoekString.ForeColor = Color.Gray;
            this.txtZoekString.Text = defaultText;
        }
    }
}
