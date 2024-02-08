using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTaking.DTOs.StockTakingStock
{
    public class StockTakingStockToCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }= string.Empty;
    }
}