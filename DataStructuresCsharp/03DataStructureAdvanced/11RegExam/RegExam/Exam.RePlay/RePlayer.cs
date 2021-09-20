using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exam.RePlay
{
    public class RePlayer : IRePlayer, IEnumerable<Track>
    {

        private class AlbumNamePlaysDuration : IComparer<Track>
        {
            public int Compare(Track x, Track y)
            {
                int comp = x.AlbumName.CompareTo(y.AlbumName);

                if (comp == 0)
                {
                    comp = y.Plays.CompareTo(x.Plays);
                }

                if (comp == 0)
                {
                    comp = y.DurationInSeconds.CompareTo(x.DurationInSeconds);
                }

                if (comp == 0)
                {
                    comp = x.Id.CompareTo(y.Id);
                }

                return comp;
            }
        }
        private class AlbumTrackPlays : IComparer<Track>
        {
            public int Compare(Track x, Track y)
            {
                int comp = y.Plays.CompareTo(x.Plays);

                if (comp == 0)
                {
                    comp = x.Id.CompareTo(y.Id);
                }

                return comp;
            }
        }
        private class Duration : IComparer<Track>
        {
            public int Compare(Track x, Track y)
            {
                int comp = x.DurationInSeconds.CompareTo(y.DurationInSeconds);

                if (comp == 0)
                {
                    comp = y.Plays.CompareTo(x.Plays);
                }

                if (comp == 0)
                {
                    comp = x.Id.CompareTo(y.Id);
                }

                return comp;
            }
        }

        private Dictionary<string, SortedSet<Track>> albumTrackSortedByNPlaysDSC;
        private Dictionary<string, Dictionary<string, List<Track>>> artistAlbumTracks;
        private Dictionary<string, Dictionary<string, Track>> albumTitleTrack;

        private HashSet<string> albums;
        private HashSet<string> trackNames;

        private SortedSet<Track> tracksOrderedByAlbumNameORDAlbNamePlaysDCSDuratinDSC;
        private SortedSet<Track> tracksOrderByDurationPlaysDSCID;

        private List<Track> q;

        public RePlayer()
        {
            this.q = new List<Track>();
            this.artistAlbumTracks = new Dictionary<string, Dictionary<string, List<Track>>>();
            this.tracksOrderedByAlbumNameORDAlbNamePlaysDCSDuratinDSC = new SortedSet<Track>(new AlbumNamePlaysDuration());
            this.albumTitleTrack = new Dictionary<string, Dictionary<string, Track>>();
            this.albums = new HashSet<string>();
            this.trackNames = new HashSet<string>();
            this.albumTrackSortedByNPlaysDSC = new Dictionary<string, SortedSet<Track>>();
            this.tracksOrderByDurationPlaysDSCID = new SortedSet<Track>(new Duration());
        }

        public int Count => this.tracksOrderedByAlbumNameORDAlbNamePlaysDCSDuratinDSC.Count;

        public void AddToQueue(string trackName, string albumName)
        {
            if (!this.albums.Contains(albumName))
            {
                throw new ArgumentException();
            }

            if (!this.trackNames.Contains(trackName))
            {
                throw new ArgumentException();
            }

            Track toAdd = this.albumTitleTrack[albumName][trackName];

            this.q.Add(toAdd);
        }

        public void AddTrack(Track track, string album)
        {
            this.albums.Add(album);
            this.trackNames.Add(track.Title);
            track.AlbumName = album;

            if (!this.albumTitleTrack.ContainsKey(album))
            {
                this.albumTitleTrack[album] = new Dictionary<string, Track>();
                this.albumTrackSortedByNPlaysDSC[album] = new SortedSet<Track>(new AlbumTrackPlays());
            }

            if (!this.artistAlbumTracks.ContainsKey(track.Artist))
            {
                this.artistAlbumTracks[track.Artist] = new Dictionary<string, List<Track>>();
            }

            if (!this.artistAlbumTracks[track.Artist].ContainsKey(track.AlbumName))
            {
                this.artistAlbumTracks[track.Artist][track.AlbumName] = new List<Track>();
            }

            this.albumTrackSortedByNPlaysDSC[album].Add(track);
            this.artistAlbumTracks[track.Artist][track.AlbumName].Add(track);
            this.albumTitleTrack[album].Add(track.Title, track);
            this.tracksOrderedByAlbumNameORDAlbNamePlaysDCSDuratinDSC.Add(track);
            this.tracksOrderByDurationPlaysDSCID.Add(track);
        }

        public bool Contains(Track track)
        {
            return this.trackNames.Contains(track.Title);
        }

        public IEnumerable<Track> GetAlbum(string albumName)
        {
            if (!this.albums.Contains(albumName))
            {
                throw new ArgumentException();
            }

            return this.albumTrackSortedByNPlaysDSC[albumName];
        }

        public Dictionary<string, List<Track>> GetDiscography(string artistName)
        {
            if (!this.artistAlbumTracks.ContainsKey(artistName))
            {
                throw new ArgumentException();
            }

            return this.artistAlbumTracks[artistName];
        }

        public Track GetTrack(string title, string albumName)
        {
            if (!this.trackNames.Contains(title))
            {
                throw new ArgumentException();
            }

            if (!this.albums.Contains(albumName))
            {
                throw new ArgumentException();
            }

            return this.albumTitleTrack[albumName][title];
        }

        public IEnumerable<Track> GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(int lowerBound, int upperBound)
        {
            return this.tracksOrderByDurationPlaysDSCID.GetViewBetween(new Track("aa", "aa", "aa", 1, lowerBound),
                new Track("bb", "aa", "aa", 1, upperBound));
        }

        public IEnumerable<Track> GetTracksOrderedByAlbumNameThenByPlaysDescendingThenByDurationDescending()
        {
            return this.tracksOrderedByAlbumNameORDAlbNamePlaysDCSDuratinDSC;
        }

        public Track Play()
        {

            if (q.Count == 0)
            {
                throw new ArgumentException();
            }

            Track toReturn = q[0];
            toReturn.Plays++;
            q.RemoveAt(0);

            return toReturn;

        }

        public void RemoveTrack(string trackTitle, string albumName)
        {
            if (!this.albums.Contains(albumName))
            {
                throw new ArgumentException();
            }

            if (!this.trackNames.Contains(trackTitle))
            {
                throw new ArgumentException();
            }



            Track toRemove = this.albumTitleTrack[albumName][trackTitle];

            this.albums.Remove(albumName);
            this.trackNames.Remove(trackTitle);
            this.albumTitleTrack[albumName].Remove(trackTitle);
            this.artistAlbumTracks[toRemove.Artist][toRemove.AlbumName].Remove(toRemove);
            this.albumTrackSortedByNPlaysDSC[toRemove.AlbumName].Remove(toRemove);
            this.tracksOrderByDurationPlaysDSCID.Remove(toRemove);
            this.tracksOrderedByAlbumNameORDAlbNamePlaysDCSDuratinDSC.Remove(toRemove);
            this.q.Remove(toRemove);

        }

        public IEnumerator<Track> GetEnumerator()
        {
            foreach (var track in tracksOrderedByAlbumNameORDAlbNamePlaysDCSDuratinDSC)
            {
                yield return track;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
