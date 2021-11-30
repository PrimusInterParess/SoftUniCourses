using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using System;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer =
                new XmlSerializer(typeof(ProjectXMLExportModel[]), new XmlRootAttribute("Projects"));

            XmlSerializerNamespaces nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add(String.Empty, String.Empty);

            using StringWriter strWriter = new StringWriter(sb);

            Project[] projects = context.Projects.Where(p => p.Tasks.Count > 0).ToArray();

            ProjectXMLExportModel[] projectXmlExportModels = Mapper.Map<ProjectXMLExportModel[]>(projects)
                .OrderByDescending(p=>p.TasksCount)
                .ThenBy(p=>p.Name)
                .ToArray();

            serializer.Serialize(strWriter,projectXmlExportModels,nameSpaces);

            return sb.ToString().TrimEnd();


        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var emplpyeesWithOpenTasks = context
                .Employees
                .Where(e =>
                    e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .ToArray()
                .Select(e => new
                {
                    e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(t => t.Task.OpenDate >= date)
                        .ToArray()
                        .OrderByDescending(t => t.Task.DueDate)
                        .ThenBy(t => t.Task.Name)
                        .Select(t => new
                        {
                            TaskName = t.Task.Name,
                            OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = t.Task.LabelType.ToString(),
                            ExecutionType = t.Task.ExecutionType.ToString()
                        })

                        .ToArray()
                }).OrderByDescending(em => em.Tasks.Length)
                .ThenBy(em => em.Username)
                .Take(10)
                .ToArray();


            string serialized = JsonConvert.SerializeObject(emplpyeesWithOpenTasks, Formatting.Indented);

            return serialized;
        }
    }
}