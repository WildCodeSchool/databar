using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataBar
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase();
            DataBarContext context = new DataBarContext();
            foreach (Category category in context.Categories.Include(c => c.Drinks))
            {
                Console.WriteLine(category.Name);
                foreach (Drink drink in category.Drinks)
                {
                    Console.WriteLine("\t" + drink);
                }
            }
        }

        private static void CreateDatabase()
        {
            DataBarContext context = new DataBarContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            ICollection<Drink> whiskies = new List<Drink>
            {
                new Drink { Name = "Monkey Shoulder", Price = 6, Quantity = 5 },
                new Drink { Name = "Pike Creek", Price = 8, Quantity = 5 },
            }; 
            
            ICollection<Drink> rhums = new List<Drink>
            {
                new Drink { Name = "Diplomatico", Price = 8, Quantity = 5 },
                new Drink { Name = "Kraken", Price = 8, Quantity = 5 },
            };

            Category rhumsCategory = new Category { Name = "Rhum", Drinks = rhums };
            Category whiskiesCategory = new Category { Name = "Whisky", Drinks = whiskies };

            context.AddRange(rhumsCategory, whiskiesCategory);
            context.SaveChanges();
        }
    }
}
