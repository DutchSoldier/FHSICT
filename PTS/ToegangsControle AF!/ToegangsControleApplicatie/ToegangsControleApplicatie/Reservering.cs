using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToegangsControleApplicatie
{
    class Reservering
    {
        //Datavelden
        private string naam;
        private string rfid;
        private string gereserveerdePlaatsen;
        private bool betalingVoltooid;
        private int bedrag;
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

        public string Naam
        {
            get
            {
                return naam;
            }
        }

        public string Rfid
        {
            get
            {
                return rfid;
            }
        }

        public string GereserveerdePlaatsen
        {
            get
            {
                return gereserveerdePlaatsen;
            }
        }

        public bool BetalingVoltooid
        {
            get
            {
                return betalingVoltooid;
            }

            set
            {
                betalingVoltooid = value;
            }
        }

        public int Bedrag
        {
            get
            {
                return bedrag;
            }
        }
        //

        //Methodes
        public Reservering(string naam, string rfid, string gereserveerdePlaatsen, bool betalingVoltooid, int bedrag, int reserveringsnummer)
        {
            this.reserveringsnummer = reserveringsnummer;
            this.naam = naam;
            this.rfid = rfid;
            this.gereserveerdePlaatsen = gereserveerdePlaatsen;
            this.betalingVoltooid = betalingVoltooid;
            this.bedrag = bedrag;
        }
        //
    }
}
