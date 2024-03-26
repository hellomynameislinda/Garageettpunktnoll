using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal abstract class Vehicle
    {
        //// Identifiers for the class
        //public static string TypeName { get; internal set; } = "Fordon";
        //public static ConsoleKey TypeKey { get; internal set; } = ConsoleKey.V;

        public string RegistrationNumber { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public int MaxSpeedKm { get; set; }

        protected Vehicle(string regNo, string brand, string color, int noOfWheels, int maxSpeedKm)
        {
            RegistrationNumber = regNo;
            Brand = brand;
            Color = color;
            NumberOfWheels = noOfWheels;
            MaxSpeedKm = maxSpeedKm;
        }

        public string GetAllProps()
        {
            // These come in the order of declaration in subclass first and then base class
            // IFTIME: Make a nicer output in correct order and with translated names.
            string allProps = string.Empty;

            foreach (var prop in this.GetType().GetProperties())
            {
                allProps += $"{prop.Name}: {prop.GetValue(this)}\n";
            }

            return allProps;
        }
    }
}
