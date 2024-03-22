using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Garageettpunktnoll
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                   //       services.AddSingleton<IUI, ConsoleUI>(); // Vi kommer bara använda en version av objektet
                   //       services.AddSingleton<IConfiguration>(config); // Den ska förstå config själv
                   //       services.AddSingleton<IMap, Map>(); // Om man ber om en IMap så får man en map
                   //       services.AddSingleton<IMapService, MapService>();
                   //       services.AddSingleton<Game>();
                   //       services.AddSingleton<ILimitedList<string>>(new MessageLog<string>(6));
                   //       //                   services.AddSingleton<ILimitedList<Item>>(new MessageLog<Item>(3)); 
                   //       services.AddSingleton<IMapSettings>(config.GetSection("game:mapsettings").Get<MapSettings>()!);
               })
               .UseConsoleLifetime()
               .Build();


            ParkingManager parkingManager = new ParkingManager(/*new ConsoleUI(), new Map(width: 10, height: 10)*/);
            parkingManager.Run();

            Console.WriteLine("Tack för idag!");
            Console.ReadLine();
        }
    }
}
