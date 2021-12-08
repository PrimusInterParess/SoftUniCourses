using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace _07PrintNames
{
    class StartUp
    {
        private const string CONNECTION_STR = "Server = .;Integrated Security = true; Database = MinionsDB";

        static void Main(string[] args)
        {
            List<string> MINIONS = GetMInions();
            int backwards = MINIONS.Count;

            for (int i = 0; i < MINIONS.Count; i++)
            {
                Console.WriteLine(MINIONS[i]);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < MINIONS.Count/2; i++)
            {
                Console.WriteLine($"{MINIONS[i]}");
                Console.WriteLine($"{MINIONS[backwards -= 1]}");
            }

            Console.WriteLine(MINIONS[MINIONS.Count / 2]);


        }

        private static List<string> GetMInions()
        {
            List<string> toReturnList = new List<string>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STR))
            {
                connection.Open();

                string queryGetAllNames = "SELECT Name FROM Minions";

                using (SqlCommand command = new SqlCommand(queryGetAllNames, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            toReturnList.Add((string)reader[0]);
                        }

                        return toReturnList;
                    }

                }

            }
        }
    }
}
