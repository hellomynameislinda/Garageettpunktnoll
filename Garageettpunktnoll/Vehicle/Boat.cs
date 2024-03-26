using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class Boat : Vehicle
    {
        public string Name { get; set; }

        public Boat(string regNo, string brand, string color, int noOfWheels, int maxSpeedKm, string name) : base(regNo, brand, color, noOfWheels, maxSpeedKm)
        {
            Name = name;
        }
    }
}
