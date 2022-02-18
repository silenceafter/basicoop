using System;
using System.Text;
using System.Linq;

﻿//задание 1
//acoder
ACoder acoder = new ACoder();
string s1 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
string s2 = "проверка";
string s3 = "АбвгдеёжзийкЛмнопрстуФхцчшщъыьэюЯ";
string s4 = "ПРОВерКа";
//s1
acoder.Shift = 1;
string encode = acoder.Encode(s1);
acoder.Shift = -1;
string decode = acoder.Decode(encode);
Console.WriteLine("acoder");
Console.WriteLine($"'абвгдеёжзийклмнопрстуфхцчшщъыьэюя' -> '{ encode } -> '{ decode }'");

//s2
acoder.Shift = 1;
encode = acoder.Encode(s2);
acoder.Shift = -1;
decode = acoder.Decode(encode);
Console.WriteLine($"'проверка' -> '{ encode } -> '{ decode }'\n");

//bcoder
BCoder bcoder = new BCoder();
encode = bcoder.Encode(s3);
decode = bcoder.Decode(encode);
Console.WriteLine("bcoder");
Console.WriteLine($"'АбвгдеёжзийкЛмнопрстуФхцчшщъыьэюЯ' -> '{ encode }' -> '{ decode }'");

encode = bcoder.Encode(s4);
decode = bcoder.Decode(encode);
Console.WriteLine($"'ПРОВерКа' -> '{ encode }' -> '{ decode }'");
Console.ReadKey();

/// <summary>
/// интерфейс ICoder с методами для кодирования/декодирования строки
/// </summary>
public interface ICoder {
    public string Encode(string s);
    public string Decode(string s);
}

/// <summary>
/// класс ACoder, реализующий интерфейс ICoder
/// </summary>
public class ACoder : ICoder
{
    /// <summary>
    /// поле для хранения алфавита без пробелов
    /// </summary>
    private string _alphabet;
    
    /// <summary>
    /// поле для хранения значение сдвига символа влево/вправо
    /// </summary>
    private int _shift;

    /// <summary>
    /// свойство для доступа к полю _alphabet (только чтение)
    /// </summary>
    /// <value></value>
    public string Alphabet
    {
        get => _alphabet;
    }

    /// <summary>
    /// свойство для доступа к полю _shift
    /// </summary>
    /// <value></value>
    public int Shift {
        get => _shift;
        set => _shift = value;
    }

    /// <summary>
    /// конструктор без параметров класса ACoder
    /// </summary>
    public ACoder()
    {
        _alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    }

    /// <summary>
    /// метод Encode() кодирования строки 
    /// </summary>
    /// <param name="s">string</param>
    /// <returns>string</returns>
    public string Encode(string s) 
    {
        //сдвиг букв вправо на n-позиций
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            var index = _alphabet.IndexOf(s[i]);
            var index2 = 0;
            //
            if (index + _shift > 32)
            {
                //переход в начало алфавита
                index2 = (index + _shift) - _alphabet.Length;
            } else {
                //по умолчанию
                index2 = index + _shift;
            }
            sb.Append(_alphabet[index2]);
        }
        return sb.ToString();
    }

    /// <summary>
    /// метод Decode() для декодирования строки
    /// </summary>
    /// <param name="s">string</param>
    /// <returns>string</returns>
    public string Decode(string s)
    {
        //сдвиг букв влево на n-позиций
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            var index = _alphabet.IndexOf(s[i]);
            var index2 = 0;
            //
            if (index + _shift < 0)
            {
                //переход в конец алфавита
                index2 = _alphabet.Length - Math.Abs(index + _shift);
            } else {
                //по умолчанию
                index2 = index + _shift;
            }
            sb.Append(_alphabet[index2]);
        }
        return sb.ToString();
    }
}

/// <summary>
/// класс BCoder, реализующий интерфейс ICoder
/// </summary>
public class BCoder : ICoder
{
    /// <summary>
    /// поле для хранения алфавита без пробелов
    /// </summary>
    private string _alphabet;

    /// <summary>
    /// свойство для доступа к полю _alphabet (только чтение)
    /// </summary>
    /// <value></value>
    public string Alphabet
    {
        get => _alphabet;
    }

    /// <summary>
    /// конструктор класса без параметров
    /// </summary>
    public BCoder()
    {
        _alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    }

    /// <summary>
    /// метод Encode() кодирования строки 
    /// </summary>
    /// <param name="s">string</param>
    /// <returns>string</returns>
    public string Encode(string s) 
    {
        //сдвиг вправо, замена i-й позиции на i-ю позицию с конца алфавита, с сохранением регистра
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            var upper = char.IsUpper(s[i]);
            var index = _alphabet.IndexOf(char.ToLower(s[i]));
            //
            var index2 = _alphabet.Length - 1 - index;
            var symbol = _alphabet[index2];
            
            if (upper)
            {
                symbol = char.ToUpper(symbol);   
            }
            sb.Append(symbol);
        }
        return sb.ToString();
    }

    /// <summary>
    /// метод Decode() для декодирования строки
    /// </summary>
    /// <param name="s">string</param>
    /// <returns>string</returns>
    public string Decode(string s)
    {
        //сдвиг влево, замена i-й позиции на i-ю позицию с конца алфавита, с сохранением регистра
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            var upper = char.IsUpper(s[i]);
            var index = _alphabet.IndexOf(char.ToLower(s[i]));
            //
            var index2 = _alphabet.Length - 1 - index;
            var symbol = _alphabet[index2];

            if (upper) 
            {
                symbol = char.ToUpper(symbol);   
            }
            sb.Append(symbol);
        }
        return sb.ToString();
    }
}