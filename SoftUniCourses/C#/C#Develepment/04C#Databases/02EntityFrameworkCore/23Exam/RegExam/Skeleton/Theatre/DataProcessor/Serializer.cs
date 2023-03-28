using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Theatre.DataProcessor.ExportDto.XmlModels;

namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            StringBuilder sb = new StringBuilder();

            var theathers = context.Theatres.Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count>=20)
                .OrderByDescending(t=>t.NumberOfHalls)
                .ThenBy(t=>t.Name)
                .ToArray()
                .Select(t=>new 
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(t=>t.RowNumber>=1 && t.RowNumber<=5).Sum(t=>t.Price),
                    Tickets = t.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Select(ticket=>new 
                    { 
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber
                    }).OrderByDescending(ticket=>ticket.Price)
                    .ToArray()
                }).ToArray();



            string serialized = JsonConvert.SerializeObject(theathers, Formatting.Indented);

            return serialized;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {

            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer =
                new XmlSerializer(typeof(PlayExportModel[]), new XmlRootAttribute("Plays"));

            XmlSerializerNamespaces nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add(String.Empty, String.Empty);

            using StringWriter strWriter = new StringWriter(sb);

            var plays = context
                .Plays
                .Where(p => p.Rating <= rating)
                .ToArray()
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .Select(p => new PlayExportModel()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating==0? "Premier":p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.Where(a=>a.IsMainCharacter).Select(a=>new ActorXmlModel()
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'.".ToString()
                    })
                        .OrderByDescending(a=>a.FullName)
                        .ToList()
                }).ToArray();

            serializer.Serialize(strWriter, plays, nameSpaces);


            return sb.ToString().TrimEnd();


        }
    }
}
