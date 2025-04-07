using System;
using System.Windows.Forms;
using VDStore.Models;

namespace VDStore.Forms
{
    public partial class GenerateBillForm : Form
    {
        private User currentUser;

        public GenerateBillForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public GenerateBillForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GenerateBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "GenerateBillForm";
            this.Text = "Generate Bill";
            this.ResumeLayout(false);
        }
    }
} 