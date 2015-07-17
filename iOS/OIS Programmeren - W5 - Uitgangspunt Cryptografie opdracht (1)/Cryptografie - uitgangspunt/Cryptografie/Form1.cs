using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cryptografie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Onderstaande methode "zetOm" zet een string met daarin één letter om naar de letter 13 plaatsen verder in het alfabet als dit een kleine letter is. 
        /// </summary>
        /// <param name="letter">De meegegeven letter is de letter die omgezet moet worden. Als niet precies één kleine letter wordt meegegeven dan wordt hierover een foutmelding getoond.</param
        /// <returns>Teruggegeven als resultaat wordt de omgezette variant van de kleine letter of, als de meegegeven letter geen kleine letter is het originele leesteken (alleen kleine letters worden veranderd)</returns>
        private String zetOm(String letter)
        {
            if (letter.Length < 1)
            {
                throw new Exception("De meegegeven String aan de zetOm methode is leeg, dus is er niets om te coderen! Als je zetOm gebruikt, geef dan een String mee met precies één letter.");
            }
            if (letter.Length > 1)
            {
                throw new Exception("De meegegeven String aan de zetOm methode is groter dan één letter, deze kunnen niet allemaal tegelijkertijd worden omgezet! Zorg dat je letter voor letter meegeeft bij de aanroep van zetOm.");
            }

            String opzoekLijstKleineletter = "abcdefghijklmnopqrstuvwxyz";
            String vervangLijstKleineletter = "nopqrstuvwxyzabcdefghijklm";

            //Kijk of het om een kleine letter gaat ...
            if (opzoekLijstKleineletter.IndexOf(letter) > -1)
            {
                //... zo ja: vervang de kleinletter met een andere kleineletter
                int index = opzoekLijstKleineletter.IndexOf(letter);
                return vervangLijstKleineletter.Substring(index, 1);
            }
            else
            {
                //... zo nee: geef dan het oorspronkelijke leesteken terug.
                return letter;
            }
        }

        private void codeerDecodeerKnop_Click(object sender, EventArgs e)
        {
            String normaleTekst = normaleTekstTextBox.Text;
            String omgezetteTekst = "";

            
            //Zet hier de programmacode neer waarmee je één voor één de letters uit 'normaleTekst' omzet.
            

            omgezetteTekstTextBox.Text = omgezetteTekst;
        }
    }
}
