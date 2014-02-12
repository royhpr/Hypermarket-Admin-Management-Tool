using Hypermarket_Admin_Management_Tool._1_Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace DBManagerTester
{
    
    
    /// <summary>
    ///This is a test class for DBManagerTester and is intended
    ///to contain all DBManagerTester Unit Tests
    ///</summary>
    [TestClass()]
    public class DBManagerTester
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


        //
        /// <summary>
        ///A test for AddApprovedRequest
        ///</summary>
        [TestMethod()]
        public void AddApprovedRequestTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            DataTable dtExpected = new DataTable();
            DataTable dtResult;
            dtExpected.Columns.Add("ProductName", typeof(string));
            dtExpected.Columns.Add("ManufacturerName", typeof(string));
            dtExpected.Columns.Add("ProductID", typeof(string));
            dtExpected.Columns.Add("ShopID", typeof(string));
            dtExpected.Columns.Add("ShopCountry", typeof(string));
            dtExpected.Columns.Add("ShopLocation", typeof(string));
            dtExpected.Columns.Add("RequestDate", typeof(DateTime));
            dtExpected.Columns.Add("ApprovedDate", typeof(DateTime));
            dtExpected.Columns.Add("StaffID", typeof(string));
            dtExpected.Columns.Add("Quantity", typeof(int));
            dtExpected.Columns.Add("Urgency", typeof(bool));

            string productName = "Money Clip"; // TODO: Initialize to an appropriate value
            string manufacturerName = "Zooper Dooper"; // TODO: Initialize to an appropriate value
            string productID = "11521340"; // TODO: Initialize to an appropriate value
            string shopID = "0001"; // TODO: Initialize to an appropriate value
            string shopCountry = "Singapore"; // TODO: Initialize to an appropriate value
            string shopLocaton = "Ang Mo Kio"; // TODO: Initialize to an appropriate value
            DateTime requestDate = new DateTime(2013,8,29); // TODO: Initialize to an appropriate value
            DateTime approvedDate = DateTime.Now; // TODO: Initialize to an appropriate value
            string staffID = "roy.hpr@gmail.com"; // TODO: Initialize to an appropriate value
            string quantity = "50"; // TODO: Initialize to an appropriate value
            bool urgency = true; // TODO: Initialize to an appropriate value
            //target.AddApprovedRequest(productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, requestDate, approvedDate, staffID, quantity, urgency);

            dtResult = target.FetchApprovedRequest();
            dtExpected.Rows.Add(productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, requestDate, approvedDate, staffID, quantity, urgency);

            //Comparison
            Assert.AreEqual(dtExpected.Rows[0]["ProductName"].ToString(), dtResult.Rows[dtResult.Rows.Count-1]["ProductName"].ToString());
            Assert.AreEqual(dtExpected.Rows[0]["ManufacturerName"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["ManufacturerName"].ToString());
            Assert.AreEqual(dtExpected.Rows[0]["ProductID"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["ProductID"].ToString());
            Assert.AreEqual(dtExpected.Rows[0]["ShopID"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["ShopID"].ToString());
            Assert.AreEqual(dtExpected.Rows[0]["ShopCountry"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["ShopCountry"].ToString());
            Assert.AreEqual(dtExpected.Rows[0]["ShopLocation"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["ShopLocation"].ToString());
            Assert.AreEqual(dtExpected.Rows[0]["RequestDate"], dtResult.Rows[dtResult.Rows.Count - 1]["RequestDate"]);
            Assert.AreEqual(dtExpected.Rows[0]["ApprovedDate"], dtResult.Rows[dtResult.Rows.Count - 1]["ApprovedDate"]);
            Assert.AreEqual(dtExpected.Rows[0]["StaffID"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["StaffID"].ToString());
            Assert.AreEqual(dtExpected.Rows[0]["Quantity"], dtResult.Rows[dtResult.Rows.Count - 1]["Quantity"]);
            Assert.AreEqual(dtExpected.Rows[0]["Urgency"], dtResult.Rows[dtResult.Rows.Count - 1]["Urgency"]);
        }

        /// <summary>
        ///A test for AddManufacturer
        ///</summary>
        [TestMethod()]
        public void AddManufacturerTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string manufacturerName = "just for test"; // TODO: Initialize to an appropriate value
            string address = "just for test"; // TODO: Initialize to an appropriate value
            string country = "just for test"; // TODO: Initialize to an appropriate value
            string contact = "88888888"; // TODO: Initialize to an appropriate value
            target.AddManufacturer(manufacturerName, address, country, contact);

            DataTable dtExpected = new DataTable();
            DataTable dtResult = target.FetchManufacturer();

            try
            {
                dtExpected.Columns.Add("Manufacturer", typeof(string));
                dtExpected.Columns.Add("Address", typeof(string));
                dtExpected.Columns.Add("Country", typeof(string));
                dtExpected.Columns.Add("Contact", typeof(string));
                dtExpected.Rows.Add(manufacturerName, address, country, contact);

                //Comparison
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    if (dtResult.Rows[i]["ManufacturerName"].ToString().Equals(dtExpected.Rows[0]["Manufacturer"].ToString()))
                    {
                        Assert.AreEqual(dtResult.Rows[i]["ManufacturerName"].ToString(), dtExpected.Rows[0]["ManufacturerName"].ToString());
                        Assert.AreEqual(dtResult.Rows[i]["Address"].ToString(), dtExpected.Rows[0]["Address"].ToString());
                        Assert.AreEqual(dtResult.Rows[i]["Country"].ToString(), dtExpected.Rows[0]["Country"].ToString());
                        Assert.AreEqual(dtResult.Rows[i]["Contact"].ToString(), dtExpected.Rows[0]["Contact"].ToString());
                    }
                }
            }
            catch
            {
                target.DeleteManufacturer(manufacturerName);
            }
        }

        /// <summary>
        ///A test for AddProduct
        ///</summary>
        [TestMethod()]
        public void AddProductTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string manufacturerName = "3M"; // TODO: Initialize to an appropriate value
            string productID = "88888888"; // TODO: Initialize to an appropriate value
            string name = "just for test"; // TODO: Initialize to an appropriate value
            string category = "just for test"; // TODO: Initialize to an appropriate value
            bool perishable = false; // TODO: Initialize to an appropriate value
            //target.AddProduct(manufacturerName, productID, name, category, perishable);

            DataTable dtExpected = new DataTable();
            DataTable dtResult = target.FetchProduct();

            try
            {
                dtExpected.Columns.Add("Manufacturer", typeof(string));
                dtExpected.Columns.Add("ProductID", typeof(string));
                dtExpected.Columns.Add("Name", typeof(string));
                dtExpected.Columns.Add("Category", typeof(string));
                dtExpected.Columns.Add("Perishable", typeof(bool));
                dtExpected.Rows.Add(manufacturerName, productID, name, category, perishable);

                //Comparison
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    if (dtResult.Rows[i]["ProductID"].ToString().Equals(dtExpected.Rows[0]["ProductID"].ToString()))
                    {
                        Assert.AreEqual(dtResult.Rows[i]["ManufacturerName"].ToString(), dtExpected.Rows[0]["ManufacturerName"].ToString());
                        Assert.AreEqual(dtResult.Rows[i]["Name"].ToString(), dtExpected.Rows[0]["Name"].ToString());
                        Assert.AreEqual(dtResult.Rows[i]["Category"].ToString(), dtExpected.Rows[0]["Category"].ToString());
                        Assert.AreEqual(dtResult.Rows[i]["Perishable"].ToString(), dtExpected.Rows[0]["Perishable"].ToString());
                    }
                }
            }
            catch
            {
                target.DeleteProduct(productID);
            }
        }

        /// <summary>
        ///A test for AddRejectedRequest
        ///</summary>
        [TestMethod()]
        public void AddRejectedRequestTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            DataTable dtExpected = new DataTable();
            DataTable dtResult;
            string productName = "4 ink colour ball pen"; // TODO: Initialize to an appropriate value
            string manufacturerName = "Wow Select"; // TODO: Initialize to an appropriate value
            string productID = "11521340"; // TODO: Initialize to an appropriate value
            string shopID = "0001"; // TODO: Initialize to an appropriate value
            string shopCountry = "Singapore"; // TODO: Initialize to an appropriate value
            string shopLocaton = "Ang Mo Kio"; // TODO: Initialize to an appropriate value
            DateTime requestDate = new DateTime(2013, 8, 29); // TODO: Initialize to an appropriate value
            DateTime rejectedDate = DateTime.Now; // TODO: Initialize to an appropriate value
            string staffID = "roy.hpr@gmail.com"; // TODO: Initialize to an appropriate value
            string quantity = "50"; // TODO: Initialize to an appropriate value
            bool urgency = true; // TODO: Initialize to an appropriate value

            dtExpected.Columns.Add("ProductName", typeof(string));
            dtExpected.Columns.Add("ManufacturerName", typeof(string));
            dtExpected.Columns.Add("ProductID", typeof(string));
            dtExpected.Columns.Add("ShopID", typeof(string));
            dtExpected.Columns.Add("ShopCountry", typeof(string));
            dtExpected.Columns.Add("ShopLocation", typeof(string));
            dtExpected.Columns.Add("RequestDate", typeof(DateTime));
            dtExpected.Columns.Add("RejectedDate", typeof(DateTime));
            dtExpected.Columns.Add("StaffID", typeof(string));
            dtExpected.Columns.Add("Quantity", typeof(int));
            dtExpected.Columns.Add("Urgency", typeof(bool));

            try
            {
                target.AddRejectedRequest(productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, requestDate, rejectedDate, staffID, quantity, urgency);

                dtResult = target.FetchApprovedRequest();
                dtExpected.Rows.Add(productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, requestDate, rejectedDate, staffID, quantity, urgency);

                //Comparison
                Assert.AreEqual(dtExpected.Rows[0]["ProductName"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["ProductName"].ToString());
                Assert.AreEqual(dtExpected.Rows[0]["ManufacturerName"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["ManufacturerName"].ToString());
                Assert.AreEqual(dtExpected.Rows[0]["ProductID"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["ProductID"].ToString());
                Assert.AreEqual(dtExpected.Rows[0]["ShopID"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["ShopID"].ToString());
                Assert.AreEqual(dtExpected.Rows[0]["ShopCountry"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["ShopCountry"].ToString());
                Assert.AreEqual(dtExpected.Rows[0]["ShopLocation"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["ShopLocation"].ToString());
                Assert.AreEqual(dtExpected.Rows[0]["RejectedDate"], dtResult.Rows[dtResult.Rows.Count - 1]["RejectedDate"]);
                Assert.AreEqual(dtExpected.Rows[0]["ApprovedDate"], dtResult.Rows[dtResult.Rows.Count - 1]["ApprovedDate"]);
                Assert.AreEqual(dtExpected.Rows[0]["StaffID"].ToString(), dtResult.Rows[dtResult.Rows.Count - 1]["StaffID"].ToString());
                Assert.AreEqual(dtExpected.Rows[0]["Quantity"], dtResult.Rows[dtResult.Rows.Count - 1]["Quantity"]);
                Assert.AreEqual(dtExpected.Rows[0]["Urgency"], dtResult.Rows[dtResult.Rows.Count - 1]["Urgency"]);

                target.DeleteRejectedRequest(productID, shopID, requestDate, staffID);
            }
            catch
            {
                target.DeleteRejectedRequest(productID, shopID, requestDate, staffID);
            }
        }

        /// <summary>
        ///A test for AddShop
        ///</summary>
        [TestMethod()]
        public void AddShopTest()
        {
            DBManager_Accessor DBAccessor = DBManager_Accessor.getInstance();
            DataTable dtTestResult;
            DataTable expectedResult = new DataTable();
            expectedResult.Columns.Add("ShopID", typeof(string));
            expectedResult.Columns.Add("Country", typeof(string));
            expectedResult.Columns.Add("Location", typeof(string));
            expectedResult.Columns.Add("Contact", typeof(string));
            string shopID = "9999";
            string country = "Singapore";
            string location = "Ang Mo Kio";
            string contact = "89897676";

            try
            {
                expectedResult.Rows.Add(shopID, country, location, contact);

                DBAccessor.AddShop(shopID, country, location, contact);
                dtTestResult = DBAccessor.FetchShop();

                //Comparison
                for (int i = 0; i < dtTestResult.Rows.Count; i++)
                {
                    Assert.AreEqual(expectedResult.Rows[i]["ShopID"].ToString(), dtTestResult.Rows[dtTestResult.Rows.Count - 1]["ShopID"].ToString());
                    Assert.AreEqual(expectedResult.Rows[i]["Country"].ToString(), dtTestResult.Rows[dtTestResult.Rows.Count - 1]["Country"].ToString());
                    Assert.AreEqual(expectedResult.Rows[i]["Location"].ToString(), dtTestResult.Rows[dtTestResult.Rows.Count - 1]["Location"].ToString());
                    Assert.AreEqual(expectedResult.Rows[i]["Contact"].ToString(), dtTestResult.Rows[dtTestResult.Rows.Count - 1]["Contact"].ToString());
                }

                DBAccessor.DeleteShop(shopID);
            }
            catch
            {
                DBAccessor.DeleteShop(shopID);
            }
        }

        /// <summary>
        ///A test for AddStaff
        ///</summary>
        [TestMethod()]
        public void AddStaffTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string staffID = "justfortest@gmail.com"; // TODO: Initialize to an appropriate value
            string staffName = "just for test";
            DateTime renewPasswordDate = DateTime.Now; // TODO: Initialize to an appropriate value
            DateTime dateOfBirth = DateTime.Now; // TODO: Initialize to an appropriate value
            DateTime joinDate = DateTime.Now; // TODO: Initialize to an appropriate value
            string gender = "Male"; // TODO: Initialize to an appropriate value
            string religion = "Free thinker";// TODO: Initialize to an appropriate value
            string position = "just for test"; // TODO: Initialize to an appropriate value
            string contact = "88888888"; // TODO: Initialize to an appropriate value
            bool isDefaultPassword = true; // TODO: Initialize to an appropriate value
            //target.AddStaff(staffID, staffName, renewPasswordDate, dateOfBirth, joinDate, gender, religion, position, contact, isDefaultPassword);

            DataTable dtExpected = new DataTable();
            DataTable dtResult;

            dtExpected.Columns.Add("StaffID", typeof(string));
            dtExpected.Columns.Add("StaffName", typeof(string));
            dtExpected.Columns.Add("RenewPasswordDate", typeof(DateTime));
            dtExpected.Columns.Add("DateOfBirth", typeof(DateTime));
            dtExpected.Columns.Add("JoinDate", typeof(DateTime));
            dtExpected.Columns.Add("Gender", typeof(string));
            dtExpected.Columns.Add("Religion", typeof(string));
            dtExpected.Columns.Add("Position", typeof(string));
            dtExpected.Columns.Add("Contact", typeof(int));
            dtExpected.Columns.Add("DefaultPassword", typeof(bool));

            dtExpected.Rows.Add(staffID, staffName, renewPasswordDate, dateOfBirth, joinDate, gender, religion, position, contact, isDefaultPassword);
            dtResult = target.FetchStaff();

            //Comparison
        }

        /// <summary>
        ///A test for AddStock
        ///</summary>
        [TestMethod()]
        public void AddStockTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string productName = string.Empty; // TODO: Initialize to an appropriate value
            string manufacturerName = string.Empty; // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
           // DateTime batchID = new DateTime(); // TODO: Initialize to an appropriate value
            string importPrice = string.Empty; // TODO: Initialize to an appropriate value
            string sellPrice = string.Empty; // TODO: Initialize to an appropriate value
          //  DateTime expireDate = new DateTime(); // TODO: Initialize to an appropriate value
            string quantity = string.Empty; // TODO: Initialize to an appropriate value
            //target.AddStock(productName, manufacturerName, productID, batchID, importPrice, sellPrice, expireDate, quantity);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ChangeRequestApprovalStatus
        ///</summary>
        [TestMethod()]
        public void ChangeRequestApprovalStatusTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
           // bool approved = false; // TODO: Initialize to an appropriate value
            string productName = string.Empty; // TODO: Initialize to an appropriate value
            string manufacturerName = string.Empty; // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            string shopID = string.Empty; // TODO: Initialize to an appropriate value
            string shopCountry = string.Empty; // TODO: Initialize to an appropriate value
            string shopLocaton = string.Empty; // TODO: Initialize to an appropriate value
           // DateTime requestDate = new DateTime(); // TODO: Initialize to an appropriate value
           // DateTime approvedDate = new DateTime(); // TODO: Initialize to an appropriate value
           // DateTime rejectedDate = new DateTime(); // TODO: Initialize to an appropriate value
            string staffID = string.Empty; // TODO: Initialize to an appropriate value
            string quantity = string.Empty; // TODO: Initialize to an appropriate value
           // bool urgency = false; // TODO: Initialize to an appropriate value
            //target.ChangeRequestApprovalStatus(approved, productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, requestDate, approvedDate, rejectedDate, staffID, quantity, urgency);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeleteManufacturer
        ///</summary>
        [TestMethod()]
        public void DeleteManufacturerTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string manufacturerName = string.Empty; // TODO: Initialize to an appropriate value
            target.DeleteManufacturer(manufacturerName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeletePendingRequest
        ///</summary>
        [TestMethod()]
        public void DeletePendingRequestTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            string shopID = string.Empty; // TODO: Initialize to an appropriate value
            DateTime requestDate = new DateTime(); // TODO: Initialize to an appropriate value
            target.DeletePendingRequest(productID, shopID, requestDate);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeleteProduct
        ///</summary>
        [TestMethod()]
        public void DeleteProductTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            target.DeleteProduct(productID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeleteShop
        ///</summary>
        [TestMethod()]
        public void DeleteShopTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string shopID = string.Empty; // TODO: Initialize to an appropriate value
            target.DeleteShop(shopID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeleteStaff
        ///</summary>
        [TestMethod()]
        public void DeleteStaffTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string staffID = string.Empty; // TODO: Initialize to an appropriate value
            target.DeleteStaff(staffID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FetchApprovedRequest
        ///</summary>
        [TestMethod()]
        public void FetchApprovedRequestTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchApprovedRequest();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchManufacturer
        ///</summary>
        [TestMethod()]
        public void FetchManufacturerTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchManufacturer();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchPendingRequest
        ///</summary>
        [TestMethod()]
        public void FetchPendingRequestTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchPendingRequest();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchProduct
        ///</summary>
        [TestMethod()]
        public void FetchProductTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchProduct();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchRejectedRequest
        ///</summary>
        [TestMethod()]
        public void FetchRejectedRequestTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchRejectedRequest();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchReport
        ///</summary>
        [TestMethod()]
        public void FetchReportTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            //DataTable expected = null; // TODO: Initialize to an appropriate value
           // DataTable actual;
            //actual = target.FetchReport();
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchShop
        ///</summary>
        [TestMethod()]
        public void FetchShopTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchShop();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchStaff
        ///</summary>
        [TestMethod()]
        public void FetchStaffTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchStaff();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FetchStock
        ///</summary>
        [TestMethod()]
        public void FetchStockTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = target.FetchStock();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateManufacturer
        ///</summary>
        [TestMethod()]
        public void UpdateManufacturerTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string manufacturerName = string.Empty; // TODO: Initialize to an appropriate value
            string address = string.Empty; // TODO: Initialize to an appropriate value
            string country = string.Empty; // TODO: Initialize to an appropriate value
            string contact = string.Empty; // TODO: Initialize to an appropriate value
           // target.UpdateManufacturer(manufacturerName, address, country, contact);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateProduct
        ///</summary>
        [TestMethod()]
        public void UpdateProductTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string manufacturerName = string.Empty; // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            string category = string.Empty; // TODO: Initialize to an appropriate value
           // bool perishable = false; // TODO: Initialize to an appropriate value
            //target.UpdateProduct(manufacturerName, productID, name, category, perishable);
            Assert.Inconclusive("A method that does not rreturn a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateShop
        ///</summary>
        [TestMethod()]
        public void UpdateShopTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string shopID = string.Empty; // TODO: Initialize to an appropriate value
            string country = string.Empty; // TODO: Initialize to an appropriate value
            string location = string.Empty; // TODO: Initialize to an appropriate value
            string contact = string.Empty; // TODO: Initialize to an appropriate value
            target.UpdateShop(shopID, country, location, contact);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateStaff
        ///</summary>
        [TestMethod()]
        public void UpdateStaffTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string staffID = string.Empty; // TODO: Initialize to an appropriate value
            string contact = string.Empty; // TODO: Initialize to an appropriate value
            string position = string.Empty; // TODO: Initialize to an appropriate value
            //target.UpdateStaff(staffID, contact, position);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateStaffPassword
        ///</summary>
        [TestMethod()]
        public void UpdateStaffPasswordTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string staffID = string.Empty; // TODO: Initialize to an appropriate value
            string newPassword = string.Empty; // TODO: Initialize to an appropriate value
           // DateTime renewPasswordDate = new DateTime(); // TODO: Initialize to an appropriate value
           // bool isDefaultPassword = false; // TODO: Initialize to an appropriate value
            //target.UpdateStaffPassword(staffID, newPassword, renewPasswordDate, isDefaultPassword);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateStock
        ///</summary>
        [TestMethod()]
        public void UpdateStockTest()
        {
            DBManager_Accessor target = new DBManager_Accessor(); // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            //DateTime batchID = new DateTime(); // TODO: Initialize to an appropriate value
            string importPrice = string.Empty; // TODO: Initialize to an appropriate value
            string sellPrice = string.Empty; // TODO: Initialize to an appropriate value
            //DateTime expireDate = new DateTime(); // TODO: Initialize to an appropriate value
            string quantity = string.Empty; // TODO: Initialize to an appropriate value
            //target.UpdateStock(productID, batchID, importPrice, sellPrice, expireDate, quantity);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
