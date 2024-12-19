using Devcom.Application.Interfaces;
using Devcom.Application.Services;
using Devcom.Domain.Enums;
using Devcom.Domain.Interfaces;
using Devcom.Infrastracture.Data;
using Devcom.Infrastracture.Data.Entities;
using Devcom.Infrastracture.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
        .AddCookie()
        .AddGoogle(options =>
        {
            options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
            options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
        });

builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!dbContext.Announcements.Any())
    {
        dbContext.Announcements.AddRange(
            new AnnouncementEntity
            {
                Title = "Продається холодильник",
                Description = "Відмінний стан, мало використовувався",
                CreatedDate = DateTime.Now,
                Status = Status.active,
                Category = "Побутова техніка",
                SubCategory = "Холодильники"
            },
            new AnnouncementEntity
            {
                Title = "Ноутбук Asus ROG",
                Description = "Ігровий ноутбук, RTX 3060",
                CreatedDate = DateTime.Now,
                Status = Status.active,
                Category = "Комп'ютерна техніка",
                SubCategory = "Ноутбуки"
            }
        );

        dbContext.SaveChanges();
    }
}



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

