using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTaking.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public IEnumerable<Product>? Products {get; set;}
    }
}