using System;

namespace VDStore.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? EmployeeID { get; set; }
        public int? ClientID { get; set; }
        
        // Navigation property
        public Employee Employee { get; set; }
        public Client Client { get; set; }
    }
} 