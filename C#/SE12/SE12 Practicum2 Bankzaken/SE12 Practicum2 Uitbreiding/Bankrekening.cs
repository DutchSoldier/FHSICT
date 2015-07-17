using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE12_Practicum2_Bankzaken
{
    class Bankrekening
    {
        //datavelden 
        private int rekeningnummer;
        private string naam;
        private decimal saldo;
        private static int volgendeVrijeRekeningnummer = 2001;

        //properties 
        public int Rekeningnummer { get { return rekeningnummer; } }
        public string Naam { get { return naam; } }
        public decimal Saldo { get { return saldo; } }

        //constructors 
        public Bankrekening(string naam)
        {
            this.naam = naam;
            saldo = 0 + 0.0000M;
            //volgendeVrijeRekeningnummer is klassevariable, 
            //je kunt this niet gebruiken 
            rekeningnummer = volgendeVrijeRekeningnummer++;
        }

        public Bankrekening(string naam, decimal saldo)
        {
            //zelf invullen 
            this.naam = naam;
            this.saldo = saldo + 0.0000M;
            rekeningnummer = volgendeVrijeRekeningnummer++;
        } 

        //bedrag in hele centen 
        //negatieve getallen worden genegeerd. 
        public void NeemOp(decimal bedrag)
        {
            //zelf invullen 
            saldo = saldo - bedrag;
        }

        //bedrag in hele centen 
        //negatieve getallen worden genegeerd. 
        public void Stort(decimal bedrag)
        {
            //zelf invullen 
            saldo = saldo + bedrag;
        }

        public void MaakOverNaar(Bankrekening andereRekening, decimal bedrag)
        {
            //zelf invullen 
            NeemOp(bedrag);
            andereRekening.Stort(bedrag);
        }
    }
}
