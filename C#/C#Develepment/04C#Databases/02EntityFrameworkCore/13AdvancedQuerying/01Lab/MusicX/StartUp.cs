using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MusicX
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new MusicXContext();


            //string query = $"UPDATE Songs SET ModifiedOn = GETDATE()";

            //db.Database.ExecuteSqlRaw(query);

            //string query = $"Select * from Songs where Id<=10";

            //db.Songs.FromSqlRaw(query);

            // to avoid SQLIjection

            //1

            //string max = Console.ReadLine();

            //string query = "Select * from Songs where Id<={0}";

            //db.Songs.FromSqlRaw(query, max);

            //2

            //string max = Console.ReadLine(); 

            //db.Songs.FromSqlInterpolated($"Select * from Songs where Id<={max}");


            //OBJECT TRACKING


            //  var songs = db.Songs.Where(s => s.Name.Contains("viv")).ToList();

            //detach - use when you don't change  or don't want to make changes in DB.
            //Also when using anonymous obj it  detached dbObj from tracking

            //var songs = db.Songs.AsNoTracking().Where(s => s.Id < 10).ToList();

            //foreach (var song in songs)
            //{

            //    //this is how you change the state of cur obj

            //    db.Entry(song).State = EntityState.Detached;
            //}


            //BULK


            //loadings

            //explicit

            //var songs = db.Songs.Where(s => s.Id < 10).ToList();

            //foreach (var song in songs)
            //{

            //    db.Entry(song).Reference(x=>x.Source).Load(); 
            //    db.Entry(song).Collection(x=>x.SongArtists).Load();
            //}

            //eager


            //var songs = db
            //    .Songs
            //    .Include(s=>s.Source)
            //    .Include(s=>s.SongArtists)
            //    .ThenInclude(s=>s.Artist)
            //    .Where(s => s.Id < 10)
            //    .ToList();

            //foreach (var song in songs)
            //{


            //}

            //lazy

            //1. Nav props should be virtual
            //2.Install - nuGetPack microsoft.entityframeworkcore.proxies
            //3.Go DbContex -> optionBuilder .UseLazyLoadingProxies().UseSqlServer()

            //var songs = db
            //    .Songs
            //    .Include(s => s.Source)
            //    .Include(s => s.SongArtists)
            //    .ThenInclude(s => s.Artist)
            //    .Where(s => s.Id < 10)
            //    .ToList();

         


        }
    }
}
