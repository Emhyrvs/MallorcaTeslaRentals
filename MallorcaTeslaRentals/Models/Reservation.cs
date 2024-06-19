using System;
using System.Data;

namespace MallorcaTeslaRentals.Models
{
   
        public class Reservation
        {
            public Guid Id { get; set; }

           
            public Location ReturnLocation { get; set; }
            public Guid ReturnLocationId { get; set; }

           
            public Location PickupLocation { get; set; }
            public Guid PickupLocationId { get; set; }

           
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public Client Client { get; set; }
            public Guid ClientId { get; set; }

            public Car Car { get; set; }
            public Guid CarId { get; set; }

        public Decimal TotalCost { get; set; }
        }
    

}
