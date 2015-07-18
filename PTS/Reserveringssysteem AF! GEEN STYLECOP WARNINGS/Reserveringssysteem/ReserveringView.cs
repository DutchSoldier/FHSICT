//Reservering View

namespace Reserveringssysteem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ReserveringView
    {
        //Datavelden
        private int reserveringsnummer;
        private string naam;
        private int personen;

        //Constructor
        /// <summary>
        /// Deze constructor wordt gebruikt voor het weergeven van informatie voor een reservering in MenuForm.
        /// Dit zit in een aparte classe omdat hier extra informatie bij staat waar een aparte query voor nodig is.
        /// </summary>
        /// <param name="reserveringsnummer"></param>
        /// <param name="naam"></param>
        /// <param name="personen"></param>
        public ReserveringView(int reserveringsnummer, string naam, int personen)
        {
            this.reserveringsnummer = reserveringsnummer;
            this.naam = naam;
            this.personen = personen;
        }

        //Poperties
        public int Reserveringsnummer
        {
            get
            {
                return this.reserveringsnummer;
            }
        }

        public string Naam
        {
            get
            {
                return this.naam;
            }
        }

        public int Personen
        {
            get
            {
                return this.personen;
            }
        }
    }
}
