using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using CarDealer.Dots.Import;

namespace CarDealer.Dots.Export
{
    [XmlType("car")]
    public class CarExportModel
    {
       [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]

        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
