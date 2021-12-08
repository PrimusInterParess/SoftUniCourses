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

            string res = RemoveTown(db);

            Console.WriteLine(res);

        }

        public static string RemoveTown(SoftUniContext context)
        {

            Town town = context.Towns.Include(t => t.Addresses).FirstOrDefault(t => t.Name == "Seattle");

            var numberOfAdresses = town.Addresses.Count;

            List<Address> addressesToRemove = town.Addresses.ToList();

            var employees = context
                .Employees
                .Include(e => e.Address)
                .Where(e=>addressesToRemove
                    .Contains(e.Address)).ToList();

            foreach (var employee in employees)
            {

                if (addressesToRemove.Contains(employee.Address))
                {
                    employee.AddressId = null;
                    context.SaveChanges();
                }
                

            }


            context.RemoveRange(addressesToRemove);

            context.SaveChanges();

            context.Towns.Remove(town);

            context.SaveChanges();



            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"{numberOfAdresses} addresses in {town.Name} were deleted");


            return sb.ToString().TrimEnd();

        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            int projId = 2;

            var toRemove = context.Projects.FirstOrDefault(p => p.ProjectId == projId);

            var emloyees = context.Employees
                .Include(e => e.EmployeesProjects)
                .Where(e => e.EmployeesProjects.Any(e => e.ProjectId == projId))
                .ToList();

            foreach (var emp in emloyees)
            {
                foreach (var proj in emp.EmployeesProjects)
                {
                    if (proj.ProjectId == projId)
                    {
                        emp.EmployeesProjects.Remove(proj);
                        context.SaveChanges();
                        break;
                    }
                }
            }

            context.Projects.Remove(toRemove);

            context.SaveChanges();

            var projects = context.Projects.Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var varrr in projects)
            {
                sb.AppendLine(varrr.Name);
            }

            return sb.ToString().TrimEnd();

        }


        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var varr = context.Employees
                .Select(e => new
                {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    jobtitle = e.JobTitle,
                    salary = e.Salary
                })
                .Where(e => e.firstName.StartsWith("Sa"))
                .OrderBy(e => e.firstName)
                .ThenBy(e => e.lastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in varr)
            {
                sb.AppendLine($"{emp.firstName} {emp.lastName} - {emp.jobtitle} - (${emp.salary:f2})");
            }

            return sb.ToString().TrimEnd();

        }


        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departmentsList = context.Departments
                .Include(d => d.Employees)
                .Select
                    (d => new
                    {
                        dName = d.Name,
                        mng = d.Manager,
                        employees = d.Employees
                    }
                    )
                .Where(d => d.employees.Count > 5)
                .OrderBy(d => d.employees.Count)
                .ThenBy(d => d.dName)
                .ToList();

            StringBuilder sb = new StringBuilder();



            foreach (var department in departmentsList)
            {
                sb.AppendLine($"{department.dName} - {department.mng.FirstName} {department.mng.LastName}");

                foreach (var employee in department.employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();



        }

        public static string IncreaseSalaries(SoftUniContext context)
        {

            var employees = context
                .Employees
                .Where(P => P.Department.Name == "Engineering"
                            || P.Department.Name == "Tool Design"
                            || P.Department.Name == "Information Services"
                            || P.Department.Name == "Marketing")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();


            foreach (var emp in employees)
            {
                emp.Salary *= 1.12m;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.FirstName} {empl.LastName} (${empl.Salary:f2})");
            }


            return sb.ToString().TrimEnd();




        }

        public static string GetLatestProjects(SoftUniContext context)
        {

            var top10 = context.Projects.Select(p => new
            {
                ProjectName = p.Name,
                ProjectDescription = p.Description,
                ProjectStartDate = p.StartDate
            })
                .OrderByDescending(p => p.ProjectStartDate)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var proj in top10.OrderBy(p => p.ProjectName).ThenBy(p => p.ProjectStartDate))
            {
                sb.AppendLine(proj.ProjectName);
                sb.AppendLine(proj.ProjectDescription);
                sb.AppendLine(proj.ProjectStartDate.ToString());
            }

            return sb.ToString().TrimEnd();
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
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects.Select
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

                foreach (var project in employee.Projects.OrderBy(p => p.ProjectName))
                {
                    sb.AppendLine(project.ProjectName);
                }
            }

            return sb.ToString().TrimEnd();

        }



        public static string GetAddressesByTown(SoftUniContext context)
        {
            var res = context.Addresses
                .Select(a => new { a.AddressText, a.Town.Name, a.Employees.Count })
                .Take(10)
                .OrderByDescending(c => c.Count)
                .ThenBy(t => t.Name)
                .ThenBy(t => t.AddressText)
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
