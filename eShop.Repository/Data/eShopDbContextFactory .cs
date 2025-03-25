using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace eShop.Repository.Data
{
    public class eShopDbContextFactory : IDesignTimeDbContextFactory<eShopDbContext>
    {
        public eShopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<eShopDbContext>();

            // Configure DbContext to use SQL Server with the connection string
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=eShop;Trusted_Connection=True;");

            return new eShopDbContext(optionsBuilder.Options);
        }
    }
}
