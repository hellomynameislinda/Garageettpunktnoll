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
        private ConsoleUI ui;
        private GarageHandler garageHandler;

        private Menu menu;


        public ParkingManager(ConsoleUI ui, GarageHandler gh, Menu menu)
        {
            this.ui = ui;
            this.garageHandler = gh;
            this.menu = menu;
        }

        internal void Run()
        {
            do
            {

                ui.WriteLine("Väkommen till ParkingManager\n");

                ui.WriteLine($"Du är i garaget {garageHandler.CurrentGarage.GarageName}\n");

                // Menu
                menu.DisplayMenu();
                menu.HandleChoice();

                // TODO: Add a log of sorts.
            } while (true);
        }
    }
}
