using eShop.Repository.IEntity;

namespace eShop.Service.Services.Generics.IGeneric
{
    public interface IGenericSearchService<T> where T : class, IHasName
    {
        Task<IEnumerable<T>> GetPaginatedSearchAsync(int page, int pageSize, string? searchTerm = null);
    }
}