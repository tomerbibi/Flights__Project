using Flights__Project;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flights_Project_Api.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult CreateCustomer()
        {
            var x = Request.Form;
            new UserDAOPGSQL().Add(new User(x["usernametxt"], x["passwordtxt"], x["emailtxt"], 3));
            new CustomerDAOPGSQL().Add(new Customer(x["firstnametxt"], x["lastnametxt"], x["adresstxt"], 
                x["phonenotxt"], x["creditcardtxt"],
            new UserDAOPGSQL().GetAll().First(u => u.Username == x["usernametxt"] && u.Password == x["passwordtxt"]).Id));
            return Content("hello");
        }
        public ActionResult CreateAirline()
        {
            var x = Request.Form;
            new AirlineAuthDAOPGSQL().Add(new AirlineAuth(x["nametxt"], Convert.ToInt32(x["countrytxt"]),
                x["usernametxt"], x["passwordtxt"], x["emailtxt"]));
            return Content("hello");
        }
        public ActionResult CreateAdmin()
        {
            var x = Request.Form;
            new UserDAOPGSQL().Add(new User(x["usernametxt"], x["passwordtxt"], x["emailtxt"], 3));
            new AdministratorDAOPGSQL().Add(new Administrator(x["firstnametxt"], x["lastnametxt"],Convert.ToInt32(x["levelstxt"]),
            new UserDAOPGSQL().GetAll().First(u => u.Username == x["usernametxt"] && u.Password == x["passwordtxt"]).Id));
            return Content("hello");
        }
        public ActionResult SignIn()
        {
            var x = Request.Form;
            Debug.WriteLine(x);
            return Content("hello");
        }
    }
}
