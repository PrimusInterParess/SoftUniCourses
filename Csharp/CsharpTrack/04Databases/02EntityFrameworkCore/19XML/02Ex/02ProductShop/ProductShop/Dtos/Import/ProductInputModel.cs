using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Castle.DynamicProxy.Generators.Emitters;

namespace ProductShop.Dtos.Import
{
    [XmlType("Product")]
    public class ProductInputModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("sellerId")]
        public int? SellerId { get; set; }

        [XmlElement("buyerId")]
        public int? BuyerId { get; set; }



        /*
         *    <name>U-max Multi BB</name>
              <price>137.16</price>
              <sellerId>20</sellerId>
              <buyerId>35</buyerId>
         */
    }
}
