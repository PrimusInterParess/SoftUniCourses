using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterrials = new Dictionary<string, int>();
            Dictionary<string, int> notImportantMaterials = new Dictionary<string, int>();

            keyMaterrials["shards"] = 0;
            keyMaterrials["fragments"] = 0;
            keyMaterrials["motes"] = 0;

            bool gotTheItem = false;


            while (!gotTheItem)
            {
                List<string> mined = Console.ReadLine().Split().ToList();

                while (mined.Count != 0)
                {
                    string good = mined[1].ToLower();

                    if (good == "shards" || good == "fragments" || good == "motes")
                    {
                        if (keyMaterrials.ContainsKey(good))
                        {
                            keyMaterrials[good] += int.Parse(mined[0]);
                            mined.RemoveAt(0);
                            mined.RemoveAt(0);

                            if (keyMaterrials[good] >= 250)
                            {
                                keyMaterrials[good] -= 250;

                                if (good == "fragments")
                                {
                                    Console.WriteLine("Valanyr obtained!");

                                }
                                else if (good == "shards")
                                {
                                    Console.WriteLine("Shadowmourne obtained!");

                                }
                                else if (good == "motes")
                                {
                                    Console.WriteLine("Dragonwrath obtained!");

                                }

                                gotTheItem = true;
                                break;

                            }

                        }
                        else
                        {
                            keyMaterrials.Add(good, int.Parse(mined[0]));
                            mined.RemoveAt(0);
                            mined.RemoveAt(0);

                            if (keyMaterrials[good] >= 250)
                            {
                                keyMaterrials[good] -= 250;

                                if (good == "fragments")
                                {
                                    Console.WriteLine("Valanyr obtained!");

                                }
                                else if (good == "Shadowmourne")
                                {
                                    Console.WriteLine("Shadowmourne obtained!");

                                }
                                else if (good == "Dragonwrath")
                                {
                                    Console.WriteLine("Dragonwrath obtained!");

                                }

                                gotTheItem = true;

                            }
                        }

                    }
                    else
                    {
                        if (notImportantMaterials.ContainsKey(good))
                        {
                            notImportantMaterials[good] += int.Parse(mined[0]);
                            mined.RemoveAt(0);
                            mined.RemoveAt(0);
                        }
                        else
                        {
                            notImportantMaterials.Add(good, int.Parse(mined[0]));
                            mined.RemoveAt(0);
                            mined.RemoveAt(0);
                        }
                    }
                   

                }
                
            }

            keyMaterrials = keyMaterrials.OrderByDescending(x => x.Value).ThenBy(k => k.Key).ToDictionary(a => a.Key, a => a.Value);

            foreach (var item in keyMaterrials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in notImportantMaterials.OrderBy(x=> x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");

            }



        }
    }
}
