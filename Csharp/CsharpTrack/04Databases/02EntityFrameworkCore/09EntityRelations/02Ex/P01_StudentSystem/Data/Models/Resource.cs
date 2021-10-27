using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        /*

                ResourceId
	            Name (up to 50 characters, unicode)
            	Url (not unicode)
                ResourceType (enum – can be Video, Presentation, Document or Other)
                CourseId

         */


        public int ResourceId { get; set; }


        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
