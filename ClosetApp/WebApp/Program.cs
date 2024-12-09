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

builder.Services.AddDistributedMemoryCache(); // Required to store session in memory
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout as needed
    options.Cookie.HttpOnly = true; // Make session cookie accessible only to the server
    options.Cookie.IsEssential = true; // Ensure the cookie is essential for the app to work
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
