//4
var accountList = new List<BankAccount>();
for (int i = 0; i < 3; i++)
{
    var account = new BankAccount();
    account.AccountNumber = "0000";
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
        get
        {
            return _accountNumber;
        }

        set
        {
            _accountNumber = String.Format("{0:00000}", ++_counter);
        }
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
    }
}