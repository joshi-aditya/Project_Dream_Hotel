using System.Threading.Tasks;
using DreamHotelWebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DreamHotelWebApi.Controllers
{
    public class BookingReservationController : Controller
    {
        DatabaseManager dm = new DatabaseManager();

        private IHostingEnvironment _Env;

        public BookingReservationController(IHostingEnvironment envrnmt) {
            _Env = envrnmt;
        }

        // create new reservation
        // POST api/Reservation
        [HttpPost]
        [Route("api/reservation/[controller]")]
        public async Task<StatusCodeResult> BookingReservation([FromBody] GetJSON json) {
            if (json == null) {
                return new BadRequestResult();
            }
            BookingReservation br = JsonConvert.DeserializeObject<BookingReservation>(json.Body);

           // dm.CreateReservation(br);
            return new StatusCodeResult(201);
        }
    }

    public class GetJSON
    {
        public string Body { get; set; }
    }
}