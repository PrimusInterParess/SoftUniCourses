using System;

namespace _08.OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMin = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMin;
            int arrivalTime = arrivalHour * 60 + arrivalMin;


            if (arrivalTime > examTime)
            {
                Console.WriteLine("Late");
            }

            else if (arrivalTime >= examTime - 30)
            {
                Console.WriteLine("On time");
            }

            else
            {
                Console.WriteLine("Early");
            }
            int diff = arrivalTime - examTime;
            int hours = Math.Abs(diff / 60);
            int minutes = Math.Abs(diff % 60);
            if (hours > 0)
            {
                if (minutes < 10)
                {
                    Console.Write($"{hours}:0{minutes} hours");
                }
                else
                {
                    Console.Write($"{hours}:{minutes} hours");
                }
            }
            else
            {
                Console.Write(minutes + " minutes");
            }

            if (diff < 0)
            {
                Console.WriteLine(" before the start");
            }
            else
            {
                Console.WriteLine(" after the start");
            }

        }
    }
}
