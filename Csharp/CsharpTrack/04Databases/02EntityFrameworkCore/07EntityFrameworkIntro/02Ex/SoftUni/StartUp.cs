using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext sb = new SoftUniContext();

            string res = AddNewAddressToEmployee(sb);



            Console.WriteLine(res);

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

           var addresses = context.Employees.Select(e => new {e.Address.AddressText, e.Address.AddressId})
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
                .Select(e => new { e.FirstName,e.LastName,e.Salary,e.Department})
                .Where(e => e.Department.Name== "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e=>e.FirstName)
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
                .Select(e => new { e.FirstName,e.Salary, })
                .Where(e=>e.Salary>50000)
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
                .Select(e=>new {e.FirstName,e.LastName,e.MiddleName,e.JobTitle,e.Salary,e.EmployeeId})
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
