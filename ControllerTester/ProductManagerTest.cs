using Hypermarket_Admin_Management_Tool._2_Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace ControllerTester
{
    
    
    /// <summary>
    ///This is a test class for ProductManagerTest and is intended
    ///to contain all ProductManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProductManagerTest
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
        ///A test for ProductManager Constructor
        ///</summary>
        [TestMethod()]
        public void ProductManagerConstructorTest()
        {
            ProductManager target = new ProductManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for UpdateProduct
        ///</summary>
        [TestMethod()]
        public void UpdateProductTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                       Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
           // string manufacturerName = "CLR"; // TODO: Initialize to an appropriate value
            string productID = "1234"; // TODO: Initialize to an appropriate value
           // string name = "Apple"; // TODO: Initialize to an appropriate value
           // string category = "Food"; // TODO: Initialize to an appropriate value
           // bool perishable = true; // TODO: Initialize to an appropriate value
            DBController.DeleteProduct(productID);
            //target.AddProduct(manufacturerName, productID, name, category, perishable);

            //target.UpdateProduct("CLR", "1234", "America Apple", "Food", true);
            DataTable targetResult = DBController.FetchProduct();
            DataRow targetRow = targetResult.Rows[targetResult.Rows.Count - 1];

            Assert.AreEqual("CLR", targetRow["ManufacturerName"]);
            Assert.AreEqual("1234", targetRow["ProductID"]);
            Assert.AreEqual("America Apple", targetRow["Name"]);
            Assert.AreEqual("Food", targetRow["Category"]);
            Assert.AreEqual(true, targetRow["Perishable"]);
            DBController.DeleteProduct(productID);
        }

        /// <summary>
        ///A test for UpdateManufacturer
        ///</summary>
        [TestMethod()]
        public void UpdateManufacturerTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                       Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            string manufacturerName = "Test"; // TODO: Initialize to an appropriate value
            string address = "TestAddress"; // TODO: Initialize to an appropriate value
            string country = "Singapore"; // TODO: Initialize to an appropriate value
            string contact = "+6594326098"; // TODO: Initialize to an appropriate value
            DBController.DeleteManufacturer(manufacturerName);
            target.AddManufacturer(manufacturerName, address, country, contact);

            target.UpdateManufacturer("Test", "TestAddress", "China", "+6594326098");
            DataTable targetResult = DBController.FetchManufacturer();
            DataRow targetRow = targetResult.Rows[targetResult.Rows.Count - 1];

            Assert.AreEqual("Test", targetRow["ManufacturerName"]);
            Assert.AreEqual("TestAddress", targetRow["Address"]);
            Assert.AreEqual("China", targetRow["Country"]);
            Assert.AreEqual("+6594326098", targetRow["Contact"]);
            DBController.DeleteManufacturer(manufacturerName);
        }

        /// <summary>
        ///A test for GenerateNextAvailableProductID
        ///</summary>
        [TestMethod()]
        public void GenerateNextAvailableProductIDTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                       Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            //first test
            DBController.DeleteProduct("1");
            DBController.DeleteProduct("23456");
           // string manufacturerName = "CLR"; // TODO: Initialize to an appropriate value
            string productID = "23456"; // TODO: Initialize to an appropriate value
           // string name = "egg"; // TODO: Initialize to an appropriate value
           // string category = "Food"; // TODO: Initialize to an appropriate value
            //bool perishable = true; // TODO: Initialize to an appropriate value
            //target.AddProduct(manufacturerName, productID, name, category, perishable);
            DataTable targetResult = DBController.FetchProduct();
            string AddedNewProductID = target.GenerateNextAvailableProductID();
            Assert.AreEqual("1", AddedNewProductID);

            ////second test
            productID = "1";
            DBController.DeleteProduct(productID);
            //target.AddProduct(manufacturerName, productID, name, category, perishable);
            targetResult = DBController.FetchProduct();
            AddedNewProductID = target.GenerateNextAvailableProductID();
            Assert.AreEqual("2", AddedNewProductID);
            DBController.DeleteProduct("1");
            DBController.DeleteProduct("23456");

            ////third test
            AddedNewProductID = target.GenerateNextAvailableProductID();
            Assert.AreEqual("1", AddedNewProductID);
        }
        /// <summary>
        ///A test for FetchProduct
        ///</summary>
        [TestMethod()]

        public void FetchProductTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                       Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            DataTable expectedResult = DBController.FetchProduct();
            DataTable targetResult = target.FetchProduct();
            Assert.AreEqual(targetResult.Rows.Count, expectedResult.Rows.Count);
        }

        /// <summary>
        ///A test for FetchManufacturer
        ///</summary>
        [TestMethod()]
        public void FetchManufacturerTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                       Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            DataTable expectedResult = DBController.FetchManufacturer();
            DataTable targetResult = target.FetchManufacturer();
            Assert.AreEqual(targetResult.Rows.Count, expectedResult.Rows.Count);
        }

        /// <summary>
        ///A test for DeleteManufacturer
        ///</summary>
        [TestMethod()]
        public void DeleteManufacturerTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                       Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            DataTable expectedResult = new DataTable();
            expectedResult = DBController.FetchManufacturer();   //featch original shop table
            string manufacturerName = "Test"; // TODO: Initialize to an appropriate value
            string address = "1234"; // TODO: Initialize to an appropriate value
            string country = "Apple"; // TODO: Initialize to an appropriate value
            string contact = "Food"; // TODO: Initialize to an appropriate value
            DBController.DeleteManufacturer("Test");
            target.AddManufacturer(manufacturerName, address, country, contact);
            target.DeleteManufacturer("Test");
            DataTable targetResult = DBController.FetchManufacturer();
            Assert.AreEqual(expectedResult.Rows.Count, targetResult.Rows.Count);
        }

        /// <summary>
        ///A test for DeleteProduct
        ///</summary>
        [TestMethod()]
        public void DeleteProductTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                       Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            DataTable expectedResult = new DataTable();
            expectedResult = DBController.FetchProduct();   //featch original shop table
           // string manufacturerName = "Mars"; // TODO: Initialize to an appropriate value
           // string productID = "1234"; // TODO: Initialize to an appropriate value
           // string name = "Apple"; // TODO: Initialize to an appropriate value
           // string category = "Food"; // TODO: Initialize to an appropriate value
           // bool perishable = true; // TODO: Initialize to an appropriate value
            DBController.DeleteProduct("1234");
            //target.AddProduct(manufacturerName, productID, name, category, perishable);
            target.DeleteProduct("1234");
            DataTable targetResult = DBController.FetchProduct();
            Assert.AreEqual(expectedResult.Rows.Count, targetResult.Rows.Count);
        }

        /// <summary>
        ///A test for AddProduct
        ///</summary>
        [TestMethod()]
        public void AddProductTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            DataTable expectedResult = new DataTable();
            expectedResult.Columns.Add("ManufacturerName", typeof(string));  //define the attributes
            expectedResult.Columns.Add("ProductID", typeof(string));
            expectedResult.Columns.Add("Name", typeof(string));
            expectedResult.Columns.Add("Category", typeof(string));
            expectedResult.Columns.Add("Perishable", typeof(bool));

            string manufacturerName = "Mars"; // TODO: Initialize to an appropriate value
            string productID = "1234"; // TODO: Initialize to an appropriate value
            string name = "Apple"; // TODO: Initialize to an appropriate value
            string category = "Food"; // TODO: Initialize to an appropriate value
            bool perishable = true; // TODO: Initialize to an appropriate value
            DBController.DeleteProduct(productID);
            //target.AddProduct(manufacturerName, productID, name, category, perishable);
            expectedResult.Rows.Add(manufacturerName, productID, name, category, perishable);

            DataTable targetResult = DBController.FetchProduct();
            DataRow expectedRow = expectedResult.Rows[expectedResult.Rows.Count - 1];
            DataRow targetRow = targetResult.Rows[targetResult.Rows.Count - 1];

            Assert.AreEqual(expectedRow["ManufacturerName"], targetRow["ManufacturerName"]);
            Assert.AreEqual(expectedRow["ProductID"], targetRow["ProductID"]);
            Assert.AreEqual(expectedRow["Name"], targetRow["Name"]);
            Assert.AreEqual(expectedRow["Category"], targetRow["Category"]);
            Assert.AreEqual(expectedRow["Perishable"], targetRow["Perishable"]);
            DBController.DeleteProduct(productID);

        }

        /// <summary>
        ///A test for AddManufacturer
        ///</summary>
        [TestMethod()]
        public void AddManufacturerTest()
        {
            ProductManager target = new ProductManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            DataTable expectedResult = new DataTable();
            expectedResult.Columns.Add("ManufacturerName", typeof(string));  //define the attributes
            expectedResult.Columns.Add("Address", typeof(string));
            expectedResult.Columns.Add("Country", typeof(string));
            expectedResult.Columns.Add("Contact", typeof(string));

            string manufacturerName = "ZL"; // TODO: Initialize to an appropriate value
            string address = "Tester"; // TODO: Initialize to an appropriate value
            string country = "Singapore"; // TODO: Initialize to an appropriate value
            string contact = "+6593425678"; // TODO: Initialize to an appropriate value

            DBController.DeleteManufacturer("ZL");
            target.AddManufacturer(manufacturerName, address, country, contact);
            expectedResult.Rows.Add(manufacturerName, address, country, contact);

            DataTable targetResult = DBController.FetchManufacturer();
            DataRow expectedRow = expectedResult.Rows[expectedResult.Rows.Count - 1];
            DataRow targetRow = targetResult.Rows[targetResult.Rows.Count - 1];

            Assert.AreEqual(expectedRow["ManufacturerName"], targetRow["ManufacturerName"]);
            Assert.AreEqual(expectedRow["Address"], targetRow["Address"]);
            Assert.AreEqual(expectedRow["Country"], targetRow["Country"]);
            Assert.AreEqual(expectedRow["Contact"], targetRow["Contact"]);
            DBController.DeleteManufacturer("ZL");
        }
    }
}
