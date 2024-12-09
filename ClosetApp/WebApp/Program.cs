using Microsoft.EntityFrameworkCore;
using WebApp.Services;
using Microsoft.AspNetCore.Identity;
using WebApp.Models;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<RealDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

/*builder.Services.AddDbContext<TestDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("TestConnetionString");
    options.UseSqlServer(connectionString);
});*/
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});



var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
   
    app.UseHsts();
}

app.UseAuthorization();
/*zxcc
app.Use(async (context, next) =>
{
    var path = context.Request.Path;
    if (!path.StartsWithSegments("/Account") && context.Session.GetString("Username")==null)
    if(!context.Session.Keys.Contains("User_ID") && context.Request.Path != "Account/Login")
        {
            context.Response.Redirect("Account/Login");
            return;
        }
    await next();
});C*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
