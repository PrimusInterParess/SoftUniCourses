using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto.XmlModels
{
    [XmlType("Cast")]
    public class CastInputModel
    {
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public bool IsMainCharacter { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^\+44\-[0-9]{2}\-[0-9]{3}\-[0-9]{4}$")]
        public string PhoneNumber { get; set; }

        public int PlayId { get; set; }
    }
}
