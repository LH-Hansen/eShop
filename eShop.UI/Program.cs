using eShop.Repository.Data;
using eShop.Repository.Repositories.IRepository;
using eShop.Repository.Repositories.Repository;
using eShop.Service.Services.IService;
using eShop.Service.Services.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<EShopDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=eShop;Trusted_Connection=True;"))
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddScoped(typeof(IGenericService<>), typeof(GenericService<>))
            .BuildServiceProvider();

        var brandService = serviceProvider.GetService<IGenericService<eShop.Repository.Entities.Brand>>();

        if (brandService != null)
        {
            var brands = await brandService.GetAllAsync();
            foreach (var brand in brands)
            {
                Console.WriteLine($"Brand Id: {brand.Id}, Name: {brand.Name}, Description: {brand.Description}");
            }
        }
        else
        {
            Console.WriteLine("Brand service not found.");
        }

        serviceProvider.Dispose();
    }
}