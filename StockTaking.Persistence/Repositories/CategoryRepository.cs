using StockTaking.Entities;
using StockTaking.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StockTaking.Persistence.Repositories
{
    public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
            
        }
    }
}