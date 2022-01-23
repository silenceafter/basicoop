//2
var accountList = new List<BankAccount>();
for (int i = 0; i < 3; i++)
{
    var account = new BankAccount();
    account.AccountNumber = BankAccount.IncrementAccountNumber();
    account.Balance = 5000.23;
    account.CurrentAccountType = BankAccount.AccountType.кредитный;
    accountList.Add(account);
}

foreach (var account in accountList)
{
    Console.WriteLine($"Номер аккаунта: {account.AccountNumber}");
    Console.WriteLine($"Баланс: {account.Balance}");
    Console.WriteLine($"Тип аккаунта: {account.CurrentAccountType}\n");
}
Console.ReadKey();

public class BankAccount
{
    //accountNumber
    private string _accountNumber = "00000";
    public string AccountNumber
    {
        get => _accountNumber;
        set => _accountNumber = value;
    }

    //accountType
    public enum AccountType { текущий, расчетный, кредитный, депозит };
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
        set => _counter = value;
    }

    public static string IncrementAccountNumber()
    {
        return String.Format("{0:00000}", ++_counter);
    }
}