using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _06WordCruncher
{
    class Program
    {
        private static string target;
        private static string current;


        private static Dictionary<int, List<string>> wordsByLen;
        private static Dictionary<string, int> occurances;


        private static List<string> selectedWords { get; set; }

        private static HashSet<string> results;

        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ").ToArray();

            target = Console.ReadLine();

            wordsByLen = new Dictionary<int, List<string>>();

            occurances = new Dictionary<string, int>();

            selectedWords = new List<string>();

            results = new HashSet<string>();

            foreach (var word in words)
            {
                if (!target.Contains(word))
                {
                    continue;

                }

                int len = word.Length;

                if (!wordsByLen.ContainsKey(len))
                {
                    wordsByLen.Add(len, new List<string>());
                }

                wordsByLen[len].Add(word);


                if (occurances.ContainsKey(word))
                {
                    occurances[word] += 1;
                }
                else
                {
                    occurances.Add(word, 1);
                }



            }

            current = string.Empty;
            GenerateSolution(target.Length);
            Console.WriteLine(string.Join(Environment.NewLine, results));
        }

        private static void GenerateSolution(int len)
        {
            if (len == 0)
            {
                if (current == target)
                {
                    results.Add(string.Join(" ", selectedWords));
                }

                return;
            }


            foreach (var kvp in wordsByLen)
            {
                if (kvp.Key > len)
                {
                    continue;
                }

                foreach (var word in kvp.Value)
                {

                    if (occurances[word] > 0)
                    {

                        current += word;

                        if (isMatchSoFar(target, current))
                        {
                            occurances[word] -= 1;

                            selectedWords.Add(word);

                            GenerateSolution(len - kvp.Key);

                            occurances[word] += 1;

                            selectedWords.RemoveAt(selectedWords.Count - 1);


                        }

                        current = current.Remove(current.Length - word.Length, word.Length);

                    }
                }
            }
        }

        private static bool isMatchSoFar(string expected, string actual)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
