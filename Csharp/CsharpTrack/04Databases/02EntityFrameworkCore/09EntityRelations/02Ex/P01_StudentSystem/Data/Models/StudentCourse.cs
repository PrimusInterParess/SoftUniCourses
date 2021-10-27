using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
   public class StudentCourse
    {

        public int StudentId { get; set; }

        [Required]
        public Student Student { get; set; }


        public int CourseId { get; set; }

        [Required]
        public Course Course { get; set; }

       
    }
}
