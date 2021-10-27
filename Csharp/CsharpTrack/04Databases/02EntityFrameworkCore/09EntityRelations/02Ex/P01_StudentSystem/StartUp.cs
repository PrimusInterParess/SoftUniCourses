using System;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem
{
   public class StartUp
    {
     public static void Main(string[] args)
     {
         StudentSystemContext db = new StudentSystemContext();

         db.Database.EnsureDeleted();

         db.Database.EnsureCreated();
     }
    }
}
