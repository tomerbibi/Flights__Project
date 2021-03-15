using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {
        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if(token.User.Id == flight.AirlineCompanyID)
                _flightDAOPGSQL.Remove(flight);
            else
                Console.WriteLine($"the flight that you try to cancel belongs to another airline");
        }

        public void ChangeMyPassword(LoginToken<AirlineCompany> token, string oldPassword, string newPassword)
        {
            User u = new User();
            _userDAOPGSQL.GetAll().ForEach(_ =>
            {
                if (_.Id == token.User.UserId)
                    u = _;
            });

            int i = 0;
            while(true)
            {
                if (u.Password == oldPassword)
                {
                    u.Password = newPassword;
                    _userDAOPGSQL.Update(u);
                }

                else
                {
                    if (i == 5)
                        break;
                    Console.WriteLine("the password that you entered does not match the old password please try again");
                    i++;
                }
            }

        }

        public void CreateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token.User.Id == flight.AirlineCompanyID)
                _flightDAOPGSQL.Add(flight);
            else
                Console.WriteLine("the flight that you try to create belongs to another airline");
        }

        public List<Flight> GetAllFlights(LoginToken<AirlineCompany> token)
        {
            List<Flight> f = new List<Flight>();
            _flightDAOPGSQL.GetAll().ForEach(flight =>
            {
                if (flight.AirlineCompanyID == token.User.Id)
                {
                    f.Add(flight);
                }
            });
            return f;
        }

        public List<Ticket> GetAllTickets(LoginToken<AirlineCompany> token)
        {
            List<Ticket> t = new List<Ticket>();
            _flightDAOPGSQL.GetAll().ForEach(flight =>
            {
                if (flight.AirlineCompanyID == token.User.Id)
                {
                    _ticketDAOPGSQL.GetAll().ForEach(ticket =>
                    {
                        if(ticket.FlightID == flight.Id)
                        {
                            t.Add(ticket);
                        }
                    });
                }
            });
            return t;
        }

        public void MofidyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline)
        {
            if(token.User.Id == airline.Id)
                _airlineDAOPGSQL.Update(airline);
            else
                Console.WriteLine("the id of the token and the id of the modified airline does not match");
        }

        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token.User.Id == flight.AirlineCompanyID)
                _flightDAOPGSQL.Update(flight);
            else
                Console.WriteLine("the flight that you try to modify belongs to another airline");
        }
    }
}
