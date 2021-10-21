using System;
using System.Collections.Generic;

#nullable disable

namespace _01Demo.Models
{
    public partial class Trip
    {
        public Trip()
        {
            AccountsTrips = new HashSet<AccountsTrip>();
        }

        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime BookDate { get; set; }
        public DateTime? CancelDate { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<AccountsTrip> AccountsTrips { get; set; }
    }
}
