using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Flights__Project
{
    public class FlightDAOPGSQL : IFlightDAO
    {
        private static string connection_string;
        static FlightDAOPGSQL()
        {
            var reader = File.OpenText("ConnectionStringConfig.txt");
            connection_string = reader.ReadToEnd();
        }
        private void ExecuteNonQuery(string procedure_string)
        {
            using (var con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(procedure_string, con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
        public void Add(Flight f)
        {
            ExecuteNonQuery($"call add_flight({f.AirlineCompanyID}, {f.OriginCountryID}, " +
                $"{f.DestinationCountryID}, '{f.DepartureTime}', '{f.LandingTime}', {f.RemainingTickets})");
        }

        public Flight Get(long id)
        {
            Flight f = new Flight();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_flight({id})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    f.Id = (long)reader.GetValue(0);
                    f.AirlineCompanyID = (long)reader.GetValue(1);
                    f.OriginCountryID = (int)reader.GetValue(2);
                    f.DestinationCountryID = (int)reader.GetValue(3);
                    f.DepartureTime = (DateTime)reader.GetValue(4);
                    f.LandingTime = (DateTime)reader.GetValue(5);
                    f.RemainingTickets = (int)reader.GetValue(6);

                }
            }
            return f;
        }

        public List<Flight> GetAll()
        {
            List<Flight> flights = new List<Flight>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from get_all_flights()", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flights.Add(new Flight((long)reader.GetValue(0), (long)reader.GetValue(1),
                        (int)reader.GetValue(2), (int)reader.GetValue(3), (DateTime)reader.GetValue(4),
                        (DateTime)reader.GetValue(5), (int)reader.GetValue(6)));
                }
            }
            return flights;
        }

        public void Remove(Flight f)
        {
            ExecuteNonQuery($"call remove_flight({f.Id})");
        }

        public void Update(Flight f)
        {
            ExecuteNonQuery($"call update_flight({f.Id}, {f.AirlineCompanyID}, {f.OriginCountryID}," +
                $" {f.DestinationCountryID}, '{f.DepartureTime}', '{f.LandingTime}', {f.RemainingTickets})");
        }


        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            Dictionary<Flight, int> flights = new Dictionary<Flight, int>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from get_all_flights()", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flights.Add(new Flight((long)reader.GetValue(0), (long)reader.GetValue(1),
                        (int)reader.GetValue(2), (int)reader.GetValue(3), (DateTime)reader.GetValue(4),
                        (DateTime)reader.GetValue(5), (int)reader.GetValue(6)), (int)reader.GetValue(6));
                }
            }
            return flights;
        }



        // you said that we need to make a GetFlightById function but the normal get is already by id... 
        public Flight GetFlightById(int id)
        {
            throw new NotImplementedException();
        }


        public List<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            List<Flight> flights = new List<Flight>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_flights_by_origin_country({countryCode})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flights.Add(new Flight((long)reader.GetValue(0), (long)reader.GetValue(1),
                        (int)reader.GetValue(2), (int)reader.GetValue(3), (DateTime)reader.GetValue(4),
                        (DateTime)reader.GetValue(5), (int)reader.GetValue(6)));
                }
            }
            return flights;
        }

        public List<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            List<Flight> flights = new List<Flight>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_flights_by_destination_country({countryCode})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flights.Add(new Flight((long)reader.GetValue(0), (long)reader.GetValue(1),
                        (int)reader.GetValue(2), (int)reader.GetValue(3), (DateTime)reader.GetValue(4),
                        (DateTime)reader.GetValue(5), (int)reader.GetValue(6)));
                }
            }
            return flights;
        }

        public List<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            List<Flight> flights = new List<Flight>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_flights_by_departure_date({departureDate})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flights.Add(new Flight((long)reader.GetValue(0), (long)reader.GetValue(1),
                        (int)reader.GetValue(2), (int)reader.GetValue(3), (DateTime)reader.GetValue(4),
                        (DateTime)reader.GetValue(5), (int)reader.GetValue(6)));
                }
            }
            return flights;
        }

        public List<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            List<Flight> flights = new List<Flight>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_flights_by_landing_date({landingDate})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flights.Add(new Flight((long)reader.GetValue(0), (long)reader.GetValue(1),
                        (int)reader.GetValue(2), (int)reader.GetValue(3), (DateTime)reader.GetValue(4),
                        (DateTime)reader.GetValue(5), (int)reader.GetValue(6)));
                }
            }
            return flights;
        }

        public List<Flight> GetFlightsByCustomer(Customer customer)
        {
            List<Flight> returnedFlights = new List<Flight>();
            List<Flight> flights = new List<Flight>();
            TicketDAOPGSQL t = new TicketDAOPGSQL();
            List<Ticket> tickets = t.GetAll();
            tickets.ForEach(ticket =>
            {
                if (ticket.CustimerID == customer.Id)
                {
                    returnedFlights.Add(Get(ticket.FlightID));
                }
            });
            return returnedFlights;
        }

    }
}
