﻿using eShop.Repository.Data;
using eShop.Repository.Repositories.Generics.Interface;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException($"Brand with id {id} not found.");

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
