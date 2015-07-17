using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseKoppeling
{
    public class Student
    {
        private int nummer;
        private String naam;
        private int studiepunten;

        public Student(int nummer, String naam, int studiepunten)
        {
            this.nummer = nummer;
            this.naam = naam;
            this.studiepunten = studiepunten;
        }

        public int Nummer
        {
            get 
            {
                return nummer;
            }
        }

        public String Naam
        {
            get
            {
                return naam;
            }
        }

        public int Studiepunten
        {
            get
            {
                return studiepunten;
            }
        }

        public String toonInfo()
        {
            return nummer.ToString() + " - " + naam + " - " + studiepunten.ToString();
        }
    }
}
