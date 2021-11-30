using System;
using System.Collections.Generic;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Export.JsonModels
{

    public class GenreJsonExportModel
    {
        public GenreJsonExportModel()
        {
            this.Games = new List<GameJsonExportModel>();
        }

        public int Id { get; set; }

        public string Genre { get; set; }

        public ICollection<GameJsonExportModel> Games { get; set; }
    }
}
