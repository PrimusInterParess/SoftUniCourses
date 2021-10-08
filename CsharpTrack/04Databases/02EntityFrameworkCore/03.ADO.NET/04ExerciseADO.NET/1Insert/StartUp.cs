using System;
using Microsoft.Data.SqlClient;

namespace _1Insert
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = $"Server = .;Integrated Security = true;Database = MinionsDB";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string[] insertStatmenst = GetInsertDataStatments();

                foreach (var query in insertStatmenst)
                {
                    ExecuteNonQuery(query,connection);
                }


            }
        }


        static void ExecuteNonQuery(string query, SqlConnection connection)
        {
            using (SqlCommand commnad = new SqlCommand(query, connection))
            {
                commnad.ExecuteNonQuery();
            }
        }

        private static string[] GetInsertDataStatments()
        {

            string insertQueryForCountries =
                "INSERT INTO Countries (Name) VALUES ('Bulgaria'),('Norway'),('Cyprus'),('Greece'),('England')";

            string insertQueryForTowns =
                "INSERT INTO Towns (Name,CountryCode) VALUES ('Sofia',1),('Oslo',2),('Nicosia',3),('Athens',4),('London',5)";

            string insertQueryForMinions =
                "INSERT INTO Minions (Id,Name,Age,TownId) VALUES (1,'Stewerd',10,1),(2,'Sam',9,2),(3,'Robert',9,3),(4,'Athens',7,4),(5,'James',10,5)";

            string insertQueryForEvilnessFactors =
                "INSERT INTO EvilnessFactors (Name) VALUES ('super good'),('good'),('bad'),('evil'),('super evil')";

            string insertQueryForVillains =
                "INSERT INTO Villains (Name,EvilnessFactorId) VALUES ('Gru the FatBut',1),('Lim The Glim',2),('Clark the Mark',3),('Sam the Drum',4),('Tom the Boom',5)";

            string insertQueryForMinionsVillains =
                "INSERT INTO MinionsVillains (MinionId,VillainId) VALUES (1,5),(2,4),(3,3),(4,2),(5,1)";

            string[] toReturn = new String[]
            {
                insertQueryForCountries,
                insertQueryForTowns,
                insertQueryForMinions,
                insertQueryForEvilnessFactors,
                insertQueryForVillains,
                insertQueryForMinionsVillains
            };


            return toReturn;
        }
        
    }
}
