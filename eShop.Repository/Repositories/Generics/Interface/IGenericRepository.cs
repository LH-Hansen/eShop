using System.Linq.Expressions;

namespace eShop.Repository.Repositories.Generics.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task UpdateAsync(T entity);
        Task<int> GetCountAsync();
        Task<IEnumerable<T>> GetPaginatedAsync(int page, int pageSize);
    }
}