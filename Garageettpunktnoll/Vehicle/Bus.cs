using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class Bus : Vehicle
    {
        public int MaxPassengers { get; set; }

        public Bus(string regNo, string brand, string color, int noOfWheels, int maxSpeedKm, int maxPassengers) : base(regNo, brand, color, noOfWheels, maxSpeedKm)
        {
            MaxPassengers = maxPassengers;
        }
    }
}
