
List<Counter> counters = new List<Counter>();

for (int i = 0; i < 10; i++)
{
    counters.Add(new Counter());
}

counters.ForEach(t => t.Run());

Thread.Sleep(100);

counters.ForEach(t => { t.thread.Interrupt(); Console.WriteLine($"Counter {t.thread.Priority}: {t.Count}"); });

for (int i = 0; i < counters.Count/2; i++)
{
    counters[i].Count = 0;
    counters[i].Run();
    counters[i].thread.Priority = ThreadPriority.Highest;
}

for (int i = counters.Count / 2; i < counters.Count; i++)
{
    counters[i].Count = 0;
    counters[i].Run();
    counters[i].thread.Priority = ThreadPriority.Lowest;
}

Thread.Sleep(100);

counters.ForEach(t => { t.thread.Interrupt(); Console.WriteLine($"Counter {t.thread.Priority}: {t.Count}"); });


class Counter
{
    public ulong Count { get; set; }
    public Thread thread { get; set; }

    public void Run()
    {
        thread = new Thread(() =>
        {
            while (true)
            {
                try
                {
                    Count++;
                    Thread.Sleep(1);
                }
                catch (Exception)
                {
                    break;
                }
            }
        });
        thread.Start();
    }
}

