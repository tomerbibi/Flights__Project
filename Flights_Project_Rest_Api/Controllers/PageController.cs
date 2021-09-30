using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flights_Project_Rest_Api.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult SendFormHere()
        {
            var x = Request.Form;
            Debug.WriteLine(x);
            return Content("hello");
        }
    }
}
