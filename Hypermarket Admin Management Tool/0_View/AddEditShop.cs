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
    public enum ActionType {Add, Edit}

    public partial class AddEditShop : Form
    {
        private _2_Controller.CoordinatingController mainController = _2_Controller.CoordinatingController.getInstance();
        private ActionType currentAction;

        public AddEditShop()
        {
            InitializeComponent();
            lblShopID.Text = mainController.GenerateNextAvailableShopID();
            currentAction = ActionType.Add;
        }

        public AddEditShop(string shopID, string country, string location, string contact)
        {
            InitializeComponent();
            lblShopID.Text = shopID;
            txtContact.Text = contact;
            txtLocation.Text = location;
            cbCountry.Text = country;
            currentAction = ActionType.Edit;
        }

        private void AddShopInterace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    txtError.Visible = true;
                    if (currentAction == ActionType.Add)
                    {
                        PerformAddShop();
                    }
                    else
                    {
                        PerformEditShop();
                    }
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
            Int64 contactNumber = Constant.CONSTANT_ZERO;
            if (IsStringNullOrEmptyOrWhiteSpaces(cbCountry.Text))
            {
                txtError.Text = Constant.ERROR_ADD_SHOP_EMPTY_COUNTRY;
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(txtLocation.Text))
            {
                txtError.Text = Constant.ERROR_ADD_SHOP_EMPTY_LOCATION;
                return false;
            }
            else if (IsStringNullOrEmptyOrWhiteSpaces(txtContact.Text))
            {
                txtError.Text = Constant.ERROR_ADD_SHOP_EMPTY_CONTACT;
                return false;
            }
            else if (!Int64.TryParse(txtContact.Text, out contactNumber))
            {
                txtError.Text = Constant.ERROR_ADD_SHOP_WRONG_CONTACT;
                return false;
            }
            else
            {
                return true;
            }
        }

        private void PerformAddShop()
        {
            if (IsAllFieldCheckPass())
            {
                mainController.AddShop(lblShopID.Text, cbCountry.Text, txtLocation.Text, txtContact.Text);
                this.Close();
            }
        }

        private void PerformEditShop()
        {
            if (IsAllFieldCheckPass())
            {
                mainController.UpdateShop(lblShopID.Text, cbCountry.Text, txtLocation.Text, txtContact.Text);
                this.Close();
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
                txtError.Visible = true;
                if (currentAction == ActionType.Add)
                {
                    PerformAddShop();
                }
                else
                {
                    PerformEditShop();
                }
            }
            catch (Exception ex)
            {
                txtError.Text = ex.Message;
            }
        }
    }
}
