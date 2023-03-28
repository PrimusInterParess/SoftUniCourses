using System;
using _01Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace _01Demo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SlidoDBContext db = new SlidoDBContext();

            db.Database.Migrate();

  
        }
    }
}
