using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace Hypermarket_Admin_Management_Tool._0_View
{
    public delegate void SelectStockTabpage();
    public partial class Alert : Form
    {
        private DataTable lessThanMinimumStockTable = new DataTable();
        public SelectStockTabpage del;

        public Alert()
        {
            InitializeComponent();
        }

        private void Alert_Load(object sender, EventArgs e)
        {
            try
            {
                _1_Model.DBConnectionManager DBConn = _1_Model.DBConnectionManager.getInstance();
                using (SqlConnection SQLConn = new SqlConnection(DBConn.getConnectionString()))
                using (SqlCommand SQLComm = new SqlCommand(Constant.ALERT_SELECT_COMMAND, SQLConn))
                {
                    SQLConn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(SQLComm);
                    adapter.Fill(lessThanMinimumStockTable);
                    SQLConn.Close();

                    dgvAlert.AutoGenerateColumns = false;
                    dgvAlert.DataSource = lessThanMinimumStockTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlert.Rows.Count == Constant.CONSTANT_ZERO)
                {
                    MessageBox.Show(Constant.NOTHING_TO_EXPORT, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                    
                StreamWriter exportProductInfo;
                string fileName = Constant.LESS_THAN_MINIMUM_STOCK_FILE_NAME;
                if (!File.Exists(fileName))
                {
                    exportProductInfo = new StreamWriter(fileName);
                }
                else
                {
                    exportProductInfo = File.AppendText(fileName);
                }

                foreach (DataGridViewRow dgr in dgvAlert.Rows)
                {
                    string writeString = dgr.Cells[Constant.CONSTANT_ZERO].Value.ToString() + Constant.SPACE + dgr.Cells[Constant.OPERATION_INDEX_ONE].Value.ToString() + Constant.SPACE + dgr.Cells[Constant.OPERATION_INDEX_TWO].Value.ToString();
                    exportProductInfo.WriteLine(writeString);
                }
                exportProductInfo.Close();
                MessageBox.Show(Constant.EXPORT_SUCCESS, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constant.SPACE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestock_Click(object sender, EventArgs e)
        {
            del();
            Close();
        }
    }
}
