using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade
    {
        public List<AirlineCompany> GetAllAirlineCompanies()
        {
            return _airlineDAOPGSQL.GetAll();
        }

        public List<Flight> GetAllFlights()
        {
            return _flightDAOPGSQL.GetAll();
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            return _flightDAOPGSQL.GetAllFlightsVacancy();
        }

        public Flight GetFlightById(int id)
        {
            return _flightDAOPGSQL.Get(id);
        }

        public List<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            return _flightDAOPGSQL.GetFlightsByDepatrureDate(departureDate);
        }

        public List<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            return _flightDAOPGSQL.GetFlightsByDestinationCountry(countryCode);
        }

        public List<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            return GetFlightsByLandingDate(landingDate);
        }

        public List<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            return _flightDAOPGSQL.GetFlightsByOriginCountry(countryCode);
        }
    }
}
