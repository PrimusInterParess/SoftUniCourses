using System;

namespace _09.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            double wildth = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double Hight = double.Parse(Console.ReadLine());

            double totalRoomVolume = wildth * Hight * lenght;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Done")
                {
                    Console.WriteLine($"{totalRoomVolume} Cubic meters left.");
                    break;
                }

                int boxes = int.Parse(input);
                totalRoomVolume -= boxes;

                if (totalRoomVolume < 0)
                {

                    Console.WriteLine($"No more free space! You need {Math.Abs(totalRoomVolume)} Cubic meters more.");
                    break;
                }

            }
        }
    }
}
