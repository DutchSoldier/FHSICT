using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_bankrekening
{
    class Spaarrekening : Bankrekening
    {
        private double opgenomen;
        private double rente;
        private const double BOETEPERC = 5; //5% boete over het bedrag dat je meer leent dan 10.000
        private const double MAXOPNAME = 10000; //10.000 euro per jaar
        private const double RENTEPERC = 5; //5% per jaar dus 5/12 % pe maand


        public void eindeJaar()
        { 
            
        }

        public void eindeMaand()
        { 
            
        }

        public override bool NeemOp(double bedrag)
        {
            base.NeemOp(bedrag);
            
            if (opgenomen > MAXOPNAME)
            {
                
                    bedrag = opgenomen - MAXOPNAME * ((BOETEPERC+100)/100);
                
                if (saldo < bedrag)
                {
                    return true;
                }
                
            }
            else if (opgenomen < MAXOPNAME)
            { 
                if(opgenomen + bedrag > MAXOPNAME)
                {
                    double boetebedrag = opgenomen - MAXOPNAME * (BOETEPERC/100);
                    saldo = saldo - (bedrag + boetebedrag);
                    if (bedrag < saldo)
                    {
                        return true;
                    }
                }
                else
                {
                    saldo = saldo - bedrag;
                    if (bedrag < saldo)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Spaarrekening(string naam, int nummer)
        {
            nummer = Nummer;
            naam = Naam;
            saldo = 0;
        }
    }
}
