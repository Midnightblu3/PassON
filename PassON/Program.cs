

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using PassON.Models;
/**
* Look at default appsetting file
*/
var builder = WebApplication.CreateBuilder(args);

/**
 * Add Dependency injection
 */
builder.Services.AddScoped<ICategoryRepository, CategoryRespository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddScoped<IOrderRespository, OrderRepository>();

/**
 * Add session service
 */
builder.Services.AddSession();

/**
 * Add http context accessor
 */
builder.Services.AddHttpContextAccessor();

/**
 * Add services that make sure asp.net know about MVC
 */
builder.Services.AddControllersWithViews();

/**
 * Register PassONDbcontext class as the Dbcontext for the application
 */

builder.Services.AddDbContext<PassONDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:PassONDbContextConnection"]
        );
});

var app = builder.Build();

/**
 * Middleware that look for incoming static file or in www.root file
 */
app.UseStaticFiles();

/**
 * if it is in Development environment using developer Exception page
 */
if (app.Environment.IsDevelopment())
{

    app.UseDeveloperExceptionPage();
}

/**
 * Middleware that set up default routing for MVC


app.MapDefaultControllerRoute();

 */

/**
 * Middleware that set up routing pattern for MVC
 */

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/**
 * Session middleware
 */

app.UseSession();

/**
 * add initial data to database
 */

DbInitializer.Initialize(app);

/**
 * start the application
 */

app.Run();
