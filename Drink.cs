using System;

namespace DataBar
{
    internal class Drink
    {
        public Int32 DrinkId { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public Int32 Quantity { get; set; }
        public Int32 CategoryId { get; set; }

        public override string ToString()
        {
            return Name + " - " + Quantity + " cl - " + Price + " €";
        }
    }
}