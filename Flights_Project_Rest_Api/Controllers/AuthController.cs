using Flights__Project;
using Flights_Project_Rest_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Flights_Project_Rest_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public ActionResult GetToken([FromBody] UserDetails userDetails)
        {
            Customer customer = new Customer();
            AirlineCompany airline = new AirlineCompany();
            Administrator administrator = new Administrator();
            LoginToken<Customer> customerToken = new LoginToken<Customer>();
            LoginToken<AirlineCompany> airlineToken = new LoginToken<AirlineCompany>();
            LoginToken<Administrator> adminToken = new LoginToken<Administrator>();


            try
            {
                FlightsCenterSystem.GetInstance().login(userDetails.Name, userDetails.Password,
                out LoginToken<Object> l, out FacadeBase f);

                if (l.User.GetType() == typeof(Administrator))
                {
                    administrator = l.User as Administrator;
                }

                if (l.User.GetType() == typeof(AirlineCompany))
                {
                    airline = l.User as AirlineCompany;
                }

                if (l.User.GetType() == typeof(Customer))
                {
                    customer = l.User as Customer;
                }
            }
            catch (WrongCredentialsException ex)
            {
                return StatusCode(400, ex);
            }

            string securityKey =
       "this_is_our_supper_long_security_key_for_token_validation_project_2018_09_07$smesk.in";

            var symmetricSecurityKey = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            var signingCredentials = new
                  SigningCredentials(symmetricSecurityKey,
                  SecurityAlgorithms.HmacSha256Signature);


            var claims = new List<Claim>();
            if (administrator.Id != 0)
            {
                claims.Add(new Claim("id", $"{administrator.Id}"));
                claims.Add(new Claim(ClaimTypes.Role, "administrator"));
                claims.Add(new Claim("username", userDetails.Name));
                claims.Add(new Claim("password", userDetails.Password));
            }
            if (airline.Id != 0)
            {
                claims.Add(new Claim("id", $"{airline.Id}"));
                claims.Add(new Claim(ClaimTypes.Role, "airlinecompany"));
                claims.Add(new Claim("username", userDetails.Name));
                claims.Add(new Claim("password", userDetails.Password));
            }
            if (customer.Id != 0)
            {
                claims.Add(new Claim("id", $"{customer.Id}"));
                claims.Add(new Claim(ClaimTypes.Role, "customer"));
                claims.Add(new Claim("username", userDetails.Name));
                claims.Add(new Claim("password", userDetails.Password));
            }

            var token = new JwtSecurityToken(
            issuer: "smesk.in",
            audience: "readers",
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signingCredentials,
            claims: claims);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
