using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReviewApp.Entities;
using ReviewApp;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocalSqlDb")));

builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<AppDbContext>()
     .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();



builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/Authentication/UserLogin";
    x.AccessDeniedPath = "/denied";
});


var app = builder.Build();

app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();