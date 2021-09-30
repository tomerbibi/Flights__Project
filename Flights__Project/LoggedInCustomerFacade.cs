using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public class LoggedInCustomerFacade : AnonymousUserFacade, ILoggedInCustomerFacade
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
            else
                Console.WriteLine("the ticket that you try to cancel belongs to another customer");
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
            Ticket ticket = new Ticket();
            /* _ticketDAOPGSQL.GetAll().ForEach(ticket =>
             {
                 if(ticket.FlightID == flight.Id && ticket.CustimerID == 0)
                 {
                     t = ticket; 
                     t.CustimerID = token.User.Id;
                     _ticketDAOPGSQL.Update(t);
                 } 
             });*/
            ticket = _ticketDAOPGSQL.GetAll().Find(t => t.FlightID == flight.Id && t.CustimerID == 0);
            if (ticket is null) 
                Console.WriteLine("sorry we are out of tickets for this flight");
            else
            {
                ticket.CustimerID = token.User.Id;
                _ticketDAOPGSQL.Update(ticket);
            }
            return ticket;
        }
    }
}
