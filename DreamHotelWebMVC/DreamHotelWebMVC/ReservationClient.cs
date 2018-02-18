using DreamHotelWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DreamHotelWebMVC
{
    public class ReservationClient
    {
        string _hostUri;

        public ReservationClient(string hostUri) {
            _hostUri = hostUri;
        }

        HttpClient client;
        public HttpClient CreateSingletonClient() {

            if (client == null) {
                client = new HttpClient();
            }
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/reservation/");
            return client;
        }

        public HttpClient CreateSingletonActionClient(string action) {

            if (client == null) {
                client = new HttpClient();
            }
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/reservation/" + action);
            return client;
        }

        public HttpClient CreateClient() {

            client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/reservation/");
            return client;
        }

        public HttpClient CreateActionClient(string action) {

            client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/reservation/" + action);
            return client;
        }

        public async Task<IEnumerable<Rooms>> GetRoomsAsync() {

            using (var client = CreateActionClient("rooms")) {

                HttpResponseMessage response;
                response = client.GetAsync(client.BaseAddress).Result;

                //var result = response.Content.ReadAsAsync<IEnumerable<Rooms>>().Result;
                if (response.IsSuccessStatusCode) {

                    var avail = await response.Content.ReadAsStringAsync()
                        .ContinueWith<IEnumerable<Rooms>>(postTask =>
                        {
                            return JsonConvert.DeserializeObject<IEnumerable<Rooms>>(postTask.Result);
                        });
                    return avail;
                } else {
                    return null;
                }
            }
            //return result;
        }
    }
}