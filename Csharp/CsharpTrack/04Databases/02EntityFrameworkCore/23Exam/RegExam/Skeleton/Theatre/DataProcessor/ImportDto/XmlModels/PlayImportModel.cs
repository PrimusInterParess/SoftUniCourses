using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto.XmlModels
{
    [XmlType("Play")]
    public class PlayImportModel
    {
        [XmlElement("Title")]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Range(typeof(double), "0.00", "100.00")]
        public double Rating { get; set; }

        [XmlElement("Genre")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Genre { get; set; }

        [XmlElement("Description")]

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(700)]
        public string Description { get; set; }


        [XmlElement("Screenwriter")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; }
        /*
         *
         * <Play>
            <Title>The Hsdfoming</Title>
            <Duration>03:40:00</Duration>
            <Rating>8.2</Rating>
            <Genre>Action</Genre>
            <Description>A guyat Pinter turns into a debatable 
        conundrum as oth ordinary and menacing. Much of this has to do with
        the fabled "Pinter Pause," which simply mirrors the way we often resp
        ond to each other in conversation, tossing in remainders of thoughts o
        n one subject well after having moved on to another.</Description>
            <Screenwriter>Roger Nciotti</Screenwriter>

         */
    }
}
