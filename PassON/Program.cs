

using Microsoft.EntityFrameworkCore;
using PassON.Models;
/**
* Look at default appsetting file
*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRespository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

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
 * Middleware taht set up default routing for MVC
 */

app.MapDefaultControllerRoute();


/**
 * start the application
 */

app.Run();
