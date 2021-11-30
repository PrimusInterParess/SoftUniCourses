using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace VaporStore.DataProcessor.Dto.Import.JsonModels
{
   public class CardJsonInputModel
    {
      

        [Required]
        [RegularExpression(GlobalConstants.CardNumberRegexPattern)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CVCRegexPattern)]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }

        /*
         *"     Number": "8746 7253 1464 1729",
				"CVC": "756",
				"Type": "Credit"
         *
         *
         */
    }
}
