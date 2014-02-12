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
    public delegate void UpdateManufacturerList(string newManufacturer);
    public partial class AddEditManufacturer : Form
    {
        private ActionType currentAction;
        private _2_Controller.CoordinatingController mainController = _2_Controller.CoordinatingController.getInstance();
        public UpdateManufacturerList updateManufacturer;
        public DataTable manufacturerList;

        public AddEditManufacturer()
        {
            InitializeComponent();
            currentAction = ActionType.Add;
        }

        public AddEditManufacturer(string manufacturerName, string address, string country, string contact)
        {
            InitializeComponent();
            txtName.Text = manufacturerName;
            txtAdress.Text = address;
            cbCountry.Text = country;
            txtContact.Text = contact;
            txtName.Enabled = false;
            this.ActiveControl = txtAdress;
            currentAction = ActionType.Edit;
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
            Int64 contact;
            if (IsStringNullOrEmptyOrWhiteSpaces(txtName.Text))
            {
                txtError.Text = Constant.ERROR_ADD_MANUFACTURER_EMPTEY_MANUFACTURER_NAME;
                txtName.Focus();
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(txtAdress.Text))
            {
                txtError.Text = Constant.ERROR_ADD_MANUFACTURER_EMPTEY_ADDRESS;
                txtAdress.Focus();
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(cbCountry.Text))
            {
                txtError.Text = Constant.ERROR_ADD_MANUFACTURER_EMPTEY_COUNTRY;
                cbCountry.Focus();
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(txtContact.Text))
            {
                txtError.Text = Constant.ERROR_ADD_MANUFACTURER_EMPTEY_CONTACT;
                txtContact.Focus();
                return false;
            }
            else if (!Int64.TryParse(txtContact.Text, out contact))
            {
                txtError.Text = Constant.ERROR_ADD_MANUFACTURER_IVALID_CONTACT;
                txtContact.Focus();
                return false;
            }
            else if (!IsValidCountry())
            {
                txtError.Text = Constant.ERROR_ADD_MANUFACTURER_MISMATCH_COUNTRY;
                cbCountry.SelectedIndex = Constant.CONSTANT_ZERO;
                cbCountry.Focus();
                return false;
            }
            else if (manufacturerList.AsEnumerable().Any(row => txtName.Text == row.Field<string>(Constant.M_NAME)))
            {
                txtError.Text = Constant.ERROR_ADD_MANUFACTURER_EXIST_NAME;
                txtName.Clear();
                txtName.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsValidCountry()
        {
            var result = from DataRow itemRow in manufacturerList.AsEnumerable()
                         where itemRow[Constant.M_COUNTRY].ToString().Equals(cbCountry.Text)
                         select itemRow[Constant.M_COUNTRY].ToString();

            return cbCountry.Items.Contains(cbCountry.Text) || result.Any();
        }

        private bool IsEditFieldCheckPass()
        {
            Int64 contact;
             if (IsStringNullOrEmptyOrWhiteSpaces(txtAdress.Text))
            {
                txtError.Text = Constant.ERROR_ADD_MANUFACTURER_EMPTEY_ADDRESS;
                txtAdress.Focus();
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(cbCountry.Text))
            {
                txtError.Text = Constant.ERROR_ADD_MANUFACTURER_EMPTEY_COUNTRY;
                cbCountry.Focus();
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(txtContact.Text))
            {
                txtError.Text = Constant.ERROR_ADD_MANUFACTURER_EMPTEY_CONTACT;
                txtContact.Focus();
                return false;
            }
             else if (!Int64.TryParse(txtContact.Text, out contact))
             {
                 txtError.Text = Constant.ERROR_ADD_MANUFACTURER_IVALID_CONTACT;
                 txtContact.Focus();
                 return false;
             }
             else if (!IsValidCountry())
             {
                 txtError.Text = Constant.ERROR_ADD_MANUFACTURER_MISMATCH_COUNTRY;
                 cbCountry.SelectedIndex = Constant.CONSTANT_ZERO;
                 cbCountry.Focus();
                 return false;
             }
             else
             {
                 return true;
             }
        }

        private void PerformAddManufacturer()
        {
            if (IsAllFieldCheckPass())
            {
                mainController.AddNewManufacturer(txtName.Text, txtAdress.Text, cbCountry.Text, txtContact.Text);
                updateManufacturer(txtName.Text);
                this.Close();
            }
        }

        private void PerformEditManufacturer()
        {
            if (IsEditFieldCheckPass())
            {
                mainController.UpdateExistingManufacturer(txtName.Text, txtAdress.Text, cbCountry.Text, txtContact.Text);
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
                    PerformAddManufacturer();
                }
                else
                {
                    PerformEditManufacturer();
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

        private void AddEditManufacturer_Load(object sender, EventArgs e)
        {
            manufacturerList = mainController.GetListOfManufacturer();
        }
    }
}
