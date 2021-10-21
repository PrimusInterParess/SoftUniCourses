using System;
using System.Collections.Generic;

#nullable disable

namespace _01Demo.Models
{
    public partial class Colonist
    {
        public Colonist()
        {
            TravelCards = new HashSet<TravelCard>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ucn { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<TravelCard> TravelCards { get; set; }
    }
}
