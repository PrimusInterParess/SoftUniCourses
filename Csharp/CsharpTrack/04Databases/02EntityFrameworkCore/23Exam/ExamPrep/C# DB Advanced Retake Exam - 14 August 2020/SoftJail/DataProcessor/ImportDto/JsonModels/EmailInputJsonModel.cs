using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto.JsonModels
{
    public class EmailInputJsonModel


    {

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]

        public string Description { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Sender { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(GlobalConstants.AddressRegexPattern)]
        public string Address { get; set; }


        /*
         *         "Description": "Invalid FullName",
                    "Sender": "Invalid Sender",
                    "Address": "No Address"
                  },

         */
    }
}
