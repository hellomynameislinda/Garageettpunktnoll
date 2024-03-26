using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class Car : Vehicle
    {
        public int NoOfDoors { get; set; }

        public Car(string regNo, string brand, string color, int noOfWheels, int maxSpeedKm, int noOfDoors) : base(regNo, brand, color, noOfWheels, maxSpeedKm)
        {
            NoOfDoors = noOfDoors;
        }
    }
}
