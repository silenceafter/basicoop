//задание 2
char[] array1 = { 'п', 'р', 'и', 'м', 'е', 'р' };
char[] array2 = { 'А', 'л', 'е', 'к', 'с', 'а', 'н', 'д', 'р' };
char[] array3 = { 'п', 'р', 'о', 'г', 'р', 'а', 'м', 'м', 'и', 'с', 'т', 'ы', ' ',
'п', 'р', 'о', 'г', 'р', 'а', 'м', 'м', 'и', 'р', 'у', 'ю', 'т' };
//
Console.WriteLine($"пример -> { GetReverseString(array1) }");
Console.WriteLine($"Александр -> { GetReverseString(array2) }");
Console.WriteLine($"программисты программируют -> { GetReverseString(array3) }");
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

static string? GetReverseString(char[] array) 
{
    //вернуть обратную строку (тип строка)
    char tmp;
    for(int i = 0, j = array.Length - 1; i < array.Length / 2; i++, j--)
    {
        tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }
    return new string(array);
}
public class BankAccount
{
    public BankAccount()
    {
        _counter += 1;//AccountNumber = 0;//"";
        _accountNumber = _counter;
    }

    //accountNumber
    private uint _accountNumber;// = 0;
    public uint AccountNumber
    {
        get => _accountNumber;
        set =>_accountNumber = value;//++_counter;//_accountNumber = String.Format("{0:00000}", ++_counter);
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