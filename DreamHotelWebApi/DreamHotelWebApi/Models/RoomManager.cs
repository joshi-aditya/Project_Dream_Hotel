using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHotelWebApi.Models
{
    public class RoomManager
    {
        readonly List<Rooms> _rooms = new List<Rooms>() {

            new Rooms { Type = "Villa", Rent = 1000 },
            new Rooms { Type = "Penthouse", Rent = 900 },
            new Rooms { Type = "Suite", Rent = 700 },
            new Rooms { Type = "Standard Room", Rent = 500}
        };

        public IEnumerable<Rooms> GetAll { get { return _rooms; } }

    }
}
