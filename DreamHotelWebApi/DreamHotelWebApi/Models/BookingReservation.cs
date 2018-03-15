using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHotelWebApi.Models
{
    public class BookingReservation
    {   
        [BsonId]
        public ObjectId Id { get; set; }

        public List<Person> Persons;

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        [Required]
        public int NumberOfPersons { get; set; }

        [Required]
        public Rooms Room { get; set; }

        public BookingReservation() {
            Persons = new List<Person>();
        }
    }
}
