using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DreamHotelWebApi.Models
{
    public class Rooms
    {   
        [BsonId]
        public ObjectId _id { get; set; }
        public string Type { get; set; }
        public int Rent { get; set; }
    }
}
