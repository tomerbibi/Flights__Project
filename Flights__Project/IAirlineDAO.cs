using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public interface IAirlineDAO : IBasicDB<AirlineCompany>
    {
        AirlineCompany GetAirlineByUserame(string name);
        List<AirlineCompany> GetAllAirlinesByCountry(int countryId);

    }
}
