var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISingletonCounter, SingletonCounter>();
builder.Services.AddSingleton<ITransientCounter, TransientCounter>();

var app = builder.Build();
app.UseMiddleware<SetCounter>();
app.UseMiddleware<GetCounter>();
app.Run();

interface ICounter
{
    public int Count { get; } 
    void Increment();
}

interface ISingletonCounter : ICounter
{
    
}

interface IScopeCounter : ICounter
{

}

interface ITransientCounter : ICounter
{

}

class BaseCounter : ICounter
{
    int count;
    public int Count => count;

    public void Increment()
    {
        count++;
    }
}

class SingletonCounter : BaseCounter, ISingletonCounter
{

}

class ScopeCounter: BaseCounter, IScopeCounter
{

}

class TransientCounter: BaseCounter, ITransientCounter
{

}

class SetCounter
{
    private readonly RequestDelegate next;
    private readonly ICounter[] counters;
    public SetCounter(RequestDelegate next, ISingletonCounter singletonCounter, ITransientCounter transientCounter)
    {
        this.next = next;
        this.counters = new ICounter[] { singletonCounter, transientCounter };
    }

    public async Task InvokeAsync(HttpContext context)
    {
        foreach (var counter in counters)
        {
            counter.Increment();
        }
        await next(context);
    }
}

class GetCounter
{
    ISingletonCounter singletonCounter;
    ITransientCounter transientCounter;
    public GetCounter(RequestDelegate next, ISingletonCounter singletonCounter, ITransientCounter transientCounter)
    {
        this.singletonCounter = singletonCounter;
        this.transientCounter = transientCounter;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.WriteAsync($"Singleton counter: {singletonCounter.Count}\nTransient counter: {transientCounter.Count}");
    }
}