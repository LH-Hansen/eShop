using eShop.Repository.Data;
using eShop.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Repository.Repositories.Repository
{
    public class BrandRepository
    {
        private readonly eShopDbContext _dbContext;

        public BrandRepository(eShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync() => await _dbContext.Brands.ToListAsync();

        public async Task<Brand?> GetByIdAsync(int id) => await _dbContext.Brands.FindAsync(id) ?? throw new KeyNotFoundException($"Brand with id {id} not found.");

        public async Task AddAsync(Brand newBrand)
        {
            await _dbContext.AddAsync(newBrand);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Brand updatedBrand)
        {
            _dbContext.Brands.Update(updatedBrand);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Brand brand = await GetByIdAsync(id);

            _dbContext.Brands.Remove(brand);
            await _dbContext.SaveChangesAsync();
        }
    }
}
