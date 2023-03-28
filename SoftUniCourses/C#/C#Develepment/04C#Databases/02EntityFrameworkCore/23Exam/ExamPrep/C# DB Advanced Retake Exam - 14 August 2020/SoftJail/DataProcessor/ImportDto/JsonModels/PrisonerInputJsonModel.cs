using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto.JsonModels
{
    public class PrisonerInputJsonModel
    {
        public PrisonerInputJsonModel()
        {
            this.Mails = new List<EmailInputJsonModel>();
        }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(GlobalConstants.PrisonerNickNameRegexPattern)]
        public string Nickname { get; set; }

        [Range(18,65)]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public ICollection<EmailInputJsonModel> Mails { get; set; }

        /*
         *  {
           "FullName": null,
           "Nickname": "The Null",
           "Age": 38,
           "IncarcerationDate": "12/09/1967",
           "ReleaseDate": "07/02/1989",
           "Bail": 93934.2,
           "CellId": 4,
           "Mails": [

         */
    }
}
