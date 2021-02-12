using ShopBridgeApp.Interface;
using ShopBridgeApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBridgeApp.Repositary
{
    public class InventoryRepositary:IInventory
    {
        SqlConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString);
        public List<Inventory> GetInventories()
        {
            List<Inventory> inventories = new List<Inventory>();
            using (connectionString)
            {
                SqlCommand cmd = new SqlCommand("spGetAllInventories", connectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionString.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Inventory inventory = new Inventory();
                    inventory.ID = Convert.ToInt32(reader["ID"]);
                    inventory.Name = reader["Name"].ToString();
                    inventory.Price = Convert.ToDecimal(reader["Price"]);
                    inventory.Description = reader["Description"].ToString();
                    inventory.ImagePath = reader["ImagePath"].ToString();
                    inventories.Add(inventory);
                }
                return inventories;


            }
        }

        public int SaveInventory(Inventory inventory)
        {
            using (connectionString)
            {
                SqlCommand cmd = new SqlCommand("spSaveInventory", connectionString);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", inventory.Name);
                if (inventory.Description != null)
                { cmd.Parameters.AddWithValue("@Description", inventory.Description); }
                else
                { cmd.Parameters.AddWithValue("@Description", DBNull.Value); }
              
                cmd.Parameters.AddWithValue("@Price", inventory.Price);
                if (inventory.ImagePath != null)
                { cmd.Parameters.AddWithValue("@ImagePath", inventory.ImagePath); }
                else
                { cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value); }
                
                connectionString.Open();
                return cmd.ExecuteNonQuery();

            }
        }

        //To Delete the record on a particular inventory  
        public int DeleteInventory(int id)
        {
            using (connectionString)
            {
                SqlCommand cmd = new SqlCommand("spDeleteInventory", connectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                connectionString.Open();
                return cmd.ExecuteNonQuery();

            }
        }
    }
}