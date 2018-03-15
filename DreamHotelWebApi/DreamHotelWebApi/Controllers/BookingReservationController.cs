using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamHotelWebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DreamHotelWebApi.Controllers
{
    public class BookingReservationController : Controller
    {
        DatabaseManager dm = new DatabaseManager();

        private IHostingEnvironment _Env;

        public BookingReservationController(IHostingEnvironment envrnmt) {
            _Env = envrnmt;
        }

        // create new reservation
        // POST api/Reservation
        [HttpPost]
        [Route("api/reservation/[controller]")]
        public async Task<StatusCodeResult> BookingReservation(BookingReservation br) {
            if (br == null) {
                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }

            dm.CreateReservation(br);
            return new StatusCodeResult(201);
        }
    }
}