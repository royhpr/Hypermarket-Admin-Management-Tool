using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

/****************************************
 *The class is responsible for managing product list and manufacturer info
 *
 * Methods:
 * public void AddProduct(string productID, string manufacturerName, string name, string category, bool perishable)
 * public void DeleteProduct(string productID, string manufacturerName )
 * public void UpdateProduct(string productID, string manufacturerName, string name, string category, bool perishable)
 * public void AddManufacturer(string manufacturerName, string location, string country, bool contact)
 * public void DeleteManufacturer(string manufacturerName)
 * public void UpdateManufacturer(string manufacturerName, string country, string location, string contact)
 * public string GenerateNextAvailableProductID()
 * public DataTable FetchProduct()
 * public DataTable FetchManufacturer() 
 * 
 * 
 * @Auther:
 * @Date:
 * *****************************************/

namespace Hypermarket_Admin_Management_Tool._2_Controller
{
    class ProductManager
    {
        private _1_Model.DBManager DBController = _1_Model.DBManager.getInstance();
        private DataTable ProductList;
        private DataTable ManufacturerList;

        #region Add product

        public void AddProduct(string manufacturerName,string productID, string name, string category, string maxStock, string minStock)
        {
            try
            {
                DBController.AddProduct(manufacturerName, productID, name, category, maxStock, minStock);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion


        #region Delete Product

        public void DeleteProduct(string productID)
        {
            try
            {
                DBController.DeleteProduct(productID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region Update Product

        public void UpdateProduct(string manufacturerName, string productID, string name, string category, string maxStock, string minStock)
        {
            try
            {
                DBController.UpdateProduct(manufacturerName, productID, name, category, maxStock, minStock);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region Add Manufacturer

        public void AddManufacturer(string manufacturerName, string address, string country, string contact)
        {
            try
            {
               DBController.AddManufacturer(manufacturerName,address,country, contact);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion


        #region Delete Manufacturer

        public void DeleteManufacturer(string manufacturerName)
        {
            try
            {
                DBController.DeleteManufacturer(manufacturerName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region Update Manufacturer

        public void UpdateManufacturer(string manufacturerName, string address, string country, string contact)
        {
            try
            {
               
               DBController.UpdateManufacturer(manufacturerName, address, country, contact);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region Generate Product ID

        public string GenerateNextAvailableProductID()
        {
            try
            {
                ProductList = DBController.FetchProduct();
                return RetriveNewProductID().PadLeft(Constant.PRODUCT_ID_LENGTH,Constant.LEFT_PAD_CHAR);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private string RetriveNewProductID()
        {
            List<int> ProductIDList = ProductList.AsEnumerable().Select(al => al.Field<string>(Constant.P_ID)).Select(int.Parse).ToList();
            if (ProductIDList.Count == 0)
            {
                return Convert.ToString(1);
            }
            else
            {
                return GetAvailableProductID(ProductIDList);
            }
        }
        private static string GetAvailableProductID(List<int> ProductIDList)
        {
            ProductIDList.Sort();
            for (int i = 0; i < ProductIDList.Count; i++)
            {
                if (i + 1 != ProductIDList[i])
                {
                    return Convert.ToString(i + 1);
                }
            }
            int productID = ProductIDList.Max() + 1;
            return Convert.ToString(productID);
        }


        #endregion


        #region Fetch Product

        public DataTable FetchProduct()
        {
            try
            {
                ProductList = DBController.FetchProduct();
                return ProductList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region Fetch Manufacturer

        public DataTable FetchManufacturer()
        {
            try
            {
                ManufacturerList = DBController.FetchManufacturer();
                return ManufacturerList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region CheckStock

        public bool IsProductAllowedDeletion(string productID)
        {
            try
            {
                return DBController.IsProductAllowedDeletion(productID);
            }
            catch
            {
                throw;
            }
        }

        #endregion

    }
}
