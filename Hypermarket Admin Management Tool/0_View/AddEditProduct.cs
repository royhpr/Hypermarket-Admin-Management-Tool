using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hypermarket_Admin_Management_Tool._0_View
{
    public partial class AddEditProduct : Form
    {
        private _2_Controller.CoordinatingController mainController = _2_Controller.CoordinatingController.getInstance();
        private ActionType currentAction;
        DataTable currentManufacturerList;
        private DataTable currentProductList;
        private BindingSource manufacturerListSource = new BindingSource();
        private BindingSource productListSource = new BindingSource();
        private BackgroundWorker backgroundthread = new BackgroundWorker();
        private bool isLoaded = false;

        public AddEditProduct(ref DataTable productList)
        {
            InitializeComponent();
            lblProductID.Text = mainController.GenerateNextAvailableProductID();
            currentProductList = productList;
            currentAction = ActionType.Add;
        }

        public AddEditProduct(ref DataTable productList, string productID, string productName, string manufacturer, string category, string maxStock, string minStock)
        {
            InitializeComponent();
            lblProductID.Text = productID;
            txtProductName.Text = productName;
            cbManufacturer.Text = manufacturer;
            cbCategory.Text = category;
            txtMaxStock.Text = maxStock;
            txtMinStock.Text = minStock;
            currentProductList = productList;
            currentAction = ActionType.Edit;
        }

        private void AddEditProduct_Load(object sender, EventArgs e)
        {
            currentManufacturerList = mainController.GetListOfManufacturer();
            manufacturerListSource.DataSource = currentManufacturerList;
            cbManufacturer.DataSource = manufacturerListSource.DataSource;
            cbManufacturer.DisplayMember = Constant.M_NAME;
            cbManufacturer.ValueMember = Constant.M_NAME;

            checkLoadReady.Start();
            InitializeBackgroundworker();
            isLoaded = true;

            //productListSource.DataSource = currentProductList;
            //cbCategory.DataSource = productListSource.DataSource;
            //cbCategory.DisplayMember = Constant.P_CATEGORY;
            //cbCategory.ValueMember = Constant.P_CATEGORY;
        }

        private void AddProductInterace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    startProcess();
                }
                catch (Exception ex)
                {
                    txtError.Text = ex.Message;
                }
            }
        }

        private bool IsStringNullOrEmptyOrWhiteSpaces(string inputString)
        {
            return (string.IsNullOrEmpty(inputString) || string.IsNullOrWhiteSpace(inputString));
        }

        private bool IsAllFieldCheckPass()
        {
            double maxStock, minStock;
            if (IsStringNullOrEmptyOrWhiteSpaces(txtProductName.Text))
            {
                txtError.Text = Constant.ERROR_ADD_PRODUCT_EMPTY_NAME;
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(cbManufacturer.Text))
            {
                txtError.Text = Constant.ERROR_ADD_PRODUCT_EMPTY_MANUFACTURER;
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(cbCategory.Text))
            {
                txtError.Text = Constant.ERROR_ADD_PRODUCT_EMPTY_CATEGORY;
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(txtMaxStock.Text))
            {
                txtError.Text = Constant.ERROR_ADD_PRODUCT_EMPTY_MAXSTOCK;
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(txtMinStock.Text))
            {
                txtError.Text = Constant.ERROR_ADD_PRODUCT_EMPTY_MINSTOCK;
                return false;
            }
            else if (!currentManufacturerList.AsEnumerable().Any(row => cbManufacturer.Text == row.Field<String>(Constant.M_NAME)))
            {
                txtError.Text = Constant.ERROR_ADD_PRODCUT_MANUFACTURER_NO_EXIST;
                return false;
            }
            else if (currentProductList.AsEnumerable().Any(row => cbManufacturer.Text == row.Field<String>(Constant.M_NAME) && txtProductName.Text == row.Field<String>(Constant.P_NAME)))
            {
                txtError.Text = Constant.ERROR_ADD_PRODUCT_SAME_NAME_SAME_MANUFACTURER;
                return false;
            }
            else if (!cbCategory.Items.Contains(cbCategory.Text))
            {
                txtError.Text = Constant.ERROR_ADD_PRODUCT_CATEGORY_NO_EXIST;
                return false;
            }
            else if (!double.TryParse(txtMaxStock.Text, out maxStock))
            {
                txtError.Text = Constant.ERROR_ADD_PRODUCT_MAXSTOCK;
                return false;
            }
            else if (!double.TryParse(txtMinStock.Text, out minStock))
            {
                txtError.Text = Constant.ERROR_ADD_PRODUCT_MINSTOCK;
                return false;
            }
            else if (Convert.ToDouble(maxStock) < Convert.ToDouble(minStock))
            {
                txtError.Text = Constant.ERROR_ADD_PRODUCT_MAXSTOCK_COMPARE_MINSTOCK;
                return false;
            }
            else if (Convert.ToDouble(minStock) <= 0)
            {
                txtError.Text = Constant.ERROR_ADD_PRODUCT_MINSTOCK_LESS_THAN_ZERO;
                return false;
            }
            else
            {
                return true;
            }
        }

        private void PerformAddProduct()
        {
            if (IsAllFieldCheckPass())
            {
                mainController.AddNewProduct(cbManufacturer.Text, lblProductID.Text, txtProductName.Text, cbCategory.Text, txtMaxStock.Text, txtMinStock.Text);
                this.Close();
            }
        }

        private void PerformEditProduct()
        {
            if (IsAllFieldCheckPass())
            {
                mainController.UpdateExistingProduct(lblProductID.Text, cbManufacturer.Text, txtProductName.Text, cbCategory.Text, txtMaxStock.Text, txtMinStock.Text);
                this.Close();
            }
        }

        private void startProcess()
        {
            try
            {
                txtError.Visible = true;
                if (currentAction == ActionType.Add)
                {
                    PerformAddProduct();
                }
                else
                {
                    PerformEditProduct();
                }
            }
            catch
            {
                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                startProcess();
            }
            catch (Exception ex)
            {
                txtError.Text = ex.Message;
            }
        }

        private void pbAddManufacturer_Click(object sender, EventArgs e)
        {
            AddEditManufacturer frmManufacturer = new AddEditManufacturer();
            frmManufacturer.updateManufacturer = new UpdateManufacturerList(addToItems);
            frmManufacturer.ShowDialog();
        }

        private void addToItems(string newItem)
        {
            DataRow[] dr = currentManufacturerList.Select(Constant.M_NAME + Constant.EQUAL + Constant.OPERATION_SINGLE_QUOTE + newItem + Constant.OPERATION_SINGLE_QUOTE);
            cbManufacturer.SelectedIndex = currentManufacturerList.Rows.IndexOf(dr[Constant.CONSTANT_ZERO]);
        }

        private void InitializeBackgroundworker()
        {
            backgroundthread.DoWork += new DoWorkEventHandler(backgroundthread_DoWork);
            backgroundthread.ProgressChanged += new ProgressChangedEventHandler
                    (backgroundthread_ProgressChanged);
            backgroundthread.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (backgroundthread_RunWorkerCompleted);
            backgroundthread.WorkerReportsProgress = true;
            backgroundthread.WorkerSupportsCancellation = true;
        }

        void backgroundthread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblPopulatingInfo.Text = Constant.ERROR_DURING_POPULATING_LIST;
            }
            else
            {
                lblPopulatingInfo.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }

        void backgroundthread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string category = cbCategory.Text;
            cbCategory.DataSource = (string[])e.UserState;
            cbCategory.Text = category;
        }

        void backgroundthread_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dt = (DataTable)e.Argument;

            var productList = from DataRow row in dt.AsEnumerable().Distinct()
                              select row[Constant.P_CATEGORY].ToString();


            backgroundthread.ReportProgress(Constant.CONSTANT_ZERO, productList.ToArray());
        }

        private void checkLoadReady_Tick(object sender, EventArgs e)
        {
            if (isLoaded == true && backgroundthread.IsBusy == false)
            {
                this.Cursor = Cursors.AppStarting;
                lblPopulatingInfo.Visible = true;
                DataTable dt = currentProductList.Copy();
                backgroundthread.RunWorkerAsync(dt);
                checkLoadReady.Stop();
            }
        }
    }
}
