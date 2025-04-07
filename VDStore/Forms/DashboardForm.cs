using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VDStore.DAL;
using VDStore.Models;

namespace VDStore.Forms
{
    public partial class DashboardForm : Form
    {
        private User currentUser;

        public DashboardForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        public DashboardForm(User user)
        {
            InitializeComponent();
            this.currentUser = user;
            this.Text = $"Dashboard - Welcome {user.Username} ({user.Role})";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSalesRevenue = new System.Windows.Forms.Panel();
            this.chartSalesRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblSalesRevenue = new System.Windows.Forms.Label();
            this.pnlInventory = new System.Windows.Forms.Panel();
            this.chartInventory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblInventory = new System.Windows.Forms.Label();
            this.pnlEmployeeSales = new System.Windows.Forms.Panel();
            this.chartEmployeeSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblEmployeeSales = new System.Windows.Forms.Label();
            this.pnlCustomerOrders = new System.Windows.Forms.Panel();
            this.chartCustomerOrders = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblCustomerOrders = new System.Windows.Forms.Label();
            this.cboDateRange = new System.Windows.Forms.ComboBox();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.pnlDateRange = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlSalesRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesRevenue)).BeginInit();
            this.pnlInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartInventory)).BeginInit();
            this.pnlEmployeeSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployeeSales)).BeginInit();
            this.pnlCustomerOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomerOrders)).BeginInit();
            this.pnlDateRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1200, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSalesRevenue
            // 
            this.pnlSalesRevenue.Controls.Add(this.chartSalesRevenue);
            this.pnlSalesRevenue.Controls.Add(this.lblSalesRevenue);
            this.pnlSalesRevenue.Location = new System.Drawing.Point(12, 86);
            this.pnlSalesRevenue.Name = "pnlSalesRevenue";
            this.pnlSalesRevenue.Size = new System.Drawing.Size(580, 300);
            this.pnlSalesRevenue.TabIndex = 2;
            // 
            // chartSalesRevenue
            // 
            chartArea5.Name = "ChartArea1";
            this.chartSalesRevenue.ChartAreas.Add(chartArea5);
            this.chartSalesRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.chartSalesRevenue.Legends.Add(legend5);
            this.chartSalesRevenue.Location = new System.Drawing.Point(0, 23);
            this.chartSalesRevenue.Name = "chartSalesRevenue";
            this.chartSalesRevenue.Size = new System.Drawing.Size(580, 277);
            this.chartSalesRevenue.TabIndex = 1;
            this.chartSalesRevenue.Text = "Sales Revenue";
            // 
            // lblSalesRevenue
            // 
            this.lblSalesRevenue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSalesRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesRevenue.Location = new System.Drawing.Point(0, 0);
            this.lblSalesRevenue.Name = "lblSalesRevenue";
            this.lblSalesRevenue.Size = new System.Drawing.Size(580, 23);
            this.lblSalesRevenue.TabIndex = 0;
            this.lblSalesRevenue.Text = "Sales Revenue";
            this.lblSalesRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInventory
            // 
            this.pnlInventory.Controls.Add(this.chartInventory);
            this.pnlInventory.Controls.Add(this.lblInventory);
            this.pnlInventory.Location = new System.Drawing.Point(608, 86);
            this.pnlInventory.Name = "pnlInventory";
            this.pnlInventory.Size = new System.Drawing.Size(580, 300);
            this.pnlInventory.TabIndex = 3;
            // 
            // chartInventory
            // 
            chartArea6.Name = "ChartArea1";
            this.chartInventory.ChartAreas.Add(chartArea6);
            this.chartInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chartInventory.Legends.Add(legend6);
            this.chartInventory.Location = new System.Drawing.Point(0, 23);
            this.chartInventory.Name = "chartInventory";
            this.chartInventory.Size = new System.Drawing.Size(580, 277);
            this.chartInventory.TabIndex = 1;
            this.chartInventory.Text = "Product Inventory";
            // 
            // lblInventory
            // 
            this.lblInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.Location = new System.Drawing.Point(0, 0);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(580, 23);
            this.lblInventory.TabIndex = 0;
            this.lblInventory.Text = "Product Inventory";
            this.lblInventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlEmployeeSales
            // 
            this.pnlEmployeeSales.Controls.Add(this.chartEmployeeSales);
            this.pnlEmployeeSales.Controls.Add(this.lblEmployeeSales);
            this.pnlEmployeeSales.Location = new System.Drawing.Point(12, 392);
            this.pnlEmployeeSales.Name = "pnlEmployeeSales";
            this.pnlEmployeeSales.Size = new System.Drawing.Size(580, 300);
            this.pnlEmployeeSales.TabIndex = 4;
            // 
            // chartEmployeeSales
            // 
            chartArea7.Name = "ChartArea1";
            this.chartEmployeeSales.ChartAreas.Add(chartArea7);
            this.chartEmployeeSales.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chartEmployeeSales.Legends.Add(legend7);
            this.chartEmployeeSales.Location = new System.Drawing.Point(0, 23);
            this.chartEmployeeSales.Name = "chartEmployeeSales";
            this.chartEmployeeSales.Size = new System.Drawing.Size(580, 277);
            this.chartEmployeeSales.TabIndex = 1;
            this.chartEmployeeSales.Text = "Employee Sales Performance";
            // 
            // lblEmployeeSales
            // 
            this.lblEmployeeSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmployeeSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeSales.Location = new System.Drawing.Point(0, 0);
            this.lblEmployeeSales.Name = "lblEmployeeSales";
            this.lblEmployeeSales.Size = new System.Drawing.Size(580, 23);
            this.lblEmployeeSales.TabIndex = 0;
            this.lblEmployeeSales.Text = "Employee Sales Performance";
            this.lblEmployeeSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCustomerOrders
            // 
            this.pnlCustomerOrders.Controls.Add(this.chartCustomerOrders);
            this.pnlCustomerOrders.Controls.Add(this.lblCustomerOrders);
            this.pnlCustomerOrders.Location = new System.Drawing.Point(608, 392);
            this.pnlCustomerOrders.Name = "pnlCustomerOrders";
            this.pnlCustomerOrders.Size = new System.Drawing.Size(580, 300);
            this.pnlCustomerOrders.TabIndex = 5;
            // 
            // chartCustomerOrders
            // 
            chartArea8.Name = "ChartArea1";
            this.chartCustomerOrders.ChartAreas.Add(chartArea8);
            this.chartCustomerOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Name = "Legend1";
            this.chartCustomerOrders.Legends.Add(legend8);
            this.chartCustomerOrders.Location = new System.Drawing.Point(0, 23);
            this.chartCustomerOrders.Name = "chartCustomerOrders";
            this.chartCustomerOrders.Size = new System.Drawing.Size(580, 277);
            this.chartCustomerOrders.TabIndex = 1;
            this.chartCustomerOrders.Text = "Orders by Customer";
            // 
            // lblCustomerOrders
            // 
            this.lblCustomerOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCustomerOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerOrders.Location = new System.Drawing.Point(0, 0);
            this.lblCustomerOrders.Name = "lblCustomerOrders";
            this.lblCustomerOrders.Size = new System.Drawing.Size(580, 23);
            this.lblCustomerOrders.TabIndex = 0;
            this.lblCustomerOrders.Text = "Orders by Customer";
            this.lblCustomerOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboDateRange
            // 
            this.cboDateRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateRange.FormattingEnabled = true;
            this.cboDateRange.Items.AddRange(new object[] {
            "Last 7 Days",
            "Last 30 Days",
            "Last 90 Days",
            "Last 365 Days",
            "All Time"});
            this.cboDateRange.Location = new System.Drawing.Point(91, 9);
            this.cboDateRange.Name = "cboDateRange";
            this.cboDateRange.Size = new System.Drawing.Size(121, 21);
            this.cboDateRange.TabIndex = 1;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRange.Location = new System.Drawing.Point(12, 12);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(76, 15);
            this.lblDateRange.TabIndex = 0;
            this.lblDateRange.Text = "Date Range:";
            // 
            // pnlDateRange
            // 
            this.pnlDateRange.Controls.Add(this.btnRefresh);
            this.pnlDateRange.Controls.Add(this.cboDateRange);
            this.pnlDateRange.Controls.Add(this.lblDateRange);
            this.pnlDateRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDateRange.Location = new System.Drawing.Point(0, 40);
            this.pnlDateRange.Name = "pnlDateRange";
            this.pnlDateRange.Size = new System.Drawing.Size(1200, 40);
            this.pnlDateRange.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(218, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlCustomerOrders);
            this.Controls.Add(this.pnlEmployeeSales);
            this.Controls.Add(this.pnlInventory);
            this.Controls.Add(this.pnlSalesRevenue);
            this.Controls.Add(this.pnlDateRange);
            this.Controls.Add(this.lblTitle);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.pnlSalesRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesRevenue)).EndInit();
            this.pnlInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartInventory)).EndInit();
            this.pnlEmployeeSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployeeSales)).EndInit();
            this.pnlCustomerOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomerOrders)).EndInit();
            this.pnlDateRange.ResumeLayout(false);
            this.pnlDateRange.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSalesRevenue;
        private System.Windows.Forms.Label lblSalesRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesRevenue;
        private System.Windows.Forms.Panel pnlInventory;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInventory;
        private System.Windows.Forms.Panel pnlEmployeeSales;
        private System.Windows.Forms.Label lblEmployeeSales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEmployeeSales;
        private System.Windows.Forms.Panel pnlCustomerOrders;
        private System.Windows.Forms.Label lblCustomerOrders;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCustomerOrders;
        private System.Windows.Forms.Panel pnlDateRange;
        private System.Windows.Forms.ComboBox cboDateRange;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Button btnRefresh;

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Set default date range to Last 30 Days
            cboDateRange.SelectedIndex = 1;
            
            // Load initial dashboard data
            LoadDashboardData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // Get date range based on selected option
            DateTime startDate = GetStartDateFromSelection();
            DateTime endDate = DateTime.Now;
            
            // Load sales revenue chart
            LoadSalesRevenueChart(startDate, endDate);
            
            // Load inventory chart
            LoadInventoryChart();
            
            // Load employee sales chart
            LoadEmployeeSalesChart(startDate, endDate);
            
            // Load customer orders chart
            LoadCustomerOrdersChart(startDate, endDate);
        }

        private DateTime GetStartDateFromSelection()
        {
            DateTime now = DateTime.Now;
            
            switch (cboDateRange.SelectedIndex)
            {
                case 0: // Last 7 Days
                    return now.AddDays(-7);
                case 1: // Last 30 Days
                    return now.AddDays(-30);
                case 2: // Last 90 Days
                    return now.AddDays(-90);
                case 3: // Last 365 Days
                    return now.AddDays(-365);
                case 4: // All Time
                    return new DateTime(2020, 1, 1); // Default to a reasonable "beginning of time"
                default:
                    return now.AddDays(-30); // Default to 30 days
            }
        }

        private void LoadSalesRevenueChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                // Get all bills in the date range
                List<Bill> bills = BillDAL.SearchBillsByDateRange(startDate, endDate);
                
                // Group by date and sum amounts
                var dailyRevenue = bills
                    .GroupBy(b => b.BillDate.Date)
                    .Select(g => new { Date = g.Key, Revenue = g.Sum(b => b.TotalAmount) })
                    .OrderBy(x => x.Date)
                    .ToList();
                
                // Clear existing data
                chartSalesRevenue.Series.Clear();
                
                // Add a new series for the chart
                Series series = new Series("Revenue");
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 3;
                series.Color = Color.Blue;
                
                // Set X value type to date
                chartSalesRevenue.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
                chartSalesRevenue.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                chartSalesRevenue.ChartAreas[0].AxisX.Interval = GetOptimalInterval(startDate, endDate);
                
                // Add data points
                foreach (var point in dailyRevenue)
                {
                    series.Points.AddXY(point.Date, point.Revenue);
                }
                
                // Add series to chart
                chartSalesRevenue.Series.Add(series);
                
                // Calculate total revenue
                decimal totalRevenue = bills.Sum(b => b.TotalAmount);
                lblSalesRevenue.Text = $"Sales Revenue: ${totalRevenue:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales revenue data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double GetOptimalInterval(DateTime startDate, DateTime endDate)
        {
            // Calculate total days
            int totalDays = (endDate - startDate).Days;
            
            // Determine optimal interval based on total days
            if (totalDays <= 14) return 1; // Daily for up to 2 weeks
            if (totalDays <= 60) return 3; // Every 3 days for up to 2 months
            if (totalDays <= 180) return 7; // Weekly for up to 6 months
            return 30; // Monthly for anything longer
        }

        private void LoadInventoryChart()
        {
            try
            {
                // Get all products
                List<Product> products = ProductDAL.GetAllProducts();
                
                // Sort products by quantity (low to high)
                products = products.OrderBy(p => p.Quantity).ToList();
                
                // Clear existing data
                chartInventory.Series.Clear();
                
                // Add a new series for the chart
                Series series = new Series("Stock Levels");
                series.ChartType = SeriesChartType.Bar;
                
                // Add data points
                foreach (var product in products)
                {
                    int index = series.Points.AddXY(product.Name, product.Quantity);
                    
                    // Set colors based on stock level
                    if (product.Quantity <= 5)
                        series.Points[index].Color = Color.Red;
                    else if (product.Quantity <= 20)
                        series.Points[index].Color = Color.Orange;
                    else
                        series.Points[index].Color = Color.Green;
                        
                    // Add product price as tooltip
                    series.Points[index].ToolTip = $"Price: ${product.Price:N2}";
                }
                
                // Add series to chart
                chartInventory.Series.Add(series);
                
                // Update label with low stock count
                int lowStockCount = products.Count(p => p.Quantity <= 5);
                lblInventory.Text = $"Product Inventory (Low Stock Items: {lowStockCount})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployeeSalesChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                // Get all bills in the date range
                List<Bill> bills = BillDAL.SearchBillsByDateRange(startDate, endDate);
                
                // Group by employee and sum total amount
                var employeeSales = bills
                    .GroupBy(b => b.EmployeeID)
                    .Select(g => new 
                    { 
                        EmployeeID = g.Key, 
                        Revenue = g.Sum(b => b.TotalAmount),
                        OrderCount = g.Count()
                    })
                    .OrderByDescending(x => x.Revenue)
                    .ToList();
                
                // Get employee names for the IDs
                List<Employee> employees = EmployeeDAL.GetAllEmployees();
                
                // Clear existing data
                chartEmployeeSales.Series.Clear();
                
                // Add a new series for the revenue
                Series revenueSeries = new Series("Revenue");
                revenueSeries.ChartType = SeriesChartType.Column;
                revenueSeries.YAxisType = AxisType.Primary;
                revenueSeries.Color = Color.Blue;
                
                // Add a new series for the order count
                Series orderSeries = new Series("Orders");
                orderSeries.ChartType = SeriesChartType.Line;
                orderSeries.YAxisType = AxisType.Secondary;
                orderSeries.Color = Color.Red;
                orderSeries.BorderWidth = 3;
                
                // Set up the chart area with two Y axes
                chartEmployeeSales.ChartAreas[0].AxisY.Title = "Revenue ($)";
                chartEmployeeSales.ChartAreas[0].AxisY2.Title = "Number of Orders";
                chartEmployeeSales.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                
                // Add data points
                foreach (var employee in employeeSales)
                {
                    string employeeName = employees.FirstOrDefault(e => e.ID == employee.EmployeeID)?.Name ?? $"Employee {employee.EmployeeID}";
                    
                    revenueSeries.Points.AddXY(employeeName, (double)employee.Revenue);
                    orderSeries.Points.AddXY(employeeName, employee.OrderCount);
                }
                
                // Add series to chart
                chartEmployeeSales.Series.Add(revenueSeries);
                chartEmployeeSales.Series.Add(orderSeries);
                
                // Update the label with total employee count
                lblEmployeeSales.Text = $"Employee Sales Performance ({employeeSales.Count} employees)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee sales data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomerOrdersChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                // Get all orders in the date range
                List<Order> orders = OrderDAL.SearchOrdersByDateRange(startDate, endDate);
                
                // Group by client and count orders
                var customerOrders = orders
                    .GroupBy(o => o.ClientID)
                    .Select(g => new 
                    { 
                        ClientID = g.Key, 
                        OrderCount = g.Count(),
                        TotalSpend = g.Sum(o => o.TotalPrice)
                    })
                    .OrderByDescending(x => x.OrderCount)
                    .Take(10)
                    .ToList();
                
                // Get client names for the IDs
                List<Client> clients = ClientDAL.GetAllClients();
                
                // Clear existing data
                chartCustomerOrders.Series.Clear();
                
                // Add a new series for the orders
                Series orderSeries = new Series("Number of Orders");
                orderSeries.ChartType = SeriesChartType.Pie;
                
                // Add data points
                foreach (var customer in customerOrders)
                {
                    string clientName = clients.FirstOrDefault(c => c.ID == customer.ClientID)?.Name ?? $"Client {customer.ClientID}";
                    
                    // Add the data point
                    int index = orderSeries.Points.AddXY(clientName, customer.OrderCount);
                    
                    // Set the tooltip to include total spend
                    orderSeries.Points[index].ToolTip = $"Total Spend: ${customer.TotalSpend:N2}";
                    
                    // Set the label to show client name and order count
                    orderSeries.Points[index].Label = $"{clientName}: {customer.OrderCount}";
                }
                
                // Add series to chart
                chartCustomerOrders.Series.Add(orderSeries);
                
                // Set up the chart display options
                chartCustomerOrders.Series[0].IsValueShownAsLabel = true;
                chartCustomerOrders.Series[0].LabelFormat = "#";
                
                // Update the label
                lblCustomerOrders.Text = $"Top 10 Customers by Order Count";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer orders data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 