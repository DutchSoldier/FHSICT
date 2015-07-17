using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OIS_kennis_tester
{
    [TestClass]
    public class HerhalingsTest
    {
        int resultaat = 0;
        int antwoord = 0;

        void DeWaardeVanResultaatIs(int getal)
        {
            antwoord = getal;
            Assert.IsTrue((antwoord != 0) && (antwoord == resultaat));
        }

        [TestInitialize]
        public void setUp()
        {
            resultaat = 0;
            antwoord = 0;
        }

        [TestMethod]
        public void HerhalingsVraag1()
        {
            int b = 4;
            for (int i = 0; i < 8; i++)
            {
                if (i > 5)
                {
                    b = b + i;
                }
            }

            resultaat = b;

            DeWaardeVanResultaatIs(17);
        }

        [TestMethod]
        public void HerhalingsVraag2()
        {
            int a = 4;
            int b = 7;
            int c = 0;

            if (a > 4)
            {
                c = b + 12;
            }
            else if (a < 4)
            {
                c = a + 12;
            }
            else
            {
                c = a + b;
            }

            resultaat = c;

            DeWaardeVanResultaatIs(11);
        }

        [TestMethod]
        public void HerhalingsVraag3()
        {
            int x = 3;
            int y = 9;

            while (y < x)
            {
                x = x + 3;
                y = y - 3;
            }

            resultaat = x;

            DeWaardeVanResultaatIs(3);
        }

        [TestMethod]
        public void HerhalingsVraag4()
        {
            int c = 0;
            int d = 4;

            while ( (c < 4) && (d < 8) )
            {
                c = c + 1;
                d = d + 2;
            }

            resultaat = c + d;

            DeWaardeVanResultaatIs(10);
        }

        [TestMethod]
        public void HerhalingsVraag5()
        {
            int z = 2;

            for (int a = 4; a < 8; a = a + 2)
            {
                z = z + 2 * a;
            }

            resultaat = z;

            DeWaardeVanResultaatIs(0);
        }
    }
}
