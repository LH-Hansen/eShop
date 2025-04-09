using eShop.Repository.IEntity;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.Services.Generics.IGeneric;

namespace eShop.Service.Services.Generics.Generic
{
    public class GenericSearchService<T> : GenericService<T>, IGenericSearchService<T> where T : class, IHasName
    {
        protected readonly IGenericService<T> _service;

        public GenericSearchService(IGenericService<T> service, IGenericRepository<T> repository) : base(repository)
        {
            _service = service;
        }

        public async Task<IEnumerable<T>> GetPaginatedSearchAsync(int page, int pageSize, string? searchTerm = null)
        {
            IEnumerable<T> entities = await _service.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
                entities = entities.Where(b => b.Name.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));

            List<T> paginatedEntities = entities.Skip((page - 1) * pageSize)
                                                .Take(pageSize)
                                                .ToList();
            return paginatedEntities;
        }
    }
}
