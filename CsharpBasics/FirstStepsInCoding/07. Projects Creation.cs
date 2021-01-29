using System;

namespace _07._Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string architectName = Console.ReadLine();
            int projectNumber = int.Parse(Console.ReadLine());
            int project = 3 * projectNumber;
            Console.WriteLine($"The architect {architectName} will need {project} hours to complete {projectNumber} project/s.");
        }
    }
}
