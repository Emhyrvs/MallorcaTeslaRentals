using System;
using System.Data;

namespace MallorcaTeslaRentals.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Location ReturnLocation { get; set; }
        public Location PickupLocation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime  EndDate { get; set; }

        public required Client Client { get; set; }

        public required Car Car { get; set; }
    }
}
