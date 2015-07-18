//ReserveringForm Test

namespace Reserveringsapplicatie_TestCases
{
    using System;
    using System.Collections.Generic;
    using Reserveringssysteem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
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
                return this.testContextInstance;
            }
            set
            {
                this.testContextInstance = value;
            }
        }

        #region Additional test attributes
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
        #endregion

        /// <summary>
        ///Test of een reservering wordt toegevoegd in de DB. 
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Reserveringssysteem.exe")]
        public void BtnBevestig_ClickTest()
        {
            int reserveringsNummer = DatabaseKoppeling.GetNieuwReserveringsnummer();
            Reservering reservering = new Reservering(reserveringsNummer, "false");
            DatabaseKoppeling.AddReservering(reservering);
            string rfid = DatabaseKoppeling.GetVrijRFID();
            BetalendeKlant klant = new BetalendeKlant(rfid, "Klaas Jansen", "125879654", "thesarao@hotmail.com", "0497641565", "Hoge Veluwe", "Garstbocht 2", "84.15.45.122", "4584 AK", reserveringsNummer);
            DatabaseKoppeling.AddBetalendeKlant(klant);

            DatabaseKoppeling.AddReserveringPlaats(reserveringsNummer, "3");
            DatabaseKoppeling.AddReserveringPlaats(reserveringsNummer, "8");

            string vrijRFID = DatabaseKoppeling.GetVrijRFID();
            Klant klant2 = new Klant(vrijRFID, reserveringsNummer);
            DatabaseKoppeling.AddKlant(klant2);
            string vrijRFID2 = DatabaseKoppeling.GetVrijRFID();
            Klant klant3 = new Klant(vrijRFID2, reserveringsNummer);
            DatabaseKoppeling.AddKlant(klant3);

            int actual1 = DatabaseKoppeling.GetAantalPersonen(reserveringsNummer);
            int expected1 = 3;
            Assert.AreEqual(expected1, actual1);

            BetalendeKlant actual2 = DatabaseKoppeling.GetKlantBetalend(reserveringsNummer);
            BetalendeKlant expected2 = klant;
            Assert.AreEqual(expected2.Naam, actual2.Naam);
            Assert.AreEqual(expected2.Rfid, actual2.Rfid);
        }
    }
}
