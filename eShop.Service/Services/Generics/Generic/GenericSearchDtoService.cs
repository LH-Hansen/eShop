using AutoMapper;
using eShop.Repository.IEntity;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.Services.Generics.IGeneric;
using Microsoft.Extensions.Caching.Memory;

namespace eShop.Service.Services.Generics.Generic
{
    public class GenericDtoSearchService<TEntity, TDto, TUpsertDto>
        : GenericDtoService<TEntity, TDto, TUpsertDto>, IGenericDtoSearchService<TDto> where TEntity : class, IHasName
    {
        protected readonly IGenericSearchService<TEntity> _searchService;

        public GenericDtoSearchService(
            IGenericSearchService<TEntity> searchService,
            IGenericRepository<TEntity> repository,
            IMapper mapper,
            IMemoryCache cache)
            : base(repository, mapper, cache)
        {
            _searchService = searchService;
        }

        public virtual async Task<IEnumerable<TDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm, string cacheKey = null)
        {
            if (string.IsNullOrEmpty(cacheKey))
                return _mapper.Map<IEnumerable<TDto>>(await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm));

            return _mapper.Map<IEnumerable<TDto>>(
                await _cache.GetOrCreateAsync(cacheKey, async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                    return await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);
                })
            );
        }
    }
}
