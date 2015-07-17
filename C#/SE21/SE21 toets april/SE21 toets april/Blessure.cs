using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_toets_april
{
    class Blessure
    {
        string blessureinfo;
        string Omschrijving;
        string Lichaamsdeel;
        DateTime Datum;

        public string ToString(Atleet blessure)
        {
            blessureinfo = "Omschrijving: " + Omschrijving + " , Lichaamsdeel: " + Lichaamsdeel;
            return blessureinfo;
        }
    }
}
