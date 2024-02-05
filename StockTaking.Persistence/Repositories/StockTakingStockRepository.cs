using StockTaking.Entities;
using StockTaking.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StockTaking.Persistence.Repositories
{
    public class StockTakingStockRepository: BaseRepository<StockTakingStock>, IStockTakingStockRepository
    {
        public StockTakingStockRepository(DataContext context) : base(context)
        {
            
        }
    }
}