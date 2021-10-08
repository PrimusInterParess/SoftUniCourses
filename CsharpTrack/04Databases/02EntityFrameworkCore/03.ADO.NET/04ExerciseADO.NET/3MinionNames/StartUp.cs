using System;
using Microsoft.Data.SqlClient;

namespace _3MinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());


            string connectionStr = "Server=.;Integrated Security = true;Database = MinionsDB";

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string queryVillain = $"SELECT NAME FROM Villains WHERE ID = @InputID";

                using (SqlCommand command = new SqlCommand(queryVillain, connection))
                {


                    command.Parameters.AddWithValue("@InputID", villainId);

                    string villan = (string)command.ExecuteScalar();

                    if (villan != null)
                    {
                        Console.WriteLine($"Villian: {villan}");

                        string minionsQuery = $@"SELECT M.Name,M.Age
                                	FROM
	                                	MinionsVillains AS VM 
	                    		        JOIN Villains AS V ON V.Id=VM.VillainId
	                    		        	JOIN Minions AS M ON M.Id = VM.MinionId
	                    		WHERE V.ID={villainId}";


                        using (SqlCommand commandMinionsCheck = new SqlCommand(minionsQuery,connection))
                        {
                            using (SqlDataReader dataReader = commandMinionsCheck.ExecuteReader())
                            {

                                if (!dataReader.HasRows)
                                {
                                    Console.WriteLine("(no minions)");
                                }
                                else
                                {
                                    int count = 1;
                                    while (dataReader.Read())
                                    {
                                        string name = (string)dataReader[0];
                                        int age = (int)dataReader[1];

                                        Console.WriteLine($"{count}. {name} {age}");
                                        count++;
                                    }
                                }
                                  
                                
                            }
                        }
                       
                    }
                    else
                    {
                        Console.WriteLine($"No villain with ID {villainId} in the database.");
                    }

                }
            }
        }
    }
}
