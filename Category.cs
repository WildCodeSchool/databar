using System;
using System.Collections.Generic;

namespace DataBar
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public String Name { get; set; }

        public ICollection<Drink> Drinks { get; set; }
    }
}