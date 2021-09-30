using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public class AirlineAuth
    {
        public AirlineAuth()
        {
        }

        public AirlineAuth(long id, string name, int countryID, string userName,
            string password, string email)
        {
            Id = id;
            Name = name;
            CountryID = countryID;
            UserName = userName;
            Password = password;
            Email = email;
        }

        public AirlineAuth(string name, int countryID,  string userName, string password, string email)
        {
            Name = name;
            CountryID = countryID;
            UserName = userName;
            Password = password;
            Email = email;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public override bool Equals(object obj)
        {
            return this.Id == ((AirlineCompany)obj).Id;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        public static bool operator ==(AirlineAuth airline1, AirlineAuth airline2)
        {
            return airline1.Id == airline2.Id;
        }
        public static bool operator !=(AirlineAuth airlineCompany1, AirlineAuth airline2)
        {
            return !(airlineCompany1 == airline2);
        }


        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
