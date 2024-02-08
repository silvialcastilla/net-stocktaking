using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTaking.DTOs.MovementType
{
    public class MovementTypeToCreateDto
    {
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; }= string.Empty;
        public bool IsIncoming { get; set; }
        public bool IsOutgoing { get; set; }
        public bool IsInternalTransfer { get; set; }
    }
}