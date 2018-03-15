using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHotelWebApi.Models
{
    public class DatabaseManager
    {
        MongoClient client;
        IMongoDatabase db;

        public DatabaseManager() {
            try {
                client = new MongoClient("mongodb://localhost:27017");
                if (client == null) {
                    Console.WriteLine("Error while connecting to database");
                }
                db = client.GetDatabase("HotelDb");
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        public IEnumerable<Rooms> GetAll() {
            var collection = db.GetCollection<Rooms>("Rooms");
            return collection.Find(_ => true).ToList();

        }

        public void CreateReservation(BookingReservation _br) {
            var collection = db.GetCollection<BookingReservation>("BookingReservation");
            collection.InsertOneAsync(_br);
        }
    }
}
