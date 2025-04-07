using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VDStore.DAL;
using VDStore.Models;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace VDStore.Forms
{
    public class PdfLineSeparator : Chunk
    {
        public PdfLineSeparator() : base(new iTextSharp.text.pdf.draw.LineSeparator(1, 100, BaseColor.BLACK, Element.ALIGN_CENTER, -2))
        {
        }

        public PdfLineSeparator(float lineWidth, float percentage, BaseColor color) 
            : base(new iTextSharp.text.pdf.draw.LineSeparator(lineWidth, percentage, color, Element.ALIGN_CENTER, -2))
        {
        }
    }

    public partial class BillsForm : Form
    {
        private List<Bill> bills;
        private Bill currentBill;

        public BillsForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            bills = new List<Bill>();
        }

        private void InitializeComponent()
        {
            this.grpBillList = new System.Windows.Forms.GroupBox();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.grpBillDetails = new System.Windows.Forms.GroupBox();
            this.dgvBillItems = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnMarkAsPaid = new System.Windows.Forms.Button();
            this.btnExportBillsCsv = new System.Windows.Forms.Button();
            this.btnExportItemsCsv = new System.Windows.Forms.Button();
            this.grpBillList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpBillDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillItems)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBillList
            // 
            this.grpBillList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBillList.Controls.Add(this.dgvBills);
            this.grpBillList.Location = new System.Drawing.Point(12, 94);
            this.grpBillList.Name = "grpBillList";
            this.grpBillList.Size = new System.Drawing.Size(776, 179);
            this.grpBillList.TabIndex = 0;
            this.grpBillList.TabStop = false;
            this.grpBillList.Text = "Bill List";
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Location = new System.Drawing.Point(6, 19);
            this.dgvBills.MultiSelect = false;
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBills.Size = new System.Drawing.Size(764, 154);
            this.dgvBills.TabIndex = 0;
            this.dgvBills.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBills_CellClick);
            // 
            // grpSearch
            // 
            this.grpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.dtpEndDate);
            this.grpSearch.Controls.Add(this.lblEndDate);
            this.grpSearch.Controls.Add(this.dtpStartDate);
            this.grpSearch.Controls.Add(this.lblStartDate);
            this.grpSearch.Controls.Add(this.cboClient);
            this.grpSearch.Controls.Add(this.lblClient);
            this.grpSearch.Controls.Add(this.btnExportBillsCsv);
            this.grpSearch.Location = new System.Drawing.Point(12, 12);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(900, 76);
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
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
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
            // grpBillDetails
            // 
            this.grpBillDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBillDetails.Controls.Add(this.dgvBillItems);
            this.grpBillDetails.Controls.Add(this.btnPrint);
            this.grpBillDetails.Controls.Add(this.btnMarkAsPaid);
            this.grpBillDetails.Controls.Add(this.btnExportItemsCsv);
            this.grpBillDetails.Location = new System.Drawing.Point(12, 279);
            this.grpBillDetails.Name = "grpBillDetails";
            this.grpBillDetails.Size = new System.Drawing.Size(776, 159);
            this.grpBillDetails.TabIndex = 2;
            this.grpBillDetails.TabStop = false;
            this.grpBillDetails.Text = "Bill Details";
            // 
            // dgvBillItems
            // 
            this.dgvBillItems.AllowUserToAddRows = false;
            this.dgvBillItems.AllowUserToDeleteRows = false;
            this.dgvBillItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBillItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillItems.Location = new System.Drawing.Point(6, 19);
            this.dgvBillItems.Name = "dgvBillItems";
            this.dgvBillItems.ReadOnly = true;
            this.dgvBillItems.Size = new System.Drawing.Size(659, 134);
            this.dgvBillItems.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(671, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(99, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print Bill";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnMarkAsPaid
            // 
            this.btnMarkAsPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarkAsPaid.Location = new System.Drawing.Point(671, 48);
            this.btnMarkAsPaid.Name = "btnMarkAsPaid";
            this.btnMarkAsPaid.Size = new System.Drawing.Size(99, 23);
            this.btnMarkAsPaid.TabIndex = 1;
            this.btnMarkAsPaid.Text = "Mark as Paid";
            this.btnMarkAsPaid.UseVisualStyleBackColor = true;
            this.btnMarkAsPaid.Click += new System.EventHandler(this.BtnMarkAsPaid_Click);
            // 
            // btnExportBillsCsv
            // 
            this.btnExportBillsCsv.Location = new System.Drawing.Point(btnSearch.Right + 20, btnSearch.Top);
            this.btnExportBillsCsv.Name = "btnExportBillsCsv";
            this.btnExportBillsCsv.Size = new System.Drawing.Size(120, 23);
            this.btnExportBillsCsv.TabIndex = 7;
            this.btnExportBillsCsv.Text = "Export to CSV";
            this.btnExportBillsCsv.UseVisualStyleBackColor = true;
            this.btnExportBillsCsv.BackColor = System.Drawing.Color.DarkSeaGreen;

            this.btnExportBillsCsv.Click += new System.EventHandler(this.BtnExportBillsCsv_Click);
            // 
            // btnExportItemsCsv
            // 
            this.btnExportItemsCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportItemsCsv.Location = new System.Drawing.Point(btnMarkAsPaid.Left, btnMarkAsPaid.Bottom + 10);
            this.btnExportItemsCsv.Name = "btnExportItemsCsv";
            this.btnExportItemsCsv.Size = new System.Drawing.Size(99, 23);
            this.btnExportItemsCsv.TabIndex = 3;
            this.btnExportItemsCsv.Text = "Export to CSV";
            this.btnExportItemsCsv.UseVisualStyleBackColor = true;
            this.btnExportItemsCsv.Click += new System.EventHandler(this.BtnExportItemsCsv_Click);
            // 
            // BillsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.grpBillDetails);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpBillList);
            this.Name = "BillsForm";
            this.Text = "Manage Bills";
            this.Load += new System.EventHandler(this.BillsForm_Load);
            this.grpBillList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpBillDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillItems)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpBillList;
        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grpBillDetails;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnMarkAsPaid;
        private System.Windows.Forms.DataGridView dgvBillItems;
        private System.Windows.Forms.Button btnExportBillsCsv;
        private System.Windows.Forms.Button btnExportItemsCsv;

        private void BillsForm_Load(object sender, EventArgs e)
        {
            // Load clients for dropdown
            LoadClients();
            
            // Setup date range (default to last 30 days)
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            
            // Load bills
            LoadBills();
            
            // Setup bill items grid
            SetupBillItemsGrid();
            
            // Disable buttons until a bill is selected
            btnPrint.Enabled = false;
            btnMarkAsPaid.Enabled = false;
            btnExportItemsCsv.Enabled = false;
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

        private void LoadBills()
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
                    // Load bills for specific client
                    bills = BillDAL.GetBillsByClientID(clientId);
                }
                else
                {
                    // Load all bills within date range
                    bills = BillDAL.SearchBillsByDateRange(startDate, endDate);
                }
                
                // Create a bindable list to display client and employee names
                var bindableBills = bills.Select(b => new 
                {
                    b.ID,
                    b.OrderID,
                    ClientName = b.Client?.Name ?? "Unknown",
                    EmployeeName = b.Employee?.Name ?? "Unknown",
                    b.BillDate,
                    b.TotalAmount,
                    b.IsPaid
                }).ToList();
                
                // Display the bills
                dgvBills.DataSource = bindableBills;
                
                // Configure columns
                if (dgvBills.Columns.Count > 0)
                {
                    dgvBills.Columns["ID"].Width = 50;
                    dgvBills.Columns["ID"].HeaderText = "Bill ID";
                    dgvBills.Columns["OrderID"].Width = 60;
                    dgvBills.Columns["OrderID"].HeaderText = "Order ID";
                    dgvBills.Columns["ClientName"].Width = 150;
                    dgvBills.Columns["ClientName"].HeaderText = "Client";
                    dgvBills.Columns["EmployeeName"].Width = 150;
                    dgvBills.Columns["EmployeeName"].HeaderText = "Employee";
                    dgvBills.Columns["BillDate"].Width = 120;
                    dgvBills.Columns["BillDate"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                    dgvBills.Columns["BillDate"].HeaderText = "Bill Date";
                    dgvBills.Columns["TotalAmount"].Width = 100;
                    dgvBills.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";
                    dgvBills.Columns["TotalAmount"].HeaderText = "Total Amount";
                    dgvBills.Columns["IsPaid"].Width = 60;
                    dgvBills.Columns["IsPaid"].HeaderText = "Paid";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bills: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupBillItemsGrid()
        {
            // Clear any existing data
            dgvBillItems.DataSource = null;
        }

        private void DgvBills_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int billID = Convert.ToInt32(dgvBills.Rows[e.RowIndex].Cells["ID"].Value);
                currentBill = BillDAL.GetBillByID(billID);
                
                if (currentBill != null)
                {
                    LoadBillItems(currentBill);
                    
                    // Enable or disable buttons based on bill status
                    btnPrint.Enabled = true;
                    btnMarkAsPaid.Enabled = !currentBill.IsPaid;
                    btnExportItemsCsv.Enabled = true;
                }
            }
        }

        private void LoadBillItems(Bill bill)
        {
            // Get order items associated with the bill's order
            Order order = OrderDAL.GetOrderByID(bill.OrderID);
            
            if (order != null && order.OrderItems != null)
            {
                dgvBillItems.DataSource = order.OrderItems;
                
                // Configure columns
                if (dgvBillItems.Columns.Count > 0)
                {
                    dgvBillItems.Columns["ID"].Width = 50;
                    dgvBillItems.Columns["OrderID"].Visible = false;
                    dgvBillItems.Columns["ProductID"].Visible = false;
                    dgvBillItems.Columns["Order"].Visible = false;
                    
                    if (dgvBillItems.Columns.Contains("Product"))
                    {
                        dgvBillItems.Columns["Product"].Visible = false;
                    }
                    
                    // Add custom columns
                    if (!dgvBillItems.Columns.Contains("ProductName"))
                    {
                        DataGridViewTextBoxColumn productColumn = new DataGridViewTextBoxColumn();
                        productColumn.Name = "ProductName";
                        productColumn.HeaderText = "Product";
                        productColumn.DataPropertyName = "Product.Name";
                        dgvBillItems.Columns.Add(productColumn);
                    }
                    
                    dgvBillItems.Columns["Quantity"].Width = 80;
                    dgvBillItems.Columns["UnitPrice"].Width = 100;
                    dgvBillItems.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
                    dgvBillItems.Columns["UnitPrice"].HeaderText = "Unit Price";
                    
                    // Add Subtotal column
                    if (!dgvBillItems.Columns.Contains("Subtotal"))
                    {
                        DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn();
                        subtotalColumn.Name = "Subtotal";
                        subtotalColumn.HeaderText = "Subtotal";
                        subtotalColumn.DefaultCellStyle.Format = "N2";
                        dgvBillItems.Columns.Add(subtotalColumn);
                        
                        // Calculate subtotal for each row
                        foreach (DataGridViewRow row in dgvBillItems.Rows)
                        {
                            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                            decimal unitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
                            row.Cells["Subtotal"].Value = quantity * unitPrice;
                        }
                    }
                    
                    if (dgvBillItems.Columns.Contains("ProductName"))
                    {
                        dgvBillItems.Columns["ProductName"].Width = 200;
                    }
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadBills();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (currentBill == null)
            {
                MessageBox.Show("Please select a bill first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                // Get the order associated with this bill
                Order order = OrderDAL.GetOrderByID(currentBill.OrderID);
                if (order == null || order.OrderItems == null || order.OrderItems.Count == 0)
                {
                    MessageBox.Show("No order items found for this bill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a SaveFileDialog to let the user specify where to save the PDF file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    Title = "Save Bill as PDF",
                    FileName = $"Bill_{currentBill.ID}_{DateTime.Now.ToString("yyyyMMdd")}.pdf"
                };
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Create the PDF document
                    Document document = new Document(PageSize.A4, 50, 50, 50, 50);
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    
                    // Open the document for writing
                    document.Open();
                    
                    // Add title
                    Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA, 18, 1, BaseColor.BLACK);
                    Paragraph title = new Paragraph("VD STORE BILL", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 20f;
                    document.Add(title);
                    
                    // Add bill info
                    Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, 0, BaseColor.BLACK);
                    document.Add(new Paragraph($"Bill Number: {currentBill.ID}", normalFont));
                    document.Add(new Paragraph($"Date: {currentBill.BillDate.ToString("dd/MM/yyyy HH:mm")}", normalFont));
                    document.Add(new Paragraph($"Client: {currentBill.Client?.Name ?? "Unknown"}", normalFont));
                    document.Add(new Paragraph($"Employee: {currentBill.Employee?.Name ?? "Unknown"}", normalFont));
                    
                    // Add line separator
                    document.Add(new PdfLineSeparator());
                    document.Add(Chunk.NEWLINE); // Add some space
                    
                    // Create items table
                    PdfPTable table = new PdfPTable(5) // 5 columns
                    {
                        WidthPercentage = 100 // Set table width to 100% of page
                    };
                    table.SetWidths(new float[] { 1f, 5f, 1.5f, 2f, 2.5f }); // Column widths
                    
                    // Add table headers
                    Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, 1, BaseColor.BLACK);
                    table.AddCell(new PdfPCell(new Phrase("No.", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Product", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Quantity", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Price", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    table.AddCell(new PdfPCell(new Phrase("Subtotal", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    
                    // Add table rows
                    Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, 0, BaseColor.BLACK);
                    int i = 1;
                    decimal totalAmount = 0;
                    
                    foreach (OrderItem item in order.OrderItems)
                    {
                        decimal subtotal = item.Quantity * item.UnitPrice;
                        totalAmount += subtotal;
                        
                        table.AddCell(new Phrase(i++.ToString(), cellFont));
                        table.AddCell(new Phrase(item.Product?.Name ?? "Unknown Product", cellFont));
                        table.AddCell(new Phrase(item.Quantity.ToString(), cellFont));
                        table.AddCell(new Phrase(item.UnitPrice.ToString("N2"), cellFont));
                        table.AddCell(new Phrase(subtotal.ToString("N2"), cellFont));
                    }
                    
                    // Add table to document
                    document.Add(table);
                    document.Add(Chunk.NEWLINE); // Add some space
                    
                    // Add total amount
                    Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, 1, BaseColor.BLACK);
                    Paragraph total = new Paragraph($"Total Amount: {currentBill.TotalAmount:N2}", boldFont);
                    total.Alignment = Element.ALIGN_RIGHT;
                    document.Add(total);
                    
                    // Add payment status
                    Paragraph status = new Paragraph($"Payment Status: {(currentBill.IsPaid ? "Paid" : "Unpaid")}", normalFont);
                    status.Alignment = Element.ALIGN_RIGHT;
                    document.Add(status);
                    
                    document.Add(Chunk.NEWLINE); // Add some space
                    document.Add(new PdfLineSeparator()); // Add another line separator
                    
                    // Add footer
                    Font italicFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, 2, BaseColor.BLACK);
                    Paragraph footer = new Paragraph("Thank you for shopping!", italicFont);
                    footer.Alignment = Element.ALIGN_CENTER;
                    footer.SpacingBefore = 20f;
                    document.Add(footer);
                    
                    // Close the document
                    document.Close();
                    
                    MessageBox.Show($"Bill exported successfully to {saveFileDialog.FileName}", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    // Ask if user wants to open the file
                    if (MessageBox.Show("Do you want to open this PDF now?", "Open File", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting bill: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMarkAsPaid_Click(object sender, EventArgs e)
        {
            if (currentBill == null)
            {
                MessageBox.Show("Please select a bill first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (currentBill.IsPaid)
            {
                MessageBox.Show("This bill is already marked as paid.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                // Update bill payment status
                if (BillDAL.MarkBillAsPaid(currentBill.ID))
                {
                    MessageBox.Show("Bill marked as paid successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Refresh the bills
                    LoadBills();
                    
                    // Disable the mark as paid button
                    btnMarkAsPaid.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Failed to mark bill as paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating bill: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Export Bills to CSV
        private void BtnExportBillsCsv_Click(object sender, EventArgs e)
        {
            if (dgvBills.Rows.Count == 0)
            {
                MessageBox.Show("No bills to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Save Bills List",
                FileName = "Bills_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a StringBuilder to store CSV data
                    StringBuilder csv = new StringBuilder();
                    
                    // Add headers
                    List<string> headers = new List<string>();
                    foreach (DataGridViewColumn column in dgvBills.Columns)
                    {
                        if (column.Visible)
                        {
                            headers.Add($"\"{column.HeaderText}\"");
                        }
                    }
                    csv.AppendLine(string.Join(",", headers));
                    
                    // Add rows
                    foreach (DataGridViewRow row in dgvBills.Rows)
                    {
                        List<string> fields = new List<string>();
                        foreach (DataGridViewColumn column in dgvBills.Columns)
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
                    
                    MessageBox.Show($"Bills successfully exported to {saveFileDialog.FileName}", "Success", 
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

        // Export Bill Items to CSV
        private void BtnExportItemsCsv_Click(object sender, EventArgs e)
        {
            if (dgvBillItems.Rows.Count == 0)
            {
                MessageBox.Show("No bill items to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Save Bill Items List",
                FileName = "BillItems_" + (currentBill != null ? currentBill.ID.ToString() + "_" : "") + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a StringBuilder to store CSV data
                    StringBuilder csv = new StringBuilder();
                    
                    // Add headers
                    List<string> headers = new List<string>();
                    foreach (DataGridViewColumn column in dgvBillItems.Columns)
                    {
                        if (column.Visible)
                        {
                            headers.Add($"\"{column.HeaderText}\"");
                        }
                    }
                    csv.AppendLine(string.Join(",", headers));
                    
                    // Add rows
                    foreach (DataGridViewRow row in dgvBillItems.Rows)
                    {
                        List<string> fields = new List<string>();
                        foreach (DataGridViewColumn column in dgvBillItems.Columns)
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
                    
                    MessageBox.Show($"Bill items successfully exported to {saveFileDialog.FileName}", "Success", 
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