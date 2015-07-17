using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{


    public class Rekening
    {
        private float saldo;
        private float kredietlimiet;

        public Rekening()
        {
            saldo = 0;

        }

        public void Stort(float bedrag)
        {
        }

        public bool NeemOp(float bedrag)
        {
            return false;
        }

        public bool SchrijfOver(Rekening bestemming, float bedrag)
        {
            return false;
        }

        public float Saldo
        {
            get { return saldo; }
        }

        public float Kredietlimiet
        {
            get { return kredietlimiet; }
        }
    }

}
