using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTaking.Entities
{
    public class MovementType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsIncoming { get; set; }
        public bool IsOutgoing { get; set; }
        public bool IsInternalTransfer { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public IEnumerable<StockTakingMovement>? StockTakingMovement {get; set;}
    }
}