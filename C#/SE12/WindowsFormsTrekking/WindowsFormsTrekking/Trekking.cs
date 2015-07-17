using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsTrekking
{
    class Trekking
    {

        //attributes
        private Random random;
        private int[] getallen;

        //properties
        public int Maxwaarde { get; private set; } //maximum waarde van te trekken getal
        public int AantalGetrokken { get; private set; } //aantal getrokken getallen
        public int AantalGewenst { get; private set; } //aantal te trekken getallen
        public bool IsTenEinde { get; private set; } //true als alle getallen getrokken

        public Trekking(int Maxwaarde, int AantalGewenst)
        {
            //vul  hier zelf de initialisatie in van: 
            //    MaxWaarde max 90 en 2* zo groot als AantalGewenst, AantalGewenst max45, AantalGetrokken en IsTenEinde
            this.Maxwaarde = Maxwaarde;
            this.AantalGewenst = AantalGewenst;
            this.AantalGetrokken = 0;
            IsTenEinde = false;
            random = new Random();
            getallen = new int[Maxwaarde];
        }

        //methodse
        
        public void TrekGetal()
        {
            //Vul de method zelf in
            if (AantalGetrokken < AantalGewenst)
            {
                getallen[AantalGetrokken] = random.Next (1, Maxwaarde);

                while (InArray(getallen[AantalGetrokken]))
                {
                getallen[AantalGetrokken] = random.Next(1, Maxwaarde);
                }
                AantalGetrokken++;
            }
        }
        
        //number is the number of the figure drawn (1..Max)
        
        public int GeefGetal(int number)
        {
          
            return getallen[number];
        }
        
        //sorteert getrokken getallen in array "getallen"
        
        public void Sort()
        {
            //Vul deze methode in
           
            for (int i = 0; i < AantalGewenst; i++)
            {
                for (int y = 0; y < AantalGewenst - i; y++)
                {

                    if (getallen[y] > getallen[AantalGewenst - 1 - i])
                    {
                        int getal = getallen[AantalGewenst - 1 - i];
                        getallen[AantalGewenst - 1 - i] = getallen[y];
                        getallen[y] = getal;
                    }
                }
            }

        }

        private bool InArray(int getal)
        {
            //Vul de method in
            for (int i = 0; i < AantalGetrokken; i++)
            {
                if (getallen[i] == getal)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
