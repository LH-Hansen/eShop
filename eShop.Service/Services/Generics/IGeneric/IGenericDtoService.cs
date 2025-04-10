using System.Linq.Expressions;

namespace eShop.Service.Services.Generics.IGeneric
{
    public interface IGenericDtoService<TEntity, TDto, TUpsertDto>
    {
        Task AddAsync(TUpsertDto dto, string invalidateCacheKey = null);
        Task DeleteAsync(int id, string invalidateCacheKey = null);
        Task<IEnumerable<TDto>> GetAllAsync(string cacheKey = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TDto> GetByIdAsync(int id, string cacheKey = null);
        Task UpdateAsync(TUpsertDto dto, string invalidateCacheKey = null);
    }
}