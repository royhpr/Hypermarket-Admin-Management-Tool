using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

/****************************************
 *The class is responsible for adding, deleting or updating outlets info
 *
 * Methods:
 * public void AddShop(string shopID, string country, string location, string contact)
 * public void DeleteShop(string shopID)
 * public void UpdateShop(string shopID, string country, string location, string contact)
 * public string GenerateNextAvailableShopID()
 * public DataTable FetchShop()
 * 
 * 
 * 
 * 
 * @Auther:
 * @Date:
 * *****************************************/

namespace Hypermarket_Admin_Management_Tool._2_Controller
{
    class ShopsManager
    {
        private _1_Model.DBManager DBController = _1_Model.DBManager.getInstance();
        private DataTable ShopList;

        #region Add Shop
        public void AddShop(string shopID, string country, string location, string contact)
        {
            try
            {
                DBController.AddShop(shopID, country, location, contact);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion


        #region Delete Shop
        public void DeleteShop(string shopID)
        {
            try
            {
                DBController.DeleteShop(shopID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion


        #region Update Shop
        public void UpdateShop (string shopID, string country, string location, string contact)
        {
            try
            {
                DBController.UpdateShop(shopID, country, location, contact);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion


        #region Generate Shop ID
        public string GenerateNextAvailableShopID()
        {
            try
            {
                ShopList = DBController.FetchShop();
                return RetriveNewShopID();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string RetriveNewShopID()
        {
            List<int> shopIDList = ShopList.AsEnumerable().Select(al => al.Field<string>(Constant.S_ID)).Select(int.Parse).ToList();
            if (shopIDList.Count == 0)
            {
                return Convert.ToString(1);
            }
            else
            {
                return GetAvailableShopID(shopIDList).PadLeft(4,'0').ToString();
            }
        }

        private static string GetAvailableShopID(List<int> shopIDList)
        {
            shopIDList.Sort();
            for (int i = 0; i < shopIDList.Count; i++)
            {
                if (i + 1 != shopIDList[i])
                {
                    return Convert.ToString(i + 1);
                }
            }
            int shopID = shopIDList.Max() + 1;
            return Convert.ToString(shopID);
        }
        #endregion


        #region Fetch Shop ID
        public DataTable FetchShop()
        {
            try
            {
                ShopList = DBController.FetchShop();
                return ShopList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

    }
}
