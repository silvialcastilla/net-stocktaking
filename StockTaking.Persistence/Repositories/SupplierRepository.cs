using StockTaking.Entities;
using StockTaking.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StockTaking.Persistence.Repositories
{
    public class SupplierRepository: BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DataContext context) : base(context)
        {
            
        }
    }
}