using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public class AirlineCompany : IPoco, IUser
    {
        public AirlineCompany()
        {
        }

        public AirlineCompany(string name, int countryID, long userId)
        {
            Name = name;
            CountryID = countryID;
            UserId = userId;
        }

        public AirlineCompany(long id, string name, int countryID, long userId)
        {
            Id = id;
            Name = name;
            CountryID = countryID;
            UserId = userId;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public long UserId { get; set; }
        public override bool Equals(object obj)
        {
            return this.Id == ((AirlineCompany)obj).Id;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        public static bool operator ==(AirlineCompany airlineCompany1, AirlineCompany airlineCompany2)
        {
            return airlineCompany1.Id == airlineCompany2.Id;
        }
        public static bool operator !=(AirlineCompany airlineCompany1, AirlineCompany airlineCompany2)
        {
            return !(airlineCompany1 == airlineCompany2);
        }


        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

    }
}
