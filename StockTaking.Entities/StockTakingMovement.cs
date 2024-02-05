using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTaking.Entities
{
    public class StockTakingMovement
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public int MovementTypeId { get; set; }

        public MovementType? MovementType { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

    }
}