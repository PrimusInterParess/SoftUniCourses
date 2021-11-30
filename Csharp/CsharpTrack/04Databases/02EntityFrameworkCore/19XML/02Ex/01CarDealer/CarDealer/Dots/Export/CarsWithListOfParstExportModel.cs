using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Castle.DynamicProxy.Generators.Emitters;

namespace CarDealer.Dots.Export
{

    [XmlType("car")]
   public class CarsWithListOfParstExportModel
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDisntace { get; set; }

        [XmlArray("parts")]
        public List<PartExportModel> Parts { get; set; }

        //  <car make="Opel" model="Astra" travelled-distance="516628215">
    }
}
