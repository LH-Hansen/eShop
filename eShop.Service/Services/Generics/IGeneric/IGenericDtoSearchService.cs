namespace eShop.Service.Services.Generics.IGeneric
{
    public interface IGenericDtoSearchService<TDto>
    {
        Task<IEnumerable<TDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm, string cacheKey = null);
    }
}