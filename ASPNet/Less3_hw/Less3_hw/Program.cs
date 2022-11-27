using Less3_hw.DAL.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DatabaseContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("Default")));
var app = builder.Build();

app.UseRouting();
app.MapRazorPages();
app.UseStaticFiles();
app.Run();
