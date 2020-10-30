using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBar
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "LOCALHOST\\SQLEXPRESS";
            stringBuilder.InitialCatalog = "DataBar";
            stringBuilder.IntegratedSecurity = true;
            DataAbstractionLayer.Open(stringBuilder);
            IEnumerable<Drink> drinks = DataAbstractionLayer.SelectAllDrinks();
            Console.WriteLine($"SELECT * FROM table WHERE kkchoz={Convert.ToInt32(true)}");
            Console.WriteLine("Kesstu ve boire ? Putain de client de merde !");
            foreach (Drink drink in drinks)
            {
                Console.WriteLine(drink);
            }
            DataAbstractionLayer.Close();
        }
    }
}
