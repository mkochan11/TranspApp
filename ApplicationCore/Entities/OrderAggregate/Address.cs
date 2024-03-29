﻿using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.OrderAggregate
{
    public class Address : BaseEntity, IAggregateRoot
    {
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;

        public Address(string country, string city, string postalCode, string street, string houseNumber) {
            this.Country = country;
            this.City = city;
            this.PostalCode = postalCode;
            this.Street = street;
            this.HouseNumber = houseNumber;
        }
    }
}
