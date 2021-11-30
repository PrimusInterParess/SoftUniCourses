using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("User")]
    public class UserInputModel
    {

        [XmlElement("firstName")]
        public string FirstName { get; set; }


        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }



        /*
         *     <firstName>Wallas</firstName>
               <lastName>Duffyn</lastName>
               <age>44</age>
         */
    }
}
