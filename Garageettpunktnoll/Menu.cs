using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class Menu
    {
        private readonly ConsoleUI ui;
        private readonly GarageHandler garageHandler;

        public Menu(ConsoleUI ui, GarageHandler gh)
        {
            this.ui = ui;
            this.garageHandler = gh;
        }

        public void DisplayMenu()
        {
            ui.WriteLine("Välj vad du vill göra:");
            ui.WriteLine("V Visa fordon i valt garage");
            ui.WriteLineGray("P Parkera nytt fordon i valt garage");
            ui.WriteLineGray("T Ta bort fordon från valt garage");
            ui.WriteLineGray("S Sök efter fordon i valt garage");
            ui.WriteLineGray("M Ändra maxkapacitet för valt garage (ej implementerat)");
            ui.WriteLineGray("G Välj ett annat garage (ej implementerat)");
            ui.WriteLine("N Lägg till ett nytt garage");
            ui.WriteLine("Q. Avsluta\n");
        }

        internal void HandleChoice()
        {
            var input = ui.GetKey();
            switch (input)
            {
                case ConsoleKey.V:
                    //Display all vehicles in current garage
                    ui.WriteLine("Display all vehicles");
                    garageHandler.DisplayAllVehicles();
                    break;
                case ConsoleKey.P:
                    //Park a vehicle in current garage
                    ui.WriteLine("Park in garage");
                    break;
                case ConsoleKey.T:
                    //Remove vehicle from current garage
                    ui.WriteLine("Remove vehicle from garage");
                    break;
                case ConsoleKey.S:
                    //Search for vehicle
                    ui.WriteLine("Search for vehicles");
                    break;
                case ConsoleKey.M:
                    //Change current garage capacity
                    ui.WriteLineGray("Change garage capacity");
                    garageHandler.ChangeGarageCapacity();
                    break;
                case ConsoleKey.G:
                    //Switch to another garage
                    //NOTE: Do not implement for now
                    ui.WriteLine("Change to another garage");
                    break;
                case ConsoleKey.N:
                    //Add a new garage
                    ui.WriteLine("Add new garage");
                    garageHandler.CreateNewGarage();
                    break;
                case ConsoleKey.Q:
                    //Quit program
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
