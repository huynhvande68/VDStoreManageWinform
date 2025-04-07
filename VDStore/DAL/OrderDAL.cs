using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VDStore.Models;

namespace VDStore.DAL
{
    public class OrderDAL
    {
        public static List<Order> GetAllOrders()
        {
            string query = @"SELECT o.*, c.Name as ClientName, e.Name as EmployeeName 
                           FROM [Order] o
                           INNER JOIN Client c ON o.ClientID = c.ID
                           INNER JOIN Employee e ON o.EmployeeID = e.ID";
            DataTable dt = DbConnection.ExecuteQuery(query);
            
            List<Order> orders = new List<Order>();
            foreach (DataRow row in dt.Rows)
            {
                Order order = new Order
                {
                    ID = Convert.ToInt32(row["ID"]),
                    ClientID = Convert.ToInt32(row["ClientID"]),
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    TotalPrice = Convert.ToDecimal(row["TotalPrice"]),
                    Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "Active",
                    Client = new Client { ID = Convert.ToInt32(row["ClientID"]), Name = row["ClientName"].ToString() },
                    Employee = new Employee { ID = Convert.ToInt32(row["EmployeeID"]), Name = row["EmployeeName"].ToString() }
                };
                
                orders.Add(order);
            }
            
            return orders;
        }
        
        public static Order GetOrderByID(int id)
        {
            string query = @"SELECT o.*, c.Name as ClientName, e.Name as EmployeeName 
                           FROM [Order] o
                           INNER JOIN Client c ON o.ClientID = c.ID
                           INNER JOIN Employee e ON o.EmployeeID = e.ID
                           WHERE o.ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count == 0)
                return null;
                
            DataRow row = dt.Rows[0];
            Order order = new Order
            {
                ID = Convert.ToInt32(row["ID"]),
                ClientID = Convert.ToInt32(row["ClientID"]),
                EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                OrderDate = Convert.ToDateTime(row["OrderDate"]),
                TotalPrice = Convert.ToDecimal(row["TotalPrice"]),
                Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "Active",
                Client = new Client { ID = Convert.ToInt32(row["ClientID"]), Name = row["ClientName"].ToString() },
                Employee = new Employee { ID = Convert.ToInt32(row["EmployeeID"]), Name = row["EmployeeName"].ToString() },
                OrderItems = GetOrderItemsByOrderID(Convert.ToInt32(row["ID"]))
            };
            
            return order;
        }
        
