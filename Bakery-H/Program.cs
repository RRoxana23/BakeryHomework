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

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<DbContext, BakeryDbContext>();

builder.Services.AddScoped<ILocatiiService, LocatiiService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILocatiiRepository, LocatiiRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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