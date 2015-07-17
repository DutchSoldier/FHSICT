using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_bankrekening
{
    class Gewonerekening : Bankrekening
    {
        public Gewonerekening(string naam, int nummer)
        {
            naam = Naam;
            nummer = Nummer;
            saldo = 0;
        }

        public void maakOver()
        { 
        
        }

        public void NeemOp()
        {

        }
    }
}
