using Microsoft.EntityFrameworkCore;
using BoletoAppSol.Data.Context;
using BoletoAppSol.Data.Interfaces;
using BoletoAppSol.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<BoletoContext>(options => options.UseInMemoryDatabase("DbBoletos"))

builder.Services.AddDbContext<BoletoContext>();

builder.Services.AddScoped<IBusRepository, BusRepository>();

builder.Services.AddScoped<IRutaRepository, RutaRepository>();

builder.Services.AddScoped<IAsientoRepository, AsientoRepository>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
