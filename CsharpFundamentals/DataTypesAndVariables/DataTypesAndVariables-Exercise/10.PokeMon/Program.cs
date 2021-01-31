using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int target = 0;

            double pokeDouble = pokePower * 0.50;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                target++;

                if (pokePower == pokeDouble && exhaustionFactor != 0)
                {

                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(target);
        }
    }
}
