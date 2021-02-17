using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    class Ticket : IPoco
    {
        public Ticket()
        {
        }

        public Ticket(long flightID, long custimerID)
        {
            FlightID = flightID;
            CustimerID = custimerID;
        }

        public Ticket(long id, long flightID, long custimerID)
        {
            Id = id;
            FlightID = flightID;
            CustimerID = custimerID;
        }

        public long Id { get; set; }
        public long FlightID { get; set; }
        public long CustimerID { get; set; }
        public override bool Equals(object obj)
        {
            return this.Id == ((Ticket)obj).Id;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        public static bool operator ==(Ticket ticket1, Ticket ticket2)
        {
            return ticket1.Id == ticket2.Id;
        }
        public static bool operator !=(Ticket ticket1, Ticket ticket2)
        {
            return !(ticket1 == ticket2);
        }


        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
