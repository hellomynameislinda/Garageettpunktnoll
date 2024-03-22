using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class ParkingManager
    {
        public Garage<Vehicle> CurrentGarage { get; private set; }
        
        private readonly ConsoleUI ui;

        private List<Garage<Vehicle>> garages = new List<Garage<Vehicle>>(); // TODO: Should this really be a list if we want to save current location?

        private Menu menu = new Menu();

        public ParkingManager()
        {
            ui = new ConsoleUI(/**/);

            // TODO: Using ONE hard coded instance of garage for now.
            // Later, add the ability to add more garages if there is enough time!
            garages.Add(new Garage<Vehicle>("Garag1", 12));
            CurrentGarage = garages.FirstOrDefault()!; // TODO: Check if null? Cannot be null until multiple garages are handled
        }

        internal void Run()
        {
            do
            {
                ui.WriteLine("Väkommen till ParkingManager\n");

                ui.WriteLine($"Du är i garaget {CurrentGarage.GarageName}\n");

                // Menu
                menu.DisplayMenu();
                menu.HandleChoice();

                Console.ReadLine(); // TODO: Temporary code during dev. Remove this once there is a natural stop.
            } while (true);
        }
    }
}
