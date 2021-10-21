using System;
using System.Collections.Generic;

#nullable disable

namespace _01Demo.Models
{
    public partial class Planet
    {
        public Planet()
        {
            Spaceports = new HashSet<Spaceport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Spaceport> Spaceports { get; set; }
    }
}
