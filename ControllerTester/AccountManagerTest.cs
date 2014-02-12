using Hypermarket_Admin_Management_Tool._2_Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace ControllerTester
{
    
    
    /// <summary>
    ///This is a test class for AccountManagerTest and is intended
    ///to contain all AccountManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AccountManagerTest
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
        ///A test for AccountManager Constructor
        ///</summary>
        [TestMethod()]
        public void AccountManagerConstructorTest()
        {
            AccountManager target = new AccountManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddStaff
        ///</summary>
        [TestMethod()]
        public void AddStaffTest()
        {
            AccountManager_Accessor target = new AccountManager_Accessor(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            string staffID = "a00@nus.edu.sg";
            DBController.DeleteStaff(staffID);
            DataTable expectedResult = setupExpectedResultTable();
            storeInfoIntoExpectedTables(expectedResult, staffID);
            storeInfoIntoTargetTables(target, staffID);
            DataTable targetResult = DBController.FetchStaff();
            DataRow expectedRow = expectedResult.Rows[expectedResult.Rows.Count - 1];
            DataRow targetRow = targetResult.Rows[targetResult.Rows.Count - 1];

            Assert.AreEqual(expectedRow["StaffID"].ToString(), targetRow["StaffID"].ToString());
            Assert.AreEqual(expectedRow["Name"].ToString(), targetRow["Name"].ToString());
            Assert.AreEqual(expectedRow["Password"].ToString(), targetRow["Password"].ToString());
            Assert.AreEqual(expectedRow["RenewPasswordDate"].ToString(), targetRow["RenewPasswordDate"].ToString());
            Assert.AreEqual(expectedRow["JoinDate"].ToString(), targetRow["JoinDate"].ToString());
            Assert.AreEqual(expectedRow["Gender"].ToString(), targetRow["Gender"].ToString());
            Assert.AreEqual(expectedRow["Religion"].ToString(), targetRow["Religion"].ToString());
            Assert.AreEqual(expectedRow["Position"].ToString(), targetRow["Position"].ToString());
            Assert.AreEqual(expectedRow["Contact"].ToString(), targetRow["Contact"].ToString());
            Assert.AreEqual(expectedRow["DefaultPassword"].ToString(), targetRow["DefaultPassword"].ToString());
            Assert.AreEqual(expectedRow["IsValidLogin"].ToString(), targetRow["IsValidLogin"].ToString());
            DBController.DeleteStaff(staffID);
        }

        /// <summary>
        ///A test for ChangePassword
        ///</summary>
        [TestMethod()]
        public void ChangePasswordTest()
        {
            AccountManager_Accessor target = new AccountManager_Accessor();
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            Hypermarket_Admin_Management_Tool._2_Controller.SecurityManager_Accessor SecurityController =
                                                        Hypermarket_Admin_Management_Tool._2_Controller.SecurityManager_Accessor.getInstance();
            string staffID = "a00@nus.edu.sg";
            string password = "test12345";
            DBController.DeleteStaff(staffID);
            DataTable expectedResult = setupExpectedResultTable();
            storeInfoIntoExpectedTables(expectedResult, staffID);
            storeInfoIntoTargetTables(target, staffID);
            target.ChangePassword(staffID, password);
            DataRow expectedRow = expectedResult.Rows[expectedResult.Rows.Count - 1];
            expectedRow["password"] = SecurityController.ComplexEncrypt(password);
            DataTable targetResult = DBController.FetchStaff();
            DataRow targetRow = targetResult.Rows[targetResult.Rows.Count - 1];
            Assert.AreEqual(expectedRow["StaffID"].ToString(), targetRow["StaffID"].ToString());
            Assert.AreEqual(expectedRow["password"].ToString(), targetRow["password"].ToString());
            DBController.DeleteStaff(staffID);
        }

        /// <summary>
        ///A test for DeleteStaff
        ///</summary>
        [TestMethod()]
        public void DeleteStaffTest()
        {
            AccountManager_Accessor target = new AccountManager_Accessor(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            string staffID = "a00@nus.edu.sg";
            DBController.DeleteStaff(staffID);
            DataTable expected = setupExpectedResultTable();
            expected = DBController.FetchStaff();
            storeInfoIntoTargetTables(target, staffID);
            target.DeleteStaff(staffID);
            DataTable actual = DBController.FetchStaff(); 
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FetchStaff
        ///</summary>
        [TestMethod()]
        public void FetchStaffTest()
        {
            AccountManager_Accessor target = new AccountManager_Accessor(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            DataTable expected = DBController.FetchStaff();
            DataTable actual = target.FetchStaff();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsFirstTimeLogin
        ///</summary>
        [TestMethod()]
        public void IsFirstTimeLoginTest()
        {
            AccountManager_Accessor target = new AccountManager_Accessor(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            string staffID = "a00@nus.edu.sg";
            DBController.DeleteStaff(staffID);
            storeInfoIntoTargetTables(target, staffID);
            bool expected = true;
            bool actual;
            actual = target.IsFirstTimeLogin(staffID);
            Assert.AreEqual(expected, actual);
            DBController.DeleteStaff(staffID);
        }

        /// <summary>
        ///A test for IsPasswordExpired
        ///</summary>
        [TestMethod()]
        public void IsPasswordExpiredTest()
        {
            AccountManager_Accessor target = new AccountManager_Accessor();
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();

            string staffID = "a00@nus.edu.sg";
            DBController.DeleteStaff(staffID);
            storeInfoIntoTargetTables(target, staffID);
            bool expected = false;
            bool actual;
            actual = target.IsPasswordExpired(staffID);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsValidUser
        ///</summary>
        [TestMethod()]
        public void IsValidUserTest()
        {
            AccountManager_Accessor target = new AccountManager_Accessor(); // TODO: Initialize to an appropriate value
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            string staffID = "a00@nus.edu.sg";
            DBController.DeleteStaff(staffID);
            storeInfoIntoTargetTables(target, staffID);
            bool expected = true;
            bool actual;
            actual = target.IsValidUser(staffID);
            Assert.AreEqual(expected, actual);

            DBController.DeleteStaff(staffID);
            expected = false;
            actual = target.IsValidUser(staffID);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsValidLogin
        ///</summary>
        [TestMethod()]
        public void IsValidLoginTest()
        {
            AccountManager_Accessor target = new AccountManager_Accessor(); 
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();

            string staffID = "a00@nus.edu.sg";
            DBController.DeleteStaff(staffID);
            storeInfoIntoTargetTables(target, staffID);
            bool expected = true; 
            bool actual;
            actual = target.IsBlocked(staffID);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for UpdateStaff
        ///</summary>
        [TestMethod()]
        public void UpdateStaffTest()
        {
            AccountManager_Accessor target = new AccountManager_Accessor();
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            string staffID = staffID = "a00@nus.edu.sg";
            DBController.DeleteStaff(staffID);
            DataTable expectedResult = setupExpectedResultTable();;
           // string name = "CG3002"; // TODO: Initialize to an appropriate value
            //string password = Hypermarket_Admin_Management_Tool.Constant_Accessor.DEFAULT_PASSWORD;
            DateTime renewPasswordDate = DateTime.Today.AddDays(180).Date;
            DateTime dateOfBirth = new DateTime(2000, 12, 12); // TODO: Initialize to an appropriate value
            DateTime joinDate = new DateTime(2012, 8, 1); // TODO: Initialize to an appropriate value
           // string gender = "male"; // TODO: Initialize to an appropriate value
          //  string religion = "N.A"; // TODO: Initialize to an appropriate value
            string position = "Manager"; // TODO: Initialize to an appropriate value
            string contact = "+6589896464"; // TODO: Initialize to an appropriate value
           // bool IsDefaultPassword = true;
           // bool IsValidLogin = true;  
            //expectedResult.Rows.Add(staffID, name, password, renewPasswordDate, dateOfBirth.Date,
                   //                 joinDate.Date, gender, religion, position, contact, IsDefaultPassword, IsValidLogin);
            storeInfoIntoTargetTables(target, staffID);
            DataTable targetResult = DBController.FetchStaff();
            contact = "6511110000";
            position = "CEO";
            //target.UpdateStaff(staffID, contact, position);
            DataRow expectedRow  = expectedResult.Rows[expectedResult.Rows.Count - 1];
            DataRow targetRow = targetResult.Rows[targetResult.Rows.Count - 1];
            Assert.AreEqual(expectedRow["StaffID"].ToString(), targetRow["StaffID"].ToString());
            Assert.AreEqual(expectedRow["Name"].ToString(), targetRow["Name"].ToString());
            Assert.AreEqual(expectedRow["Password"].ToString(), targetRow["Password"].ToString());
            Assert.AreEqual(expectedRow["RenewPasswordDate"].ToString(), targetRow["RenewPasswordDate"].ToString());
            Assert.AreEqual(expectedRow["JoinDate"].ToString(), targetRow["JoinDate"].ToString());
            Assert.AreEqual(expectedRow["Gender"].ToString(), targetRow["Gender"].ToString());
            Assert.AreEqual(expectedRow["Religion"].ToString(), targetRow["Religion"].ToString());
            Assert.AreEqual(position, targetRow["Position"].ToString());
            Assert.AreEqual(contact, targetRow["Contact"].ToString());
            Assert.AreEqual(expectedRow["DefaultPassword"].ToString(), targetRow["DefaultPassword"].ToString());
            Assert.AreEqual(expectedRow["IsValidLogin"].ToString(), targetRow["IsValidLogin"].ToString());
            DBController.DeleteStaff(staffID);
        }

        /// <summary>
        ///A test for VerifyUserIdAndPassword
        ///</summary>
        [TestMethod()]
        public void VerifyUserIdAndPasswordTest()
        {
            AccountManager_Accessor target = new AccountManager_Accessor();
            Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor DBController =
                                                        Hypermarket_Admin_Management_Tool._1_Model.DBManager_Accessor.getInstance();
            Hypermarket_Admin_Management_Tool._2_Controller.SecurityManager_Accessor SecurityController =
                                                        Hypermarket_Admin_Management_Tool._2_Controller.SecurityManager_Accessor.getInstance();
            string staffID = "a00@nus.edu.sg";
            DBController.DeleteStaff(staffID);
            string password = "12345678";
            storeInfoIntoTargetTables(target, staffID);
            bool expected = true;
            bool actual;
            actual = target.VerifyUserIdAndPassword(staffID, password);
            Assert.AreEqual(expected, actual);
            DBController.DeleteStaff(staffID);
        }

        #region store Info

        private static void storeInfoIntoExpectedTables(DataTable expectedResult, string staffID)
        {

           // string name = "CG3002"; // TODO: Initialize to an appropriate value
           // string password = Hypermarket_Admin_Management_Tool.Constant_Accessor.DEFAULT_PASSWORD;
            DateTime renewPasswordDate = DateTime.Today.AddDays(180).Date;
            DateTime dateOfBirth = new DateTime(2000, 12, 12); // TODO: Initialize to an appropriate value
            DateTime joinDate = new DateTime(2012, 8, 1); // TODO: Initialize to an appropriate value
            //string gender = "male"; // TODO: Initialize to an appropriate value
            //string religion = "N.A"; // TODO: Initialize to an appropriate value
           // string position = "Manager"; // TODO: Initialize to an appropriate value
           // string contact = "+6589896464"; // TODO: Initialize to an appropriate value
           // bool IsDefaultPassword = true;
           // bool IsValidLogin = true;
           // expectedResult.Rows.Add(staffID, name, password, renewPasswordDate, dateOfBirth.Date,
                        //            joinDate.Date, gender, religion, position, contact, IsDefaultPassword, IsValidLogin);
        }

        private static void storeInfoIntoTargetTables(AccountManager_Accessor target, string staffID)
        {
            //string name = "CG3002"; // TODO: Initialize to an appropriate value
           // string password = Hypermarket_Admin_Management_Tool.Constant_Accessor.DEFAULT_PASSWORD;
            DateTime renewPasswordDate = DateTime.Today.AddDays(180).Date;
            DateTime dateOfBirth = new DateTime(2000, 12, 12); // TODO: Initialize to an appropriate value
            DateTime joinDate = new DateTime(2012, 8, 1); // TODO: Initialize to an appropriate value
            //string gender = "male"; // TODO: Initialize to an appropriate value
            //string religion = "N.A"; // TODO: Initialize to an appropriate value
            //string position = "Manager"; // TODO: Initialize to an appropriate value
            //string contact = "+6589896464"; // TODO: Initialize to an appropriate value
            //target.AddStaff(staffID, name, dateOfBirth, joinDate, gender, religion, position, contact);
        }

        private static DataTable setupExpectedResultTable()
        {
            DataTable expectedResult = new DataTable();
            expectedResult.Columns.Add("StaffID", typeof(string));
            expectedResult.Columns.Add("Name", typeof(string));
            expectedResult.Columns.Add("Password", typeof(string));
            expectedResult.Columns.Add("RenewPasswordDate", typeof(DateTime));
            expectedResult.Columns.Add("DateOfBirth", typeof(DateTime));
            expectedResult.Columns.Add("JoinDate", typeof(DateTime));
            expectedResult.Columns.Add("Gender", typeof(string));
            expectedResult.Columns.Add("Religion", typeof(string));
            expectedResult.Columns.Add("Position", typeof(string));
            expectedResult.Columns.Add("Contact", typeof(string));
            expectedResult.Columns.Add("DefaultPassword", typeof(bool));
            expectedResult.Columns.Add("IsValidLogin", typeof(bool));
            return expectedResult;
        }

        #endregion
    }
}
