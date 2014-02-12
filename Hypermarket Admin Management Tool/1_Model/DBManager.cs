using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
/*********************************************
 * Handle database retirval and update
 * 
 * Methods:
 * 
 * 
 * 
 * @Author: Huang Purong
 * @Date: 26/08/2013
 * ********************************************/

namespace Hypermarket_Admin_Management_Tool._1_Model
{
    class DBManager
    {
        public static DBManager DBManagerInstance;
        private DBConnectionManager DBConn = DBConnectionManager.getInstance();
        private DataSet dsTableList = new DataSet();
        private SqlConnection SQLConn = new SqlConnection();

        private SqlDataAdapter shopAdapter;
        private SqlDataAdapter productAdapter;
        private SqlDataAdapter stockAdapter;
        private SqlDataAdapter sendStockAdapter;
        private SqlDataAdapter manufacturerAdapter;
        private SqlDataAdapter staffAdapter;
        private SqlDataAdapter reportAdapter;
        private SqlDataAdapter discountAdapter;
        private SqlDataAdapter pendingRequestAdapter;
        private SqlDataAdapter approvedRequestAdapter;
        private SqlDataAdapter rejectedRequestAdapter;

        private SqlCommandBuilder shopCommandBuilder;
        private SqlCommandBuilder productCommandBuilder;
        private SqlCommandBuilder manufacturerCommandBuilder;
        private SqlCommandBuilder staffCommandBuilder;
        private SqlCommandBuilder discountCommandBuilder;

        public static DBManager getInstance()
        {
            if (DBManagerInstance == null)
            {
                DBManagerInstance = new DBManager();
            }
            return DBManagerInstance;
        }

