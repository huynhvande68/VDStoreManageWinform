using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using VDStore.DAL;
using VDStore.Models;

namespace VDStore.Forms
{
    public partial class HomeForm : Form
    {
        private List<Product> products;
        private List<Product> filteredProducts;
        private readonly List<OrderItem> cartItems = new List<OrderItem>();
        private readonly User currentUser;
        private int selectedClientId = 0;

        public HomeForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            products = new List<Product>();
            
            // Set form to display at center of screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.pnlProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCart = new System.Windows.Forms.Panel();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblCart = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblSearch);
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Controls.Add(this.btnSearch);
            this.pnlHeader.Controls.Add(this.cboClient);
            this.pnlHeader.Controls.Add(this.lblClient);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(928, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(12, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(193, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to VDSTORE";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(13, 49);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(49, 15);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(63, 46);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(221, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(290, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(443, 46);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(221, 23);
            this.cboClient.TabIndex = 5;
            this.cboClient.SelectedIndexChanged += new System.EventHandler(this.CboClient_SelectedIndexChanged);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.Location = new System.Drawing.Point(401, 49);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(41, 15);
            this.lblClient.TabIndex = 4;
            this.lblClient.Text = "Client:";
            // 
            // pnlProducts
            // 
            this.pnlProducts.AutoScroll = true;
            this.pnlProducts.Location = new System.Drawing.Point(0, 80);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(437, 461);
            this.pnlProducts.TabIndex = 1;
            // 
            // pnlCart
            // 
            this.pnlCart.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCart.Controls.Add(this.dgvCart);
            this.pnlCart.Controls.Add(this.lblCart);
            this.pnlCart.Controls.Add(this.lblTotal);
            this.pnlCart.Controls.Add(this.btnClearCart);
            this.pnlCart.Controls.Add(this.btnPlaceOrder);
            this.pnlCart.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCart.Location = new System.Drawing.Point(443, 80);
            this.pnlCart.Name = "pnlCart";
            this.pnlCart.Size = new System.Drawing.Size(485, 461);
            this.pnlCart.TabIndex = 2;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(10, 44);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(463, 353);
            this.dgvCart.TabIndex = 1;
            this.dgvCart.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCart_CellEndEdit);
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCart.Location = new System.Drawing.Point(6, 14);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(106, 20);
            this.lblCart.TabIndex = 0;
            this.lblCart.Text = "Your Cart: 0";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(6, 409);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(104, 20);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total: $0.00";
            // 
            // btnClearCart
            // 
            this.btnClearCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCart.BackColor = System.Drawing.Color.Tomato;
            this.btnClearCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCart.ForeColor = System.Drawing.Color.Black;
            this.btnClearCart.Location = new System.Drawing.Point(288, 409);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(83, 31);
            this.btnClearCart.TabIndex = 3;
            this.btnClearCart.Text = "Clear Cart";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.BtnClearCart_Click);
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlaceOrder.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPlaceOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaceOrder.ForeColor = System.Drawing.Color.Black;
            this.btnPlaceOrder.Location = new System.Drawing.Point(377, 409);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(96, 31);
            this.btnPlaceOrder.TabIndex = 4;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            this.btnPlaceOrder.Click += new System.EventHandler(this.BtnPlaceOrder_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 541);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.pnlCart);
            this.Controls.Add(this.pnlHeader);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pi Store - Home";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCart.ResumeLayout(false);
            this.pnlCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.FlowLayoutPanel pnlProducts;
        private System.Windows.Forms.Panel pnlCart;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnPlaceOrder;

        private void HomeForm_Load(object sender, EventArgs e)
        {
            // Set welcome message
            if (currentUser != null)
            {
                lblWelcome.Text = $"Welcome, {currentUser.Username}!";
            }
            
            // Load products
            LoadProducts();
            
            // Load clients
            LoadClients();
            
            // Setup cart
            SetupCart();
        }

