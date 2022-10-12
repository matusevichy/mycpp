Account account = new Account(100000);
bool deposited = false;
bool withdrawed = false;

account.DepositComplited += Account_DepositComplited;
account.WithdrawCompleted += Account_WithdrawCompleted;

void Account_WithdrawCompleted(object? sender, EventArgs e)
{
    withdrawed = true;
}

void Account_DepositComplited(object? sender, EventArgs e)
{
    deposited = true;
}

account.Depositing(1, 20000);
account.Withdrawing(1, 20000);

while (!deposited && !withdrawed)
{
    Console.Write(".");
    Thread.Sleep(10);
}

Console.WriteLine(account.Balance);

class Account
{
    public event EventHandler DepositComplited;
    public event EventHandler WithdrawCompleted;
    public Account(int balance)
    {
        Balance = balance;
    }

    public int Balance { get; set; }
    public void Deposit(int amount)
    {
        Balance += amount;
        DepositComplited?.Invoke(this, new EventArgs());
    }
    public void Depositing(int amount, int count)
    {
        Thread thread = new Thread(() =>
        {
            for (int i = 0; i < count; i++)
            {
                Deposit(amount);
            }
            DepositComplited?.Invoke(this, new EventArgs());
        });
        thread.Start();
    }
    public void Withdraw(int amount)
    {
        Balance -= amount;
        WithdrawCompleted?.Invoke(this, new EventArgs());
    }
    public void Withdrawing(int amount, int count)
    {
        Thread thread = new Thread(() =>
        {
            for (int i = 0; i < count; i++)
            {
                Withdraw(amount);
            }
            WithdrawCompleted?.Invoke(this, new EventArgs());
        });
        thread.Start();
    }
}
