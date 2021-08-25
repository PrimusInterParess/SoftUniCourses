using System;
using System.Linq;

namespace ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] piretShip = Console.ReadLine().Split('>').Select(int.Parse).ToArray();
            int[] warShip = Console.ReadLine().Split('>').Select(int.Parse).ToArray();

            int maxCapacity = int.Parse(Console.ReadLine());

            string input = string.Empty;

            bool hasWon = false;

            bool hasSinked = false;

            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] command = input.Split();

                string action = command[0];

                switch (action)
                {
                    case "Fire":
                        int index = int.Parse(command[1]);

                        int damage = int.Parse(command[2]);

                        hasWon = PiretShipAttacks(piretShip, warShip, index, damage);

                        break;
                    case "Defend":
                        int startIndex = int.Parse(command[1]);

                        int endIndex = int.Parse(command[2]);

                        int hit = int.Parse(command[3]);

                        hasSinked = PiretShipsDefends(piretShip, warShip, startIndex, endIndex, hit);
                        break;
                    case "Repair":
                        int indexToRepair = int.Parse(command[1]);
                        int health = int.Parse(command[2]);
                        RepairsPiretShip(piretShip, indexToRepair, health, maxCapacity);
                        break;
                    case "Status":
                        ChechsShipsStatus(piretShip, warShip, maxCapacity);
                        break;

                }

                if (hasWon || hasSinked)
                {
                    return;
                }

            }

            Console.WriteLine($"Pirate ship status: {piretShip.Sum()}");

            Console.WriteLine($"Warship status: {warShip.Sum()}");



        }

        private static void ChechsShipsStatus(int[] piretShip, int[] warShip, int maxCapacity)
        {
            int sectionCounter = 0;
            double percentage = 0;

            for (int i = 0; i < piretShip.Length; i++)
            {

                if (piretShip[i] < maxCapacity * 0.2)
                {
                    sectionCounter++;
                }
            }

            Console.WriteLine($"{sectionCounter} sections need repair.");




        }

        private static void RepairsPiretShip(int[] piretShip, int indexToRepair, int health, int maxCapacity)
        {
            if (indexToRepair >= 0 && indexToRepair < piretShip.Length)
            {

                if (piretShip[indexToRepair] + health > maxCapacity) //?
                {
                    piretShip[indexToRepair] = maxCapacity;
                }
                else
                {
                    piretShip[indexToRepair] += health;
                }
            }

        }

        private static bool PiretShipsDefends(int[] piretShip, int[] warShip, int startIndex, int endIndex, int damage)
        {

            if (startIndex >= 0 && startIndex < piretShip.Length && endIndex >= 0 && endIndex < piretShip.Length)
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    piretShip[i] -= damage;

                    if (piretShip[i] <= 0)
                    {
                        Console.WriteLine("You lost! The pirate ship has sunken.");
                        return true;

                    }

                }
            }

            return false;



        }

        private static bool PiretShipAttacks(int[] piretShip, int[] warShip, int index, int damage)
        {

            if (!(index < 0 || index > warShip.Length))
            {
                warShip[index] -= damage;

                if (warShip[index] <= 0)

                {
                    Console.WriteLine("You won! The enemy ship has sunken.");

                    return true;


                }
            }

            return false;

        }

    }
}
