using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    class Flight : IPoco
    {
        public Flight()
        {
        }

        public Flight(long airlineCompanyID, int originCountryID, int destinationCountryID,
            DateTime departureTime, DateTime landingTime, int remainingTickets)
        {
            AirlineCompanyID = airlineCompanyID;
            OriginCountryID = originCountryID;
            DestinationCountryID = destinationCountryID;
            DepartureTime = departureTime;
            LandingTime = landingTime;
            RemainingTickets = remainingTickets;
        }

        public Flight(long id, long airlineCompanyID, int originCountryID, int destinationCountryID,
            DateTime departureTime, DateTime landingTime, int remainingTickets)
        {
            Id = id;
            AirlineCompanyID = airlineCompanyID;
            OriginCountryID = originCountryID;
            DestinationCountryID = destinationCountryID;
            DepartureTime = departureTime;
            LandingTime = landingTime;
            RemainingTickets = remainingTickets;
        }

        public long Id { get; set; }
        public long AirlineCompanyID { get; set; }
        public int OriginCountryID { get; set; }
        public int DestinationCountryID { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }
        public int RemainingTickets { get; set; }
        public override bool Equals(object obj)
        {
            return this.Id == ((Flight)obj).Id;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        public static bool operator ==(Flight fligh1, Flight fligh2)
        {
            return fligh1.Id == fligh2.Id;
        }
        public static bool operator !=(Flight fligh1, Flight fligh2)
        {
            return !(fligh1 == fligh2);
        }


        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

    }
}
