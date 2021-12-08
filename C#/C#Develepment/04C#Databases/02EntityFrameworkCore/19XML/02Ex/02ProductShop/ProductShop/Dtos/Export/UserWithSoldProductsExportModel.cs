using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ProductShop.Models;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]

   public class UserWithSoldProductsExportModel
    {

        /*
         * <Users>
           <User>
             <firstName>Almire</firstName>
             <lastName>Ainslee</lastName>
             <soldProducts>

         */
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]

        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public List<ProductExportModel> SoldProducts { get; set; }
    }
}
