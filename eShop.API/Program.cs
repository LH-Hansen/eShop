using eShop.Repository.Data;
using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Generic;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.Mapping;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.IService;
using eShop.Service.Services.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

#if DEBUG
builder.Services.AddDbContext<EShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
});
#else
builder.Services.AddDbContext<EShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Production"));
});
#endif

#region SCOPES
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

builder.Services.AddScoped<IGenericSearchService<Product>, GenericSearchService<Product>>();
builder.Services.AddScoped<IGenericSearchService<Brand>, GenericSearchService<Brand>>();
builder.Services.AddScoped<IGenericSearchService<SubCategory>, GenericSearchService<SubCategory>>();


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
