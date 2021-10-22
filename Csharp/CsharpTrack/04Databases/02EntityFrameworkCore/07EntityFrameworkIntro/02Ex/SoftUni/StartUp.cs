using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            string res = GetEmployee147(db);

            Console.WriteLine(res);

        }

        public static string GetEmployee147(SoftUniContext context)
        {
            int empId = 147;

            var res = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(e => e.Project)
                .Where(e => e.EmployeeId == empId)
                .Select(e => new
                {
                   FirstName= e.FirstName, LastName=e.LastName,JobTitle= e.JobTitle,Projects = e.EmployeesProjects.Select
                    (p => new
                        {
                            ProjectName = p.Project.Name
                        }
                    )
                }).ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var employee in res)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                foreach (var project in employee.Projects.OrderBy(p=>p.ProjectName))
                {
                    sb.AppendLine(project.ProjectName);
                }
            }

            return sb.ToString().TrimEnd();

        }



        public static string GetAddressesByTown(SoftUniContext context)
        {
          var res =  context.Addresses
              .Select(a => new {a.AddressText, a.Town.Name, a.Employees.Count})
              .Take(10)
              .OrderByDescending(c=>c.Count)
              .ThenBy(t=>t.Name)
              .ThenBy(t=>t.AddressText)
              .ToList();

          StringBuilder sb = new StringBuilder();

          foreach (var adr in res)
          {
              sb.AppendLine($"{adr.AddressText}, {adr.Name} - {adr.Count} employees");
          }

          return sb.ToString().TrimEnd();


        }

        public static string GetEmployeesInPeriod(SoftUniContext db)
        {

            var employees = db
                .Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(e => e.Project)
                .Where(p => p.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(
                    e => new
                    {
                        empFirstName = e.FirstName,
                        empLastName = e.LastName,
                        mngFirstName = e.Manager.FirstName,
                        mngLastName = e.Manager.LastName,
                        Projects = e.EmployeesProjects.Select
                            (
                            p =>
                                new
                                {
                                    ProjectName = p.Project.Name,
                                    StartDate = p.Project.StartDate,
                                    EndDate = p.Project.EndDate
                                }

                            )
                    })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.empFirstName} {employee.empLastName} - Manager: {employee.mngFirstName} {employee.mngLastName}");

                foreach (var project in employee.Projects)
                {
                    var endDate = project.EndDate == null ? "not finished" : project.EndDate.ToString();

                    sb.AppendLine(
                        $"--{project.ProjectName} - {project.StartDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();

        }



        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);

            context.SaveChanges();

            Employee employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = address;

            context.SaveChanges();

            var addresses = context.Employees.Select(e => new { e.Address.AddressText, e.Address.AddressId })
                 .OrderByDescending(e => e.AddressId).Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address1 in addresses)
            {
                sb.AppendLine(address1.AddressText);
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var res = context.Employees
                .Select(e => new { e.FirstName, e.LastName, e.Salary, e.Department })
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var obj in res)
            {
                sb.AppendLine($"{obj.FirstName} {obj.LastName} from {obj.Department.Name} - ${obj.Salary:f2}");
            }

            return sb.ToString().TrimEnd();


        }


        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var res = context.Employees
                .Select(e => new { e.FirstName, e.Salary, })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var obj in res)
            {
                sb.AppendLine($"{obj.FirstName} - {obj.Salary:F2}");
            }

            return sb.ToString().TrimEnd();


        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var res = context.Employees
                .Select(e => new { e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary, e.EmployeeId })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var obj in res)
            {
                sb.AppendLine($"{obj.FirstName} {obj.LastName} {obj.MiddleName} {obj.JobTitle} {obj.Salary:F2}");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
