using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Theatre.Data;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto.JsonModels;
using Theatre.DataProcessor.ImportDto.XmlModels;
using Theatre = Theatre.Data.Models.Theatre;

namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer =
                new XmlSerializer(typeof(PlayImportModel[]),
                    new XmlRootAttribute("Plays"));

            StringReader reader = new StringReader(xmlString);

            PlayImportModel[] playsDto = (PlayImportModel[])serializer.Deserialize(reader);

            foreach (var playDto in playsDto)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                bool tryParseEnum = Enum.TryParse<Genre>(playDto.Genre, out var parsedEnum);

                if (!tryParseEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                bool tryParsedTimeSpam = TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture,
                    TimeSpanStyles.None, out var parsedTimeSpam);

                if (!tryParsedTimeSpam)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (parsedTimeSpam.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play()
                {
                    Title = playDto.Title,
                    Duration = parsedTimeSpam,
                    Rating = playDto.Rating,
                    Genre = parsedEnum,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                context.Plays.Add(play);

                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfulImportPlay, playDto.Title, playDto.Genre,
                    playDto.Rating));

            }

            return sb.ToString().TrimEnd();

        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();


            XmlSerializer serializer =
                new XmlSerializer(typeof(CastInputModel[]),
                    new XmlRootAttribute("Casts"));

            StringReader reader = new StringReader(xmlString);

            CastInputModel[] castsDto = (CastInputModel[])serializer.Deserialize(reader);

            List<Cast> castToImport = new List<Cast>();

            foreach (var castDto in castsDto)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast toImport = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                sb.AppendLine(string.Format(SuccessfulImportActor, castDto.FullName,
                    castDto.IsMainCharacter == true ? "main" : "lesser"));

                castToImport.Add(toImport);

            }


            context.Casts.AddRange(castToImport);

            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();


            TeatherInputModel[] theatherDtos = JsonConvert.DeserializeObject<TeatherInputModel[]>(jsonString);

            List<Data.Models.Theatre> theaters = new List<Data.Models.Theatre>();

            foreach (var theatherDto in theatherDtos)
            {

                if (!IsValid(theatherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool invalidPlay = false;

                Data.Models.Theatre theatreToAdd = new Data.Models.Theatre()
                {
                    Name = theatherDto.Name,
                    Director = theatherDto.Director,
                    NumberOfHalls=theatherDto.NumberOfHalls
                    

                };
                foreach (var ticketDto in theatherDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    theatreToAdd.Tickets.Add(ticket);

                }

                if (invalidPlay)
                {
                    continue;
                }

                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatreToAdd.Name, theatreToAdd.Tickets.Count));

                theaters.Add(theatreToAdd);

            }

            context.AddRange(theaters);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
