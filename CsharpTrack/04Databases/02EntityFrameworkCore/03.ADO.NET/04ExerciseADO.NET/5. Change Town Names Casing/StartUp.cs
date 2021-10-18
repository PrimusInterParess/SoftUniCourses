using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace _5._Change_Town_Names_Casing
{
    class StartUp
    {
        private const string CONNECTION_STRING = "Server = .;Integrated Security = true; Database = MinionsDB";

        static void Main(string[] args)
        {

            string inputCountryName = Console.ReadLine();

            int? countryId = GetCountryId(inputCountryName);

            if (countryId is null)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            int numbOfChangedTowns = UpdatingTownNamesCasingByCountry(countryId);

            if (numbOfChangedTowns == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            List<string> townsName = GetTownsNameByCountry(countryId);

            Console.WriteLine($"{numbOfChangedTowns} town names were affected.");
            Console.WriteLine($"[{string.Join(", ", townsName)}]");

        }

        private static List<string> GetTownsNameByCountry(int? countryId)
        {
            List<string> toReturn = new List<string>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string queryUpdateNames = "SELECT Name FROM Towns WHERE CountryCode = @InputCountryCode";

                using (SqlCommand command = new SqlCommand(queryUpdateNames, connection))
                {
                    command.Parameters.AddWithValue("@InputCountryCode", countryId);

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            string townName = (string) dataReader[0];
                            toReturn.Add(townName);
                        }

                        return toReturn;
                    }
                }

            }
        }

        private static int UpdatingTownNamesCasingByCountry(int? countryId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string queryUpdateNames = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = @InputCountryCode";

                using (SqlCommand command = new SqlCommand(queryUpdateNames, connection))
                {
                    command.Parameters.AddWithValue("@InputCountryCode", countryId);

                    int result = command.ExecuteNonQuery();

                    return result;
                }
            }
        }

        private static int? GetCountryId(string inputCountryName)
        {

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string queryGetCountryId = "SELECT Id FROM Countries WHERE Name LIKE @InputName";

                using (SqlCommand command = new SqlCommand(queryGetCountryId, connection))
                {
                    command.Parameters.AddWithValue("@InputName", inputCountryName);

                    return (int?)command.ExecuteScalar();
                }
            }
        }
    }
}
