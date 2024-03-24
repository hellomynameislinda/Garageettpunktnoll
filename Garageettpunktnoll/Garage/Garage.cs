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

        internal bool UpdateMaxCapacity(int maxCapacity)
        {
            // TODO: Check if garage less cars than the new maxCapacity, if so, update maxCapacity. If not return false.
            MaxCapacity = maxCapacity;
            return true;
        }

        // Is garage full?

    }
}
