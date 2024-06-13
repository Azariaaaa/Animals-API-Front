using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Front_Final_Workshop.Model;
using Front_Final_Workshop.DTO.Requests;
using Front_Final_Workshop.DTO.Responses;
using System.Security.Cryptography.X509Certificates;

namespace Front_Final_Workshop
{
    public class Logger
    {
        public async Task LogginAsync()
        {
            bool isConnected = false;
            
            while (!isConnected)
            {
                Console.Clear();
                Console.WriteLine("[CONNEXION] : ");

                string userMail = AskForMail();
                string userPassword = AskForPassword();
                isConnected = await ConnectAsync(userMail, userPassword);

                if (!isConnected)
                {
                    Console.WriteLine("Connexion échouée. Veuillez réessayer.");
                }
            }

            Console.WriteLine("Connexion réussie !");
            Thread.Sleep(2000);
        }

        public string AskForMail()
        {
            string userMail;

            Console.Clear();
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

        public async Task<bool> ConnectAsync(string mail, string password)
        {
            HttpClient client = new HttpClient();
            UserConnectRequestDTO request = new UserConnectRequestDTO
            {
                Mail = mail,
                Password = password
            };

            var response = await client.PostAsJsonAsync("http://localhost:58226/connect", request);

            if (response.IsSuccessStatusCode)
            {
                UserConnectResponseDTO? connectUserResponse = await response.Content.ReadFromJsonAsync<UserConnectResponseDTO>();
                return connectUserResponse.isConnected;
            }

            return false;
        }
    }
}

