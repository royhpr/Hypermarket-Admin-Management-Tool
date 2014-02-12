using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

/****************************************
 *The class is responsible for managing stock and approving or rejecting request from outlets
 *
 * Methods:
 * public void AddStock(string prodcutName, string manufacturerName, string productID, DateTime batchID, string importPrice, string sellPrice, DateTime expireDate, string quantity)
 * public void UpdateStock(string productID, DateTime batchID, string importPrice, string sellPrice, DateTime expireDate, string quantity)
 * public DataTable FetchStock()
 * public DataTable FetchPendingRequest()
 * public void DeletePendingRequest(string productID, string shopID, DateTime requestDate)
 * public void AddApprovedRequest(string productName, string manufacturerName, string productID, string shopID, string shopCountry, string shopLocaton, DateTime requestDate, DateTime approvedDate, string staffID, string quantity, bool urgency)
 * public DataTable FetchApprovedRequest()
 * public void AddRejectedRequest(string productName, string manufacturerName, string productID, string shopID, string shopCountry, string shopLocaton, DateTime requestDate, DateTime rejectedDate, string staffID, string quantity, bool urgency)
 * public DataTable FetchRejectedRequest()
 * public void ChangeRequestStatus(bool approved, string productName, string manufacturerName, string productID, string shopID, string shopCountry, string shopLocaton, DateTime requestDate, DateTime approvedDate, DateTime rejectedDate, string staffID, string quantity, bool urgency)
 * public void AddSendStock(string productName, string manufacturerName, string productID, DateTime batchID, string shopID, string shopCountry, string shopLocation, DateTime sendDate, string quantity, bool deliveryStatus)
 * public DataTable FetchSendStock()
 * public void DeleteSendStock(string productID, DateTime batchID, string shopID)
 * 
 * @Auther:
 * @Date:
 * *****************************************/

namespace Hypermarket_Admin_Management_Tool._2_Controller
{
    class WarehouseManager
    {
        private _1_Model.DBManager DBController = _1_Model.DBManager.getInstance();


        #region All about stock

        public void AddStock(string prodcutName, string manufacturerName, string productID, DateTime batchID, 
                            string importPrice, string sellPrice, DateTime expireDate, string quantity)
        {
            try
            {
                DBController.AddStock(prodcutName, manufacturerName, productID, batchID, importPrice, sellPrice, expireDate, quantity, true);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateStock(string productID, DateTime batchID, string importPrice, string sellPrice, DateTime expireDate, string quantity)
        {
            try
            {
                DBController.UpdateStock(productID, batchID, importPrice, sellPrice, expireDate, quantity);
            }
            catch
            {
                throw;
            }  
        }

        public ArrayList getLatestProductBatch(string productID)
        {
            try
            {
                return DBController.getLatestBatchInfo(productID);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FetchStock()
        {
            try
            {
                return DBController.FetchStock();
            }
            catch
            {
                throw;
            }
        }

        public void ReduceStockQuantity(string productID, DateTime batchID, string substractQuantity)
        {
            try
            {
                DBController.ReduceStockQuantity(productID, batchID, substractQuantity);
            }
            catch
            {
                throw;
            }
        }

        #endregion


        #region All About Request

        public DataTable FetchPendingRequest()
        {
            try
            {
                return DBController.FetchPendingRequest();
            }
            catch
            {
                throw;
            }
        }

        public void AddApprovedRequest(string productName, string manufacturerName, string productID, string shopID, string shopCountry,
                        string shopLocation, DateTime requestDate, DateTime approvedDate, string staffID, string quantity, string approvedQuantity, bool urgency, string comments)
        {
            try
            {
                DBController.AddApprovedRequest(productName, manufacturerName, productID, shopID, shopCountry,shopLocation, requestDate,
                                                approvedDate, staffID, quantity, approvedQuantity, urgency, comments);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FetchApprovedRequest()
        {
            try
            {
                return DBController.FetchApprovedRequest();
            }
            catch
            {
                throw;
            }
        } 

        public void AddRejectedRequest(string productName, string manufacturerName, string productID, string shopID, string shopCountry, 
                        string shopLocation, DateTime requestDate, DateTime rejectedDate, string staffID, string quantity, bool urgency)
        {
            try
            {
                DBController.AddRejectedRequest(productName, manufacturerName, productID, shopID, shopCountry, shopLocation,
                                requestDate, rejectedDate, staffID, quantity, urgency);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FetchRejectedRequest()
        {
            try
            {
                return DBController.FetchRejectedRequest();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ChangeRequestStatus(bool approved, string productName, string manufacturerName, string productID,
                            string shopID, string shopCountry, string shopLocaton, DateTime requestDate, DateTime actionDate, string staffID, string quantity, bool urgency)
        {
            try
            {
                DBController.ChangeRequestApprovalStatus(approved, productName, manufacturerName, productID, shopID, shopCountry, shopLocaton,
                                                    requestDate, actionDate, staffID, quantity, urgency);
            }
            catch
            {
                throw;
            }
        }

        public void RefreshRequest()
        {
            try
            {
                DBController.RefreshRequest();
            }
            catch
            {
                throw;
            }
        }

        #endregion


        #region All About Send Stock

        public void AddSendStock(string productName, string manufacturerName, string productID, DateTime batchID, string shopID, 
                                string shopCountry, string shopLocation, string quantity)
        {
            try
            {
                DBController.AddSendStock(productName, manufacturerName, productID, batchID, shopID, 
                                        shopCountry, shopLocation, quantity);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FetchSendStock()
        {
            try
            {
                return DBController.FetchSendStock();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteSendStock(string productID, DateTime batchID, string shopID)
        {
            try
            {
                DBController.DeleteSendStock(productID, batchID, shopID);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateSendStock(string productID, DateTime batchID, string shopID, DateTime confirmDate, DateTime sendDate, bool deliveryStatus)
        {
            try
            {
                DBController.UpdateSendStock(productID, batchID, shopID, confirmDate, sendDate, deliveryStatus);
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
