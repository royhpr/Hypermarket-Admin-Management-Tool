using Hypermarket_Admin_Management_Tool._2_Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace ControllerTester
{
    
    
    /// <summary>
    ///This is a test class for WarehouseManagerTest and is intended
    ///to contain all WarehouseManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WarehouseManagerTest
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
        ///A test for WarehouseManager Constructor
        ///</summary>
        [TestMethod()]
        public void WarehouseManagerConstructorTest()
        {
            WarehouseManager target = new WarehouseManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddApprovedRequest
        ///</summary>
        [TestMethod()]
        public void AddApprovedRequestTest()
        {
            WarehouseManager target = new WarehouseManager();
            Hypermarket_Admin_Management_Tool._1_Model.DBManager DBController = Hypermarket_Admin_Management_Tool._1_Model.DBManager.getInstance();
            string productName = "Money Clip";
            string manufacturerName = "Zooper Dooper"; 
            string productID = "11521340";
            string shopID = "0009"; 
            string shopCountry = "Middlesex";
            string shopLocation = "286 State St, 8861";
            DateTime requestDate = Convert.ToDateTime("2013-9-1");
            DateTime approvedDate = Convert.ToDateTime("2013-9-2"); 
            string staffID = "billie@tinnes.com"; 
            string quantity = "100"; 
            bool urgency = false;
            //target.AddApprovedRequest(productName, manufacturerName, productID, shopID, shopCountry, shopLocation, requestDate, approvedDate, staffID, quantity, urgency);
            DataTable actualTable = DBController.FetchApprovedRequest();
            DataTable expectedTable = setupApprovedStockExpectedTable();
            expectedTable.Rows.Add(productName, manufacturerName, productID, shopID, shopCountry, shopLocation, requestDate, approvedDate, staffID, quantity, urgency);
            DataRow actualRow = actualTable.Rows[actualTable.Rows.Count - 1];
            DataRow expectedRow = expectedTable.Rows[expectedTable.Rows.Count - 1];

            Assert.AreEqual(expectedRow["ProductName"].ToString(), actualRow["ProductName"].ToString());
            Assert.AreEqual(expectedRow["ManufacturerName"].ToString(), actualRow["ManufacturerName"].ToString());
            Assert.AreEqual(expectedRow["ProductID"].ToString(), actualRow["ProductID"].ToString());
            Assert.AreEqual(expectedRow["ShopID"].ToString(), actualRow["ShopID"].ToString());
            Assert.AreEqual(expectedRow["ShopCountry"].ToString(), actualRow["ShopCountry"].ToString());
            Assert.AreEqual(expectedRow["ShopLocation"].ToString(), actualRow["ShopLocation"].ToString());
            Assert.AreEqual(expectedRow["RequestDate"].ToString(), actualRow["RequestDate"].ToString());
            Assert.AreEqual(expectedRow["ApprovedDate"].ToString(), actualRow["ApprovedDate"].ToString());
            Assert.AreEqual(expectedRow["StaffID"].ToString(), actualRow["StaffID"].ToString());
            Assert.AreEqual(expectedRow["Quantity"].ToString(), actualRow["Quantity"].ToString());
            Assert.AreEqual(expectedRow["Urgency"].ToString(), actualRow["Urgency"].ToString());
        }

        /// <summary>
        ///A test for AddRejectedRequest
        ///</summary>
        [TestMethod()]
        public void AddRejectedRequestTest()
        {
            WarehouseManager target = new WarehouseManager();
            Hypermarket_Admin_Management_Tool._1_Model.DBManager DBController = Hypermarket_Admin_Management_Tool._1_Model.DBManager.getInstance();
            string productName = "Money Clip";
            string manufacturerName = "Zooper Dooper";
            string productID = "11521340";
            string shopID = "0012";
            string shopCountry = "Middlesex";
            string shopLocation = "286 State St, 8861";
            DateTime requestDate = Convert.ToDateTime("2013-9-1");
            DateTime rejectedDate = Convert.ToDateTime("2013-9-1");
            string staffID = "billie@tinnes.com";
            string quantity = "100";
            bool urgency = false;
            target.AddRejectedRequest(productName, manufacturerName, productID, shopID, shopCountry, shopLocation, requestDate, rejectedDate, staffID, quantity, urgency);
            DataTable actualTable = DBController.FetchApprovedRequest();
            DataTable expectedTable = setupApprovedStockExpectedTable();
            expectedTable.Rows.Add(productName, manufacturerName, productID, shopID, shopCountry, shopLocation, requestDate, rejectedDate, staffID, quantity, urgency);
            DataRow actualRow = actualTable.Rows[actualTable.Rows.Count - 1];
            DataRow expectedRow = expectedTable.Rows[expectedTable.Rows.Count - 1];

            Assert.AreEqual(expectedRow["ProductName"].ToString(), actualRow["ProductName"].ToString());
            Assert.AreEqual(expectedRow["ManufacturerName"].ToString(), actualRow["ManufacturerName"].ToString());
            Assert.AreEqual(expectedRow["ProductID"].ToString(), actualRow["ProductID"].ToString());
            Assert.AreEqual(expectedRow["ShopID"].ToString(), actualRow["ShopID"].ToString());
            Assert.AreEqual(expectedRow["ShopCountry"].ToString(), actualRow["ShopCountry"].ToString());
            Assert.AreEqual(expectedRow["ShopLocation"].ToString(), actualRow["ShopLocation"].ToString());
            Assert.AreEqual(expectedRow["RequestDate"].ToString(), actualRow["RequestDate"].ToString());
            Assert.AreEqual(expectedRow["ApprovedDate"].ToString(), actualRow["RejectedDate"].ToString());
            Assert.AreEqual(expectedRow["StaffID"].ToString(), actualRow["StaffID"].ToString());
            Assert.AreEqual(expectedRow["Quantity"].ToString(), actualRow["Quantity"].ToString());
            Assert.AreEqual(expectedRow["Urgency"].ToString(), actualRow["Urgency"].ToString());
        }

        /// <summary>
        ///A test for AddSendStock
        ///</summary>
        [TestMethod()]
        public void AddSendStockTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
            string productName = string.Empty; // TODO: Initialize to an appropriate value
            string manufacturerName = string.Empty; // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
           // DateTime batchID = new DateTime(); // TODO: Initialize to an appropriate value
            string shopID = string.Empty; // TODO: Initialize to an appropriate value
            string shopCountry = string.Empty; // TODO: Initialize to an appropriate value
            string shopLocation = string.Empty; // TODO: Initialize to an appropriate value
           // DateTime sendDate = new DateTime(); // TODO: Initialize to an appropriate value
            string quantity = string.Empty; // TODO: Initialize to an appropriate value
           // bool deliveryStatus = false; // TODO: Initialize to an appropriate value
            //target.AddSendStock(productName, manufacturerName, productID, batchID, shopID, shopCountry, shopLocation, sendDate, quantity, deliveryStatus);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddStock
        ///</summary>
        [TestMethod()]
        public void AddStockTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager DBController = Hypermarket_Admin_Management_Tool._1_Model.DBManager.getInstance();
            string prodcutName = "Money Clip"; // TODO: Initialize to an appropriate value
            string manufacturerName = "Zooper Dooper"; // TODO: Initialize to an appropriate value
            string productID = "11521340"; // TODO: Initialize to an appropriate value
            DateTime batchID = DateTime.Today.Date; // TODO: Initialize to an appropriate value
            string importPrice = "19"; // TODO: Initialize to an appropriate value
            string sellPrice = "38"; // TODO: Initialize to an appropriate value
            DateTime expireDate = DateTime.Today.AddYears(2).Date; // TODO: Initialize to an appropriate value
            string quantity = "1000"; // TODO: Initialize to an appropriate value
            target.AddStock(prodcutName, manufacturerName, productID, batchID, importPrice, sellPrice, expireDate, quantity);
            DataTable actualTable = DBController.FetchStock();
            DataTable expectedTable = setupStockExpectedTable();
            expectedTable.Rows.Add(prodcutName, manufacturerName, productID, batchID, importPrice, sellPrice, expireDate, quantity);
            DataRow actualRow = actualTable.Rows[actualTable.Rows.Count - 1];
            DataRow expectedRow = expectedTable.Rows[expectedTable.Rows.Count - 1];

            Assert.AreEqual(expectedRow["ProductName"].ToString(), actualRow["ProductName"].ToString());
            Assert.AreEqual(expectedRow["ManufacturerName"].ToString(), actualRow["ManufacturerName"].ToString());
            Assert.AreEqual(expectedRow["ProductID"].ToString(), actualRow["ProductID"].ToString());
            Assert.AreEqual(expectedRow["BatchID"].ToString(), actualRow["BatchID"].ToString());
            Assert.AreEqual(expectedRow["ImportPrice"].ToString(), actualRow["ImportPrice"].ToString());
            Assert.AreEqual(expectedRow["SellPrice"].ToString(), actualRow["SellPrice"].ToString());
            Assert.AreEqual(expectedRow["ExpireDate"].ToString(), actualRow["ExpireDate"].ToString());
            Assert.AreEqual(expectedRow["Quantity"].ToString(), actualRow["Quantity"].ToString());
        }

        /// <summary>
        ///A test for ChangeRequestStatus
        ///</summary>
        [TestMethod()]
        public void ChangeRequestStatusTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
           // bool approved = false; // TODO: Initialize to an appropriate value
            string productName = string.Empty; // TODO: Initialize to an appropriate value
            string manufacturerName = string.Empty; // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            string shopID = string.Empty; // TODO: Initialize to an appropriate value
            string shopCountry = string.Empty; // TODO: Initialize to an appropriate value
            string shopLocaton = string.Empty; // TODO: Initialize to an appropriate value
          //  DateTime requestDate = new DateTime(); // TODO: Initialize to an appropriate value
         //   DateTime approvedDate = new DateTime(); // TODO: Initialize to an appropriate value
          //  DateTime rejectedDate = new DateTime(); // TODO: Initialize to an appropriate value
            string staffID = string.Empty; // TODO: Initialize to an appropriate value
            string quantity = string.Empty; // TODO: Initialize to an appropriate value
          //  bool urgency = false; // TODO: Initialize to an appropriate value
            //target.ChangeRequestStatus(approved, productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, requestDate, approvedDate, rejectedDate, staffID, quantity, urgency);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeletePendingRequest
        ///</summary>
        [TestMethod()]
        public void DeletePendingRequestTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            string shopID = string.Empty; // TODO: Initialize to an appropriate value
            DateTime requestDate = new DateTime(); // TODO: Initialize to an appropriate value
            target.DeletePendingRequest(productID, shopID, requestDate);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeleteRejectedRequest
        ///</summary>
        [TestMethod()]
        public void DeleteRejectedRequestTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            string shopID = string.Empty; // TODO: Initialize to an appropriate value
            DateTime requestDate = new DateTime(); // TODO: Initialize to an appropriate value
            string staffID = string.Empty; // TODO: Initialize to an appropriate value
            target.DeleteRejectedRequest(productID, shopID, requestDate, staffID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeleteSendStock
        ///</summary>
        [TestMethod()]
        public void DeleteSendStockTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            DateTime batchID = new DateTime(); // TODO: Initialize to an appropriate value
            string shopID = string.Empty; // TODO: Initialize to an appropriate value
            target.DeleteSendStock(productID, batchID, shopID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FetchApprovedRequest
        ///</summary>
        [TestMethod()]
        public void FetchApprovedRequestTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchApprovedRequest();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchPendingRequest
        ///</summary>
        [TestMethod()]
        public void FetchPendingRequestTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchPendingRequest();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchRejectedRequest
        ///</summary>
        [TestMethod()]
        public void FetchRejectedRequestTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchRejectedRequest();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchSendStock
        ///</summary>
        [TestMethod()]
        public void FetchSendStockTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchSendStock();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchStock
        ///</summary>
        [TestMethod()]
        public void FetchStockTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager DBController = Hypermarket_Admin_Management_Tool._1_Model.DBManager.getInstance();
            DataTable expected = DBController.FetchStock();
            DataTable actual;
            actual = target.FetchStock();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for UpdateStock
        ///</summary>
        [TestMethod()]
        public void UpdateStockTest()
        {
            WarehouseManager target = new WarehouseManager(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager DBController = Hypermarket_Admin_Management_Tool._1_Model.DBManager.getInstance();
            string prodcutName = "Money Clip"; // TODO: Initialize to an appropriate value
            string manufacturerName = "Zooper Dooper"; // TODO: Initialize to an appropriate value
            string productID = "11521340"; // TODO: Initialize to an appropriate value
            DateTime batchID = Convert.ToDateTime("2013-08-29"); // TODO: Initialize to an appropriate value
            string importPrice = "99"; // TODO: Initialize to an appropriate value
            string sellPrice = "15"; // TODO: Initialize to an appropriate value
            DateTime expireDate = Convert.ToDateTime("2015-08-29"); // TODO: Initialize to an appropriate value
            string quantity = "1000"; // TODO: Initialize to an appropriate value
            target.UpdateStock(productID, batchID, importPrice, sellPrice, expireDate, quantity);
            DataTable actualTable = DBController.FetchStock();
            DataTable expectedTable = setupStockExpectedTable();
            expectedTable.Rows.Add(prodcutName, manufacturerName, productID, batchID, importPrice, sellPrice, expireDate, quantity);
            DataRow actualRow = actualTable.Select("ProductID = '11521340' AND batchID = '2013-08-29'")[0];
            DataRow expectedRow = expectedTable.Rows[expectedTable.Rows.Count - 1];

            Assert.AreEqual(expectedRow["ProductName"].ToString(), actualRow["ProductName"].ToString());
            Assert.AreEqual(expectedRow["ManufacturerName"].ToString(), actualRow["ManufacturerName"].ToString());
            Assert.AreEqual(expectedRow["ProductID"].ToString(), actualRow["ProductID"].ToString());
            Assert.AreEqual(expectedRow["BatchID"].ToString(), actualRow["BatchID"].ToString());
            Assert.AreEqual(expectedRow["ImportPrice"].ToString(), actualRow["ImportPrice"].ToString());
            Assert.AreEqual(expectedRow["SellPrice"].ToString(), actualRow["SellPrice"].ToString());
            Assert.AreEqual(expectedRow["ExpireDate"].ToString(), actualRow["ExpireDate"].ToString());
            Assert.AreEqual(expectedRow["Quantity"].ToString(), actualRow["Quantity"].ToString());
        }

        #region Expected Tables

        private static DataTable setupStockExpectedTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("ManufacturerName", typeof(string));
            table.Columns.Add("ProductID", typeof(string));
            table.Columns.Add("BatchID", typeof(DateTime));
            table.Columns.Add("ImportPrice", typeof(string));
            table.Columns.Add("SellPrice", typeof(string));
            table.Columns.Add("ExpireDate", typeof(DateTime));
            table.Columns.Add("Quantity", typeof(string));
            return table;
        }

        private static DataTable setupApprovedStockExpectedTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("ManufacturerName", typeof(string));
            table.Columns.Add("ProductID", typeof(string));
            table.Columns.Add("ShopID", typeof(string));
            table.Columns.Add("ShopCountry", typeof(string));
            table.Columns.Add("ShopLocation", typeof(string));
            table.Columns.Add("RequestDate", typeof(DateTime));
            table.Columns.Add("ApprovedDate", typeof(DateTime));
            table.Columns.Add("StaffID", typeof(string));
            table.Columns.Add("Quantity", typeof(string));
            table.Columns.Add("Urgency", typeof(bool));
            return table;
        }

        private static DataTable setupRejectedStockExpectedTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("ManufacturerName", typeof(string));
            table.Columns.Add("ProductID", typeof(string));
            table.Columns.Add("ShopID", typeof(string));
            table.Columns.Add("ShopCountry", typeof(string));
            table.Columns.Add("ShopLocation", typeof(string));
            table.Columns.Add("RequestDate", typeof(DateTime));
            table.Columns.Add("RejectedDate", typeof(DateTime));
            table.Columns.Add("StaffID", typeof(string));
            table.Columns.Add("Quantity", typeof(string));
            table.Columns.Add("Urgency", typeof(bool));
            return table;
        }

        #endregion
    }
}