        public static int CreateOrder(Order order)
        {
            SqlParameter outputParam = new SqlParameter("@OrderID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            
            SqlParameter[] parameters = {
                new SqlParameter("@ClientID", order.ClientID),
                new SqlParameter("@EmployeeID", order.EmployeeID),
                new SqlParameter("@OrderDate", order.OrderDate),
                new SqlParameter("@Status", order.Status ?? "Active"),
                outputParam
            };
            
            DbConnection.ExecuteNonQuery("EXEC sp_PlaceOrder @ClientID, @EmployeeID, @OrderDate, @Status, @OrderID OUTPUT", parameters);
            
            return Convert.ToInt32(outputParam.Value);
        }
        
        public static int PlaceOrder(int clientId, int employeeId, DateTime orderDate, string status = "Active")
        {
            SqlParameter outputParam = new SqlParameter("@OrderID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            
            SqlParameter[] parameters = {
                new SqlParameter("@ClientID", clientId),
                new SqlParameter("@EmployeeID", employeeId),
                new SqlParameter("@OrderDate", orderDate),
                new SqlParameter("@Status", status),
                outputParam
            };
            
            DbConnection.ExecuteNonQuery("EXEC sp_PlaceOrder @ClientID, @EmployeeID, @OrderDate, @Status, @OrderID OUTPUT", parameters);
            
            return Convert.ToInt32(outputParam.Value);
        }
        
        public static bool AddOrderItem(OrderItem orderItem)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@OrderID", orderItem.OrderID),
                new SqlParameter("@ProductID", orderItem.ProductID),
                new SqlParameter("@Quantity", orderItem.Quantity)
            };
            
            try
            {
                DbConnection.ExecuteNonQuery("EXEC sp_AddOrderItem @OrderID, @ProductID, @Quantity", parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static bool AddOrderItem(int orderId, int productId, int quantity)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@OrderID", orderId),
                new SqlParameter("@ProductID", productId),
                new SqlParameter("@Quantity", quantity)
            };
            
            try
            {
                DbConnection.ExecuteNonQuery("EXEC sp_AddOrderItem @OrderID, @ProductID, @Quantity", parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static List<OrderItem> GetOrderItemsByOrderID(int orderId)
        {
            string query = @"SELECT oi.*, p.Name as ProductName, p.Price 
                           FROM OrderItem oi
                           INNER JOIN Product p ON oi.ProductID = p.ID
                           WHERE oi.OrderID = @OrderID";
            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId) };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (DataRow row in dt.Rows)
            {
                OrderItem orderItem = new OrderItem
                {
                    ID = Convert.ToInt32(row["ID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    Product = new Product
                    {
                        ID = Convert.ToInt32(row["ProductID"]),
                        Name = row["ProductName"].ToString(),
                        Price = Convert.ToDecimal(row["Price"])
                    }
                };
                
                orderItems.Add(orderItem);
            }
            
            return orderItems;
        }
        
        public static List<Order> SearchOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT o.*, c.Name as ClientName, e.Name as EmployeeName 
                           FROM [Order] o
                           INNER JOIN Client c ON o.ClientID = c.ID
                           INNER JOIN Employee e ON o.EmployeeID = e.ID
                           WHERE o.OrderDate BETWEEN @StartDate AND @EndDate";
            SqlParameter[] parameters = {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            List<Order> orders = new List<Order>();
            foreach (DataRow row in dt.Rows)
            {
                Order order = new Order
                {
                    ID = Convert.ToInt32(row["ID"]),
                    ClientID = Convert.ToInt32(row["ClientID"]),
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    TotalPrice = Convert.ToDecimal(row["TotalPrice"]),
                    Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "Active",
                    Client = new Client { ID = Convert.ToInt32(row["ClientID"]), Name = row["ClientName"].ToString() },
                    Employee = new Employee { ID = Convert.ToInt32(row["EmployeeID"]), Name = row["EmployeeName"].ToString() }
                };
                
                orders.Add(order);
            }
            
            return orders;
        }
        
        public static List<Order> GetOrdersByClientID(int clientId)
        {
            string query = @"SELECT o.*, c.Name as ClientName, e.Name as EmployeeName 
                           FROM [Order] o
                           INNER JOIN Client c ON o.ClientID = c.ID
                           INNER JOIN Employee e ON o.EmployeeID = e.ID
                           WHERE o.ClientID = @ClientID";
            SqlParameter[] parameters = { new SqlParameter("@ClientID", clientId) };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            List<Order> orders = new List<Order>();
            foreach (DataRow row in dt.Rows)
            {
                Order order = new Order
                {
                    ID = Convert.ToInt32(row["ID"]),
                    ClientID = Convert.ToInt32(row["ClientID"]),
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    TotalPrice = Convert.ToDecimal(row["TotalPrice"]),
                    Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "Active",
                    Client = new Client { ID = Convert.ToInt32(row["ClientID"]), Name = row["ClientName"].ToString() },
                    Employee = new Employee { ID = Convert.ToInt32(row["EmployeeID"]), Name = row["EmployeeName"].ToString() }
                };
                
                orders.Add(order);
            }
            
            return orders;
        }
        
        public static bool UpdateOrderStatus(int orderId, string status)
        {
            string query = "UPDATE [Order] SET Status = @Status WHERE ID = @OrderID";
            SqlParameter[] parameters = {
                new SqlParameter("@OrderID", orderId),
                new SqlParameter("@Status", status)
            };
            
            try
            {
                DbConnection.ExecuteNonQuery(query, parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static List<Order> GetOrdersByStatus(string status)
        {
            string query = @"SELECT o.*, c.Name as ClientName, e.Name as EmployeeName 
                           FROM [Order] o
                           INNER JOIN Client c ON o.ClientID = c.ID
                           INNER JOIN Employee e ON o.EmployeeID = e.ID
                           WHERE o.Status = @Status";
            SqlParameter[] parameters = { new SqlParameter("@Status", status) };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            List<Order> orders = new List<Order>();
            foreach (DataRow row in dt.Rows)
            {
                Order order = new Order
                {
                    ID = Convert.ToInt32(row["ID"]),
                    ClientID = Convert.ToInt32(row["ClientID"]),
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    TotalPrice = Convert.ToDecimal(row["TotalPrice"]),
                    Status = row["Status"].ToString(),
                    Client = new Client { ID = Convert.ToInt32(row["ClientID"]), Name = row["ClientName"].ToString() },
                    Employee = new Employee { ID = Convert.ToInt32(row["EmployeeID"]), Name = row["EmployeeName"].ToString() }
                };
                
                orders.Add(order);
            }
            
            return orders;
        }
    }
} 