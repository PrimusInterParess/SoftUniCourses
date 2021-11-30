using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ProductShop.Models;

namespace ProductShop.Dtos.Export
{

    [XmlType("Product")]
    public class ProductInRangeExportModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string Buyer { get; set; }

        /*
         *  <Product>
            <name>Allopurinol</name>
            <price>518.5</price>
            <buyer>Wallas Duffyn</buyer>
            </Product>

         */
    }
}
