using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTaking.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string BarCode { get; set; } = string.Empty;

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public int CategoryId { get; set; } //foreign key

        public Category? Category {get; set;}

        public int SupplierId {get; set;}

        public Supplier? Supplier {get; set;}

        public IEnumerable<StockTakingMovement>? StockTakingMovement {get; set;}
    }
}