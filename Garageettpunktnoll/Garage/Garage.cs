using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class Garage<T> where T : Vehicle
    {
        public string GarageName { get; private set; }
        public int MaxCapacity { get; private set; } // IFTIME: Expand this and throw exception if not between reasonable numbers

        internal T[] parkingSpaces;


        public Garage(string garageName, int maxCapacity)
        {
            GarageName = garageName;
            MaxCapacity = maxCapacity;

            parkingSpaces = new T[maxCapacity];
        }

        internal bool UpdateMaxCapacity(int maxCapacity)
        {
            // TODO: Not properly implemented, so far only used for testing.
            // IFTIME: Check if garage less cars than the new maxCapacity, if so, update maxCapacity. If not return false.
            // IFTIME: Also redo the actual array :)
            MaxCapacity = maxCapacity;

            return true;
        }

        internal bool IsFull()
        {
            return MaxCapacity == parkingSpaces.Count(p => p != null);
        }
        internal bool IsEmpty()
        {
            return parkingSpaces.Count(p => p != null) == 0;
        }
        internal bool RegistrationAvailable(string registrationNo)
        {
            return MaxCapacity == parkingSpaces.Count(p => p != null && p.RegistrationNumber.ToUpper() == registrationNo.ToUpper());
        }

    }
}
