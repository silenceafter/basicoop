//пример 1
var account1 = new BankAccount();
account1.Balance = 5000.23;
account1.CurrentAccountType = BankAccount.AccountType.кредитный;

//пример2
var account2 = new BankAccount();
account2.Balance = 1000;
account2.CurrentAccountType = BankAccount.AccountType.кредитный;

//пример3
var account3 = new BankAccount();
account3.Balance = 2000;
account3.CurrentAccountType = BankAccount.AccountType.текущий;

account1.TransferMoney(account2, 500);//account1 = 5500.23, account2 = 500
account2.TransferMoney(account1, 1500);//account1 = 4000.23, account2 = 2000
account3.TransferMoney(account2, -1000);//account2 = 2000, account3 = 2000
//
Show(account1);
Show(account2);
Show(account3);
Console.ReadKey();

static void Show(BankAccount account)
{
    if (account != null)
    {
        Console.WriteLine($"Номер аккаунта: {account.AccountNumber}");
        Console.WriteLine($"Баланс: {Math.Round(account.Balance, 2)}");
        Console.WriteLine($"Тип аккаунта: {account.CurrentAccountType}\n");
    }
    return;
}

public class BankAccount
{
    public BankAccount()
    {
        AccountNumber = "";
    }

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
        //set => _counter = value;
    }

    public bool GetMoney(double value)
    {
        //снятие со счета
        bool done = false;
        double balance = _balance;
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
        if (bankAccount != null)
        {
            if (amount > 0 && bankAccount.Balance - amount >= 0)
            {
                //на счете есть нужная сумма
                bankAccount.Balance -= amount;
                this.SetMoney(amount);
                done = true;
            }
        }
        return done;
    }
}