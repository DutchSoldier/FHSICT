//Reservering

namespace Reserveringssysteem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Reservering
    {
        //Datavelden
        private int reserveringsNummer;
        private string betaald;

        //Constructor
        public Reservering(int reserveringsNummer, string betaald)
        {
            this.reserveringsNummer = reserveringsNummer;
            this.betaald = betaald;
        }

        //Properties
        public int ReserveringsNummer
        {
            get
            {
                return this.reserveringsNummer;
            }
        }

        public string Betaald
        {
            get
            {
                return this.betaald;
            }
        }
    }
}