        private DBManager()
        {
            SQLConn.ConnectionString = DBConn.getConnectionString();
            try
            {
                using (SQLConn)
                {
                    SQLConn.Open();
                    InitializeSelectCommand();
                    InitializeAdapterCommands();
                    FillDataset();
                    SQLConn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CheckAndCloseSQLConnection();
            }
        }


        #region Initialize DataSet

        private void InitializeSelectCommand()
        {
            shopAdapter = new SqlDataAdapter(Constant.SHOP_TABLE_SELECT_COMMAND, SQLConn);
            productAdapter = new SqlDataAdapter(Constant.PRODUCT_TABLE_SELECT_COMMAND, SQLConn);
            stockAdapter = new SqlDataAdapter(Constant.STOCK_TABLE_SELECT_COMMAND, SQLConn);
            sendStockAdapter = new SqlDataAdapter(Constant.SEND_STOCK_TABLE_SELECT_COMMAND, SQLConn);
            manufacturerAdapter = new SqlDataAdapter(Constant.MANUFACTURER_TABLE_SELECT_COMMAND, SQLConn);
            staffAdapter = new SqlDataAdapter(Constant.STAFF_TABLE_SELECT_COMMAND, SQLConn);
            reportAdapter = new SqlDataAdapter(Constant.REPORT_TABLE_SELECT_COMMAND, SQLConn);
            discountAdapter = new SqlDataAdapter(Constant.DISCOUNT_TABLE_SELECT_COMMAND, SQLConn);
            pendingRequestAdapter = new SqlDataAdapter(Constant.PENDING_REQUEST_TABLE_SELECT_COMMAND, SQLConn);
            approvedRequestAdapter = new SqlDataAdapter(Constant.APPROVED_REQUEST_TABLE_SELECT_COMMAND, SQLConn);
            rejectedRequestAdapter = new SqlDataAdapter(Constant.REJECTED_REQUEST_TABLE_SELECT_COMMAND, SQLConn);
        }

        private void InitializeAdapterCommands()
        {
            shopCommandBuilder = new SqlCommandBuilder(shopAdapter);
            productCommandBuilder = new SqlCommandBuilder(productAdapter);
            manufacturerCommandBuilder = new SqlCommandBuilder(manufacturerAdapter);
            staffCommandBuilder = new SqlCommandBuilder(staffAdapter);
            discountCommandBuilder = new SqlCommandBuilder(discountAdapter);
        }

        private void FillDataset()
        {
            shopAdapter.Fill(dsTableList, Constant.SHOP_TABLE);
            productAdapter.Fill(dsTableList, Constant.PRODUCT_TABLE);
            stockAdapter.Fill(dsTableList, Constant.STOCK_TABLE);
            sendStockAdapter.Fill(dsTableList, Constant.SEND_STOCK_TABLE);
            manufacturerAdapter.Fill(dsTableList, Constant.MANUFACTURER_TABLE);
            staffAdapter.Fill(dsTableList, Constant.STAFF_TABLE);
            reportAdapter.Fill(dsTableList, Constant.REPORT_TABLE);
            discountAdapter.Fill(dsTableList, Constant.DISCOUNT_TABLE);
            pendingRequestAdapter.Fill(dsTableList, Constant.PENDING_REQUEST_TABLE);
            approvedRequestAdapter.Fill(dsTableList, Constant.APPROVED_REQUEST_TABLE);
            rejectedRequestAdapter.Fill(dsTableList, Constant.REJECTED_REQUEST_TABLE);
        }

        #endregion


        #region Shared Methods

        private void CheckAndCloseSQLConnection()
        {
            if (SQLConn.State == ConnectionState.Open)
            {
                SQLConn.Close();
            }
        }

        private void SynchronizeDataTableWithDatabaseTable(string tableName)
        {
            try
            {
                SQLConn.ConnectionString = DBConn.getConnectionString();
                using (SQLConn)
                {
                    SQLConn.Open();
                    switch (tableName)
                    {
                        case Constant.SHOP_TABLE:
                            shopAdapter.Update(dsTableList, Constant.SHOP_TABLE);
                            break;
                        case Constant.PRODUCT_TABLE:
                            productAdapter.Update(dsTableList, Constant.PRODUCT_TABLE);
                            break;
                        case Constant.STOCK_TABLE:
                            stockAdapter.Update(dsTableList, Constant.STOCK_TABLE);
                            break;
                        case Constant.SEND_STOCK_TABLE:
                            sendStockAdapter.Update(dsTableList, Constant.SEND_STOCK_TABLE);
                            break;
                        case Constant.MANUFACTURER_TABLE:
                            manufacturerAdapter.Update(dsTableList, Constant.MANUFACTURER_TABLE);
                            break;
                        case Constant.STAFF_TABLE:
                            staffAdapter.Update(dsTableList, Constant.STAFF_TABLE);
                            break;
                        case Constant.REPORT_TABLE:
                            reportAdapter.Update(dsTableList, Constant.REPORT_TABLE);
                            break;
                        case Constant.DISCOUNT_TABLE:
                            discountAdapter.Update(dsTableList, Constant.DISCOUNT_TABLE);
                            break;
                        case Constant.PENDING_REQUEST_TABLE:
                            pendingRequestAdapter.Update(dsTableList, Constant.PENDING_REQUEST_TABLE);
                            break;
                        case Constant.APPROVED_REQUEST_TABLE:
                            approvedRequestAdapter.Update(dsTableList, Constant.APPROVED_REQUEST_TABLE);
                            break;
                        case Constant.REJECTED_REQUEST_TABLE:
                            rejectedRequestAdapter.Update(dsTableList, Constant.REJECTED_REQUEST_TABLE);
                            break;

                        default:
                            break;
                    }
                    SQLConn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CheckAndCloseSQLConnection();
            }
        }

        private void AddRejectedRequestListRemoveApprovedRequestList(bool approved, string productName, string manufacturerName, string productID, string shopID, string shopCountry, string shopLocaton, DateTime requestDate, DateTime actionDate, string staffID, string quantity, bool urgency)
        {
            try
            {
                DataTable dt = dsTableList.Tables[Constant.APPROVED_REQUEST_TABLE];
                dsTableList.Tables[Constant.REJECTED_REQUEST_TABLE].Rows.Add(productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, actionDate, staffID, quantity, urgency);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.PRODUCT_ID].ToString().Equals(productID) && dt.Rows[i][Constant.SHOP_ID].ToString().Equals(shopID) &&
                        DateTime.Equals(dt.Rows[i][Constant.REQUEST_DATE], requestDate) && dt.Rows[i][Constant.STAFF_ID].ToString().Equals(staffID))
                    {
                        dsTableList.Tables[Constant.APPROVED_REQUEST_TABLE].Rows[i].Delete();
                        SetRequestStatusSwitchCommand(approved, actionDate, productID, shopID, requestDate, staffID);
                        SynchronizeDataTableWithDatabaseTable(Constant.APPROVED_REQUEST_TABLE);
                        break;
                    }
                } 
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void AddApprovedRequestListRemoveRejectedRequestList(bool approved, string productName, string manufacturerName, string productID, string shopID, string shopCountry, string shopLocaton, DateTime requestDate, DateTime actionDate, string staffID, string quantity, bool urgency)
        {
            try
            {
                DataTable dt = dsTableList.Tables[Constant.REJECTED_REQUEST_TABLE];
                dsTableList.Tables[Constant.APPROVED_REQUEST_TABLE].Rows.Add(productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, requestDate, actionDate, staffID, quantity, urgency);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.PRODUCT_ID].ToString().Equals(productID) && dt.Rows[i][Constant.SHOP_ID].ToString().Equals(shopID) &&
                        DateTime.Equals(dt.Rows[i][Constant.REQUEST_DATE], requestDate) && dt.Rows[i][Constant.STAFF_ID].ToString().Equals(staffID))
                    {
                        dsTableList.Tables[Constant.REJECTED_REQUEST_TABLE].Rows[i].Delete();
                        SetRequestStatusSwitchCommand(approved, actionDate, productID, shopID, requestDate, staffID);
                        SynchronizeDataTableWithDatabaseTable(Constant.REJECTED_REQUEST_TABLE);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region Manually Build Other Commands

        private void SetStockAdapterUpdateCommand(string importPrice, string sellPrice, DateTime expireDate, string quantity, string productID, DateTime batchID)
        {
            try
            {
                SqlCommand updateCommand = new SqlCommand(Constant.UPDATE_STOCK_COMMAND, SQLConn);
                updateCommand.Parameters.Add(Constant.IMPORT_PRICE, SqlDbType.Decimal).Value = Convert.ToDouble(importPrice);
                updateCommand.Parameters.Add(Constant.SELL_PRICE, SqlDbType.Decimal).Value = Convert.ToDouble(sellPrice);
                updateCommand.Parameters.Add(Constant.STOCK_EXPIRE_DATE, SqlDbType.Date).Value = expireDate.Date;
                updateCommand.Parameters.Add(Constant.QUANTITY, SqlDbType.Int).Value = quantity;
                updateCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                updateCommand.Parameters.Add(Constant.BATCH_ID, SqlDbType.Date).Value = batchID.Date;
                stockAdapter.UpdateCommand = updateCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetStockAdapterReduceQuantityCommand(string quantity, string productID, DateTime batchID)
        {
            try
            {
                SqlCommand updateCommand = new SqlCommand(Constant.REDUCE_STOCK_QUANTITY_COMMAND, SQLConn);
                updateCommand.Parameters.Add(Constant.QUANTITY, SqlDbType.Int).Value = quantity;
                updateCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                updateCommand.Parameters.Add(Constant.BATCH_ID, SqlDbType.Date).Value = batchID.Date;
                stockAdapter.UpdateCommand = updateCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetStockAdapterInsertCommand(string productID, DateTime batchID, string importPrice, string sellPrice, DateTime expireDate, string quantity, bool defaultDiscount)
        {
            try
            {
                SqlCommand insertCommand = new SqlCommand(Constant.ADD_STOCK_COMMAND, SQLConn);
                insertCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                insertCommand.Parameters.Add(Constant.BATCH_ID, SqlDbType.Date).Value = batchID.Date;
                insertCommand.Parameters.Add(Constant.IMPORT_PRICE, SqlDbType.Decimal).Value = Convert.ToDouble(importPrice);
                insertCommand.Parameters.Add(Constant.SELL_PRICE, SqlDbType.Decimal).Value = Convert.ToDouble(sellPrice);
                insertCommand.Parameters.Add(Constant.EXPIRE_DATE, SqlDbType.Date).Value = expireDate.Date;
                insertCommand.Parameters.Add(Constant.QUANTITY, SqlDbType.Int).Value = Convert.ToInt32(quantity);
                insertCommand.Parameters.Add(Constant.DEFAULT_DISCOUNT, SqlDbType.Bit).Value = defaultDiscount;
                stockAdapter.InsertCommand = insertCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetSendStockAdapterDeleteCommand(string productID, DateTime batchID, string shopID)
        {
            try
            {
                SqlCommand deleteCommand = new SqlCommand(Constant.DELETE_SEND_STOCK_COMMAND, SQLConn);
                deleteCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                deleteCommand.Parameters.Add(Constant.BATCH_ID, SqlDbType.Date).Value = batchID.Date;
                deleteCommand.Parameters.Add(Constant.SHOP_ID, SqlDbType.NVarChar).Value = shopID;
                stockAdapter.DeleteCommand = deleteCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetSendStockAdapterUpdateCommand(string productID, DateTime batchID, string shopID, DateTime confirmDate, DateTime sendDate, bool deliveryStatus)
        {
            try
            {
                SqlCommand updateCommand = new SqlCommand(Constant.UPDATE_SEND_STOCK_COMMAND, SQLConn);
                updateCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                updateCommand.Parameters.Add(Constant.BATCH_ID, SqlDbType.DateTime).Value = batchID.Date;
                updateCommand.Parameters.Add(Constant.SHOP_ID, SqlDbType.NVarChar).Value = shopID;
                updateCommand.Parameters.Add(Constant.CONFIRM_DATE, SqlDbType.DateTime).Value = confirmDate;
                updateCommand.Parameters.Add(Constant.SEND_DATE, SqlDbType.DateTime).Value = sendDate;
                updateCommand.Parameters.Add(Constant.DELIVERY_STATUS, SqlDbType.Bit).Value = deliveryStatus;
                sendStockAdapter.UpdateCommand = updateCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetDiscountAdapterUpdateCommand(string productID, DateTime effectiveDate, string bundleUnit, string freeItemQuantity, string discount)
        {
            try
            {
                SqlCommand updateCommand = new SqlCommand(Constant.UPDATE_DISCOUNT_COMMAND, SQLConn);
                updateCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                updateCommand.Parameters.Add(Constant.EFFECTIVE_DATE, SqlDbType.DateTime).Value = effectiveDate;
                updateCommand.Parameters.Add(Constant.BUNDLE_UNIT, SqlDbType.Int).Value = Convert.ToInt16(bundleUnit);
                updateCommand.Parameters.Add(Constant.FREE_ITEM_QUANTITY, SqlDbType.Int).Value = Convert.ToInt16(freeItemQuantity);
                updateCommand.Parameters.Add(Constant.DISCOUNT, SqlDbType.Decimal).Value = Convert.ToDouble(discount);
                discountAdapter.UpdateCommand = updateCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetDiscountAdapterInsertCommand(string productID, DateTime effectiveDate, string bundleUnit, string freeItemQuantity, string discount)
        {
            try
            {
                SqlCommand insertCommand = new SqlCommand(Constant.ADD_DISCOUNT_COMMAND, SQLConn);
                insertCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                insertCommand.Parameters.Add(Constant.EFFECTIVE_DATE, SqlDbType.DateTime).Value = effectiveDate;
                insertCommand.Parameters.Add(Constant.BUNDLE_UNIT, SqlDbType.Int).Value = Convert.ToInt16(bundleUnit);
                insertCommand.Parameters.Add(Constant.FREE_ITEM_QUANTITY, SqlDbType.Int).Value = Convert.ToInt16(freeItemQuantity);
                insertCommand.Parameters.Add(Constant.DISCOUNT, SqlDbType.Decimal).Value = Convert.ToDouble(discount);
                discountAdapter.InsertCommand = insertCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetDiscountAdapterDeleteCommand(string productID)
        {
            try
            {
                SqlCommand deleteCommand = new SqlCommand(Constant.DELETE_DISCOUNT_COMMAND, SQLConn);
                deleteCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                discountAdapter.DeleteCommand = deleteCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetPendingRequestDeleteCommand(string productID, string shopID, DateTime requestDate)
        {
            try
            {
                SqlCommand deleteCommand = new SqlCommand(Constant.DELETE_PENDING_REQUEST_COMMAND, SQLConn);
                deleteCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                deleteCommand.Parameters.Add(Constant.SHOP_ID, SqlDbType.NVarChar).Value = shopID;
                deleteCommand.Parameters.Add(Constant.REQUEST_DATE, SqlDbType.DateTime).Value = requestDate;
                pendingRequestAdapter.DeleteCommand = deleteCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetApprovedRequestInsertCommand(string productID, string shopID, DateTime requestDate, string staffID, bool approved, DateTime approvedDate, string approvedQuantity, string comments)
        {
            try
            {
                SqlCommand insertCommand = new SqlCommand(Constant.ADD_APPROVED_REQUEST_COMMAND, SQLConn);
                insertCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                insertCommand.Parameters.Add(Constant.SHOP_ID, SqlDbType.NVarChar).Value = shopID;
                insertCommand.Parameters.Add(Constant.REQUEST_DATE, SqlDbType.DateTime).Value = requestDate;
                insertCommand.Parameters.Add(Constant.STAFF_ID, SqlDbType.NVarChar).Value = staffID;
                insertCommand.Parameters.Add(Constant.APPROVED, SqlDbType.Bit).Value = approved;
                insertCommand.Parameters.Add(Constant.APPROVED_QUANTITY, SqlDbType.Int).Value = Int32.Parse(approvedQuantity);
                insertCommand.Parameters.Add(Constant.ACTION_DATE, SqlDbType.DateTime).Value = approvedDate;
                insertCommand.Parameters.Add(Constant.COMMENTS, SqlDbType.NVarChar).Value = comments;
                approvedRequestAdapter.InsertCommand = insertCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetRejectedRequestInsertCommand(string productID, string shopID, DateTime requestDate, string staffID, bool approved, DateTime rejectedDate)
        {
            try
            {
                SqlCommand insertCommand = new SqlCommand(Constant.ADD_REJECT_REQUEST_COMMAND, SQLConn);
                insertCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                insertCommand.Parameters.Add(Constant.SHOP_ID, SqlDbType.NVarChar).Value = shopID;
                insertCommand.Parameters.Add(Constant.REQUEST_DATE, SqlDbType.DateTime).Value = requestDate;
                insertCommand.Parameters.Add(Constant.STAFF_ID, SqlDbType.NVarChar).Value = staffID;
                insertCommand.Parameters.Add(Constant.APPROVED, SqlDbType.Bit).Value = approved;
                insertCommand.Parameters.Add(Constant.ACTION_DATE, SqlDbType.DateTime).Value = rejectedDate;
                rejectedRequestAdapter.InsertCommand = insertCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetRejectedRequestDeleteCommand(string productID, string shopID, DateTime requestDate, string staffID)
        {
            try
            {
                SqlCommand deleteCommand = new SqlCommand(Constant.DELETE_REJECTED_REQUEST_COMMAND, SQLConn);
                deleteCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                deleteCommand.Parameters.Add(Constant.SHOP_ID, SqlDbType.NVarChar).Value = shopID;
                deleteCommand.Parameters.Add(Constant.REQUEST_DATE, SqlDbType.DateTime).Value = requestDate;
                deleteCommand.Parameters.Add(Constant.STAFF_ID, SqlDbType.NVarChar).Value = staffID;
                approvedRequestAdapter.DeleteCommand = deleteCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetRequestStatusSwitchCommand(bool approved, DateTime actionDate, string productID, string shopID, DateTime requestDate, string staffID)
        {
            try
            {
                SqlCommand updateCommand = new SqlCommand(Constant.REQUEST_STATUS_SWITCH_COMMAND, SQLConn);
                updateCommand.Parameters.Add(Constant.APPROVED, SqlDbType.Bit).Value = approved;
                updateCommand.Parameters.Add(Constant.ACTION_DATE, SqlDbType.DateTime).Value = actionDate;
                updateCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                updateCommand.Parameters.Add(Constant.SHOP_ID, SqlDbType.NVarChar).Value = shopID;
                updateCommand.Parameters.Add(Constant.REQUEST_DATE, SqlDbType.DateTime).Value = requestDate;
                updateCommand.Parameters.Add(Constant.STAFF_ID, SqlDbType.NVarChar).Value = staffID;
                rejectedRequestAdapter.DeleteCommand = updateCommand;
                approvedRequestAdapter.DeleteCommand = updateCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetSendStockInsertCommand(string productID, DateTime batchID, string shopID, DateTime confirmDate, string quantity)
        {
            try
            {
                SqlCommand insertCommand = new SqlCommand(Constant.ADD_SEND_STOCK_COMMAND, SQLConn);
                insertCommand.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar).Value = productID;
                insertCommand.Parameters.Add(Constant.BATCH_ID, SqlDbType.Date).Value = batchID;
                insertCommand.Parameters.Add(Constant.SHOP_ID, SqlDbType.NVarChar).Value = shopID;
                insertCommand.Parameters.Add(Constant.CONFIRM_DATE, SqlDbType.DateTime).Value = confirmDate;
                insertCommand.Parameters.Add(Constant.DELIVERY_STATUS, SqlDbType.Bit).Value = false;
                insertCommand.Parameters.Add(Constant.RECEIVE_STATUS, SqlDbType.Bit).Value = false;
                insertCommand.Parameters.Add(Constant.QUANTITY, SqlDbType.Int).Value = quantity;
                sendStockAdapter.InsertCommand = insertCommand;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region Shop Operation

        public DataTable FetchShop()
        {
            return dsTableList.Tables[Constant.SHOP_TABLE];
        }

        public void AddShop(string shopID, string country, string location, string contact)
        {
            try
            {
                DataRow newRow = dsTableList.Tables[Constant.SHOP_TABLE].NewRow();
                newRow[Constant.S_ID] = shopID;
                newRow[Constant.S_COUNTRY] = country;
                newRow[Constant.S_LOCATION] = location;
                newRow[Constant.S_CONTACT] = contact;
                dsTableList.Tables[Constant.SHOP_TABLE].Rows.InsertAt(newRow, Constant.CONSTANT_ZERO);
                SynchronizeDataTableWithDatabaseTable(Constant.SHOP_TABLE);
            }
            catch
            {
                throw;
            }
            finally
            {
                CheckAndCloseSQLConnection();
            }
        }

        public void DeleteShop(string shopID)
        {
            DataTable dt = dsTableList.Tables[Constant.SHOP_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.S_ID].ToString().Equals(shopID))
                    {
                        dsTableList.Tables[Constant.SHOP_TABLE].Rows[i].Delete();
                        SynchronizeDataTableWithDatabaseTable(Constant.SHOP_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CheckAndCloseSQLConnection();
            }
        }

        public void UpdateShop(string shopID, string country, string location, string contact)
        {
            DataTable dt = dsTableList.Tables[Constant.SHOP_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.S_ID].ToString().Equals(shopID))
                    {
                        dsTableList.Tables[Constant.SHOP_TABLE].Rows[i][Constant.S_COUNTRY] = country;
                        dsTableList.Tables[Constant.SHOP_TABLE].Rows[i][Constant.S_LOCATION] = location;
                        dsTableList.Tables[Constant.SHOP_TABLE].Rows[i][Constant.S_CONTACT] = contact;
                        SynchronizeDataTableWithDatabaseTable(Constant.SHOP_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw; 
            }
            finally
            {
                CheckAndCloseSQLConnection();
            }
        }

        #endregion


        #region Product Operation

        public DataTable FetchProduct()
        {
            return dsTableList.Tables[Constant.PRODUCT_TABLE];
        }

        public void AddProduct(string manufacturerName, string productID, string name, string category, string maxStock, string minStock)
        {
            try
            {
                DataRow newRow = dsTableList.Tables[Constant.PRODUCT_TABLE].NewRow();
                newRow[Constant.P_M_Name] = manufacturerName;
                newRow[Constant.P_ID] = productID;
                newRow[Constant.P_NAME] = name;
                newRow[Constant.P_CATEGORY] = category;
                newRow[Constant.P_MAX] = maxStock;
                newRow[Constant.P_MIN] = minStock;
                dsTableList.Tables[Constant.PRODUCT_TABLE].Rows.InsertAt(newRow, Constant.CONSTANT_ZERO);
                SynchronizeDataTableWithDatabaseTable(Constant.PRODUCT_TABLE);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteProduct(string productID)
        {
            try
            {
                DataTable dt = dsTableList.Tables[Constant.PRODUCT_TABLE];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.P_ID].ToString().Equals(productID))
                    {
                        dsTableList.Tables[Constant.PRODUCT_TABLE].Rows[i].Delete();
                        SynchronizeDataTableWithDatabaseTable(Constant.PRODUCT_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateProduct(string manufacturerName, string productID, string name, string category, string maxStock, string minStock)
        {
            try
            {
                DataTable dt = dsTableList.Tables[Constant.PRODUCT_TABLE];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.P_ID].ToString().Equals(productID))
                    {
                        dsTableList.Tables[Constant.PRODUCT_TABLE].Rows[i][Constant.P_M_Name] = manufacturerName;
                        dsTableList.Tables[Constant.PRODUCT_TABLE].Rows[i][Constant.P_NAME] = name;
                        dsTableList.Tables[Constant.PRODUCT_TABLE].Rows[i][Constant.P_CATEGORY] = category;
                        dsTableList.Tables[Constant.PRODUCT_TABLE].Rows[i][Constant.P_MAX] = maxStock;
                        dsTableList.Tables[Constant.PRODUCT_TABLE].Rows[i][Constant.P_MIN] = minStock;
                        SynchronizeDataTableWithDatabaseTable(Constant.PRODUCT_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public bool IsProductAllowedDeletion(string productID)
        {
            try
            {
                using (SqlConnection hqConn = new SqlConnection(DBConn.getConnectionString()))
                using (SqlCommand hqComm = new SqlCommand(Constant.Product_Check_Stock, hqConn))
                {
                    hqComm.CommandType = CommandType.Text;
                    hqComm.Parameters.Add(Constant.PRODUCT_ID, SqlDbType.NVarChar);
                    hqComm.Parameters[Constant.PRODUCT_ID].Value = productID;

                    hqConn.Open();
                    int count;
                    object result;
                    if((result = hqComm.ExecuteScalar()) == DBNull.Value)
                    {
                        count = Constant.CONSTANT_ZERO;
                    }
                    else
                    {
                        count = (int)result;
                    }
                    hqConn.Close();

                    if (count == Constant.CONSTANT_ZERO)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

 
        #region Stock Operation

        public DataTable FetchStock()
        {
            return dsTableList.Tables[Constant.STOCK_TABLE];
        }

        public void AddStock(string productName, string manufacturerName, string productID, DateTime batchID, string importPrice, string sellPrice, DateTime expireDate, string quantity, bool defaultDiscount)
        {
            try
            {
                DataRow newRow = dsTableList.Tables[Constant.STOCK_TABLE].NewRow();
                newRow[Constant.STOCK_P_NAME] = productName;
                newRow[Constant.STOCK_M_NAME] = manufacturerName;
                newRow[Constant.STOCK_P_ID] = productID;
                newRow[Constant.STOCK_BATCH_ID] = batchID.Date;
                newRow[Constant.STOCK_IMPORT_PRICE] = Convert.ToDouble(importPrice);
                newRow[Constant.STOCK_SELL_PRICE] = Convert.ToDouble(sellPrice);
                newRow[Constant.STOCK_EXPIRE_DATE] = expireDate.Date;
                newRow[Constant.STOCK_QUANTITY] = Convert.ToInt64(quantity);
                newRow[Constant.STOCK_DEFAULT_DISCOUNT_POLICY] = defaultDiscount;
                dsTableList.Tables[Constant.STOCK_TABLE].Rows.InsertAt(newRow,Constant.CONSTANT_ZERO);
                SetStockAdapterInsertCommand(productID, batchID, importPrice, sellPrice, expireDate, quantity, defaultDiscount);
                SynchronizeDataTableWithDatabaseTable(Constant.STOCK_TABLE);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateStock(string productID, DateTime batchID, string importPrice, string sellPrice, DateTime expireDate, string quantity)
        {
            DataTable dt = dsTableList.Tables[Constant.STOCK_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.STOCK_P_ID].ToString().Equals(productID) && DateTime.Equals(dt.Rows[i][Constant.STOCK_BATCH_ID], batchID))
                    {
                        dsTableList.Tables[Constant.STOCK_TABLE].Rows[i][Constant.STOCK_IMPORT_PRICE] = Convert.ToDouble(importPrice);
                        dsTableList.Tables[Constant.STOCK_TABLE].Rows[i][Constant.STOCK_SELL_PRICE] = Convert.ToDouble(sellPrice);
                        dsTableList.Tables[Constant.STOCK_TABLE].Rows[i][Constant.STOCK_EXPIRE_DATE] = expireDate.Date;
                        dsTableList.Tables[Constant.STOCK_TABLE].Rows[i][Constant.STOCK_QUANTITY] = Convert.ToInt32(quantity);
                        SetStockAdapterUpdateCommand(importPrice, sellPrice, expireDate, quantity, productID, batchID);
                        SynchronizeDataTableWithDatabaseTable(Constant.STOCK_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void ReduceStockQuantity(string productID, DateTime batchID, string substractQuantity)
        {
            DataTable dt = dsTableList.Tables[Constant.STOCK_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.STOCK_P_ID].ToString().Equals(productID) && DateTime.Equals(dt.Rows[i][Constant.STOCK_BATCH_ID], batchID))
                    {
                        Int32 updatedQuantity = Convert.ToInt32(dsTableList.Tables[Constant.STOCK_TABLE].Rows[i][Constant.STOCK_QUANTITY].ToString()) - Convert.ToInt32(substractQuantity);
                        dsTableList.Tables[Constant.STOCK_TABLE].Rows[i][Constant.STOCK_QUANTITY] = updatedQuantity;
                        SetStockAdapterReduceQuantityCommand(updatedQuantity.ToString(), productID, batchID);
                        SynchronizeDataTableWithDatabaseTable(Constant.STOCK_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public ArrayList getLatestBatchInfo(string productID)
        {
            DataRow[] result = dsTableList.Tables[Constant.STOCK_TABLE].Select("ProductID = '" + productID + "' AND  Quantity <> '0" + "'", "BatchID ASC");

            return new ArrayList(){result[Constant.CONSTANT_ZERO][Constant.CONSTANT_ZERO], result[Constant.CONSTANT_ZERO][Constant.OPERATION_INDEX_ONE], result[Constant.CONSTANT_ZERO][Constant.OPERATION_INDEX_TWO], result[Constant.CONSTANT_ZERO][Constant.OPERATION_INDEX_THREE],
                                    result[Constant.CONSTANT_ZERO][Constant.OPERATION_INDEX_FOUR], result[Constant.CONSTANT_ZERO][Constant.OPERATION_INDEX_FIVE], result[Constant.CONSTANT_ZERO][Constant.OPERATION_INDEX_SIX], result[Constant.CONSTANT_ZERO][Constant.OPERATION_INDEX_SEVEN],
                                    result[Constant.CONSTANT_ZERO][Constant.OPERATION_INDEX_EIGHT]};
        }

        #endregion


        #region Manufacturer Operation

        public DataTable FetchManufacturer()
        {
            return dsTableList.Tables[Constant.MANUFACTURER_TABLE];
        }

        public void AddManufacturer(string manufacturerName, string address, string country, string contact)
        {
            try
            {
                dsTableList.Tables[Constant.MANUFACTURER_TABLE].Rows.Add(manufacturerName, address, country, contact);
                SynchronizeDataTableWithDatabaseTable(Constant.MANUFACTURER_TABLE);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteManufacturer(string manufacturerName)
        {
            DataTable dt = dsTableList.Tables[Constant.MANUFACTURER_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.M_NAME].ToString().Equals(manufacturerName))
                    {
                        dsTableList.Tables[Constant.MANUFACTURER_TABLE].Rows[i].Delete();
                        SynchronizeDataTableWithDatabaseTable(Constant.MANUFACTURER_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateManufacturer(string manufacturerName, string address, string country, string contact)
        {
            DataTable dt = dsTableList.Tables[Constant.MANUFACTURER_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.M_NAME].ToString().Equals(manufacturerName))
                    {
                        dsTableList.Tables[Constant.MANUFACTURER_TABLE].Rows[i][Constant.M_ADDRESS] = address;
                        dsTableList.Tables[Constant.MANUFACTURER_TABLE].Rows[i][Constant.M_COUNTRY] = country;
                        dsTableList.Tables[Constant.MANUFACTURER_TABLE].Rows[i][Constant.M_CONTACT] = contact;
                        SynchronizeDataTableWithDatabaseTable(Constant.MANUFACTURER_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

  
        #region Staff Operation

        public DataTable FetchStaff()
        {
            return dsTableList.Tables[Constant.STAFF_TABLE];
        }

        public void AddStaff(string staffID, string name, DateTime renewPasswordDate, DateTime dateOfBirth, DateTime joinDate, string gender, string position, string contact, bool isDefaultPassword, bool isBlocked)
        {
            try
            {
                dsTableList.Tables[Constant.STAFF_TABLE].Rows.Add(staffID, name, Constant.DEFAULT_PASSWORD_ENCRYPTED, renewPasswordDate, dateOfBirth, joinDate, gender, position, contact, isDefaultPassword, isBlocked);
                SynchronizeDataTableWithDatabaseTable(Constant.STAFF_TABLE);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteStaff(string staffID)
        {
            DataTable dt = dsTableList.Tables[Constant.STAFF_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.STAFF_ID].ToString().Equals(staffID))
                    {
                        dsTableList.Tables[Constant.STAFF_TABLE].Rows[i].Delete();
                        SynchronizeDataTableWithDatabaseTable(Constant.STAFF_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateStaff(string staffID, string contact, string position, bool defaultPassword, bool blocked)
        {
            DataTable dt = dsTableList.Tables[Constant.STAFF_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.STAFF_ID].ToString().Equals(staffID))
                    {
                        dt.Rows[i][Constant.STAFF_CONTACT] = Convert.ToInt64(contact);
                        dt.Rows[i][Constant.STAFF_POSITION] = position;
                        dt.Rows[i][Constant.STAFF_IS_DEFAULT_PASSWORD] = defaultPassword;
                        dt.Rows[i][Constant.STAFF_BLOCKED] = blocked;
                        SynchronizeDataTableWithDatabaseTable(Constant.STAFF_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateStaffPassword(string staffID, string newPassword)
        {
            DataTable dt = dsTableList.Tables[Constant.STAFF_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.STAFF_ID].ToString().Equals(staffID))
                    {
                        dt.Rows[i][Constant.STAFF_PASSWORD] = newPassword;
                        dt.Rows[i][Constant.STAFF_RENEWED_PASSWORD_DATE] = DateTime.Now.Date.AddDays(Constant.PASSWORD_VALID_DAYS);
                        dt.Rows[i][Constant.STAFF_IS_DEFAULT_PASSWORD] = false;
                        SynchronizeDataTableWithDatabaseTable(Constant.STAFF_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void ResetStaffPassword(string staffID)
        {
            DataTable dt = dsTableList.Tables[Constant.STAFF_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.STAFF_ID].ToString().Equals(staffID))
                    {
                        dt.Rows[i][Constant.STAFF_PASSWORD] = Constant.DEFAULT_PASSWORD_ENCRYPTED;
                        dt.Rows[i][Constant.STAFF_RENEWED_PASSWORD_DATE] = DateTime.Now.Date.AddDays(Constant.PASSWORD_VALID_DAYS);
                        dt.Rows[i][Constant.STAFF_IS_DEFAULT_PASSWORD] = true;
                        SynchronizeDataTableWithDatabaseTable(Constant.STAFF_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion
    

        #region Request Operation

        public DataTable FetchPendingRequest()
        {
            return dsTableList.Tables[Constant.PENDING_REQUEST_TABLE];
        }

        public DataTable FetchApprovedRequest()
        {
            return dsTableList.Tables[Constant.APPROVED_REQUEST_TABLE];
        }

        public DataTable FetchRejectedRequest()
        {
            return dsTableList.Tables[Constant.REJECTED_REQUEST_TABLE];
        }

        public void AddRejectedRequest(string productName, string manufacturerName, string productID, string shopID, string shopCountry, string shopLocation, DateTime requestDate, DateTime rejectedDate, string staffID, string quantity, bool urgency)
        {
            try
            {
                dsTableList.Tables[Constant.REJECTED_REQUEST_TABLE].Rows.Add(productName, manufacturerName, productID, shopID, shopCountry, shopLocation, requestDate, rejectedDate, staffID, quantity, urgency);
                SetRejectedRequestInsertCommand(productID, shopID, requestDate, staffID, false, rejectedDate);
                SynchronizeDataTableWithDatabaseTable(Constant.REJECTED_REQUEST_TABLE);
                dsTableList.Tables[Constant.PENDING_REQUEST_TABLE].Clear();

                SQLConn.ConnectionString = DBConn.getConnectionString();

                using (SQLConn)
                {
                    if (SQLConn.State == ConnectionState.Closed)
                    {
                        SQLConn.Open();
                    }
                    pendingRequestAdapter.Fill(dsTableList, Constant.PENDING_REQUEST_TABLE);
                    SQLConn.Close();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CheckAndCloseSQLConnection();
            }
        }

        public void AddApprovedRequest(string productName, string manufacturerName, string productID, string shopID, string shopCountry, string shopLocation, DateTime requestDate, DateTime approvedDate, string staffID, string quantity, string approvedQuantity, bool urgency, string comments)
        {
            try
            {
                dsTableList.Tables[Constant.APPROVED_REQUEST_TABLE].Rows.Add(productName, manufacturerName, productID, shopID, shopCountry, shopLocation, requestDate, approvedDate, staffID, quantity, approvedQuantity, urgency);
                SetApprovedRequestInsertCommand(productID, shopID, requestDate, staffID, true, approvedDate, approvedQuantity, comments);
                SynchronizeDataTableWithDatabaseTable(Constant.APPROVED_REQUEST_TABLE);
                dsTableList.Tables[Constant.PENDING_REQUEST_TABLE].Clear();

                SQLConn.ConnectionString = DBConn.getConnectionString();
                using (SQLConn)
                {
                    if (SQLConn.State == ConnectionState.Closed)
                    {
                        SQLConn.Open();
                    }
                    pendingRequestAdapter.Fill(dsTableList, Constant.PENDING_REQUEST_TABLE);
                    SQLConn.Close();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CheckAndCloseSQLConnection();
            }
        }

        public void ChangeRequestApprovalStatus(bool approved, string productName, string manufacturerName, string productID, string shopID, string shopCountry, string shopLocaton, DateTime requestDate, DateTime actionDate, string staffID, string quantity, bool urgency)
        {
            try
            {
                if (approved == true)
                {
                    AddApprovedRequestListRemoveRejectedRequestList(approved, productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, requestDate, actionDate, staffID, quantity, urgency);
                }
                else
                {
                    AddRejectedRequestListRemoveApprovedRequestList(approved, productName, manufacturerName, productID, shopID, shopCountry, shopLocaton, requestDate, actionDate, staffID, quantity, urgency);
                }
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
                dsTableList.Tables[Constant.PENDING_REQUEST_TABLE].Clear();
                dsTableList.Tables[Constant.APPROVED_REQUEST_TABLE].Clear();
                dsTableList.Tables[Constant.REJECTED_REQUEST_TABLE].Clear();
                dsTableList.Tables[Constant.SEND_STOCK_TABLE].Clear();

                SQLConn.ConnectionString = DBConn.getConnectionString();
                using (SQLConn)
                {
                    if (SQLConn.State == ConnectionState.Closed)
                    {
                        SQLConn.Open();
                    }
                    pendingRequestAdapter.Fill(dsTableList, Constant.PENDING_REQUEST_TABLE);
                    approvedRequestAdapter.Fill(dsTableList, Constant.APPROVED_REQUEST_TABLE);
                    rejectedRequestAdapter.Fill(dsTableList, Constant.REJECTED_REQUEST_TABLE);
                    sendStockAdapter.Fill(dsTableList, Constant.SEND_STOCK_TABLE);
                    SQLConn.Close();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CheckAndCloseSQLConnection();
            }
        }

        #endregion


        #region SendStock Operation

        public DataTable FetchSendStock()
        {
            return dsTableList.Tables[Constant.SEND_STOCK_TABLE];
        }

        public void AddSendStock(string productName, string manufacturerName, string productID, DateTime batchID, string shopID, string shopCountry, string shopLocation, string quantity)
        {
            try
            {
                DateTime timeStamp = DateTime.Now;
                DateTime currentTime = new DateTime(timeStamp.Year, timeStamp.Month, timeStamp.Day, timeStamp.Hour, timeStamp.Minute, timeStamp.Second);
                dsTableList.Tables[Constant.SEND_STOCK_TABLE].Rows.Add(productName, manufacturerName, productID, batchID, shopID, shopCountry, shopLocation, currentTime, DBNull.Value, DBNull.Value, false, false, quantity);
                SetSendStockInsertCommand(productID, batchID, shopID, currentTime, quantity);
                SynchronizeDataTableWithDatabaseTable(Constant.SEND_STOCK_TABLE);
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
                DataTable dt = dsTableList.Tables[Constant.SEND_STOCK_TABLE];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ProductID"].ToString().Equals(productID) && DateTime.Equals(dt.Rows[i]["batchID"], batchID) &&
                        dt.Rows[i]["ShopID"].ToString().Equals(shopID))
                    {
                        dsTableList.Tables[Constant.SEND_STOCK_TABLE].Rows[i].Delete();
                        SetSendStockAdapterDeleteCommand(productID, batchID, shopID);
                        SynchronizeDataTableWithDatabaseTable(Constant.SEND_STOCK_TABLE);
                        break;
                    }
                }
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
                DataTable dt = dsTableList.Tables[Constant.SEND_STOCK_TABLE];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ProductID"].ToString().Equals(productID) && DateTime.Equals(dt.Rows[i]["batchID"], batchID) &&
                        dt.Rows[i]["ShopID"].ToString().Equals(shopID) && DateTime.Equals((DateTime)dt.Rows[i]["ConfirmDate"], confirmDate))
                    {
                        dsTableList.Tables[Constant.SEND_STOCK_TABLE].Rows[i]["SendDate"] = sendDate;
                        dsTableList.Tables[Constant.SEND_STOCK_TABLE].Rows[i]["DeliveryStatus"] = deliveryStatus;

                        SetSendStockAdapterUpdateCommand(productID, batchID, shopID, confirmDate, sendDate, deliveryStatus);
                        SynchronizeDataTableWithDatabaseTable(Constant.SEND_STOCK_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion


        #region Discount Operation

        public DataTable FetchDiscountPolicy()
        {
            return dsTableList.Tables[Constant.DISCOUNT_TABLE];
        }

        public void AddDiscountPolicy(string productName, string manufacturer, string productID, DateTime effectiveDate, string bundleUnit, string freeItemQuantity, string discount)
        {
            try
            {
                dsTableList.Tables[Constant.DISCOUNT_TABLE].Rows.Add(productName, manufacturer, productID, effectiveDate, bundleUnit, freeItemQuantity, discount);
                SetDiscountAdapterInsertCommand(productID, effectiveDate, bundleUnit, freeItemQuantity, discount);
                SynchronizeDataTableWithDatabaseTable(Constant.DISCOUNT_TABLE);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteDiscountPolicy(string productID)
        {
            DataTable dt = dsTableList.Tables[Constant.DISCOUNT_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.D_P_ID].ToString().Equals(productID))
                    {
                        dsTableList.Tables[Constant.DISCOUNT_TABLE].Rows[i].Delete();
                        SetDiscountAdapterDeleteCommand(productID);
                        SynchronizeDataTableWithDatabaseTable(Constant.DISCOUNT_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateDiscountPolicy(string productID, DateTime effectiveDate, string unitBundle, string freeItemQuantity, string discount)
        {
            DataTable dt = dsTableList.Tables[Constant.DISCOUNT_TABLE];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][Constant.D_P_ID].ToString().Equals(productID))
                    {
                        dt.Rows[i][Constant.D_EFFECTIVE_DATE] = Convert.ToDateTime(effectiveDate);
                        dt.Rows[i][Constant.D_BUNDLE_UNIT] = Convert.ToInt16(unitBundle);
                        dt.Rows[i][Constant.D_FREE_ITEM_QUANTITY] = Convert.ToInt16(freeItemQuantity);
                        dt.Rows[i][Constant.D_DISCOUNT_PERCENTAGE] = Convert.ToDouble(discount);
                        SetDiscountAdapterUpdateCommand(productID, effectiveDate, unitBundle, freeItemQuantity, discount);
                        SynchronizeDataTableWithDatabaseTable(Constant.DISCOUNT_TABLE);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion


        #region Report Operation

        public DataTable FetchReport()
        {
            return dsTableList.Tables[Constant.REPORT_TABLE];
        }

        public DataTable FetchYearlySummary(string startYear, string endYear)
        {
            DataTable returnTable = new DataTable();
            SQLConn.ConnectionString = DBConn.getConnectionString();
            using (SqlCommand selectCommand = new SqlCommand(string.Format(Constant.YEARLY_SUMMARY_TABLE_SELECT_COMMAND, startYear, endYear), SQLConn))
            {
                SQLConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                adapter.Fill(returnTable);
                SQLConn.Close();
            }

            return returnTable;
        }

        public DataTable FetchYearlyProduct(string startYear, string endYear)
        {
            DataTable returnTable = new DataTable();
            SQLConn.ConnectionString = DBConn.getConnectionString();
            using (SqlCommand selectCommand = new SqlCommand(string.Format(Constant.YEARLY_PRODUCT_TABLE_SELECT_COMMAND, startYear, endYear), SQLConn))
            {
                SQLConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                adapter.Fill(returnTable);
                SQLConn.Close();
            }

            return returnTable;
        }

        public DataTable FetchYearlyShop(string startYear, string endYear)
        {
            DataTable returnTable = new DataTable();
            SQLConn.ConnectionString = DBConn.getConnectionString();
            using (SqlCommand selectCommand = new SqlCommand(string.Format(Constant.YEARLY_SHOP_TABLE_SELECT_COMMAND, startYear, endYear), SQLConn))
            {
                SQLConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                adapter.Fill(returnTable);
                SQLConn.Close();
            }

            return returnTable;
        }

        public DataTable FetchMonthlySummary(DateTime startDate, DateTime endDate)
        {
            DataTable returnTable = new DataTable();
            SQLConn.ConnectionString = DBConn.getConnectionString();
            using (SqlCommand selectCommand = new SqlCommand(string.Format(Constant.MONTHLY_SUMMARY_TABLE_SELECT_COMMAND, startDate.ToShortDateString(), endDate.ToShortDateString()), SQLConn))
            {
                SQLConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                adapter.Fill(returnTable);
                SQLConn.Close();
            }

            return returnTable;
        }

        public DataTable FetchMonthlyProduct(DateTime startDate, DateTime endDate)
        {
            DataTable returnTable = new DataTable();
            SQLConn.ConnectionString = DBConn.getConnectionString();
            using (SqlCommand selectCommand = new SqlCommand(string.Format(Constant.MONTHLY_PRODUCT_TABLE_SELECT_COMMAND, startDate.ToShortDateString(), endDate.ToShortDateString()), SQLConn))
            {
                SQLConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                adapter.Fill(returnTable);
                SQLConn.Close();
            }

            return returnTable;
        }

        public DataTable FetchMonthlyShop(DateTime startDate, DateTime endDate)
        {
            DataTable returnTable = new DataTable();
            SQLConn.ConnectionString = DBConn.getConnectionString();
            using (SqlCommand selectCommand = new SqlCommand(string.Format(Constant.MONTHLY_SHOP_TABLE_SELECT_COMMAND, startDate.ToShortDateString(), endDate.ToShortDateString()), SQLConn))
            {
                SQLConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                adapter.Fill(returnTable);
                SQLConn.Close();
            }

            return returnTable;
        }

        public DataTable FetchDailySummary(DateTime startDate, DateTime endDate)
        {
            DataTable returnTable = new DataTable();
            SQLConn.ConnectionString = DBConn.getConnectionString();
            using (SqlCommand selectCommand = new SqlCommand(string.Format(Constant.DAILY_SUMMARY_TABLE_SELECT_COMMAND, startDate.ToString(), endDate.ToString()), SQLConn))
            {
                SQLConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                adapter.Fill(returnTable);
                SQLConn.Close();
            }

            return returnTable;
        }

        public DataTable FetchDailyProduct(DateTime startDate, DateTime endDate)
        {
            DataTable returnTable = new DataTable();
            SQLConn.ConnectionString = DBConn.getConnectionString();
            using (SqlCommand selectCommand = new SqlCommand(string.Format(Constant.DAILY_PRODUCT_TABLE_SELECT_COMMAND, startDate.ToString(), endDate.ToString()), SQLConn))
            {
                SQLConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                adapter.Fill(returnTable);
                SQLConn.Close();
            }

            return returnTable;
        }

        public DataTable FetchDailyShop(DateTime startDate, DateTime endDate)
        {
            DataTable returnTable = new DataTable();
            SQLConn.ConnectionString = DBConn.getConnectionString();
            using (SqlCommand selectCommand = new SqlCommand(string.Format(Constant.DAILY_SHOP_TABLE_SELECT_COMMAND, startDate.ToString(), endDate.ToString()), SQLConn))
            {
                SQLConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                adapter.Fill(returnTable);
                SQLConn.Close();
            }

            return returnTable;
        }

        #endregion

    }
}
