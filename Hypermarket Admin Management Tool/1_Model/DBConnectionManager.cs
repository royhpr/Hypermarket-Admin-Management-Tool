using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Hypermarket_Admin_Management_Tool._1_Model
{
    class DBConnectionManager
    {
        public static DBConnectionManager DBConn;
        private string ConnectionString;
        private _2_Controller.SecurityManager SecurityProtector = _2_Controller.SecurityManager.getInstance();

        private DBConnectionManager()
        {
            SetConnectionString();
        }

        private void SetConnectionString()
        {
            try
            {
                string encryptedString = ConfigurationManager.ConnectionStrings["HypermarketHQ.Properties.Settings.HypermartHQConnectionString"].ConnectionString;
                ConnectionString = SecurityProtector.Decrypt(encryptedString);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static DBConnectionManager getInstance()
        {
            if (DBConn == null)
            {
                DBConn = new DBConnectionManager();
            }
            return DBConn;
        }

        public string getConnectionString()
        {
            return ConnectionString;
        }
    }
}
