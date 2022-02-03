//задание 2
Console.WriteLine($"пример -> { GetReverseString("пример") }");
Console.WriteLine($"Александр -> { GetReverseString("Александр") }");
Console.WriteLine($"программисты программируют -> { GetReverseString("программисты программируют") }");
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

static string GetReverseString(string str) 
{
    //вернуть обратную строку
    string reverse = "";
    for(int i = str.Length - 1; i >= 0; i--)
    {
        reverse += str[i];
    }
    return reverse;
}
public class BankAccount
{
    public BankAccount()
    {
        AccountNumber = 0;//"";
    }

    //accountNumber
    private uint _accountNumber = 0;//"00000";
    public uint AccountNumber
    {
        get
        {
            return _accountNumber;
        }

        set
        {
            _accountNumber = ++_counter;//_accountNumber = String.Format("{0:00000}", ++_counter);
        }
    }

    //accountType
    public enum AccountType { current, estimated, credit, deposit };
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
        bool done = false;
        double balance = _balance;
        //
        if (balance - value >= 0)
        {
            //деньги можно снять, изменяем баланс
            _balance -= value;
            done = true;
        }
        else
        {
            //снять нельзя
            done = false;
        }
        return done;
    }

    public bool SetMoney(double value)
    {
        //положить на счет
        bool done = false;
        //
        if (value > 0)
        {
            _balance += value;
            done = true;
        }
        return done;
    }

    public bool TransferMoney(BankAccount bankAccount, double amount)//double value
    {
        //перевести деньги на счет,
        //bankAccount - объект, у которого снимаются деньги
        bool done = false;
        //
        if (bankAccount != null)
        {

            if (amount > 0 && bankAccount.Balance - amount >= 0)
            {
                //на счете есть нужная сумма
                bankAccount.Balance -= amount;
                this.SetMoney(amount);
                done = true;                
            }
            
            //вывод на экран
            Console.WriteLine($"Аккаунт \"{ bankAccount.AccountNumber }\" -> \"{ this.AccountNumber }\": { amount }");
            Console.WriteLine($"Аккаунт \"{ bankAccount.AccountNumber }\": { Math.Round(bankAccount.Balance, 2) }");
            Console.WriteLine($"Аккаунт \"{ this.AccountNumber }\": { Math.Round(this.Balance, 2) }\n");
        }
        return done;
    }
}