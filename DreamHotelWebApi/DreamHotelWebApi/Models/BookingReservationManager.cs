using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHotelWebApi.Models
{
    public class BookingReservationManager
    {
        List<BookingReservation> _reservation = new List<BookingReservation>();
        public BookingReservationManager() {
        }

        IEnumerable<BookingReservation> ReadreservationList() {
            return JsonConvert.DeserializeObject<List<BookingReservation>>(File.ReadAllText("reservation.txt"));
        }

        public void CreateReservation(BookingReservation _br) {
            if (File.Exists("reservation.txt")) {
                _reservation = ReadreservationList().ToList();
            }
            _reservation.Add(_br);
            var output = JsonConvert.SerializeObject(_reservation);
            File.WriteAllText("reservation.txt", output);
        }

    }
}