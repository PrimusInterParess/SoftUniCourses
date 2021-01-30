using System;

namespace _06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            double result = 0.0;
            string input = string.Empty;
            string evenOdd = string.Empty;

            switch (symbol)
            {
                case "+":
                    result = N1 + N2;
                    if (result % 2 == 0)
                    {
                        evenOdd = "even";
                    }
                    else
                    {
                        evenOdd = "odd";
                    }
                    Console.WriteLine($"{N1} {symbol} {N2} = {result} - {evenOdd}");
                    break;
                case "-":
                    result = N1 - N2;
                    if (result % 2 == 0)
                    {
                        evenOdd = "even";
                    }
                    else
                    {
                        evenOdd = "odd";
                    }
                    Console.WriteLine($"{N1} {symbol} {N2} = {result} - {evenOdd}");
                    break;
                case "*":
                    result = N1 * N2;
                    if (result % 2 == 0)
                    {
                        evenOdd = "even";
                    }
                    else
                    {
                        evenOdd = "odd";
                    }
                    Console.WriteLine($"{N1} {symbol} {N2} = {result} - {evenOdd}");
                    break;
                case "/":
                    result = N1 / N2;
                    if (N2 != 0)
                    {
                        Console.WriteLine($"{N1} / {N2} = {result:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                    }
                    break;
                case "%":
                    result = N1 % N2;
                    if (N2 != 0)
                    {
                        Console.WriteLine($"{N1} % {N2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                    }
                    break;

            }
        }
    }
}
