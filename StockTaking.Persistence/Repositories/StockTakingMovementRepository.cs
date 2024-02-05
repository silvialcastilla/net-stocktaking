using StockTaking.Entities;
using StockTaking.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StockTaking.Persistence.Repositories
{
    public class StockTakingMovementRepository: BaseRepository<StockTakingMovement>, IStockTakingMovementRepository 
    {
        public StockTakingMovementRepository(DataContext context) : base(context)
        {
            
        }
    }
}