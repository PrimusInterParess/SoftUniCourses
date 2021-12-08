using System.Linq;
using TeisterMask.Data.Models;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask
{
    using AutoMapper;

    public class TeisterMaskProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TeisterMaskProfile()
        {
            this.CreateMap<Task, TaskXMLExportModel>()
                .ForMember(exportModel => exportModel.Name, m => m.MapFrom(t => t.Name))
                .ForMember(exportModel => exportModel.Label, m => m.MapFrom(t => t.LabelType.ToString()));

            this.CreateMap<Project, ProjectXMLExportModel>()
                .ForMember(exportModel => exportModel.TasksCount, m
                    => m.MapFrom(p => p.Tasks.Count))
                .ForMember(exportModel => exportModel.Name,
                    m => m.MapFrom(p => p.Name))
                .ForMember(exportModel => exportModel.HasEndDate,
                    m => m.MapFrom(p => p.DueDate.HasValue ? "Yes" : "No"))
                .ForMember(exportModel => exportModel.TaskXmlExportModel,
                    m => m.MapFrom(p => p.Tasks.ToArray().OrderBy(t => t.Name)));
        }
    }
}
