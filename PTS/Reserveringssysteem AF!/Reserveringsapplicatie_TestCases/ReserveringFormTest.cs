using Reserveringssysteem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Reserveringsapplicatie_TestCases
{
    
    
    /// <summary>
    ///This is a test class for ReserveringFormTest and is intended
    ///to contain all ReserveringFormTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ReserveringFormTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Test of een reservering wordt toegevoegd in de DB. 
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Reserveringssysteem.exe")]
        public void btnBevestig_ClickTest()
        {
            int reserveringsNummer = DatabaseKoppeling_Accessor.GetNieuwReserveringsnummer();
            Reservering_Accessor reservering = new Reservering_Accessor(reserveringsNummer, "false");
            DatabaseKoppeling_Accessor.AddReservering(reservering);
            string rfid = DatabaseKoppeling_Accessor.GetVrijRFID();
            BetalendeKlant_Accessor klant = new BetalendeKlant_Accessor(rfid, "Klaas Jansen", "125879654", "thesarao@hotmail.com", "0497641565", "Hoge Veluwe", "Garstbocht 2", "84.15.45.122", "4584 AK", reserveringsNummer);
            DatabaseKoppeling_Accessor.AddBetalendeKlant(klant);

            DatabaseKoppeling_Accessor.AddReserveringPlaats(reserveringsNummer, "3");
            DatabaseKoppeling_Accessor.AddReserveringPlaats(reserveringsNummer, "8");

            string vrijRFID = DatabaseKoppeling_Accessor.GetVrijRFID();
            Klant_Accessor klant2 = new Klant_Accessor(vrijRFID, reserveringsNummer);
            DatabaseKoppeling_Accessor.AddKlant(klant2);
            string vrijRFID2 = DatabaseKoppeling_Accessor.GetVrijRFID();
            Klant_Accessor klant3 = new Klant_Accessor(vrijRFID2, reserveringsNummer);
            DatabaseKoppeling_Accessor.AddKlant(klant3);

            int actual1 = DatabaseKoppeling_Accessor.GetAantalPersonen(reserveringsNummer);
            int expected1 = 3;
            Assert.AreEqual(expected1, actual1);

            BetalendeKlant_Accessor actual2 = DatabaseKoppeling_Accessor.GetKlantBetalend(reserveringsNummer);
            BetalendeKlant_Accessor expected2 = klant;
            Assert.AreEqual(expected2.Naam, actual2.Naam);
            Assert.AreEqual(expected2.Rfid, actual2.Rfid);
        }
    }
}
