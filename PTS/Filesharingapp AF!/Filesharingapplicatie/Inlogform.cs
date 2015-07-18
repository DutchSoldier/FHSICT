using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Filesharingapplicatie
{
    public partial class Inlogform : Form 
    {
        // data
        public string RFID;
        public type_gebruiker type;
        bool succes = false;

        // constructor
        public Inlogform()
        {
            InitializeComponent();
        }

        // methoden
        private void bt_accept_Click(object sender, EventArgs e)
        {
            RFID = tb_RFID.Text;

            try
            {
                string[] data = DatabaseKoppeling.inlogSeq(RFID);

                if (data[1] == null)
                {
                    MessageBox.Show("Het ingevoerde RFID-nummer is niet gevonden in de database.", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (data[0] != SHA1Hashing.MaakSHA1(tb_wachtwoord.Text))
                {
                    MessageBox.Show("Het ingevoerde wachtwoord is onjuist.", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (data[1] == "Medewerker")
                    {
                        type = type_gebruiker.Medewerker;
                    }
                    else
                    {
                        type = type_gebruiker.Klant;
                    }
                    succes = true;
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // kijkt in de database ofdat het ingevoerde RFID bestaat en ofdat het ingevoerde wachtwoord juist is en geeft toepasselijke berichten/waarschuwingen

        private void Inlogform_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!succes)
            {
                Application.Exit();
            }
        }   // indien de gebruiker niet succesvol is ingelogt dan word de applicatie afgesloten
    }
}
