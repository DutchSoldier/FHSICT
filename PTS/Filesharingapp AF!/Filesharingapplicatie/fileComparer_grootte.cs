using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filesharingapplicatie
{
    public class fileComparer_grootte : IComparer<File>
    {
        public int Compare(File x, File y)
        {
            if (x.Grootte > y.Grootte)
            {
                return 1;
            }
            if (x.Grootte < y.Grootte)
            {
                return -1;
            }
            for (int i = 0; i < x.Naam.Length && i < y.Naam.Length; i++)
            {
                if (x.Naam[i] > y.Naam[i])
                {
                    return 1;
                }
                if (x.Naam[i] < y.Naam[i])
                {
                    return -1;
                }
            }
            if (x.Naam.Length > y.Naam.Length)
            {
                return 1;
            }
            if (x.Naam.Length < y.Naam.Length)
            {
                return -1;
            }
            return 0;
        }
    }
}
