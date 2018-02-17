using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHotelWebMVC.Models
{
    public class BookingReservation
    {

        public long Id { get; set; }
        public List<Person> Persons;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfPeople { get; set; }
        public int RoomType { get; set; }
        public RoomType Room { get; set; }

        public BookingReservation()
        {
            Persons = new List<Person>();
        }

    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class RoomType
    {
        public string TypeOfRoom { get; set; }
    }
}
