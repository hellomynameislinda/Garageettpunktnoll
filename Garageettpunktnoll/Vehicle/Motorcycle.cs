using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }

        public Motorcycle(string regNo, string brand, string color, int noOfWheels, int maxSpeedKm, bool hasSidecar) : base(regNo, brand, color, noOfWheels, maxSpeedKm)
        {
            HasSidecar = hasSidecar;
        }
    }
}
