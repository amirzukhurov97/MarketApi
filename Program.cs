using FluentValidation;
using MarketApi.DTOs.Address;
using MarketApi.DTOs.CurrencyExchange;
using MarketApi.DTOs.Customer;
using MarketApi.DTOs.Market;
using MarketApi.DTOs.Measurement;
using MarketApi.DTOs.Organization;
using MarketApi.DTOs.OrganizationType;
using MarketApi.DTOs.Product;
using MarketApi.DTOs.ProductCategory;
using MarketApi.DTOs.Purchase;
using MarketApi.DTOs.Sale;
using MarketApi.FluentValidation;
using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Infrastructure.Repositories;
using MarketApi.Mappers;
using MarketApi.Repositories;
using MarketApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

var databaseConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    options.UseSqlServer(databaseConnectionString).EnableSensitiveDataLogging();
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Market application APIs", Version = "v1" }));
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IMeasurementRepository, MeasurementRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IOrganizationTypeRepository, OrganizationTypeRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ICurrencyExchangeRepository, CurrencyExchangeRepository>();
builder.Services.AddScoped<IMarketRopository, MarketRepository>();

builder.Services.AddScoped<IGenericService<ProductRequest, ProductUpdateRequest, ProductResponse>, ProductServise>();
builder.Services.AddScoped<IGenericService<MeasurementRequest, MeasurementUpdateRequest, MeasurementResponse>, MeasurementService>();
builder.Services.AddScoped<IGenericService<ProductCategoryRequest, ProductCategoryUpdateRequest, ProductCategoryResponse>, ProductCategoryService>();
builder.Services.AddScoped<IGenericService<CustomerRequest, CustomerUpdateRequest, CustomerResponse>, CustomerService>();
builder.Services.AddScoped<IGenericService<AddressRequest, AddressUpdateRequest, AddressResponse>, AddressService>();
builder.Services.AddScoped<IGenericService<OrganizationRequest, OrganizationUpdateRequest, OrganizationResponse>, OrganizationService>();
builder.Services.AddScoped<IGenericService<OrganizationTypeRequest, OrganizationTypeUpdateRequest, OrganizationTypeResponse>, OrganizationTypeService>();
builder.Services.AddScoped<IGenericService<PurchaseRequest, PurchaseUpdateRequest, PurchaseResponse>, PurchaseService>();
builder.Services.AddScoped<IGenericService<SaleRequest, SaleUpdateRequest, SaleResponse>, SaleService>();
builder.Services.AddScoped<IGenericService<CurrencyExchangeRequest, CurrencyExchangeUpdateRequest, CurrencyExchangeResponse>, CurrencyExchangeService>();
builder.Services.AddScoped<MarketService>();

builder.Services.AddAutoMapper(op =>
{
    op.AddMaps(typeof(ProductProfile).Assembly);
    op.AddMaps(typeof(OrganizationProfile).Assembly);
    op.AddMaps(typeof(OrganizationTypeProfile).Assembly);
    op.AddMaps(typeof(ProductCategoryProfile).Assembly);
    op.AddMaps(typeof(MeasurementProfile).Assembly);
    op.AddMaps(typeof(AddressProfile).Assembly);
    op.AddMaps(typeof(CustomerProfile).Assembly);
    op.AddMaps(typeof(PuschaseProfile).Assembly);
    op.AddMaps(typeof(SaleProfile).Assembly);
    op.AddMaps(typeof(ReturnCustomerProfile).Assembly);
    op.AddMaps(typeof(ReturnOrganizationProfile).Assembly);
    op.AddMaps(typeof(CurrencyExchangeProfile).Assembly);
    op.AddMaps(typeof(MarketProfile).Assembly);
});
builder.Services.AddValidatorsFromAssemblyContaining<PurchaseRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(op => op.EnableTryItOutByDefault());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
