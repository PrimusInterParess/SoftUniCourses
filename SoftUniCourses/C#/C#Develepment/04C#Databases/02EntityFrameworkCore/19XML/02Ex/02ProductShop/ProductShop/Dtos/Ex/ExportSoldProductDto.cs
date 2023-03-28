using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Ex
{
  public  class ExportSoldProductDto
    {
        public ExportSoldProductDto()
        {
            this.Products = new List<ExportProductDto>();
        }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ICollection<ExportProductDto> Products { get; set; }
    }
}
