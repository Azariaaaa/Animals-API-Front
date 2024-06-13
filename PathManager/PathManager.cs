using Front_Final_Workshop.HttpRequest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Front_Final_Workshop.PathManager
{
    public class PathManager
    {
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                string userChoice = DisplayMainMenu();
                RouteToMenu(userChoice);
            }
        }

        private string DisplayMainMenu()
        {
            string userChoice = "";
            List<string> possibleChoices = new List<string> { "1", "2" };

            while (!possibleChoices.Contains(userChoice))
            {
                Console.Clear();
                Console.WriteLine("[1] - Animaux");
                Console.WriteLine("[2] - Races");
                userChoice = Console.ReadLine();
            }

            return userChoice;
        }

        private void RouteToMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    DisplayAnimalsMenu();
                    break;
                case "2":
                    DisplayRacesMenu();
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }

        private void DisplayAnimalsMenu()
        {
            string userChoice = "";
            List<string> possibleChoices = new List<string> { "1", "2", "3", "4", "5" };

            while (!possibleChoices.Contains(userChoice))
            {
                Console.Clear();
                Console.WriteLine("[1] - Ajouter un animal");
                Console.WriteLine("[2] - Modifier un animal");
                Console.WriteLine("[3] - Supprimer un animal");
                Console.WriteLine("[4] - Lister les animaux");
                Console.WriteLine("[5] - Rechercher un animal par nom");
                userChoice = Console.ReadLine();
            }

            RouteAnimalMenu(userChoice);
        }

        private void DisplayRacesMenu()
        {
            string userChoice = "";
            List<string> possibleChoices = new List<string> { "1", "2", "3", "4" };

            while (!possibleChoices.Contains(userChoice))
            {
                Console.Clear();
                Console.WriteLine("[1] - Ajouter une race");
                Console.WriteLine("[2] - Modifier une race");
                Console.WriteLine("[3] - Supprimer une race");
                Console.WriteLine("[4] - Lister les races");
                userChoice = Console.ReadLine();
            }

            RouteRaceMenu(userChoice);
        }

        private void RouteAnimalMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    AddAnimalAsync().Wait();
                    break;
                case "2":
                    UpdateAnimalAsync().Wait();
                    break;
                case "3":
                    DeleteAnimalAsync().Wait();
                    break;
                case "4":
                    ListAllAnimalsAsync().Wait();
                    break;
                case "5":
                    SearchAnimalByNameAsync().Wait();
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }

        private void RouteRaceMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    AddRaceAsync().Wait();
                    break;
                case "2":
                    UpdateRaceAsync().Wait();
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }

        private async Task AddAnimalAsync()
        {
            Console.Clear();
            Console.WriteLine("Entrez le nom de l'animal : ");
            string name = Console.ReadLine();

            Console.WriteLine("Entrez la description de l'animal : ");
            string description = Console.ReadLine();

            Console.WriteLine("Entrez la race de l'animal : ");
            string raceName = Console.ReadLine();

            await AnimalHttpRequests.Add(name, description, raceName);
        }

        private async Task UpdateAnimalAsync()
        {
            Console.Clear();
            Console.WriteLine("Entrez l'id de l'animal à modifier : ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Entrez le nouveau nom de l'animal : ");
            string name = Console.ReadLine();

            Console.WriteLine("Entrez la nouvelle description de l'animal : ");
            string description = Console.ReadLine();

            Console.WriteLine("Entrez le nouvel id de la race de l'animal : ");
            int raceId = int.Parse(Console.ReadLine());

            await AnimalHttpRequests.Update(id, name, description, raceId);
        }

        private async Task DeleteAnimalAsync()
        {
            Console.Clear();
            Console.WriteLine("Entrez l'id de l'animal à supprimer : ");
            int id = int.Parse(Console.ReadLine());

            await AnimalHttpRequests.Delete(id);
        }

        private async Task ListAllAnimalsAsync()
        {
            Console.Clear();
            var animals = await AnimalHttpRequests.GetAll();

            foreach (var animal in animals)
            {
                Console.WriteLine("################");
                Console.WriteLine($"# [ID] : {animal.Id}");
                Console.WriteLine($"# [NAME] : {animal.Name}");
                Console.WriteLine($"# [DESCRIPTION] : {animal.Description}");
                Console.WriteLine($"# [RACE ID] : {animal.RaceId}");
                Console.WriteLine("################");
            }
            Console.ReadLine();
        }

        private async Task SearchAnimalByNameAsync()
        {
            Console.Clear();
            Console.WriteLine("Entrez le nom de l'animal à afficher : ");
            string name = Console.ReadLine();

            var animal = await AnimalHttpRequests.GetByName(name);

            if (animal != null)
            {
                Console.Clear();
                Console.WriteLine($"ID: {animal.Id}");
                Console.WriteLine($"Nom: {animal.Name}");
                Console.WriteLine($"Description: {animal.Description}");
                Console.WriteLine($"Race ID: {animal.RaceId}");
            }
            else
            {
                Console.WriteLine("Animal non trouvé.");
            }
            Console.ReadLine();
        }

        private async Task AddRaceAsync()
        {
            Console.Clear();
            Console.WriteLine("Entrez le nom de la race : ");
            string name = Console.ReadLine();

            await RaceHttpRequests.Add(name);
        }

        private async Task UpdateRaceAsync()
        {
            Console.Clear();
            Console.WriteLine("Entrez l'id de la race à modifier : ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Entrez le nouveau nom de la race : ");
            string name = Console.ReadLine();

            await RaceHttpRequests.Update(id, name);
        }
    }
}