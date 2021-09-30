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
    [Authorize(Roles = "administrator")]
    public class AdminController : FlightControllerBase<Administrator>
    {
        LoggedInAdministratorFacade facade;
        LoginToken<Administrator> token_admin;
        [HttpPut("createadmin")]
        public async Task<ActionResult<Administrator>> CreateAdmin([FromBody] Administrator admin)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            token_admin = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_admin.Password && _.Username == token_admin.Name);
            token_admin.User = new AdministratorDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            await Task.Run(() => facade.CreateAdmin(token_admin, admin));
            return StatusCode(200, admin);
        }

        [HttpPut("createnewairline")]
        public async Task<ActionResult<AirlineCompany>> CreateNewAirline([FromBody] AirlineCompany airline)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            token_admin = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_admin.Password && _.Username == token_admin.Name);
            token_admin.User = new AdministratorDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            await Task.Run(() => facade.CreateNewAirline(token_admin, airline));
            return StatusCode(200, airline);
        }

        [HttpPut("createnewcustomer")]
        public async Task<ActionResult<Customer>> CreateNewCustomer([FromBody] Customer customer)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            token_admin = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_admin.Password && _.Username == token_admin.Name);
            token_admin.User = new AdministratorDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            await Task.Run(() => facade.CreateNewCustomer(token_admin, customer));
            return StatusCode(200, customer);
        }
        [HttpGet("getallcustomers")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            token_admin = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_admin.Password && _.Username == token_admin.Name);
            token_admin.User = new AdministratorDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            var result = await Task.Run(() => facade.GetAllCustomers(token_admin));
            return StatusCode(200, result);
        }

        [HttpDelete("removeadmin")]
        public async Task<ActionResult<Customer>> RemoveAdmin([FromBody] Administrator admin)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            token_admin = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_admin.Password && _.Username == token_admin.Name);
            token_admin.User = new AdministratorDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            await Task.Run(() => facade.RemoveAdmin(token_admin, admin));
            return StatusCode(200, admin);
        }

        [HttpDelete("removeairline")]
        public async Task<ActionResult<Customer>> RemoveAirline([FromBody] AirlineCompany airline)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            token_admin = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_admin.Password && _.Username == token_admin.Name);
            token_admin.User = new AdministratorDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            await Task.Run(() => facade.RemoveAirline(token_admin, airline));
            return StatusCode(200, airline);
        }

        [HttpDelete("removecustomer")]
        public async Task<ActionResult<Customer>> RemoveCustomer([FromBody] Customer customer)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            token_admin = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_admin.Password && _.Username == token_admin.Name);
            token_admin.User = new AdministratorDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            await Task.Run(() => facade.RemoveCustomer(token_admin, customer));
            return StatusCode(200, customer);
        }

        [HttpPost("updateadmin")]
        public async Task<ActionResult<Customer>> UpdateAdmin([FromBody] Administrator admin)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            token_admin = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_admin.Password && _.Username == token_admin.Name);
            token_admin.User = new AdministratorDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            await Task.Run(() => facade.UpdateAdmin(token_admin, admin));
            return StatusCode(200, admin);
        }

        [HttpPost("updateairlinedetails")]
        public async Task<ActionResult<Customer>> UpdateAirlineDetails([FromBody] AirlineCompany airline)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            token_admin = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_admin.Password && _.Username == token_admin.Name);
            token_admin.User = new AdministratorDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            await Task.Run(() => facade.UpdateAirlineDetails(token_admin, airline));
            return StatusCode(200, airline);
        }

        [HttpPost("updatecustomerdetails")]
        public async Task<ActionResult<Customer>> UpdateCustomerDetails([FromBody] Customer customer)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            token_admin = GetLoginToken();
            User u = new UserDAOPGSQL().GetAll().FirstOrDefault(_ => _.Password == token_admin.Password && _.Username == token_admin.Name);
            token_admin.User = new AdministratorDAOPGSQL().GetAll().FirstOrDefault(_ => _.User_id == u.Id);
            await Task.Run(() => facade.UpdateCustomerDetails(token_admin, customer));
            return StatusCode(200, customer);
        }

        [HttpGet("getflight/{flight_id}")]
        public async Task<ActionResult<Flight>> GetFlightById(int flight_id)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
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
            facade = f as LoggedInAdministratorFacade;
            var result = await Task.Run(() => facade.GetAllAirlineCompanies());
            return StatusCode(200, result);
        }

        [HttpGet("getallflights")]
        public async Task<ActionResult<List<Flight>>> GetAllFlights()
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            var result = await Task.Run(() => facade.GetAllFlights());
            return StatusCode(200, result);
        }

        [HttpPost("getflightsbydepatruredate")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByDepatrureDate([FromBody] DateTime date)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            var result = await Task.Run(() => facade.GetFlightsByDepatrureDate(date));
            return StatusCode(200, result);
        }

        [HttpPost("getflightsbylandingdate")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByLandingDate([FromBody] DateTime date)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            var result = await Task.Run(() => facade.GetFlightsByLandingDate(date));
            return StatusCode(200, result);
        }

        [HttpGet("getflightsbydestinationcountry/{country_id}")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByDestinationCountry(int country_id)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            var result = await Task.Run(() => facade.GetFlightsByDestinationCountry(country_id));
            return StatusCode(200, result);
        }

        [HttpGet("getflightsbyorigincountry/{country_id}")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByOriginCountry(int country_id)
        {
            FlightsCenterSystem.GetInstance().login(GetLoginToken().Name, GetLoginToken().Password,
                out LoginToken<Object> l, out FacadeBase f);
            facade = f as LoggedInAdministratorFacade;
            var result = await Task.Run(() => facade.GetFlightsByOriginCountry(country_id));
            return StatusCode(200, result);
        }
    }
}
