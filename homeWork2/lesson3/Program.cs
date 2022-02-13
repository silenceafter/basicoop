//3
var accountList = new List<BankAccount>();
//1 - balance
var account1 = new BankAccount(5000.23);
accountList.Add(account1);

//2 - type
var account2 = new BankAccount(BankAccount.AccountType.Current);
accountList.Add(account2);

//3 - balance & type
var account3 = new BankAccount(700, BankAccount.AccountType.Estimated);
accountList.Add(account3);

//4 - default
var account4 = new BankAccount();
accountList.Add(account4);

foreach (var account in accountList)
{
    Console.WriteLine($"Номер аккаунта: {account.AccountNumber}");
    Console.WriteLine($"Баланс: {account.Balance}");
    Console.WriteLine($"Тип аккаунта: {account.CurrentAccountType}\n");
}
Console.ReadKey();

public class BankAccount
{
    //default
    public BankAccount()
    {
        _balance = 100;
        _accountType = BankAccount.AccountType.Deposit;
        _accountNumber = IncrementAccountNumber();
    }

    public BankAccount(double balance)
    {
        _balance = balance;
        _accountNumber = IncrementAccountNumber();
    }

    public BankAccount(AccountType accountType)
    {
        _accountType = accountType;
        _accountNumber = IncrementAccountNumber();
    }

    public BankAccount(double balance, AccountType accountType)
    {
        _balance = balance;
        _accountType = accountType;
        _accountNumber = IncrementAccountNumber();
    }

    //accountNumber
    private uint _accountNumber;// = "00000";
    public uint AccountNumber
    {
        get => _accountNumber;
    }

    //accountType
    public enum AccountType { Current, Estimated, Credit, Deposit };
    private AccountType _accountType;
    public AccountType CurrentAccountType
    {
        get => _accountType;
    }

    //balance
    private double _balance;
    public double Balance
    {
        get => _balance;
    }

    private static uint _counter = 0;
    private static uint Counter
    {
        get => _counter;
    }

    public static uint IncrementAccountNumber()
    {
        //return String.Format("{0:00000}", ++_counter);
        return ++_counter;
    }
}