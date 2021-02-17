using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    interface IAirlineDAO : IBasicDB<AirlineCompany>
    {
        AirlineCompany GetAirlineByUserame(string name);
        List<AirlineCompany> GetAllAirlinesByCountry(int countryId);

    }
}
