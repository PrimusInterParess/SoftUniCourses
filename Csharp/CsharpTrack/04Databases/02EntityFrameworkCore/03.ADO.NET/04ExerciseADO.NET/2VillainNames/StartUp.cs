using System;
using Microsoft.Data.SqlClient;

namespace _2VillainNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionStr = $"Server=.;Integrated Security = true;Database=MinionsDB";

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string query = @"SELECT V.Name, COUNT(MV.MinionId)
	                               FROM MinionsVillains AS MV
	                                JOIN Villains AS V ON MV.VillainId = V.Id
			                         JOIN Minions AS M ON MV.MinionId =M.Id
	                                  GROUP BY V.Id,V.Name";
	                                  // " HAVING COUNT(MV.MinionId)>3";


                using (SqlCommand command = new SqlCommand(query,connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            string currentRow =(string)reader[0];
                           int count =(int)reader[1];

                           Console.WriteLine($"{currentRow} - {count}");
                        }
                    }

                   
                }
            }
        }
    }
}
