using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainersDictionary = new Dictionary<string, Trainer>();


            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] trainersData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string trainerName = trainersData[0];

                string pokemonName = trainersData[1];

                string pokemonElement = trainersData[2];

                int pokemonHealth = int.Parse(trainersData[3]);

                if (!trainersDictionary.ContainsKey(trainerName))
                {
                    trainersDictionary.Add(trainerName, new Trainer(trainerName));
                }

                Trainer curTrainer = trainersDictionary[trainerName];

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                curTrainer.AddPockemons(pokemon);


            }

            while ((input = Console.ReadLine()) != "End")
            {
                string element = input;

                foreach (var currTrainer in trainersDictionary)
                {
                    if (currTrainer.Value.Pokemons.Any(p => p.Element == element))
                    {
                        currTrainer.Value.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in currTrainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        currTrainer.Value.Pokemons.RemoveAll(p => p.Health <= 10);
                    }
                }


            }

            var result = trainersDictionary
                .OrderByDescending(x => x.Value.Badges)
                .ToDictionary(k=>k.Key,v=>v.Value);

            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key} {pair.Value.Badges} {pair.Value.Pokemons.Count}");
            }
        }

        //private static void ChecksForExistingPokemons(string element, List<Trainer> trainers)
        //{

        //    foreach (var trainer in trainers)
        //    {
        //        if (trainer.Pokemons.Exists(p => p.Element == element))
        //        {
        //            trainer.Badges++;

        //            continue;
        //        }
        //        else
        //        {
        //            foreach (var pokemon in trainer.Pokemons)
        //            {
        //                pokemon.Health -= 10;

        //                if (pokemon.Health <= 0)
        //                {
        //                    trainer.Pokemons.Remove(pokemon);

        //                    if (trainer.Pokemons.Count == 0)
        //                    {
        //                        break;
        //                    }
        //                }
        //            }


        //        }

        //    }

        //}

        //private static void AddTrainers(string[] trainersData, List<Trainer> trainers)
        //{
        //    string trainerName = trainersData[0];

        //    bool hasTrainer = trainers.Exists(t => t.Name == trainerName);

        //    if (hasTrainer)
        //    {
        //        foreach (var trainer in trainers)
        //        {
        //            if (trainer.Name == trainerName)
        //            {
        //                AddPokemon(trainer, trainersData);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Trainer trainer = new Trainer(trainerName);

        //        AddPokemon(trainer, trainersData);

        //        trainers.Add(trainer);
        //    }


        //}

        //static void AddPokemon(Trainer trainer, string[] trainersData)
        //{
        //    string pokemonsName = trainersData[1];

        //    string pokemonsElement = trainersData[2];

        //    int pokemonHealth = int.Parse(trainersData[3]);

        //    trainer.AddPockemons(new Pokemon(pokemonsName, pokemonsElement, pokemonHealth));

        //}
    }
}
