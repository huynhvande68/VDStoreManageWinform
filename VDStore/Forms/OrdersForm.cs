using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VDStore.DAL;
using VDStore.Models;
using System.Linq;
using System.IO;
using System.Text;

namespace VDStore.Forms
{
    public partial class OrdersForm : Form
    {
        private List<Order> orders;
        private Order currentOrder;

        public OrdersForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Thay đổi vị trí của nút Export Orders để dễ nhìn thấy hơn
            this.btnExportOrdersCsv.Location = new System.Drawing.Point(771, 29);
            this.btnExportOrdersCsv.BringToFront();
        }

        private void InitializeComponent()
        {
            this.grpOrderList = new System.Windows.Forms.GroupBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.grpOrderDetails = new System.Windows.Forms.GroupBox();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.btnGenerateBill = new System.Windows.Forms.Button();
            this.btnExportOrdersCsv = new System.Windows.Forms.Button();
            this.grpOrderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // grpOrderList
            // 
            this.grpOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOrderList.Controls.Add(this.dgvOrders);
            this.grpOrderList.Location = new System.Drawing.Point(12, 94);
            this.grpOrderList.Name = "grpOrderList";
            this.grpOrderList.Size = new System.Drawing.Size(934, 179);
            this.grpOrderList.TabIndex = 0;
            this.grpOrderList.TabStop = false;
            this.grpOrderList.Text = "Order List";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(6, 19);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(922, 154);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            // 
            // grpSearch
            // 
            this.grpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearch.Controls.Add(this.btnExportOrdersCsv);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.dtpEndDate);
            this.grpSearch.Controls.Add(this.lblEndDate);
            this.grpSearch.Controls.Add(this.dtpStartDate);
            this.grpSearch.Controls.Add(this.lblStartDate);
            this.grpSearch.Controls.Add(this.cboClient);
            this.grpSearch.Controls.Add(this.lblClient);
            this.grpSearch.Location = new System.Drawing.Point(12, 12);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(934, 76);
            this.grpSearch.TabIndex = 1;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(671, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(524, 29);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 20);
            this.dtpEndDate.TabIndex = 5;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(465, 33);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "End Date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(342, 29);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(117, 20);
            this.dtpStartDate.TabIndex = 3;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(280, 33);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "Start Date:";
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(59, 30);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(200, 21);
            this.cboClient.TabIndex = 1;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(19, 33);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(36, 13);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Client:";
            // 
            // grpOrderDetails
            // 
            this.grpOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOrderDetails.Controls.Add(this.dgvOrderItems);
            this.grpOrderDetails.Controls.Add(this.btnGenerateBill);
            this.grpOrderDetails.Location = new System.Drawing.Point(12, 279);
            this.grpOrderDetails.Name = "grpOrderDetails";
            this.grpOrderDetails.Size = new System.Drawing.Size(934, 159);
            this.grpOrderDetails.TabIndex = 2;
            this.grpOrderDetails.TabStop = false;
            this.grpOrderDetails.Text = "Order Details";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(6, 19);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.Size = new System.Drawing.Size(812, 134);
            this.dgvOrderItems.TabIndex = 1;
            // 
            // btnGenerateBill
            // 
            this.btnGenerateBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateBill.Location = new System.Drawing.Point(829, 19);
            this.btnGenerateBill.Name = "btnGenerateBill";
            this.btnGenerateBill.Size = new System.Drawing.Size(99, 23);
            this.btnGenerateBill.TabIndex = 0;
            this.btnGenerateBill.Text = "Generate Bill";
            this.btnGenerateBill.UseVisualStyleBackColor = true;
            this.btnGenerateBill.Click += new System.EventHandler(this.btnGenerateBill_Click);
            // 
            // btnExportOrdersCsv
            // 
            this.btnExportOrdersCsv.Location = new System.Drawing.Point(771, 29);
            this.btnExportOrdersCsv.Name = "btnExportOrdersCsv";
            this.btnExportOrdersCsv.Size = new System.Drawing.Size(140, 22);
            this.btnExportOrdersCsv.TabIndex = 13;
            this.btnExportOrdersCsv.Text = "Export to CSV";
            this.btnExportOrdersCsv.UseVisualStyleBackColor = true;
            this.btnExportOrdersCsv.Click += new System.EventHandler(this.BtnExportOrdersCsv_Click);
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 450);
            this.Controls.Add(this.grpOrderDetails);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpOrderList);
            this.Name = "OrdersForm";
            this.Text = "Manage Orders";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            this.grpOrderList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpOrderDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox grpOrderList;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grpOrderDetails;
        private System.Windows.Forms.Button btnGenerateBill;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnExportOrdersCsv;

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            // Load clients for dropdown
            LoadClients();
            
            // Setup date range (default to last 30 days)
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            
            // Load orders
            LoadOrders();
            
            // Setup order items grid
            SetupOrderItemsGrid();
            
            // Disable generate bill button until an order is selected
            btnGenerateBill.Enabled = false;
        }

        private void LoadClients()
        {
            try
            {
                // Add an "All Clients" option
                List<Client> clientList = new List<Client>();
                clientList.Add(new Client { ID = 0, Name = "-- All Clients --" });
                
                // Add actual clients
                clientList.AddRange(ClientDAL.GetAllClients());
                
                cboClient.DataSource = null;
                cboClient.DisplayMember = "Name";
                cboClient.ValueMember = "ID";
                cboClient.DataSource = clientList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading clients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            try
            {
                // Get the selected client ID
                int clientId = Convert.ToInt32(cboClient.SelectedValue);
                
                // Get the date range
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1); // End of day
                
                if (clientId > 0)
                {
                    // Load orders for specific client
                    orders = OrderDAL.GetOrdersByClientID(clientId);
                }
                else
                {
                    // Load all orders within date range
                    orders = OrderDAL.SearchOrdersByDateRange(startDate, endDate);
                }
                
                // First create a bindable list for the grid
                var bindableOrders = new List<object>();
                foreach(var order in orders)
                {
                    bindableOrders.Add(new
                    {
                        order.ID,
                        order.OrderDate,
                        ClientName = order.Client.Name,
                        EmployeeName = order.Employee.Name,
                        order.TotalPrice,
                        order.ClientID,
                        order.EmployeeID
                    });
                }
                
                // Display the orders
                dgvOrders.DataSource = bindableOrders;
                
                // Configure columns
                if (dgvOrders.Columns.Count > 0)
                {
                    dgvOrders.Columns["ID"].Width = 50;
                    dgvOrders.Columns["ID"].HeaderText = "Order ID";
                    dgvOrders.Columns["ClientID"].Visible = false;
                    dgvOrders.Columns["EmployeeID"].Visible = false;
                    
                    dgvOrders.Columns["ClientName"].Width = 150;
                    dgvOrders.Columns["ClientName"].HeaderText = "Client";
                    
                    dgvOrders.Columns["EmployeeName"].Width = 150;
                    dgvOrders.Columns["EmployeeName"].HeaderText = "Employee";
                    
                    dgvOrders.Columns["OrderDate"].Width = 120;
                    dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                    dgvOrders.Columns["OrderDate"].HeaderText = "Order Date";
                    
                    dgvOrders.Columns["TotalPrice"].Width = 100;
                    dgvOrders.Columns["TotalPrice"].DefaultCellStyle.Format = "N2";
                    dgvOrders.Columns["TotalPrice"].HeaderText = "Total Amount";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupOrderItemsGrid()
        {
            // Clear any existing data
            dgvOrderItems.DataSource = null;
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int orderID = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["ID"].Value);
                currentOrder = OrderDAL.GetOrderByID(orderID);
                
                if (currentOrder != null)
                {
                    LoadOrderItems(currentOrder);
                    btnGenerateBill.Enabled = true;
                }
            }
        }

        private void LoadOrderItems(Order order)
        {
            dgvOrderItems.DataSource = order.OrderItems;
            
            // Configure columns
            if (dgvOrderItems.Columns.Count > 0)
            {
                dgvOrderItems.Columns["ID"].Width = 50;
                dgvOrderItems.Columns["OrderID"].Visible = false;
                dgvOrderItems.Columns["ProductID"].Visible = false;
                dgvOrderItems.Columns["Order"].Visible = false;
                
                if (dgvOrderItems.Columns.Contains("Product"))
                {
                    dgvOrderItems.Columns["Product"].Visible = false;
                }
                
                // Add custom columns
                if (!dgvOrderItems.Columns.Contains("ProductName"))
                {
                    DataGridViewTextBoxColumn productColumn = new DataGridViewTextBoxColumn();
                    productColumn.Name = "ProductName";
                    productColumn.HeaderText = "Product";
                    productColumn.DataPropertyName = "Product.Name";
                    dgvOrderItems.Columns.Add(productColumn);
                }
                
                dgvOrderItems.Columns["Quantity"].Width = 80;
                dgvOrderItems.Columns["UnitPrice"].Width = 100;
                dgvOrderItems.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
                dgvOrderItems.Columns["UnitPrice"].HeaderText = "Unit Price";
                
                // Add Subtotal column
                if (!dgvOrderItems.Columns.Contains("Subtotal"))
                {
                    DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn();
                    subtotalColumn.Name = "Subtotal";
                    subtotalColumn.HeaderText = "Subtotal";
                    subtotalColumn.DefaultCellStyle.Format = "N2";
                    dgvOrderItems.Columns.Add(subtotalColumn);
                    
                    // Calculate subtotal for each row
                    foreach (DataGridViewRow row in dgvOrderItems.Rows)
                    {
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        decimal unitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
                        row.Cells["Subtotal"].Value = quantity * unitPrice;
                    }
                }
                
                if (dgvOrderItems.Columns.Contains("ProductName"))
                {
                    dgvOrderItems.Columns["ProductName"].Width = 200;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            if (currentOrder == null)
            {
                MessageBox.Show("Please select an order first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                // Check if bill already exists for this order
                // This would require additional functionality in your BillDAL class
                
                // Generate bill
                int billID = BillDAL.GenerateBill(currentOrder.ID);
                
                if (billID > 0)
                {
                    MessageBox.Show("Bill generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Refresh the orders
                    LoadOrders();
                }
                else
                {
                    MessageBox.Show("Failed to generate bill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating bill: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Export Orders to CSV
        private void BtnExportOrdersCsv_Click(object sender, EventArgs e)
        {
            if (dgvOrders.Rows.Count == 0)
            {
                MessageBox.Show("No orders to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Save Order List",
                FileName = "Orders_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a StringBuilder to store CSV data
                    StringBuilder csv = new StringBuilder();
                    
                    // Add headers
                    List<string> headers = new List<string>();
                    foreach (DataGridViewColumn column in dgvOrders.Columns)
                    {
                        if (column.Visible)
                        {
                            headers.Add($"\"{column.HeaderText}\"");
                        }
                    }
                    csv.AppendLine(string.Join(",", headers));
                    
                    // Add rows
                    foreach (DataGridViewRow row in dgvOrders.Rows)
                    {
                        List<string> fields = new List<string>();
                        foreach (DataGridViewColumn column in dgvOrders.Columns)
                        {
                            if (column.Visible)
                            {
                                // Get value, handle null and escape quotes
                                var value = row.Cells[column.Index].Value;
                                string fieldValue = value == null ? "" : value.ToString();
                                fieldValue = $"\"{fieldValue.Replace("\"", "\"\"")}\"";
                                fields.Add(fieldValue);
                            }
                        }
                        csv.AppendLine(string.Join(",", fields));
                    }
                    
                    // Write to file
                    File.WriteAllText(saveFileDialog.FileName, csv.ToString(), Encoding.UTF8);
                    
                    MessageBox.Show($"Orders successfully exported to {saveFileDialog.FileName}", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    // Ask if user wants to open the file
                    if (MessageBox.Show("Do you want to open this file now?", "Open File", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveFileDialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting data: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
} 