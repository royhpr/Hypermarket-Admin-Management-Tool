using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

/***********************************************
 * This API Manages the flows from the views to individual managers. It's basically a flow controller.
 * 
 * Methods:
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * @Auther: Huang Purong
 * @Date: 27/08/2013
 * *********************************************/

namespace Hypermarket_Admin_Management_Tool._2_Controller
{
    class CoordinatingController
    {
        private static CoordinatingController instance;
        private ProductManager productController = new ProductManager();
        private AccountManager accountController = new AccountManager();
        private SalesManager salesController = new SalesManager();
        private ShopsManager shopsController = new ShopsManager();
        private WarehouseManager warehouseController = new WarehouseManager();


        private CoordinatingController()
        {
            
        }

        public static CoordinatingController getInstance()
        {
            if (instance == null)
            {
                instance = new CoordinatingController();
            }
            return instance;
        }

        #region Product Manager

        public DataTable GetListOfProduct()
        {
            try
            {
                return productController.FetchProduct();
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.PRODUCT_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.PRODUCT_TABLE);
            }
        }

        public void AddNewProduct(string manufacturerName, string productID, string name, string category, string maxStock, string minStock)
        {
            try
            {
                productController.AddProduct(manufacturerName, productID, name, category, maxStock, minStock);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_ADD + Constant.PRODUCT_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_ADD + Constant.PRODUCT_TABLE);
            }
        }

        public void DeleteExistingProduct(string productID)
        {
            try
            {
                productController.DeleteProduct(productID);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_DELETE + Constant.PRODUCT_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_DELETE + Constant.PRODUCT_TABLE);
            }
        }

        public void UpdateExistingProduct(string productID, string manufacturerName, string name, string category, string maxStock, string minStock)
        {
            try
            {
                productController.UpdateProduct(manufacturerName, productID, name, category, maxStock, minStock);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_UPDATE + Constant.PRODUCT_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_UPDATE + Constant.PRODUCT_TABLE);
            }
        }

        public string GenerateNextAvailableProductID()
        {
            try
            {
                return productController.GenerateNextAvailableProductID();
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_GENERATE_PRODUCT_ID + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_GENERATE_PRODUCT_ID);
            }
        }

        public bool IsProductAllowedDeletion(string productID)
        {
            try
            {
                return productController.IsProductAllowedDeletion(productID);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(Constant.ERROR_PRODUCT_CHECK_STOCK + Constant.ACTUAL_ERROR + ex.Message);
                throw new Exception(Constant.ERROR_PRODUCT_CHECK_STOCK);
            }
        }

        public DataTable GetListOfManufacturer()
        {
            try
            {
                return productController.FetchManufacturer();
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.MANUFACTURER_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.MANUFACTURER_TABLE);
            }
        }

        public void AddNewManufacturer(string manufacturerName, string address, string country, string contact)
        {
            try
            {
                productController.AddManufacturer(manufacturerName, address, country, contact);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_ADD + Constant.MANUFACTURER_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_ADD + Constant.MANUFACTURER_TABLE);
            }
        }

        public void DeleteExistingManufacturer(string manufacturerName)
        {
            try
            {
                productController.DeleteManufacturer(manufacturerName);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_DELETE + Constant.MANUFACTURER_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_DELETE + Constant.MANUFACTURER_TABLE);
            }
        }

        public void UpdateExistingManufacturer(string manufacturerName, string address, string country, string contact)
        {
            try
            {
                productController.UpdateManufacturer(manufacturerName, address, country, contact);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_UPDATE + Constant.MANUFACTURER_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_UPDATE + Constant.MANUFACTURER_TABLE);
            }
        }
      
        #endregion

        #region  Sales Manager

        #region Report

        public DataTable GetListOfReport()
        {
            try
            {
                return salesController.FetchReport();;
            }
            catch(Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.REPORT_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.REPORT_TABLE);
            }
        }

        public DataTable FetchYearlySummary(string startDate, string endDate)
        {
            return salesController.FetchYearlySummary(startDate, endDate);
        }

        public DataTable FetchYearlyProduct(string startDate, string endDate)
        {
            return salesController.FetchYearlyProduct(startDate, endDate);
        }

        public DataTable FetchYearlyShop(string startDate, string endDate)
        {
            return salesController.FetchYearlyShop(startDate, endDate);
        }

        public DataTable FetchMonthlySummary(DateTime startDate, DateTime endDate)
        {
            return salesController.FetchMonthlySummary(startDate, endDate);
        }

        public DataTable FetchMonthlyProduct(DateTime startDate, DateTime endDate)
        {
            return salesController.FetchMonthlyProduct(startDate, endDate);
        }

        public DataTable FetchMonthlyShop(DateTime startDate, DateTime endDate)
        {
            return salesController.FetchMonthlyShop(startDate, endDate);
        }

        public DataTable FetchDailySummary(DateTime startDate, DateTime endDate)
        {
            return salesController.FetchDailySummary(startDate, endDate);
        }

        public DataTable FetchDailyProduct(DateTime startDate, DateTime endDate)
        {
            return salesController.FetchDailyProduct(startDate, endDate);
        }

        public DataTable FetchDailyShop(DateTime startDate, DateTime endDate)
        {
            return salesController.FetchDailyShop(startDate, endDate);
        }

        #endregion

        #region Discount

        public DataTable GetListOfDiscountPolicy()
        {
            try
            {
                return salesController.FetchDiscount();
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.DISCOUNT_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.DISCOUNT_TABLE);
            }
        }

        public void AddDiscountPolicy(string productName, string manufacturer, string productID, DateTime effectiveDate, string bundleUnit, string freeItemQuantity, string discount)
        {
            try
            {
                salesController.AddDiscountPolicy(productName, manufacturer, productID, effectiveDate, bundleUnit, freeItemQuantity, discount);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_ADD + Constant.DISCOUNT_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_ADD + Constant.DISCOUNT_TABLE);
            }
        }

        public void DeleteDiscountPolicy(string productID)
        {
            try
            {
                salesController.DeleteDiscountPolicy(productID);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_DELETE + Constant.DISCOUNT_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_DELETE + Constant.DISCOUNT_TABLE);
            }
        }

        public void UpdateDiscountPolicy(string productID, DateTime effectiveDate, string unitBundle, string freeItemQuantity, string discount)
        {
            try
            {
                salesController.UpdateDiscountPolicy(productID, effectiveDate, unitBundle, freeItemQuantity, discount);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_UPDATE + Constant.DISCOUNT_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_UPDATE + Constant.DISCOUNT_TABLE);
            }
        }

        #endregion

        #endregion

        #region ShopsManager

        public DataTable GetListOfShops()
        {
            try
            {
                return shopsController.FetchShop();
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.SHOP_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.SHOP_TABLE);
            }
        }

        public void AddShop(string shopID, string country, string location, string contact)
        {
            try
            {
                shopsController.AddShop(shopID, country, location, contact);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_ADD + Constant.SHOP_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_ADD + Constant.SHOP_TABLE);
            }
        }

        public void DeleteShop(string shopID)
        {
            try
            {
                shopsController.DeleteShop(shopID);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_DELETE + Constant.SHOP_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_DELETE + Constant.SHOP_TABLE);
            }
        }

        public void UpdateShop(string shopID, string country, string location, string contact)
        {
            try
            {
                shopsController.UpdateShop(shopID, country, location, contact);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_UPDATE + Constant.SHOP_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_UPDATE + Constant.SHOP_TABLE);
            }
        }

        public string GenerateNextAvailableShopID()
        {
            try
            {
                return shopsController.GenerateNextAvailableShopID();
            }
            catch(Exception e)
            {
                ErrorLog.Log(Constant.ERROR_GENERATE_SHOP_ID + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_GENERATE_SHOP_ID);
            }
        }

        #endregion

        #region Warehouse Manager

        public DataTable GetListOfStock()
        {
            try
            {
                return warehouseController.FetchStock();
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.STOCK_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.STOCK_TABLE);
            }
        }

        public void AddStock(string productName, string manufacturerName, string productID, DateTime batchID, string importPrice, string sellPrice, DateTime expireDate, string quantity)
        {
            try
            {
                warehouseController.AddStock(productName, manufacturerName, productID, batchID, importPrice, sellPrice, expireDate, quantity);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_ADD + Constant.STOCK_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_ADD + Constant.STOCK_TABLE);
            }
        }

        public void UpdateStock(string productID, DateTime batchID, string importPrice, string sellPrice, DateTime expireDate, string quantity)
        {
            try
            {
                warehouseController.UpdateStock(productID, batchID, importPrice, sellPrice, expireDate, quantity);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_UPDATE + Constant.STOCK_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_UPDATE + Constant.STOCK_TABLE);
            }
        }

        public void ReduceStockQuantity(string productID, DateTime batchID, string substractQuantity)
        {
            try
            {
                warehouseController.ReduceStockQuantity(productID, batchID, substractQuantity);
            }
            catch(Exception ex)
            {
                ErrorLog.Log(Constant.ERROR_UPDATE + Constant.STOCK_TABLE + Constant.ACTUAL_ERROR + ex.Message);
                throw new Exception(Constant.ERROR_UPDATE + Constant.STOCK_TABLE);
            }
        }

        public DataTable GetListOfPendingRequest()
        {
            try
            {
                return warehouseController.FetchPendingRequest();
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.PENDING_REQUEST_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.PENDING_REQUEST_TABLE);
            }
        }

        public DataTable GetListOfApprovedRequest()
        {
            try
            {
                return warehouseController.FetchApprovedRequest();
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.APPROVED_REQUEST_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.APPROVED_REQUEST_TABLE);
            }
        }

        public DataTable GetListOfRejectedRequest()
        {
            try
            {
                return warehouseController.FetchRejectedRequest();
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.REJECTED_REQUEST_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.REJECTED_REQUEST_TABLE);
            }
        }

        public DataTable GetListOfOngoingRequest()
        {
            try
            {
                return warehouseController.FetchSendStock();
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.SEND_STOCK_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.SEND_STOCK_TABLE);
            }
        }

        public ArrayList getLatestProductBatch(string productId)
        {
            try
            {
                return warehouseController.getLatestProductBatch(productId);
            }
            catch
            {
                throw;
            }
        }

        public void AddApprovedRequest(string productName, string manufacturerName, string productID, string shopID, string shopCountry, string shopLocaton, DateTime requestDate, DateTime approvedDate, string staffID, string quantity, string approvedQuantity, bool urgency, string comments)
        {
            try
            {
                warehouseController.AddApprovedRequest(productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, requestDate, approvedDate, staffID, quantity, approvedQuantity, urgency, comments);

            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_ADD + Constant.PENDING_REQUEST_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_ADD + Constant.PENDING_REQUEST_TABLE);
            }
        }

        public void AddRejectedRequest(string productName, string manufacturerName, string productID, string shopID, string shopCountry, string shopLocaton, DateTime requestDate, DateTime rejectedDate, string staffID, string quantity, bool urgency)
        {
            try
            {
                warehouseController.AddRejectedRequest(productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, requestDate, rejectedDate, staffID, quantity, urgency);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_ADD + Constant.REJECTED_REQUEST_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_ADD + Constant.REJECTED_REQUEST_TABLE);
            }
        }

        public void ChangeRequestStatus(bool approved, string productName, string manufacturerName, string productID, string shopID, string shopCountry, string shopLocaton, DateTime actionDate, DateTime rejectedDate, string staffID, string quantity, bool urgency)
        {
            try
            {
                warehouseController.ChangeRequestStatus(approved, productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, actionDate, rejectedDate, staffID, quantity, urgency);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_CHANGE_STATUS + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_CHANGE_STATUS);
            }
        }

        public void AddOutgoingRequest(string productName, string manufacturerName, string productID, DateTime batchID, string shopID, string shopCountry, string shopLocation, string quantity)
        {
            try
            {
                warehouseController.AddSendStock(productName, manufacturerName, productID, batchID, shopID, shopCountry, shopLocation, quantity);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_ADD + Constant.SEND_STOCK_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_ADD + Constant.SEND_STOCK_TABLE);
            }
        }

        public void DeleteOutgoingRequest(string productID, DateTime batchID, string shopID)
        {
            try
            {
                warehouseController.DeleteSendStock(productID, batchID, shopID);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_DELETE + Constant.SEND_STOCK_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_DELETE + Constant.SEND_STOCK_TABLE);
            }
        }

        public void UpdateOutgoingRequest(string productID, DateTime batchID, string shopID, DateTime confirmDate, DateTime sendDate, bool deliveryStatus)
        {
            try
            {
                warehouseController.UpdateSendStock(productID, batchID, shopID, confirmDate, sendDate, deliveryStatus);
            }
            catch(Exception ex)
            {
                ErrorLog.Log(Constant.ERROR_UPDATE + Constant.SEND_STOCK_TABLE + Constant.ACTUAL_ERROR + ex.Message);
                throw new Exception(Constant.ERROR_UPDATE + Constant.SEND_STOCK_TABLE);
            }
        }

        public void RefreshRequest()
        {
            try
            {
                warehouseController.RefreshRequest();
            }
            catch (Exception ex)
            {
                ErrorLog.Log(Constant.ERROR_REFRESH_REQUEST + Constant.ERROR_NEXT_ACTION + Constant.ACTUAL_ERROR + ex.Message);
                throw new Exception(Constant.ERROR_REFRESH_REQUEST + Constant.ERROR_NEXT_ACTION);
            }
        }

        #endregion

        #region Account Manager
        
        public bool IsValidUser(string staffID)
        {
            try
            {
                return accountController.IsValidUser(staffID);
            }
            catch(Exception e)
            {
                ErrorLog.Log(Constant.ERROR_VERIFYING_USER + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_VERIFYING_USER);
            }
        }

        public bool VerifyUserIdAndPassword(string staffID, string password)
        {
            try
            {
                return accountController.VerifyUserIdAndPassword(staffID, password);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_VERIFYING_PASSWORD + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_VERIFYING_PASSWORD);
            }
        }

        public bool RequireChangingPassword(string staffID)
        {
            try
            {
                return (accountController.IsFirstTimeLogin(staffID) || accountController.IsPasswordExpired(staffID));
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_CHECK_DEFAULT_PASSWORD + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_CHECK_DEFAULT_PASSWORD);
            }
        }

        public DataTable GetListOfStaff()
        {
            try
            {
                return accountController.FetchStaff();
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.STAFF_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.STAFF_TABLE);
            }
        }

        public void AddStaff(string staffID, string name, DateTime dateOfBirth, DateTime joinDate, string gender, string position, string contact)
        {
            try
            {
                accountController.AddStaff(staffID, name, dateOfBirth, joinDate, gender, position, contact);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_FETCH + Constant.STAFF_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_FETCH + Constant.STAFF_TABLE);
            }
        }

        public void DeleteStaff(string staffID)
        {
            try
            {
                accountController.DeleteStaff(staffID);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_DELETE + Constant.STAFF_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_DELETE + Constant.STAFF_TABLE);
            }
        }

        public void UpdateStaff(string staffID, string contact, string position, bool defaultPassword, bool blocked)
        {
            try
            {
                accountController.UpdateStaff(staffID, contact, position, defaultPassword, blocked);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_UPDATE + Constant.STAFF_TABLE + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_UPDATE + Constant.STAFF_TABLE);
            }
        }

        public void ChangePassword(string staffID, string password)
        {
            try
            {
                accountController.ChangePassword(staffID, password);
            }
            catch (Exception e)
            {
                ErrorLog.Log(Constant.ERROR_UPDATE_PASSWORD + Constant.ACTUAL_ERROR + e.Message);
                throw new Exception(Constant.ERROR_UPDATE_PASSWORD);
            }
        }

        public void ResetPassword(string staffID)
        {
            accountController.ResetPassword(staffID);
        }

        public void BlockStaff()
        {
        }

        #endregion
    }
}
