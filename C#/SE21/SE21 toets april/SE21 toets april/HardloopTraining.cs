using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_toets_april
{
    class HardloopTraining : Training
    {
        string hardloopInfo;
        new List<Parcours> parcours = new List<Parcours>();
        string WeerType;


        public string ToString(Training hardlooptraining)
        {
            hardloopInfo = "Weertype: " + WeerType + "Parcours: " + parcours;
            return hardloopInfo;
        }

    }
}
