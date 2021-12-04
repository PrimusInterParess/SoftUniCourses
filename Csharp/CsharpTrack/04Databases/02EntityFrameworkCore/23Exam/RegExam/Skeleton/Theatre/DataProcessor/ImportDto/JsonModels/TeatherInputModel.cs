using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto.JsonModels
{
    public class TeatherInputModel
    {

        public TeatherInputModel()
        {
            this.Tickets = new HashSet<TicketInputModel>();
        }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Range(1, 10)]
        public sbyte NumberOfHalls { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MinLength(4)]
        [MaxLength(30)]
        public string Director { get; set; }

        public ICollection<TicketInputModel> Tickets { get; set; }

        /*
         * "Name": "Corona Theatre",
           "NumberOfHalls": 7,
           "Director": "Alwin MacCosty",
           "Tickets": [

         */
    }
}
