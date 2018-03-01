using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHotelWebApi.Models
{
    public class BookingReservation
    {
        public long Id { get; set; }
        public List<SelectListItem> newList = new List<SelectListItem>();
        public List<Person> Persons;

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        [Required]
        public int NumberOfPersons { get; set; }

        [Required]
        public Rooms R { get; set; }

        public string Room { get; set; }

        public BookingReservation() {
            Persons = new List<Person>();
        }
    }
}
