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
            Random rand = new Random((int)DateTime.Now.Ticks);
            int _ID = rand.Next(1, 10000);
            _br.Id = _ID;
            _reservation.Add(_br);
            var output = JsonConvert.SerializeObject(_reservation);
            File.WriteAllText("reservation.txt", output);
        }

    }
}