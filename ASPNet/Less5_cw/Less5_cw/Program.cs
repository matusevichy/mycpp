using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Less5_cw.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Less5_cwContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Less5_cwContext") ?? throw new InvalidOperationException("Connection string 'Less5_cwContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
