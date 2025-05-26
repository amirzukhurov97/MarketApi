using MarketApi.Interfacies;
using MarketApi.Mappers;
using MarketApi.Models;
using MarketApi.Repositories;
using MarketApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>c.SwaggerDoc("v1", new OpenApiInfo { Title = "Market application APIs", Version = "v1" }));
builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IOrganizationRepository, OrganizationRepository>();

builder.Services.AddScoped<IProductServise, ProductServise>();

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
