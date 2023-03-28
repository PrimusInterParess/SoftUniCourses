using System;
using System.Collections.Generic;

#nullable disable

namespace _01Demo.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountsTrips = new HashSet<AccountsTrip>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int CityId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<AccountsTrip> AccountsTrips { get; set; }
    }
}
