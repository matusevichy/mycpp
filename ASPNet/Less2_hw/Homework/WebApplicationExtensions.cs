namespace Homework;

public static class WebApplicationExtensions
{
    public static WebApplicationBuilder AddRender(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ExamplesFactory>();
        builder.Services.AddSingleton<Render>();
        return builder;
    }
    
    public static WebApplicationBuilder AddRender(this WebApplicationBuilder builder, RenderOptions renderOptions)
    {
        var env = builder.Environment;
        var examplesFactory = new ExamplesFactory();
        builder.Services.AddSingleton<ExamplesFactory>();
        builder.Services.AddSingleton<Render>(p => new Render(env, examplesFactory, renderOptions));
        return builder;
    }
}