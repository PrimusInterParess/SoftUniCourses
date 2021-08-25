using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Hero
    {
        public string Name { get; set; }

        public int MP { get; set; }

        public int HP { get; set; }

        public Hero(string name, int mp, int hp)
        {
            Name = name;
            MP = mp;
            HP = hp;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Hero> herosList = new List<Hero>();


            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                herosList.Add(new Hero(data[0], int.Parse(data[2]), int.Parse(data[1])));
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (command[0])
                {
                    case "CastSpell":
                        Cast(herosList, command[1], int.Parse(command[2]), command[3]);
                        break;
                    case "TakeDamage":
                        TakesDamage(herosList, command[1], int.Parse(command[2]), command[3]);
                        break;
                    case "Recharge":
                        Recharge(herosList, command[1], int.Parse(command[2]));
                        break;
                    case "Heal":
                        Heal(herosList, command[1], int.Parse(command[2]));
                        break;
                }
            }

            foreach (Hero hero in herosList.OrderByDescending(h => h.HP).ThenBy(h => h.Name))
            {
                StringBuilder toPrint = new StringBuilder();

                toPrint.AppendLine(hero.Name);
                toPrint.AppendLine($"  HP: {hero.HP}");
                toPrint.AppendLine($"  MP: {hero.MP}");

                Console.WriteLine(toPrint);
            }
        }

        private static void Heal(List<Hero> herosList, string heroName, int healing)
        {
            foreach (Hero hero in herosList)
            {
                if (hero.Name == heroName)
                {
                   

                    if (hero.HP + healing> 100)
                    {
                        healing = 100-hero.HP;

                        
                    }

                    hero.HP += healing;

                    Console.WriteLine($"{hero.Name} healed for {healing} HP!");
                    return;
                   
                }
            }
        }

        private static void Recharge(List<Hero> herosList, string heroName, int mpToAdd)
        {
            foreach (Hero hero in herosList)
            {
                if (hero.Name == heroName)
                {
                    int mpNeeded = 200 - hero.MP;


                    if (hero.MP + mpToAdd > 200)
                    {
                        mpToAdd = 200 - hero.MP;
                    }

                    hero.MP += mpToAdd;

                    Console.WriteLine($"{hero.Name} recharged for {mpToAdd} MP!");
                    return;

                }
            }
        }

        private static void TakesDamage(List<Hero> herosList, string heroName, int damage, string attacker)
        {
            foreach (Hero hero in herosList)
            {
                if (hero.Name == heroName)
                {
                    hero.HP -= damage;

                    if (hero.HP > 0)
                    {
                        Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.HP} HP left!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
                        herosList.Remove(hero);
                        return;
                    }
                }
            }
        }

        private static void Cast(List<Hero> heroes, string heroName, int neededMP, string spellName)
        {
            if (neededMP > 200)
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                return;
            }
            else
            {
                foreach (Hero hero in heroes)
                {
                    if (hero.Name == heroName)
                    {
                        if (hero.MP >= neededMP)
                        {
                            hero.MP -= neededMP;

                            Console.WriteLine($"{hero.Name} has successfully cast {spellName} and now has {hero.MP} MP!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"{hero.Name} does not have enough MP to cast {spellName}!");
                            return;
                        }
                    }
                }
            }


        }
    }
}

