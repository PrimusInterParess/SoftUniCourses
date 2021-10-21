using System;
using System.Collections.Generic;

#nullable disable

namespace _01Demo.Models
{
    public partial class City
    {
        public City()
        {
            Accounts = new HashSet<Account>();
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
