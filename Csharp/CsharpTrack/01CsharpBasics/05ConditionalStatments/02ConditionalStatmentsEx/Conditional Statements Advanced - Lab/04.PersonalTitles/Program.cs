using System;

namespace _04.PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            if (gender == "m" && age >= 16)
            {
                Console.WriteLine("Mr.");
            }
            else if (gender == "m" && age < 16)
            {
                Console.WriteLine("Master");
            }
            if (gender == "f" && age >= 16)
            {
                Console.WriteLine("Ms.");
            }
            else if (gender == "f" && age < 16)
            {
                Console.WriteLine("Miss");
            }
        }
    }
}
