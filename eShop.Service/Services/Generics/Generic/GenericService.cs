using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.Services.Generics.IGenericService;

namespace eShop.Service.Services.Generics.GenericSerivice
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _repository.GetCountAsync();
        }

        public async Task<IEnumerable<T>> GetPaginatedAsync(int page, int pageSize)
        {
            return await _repository.GetPaginatedAsync(page, pageSize);
        }
    }
}
