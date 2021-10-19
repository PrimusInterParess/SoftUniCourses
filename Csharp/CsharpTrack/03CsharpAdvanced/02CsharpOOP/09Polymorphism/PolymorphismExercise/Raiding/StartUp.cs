using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int numberOfHeroes = int.Parse(Console.ReadLine());

            while (heroes.Count < numberOfHeroes)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero hero = GetHero(name, type);

                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                heroes.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());


            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());

                bossPower -= hero.Power;
            }


            Console.WriteLine(bossPower <= 0 ? "Victory!" : "Defeat...");
        }

        private static BaseHero GetHero(string name, string type)
        {
            BaseHero toReturn = null;

            if (type == nameof(Druid))
            {
                toReturn = new Druid(name);
            }
            else if (type == nameof(Paladin))
            {
                toReturn = new Paladin(name);
            }
            else if (type == nameof(Warrior))
            {
                toReturn = new Warrior(name);
            }
            else if (type == nameof(Rogue))
            {
                toReturn = new Rogue(name);
            }


            return toReturn;

        }
    }
}
