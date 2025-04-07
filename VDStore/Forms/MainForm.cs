using System;
using System.Windows.Forms;
using VDStore.Models;

namespace VDStore.Forms
{
    public partial class MainForm : Form
    {
        private User currentUser;
        private bool isLoggingOut = false;

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblStatusUser.Text = $"User: {currentUser.Username} ({currentUser.Role})";
            lblStatusDateTime.Text = $"Date Time: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
            
            // Set menu permissions based on user role
            SetMenuPermissions();
            
            // Automatically select the appropriate tab based on user role
            switch (currentUser.Role)
            {
                case "Admin":
                    // Auto-open Dashboard for Admin
                    mnuDashboard.PerformClick();
                    break;
                    
                case "Employee":
                case "Customer":
                    // Auto-open Home for Employee and Customer
                    mnuHome.PerformClick();
                    break;
                    
                default:
                    // Default to Home for unknown roles
                    mnuHome.PerformClick();
                    break;
            }
        }

        private void SetMenuPermissions()
        {
            // Default: all menus are visible
            mnuHome.Visible = true;
            mnuDashboard.Visible = true;
            mnuEmployee.Visible = true;
            mnuClient.Visible = true;
            mnuProduct.Visible = true;
            mnuManageOrders.Visible = true;
            mnuViewBills.Visible = true;
            
            switch (currentUser.Role)
            {
                case "Admin":
                    // Admin has full access to all menus
                    break;
                    
                case "Employee":
                    // Employee has limited access
                    mnuDashboard.Visible = false;  // Only admin can see dashboard
                    mnuEmployee.Visible = false;  // Can't manage employees
                    
                    // Can fully manage clients, products, orders, and bills
                    break;
                    
                default:
                    // Unknown role - restrict access to most features
                    mnuDashboard.Visible = false;
                    mnuEmployee.Visible = false;
                    mnuClient.Visible = false;
                    mnuProduct.Visible = false;
                    mnuManageOrders.Visible = false;
                    mnuViewBills.Visible = false;
                    break;
            }
        }

        private void TimerDateTime_Tick(object sender, EventArgs e)
        {
            lblStatusDateTime.Text = $"Date Time: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoggingOut)
            {
                Application.Exit();
            }
        }

        private void MnuLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Set logging out flag
                isLoggingOut = true;
                
                // Close all child forms
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }

                // Show login form and keep it visible
                LoginForm loginForm = new LoginForm();
                this.Hide();
                loginForm.Show();
                this.Close();
            }
        }

        private void MnuHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HomeForm(currentUser));
        }

        private void MnuEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeForm());
        }

        private void MnuClient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClientForm());
        }

        private void MnuProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductForm());
        }

        private void MnuManageOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrdersForm());
        }

        private void MnuViewBills_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BillsForm());
        }

        private void MnuDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardForm(currentUser));
        }

        private void OpenChildForm(Form form)
        {
            // Close all existing child forms before opening a new one
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            
            // Open the new form
            form.MdiParent = this;
            form.WindowState = FormWindowState.Normal;
            
            // Center the form in the MDI parent container
            form.StartPosition = FormStartPosition.CenterParent;
            
            form.Show();
        }
    }
} 