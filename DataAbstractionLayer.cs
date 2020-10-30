using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DataBar
{
    internal class DataAbstractionLayer
    {
        private static SqlConnection _connection = new SqlConnection();

        internal static void Open(SqlConnectionStringBuilder stringBuilder)
        {
            _connection.ConnectionString = stringBuilder.ConnectionString;
            _connection.Open();  
        }

        internal static void Close()
        {
            _connection.Close();
        }

        internal static IEnumerable<Drink> SelectAllDrinks()
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Drink";
            SqlDataReader reader = command.ExecuteReader();
            List<Drink> drinks = new List<Drink>();
            while (reader.Read()) // Tant qu'il y a de la donnée je lis un enregistrement
            {
                Drink drink = new Drink
                {
                    DrinkId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDecimal(2),
                    Quantity = reader.GetInt32(3),
                    CategoryId = reader.GetInt32(4)
                };
                drinks.Add(drink);
            }
            reader.Close();
            return drinks;
        }
    }
}