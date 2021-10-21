using System;
using _02CRUD.Models;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicXContext db = new MusicXContext();

            Artist asrtist = new Artist();

            asrtist.Name = "Nakov";
            asrtist.CreatedOn = DateTime.UtcNow;

            db.Artists.Add(asrtist);
            db.SaveChanges();

        }
    }
}