        private void LoadProducts()
        {
            try
            {
                // Get all products
                products = ProductDAL.GetAllProducts();
                
                // Filter and display products
                FilterAndDisplayProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClients()
        {
            try
            {
                // Get all clients
                List<Client> clients = ClientDAL.GetAllClients();
                
                cboClient.DisplayMember = "Name";
                cboClient.ValueMember = "ID";
                cboClient.DataSource = clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading clients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterAndDisplayProducts()
        {
            // Clear panel
            pnlProducts.Controls.Clear();
            
            // Filter products
            string searchTerm = txtSearch.Text.Trim().ToLower();
            
            if (string.IsNullOrEmpty(searchTerm))
            {
                filteredProducts = new List<Product>(products);
            }
            else
            {
                filteredProducts = products.Where(p => 
                    p.Name.ToLower().Contains(searchTerm) || 
                    (p.Description != null && p.Description.ToLower().Contains(searchTerm))
                ).ToList();
            }
            
            // Display products
            foreach (Product product in filteredProducts)
            {
                // Create product panel
                Panel productPanel = new Panel
                {
                    Width = 168,
                    Height = 280,  // Increased height to accommodate image
                    Margin = new Padding(8),
                    BorderStyle = BorderStyle.FixedSingle
                };
                
                // Product image
                PictureBox picProduct = new PictureBox
                {
                    Width = 100,
                    Height = 80,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(34, 5),
                    BorderStyle = BorderStyle.None  // Changed from FixedSingle to None to remove border
                };
                
                // Load image if available
                if (!string.IsNullOrEmpty(product.ImagePath))
                {
                    try
                    {
                        string fullPath = System.IO.Path.Combine(Application.StartupPath, product.ImagePath);
                        if (System.IO.File.Exists(fullPath))
                        {
                            picProduct.Image = Image.FromFile(fullPath);
                        }
                    }
                    catch (Exception)
                    {
                        // If image can't be loaded, just don't show it
                    }
                }
                
                // Product name - adjust position
                Label lblName = new Label
                {
                    Text = product.Name,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                    Location = new Point(5, 90),  // Moved down to make room for image
                    Width = 158,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                
                // Product description - adjust position
                Label lblDescription = new Label
                {
                    Text = product.Description ?? "",
                    Location = new Point(5, 135),  // Moved down
                    Width = 158,
                    Height = 60,
                    TextAlign = ContentAlignment.TopLeft
                };
                
                // Product price - adjust position
                Label lblPrice = new Label
                {
                    Text = $"Price: ${product.Price:N2}",
                    Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                    Location = new Point(5, 200),  // Moved down
                    Width = 158,
                    Height = 20,
                    TextAlign = ContentAlignment.MiddleLeft
                };
                
                // Product quantity - adjust position
                Label lblQuantity = new Label
                {
                    Text = $"In Stock: {product.Quantity}",
                    Location = new Point(5, 225),  // Moved down
                    Width = 158,
                    Height = 20,
                    TextAlign = ContentAlignment.MiddleLeft
                };
                
                // Button to add to cart - adjust position
                Button btnAddToCart = new Button
                {
                    Text = "Add to Cart",
                    Location = new Point(34, 245),  // Moved down
                    Width = 100,
                    Height = 30,
                    Tag = product,
                    BackColor = Color.LightGreen,
                };
                
                btnAddToCart.Click += BtnAddToCart_Click;
                
                // Add controls to product panel
                productPanel.Controls.Add(picProduct);  // Add the image
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(lblDescription);
                productPanel.Controls.Add(lblPrice);
                productPanel.Controls.Add(lblQuantity);
                productPanel.Controls.Add(btnAddToCart);
                
                // Add product panel to flow layout panel
                pnlProducts.Controls.Add(productPanel);
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Product product = (Product)btn.Tag;
            
            // Check if product is already in cart
            OrderItem existingItem = cartItems.FirstOrDefault(item => item.ProductID == product.ID);
            
            if (existingItem != null)
            {
                // Increment quantity if already in cart
                if (existingItem.Quantity < product.Quantity)
                {
                    existingItem.Quantity++;
                    RefreshCart();
                }
                else
                {
                    MessageBox.Show("Cannot add more units of this product. Maximum stock reached.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Check if product is in stock
                if (product.Quantity > 0)
                {
                    // Add new item to cart
                    OrderItem newItem = new OrderItem
                    {
                        ProductID = product.ID,
                        Product = product,
                        Quantity = 1,
                        UnitPrice = product.Price
                    };
                    
                    cartItems.Add(newItem);
                    RefreshCart();
                }
                else
                {
                    MessageBox.Show("Sorry, this product is out of stock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void SetupCart()
        {
            // Create columns
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
            {
                Name = "ProductID",
                HeaderText = "ID",
                Width = 40,
                ReadOnly = true
            };
            
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Product",
                Width = 120,
                ReadOnly = true
            };
            
            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                HeaderText = "Price",
                Width = 70,
                ReadOnly = true,
                DefaultCellStyle = { Format = "C2" }
            };
            
            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Quantity",
                Width = 60
            };
            
            DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                Width = 70,
                ReadOnly = true,
                DefaultCellStyle = { Format = "C2" }
            };
            
            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Remove",
                Text = "X",
                UseColumnTextForButtonValue = true,
                Width = 60,
                
            };
            
            // Add columns to grid
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add(idColumn);
            dgvCart.Columns.Add(nameColumn);
            dgvCart.Columns.Add(priceColumn);
            dgvCart.Columns.Add(quantityColumn);
            dgvCart.Columns.Add(subtotalColumn);
            dgvCart.Columns.Add(removeColumn);
            
            // Handle cell click for remove button
            dgvCart.CellClick += DgvCart_CellClick;
            

            // Refresh cart
            RefreshCart();
        }

        private void RefreshCart()
        {
            // Clear rows
            dgvCart.Rows.Clear();
            
            // Add items to grid
            foreach (OrderItem item in cartItems)
            {
                int rowIndex = dgvCart.Rows.Add();
                DataGridViewRow row = dgvCart.Rows[rowIndex];
                
                row.Cells["ProductID"].Value = item.ProductID;
                row.Cells["ProductName"].Value = item.Product.Name;
                row.Cells["UnitPrice"].Value = item.UnitPrice;
                row.Cells["Quantity"].Value = item.Quantity;
                row.Cells["Subtotal"].Value = item.Quantity * item.UnitPrice;
            }
            
            // Update cart label and total
            lblCart.Text = $"Your Cart: {cartItems.Count} items";
            
            decimal total = cartItems.Sum(item => item.Quantity * item.UnitPrice);
            lblTotal.Text = $"Total: ${total:N2}";
            
            // Enable/disable place order button
            btnPlaceOrder.Enabled = cartItems.Count > 0 && cboClient.SelectedValue != null;
        }

        private void DgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if remove button is clicked
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCart.Columns.Count - 1)
            {
                int productId = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["ProductID"].Value);
                
                // Remove item from cart
                OrderItem itemToRemove = cartItems.FirstOrDefault(item => item.ProductID == productId);
                if (itemToRemove != null)
                {
                    cartItems.Remove(itemToRemove);
                    RefreshCart();
                }
            }
        }

        private void DgvCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if quantity column is edited
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCart.Columns["Quantity"].Index)
            {
                int productId = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["ProductID"].Value);
                
                // Get the item
                OrderItem item = cartItems.FirstOrDefault(i => i.ProductID == productId);
                if (item != null)
                {
                    // Get the new quantity
                    int newQuantity;
                    if (int.TryParse(dgvCart.Rows[e.RowIndex].Cells["Quantity"].Value?.ToString(), out newQuantity))
                    {
                        // Check if quantity is valid
                        if (newQuantity <= 0)
                        {
                            // Remove item if quantity is 0 or negative
                            cartItems.Remove(item);
                        }
                        else if (newQuantity > item.Product.Quantity)
                        {
                            // Set to max available quantity
                            MessageBox.Show($"Maximum available quantity for this product is {item.Product.Quantity}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            item.Quantity = item.Product.Quantity;
                        }
                        else
                        {
                            // Update quantity
                            item.Quantity = newQuantity;
                        }
                        
                        RefreshCart();
                    }
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            FilterAndDisplayProducts();
        }

        private void BtnClearCart_Click(object sender, EventArgs e)
        {
            cartItems.Clear();
            RefreshCart();
        }

        private void CboClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClient.SelectedItem != null)
            {
                Client selectedClient = (Client)cboClient.SelectedItem;
                selectedClientId = selectedClient.ID;
            }
        }

        private void BtnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (selectedClientId == 0)
            {
                MessageBox.Show("Please select a client first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Create order
                int orderId = OrderDAL.PlaceOrder(selectedClientId, currentUser.EmployeeID.Value, DateTime.Now);
                
                // Add order items
                foreach (OrderItem item in cartItems)
                {
                    OrderDAL.AddOrderItem(orderId, item.ProductID, item.Quantity);
                }
                
                // Clear the cart
                cartItems.Clear();
                dgvCart.Rows.Clear();
                lblCart.Text = "Your Cart: 0";
                lblTotal.Text = "Total: $0.00";
                
                MessageBox.Show("Order placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error placing order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Export Cart to CSV
        private void BtnExportCartCsv_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("No items in cart to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Save Cart Items",
                FileName = "CartItems_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a StringBuilder to store CSV data
                    StringBuilder csv = new StringBuilder();
                    
                    // Add headers
                    csv.AppendLine("\"Product ID\",\"Product\",\"Unit Price\",\"Quantity\",\"Subtotal\"");
                    
                    // Add rows
                    foreach (OrderItem item in cartItems)
                    {
                        decimal subtotal = item.Quantity * item.UnitPrice;
                        csv.AppendLine($"\"{item.ProductID}\",\"{item.Product.Name.Replace("\"", "\"\"")}\",\"{item.UnitPrice:N2}\",\"{item.Quantity}\",\"{subtotal:N2}\"");
                    }
                    
                    // Add total line
                    decimal total = cartItems.Sum(item => item.Quantity * item.UnitPrice);
                    csv.AppendLine($"\"\",\"\",\"\",\"Total:\",\"{total:N2}\"");
                    
                    // Write to file
                    File.WriteAllText(saveFileDialog.FileName, csv.ToString(), Encoding.UTF8);
                    
                    MessageBox.Show($"Cart items successfully exported to {saveFileDialog.FileName}", "Success", 
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

        private void pnlCart_Paint(object sender, PaintEventArgs e)
        {

        }
    }
} 