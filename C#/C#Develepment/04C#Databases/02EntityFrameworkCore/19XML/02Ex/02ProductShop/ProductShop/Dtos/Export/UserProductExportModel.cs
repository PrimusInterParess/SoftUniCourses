using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
   
    
    [XmlType("user")]
    public class UserProductExportModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlArray("SoldProducts")]
        public SoldProductsExportModel SoldProducts { get; set; }
    }


    public class SoldProductsExportModel
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public List<SoldProductExportModel> Products { get; set; }
    }

    [XmlType("Product")]
    public class SoldProductExportModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
