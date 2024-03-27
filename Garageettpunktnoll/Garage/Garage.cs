using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Garageettpunktnoll.MSTest")]

namespace Garageettpunktnoll
{
    internal class Garage<T> where T : Vehicle
    {
        public string GarageName { get; private set; }
        public int MaxCapacity { get; private set; } // IFTIME: Expand this and throw exception if not between reasonable numbers

        public T[] parkingSpaces;


        public Garage(string garageName, int maxCapacity)
        {
            GarageName = garageName;
            MaxCapacity = maxCapacity;

            parkingSpaces = new T[maxCapacity];
        }

        public bool UpdateMaxCapacity(int maxCapacity)
        {
            // TODO: Not properly implemented, so far only used for testing.
            // IFTIME: Check if garage less cars than the new maxCapacity, if so, update maxCapacity. If not return false.
            // IFTIME: Also redo the actual array :)
            MaxCapacity = maxCapacity;

            return true;
        }

        public bool IsFull()
        {
            return MaxCapacity == parkingSpaces.Count(p => p != null);
        }
        public bool IsEmpty()
        {
            return parkingSpaces.Count(p => p != null) == 0;
        }
        public bool RegistrationAvailable(string registrationNo) // TODO: Something goes 
        {
            return (parkingSpaces.Count(p => p != null && p.RegistrationNumber.ToUpper() == registrationNo.ToUpper())) > 0 ? false : true;
        }

    }
}
