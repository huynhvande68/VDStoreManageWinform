using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VDStore.DAL;
using VDStore.Models;
using System.Linq;
using System.IO;
using System.Text;
using System.Drawing;

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
            this.btnExportOrdersCsv = new System.Windows.Forms.Button();
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
            this.grpOrderStatus = new System.Windows.Forms.GroupBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.grpOrderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.grpOrderStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOrderList
            // 
            this.grpOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOrderList.Controls.Add(this.dgvOrders);
            this.grpOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.grpSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearch.Location = new System.Drawing.Point(12, 12);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(934, 76);
            this.grpSearch.TabIndex = 1;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search";
            // 
            // btnExportOrdersCsv
            // 
            this.btnExportOrdersCsv.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnExportOrdersCsv.Location = new System.Drawing.Point(771, 29);
            this.btnExportOrdersCsv.Name = "btnExportOrdersCsv";
            this.btnExportOrdersCsv.Size = new System.Drawing.Size(140, 24);
            this.btnExportOrdersCsv.TabIndex = 13;
            this.btnExportOrdersCsv.Text = "Export to CSV";
            this.btnExportOrdersCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportOrdersCsv.UseVisualStyleBackColor = false;
            this.btnExportOrdersCsv.Click += new System.EventHandler(this.BtnExportOrdersCsv_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Window;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Location = new System.Drawing.Point(671, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(524, 29);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 21);
            this.dtpEndDate.TabIndex = 5;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(465, 33);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(61, 15);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "End Date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(342, 29);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(117, 21);
            this.dtpStartDate.TabIndex = 3;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(280, 33);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(64, 15);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "Start Date:";
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(59, 30);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(200, 23);
            this.cboClient.TabIndex = 1;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(19, 33);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(41, 15);
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
            this.grpOrderDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnGenerateBill.BackColor = System.Drawing.Color.IndianRed;
            this.btnGenerateBill.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGenerateBill.Location = new System.Drawing.Point(829, 19);
            this.btnGenerateBill.Name = "btnGenerateBill";
            this.btnGenerateBill.Size = new System.Drawing.Size(99, 26);
            this.btnGenerateBill.TabIndex = 0;
            this.btnGenerateBill.Text = "Generate Bill";
            this.btnGenerateBill.UseVisualStyleBackColor = false;
            this.btnGenerateBill.Click += new System.EventHandler(this.btnGenerateBill_Click);
            // 
            // grpOrderStatus
            // 
            this.grpOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpOrderStatus.Controls.Add(this.cboStatus);
            this.grpOrderStatus.Controls.Add(this.lblStatus);
            this.grpOrderStatus.Controls.Add(this.btnUpdateStatus);
            this.grpOrderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOrderStatus.Location = new System.Drawing.Point(12, 444);
            this.grpOrderStatus.Name = "grpOrderStatus";
            this.grpOrderStatus.Size = new System.Drawing.Size(401, 65);
            this.grpOrderStatus.TabIndex = 3;
            this.grpOrderStatus.TabStop = false;
            this.grpOrderStatus.Text = "Update Order Status";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Active",
            "Completed",
            "Cancelled"});
            this.cboStatus.Location = new System.Drawing.Point(69, 24);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(200, 23);
            this.cboStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(19, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status:";
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(284, 23);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(102, 25);
            this.btnUpdateStatus.TabIndex = 2;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 521);
            this.Controls.Add(this.grpOrderStatus);
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
            this.grpOrderStatus.ResumeLayout(false);
            this.grpOrderStatus.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpOrderStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnUpdateStatus;

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            // Set default dates to 30 days range
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            
            // Load clients for filter dropdown
            LoadClients();
            
            // Load initial orders
            LoadOrders();
            
            // Setup order items grid
            SetupOrderItemsGrid();
            
            // Disable the update status controls until an order is selected
            cboStatus.SelectedIndex = 0;
            grpOrderStatus.Enabled = false;
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
                // Get selected client ID if any
                int clientId = 0;
                if (cboClient.SelectedItem != null && cboClient.SelectedIndex > 0)
                {
                    clientId = ((Client)cboClient.SelectedItem).ID;
                }
                
                // Get date range
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1); // End of the day
                
                // Load orders based on filter
                if (clientId > 0)
                {
                    orders = OrderDAL.GetOrdersByClientID(clientId);
                }
                else
                {
                    orders = OrderDAL.SearchOrdersByDateRange(startDate, endDate);
                }
                
                // Create a bindable list with client and employee names
                var bindableOrders = orders.Select(o => new {
                    ID = o.ID,
                    Client = o.Client?.Name ?? "Unknown",
                    Employee = o.Employee?.Name ?? "Unknown",
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalPrice,
                    Status = o.Status
                }).ToList();
                
                // Set the data source
                dgvOrders.DataSource = bindableOrders;
                
                // Configure columns
                dgvOrders.Columns["ID"].HeaderText = "Order ID";
                dgvOrders.Columns["ID"].Width = 80;
                dgvOrders.Columns["Client"].HeaderText = "Client";
                dgvOrders.Columns["Client"].Width = 150;
                dgvOrders.Columns["Employee"].HeaderText = "Employee";
                dgvOrders.Columns["Employee"].Width = 150;
                dgvOrders.Columns["OrderDate"].HeaderText = "Order Date";
                dgvOrders.Columns["OrderDate"].Width = 120;
                dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvOrders.Columns["TotalAmount"].HeaderText = "Total Amount";
                dgvOrders.Columns["TotalAmount"].Width = 120;
                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
                dgvOrders.Columns["Status"].HeaderText = "Status";
                dgvOrders.Columns["Status"].Width = 100;
                
                // Color code the Status column
                dgvOrders.CellFormatting += DgvOrders_CellFormatting;
                
                // Clear order details
                dgvOrderItems.DataSource = null;
                currentOrder = null;
                btnGenerateBill.Enabled = false;
                grpOrderStatus.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrders.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                switch (status)
                {
                    case "Active":
                        e.CellStyle.ForeColor = Color.Blue;
                        break;
                    case "Completed":
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case "Cancelled":
                        e.CellStyle.ForeColor = Color.Red;
                        break;
                }
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
                // Get the order ID from the selected row
                int orderID = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["ID"].Value);
                
                // Load the current order
                currentOrder = OrderDAL.GetOrderByID(orderID);
                
                // Load order items
                if (currentOrder != null)
                {
                    LoadOrderItems(currentOrder);
                    btnGenerateBill.Enabled = true;
                    
                    // Enable and set the status dropdown
                    grpOrderStatus.Enabled = true;
                    cboStatus.SelectedItem = currentOrder.Status;
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
            
            // Kiểm tra nếu đơn hàng đã ở trạng thái "Cancelled"
            if (currentOrder.Status == "Cancelled")
            {
                MessageBox.Show("Cannot generate bill for a cancelled order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                // Lưu ID đơn hàng trước khi gọi LoadOrders() làm mất currentOrder
                int orderId = currentOrder.ID;
                
                // Generate bill
                int billID = BillDAL.GenerateBill(orderId);
                
                if (billID > 0)
                {
                    // Cập nhật trạng thái đơn hàng thành "Completed"
                    if (currentOrder.Status != "Completed")
                    {
                        if (OrderDAL.UpdateOrderStatus(orderId, "Completed"))
                        {
                            MessageBox.Show("Bill generated successfully and order status updated to Completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Bill generated successfully but failed to update order status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bill generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    // Refresh the orders
                    LoadOrders();
                    
                    // Tìm và chọn lại đơn hàng vừa cập nhật
                    if (dgvOrders.Rows.Count > 0)
                    {
                        for (int i = 0; i < dgvOrders.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dgvOrders.Rows[i].Cells["ID"].Value) == orderId)
                            {
                                dgvOrders.Rows[i].Selected = true;
                                dgvOrders.CurrentCell = dgvOrders.Rows[i].Cells[0];
                                
                                // Đặt lại currentOrder và cập nhật giao diện
                                dgvOrders_CellClick(dgvOrders, new DataGridViewCellEventArgs(0, i));
                                break;
                            }
                        }
                    }
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

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (currentOrder == null)
            {
                MessageBox.Show("Please select an order first.", "No Order Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string newStatus = cboStatus.SelectedItem.ToString();
            
            // Verify if status changed
            if (newStatus == currentOrder.Status)
            {
                MessageBox.Show("Order status is already set to " + newStatus, "No Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // Confirm update
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to change the order status from '{currentOrder.Status}' to '{newStatus}'?", 
                "Confirm Status Update", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                try
                {
                    int orderId = currentOrder.ID; // Lưu ID trước khi LoadOrders() làm mất currentOrder
                    
                    if (OrderDAL.UpdateOrderStatus(orderId, newStatus))
                    {
                        MessageBox.Show("Order status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Reload orders to refresh the grid
                        LoadOrders();
                        
                        // Find and select the updated order
                        if (dgvOrders.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgvOrders.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dgvOrders.Rows[i].Cells["ID"].Value) == orderId)
                                {
                                    dgvOrders.Rows[i].Selected = true;
                                    dgvOrders.CurrentCell = dgvOrders.Rows[i].Cells[0];
                                    
                                    // Đặt lại currentOrder và cập nhật giao diện
                                    dgvOrders_CellClick(dgvOrders, new DataGridViewCellEventArgs(0, i));
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to update order status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating order status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
} 