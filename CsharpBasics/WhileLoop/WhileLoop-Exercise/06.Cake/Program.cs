using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLenght = int.Parse(Console.ReadLine());

            int cakeTotalSize = cakeLenght * cakeWidth;
            int sliceCount = 0;
            string command = Console.ReadLine();

            while (command != "STOP")
            {
                int cakeSlice = int.Parse(command);
                cakeTotalSize -= cakeSlice;
                sliceCount++;

                if (cakeTotalSize <= 0)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            string result = string.Empty;

            if (cakeTotalSize > 0)
            {
                result = $"{cakeTotalSize} pieces are left.";
            }
            else
            {
                result = $"No more cake left! You need {Math.Abs(cakeTotalSize)} pieces more.";
            }

            Console.WriteLine(result);
        }
    }
}
