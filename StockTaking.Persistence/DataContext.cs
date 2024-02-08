using Microsoft.EntityFrameworkCore;
using StockTaking.Entities;

namespace StockTaking.Persistence
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<MovementType> MovementType { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StockTakingMovement> StockTakingMovements { get; set; }
        public DbSet<StockTakingStock> StockTakingStocks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}