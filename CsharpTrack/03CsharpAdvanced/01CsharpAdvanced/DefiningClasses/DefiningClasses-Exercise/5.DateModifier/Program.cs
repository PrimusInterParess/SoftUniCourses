using System;

namespace _5.DateModifier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string startDate = Console.ReadLine();

            string endDate = Console.ReadLine();

            int days = DateModifier.ReturnsTotalDays(startDate, endDate);

            Console.WriteLine(days);
        }
    }
}
