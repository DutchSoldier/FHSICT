using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_toets_april
{
    abstract class Training : ITraining
    {
        public List<int> Gettrainingen = new List<int>();
        string trainingInfo;
        public DateTime tijdstip { get; set; }
        public int tijdsduur { get; set; }
        public int intensiteit { get; set; }
        public string omschrijving { get; set; }
        private int[] getallen;

        public string ToString(Training training)
        { 
            trainingInfo = "Tijdstip: " + tijdstip + " , Tijdsduur: " + tijdsduur + " , Intensiteit: " + intensiteit + " , Omschrijving: " + omschrijving;
            return trainingInfo;
        }

        //public void Sort()
        //{
        //    for (int i = 0; i < intensiteit; i++)
        //    {
        //        for (int y = 0; y < intensiteit - i; y++)
        //        {

        //            if (getallen[y] > getallen[intensiteit - 1 - i])
        //            {
        //                int getal = getallen[intensiteit - 1 - i];
        //                getallen[intensiteit - 1 - i] = getallen[y];
        //                getallen[y] = getal;
        //            }
        //        }
        //    }
        //}
    }
}
