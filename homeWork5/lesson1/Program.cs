using System;
using System.Text;

var rNumbers1 = new RatinalNumbers(3, 4);
var rNumbers2 = new RatinalNumbers(3, 4);
var rNumbers3 = new RatinalNumbers(5, 6);

//Equals
Console.WriteLine($"rNumbers1 Equals rNumbers2 = { rNumbers1.Equals(rNumbers2) }");
Console.WriteLine($"rNumbers1 Equals rNumbers3 = { rNumbers1.Equals(rNumbers3) }");
Console.WriteLine($"rNumbers2 Equals rNumbers3 = { rNumbers2.Equals(rNumbers3) }\n");

//GetHashCode()
Console.WriteLine($"rNumbers1 GetHashCode() = { rNumbers1.GetHashCode() }");
Console.WriteLine($"rNumbers2 GetHashCode() = { rNumbers2.GetHashCode() }");
Console.WriteLine($"rNumbers3 GetHashCode() = { rNumbers3.GetHashCode() }\n");

//ToString()
Console.WriteLine($"rNumbers1.ToString() { rNumbers1.ToString() }");
Console.WriteLine($"rNumbers2.ToString() { rNumbers2.ToString() }");
Console.WriteLine($"rNumbers3.ToString() { rNumbers3.ToString() }\n");

//Float
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) to float = { (float)rNumbers1 }");
Console.WriteLine($"({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) to float = { (float)rNumbers2 }");
Console.WriteLine($"({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) to float = { (float)rNumbers3 }\n");

//Int
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) to int = { (int)rNumbers1 }");
Console.WriteLine($"({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) to int = { (int)rNumbers2 }");
Console.WriteLine($"({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) to int = { (int)rNumbers3 }\n");

