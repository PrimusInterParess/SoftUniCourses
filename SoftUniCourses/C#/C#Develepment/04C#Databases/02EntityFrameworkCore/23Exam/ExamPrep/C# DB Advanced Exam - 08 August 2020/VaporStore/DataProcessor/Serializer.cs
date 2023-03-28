using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Export.JsonModels;
using VaporStore.DataProcessor.Dto.Export.XMLModels;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Serializer
    {

        //For each game, export its id, name, developer, tags (separated by ", ") and total player count (purchase count)

        //Order the games by player count (descending), then by game id (ascending).

        // Order the genres by total player count(descending), then by genre id(ascending)

        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genresWithTheirGames = context.Genres.Where(g => genreNames.Contains(g.Name)).ToArray().Select(g => new
            {
                Id = g.Id,
                Genre = g.Name,
                Games = g.Games.Where(gm => gm.Purchases.Any()).Select(gm => new
                {
                    Id = gm.Id,
                    Title = gm.Name,
                    Developer = gm.Developer.Name,
                    Tags = string.Join(", ", gm.GameTags.Select(t => t.Tag.Name).ToArray()),
                    Players = gm.Purchases.Count
                })
                    .OrderByDescending(gm => gm.Players)
                    .ThenBy(gm => gm.Id)
                    .ToArray(),
                TotalPlayers = g.Games
                    .Select(g => g.Purchases.Count)
                    .Sum()
            }).OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            string serialized = JsonConvert.SerializeObject(genresWithTheirGames, Formatting.Indented);

            return serialized;

        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {

            var InputPurchaseType = Enum.Parse<PurchaseType>(storeType);


            var users = context.Users
                .Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type.Equals(InputPurchaseType))))
                .ToArray().Select(u => new UserExportXMLModel()
                {
                    Username = u.Username,
                    Purchases = context.Purchases.Where(p =>
                        p.Card.User.Username == u.Username && p.Type == InputPurchaseType)
                });





            return "";

        }
    }
}