using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    interface IAnonymousUserFacade
    {
        List<Flight> GetAllFlights();
        List<AirlineCompany> GetAllAirlineCompanies();
        Dictionary<Flight, int> GetAllFlightsVacancy();
        Flight GetFlightById(int id);
        List<Flight> GetFlightsByOriginCountry(int countryCode);
        List<Flight> GetFlightsByDestinationCountry(int countryCode);
        List<Flight> GetFlightsByDepatrureDate(DateTime departureDate);
        List<Flight> GetFlightsByLandingDate(DateTime landingDate);
    }
}
