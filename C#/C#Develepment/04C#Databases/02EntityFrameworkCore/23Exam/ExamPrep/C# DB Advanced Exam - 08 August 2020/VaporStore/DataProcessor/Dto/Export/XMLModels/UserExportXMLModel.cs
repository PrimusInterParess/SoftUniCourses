using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export.XMLModels
{
    [XmlType("User")]
   public class UserExportXMLModel
    {
        public UserExportXMLModel()
        {
            this.Purchases = new List<PurchaseExportXMLModel>();
        }

        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public ICollection<PurchaseExportXMLModel> Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalMoney { get; set; }
    }
}
