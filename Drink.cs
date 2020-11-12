using System;
using System.ComponentModel;

namespace DataBar
{
    public class Drink
    {
        public Int32 DrinkId { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public Int32 Quantity { get; set; }

        public Category Category { get; set; }

        public override string ToString()
        {
            return Name + " - " + Quantity + " cl - " + Price + " €";
        }
    }
}