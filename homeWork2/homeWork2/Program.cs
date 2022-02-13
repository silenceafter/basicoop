//1
var account = new BankAccount();
account.AccountNumber = 1;
account.Balance = 5000.23;
account.CurrentAccountType = BankAccount.AccountType.Credit;
//
Console.WriteLine($"Номер аккаунта: {account.AccountNumber}");
Console.WriteLine($"Баланс: {account.Balance}");
Console.WriteLine($"Тип аккаунта: {account.CurrentAccountType}");
Console.ReadKey();

public class BankAccount
{
    //accountNumber
    private uint _accountNumber;
    public uint AccountNumber
    {
        get => _accountNumber;
        set => _accountNumber = value;
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
}