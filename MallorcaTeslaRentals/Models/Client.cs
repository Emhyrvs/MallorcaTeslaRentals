﻿namespace MallorcaTeslaRentals.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }
        public string PersonalIdentificationNumber { get; set; }

        public string PhoneNumber { get; set; }
    }
}
