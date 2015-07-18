using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MateriaalVerhuurApplicatie
{
    class Uitlening
    {
        //Datavelden
        private string type;
        private int reserveringsnummer;
        private DateTime datum_ingeleverd;
        private DateTime datum_uitgeleend;
        private int aantal;
        //

        //Properties
        public string Type
        {
            get
            {
                return type;
            }
        }

        public int Reserveringsnummer
        {
            get
            {
                return reserveringsnummer;
            }
        }

        public DateTime Datum_ingeleverd
        {
            get
            {
                return datum_ingeleverd;
            }
        }

        public DateTime Datum_uitgeleend
        {
            get
            {
                return datum_uitgeleend;
            }
        }

        public int Aantal
        {
            get
            {
                return aantal;
            }
        }

        //

        //Constructor
        public Uitlening(string type, int reserveringsnummer, DateTime datum_ingeleverd, DateTime datum_uitgeleend, int aantal)
        {
            this.type = type;
            this.reserveringsnummer = reserveringsnummer;
            this.datum_ingeleverd = datum_ingeleverd;
            this.datum_uitgeleend = datum_uitgeleend;
            this.aantal = aantal;
        }
        //
    }
}
