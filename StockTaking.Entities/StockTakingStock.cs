using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTaking.Entities
{
    public class StockTakingStock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}