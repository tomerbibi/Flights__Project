using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Flights__Project
{
    public class CountryDAOPGSQL : ICountryDAO
    {
        private static string connection_string;
        static CountryDAOPGSQL()
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
        public void Add(Country c)
        {
            ExecuteNonQuery($"call add_country('{c.Name}')");
        }

        public Country Get(long id)
        {
            Country c = new Country();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_country({(int)id})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c.Id = (int)reader.GetValue(0);
                    c.Name = (string)reader.GetValue(1);
                }
            }
            return c;
        }

        public List<Country> GetAll()
        {
            List<Country> countries = new List<Country>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from get_all_countries()", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    countries.Add(new Country((int)reader.GetValue(0), (string)reader.GetValue(1)));
                }
            }
            return countries;
        }

        public void Remove(Country c)
        {
            ExecuteNonQuery($"call remove_country({c.Id})");
        }

        public void Update(Country c)
        {
            ExecuteNonQuery($"call update_country({c.Id},'{c.Name}')");
        }
    }
}
