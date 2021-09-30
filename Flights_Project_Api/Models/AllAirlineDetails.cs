using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flights_Project_Api.Models
{
    public class AllAirlineDetails
    {
        public AllAirlineDetails()
        {
        }

        public AllAirlineDetails(string username, string password, string email,
            string name, int countryId, long userId)
        {
            Username = username;
            Password = password;
            Email = email;
            Name = name;
            CountryId = countryId;
            UserId = userId;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public long UserId { get; set; }
    }
}
