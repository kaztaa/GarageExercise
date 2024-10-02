﻿using GarageExercise.Interfaces;

namespace GarageExercise.Classes
{
    // Class UI implementing interface IUI
    public class UI : IUI
    {
        // Field with reference to garage containing type IVehicle 
        private readonly Garage<IVehicle> garage;

        // Constructor
        public UI(Garage<IVehicle> garage)
        {
            this.garage = garage;
        }
        
        // Starting the menu
        public void Start()
        {

            while (true)
            {
                
                Console.WriteLine("1. Park a vehicle");
                Console.WriteLine("2. Unpark a vehicle");
                Console.WriteLine("3. List parked vehicle(s)");
                //Console.WriteLine("4. Search for a vehicle");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ParkVehicle();
                        break;
                    case "2":
                        UnparkVehicle();
                        break;
                    case "3":
                        ListVehicles();
                        break;
                    case "4":
                         SearchVehicle();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the application...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


        // Method for parking a vehicle in the garage
        private void ParkVehicle()
        {
            Console.WriteLine("Which type of vehicle to park:");
            Console.WriteLine("1. Motorcycle");
            //Console.WriteLine("2. Car");
            //Console.WriteLine("3. Bus");
            //Console.WriteLine("4. Boat");
            //Console.WriteLine("5. Airplane"); 
            Console.Write("Enter your choice: ");

            string vehicleType = Console.ReadLine();
            Console.WriteLine();

            // Getting vehicle type
            switch (vehicleType)
            {
                case "1":
                    ParkVehicle(CreateMotorcycle());
                    break;
                case "2":
                //    AddVehicle(CreateCar());
                //    break;
                //case "3":
                //    AddVehicle(CreateBus());
                //    break;
                //case "4":
                //    AddVehicle(CreateBoat());
                //    break;
                //case "5":
                //    AddVehicle(CreateAirplane());
                //    break;


                default:
                    Console.WriteLine("Error. Wrong choice, try again.");
                    break;
            }

        }

        // Private method for parking vehicle. Passing the vehicle to be parked 
        private void ParkVehicle(IVehicle vehicleToPark)
        {
            // Checking if there is a vechile to park
            if (vehicleToPark != null)
            {
                garage.ParkVehicle(vehicleToPark);
                Console.WriteLine($"{vehicleToPark.Type} with Reg number {vehicleToPark.RegNumber} is parked.");
            }
            else
            {
                Console.WriteLine("Error. Failed to park vehicle.");
            }
        }

        // Show vehicle details
        private void ShoweDetails(IVehicle vehicle)
        {

        }

        // Method for unparking vechicle
        private void UnparkVehicle()
        {
            // string regNumber gets it's value from calling GetPropertyValue
            string regNumber = GetPropertyValue("Reg number of the vehicle to unpark");
            var vehicle = garage.Vehicles.FirstOrDefault(v => v.RegNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase));
            if (vehicle != null)
            {
                garage.UnparkVehicle(vehicle);
                Console.WriteLine($"Vehicle {regNumber} is unparked.");
            }
            else
            {
                Console.WriteLine($"Vehicle {regNumber} is not parked.");
            }
        }

        // Method for listing parked vehicles 
        private void ListVehicles()
        {
            // Counting parked vehicles
            int vehicleCount = garage.Vehicles.Count();
            Console.WriteLine($"Vehicles are parked: {vehicleCount}");
            
            foreach (var vehicle in garage.Vehicles)
            {
                Console.WriteLine($"Type: {vehicle.Type}\nReg number: {vehicle.RegNumber}\nColor: {vehicle.Color}\nNumber of wheels: {vehicle.WheelsNumber}");
                
                if (vehicle is Motorcycle motorcycle)
                    Console.WriteLine($"Cylinder Volume: {motorcycle.CylinderVolume}\nFuel type: {motorcycle.FuelType}");


                Console.WriteLine();
            }
        }
        private void SearchVehicle()
        {

        }
        private IVehicle CreateMotorcycle()
        {
            return new Motorcycle(
                GetPropertyValue("Reg number"),
                GetPropertyValue("Color"),
                GetNumericPropertyValue("Number of wheels"),
                GetNumericPropertyValue("Cylinder volume"),
                GetPropertyValue("Fuel type")
            );
        }
        //private IVehicle CreateCar()
        //{
         
        //}

        //private IVehicle CreateBus()
        //{
         
        //}

        //private IVehicle CreateAirplane()
        //{          
        //}


        //private IVehicle CreateBoat()
        //{
        //}


        // Dynamic methods for getting propery values from vehicles
        private string GetPropertyValue(string propertyName)
        {
            Console.Write($"Enter {propertyName}: ");
            return Console.ReadLine();
        }

        // For values of type int
        private int GetNumericPropertyValue(string propertyName)
        {
            Console.Write($"Enter {propertyName}: ");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Error. Enter correct int.");
                return -1; // Return a default value or an indicator of error
            }
        }

        // For values of type double
        private double GetDoublePropertyValue(string propertyName)
        {
            Console.Write($"Enter {propertyName}: ");
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Error. Enter correct double.");
                return -1; // Return a default value or an indicator of error
            }
        }

    }
}