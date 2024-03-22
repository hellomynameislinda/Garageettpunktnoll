﻿using System;
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

        public Menu()
        {
            ui = new ConsoleUI();
            garageHandler = new GarageHandler();
        }

        public void DisplayMenu()
        {
            ui.WriteLine("Välj vad du vill göra:");
            ui.WriteLineGray("V Visa fordon i valt garage");
            ui.WriteLineGray("P Parkera nytt fordon i valt garage");
            ui.WriteLineGray("T Ta bort fordon från valt garage");
            ui.WriteLineGray("S Sök efter fordon i valt garage");
            ui.WriteLine("M Ändra maxkapacitet för valt garage");
            ui.WriteLineGray("G Välj ett annat garage (ej implementerat)");
            ui.WriteLineGray("N Lägg till ett nytt garage");
            ui.WriteLineGray("Q. Avsluta");
        }

        internal void HandleChoice()
        {
            var input = ui.GetKey();
            switch (input)
            {
                case ConsoleKey.V:
                    //Display all vehicles in current garage
                    ui.WriteLine("Display all vehicles");
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
                    ui.WriteLine("Change garage capacity");
                    garageHandler.changeGarageCapacity();
                    break;
                case ConsoleKey.G:
                    //Switch to another garage
                    ui.WriteLine("Change to another garage");
                    break;
                case ConsoleKey.N:
                    //Add a new garage
                    ui.WriteLine("Add new garage");
                    break;
                case ConsoleKey.Q:
                    //Quit program
                    ui.WriteLine("Quit program");
                    break;
            }
        }
    }
}