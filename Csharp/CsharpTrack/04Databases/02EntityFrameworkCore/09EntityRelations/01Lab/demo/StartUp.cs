using System;
using EfCoreDemo.Models;

namespace EfCoreDemo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();


            Department department = new Department()
            {
                Name = "HR"
            };

            for (int i = 20; i < 30; i++)
            {
               

                db.Employees.Add(new Employee()
                {
                    FirstName = "Modjo"+i%2,
                    Eng = $"{i*( i * 6)} {i*i}",
                    LastName = "Cosmos"+i*i,
                    FullName = $"{"Modjo"+i%2} {"Cosmos" + i * i}",
                    StartWorkDate = DateTime.UtcNow,
                    Salary = 100 + i,
                    Department = department
                });
            }

            db.SaveChanges();

        }
    }
}
