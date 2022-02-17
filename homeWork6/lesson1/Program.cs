using System.Text;

﻿//задание 1
BankAccount account1 = new BankAccount();
account1.Balance = 5000.23;
account1.CurrentAccountType = BankAccount.AccountType.Credit;

BankAccount account2 = new BankAccount();
account2.Balance = 1000;
account2.CurrentAccountType = BankAccount.AccountType.Credit;

//1 ==
if (account1 == account2) {
    Console.WriteLine("account 1 == account2");
} else {
    Console.WriteLine("account 1 != account2");
}

//2 ==
if (account1 == account1) {
    Console.WriteLine("account 1 == account1");
} else {
    Console.WriteLine("account 1 != account1");
}

//3 !=
if (account1 != account2) {
    Console.WriteLine("account 1 != account2");
} else {
    Console.WriteLine("account 1 == account2");
}

//4 !=
if (account1 != account1) {
    Console.WriteLine("account 1 != account1");
} else {
    Console.WriteLine("account 1 == account1");
}
Console.WriteLine();

//5 Equals()
Console.WriteLine($"account1 equals account2 = { account1.Equals(account2) }");
Console.WriteLine($"account2 equals account1 = { account2.Equals(account1) }");
Console.WriteLine();

//6 GetHashCode()
Console.WriteLine($"account1 hashcode = { account1.GetHashCode() }");
Console.WriteLine($"account2 hashcode = { account2.GetHashCode() }");
Console.WriteLine();

//7 ToString()
Console.WriteLine(account1.ToString());
Console.WriteLine(account2.ToString());
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

    public static bool operator ==(BankAccount account1, BankAccount account2)
    {
        if (ReferenceEquals(account1, account2)) 
        {
            return true;
        }
            
        if (ReferenceEquals(account1, null)) 
        {
            return false;
        }
            
        if (ReferenceEquals(account2, null))
        {
            return false;
        }
        return account1.Equals(account2);
    }

    public static bool operator !=(BankAccount account1, BankAccount account2) => !(account1 == account2);

    public override bool Equals(object obj)
    {
        if (obj is not BankAccount account)
        {
           return false;
        }
        return AccountNumber == account.AccountNumber &&
               Balance == account.Balance &&
               CurrentAccountType == account.CurrentAccountType;
    }

    public override int GetHashCode()
    {
        int hashcode = _accountNumber.GetHashCode();
        hashcode = 31 * hashcode + _accountType.GetHashCode();
        hashcode = 31 * hashcode + _balance.GetHashCode();
        return hashcode;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"AccountNumber = { AccountNumber.ToString() }");
        sb.AppendLine($"Balance = { Balance.ToString() }");
        sb.AppendLine($"CurrentAccountType = { CurrentAccountType.ToString() }");
        return sb.ToString();
    }
}