using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reserveringssysteem
{
    class Reservering
    {
        //Datavelden
        private int reserveringsNummer;
        private string betaald;
        //

        //Properties
        public int ReserveringsNummer
        {
            get
            {
                return reserveringsNummer;
            }
        }

        public string Betaald
        {
            get
            {
                return betaald;
            }
        }
        //

        //Methodes
        public Reservering(int reserveringsNummer, string betaald)
        {
            this.reserveringsNummer = reserveringsNummer;
            this.betaald = betaald;
        }
        //

    }
}
