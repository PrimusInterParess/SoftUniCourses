using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.DataProcessor.ImportDto.JsonModels;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var inputJson =
                @"[{'Name':'','Cells':[]},{'Name':'Invaliiiiiiiiiiiiiiiiiiiiiiiiiiiiidddddd','Cells':[]},{'Name':'Test','Cells':[{'CellNumber':0,'HasWindow':true}]},{'Name':'Test','Cells':[{'CellNumber':1001,'HasWindow':true}]}]";

            DepartmentInputJsonModel[] departmentsImportModels =
                JsonConvert.DeserializeObject<DepartmentInputJsonModel[]>(jsonString);

            List<Department> departmets = new List<Department>();

            foreach (var departmentInputModel in departmentsImportModels)
            {
                bool notInvalidCell = true;

                if (!IsValid(departmentInputModel))
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                if (departmentInputModel.Cells.Count == 0)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                var departmentToImport = new Department()
                {
                    Name = departmentInputModel.Name
                };

                foreach (var cellInputModel in departmentInputModel.Cells)
                {
                    if (!IsValid(cellInputModel))
                    {
                        sb.AppendLine(GlobalConstants.ErrorMessage);
                        notInvalidCell = false;
                        break;
                    }


                    departmentToImport.Cells.Add(new Cell()
                    {
                        CellNumber = cellInputModel.CellNumber,
                        HasWindow = cellInputModel.HasWindow
                    });
                }

              


                if (notInvalidCell)
                {
                    sb.AppendLine(string.Format(GlobalConstants.SuccsessfulImportMessageDepartmentCell,
                        departmentToImport.Name, departmentToImport.Cells.Count));


                    departmets.Add(departmentToImport);
                }
               
               
            }


            context.Departments.AddRange(departmets);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();


            PrisonerInputJsonModel[] departmentsImportModels =
                JsonConvert.DeserializeObject<PrisonerInputJsonModel[]>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();


            foreach (var prisonerInputModel in departmentsImportModels)
            {

                if (!IsValid(prisonerInputModel))
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;

                bool isValidincarcerationDate = DateTime.TryParseExact(prisonerInputModel.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                if (!isValidincarcerationDate)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                DateTime? releaseDate = null;


                if (!string.IsNullOrWhiteSpace(prisonerInputModel.ReleaseDate))
                {
                    DateTime releaseDateDto;

                    bool isValidReleaseDate = DateTime.TryParseExact(prisonerInputModel.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateDto);

                    if (!isValidReleaseDate)
                    {
                        sb.AppendLine(GlobalConstants.ErrorMessage);
                        continue;
                    }

                    releaseDate = releaseDateDto;
                }

                var prisoner = new Prisoner()
                {
                    FullName = prisonerInputModel.FullName,
                    Nickname = prisonerInputModel.Nickname,
                    Age = prisonerInputModel.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate
                };

                bool invalidEmail = false;

                foreach (var mailInputModel in prisonerInputModel.Mails)
                {
                    if (!IsValid(mailInputModel))
                    {
                        sb.AppendLine(GlobalConstants.ErrorMessage);
                        invalidEmail = true;
                        break;

                    }

                    var email = new Mail()
                    {
                        Description = mailInputModel.Description,
                        Sender = mailInputModel.Sender,
                        Address = mailInputModel.Address
                    };

                    prisoner.Mails.Add(email);
                }

                if (invalidEmail)
                {
                    
                    break;
                }

                context.Prisoners.Add(prisoner);

                context.SaveChanges();

                sb.AppendLine(string.Format(GlobalConstants.SuccsessfulImportMessagePrisoner, prisoner.FullName,
                    prisoner.Age));


            }

            

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}