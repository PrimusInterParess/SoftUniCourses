using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBFirstApproach.Models;
using Newtonsoft.Json;

namespace DBFirstApproach
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding =Encoding.Unicode;
            var db = new MusicXContext();

            // var songs = db.Songs.ToList(); //this way you gets the primitive properties;

            // var songs = db.Songs.Where(s=>s.Name.StartsWith("Н")).ToList();

            // var song = db.Songs.Where(s => s.Source.Name == "User").ToList();

            //var song = db.Songs
            //    .Where(s => s.Source.Name == "User")
            //    .Select(a=>new {a.Name,Source = a.Source.Name})
            //    .ToList();

            //var song = db.Songs
            //    .Where(s => s.Source.Name == "User")
            //    .Select(a => new
            //    {
            //        a.Name,  
            //        Source = a.Source.Name,
            //        Artists = string.Join(", ",a.SongArtists.Select(a=>a.Artist.Name))

            //    })
            //    .ToList();
             

            ////aggregateFunks

            //var dbe=db.Artists.Where(a=>a.Name.StartsWith("A")).Sum(i=>i.Id);

            //var artists = db
            //    .Artists
            //    .OrderByDescending(a => a.SongArtists.Count())
            //    .Where(a=>a.SongArtists.Count>50)
            //    .Select(a => new {Name = a.Name,Count = a.SongArtists.Count()})
            //    .Take(10)
            //    .ToList();


            //join
            //inner
            //var songs = db.Songs.Join(db.Sources, x => x.SourceId, x => x.Id,(x,s)=>new
            //{
            //    SongName=x.Name,
            //    SourceName=s.Name
            //}).ToList();

            ////or
            ////left
            //var songs2 = db.Songs.Select(x => new
            //{
            //    songname=x.Name,
            //    sourcename=x.Source.Name
            //});

            //grouping 

            //var songssga = db
            //    .Artists.AsEnumerable()
            //    .GroupBy(a => a.Name.Substring(0, 1))
            //    .Select(a => new 
            //    {
            //        firstLetter = a.Key,
            //        ArtiststCount =a.Select(a=>
            //        
            //            a.Name
            //      
            //        ).ToList()
            //    }).ToList();

              
            //var arttist = db.Artists.OrderByDescending(a => a.SongArtists.Count()).Select(a => new
            //{
            //    name = a.Name,
            //    songs = a.SongArtists.Select(s => s.Song.Name).ToList()
            //}).ToList();

            //foreach (var ssadsa in song)
            //{
            //    Console.WriteLine(ssadsa);
            //}

            //var artisst = db.Artists.SelectMany(a => a.SongArtists.Select(sa => sa.Song.Name)).ToList();


            var songs = db.Songs.Where(s => s.SongArtists.Count() == 1)
                .OrderBy(s=>s.Name)
                .Select(s => new
                {
                    nameofsong = s.Name,
                    artistName = s.SongArtists.FirstOrDefault().Artist.Name
                }).Skip(100).Take(10).ToList();

            Console.WriteLine();
        }  
    }
}
