using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VDStore.Models;

namespace VDStore.DAL
{
    public class EmployeeDAL
    {
        public static List<Employee> GetAllEmployees()
        {
            string query = "SELECT * FROM Employee";
            DataTable dt = DbConnection.ExecuteQuery(query);
            
            List<Employee> employees = new List<Employee>();
            foreach (DataRow row in dt.Rows)
            {
                Employee employee = new Employee
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Address = row["Address"].ToString(),
                    Salary = Convert.ToDecimal(row["Salary"]),
                    HireDate = Convert.ToDateTime(row["HireDate"])
                };
                
                employees.Add(employee);
            }
            
            return employees;
        }
        
        public static Employee GetEmployeeByID(int id)
        {
            string query = "SELECT * FROM Employee WHERE ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count == 0)
                return null;
                
            DataRow row = dt.Rows[0];
            Employee employee = new Employee
            {
                ID = Convert.ToInt32(row["ID"]),
                Name = row["Name"].ToString(),
                Email = row["Email"].ToString(),
                Phone = row["Phone"].ToString(),
                Address = row["Address"].ToString(),
                Salary = Convert.ToDecimal(row["Salary"]),
                HireDate = Convert.ToDateTime(row["HireDate"])
            };
            
            return employee;
        }
        
        public static int AddEmployee(Employee employee)
        {
            string query = @"INSERT INTO Employee (Name, Email, Phone, Address, Salary, HireDate) 
                           VALUES (@Name, @Email, @Phone, @Address, @Salary, @HireDate);
                           SELECT SCOPE_IDENTITY();";
                           
            SqlParameter[] parameters = {
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Phone", employee.Phone),
                new SqlParameter("@Address", employee.Address),
                new SqlParameter("@Salary", employee.Salary),
                new SqlParameter("@HireDate", employee.HireDate)
            };
            
            object result = DbConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }
        
        public static bool UpdateEmployee(Employee employee)
        {
            string query = @"UPDATE Employee 
                           SET Name = @Name, Email = @Email, Phone = @Phone, 
                           Address = @Address, Salary = @Salary, HireDate = @HireDate
                           WHERE ID = @ID";
                           
            SqlParameter[] parameters = {
                new SqlParameter("@ID", employee.ID),
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Phone", employee.Phone),
                new SqlParameter("@Address", employee.Address),
                new SqlParameter("@Salary", employee.Salary),
                new SqlParameter("@HireDate", employee.HireDate)
            };
            
            int rowsAffected = DbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
        
        public static bool DeleteEmployee(int id)
        {
            string query = "DELETE FROM Employee WHERE ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            
            int rowsAffected = DbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
        
        public static List<Employee> SearchEmployees(string searchTerm)
        {
            string query = @"SELECT * FROM Employee 
                           WHERE Name LIKE @SearchTerm 
                           OR Email LIKE @SearchTerm 
                           OR Phone LIKE @SearchTerm";
                           
            SqlParameter[] parameters = { new SqlParameter("@SearchTerm", "%" + searchTerm + "%") };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            List<Employee> employees = new List<Employee>();
            foreach (DataRow row in dt.Rows)
            {
                Employee employee = new Employee
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Address = row["Address"].ToString(),
                    Salary = Convert.ToDecimal(row["Salary"]),
                    HireDate = Convert.ToDateTime(row["HireDate"])
                };
                
                employees.Add(employee);
            }
            
            return employees;
        }
    }
} 