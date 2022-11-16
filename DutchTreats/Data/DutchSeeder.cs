using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DutchTreats.Data
{
    public class DutchSeeder
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hosting;

        public DutchSeeder(ApplicationDbContext ctx, IWebHostEnvironment hosting)
        {
            _db = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            // Verify that the database actually exists
            _db.Database.EnsureCreated();

            // If there are no products then create Sample Data
            if (!_db.Products.Any())
            {
                // Need to create the Sample data
                // the ContentRootPath is refering to the folders not related to the wwwroot
                var file = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(file);


                // Deserialize the json file into the List of Product Class
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);

                // Add the new list of products to the database
                _db.Products.AddRange(products);

                var order = new Order()
                {
                    OrderDate = DateTime.Today,
                    OrderNumber = "10000",
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    }
                };

                _db.Orders.Add(order);

                _db.SaveChanges(); // commit changes to database (make permanent)
            }

        }

    }
}
