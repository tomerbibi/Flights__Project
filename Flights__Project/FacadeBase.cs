using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public class FacadeBase
    {
        protected AirlineDAOPGSQL _airlineDAOPGSQL = new AirlineDAOPGSQL();
        protected CountryDAOPGSQL _countryDAOPGSQL = new CountryDAOPGSQL();
        protected CustomerDAOPGSQL _customerDAOPGSQL = new CustomerDAOPGSQL();
        protected AdministratorDAOPGSQL _adminDAOPGSQL = new AdministratorDAOPGSQL();
        protected UserDAOPGSQL _userDAOPGSQL = new UserDAOPGSQL();
        protected FlightDAOPGSQL _flightDAOPGSQL = new FlightDAOPGSQL();
        protected TicketDAOPGSQL _ticketDAOPGSQL = new TicketDAOPGSQL();
    }
}
