using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_bankrekening
{
    interface IBankrekening
    {
  
        //properties 
        int Nummer { get; }
        string Naam {get;}
        double Saldo {get;}

        
        bool NeemOp(double bedrag);
        void Stort(double bedrag);
    }
}
