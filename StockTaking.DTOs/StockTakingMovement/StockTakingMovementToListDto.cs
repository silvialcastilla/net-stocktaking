using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTaking.DTOs.StockTakingMovement
{
    public class StockTakingMovementToListDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int MovementTypeId { get; set; }
        public string MovementTypeName { get; set; }  = string.Empty;
        public string ProductName { get; set; } = string.Empty;
    }
}