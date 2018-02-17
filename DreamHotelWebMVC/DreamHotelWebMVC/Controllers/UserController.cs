using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DreamHotelWebMVC.Controllers
{
    [Route("/user")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}