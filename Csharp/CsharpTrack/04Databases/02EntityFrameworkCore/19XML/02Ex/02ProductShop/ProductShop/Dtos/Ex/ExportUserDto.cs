using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Ex
{
    [XmlType("user")]
    public class ExportUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]

        public string LastName { get; set; }
        [XmlElement("age")]

        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public ExportSoldProductDto  SoldProducts { get; set; }
    }
}
