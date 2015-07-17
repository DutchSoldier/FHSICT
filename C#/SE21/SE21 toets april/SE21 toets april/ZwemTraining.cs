using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_toets_april
{
    class ZwemTraining : Training
    {
        string zwemInfo;
        string Slag;
        bool Indoor;
        int AantalMeter;

        public string ToString(Training zwemtraining)
        {
            zwemInfo = "Aantal slagen: " + Slag + " , Aantal meters: " + AantalMeter + " , Indoor: " + Indoor;
            return zwemInfo;
        }

    }
}
