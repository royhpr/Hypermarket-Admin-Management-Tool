using Hypermarket_Admin_Management_Tool._2_Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace ControllerTester
{
    
    
    /// <summary>
    ///This is a test class for ShopsManagerTest and is intended
    ///to contain all ShopsManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShopsManagerTester
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
        ///A test for ShopsManager Constructor
        ///</summary>
        [TestMethod()]
        public void ShopsManagerConstructorTest()
        {
            ShopsManager target = new ShopsManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddShop
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Hypermarket Admin Management Tool.exe")]
        public void AddShopTest()
        {
            ShopsManager_Accessor target = new ShopsManager_Accessor(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            DataTable expectedResult = new DataTable();
            expectedResult.Columns.Add("ShopID", typeof(string));  //define the attributes
            expectedResult.Columns.Add("Country", typeof(string));
            expectedResult.Columns.Add("Location", typeof(string));
            expectedResult.Columns.Add("Contact", typeof(string));

            string shopID = "1234"; // TODO: Initialize to an appropriate value
            string country = "Singapore"; // TODO: Initialize to an appropriate value
            string location = "TestingLocation"; // TODO: Initialize to an appropriate value
            string contact = "+6594326098"; // TODO: Initialize to an appropriate value
            DBController.DeleteShop(shopID);
            expectedResult.Rows.Add(shopID, country, location, contact);
            target.AddShop(shopID, country, location, contact);   //test on AddShop
            DataTable targetResult = DBController.FetchShop();
            DataRow expectedRow = expectedResult.Rows[expectedResult.Rows.Count - 1];
            DataRow targetRow = targetResult.Rows[targetResult.Rows.Count - 1];
            Assert.AreEqual(expectedRow["ShopID"],targetRow["ShopID"]);
            Assert.AreEqual(expectedRow["Country"], targetRow["Country"]);
            Assert.AreEqual(expectedRow["Location"], targetRow["Location"]);
            Assert.AreEqual(expectedRow["Contact"], targetRow["Contact"]);
            DBController.DeleteShop(shopID);
        }

        /// <summary>
        ///A test for DeleteShop
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Hypermarket Admin Management Tool.exe")]
        public void DeleteShopTest()
        {
            ShopsManager_Accessor target = new ShopsManager_Accessor(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                       Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            DataTable expectedResult = new DataTable();
            expectedResult = DBController.FetchShop();   //featch original shop table

            string shopID = "1234"; // TODO: Initialize to an appropriate value
            string country = "Singapore"; // TODO: Initialize to an appropriate value
            string location = "TestingLocation"; // TODO: Initialize to an appropriate value
            string contact = "+6594326098"; // TODO: Initialize to an appropriate value
            DBController.DeleteShop(shopID);
            target.AddShop(shopID, country, location, contact);  
            target.DeleteShop(shopID);
            DataTable targetResult = DBController.FetchShop();
            Assert.AreEqual(expectedResult.Rows.Count, targetResult.Rows.Count);
        }

        /// <summary>
        ///A test for FetchShop
        ///</summary>
        [TestMethod()]
        public void FetchShopTest()
        {
            ShopsManager_Accessor target = new ShopsManager_Accessor(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                       Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            DataTable expectedResult = DBController.FetchShop();
            DataTable targetResult = target.FetchShop();
            Assert.AreEqual(targetResult.Rows.Count, expectedResult.Rows.Count);
        }

        /// <summary>
        ///A test for GenerateNextAvailableShopID
        ///</summary>
        [TestMethod()]
        public void GenerateNextAvailableShopIDTest()
        {
            ShopsManager_Accessor target = new ShopsManager_Accessor(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                       Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            //first test
            DBController.DeleteShop("1");
            DBController.DeleteShop("1234");
            string shopID = "1234"; // TODO: Initialize to an appropriate value
            string country = "Singapore"; // TODO: Initialize to an appropriate value
            string location = "TestingLocation"; // TODO: Initialize to an appropriate value
            string contact = "+6594326098"; // TODO: Initialize to an appropriate value
            target.AddShop(shopID, country, location, contact);
            
            DataTable targetResult = DBController.FetchShop();
            string AddedNewShopID = target.GenerateNextAvailableShopID();
            Assert.AreEqual("1", AddedNewShopID);

            //second test
            shopID = "1";
            DBController.DeleteShop(shopID);
            target.AddShop(shopID, country, location, contact);
            targetResult = DBController.FetchShop();
            AddedNewShopID = target.GenerateNextAvailableShopID();
            Assert.AreEqual("2", AddedNewShopID);
            DBController.DeleteShop("1");
            DBController.DeleteShop("1234");

            //third test
            AddedNewShopID = target.GenerateNextAvailableShopID();
            Assert.AreEqual("1", AddedNewShopID);
        }

        /// <summary>
        ///A test for UpdateShop
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Hypermarket Admin Management Tool.exe")]
        public void UpdateShopTest()
        {
            ShopsManager_Accessor target = new ShopsManager_Accessor(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                       Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            string shopID = "1234"; // TODO: Initialize to an appropriate value
            string country = "Singapore"; // TODO: Initialize to an appropriate value
            string location = "TestingLocation"; // TODO: Initialize to an appropriate value
            string contact = "+6594326098"; // TODO: Initialize to an appropriate value
            DBController.DeleteShop(shopID);
            target.AddShop(shopID, country, location, contact); 

            target.UpdateShop("1234", "Singapore", "TestingLocation", "+6594326099");
            DataTable targetResult = DBController.FetchShop();
            DataRow targetRow = targetResult.Select("ShopID=1234")[0];
            Assert.AreEqual("1234", targetRow["ShopID"]);
            Assert.AreEqual("Singapore", targetRow["Country"]);
            Assert.AreEqual("TestingLocation", targetRow["Location"]);
            Assert.AreEqual("+6594326099", targetRow["Contact"]);
            DBController.DeleteShop(shopID);

        }
    }
}
