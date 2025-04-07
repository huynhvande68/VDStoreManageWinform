using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VDStore.Models;

namespace VDStore.DAL
{
    public class ProductDAL
    {
        public static List<Product> GetAllProducts()
        {
            string query = "SELECT * FROM Product";
            DataTable dt = DbConnection.ExecuteQuery(query);
            
            List<Product> products = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                Product product = new Product
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = row["Name"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : null
                };
                
                products.Add(product);
            }
            
            return products;
        }
        
        public static Product GetProductByID(int id)
        {
            string query = "SELECT * FROM Product WHERE ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count == 0)
                return null;
                
            DataRow row = dt.Rows[0];
            Product product = new Product
            {
                ID = Convert.ToInt32(row["ID"]),
                Name = row["Name"].ToString(),
                Description = row["Description"].ToString(),
                Price = Convert.ToDecimal(row["Price"]),
                Quantity = Convert.ToInt32(row["Quantity"]),
                ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : null
            };
            
            return product;
        }
        
        public static int AddProduct(Product product)
        {
            string query = @"INSERT INTO Product (Name, Description, Price, Quantity, ImagePath) 
                           VALUES (@Name, @Description, @Price, @Quantity, @ImagePath);
                           SELECT SCOPE_IDENTITY();";
                           
            SqlParameter[] parameters = {
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Quantity", product.Quantity),
                new SqlParameter("@ImagePath", (object)product.ImagePath ?? DBNull.Value)
            };
            
            object result = DbConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }
        
        public static bool UpdateProduct(Product product)
        {
            string query = @"UPDATE Product 
                           SET Name = @Name, Description = @Description, 
                           Price = @Price, Quantity = @Quantity, ImagePath = @ImagePath
                           WHERE ID = @ID";
                           
            SqlParameter[] parameters = {
                new SqlParameter("@ID", product.ID),
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Quantity", product.Quantity),
                new SqlParameter("@ImagePath", (object)product.ImagePath ?? DBNull.Value)
            };
            
            int rowsAffected = DbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
        
        public static bool DeleteProduct(int id)
        {
            string query = "DELETE FROM Product WHERE ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            
            int rowsAffected = DbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
        
        public static List<Product> SearchProducts(string searchTerm)
        {
            string query = @"SELECT * FROM Product 
                           WHERE Name LIKE @SearchTerm 
                           OR Description LIKE @SearchTerm";
                           
            SqlParameter[] parameters = { new SqlParameter("@SearchTerm", "%" + searchTerm + "%") };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            List<Product> products = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                Product product = new Product
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = row["Name"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : null
                };
                
                products.Add(product);
            }
            
            return products;
        }
        
        public static bool UpdateProductQuantity(int productId, int quantityChange)
        {
            string query = @"UPDATE Product SET Quantity = Quantity + @QuantityChange WHERE ID = @ID";
            SqlParameter[] parameters = {
                new SqlParameter("@ID", productId),
                new SqlParameter("@QuantityChange", quantityChange)
            };
            
            int rowsAffected = DbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
} 