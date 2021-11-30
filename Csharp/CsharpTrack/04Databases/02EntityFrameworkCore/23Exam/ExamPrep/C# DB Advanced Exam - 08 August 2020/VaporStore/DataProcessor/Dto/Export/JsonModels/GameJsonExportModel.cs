using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Export.JsonModels
{
    public class GameJsonExportModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Developer { get; set; }

        public string Tags { get; set; }

        public int Players { get; set; }
    }
}
