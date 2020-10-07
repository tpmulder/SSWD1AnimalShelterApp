using AnimalShelter.Core.Attributes;
using AnimalShelter.Core.Enums;
using AnimalShelter.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models
{
    public class Address : DbModelBase
    {
        public string StreetName { get; set; }
        public string CountryCode { get; set; }
        public int HouseNumber { get; set; }
        public string HouseNumberAddition { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
