using System;

namespace _03.OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;

            if (numbers == 0)
            {
                Console.WriteLine($"OddSum=0.00,");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
                Console.WriteLine($"EvenSum=0.00,");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
            else
            {


                for (int i = 1; i <= numbers; i++)
                {
                    double inputNumber = double.Parse(Console.ReadLine());

                    if (numbers == 1)
                    {
                        Console.WriteLine($"OddSum={inputNumber:f2},");
                        Console.WriteLine($"OddMin={inputNumber:f2},");
                        Console.WriteLine($"OddMax={inputNumber:f2},");
                        Console.WriteLine($"EvenSum=0.00,");
                        Console.WriteLine($"EvenMin=No,");
                        Console.WriteLine($"EvenMax=No");

                    }

                    if (i % 2 == 1)
                    {
                        oddSum += inputNumber;
                        if (inputNumber > oddMax)
                        {
                            oddMax = inputNumber;
                        }
                        if (inputNumber < oddMin)
                        {
                            oddMin = inputNumber;
                        }
                    }
                    else
                    {
                        evenSum += inputNumber;
                        if (inputNumber > evenMax)
                        {
                            evenMax = inputNumber;
                        }
                        if (inputNumber < evenMin)
                        {
                            evenMin = inputNumber;
                        }
                    }
                }


            }
            if (numbers > 1)
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}
