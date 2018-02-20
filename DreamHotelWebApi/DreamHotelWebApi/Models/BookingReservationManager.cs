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
        List<BookingReservation> _reservation;
        public BookingReservationManager() {
            try {
                if (File.Exists("reservation.txt")) {
                    _reservation = ReadreservationList().ToList();
                }
            }
            catch (IOException ioe) {

            }
        }

        IEnumerable<BookingReservation> ReadreservationList() {
            return JsonConvert.DeserializeObject<List<BookingReservation>>(File.ReadAllText("reservation.txt"));
        }

        public void CreateReservation(BookingReservation _br) {
            _reservation.Add(_br);
            var output = JsonConvert.SerializeObject(_reservation);
            File.WriteAllText("reservation.txt", output);
        }

    }
}
