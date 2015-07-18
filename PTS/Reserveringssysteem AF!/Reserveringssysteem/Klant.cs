using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reserveringssysteem
{
    class Klant : Persoon
    {
        //Datavelden
        private int reserveringsnummer;
        //

        //Properties
        public int Reserveringsnummer
        {
            get
            {
                return reserveringsnummer;
            }
        }
        //

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
        //
    }
}
