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
    public partial class MenuForm : Form
    {
        private int reserveringsNummer;
        ToolTip tooltip = new ToolTip();

        public MenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Deze knop start een instantie van NieuweReserveringForm en als deze succesvol is doorlopen 
        /// (er is een reserveringsnummer aangemaakt) wordt de Form ReserveringForm geopend, 
        /// als deze weer gesloten wordt wordt de lijst met reserveringen geupdate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNieuw_Click(object sender, EventArgs e)
        {
            NieuweReserveringForm NieuweReserveringForm = new NieuweReserveringForm();
            NieuweReserveringForm.ShowDialog();
            reserveringsNummer = NieuweReserveringForm.ReserveringsNummer;

            if (reserveringsNummer != 0 && NieuweReserveringForm.Gelukt != false)
            {
                ReserveringForm ReserveringForm = new ReserveringForm(reserveringsNummer, true);
                ReserveringForm.ShowDialog();
                LoadReserveringen();
            }
        }

        /// <summary>
        /// Hiermee wordt de lijst met gemaakte reserveringen gevult. De gegevens worden 
        /// opgehaalt uit de Database en opgeslagen in een list met ReserveringView objecten.
        /// </summary>
        private void LoadReserveringen()
        {
            listViewReserveringen.Items.Clear();
            try
            {
                List<ReserveringView> reserveringen = DatabaseKoppeling.GetReserveringen();
                foreach (ReserveringView rv in reserveringen)
                {
                    ListViewItem tempItem = new ListViewItem(rv.Reserveringsnummer.ToString(), 0);
                    tempItem.Name = rv.Reserveringsnummer.ToString();
                    tempItem.SubItems.Add(rv.Naam).Name = rv.Naam;
                    tempItem.SubItems.Add(rv.Personen.ToString()).Name = rv.Personen.ToString();

                    listViewReserveringen.Items.Add(tempItem);
                }
            }
            catch (Oracle.DataAccess.Client.OracleException)
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnVervers_Click(object sender, EventArgs e)
        {
            LoadReserveringen();
        }

        /// <summary>
        /// Deze knop opend een instantie van ReserveringForm in wijzig modes en 
        /// herlaad de lijst met reserveringen als de wijzing voltooid is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWijzig_Click(object sender, EventArgs e)
        {
            try
            {
                ReserveringForm ReserveringForm = new ReserveringForm(Convert.ToInt32(listViewReserveringen.FocusedItem.Name), false);
                ReserveringForm.ShowDialog();
                LoadReserveringen();
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
        private void btnAnnuleer_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Wilt u reservering " + listViewReserveringen.FocusedItem.Name + " annuleren?", "Annuleren bevestigen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DatabaseKoppeling.RemoveReservering(Convert.ToInt32(listViewReserveringen.FocusedItem.Name));
                    LoadReserveringen();
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
                LoadReserveringen();
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
            LoadReserveringen();
            btnNieuw.HelpRequested += new HelpEventHandler(View_HelpRequested);
            btnWijzig.HelpRequested += new HelpEventHandler(View_HelpRequested);
            btnAnnuleer.HelpRequested += new HelpEventHandler(View_HelpRequested);
            btnVervers.HelpRequested += new HelpEventHandler(View_HelpRequested);
            listViewReserveringen.HelpRequested += new HelpEventHandler(View_HelpRequested);
            txtZoekString.HelpRequested += new HelpEventHandler(View_HelpRequested);
        }

        /// <summary>
        /// Deze functie zorgt ervoor dat de Help eventhandler een tooltip met informatie weergeeft.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_HelpRequested(object sender, HelpEventArgs e)
        {
            Control requestingControl = (Control)sender;
            tooltip.ToolTipIcon = ToolTipIcon.Info;
            tooltip.ToolTipTitle = requestingControl.Text;
            tooltip.UseAnimation = true;
            tooltip.Show(requestingControl.Tag.ToString(), requestingControl, 5000);
            e.Handled = true;
        }

        /// <summary>
        /// Hiermee worden de zoekresultaten voor de zoekwoorden gegenereerd en weergegeven.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtZoekString_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem foundItem = listViewReserveringen.FindItemWithText(txtZoekString.Text, true, 0, true);
                if (foundItem != null)
                {
                    listViewReserveringen.Items.Remove(foundItem);
                    listViewReserveringen.Items.Insert(0, foundItem);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                listViewReserveringen.Items.Add("").SubItems.Add("Geen resultaten...");
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
        private void txtZoekString_Enter(object sender, EventArgs e)
        {
            string defaultText = "Zoek...";

            if (txtZoekString.Text == defaultText)
            {
                txtZoekString.ForeColor = Color.Black;
                txtZoekString.Text = "";
            }
        }

        /// <summary>
        /// Als de zoekbox wordt verlaten wordt de default tekst "Zoek..." weer teruggezet 
        /// en de kleur van de tekst grijs gemaakt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtZoekString_Leave(object sender, EventArgs e)
        {
            string defaultText = "Zoek...";
            txtZoekString.ForeColor = Color.Gray;
            txtZoekString.Text = defaultText;
        }
    }
}
