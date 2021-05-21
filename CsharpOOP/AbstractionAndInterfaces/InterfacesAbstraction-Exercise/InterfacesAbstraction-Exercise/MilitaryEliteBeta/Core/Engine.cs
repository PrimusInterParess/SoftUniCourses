using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Contracts;
using MilitaryElite.Core.Contracts;
using MilitaryElite.Exeptions;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Models;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
        : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;

            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] commandArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string soldierType = commandArg[0];

                ISoldier soldier = null;

                string id = commandArg[1];
                string firstName = commandArg[2];
                string lastName = commandArg[3];

                if (soldierType == nameof(Private))
                {
                    decimal salary = decimal.Parse(commandArg[4]);

                    soldier = new Private(id, firstName, lastName, salary);
                }
                if (soldierType == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(commandArg[4]);

                    ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    foreach (var prId in commandArg.Skip(5))
                    {
                        ISoldier privateToAdd = this.soldiers.First(s => s.Id == prId);

                        general.AddPrivate(privateToAdd);
                    }

                    soldier = general;

                }
                if (soldierType == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(commandArg[4]);

                    string corps = commandArg[5];

                    try
                    {
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        string[] repArgs = commandArg.Skip(6).ToArray();

                        for (int i = 0; i < repArgs.Length; i += 2)
                        {
                            string partName = repArgs[i];
                            int hours = int.Parse(repArgs[i + 1]);

                            IRepair repair = new Repair(partName, hours);

                            engineer.AddRepair(repair);
                        }

                        soldier = engineer;

                    }
                    catch (InvalidCorpsExeption ex)
                    {
                        continue;
                    }



                }
                if (soldierType == nameof(Comando))
                {
                    decimal salary = decimal.Parse(commandArg[4]);

                    string corps = commandArg[5];

                    try
                    {
                        IComando comando = new Comando(id, firstName, lastName, salary, corps);

                        string[] missionArgs = commandArg.Skip(6).ToArray();

                        for (int i = 0; i < missionArgs.Length; i += 2)
                        {

                            try
                            {
                                string mName = missionArgs[i];
                                string state = missionArgs[i + 1];

                                IMission mission = new Mission(mName, state);

                                comando.AddMission(mission);
                            }
                            catch (InvalidMissionCopletionException ex)
                            {
                                continue;
                            }

                        }

                        soldier = comando;
                    }
                    catch (InvalidCorpsExeption e)
                    {
                        continue;
                    }
                }
                if (soldierType == nameof(Spy))
                {
                    int codeNum = int.Parse(commandArg[4]);

                    soldier = new Spy(id, firstName, lastName, codeNum);
                }

                if (soldier != null)
                {

                    this.soldiers.Add(soldier);
                }




            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }
    }
}