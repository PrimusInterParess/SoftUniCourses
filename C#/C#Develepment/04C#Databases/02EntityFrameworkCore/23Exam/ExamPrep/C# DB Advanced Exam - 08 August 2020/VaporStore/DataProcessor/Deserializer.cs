using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import.JsonModels;
using VaporStore.DataProcessor.Dto.Import.XmlModels;

namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;



    public static class Deserializer
    {


        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {

            GameJsonInputModel[] gamesDto = JsonConvert.DeserializeObject<GameJsonInputModel[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Game> gamesToImport = new List<Game>();

            List<Genre> genresToCount = new List<Genre>();

            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto) || gameDto.Tags.Count == 0)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                DateTime releaseDateDto;

                bool isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateDto);

                if (!isReleaseDateValid)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                var developer = context.Developers.FirstOrDefault(d => d.Name == gameDto.Developer) ?? new Developer()
                {
                    Name = gameDto.Developer
                };

                var genre = context.Genres.FirstOrDefault(g => g.Name == gameDto.Genre) ?? new Genre()
                {
                    Name = gameDto.Genre
                };

                genresToCount.Add(genre);

                List<Tag> tags = new List<Tag>();

                foreach (var tagDto in gameDto.Tags)
                {
                    if (!string.IsNullOrWhiteSpace(tagDto))
                    {
                        var tag = context.Tags.FirstOrDefault(t => t.Name == tagDto) ?? new Tag()
                        {
                            Name = tagDto
                        };

                        tags.Add(tag);
                    }

                }

                if (tags.Count == 0)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDateDto,
                    Developer = developer,
                    Genre = genre
                };

                foreach (var tag in tags)
                {
                    game.GameTags.Add(new GameTag()
                    {
                        Tag = tag,
                        Game = game

                    });
                }

                sb.AppendLine(string.Format(GlobalConstants.SuccsessfulMessageGameImport, game.Name, game.Genre.Name,
                    game.GameTags.Count));

                context.Games.Add(game);
                context.SaveChanges();

            }


            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            UserJsonInputModel[] usersDto = JsonConvert.DeserializeObject<UserJsonInputModel[]>(jsonString);

            List<User> usersToImportToDb = new List<User>();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }


                var userToAdd = new User()
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        sb.AppendLine(GlobalConstants.ErrorMessage);
                        break;
                    }

                    if (cardDto.Type != CardType.Credit.ToString() &&
                        cardDto.Type != CardType.Debit.ToString())
                    {
                        sb.AppendLine(GlobalConstants.ErrorMessage);
                        break;
                    }

                    userToAdd.Cards.Add(new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    });


                }

                usersToImportToDb.Add(userToAdd);

                sb.AppendLine(string.Format(GlobalConstants.SuccsessfulMessageUserImport, userToAdd.Username,
                    userToAdd.Cards.Count));
            }


            context.Users.AddRange(usersToImportToDb);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer =
                new XmlSerializer(typeof(PurchaseXMLInputModel[]),
                    new XmlRootAttribute("Purchases"));

            StringReader reader = new StringReader(xmlString);

            PurchaseXMLInputModel[] purchasesDto = (PurchaseXMLInputModel[])serializer.Deserialize(reader);

            List<Purchase> purchasesToAdd = new List<Purchase>();

            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                DateTime date;

                bool isValidDate = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isValidDate)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.CardNumber);

                var user = context.Users.FirstOrDefault(u => u.Id == card.UserId);

                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.GameTitle);

                if (card == null || game == null || user == null)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                var purchaseType = Enum.Parse<PurchaseType>(purchaseDto.Type);


                if (purchaseType != PurchaseType.Digital && purchaseType != PurchaseType.Retail)
                {
                    sb.AppendLine(GlobalConstants.ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase()
                {
                    Type = purchaseType,
                    ProductKey = purchaseDto.ProductKey,
                    Date = date,
                    Card = card,
                    Game = game
                };

                purchasesToAdd.Add(purchase);

                sb.AppendLine(string.Format(GlobalConstants.SuccsessfulMessagePurchaseImport, purchase.Game.Name,
                    user.Username));
            }


            context.Purchases.AddRange(purchasesToAdd);

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