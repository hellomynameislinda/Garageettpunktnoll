using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class GarageHandler
    {
        private List<Garage<Vehicle>> garages = new List<Garage<Vehicle>>(); // TODO: Should this really be a list if we want to save current location?
        public Garage<Vehicle> CurrentGarage { get; private set; }

        private readonly ConsoleUI ui;

        public GarageHandler(ConsoleUI ui)
        {
            this.ui = ui;
            // TODO: Using ONE hard coded instance of garage for now.
            // Later, add the ability to add more garages if there is enough time!
            garages.Add(new Garage<Vehicle>("Garag1", 12));
            CurrentGarage = garages.FirstOrDefault()!; // TODO: Check if null? Cannot be null until multiple garages are handled
        }
        internal void ChangeGarageCapacity()
        {
            ui.WriteLine($"Garagets nuvarande maxkapacitet är {CurrentGarage.MaxCapacity} fordon.");
            // Label and field to add capacity. Check for numbers only.
            CurrentGarage.UpdateMaxCapacity(5);
        }

        internal void CreateNewGarage() {
            Garage<Vehicle> newGarage = new Garage<Vehicle>("Garage II", 6);
            garages.Add(newGarage);
            CurrentGarage = newGarage;
            ui.WriteLine($"Det nya garaget {CurrentGarage.GarageName} har sparats och är nu det förvalda garaget.");
        }
    }
}
