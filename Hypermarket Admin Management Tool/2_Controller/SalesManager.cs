using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

/****************************************
 *The class is responsible for managing critical discount policy and retriving sales report
 *
 * Methods:
 * public DataTable FetchReport(...)
 * public void SetDiscount(float a, float b, float)
 * 
 * 
 * 
 * 
 * 
 * @Auther: Huang Purong
 * @Date:
 * *****************************************/

namespace Hypermarket_Admin_Management_Tool._2_Controller
{
    class SalesManager
    {
        private _1_Model.DBManager DBController = _1_Model.DBManager.getInstance();

        #region All About Discount

        public DataTable FetchDiscount()
        {
            try
            {
                return DBController.FetchDiscountPolicy();
            }
            catch
            {
                throw;
            }
        }

        public void AddDiscountPolicy(string productName, string manufacturer, string productID, DateTime effectiveDate, string bundleUnit, string freeItemQuantity, string discount)
        {
            try
            {
                DBController.AddDiscountPolicy(productName, manufacturer, productID, effectiveDate, bundleUnit, freeItemQuantity, discount);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteDiscountPolicy(string productID)
        {
            try
            {
                DBController.DeleteDiscountPolicy(productID);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateDiscountPolicy(string productID, DateTime effectiveDate, string unitBundle, string freeItemQuantity, string discount)
        {
            try
            {
                DBController.UpdateDiscountPolicy(productID, effectiveDate, unitBundle, freeItemQuantity, discount);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region All About Report

        public DataTable FetchReport()
        {
            return DBController.FetchReport();
        }

        public DataTable FetchYearlySummary(string startDate, string endDate)
        {
            return DBController.FetchYearlySummary(startDate, endDate);
        }

        public DataTable FetchYearlyProduct(string startDate, string endDate)
        {
            return DBController.FetchYearlyProduct(startDate, endDate);
        }

        public DataTable FetchYearlyShop(string startDate, string endDate)
        {
            return DBController.FetchYearlyShop(startDate, endDate);
        }

        public DataTable FetchMonthlySummary(DateTime startDate, DateTime endDate)
        {
            return DBController.FetchMonthlySummary(startDate, endDate);
        }

        public DataTable FetchMonthlyProduct(DateTime startDate, DateTime endDate)
        {
            return DBController.FetchMonthlyProduct(startDate, endDate);
        }

        public DataTable FetchMonthlyShop(DateTime startDate, DateTime endDate)
        {
            return DBController.FetchMonthlyShop(startDate, endDate);
        }

        public DataTable FetchDailySummary(DateTime startDate, DateTime endDate)
        {
            return DBController.FetchDailySummary(startDate, endDate);
        }

        public DataTable FetchDailyProduct(DateTime startDate, DateTime endDate)
        {
            return DBController.FetchDailyProduct(startDate, endDate);
        }

        public DataTable FetchDailyShop(DateTime startDate, DateTime endDate)
        {
            return DBController.FetchDailyShop(startDate, endDate);
        }

        #endregion
    }
}
