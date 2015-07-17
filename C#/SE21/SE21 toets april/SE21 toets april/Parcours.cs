using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_toets_april
{
    class Parcours
    {
        // image kaart;
        string info;
        string Beschrijving;
        int SnelsteTijdMinuten;
        int AfstandKM;
        int MaxHoogteverschil;
        bool Verhard;

        public string ToString()
        {
            info = "Beschrijving: " + Beschrijving + " , Snelste tijd in minuten: " + SnelsteTijdMinuten + " , Afstand in Kilometers: " + AfstandKM + " , Maximale hoogte verschil: " + MaxHoogteverschil + " , Verhard: " + Verhard;
            return info;
        }
    }
}
