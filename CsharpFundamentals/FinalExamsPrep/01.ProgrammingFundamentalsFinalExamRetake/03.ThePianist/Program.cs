using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Piece
    {
        public string Name { get; set; }

        public string Composer { get; set; }

        public string Key { get; set; }

        public override string ToString()
        {
            return $"{Name} -> Composer: {Composer}, Key: {Key}";
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Piece> musicalWorks = new List<Piece>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                musicalWorks.Add(new Piece { Name = data[0], Composer = data[1], Key = data[2] });
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] command = input.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (command[0])
                {
                    case "Add":
                        Add(musicalWorks, command[1], command[2], command[3]);
                        break;
                    case "Remove":
                        Remove(musicalWorks, command[1]);
                        break;
                    case "ChangeKey":
                        ChangeKey(musicalWorks, command[1], command[2]);
                        break;

                }
            }

            foreach (Piece piece in musicalWorks.OrderBy(x => x.Name).ThenBy(x => x.Composer))
            {
                Console.WriteLine(piece);
            }
        }

        private static void ChangeKey(List<Piece> musicalWorks, string piece, string keyToBeRenewed)
        {
            foreach (Piece musicPiece in musicalWorks)
            {
                if (musicPiece.Name == piece)
                {
                    musicPiece.Key = keyToBeRenewed;

                    Console.WriteLine($"Changed the key of {piece} to {keyToBeRenewed}!");

                    return;
                }
            }

            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
        }

        private static void Remove(List<Piece> musicalWorks, string toRemove)
        {


            foreach (Piece piece in musicalWorks)
            {
                if (piece.Name == toRemove)
                {
                    musicalWorks.Remove(piece);

                    Console.WriteLine($"Successfully removed {toRemove}!");
                    return;
                }
            }



            Console.WriteLine($"Invalid operation! {toRemove} does not exist in the collection.");

        }

        private static void Add(List<Piece> musicalWorks, string name, string composer, string key)
        {
            bool exists = false;

            foreach (Piece piece in musicalWorks)
            {
                if (piece.Name == name)
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                Console.WriteLine($"{name} is already in the collection!");
            }
            else
            {
                musicalWorks.Add(new Piece { Name = name, Composer = composer, Key = key });

                Console.WriteLine($"{name} by {composer} in {key} added to the collection!");
            }
        }
    }
}
