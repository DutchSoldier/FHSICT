//Materiaal

namespace MateriaalVerhuurApplicatie
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Materiaal
    {
        //Datavelden
        private string type;
        private int prijs;
        private int aantal;

        //Constructor
        public Materiaal(string type, int prijs, int aantal)
        {
            this.type = type;
            this.prijs = prijs;
            this.aantal = aantal;
        }

        //Properties
        public int Aantal
        {
            get
            {
                return this.aantal;
            }
        }

        public int Prijs
        {
            get
            {
                return this.prijs;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
