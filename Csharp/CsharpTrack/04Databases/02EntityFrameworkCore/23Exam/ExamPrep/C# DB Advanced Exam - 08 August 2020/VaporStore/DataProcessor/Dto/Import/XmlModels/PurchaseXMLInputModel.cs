using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import.XmlModels
{
    [XmlType("Purchase")]
    public class PurchaseXMLInputModel
    {

        [XmlAttribute("title")]
        public string GameTitle { get; set; }

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.ProductKeyRegexPattern)]
        [XmlElement("Key")]
        public string ProductKey { get; set; }

        [Required]
        [XmlElement("Card")]

        [RegularExpression(GlobalConstants.CardNumberRegexPattern)]
        public string CardNumber { get; set; }

        [Required]
        public string Date { get; set; }

        /*
         *   <Purchase title="Dungeon Warfare 2">
             <Type>Digital</Type>
             <Key>ZTZ3-0D2S-G4TJ</Key>
             <Card>1833 5024 0553 6211</Card>
             <Date>07/12/2016 05:49</Date>
           </Purchase>

         */
    }
}
