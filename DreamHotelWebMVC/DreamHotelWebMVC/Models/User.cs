using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHotelWebMVC.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<BookingReservation> Booking;

        public User()
        {
            Booking = new List<BookingReservation>();
        }
    }
}
