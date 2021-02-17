using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Flights__Project
{
    class AdministratorDAOPGSQL : IAdministratorDAO
    {
        private static string connection_string;
        static AdministratorDAOPGSQL()
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
        public void Add(Administrator a)
        {
            ExecuteNonQuery($"call add_administrator('{a.FirstName}', '{a.LastName}', {a.Level}, {a.User_id})");
        }

        public Administrator Get(long id)
        {
            Administrator a = new Administrator();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_administrator({id})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    a.Id = (int)reader.GetValue(0);
                    a.FirstName = (string)reader.GetValue(1);
                    a.LastName = (string)reader.GetValue(2);
                    a.Level = (int)reader.GetValue(3);
                    a.User_id = (long)reader.GetValue(4);
                }
            }
            return a;
        }

        public List<Administrator> GetAll()
        {
            List<Administrator> administrators = new List<Administrator>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from get_all_administrators()", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    administrators.Add(new Administrator((int)reader.GetValue(0), (string)reader.GetValue(1),
                        (string)reader.GetValue(2), (int)reader.GetValue(3), (long)reader.GetValue(4)));
                }
            }
            return administrators;
        }

        public void Remove(Administrator a)
        {
            ExecuteNonQuery($"call remove_administrator({a.Id})");
        }

        public void Update(Administrator a)
        {
            ExecuteNonQuery($"call update_administrator({a.Id},'{a.FirstName}', '{a.LastName}', {a.Level}, {a.User_id})");
        }
    }
}
