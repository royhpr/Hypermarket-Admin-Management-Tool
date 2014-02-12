using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

/****************************************
 *The class is responsible for adding, deleting or updating staff info
 *
 * Methods:
 * public bool IsValidUser(string staffID)
 * public bool VerifyUserIdAndPassword(string staffID, string password)
 * public bool IsLoginValid(string staffID)
 * public bool IsFirstTimeLogin(string staffID)
 * public bool IsPasswordExpired(string staffID)
 * public void ChangePassword(string staffID, string password)
 * public void AddStaff(string staffID, string name, DateTime dateOfBirth, DateTime joinDate,string gender, string religion, string position, string contact)
 * public void DeleteStaff(string staffID)
 * public void UpdateStaff(string staffID, string contact, string position)
 * public DataTable FetchStaff()
 * 
 * @Auther:
 * @Date:
 * *****************************************/

namespace Hypermarket_Admin_Management_Tool._2_Controller
{
    class AccountManager
    {
        private _1_Model.DBManager DBController = _1_Model.DBManager.getInstance();
        private _2_Controller.SecurityManager SecurityController = _2_Controller.SecurityManager.getInstance();
        private DataTable StaffList;

        # region Login

        public bool IsValidUser(string staffID)
        {
            try
            {
                StaffList = DBController.FetchStaff();
                foreach (DataRow dr in StaffList.Rows)
                {
                    if (dr[Constant.STAFF_ID].ToString().Equals(staffID))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool VerifyUserIdAndPassword(string staffID, string password)
        {
            try
            {
                StaffList = DBController.FetchStaff();
                foreach (DataRow dr in StaffList.Rows)
                {
                    if (dr[Constant.STAFF_ID].Equals(staffID) && 
                        SecurityController.Decrypt(dr[Constant.STAFF_PASSWORD].ToString()).Equals(password))
                    {
                        SetStaffInfoForDisplay(dr);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool IsBlocked(string staffID)
        {
            try
            {
                StaffList = DBController.FetchStaff();
                foreach (DataRow dr in StaffList.Rows)
                {
                    if (dr[Constant.STAFF_ID].Equals(staffID))
                    {
                        return Convert.ToBoolean(dr[Constant.STAFF_BLOCKED]);
                    }
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        private static void SetStaffInfoForDisplay(DataRow dr)
        {
            DateTime renewDate = Convert.ToDateTime(dr[Constant.STAFF_RENEWED_PASSWORD_DATE]);
            TimeSpan passwordValidDayLeft = renewDate - DateTime.Today;
            GlobalVariableAccessor.CurrentStaffName = dr[Constant.STAFF_NAME].ToString();
            GlobalVariableAccessor.PasswordValidDays = passwordValidDayLeft.Days.ToString();
            GlobalVariableAccessor.Position = dr[Constant.STAFF_POSITION].ToString();
            GlobalVariableAccessor.CurrentStaffID = dr[Constant.STAFF_ID].ToString();
            SetSalution(dr);
        }

        private static void SetSalution(DataRow dr)
        {
            if (dr[Constant.STAFF_GENDER].ToString().ToLower().Equals(Constant.MALE.ToLower()))
            {
                GlobalVariableAccessor.Salution = Constant.MR;
            }
            else
            {
                GlobalVariableAccessor.Salution = Constant.MS;
            }
        }

        #endregion


        #region Check First Time Login

        public bool IsFirstTimeLogin(string staffID)
        {
            StaffList = DBController.FetchStaff();
            try
            {
                foreach (DataRow dr in StaffList.Rows)
                {
                    if (dr[Constant.STAFF_ID].ToString().Equals(staffID))
                    {
                        return Convert.ToBoolean(dr[Constant.STAFF_IS_DEFAULT_PASSWORD]);
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region Check password expire

        public bool IsPasswordExpired(string staffID)
        {
            try
            {
                StaffList = DBController.FetchStaff();
                foreach (DataRow dr in StaffList.Rows)
                {
                    if (dr[Constant.STAFF_ID].ToString().Equals(staffID))
                    {
TimeSpan daysLeft = Convert.ToDateTime(dr[Constant.STAFF_RENEWED_PASSWORD_DATE].ToString()) - DateTime.Today;
                        if (Convert.ToInt16(daysLeft.Days.ToString()) <= Constant.CONSTANT_ZERO)
                        {
                            return true;
                        }
                        break;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckPasswordExpiredDate(DataRow dr)
        {
            DateTime renewPasswrdDate = Convert.ToDateTime(dr[Constant.STAFF_RENEWED_PASSWORD_DATE]);
            if (renewPasswrdDate.CompareTo(DateTime.Today) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region Change Password

        public void ChangePassword(string staffID, string password)
        {
            try
            {
                string newPassword = SecurityController.ComplexEncrypt(password);
                DBController.UpdateStaffPassword(staffID, newPassword);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ResetPassword(string staffID)
        {
            DBController.ResetStaffPassword(staffID);
        }

        #endregion


        #region Add Staff

        public void AddStaff(string staffID, string name, DateTime dateOfBirth, DateTime joinDate,
                            string gender, string position, string contact)
        {
            try
            {
                DateTime renewPasswordDate = DateTime.Today.AddDays(Constant.PASSWORD_VALID_DAYS);
                DBController.AddStaff(staffID, name, renewPasswordDate, dateOfBirth, joinDate, gender, position, contact, true, false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region DeleteStaff

        public void DeleteStaff(string staffID)
        {
            try
            {
                DBController.DeleteStaff(staffID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region UpdateStaff

        public void UpdateStaff(string staffID, string contact, string position, bool defaultPassword, bool blocked)
        {
            try
            {
                DBController.UpdateStaff(staffID, contact, position, defaultPassword, blocked);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region Fetch Staff

        public DataTable FetchStaff()
        {
            try
            {
                return DBController.FetchStaff();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
