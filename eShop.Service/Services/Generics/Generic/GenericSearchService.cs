using eShop.Repository.IEntity;
using eShop.Service.Services.Generics.IGeneric;

namespace eShop.Service.Services.Generics.Generic
{
    public class GenericSearchService<T>(IGenericService<T> service) : IGenericSearchService<T> where T : class, IHasName
    {
        protected readonly IGenericService<T> _repository = service;

        public async Task<IEnumerable<T>> GetPaginatedSearchAsync(int page, int pageSize, string? searchTerm = null)
        {
            IEnumerable<T> entities = await _repository.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
                entities = entities.Where(b => b.Name.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));

            List<T> paginatedEntities = entities.Skip((page - 1) * pageSize)
                                                .Take(pageSize)
                                                .ToList();
            return paginatedEntities;
        }
    }
}
