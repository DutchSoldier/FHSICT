//Klant

namespace Reserveringssysteem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Klant : Persoon
    {
        //Datavelden
        private int reserveringsnummer;

        //Methodes
        /// <summary>
        /// Deze constructor wordt gebruikt voor het wegschrijven van klanten.
        /// </summary>
        /// <param name="rfid"></param>
        /// <param name="reserveringsnummer"></param>
        public Klant(string rfid, int reserveringsnummer)
            : base(rfid, "Klant")
        {
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
    }
}
