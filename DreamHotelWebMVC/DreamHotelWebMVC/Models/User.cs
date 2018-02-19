using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHotelWebMVC.Models
{
    public class User
    {
        [Required]
        [Display(Name = "First Name"), DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name"), DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Name"), DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required, Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        public List<BookingReservation> Booking;

        public User()
        {
            Booking = new List<BookingReservation>();
        }
    }
}
