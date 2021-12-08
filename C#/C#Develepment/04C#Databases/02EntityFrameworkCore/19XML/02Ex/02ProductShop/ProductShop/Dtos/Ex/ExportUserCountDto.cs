using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Ex
{
    public class ExportUserCountDto
    {

        public ExportUserCountDto()
        {
            this.Users = new List<ExportUserDto>();
        }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ICollection<ExportUserDto> Users { get; set; }
    }
}
