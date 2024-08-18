using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IOrdersProvider, OrdersProvider>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<OrdersDbContext>(options => {
    options.UseInMemoryDatabase("Orders");
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
