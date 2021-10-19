using System;
using Microsoft.Data.SqlClient;

namespace _6RemoveVillain
{
    class StartUp
    {
        private const string CONNECTION_STR = "Server = . ;Integrated security = true; Database = MinionsDB";

        static void Main(string[] args)
        {

            int villainInputId = int.Parse(Console.ReadLine());

            string villainName = GetVillainName(villainInputId);

            if (villainName is null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            int numberOfMinionsServants = GetNumberOfMinions(villainInputId);

            ReleaseMinionsFromVillain(villainInputId);
            DeleteVillainById(villainInputId);

            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{numberOfMinionsServants} minions were released.");
        }

        private static void DeleteVillainById(int villainInputId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STR))
            {
                connection.Open();

                string queryGetName = "DELETE FROM Villains WHERE Id = @inputId";

                using (SqlCommand command = new SqlCommand(queryGetName, connection))
                {
                    command.Parameters.AddWithValue("@inputId", villainInputId);

                    command.ExecuteNonQuery();
                }
            }
        }

        private static void ReleaseMinionsFromVillain(int villainInputId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STR))
            {
                connection.Open();

                string queryGetName = "DELETE FROM MinionsVillains WHERE VillainId = @inputId";

                using (SqlCommand command = new SqlCommand(queryGetName, connection))
                {
                    command.Parameters.AddWithValue("@inputId", villainInputId);

                    command.ExecuteNonQuery();
                }
            }

        }

        private static int GetNumberOfMinions(int villainInputId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STR))
            {
                connection.Open();

                string queryGetMinionsCount = "SELECT count(*) FROM MinionsVillains WHERE VillainId = @inputId";

                using (SqlCommand command = new SqlCommand(queryGetMinionsCount, connection))
                {
                    command.Parameters.AddWithValue("@inputId", villainInputId);

                    int nameToReturn = (int)command.ExecuteScalar();

                    return nameToReturn;
                }
            }

        }

        private static string GetVillainName(int villainInputId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STR))
            {
                connection.Open();

                string queryGetName = "SELECT Name FROM Villains WHERE Id = @inputId";

                using (SqlCommand command = new SqlCommand(queryGetName,connection))
                {
                    command.Parameters.AddWithValue("@inputId", villainInputId);

                    string nameToReturn = (string)command.ExecuteScalar();

                    return nameToReturn;
                }
            }
        }
    }
}
