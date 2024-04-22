using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Database;
using MyBlog.Data.Extensions;
using MyBlog.Entity.Entities;
using MyBlog.Service.Describers;
using MyBlog.Service.Extensions;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions() 
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 5000
    })
    .AddRazorRuntimeCompilation();
builder.Services.LoadDataLayerExtensions(builder.Configuration);
builder.Services.LoadServiceLayerExtensions();
builder.Services.AddSession();
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityDescriber>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(cfg => 
{
    cfg.LoginPath = new PathString("/Admin/Auth/Login");
    cfg.LogoutPath = new PathString("/Admin/Auth/LogOut");
    cfg.Cookie = new CookieBuilder 
    {
     Name = "MyBlogProject",
     HttpOnly = true,
     SameSite = SameSiteMode.Strict,
     SecurePolicy = CookieSecurePolicy.Always,
    };
    cfg.SlidingExpiration = true;
    cfg.ExpireTimeSpan = TimeSpan.FromDays(1);
    cfg.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
