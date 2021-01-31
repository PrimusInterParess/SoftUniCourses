using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            int dayCount = 0;
            int totalMined = 0;

            if (yield < 100)
            {
                Console.WriteLine(dayCount);
                Console.WriteLine(totalMined);
            }
            else
            {
                while (yield >= 100)
                {
                    totalMined += yield - 26;
                    yield -= 10;
                    dayCount++;


                }

                totalMined -= 26;
                Console.WriteLine(dayCount);
                Console.WriteLine(totalMined);
            }
        }
    }
}
