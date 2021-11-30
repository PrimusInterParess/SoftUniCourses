using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VaporStore.DataProcessor.Dto.Export.JsonModels;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genresAlpha = context
                .Genres
                .ToArray()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                        .Where(g => g.Purchases.Count > 0)
                        .Select(game => new
                        {
                            Id = game.Id,
                            Title = game.Name,
                            Developer = game.Developer.Name,
                            Tags = string.Join(", ", game.GameTags.Select(gt => gt.Tag.Name).ToArray()),
                            Players = game.Purchases.Count
                        }).OrderByDescending(gs => gs.Players)
                        .ThenBy(gs => gs.Id)
                        .ToArray(),
                    TotalPlayers = g.Games.Select(g => g.Purchases.Count).ToArray().Sum()
                }).OrderByDescending(gm => gm.TotalPlayers)
                .ThenBy(gm => gm.Id)
                .ToArray();


            //var genresBetha = context
            //    .Genres
            //    .ToArray()
            //    .Where(g => genreNames.Contains(g.Name))
            //    .Select(g => new
            //    {
            //        Id = g.Id,
            //        Genre = g.Name,
            //        Games = g.Games
            //            .Where(ga => ga.Purchases.Any())
            //            .Select(ga => new
            //            {
            //                Id = ga.Id,
            //                Title = ga.Name,
            //                Developer = ga.Developer.Name,
            //                Tags = String.Join(", ", ga.GameTags
            //                    .Select(gt => gt.Tag.Name)
            //                    .ToArray()),
            //                Players = ga.Purchases.Count
            //            })
            //            .OrderByDescending(ga => ga.Players)
            //            .ThenBy(ga => ga.Id)
            //            .ToArray(),
            //        TotalPlayers = g.Games.Sum(ga => ga.Purchases.Count)
            //    })
            //    .OrderByDescending(g => g.TotalPlayers)
            //    .ThenBy(g => g.Id)
            //    .ToArray();


            string result = JsonConvert.SerializeObject(genresAlpha, Formatting.Indented);

            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {







            return "";

        }
    }
}