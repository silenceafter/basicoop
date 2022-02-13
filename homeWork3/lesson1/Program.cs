//пример 1
var account1 = new BankAccount();
account1.Balance = 5000.23;
account1.CurrentAccountType = BankAccount.AccountType.Credit;

//пример2
var account2 = new BankAccount();
account2.Balance = 1000;
account2.CurrentAccountType = BankAccount.AccountType.Credit;

//пример3
var account3 = new BankAccount();
account3.Balance = 2000;
account3.CurrentAccountType = BankAccount.AccountType.Current;
//
ShowAccount(account1);
ShowAccount(account2);
ShowAccount(account3);

var amount = 500;
account1.TransferMoney(account2, amount);//account1 = 5500.23, account2 = 500
ShowTransfer(account1, account2, amount);

amount = 1500;
account2.TransferMoney(account1, amount);//account1 = 4000.23, account2 = 2000
ShowTransfer(account2, account1, amount);

amount = -1000;
account3.TransferMoney(account2, -amount);//account2 = 2000, account3 = 2000
ShowTransfer(account3, account2, amount);
Console.ReadKey();

static void ShowAccount(BankAccount account)
{
    if (account != null)
    {
        Console.WriteLine($"Номер аккаунта: {account.AccountNumber}");
        Console.WriteLine($"Баланс: {Math.Round(account.Balance, 2)}");
        Console.WriteLine($"Тип аккаунта: {account.CurrentAccountType}\n");
    }
    return;
}

static void ShowTransfer(BankAccount account1, BankAccount account2, double amount)
{
    //вывод на экран информации о переводе
    Console.WriteLine($"Аккаунт \"{ account2.AccountNumber }\" -> \"{ account1.AccountNumber }\": { amount }");
    Console.WriteLine($"Аккаунт \"{ account2.AccountNumber }\": { Math.Round(account2.Balance, 2) }");
    Console.WriteLine($"Аккаунт \"{ account1.AccountNumber }\": { Math.Round(account1.Balance, 2) }\n");
}

public class BankAccount
{
    public BankAccount()
    {
        _counter += 1;//AccountNumber = 0;//"";
        _accountNumber = _counter;
    }

    //accountNumber
    private uint _accountNumber = 0;//"00000";
    public uint AccountNumber
    {
        get => _accountNumber;
        set => _accountNumber = value;//++_counter;
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
        //set => _counter = value;
    }

    public bool GetMoney(double value)
    {
        //снятие со счета
        double balance = _balance;
        //
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

    public bool TransferMoney(BankAccount bankAccount, double amount)//double value
    {
        //перевести деньги на счет,
        //bankAccount - объект, у которого снимаются деньги
        if (bankAccount != null)
        {
            if (amount > 0 && bankAccount.Balance - amount >= 0)
            {
                //на счете есть нужная сумма
                bankAccount.Balance -= amount;
                this.SetMoney(amount);
            }
            return true;
        }
        return false;
    }
}