using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Mapper01
{
    class SongInfoDto
    {
        public string Name { get; set; }
        public string SourceName { get; set; }

    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new MusicXContext();

            //    var song = db.Songs.Where(s => s.Id == 3).FirstOrDefault();

            //    //var config = new MapperConfiguration(config =>
            //    //{
            //    //    config.CreateMap<Song, SongInfoDto>()
            //    //        .ForMember(x=>x.);
            //    //});

            //    var mapper = config.CreateMapper();

            //    var songDto = mapper.Map<SongInfoDto>(song);

            //    var songs = db
            //        .Songs
            //        .Where(s => s.Name.StartsWith("Da"))
            //        .ProjectTo<SongInfoDto>(config)
            //        .ToList();
        }



    }





}
