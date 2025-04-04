// Ignore Spelling: Serivice

using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.Services.Generics.IGeneric;

namespace eShop.Service.Services.Generics.Generic
{
    public class GenericService<T>(IGenericRepository<T> repository) : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository = repository;

        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<T> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(T entity) => await _repository.AddAsync(entity);

        public async Task UpdateAsync(T entity) => await _repository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task<int> GetCountAsync() => await _repository.GetCountAsync();

        public async Task<IEnumerable<T>> GetPaginatedAsync(int page, int pageSize) => await _repository.GetPaginatedAsync(page, pageSize);
    }
}
