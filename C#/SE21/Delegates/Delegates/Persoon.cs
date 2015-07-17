using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    class Persoon
    {
        private string Voornaam;
        private string Tussenvoegsel;
        private string Achternaam;
        private string Doopnamen;

        public Persoon(string voornaam, string tussenvoegsel, string achternaam, string doopnamen)
        {
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            Doopnamen = doopnamen;
        }

        public string GetNaam1()
        {
            return Voornaam + " " + Tussenvoegsel + " " + Achternaam;
        }

        public string GetNaam2()
        {
            return Achternaam + ", " + Voornaam + " " + Tussenvoegsel;
        }

        public string GetNaam3()
        {
            return Achternaam + " " + Tussenvoegsel + "; " + Doopnamen;
        }
    }
}
