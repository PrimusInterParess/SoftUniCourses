using System;
using System.Collections.Generic;

#nullable disable

namespace _01Demo.Models
{
    public partial class AccountsTrip
    {
        public int AccountId { get; set; }
        public int TripId { get; set; }
        public int Luggage { get; set; }

        public virtual Account Account { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
