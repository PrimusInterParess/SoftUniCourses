
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;


    [TestFixture]
    public class StageTests
    {

        private const int ZERO = 0;

        private Song validSong = new Song("everlasting", new TimeSpan(0, 0, 4, 12));
        private Song validSong2 = new Song("everLoving", new TimeSpan(0, 0, 4, 12));
        private Song invalidSongDuration = new Song("everlasting", new TimeSpan(0, 0, 0, 12));
        private Song invalidSong = null;

        private Performer validPerformer = new Performer("Gary", "Foster", 43);
        private Performer validPerformer2 = new Performer("Stan", "SouthPark", 19);
        private Performer underAgePerformer = new Performer("Gary", "Foster", 13);
        private Performer invalidPerformer = null;
        private Stage stage;



        [SetUp]
        public void SetUp()
        {

            this.stage = new Stage();
        }


        [Test]
        public void When_InitializingStageItsPerformarsCollections_ShouldBeZero()
        {
            Assert.AreEqual(ZERO, this.stage.Performers.Count);
        }

        [Test]
        public void AddPerformer_ShouldThrowEx()
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(invalidPerformer));
        }

        [Test]
        public void AddPerformer_ShouldThrowExWithMessege()
        {
            Exception result = Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(invalidPerformer));

            string expected = $"Can not be null! (Parameter 'performer')";

            Assert.AreEqual(expected, result.Message);

        }

        [Test]
        public void AddPerformer_ShouldThrowExWithInvalidPerformer()
        {
            Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(underAgePerformer));
        }

        [Test]
        public void AddPerformer_ShouldThrowEx_WithInvalidPerformer_Messege()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(underAgePerformer));

            string expected = "You can only add performers that are at least 18.";

            Assert.AreEqual(expected, ex.Message);
        }


        [Test]
        public void WhenAdd_Successfully_PerformersCountShoudIncrease()
        {
            int expectedCount = 1;

            this.stage.AddPerformer(validPerformer);

            Assert.AreEqual(expectedCount, this.stage.Performers.Count);
        }

        [Test]
        public void WhenAdd_Song_ShouldThrowExWithNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(invalidSong));
        }

        [Test]
        public void WhenAdd_Song_ShouldThrowExWithNullValue_Messege()
        {
            Exception ex = Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(invalidSong));

            string expected = $"Can not be null!(Parameter 'song')";
        }

        [Test]
        public void WhenAdd_SongWithShortDuration_ShouldThrowEx()
        {
            Assert.Throws<ArgumentException>(() => this.stage.AddSong(invalidSongDuration));
        }

        [Test]
        public void WhenAdd_SongWithShortDuration_ShouldThrowEx_Messege()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => this.stage.AddSong(invalidSongDuration));

            string expected = "You can only add songs that are longer than 1 minute.";

            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void WhenAddSongToPerformer_ShouldThrowExWithNullValue_Song()
        {
            string empty = null;

            Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(empty, "ToshoTupalkata"));
        }

        [Test]
        public void WhenAddSongToPerformer_ShouldThrowExWithNullValue_Song_Messege()
        {
            string empty = null;

            Exception ex = Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(empty, "ToshoTupalkata"));

            string expected = "Can not be null! (Parameter 'songName')";

            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void WhenAddSongToPerformer_ShouldThrowExWithNullValue_Performer()
        {
            string songName = "notNull";
            string performerName = null;

            Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(songName, performerName));
        }

        [Test]
        public void WhenAddSongToPerformer_ShouldThrowExWithNullValue_Performer_Messege()
        {
            string songName = "notNull";
            string performerName = null;

            Exception ex = Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(songName, performerName));


            string expected = "Can not be null! (Parameter 'performerName')";

            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void GetPerformer_ShouldThrowEx_WhenNotExistingPerformer()
        {
            string performerName = "Stan";

            string songName = "everlasting";
            this.stage.AddSong(validSong);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(songName, performerName));


        }

        [Test]
        public void GetPerformer_ShouldThrowEx_WhenNotExistingPerformer_Messege()
        {
            string performerName = "Stan";

            string songName = "everlasting";
            this.stage.AddSong(validSong);

            Exception ex = Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(songName, performerName));

            string expected = "There is no performer with this name.";

            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void GetPerformer_ShouldThrowEx_WhenNotExistingSong()
        {

            string songName = "everlasting";
            this.stage.AddPerformer(validPerformer);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(songName, validPerformer.FullName));


        }

        [Test]
        public void GetPerformer_ShouldThrowEx_WhenNotExistingSong_Messege()
        {

            string songName = "everlasting";
            this.stage.AddPerformer(validPerformer);

            Exception ex = Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(songName, validPerformer.FullName));

            string expected = "There is no song with this name.";

            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void PerformerSongListCountShouldIncrease_WhenAddingSucssessfuly()
        {
            int expectedSongCount = 1;

            this.stage.AddPerformer(validPerformer);
            this.stage.AddSong(validSong);

            this.stage.AddSongToPerformer(validSong.Name, validPerformer.FullName);

            Assert.AreEqual(expectedSongCount, this.validPerformer.SongList.Count);
        }

        [Test]
        public void AddSong_ShouldReturnCorrectMessege()
        {
            this.stage.AddPerformer(validPerformer);
            this.stage.AddSong(validSong);

            string result = this.stage.AddSongToPerformer(validSong.Name, validPerformer.FullName);

            string expected = $"{validSong.ToString()} will be performed by {validPerformer.FullName}";

            Assert.AreEqual(expected, result);

        }

        [Test]
        public void Play_ShouldReturnCorrectData()
        {
            int expectedSongsCount = 3;
            int expectedPerformersCount = 2;

            this.stage.AddPerformer(validPerformer);
            this.stage.AddPerformer(validPerformer2);
            this.stage.AddSong(validSong);
            this.stage.AddSong(validSong2);

            this.stage.AddSongToPerformer(validSong.Name, validPerformer.FullName);
            this.stage.AddSongToPerformer(validSong2.Name, validPerformer.FullName);
            this.stage.AddSongToPerformer(validSong.Name, validPerformer2.FullName);

            string expected = $"{expectedPerformersCount} performers played {expectedSongsCount} songs";

            Assert.AreEqual(expected,this.stage.Play());

        }





    }
}