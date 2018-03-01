using System.Collections.Generic;
using DreamHotelWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DreamHotelWebApi.Controllers
{
    public class RoomsController : Controller
    {
        readonly RoomManager rm = new RoomManager();

        // GET api/reservation/rooms
        [HttpGet]
        [Route("api/reservation/[controller]")]
        public IEnumerable<Rooms> Get() {
            return rm.GetAll;
        }
    }
}