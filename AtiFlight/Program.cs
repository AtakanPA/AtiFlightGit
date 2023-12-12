using AtiFlight.Context;
using AtiFlight.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthDbContextConnection' not found.");


builder.Services.AddControllersWithViews();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));




});
builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/LogIn/Index";
    x.ExpireTimeSpan=TimeSpan.FromMinutes(30);
    x.SlidingExpiration = true; // Oturumun sürekli uzatýlmasýný saðlar
});



builder.Services.AddDbContext<MyContext>();
builder.Services.AddIdentity<User, AppRole>(options =>
{
    // Þifre gereksinimleri (opsiyonel)
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.User.AllowedUserNameCharacters = "abcdefghijklýçüðömnopqrstþuvwxyzABCDEFGHIJKLMNOPQRSÞÇÖÜÝÐTUVWXYZ0123456789-._@+";
    

    // Kullanýcý adý ve email gereksinimleri
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<MyContext>();
builder.Services.ConfigureApplicationCookie(Options =>
{
    Options.Cookie.HttpOnly = true;
    Options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    Options.AccessDeniedPath = new PathString("/Home/Index");
    Options.LoginPath = "/LogIn/Index";
    Options.SlidingExpiration = true;

}
);
// Add services to the container.

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

app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
