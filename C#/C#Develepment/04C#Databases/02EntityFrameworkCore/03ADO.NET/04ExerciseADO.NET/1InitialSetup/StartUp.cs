using System;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace _1InitialSetup
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string serverLogData = "Server=.;Integrated Security=true;Database = MinionsDB";

            using (SqlConnection connection = new SqlConnection(serverLogData))
            {
                connection.Open();

               // string databaseName = "MinionsDB";

               // string queryCreateDataBase = CreatingDatabase(databaseName);

               string[] tables = CreatingDatabaseTables();

               foreach (var createStatment in tables)
               {
                    ExecuteNonQuery(createStatment,connection);   
               }
            }
        }

        static string CreatingDatabase(string dataBaseName)
        {

            return $"CREATE DATABASE {dataBaseName}";
        }

        static string[] CreatingDatabaseTables()
        {

            string[] createingTablesArr = new String[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY NOT NULL,Name VARCHAR(50) NOT NULL)",
                "CREATE TABLE Towns (Id INT PRIMARY KEY IDENTITY NOT NULL,Name VARCHAR(50) NOT NULL,CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions (Id INT PRIMARY KEY NOT NULL,Name VARCHAR(50),Age INT NOT NULL,TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL)",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY NOT NULL,Name VARCHAR(50) NOT NULL)",
                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY NOT NULL,Name VARCHAR(50) NOT NULL,EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id) CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId,VillainId))"
            };

            return createingTablesArr;

        }

        static void ExecuteNonQuery(string query, SqlConnection connection)
        {
            using (SqlCommand commnad = new SqlCommand(query, connection))
            {
                commnad.ExecuteNonQuery();
            }
        }
    }
}
