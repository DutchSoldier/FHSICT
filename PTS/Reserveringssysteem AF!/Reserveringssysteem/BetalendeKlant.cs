using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reserveringssysteem
{
    class BetalendeKlant : Persoon
    {
        //Datavelden
        private int reserveringsnummer;
        private string postcode;
        private string rekeningnummer;
        private string straat;
        private string woonplaats;
        private string telefoon;
        private string email;
        private string rijbewijsnummer;
        private string naam;
        //

        //Properties
        public int Reserveringsnummer
        {
            get
            {
                return reserveringsnummer;
            }
        }

        public string Postcode
        {
            get
            {
                return postcode;
            }
        }

        public string Rekeningnummer
        {
            get
            {
                return rekeningnummer;
            }
        }

        public string Straat
        {
            get
            {
                return straat;
            }
        }

        public string Woonplaats
        {
            get
            {
                return woonplaats;
            }
        }

        public string Telefoon
        {
            get
            {
                return telefoon;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
        }

        public string Rijbewijsnummer
        {
            get
            {
                return rijbewijsnummer;
            }
        }

        public string Naam
        {
            get
            {
                return naam;
            }
        }
        //

        //Methodes
        /// <summary>
        /// Deze constructor is voor het updaten van een betalende klant.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="rijbewijsnummer"></param>
        /// <param name="email"></param>
        /// <param name="telefoon"></param>
        /// <param name="woonplaats"></param>
        /// <param name="straat"></param>
        /// <param name="rekeningnummer"></param>
        /// <param name="postcode"></param>
        /// <param name="reserveringsnummer"></param>
        public BetalendeKlant(string naam, string rijbewijsnummer, string email, string telefoon, string woonplaats, string straat, string rekeningnummer, string postcode, int reserveringsnummer)
        :base ("Klant_betalend")
        {
            this.naam = naam;
            this.rijbewijsnummer = rijbewijsnummer;
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
        /// <param name="rijbewijsnummer"></param>
        /// <param name="email"></param>
        /// <param name="telefoon"></param>
        /// <param name="woonplaats"></param>
        /// <param name="straat"></param>
        /// <param name="rekeningnummer"></param>
        /// <param name="postcode"></param>
        /// <param name="reserveringsnummer"></param>
        public BetalendeKlant(string rfid, string naam, string rijbewijsnummer, string email, string telefoon, string woonplaats, string straat, string rekeningnummer, string postcode, int reserveringsnummer)
            : base(rfid, "Klant_betalend")
        {
            this.naam = naam;
            this.rijbewijsnummer = rijbewijsnummer;
            this.email = email;
            this.telefoon = telefoon;
            this.woonplaats = woonplaats;
            this.straat = straat;
            this.rekeningnummer = rekeningnummer;
            this.postcode = postcode;
            this.reserveringsnummer = reserveringsnummer;
        }
        //
    }
}
