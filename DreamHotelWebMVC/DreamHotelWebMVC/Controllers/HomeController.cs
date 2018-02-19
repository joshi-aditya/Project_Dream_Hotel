using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamHotelWebMVC.Models;
using DreamHotelWebMVC.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DreamHotelWebMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index() {

            BookingReservation bookingReservation = new BookingReservation();
            bookingReservation.CheckIn = DateTime.Now;
            bookingReservation.CheckOut = DateTime.Now;

            // Create a company client instance:
            var baseUri = new Uri("http://localhost:60361");
            var reservationClient = new ReservationClient("http://localhost:60361");

            // Read initial rooms list:

            //ViewData["rooms"] = rooms;
            var rooms = reservationClient.GetRoomsAsync().Result;
            List<SelectListItem> newrooms = new List<SelectListItem>();
            foreach (Rooms room in rooms)
            {
                newrooms.Add(new SelectListItem { Value = room.Rent.ToString(), Text = room.Type });
            }
            bookingReservation.newList = newrooms;
            bookingReservation.Room = rooms.First(_ => true);
            return View(bookingReservation);
        }

        [HttpPost]
        public IActionResult Booking(BookingReservation bookingReservation)
        {
            return View();
        }


        [HttpPost]
        public IActionResult GuestDetails()
        {
            return View();
        }
    }
}