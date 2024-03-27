using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Garageettpunktnoll
{
    internal class GarageHandler
    {
        private List<Garage<Vehicle>> garages = new List<Garage<Vehicle>>();
        public Garage<Vehicle> CurrentGarage { get; private set; }

        private readonly IConsoleUI ui;

        public GarageHandler(IConsoleUI ui)
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

            newGarageName = ui.ReadString("Ange garagets namn:");
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
            string[] colors = { "Black", "Blue", "Green", "Red", "White" };
            string[] brands = { "Harley-Davidson", "Ducati", "Honda", "Fiat", "Trabant", "Oldsmobile", "Volvo", "Saab" };
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Vehicle newSeedVehicle;
            int i;
            for (i = 0; i < (CurrentGarage.parkingSpaces.Length / 2); i++) // Seed half of the parking spaces in current garage
            {
                int rndNumber;
                Random rnd = new Random();
                rndNumber = rnd.Next(1, 4);
                string randomRegNo = $"{alpha.ElementAt(rnd.Next(1, 26))}{alpha.ElementAt(rnd.Next(1, 26))}{alpha.ElementAt(rnd.Next(1, 26))}{rnd.Next(0, 10)}{rnd.Next(0, 10)}{rnd.Next(0, 10)}";

                if (rndNumber == 1)
                {
                    newSeedVehicle = new Car($"{randomRegNo}", brands[rnd.Next(2, 8)], colors[rnd.Next(0,5)],4,rnd.Next(180, 251), rnd.Next(2, 6));
                }
                else if (rndNumber == 2)
                {
                    newSeedVehicle = new Bus($"{randomRegNo}", brands[rnd.Next(6, 8)], colors[rnd.Next(0, 5)], 8, rnd.Next(90, 181), rnd.Next(24, 121));
                }
                else
                {
                    newSeedVehicle = new Motorcycle($"{randomRegNo}", brands[rnd.Next(0, 3)], colors[rnd.Next(0, 5)], 2, rnd.Next(170, 236), false);
                }
                CurrentGarage.parkingSpaces[i] = newSeedVehicle;
            }
            ui.WriteLine($"Garaget är seedat med {i} fordon.");
        }

        internal void DisplayAllVehicles()
        {
            foreach (var vehicle in CurrentGarage.parkingSpaces)
            {
                if (vehicle is not null)
                {
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


            // Get first empty parking space
            var lowestIndex = Array.IndexOf(CurrentGarage.parkingSpaces, null);


            // TODO: Insert code to add new vehicle! Based on type.
            string regNo = ui.ReadString("Ange registreringsnummer:").ToUpper();

            // Check if registration already exists in garage
            if (!CurrentGarage.RegistrationAvailable(regNo))
            {
                ui.WriteLine("Det finns redan en bil i garaget med detta Registreringsnummer.");
                return false;
            }

            string brand = ui.ReadString("Ange märke:");
            string color = ui.ReadString("Ange färg:");
            int numberOfWheels = ui.ReadInt("Ange antal hjul:");
            int maxSpeedKm = ui.ReadInt("Ange maxhastighet i kilometer:");


            Vehicle newVehicle = null!;
            switch (vehicleType)
            {
                case ConsoleKey.C:
                    // Add Car
                    int noOfDoors = ui.ReadInt("Ange antal dörrar:");
                    newVehicle = new Car(regNo, brand, color, numberOfWheels, maxSpeedKm, noOfDoors);
                    break;
                case ConsoleKey.B:
                    // Add Bus
                    int maxPassengers = ui.ReadInt("Ange max antal passagerare:");
                    newVehicle = new Bus(regNo, brand, color, numberOfWheels, maxSpeedKm, maxPassengers);
                    break;
                case ConsoleKey.M:
                    //Add Motorcycle
                    bool hasSidecar = ui.ReadYesNo("Har motorcykeln sidovagn (y/n):");
                    newVehicle = new Motorcycle(regNo, brand, color, numberOfWheels, maxSpeedKm, hasSidecar);
                    break;
                case ConsoleKey.A:
                    //Add Airplane
                    maxPassengers = ui.ReadInt("Ange max antal passagerare:");
                    newVehicle = new Airplane(regNo, brand, color, numberOfWheels, maxSpeedKm, maxPassengers);
                    break;
                case ConsoleKey.O:
                    //Add Boat
                    string name = ui.ReadString("Ange båtens namn:");
                    newVehicle = new Boat(regNo, brand, color, numberOfWheels, maxSpeedKm, name);
                    break;
            }

            if (newVehicle == null)
            {
                // This should never happen, unless there is a code error, but just in case.
                ui.WriteLine("Unexpected error, the new vehicle is null and could not be saved.");
                return false;
            }
            CurrentGarage.parkingSpaces[lowestIndex] = newVehicle;

            return true;
        }

        internal void SearchVehicles()
        {
            string searchString = ui.ReadString("Ange de termer du vill söka på, separerade med mellanslag (t.ex. \"type:car color:röd\"\n" +
                "Tillgängliga filter: type, regNo, brand, color, noWheels, maxSpeed, noDoors, maxPass, sidecar, name):");
            string[] search = searchString.Split(' ');

            string type = null!;
            string regNo = null!;
            string brand = null!;
            string color = null!;
            int? noWheels = null;
            int? maxSpeed = null;
            int? noDoors = null;
            int? maxPass = null;
            bool? sidecar = null;
            string name = null!;

            foreach (string part in search)
            {
                string[] keyvalue = part.Split(':');

                // TODO: Remove leading and trailing spaces från both key and value
                switch (keyvalue[0].ToLower())
                {
                    case "type":
                        type = keyvalue[1].ToLower();
                        break;
                    case "regNo":
                        regNo = keyvalue[1].ToLower();
                        break;
                    case "brand":
                        brand = keyvalue[1].ToLower();
                        break;
                    case "color":
                        color = keyvalue[1].ToLower();
                        break;
                    case "noWheels":
                        noWheels = int.TryParse(keyvalue[1], out int parsedInt) ? parsedInt : null;
                        break;
                    case "maxSpeed":
                        maxSpeed = int.TryParse(keyvalue[1], out parsedInt) ? parsedInt : null;
                        break;
                    case "noDoors":
                        noDoors = int.TryParse(keyvalue[1], out parsedInt) ? parsedInt : null;
                        break;
                    case "maxPass":
                        maxPass = int.TryParse(keyvalue[1], out parsedInt) ? parsedInt : null;
                        break;
                    case "sidecar":
                        sidecar = Boolean.TryParse(keyvalue[1], out bool parsedBool) ? parsedBool : null;
                        break;
                    case "name":
                        name = keyvalue[1].ToLower();
                        break;
                }
            }

            IEnumerable<Vehicle> vehicles = CurrentGarage.parkingSpaces;

            if (!string.IsNullOrEmpty(type))
            {
                vehicles = vehicles.Where(v => v != null && v.GetType().Name.ToLower() == type);
            }
            if (!string.IsNullOrEmpty(regNo))
            {
                vehicles = vehicles.Where(v => v != null && v.RegistrationNumber.ToLower() == regNo);
            }
            if (!string.IsNullOrEmpty(brand))
            {
                vehicles = vehicles.Where(v => v != null && v.Brand.ToLower() == brand);
            }
            if (!string.IsNullOrEmpty(color))
            {
                vehicles = vehicles.Where(v => v != null && v.Color.ToLower() == color);
            }

            foreach (Vehicle vehicle in vehicles)
            {
                ui.WriteLine("Filtret ger följande fordon:");
                ui.WriteLine($"{vehicle.RegistrationNumber} som är en {vehicle.Color} {vehicle.Brand} {vehicle.GetType().Name}.");
            }

        }
    }
}
