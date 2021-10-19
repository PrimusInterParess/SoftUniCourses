using System;
using System.Collections.Generic;

namespace Exam.RePlay
{
    class Program
    {
        static void Main(string[] args)
        {
            RePlayer player = new RePlayer();

            Track track321412 = new Track("nekvoRapche", "WAP", "Megan Thee Stallion", 3,187);
            Track track21312 = new Track("booo", "Gosips", "Megan Thee Stallion", 7,147);
            Track track123 = new Track("ho-trop", "Artelian", "Megan Thee Stallion", 3,187);

            Track track2 = new Track("drugo", "	People", "I've been sadChristine and the Queens", 1,207);
            Track track3 = new Track("madagazs", "Black Window", "I've been sadChristine and the Queens", 3,187);
            Track track4 = new Track("asle", "sleepy house", "I've been sadChristine and the Queens", 7,197);
            Track track5 = new Track("nbrfh", "n-k", "I've been sadChristine and the Queens", 3,187);

            Track track56 = new Track("krash", "World end", "Art of Machines", 2, 200);
            Track track57 = new Track("crash", "end of World", "Art of Machines", 0, 200);


            string albumName1 = "Megan";
            string albumName2 = "sadChristine";
            string albumName3 = "Art of Machines";


            List<Track> Megan = new List<Track> {track321412, track21312, track123};
            List<Track> sadChristine = new List<Track> { track2, track3, track4 , track5 };
            List<Track> ArtofMachines = new List<Track> { track56, track57};



            foreach (var track in Megan)
            {
                track.AlbumName = albumName1;
                player.AddTrack(track,albumName1);

            }


            foreach (var track in sadChristine)
            {
                track.AlbumName = albumName2;

                player.AddTrack(track, albumName2);

            }


            foreach (var track in ArtofMachines)
            {

                track.AlbumName = albumName3;
                player.AddTrack(track, albumName3);

            }

            IEnumerable<Track> tracks= player.GetAlbum(albumName1);

            IEnumerable<Track> tracks2 = player.GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(20, 201);

            foreach (var track in player)
            {
                Console.WriteLine(track);
            }

        }
    }
}
