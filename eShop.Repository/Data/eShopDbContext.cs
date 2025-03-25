using Microsoft.EntityFrameworkCore;

namespace eShop.Repository.Data
{
    public class eShopDbContext : DbContext
    {
        public eShopDbContext(DbContextOptions<eShopDbContext> options) : base(options) { }

        protected void OnConfiguration(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
