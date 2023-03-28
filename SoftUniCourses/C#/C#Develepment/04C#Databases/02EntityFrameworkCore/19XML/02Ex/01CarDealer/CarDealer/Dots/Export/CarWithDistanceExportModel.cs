using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dots.Export
{
    [XmlType("car")]
    public class CarWithDistanceExportModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }

        /*
        * <cars>
           <car>
             <make>BMW</make>
             <model>1M Coupe</model>
             <travelled-distance>39826890</travelled-distance>
           </car>

        */

    }
}
