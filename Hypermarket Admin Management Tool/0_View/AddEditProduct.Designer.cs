namespace Hypermarket_Admin_Management_Tool._0_View
{
    partial class AddEditProduct
    {
        /// <summary>2
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditProduct));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbManufacturer = new System.Windows.Forms.ComboBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.TextBox();
            this.pbAddManufacturer = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinStock = new System.Windows.Forms.TextBox();
            this.lblPopulatingInfo = new System.Windows.Forms.Label();
            this.checkLoadReady = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddManufacturer)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product ID: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Name: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 105);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Category: ";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(126, 39);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(308, 26);
            this.txtProductName.TabIndex = 0;
            this.txtProductName.Tag = "";
            this.txtProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddProductInterace_KeyPress);
            // 
            // cbCategory
            // 
            this.cbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCategory.DropDownHeight = 100;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.IntegralHeight = false;
            this.cbCategory.Location = new System.Drawing.Point(126, 105);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(233, 28);
            this.cbCategory.TabIndex = 2;
            this.cbCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddProductInterace_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(365, 210);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 30);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manufacturer: ";
            // 
            // cbManufacturer
            // 
            this.cbManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbManufacturer.DropDownHeight = 100;
            this.cbManufacturer.FormattingEnabled = true;
            this.cbManufacturer.IntegralHeight = false;
            this.cbManufacturer.Location = new System.Drawing.Point(126, 71);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(233, 28);
            this.cbManufacturer.TabIndex = 1;
            this.cbManufacturer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddProductInterace_KeyPress);
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(122, 13);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(26, 20);
            this.lblProductID.TabIndex = 9;
            this.lblProductID.Text = "ID";
            // 
            // txtError
            // 
            this.txtError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtError.Location = new System.Drawing.Point(12, 210);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(273, 35);
            this.txtError.TabIndex = 11;
            this.txtError.Text = "Error";
            this.txtError.Visible = false;
            // 
            // pbAddManufacturer
            // 
            this.pbAddManufacturer.BackColor = System.Drawing.Color.Transparent;
            //this.pbAddManufacturer.Image = global::Hypermarket_Admin_Management_Tool.Properties.Resources.add1;
            this.pbAddManufacturer.Location = new System.Drawing.Point(362, 71);
            this.pbAddManufacturer.Name = "pbAddManufacturer";
            this.pbAddManufacturer.Size = new System.Drawing.Size(34, 28);
            this.pbAddManufacturer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAddManufacturer.TabIndex = 10;
            this.pbAddManufacturer.TabStop = false;
            this.pbAddManufacturer.Click += new System.EventHandler(this.pbAddManufacturer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Maximum Stock: ";
            // 
            // txtMaxStock
            // 
            this.txtMaxStock.Location = new System.Drawing.Point(126, 139);
            this.txtMaxStock.Name = "txtMaxStock";
            this.txtMaxStock.Size = new System.Drawing.Size(233, 26);
            this.txtMaxStock.TabIndex = 3;
            this.txtMaxStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddProductInterace_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 177);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Minimum Stock: ";
            // 
            // txtMinStock
            // 
            this.txtMinStock.Location = new System.Drawing.Point(126, 171);
            this.txtMinStock.Name = "txtMinStock";
            this.txtMinStock.Size = new System.Drawing.Size(233, 26);
            this.txtMinStock.TabIndex = 4;
            this.txtMinStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddProductInterace_KeyPress);
            // 
            // lblPopulatingInfo
            // 
            this.lblPopulatingInfo.AutoSize = true;
            this.lblPopulatingInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPopulatingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPopulatingInfo.Location = new System.Drawing.Point(224, 13);
            this.lblPopulatingInfo.Name = "lblPopulatingInfo";
            this.lblPopulatingInfo.Size = new System.Drawing.Size(210, 15);
            this.lblPopulatingInfo.TabIndex = 12;
            this.lblPopulatingInfo.Text = "Populating category list, please wait...";
            this.lblPopulatingInfo.Visible = false;
            // 
            // checkLoadReady
            // 
            this.checkLoadReady.Tick += new System.EventHandler(this.checkLoadReady_Tick);
            // 
            // AddEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(440, 247);
            this.ControlBox = false;
            this.Controls.Add(this.lblPopulatingInfo);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.pbAddManufacturer);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.cbManufacturer);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.txtMinStock);
            this.Controls.Add(this.txtMaxStock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddEditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AddEditProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddManufacturer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbManufacturer;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.PictureBox pbAddManufacturer;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMinStock;
        private System.Windows.Forms.Label lblPopulatingInfo;
        private System.Windows.Forms.Timer checkLoadReady;
    }
}