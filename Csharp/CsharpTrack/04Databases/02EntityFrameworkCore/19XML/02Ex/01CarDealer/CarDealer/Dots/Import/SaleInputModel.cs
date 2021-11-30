using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dots.Import
{

    [XmlType("Sale")]
   public class SaleInputModel
    {
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        /*
         * <Sale>
           <carId>336</carId>
           <customerId>2</customerId>
           <discount>40</discount>
         */
    }
}
