using Microsoft.EntityFrameworkCore;
using PresProductCategory.DAL.Database;
using PresProductCategory.DAL.Repositories;
using PresProductCategory.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<ShopContext>(
    b => b.UseSqlServer(builder.Configuration.GetConnectionString("Dev"))
);

// ADD Repositories from DAL
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// ADD Services from BLL
// TODO

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
