using Front_Final_Workshop.DTO.Requests;
using Front_Final_Workshop.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Front_Final_Workshop
{
    public class Register
    {
        public async Task RegisterManager()
        {
            bool hasBeenRegistered = false;

            while(!hasBeenRegistered)
            {
                string userMail = AskForMail();
                string userPassword = AskForPassword();
                hasBeenRegistered = await CreateNewUser(userMail, userPassword);
            }
            
        }
        public string AskForMail()
        {
            string userMail;

            Console.WriteLine("Entrez votre mail : ");
            userMail = Console.ReadLine();

            return userMail;
        }
        public string AskForPassword() 
        {
            string userPassword;

            Console.Clear();
            Console.WriteLine("Entrez votre mot de passe : ");
            userPassword = Console.ReadLine();

            return userPassword;
        }

        public async Task<bool> CreateNewUser(string mail, string password)
        {
            bool hasBeenRegistered = false;

            HttpClient client = new HttpClient();
            CreateUserRequestDTO request = new CreateUserRequestDTO
            {
                Mail = mail,
                Password = password
            };

            try
            {
                var response = await client.PostAsJsonAsync("http://localhost:58226/create/user", request);

                if (response.IsSuccessStatusCode)
                {
                    CreateUserReponseDTO? createUserResponse = await response.Content.ReadFromJsonAsync<CreateUserReponseDTO>();

                    if (createUserResponse.IsRegistered)
                    {
                        hasBeenRegistered = true;
                    }
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error: " + errorContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return hasBeenRegistered;
        }
    }
}
