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
        static volatile BookingReservation _bookingReservation = new BookingReservation();
        private IEnumerable<Rooms> rooms;

        // Create a company client instance:
        Uri baseUri = new Uri("http://localhost:60361");
        ReservationClient reservationClient = new ReservationClient("http://localhost:60361");

        public IActionResult Index()
        {

            _bookingReservation.CheckIn = DateTime.Now;
            _bookingReservation.CheckOut = DateTime.Now;

            // Read initial rooms list:

            //ViewData["rooms"] = rooms;
            rooms = reservationClient.GetRoomsAsync().Result;
            List<SelectListItem> newrooms = new List<SelectListItem>();
            foreach (Rooms room in rooms)
            {
                newrooms.Add(new SelectListItem { Value = room.Type, Text = room.Type });
            }
            ViewBag.newList = newrooms;
            _bookingReservation.R = rooms.First(_ => true);
            _bookingReservation.Room = _bookingReservation.R.Type;
            return View(_bookingReservation);
        }

        [HttpPost]
        public IActionResult Booking(BookingReservation bookingReservation)
        {
            rooms = reservationClient.GetRoomsAsync().Result;
            bookingReservation.R = rooms.FirstOrDefault(_ => _.Type.Equals(bookingReservation.Room));
            bookingReservation.Room = bookingReservation.R.Type;
            _bookingReservation.R = bookingReservation.R;
            _bookingReservation.Room = _bookingReservation.R.Type;
            _bookingReservation.CheckIn = bookingReservation.CheckIn;
            _bookingReservation.CheckOut = bookingReservation.CheckOut;
            _bookingReservation.NumberOfPersons = bookingReservation.NumberOfPersons;

            return RedirectToAction("GuestDetails", "Home", bookingReservation);
        }

        public IActionResult GuestDetails(BookingReservation bookingDetails)
        {
            var numberOfPersons = bookingDetails.NumberOfPersons;
            List<Person> model = new List<Person>();
            for (var i = 0; i < numberOfPersons; i++)
                model.Add(new Person());
            _bookingReservation.Persons = model;
            ViewBag.Price = _bookingReservation.R.Rent;
            return View(model);
        }

        [HttpPost]
        public IActionResult GuestDetails(IEnumerable<Person> per)
        {
            _bookingReservation.Persons.Concat(per.ToList());
            var res = reservationClient.CreateReservation(_bookingReservation);
            return RedirectToAction("Index");
        }
    }
}