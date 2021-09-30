using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Flights__Project
{
    public class CustomerDAOPGSQL : ICustomerDAO
    {
        private static string connection_string;
        static CustomerDAOPGSQL()
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
        public void Add(Customer c)
        {
            ExecuteNonQuery($"call add_customer('{c.First_name}', '{c.Last_name}', '{c.Adress}', " +
                $"'{c.Phone}', '{c.Credit_card_no}', {c.User_id})");
        }

        public Customer Get(long id)
        {
            Customer c = new Customer();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_customer({id})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c.Id = (long)reader.GetValue(0);
                    c.First_name = (string)reader.GetValue(1);
                    c.Last_name = (string)reader.GetValue(2);
                    c.Adress = (string)reader.GetValue(3);
                    c.Phone = (string)reader.GetValue(4);
                    c.Credit_card_no = (string)reader.GetValue(5);
                    c.User_id = (long)reader.GetValue(6);
                }
            }
            return c;
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from get_all_customers()", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer((long)reader.GetValue(0), (string)reader.GetValue(1),
                        (string)reader.GetValue(2), (string)reader.GetValue(3), (string)reader.GetValue(4),
                        (string)reader.GetValue(5), (long)reader.GetValue(6)));
                }
            }
            return customers;
        }

        public void Remove(Customer c)
        {
            ExecuteNonQuery($"call remove_customer({c.Id})");
        }

        public void Update(Customer c)
        {
            ExecuteNonQuery($"call update_customer({c.Id},'{c.First_name}', '{c.Last_name}', " +
                $"'{c.Adress}', '{c.Phone}', '{c.Credit_card_no}', {c.User_id})");
        }

        public Customer GetCustomerByUserame(string name)
        {
            Customer c = new Customer();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_customer_by_username('{name}')", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c.Id = (long)reader.GetValue(0);
                    c.First_name = (string)reader.GetValue(1);
                    c.Last_name = (string)reader.GetValue(2);
                    c.Adress = (string)reader.GetValue(3);
                    c.Phone = (string)reader.GetValue(4);
                    c.Credit_card_no = (string)reader.GetValue(5);
                    c.User_id = (long)reader.GetValue(6);
                }
            }
            return c;
        }
    }
}
