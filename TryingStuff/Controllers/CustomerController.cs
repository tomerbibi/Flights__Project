using Flights__Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryingStuff.Models;

namespace TryingStuff.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "customer")]
    [ApiController]
    public class CustomerController : FlightControllerBase<Customer>
    {
        /*FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
        facade = f as LoggedInCustomerFacade;
            token_customer = new LoginToken<Customer>()
            {
                User = GetLoginToken().User
            };*/
        LoggedInCustomerFacade facade;
        LoginToken<Customer> token_customer;

        [HttpPost("purchaseticket/{flight_id}")]
        public async Task<ActionResult> PurchaseTicket(int flight_id)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInCustomerFacade;
            token_customer = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_customer.Password && _.Username == token_customer.Name);
            token_customer.User = new CustomerDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            var result = await Task.Run(() => facade.PurchaseTicket(token_customer, new FlightDAOPGSQL().Get(flight_id)));
            if (result.Id == 0)
            {
                return StatusCode(204, $"{{there are no tickets left for the flight \"{flight_id}\"}}");
            }
            return Ok(result);
        }

        [HttpPost("cancleticket/{ticket_id}")]
        public async Task<ActionResult> CancleTicket(int ticket_id)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInCustomerFacade;
            token_customer = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_customer.Password && _.Username == token_customer.Name);
            token_customer.User = new CustomerDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            await Task.Run(() => facade.CancelTicket(token_customer, new TicketDAOPGSQL().Get(ticket_id)));
            return Ok();
        }




        // from here its functions for everyone
        [HttpGet("getflight/{flight_id}")]
        public async Task<ActionResult<Flight>> GetFlightById(int flight_id)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInCustomerFacade;
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
            facade = f as LoggedInCustomerFacade;
            var result = await Task.Run(() => facade.GetAllAirlineCompanies());
            return StatusCode(200, result);
        }

        [HttpGet("getallflights")]
        public async Task<ActionResult<List<Flight>>> GetAllFlights()
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInCustomerFacade;
            var result = await Task.Run(() => facade.GetAllFlights());
            return StatusCode(200, result);
        }

        [HttpPost("getflightsbydepatruredate")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByDepatrureDate([FromBody] DateTime date)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInCustomerFacade;
            var result = await Task.Run(() => facade.GetFlightsByDepatrureDate(date));
            return StatusCode(200, result);
        }

        [HttpPost("getflightsbylandingdate")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByLandingDate([FromBody] DateTime date)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInCustomerFacade;
            var result = await Task.Run(() => facade.GetFlightsByLandingDate(date));
            return StatusCode(200, result);
        }

        [HttpGet("getflightsbydestinationcountry/{country_id}")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByDestinationCountry(int country_id)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInCustomerFacade;
            var result = await Task.Run(() => facade.GetFlightsByDestinationCountry(country_id));
            return StatusCode(200, result);
        }

        [HttpGet("getflightsbyorigincountry/{country_id}")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByOriginCountry(int country_id)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInCustomerFacade;
            var result = await Task.Run(() => facade.GetFlightsByOriginCountry(country_id));
            return StatusCode(200, result);
        }

    }
}
