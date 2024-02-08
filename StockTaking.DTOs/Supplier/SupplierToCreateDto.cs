using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTaking.DTOs.Supplier
{
    public class SupplierToCreateDto
    {
        public string Name { get; set; }= string.Empty;
        public string ContactPerson { get; set; }= string.Empty;
        public string Phone { get; set; }= string.Empty;
        public string Email { get; set; }= string.Empty;
        public string Address { get; set; }= string.Empty;
    }
}