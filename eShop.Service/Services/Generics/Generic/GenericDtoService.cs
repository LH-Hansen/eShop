using AutoMapper;
using eShop.Repository.Repositories.Generics.Interface;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace eShop.Service.Services.Generics.IGeneric
{
    public class GenericDtoService<TEntity, TDto, TUpsertDto> : IGenericDtoService<TEntity, TDto, TUpsertDto> where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        protected readonly IMemoryCache _cache;

        public GenericDtoService(
            IGenericRepository<TEntity> repository,
            IMapper mapper,
            IMemoryCache cache)
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cache;
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync(string cacheKey = null, params Expression<Func<TEntity, object>>[] includes)
        {
            if (string.IsNullOrEmpty(cacheKey))
                return _mapper.Map<IEnumerable<TDto>>(await _repository.GetAllAsync(includes));

            return _mapper.Map<IEnumerable<TDto>>(
                await _cache.GetOrCreateAsync(cacheKey, async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                    return await _repository.GetAllAsync(includes);
                })
            );
        }

        public virtual async Task<TDto> GetByIdAsync(int id, string cacheKey = null)
        {
            if (string.IsNullOrEmpty(cacheKey))
                return _mapper.Map<TDto>(await _repository.GetByIdAsync(id));

            return _mapper.Map<TDto>(
                await _cache.GetOrCreateAsync(cacheKey, async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                    return await _repository.GetByIdAsync(id);
                })
            );
        }

        public virtual async Task AddAsync(TUpsertDto dto, string invalidateCacheKey = null)
        {
            await _repository.AddAsync(_mapper.Map<TEntity>(dto));
            if (!string.IsNullOrEmpty(invalidateCacheKey))
                _cache.Remove(invalidateCacheKey);
        }

        public virtual async Task UpdateAsync(TUpsertDto dto, string invalidateCacheKey = null)
        {
            await _repository.UpdateAsync(_mapper.Map<TEntity>(dto));
            if (!string.IsNullOrEmpty(invalidateCacheKey))
                _cache.Remove(invalidateCacheKey);
        }

        public virtual async Task DeleteAsync(int id, string invalidateCacheKey = null)
        {
            await _repository.DeleteAsync(id);
            if (!string.IsNullOrEmpty(invalidateCacheKey))
                _cache.Remove(invalidateCacheKey);
        }
    }
}

