using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComputerService.Models;
using Microsoft.AspNetCore.Authorization;

namespace ComputerService.Models
{
    public class AllItems
    {
        readonly SqlCommand command = new SqlCommand();
        SqlDataReader datareader;
        public SqlConnection connection = new SqlConnection();
        public List<Item> _items = new List<Item>();
        

        public List<Item> CatchData()
        {
            
            if (_items.Count > 0)
            {
                _items.Clear();
            }
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select id, name, brand, type, price, image from Items";
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    _items.Add(new Item()

                    {
                        Id = datareader["id"].ToString(),
                        Name = datareader["name"].ToString(),
                        Brand = datareader["brand"].ToString(),
                        Type = datareader["type"].ToString(),
                        Price = datareader["price"].ToString(),
                        Image = datareader["image"].ToString(),


                    }); ;


                }
                connection.Close();
                return _items;
                
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }
        
        public Item find(string id)
        {
            List<Item> items = CatchData();
            var it = items.Where(a => a.Id == id).FirstOrDefault();
            return it;
        }
        public  AllItems()
        {
            connection.ConnectionString = ComputerService.Properties.Resources.ConnectionStringDB;
            CatchData();
        }
    }
}
