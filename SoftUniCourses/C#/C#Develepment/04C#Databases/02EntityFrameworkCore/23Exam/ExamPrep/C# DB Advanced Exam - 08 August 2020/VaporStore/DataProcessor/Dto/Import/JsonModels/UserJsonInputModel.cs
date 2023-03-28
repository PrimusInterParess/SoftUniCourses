using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import.JsonModels
{
    public class UserJsonInputModel
    {
        public UserJsonInputModel()
        {
            this.Cards = new List<CardJsonInputModel>();
        }


        [Required]

        [RegularExpression(GlobalConstants.FullNameRegexPattern)]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }



        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public ICollection<CardJsonInputModel> Cards { get; set; }

        /*    {
                "FullName": "Lorrie Silbert",
                "Username": "lsilbert",
                "Email": "lsilbert@yahoo.com",
                "Age": 33,
                "Cards": [
                  {
                    "Number": "1833 5024 0553 6211",
                    "CVC": "903",
                    "Type": "Debit"
                  },
                  {
                    "Number": "5625 0434 5999 6254",
                    "CVC": "570",
                    "Type": "Credit"
                  },
                  {
                    "Number": "4902 6975 5076 5316",
                    "CVC": "091",
                    "Type": "Debit"
                  }
                ]

         *
         *
         *
         */

    }
}
