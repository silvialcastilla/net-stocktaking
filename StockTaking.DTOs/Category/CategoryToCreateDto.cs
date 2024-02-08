using System;

namespace StockTaking.DTOs.Category
{
    public class CategoryToCreateDto
    {
        public string Name {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
    }
}