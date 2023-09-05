using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HSRC_RMS.Helpers;
using Microsoft.AspNetCore.Identity; // Add this using directive
using HSRC_RMS.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the configuration for accessing appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");


// Register the IMemoryCache service for session
//builder.Services.AddMemoryCache();

// Register the DbContext using Entity Framework Core
builder.Services.AddDbContext<RmsDbConnect>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);





// Register the IRepository<T> implementation
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromHours(10);
    options.Cookie.IsEssential = true;
});



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

// Use session middleware
app.UseSession();

// Use Identity
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "createGift",
    pattern: "GiftRegister/Index",
    defaults: new { controller = "GiftRegister", action = "Index" }
);

//app.MapControllerRoute(
//    name: "fileUpload",
//    pattern: "LicenseMActivationUser/Index", // Define a route for handling file uploads
//    defaults: new { controller = "LicenseMActivationUser", action = "Index" } // pecify the controller and action for file uploads
//);


app.Run();
