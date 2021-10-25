using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerAPI.ApplicationCore.Domain.CustomerAggregate
{
    public class Address  //Value Object
    {
        public string AddressLine { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public int CityCode { get; private set; }

        private Address() { }  //Ef Required

        public Address(string addressline,string city,string country, int cityCode)
        {
            AddressLine = addressline;
            City = city;
            Country = country;
            CityCode = cityCode;
        }
    }
}
