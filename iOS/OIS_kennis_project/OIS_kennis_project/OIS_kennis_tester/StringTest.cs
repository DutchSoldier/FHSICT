using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace OIS_kennis_tester
{
    [TestClass]
    public class StringTest
    {
        string resultaat;
        string antwoord;
        string kweetNiet = "?";

        void DeWaardeVanResultaatIs(string getal)
        {
            antwoord = getal;
            Assert.IsTrue(antwoord != kweetNiet && antwoord.Equals(resultaat));
        }

        [TestInitialize]
        public void testSetup()
        {
            resultaat = kweetNiet;
            antwoord = kweetNiet;
        }

        [TestMethod]
        public void StringVraag1()
        {
            string getal = "zes";

            resultaat = getal + 5 * 6;

            DeWaardeVanResultaatIs("zes30");
        }

        [TestMethod]
        public void StringVraag2()
        {
            int wam = 8;
            int bam = 4;

            resultaat = Convert.ToString(wam) + Convert.ToString(bam) + wam * bam;

            DeWaardeVanResultaatIs("8432");
        }

        [TestMethod]
        public void StringVraag3()
        {
            string grootGetal = "10";
            string luckyGetal = "8";
            int anderGetal = Convert.ToInt16(grootGetal) - Convert.ToInt16(luckyGetal);

            resultaat = "10" + anderGetal;

            DeWaardeVanResultaatIs("");
        }

        [TestMethod]
        public void StringVraag4()
        {
            int x = 7;
            int y = 3;

            resultaat = Convert.ToString(x + y * y);

            DeWaardeVanResultaatIs("16");
        }

        [TestMethod]
        public void StringVraag5()
        {
            string s = "2";
            string t = "5";
            string u = s + t;
            resultaat = Convert.ToString(Convert.ToInt32(u));

            DeWaardeVanResultaatIs("25");
        }
    }
}
