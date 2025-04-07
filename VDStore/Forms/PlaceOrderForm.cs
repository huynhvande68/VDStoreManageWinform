using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using VDStore.DAL;
using VDStore.Models;

namespace VDStore.Forms
{
    public partial class PlaceOrderForm : Form
    {
        private User currentUser;
        private List<Client> clients;
        private List<Product> products;
        private DataTable orderItems;
        private decimal totalAmount = 0;

        public PlaceOrderForm(User user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            currentUser = user;
            
            // Initialize OrderItems DataTable
            orderItems = new DataTable();
            orderItems.Columns.Add("ProductID", typeof(int));
            orderItems.Columns.Add("ProductName", typeof(string));
            orderItems.Columns.Add("Price", typeof(decimal));
            orderItems.Columns.Add("Quantity", typeof(int));
            orderItems.Columns.Add("Subtotal", typeof(decimal));
        }

        private void InitializeComponent()
        {
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.grpProduct = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.grpOrderItems = new System.Windows.Forms.GroupBox();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.grpTotal = new System.Windows.Forms.GroupBox();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.grpClient.SuspendLayout();
            this.grpProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.grpOrderItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.grpTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(this.cboClient);
            this.grpClient.Controls.Add(this.lblClient);
            this.grpClient.Location = new System.Drawing.Point(12, 12);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(776, 68);
            this.grpClient.TabIndex = 0;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client Information";
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(88, 27);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(300, 21);
            this.cboClient.TabIndex = 1;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(15, 30);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(36, 13);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Client:";
            // 
            // grpProduct
            // 
            this.grpProduct.Controls.Add(this.btnAdd);
            this.grpProduct.Controls.Add(this.numQuantity);
            this.grpProduct.Controls.Add(this.lblQuantity);
            this.grpProduct.Controls.Add(this.lblPrice);
            this.grpProduct.Controls.Add(this.txtPrice);
            this.grpProduct.Controls.Add(this.lblStock);
            this.grpProduct.Controls.Add(this.txtStock);
            this.grpProduct.Controls.Add(this.cboProduct);
            this.grpProduct.Controls.Add(this.lblProduct);
            this.grpProduct.Location = new System.Drawing.Point(12, 86);
            this.grpProduct.Name = "grpProduct";
            this.grpProduct.Size = new System.Drawing.Size(776, 108);
            this.grpProduct.TabIndex = 1;
            this.grpProduct.TabStop = false;
            this.grpProduct.Text = "Product Information";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(623, 65);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add to Order";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(485, 65);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 20);
            this.numQuantity.TabIndex = 7;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(433, 67);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(223, 67);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(263, 64);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(125, 20);
            this.txtPrice.TabIndex = 4;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(15, 67);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(65, 13);
            this.lblStock.TabIndex = 3;
            this.lblStock.Text = "In Stock Qt:";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(86, 64);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(100, 20);
            this.txtStock.TabIndex = 2;
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(88, 27);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(300, 21);
            this.cboProduct.TabIndex = 1;
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(15, 30);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(47, 13);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "Product:";
            // 
            // grpOrderItems
            // 
            this.grpOrderItems.Controls.Add(this.dgvOrderItems);
            this.grpOrderItems.Controls.Add(this.btnRemove);
            this.grpOrderItems.Location = new System.Drawing.Point(12, 200);
            this.grpOrderItems.Name = "grpOrderItems";
            this.grpOrderItems.Size = new System.Drawing.Size(776, 175);
            this.grpOrderItems.TabIndex = 2;
            this.grpOrderItems.TabStop = false;
            this.grpOrderItems.Text = "Order Items";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(18, 19);
            this.dgvOrderItems.MultiSelect = false;
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderItems.Size = new System.Drawing.Size(657, 143);
            this.dgvOrderItems.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(681, 19);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // grpTotal
            // 
            this.grpTotal.Controls.Add(this.btnPlaceOrder);
            this.grpTotal.Controls.Add(this.txtTotal);
            this.grpTotal.Controls.Add(this.lblTotal);
            this.grpTotal.Controls.Add(this.dtpOrderDate);
            this.grpTotal.Controls.Add(this.lblOrderDate);
            this.grpTotal.Location = new System.Drawing.Point(12, 381);
            this.grpTotal.Name = "grpTotal";
            this.grpTotal.Size = new System.Drawing.Size(776, 57);
            this.grpTotal.TabIndex = 3;
            this.grpTotal.TabStop = false;
            this.grpTotal.Text = "Order Total";
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Location = new System.Drawing.Point(623, 19);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(131, 23);
            this.btnPlaceOrder.TabIndex = 4;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(446, 22);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(150, 20);
            this.txtTotal.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(382, 25);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(58, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total (RS):";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(88, 19);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 20);
            this.dtpOrderDate.TabIndex = 1;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(18, 25);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(62, 13);
            this.lblOrderDate.TabIndex = 0;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // PlaceOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpTotal);
            this.Controls.Add(this.grpOrderItems);
            this.Controls.Add(this.grpProduct);
            this.Controls.Add(this.grpClient);
            this.Name = "PlaceOrderForm";
            this.Text = "Place Order";
            this.Load += new System.EventHandler(this.PlaceOrderForm_Load);
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            this.grpProduct.ResumeLayout(false);
            this.grpProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.grpOrderItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.grpTotal.ResumeLayout(false);
            this.grpTotal.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.GroupBox grpProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpOrderItems;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.GroupBox grpTotal;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnPlaceOrder;

        private void PlaceOrderForm_Load(object sender, EventArgs e)
        {
            // Set date picker to current date
            dtpOrderDate.Value = DateTime.Now;
            
            // Load clients
            LoadClients();
            
            // Load products
            LoadProducts();
            
            // Setup OrderItems DataGridView
            SetupOrderItemsGrid();
            
            // Update total
            UpdateTotal();
        }

        private void LoadClients()
        {
            try
            {
                clients = ClientDAL.GetAllClients();
                cboClient.DataSource = null;
                cboClient.DisplayMember = "Name";
                cboClient.ValueMember = "ID";
                cboClient.DataSource = clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading clients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                products = ProductDAL.GetAllProducts();
                cboProduct.DataSource = null;
                cboProduct.DisplayMember = "Name";
                cboProduct.ValueMember = "ID";
                cboProduct.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupOrderItemsGrid()
        {
            dgvOrderItems.DataSource = orderItems;
            
            // Configure columns
            if (dgvOrderItems.Columns.Count > 0)
            {
                dgvOrderItems.Columns["ProductID"].Visible = false;
                dgvOrderItems.Columns["ProductName"].HeaderText = "Product";
                dgvOrderItems.Columns["ProductName"].Width = 200;
                dgvOrderItems.Columns["Price"].HeaderText = "Unit Price";
                dgvOrderItems.Columns["Price"].Width = 100;
                dgvOrderItems.Columns["Price"].DefaultCellStyle.Format = "N2";
                dgvOrderItems.Columns["Quantity"].Width = 80;
                dgvOrderItems.Columns["Subtotal"].Width = 120;
                dgvOrderItems.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex != -1)
            {
                Product selectedProduct = (Product)cboProduct.SelectedItem;
                txtStock.Text = selectedProduct.Quantity.ToString();
                txtPrice.Text = selectedProduct.Price.ToString("N2");
                
                // Set a reasonable default for quantity
                numQuantity.Maximum = selectedProduct.Quantity;
                numQuantity.Value = 1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            Product selectedProduct = (Product)cboProduct.SelectedItem;
            
            if (selectedProduct.Quantity < numQuantity.Value)
            {
                MessageBox.Show("Not enough stock available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Check if product already exists in order
            foreach (DataRow row in orderItems.Rows)
            {
                if ((int)row["ProductID"] == selectedProduct.ID)
                {
                    // Update quantity and subtotal
                    int newQuantity = (int)row["Quantity"] + (int)numQuantity.Value;
                    
                    if (newQuantity > selectedProduct.Quantity)
                    {
                        MessageBox.Show("Not enough stock available for the requested quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    row["Quantity"] = newQuantity;
                    row["Subtotal"] = newQuantity * selectedProduct.Price;
                    
                    // Update total amount
                    UpdateTotal();
                    return;
                }
            }
            
            // Add new row
            DataRow newRow = orderItems.NewRow();
            newRow["ProductID"] = selectedProduct.ID;
            newRow["ProductName"] = selectedProduct.Name;
            newRow["Price"] = selectedProduct.Price;
            newRow["Quantity"] = (int)numQuantity.Value;
            newRow["Subtotal"] = selectedProduct.Price * (int)numQuantity.Value;
            orderItems.Rows.Add(newRow);
            
            // Update total amount
            UpdateTotal();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            DataRow row = ((DataRowView)dgvOrderItems.SelectedRows[0].DataBoundItem).Row;
            orderItems.Rows.Remove(row);
            
            // Update total amount
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            totalAmount = 0;
            
            foreach (DataRow row in orderItems.Rows)
            {
                totalAmount += (decimal)row["Subtotal"];
            }
            
            txtTotal.Text = totalAmount.ToString("N2");
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (cboClient.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a client.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (orderItems.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one product to the order.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                Client selectedClient = (Client)cboClient.SelectedItem;
                
                // Create order
                Order order = new Order
                {
                    ClientID = selectedClient.ID,
                    EmployeeID = currentUser.EmployeeID.Value,
                    OrderDate = dtpOrderDate.Value,
                    TotalPrice = totalAmount
                };
                
                // Create order in database
                int orderID = OrderDAL.CreateOrder(order);
                
                // Add order items
                bool allItemsAdded = true;
                foreach (DataRow row in orderItems.Rows)
                {
                    OrderItem orderItem = new OrderItem
                    {
                        OrderID = orderID,
                        ProductID = (int)row["ProductID"],
                        Quantity = (int)row["Quantity"]
                    };
                    
                    if (!OrderDAL.AddOrderItem(orderItem))
                    {
                        allItemsAdded = false;
                        break;
                    }
                }
                
                if (allItemsAdded)
                {
                    MessageBox.Show("Order placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Clear order items
                    orderItems.Rows.Clear();
                    UpdateTotal();
                    
                    // Reload products to get updated stock
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("There was an error placing the order. Some items may not have been added.", 
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error placing order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 