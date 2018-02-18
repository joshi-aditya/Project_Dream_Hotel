using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHotelWebMVC.Models
{
    public class BookingReservation
    {

        public long Id { get; set; }
        public List<Person> Persons;

        [Required]
        [Display(Name = "Check-in Date")]
        public DateTime CheckIn { get; set; }

        [Required]
        [Display(Name = "Check-out Date")]
        public DateTime CheckOut { get; set; }

        [Required]
        [Display(Name = "Number of People")]
        public int NumberOfPersons { get; set; }

        [Required]
        [Display(Name = "Type of Room")]
        public RoomType Room { get; set; }

        public BookingReservation()
        {
            Persons = new List<Person>();
        }

    }

    public class Person
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public int Age { get; set; }
    }

    public class RoomType
    {
        public string TypeOfRoom { get; set; }
    }
}
