using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flights__Project
{
    public class FlightsCenterSystem
    {
        private static FlightsCenterSystem _instance;
        private static object key = new object();
        private LoginService loginService = new LoginService();
        private FlightsCenterSystem()
        {
            AddToHistory();
            //t.RunSynchronously();
            //var result = Task.Run(() => Console.WriteLine());
        }

        public async void AddToHistory()
        {
            FlightDAOPGSQL fl = new FlightDAOPGSQL();
            var reader = File.OpenText("ConnectionStringConfig.txt");
            string connection_string = reader.ReadToEnd();
            await Task.Run(() =>
            {
                using (var con = new NpgsqlConnection(connection_string))
                {
                    while (true)
                    {
                        Thread.Sleep(86400000);
                        fl.GetAll().ForEach(_ =>
                        {
                            if (_.LandingTime < DateTime.Now.AddHours(3))
                            {

                                con.Open();
                                NpgsqlCommand cmd = new NpgsqlCommand("call add_to_history", con);
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.ExecuteNonQuery();

                                fl.Remove(_);
                            }
                        });
                    }
                }
            });
        }
        public static FlightsCenterSystem GetInstance()
        {
            if (_instance == null)
            {
                lock (key)
                {
                    if (_instance == null)
                    {
                        _instance = new FlightsCenterSystem();
                    }
                }
            }
            return _instance;
        }

        public void login(string userName, string password, out LoginToken<object> token, out FacadeBase facade)
        {
            loginService.Login(userName, password, out LoginToken<object> l, out FacadeBase f);
            token = l;
            facade = f;
        }


    }
}
