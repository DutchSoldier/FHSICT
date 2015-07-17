using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_toets_april
{
    class Schoen
    {
        
        string schoeninfo;
        int AantalKm;
        bool InGebruik;
        string MerkEnType;

        public string ToString(Atleet schoen)
        {
            schoeninfo = "Aantal Kilometers: " + AantalKm + " , In Gebruik: " + InGebruik + " , Merk en Type: " + MerkEnType;
            return schoeninfo;
        }

        public void GelopenKM(int gelopenKm)
        {
            AantalKm = AantalKm + gelopenKm;
        }
    }
}
