namespace Hypermarket_Admin_Management_Tool._0_View
{
    partial class Alert
    {
        /// <summary>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alert));
            this.dgvAlert = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRestock = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.clProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlert
            // 
            this.dgvAlert.AllowUserToAddRows = false;
            this.dgvAlert.AllowUserToDeleteRows = false;
            this.dgvAlert.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlert.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvAlert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlert.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clProductID,
            this.clProductName,
            this.clManufacturer});
            this.dgvAlert.Location = new System.Drawing.Point(2, 46);
            this.dgvAlert.Name = "dgvAlert";
            this.dgvAlert.ReadOnly = true;
            this.dgvAlert.RowHeadersVisible = false;
            this.dgvAlert.Size = new System.Drawing.Size(393, 224);
            this.dgvAlert.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(-1, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please be reminded:\r\nAmount of the following product(s) are below Minimum Stock!";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Gray;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(320, 276);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 29);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRestock
            // 
            this.btnRestock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRestock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestock.ForeColor = System.Drawing.Color.White;
            this.btnRestock.Location = new System.Drawing.Point(239, 276);
            this.btnRestock.Name = "btnRestock";
            this.btnRestock.Size = new System.Drawing.Size(75, 29);
            this.btnRestock.TabIndex = 2;
            this.btnRestock.Text = "Restock";
            this.btnRestock.UseVisualStyleBackColor = false;
            this.btnRestock.Click += new System.EventHandler(this.btnRestock_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(155, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // clProductID
            // 
            this.clProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clProductID.DataPropertyName = "ProductID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clProductID.DefaultCellStyle = dataGridViewCellStyle1;
            this.clProductID.HeaderText = "Product ID";
            this.clProductID.Name = "clProductID";
            this.clProductID.ReadOnly = true;
            // 
            // clProductName
            // 
            this.clProductName.DataPropertyName = "Name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clProductName.DefaultCellStyle = dataGridViewCellStyle2;
            this.clProductName.HeaderText = "Product Name";
            this.clProductName.Name = "clProductName";
            this.clProductName.ReadOnly = true;
            this.clProductName.Width = 180;
            // 
            // clManufacturer
            // 
            this.clManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clManufacturer.DataPropertyName = "ManufacturerName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clManufacturer.DefaultCellStyle = dataGridViewCellStyle3;
            this.clManufacturer.HeaderText = "Manufacturer";
            this.clManufacturer.Name = "clManufacturer";
            this.clManufacturer.ReadOnly = true;
            // 
            // Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 306);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRestock);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAlert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Alert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alert";
            this.Load += new System.EventHandler(this.Alert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRestock;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturer;

    }
}