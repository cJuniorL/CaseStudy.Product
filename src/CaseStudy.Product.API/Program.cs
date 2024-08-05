using CaseStudy.Product.API.Configurations;
using CaseStudy.Product.API.Handlers;
using CaseStudy.Product.Application.Abstractions;
using CaseStudy.Product.Application.Mappers;
using CaseStudy.Product.Infra.Data;
using CaseStudy.Product.Infra.Settings;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICancellationTokenAcessor>(sp => new CancellationTokenAcessor(sp.GetService<IHttpContextAccessor>()?.HttpContext?.RequestAborted ?? default));

builder.Services.AddMappers();
builder.Services.AddUseCases();
builder.Services.AddProviders();
builder.Services.AddValidators();
builder.Services.AddRepositories();

builder.Services.AddAutoMapper(typeof(ProductMapper));

builder.Services.AddDbContext<ProductDbContext>();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("Database"));

builder.Services.AddMemoryCache();

builder.Services.AddMassTransitKafkaConfig(builder.Configuration);

var app = builder.Build();

app.UseErrorHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
