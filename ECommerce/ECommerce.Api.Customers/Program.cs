using ECommerce.Api.Customers.Db;
using ECommerce.Api.Customers.Interfaces;
using ECommerce.Api.Customers.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICustomersProvider, CustomersProvider>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<CustomersDbContext>(options => {
    options.UseInMemoryDatabase("Customers");
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
