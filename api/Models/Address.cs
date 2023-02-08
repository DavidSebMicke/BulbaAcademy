using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.Models
{
    public class Address
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string StreetAddress { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [Range(10000, 99999)]
        public int PostalCode { get; set; }

        public Address()
        { }

        public Address(string streetAddress, string city, int postalCode)
        {
            StreetAddress = streetAddress;
            City = city;
            PostalCode = postalCode;
        }
    }
}