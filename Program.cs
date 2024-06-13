using Front_Final_Workshop.HttpRequest;
using Front_Final_Workshop.Model;
using Front_Final_Workshop.PathManager;

namespace Front_Final_Workshop
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            //Register register2 = new Register();
            //bool result3 = await register2.CreateNewUser("salut", "lusal");
            //bool result5 = await register2.CreateNewUser("macbeth574@gmail.com", "mdp123");

            //Logger logger2 = new Logger();
            //bool result1 = await logger2.ConnectAsync("salut", "lusal");
            //bool result2 = await logger2.ConnectAsync("mail", "passwordz");

            //Console.WriteLine(result3);
            //Console.WriteLine(result5);
            //Console.WriteLine(result1);
            //Console.WriteLine(result2);

            Register register = new Register();
            Logger logger = new Logger();
            PathManager.PathManager pathManager = new PathManager.PathManager(); //Bug namespace ici

            await register.RegisterManager();
            await logger.LogginAsync();
            pathManager.Start();

            //Animal animal = await AnimalHttpRequests.GetByName("Alex");
            //Console.WriteLine(animal.Name);
            //Console.WriteLine(animal.Description);
            //Console.WriteLine(animal.Id);

            //List<Animal> testList = await AnimalHttpRequests.GetAll();

            //await AnimalHttpRequests.Delete(10);
            //await AnimalHttpRequests.Update(3, "Wolf", "Woohooo", 2);
            //await AnimalHttpRequests.Add("Pito", "reine des enfers", "Chat");

            

            //Console.WriteLine(result3);
            //Console.WriteLine(result5);

        }
    }
}
