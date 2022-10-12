var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Run(async context =>
{
    var path = context.Request.Path;
    var queries = context.Request.Query;
    int result = 0;
    int a = 0, b =0;
    if (queries.ContainsKey("a"))
    {
       int.TryParse(queries["a"].ToString(), out a);
    }
    if (queries.ContainsKey("b"))
    {
        int.TryParse(queries["b"].ToString(), out b);
    }

    switch (path)
    {
        case "/add":
            result = a + b;
            break;
        case "/div":
            result = a / b;
            break;
        default:
            break;
    }
    await context.Response.WriteAsync(result.ToString());
});

app.Run();