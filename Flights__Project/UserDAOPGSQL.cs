using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Flights__Project
{
    public class UserDAOPGSQL : IUserDAO
    {
        private static string connection_string;
        static UserDAOPGSQL()
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
        public void Add(User u)
        {
            ExecuteNonQuery($"call add_user('{u.Username}', '{u.Password}', {u.Email}, {u.UserRole})");
        }

        public User Get(long id)
        {
            User u = new User();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_user({id})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    u.Id = (long)reader.GetValue(0);
                    u.Username = (string)reader.GetValue(1);
                    u.Password = (string)reader.GetValue(2);
                    u.Email = (string)reader.GetValue(3);
                    u.UserRole = (int)reader.GetValue(4);
                }
            }
            return u;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from get_all_users()", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User((long)reader.GetValue(0), (string)reader.GetValue(1),
                        (string)reader.GetValue(2), (string)reader.GetValue(3), (int)reader.GetValue(4)));
                }
            }
            return users;
        }

        public void Remove(User u)
        {
            ExecuteNonQuery($"call remove_user({u.Id})");
        }

        public void Update(User u)
        {
            ExecuteNonQuery($"call update_user({u.Id},'{u.Username}', '{u.Password}', '{u.Email}'," +
            $" {u.UserRole})");
        }
    }
}
