﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComputerService.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;

namespace ComputerService.Controllers
{




    [Authorize]
   
    public class HomeController : Controller
    {
        SqlCommand command = new SqlCommand();
        SqlDataReader datareader;
        SqlConnection connection = new SqlConnection();
        public List<Items> items = new List<Items>();
        public List<Items> itemsToPost = new List<Items>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            connection.ConnectionString = ComputerService.Properties.Resources.ConnectionStringDB;
            CatchData();
        }

        public IActionResult Index()
        {
            CatchData();
            //FiltrData("procesor",items);
            return View(this);
        }

        public IActionResult UpdateInex(string input)
        {
            var newString = input.ToLower();
            
            switch (input)
            {
               
                case("headphones"):
           
                     itemsToPost = new List<Items>(items.Where(x => x.Type.ToLower().Contains(input.ToLower())).ToList());
                     break;
                case ("monitor"):

                    itemsToPost = new List<Items>(items.Where(x => x.Type.ToLower().Contains(input.ToLower())).ToList());
                    break;
                case ("procesor"):
                    itemsToPost = new List<Items>(items.Where(x => x.Type.ToLower().Contains(input.ToLower())).ToList());
                    break;
                case ("card"):
                    itemsToPost = new List<Items>(items.Where(x => x.Type.ToLower().Contains(input.ToLower())).ToList());
                    break;
                default:
                    itemsToPost = new List<Items>(items);
                    break;
            }
            
            
            return Index();
        }
        private Items FiltrData(string condition, IEnumerable<Items> It)
        {
            return It.Where(x => x.Type == condition).FirstOrDefault();
        }
            //     IEnumerable<Items> scoreQuery =
            //        from score in It.Type
            //        where score == condition
            //        select score;
            //return scoreQuery;
       // }
        public void CatchData()
        {
            
            if(items.Count>0)
            {
                items.Clear();
            }
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select name, brand, type, price, image from Items";
                datareader = command.ExecuteReader();
                while(datareader.Read())
                {
                    items.Add(new Items()

                    {
                        Name = datareader["name"].ToString(),
                        Brand = datareader["brand"].ToString(),
                        Type = datareader["type"].ToString(),
                        Price = datareader["price"].ToString(),
                        Image = datareader["image"].ToString(),
                       

                    }); ;

               
                }
                connection.Close();            
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
