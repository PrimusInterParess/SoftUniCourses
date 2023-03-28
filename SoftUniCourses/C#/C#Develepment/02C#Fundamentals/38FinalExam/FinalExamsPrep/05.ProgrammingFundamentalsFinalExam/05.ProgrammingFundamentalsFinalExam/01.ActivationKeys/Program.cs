using System;
using System.Linq;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawData = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Generate")
            {

                string[] command = input.Split(">>>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string action = command[0];

                switch (action)
                {
                    case "Contains":
                        ChecksIfRawDataContainsСpecificSubstring(rawData, command[1]);
                        break;
                    case "Flip":
                        if (command[1] == "Upper")
                        {
                            rawData = TurnsLettersFromLowerToUpper(rawData, int.Parse(command[2]), int.Parse(command[3]));
                        }
                        else
                        {
                            rawData = TurnsLettersFromLowerToLower(rawData, int.Parse(command[2]), int.Parse(command[3]));
                        }
                        break;
                    case "Slice":
                        rawData = RemovesSubstringFromRawData(rawData, int.Parse(command[1]), int.Parse(command[2]));
                        break;

                }

            }

            Console.WriteLine($"Your activation key is: {rawData}");
        }

        private static string RemovesSubstringFromRawData(string rawData, int start, int end)
        {
            rawData = rawData.Remove(start, end - start);

            Console.WriteLine(rawData);

            return rawData;
        }

        private static string TurnsLettersFromLowerToLower(string rawData, int start, int end)
        {
            string toLower = rawData.Substring(start, end-start).ToLower();

            rawData = rawData.Remove(start, end - start);

            rawData = rawData.Insert(start, toLower);

            Console.WriteLine(rawData);

            return rawData;
        }


        private static string TurnsLettersFromLowerToUpper(string rawData, int start, int end)
        {
            string toUpper = rawData.Substring(start, end-start).ToUpper();

            rawData = rawData.Remove(start, end-start);


            rawData = rawData.Insert(start, toUpper);

            Console.WriteLine(rawData);


            return rawData;



        }

        private static void ChecksIfRawDataContainsСpecificSubstring(string rawData, string subStr)
        {
            if (rawData.Contains(subStr))
            {
                Console.WriteLine($"{rawData} contains {subStr}");
            }
            else
            {
                Console.WriteLine($"Substring not found!");
            }
        }
    }
}
