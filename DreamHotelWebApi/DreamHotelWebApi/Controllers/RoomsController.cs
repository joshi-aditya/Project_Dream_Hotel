using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamHotelWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DreamHotelWebApi.Controllers
{
    public class RoomsController : Controller
    {
        RoomManager rm = new RoomManager();

        public IActionResult Index()
        {
            return View();
        }

        // GET api/reservation/rooms
        [HttpGet]
        [Route("api/reservation/[controller]")]
        public IEnumerable<Rooms> Get() {
            return rm.GetAll;
        }
    }
}