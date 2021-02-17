using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Flights__Project
{
    class TicketDAOPGSQL : ITickedDAO
    {
        private static string connection_string;
        static TicketDAOPGSQL()
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
        public void Add(Ticket t)
        {
            ExecuteNonQuery($"call add_ticket({t.FlightID}, {t.CustimerID})");
        }

        public Ticket Get(long id)
        {
            Ticket t = new Ticket();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"select * from get_ticket({id})", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    t.Id = (long)reader.GetValue(0);
                    t.FlightID = (long)reader.GetValue(1);
                    t.CustimerID = (long)reader.GetValue(2);
                }
            }
            return t;
        }

        public List<Ticket> GetAll()
        {
            List<Ticket> tickets = new List<Ticket>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection_string))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from get_all_tickets()", con);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tickets.Add(new Ticket((long)reader.GetValue(0), (long)reader.GetValue(1),
                        (long)reader.GetValue(2)));
                }
            }
            return tickets;
        }

        public void Remove(Ticket t)
        {
            ExecuteNonQuery($"call remove_ticket({t.Id})");
        }

        public void Update(Ticket t)
        {
            ExecuteNonQuery($"call update_ticket({t.Id}, {t.FlightID}, {t.CustimerID})");
        }
    }
}
