using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hypermarket_Admin_Management_Tool._0_View
{
    public enum ReportType { Daily, Monthly, Yearly };

    public struct SearchboxPair
    {
        public BindingSource currentBindingSource { get; set; }
        public PictureBox currentIconBox { get; set; }
        public string currentFilterQuery { get; set; }
    }

    public partial class Operation : Form
    {
        private _2_Controller.CoordinatingController mainController = _2_Controller.CoordinatingController.getInstance();
        private BindingSource shopBindingSource = new BindingSource();
        private BindingSource productBindingSource = new BindingSource();
        private BindingSource stockBindingSource = new BindingSource();
        private BindingSource pendingRequestBindingSource = new BindingSource();
        private BindingSource rejectedRequestBindingSource = new BindingSource();
        private BindingSource approvedReuestBindingSource = new BindingSource();
        private BindingSource outgoingRequestBindingSource = new BindingSource();
        private BindingSource manufacturerBindingSource = new BindingSource();
        private BindingSource staffBindingSource = new BindingSource();
        private BindingSource discountBindingSource = new BindingSource();
        private BindingSource reportBindingSource = new BindingSource();

        public Operation()
        {
            InitializeComponent();
        }

        public Operation(string tabName)
        {
            InitializeComponent();
            RemoveTabpages();
            tcOperation.SelectTab(tabName);
            SetUpTabPageInterface(tcOperation);
            //DisableSomeFunctions();
            InitializeShopBindingSource();
            InitializeProductBindingSource();
            InitializeStockBindingSource();
            InitializePendingRequestBindingSource();
            InitializeApprovedRequestBindingSource();
            InitializeRejectedRequestBindingSource();
            InitializeOutgoingRequestBindingSource();
            InitializeStaffBindingSource();
            InitializeManufacturerBindingSource();
            InitializeDiscountBindingSource();
            InitializeReportBindingSource();
        }

        private void Operation_Load(object sender, EventArgs e)
        {
            initializeProfile();
            UpdateGreeting(GlobalVariableAccessor.PasswordValidDays);

            if (IsAnyProductLessThanMinimumStock())
            {
                Alert alertView = new Alert();
                alertView.del = new SelectStockTabpage(SelectStockPage);
                alertView.ShowDialog();
            }
        }

        private void llblChangePsw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword frmChangePsw = new ChangePassword();
            frmChangePsw.ShowDialog();
            UpdateGreeting(GlobalVariableAccessor.PasswordValidDays);
        }

        public void UpdateGreeting(string days)
        {
            lblGreeting.Text = Constant.GREETING0 + GlobalVariableAccessor.Salution + GlobalVariableAccessor.CurrentStaffName + Constant.COMMA + Constant.GREETING1 + days + Constant.DAYS;
        }

        private void SelectStockPage()
        {
            tcOperation.SelectTab(Constant.OPERATION_TAB_STOCK);
        }

        private bool IsAnyProductLessThanMinimumStock()
        {
            _1_Model.DBConnectionManager DBConn = _1_Model.DBConnectionManager.getInstance();
            using (SqlConnection SQLConn = new SqlConnection(DBConn.getConnectionString()))
            using (SqlCommand SQLComm = new SqlCommand(Constant.ALERT_COUNT_COMMAND, SQLConn))
            {
                SQLConn.Open();
                int i = (int)SQLComm.ExecuteScalar();
                SQLConn.Close();
                if (i > Constant.CONSTANT_ZERO)
                {
                    return true;
                }
            }
            return false;
        }

        #region Intialize Binding Source

        private void InitializeShopBindingSource()
        {
            shopBindingSource.DataSource = mainController.GetListOfShops();
            dgvShopsInfo.AutoGenerateColumns = false;
            dgvShopsInfo.DataSource = shopBindingSource;
        }

        private void InitializeProductBindingSource()
        {
            productBindingSource.DataSource = mainController.GetListOfProduct();
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = productBindingSource;
        }

        private void InitializeStockBindingSource()
        {
            stockBindingSource.DataSource = mainController.GetListOfStock();
            dgvStock.AutoGenerateColumns = false;
            dgvStock.DataSource = stockBindingSource;
        }

        private void InitializePendingRequestBindingSource()
        {
            pendingRequestBindingSource.DataSource = mainController.GetListOfPendingRequest();
            dgvPending.AutoGenerateColumns = false;
            dgvPending.DataSource = pendingRequestBindingSource;
        }

        private void InitializeApprovedRequestBindingSource()
        {
            approvedReuestBindingSource.DataSource = mainController.GetListOfApprovedRequest();
            dgvApproved.AutoGenerateColumns = false;
            dgvApproved.DataSource = approvedReuestBindingSource;
        }

        private void InitializeRejectedRequestBindingSource()
        {
            rejectedRequestBindingSource.DataSource = mainController.GetListOfRejectedRequest();
            dgvRejected.AutoGenerateColumns = false;
            dgvRejected.DataSource = rejectedRequestBindingSource;
        }

        private void InitializeOutgoingRequestBindingSource()
        {
            outgoingRequestBindingSource.DataSource = mainController.GetListOfOngoingRequest();
            dgvOutgoing.AutoGenerateColumns = false;
            dgvOutgoing.DataSource = outgoingRequestBindingSource;
        }

        private void InitializeManufacturerBindingSource()
        {
            manufacturerBindingSource.DataSource = mainController.GetListOfManufacturer();
            dgvManufacturer.AutoGenerateColumns = false;
            dgvManufacturer.DataSource = manufacturerBindingSource;
        }

        private void InitializeStaffBindingSource()
        {
            staffBindingSource.DataSource = mainController.GetListOfStaff();
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.DataSource = staffBindingSource;
        }

        private void InitializeDiscountBindingSource()
        {
            discountBindingSource.DataSource = mainController.GetListOfDiscountPolicy();
            dgvDiscount.AutoGenerateColumns = false;
            dgvDiscount.DataSource = discountBindingSource;
        }

        private void InitializeReportBindingSource()
        {
            reportBindingSource.DataSource = mainController.GetListOfReport();
            dgvReport.AutoGenerateColumns = false;
            dgvReport.DataSource = reportBindingSource;
        }

        private void InitializeTabsInterface(object sender, TabControlEventArgs e)
        {
            //TabControl tcTemp = sender as TabControl;
            SetUpTabPageInterface(tcOperation);
        }

        #endregion

        #region SetUp Operation Interface

        private void SetUpTabPageInterface(TabControl tcTemp)
        {
            switch (tcTemp.SelectedTab.Name)
            {
                case Constant.OPERATION_TAB_SHOP:
                    //this.ActiveControl = txtKeywordShop;
                    //txtKeywordShop.Select(Constant.CONSTANT_ZERO, Constant.CONSTANT_ZERO);
                    break;
                case Constant.OPERATION_TAB_PRODUCT:
                    break;
                case Constant.OPERATION_TAB_STOCK:
                    break;
                case Constant.OPERATION_TAB_STAFF:
                    break;
                case Constant.OPERATION_TAB_REPORT:
                    break;
                case Constant.OPERATION_TAB_PROFILE:
                    break;
                case Constant.OPERATION_TAB_DISCOUNT:
                    break;
                case Constant.OPERATION_TAB_MANUFACTURER:
                    break;

                default:
                    break;
            }
        }
        //Pending
        private void DisableSomeFunctions()
        {
            string position = GlobalVariableAccessor.Position;
            switch (position)
            {
                case Constant.PRODUCT_OFFICER:
                    break;
                case  Constant.SALES_OFFICER:
                    break;
                case Constant.WAREHOUSE_OFFICER:
                    break;

                default:
                    break;
            }
        }

        private void RemoveTabpages()
        {
            string position = GlobalVariableAccessor.Position;
            try
            {
                switch (position)
                {
                    case Constant.PRODUCT_MANAGER:
                    case Constant.PRODUCT_OFFICER:
                        RemoveUnnecessaryTabpagesAcceptThree(ref tbManageProducts, ref tbViewManufacturerList, ref tbProfile);
                        break;
                    case Constant.SALES_MANAGER:
                    case Constant.SALES_OFFICER:
                        RemoveUnnecessaryTabpagesAcceptThree(ref tbDiscountPolicy, ref tbViewReport, ref tbProfile);
                        break;
                    case Constant.WAREHOUSE_MANAGER:
                    case Constant.WAREHOUSE_OFFICER:
                        RemoveUnnecessaryTabpagesAcceptFour(ref tbViewOrder, ref tbManageStock, ref tbManageShops, ref tbProfile);
                        break;

                    default:
                        break;
                }
            }
            catch
            {
                MessageBox.Show(Constant.ERROR_REMOVE_TABPAGE);
            }
        }

        private void RemoveUnnecessaryTabpagesAcceptThree(ref TabPage tp1, ref TabPage tp2, ref TabPage tp3)
        {
            try
            {
                foreach (TabPage tp in tcOperation.TabPages)
                {
                    if (!IsTwoStringEqual(tp.ToString(), tp1.ToString()) && !IsTwoStringEqual(tp.ToString(), tp2.ToString()) &&
                        !IsTwoStringEqual(tp.ToString(), tp3.ToString()))
                    {
                        tcOperation.TabPages.Remove(tp);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void RemoveUnnecessaryTabpagesAcceptFour(ref TabPage tp1, ref TabPage tp2, ref TabPage tp3, ref TabPage tp4)
        {
            try
            {
                foreach (TabPage tp in tcOperation.TabPages)
                {
                    if (!IsTwoStringEqual(tp.ToString(), tp1.ToString()) && !IsTwoStringEqual(tp.ToString(), tp2.ToString()) &&
                        !IsTwoStringEqual(tp.ToString(), tp3.ToString()) && !IsTwoStringEqual(tp.ToString(), tp4.ToString()))
                    {
                        tcOperation.TabPages.Remove(tp);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void SetTextAlignment(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            TabPage _tabPage = tcOperation.TabPages[e.Index];

            Rectangle _tabBounds = tcOperation.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            Font _tabFont = new Font("Arial", (float)14.0, FontStyle.Bold, GraphicsUnit.Pixel);
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void tcOrder_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font _tabFont = new Font("Arial", (float)14.0, FontStyle.Bold, GraphicsUnit.Pixel);
            switch (e.Index)
            {
                case 0:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Pink), e.Bounds);
                    break;
                case 1:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Green), e.Bounds);
                    break;
                case 2:
                    e.Graphics.FillRectangle(new SolidBrush(Color.Gray), e.Bounds);
                    break;
                case 3:
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);
                    break;
                default:
                    break;
            }

            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-2, -2);
            e.Graphics.DrawString(tcOrder.TabPages[e.Index].Text, _tabFont, SystemBrushes.HighlightText, paddedBounds);
        }

        private void MoveCurserToFront(object sender, EventArgs e)
        {
            TextBox txtActive = sender as TextBox;
            if (txtActive.Text.Equals(Constant.SEARCH_HINT))
            {
                txtActive.Select(Constant.CONSTANT_ZERO, Constant.CONSTANT_ZERO);
            }
        }

        #endregion

        #region Shared Methods

        private bool IsTwoStringEqual(string a, string b)
        {
            return a.Equals(b);
        }

        public static void goBackToHomePageThread()
        {
            Application.Run(new _0_View.Main());
        }

        public static void goBackToLoginPageThread()
        {
            Application.Run(new _0_View.Login());
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(goBackToHomePageThread));
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            this.Close();
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(goBackToLoginPageThread));
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            this.Close();
        }

        private void SelectOrDeselectAll(object sender, EventArgs e)
        {
            Button currentButton = sender as Button;
            if (currentButton.Text.Equals(Constant.OPERATION_SELECT_ALL))
            {
                currentButton.Text = Constant.OPERATION_UNSELECT_ALL;
            }
            else
            {
                currentButton.Text = Constant.OPERATION_SELECT_ALL;
            }
            SelectGridView(currentButton);
        }

        private void SelectGridView(Button currentButton)
        {
            DataGridView dgvCurrent = null;
            switch (currentButton.Parent.Parent.Name)
            {
                case Constant.OPERATION_TAB_SHOP:
                    dgvCurrent = dgvShopsInfo;
                    break;
                case Constant.OPERATION_TAB_PRODUCT:
                    dgvCurrent = dgvProducts;
                    break;
                case Constant.OPERATION_TAB_STOCK:
                    dgvCurrent = dgvStock;
                    break;
                case Constant.OPERATION_TAB_PENDING:
                    dgvCurrent = dgvPending;
                    break;
                case Constant.OPERATION_TAB_REJECTED:
                    dgvCurrent = dgvRejected;
                    break;
                case Constant.OPERATION_TAB_STAFF:
                    dgvCurrent = dgvStaff;
                    break;
                case Constant.OPERATION_TAB_DISCOUNT:
                    dgvCurrent = dgvDiscount;
                    break;

                default:
                    break;
            }
            foreach (DataGridViewRow row in dgvCurrent.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
            }
        }

        #endregion

        #region All about search

        private void SearchFieldTextChange(object sender, EventArgs e)
        {
            TextBox currentTextbox = sender as TextBox;
            try
            {
                SearchboxPair currentPair = getCurrentPair(currentTextbox.Name);
                currentPair.currentIconBox.Image = Properties.Resources.delete;
                if (currentTextbox.Text.Equals(Constant.OPERATION_EMPTY))
                {
                    currentPair.currentBindingSource.Filter = string.Empty;
                    currentPair.currentIconBox.Image = Properties.Resources.search;
                }
            }
            catch
            {
                CustomMessageBox.Show(Constant.ERROR_SEARCH_VERIFY_CONTENT, Constant.MSG_ERROR);
            }
        }

        private SearchboxPair getCurrentPair(string currentTextbox)
        {
            SearchboxPair currentPair = new SearchboxPair();
            try
            {
                switch (currentTextbox)
                {
                    case Constant.SHOP_SEARCH_BOX:
                        currentPair.currentBindingSource = shopBindingSource;
                        currentPair.currentIconBox = pbShopSign;
                        currentPair.currentFilterQuery = Constant.SEARCH_SHOP;
                        break;
                    case Constant.PRODUCT_SEARCH_BOX:
                        currentPair.currentBindingSource = productBindingSource;
                        currentPair.currentIconBox = pbProductSign;
                        currentPair.currentFilterQuery = Constant.SEARCH_PRODUCT;
                        break;
                    case Constant.STOCK_SEARCH_BOX:
                        currentPair.currentBindingSource = stockBindingSource;
                        currentPair.currentIconBox = pbStockSign;
                        currentPair.currentFilterQuery = Constant.SEARCH_STOCK;
                        break;
                    case Constant.PENDING_SEARCH_BOX:
                        currentPair.currentBindingSource = pendingRequestBindingSource;
                        currentPair.currentIconBox = pbPendingSign;
                        currentPair.currentFilterQuery = Constant.SEARCH_PENDING_REQUEST;
                        break;
                    case Constant.APPROVED_SEARCH_BOX:
                        currentPair.currentBindingSource = approvedReuestBindingSource;
                        currentPair.currentIconBox = pbApprovedSign;
                        currentPair.currentFilterQuery = Constant.SEARCH_APPROVED_REQUEST;
                        break;
                    case Constant.REJECTED_SEARCH_BOX:
                        currentPair.currentBindingSource = rejectedRequestBindingSource;
                        currentPair.currentIconBox = pbRejectedSign;
                        currentPair.currentFilterQuery = Constant.SEARCH_REJECTED_REQUEST;
                        break;
                    case Constant.OUTGOING_SEARCH_BOX:
                        currentPair.currentBindingSource = outgoingRequestBindingSource;
                        currentPair.currentIconBox = pbOutgoingSign;
                        currentPair.currentFilterQuery = Constant.SEARCH_OUTGOING_REQUEST;
                        break;
                    case Constant.MANUFACTURER_SEARCH_BOX:
                        currentPair.currentBindingSource = manufacturerBindingSource;
                        currentPair.currentIconBox = pbManufacturerSign;
                        currentPair.currentFilterQuery = Constant.SEARCH_MANUFACTURER;
                        break;
                    case Constant.STAFF_SEARCH_BOX:
                        currentPair.currentBindingSource = staffBindingSource;
                        currentPair.currentIconBox = pbStaffSign;
                        currentPair.currentFilterQuery = Constant.SEARCH_STAFF;
                        break;
                    case Constant.DISCOUNT_SEARCH_BOX:
                        currentPair.currentBindingSource = discountBindingSource;
                        currentPair.currentIconBox = pbDiscountSign;
                        currentPair.currentFilterQuery = Constant.SEARCH_DISCOUNT;
                        break;
                    case Constant.REPORT_SEARCH_BOX:
                        currentPair.currentBindingSource = reportBindingSource;
                        currentPair.currentIconBox = pbReportSign;
                        currentPair.currentFilterQuery = Constant.SEARCH_REPORT;
                        break;

                    default:
                        break;
                }
                return currentPair;
            }
            catch
            {
                throw;
            }
        }

        private void SearchField_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    Cursor.Current = Cursors.AppStarting;
                    Search(sender as TextBox);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {
                CustomMessageBox.Show(Constant.ERROR_SEARCH, Constant.MSG_ERROR);
            }
        }

        private void Search(TextBox currentTextbox)
        {
            try
            {
                SearchboxPair currentPair = getCurrentPair(currentTextbox.Name);
                currentPair.currentBindingSource.Filter = string.Format(currentPair.currentFilterQuery, currentTextbox.Text.Replace(Constant.OPERATION_SINGLE_QUOTE, Constant.OPERATION_DOUBLE_SINGLE_QUOTE));
            }
            catch
            {
                CustomMessageBox.Show(Constant.ERROR_SEARCH + Constant.PRODUCT_TABLE, Constant.MSG_ERROR);
            }
        }

        private void iconBox_Click(object sender, EventArgs e)
        {
            PictureBox currentIconBox = sender as PictureBox;
            TextBox currentTextbox = null;
            object currentObject = null;
            for (int i = 0; i < currentIconBox.Parent.Size.Width; i += currentIconBox.Parent.Size.Width / 20)
            {
                if ((currentObject = currentIconBox.Parent.GetChildAtPoint(new Point(i, currentIconBox.Height / 2))) is TextBox)
                {
                    currentTextbox = (TextBox)currentObject;
                    break;
                }
            }

            if (!currentTextbox.Text.Equals(Constant.SEARCH_HINT))
            {
                currentTextbox.Clear();
            }
        }

        #endregion

        #region All about shop

        private void removeShopRows(ArrayList pendingList)
        {
            try
            {
                foreach (string shopID in pendingList)
                {
                    mainController.DeleteShop(shopID);
                }
            }
            catch
            {
                throw;
            }
        }

        private void btnDeleteShop_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList pendingRemoveArray = new ArrayList();
                foreach (DataGridViewRow dgr in dgvShopsInfo.Rows)
                {
                    if (Convert.ToBoolean(dgr.Cells[Constant.CONSTANT_ZERO].Value) == true)
                    {
                        pendingRemoveArray.Add(dgr.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString());
                    }
                }
                if (pendingRemoveArray.Count == Constant.CONSTANT_ZERO)
                {
                    CustomMessageBox.Show(Constant.NO_ROW_SELECTED, Constant.MSG_ERROR);
                    return;
                }
                CustomMessageBox.Show(Constant.CONFIRM_DELETE_SHOP, Constant.MSG_WARNING);
                if (CustomMessageBox.result == System.Windows.Forms.DialogResult.OK)
                {
                    removeShopRows(pendingRemoveArray);
                    CustomMessageBox.Show(Constant.SHOP_ID + Constant.DELETE_SUCCESS, Constant.MSG_AUTO_CLOSE);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message, Constant.MSG_ERROR);
            }
        }

        private void EditView(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dgvShopsInfo.SelectedRows.Count == Constant.CONSTANT_ZERO)
                return;
            DataGridViewRow selectedRow = dgvShopsInfo.SelectedRows[Constant.CONSTANT_ZERO];
            string shopID = selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString();
            string shopLocation = selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value.ToString();
            string shopCountry = selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value.ToString();
            string shopContact = selectedRow.Cells[Constant.OPERATION_INDEX_FOUR].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_FOUR].Value.ToString();
            AddEditShop frmEditShop = new AddEditShop(shopID, shopCountry, shopLocation, shopContact);
            frmEditShop.ShowDialog();
        }

        private void btnAddShop_Click(object sender, EventArgs e)
        {
            _0_View.AddEditShop addShopInterface = new _0_View.AddEditShop();
            addShopInterface.ShowDialog();
        }

        #endregion

        #region All About Profile

        private bool IsAllFieldPass()
        {
            Int64 contact;

            if (string.IsNullOrEmpty(txtContact.Text))
            {
                CustomMessageBox.Show(Constant.ERROR_ADD_STAFF_EMPTY_CONTACT, Constant.MSG_WARNING);
                return false;
            }
            else if (!Int64.TryParse(txtContact.Text, out contact))
            {
                CustomMessageBox.Show(Constant.ERROR_ADD_STAFF_WRONG_CONTACT, Constant.MSG_WARNING);
                return false;
            }
            else if (!cbPosition.Items.Contains(cbPosition.Text))
            {
                CustomMessageBox.Show(Constant.ERROR_ADD_STAFF_WRONG_POSITION, Constant.MSG_WARNING);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void initializeProfile()
        {
            DataTable dt = (DataTable)staffBindingSource.DataSource;
            string staffID = GlobalVariableAccessor.CurrentStaffID;

            var result = from DataRow row in dt.AsEnumerable()
                         where row[Constant.STAFF_ID].ToString().Equals(staffID)
                         select new{staffID = row[Constant.STAFF_ID].ToString(), staffName = row[Constant.STAFF_NAME].ToString(), gender = row[Constant.STAFF_GENDER].ToString(),
                         dateOfBirth = row[Constant.STAFF_DATE_OF_BIRTH], position = row[Constant.STAFF_POSITION].ToString(), contact = row[Constant.STAFF_CONTACT].ToString(),
                         joinDate = row[Constant.STAFF_JOIN_DATE]};

            DateTime birthDate = (DateTime)result.ToArray()[Constant.CONSTANT_ZERO].dateOfBirth;
            DateTime joinDate = (DateTime)result.ToArray()[Constant.CONSTANT_ZERO].joinDate;

            lblDoB.Text = birthDate.Date.ToShortDateString();
            lblGender.Text = result.ToArray()[Constant.CONSTANT_ZERO].gender;
            lblJoinDate.Text = joinDate.Date.ToShortDateString();
            lblName.Text = result.ToArray()[Constant.CONSTANT_ZERO].staffName;
            lblStaffID.Text = result.ToArray()[Constant.CONSTANT_ZERO].staffID;
            txtContact.Text = result.ToArray()[Constant.CONSTANT_ZERO].contact;
            cbPosition.Text = result.ToArray()[Constant.CONSTANT_ZERO].position;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            _0_View.ChangePassword changepasswordInterface = new _0_View.ChangePassword();
            changepasswordInterface.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsAllFieldPass())
            {
                mainController.UpdateStaff(lblStaffID.Text, txtContact.Text, cbPosition.Text, false, false);
            }
        }

        #endregion

        #region All about product

        private void removeProductRows(ArrayList pendingList)
        {
            try
            {
                foreach (string productID in pendingList)
                {
                    mainController.DeleteExistingProduct(productID);
                }
            }
            catch(Exception ex)
            {
                CustomMessageBox.Show(ex.Message, Constant.MSG_ERROR);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList pendingRemoveArray = new ArrayList();
                foreach (DataGridViewRow dgr in dgvProducts.Rows)
                {
                    if (Convert.ToBoolean(dgr.Cells[Constant.CONSTANT_ZERO].Value) == true)
                    {
                        pendingRemoveArray.Add(dgr.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString());
                    }
                }
                if (pendingRemoveArray.Count == Constant.CONSTANT_ZERO)
                {
                    MessageBox.Show(Constant.NO_ROW_SELECTED,string.Empty,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show(Constant.CONFIRM_DELETE_PRODUCT, string.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    ArrayList inSaleProductList = getInSaleProducts(pendingRemoveArray);

                    if (inSaleProductList.Count == Constant.CONSTANT_ZERO)
                    {
                        removeProductRows(pendingRemoveArray);
                    }
                    else
                    {
                        RemoveNotInSaleProducts(pendingRemoveArray, inSaleProductList);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveNotInSaleProducts(ArrayList pendingRemoveArray, ArrayList inSaleProductList)
        {
            string warning = Constant.WARNING_PRODUCT_REMOVE_INSALE_PRODUCT_HEADER;
            foreach (string productID in inSaleProductList)
            {
                if (productID.Equals(inSaleProductList[inSaleProductList.Count - Constant.OPERATION_INDEX_ONE]))
                {
                    warning = warning + productID;
                }
                else
                {
                    warning = warning + productID + Constant.COMMA;
                }
            }
   
            warning = warning + Constant.WARNING_RPODCUT_REMOVE_INSALE_PRODUCT_FOOTER_0 + ((inSaleProductList.Count == pendingRemoveArray.Count) ? string.Empty : Constant.WARNING_PRODUCT_REMOVE_INSALE_PRODUCT_FOOTER_1);


            if (MessageBox.Show(warning, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                var exceptedList = pendingRemoveArray.ToArray().Except(inSaleProductList.ToArray()).ToList();
                ArrayList removingList = new ArrayList();
                foreach (string product in exceptedList)
                {
                    removingList.Add(product);
                }
                removeProductRows(removingList);
            }
        }

        private ArrayList getInSaleProducts(ArrayList pendingDeleteList)
        {
            try
            {
                ArrayList DisallowedDeletionProductList = new ArrayList();

                foreach(string productID in pendingDeleteList)
                {
                    if(!mainController.IsProductAllowedDeletion(productID))
                    {
                        DisallowedDeletionProductList.Add(productID);
                    }
                }
                return DisallowedDeletionProductList;
            }
            catch
            {
                throw;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            DataTable productList = (DataTable)productBindingSource.DataSource;
            _0_View.AddEditProduct addProductInterface = new _0_View.AddEditProduct(ref productList);
            addProductInterface.ShowDialog();
        }

        private void EditProduct(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dgvProducts.SelectedRows.Count == Constant.CONSTANT_ZERO)
                return;
            DataGridViewRow selectedRow = dgvProducts.SelectedRows[Constant.CONSTANT_ZERO];
            string productID = selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString();
            string productName = selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value.ToString();
            string manufacturer = selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value.ToString();
            string category = selectedRow.Cells[Constant.OPERATION_INDEX_FOUR].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_FOUR].Value.ToString();
            string maxStock = selectedRow.Cells[Constant.OPERATION_INDEX_FIVE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_FIVE].Value.ToString();
            string minStock = selectedRow.Cells[Constant.OPERATION_INDEX_SIX].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_SIX].Value.ToString();
        
            DataTable productList = (DataTable)productBindingSource.DataSource;
            AddEditProduct frmProduct = new AddEditProduct(ref productList, productID, productName, manufacturer, category, maxStock, minStock);
            frmProduct.ShowDialog();
        }

        #endregion

        #region All About stock

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            DataTable dtProduct = (DataTable)productBindingSource.DataSource;
            DataTable dtStock = (DataTable)stockBindingSource.DataSource;
            this.Cursor = Cursors.AppStarting;
            _0_View.AddEditStock addStockInterface = new _0_View.AddEditStock(dtProduct,dtStock);
            addStockInterface.cursorDel = new ChangeCursorBackDel(ChangeCuresorToDefault);
            addStockInterface.ShowDialog();
        }

        private void ChangeCuresorToDefault()
        {
            this.Cursor = Cursors.Default;
        }

        private void EditStock(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dgvStock.SelectedRows.Count == Constant.CONSTANT_ZERO)
                return;
            DataGridViewRow selectedRow = dgvStock.SelectedRows[Constant.CONSTANT_ZERO];

            string productID = selectedRow.Cells[Constant.CONSTANT_ZERO].Value == null ? string.Empty : selectedRow.Cells[Constant.CONSTANT_ZERO].Value.ToString();
            string productName = selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString();
            string manufacturerName = selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value.ToString();
            DateTime batchID = (DateTime)selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value;
            string importPrice = selectedRow.Cells[Constant.OPERATION_INDEX_FOUR].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_FOUR].Value.ToString();
            string sellPrice = selectedRow.Cells[Constant.OPERATION_INDEX_FIVE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_FIVE].Value.ToString();
            DateTime expireDate = (DateTime)selectedRow.Cells[Constant.OPERATION_INDEX_SIX].Value;
            string quantity = selectedRow.Cells[Constant.OPERATION_INDEX_SEVEN].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_SEVEN].Value.ToString();

            AddEditStock frmEditStock = new AddEditStock(productName, manufacturerName, productID, batchID, importPrice, sellPrice, expireDate, quantity);
            frmEditStock.ShowDialog();
        }

        #endregion

        #region All about request

        private void showApproveInterface(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dgvPending.SelectedRows.Count == Constant.CONSTANT_ZERO)
                return;
            DataGridViewRow selectedRow = dgvPending.SelectedRows[Constant.CONSTANT_ZERO];
            string productID = selectedRow.Cells[Constant.CONSTANT_ZERO].Value == null ? string.Empty : selectedRow.Cells[Constant.CONSTANT_ZERO].Value.ToString();
            string manufacturer = selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString();
            string productName = selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value.ToString();
            string shopID = selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value.ToString();
            string country = selectedRow.Cells[Constant.OPERATION_INDEX_FOUR].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_FOUR].Value.ToString();
            string location = selectedRow.Cells[Constant.OPERATION_INDEX_FIVE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_FIVE].Value.ToString();
            DateTime requestDate = (DateTime)selectedRow.Cells[Constant.OPERATION_INDEX_SIX].Value;
            int quantity = (int)selectedRow.Cells[Constant.OPERATION_INDEX_SEVEN].Value;
            int availableQuantity = (int)selectedRow.Cells[Constant.OPERATION_INDEX_EIGHT].Value;
            bool urgency = (bool)selectedRow.Cells[Constant.OPERATION_INDEX_NINE].Value;

            ApproveInterface frmApproveInterface = new ApproveInterface(productName, manufacturer, productID, shopID, country, location, requestDate, urgency, quantity.ToString(), availableQuantity.ToString());
            frmApproveInterface.ShowDialog();
        }

        void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name == "clPendingUrgency" || grid.Columns[e.ColumnIndex].Name == "clApprovedUrgency" || grid.Columns[e.ColumnIndex].Name == "clRejectedUrgency" || grid.Columns[e.ColumnIndex].Name == "clDeliveryStatus" || grid.Columns[e.ColumnIndex].Name == "clReceiveStatus")
            {
                e.Value = (bool)e.Value ? "YES" : "NO";
                e.FormattingApplied = true;
            }
        }

        private void btnSendStock_Click(object sender, EventArgs e)
        {
            bool isDeleted = false;
            try
            {
                foreach (DataGridViewRow dgr in dgvOutgoing.Rows)
                {
                    if (Convert.ToBoolean(dgr.Cells[Constant.CONSTANT_ZERO].Value) == true && dgr.Cells[Constant.OPERATION_INDEX_NINE].Value == DBNull.Value && dgr.Cells[Constant.OPERATION_INDEX_TEN].Value == DBNull.Value)
                    {
                        DateTime timeStamp = DateTime.Now;
                        DateTime currentTime = new DateTime(timeStamp.Year, timeStamp.Month, timeStamp.Day, timeStamp.Hour, timeStamp.Minute, timeStamp.Second);
                       // mainController.ReduceStockQuantity(dgr.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString(), (DateTime)dgr.Cells[Constant.OPERATION_INDEX_FOUR].Value, dgr.Cells[Constant.OPERATION_INDEX_FIVE].Value.ToString());
                        mainController.UpdateOutgoingRequest(dgr.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString(), (DateTime)dgr.Cells[Constant.OPERATION_INDEX_FOUR].Value, dgr.Cells[Constant.OPERATION_INDEX_SIX].Value.ToString(), (DateTime)dgr.Cells[Constant.OPERATION_INDEX_SEVEN].Value, currentTime, true);
                        isDeleted = true;
                    }
                }

                if (isDeleted)
                {
                    MessageBox.Show(Constant.RE_SUCCESSFULLY_SEND, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbRefreshPending_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.RefreshRequest();
                MessageBox.Show(Constant.SUCCESSFULLY_REFRESH_REQUEST, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region All about manufacturer

        private void EditManufacturer(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dgvManufacturer.SelectedRows.Count == Constant.CONSTANT_ZERO)
                return;
            DataGridViewRow selectedRow = dgvManufacturer.SelectedRows[Constant.CONSTANT_ZERO];
            string name = selectedRow.Cells[Constant.CONSTANT_ZERO].Value == null ? string.Empty : selectedRow.Cells[Constant.CONSTANT_ZERO].Value.ToString();
            string address = selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString();
            string country = selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value.ToString();
            string contact = selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value.ToString();
            AddEditManufacturer frmEditManufacturer = new AddEditManufacturer(name, address, country, contact);
            frmEditManufacturer.ShowDialog();
        }

        #endregion

        #region All about report

        private void cbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            switch (cbReportType.SelectedIndex)
            {
                case 0:
                    dtpStartDate.Format = DateTimePickerFormat.Custom;
                    dtpStartDate.CustomFormat = "MMMM dd, yyyy";
                    dtpEndDate.Format = DateTimePickerFormat.Custom;
                    dtpEndDate.CustomFormat = "MMMM dd, yyyy";
                    dtpStartDate.ShowUpDown = false;
                    dtpEndDate.ShowUpDown = false;
                    break;
                case 1:
                    dtpStartDate.Format = DateTimePickerFormat.Custom;
                    dtpStartDate.CustomFormat = "MMMM, yyyy";
                    dtpEndDate.Format = DateTimePickerFormat.Custom;
                    dtpEndDate.CustomFormat = "MMMM, yyyy";
                    dtpStartDate.ShowUpDown = true;
                    dtpEndDate.ShowUpDown = true;
                    break;
                case 2:
                    dtpStartDate.Format = DateTimePickerFormat.Custom;
                    dtpStartDate.CustomFormat = "yyyy";
                    dtpEndDate.Format = DateTimePickerFormat.Custom;
                    dtpEndDate.CustomFormat = "yyyy";
                    dtpStartDate.ShowUpDown = true;
                    dtpEndDate.ShowUpDown = true;
                    break;

                default:
                    break;
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            DataTable summaryTable, productTable, shopTable;
            SummaryReport report = null;
            switch (cbReportType.SelectedIndex)
            {
                case 0:
                    summaryTable = mainController.FetchDailySummary(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                    productTable = mainController.FetchDailyProduct(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                    shopTable = mainController.FetchDailyShop(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                    report = new SummaryReport(ReportType.Daily, mainController.FetchDailySummary(dtpStartDate.Value.Date, dtpEndDate.Value.Date), mainController.FetchDailyProduct(dtpStartDate.Value.Date, dtpEndDate.Value.Date), mainController.FetchDailyShop(dtpStartDate.Value.Date, dtpEndDate.Value.Date));
                    break;
                case 1:
                    summaryTable = mainController.FetchMonthlySummary(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                    productTable = mainController.FetchMonthlyProduct(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                    shopTable = mainController.FetchMonthlyShop(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                    report = new SummaryReport(ReportType.Monthly, mainController.FetchMonthlySummary(dtpStartDate.Value.Date, dtpEndDate.Value.Date), mainController.FetchMonthlyProduct(dtpStartDate.Value.Date, dtpEndDate.Value.Date), mainController.FetchMonthlyShop(dtpStartDate.Value.Date, dtpEndDate.Value.Date));
                    break;
                case 2:
                    summaryTable = mainController.FetchYearlySummary(dtpStartDate.Value.Year.ToString(), dtpEndDate.Value.Year.ToString());
                    productTable = mainController.FetchYearlyProduct(dtpStartDate.Value.Year.ToString(), dtpEndDate.Value.Year.ToString());
                    shopTable = mainController.FetchYearlyShop(dtpStartDate.Value.Year.ToString(), dtpEndDate.Value.Year.ToString());
                    report = new SummaryReport(ReportType.Yearly, mainController.FetchYearlySummary(dtpStartDate.Value.Year.ToString(), dtpEndDate.Value.Year.ToString()), mainController.FetchYearlyProduct(dtpStartDate.Value.Year.ToString(), dtpEndDate.Value.Year.ToString()), mainController.FetchYearlyShop(dtpStartDate.Value.Year.ToString(), dtpEndDate.Value.Year.ToString()));
                    break;

                default:
                    return;
            }
            
            report.ShowDialog();
        }

        #endregion

        #region All about staff

        private void removeStaffRows(ArrayList pendingList)
        {
            try
            {
                foreach (string staffID in pendingList)
                {
                    mainController.DeleteStaff(staffID);
                }
            }
            catch(Exception ex)
            {
                CustomMessageBox.Show(ex.Message, Constant.MSG_ERROR);
            }
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList pendingRemoveArray = new ArrayList();
                foreach (DataGridViewRow dgr in dgvStaff.Rows)
                {
                    if (Convert.ToBoolean(dgr.Cells[Constant.CONSTANT_ZERO].Value) == true)
                    {
                        pendingRemoveArray.Add(dgr.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString());
                    }
                }
                if (pendingRemoveArray.Count == Constant.CONSTANT_ZERO)
                {
                    CustomMessageBox.Show(Constant.NO_ROW_SELECTED, Constant.MSG_ERROR);
                    return;
                }

                CustomMessageBox.Show(Constant.CONFIRM_DELETE_STAFF, Constant.MSG_WARNING);
                if (CustomMessageBox.result == System.Windows.Forms.DialogResult.OK)
                {
                    removeStaffRows(pendingRemoveArray);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message, Constant.MSG_ERROR);
            }
        }

        private void EditStaff(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;
                if (dgvStaff.SelectedRows.Count == Constant.CONSTANT_ZERO)
                    return;
                DataGridViewRow selectedRow = dgvStaff.SelectedRows[Constant.CONSTANT_ZERO];

                string staffID = selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString();
                string name = selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value.ToString();
                DateTime renewPasswordDate = (DateTime)selectedRow.Cells[Constant.OPERATION_INDEX_SEVEN].Value;
                DateTime dateOfBirth = (DateTime)selectedRow.Cells[Constant.OPERATION_INDEX_EIGHT].Value;
                DateTime joinDate = (DateTime)selectedRow.Cells[Constant.OPERATION_INDEX_FOUR].Value;
                string gender = selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value.ToString();
                string position = selectedRow.Cells[Constant.OPERATION_INDEX_FIVE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_FIVE].Value.ToString();
                string contact = selectedRow.Cells[Constant.OPERATION_INDEX_SIX].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_SIX].Value.ToString();
                bool defaultPassword = selectedRow.Cells[Constant.OPERATION_INDEX_NINE].Value == null ? false : (bool)selectedRow.Cells[Constant.OPERATION_INDEX_NINE].Value;
                bool blocked = selectedRow.Cells[Constant.OPERATION_INDEX_TEN].Value == null ? false : (bool)selectedRow.Cells[Constant.OPERATION_INDEX_TEN].Value;

                AddEditStaff frmEditStaff = new AddEditStaff(name, staffID, renewPasswordDate, dateOfBirth, joinDate, gender, position, contact, defaultPassword, blocked);
                frmEditStaff.ShowDialog();
            }
            catch
            {
                throw;
            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            AddEditStaff frmAddStaff = new AddEditStaff();
            frmAddStaff.ShowDialog();
        }

        #endregion

        #region All About Discount

        private void btnDeleteDistount_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList pendingRemoveArray = new ArrayList();
                foreach (DataGridViewRow dgr in dgvDiscount.Rows)
                {
                    if (Convert.ToBoolean(dgr.Cells[Constant.CONSTANT_ZERO].Value) == true)
                    {
                        pendingRemoveArray.Add(dgr.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString());
                    }
                }
                if (pendingRemoveArray.Count == Constant.CONSTANT_ZERO)
                {
                    MessageBox.Show(Constant.NO_ROW_SELECTED, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show(Constant.CONFIRM_DELETE_DISCOUNT, Constant.SPACE, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    removeDiscountRows(pendingRemoveArray);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.Message, Constant.MSG_ERROR);
            }
        }

        private void removeDiscountRows(ArrayList pendingList)
        {
            try
            {
                foreach (string productID in pendingList)
                {
                    mainController.DeleteDiscountPolicy(productID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            AddEditDiscount addEditDiscountForm = new AddEditDiscount((DataTable)productBindingSource.DataSource, (DataTable)discountBindingSource.DataSource);
            addEditDiscountForm.ShowDialog();
        }

        private void dgvDiscount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dgvDiscount.SelectedRows.Count == Constant.CONSTANT_ZERO)
                return;
            DataGridViewRow selectedRow = dgvDiscount.SelectedRows[Constant.CONSTANT_ZERO];

            string productID = selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString();
            string productName = selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_TWO].Value.ToString();
            string manufacturerName = selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_THREE].Value.ToString();
            DateTime effectiveDate = (DateTime)selectedRow.Cells[Constant.OPERATION_INDEX_FOUR].Value;
            string bundleUnit = selectedRow.Cells[Constant.OPERATION_INDEX_FIVE].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_FIVE].Value.ToString();
            string freeQuantity = selectedRow.Cells[Constant.OPERATION_INDEX_SIX].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_SIX].Value.ToString();
            string discount = selectedRow.Cells[Constant.OPERATION_INDEX_SEVEN].Value == null ? string.Empty : selectedRow.Cells[Constant.OPERATION_INDEX_SEVEN].Value.ToString();

            AddEditDiscount addEditDiscountForm = new AddEditDiscount(productID, productName, manufacturerName, effectiveDate, bundleUnit, freeQuantity, discount);
            addEditDiscountForm.ShowDialog();
        }

        #endregion

    }
}
