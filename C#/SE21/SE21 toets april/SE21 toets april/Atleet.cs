using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_toets_april
{
    class Atleet
    {
        string Naam;
        int Leeftijd;

        new List<Blessure> blessure = new List<Blessure>();
        new List<Schoen> schoen = new List<Schoen>();
        new List<Training> training = new List<Training>();
        
        public void VoegZwemTrainingToe(ZwemTraining zwemtraining)
        {
            zwemtraining = new ZwemTraining();
        }

        public void VoegHardloopTrainingToe(HardloopTraining hardlooptraining)
        {
            hardlooptraining = new HardloopTraining();
        }

        public void VoegBlessureToe(Blessure blessure)
        {
            blessure = new Blessure();
        }
        
        public void VoegSchoenToe(Schoen schoen)
        {
            schoen = new Schoen();
        }
       
        public void VoegParcoursToe(Parcours parcours)
        {
            parcours = new Parcours();
        }

        //public void SorteerTrainingenOpDatum()
        //{
        //    training.Sort();
        //}

        //public void SorteerOpIntensiteitEnTijdsduur()
        //{
        //    training.Sort();
        //}

    }
}
