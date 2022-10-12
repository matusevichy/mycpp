using System.Text.RegularExpressions;

namespace Homework;

public class CheckMultiplicationTableMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CheckMultiplicationTableMiddleware> _logger;
    private readonly Render _render;
    private readonly IStatisticService statisticService;

    public CheckMultiplicationTableMiddleware(RequestDelegate next,
        ILogger<CheckMultiplicationTableMiddleware> logger,
        Render render,
        IStatisticService statisticService
    )
    {
        _next = next;
        _logger = logger;
        _render = render;
        this.statisticService = statisticService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        var method = context.Request.Method;
        if (method == HttpMethods.Get)
        {
            await HandleGetRequest(context);
        }
        else if (method == HttpMethods.Post)
        {
            await HandlePostRequest(context);
        }
    }

    private async Task HandleGetRequest(HttpContext context)
    {
        var request = context.Request;
        var path = request.Path.Value.Substring(1);
        if (path == "stat")
        {
            await context.Response.WriteAsync(await _render.RenderStatistic(statisticService.GetStatistic()));
        }
        else
        {
            _logger.LogDebug("Handle GET Request");
            await context.Response.WriteAsync(await _render.RenderIndex());
        }
    }

    private async Task HandlePostRequest(HttpContext context)
    {
        _logger.LogDebug("Handle POST Request");
        var form = context.Request.Form;
        var results = GetResults(form);
        Statistic item = new Statistic(DateTime.Now, results.Count(r => r.IsRight == true), results.Count(r => r.IsRight == false));
        statisticService.Add(item);
        await context.Response.WriteAsync(await _render.RenderResult(results));
    }

    private IEnumerable<Result> GetResults(IFormCollection form)
    {
        var regex = new Regex(@"ex-(?<a>\d+)-(?<b>\d+)");
        var list = new List<Result>();
        foreach (var f in form)
        {
            _logger.LogDebug("{}: {}", f.Key, f.Value);
            var match = regex.Match(f.Key);
            if (!int.TryParse(match.Groups["a"].Value, out var a)) continue;
            if (!int.TryParse(match.Groups["b"].Value, out var b)) continue;
            if (!int.TryParse(f.Value, out var ans)) continue;
            list.Add(new Result(a, b, ans, a*b, a*b == ans));
        }
        return list;
    }
}