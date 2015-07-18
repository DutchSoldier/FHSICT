//Betalende Klant

namespace Reserveringssysteem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BetalendeKlant : Persoon
    {
        //Datavelden
        private int reserveringsnummer;
        private string postcode;
        private string rekeningnummer;
        private string straat;
        private string woonplaats;
        private string telefoon;
        private string email;
        private string sofi;
        private string naam;

        //Methodes
        /// <summary>
        /// Deze constructor is voor het updaten van een betalende klant.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="sofi"></param>
        /// <param name="email"></param>
        /// <param name="telefoon"></param>
        /// <param name="woonplaats"></param>
        /// <param name="straat"></param>
        /// <param name="rekeningnummer"></param>
        /// <param name="postcode"></param>
        /// <param name="reserveringsnummer"></param>
        public BetalendeKlant(string naam, string sofi, string email, string telefoon, string woonplaats, string straat, string rekeningnummer, string postcode, int reserveringsnummer)
        :base ("Klant_betalend")
        {
            this.naam = naam;
            this.sofi = sofi;
            this.email = email;
            this.telefoon = telefoon;
            this.woonplaats = woonplaats;
            this.straat = straat;
            this.rekeningnummer = rekeningnummer;
            this.postcode = postcode;
            this.reserveringsnummer = reserveringsnummer;
        }

        /// <summary>
        /// Deze constructor is voor het toevoegen en ophalen van een betalende klant.
        /// </summary>
        /// <param name="rfid"></param>
        /// <param name="naam"></param>
        /// <param name="sofi"></param>
        /// <param name="email"></param>
        /// <param name="telefoon"></param>
        /// <param name="woonplaats"></param>
        /// <param name="straat"></param>
        /// <param name="rekeningnummer"></param>
        /// <param name="postcode"></param>
        /// <param name="reserveringsnummer"></param>
        public BetalendeKlant(string rfid, string naam, string sofi, string email, string telefoon, string woonplaats, string straat, string rekeningnummer, string postcode, int reserveringsnummer)
            : base(rfid, "Klant_betalend")
        {
            this.naam = naam;
            this.sofi = sofi;
            this.email = email;
            this.telefoon = telefoon;
            this.woonplaats = woonplaats;
            this.straat = straat;
            this.rekeningnummer = rekeningnummer;
            this.postcode = postcode;
            this.reserveringsnummer = reserveringsnummer;
        }

        //Properties
        public int Reserveringsnummer
        {
            get
            {
                return this.reserveringsnummer;
            }
        }

        public string Postcode
        {
            get
            {
                return this.postcode;
            }
        }

        public string Rekeningnummer
        {
            get
            {
                return this.rekeningnummer;
            }
        }

        public string Straat
        {
            get
            {
                return this.straat;
            }
        }

        public string Woonplaats
        {
            get
            {
                return this.woonplaats;
            }
        }

        public string Telefoon
        {
            get
            {
                return this.telefoon;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
        }

        public string Sofi
        {
            get
            {
                return this.sofi;
            }
        }

        public string Naam
        {
            get
            {
                return this.naam;
            }
        }
    }
}
