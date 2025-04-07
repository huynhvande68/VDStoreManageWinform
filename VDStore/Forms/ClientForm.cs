using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VDStore.DAL;
using VDStore.Models;
using System.IO;
using System.Text;

namespace VDStore.Forms
{
    public partial class ClientForm : Form
    {
        private List<Client> clients;
        private Client currentClient;
        private User currentUser;

        public ClientForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            
            // Set the position of Export CSV button
            this.btnExportCsv.Location = new System.Drawing.Point(804, 39);
        }
        
        // Add a parameterless constructor to maintain backward compatibility
        public ClientForm() : this(null)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeComponent()
        {
            this.grpClientInfo = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.grpClientList = new System.Windows.Forms.GroupBox();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.grpClientInfo.SuspendLayout();
            this.grpClientList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpClientInfo
            // 
            this.grpClientInfo.Controls.Add(this.txtAddress);
            this.grpClientInfo.Controls.Add(this.lblAddress);
            this.grpClientInfo.Controls.Add(this.txtPhone);
            this.grpClientInfo.Controls.Add(this.lblPhone);
            this.grpClientInfo.Controls.Add(this.txtEmail);
            this.grpClientInfo.Controls.Add(this.lblEmail);
            this.grpClientInfo.Controls.Add(this.txtName);
            this.grpClientInfo.Controls.Add(this.lblName);
            this.grpClientInfo.Controls.Add(this.txtID);
            this.grpClientInfo.Controls.Add(this.lblID);
            this.grpClientInfo.Location = new System.Drawing.Point(12, 12);
            this.grpClientInfo.Name = "grpClientInfo";
            this.grpClientInfo.Size = new System.Drawing.Size(376, 220);
            this.grpClientInfo.TabIndex = 0;
            this.grpClientInfo.TabStop = false;
            this.grpClientInfo.Text = "Client Information";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(119, 170);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 20);
            this.txtAddress.TabIndex = 9;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(18, 173);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Address:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(119, 135);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 20);
            this.txtPhone.TabIndex = 7;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(18, 138);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(119, 101);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(18, 104);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(119, 65);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
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
            // grpClientList
            // 
            this.grpClientList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpClientList.Controls.Add(this.dgvClients);
            this.grpClientList.Location = new System.Drawing.Point(394, 80);
            this.grpClientList.Name = "grpClientList";
            this.grpClientList.Size = new System.Drawing.Size(591, 358);
            this.grpClientList.TabIndex = 1;
            this.grpClientList.TabStop = false;
            this.grpClientList.Text = "Client List";
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClients.Location = new System.Drawing.Point(3, 16);
            this.dgvClients.MultiSelect = false;
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(585, 339);
            this.dgvClients.TabIndex = 0;
            this.dgvClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellClick);
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
            this.btnNew.Location = new System.Drawing.Point(15, 253);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(104, 253);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(196, 253);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(286, 253);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Location = new System.Drawing.Point(813, 41);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(120, 23);
            this.btnExportCsv.TabIndex = 2;
            this.btnExportCsv.Text = "Export to CSV";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.BtnExportCsv_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpClientList);
            this.Controls.Add(this.grpClientInfo);
            this.Controls.Add(this.btnExportCsv);
            this.Name = "ClientForm";
            this.Text = "Manage Clients";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.grpClientInfo.ResumeLayout(false);
            this.grpClientInfo.PerformLayout();
            this.grpClientList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox grpClientInfo;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.GroupBox grpClientList;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExportCsv;

        private void ClientForm_Load(object sender, EventArgs e)
        {
            // Set permissions based on user role
            SetFormPermissions();
            
            // Load clients
            LoadClients();
        }
        
        private void SetFormPermissions()
        {
            // Both employees and admins can manage clients
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            
            txtName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtAddress.ReadOnly = false;
        }

        private void LoadClients()
        {
            clients = ClientDAL.GetAllClients();
            dgvClients.DataSource = clients;
            
            // Configure the data grid view
            dgvClients.Columns["ID"].Width = 50;
            dgvClients.Columns["Name"].Width = 120;
            dgvClients.Columns["Email"].Width = 120;
            dgvClients.Columns["Phone"].Width = 100;
            dgvClients.Columns["Address"].Width = 150;
        }

        private void ClearFields()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            
            currentClient = null;
            btnDelete.Enabled = false;
        }

        private void DisplayClient(Client client)
        {
            currentClient = client;
            
            txtID.Text = client.ID.ToString();
            txtName.Text = client.Name;
            txtEmail.Text = client.Email;
            txtPhone.Text = client.Phone;
            txtAddress.Text = client.Address;
            
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
            
            return true;
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int clientID = Convert.ToInt32(dgvClients.Rows[e.RowIndex].Cells["ID"].Value);
                Client selectedClient = clients.Find(client => client.ID == clientID);
                
                if (selectedClient != null)
                    DisplayClient(selectedClient);
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
                if (currentClient == null)
                {
                    // Add new client
                    Client newClient = new Client
                    {
                        Name = txtName.Text,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        Address = txtAddress.Text
                    };
                    
                    int newID = ClientDAL.AddClient(newClient);
                    MessageBox.Show("Client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Update existing client
                    currentClient.Name = txtName.Text;
                    currentClient.Email = txtEmail.Text;
                    currentClient.Phone = txtPhone.Text;
                    currentClient.Address = txtAddress.Text;
                    
                    bool updated = ClientDAL.UpdateClient(currentClient);
                    if (updated)
                        MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Failed to update client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                // Refresh the client list
                LoadClients();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentClient == null)
            {
                MessageBox.Show("Please select a client to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (MessageBox.Show($"Are you sure you want to delete {currentClient.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool deleted = ClientDAL.DeleteClient(currentClient.ID);
                    if (deleted)
                    {
                        MessageBox.Show("Client deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadClients();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LoadClients();
                return;
            }
            
            try
            {
                clients = ClientDAL.SearchClients(txtSearch.Text);
                dgvClients.DataSource = clients;
                
                if (clients.Count == 0)
                    MessageBox.Show("No clients found matching your search criteria.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportCsv_Click(object sender, EventArgs e)
        {
            if (dgvClients.Rows.Count == 0)
            {
                MessageBox.Show("No data to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Save Client List",
                FileName = "Clients_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a StringBuilder to store CSV data
                    StringBuilder csv = new StringBuilder();
                    
                    // Add headers
                    List<string> headers = new List<string>();
                    foreach (DataGridViewColumn column in dgvClients.Columns)
                    {
                        if (column.Visible)
                        {
                            headers.Add($"\"{column.HeaderText}\"");
                        }
                    }
                    csv.AppendLine(string.Join(",", headers));
                    
                    // Add rows
                    foreach (DataGridViewRow row in dgvClients.Rows)
                    {
                        List<string> fields = new List<string>();
                        foreach (DataGridViewColumn column in dgvClients.Columns)
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