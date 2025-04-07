using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VDStore.Models;

namespace VDStore.DAL
{
    public class ClientDAL
    {
        public static List<Client> GetAllClients()
        {
            string query = "SELECT * FROM Client";
            DataTable dt = DbConnection.ExecuteQuery(query);
            
            List<Client> clients = new List<Client>();
            foreach (DataRow row in dt.Rows)
            {
                Client client = new Client
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Address = row["Address"].ToString()
                };
                
                clients.Add(client);
            }
            
            return clients;
        }
        
        public static Client GetClientByID(int id)
        {
            string query = "SELECT * FROM Client WHERE ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count == 0)
                return null;
                
            DataRow row = dt.Rows[0];
            Client client = new Client
            {
                ID = Convert.ToInt32(row["ID"]),
                Name = row["Name"].ToString(),
                Email = row["Email"].ToString(),
                Phone = row["Phone"].ToString(),
                Address = row["Address"].ToString()
            };
            
            return client;
        }
        
        public static int AddClient(Client client)
        {
            string query = @"INSERT INTO Client (Name, Email, Phone, Address) 
                           VALUES (@Name, @Email, @Phone, @Address);
                           SELECT SCOPE_IDENTITY();";
                           
            SqlParameter[] parameters = {
                new SqlParameter("@Name", client.Name),
                new SqlParameter("@Email", client.Email),
                new SqlParameter("@Phone", client.Phone),
                new SqlParameter("@Address", client.Address)
            };
            
            object result = DbConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }
        
        public static bool UpdateClient(Client client)
        {
            string query = @"UPDATE Client 
                           SET Name = @Name, Email = @Email, Phone = @Phone, Address = @Address
                           WHERE ID = @ID";
                           
            SqlParameter[] parameters = {
                new SqlParameter("@ID", client.ID),
                new SqlParameter("@Name", client.Name),
                new SqlParameter("@Email", client.Email),
                new SqlParameter("@Phone", client.Phone),
                new SqlParameter("@Address", client.Address)
            };
            
            int rowsAffected = DbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
        
        public static bool DeleteClient(int id)
        {
            string query = "DELETE FROM Client WHERE ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            
            int rowsAffected = DbConnection.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
        
        public static List<Client> SearchClients(string searchTerm)
        {
            string query = @"SELECT * FROM Client 
                           WHERE Name LIKE @SearchTerm 
                           OR Email LIKE @SearchTerm 
                           OR Phone LIKE @SearchTerm";
                           
            SqlParameter[] parameters = { new SqlParameter("@SearchTerm", "%" + searchTerm + "%") };
            
            DataTable dt = DbConnection.ExecuteQuery(query, parameters);
            
            List<Client> clients = new List<Client>();
            foreach (DataRow row in dt.Rows)
            {
                Client client = new Client
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Address = row["Address"].ToString()
                };
                
                clients.Add(client);
            }
            
            return clients;
        }
    }
} 