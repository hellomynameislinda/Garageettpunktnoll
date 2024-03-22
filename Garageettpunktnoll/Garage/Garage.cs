using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class Garage<T>
    {
        public string GarageName { get; private set; }
        public int MaxCapacity { get; private set; }

        private T[] parkingSpaces;


        public Garage(string garageName, int maxCapacity)
        {
            GarageName = garageName;
            MaxCapacity = maxCapacity;

            parkingSpaces = new T[maxCapacity];
        }

        // Is garage full?

    }
}
