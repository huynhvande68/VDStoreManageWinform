using System;
using System.Collections.Generic;

namespace VDStore.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Active"; // Mặc định là "Active"
        
        // Navigation properties
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
} 