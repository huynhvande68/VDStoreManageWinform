using System;
using System.Windows.Forms;
using VDStore.DAL;
using VDStore.Models;

namespace VDStore.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please enter username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            User user = UserDAL.ValidateUser(txtUsername.Text, txtPassword.Text);
            if (user != null)
            {
                this.Hide();
                
                switch (user.Role)
                {
                    case "Customer":
                        // Open HomeForm for customers
                        HomeForm homeForm = new HomeForm(user);
                        homeForm.Show();
                        break;
                        
                    case "Admin":
                    case "Employee":
                        // Open MainForm for admins and employees 
                        // MainForm_Load will automatically open the appropriate tab
                        MainForm mainForm = new MainForm(user);
                        mainForm.Show();
                        break;
                        
                    default:
                        MessageBox.Show("Unknown user role: " + user.Role, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        
    }
} 