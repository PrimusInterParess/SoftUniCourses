using System;

namespace _04.MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            var inputUnit = Console.ReadLine();
            var expectedUnit = Console.ReadLine();
            double outputUnit = 0;



            if ((inputUnit == "m") && (expectedUnit == "cm"))
            {
                outputUnit = num * 100;

            }
            else if ((inputUnit == "m") && (expectedUnit == "mm"))
            {
                outputUnit = num * 1000;
            }
            if ((inputUnit == "cm") && (expectedUnit == "m"))
            {
                outputUnit = num / 100;
            }
            else if ((inputUnit == "cm") && (expectedUnit == "mm"))
            {
                outputUnit = num * 10;
            }
            if ((inputUnit == "mm") && (expectedUnit == "m"))
            {
                outputUnit = num / 1000;
            }
            else if ((inputUnit == "mm") && (expectedUnit == "cm"))
            {
                outputUnit = num / 10;
            }
            Console.WriteLine($"{outputUnit:F3}");
        }
    }
}
