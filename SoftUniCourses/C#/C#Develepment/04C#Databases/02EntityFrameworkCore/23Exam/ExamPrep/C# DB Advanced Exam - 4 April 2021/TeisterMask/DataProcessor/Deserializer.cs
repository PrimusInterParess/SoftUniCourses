using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Data;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProjectXMLInputModel[]),
                new XmlRootAttribute("Projects"));

            StringReader reader = new StringReader(xmlString);

            ProjectXMLInputModel[] projectXmlInputModels = (ProjectXMLInputModel[])serializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();

            List<Project> projectsToImport = new List<Project>();

            foreach (var projectXMlModel in projectXmlInputModels)
            {
                if (!IsValid(projectXMlModel))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectOpenDate;

                bool isProjectOpenDateValid = DateTime.TryParseExact(projectXMlModel.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                if (!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDueDate = null;

                if (!string.IsNullOrWhiteSpace(projectXMlModel.DueDate))
                {
                    DateTime currDueDate;

                    bool isProjectDueDateValid = DateTime.TryParseExact(projectXMlModel.DueDate, "dd/MM/yyyy"
                        , CultureInfo.InvariantCulture, DateTimeStyles.None, out currDueDate);

                    if (!isProjectDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    projectDueDate = currDueDate;
                }

                var projectToAdd = new Project()
                {
                    Name = projectXMlModel.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };



                foreach (var taskXmlModel in projectXMlModel.Tasks)
                {
                    if (!IsValid(taskXmlModel))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate = DateTime.MinValue;

                    bool isValidTaskOpenDate = DateTime.TryParseExact(taskXmlModel.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    if (!isValidTaskOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;

                    bool isValidTaskDueDate = DateTime.TryParseExact(taskXmlModel.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isValidTaskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;

                    }

                    if (projectDueDate.HasValue && taskDueDate > projectDueDate.Value)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var taskToAdd = new Task()
                    {
                        Name = taskXmlModel.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskXmlModel.ExecutionType,
                        LabelType = (LabelType)taskXmlModel.LabelType
                    };



                    projectToAdd.Tasks.Add(taskToAdd);

                }

                projectsToImport.Add(projectToAdd);

                sb.AppendLine(string.Format(SuccessfullyImportedProject, projectToAdd.Name, projectToAdd.Tasks.Count));
            }


            context.Projects.AddRange(projectsToImport);

            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            EmployeeJSONInputModel[] employeesJsonInputModels =
                JsonConvert.DeserializeObject<EmployeeJSONInputModel[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Employee> employeesToAdd = new List<Employee>();


            foreach (var employeeJsonModel in employeesJsonInputModels)
            {
                if (!IsValid(employeeJsonModel))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currEmployee = new Employee()
                {
                    Username = employeeJsonModel.Username,
                    Email = employeeJsonModel.Email,
                    Phone = employeeJsonModel.Phone
                };

                foreach (var taskId in employeeJsonModel.Tasks)
                {
                    Task taskToAdd = context.Tasks.FirstOrDefault(t => t.Id == taskId);

                    if (taskToAdd == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    currEmployee.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Task = taskToAdd
                    });
                }

                employeesToAdd.Add(currEmployee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, currEmployee.Username,
                    currEmployee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employeesToAdd);

            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}