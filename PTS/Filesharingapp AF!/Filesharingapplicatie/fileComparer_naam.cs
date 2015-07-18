using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filesharingapplicatie
{
    public class fileComparer_naam : IComparer<File>
    {
        public int Compare(File x, File y)
        {
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
