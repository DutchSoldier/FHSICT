using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_bankrekening
{
    abstract class Bankrekening : IBankrekening
    {
        //datavelden 
        private int nummer;
        private string naam;
        protected double saldo;
        

        //properties 
        public int Nummer { get { return nummer; } }
        public string Naam { get { return naam; } }
        public double Saldo { get { return saldo; } }

        public Bankrekening(string naam, int nummer)
        {
            nummer = Nummer;
            naam = Naam;
            saldo = 0;
        }

        public virtual bool NeemOp(double bedrag)
        {
            if (bedrag < saldo)
            {
                saldo = saldo - bedrag;
                return true;
            }
        }

        public void Stort(double bedrag)
        {
            saldo = saldo + bedrag;
        }
    }
}
