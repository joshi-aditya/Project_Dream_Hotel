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
        BookingReservation _bookingReservation;
        private IEnumerable<Rooms> rooms;

        public IActionResult Index()
        {

            _bookingReservation = new BookingReservation();
            _bookingReservation.CheckIn = DateTime.Now;
            _bookingReservation.CheckOut = DateTime.Now;

            // Create a company client instance:
            var baseUri = new Uri("http://localhost:60361");
            var reservationClient = new ReservationClient("http://localhost:60361");

            // Read initial rooms list:

            //ViewData["rooms"] = rooms;
            rooms = reservationClient.GetRoomsAsync().Result;
            List<SelectListItem> newrooms = new List<SelectListItem>();
            foreach (Rooms room in rooms)
            {
                newrooms.Add(new SelectListItem { Value = room.Rent.ToString(), Text = room.Type });
            }
            _bookingReservation.newList = newrooms;
            _bookingReservation.R = rooms.First(_ => true);
            _bookingReservation.Room = _bookingReservation.R.Type;
            return View(_bookingReservation);
        }

        [HttpPost]
        public IActionResult Booking(BookingReservation bookingReservation)
        {
            return RedirectToAction("GuestDetails", "Home", bookingReservation);
        }

        public IActionResult GuestDetails(BookingReservation bookingDetails)
        {
            var numberOfPersons = bookingDetails.NumberOfPersons;
            IEnumerable<Person> model = new List<Person>();
            for (var i = 0; i < numberOfPersons; i++)
                model.Append(new Person());
            return View(model);
        }
    }
}