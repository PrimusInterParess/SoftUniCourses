using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo.Models
{
   public class Town
    {
        public int  Id { get; set; }

        public string  Name { get; set; }



        public ICollection<Employee> NativeCitizens { get; set; }


        public ICollection<Employee> Workers { get; set; }
    }
}
