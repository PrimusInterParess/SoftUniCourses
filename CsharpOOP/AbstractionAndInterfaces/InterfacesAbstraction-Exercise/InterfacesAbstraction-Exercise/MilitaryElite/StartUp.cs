using System;
using System.Collections.Generic;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;

                }

                string[] parts = line.Split();

                string type = parts[0];
                string id = parts[1];
                string firstName = parts[2];
                string lastName = parts[3];


                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(parts[4]);

                    soldiers[id] = new Private(id, firstName, lastName, salary);
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(parts[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < parts.Length; i++)
                    {
                        string privateId = parts[i];

                        if (!soldiers.ContainsKey(privateId))
                        {
                            continue;

                        }

                        lieutenantGeneral.AddPrivate((IPrivate)soldiers[privateId]);
                    }

                    soldiers[id] = lieutenantGeneral;
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(parts[4]);

                    bool isCorpsValid = Enum.TryParse(parts[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                        
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < parts.Length; i+=2)
                    {
                        string part = parts[i];
                        int hourWorked = int.Parse(parts[i + 1]);

                        IRepair repair = new Repair(part, hourWorked);

                        engineer.AddRepair(repair);
                    }

                    soldiers[id] = engineer;

                }
                else if (type == nameof(Comando))
                {

                    decimal salary = decimal.Parse(parts[4]);

                    bool isCorpsValid = Enum.TryParse(parts[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;

                    }

                    IComando comando = new Comando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < parts.Length; i += 2)
                    {
                        string codeName = parts[i];
                        string state =parts[i + 1];

                        bool isMissionStateValid = Enum.TryParse(parts[5], out MissionState missionState);

                        if (!isMissionStateValid)
                        {
                            continue;

                        }

                        IMission misson = new Mission(codeName, missionState);

                        comando.AddMission(misson);
                    }

                    soldiers[id] = comando;


                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(parts[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers[id] = spy;
                }

            }

            foreach (var soldier in soldiers.Values)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
