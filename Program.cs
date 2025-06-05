using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Repositories;
using MarketApi.Interfacies;
using MarketApi.Mappers;
using MarketApi.Models;
using MarketApi.Repositories;
using MarketApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var databaseConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    options.UseSqlServer(databaseConnectionString);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>c.SwaggerDoc("v1", new OpenApiInfo { Title = "Market application APIs", Version = "v1" }));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IMeasurementRepository, MeasurementRepository>();

builder.Services.AddScoped<IProductServise, ProductServise>();
builder.Services.AddScoped<IMeasurementService, MeasurementService>();

builder.Services.AddAutoMapper(op =>
{
    op.AddMaps(typeof(ProductProfile).Assembly);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{    
    app.UseSwagger();
    app.UseSwaggerUI(op => op.EnableTryItOutByDefault());          
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
