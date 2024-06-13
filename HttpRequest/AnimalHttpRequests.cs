using Front_Final_Workshop.DTO.Requests;
using Front_Final_Workshop.DTO.Responses;
using Front_Final_Workshop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Front_Final_Workshop.HttpRequest
{
    public class AnimalHttpRequests
    {

        public static async Task Add(string name, string description, string raceName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CreateAnimalRequestDTO request = new CreateAnimalRequestDTO
            {
                Name = name,
                Description = description,
                RaceName = raceName
            };

            try
            {
                await client.PostAsJsonAsync("http://localhost:58226/create/animal", request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
        public static async Task Update(int id, string name, string description, int raceId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            UpdateAnimalRequestDTO request = new UpdateAnimalRequestDTO
            {
                Id = id,
                Name = name,
                Description = description,
                RaceId = raceId
            };

            try
            {
                await client.PostAsJsonAsync("http://localhost:58226/update/animal", request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        public static async Task Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            DeleteAnimalByIdRequestDTO request = new DeleteAnimalByIdRequestDTO
            {
                Id = id
            };

            try
            {
                await client.PostAsJsonAsync("http://localhost:58226/delete/animal", request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        public static async Task<List<Animal>> GetAll()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:58226/get/animals");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var animals = JsonSerializer.Deserialize<List<Animal>>(responseBody, options);

                //// Debug
                //foreach (var animal in animals)
                //{
                //    Console.WriteLine(animal.Name);
                //}

                return animals ?? new List<Animal>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return new List<Animal>();
            }
        }

        public static async Task<Animal?> GetByName(string name)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            GetAnimalByNameRequestDTO request = new GetAnimalByNameRequestDTO
            {
                Name = name
            };

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:58226/get/animals/name", request);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var getAnimalByNameResponseDTO = JsonSerializer.Deserialize<GetAnimalByNameResponseDTO>(responseBody, options);

                return getAnimalByNameResponseDTO?.Animal;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }

    }
}
