using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Wasifu.Data;
using Wasifu.Extensions;
using Wasifu.Services;

var builder = WebApplication.CreateBuilder(args);
const string CookieScheme = CookieAuthenticationDefaults.AuthenticationScheme;
// Add services to the container.

var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WasifuContext>(options => options.UseSqlServer(dbConnection));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();




builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(6);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "wasifuLogins";
});
builder.Services.AddAuthentication(CookieScheme) // Sets the default scheme to cookies
                .AddCookie(CookieScheme, options =>
                {
                    options.LogoutPath = "/logout";
                    options.LoginPath = "/login";
                    options.Cookie = new CookieBuilder()
                    {
                        IsEssential = true,
                        SameSite = SameSiteMode.Lax,
                        SecurePolicy = CookieSecurePolicy.SameAsRequest,
                        Name = ".wasifu.Session.wasifuLogins"
                    };
                });


builder.Services.AddTransient<AuthManager>();


var app = builder.Build();

app.CreateDbIfNotExists();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


