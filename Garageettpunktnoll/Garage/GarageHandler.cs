using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class GarageHandler
    {
        private List<Garage<Vehicle>> garages = new List<Garage<Vehicle>>();
        public Garage<Vehicle> CurrentGarage { get; private set; }

        private readonly ConsoleUI ui;

        public GarageHandler(ConsoleUI ui)
        {
            this.ui = ui;
            // Using ONE hard coded instance of garage for now.
            // IFTIME: Add the ability to add more garages if there is enough time!
            garages.Add(new Garage<Vehicle>("Garag1", 12));
            CurrentGarage = garages.FirstOrDefault()!; // TODO: Check if null? Cannot be null until multiple garages are handled
            SeedVehicles();
        }
        internal void ChangeGarageCapacity()
        {
            ui.WriteLine($"Garagets nuvarande maxkapacitet före ändring är {CurrentGarage.MaxCapacity} fordon.");
            // Label and field to add capacity. Check for numbers only.
            CurrentGarage.UpdateMaxCapacity(5);
            ui.WriteLine($"Garagets nuvarande maxkapacitet efter ändring är {CurrentGarage.MaxCapacity} fordon.");
        }

        internal void CreateNewGarage()
        {
            string newGarageName;
            int newGarageCapacity = int.MinValue;

            newGarageName = ui.ReadString("Ange garagets namn: ");
            newGarageCapacity = ui.ReadInt("Ange antal parkeringsplatser:");

            Garage<Vehicle> newGarage = new Garage<Vehicle>(newGarageName, newGarageCapacity);
            garages.Add(newGarage);
            CurrentGarage = newGarage;
            ui.WriteLine($"Det nya garaget {CurrentGarage.GarageName} har sparats och är nu det förvalda garaget.");
            SeedVehicles();
        }
        internal void SeedGarages()
        {
            // TODO: Adapt to seeding and initiate seed.
            Garage<Vehicle> newGarage = new Garage<Vehicle>("Garage II", 6);
            garages.Add(newGarage);
            CurrentGarage = newGarage;
        }
        internal void SeedVehicles()
        {
            // IFTIME: Make it less hardcoded and use all types of vehicles!
            Vehicle newSeedVehicle;
            int i;
            for (i = 0; i < (CurrentGarage.parkingSpaces.Length / 2); i++) // Seed half of the parking spaces in current garage
            {
                int rndNumber;
                Random rnd = new Random();
                rndNumber = rnd.Next(1, 4);
                if (rndNumber == 1)
                {
                    newSeedVehicle = new Car
                    {
                        RegistrationNumber = $"ABC{i}{i}{i}",
                        Brand = "Volvo",
                        Color = "Green",
                        MaxSpeedKm = 252,
                        NumberOfWheels = 4,
                        NoOfDoors = 4
                    };
                    CurrentGarage.parkingSpaces[i] = newSeedVehicle;
                }
                else if (rndNumber == 2)
                {
                    newSeedVehicle = new Bus
                    {
                        RegistrationNumber = $"ABC{i}{i}{i}",
                        Brand = "Scania",
                        Color = "Red",
                        MaxSpeedKm = 252,
                        NumberOfWheels = 8,
                        MaxPassengers = 82
                    };
                    CurrentGarage.parkingSpaces[i] = newSeedVehicle;
                }
                else
                {
                    newSeedVehicle = new Motorcycle
                    {
                        RegistrationNumber = $"ABC{i}{i}{i}",
                        Brand = "Harley Davidson",
                        Color = "Black",
                        MaxSpeedKm = 300,
                        NumberOfWheels = 2,
                        HasSidecar = false
                    };
                    CurrentGarage.parkingSpaces[i] = newSeedVehicle;
                }
            }
            ui.WriteLine($"Garaget är seedat med {i} fordon.");
        }

        internal void DisplayAllVehicles()
        {
            foreach (var vehicle in CurrentGarage.parkingSpaces)
            {
                if (vehicle is not null) {
                    ui.WriteLine($"{vehicle.GetType().Name}\n{vehicle.GetAllProps()}\n");
                }
            }
        }
        internal void DisplayAllVehicleRegNos()
        {
            foreach (var vehicle in CurrentGarage.parkingSpaces)
            {
                if (vehicle is not null)
                {
                    ui.WriteLine($"{vehicle.RegistrationNumber}");
                }
            }
        }

        internal void RemoveVehicle()
        {
            string vehicleToRemove;
            ui.WriteLine("Följande bilar finns i garaget:");
            DisplayAllVehicleRegNos();
            vehicleToRemove = ui.ReadString("Ange registreringsnummer för den bil du vill ta bort:");
            ui.WriteLine(vehicleToRemove);

            // TODO: Make case insensitive
            var index = CurrentGarage.parkingSpaces
                .Select((vehicle, id) => new { Vehicle = vehicle, Index = id })
                .FirstOrDefault(ps => ps.Vehicle != null && ps.Vehicle.RegistrationNumber.ToLower() == vehicleToRemove.ToLower())?
                .Index ?? -1;

            ui.WriteLine("index" + index);

            if (index == -1) // -1 registration not found
            {
                ui.WriteLine($"{vehicleToRemove} verkar inte vara registrerad i garaget");
            }
            else
            {
                CurrentGarage.parkingSpaces[index] = null!; // Yes, we really want to use a null here!
            }
        }

        internal bool ParkVehicle()
        {
            if (CurrentGarage.IsFull())
            {
                // Leave if garage is empty
                ui.WriteLine("Garaget är fullt, du måste ta bort ett fordon innan du kan parkera ett nytt.");
                return false;
            }

            ConsoleKey vehicleType;
            // IFTIME: Can this list be automated?
            vehicleType = ui.ReadKey(
                "Välj typ av fordon, tryck:\nC för Bil\nB för Buss\nM för Motorcykel\nA för Flygplan\nO för Båt",
                key => key == ConsoleKey.C || key == ConsoleKey.B || key == ConsoleKey.M || key == ConsoleKey.A || key == ConsoleKey.O);


            // TODO: Insert code to add new vehicle! Based on type.
            string regNo = ui.ReadString("Ange registreringsnummer:");

            // Check if registration already exists in garage
            if (CurrentGarage.RegistrationAvailable(regNo))
            {
                ui.WriteLine("Det finns redan en bil i garaget med detta Registreringsnummer.");
                return false;
            }

            string brand = ui.ReadString("Ange märke:");
            string color = ui.ReadString("Ange färg:");
            int numberOfWheels = ui.ReadInt("Ange antal hjul:");
            int maxSpeedKm = ui.ReadInt("Ange maxhastighet i kilometer:");

//            switch (vehicleType)
//            {
//                case ConsoleKey.C:
//                    // Add Car
////                    NoOfDoors

//                    Car newCar = new Car();
//                    break;
//                case ConsoleKey.B:
//                    // Add Bus
//                    int MaxPassengers = ui.ReadInt("Ange max antal passagerare.");
//                    Bus newBus = new Bus();
//                    break;
//                case ConsoleKey.M:
//                    //Add Motorcycle
//                    Motorcycle newVehicle = new Motorcycle();

//                    break;
//                case ConsoleKey.A:
//                    //Add Airplane
//                    newVehicle = new Airplane();
//                    break;
//                case ConsoleKey.O:
//                    //Add Boat
//                    newVehicle = new Boat();
//                    break;
//            }


            //{
            //    RegistrationNumber = $"ABC{i}{i}{i}",
            //            Brand = "Volvo",
            //            Color = "Green",
            //            MaxSpeedKm = 252,
            //            NumberOfWheels = 4,
            //            NoOfDoors = 4
            //        };
            //CurrentGarage.parkingSpaces[i] = newVehicle;

            // Get first empty parking space
            var lowestIndex = Array.IndexOf(CurrentGarage.parkingSpaces, null);

            // TODO: Create new vehicle on lowestIndex.
            Console.WriteLine($"LowestIndex: {lowestIndex}");
            return true;
        }
    }
}
