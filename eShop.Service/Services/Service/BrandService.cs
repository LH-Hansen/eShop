using eShop.Repository.Entities;
using eShop.Repository.Repositories.IRepository;
using eShop.Service.DTO;

namespace eShop.Service.Services.Service
{
    public class BrandService(IGenericRepository<Brand> brandRepository)
    {
        private readonly IGenericRepository<Brand> _brandRepository = brandRepository;

        public async Task<BrandDTO> GetByIdAsync(int id) => ConvertToDTO(await _brandRepository.GetByIdAsync(id));

        public async Task<IEnumerable<BrandDTO>> GetAllAsync()
        {
            ICollection<BrandDTO> brandColletion = [];

            foreach (Brand brand in await _brandRepository.GetAllAsync())
            {
                brandColletion.Add(ConvertToDTO(brand));
            }

            return brandColletion;
        }

        public async Task AddAsync(BrandDTO brandDTO) => await _brandRepository.AddAsync(ConvertToBrand(brandDTO));

        public async Task UpdateAsync(BrandDTO brandDTO) => await _brandRepository.UpdateAsync(ConvertToBrand(brandDTO));

        public async Task DeleteAsync(int id) => await _brandRepository.DeleteAsync(id);

        public static BrandDTO ConvertToDTO(Brand brand)
        {
            BrandDTO brandDTO = new()
            {
                Id = brand.Id,
                Name = brand.Name,
                Description = brand.Description,
                Products = brand.Products
            };

            return brandDTO;
        }

        public static Brand ConvertToBrand(BrandDTO brandDTO)
        {
            Brand brand = new()
            {
                Id = brandDTO.Id,
                Name = brandDTO.Name,
                Description = brandDTO.Description,
                Products = brandDTO.Products
            };

            return brand;
        }

    }
}
