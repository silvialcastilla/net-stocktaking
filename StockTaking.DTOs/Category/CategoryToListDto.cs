using System;

namespace StockTaking.DTOs.Category
{
    public class CategoryToListDto
    {
        public int Id {get; set;}

        public string Name {get; set;}

        public string Description {get; set;}

        public DateTime CreateAt {get; set;}

        public DateTime? UpdateAt {get; set;}
    }
}