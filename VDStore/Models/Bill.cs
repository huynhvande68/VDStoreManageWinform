using System;

namespace VDStore.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime BillDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        
        // Navigation properties
        public Order Order { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
    }
} 