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
        private IConsoleUI ui;
        private GarageHandler garageHandler;

        private Menu menu;


        public ParkingManager(IConsoleUI ui, GarageHandler gh, Menu menu)
        {
            this.ui = ui;
            this.garageHandler = gh;
            this.menu = menu;
        }

        internal void Run()
        {
            do
            {
                ui.Clear();
                ui.WriteLine("Väkommen till ParkingManager\n");

                ui.WriteLine($"Du är i garaget {garageHandler.CurrentGarage.GarageName}\n");

                // Menu
                menu.DisplayMenu();
                menu.HandleChoice();

                ui.ReadAnything("Tryck enter för att komma tillbaka till menyn.");
            } while (true);
        }
    }
}
