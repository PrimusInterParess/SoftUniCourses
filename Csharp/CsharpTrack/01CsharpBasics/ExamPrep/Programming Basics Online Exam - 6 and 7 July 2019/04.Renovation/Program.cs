using System;

namespace _04.Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            double hight = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double notPaintedPercentage = double.Parse(Console.ReadLine());

            double area = hight * 1.0 * width * 4;
            double toBePinted = area - ((area * notPaintedPercentage) / 100);




            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Tired!")
                {
                    Console.WriteLine($"{toBePinted} quadratic m left.");
                    break;
                }

                int paintInLitters = int.Parse(command);

                toBePinted -= paintInLitters;

                if (toBePinted < 0)
                {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(toBePinted)} l paint left!");
                    break;
                }
                else if (toBePinted == 0)
                {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                    break;
                }
            }
    }
}
