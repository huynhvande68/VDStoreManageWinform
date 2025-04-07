using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VDStore.DAL;
using VDStore.Models;
using System.Text;

namespace VDStore.Forms
{
    public partial class ProductForm : Form
    {
        private List<Product> products;
        private Product currentProduct;
        private string selectedImagePath;

        public ProductForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Set the position of Export CSV button
            this.btnExportCsv.Location = new System.Drawing.Point(804, 39);
        }

        private void InitializeComponent()
        {
            this.grpProductInfo = new System.Windows.Forms.GroupBox();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtPrice = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.grpProductList = new System.Windows.Forms.GroupBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpProductImage = new System.Windows.Forms.GroupBox();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.picProductImage = new System.Windows.Forms.PictureBox();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.grpProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).BeginInit();
            this.grpProductList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpProductImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // grpProductInfo
            // 
            this.grpProductInfo.Controls.Add(this.txtQuantity);
            this.grpProductInfo.Controls.Add(this.txtPrice);
            this.grpProductInfo.Controls.Add(this.lblQuantity);
            this.grpProductInfo.Controls.Add(this.lblPrice);
            this.grpProductInfo.Controls.Add(this.txtDescription);
            this.grpProductInfo.Controls.Add(this.lblDescription);
            this.grpProductInfo.Controls.Add(this.txtName);
            this.grpProductInfo.Controls.Add(this.lblName);
            this.grpProductInfo.Controls.Add(this.txtID);
            this.grpProductInfo.Controls.Add(this.lblID);
            this.grpProductInfo.Location = new System.Drawing.Point(12, 12);
            this.grpProductInfo.Name = "grpProductInfo";
            this.grpProductInfo.Size = new System.Drawing.Size(376, 248);
            this.grpProductInfo.TabIndex = 0;
            this.grpProductInfo.TabStop = false;
            this.grpProductInfo.Text = "Product Information";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(119, 204);
            this.txtQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(120, 20);
            this.txtQuantity.TabIndex = 11;
            // 
            // txtPrice
            // 
            this.txtPrice.DecimalPlaces = 2;
            this.txtPrice.Location = new System.Drawing.Point(119, 169);
            this.txtPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(120, 20);
            this.txtPrice.TabIndex = 10;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(18, 206);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "Quantity:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(18, 171);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Price:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(119, 101);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(237, 53);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(18, 104);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(119, 65);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(18, 68);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(119, 31);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(18, 34);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // grpProductList
            // 
            this.grpProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProductList.Controls.Add(this.dgvProducts);
            this.grpProductList.Location = new System.Drawing.Point(394, 80);
            this.grpProductList.Name = "grpProductList";
            this.grpProductList.Size = new System.Drawing.Size(577, 468);
            this.grpProductList.TabIndex = 1;
            this.grpProductList.TabStop = false;
            this.grpProductList.Text = "Product List";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(3, 16);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(571, 449);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.lblSearch);
            this.grpSearch.Location = new System.Drawing.Point(394, 12);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(394, 62);
            this.grpSearch.TabIndex = 2;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(313, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(84, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(223, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 32);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(71, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search Term:";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(15, 281);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(104, 281);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(196, 281);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(286, 281);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpProductImage
            // 
            this.grpProductImage.Controls.Add(this.lblImagePath);
            this.grpProductImage.Controls.Add(this.btnBrowseImage);
            this.grpProductImage.Controls.Add(this.picProductImage);
            this.grpProductImage.Location = new System.Drawing.Point(12, 315);
            this.grpProductImage.Name = "grpProductImage";
            this.grpProductImage.Size = new System.Drawing.Size(376, 230);
            this.grpProductImage.TabIndex = 7;
            this.grpProductImage.TabStop = false;
            this.grpProductImage.Text = "Product Image";
            // 
            // lblImagePath
            // 
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(119, 201);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(95, 13);
            this.lblImagePath.TabIndex = 2;
            this.lblImagePath.Text = "No image selected";
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(119, 175);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(200, 23);
            this.btnBrowseImage.TabIndex = 1;
            this.btnBrowseImage.Text = "Browse Image...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // picProductImage
            // 
            this.picProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProductImage.Location = new System.Drawing.Point(119, 19);
            this.picProductImage.Name = "picProductImage";
            this.picProductImage.Size = new System.Drawing.Size(200, 150);
            this.picProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProductImage.TabIndex = 0;
            this.picProductImage.TabStop = false;
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Location = new System.Drawing.Point(804, 39);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(120, 23);
            this.btnExportCsv.TabIndex = 2;
            this.btnExportCsv.Text = "Export to CSV";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.BtnExportCsv_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 560);
            this.Controls.Add(this.btnExportCsv);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpProductList);
            this.Controls.Add(this.grpProductInfo);
            this.Controls.Add(this.grpProductImage);
            this.Name = "ProductForm";
            this.Text = "Manage Products";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.grpProductInfo.ResumeLayout(false);
            this.grpProductInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).EndInit();
            this.grpProductList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpProductImage.ResumeLayout(false);
            this.grpProductImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox grpProductInfo;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown txtPrice;
        private System.Windows.Forms.NumericUpDown txtQuantity;
        private System.Windows.Forms.GroupBox grpProductList;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpProductImage;
        private System.Windows.Forms.PictureBox picProductImage;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.Button btnExportCsv;

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            ClearFields();
        }

        private void LoadProducts()
        {
            products = ProductDAL.GetAllProducts();
            dgvProducts.DataSource = products;
            
            // Configure the data grid view
            dgvProducts.Columns["ID"].Width = 50;
            dgvProducts.Columns["Name"].Width = 120;
            dgvProducts.Columns["Description"].Width = 200;
            dgvProducts.Columns["Price"].Width = 80;
            dgvProducts.Columns["Quantity"].Width = 80;
            
            // Hide the ImagePath column from the grid view as it's not useful to display
            if (dgvProducts.Columns.Contains("ImagePath"))
            {
                dgvProducts.Columns["ImagePath"].Visible = false;
            }
        }

        private void ClearFields()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Value = 0;
            txtQuantity.Value = 0;
            
            currentProduct = null;
            btnDelete.Enabled = false;
            
            // Clear image
            picProductImage.Image = null;
            lblImagePath.Text = "No image selected";
            selectedImagePath = null;
        }

        private void DisplayProduct(Product product)
        {
            currentProduct = product;
            
            txtID.Text = product.ID.ToString();
            txtName.Text = product.Name;
            txtDescription.Text = product.Description;
            txtPrice.Value = product.Price;
            txtQuantity.Value = product.Quantity;
            
            // Load product image if available
            LoadImageFromPath(product.ImagePath);
            selectedImagePath = product.ImagePath;
            
            btnDelete.Enabled = true;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            
            if (txtPrice.Value <= 0)
            {
                MessageBox.Show("Price must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return false;
            }
            
            if (txtQuantity.Value < 0)
            {
                MessageBox.Show("Quantity cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return false;
            }
            
            return true;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int productID = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ID"].Value);
                
                // Use GetProductByID to ensure we get all fields including ImagePath
                Product selectedProduct = ProductDAL.GetProductByID(productID);
                
                if (selectedProduct != null)
                    DisplayProduct(selectedProduct);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;
                
            try
            {
                if (currentProduct == null)
                {
                    // Add new product
                    Product newProduct = new Product
                    {
                        Name = txtName.Text,
                        Description = txtDescription.Text,
                        Price = txtPrice.Value,
                        Quantity = (int)txtQuantity.Value,
                        ImagePath = selectedImagePath
                    };
                    
                    int newID = ProductDAL.AddProduct(newProduct);
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Update existing product
                    currentProduct.Name = txtName.Text;
                    currentProduct.Description = txtDescription.Text;
                    currentProduct.Price = txtPrice.Value;
                    currentProduct.Quantity = (int)txtQuantity.Value;
                    currentProduct.ImagePath = selectedImagePath;
                    
                    bool updated = ProductDAL.UpdateProduct(currentProduct);
                    if (updated)
                        MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Failed to update product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                // Refresh the product list
                LoadProducts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentProduct == null)
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (MessageBox.Show($"Are you sure you want to delete {currentProduct.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ProductDAL.DeleteProduct(currentProduct.ID);
                    if (deleted)
                    {
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadProducts();
                return;
            }
            
            try
            {
                products = ProductDAL.SearchProducts(txtSearch.Text);
                dgvProducts.DataSource = products;
                
                if (products.Count == 0)
                    MessageBox.Show("No products found matching your search criteria.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Product Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Get the selected file path
                        string sourcePath = openFileDialog.FileName;
                        
                        // Create a directory for product images if it doesn't exist
                        string targetDir = Path.Combine(Application.StartupPath, "ProductImages");
                        if (!Directory.Exists(targetDir))
                            Directory.CreateDirectory(targetDir);
                        
                        // Generate a unique filename for the image
                        string fileName = "product_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(sourcePath);
                        string targetPath = Path.Combine(targetDir, fileName);
                        
                        // Copy the file to the target directory
                        File.Copy(sourcePath, targetPath, true);
                        
                        // Save the relative path to use in the database
                        selectedImagePath = "ProductImages\\" + fileName;
                        
                        // Display the image and update the label
                        picProductImage.Image = Image.FromFile(targetPath);
                        lblImagePath.Text = Path.GetFileName(targetPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadImageFromPath(string imagePath)
        {
            try
            {
                if (string.IsNullOrEmpty(imagePath))
                {
                    picProductImage.Image = null;
                    lblImagePath.Text = "No image selected";
                    return;
                }
                
                string fullPath = Path.Combine(Application.StartupPath, imagePath);
                if (File.Exists(fullPath))
                {
                    picProductImage.Image = Image.FromFile(fullPath);
                    lblImagePath.Text = Path.GetFileName(imagePath);
                }
                else
                {
                    picProductImage.Image = null;
                    lblImagePath.Text = "Image not found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                picProductImage.Image = null;
                lblImagePath.Text = "Error loading image";
            }
        }

        private void BtnExportCsv_Click(object sender, EventArgs e)
        {
            if (dgvProducts.Rows.Count == 0)
            {
                MessageBox.Show("No data to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Save Product List",
                FileName = "Products_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a StringBuilder to store CSV data
                    StringBuilder csv = new StringBuilder();
                    
                    // Add headers
                    List<string> headers = new List<string>();
                    foreach (DataGridViewColumn column in dgvProducts.Columns)
                    {
                        if (column.Visible)
                        {
                            headers.Add($"\"{column.HeaderText}\"");
                        }
                    }
                    csv.AppendLine(string.Join(",", headers));
                    
                    // Add rows
                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        List<string> fields = new List<string>();
                        foreach (DataGridViewColumn column in dgvProducts.Columns)
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
                    
                    MessageBox.Show($"Data successfully exported to {saveFileDialog.FileName}", "Success", 
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