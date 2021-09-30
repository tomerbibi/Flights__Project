using Flights__Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flights_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnonymousController : FlightControllerBase<Customer>
    {
        AnonymousUserFacade facade = new AnonymousUserFacade();

        [HttpGet("getallflights")]
        public async Task<ActionResult<List<Flight>>> GetAllFlights()
        {
            var result = await Task.Run(() => facade.GetAllFlights());
            return StatusCode(200, result);
        }
        [HttpGet("getallairlinecompanies")]
        public async Task<ActionResult<List<Flight>>> GetAllAirlineCompanies()
        {

            var result = await Task.Run(() => facade.GetAllAirlineCompanies());
            return StatusCode(200, result);
        }
    }
}
