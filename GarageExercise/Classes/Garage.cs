using GarageExercise.Interfaces;

namespace GarageExercise.Classes
{

    // Generic class Garage containing array of IVehicles
    public class Garage<T> : IGarage<T> where T : IVehicle
    {
        // Array with capacity of 10
        private T[] vehicles = new T[10];

        // Number of vehicles parked
        private int count = 0;

        public Garage(int capacity)
        {
            vehicles = new T[capacity];
            count = 0;
        }

        // Method for parking the vehicle - adding the vehicle object to vehicles the garage-array
        public void ParkVehicle(T vehicle)
        {
            if (count < vehicles.Length)
            {
                vehicles[count++] = vehicle;
            }
            else
            {
                Console.WriteLine("Sorry, the garage is full.");
            }
        }
        
        // Method for unpark the vehicle - removing vehicle from array 
        public void UnparkVehicle(T vehicle)
        {
            // Get index for vehicle in the array
            int index = Array.IndexOf(vehicles, vehicle);
            if (index >= 0)
            {
                // Shift the vehicles after index to fill upp empty space 
                Array.Copy(vehicles, index + 1, vehicles, index, count - index - 1);
                vehicles[count - 1] = default;// Set the last element which is empty to default value (null for reference types)
                count--;
                Console.WriteLine($"Parked vehicles: {count}");
            }
            else
            {
                Console.WriteLine($"Vehicle {vehicle.RegNumber} is not parked.");
            }
        }
   

    // Implementing IEnumerable for iteration abilities 
    public IEnumerable<T> Vehicles => vehicles.Take(count);
    }


}