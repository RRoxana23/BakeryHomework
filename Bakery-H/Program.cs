using Bakery_H.Repositories.Interfaces;
using Bakery_H.Repositories;
using Bakery_H.Services.Interfaces;
using Bakery_H.Services;
using Bakery_H.Models;
using Bakery_Homework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Bakery_Homework.Services.Interfaces;
using Bakery_Homework.Services;
using Bakery_Homework.Repositories.Interfaces;
using Bakery_Homework.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Azure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<BakeryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BakeryDatabase")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register Identity services
builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<BakeryDbContext>()
    .AddDefaultTokenProviders();

// Add custom services and repositories
builder.Services.AddScoped<DbContext, BakeryDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILocatiiService, LocatiiService>();
builder.Services.AddScoped<ILocatiiRepository, LocatiiRepository>();
builder.Services.AddScoped<IAngajatiService, AngajatiService>();
builder.Services.AddScoped<IAngajatiRepository, AngajatiRepository>();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Configure authentication and authorization
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/User/AccessDenied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Administrator"));
    options.AddPolicy("RequireClientRole", policy => policy.RequireRole("Client"));
});

var app = builder.Build();

// Seed roles
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    await SeedRolesAsync(roleManager);
    await SeedDefaultAdminAsync(userManager);
}

async Task SeedRolesAsync(RoleManager<IdentityRole<Guid>> roleManager)
{
    var roles = new[] { "Administrator", "Client" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid> { Name = role });
        }
    }
}

async Task SeedDefaultAdminAsync(UserManager<User> userManager)
{
    var adminEmail = "admin@bakery.com";

    string imageUrl = "https://static4.depositphotos.com/1000816/514/i/450/depositphotos_5140926-stock-photo-closeup-of-employee-in-the.jpg";
    byte[] imageBytes = new byte[1];
    imageBytes[0] = 0;

    using (HttpClient client = new HttpClient())
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync(imageUrl);
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.Headers.ContentType.MediaType.StartsWith("image"))
                {
                    imageBytes = await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    Debug.WriteLine("Imaginea de la URL nu este într-un format valid.");
                }
            }
            else
            {
                Debug.WriteLine("Cererea pentru imagine nu a reușit.");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"A apărut o excepție: {ex.Message}");
        }

    }

    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var adminUser = new User
            {
                UserName = adminEmail,
                Email = adminEmail,
                Nume = "Admin",
                Prenume = "UserAdmin",
                ProfileImage = imageBytes
            };
            var result = await userManager.CreateAsync(adminUser, "Admin@123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Administrator");
            }
        }
}

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

app.UseAuthentication(); // Add this line
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
