using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hypermarket_Admin_Management_Tool._0_View
{
    public partial class SummaryReport : Form
    {
        private DataTable summaryTable, productTable, shopTable;
        private ReportType currentReportType;
        private string dateType = string.Empty;
        private string summaryType = string.Empty;

        public SummaryReport()
        {
            InitializeComponent();
        }

        public SummaryReport(ReportType type, DataTable summary, DataTable product, DataTable shop)
        {
            InitializeComponent();
            currentReportType = type;
            
            summaryTable = summary;
            productTable = product;
            shopTable = shop;
            summaryType = "Revenue";
            cbType.Text = "By Revenue";

            InitializeDateType();
            InitializeDataGridViewColumn();
            InitializeTitleAndDataView();
            InitializeSummaryChart(4);
            InitializeProductChart();
            InitializeShopChart();
        }

        private void InitializeDateType()
        {
            switch (currentReportType)
            {
                case ReportType.Daily:
                    dateType = "Day";
                    break;
                case ReportType.Monthly:
                    dateType = "Month";
                    break;
                case ReportType.Yearly:
                    dateType = "Year";
                    break;
                default:
                    break;
            }
        }

        private void InitializeDataGridViewColumn()
        {
            switch (currentReportType)
            {
                case ReportType.Daily:
                    dgvSummary.Columns[0].HeaderText = "Date";
                    break;
                case ReportType.Monthly:
                    dgvSummary.Columns[0].HeaderText = "Month";
                    break;
                case ReportType.Yearly:
                    dgvSummary.Columns[0].HeaderText = "Year";
                    break;
                default:
                    break;
            }
        }

        private void InitializeTitleAndDataView()
        {
            double totalSales = 0;
            double totalCost = 0;
            double totalRevenue = 0;
            foreach (DataRow dr in summaryTable.Rows)
            {
                totalSales += Convert.ToDouble(dr["TotalSellingPrice"].ToString());
                totalCost += Convert.ToDouble(dr["TotalCostPrice"].ToString());
                totalRevenue += Convert.ToDouble(dr["TotalRevenue"].ToString());
            }
            lblSales.Text = "Sales: $" + Math.Round(totalSales,2).ToString();
            lblCost.Text = "Cost: $" + Math.Round(totalCost, 2).ToString();
            lblRevenue.Text = "Revenue: $" + Math.Round(totalRevenue, 2).ToString();

            dgvSummary.AutoGenerateColumns = false;
            dgvSummary.DataSource = summaryTable;

            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = productTable;

            dgvShop.AutoGenerateColumns = false;
            dgvShop.DataSource = shopTable;
        }

        private void InitializeSummaryChart(int location)
        {
            chtSummary.Titles[0].Text = summaryType + " Growth Forecasting By " + dateType;

            chtSummary.Series["Growth Bar"].Points.Clear();
            chtSummary.Series["Trend"].Points.Clear();
            foreach (DataRow dr in summaryTable.Rows)
            {
                chtSummary.Series["Growth Bar"].Points.AddXY(dr[0].ToString(), Math.Round(Convert.ToDouble(dr[location].ToString()), 2));
                chtSummary.Series["Trend"].Points.AddXY(dr[0].ToString(), Math.Round(Convert.ToDouble(dr[location].ToString()), 2));
            }
            chtSummary.Series["Trend"].MarkerStyle = MarkerStyle.Circle;
            chtSummary.Series["Trend"].MarkerColor = Color.Green;
            chtSummary.Series["Trend"].MarkerSize = 10;

            CheckAndForecast();
        }

        private void CheckAndForecast()
        {
            string numberOfPoints = summaryTable.Rows.Count.ToString();
            string nextX = string.Empty;
            if (Convert.ToInt16(numberOfPoints) >= 2)
            {
                switch (currentReportType)
                {
                    case ReportType.Daily:
                        nextX = Convert.ToDateTime(summaryTable.Rows[summaryTable.Rows.Count - 1][0].ToString()).AddDays(1).ToString("yyyy/M/d");
                        break;
                    case ReportType.Monthly:
                        nextX = Convert.ToDateTime(summaryTable.Rows[summaryTable.Rows.Count - 1][0].ToString()).AddMonths(1).ToString();
                        break;
                    case ReportType.Yearly:
                        nextX = (Convert.ToInt32(summaryTable.Rows[summaryTable.Rows.Count - 1][0].ToString()) + 1).ToString();
                        break;
                    default:
                        break;
                }
                chtSummary.Series.Add("HidenForecast");
                chtSummary.DataManipulator.FinancialFormula(System.Windows.Forms.DataVisualization.Charting.FinancialFormula.Forecasting, "2," + numberOfPoints + ",false,false", "Growth Bar:Y", "HidenForecast:Y");
                DataPoint forecastingPoint = chtSummary.Series["HidenForecast"].Points.FindMaxByValue();

                double[] maxValue = forecastingPoint.YValues;
                double value = (double)Math.Round(Convert.ToDecimal(maxValue[0]), 2);
                chtSummary.Series["Growth Bar"].Points.AddXY(nextX, value);
                chtSummary.Series["Growth Bar"].Points[chtSummary.Series["Growth Bar"].Points.Count - 1].Color = Color.OrangeRed;
                chtSummary.Series["Growth Bar"].Points[chtSummary.Series["Growth Bar"].Points.Count - 1].BorderDashStyle = ChartDashStyle.Dash;
                chtSummary.Series["Growth Bar"].Points[chtSummary.Series["Growth Bar"].Points.Count - 1].BorderColor = Color.Black;
                chtSummary.Series["Growth Bar"].Points[chtSummary.Series["Growth Bar"].Points.Count - 1].BorderWidth = 3;
                chtSummary.Series["Trend"].Points.AddXY(nextX, value);
                chtSummary.Series.Remove(chtSummary.Series["HidenForecast"]);
            }
        }

        private void InitializeProductChart()
        {
            string[] salesLabel = lblSales.Text.Split(new char[]{' ','$'});
            double totalSales = Convert.ToDouble(salesLabel[2]);
            double salesOfFiveProduct = 0;
            foreach (DataRow dr in productTable.Rows)
            {
                chtProduct.Series["Percentage of Product Sales"].Points.AddXY(dr[0].ToString(), string.Format("{0:N2}", Convert.ToDouble(dr[2].ToString())));
                salesOfFiveProduct += Convert.ToDouble(dr[2].ToString());
            }
            chtProduct.Series["Percentage of Product Sales"].Points.AddXY("Others", string.Format("{0:N2}", totalSales-salesOfFiveProduct));
            chtProduct.Titles[0].Text = "Sales Percentage of Category";

            foreach (DataPoint dp in chtProduct.Series["Percentage of Product Sales"].Points)
            {
                dp["Exploded"] = "true";
                dp["PieLabelStyle"] = "Outside";
                dp["PieLineColor"] = "Red";
            }
        }

        private void InitializeShopChart()
        {
            string[] salesLabel = lblSales.Text.Split(new char[]{' ','$'});
            double totalSales = Convert.ToDouble(salesLabel[2]);
            double salesOfFiveShop = 0;
            foreach (DataRow dr in shopTable.Rows)
            {
                chtShop.Series["Percentage of Shop Sales"].Points.AddXY(dr[0].ToString(), string.Format("{0:N2}", Convert.ToDouble(dr[2].ToString())));
                salesOfFiveShop += Convert.ToDouble(dr[2].ToString());
            }
            chtShop.Series["Percentage of Shop Sales"].Points.AddXY("Others", string.Format("{0:N2}", totalSales - salesOfFiveShop));
            chtShop.Titles[0].Text = "Sales Percentage of Shop";

            foreach (DataPoint dp in chtShop.Series["Percentage of Shop Sales"].Points)
            {
                dp["Exploded"] = "true";
                dp["PieLabelStyle"] = "Outside";
                dp["PieLineColor"] = "Red";
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbType.SelectedIndex)
            {
                case 0:
                    summaryType = "Revenue";
                    InitializeSummaryChart(4);
                    break;
                case 1:
                    summaryType = "Cost";
                    InitializeSummaryChart(2);
                    break;
                case 2:
                    summaryType = "Sales";
                    InitializeSummaryChart(3);
                    break;
                default:
                    break;
            }
        }
    }
}
