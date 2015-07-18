using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MateriaalVerhuurApplicatie
{
    class Materiaal
    {
        //Datavelden
        private string type;
        private int prijs;
        private int aantal;
        //

        //Properties
        public int Aantal
        {
            get
            {
                return aantal;
            }
        }

        public int Prijs
        {
            get
            {
                return prijs;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
        }
        //

        //Constructor
        public Materiaal(string type, int prijs, int aantal)
        {
            this.type = type;
            this.prijs = prijs;
            this.aantal = aantal;
        }
        //
    }
}
