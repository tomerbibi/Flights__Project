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
    public class CountryController : ControllerBase
    {
        [HttpGet("getcountries")]
        public async Task<ActionResult> GetAll()
        {
            List<Country> countries = new List<Country>();
            await Task.Run(() =>countries = new CountryDAOPGSQL().GetAll());
            return Ok(countries);
        }
    }
}
