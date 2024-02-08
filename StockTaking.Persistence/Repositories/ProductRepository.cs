using StockTaking.Entities;
using StockTaking.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StockTaking.Persistence.Repositories
{
    public class ProductRepository: BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
            
        }
    }
}