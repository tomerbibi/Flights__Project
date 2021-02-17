using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    class LoggedInCustomerggedInCustomer : AnonymousUserFacade, ILoggedInCustomerFacade
    {
        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            if(ticket.CustimerID == token.User.Id)
            {
                Ticket t = new Ticket();
                _ticketDAOPGSQL.GetAll().ForEach(_ =>
                {
                    if (_.Id == ticket.Id)
                    {
                        t = _;
                        t.CustimerID = 0;
                        _ticketDAOPGSQL.Update(t);
                    }
                });
            }
        }

        public List<Flight> GetAllMyFlights(LoginToken<Customer> token)
        {
            List<Flight> f = new List<Flight>();

            _ticketDAOPGSQL.GetAll().ForEach(ticket =>
            {
                if (ticket.CustimerID == token.User.Id)
                {
                    f.Add(_flightDAOPGSQL.Get(ticket.FlightID));
                }
            });

            return f;
        }

        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {
            Ticket t = new Ticket();
            _ticketDAOPGSQL.GetAll().ForEach(ticket =>
            {
                if(ticket.FlightID == flight.Id && ticket.CustimerID != 0)
                {
                    t = ticket;
                    t.CustimerID = token.User.Id;
                    _ticketDAOPGSQL.Update(t);
                }
            });
            return t;
        }
    }
}
