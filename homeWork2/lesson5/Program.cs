//5
//пример 1
var account1 = new BankAccount();
account1.Balance = 5000.23;
account1.CurrentAccountType = BankAccount.AccountType.Credit;
//
Show(account1);

//добавить
account1.SetMoney(1500);
Show(account1);

//списать
account1.GetMoney(500);
Show(account1);

//пример2
var account2 = new BankAccount();
account2.Balance = 1000;
account2.CurrentAccountType = BankAccount.AccountType.Credit;
//
Show(account2);

//добавить
account2.SetMoney(50);
Show(account2);

//пробуем списать больше, чем доступно
account2.GetMoney(1500);
Show(account2);

//пример3
var account3 = new BankAccount();
account3.Balance = 2000;
account3.CurrentAccountType = BankAccount.AccountType.Current;
//
Show(account3);

//добавить отрицательное значение
account3.SetMoney(-1000);
Show(account3);

//списать
account3.GetMoney(250);
Show(account3);
Console.ReadKey();

static void Show(BankAccount account)
{
    if (account != null)
    {
        Console.WriteLine($"Номер аккаунта: {account.AccountNumber}");
        Console.WriteLine($"Баланс: {account.Balance}");
        Console.WriteLine($"Тип аккаунта: {account.CurrentAccountType}\n");
    }
    return;
}

public class BankAccount
{
    public BankAccount()
    {
        _accountNumber = IncrementAccountNumber();//AccountNumber = "";
    }

    //accountNumber
    private uint _accountNumber;// = "00000";
    public uint AccountNumber
    {
        get => _accountNumber;
        set => _accountNumber = value;//String.Format("{0:00000}", ++_counter);
    }

    //accountType
    public enum AccountType { Current, Estimated, Credit, Deposit };
    private AccountType _accountType;
    public AccountType CurrentAccountType
    {
        get => _accountType;
        set => _accountType = value;
    }

    //balance
    private double _balance;
    public double Balance
    {
        get => _balance;
        set => _balance = value;
    }

    private static uint _counter = 0;
    private static uint Counter
    {
        get => _counter;
    }

    public static uint IncrementAccountNumber()
    {
        return ++_counter;
    }

    public bool GetMoney(double value)
    {
        //снятие со счета
        double balance = _balance;
        if (balance - value >= 0)
        {
            //деньги можно снять, изменяем баланс
            _balance -= value;
            return true;
        }
        return false;
    }

    public bool SetMoney(double value)
    {
        //положить на счет
        if (value > 0)
        {
            _balance += value;
            return true;
        }
        return false;
    }
}