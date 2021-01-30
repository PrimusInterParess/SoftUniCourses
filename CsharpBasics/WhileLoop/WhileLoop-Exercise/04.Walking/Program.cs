using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            int totalSpteps = 0;

            bool didReachTheGoal = false;

            while (command != "Going home")
            {
                int steps = int.Parse(command);
                totalSpteps += steps;

                if (totalSpteps >= 10000)
                {
                    didReachTheGoal = true;

                    break;
                }

                command = Console.ReadLine();
            }
            if (didReachTheGoal)
            {
                int stepsOverTheGoal = totalSpteps - 10000;
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsOverTheGoal} steps over the goal!");
            }
            else
            {
                int additoinalSteps = int.Parse(Console.ReadLine());
                totalSpteps += additoinalSteps;

                if (totalSpteps >= 10000)
                {
                    int stepsOverTheGoal = totalSpteps - 10000;
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{stepsOverTheGoal} steps over the goal!");


                }
                else
                {
                    int stepsToReachTheGoal = 10000 - totalSpteps;
                    Console.WriteLine($"{stepsToReachTheGoal} more steps to reach goal.");
                }
            }
        }
    }
}
