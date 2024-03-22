using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class GarageHandler
    {
        private readonly ConsoleUI ui;

        public GarageHandler()
        {
            ui = new ConsoleUI();

        }
        internal void changeGarageCapacity()
        {
            ui.WriteLine($"The garage capacity is currently {}.");
            ui.WriteLine("This is the garage handler function changeGarageCapacity!");
        }

        internal Garage CreateNewGarage() {
            Garage newGarage = new Garage("Garage II", 6);

            return newGarage;
        }
    }
}
