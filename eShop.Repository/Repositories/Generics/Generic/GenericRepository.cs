using eShop.Repository.Data;
using eShop.Repository.Repositories.Generics.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eShop.Repository.Repositories.Generics.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EShopDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(EShopDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entity = await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);

            if (entity == null)
                throw new KeyNotFoundException($"Entity with id {id} not found.");

            return entity;
        }


        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync() => await _dbSet.CountAsync();

        public async Task<IEnumerable<T>> GetPaginatedAsync(int page, int pageSize) => await _dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

    }
}
