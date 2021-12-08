using System;
using System.Collections.Generic;

namespace FootBallTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string input = String.Empty;

            Dictionary<string, Team> teams = new Dictionary<string, Team>();


            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = data[0];
                string teamName = data[1];


                try
                {
                    if (command == "Team")
                    {

                        teams[teamName] = new Team(teamName);


                    }
                    else if (command == "Add")
                    {
                        //	"Add;{TeamName};{PlayerName};{Endurance};{Sprint};{Dribble};{Passing};{Shooting}" 

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        string playerName = data[2];
                        int endurance = int.Parse(data[3]);
                        int sprint = int.Parse(data[4]);
                        int dribble = int.Parse(data[5]);
                        int passing = int.Parse(data[6]);
                        int shooting = int.Parse(data[7]);

                        teams[teamName].AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                    }
                    else if (command == "Remove")
                    {
                        teams[teamName].RemovePlayer(data[2]);
                    }
                    else if (command == "Rating")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;

                        }

                        Console.WriteLine($"{teamName} - {teams[teamName].GetAveragePoints}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                   
                }

            }

        }
    }
}
