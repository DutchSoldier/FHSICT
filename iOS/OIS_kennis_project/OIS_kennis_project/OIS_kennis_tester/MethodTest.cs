using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OIS_kennis_tester
{
    [TestClass]
    public class MethodTest
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

        /*+----------------------------------------------------------------+*/
        /*|  V R A A G :                                                   |*/
        /*+----------------------------------------------------------------+*/
        int Goochel(int a, int b)
        {
            return (a + b);
        }

        int Zap(int a)
        {
            return Goochel(a, a);
        }

        [TestMethod]
        public void MethodVraag1()
        {
            resultaat = Zap(4);

            DeWaardeVanResultaatIs(8);
        }

        /*+----------------------------------------------------------------+*/
        /*|  V R A A G :                                                   |*/
        /*+----------------------------------------------------------------+*/
        int Aftopper(int a)
        {
            int t = 100;

            if (a <= 100)
            {
                t = a;
            }

            return t;
        }

        [TestMethod]
        public void MethodVraag2()
        {
            resultaat = Aftopper(964) + Aftopper(36);

            DeWaardeVanResultaatIs(136);
        }

        /*+----------------------------------------------------------------+*/
        /*|  V R A A G :                                                   |*/
        /*+----------------------------------------------------------------+*/
        Boolean IsMooiGetal(int getal)
        {
            Boolean isMooi = (getal > 128) && (getal < 256);

            return isMooi;
        }

        [TestMethod]
        public void MethodVraag3()
        {
            if (IsMooiGetal(127))
            {
                resultaat = 8;
            }
            else if (IsMooiGetal(248))
            {
                resultaat = 10;
            }
            else
            {
                resultaat = 1;
            }

            DeWaardeVanResultaatIs(10);
        }
    }
}
