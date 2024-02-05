using StockTaking.Entities;
using StockTaking.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StockTaking.Persistence.Repositories
{
    public class MovementTypeRepository: BaseRepository<MovementType>, IMovementTypeRepository
    {
        public MovementTypeRepository(DataContext context) : base(context)
        {
            
        }
    }
}