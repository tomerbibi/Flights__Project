using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Flights__Project
{
    class AirlineDAOPGSQL : IAirlineDAO
    {
        private static string connection_string;
        static AirlineDAOPGSQL()
        {
            var reader = File.OpenText("ConnectionStringConfig.txt");
            string connection_string = reader.ReadToEnd();
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
        public void Add(AirlineCompany a)
        {
            ExecuteNonQuery($"call add_airline('{a.Name}', {a.CountryID}, {a.UserId})");
        }

        public AirlineCompany Get(long id)
        {
            AirlineCompany a = new AirlineCompany();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_airline({id})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    a.Id = (long)reader.GetValue(0);
                    a.Name = (string)reader.GetValue(1);
                    a.CountryID = (int)reader.GetValue(2);
                    a.UserId = (long)reader.GetValue(3);
                }
            }
            return a;
        }

        public List<AirlineCompany> GetAll()
        {
            List<AirlineCompany> airlineCompanies = new List<AirlineCompany>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from get_all_airline_companies()", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    airlineCompanies.Add(new AirlineCompany((long)reader.GetValue(0), (string)reader.GetValue(1),
                        (int)reader.GetValue(2), (long)reader.GetValue(3)));
                }
            }
            return airlineCompanies;
        }

        public void Remove(AirlineCompany a)
        {
            ExecuteNonQuery($"call remove_airline({a.Id})");
        }

        public void Update(AirlineCompany a)
        {
            ExecuteNonQuery($"call update_airline({a.Id},'{a.Name}', {a.CountryID}, {a.UserId})");
        }


        public AirlineCompany GetAirlineByUserame(string name)
        {
            AirlineCompany a = new AirlineCompany();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_airline_by_username('{name}')", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    a.Id = (long)reader.GetValue(0);
                    a.Name = (string)reader.GetValue(1);
                    a.CountryID = (int)reader.GetValue(2);
                    a.UserId = (long)reader.GetValue(3);
                }
            }
            return a;
        }

        public List<AirlineCompany> GetAllAirlinesByCountry(int countryId)
        {
            List<AirlineCompany> airlineCompanies = new List<AirlineCompany>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_all_airlines_by_country({countryId})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    airlineCompanies.Add(new AirlineCompany((long)reader.GetValue(0), (string)reader.GetValue(1),
                        (int)reader.GetValue(2), (long)reader.GetValue(3)));
                }
            }
            return airlineCompanies;
        }
    }
}
