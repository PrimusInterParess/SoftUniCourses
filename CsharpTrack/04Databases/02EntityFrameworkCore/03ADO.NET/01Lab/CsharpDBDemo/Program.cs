using System;
using System.Net.Sockets;
using Microsoft.Data.SqlClient;
using MyClasses;

namespace CsharpDBDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionStr = "Server=.;Integrated Security=true;Database = SoftUni";

            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                connectionSql.Open();

                string query = "SELECT COUNT(*)" +
                               "FROM Employees";

                string nonQuery = "UPDATE Employees " +
                                  "SET Salary -=10";

                string readerSql = "SELECT [FirstName],[LastName],[JobTitle] FROM Employees " +
                                   "ORDER BY [FirstName]";

                SqlCommand commandSql = new SqlCommand(readerSql, connectionSql);

                SqlDataReader sqlDataReader = commandSql.ExecuteReader();




                while (sqlDataReader.Read())
                {
                  //  Console.WriteLine(sqlDataReader["FirstName"] + " " + sqlDataReader["LastName"]+" "+"====>>>>"+ sqlDataReader["JobTitle"]);
                  Console.WriteLine(sqlDataReader[0]+ "   "+ sqlDataReader[1] +"   " + sqlDataReader[2]);
                  
                }


                //sqlDataReader.Read();
                //Console.WriteLine(sqlDataReader[1]);
                //sqlDataReader.Read();
                //Console.WriteLine(sqlDataReader[1]);
                //sqlDataReader.Read();
                //Console.WriteLine(sqlDataReader[1]);









                //   Console.WriteLine(commandSql.ExecuteNonQuery());


                //   Console.WriteLine(commandSql.ExecuteScalar());

            }




        }
    }
}
