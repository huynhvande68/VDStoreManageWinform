using System;
using System.Data;
using System.Data.SqlClient;
using VDStore.Models;

namespace VDStore.DAL
{
    public class UserDAL
    {
        public static User ValidateUser(string username, string password)
        {
            string query = @"SELECT u.*, e.Name as EmployeeName 
                           FROM [User] u
                           LEFT JOIN Employee e ON u.EmployeeID = e.ID
                           WHERE u.Username = @Username AND u.Password = @Password";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count == 0)
                return null;
                
            DataRow row = dt.Rows[0];
            User user = new User
            {
                ID = Convert.ToInt32(row["ID"]),
                Username = row["Username"].ToString(),
                Password = row["Password"].ToString(),
                Role = row["Role"].ToString(),
                EmployeeID = row["EmployeeID"] != DBNull.Value ? (int?)Convert.ToInt32(row["EmployeeID"]) : null
            };
            
            if (user.EmployeeID.HasValue)
            {
                user.Employee = new Employee
                {
                    ID = user.EmployeeID.Value,
                    Name = row["EmployeeName"].ToString()
                };
            }
            
            return user;
        }
        
        public static int AddUser(User user)
        {
            string query = @"INSERT INTO [User] (Username, Password, Role, EmployeeID) 
                           VALUES (@Username, @Password, @Role, @EmployeeID);
                           SELECT SCOPE_IDENTITY();";
                           
            SqlParameter employeeIDParam = new SqlParameter("@EmployeeID", SqlDbType.Int);
            if (user.EmployeeID.HasValue)
                employeeIDParam.Value = user.EmployeeID.Value;
            else
                employeeIDParam.Value = DBNull.Value;
                
            SqlParameter[] parameters = {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Role", user.Role),
                employeeIDParam
            };
            
            object result = DbConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }
        
        public static bool UpdateUser(User user)
        {
            string query = @"UPDATE [User] 
                           SET Username = @Username, Password = @Password, 
                           Role = @Role, EmployeeID = @EmployeeID
                           WHERE ID = @ID";
                           
            SqlParameter employeeIDParam = new SqlParameter("@EmployeeID", SqlDbType.Int);
            if (user.EmployeeID.HasValue)
                employeeIDParam.Value = user.EmployeeID.Value;
            else
                employeeIDParam.Value = DBNull.Value;
                
            SqlParameter[] parameters = {
                new SqlParameter("@ID", user.ID),
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Role", user.Role),
                employeeIDParam
            };
            
            int rowsAffected = DbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
        
        public static bool DeleteUser(int id)
        {
            string query = "DELETE FROM [User] WHERE ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            
            int rowsAffected = DbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
        
        public static bool UsernameExists(string username)
        {
            string query = "SELECT COUNT(1) FROM [User] WHERE Username = @Username";
            SqlParameter[] parameters = { new SqlParameter("@Username", username) };
            
            object result = DbConnection.ExecuteScalar(query, parameters);
            int count = Convert.ToInt32(result);
            return count > 0;
        }
    }
} 