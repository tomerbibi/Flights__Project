using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public interface ILoggedInCustomerFacade
    {
        List<Flight> GetAllMyFlights(LoginToken<Customer> token);
        Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight);
        void CancelTicket(LoginToken<Customer> token, Ticket ticket);
    }
}
