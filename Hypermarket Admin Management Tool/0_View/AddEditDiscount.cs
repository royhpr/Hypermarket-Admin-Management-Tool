using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hypermarket_Admin_Management_Tool._0_View
{
    public partial class AddEditDiscount : Form
    {
        private _2_Controller.CoordinatingController mainController = _2_Controller.CoordinatingController.getInstance();
        private ActionType currentAction;
        private DataTable productTable;
        private DataTable discountTable;
        private BackgroundWorker backgroundthread = new BackgroundWorker();
        private bool isLoaded = false;
        public ChangeCursorBackDel cursorDel;

        public AddEditDiscount(DataTable product, DataTable discount)
        {
            InitializeComponent();
            productTable = product;
            discountTable = discount;
            currentAction = ActionType.Add;
        }

        public AddEditDiscount(string productID, string productName, string manufacturerName, DateTime effectiveDate, string unitBundle, string freeItemQuantity, string discount)
        {
            InitializeComponent();
            cbProductName.Text = productName;
            cbManufacturer.Text = manufacturerName;
            lblProductID.Text = productID;
            dtpEffectiveDate.Value = effectiveDate;
            txtBundleUnit.Text = unitBundle;
            txtFreeQuantity.Text = freeItemQuantity;
            txtDiscount.Text = discount;
            this.ActiveControl = dtpEffectiveDate;

            DisableComponents();
            currentAction = ActionType.Edit;
        }

        private void AddEditDiscount_Load(object sender, EventArgs e)
        {
            if (currentAction == ActionType.Add)
            {
                checkLoadReady.Start();
                InitializeBackgroundworker();
                isLoaded = true;
            }
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
                lblProgress.Text = Constant.ERROR_DURING_POPULATING_LIST;
            }
            else
            {
                lblProgress.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }

        void backgroundthread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            cbProductName.DataSource = (string[])e.UserState;
        }

        void backgroundthread_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dt = (DataTable)e.Argument;

            var productList = from DataRow row in dt.AsEnumerable().Distinct()
                              select row[Constant.P_NAME].ToString();


            backgroundthread.ReportProgress(Constant.CONSTANT_ZERO, productList.ToArray());
        }

        private void DisableComponents()
        {
            cbProductName.Enabled = false;
            cbManufacturer.Enabled = false;
            lblProgress.Visible = false;
        }

        private string[] GetManufacturerComboboxSource(string product)
        {
            var resultList = from DataRow itemRow in productTable.AsEnumerable()
                             where itemRow[Constant.P_NAME].ToString().Equals(product)
                             select itemRow[Constant.P_M_Name].ToString();

            return resultList.ToArray();
        }

        private string GetProductID(string manufacturerName, string productName)
        {
            if (string.IsNullOrEmpty(productName))
                return string.Empty;

            var result = from DataRow itemRow in productTable.AsEnumerable()
                         where itemRow[Constant.P_M_Name].ToString().Equals(manufacturerName) && itemRow[Constant.P_NAME].ToString().Equals(productName)
                         select itemRow[Constant.P_ID].ToString();

            if (!result.Any())
                return string.Empty;

            return result.ToArray()[Constant.CONSTANT_ZERO].ToString();
        }

        private void populateManufacturerComboBoxDataSource(object sender, EventArgs e)
        {
            ComboBox currentBox = sender as ComboBox;
            string[] dataSource = GetManufacturerComboboxSource(currentBox.SelectedItem.ToString());
            cbManufacturer.DataSource = dataSource;
        }

        private bool IsStringNullOrEmptyOrWhiteSpaces(string inputString)
        {
            return (string.IsNullOrEmpty(inputString) || string.IsNullOrWhiteSpace(inputString));
        }

        private bool IsAllFieldCheckPass()
        {
            double discount;
            Int16 unitBundle;
            Int16 freeQuantity;
            if (IsStringNullOrEmptyOrWhiteSpaces(cbProductName.Text) || !cbProductName.Items.Contains(cbProductName.Text))
            {
                MessageBox.Show(Constant.ERROR_INVALID_PRODUCT_NAME, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(cbManufacturer.Text) || !cbManufacturer.Items.Contains(cbManufacturer.Text))
            {
                MessageBox.Show(Constant.ERROR_INVALID_MANUFACTURER, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(txtBundleUnit.Text) || !Int16.TryParse(txtBundleUnit.Text, out unitBundle))
            {
                MessageBox.Show(Constant.ERROR_INVALID_UNIT_BUNDLE, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(txtFreeQuantity.Text) || !Int16.TryParse(txtFreeQuantity.Text, out freeQuantity))
            {
                MessageBox.Show(Constant.ERROR_INVALID_FREE_QUANTITY, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(txtDiscount.Text) || !double.TryParse(txtDiscount.Text, out discount))
            {
                MessageBox.Show(Constant.ERROR_INVALID_DISCOUNT, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (IsDiscountItemExist())
            {
                MessageBox.Show(Constant.ERROR_EXIST_DISCOUNT_ITEM, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsEditFieldCheckPass()
        {
            Int16 unitBundle, freeQuantity;
            double discount;
            if (IsStringNullOrEmptyOrWhiteSpaces(txtBundleUnit.Text) || !Int16.TryParse(txtBundleUnit.Text, out unitBundle))
            {
                MessageBox.Show(Constant.ERROR_INVALID_UNIT_BUNDLE, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(IsStringNullOrEmptyOrWhiteSpaces(txtFreeQuantity.Text) || !Int16.TryParse(txtFreeQuantity.Text, out freeQuantity))
            {
                MessageBox.Show(Constant.ERROR_INVALID_FREE_QUANTITY, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(IsStringNullOrEmptyOrWhiteSpaces(txtDiscount.Text) || !double.TryParse(txtDiscount.Text, out discount))
            {
                MessageBox.Show(Constant.ERROR_INVALID_DISCOUNT, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsDiscountItemExist()
        {
            var result = from DataRow row in discountTable.AsEnumerable()
                         where row[Constant.D_P_ID].ToString().Equals(lblProductID.Text)
                         select row[Constant.D_P_ID].ToString();

            if (result.Any())
                return true;

            return false;
        }

        private void UpdateProductID(object sender, EventArgs e)
        {
            lblProductID.Text = GetProductID(cbManufacturer.Text, cbProductName.Text);
        }

        private void checkLoadReady_Tick(object sender, EventArgs e)
        {
            if (isLoaded == true && backgroundthread.IsBusy == false)
            {
                this.Cursor = Cursors.AppStarting;
                lblProgress.Visible = true;
                DataTable dt = productTable.Copy();
                backgroundthread.RunWorkerAsync(dt);
                checkLoadReady.Stop();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentAction == ActionType.Add)
                {
                    if (IsAllFieldCheckPass())
                    {
                        mainController.AddDiscountPolicy(cbProductName.Text, cbManufacturer.Text, lblProductID.Text, dtpEffectiveDate.Value, txtBundleUnit.Text, txtFreeQuantity.Text, txtDiscount.Text);
                        this.Close();
                    }
                }
                else
                {
                    if (IsEditFieldCheckPass())
                    {
                        mainController.UpdateDiscountPolicy(lblProductID.Text, dtpEffectiveDate.Value, txtBundleUnit.Text, txtFreeQuantity.Text, txtDiscount.Text);
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
