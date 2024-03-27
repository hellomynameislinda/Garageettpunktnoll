using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Garageettpunktnoll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Jag har försökt få med ett exempel på varje koncept vi gått igenom: generiska klasser, delegater, linq.
            // Jag har skapat ett interface, men lyckas inte använda det (trots att jag tycker att jag gjort som på
            // föreläsningarna. Så här finns lite att läsa på igen.
            // Jag skapade ett par test, och insåg att min check för att se om registreringsnummer är ledigt i garaget
            // inte funkar som den ska. Så testet gjorde sitt jobb, men jag hinner inte lösa felet innan 11.00...






            // TODO: Read/Write to file
            //Cusing Microsoft.Extensions.Configuration; // Kommer från ett externt library, se dependencis

            //IConfiguration config = new ConfigurationBuilder()
            //                             .SetBasePath(Environment.CurrentDirectory)
            //                             .AddJsonFile("appsettings.json", false, reloadOnChange: true)
            //                             .Build();

            //var test = config.GetSection("game:ui").Value; // Hämta värdet från game ui i json-filen

            var host = Host.CreateDefaultBuilder(args) // Host egentligen skrivet för webbapplikationer
               .ConfigureServices(services => // Delegat m. Lambda
               {
                   services.AddSingleton<ConsoleUI>(); // TODO: Change to Interface when it's ready
                   services.AddSingleton<GarageHandler>(); // TODO: Change to Interface when it's ready
                   services.AddSingleton<Menu>(); // TODO: Change to Interface when it's ready
                   services.AddSingleton<ParkingManager>();
               })
               .UseConsoleLifetime()
               .Build();

            host.Services.GetRequiredService<ParkingManager>().Run();
            //ParkingManager parkingManager = new ParkingManager();
            //parkingManager.Run();

            Console.WriteLine("Tack för idag!");
            Console.ReadLine();
        }
    }
}
