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

        // Method for parking the vehicle
        public void ParkVehicle(T vehicle)
        {
            if (count < vehicles.Length)
            {
                vehicles[count++] = vehicle;
            }
            else
            {
                Console.WriteLine("The garage is full, can't park any more.");
            }
        }
        
        // Method for unpark the vehicle
        public void UnparkVehicle(T vehicle)
        {
          
        }

        // Implementing IEnumerable for iteration abilities 
        public IEnumerable<T> Vehicles => vehicles.Take(count);
    }


}