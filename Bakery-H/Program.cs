using Bakery_H.Repositories.Interfaces;
using Bakery_H.Repositories;
using Bakery_H.Services.Interfaces;
using Bakery_H.Services;
using Bakery_Homework.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<BakeryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BakeryDatabase")));

// Adaugă serviciile și repository-urile în containerul de injecție a dependențelor
builder.Services.AddScoped<ILocatiiService, LocatiiService>();
builder.Services.AddScoped<ILocatiiRepository, LocatiiRepository>();

// Adaugă serviciul pentru controlere
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Restul configurației rămâne neschimbată
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

