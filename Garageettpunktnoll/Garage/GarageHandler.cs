﻿using System;
using System.Collections.Generic;
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
            for (i = 1; i < CurrentGarage.parkingSpaces.Length / 2; i++) // Seed half of the parking spaces in current garage
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
                        Brand = "Volvo",
                        Color = "Green",
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
                        Brand = "Volvo",
                        Color = "Green",
                        MaxSpeedKm = 252,
                        NumberOfWheels = 8,
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
                    ui.WriteLine($"{vehicle.RegistrationNumber}\n");
                }
            }
        }
    }
}
