using Front_Final_Workshop.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Front_Final_Workshop.HttpRequest
{
    public class RaceHttpRequests
    {
        public static async Task Add(string name)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CreateRaceRequestDTO request = new CreateRaceRequestDTO
            {
                Name = name,
            };

            try
            {
                await client.PostAsJsonAsync("http://localhost:58226/create/race", request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        public static async Task Update(int id, string name)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            UpdateRaceByIdRequestDTO request = new UpdateRaceByIdRequestDTO
            {
                Id = id,
                Name = name
            };

            try
            {
                await client.PostAsJsonAsync("http://localhost:58226/update/race", request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
