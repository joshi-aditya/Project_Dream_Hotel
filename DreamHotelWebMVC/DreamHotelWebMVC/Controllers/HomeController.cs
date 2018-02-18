using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DreamHotelWebMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() {

            // Create a company client instance:
            var baseUri = new Uri("http://localhost:60361");
            var reservationClient = new ReservationClient("http://localhost:60361");

            // Read initial student list:
            var rooms = reservationClient.GetRoomsAsync().Result;
            ViewData["rooms"] = rooms;
            
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }
    }
}