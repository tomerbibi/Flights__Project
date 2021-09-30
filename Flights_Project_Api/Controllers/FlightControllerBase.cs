using Flights__Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flights_Project_Api.Controllers
{
    public abstract class FlightControllerBase<T> : ControllerBase where T : IUser, new()
    {
        protected LoginToken<T> GetLoginToken()
        {
            string userName = User.Claims.First(_ => _.Type == "username").Value;
            string password = User.Claims.First(_ => _.Type == "password").Value;
            LoginToken<T> login_token = new LoginToken<T>()
            {
                Name = userName,
                Password = password,
                User = new T()
            };
            return login_token;
        }
    }
}
