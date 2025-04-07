using System;
using System.Windows.Forms;

namespace VDStore.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClient = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewBills = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.mnuMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHome,
            this.mnuDashboard,
            this.mnuEmployee,
            this.mnuClient,
            this.mnuProduct,
            this.mnuManageOrders,
            this.mnuViewBills,
            this.mnuLogout});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1302, 33);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuHome
            // 
            this.mnuHome.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuHome.Image = ((System.Drawing.Image)(resources.GetObject("mnuHome.Image")));
            this.mnuHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuHome.Name = "mnuHome";
            this.mnuHome.Size = new System.Drawing.Size(94, 29);
            this.mnuHome.Text = "Home";
            this.mnuHome.Click += new System.EventHandler(this.MnuHome_Click);
            // 
            // mnuDashboard
            // 
            this.mnuDashboard.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuDashboard.Image = ((System.Drawing.Image)(resources.GetObject("mnuDashboard.Image")));
            this.mnuDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuDashboard.Name = "mnuDashboard";
            this.mnuDashboard.Size = new System.Drawing.Size(204, 29);
            this.mnuDashboard.Text = "Dashboard";
            this.mnuDashboard.Click += new System.EventHandler(this.MnuDashboard_Click);
            // 
            // mnuEmployee
            // 
            this.mnuEmployee.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.mnuEmployee.Image = ((System.Drawing.Image)(resources.GetObject("mnuEmployee.Image")));
            this.mnuEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuEmployee.Name = "mnuEmployee";
            this.mnuEmployee.Size = new System.Drawing.Size(204, 29);
            this.mnuEmployee.Text = "Manage Employees";
            this.mnuEmployee.Click += new System.EventHandler(this.MnuEmployee_Click);
            // 
            // mnuClient
            // 
            this.mnuClient.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.mnuClient.Image = ((System.Drawing.Image)(resources.GetObject("mnuClient.Image")));
            this.mnuClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuClient.Name = "mnuClient";
            this.mnuClient.Size = new System.Drawing.Size(204, 29);
            this.mnuClient.Text = "Manage Clients";
            this.mnuClient.Click += new System.EventHandler(this.MnuClient_Click);
            // 
            // mnuProduct
            // 
            this.mnuProduct.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.mnuProduct.Image = ((System.Drawing.Image)(resources.GetObject("mnuProduct.Image")));
            this.mnuProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuProduct.Name = "mnuProduct";
            this.mnuProduct.Size = new System.Drawing.Size(204, 29);
            this.mnuProduct.Text = "Manage Products";
            this.mnuProduct.Click += new System.EventHandler(this.MnuProduct_Click);
            // 
            // mnuManageOrders
            // 
            this.mnuManageOrders.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.mnuManageOrders.Image = ((System.Drawing.Image)(resources.GetObject("mnuManageOrders.Image")));
            this.mnuManageOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuManageOrders.Name = "mnuManageOrders";
            this.mnuManageOrders.Size = new System.Drawing.Size(204, 29);
            this.mnuManageOrders.Text = "Manage Orders";
            this.mnuManageOrders.Click += new System.EventHandler(this.MnuManageOrders_Click);
            // 
            // mnuViewBills
            // 
            this.mnuViewBills.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.mnuViewBills.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewBills.Image")));
            this.mnuViewBills.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuViewBills.Name = "mnuViewBills";
            this.mnuViewBills.Size = new System.Drawing.Size(204, 29);
            this.mnuViewBills.Text = "View Bills";
            this.mnuViewBills.Click += new System.EventHandler(this.MnuViewBills_Click);
            // 
            // mnuLogout
            // 
            this.mnuLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuLogout.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.mnuLogout.Image = ((System.Drawing.Image)(resources.GetObject("mnuLogout.Image")));
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(204, 29);
            this.mnuLogout.Text = "Logout";
            this.mnuLogout.Click += new System.EventHandler(this.MnuLogout_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusUser,
            this.lblStatusDateTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 532);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1302, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatusUser
            // 
            this.lblStatusUser.Name = "lblStatusUser";
            this.lblStatusUser.Size = new System.Drawing.Size(33, 17);
            this.lblStatusUser.Text = "User:";
            // 
            // lblStatusDateTime
            // 
            this.lblStatusDateTime.Name = "lblStatusDateTime";
            this.lblStatusDateTime.Size = new System.Drawing.Size(63, 17);
            this.lblStatusDateTime.Text = "Date Time:";
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += new System.EventHandler(this.TimerDateTime_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1302, 554);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pi Store Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuHome;
        private System.Windows.Forms.ToolStripMenuItem mnuDashboard;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuClient;
        private System.Windows.Forms.ToolStripMenuItem mnuProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuManageOrders;
        private System.Windows.Forms.ToolStripMenuItem mnuViewBills;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusUser;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusDateTime;
        private System.Windows.Forms.Timer timerDateTime;
    }
} 