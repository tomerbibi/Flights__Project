using Flights__Project;
using Flights_Project_Rest_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flights_Project_Rest_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "airlinecompany")]
    public class AirlineController : FlightControllerBase<AirlineCompany>
    {
        LoggedInAirlineFacade facade;
        LoginToken<AirlineCompany> token_airline;
        [HttpDelete("cancelflight")]
        public async Task<ActionResult<Flight>> CancelFlight([FromBody] Flight flight)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            token_airline = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_airline.Password && _.Username == token_airline.Name);
            token_airline.User = new AirlineDAOPGSQL().GetAll().FirstOrDefault(_ => _.UserId == u.Id);
            await Task.Run(() => facade.CancelFlight(token_airline, flight));
            return StatusCode(200, flight);
        }

        [HttpPost("changemypassword/{old_password}/{new_password}")]
        public async Task<ActionResult<Customer>> ChangeMyPassword(string old_password, string new_password)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            token_airline = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_airline.Password && _.Username == token_airline.Name);
            token_airline.User = new AirlineDAOPGSQL().GetAll().FirstOrDefault(_ => _.UserId == u.Id);
            await Task.Run(() => facade.ChangeMyPassword(token_airline, old_password, new_password));
            return StatusCode(200);
        }

        [HttpPut("createflight")]
        public async Task<ActionResult<Customer>> CreateFlight([FromBody] Flight flight)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            token_airline = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_airline.Password && _.Username == token_airline.Name);
            token_airline.User = new AirlineDAOPGSQL().GetAll().FirstOrDefault(_ => _.UserId == u.Id);
            await Task.Run(() => facade.CreateFlight(token_airline, flight));
            return StatusCode(200, flight);
        }

        [HttpGet("getallcompanyflights")]
        public async Task<ActionResult<List<Flight>>> GetAllCompanyFlights()
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            token_airline = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_airline.Password && _.Username == token_airline.Name);
            token_airline.User = new AirlineDAOPGSQL().GetAll().FirstOrDefault(_ => _.UserId == u.Id);
            var result = await Task.Run(() => facade.GetAllCompanyFlights(token_airline));
            return StatusCode(200, result);
        }

        [HttpGet("getalltickets")]
        public async Task<ActionResult<List<Ticket>>> GetAllTickets()
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            token_airline = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_airline.Password && _.Username == token_airline.Name);
            token_airline.User = new AirlineDAOPGSQL().GetAll().FirstOrDefault(_ => _.UserId == u.Id);
            var result = await Task.Run(() => facade.GetAllTickets(token_airline));
            return StatusCode(200, result);
        }

        [HttpPost("mofidyairlinedetails")]
        public async Task<ActionResult> MofidyAirlineDetails([FromBody] AirlineCompany airline)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            token_airline = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_airline.Password && _.Username == token_airline.Name);
            token_airline.User = new AirlineDAOPGSQL().GetAll().FirstOrDefault(_ => _.UserId == u.Id);
            await Task.Run(() => facade.MofidyAirlineDetails(token_airline, airline));
            return StatusCode(200);
        }

        [HttpPost("updateflight")]
        public async Task<ActionResult<Flight>> UpdateFlight([FromBody] Flight flight)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            token_airline = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_airline.Password && _.Username == token_airline.Name);
            token_airline.User = new AirlineDAOPGSQL().GetAll().FirstOrDefault(_ => _.UserId == u.Id);
            await Task.Run(() => facade.UpdateFlight(token_airline, flight));
            return StatusCode(200, flight);
        }

        [HttpGet("getflight/{flight_id}")]
        public async Task<ActionResult<Flight>> GetFlightById(int flight_id)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            Flight result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightById(flight_id));
            }
            catch (IllegalFlightParameter ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            if (result.Id == 0)
            {
                return StatusCode(204, $"{{there is no flight with the id \"{result.Id}\"}}");
            }
            return Ok(result);
        }

        [HttpGet("getallairlinecompanies")]
        public async Task<ActionResult<List<Flight>>> GetAllAirlineCompanies()
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            var result = await Task.Run(() => facade.GetAllAirlineCompanies());
            return StatusCode(200, result);
        }

        [HttpGet("getallflights")]
        public async Task<ActionResult<List<Flight>>> GetAllFlights()
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            var result = await Task.Run(() => facade.GetAllFlights());
            return StatusCode(200, result);
        }

        [HttpPost("getflightsbydepatruredate")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByDepatrureDate([FromBody] DateTime date)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            var result = await Task.Run(() => facade.GetFlightsByDepatrureDate(date));
            return StatusCode(200, result);
        }

        [HttpPost("getflightsbylandingdate")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByLandingDate([FromBody] DateTime date)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            var result = await Task.Run(() => facade.GetFlightsByLandingDate(date));
            return StatusCode(200, result);
        }

        [HttpGet("getflightsbydestinationcountry/{country_id}")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByDestinationCountry(int country_id)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            var result = await Task.Run(() => facade.GetFlightsByDestinationCountry(country_id));
            return StatusCode(200, result);
        }

        [HttpGet("getflightsbyorigincountry/{country_id}")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByOriginCountry(int country_id)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAirlineFacade;
            var result = await Task.Run(() => facade.GetFlightsByOriginCountry(country_id));
            return StatusCode(200, result);
        }
    }
}
