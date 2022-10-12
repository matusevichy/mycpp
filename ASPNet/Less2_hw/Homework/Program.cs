using Homework;

var builder = WebApplication.CreateBuilder(args);
builder.AddRender();
builder.Services.AddSingleton<IStatisticService, StatisticService>();

var app = builder.Build();

app.UseMiddleware<CheckMultiplicationTableMiddleware>();

app.Run();