using MateriaalVerhuurApplicatie;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MateriaalVerhuurTests
{
    
    
    /// <summary>
    ///This is a test class for DatabaseKoppelingTest and is intended
    ///to contain all DatabaseKoppelingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DatabaseKoppelingTest
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
        ///A test for getUitlening
        ///</summary>
        [TestMethod()]
        public void getUitleningTest()
        {
            int ReserveringsNummer = 9999; // TODO: Initialize to an appropriate value
            List<Uitlening> expected = new List<Uitlening>(); // TODO: Initialize to an appropriate value
            Uitlening verwacht = new Uitlening("Partytent", ReserveringsNummer, Convert.ToDateTime("01-04-11"), Convert.ToDateTime("01-04-11"), 4);
            expected.Add(verwacht);
            List<Uitlening> actual;
            actual = DatabaseKoppeling.getUitlening(ReserveringsNummer);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Type, actual[i].Type);
            }
            
        }

        /// <summary>
        ///A test for getMateriaal
        ///</summary>
        [TestMethod()]
        public void getMateriaalTest()
        {
            List<Materiaal> expected = new List<Materiaal>();
            Materiaal newmat = new Materiaal("Speedboat", 500, 10);
            Materiaal newmat2 = new Materiaal("Laptop", 50, 50);
            Materiaal newmat3 = new Materiaal("Extreme Laptop", 500, 50);
            Materiaal newmat4 = new Materiaal("Partytent", 20, 100);
            Materiaal newmat5 = new Materiaal("Feestmuts",2,500);
            expected.Add(newmat);
            expected.Add(newmat2);
            expected.Add(newmat3);
            expected.Add(newmat4);
            expected.Add(newmat5);
            List<Materiaal> actual;
            actual = DatabaseKoppeling.getMateriaal();
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Type, actual[i].Type);
            }
            
        }

        /// <summary>
        ///A test for getPersonenBijUitlening
        ///</summary>
        [TestMethod()]
        public void getPersonenBijUitleningTest()
        {
            string Type = "Partytent"; // TODO: Initialize to an appropriate value
            List<Uitlening> expected = new List<Uitlening>(); // TODO: Initialize to an appropriate value
            Uitlening newuit = new Uitlening("Partytent", 9999, DateTime.MinValue, DateTime.MinValue, 1);
            List<Uitlening> actual;
            actual = DatabaseKoppeling.getPersonenBijUitlening(Type);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Reserveringsnummer, actual[i].Reserveringsnummer);
            }

        }

        /// <summary>
        ///A test for getAantalUitgeleend
        ///</summary>
        [TestMethod()]
        public void getAantalUitgeleendTest()
        {
            List<Uitlening> expected = new List<Uitlening>(); // TODO: Initialize to an appropriate value
            Uitlening newuit = new Uitlening("Extreme Laptop", 0, DateTime.MinValue, DateTime.MinValue, 1);
            Uitlening newuit2 = new Uitlening("Feestmuts", 0, DateTime.MinValue, DateTime.MinValue, 1);
            Uitlening newuit3 = new Uitlening("Laptop", 0, DateTime.MinValue, DateTime.MinValue, 1);
            Uitlening newuit4 = new Uitlening("Partytent", 0, DateTime.MinValue, DateTime.MinValue, 1);
            expected.Add(newuit);
            expected.Add(newuit2);
            expected.Add(newuit3);
            expected.Add(newuit4);

            List<Uitlening> actual;
            actual = DatabaseKoppeling.getAantalUitgeleend();
            
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Type, actual[i].Type);
            }
        }

        /// <summary>
        ///A test for GetPersoonByReserveringsnr
        ///</summary>
        [TestMethod()]
        public void GetPersoonByReserveringsnrTest()
        {
            int Reserveringsnummer = 9999; // TODO: Initialize to an appropriate value
            string expected = "TESTSUBJECT"; // TODO: Initialize to an appropriate value
            string actual;
            actual = DatabaseKoppeling.GetPersoonByReserveringsnr(Reserveringsnummer);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetHoeveelheidMateriaal
        ///</summary>
        [TestMethod()]
        public void GetHoeveelheidMateriaalTest()
        {
            Materiaal mat = new Materiaal("Laptop", 0, 10); ; // TODO: Initialize to an appropriate value
            int expected = 49; // TODO: Initialize to an appropriate value
            int actual;
            actual = DatabaseKoppeling.GetHoeveelheidMateriaal(mat);
            Assert.AreEqual(expected, actual);
        }
    }
}
