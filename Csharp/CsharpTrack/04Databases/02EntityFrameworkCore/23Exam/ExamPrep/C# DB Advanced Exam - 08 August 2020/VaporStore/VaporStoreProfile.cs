using System.Linq;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Export.JsonModels;

namespace VaporStore
{
    using AutoMapper;

    public class VaporStoreProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it.
        // If not, DO NOT DELETE THIS CLASS

        public VaporStoreProfile()
        {
            this.CreateMap<Game, GameJsonExportModel>()
                .ForMember(exportModel => exportModel.Id, m => m.MapFrom(g => g.Id))
                .ForMember(exportModel => exportModel.Title, m => m.MapFrom(g => g.Name))
                .ForMember(exportModel => exportModel.Developer, m => m.MapFrom(g => g.Developer.Name))
                .ForMember(exportModel => exportModel.Tags, m => m.MapFrom(g => string.Join(", ", g.GameTags.Select(t => t.Tag.Name))))
                .ForMember(exportModel => exportModel.Players, m => m.MapFrom(g => g.Purchases.Count));

            this.CreateMap<Genre, GenreJsonExportModel>()
                .ForMember(exportModel => exportModel.Id, m => m.MapFrom(g => g.Id))
                .ForMember(exportModel => exportModel.Genre, m => m.MapFrom(g => g.Name))
                .ForMember(exportModel => exportModel.Games, m => m.MapFrom(g => g.Games.Where(g => g.Purchases.Any())));
        }
    }
}