//Persoon

namespace Reserveringssysteem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Persoon
    {
        //Datavelden
        private string rfid;
        private string wachtwoord;
        private string type;

        //Constructor
        /// <summary>
        /// Deze constructor is voor het updaten van klanten.
        /// </summary>
        /// <param name="type">Geeft aan in welke tabel de overige gevens van de klant/medewerker te vinden zijn. 
        /// Restrictie: Klant, Klant_betalend of Medewerker.</param>
        public Persoon(string type)
        {
            this.type = type;
        }

        /// <summary>
        /// Deze constructor is voor het ophalen en toevoegen van klanten.
        /// </summary>
        /// <param name="rfid"></param>
        /// <param name="type">Geeft aan in welke tabel de overige gevens van de klant/medewerker te vinden zijn. 
        /// Restrictie: Klant, Klant_betalend of Medewerker.</param>
        public Persoon(string rfid, string type)
        {
            this.rfid = rfid;
            this.wachtwoord = this.MaakWachtwoord(rfid);
            this.type = type;
        }

        //Properties
        public string Rfid
        {
            get
            {
                return this.rfid;
            }
        }

        public string Wachtwoord
        {
            get
            {
                return this.wachtwoord;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
        }

        //Methodes

        private string MaakWachtwoord(string rfid)
        {
            string ww = null;

            for (int i = 0; i < Math.Abs(rfid.GetHashCode()).ToString().Length; i++)
            {
                char bekent = Math.Abs(rfid.GetHashCode()).ToString()[i];
                char temp;
                if (bekent == '1' || bekent == '8' || bekent == '6' || bekent == '2' || bekent == '0')
                {
                    temp = Convert.ToChar(65 + bekent);
                }
                else
                {
                    temp = bekent;
                }
                ww += temp;
            }

            return ww.ToUpper();
        }
    }
}
