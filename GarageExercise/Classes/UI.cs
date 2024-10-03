using GarageExercise.Interfaces;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

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
                Console.WriteLine("4. Search for a vehicle");
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
                        Console.WriteLine("Exiting...");
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
            Console.WriteLine("2. Car");
            Console.WriteLine("3. Bus");
            Console.WriteLine("4. Boat");
            Console.WriteLine("5. Airplane"); 
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
                    ParkVehicle(CreateCar());
                    break;
                case "3":
                    ParkVehicle(CreateBus());
                    break;
                case "4":
                    ParkVehicle(CreateBoat());
                    break;
                case "5":
                    ParkVehicle(CreateAirplane());
                    break;


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
                Console.WriteLine($"{vehicleToPark.Type} with Reg number {vehicleToPark.RegNumber} is parked.\n");
            }
            else
            {
                Console.WriteLine("Error. Failed to park vehicle.\n");
            }
        }

 

        // Method for unparking vechicle
        private void UnparkVehicle()
        {
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

        // Method for searchin vehicle
        private void SearchVehicle()
        {
            Console.WriteLine("Search, enter details or leave blank to skip:");


            Console.Write("Reg number: ");
            string regNumber = Console.ReadLine();

            Console.Write("Color:  ");
            string color = Console.ReadLine();

            Console.Write("Number of wheels: ");
            string wheelsNumberStr = Console.ReadLine();
            int? wheelsNumber = string.IsNullOrWhiteSpace(wheelsNumberStr) ? (int?)null : int.Parse(wheelsNumberStr);

            Console.Write("Type: ");
            string type = Console.ReadLine();

            var filteredVehicles = garage.Vehicles.Where(v =>
                (string.IsNullOrWhiteSpace(regNumber) || v.RegNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(color) || v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&
                (!wheelsNumber.HasValue || v.WheelsNumber == wheelsNumber.Value) &&
                (string.IsNullOrWhiteSpace(type) || v.Type.Equals(type, StringComparison.OrdinalIgnoreCase)));

            if (filteredVehicles.Any())
            {
                Console.WriteLine($"Found {filteredVehicles.Count()} matching vehicles:");
                Console.WriteLine("----------------------------------------------------");
                foreach (var vehicle in filteredVehicles)
                {
                    DisplayDetails(vehicle);
                }
            }
            else
            {
                Console.WriteLine("Could not find any matching vehicles.");
            }
        }


        // Method used by SearchVehicle to display details.
        private void DisplayDetails(IVehicle vehicle)
        {
            switch (vehicle)
            {
                case Car car:
                    Console.WriteLine($"Type: {car.Type} , Reg number: {car.RegNumber}");
                    break;
                case Bus bus:
                    Console.WriteLine($"Type: {bus.Type} , Reg number: {bus.RegNumber}");
                    break;
                case Airplane airplane:
                    Console.WriteLine($"Type: {airplane.Type} , Reg number: {airplane.RegNumber}");
                    break;
                case Boat boat:
                    Console.WriteLine($"Type: {boat.Type} , Reg number: {boat.RegNumber}");
                    break;
                case Motorcycle motorcycle:
                    Console.WriteLine($"Type: {motorcycle.Type} , Reg number: {motorcycle.RegNumber}");
                    break;
                default:
                    Console.WriteLine("Error. Wrong vehicle type.");
                    break;
            }
        }


        // Create vehicles using IVehicle interface.
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
        
        private IVehicle CreateBoat()
        {
            return new Boat(
                GetPropertyValue("Reg number"),
                GetPropertyValue("Color"),
                GetNumericPropertyValue("Number of wheels"),
                GetNumericPropertyValue("Number of engines"),
                GetPropertyValue("Fuel type"),
                GetDoublePropertyValue("Length")
            );


        }

        private IVehicle CreateCar()
        {
            
            Car car = new Car(
                GetPropertyValue("Reg number"),
                GetPropertyValue("Color"),
                GetNumericPropertyValue("Number of wheels"),
                GetNumericPropertyValue("Cylinder volume"),
                GetPropertyValue("Fuel type")
            );
            return car;
        }

        private IVehicle CreateBus()
        {
            return new Bus(
                GetPropertyValue("Reg number"),
                GetPropertyValue("Color"),
                GetNumericPropertyValue("Number of wheels"),
                GetNumericPropertyValue("Number of seats"),
                GetPropertyValue("Fuel type")

            );

        }

        private IVehicle CreateAirplane()
        {
            return new Airplane(
                GetPropertyValue("Reg number"),
                GetPropertyValue("Color"),
                GetNumericPropertyValue("Number of wheels"),
                GetNumericPropertyValue("Number of engines"),
                GetNumericPropertyValue("Cylinder volume"),
                GetPropertyValue("Fuel type")
                );
        }





        // Dynamic methods for getting propery values from vehicles

        // For properties of type string
        private string GetPropertyValue(string propertyName)
        {

            // Reg number check
            if (propertyName == "Reg number")
            {
                Console.Write($"Enter {propertyName}: ");
                string regNumToVerify = Console.ReadLine();
                bool notVerified = false;

                while (!notVerified)
                {
                    if (!Regex.IsMatch(regNumToVerify, @"^[a-zA-Z]{3}\d{3}$"))
                    {
                        Console.Write($"Enter {propertyName} (abc123/ABC123 format): ");
                        regNumToVerify = Console.ReadLine();
                    }
                    notVerified = true;
                }
                return regNumToVerify;
            }
            else
            {
                Console.Write($"Enter {propertyName}: ");
                return Console.ReadLine();
            }
        }


        // For properties of type int
        private int GetNumericPropertyValue(string propertyName)
        {
            Console.Write($"Enter {propertyName}: ");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Error. Enter a positive number.");
                return -1; // Return a default value or an indicator of error
            }
        }

        // For properties of type double
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