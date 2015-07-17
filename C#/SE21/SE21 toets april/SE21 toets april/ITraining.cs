using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE21_toets_april
{
    interface ITraining
    {
        List<int> Gettrainingen();

        DateTime tijdstip();
        int tijdsduur();
        int intensiteit();
        string omschrijving();
    }
}
