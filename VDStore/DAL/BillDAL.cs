using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VDStore.Models;

namespace VDStore.DAL
{
    public class BillDAL
    {
        public static List<Bill> GetAllBills()
        {
            string query = @"SELECT b.*, c.Name as ClientName, e.Name as EmployeeName 
                           FROM Bill b
                           INNER JOIN Client c ON b.ClientID = c.ID
                           INNER JOIN Employee e ON b.EmployeeID = e.ID";
            DataTable dt = DbConnection.ExecuteQuery(query);
            
            List<Bill> bills = new List<Bill>();
            foreach (DataRow row in dt.Rows)
            {
                Bill bill = new Bill
                {
                    ID = Convert.ToInt32(row["ID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    ClientID = Convert.ToInt32(row["ClientID"]),
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    BillDate = Convert.ToDateTime(row["BillDate"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    IsPaid = Convert.ToBoolean(row["IsPaid"]),
                    Client = new Client { ID = Convert.ToInt32(row["ClientID"]), Name = row["ClientName"].ToString() },
                    Employee = new Employee { ID = Convert.ToInt32(row["EmployeeID"]), Name = row["EmployeeName"].ToString() }
                };
                
                bills.Add(bill);
            }
            
            return bills;
        }
        
        public static Bill GetBillByID(int id)
        {
            string query = @"SELECT b.*, c.Name as ClientName, e.Name as EmployeeName 
                           FROM Bill b
                           INNER JOIN Client c ON b.ClientID = c.ID
                           INNER JOIN Employee e ON b.EmployeeID = e.ID
                           WHERE b.ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count == 0)
                return null;
                
            DataRow row = dt.Rows[0];
            Bill bill = new Bill
            {
                ID = Convert.ToInt32(row["ID"]),
                OrderID = Convert.ToInt32(row["OrderID"]),
                ClientID = Convert.ToInt32(row["ClientID"]),
                EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                BillDate = Convert.ToDateTime(row["BillDate"]),
                TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                IsPaid = Convert.ToBoolean(row["IsPaid"]),
                Client = new Client { ID = Convert.ToInt32(row["ClientID"]), Name = row["ClientName"].ToString() },
                Employee = new Employee { ID = Convert.ToInt32(row["EmployeeID"]), Name = row["EmployeeName"].ToString() }
            };
            
            return bill;
        }
        
        public static int GenerateBill(int orderId)
        {
            SqlParameter outputParam = new SqlParameter("@BillID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            
            SqlParameter[] parameters = {
                new SqlParameter("@OrderID", orderId),
                outputParam
            };
            
            DbConnection.ExecuteNonQuery("EXEC sp_GenerateBill @OrderID, @BillID OUTPUT", parameters);
            
            return Convert.ToInt32(outputParam.Value);
        }
        
        public static List<Bill> SearchBillsByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT b.*, c.Name as ClientName, e.Name as EmployeeName 
                           FROM Bill b
                           INNER JOIN Client c ON b.ClientID = c.ID
                           INNER JOIN Employee e ON b.EmployeeID = e.ID
                           WHERE b.BillDate BETWEEN @StartDate AND @EndDate";
            SqlParameter[] parameters = {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            List<Bill> bills = new List<Bill>();
            foreach (DataRow row in dt.Rows)
            {
                Bill bill = new Bill
                {
                    ID = Convert.ToInt32(row["ID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    ClientID = Convert.ToInt32(row["ClientID"]),
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    BillDate = Convert.ToDateTime(row["BillDate"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    IsPaid = Convert.ToBoolean(row["IsPaid"]),
                    Client = new Client { ID = Convert.ToInt32(row["ClientID"]), Name = row["ClientName"].ToString() },
                    Employee = new Employee { ID = Convert.ToInt32(row["EmployeeID"]), Name = row["EmployeeName"].ToString() }
                };
                
                bills.Add(bill);
            }
            
            return bills;
        }
        
        public static List<Bill> GetBillsByClientID(int clientId)
        {
            string query = @"SELECT b.*, c.Name as ClientName, e.Name as EmployeeName 
                           FROM Bill b
                           INNER JOIN Client c ON b.ClientID = c.ID
                           INNER JOIN Employee e ON b.EmployeeID = e.ID
                           WHERE b.ClientID = @ClientID";
            SqlParameter[] parameters = { new SqlParameter("@ClientID", clientId) };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            List<Bill> bills = new List<Bill>();
            foreach (DataRow row in dt.Rows)
            {
                Bill bill = new Bill
                {
                    ID = Convert.ToInt32(row["ID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    ClientID = Convert.ToInt32(row["ClientID"]),
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    BillDate = Convert.ToDateTime(row["BillDate"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    IsPaid = Convert.ToBoolean(row["IsPaid"]),
                    Client = new Client { ID = Convert.ToInt32(row["ClientID"]), Name = row["ClientName"].ToString() },
                    Employee = new Employee { ID = Convert.ToInt32(row["EmployeeID"]), Name = row["EmployeeName"].ToString() }
                };
                
                bills.Add(bill);
            }
            
            return bills;
        }
        
        public static bool MarkBillAsPaid(int billId)
        {
            string query = "UPDATE Bill SET IsPaid = 1 WHERE ID = @BillID";
            SqlParameter[] parameters = { new SqlParameter("@BillID", billId) };
            
            int rowsAffected = DbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
} 