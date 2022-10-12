Account account = new Account(100000);
ThreadPool.GetAvailableThreads(out int workerThread, out int completionPortThreads);

Console.WriteLine($"On start state: Available - WorkerThreads: {workerThread} CompletionPortThreads: {completionPortThreads}");

ThreadPool.QueueUserWorkItem((o) =>
{
    for (int i = 0; i < 20000; i++)
    {
        account.Deposit(1);
    }
});
ThreadPool.GetAvailableThreads(out workerThread, out completionPortThreads);

Console.WriteLine($"After start Deposit method: Available - WorkerThreads: {workerThread} CompletionPortThreads: {completionPortThreads}");

ThreadPool.QueueUserWorkItem((o) =>
{
    for (int i = 0; i < 20000; i++)
    {
        account.Withdraw(1);
    }
});
ThreadPool.GetAvailableThreads(out workerThread, out completionPortThreads);

Console.WriteLine($"After start Withdraw method: Available - WorkerThreads: {workerThread} CompletionPortThreads: {completionPortThreads}");

Thread.Sleep(10000);

Console.WriteLine(account.Balance);
ThreadPool.GetAvailableThreads(out workerThread, out completionPortThreads);

Console.WriteLine($"On end state: Available - WorkerThreads: {workerThread} CompletionPortThreads: {completionPortThreads}");
class Account
{
    public Account(int balance)
    {
        Balance = balance;
    }

    public int Balance { get; set; }
    public void Deposit(int amount)
    {
        Balance+=amount;
    }
    public void Withdraw(int amount)
    {
        Balance-=amount;
    }
}

// Что бы получить корректный результат нужно перед завершением программы установить достаточно большую задержку, что бы все фоновые процессы успели завершить работу,
// т.к. помещенные в ThreadPool процессы имеют одинаковый приоритет и могут выполняться с разной очередностью