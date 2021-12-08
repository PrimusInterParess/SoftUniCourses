using System;

using P01_HospitalDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace P01_HospitalDatabase
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            HospitalContext db = new HospitalContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
