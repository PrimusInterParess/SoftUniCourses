using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace _04Add_Minion
{
    class StartUp
    {
        private const string CONNECTION_STR = "Server=.;Integrated Security = true; Database= MinionsDB";
        private const int EVILNESS_FACTOR = 4;

        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STR))
            {
                connection.Open();

                string[] minionsArgs = Console.ReadLine().Split(' ').ToArray();

                string[] villainArgs = Console.ReadLine().Split(' ').ToArray();

                string inputTown = minionsArgs[3];
                string inputVillain = villainArgs[1];
                string inputMinion = minionsArgs[1];
                string minionInputName = minionsArgs[1];

                int? townId = TryGetTown(connection, inputTown);

                if (townId is null)
                {
                    Console.WriteLine(CreateTownInDatabase(connection, inputTown));
                }

                townId = TryGetTown(connection, inputTown);

                int? villainId = TryGetVillainId(connection, inputVillain);

                if (villainId is null)
                {
                    Console.WriteLine(CreateVillainInDatabase(connection, inputVillain));
                    ;

                }

                villainId = TryGetVillainId(connection, inputVillain);

                int? minionId = TryGetMinion(connection, minionInputName);

                if (minionId is null)
                {
                    Console.WriteLine(CreateMinionInDataBase(connection, minionsArgs, townId));
                    
                }

                minionId = TryGetMinion(connection, minionInputName);

                Console.WriteLine(AddMinionToVillain(connection,minionId,villainId, inputVillain, inputMinion));
                


            }
        }

        private static string AddMinionToVillain(SqlConnection connection,int? minionId, int? villainId, string inputVillain, string inputMinion)
        {
            string queryAddMinionToVillain =
                "INSERT INTO MinionsVillains(VillainId, MinionId) VALUES(@VillainId, @MinionId)";

            using (SqlCommand command = new SqlCommand(queryAddMinionToVillain,connection))
            {
                command.Parameters.AddWithValue("@VillainId", villainId);
                command.Parameters.AddWithValue("@MinionId", minionId);

                int result = command.ExecuteNonQuery();

                if (result==0)
                {
                    throw new ArgumentException("Inserting into MinionsVillains failed");
                }

                return $"Successfully added {inputMinion} to be minion of {inputVillain}.";



            }
        }

        private static string CreateMinionInDataBase(SqlConnection connection, string[] minionsArgs,int? townId)
        {
            string queryCreateMinion = "INSERT INTO Minions (Name,Age,TownId) VALUES (@InputName,@InputAge,@InputTownId)";

            using (SqlCommand command = new SqlCommand(queryCreateMinion, connection))
            {
                string name = minionsArgs[1];
                int  age = int.Parse(minionsArgs[2]);

                command.Parameters.AddWithValue("@InputName", name);
                command.Parameters.AddWithValue("@InputAge", age);
                command.Parameters.AddWithValue("@InputTownId", townId);

                int result = command.ExecuteNonQuery();

                if (result==0)
                {
                    throw new ArgumentException("Inserting Minion failed ");
                }

                return $"Minion {name} was added to the database.";

            }


        }

        private static int? TryGetMinion(SqlConnection connection, string minionInputName)
        {
            string queryGetMInion = "SELECT Id FROM Minions WHERE Name = @InputName";

            using (SqlCommand command = new SqlCommand(queryGetMInion, connection))
            {
                command.Parameters.AddWithValue("@InputName", minionInputName);

                int? minionId = (int?)command.ExecuteScalar();

                return minionId;
            }
        }

        private static string CreateVillainInDatabase(SqlConnection connection, string inputVillain)
        {
            string queryCreateVillain = "INSERT INTO Villains (Name,EvilnessFactorId) values (@inputName,@inputEvilnessFactor)";

            using (SqlCommand command = new SqlCommand(queryCreateVillain,connection))
            {
                command.Parameters.AddWithValue("@inputName", inputVillain);
                command.Parameters.AddWithValue("@inputEvilnessFactor", EVILNESS_FACTOR);

                int result = command.ExecuteNonQuery();

                if (result==0)
                {
                    throw new ArgumentException("Inserting Villain failed");
                }

                return $"Villain {inputVillain} was added to the database.";
            }
        }

        private static int? TryGetVillainId(SqlConnection connection, string inputVillain)
        {
            string queryGetVillainName = "SELECT Id FROM Villains WHERE NAME =@InputName";

            using (SqlCommand command = new SqlCommand(queryGetVillainName,connection))
            {
                command.Parameters.AddWithValue("@InputName", inputVillain);

               int? resultt = (int?)command.ExecuteScalar();

               return resultt;
            }
        }

        private static string CreateTownInDatabase(SqlConnection connection, string inputTown)
        {
            string insertTownQuery = "INSERT INTO Towns (Name) VALUES (@inputTownName)";

            using (SqlCommand command = new SqlCommand(insertTownQuery, connection))
            {
                command.Parameters.AddWithValue("@inputTownName", inputTown);

                int result = command.ExecuteNonQuery();

                if (result==0)
                {
                    throw new ArgumentException("Inserting town failed.");

                }

                return $"Town {inputTown} was added to the database.";
            }
        }

        private static int? TryGetTown(SqlConnection connection, string inputTown)
        {

            string queryGetMinionTown = "SELECT Id FROM Towns AS T WHERE T.Name = @IputTownName";

            using (SqlCommand commnad = new SqlCommand(queryGetMinionTown,connection))
            {
                commnad.Parameters.AddWithValue("@IputTownName", inputTown);

                int? town = (int?)commnad.ExecuteScalar();

                return town;
            }

        }
    }
}
