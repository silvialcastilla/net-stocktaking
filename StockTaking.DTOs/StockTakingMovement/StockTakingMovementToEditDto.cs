using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTaking.DTOs.StockTakingMovement
{
    public class StockTakingMovementToEditDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int MovementTypeId { get; set; }
    }
}