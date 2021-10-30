using System;
using System.Linq;
using EfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();


            Department hr = new Department() { Name = "HR" };
            Department it = new Department() { Name = "IT" };
            Department bs = new Department() { Name = "BS" };

            for (int i = 0; i < 11; i++)
            {
                if (i % 5 == 0)
                {
                    db.Employees.Add(new Employee()
                    {
                        FirstName = "Modjo" + i,
                        EGN = $"{i + 3}{i + 2}{i + 1}{i + 0}{i + 2}{i + 5}{i + 4}{i + 6} +m+{i}",
                        LastName = "Cosmos" + i,
                        Department = it,
                        StartWorkDate = DateTime.UtcNow,
                        Salary = 100,


                    });
                }

                if (i % 3 == 0)
                {
                    db.Employees.Add(new Employee()
                    {
                        FirstName = "Modjo" + i,
                        EGN = $"{i + 3}{i + 2}{i + 1}{i + 0}{i + 7}{i + 5}{i + 4}{i + 6}+f+{i}",
                        LastName = "Cosmos" + i,
                        Department = bs,
                        StartWorkDate = DateTime.UtcNow,
                        Salary = 100


                    });
                }

                if (i % 2 == 0)
                {
                    db.Employees.Add(new Employee()
                    {
                        FirstName = "Modjo" + i,
                        EGN = $"{i + 3}{i + 2}{i + 1}{i + 0}{i + 7}{i + 5}{i + 4}{i + 6}+h{i+2}",
                        LastName = "Cosmos" + i,
                        Department = hr,
                        StartWorkDate = DateTime.UtcNow,
                        Salary = 100,


                    });
                }




            }



            //Department department = new Department()
            //{
            //    Name = "HR"
            //};

            //for (int i = 20; i < 30; i++)
            //{


            //    db.Employees.Add(new Employee()
            //    {
            //        FirstName = "Modjo"+i%2,
            //        Eng = $"{i*( i * 6)} {i*i}",
            //        LastName = "Cosmos"+i*i,
            //        FullName = $"{"Modjo"+i%2} {"Cosmos" + i * i}",
            //        StartWorkDate = DateTime.UtcNow,
            //        Salary = 100 + i,
            //        Department = department
            //    });
            //}

            db.SaveChanges();


            var obj = db.Departments.Select(d => new {d.Id, d.Name, d.EmployeesInDepartment}).Where(d => d.Id == 3);



        


        }
    }
}
