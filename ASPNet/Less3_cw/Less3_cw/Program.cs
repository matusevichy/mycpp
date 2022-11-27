var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/{action}/{a:decimal:range(0,1000)}/{b:decimal:range(0,1000)}", (string action, decimal a, decimal b) =>
{
    switch (action)
    {
        case "add":
            return $"{a}+{b}={a + b}";
            break;
        case "substract":
            return $"{a}-{b}={a - b}";
            break;
        case "multiplication":
            return $"{a}*{b}={a * b}";
            break;
        case "division":
            if (b==0)
            {
                return "Division by zero!";
            }
            else
            {
                return $"{a}/{b}={a / b}";
            }
            break;
        default:
            break;
    }
    return $"action: {action}, a:{a}, b: {b}";
});

app.Run();
