Account account = new Account(100000);

Task t1 = Task.Run(() =>
{
    for (int i = 0; i < 20000; i++)
    {
        account.Deposit(1);
    }
});

Task t2 = Task.Run(() =>
{
    for (int i = 0; i < 20000; i++)
    {
        account.Withdraw(1);
    }
});

Task.WaitAll(t1, t2);

Console.WriteLine(account.Balance);

class Account
{
    public Account(int balance)
    {
        Balance = balance;
    }

    public int Balance { get; set; }
    public void Deposit(int amount)
    {
        Balance += amount;
    }
    public void Withdraw(int amount)
    {
        Balance -= amount;
    }
}
