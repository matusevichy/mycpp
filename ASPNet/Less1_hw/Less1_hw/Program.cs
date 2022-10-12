var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStatic();
app.Run();

static class ExtWebApp
{
    public static IApplicationBuilder UseStatic(this IApplicationBuilder app)
    {
        return app.Use(async (context, next) =>
        {
            var path=(context.Request.Path).ToString().Substring(1);
            if (path.Length > 0)
            {
                try
                {
                    path = "wwwroot/" + path;
                    using (var streamReader = new StreamReader(path))
                    {
                        await context.Response.WriteAsync(streamReader.ReadToEnd());
                        await next();
                    }
                }
                catch (FileNotFoundException)
                {

                    context.Response.StatusCode = 404;
                }
            }
        });
    }
}