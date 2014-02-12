using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Hypermarket_Admin_Management_Tool._0_View
{
    public partial class ApproveInterface : Form
    {
        _2_Controller.CoordinatingController mainController = _2_Controller.CoordinatingController.getInstance();

        public ApproveInterface()
        {
            InitializeComponent();
        }

        public ApproveInterface(string productName, string manufacturerName, string productID, string shopID, string country, string location, DateTime dateOfRequest, bool urgency, string requestQuantity, string availableQuantity)
        {
            InitializeComponent();
            lblProductName.Text = productName;
            lblManufacturerName.Text = manufacturerName;
            lblProductID.Text = productID;
            lblShopID.Text = shopID;
            lblCountry.Text = country;
            lblLocation.Text = location;
            lblRequestDate.Text = dateOfRequest.ToString();
            lblUrgency.Text = urgency ? "Yes" : "No";
            lblRequestQuantity.Text = requestQuantity;
            lblAvailableQuantity.Text = availableQuantity;
        }

        private bool IsRightQuantityFormat()
        {
            Int64 approvedQuantity;
            Int64 availableQuantity = Int64.Parse(lblAvailableQuantity.Text);
            if (string.IsNullOrEmpty(txtApprovedQuantity.Text))
            {
                MessageBox.Show(Constant.ERROR_APPROVE_EMPTY_QUANTITY, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!Int64.TryParse(txtApprovedQuantity.Text, out approvedQuantity))
            {
                MessageBox.Show(Constant.ERROR_APPROVE_WRONG_QUANTITY, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (approvedQuantity > availableQuantity)
            {
                MessageBox.Show(Constant.ERROR_APPROVE_EXCEED_AVAILABLE_QUANTITY, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (approvedQuantity <= Constant.CONSTANT_ZERO)
            {
                MessageBox.Show(Constant.ERROR_APPROVE_SMALL_EQUAL_ZERO, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ReduceStock(int requestQuantity)
        {
            ArrayList latestBatch = mainController.getLatestProductBatch(lblProductID.Text);
            int availableQuantity = (int)latestBatch[Constant.OPERATION_INDEX_SEVEN];

            if (requestQuantity <= availableQuantity)
            {
                availableQuantity = availableQuantity - requestQuantity;
                mainController.UpdateStock(lblProductID.Text, (DateTime)latestBatch[Constant.OPERATION_INDEX_THREE], latestBatch[Constant.OPERATION_INDEX_FOUR].ToString(), latestBatch[Constant.OPERATION_INDEX_FIVE].ToString(), (DateTime)latestBatch[Constant.OPERATION_INDEX_SIX], availableQuantity.ToString());
                mainController.AddOutgoingRequest(lblProductName.Text, lblManufacturerName.Text, lblProductID.Text, (DateTime)latestBatch[Constant.OPERATION_INDEX_THREE], lblShopID.Text, lblCountry.Text, lblLocation.Text, requestQuantity.ToString());
            }
            else
            {
                requestQuantity = requestQuantity - availableQuantity;
                mainController.UpdateStock(lblProductID.Text, (DateTime)latestBatch[Constant.OPERATION_INDEX_THREE], latestBatch[Constant.OPERATION_INDEX_FOUR].ToString(), latestBatch[Constant.OPERATION_INDEX_FIVE].ToString(), (DateTime)latestBatch[Constant.OPERATION_INDEX_SIX], Constant.CONSTANT_ZERO.ToString());
                mainController.AddOutgoingRequest(lblProductName.Text, lblManufacturerName.Text, lblProductID.Text, (DateTime)latestBatch[Constant.OPERATION_INDEX_THREE], lblShopID.Text, lblCountry.Text, lblLocation.Text, availableQuantity.ToString());

                ReduceStock(requestQuantity);
            }
        }

        private void ApproveInterface_Load(object sender, EventArgs e)
        {
            txtApprovedQuantity.Text = (Convert.ToInt16(lblRequestQuantity.Text) >= Convert.ToInt16(lblAvailableQuantity.Text)) ? lblAvailableQuantity.Text : lblRequestQuantity.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime timeStamp = DateTime.Now;
                DateTime currentDateTime = new DateTime(timeStamp.Year, timeStamp.Month, timeStamp.Day, timeStamp.Hour, timeStamp.Minute, timeStamp.Second);
                mainController.AddRejectedRequest(lblProductName.Text, lblManufacturerName.Text, lblProductID.Text, lblShopID.Text, lblCountry.Text, lblLocation.Text, Convert.ToDateTime(lblRequestDate.Text), currentDateTime, GlobalVariableAccessor.CurrentStaffID, lblRequestQuantity.Text, (lblUrgency.Text == "YES" ? true : false));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsRightQuantityFormat())
                {
                    mainController.AddApprovedRequest(lblProductName.Text, lblManufacturerName.Text, lblProductID.Text, lblShopID.Text, lblCountry.Text, lblLocation.Text,
                        Convert.ToDateTime(lblRequestDate.Text), DateTime.Now, GlobalVariableAccessor.CurrentStaffID, lblRequestQuantity.Text, txtApprovedQuantity.Text, lblUrgency.Text.Equals("Yes") ? true : false, txtComment.Text);

                    ReduceStock(Convert.ToInt16(txtApprovedQuantity.Text));
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
