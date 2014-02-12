using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hypermarket_Admin_Management_Tool
{
    class Constant
    {
        public const string DEFAULT_PASSWORD_ENCRYPTED = "D1qU/ibus6/wqtrUj1cWpA==";
        public const string DEFAULT_PASSWORD_NORMAL = "12345678";
        public const int CONSTANT_ZERO = 0;
        public const int PASSWORD_LIMITED_LENGTH = 8;
        public const int PRODUCT_ID_LENGTH = 8;
        public const int STAFF_ID_LENGTH = 4;
        public const int SHOP_ID_LENGTH = 4;
        public const char LEFT_PAD_CHAR = '0';
        public const string SEARCH_HINT = "type to search in any field...";
        public const string CONVERT_TO = "Convert(";
        public const string SYSTEM_STRING = ", 'System.String')";
        public const string NO_ROW_SELECTED = "Please select at least one row";
        public const string DELETE_SUCCESS = " has been successfully removed from database\nPlease wait...";
        public const string ERROR_DURING_POPULATING_LIST = "Error occurred while retriving data";
        /*****************All About Discount Table************************/
        public const string DISCOUNT_TABLE = "discount";
        //Columns
        public const string D_M_NAME = "ManufacturerName";
        public const string D_P_NAME = "ProductName";
        public const string D_P_ID = "ProductID";
        public const string D_EFFECTIVE_DATE = "EffectiveDate";
        public const string D_BUNDLE_UNIT = "BundleUnit";
        public const string D_FREE_ITEM_QUANTITY = "FreeItemQuantity";
        public const string D_DISCOUNT_PERCENTAGE = "Discount";

        public const string ERROR_INVALID_PRODUCT_NAME = "Invalid product name! Please select one from Product Name dropdown list.";
        public const string ERROR_INVALID_MANUFACTURER = "Invalid manufacturer name! Please select one from Manufacturer dropdown list.";
        public const string ERROR_INVALID_UNIT_BUNDLE = "Invalid unit bundle! Please specify a valid integer.";
        public const string ERROR_INVALID_FREE_QUANTITY = "Invalid free quantity! Please specify a valid integer.";
        public const string ERROR_INVALID_DISCOUNT = "Invalid discount! Please specify a valid numeric";
        public const string ERROR_EXIST_DISCOUNT_ITEM = "There is existing discount policy associated with provide product.\nPlease choose another product.";
        /*****************End Discount Table*******************************/

        /*****************All About Manufacturer Table********************/
        public const string MANUFACTURER_TABLE = "manufacturer";
        //Columns
        public const string M_NAME = "ManufacturerName";
        public const string M_COUNTRY = "Country";
        public const string M_ADDRESS = "Address";
        public const string M_CONTACT = "Contact";
        /******************End Manufacturer Table**************************/

        /******************All About Product Table************************/
        public const string PRODUCT_TABLE = "product";
        //Columns
        public const string P_M_Name = "ManufacturerName";
        public const string P_ID = "ProductID";
        public const string P_NAME = "Name";
        public const string P_CATEGORY = "Category";
        public const string P_MAX = "MaximumStock";
        public const string P_MIN = "MinimumStock";

        public const string Product_Check_Stock = "SELECT SUM(s.Quantity) FROM Product p, Stock s WHERE P.ProductID=s.ProductID AND p.ProductID=@ProductID";
        /*****************End Product Table********************************/


        /******************All About Report Table************************/
        public const string REPORT_TABLE = "report";
        //Columns
        public const string R_REPORT_DATE = "ReportDate";
        public const string R_S_COUNTRY = "Country";
        public const string R_S_LOCATION = "Location";
        public const string R_S_ID = "ShopID";
        public const string R_P_ID = "ProductID";
        public const string R_P_NAME = "Name";
        public const string R_P_MANUFACTURER = "ManufacturerName";
        public const string R_UNIT_SOLD = "UnitSold";
        public const string R_COST_PRICE = "CostPrice";
        public const string R_SELLING_PRICE = "SellingPrice";
        public const string R_REVENUE = "Revenue";
        public const string R_STAFF_ID = "StaffID";

        public const string YEARLY_SUMMARY_TABLE = "yearlysummarytable";
        public const string YEARLY_PRODUCT_TABLE = "yearlyproducttable";
        public const string YEARLY_SHOP_TABLE = "yearlyshoptable";
        public const string MONTHLY_SUMMARY_TABLE = "monthlysummarytable";
        public const string MONTHLY_PRODUCT_TABLE = "monthlyproducttable";
        public const string MONTHLY_SHOP_TABLE = "monthlyshoptable";
        public const string DAILY_SUMMARY_TABLE = "dailysummarytable";
        public const string DAILY_PRODUCT_TABLE = "dailyproducttable";
        public const string DAILY_SHOP_TABLE = "dailyshoptable";
        /*****************End Report Table********************************/


        /******************All About Request Table************************/
        public const string REQUEST_TABLE = "request";
        //Columns
        public const string RE_P_NAME = "Name";
        public const string RE_M_NAME = "ManufacturerName";
        public const string RE_P_ID = "ProductID";
        public const string RE_S_ID = "ShopID";
        public const string RE_S_COUNTRY = "ShopCountry";
        public const string RE_S_LOCATION = "ShopLocation";
        public const string RE_REQUEST_DATE = "RequestDate";
        public const string RE_QUANTITY = "Quantity";
        public const string RE_URGENCY = "Urgency";

        public const string RE_NO_VALID_SELECTION = "No selection!";
        public const string RE_SUCCESSFULLY_SEND = "Stock has been updated successfully!";
        public const string SUCCESSFULLY_REFRESH_REQUEST = "Request has been successfully updated!";
        public const string ERROR_REFRESH_REQUEST = "Error occurred during request synchronization.";
        public const string ERROR_NEXT_ACTION = "Please retry in a while.\nIf error persist, please contact system admin";
        /*****************End Request Table********************************/


        /******************All About RequestApproveStatus Table************************/
        public const string REQUEST_APPROVE_STATUS_TABLE = "requestapprovestatus";
        public const string PENDING_REQUEST_TABLE = "pendingRequest";
        public const string APPROVED_REQUEST_TABLE = "approvedRequest";
        public const string REJECTED_REQUEST_TABLE = "rejectedRequest";
        //Columns
        public const string RE_AP_M_Name = "ManufacturerName";
        public const string RE_AP_P_Name = "ProductName";
        public const string RE_AP_P_ID = "ProductID";
        public const string RE_AP_S_ID = "ShopID";
        public const string RE_AP_S_COUNTRY = "ShopCountry";
        public const string RE_AP_S_LOCATION = "Location";
        public const string RE_AP_REQUEST_DATE = "RequestDate";
        public const string RE_AP_STAFF_ID = "StaffID";
        public const string RE_AP_APPROVED = "Approved";
        public const string RE_AP_APPROVED_DATE = "ApprovedDate";
        public const string RE_AP_REJECTED_DATE = "RejectedDate";
        public const string RE_AP_SEND_DATE = "SendDate";
        public const string RE_AP_QUANTITY = "Quantity";
        public const string RE_AP_URGENCY = "Urgency";
        public const string RE_AP_DELEVERY_STATUS = "DeliveryStatus";
        /*****************End RequestApproveStatus Table********************************/


        /******************All About Shop Table************************/
        public const string SHOP_TABLE = "shop";
        //Columns
        public const string S_ID = "ShopID";
        public const string S_COUNTRY = "Country";
        public const string S_LOCATION = "Location";
        public const string S_CONTACT = "Contact";
        /*****************End Shop Table********************************/


        /******************All About Stafff Table************************/
        public const string STAFF_TABLE = "staff";
        //Columns
        public const string STAFF_ID = "StaffID";
        public const string STAFF_NAME = "Name";
        public const string STAFF_PASSWORD = "Password";
        public const string STAFF_RENEWED_PASSWORD_DATE = "RenewPasswordDate";
        public const string STAFF_DATE_OF_BIRTH = "DateOfBirth";
        public const string STAFF_JOIN_DATE = "JoinDate";
        public const string STAFF_GENDER = "Gender";
        public const string STAFF_POSITION = "Position";
        public const string STAFF_CONTACT = "Contact";
        public const string STAFF_IS_DEFAULT_PASSWORD = "DefaultPassword";
        public const string MALE = "Male";
        public const string STAFF_BLOCKED = "Blocked";
        public const string FEMALE = "Female";
        public const string MR = " (Mr) ";
        public const string MS = " (Ms) ";
        public const string SPACE = " ";
        public const string COMMA = ",";
        public const string GREETING0 = "Welcome";
        public const string GREETING1 = " your password will be expired after ";
        public const string DAYS = " day(s)";
        /*****************End Staff Table********************************/


        /******************All About Stock Table************************/
        public const string STOCK_TABLE = "stock";
        //Columns
        public const string STOCK_M_NAME = "ManufacturerName";
        public const string STOCK_P_NAME = "ProductName";
        public const string STOCK_P_ID = "ProductID";
        public const string STOCK_BATCH_ID = "BatchID";
        public const string STOCK_IMPORT_PRICE = "ImportPrice";
        public const string STOCK_SELL_PRICE = "SellingPrice";
        public const string STOCK_EXPIRE_DATE = "ExpireDate";
        public const string STOCK_QUANTITY = "Quantity";
        public const string STOCK_DEFAULT_DISCOUNT_POLICY = "DefaultDiscountPolicy";
        /*****************End Stock Table********************************/

        /******************All About Send Stock Table********************/
        public const string SEND_STOCK_TABLE = "outgoing request";
        /******************End Send Stock Table***************************/


        /*****************Select Commands*************************************/
        public const string SHOP_TABLE_SELECT_COMMAND = "SELECT * FROM shop";
        public const string PRODUCT_TABLE_SELECT_COMMAND = "SELECT * FROM product";
        public const string STOCK_TABLE_SELECT_COMMAND = "SELECT * FROM view_stock";
        public const string MANUFACTURER_TABLE_SELECT_COMMAND = "SELECT * FROM manufacturer";
        public const string STAFF_TABLE_SELECT_COMMAND = "SELECT * FROM staff";
        public const string DISCOUNT_TABLE_SELECT_COMMAND = "SELECT * FROM view_discount";
        public const string SEND_STOCK_TABLE_SELECT_COMMAND = "SELECT * FROM view_send_stock";
        public const string PENDING_REQUEST_TABLE_SELECT_COMMAND = "SELECT * FROM view_pending_request";
        public const string APPROVED_REQUEST_TABLE_SELECT_COMMAND = "SELECT * FROM view_approved_request";
        public const string REJECTED_REQUEST_TABLE_SELECT_COMMAND = "SELECT * FROM view_rejected_request";
        public const string REPORT_TABLE_SELECT_COMMAND = "SELECT * FROM view_report";
        public const string YEARLY_SUMMARY_TABLE_SELECT_COMMAND = "SELECT * FROM view_yearly_summary_report('{0}','{1}')";
        public const string YEARLY_PRODUCT_TABLE_SELECT_COMMAND = "SELECT * FROM view_yearly_product_report('{0}','{1}')";
        public const string YEARLY_SHOP_TABLE_SELECT_COMMAND = "SELECT * FROM view_yearly_shop_report('{0}','{1}')";
        public const string MONTHLY_SUMMARY_TABLE_SELECT_COMMAND = "SELECT * FROM view_monthly_summary_report('{0}','{1}')";
        public const string MONTHLY_PRODUCT_TABLE_SELECT_COMMAND = "SELECT * FROM view_monthly_product_report('{0}','{1}')";
        public const string MONTHLY_SHOP_TABLE_SELECT_COMMAND = "SELECT * FROM view_monthly_shop_report('{0}','{1}')";
        public const string DAILY_SUMMARY_TABLE_SELECT_COMMAND = "SELECT * FROM view_daily_summary_report('{0}','{1}')";
        public const string DAILY_PRODUCT_TABLE_SELECT_COMMAND = "SELECT * FROM view_daily_product_report('{0}','{1}')";
        public const string DAILY_SHOP_TABLE_SELECT_COMMAND = "SELECT * FROM view_daily_shop_report('{0}','{1}')";
        /********************End Select Commands******************************/

        /*****************Update Commands****************************************/
        public const string UPDATE_STOCK_COMMAND = "UPDATE stock SET ImportPrice=@ImportPrice, SellingPrice=@SellingPrice, ExpireDate=@ExpireDate, Quantity=@Quantity WHERE ProductID=@ProductID AND BatchID=@BatchID";
        public const string REDUCE_STOCK_QUANTITY_COMMAND = "UPDATE stock SET Quantity=@Quantity WHERE ProductID=@ProductID AND BatchID=@BatchID";
        public const string UPDATE_DISCOUNT_COMMAND = "UPDATE discount SET EffectiveDate=@EffectiveDate, BundleUnit=@BundleUnit, FreeItemQuantity=@FreeItemQuantity, Discount=@Discount WHERE ProductID=@ProductID";
        public const string UPDATE_SEND_STOCK_COMMAND = "UPDATE SendStock SET SendDate=@SendDate, DeliveryStatus=@DeliveryStatus WHERE ProductID=@ProductID AND BatchID=@BatchID AND ShopID=@ShopID AND ConfirmDate=@ConfirmDate";
        /******************End Update Commands************************************/

        /******************Add Commands*******************************************/
        public const string ADD_STOCK_COMMAND = "INSERT INTO stock VALUES (@ProductID, @BatchID, @ImportPrice, @SellingPrice, @ExpireDate, @Quantity, @DefaultDiscount)";
        public const string ADD_APPROVED_REQUEST_COMMAND = "INSERT INTO RequestApproveStatus VALUES (@ProductID, @ShopID, @RequestDate, @StaffID, @Approved, @ApprovedQuantity, @ActionDate, @Comments)";
        public const string ADD_REJECT_REQUEST_COMMAND = "INSERT INTO RequestApproveStatus (ProductID, ShopID, RequestDate, StaffID, Approved, ActionDate) VALUES(@ProductID, @ShopID, @RequestDate, @StaffID, @Approved, @ActionDate)";
        public const string ADD_SEND_STOCK_COMMAND = "INSERT INTO SendStock (ProductID, BatchID, ShopID, ConfirmDate, DeliveryStatus, ReceiveStatus, Quantity) VALUES (@ProductID, @BatchID, @ShopID, @ConfirmDate, @DeliveryStatus, @ReceiveStatus, @Quantity)";
        public const string ADD_DISCOUNT_COMMAND = "INSERT INTO Discount VALUES (@ProductID, @EffectiveDate, @BundleUnit, @FreeItemQuantity, @Discount)";
        /*********************End Add Commands*************************************/

        /*************************Delete Commands***********************************/
        public const string DELETE_PENDING_REQUEST_COMMAND = "DELETE FROM request WHERE ProductID=@ProductID AND ShopID=@ShopID AND RequestDate=@RequestDate";
        public const string DELETE_REJECTED_REQUEST_COMMAND = "DELETE FROM requestapprovestatus WHERE ProductID=@ProductID AND ShopID=@ShopID AND RequestDate=@RequestDate AND StaffID=@StaffID";
        public const string DELETE_SEND_STOCK_COMMAND = "DELETE FROM send_stock WHERE ProductID=@ProductID AND BatchID=@BatchID AND ShopID=@ShopID";
        public const string REQUEST_STATUS_SWITCH_COMMAND = "UPDATE RequestApproveStatus SET Approved=@Approved, ActionDate=@ActionDate, WHERE Product=@ProductID AND ShopID=@ShopID AND RequestDate=@RequestDate AND StaffID=@StaffID";
        public const string DELETE_DISCOUNT_COMMAND = "DELETE FROM Discount WHERE ProductID=@ProductID";
        /******************************End Delete Commands*****************************/

        /***********************************Parameters*********************************/
        public const string IMPORT_PRICE = "@ImportPrice";
        public const string SELL_PRICE = "@SellingPrice";
        public const string EXPIRE_DATE = "@ExpireDate";
        public const string PRODUCT_ID = "@ProductID";
        public const string BATCH_ID = "@BatchID";
        public const string A = "@A";
        public const string B = "@B";
        public const string SD = "@SD";
        public const string ED = "@ED";
        public const string APPROVED = "@Approved";
        public const string QUANTITY = "@Quantity";
        public const string APPROVED_QUANTITY = "@ApprovedQuantity";
        public const string DEFAULT_DISCOUNT = "@DefaultDiscount";
        public const string URGENCY = "@Urgency";
        public const string SHOP_ID = "@ShopID";
        public const string CONFIRM_DATE = "@ConfirmDate";
        public const string REQUEST_DATE = "@RequestDate";
        public const string ACTION_DATE = "@ActionDate";
        public const string COMMENTS = "@Comments";
        public const string SEND_DATE = "@SendDate";
        public const string DELIVERY_STATUS = "@DeliveryStatus";
        public const string RECEIVE_STATUS = "@ReceiveStatus";
        public const string EFFECTIVE_DATE = "@EffectiveDate";
        public const string BUNDLE_UNIT = "@BundleUnit";
        public const string FREE_ITEM_QUANTITY = "@FreeItemQuantity";
        public const string DISCOUNT = "@Discount";
        /************************************End Parameters*****************************/

        /******************All About AccountManager***************************/
        public const int PASSWORD_VALID_DAYS = 180;
        /************************End AccountManager***************************/

        /******************Error Message**************************************/
        public const string ACTUAL_ERROR = "\n\nActuall Error: ";
        public const string ERROR_FETCH = "system error: error occurred while trying to fetch ";
        public const string ERROR_ADD = "system error: error occurred while trying to add ";
        public const string ERROR_DELETE = "system error: error occurred while trying to delete ";
        public const string ERROR_UPDATE = "system error: error occurred while trying to update ";
        public const string ERROR_CHANGE_STATUS = "system error: error occurred while changing request status ";
        public const string ERROR_VERIFYING_USER = "system error: error occurred while verifying  staff ID ";
        public const string ERROR_VERIFYING_PASSWORD = "system error: error occurred while verifying password ";
        public const string ERROR_CHECK_DEFAULT_PASSWORD = "system error: error occurred while checking default password ";
        public const string ERROR_UPDATE_PASSWORD = "system error: error occurred while updating password ";
        public const string ERROR_GENERATE_SHOP_ID = "system error: error occurred while generating shop ID";
        public const string ERROR_GENERATE_PRODUCT_ID = "system error: error occurred while generating product ID";
        public const string ERROR_SEARCH_VERIFY_CONTENT = "system error: error occurred during verify textbox content";
        public const string ERROR_SEARCH = "system error: error occurred while search the list";
        public const string ERROR_PRODUCT_CHECK_STOCK = "system error: error occurred while checking stock for products";
        /******************End Error Message***********************************/


        /********************Login***************************/
        public const string ERROR_INVALID_USER_ID = "Invalid User ID";
        public const string ERROR_WRONG_PASSWORD = "Wrong Password";
        public const string ERROR_EMPTY_USER_ID = "No Empty or white spaces allowed in ID";
        public const string ERROR_EMPTY_PASSWORD = "No Empty or white spaces allowed in psw";
        public const string ERROR_EMPTY_NEW_PASSWORD = "Empty or white spaces are disallowed";
        public const string ERROR_EMPTY_REENTER_PASSWORD = "Please re-enter above new password";
        public const string ERROR_PASSWORD_MISMATCH = "Above passwords are different";
        public const string ERROR_PASSWORD_LENGTH = "Password length must be at least 8,\n with alphanumeric";
        /********************End Login***********************/

        /********************Account*************************/
        public const int RENEW_PASSWORD_DAYS = 180;
        /********************End Account*********************/
        /********************Staff Position******************/
        public const string ADMIN = "Admin";
        public const string PRODUCT_MANAGER = "Product Manager";
        public const string SALES_MANAGER = "Sales Manager";
        public const string WAREHOUSE_MANAGER = "Warehouse Manager";
        public const string PRODUCT_OFFICER = "Product Officer";
        public const string SALES_OFFICER = "Sales Officer";
        public const string WAREHOUSE_OFFICER = "Warehouse Officer";
        /*******************End Staff Postion****************/

        /******************Operation interface****************/
        public const string ERROR_REMOVE_TABPAGE = "system error: error occurred while removing tabpages";
        public const string OPERATION_TAB_SHOP = "tbManageShops";
        public const string OPERATION_TAB_PRODUCT = "tbManageProducts";
        public const string OPERATION_TAB_STOCK = "tbManageStock";
        public const string OPERATION_TAB_REPORT = "tbViewReport";
        public const string OPERATION_TAB_ORDER = "tbViewOrder";
        public const string OPERATION_TAB_MANUFACTURER = "tbViewManufacturerList";
        public const string OPERATION_TAB_STAFF = "tbViewStaffList";
        public const string OPERATION_TAB_DISCOUNT = "tbDiscountPolicy";
        public const string OPERATION_TAB_PROFILE = "tbProfile";
        public const string OPERATION_TAB_PENDING = "tbPending";
        public const string OPERATION_TAB_APPROVED = "tbApproved";
        public const string OPERATION_TAB_REJECTED = "tbRejected";
        public const string OPERATION_TAB_OUTGOING = "tbOutgoing";

        public const string OPERATION_LIKE = " LIKE ";
        public const string OPERATION_OR = " OR ";
        public const string OPERATION_PERCENT = "%";
        public const string OPERATION_EMPTY = "";
        public const string OPERATION_SINGLE_QUOTE = "'";
        public const string OPERATION_DOUBLE_SINGLE_QUOTE = "''";
        public const int OPERATION_INDEX_ZERO = 0;
        public const int OPERATION_INDEX_ONE = 1;
        public const int OPERATION_INDEX_TWO = 2;
        public const int OPERATION_INDEX_THREE = 3;
        public const int OPERATION_INDEX_FOUR = 4;
        public const int OPERATION_INDEX_FIVE = 5;
        public const int OPERATION_INDEX_SIX = 6;
        public const int OPERATION_INDEX_SEVEN = 7;
        public const int OPERATION_INDEX_EIGHT = 8;
        public const int OPERATION_INDEX_NINE = 9;
        public const int OPERATION_INDEX_TEN = 10;

        public const string OPERATION_UNSELECT_ALL = "Unselect All";
        public const string OPERATION_SELECT_ALL = "Select All";
        /******************End Operation interface************/

        /******************Error in add shop******************/
        public const string ERROR_ADD_SHOP_EMPTY_COUNTRY = "Country can not be empty";
        public const string ERROR_ADD_SHOP_EMPTY_LOCATION = "Location can not be empty";
        public const string ERROR_ADD_SHOP_EMPTY_CONTACT = "Contact can not be empty";
        public const string ERROR_ADD_SHOP_WRONG_CONTACT = "Contact must be numeric";
        /******************End error in add shop**************/

        /******************Error in add product**************/
        public const string ERROR_ADD_PRODUCT_EMPTY_MANUFACTURER = "Manufacturer can not be empty";
        public const string ERROR_ADD_PRODUCT_EMPTY_CATEGORY = "Category can not be empty";
        public const string ERROR_ADD_PRODUCT_EMPTY_NAME = "Product name can not be empty";
        public const string ERROR_ADD_PRODUCT_EMPTY_MAXSTOCK = "Maximum stock can not be empty";
        public const string ERROR_ADD_PRODUCT_EMPTY_MINSTOCK = "Minimum stock can not be empty";
        public const string ERROR_ADD_PRODCUT_MANUFACTURER_NO_EXIST = "Could not find manufacturer in current database.\nPlease add new manufacturer or select one from list";
        public const string ERROR_ADD_PRODUCT_CATEGORY_NO_EXIST = "Please select one category from dropdown list";
        public const string ERROR_ADD_PRODUCT_SAME_NAME_SAME_MANUFACTURER = "Same product name detected under current maufacturer. \nPlease specify another name!";
        public const string ERROR_ADD_PRODUCT_MAXSTOCK = "Maximum stock must be numeric";
        public const string ERROR_ADD_PRODUCT_MINSTOCK = "Minimum stock must be numeric";
        public const string ERROR_ADD_PRODUCT_MAXSTOCK_COMPARE_MINSTOCK = "Maximum stock must be greater than minimum stock";
        public const string ERROR_ADD_PRODUCT_MINSTOCK_LESS_THAN_ZERO = "Minimum stock must be greater than zero";

        public const string WARNING_PRODUCT_REMOVE_INSALE_PRODUCT_HEADER = "In sale Product(s) with ID ";
        public const string WARNING_RPODCUT_REMOVE_INSALE_PRODUCT_FOOTER_0 = " can not be removed! ";
        public const string WARNING_PRODUCT_REMOVE_INSALE_PRODUCT_FOOTER_1 = "Click ok to continue deleting others?";


        /*******************End add product******************/

        /*******************Error in add manufacturer**********/
        public const string ERROR_ADD_MANUFACTURER_EMPTEY_MANUFACTURER_NAME = "Name can not be empty";
        public const string ERROR_ADD_MANUFACTURER_EMPTEY_ADDRESS = "Address can not be empty";
        public const string ERROR_ADD_MANUFACTURER_EMPTEY_COUNTRY = "Country can not be empty";
        public const string ERROR_ADD_MANUFACTURER_EMPTEY_CONTACT = "Contact can not be empty";
        public const string ERROR_ADD_MANUFACTURER_MISMATCH_COUNTRY = "Please select one country from above list";
        public const string ERROR_ADD_MANUFACTURER_EXIST_NAME = "Name exist in database!\nPlease specify another one.";
        public const string EQUAL = " = ";
        public const string ERROR_ADD_MANUFACTURER_IVALID_CONTACT = "Contact must be numeric";
        /*******************End add manufacturer****************/

        /******************Error in add stock******************/
        public const string ERROR_ADD_STOCK_EMPTY_PRODUCT_NAME = "Please select one product from above list";
        public const string ERROR_ADD_STOCK_EMPTY_MANUFACTURER_NAME = "Please select one manufacturer from above list";
        public const string ERROR_ADD_STOCK_EMPTY_IMPORT_PRICE = "Please specify import price";
        public const string ERROR_ADD_STOCK_EMPTY_SELL_PRICE = "Please specify sell price";
        public const string ERROR_ADD_STOCK_EMPTY_QUANTITY = "Please specify quantity";
        public const string ERROR_ADD_STOCK_INVALID_IMPORT_PRICE = "Import price must be numeric";
        public const string ERROR_ADD_STOCK_INVALID_SELL_PRICE = "Sell price must be numeric";
        public const string ERROR_ADD_STOCK_INVALID_QUANTITY = "Quantity must be integer";
        public const string ERROR_ADD_STOCK_INVALID_DATE = "Batch ID (manufacture date) must\n be earlier than expire date";
        public const string ERROR_ADD_STOCK_INVALID_PRODUCT = "Invalid Product!\n Please re-select from above list";
        public const string ERROR_ADD_STOCK_PRODUCT_BATCH_EXIST = "Same product batch exist in database!\n Please specify another batch or proceed\n to edit stock instead of add";
        public const string ADD_STOCK_PRDUCT_GROUP_BOX_CAPTION = "Product Information";
        /******************End add stock*************************/

        /******************Error in add staff**********************/
        public const string ERROR_ADD_STAFF_EMPTY_NAME = "Please specify name of staff";
        public const string ERROR_ADD_STAFF_EMPTY_GENDER = "Please choose gender of staff";
        public const string ERROR_ADD_STAFF_EMPTY_EMAIL = "Please specify email  of staff";
        public const string ERROR_ADD_STAFF_EMPTY_CONTACT = "Please specify contact of staff";
        public const string ERROR_ADD_STAFF_EMPTY_POSITION = "Please specify position of staff";
        public const string ERROR_ADD_STAFF_WRONG_DATE_OF_BIRTH = "Date of birth must not later than today";
        public const string ERROR_ADD_STAFF_WRONG_CONTACT = "Contact must be numeric";
        public const string ERROR_ADD_STAFF_WRONG_POSITION = "Please specify position from list above";
        /*******************End add staff**************************/

        /******************About Delete********************/
        public const string CONFIRM_DELETE_SHOP = "Do you want to delete selected item(s)?\nAll requests associated with it will be\nremoved from database!";
        public const string CONFIRM_DELETE_PRODUCT = "Do you want to remove selected products?\n All stock and requests associated with it will be\nremoved accordingly!";
        public const string CONFIRM_DELETE_STAFF = "Do you want to remove selected staff from system permanently?";
        public const string CONFIRM_DELETE_DISCOUNT = "Do you want to remove selected discount policy from system permanently?";
        /********************************************************/

        /*****************All About Message box***************/
        public const string MSG_ERROR = "Error";
        public const string MSG_WARNING = "Warning";
        public const string MSG_AUTO_CLOSE = "Auto";
        /*****************End Message box**********************/

        /*****************All about search*********************/
        public const string SEARCH_SHOP = Constant.S_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.S_LOCATION + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.S_COUNTRY + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.S_CONTACT + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE;

        public const string SEARCH_PRODUCT = Constant.P_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.P_NAME + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.P_M_Name + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.P_CATEGORY + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.P_MAX + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.P_MIN + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE;

        public const string SEARCH_STOCK = Constant.STOCK_P_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.STOCK_P_NAME + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.STOCK_M_NAME + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.STOCK_BATCH_ID + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.STOCK_IMPORT_PRICE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.STOCK_SELL_PRICE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.STOCK_EXPIRE_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.STOCK_QUANTITY + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE;

        public const string SEARCH_PENDING_REQUEST = Constant.RE_AP_P_Name + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.RE_M_NAME + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.RE_P_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.RE_S_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.RE_S_COUNTRY + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.RE_S_LOCATION + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_REQUEST_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_QUANTITY + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_AP_URGENCY + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE;

        public const string SEARCH_APPROVED_REQUEST = Constant.RE_AP_P_Name + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.RE_AP_M_Name + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.RE_AP_P_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.RE_AP_S_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.RE_AP_S_COUNTRY + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.RE_AP_S_LOCATION + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_AP_REQUEST_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_AP_APPROVED_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.RE_AP_STAFF_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_QUANTITY + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                            + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_AP_URGENCY + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE;

        public const string SEARCH_REJECTED_REQUEST = Constant.RE_AP_P_Name + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.RE_AP_M_Name + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.RE_AP_P_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.RE_AP_S_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.RE_AP_S_COUNTRY + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.RE_AP_S_LOCATION + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_AP_REQUEST_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_AP_REJECTED_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.RE_AP_STAFF_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_QUANTITY + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.URGENCY + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE;


        public const string SEARCH_OUTGOING_REQUEST = Constant.RE_AP_P_Name + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.RE_AP_M_Name + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.RE_AP_P_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.STOCK_BATCH_ID + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.RE_AP_S_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.RE_AP_S_COUNTRY + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.RE_AP_S_LOCATION + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_AP_REQUEST_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_AP_SEND_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.RE_QUANTITY + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.DELIVERY_STATUS + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE;

        public const string SEARCH_MANUFACTURER = Constant.M_NAME + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.M_ADDRESS + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.M_COUNTRY + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.M_CONTACT + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE;


        public const string SEARCH_STAFF = Constant.STAFF_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.STAFF_NAME + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.STAFF_PASSWORD + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.STAFF_RENEWED_PASSWORD_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.STAFF_DATE_OF_BIRTH + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.STAFF_JOIN_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.STAFF_GENDER + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.STAFF_POSITION + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.STAFF_CONTACT + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.STAFF_IS_DEFAULT_PASSWORD+ Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.STAFF_BLOCKED + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE;

        public const string SEARCH_DISCOUNT = Constant.D_P_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.D_P_NAME + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.D_M_NAME + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.D_EFFECTIVE_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.D_BUNDLE_UNIT + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.D_FREE_ITEM_QUANTITY + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                    + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.D_DISCOUNT_PERCENTAGE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE;

        public const string SEARCH_REPORT = Constant.CONVERT_TO + Constant.R_REPORT_DATE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                   + Constant.OPERATION_OR + Constant.R_S_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                   + Constant.OPERATION_OR + Constant.R_P_ID + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                   + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.R_UNIT_SOLD + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                   + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.R_COST_PRICE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                   + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.R_SELLING_PRICE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                   + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.R_REVENUE + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE
                                   + Constant.OPERATION_OR + Constant.CONVERT_TO + Constant.R_STAFF_ID + Constant.SYSTEM_STRING + Constant.OPERATION_LIKE + Constant.OPERATION_SINGLE_QUOTE + Constant.OPERATION_PERCENT + "{0}" + Constant.OPERATION_PERCENT + Constant.OPERATION_SINGLE_QUOTE;

        /******************End search*****************************/

        /*******************Search box****************************/
        public const string SHOP_SEARCH_BOX = "txtKeywordShop";
        public const string PRODUCT_SEARCH_BOX = "txtKeywordProduct";
        public const string STOCK_SEARCH_BOX = "txtKeywordStock";
        public const string PENDING_SEARCH_BOX = "txtKeywordPending";
        public const string APPROVED_SEARCH_BOX = "txtKeywordApproved";
        public const string REJECTED_SEARCH_BOX = "txtKeywordRejected";
        public const string OUTGOING_SEARCH_BOX = "txtKeywordOutgoing";
        public const string MANUFACTURER_SEARCH_BOX = "txtKeywordManufacturer";
        public const string STAFF_SEARCH_BOX = "txtKeywordStaff";
        public const string DISCOUNT_SEARCH_BOX = "txtKeywordDiscount";
        public const string REPORT_SEARCH_BOX = "txtKeywordReport";
        /*******************End Search box************************/

        /********************Approve request************************/
        public const string ERROR_APPROVE_EMPTY_QUANTITY = "Approved quantity can not be empty";
        public const string ERROR_APPROVE_EXCEED_AVAILABLE_QUANTITY = "Approved quantity can not exceed available amount";
        public const string ERROR_APPROVE_WRONG_QUANTITY = "Approved quantity must be numeric";
        public const string ERROR_APPROVE_SMALL_EQUAL_ZERO = "Approve quantity must be at least one";
        /********************End Approve Request********************/

        /*********************Alert************************/
        public const string ALERT_SELECT_COMMAND = "SELECT * FROM view_alert_minimum_stock";
        public const string ALERT_COUNT_COMMAND = "SELECT COUNT(*) FROM view_alert_minimum_stock";
        public const string LESS_THAN_MINIMUM_STOCK_FILE_NAME = " LessThanMinimum";
        public const string NOTHING_TO_EXPORT = "Nothing can be exported!";
        public const string EXPORT_SUCCESS = "Exported Successfully!\nPlease find the exported text file \"LessThanMinimum.txt\" in the program directory.";
        /**********************End Alert*********************/
    }
}