//+
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) + ({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) = { rNumbers1 + rNumbers2 }");
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) + ({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) = { rNumbers1 + rNumbers3 }");
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) + ({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) + ({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) = { rNumbers1 + rNumbers2 + rNumbers3 }\n");

//-
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) - ({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) = { rNumbers1 - rNumbers2 }");
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) - ({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) = { rNumbers1 - rNumbers3 }");
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) - ({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) - ({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) = { rNumbers1 - rNumbers2 - rNumbers3 }\n");

//*
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) * ({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) = { rNumbers1 * rNumbers2 }");
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) * ({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) = { rNumbers1 * rNumbers3 }");
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) * ({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) * ({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) = { rNumbers1 * rNumbers2 * rNumbers3 }\n");

///
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) / ({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) = { rNumbers1 / rNumbers2 }");
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) / ({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) = { rNumbers1 / rNumbers3 }");
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) / ({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) / ({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) = { rNumbers1 / rNumbers2 / rNumbers3 }\n"); 

//%
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) % ({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) = { rNumbers1 % rNumbers2 }");
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) % ({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) = { rNumbers1 % rNumbers3 }");
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator }) % ({ rNumbers2.Numerator } / { rNumbers2.Denumenator }) % ({ rNumbers3.Numerator } / { rNumbers3.Denumenator }) = { rNumbers1 % rNumbers2 % rNumbers3 }\n");

//++
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator })++ = { rNumbers1++ }");
Console.WriteLine($"({ rNumbers2.Numerator } / { rNumbers2.Denumenator })++ = { rNumbers2++ }");
Console.WriteLine($"({ rNumbers3.Numerator } / { rNumbers3.Denumenator })++ = { rNumbers3++ }\n");

//--
Console.WriteLine($"({ rNumbers1.Numerator } / { rNumbers1.Denumenator })-- = { rNumbers1-- }");
Console.WriteLine($"({ rNumbers2.Numerator } / { rNumbers2.Denumenator })-- = { rNumbers2-- }");
Console.WriteLine($"({ rNumbers3.Numerator } / { rNumbers3.Denumenator })-- = { rNumbers3-- }");
Console.ReadKey();

public class RatinalNumbers
{
    public RatinalNumbers(int numerator, int denumerator)
    {
        _numerator = numerator;
        _denumerator = denumerator;
    }

    private int _numerator;
    private int _denumerator;

    public int Numerator
    {
        get => _numerator;
        set => _numerator = value;      
    }

    public int Denumenator
    {
        get => _denumerator;
        set => _denumerator = value;
    }

/// <summary>
/// Переопределенный метод Equals() 
/// </summary>
/// <param name="obj">object</param>
/// <returns>bool</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not RatinalNumbers rnumbers)
        {
           return false;
        }
        return Numerator == rnumbers.Numerator &&
               Denumenator == rnumbers.Denumenator;
    }

/// <summary>
/// Переопределенный метод GetHashCode()
/// </summary>
/// <returns>int</returns>
    public override int GetHashCode()
    {
        int hashcode = _numerator.GetHashCode();
        hashcode = 31 * hashcode + _denumerator.GetHashCode();
        return hashcode;
    }

/// <summary>
/// Переопределенный метод ToString()
/// </summary>
/// <returns>string</returns>
    public override string ToString()
    {
        return $"{ _numerator }/{ _denumerator }";
    }

    /// <summary>
    /// Переопределенный оператор приведения float
    /// </summary>
    /// <param name="rnumbers">RatinalNumbers</param>
    public static explicit operator float(RatinalNumbers rnumbers)
    {
        return (float)rnumbers.Numerator / rnumbers.Denumenator;
    }

    /// <summary>
    /// Переопределенный оператор приведения int
    /// </summary>
    /// <param name="rnumbers">RatinalNumbers</param>
    public static explicit operator int(RatinalNumbers rnumbers)
    {
        return (int)rnumbers.Numerator / rnumbers.Denumenator;
    }

    /// <summary>
    /// Переопределенный оператор ==
    /// </summary>
    /// <param name="rnumbers1">RatinalNumbers</param>
    /// <param name="rnumbers2">RatinalNumbers</param>
    /// <returns>bool</returns>
    public static bool operator ==(RatinalNumbers rnumbers1, RatinalNumbers rnumbers2)
    {
        if (ReferenceEquals(rnumbers1, rnumbers2))
        {
            return true;
        }
            
        if (ReferenceEquals(rnumbers1, null)) 
        {
            return false;
        }
            
        if (ReferenceEquals(rnumbers2, null))
        {
            return false;
        }
        return rnumbers1.Equals(rnumbers2);
    }

    /// <summary>
    /// Переопределенный оператор !=
    /// </summary>
    /// <param name="rnumbers1">RatinalNumbers</param>
    /// <param name="rnumbers2">RatinalNumbers</param>
    /// <returns>bool</returns>
    public static bool operator !=(RatinalNumbers rnumbers1, RatinalNumbers rnumbers2) => !(rnumbers1 == rnumbers2);

    /// <summary>
    /// Переопределенный оператор <
    /// </summary>
    /// <param name="rnumbers1">RatinalNumbers</param>
    /// <param name="rnumbers2">RatinalNumbers</param>
    /// <returns>bool</returns>
    public static bool operator <(RatinalNumbers rnumbers1, RatinalNumbers rnumbers2)
    {
        if (rnumbers1.Numerator / rnumbers1.Denumenator < rnumbers2.Numerator / rnumbers2.Denumenator)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Переопределенный оператор >
    /// </summary>
    /// <param name="rnumbers1">RatinalNumbers</param>
    /// <param name="rnumbers2">RatinalNumbers</param>
    /// <returns>bool</returns>
    public static bool operator >(RatinalNumbers rnumbers1, RatinalNumbers rnumbers2)
    {
        if (rnumbers1.Numerator / rnumbers1.Denumenator > rnumbers2.Numerator / rnumbers2.Denumenator)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Переопределенный оператор <=
    /// </summary>
    /// <param name="rnumbers1">RatinalNumbers</param>
    /// <param name="rnumbers2">RatinalNumbers</param>
    /// <returns>bool</returns>
    public static bool operator <=(RatinalNumbers rnumbers1, RatinalNumbers rnumbers2)
    {
        if (rnumbers1.Numerator / rnumbers1.Denumenator <= rnumbers2.Numerator / rnumbers2.Denumenator)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Переопределенный оператор >=
    /// </summary>
    /// <param name="rnumbers1">RatinalNumbers</param>
    /// <param name="rnumbers2">RatinalNumbers</param>
    /// <returns>bool</returns>
    public static bool operator >=(RatinalNumbers rnumbers1, RatinalNumbers rnumbers2)
    {
        if (rnumbers1.Numerator / rnumbers1.Denumenator >= rnumbers2.Numerator / rnumbers2.Denumenator)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Переопределенный оператор +
    /// </summary>
    /// <param name="rnumbers1">RatinalNumbers</param>
    /// <param name="rnumbers2">RatinalNumbers</param>
    /// <returns>RatinalNumbers</returns>
    public static RatinalNumbers operator +(RatinalNumbers rnumbers1, RatinalNumbers rnumbers2)
    {
        int numerator1 = rnumbers1.Numerator;
        int numerator2 = rnumbers2.Numerator;
        int denumerator1 = rnumbers1.Denumenator;
        int denumerator2 = rnumbers2.Denumenator;

        //result
        int numeratorRes = numerator1 * denumerator2 + denumerator1 * numerator2;
        int denumeratorRes = denumerator1 * denumerator2;

        if (numeratorRes == 0) {
            return new RatinalNumbers(0, 0);
        }

        int nod = Nod(numeratorRes, denumeratorRes);
        int numeratorTmp = numeratorRes / nod;
        int denumeratorTmp = denumeratorRes / nod;        
        return new RatinalNumbers(numeratorTmp, denumeratorTmp);
    }

    /// <summary>
    /// Переопределенный оператор -
    /// </summary>
    /// <param name="rnumbers1">RatinalNumbers</param>
    /// <param name="rnumbers2">RatinalNumbers</param>
    /// <returns>RatinalNumbers</returns>
    public static RatinalNumbers operator -(RatinalNumbers rnumbers1, RatinalNumbers rnumbers2)
    {
        int numerator1 = rnumbers1.Numerator;
        int numerator2 = rnumbers2.Numerator;
        int denumerator1 = rnumbers1.Denumenator;
        int denumerator2 = rnumbers2.Denumenator;

        if (numerator1 == 0 && denumerator1 == 0)
        {
            //число1 = 0
            return new RatinalNumbers( -numerator2, -denumerator2);
        }

        if (denumerator1 == 0|| denumerator2 == 0)
        {
            //знаменатель1 = 0 или знаменатель2 = 0
            return new RatinalNumbers(0, 0);
        }

        //result
        int numeratorRes = numerator1 * denumerator2 - denumerator1 * numerator2;
        int denumeratorRes = denumerator1 * denumerator2;

        if (numeratorRes == 0) {
            return new RatinalNumbers(0, 0);
        }

        int nod = Nod(numeratorRes, denumeratorRes);
        int numeratorTmp = numeratorRes / nod;
        int denumeratorTmp = denumeratorRes / nod;        
        return new RatinalNumbers(numeratorTmp, denumeratorTmp);
    }

    /// <summary>
    /// Метод вычисления предельного сокращения обыкновенной дроби
    /// </summary>
    /// <param name="numerator">int</param>
    /// <param name="denumerator">int</param>
    /// <returns>RatinalNumbers</returns>
    public static RatinalNumbers FractionReduction(int numerator, int denumerator)
    {
        int j, less;                                  
        do{
            if(numerator < denumerator) {
                less = numerator;     
            } 
            else {
                less = denumerator;     
            }                                                 
                     
            for(j = less; j > 0; j--){                      
                if((numerator % j == 0) && (denumerator % j == 0)){
                    numerator /= j;                          
                    denumerator /= j;                        
                    break;                               
                }
            }
        }while(j != 1);
        return new RatinalNumbers(numerator, denumerator);
    }

    /// <summary>
    /// Метод вычисления НОД
    /// </summary>
    /// <param name="numerator">int</param>
    /// <param name="denumerator">int</param>
    /// <returns>int</returns>
    public static int Nod(int numerator, int denumerator)
    {
        numerator = Math.Abs(numerator);
        denumerator = Math.Abs(denumerator);

        int tmp;
        if (denumerator > numerator) 
        {
            tmp = numerator;
            numerator = denumerator;
            denumerator = tmp;
        }

        do {
            tmp = numerator % denumerator; 
            numerator = denumerator; 
            denumerator = tmp;
        }
        while (!(denumerator == 0));
        return numerator;
    }

    /// <summary>
    /// Переопределенный оператор ++
    /// </summary>
    /// <param name="rnumbers">RatinalNumbers</param>
    /// <returns>RatinalNumbers</returns>
    public static RatinalNumbers operator ++(RatinalNumbers rnumbers)
    {
        int numerator = rnumbers.Numerator;
        int denumerator = rnumbers.Denumenator;

        var result = rnumbers + new RatinalNumbers(1, 1);
        rnumbers.Numerator = result.Numerator;
        rnumbers.Denumenator = result.Denumenator;
        return rnumbers;
    }

    /// <summary>
    /// Переопределенный оператор --
    /// </summary>
    /// <param name="rnumbers">RatinalNumbers</param>
    /// <returns>RatinalNumbers</returns>
    public static RatinalNumbers operator --(RatinalNumbers rnumbers)
    {
        int numerator = rnumbers.Numerator;
        int denumerator = rnumbers.Denumenator;

        var result = rnumbers - new RatinalNumbers(1, 1);
        rnumbers.Numerator = result.Numerator;
        rnumbers.Denumenator = result.Denumenator;
        return rnumbers;
    }

    /// <summary>
    /// Переопределенный оператор *
    /// </summary>
    /// <param name="rnumbers1">RatinalNumbers</param>
    /// <param name="rnumbers2">RatinalNumbers</param>
    /// <returns>RatinalNumbers</returns>
    public static RatinalNumbers operator *(RatinalNumbers rnumbers1, RatinalNumbers rnumbers2)
    {
        int numerator1 = rnumbers1.Numerator;
        int numerator2 = rnumbers2.Numerator;
        int denumerator1 = rnumbers1.Denumenator;
        int denumerator2 = rnumbers2.Denumenator;

        //result
        int numeratorRes = numerator1 * numerator2;
        int denumeratorRes = denumerator1 * denumerator2;        
        return RatinalNumbers.FractionReduction(numeratorRes, denumeratorRes);
    }

    /// <summary>
    /// Переопределенный оператор /
    /// </summary>
    /// <param name="rnumbers1">RatinalNumbers</param>
    /// <param name="rnumbers2">RatinalNumbers</param>
    /// <returns>RatinalNumbers</returns>
    public static RatinalNumbers operator /(RatinalNumbers rnumbers1, RatinalNumbers rnumbers2)
    {
        int numerator1 = rnumbers1.Numerator;
        int numerator2 = rnumbers2.Numerator;
        int denumerator1 = rnumbers1.Denumenator;
        int denumerator2 = rnumbers2.Denumenator;

        //result
        int numeratorRes = numerator1 * denumerator2;
        int denumeratorRes = denumerator1 * numerator2;        
        return RatinalNumbers.FractionReduction(numeratorRes, denumeratorRes);
    }

    /// <summary>
    /// Переопределенный оператор %
    /// </summary>
    /// <param name="rnumbers1">RatinalNumbers</param>
    /// <param name="rnumbers2">RatinalNumbers</param>
    /// <returns>RatinalNumbers</returns>
    public static RatinalNumbers operator %(RatinalNumbers rnumbers1, RatinalNumbers rnumbers2)
    {
        //?
        int numerator1 = rnumbers1.Numerator;
        int numerator2 = rnumbers2.Numerator;
        int denumerator1 = rnumbers1.Denumenator;
        int denumerator2 = rnumbers2.Denumenator;

        //result
        int numeratorRes = numerator1 % denumerator2;
        int denumeratorRes = denumerator1 % numerator2;        
        return RatinalNumbers.FractionReduction(numeratorRes, denumeratorRes);
    }
}