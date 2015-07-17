using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestBankProject
{
    
    
    /// <summary>
    ///This is a test class for RekeningTest and is intended
    ///to contain all RekeningTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RekeningTest
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
        ///A test for Saldo
        ///</summary>
        [TestMethod()]
        public void SaldoTest()
        {
            Rekening target = new Rekening();
            float actual;
            actual = target.Saldo;
            Assert.AreEqual(0, actual);
        }

        /// <summary>
        ///A test for Stort
        ///</summary>
        [TestMethod()]
        public void StortTest()
        {
            Rekening target = new Rekening();
            float bedrag = 200.2F; // TODO: Initialize to an appropriate value
            target.Stort(bedrag);
            Assert.AreEqual(200.2f, target.Saldo);
        }

        /// <summary>
        ///A test for NeemOp
        ///</summary>
        [TestMethod()]
        public void NeemOpTest()
        {
            Rekening target = new Rekening(); 
            float bedrag = 30F; 
            bool result = target.NeemOp(bedrag);
            Assert.AreEqual(-30,target.Saldo,"Saldo onjuist");
            Assert.AreEqual(result, true);

            result  = target.NeemOp(71F);
            Assert.AreEqual(-30, target.Saldo, "Kredietlimiet vergeten");
            Assert.AreEqual(result, false);

        }

        /// <summary>
        ///A test for Rekening Constructor
        ///</summary>
        [TestMethod()]
        public void RekeningConstructorTest()
        {
            Rekening target = new Rekening();
            Assert.AreEqual(0,target.Saldo);
            Assert.AreEqual(100, target.Kredietlimiet);
        }
    }
}
