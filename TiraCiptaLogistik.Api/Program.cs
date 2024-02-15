using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using TiraCiptaLogistik.Api;
using TiraCiptaLogistik.Core.DatabaseContexts;
using TiraCiptaLogistik.Core.Interface;
using TiraCiptaLogistik.Core.Repository;
using TiraCiptaLogistik.DataAccess.Interface;
using TiraCiptaLogistik.DataAccess.Repository;
using TiraCiptaLogistik.Domain.Entities;
using TiraCiptaLogistik.Service.Interface;
using TiraCiptaLogistik.Service.Repository;
using Serilog;



var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .WriteTo.BetterStack(sourceToken: builder.Configuration.GetSection("BetterStack").Value)
    //.WriteTo.
    .MinimumLevel.Information()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var services = builder.Services;
// Add services to the container.
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Database
var connectionString = builder.Configuration.GetConnectionString("DbLogistik");

services.AddDbContext<LogistikContext>(options =>
    options.UseSqlServer(connectionString));
services.AddScoped<LogistikContext>();

// Repositori 
services.AddScoped<ICustomerRepository, CustomerRepository>();
services.AddScoped<IPriceRepository, PriceRepository>();
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<ISalesOrderInterfaceRepository, SalesOrderInterfaceRepository>();
services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
services.AddScoped<ISalesOrderDetailRepository, SalesOrderDetailRepository>();

// Register other services, repositories, etc.
builder.Services.AddScoped<ILogistikService, LogistikService>();

// AutoMapper
services.AddAutoMapper(typeof(MappingProfiles));


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


