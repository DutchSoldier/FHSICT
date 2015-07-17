using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE12_Practicum2_Bankzaken
{
    class Bankrekening
    {
        //datavelden 
        private int rekeningnummer;
        private string naam;
        //private int saldo;
        private decimal saldo;
        private static int volgendeVrijeRekeningnummer = 2001;

        //properties 
        public int Rekeningnummer { get { return rekeningnummer; } }
        public string Naam { get { return naam; } }
        //public int Saldo { get { return saldo; } }
        public decimal Saldo { get { return saldo; } }

        //constructors 
        public Bankrekening(string naam)
        {
            this.naam = naam;
            saldo = 0;
            //volgendeVrijeRekeningnummer is klassevariable, 
            //je kunt this niet gebruiken 
            rekeningnummer = volgendeVrijeRekeningnummer++;
        }

        public Bankrekening(string naam, int saldo)
        {
            //zelf invullen 
            this.naam = naam;
            this.saldo = saldo;
            rekeningnummer = volgendeVrijeRekeningnummer++;
        } 

        //bedrag in hele centen 
        //negatieve getallen worden genegeerd. 
        public void NeemOp(int bedrag)
        {
            //zelf invullen 
            saldo = saldo - bedrag;
        }

        //bedrag in hele centen 
        //negatieve getallen worden genegeerd. 
        public void Stort(int bedrag)
        {
            //zelf invullen 
            saldo = saldo + bedrag;
        }

        public void MaakOverNaar(Bankrekening andereRekening, int bedrag)
        {
            //zelf invullen 
            NeemOp(bedrag);
            andereRekening.Stort(bedrag);
        }
    }
}
