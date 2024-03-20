using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using crm.Areas.Admin.Models;
using crm.Areas.Admin.Data;
using crm.Data;
using crm.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<crmContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("crmContext") ?? throw new InvalidOperationException("Connection string 'crmContext' not found.")));

var builder2 = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ViewContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("crmContext") ?? throw new InvalidOperationException("Connection string 'crmContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    SeedData.Initialize(services);
//}

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

//В приведенном ниже коде exists применяет ограничение, связанное с тем, что маршрут должен соответствовать области.
app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
