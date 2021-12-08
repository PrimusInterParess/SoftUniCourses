using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var alubms = context
                 .Albums
                 .ToArray()
                 .Where(a => a.ProducerId == producerId)
                 .OrderByDescending(a => a.Price)
                 .Select(a => new
                 {
                     Name = a.Name,
                     ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                     ProducerName = a.Producer.Name,
                     Price = a.Price.ToString("f2"),
                     Songs = a.Songs.Select(s => new
                     {
                         SongName = s.Name,
                         Prise = s.Price.ToString("f2"),
                         SongWriterName = s.Writer.Name
                     }).OrderByDescending(s => s.SongName)
                         .ThenBy(s => s.SongWriterName)
                 }).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var albm in alubms)
            {
                sb
                    .AppendLine($"-AlbumName: {albm.Name}")
                    .AppendLine($"-ReleaseDate: {albm.ReleaseDate}")
                    .AppendLine($"-ProducerName: {albm.ProducerName}")
                    .AppendLine($"-Songs:");

                int i = 1;

                foreach (var song in albm.Songs)
                {
                    sb
                        .AppendLine($"---#{i++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Prise}")
                        .AppendLine($"---Writer: {song.SongWriterName}");
                }

                sb
                    .AppendLine($"-AlbumPrice: {albm.Price}");
            }


            return sb
                .ToString()
                .TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context
                .Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    Name = s.Name,
                    PerformerName = s.SongPerformers.ToArray().Select(sp =>

                        $"{sp.Performer.FirstName} {sp.Performer.LastName}"

                    ).FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    Producer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerName)
                .ToList();


            StringBuilder sb = new StringBuilder();

            int i = 1;
            foreach (var song in songs)
            {
                sb
                    .AppendLine($"-Song #{i++}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.WriterName}")
                    .AppendLine($"---Performer: {song.PerformerName}")
                    .AppendLine($"---AlbumProducer: {song.Producer}")
                    .AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();


        }
    }
}
