using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public Rooms R { get; set; }

        public string Room { get; set; }

        public BookingReservation()
        {
            Persons = new List<Person>();
        }

    }

}
