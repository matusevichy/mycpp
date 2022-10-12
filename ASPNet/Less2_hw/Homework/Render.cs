namespace Homework;

public class Render
{
    private readonly IHostEnvironment _env;
    private readonly ExamplesFactory _examplesFactory;
    private readonly RenderOptions _renderOptions;

    public Render(IHostEnvironment env, ExamplesFactory examplesFactory, RenderOptions? renderOptions = null)
    {
        _renderOptions = renderOptions ?? new RenderOptions();
        _env = env;
        _examplesFactory = examplesFactory;
    }

    public async Task<string> RenderIndex()
    {
        var template = await GetTemplate(_renderOptions.Index);
        var form = await MakeExamples();
        return template.Replace("@RenderBody()", form);
    }

    public async Task<string> RenderResult(IEnumerable<Result> results)
    {
        var table = await MakeTable(results);
        var template = await GetTemplate(_renderOptions.Result);
        return template.Replace("@RenderBody()", table);
    }

    public async Task<string> RenderStatistic(List<Statistic> statistics)
    {
        var table = await MakeStatisticTable(statistics);
        var template = await GetTemplate(_renderOptions.Statistic);
        return template.Replace("@RenderStatistic", table);
    }
    
    private async Task<string> MakeStatisticTable(List<Statistic> statistics)
    {
        var template = await GetTemplate(_renderOptions.StatisticRow);
        return statistics.Aggregate("", (current, statistics) => current + template.Replace("@date", statistics.date.ToString())
        .Replace("@trueAnswers", statistics.trueAnswersCount.ToString())
        .Replace("@falseAnswers", statistics.falseAnswersCount.ToString()));
    }

    private async Task<string> MakeTable(IEnumerable<Result> results)
    {
        var template = await GetTemplate(_renderOptions.Row);
        var i = 1;
        return results.Aggregate("", (current, result) => current + template.Replace("@number", $"{i++}")
            .Replace("@answer", $"{result.Answer}")
            .Replace("@a", $"{result.A}")
            .Replace("@b", $"{result.B}")
            .Replace("@rightAnswer", $"{result.RightAnswer}")
            .Replace("@class", result.IsRight ? "right" : "wrong"));
    }
    
    private async Task<string> MakeExamples()
    {
        var template = await GetTemplate(_renderOptions.Input);
        var examples = _examplesFactory.GetExamples(10)
            .Select(e => template.Replace("@a", $"{e.a}").Replace("@b", $"{e.b}"));
        return string.Join("", examples);
    }
    
    private async Task<string> GetTemplate(string filename) => 
        await File.ReadAllTextAsync(Path.Combine(_env.ContentRootPath, _renderOptions.TemplateDir, filename));
}

public class RenderOptions
{
    public string TemplateDir { get; set; } = "template";
    public string Index { get; set; } = "index.html";
    public string Result { get; set; } = "results.html";
    public string Input { get; set; } = "_input.html";
    public string Row { get; set; } = "_row.html";
    public string Statistic { get; set; } = "statistic.html";
    public string StatisticRow { get; set; } = "statistic_row.html";
}