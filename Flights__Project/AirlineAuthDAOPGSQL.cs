using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Flights__Project
{
    public class AirlineAuthDAOPGSQL
    {
        private static string connection_string;
        static AirlineAuthDAOPGSQL()
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

        public void Add(AirlineAuth a)
        {
            ExecuteNonQuery($"call add_airline_to_auth('{a.Name}', {a.CountryID}, '{a.UserName}', '{a.Password}', '{a.Email}')");
        }

        public void Remove(long a)
        {
            ExecuteNonQuery($"call remove_airline_auth({a})");
        }

        public List<AirlineAuth> GetAll()
        {
            List<AirlineAuth> airlineCompanies = new List<AirlineAuth>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from get_all_airline_auth()", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    airlineCompanies.Add(new AirlineAuth((long)reader.GetValue(0), (string)reader.GetValue(1)
                        , (int)reader.GetValue(2), (string)reader.GetValue(3),
                        (string)reader.GetValue(4), (string)reader.GetValue(5)));
                }
            }
            return airlineCompanies;
        }



    }
}
