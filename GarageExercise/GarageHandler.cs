using GarageExercise.Classes;
using GarageExercise.Interfaces;

namespace GarageExercise
{
    // Garage handler
    public class GarageHandler
    {
        private Garage<IVehicle> garage;
        private IUI uI;

        // Constructor
        public GarageHandler(Garage<IVehicle> garage, IUI ui)
        {
            this.garage = garage ?? new Garage<IVehicle>(10);
            this.uI = ui;
        }


        public int GetParkedVehiclesCount()
        {
            return garage.Vehicles.Count();
        }

        // Returning garage capacity
        public int GetCapacity()
        {
            return garage.Capacity;
        }

        public IEnumerable<IVehicle> GetVehicles()
        {
            return garage.Vehicles;
        }

        public void UnparkVehicle(IVehicle vehicle)
        {
            garage.UnparkVehicle(vehicle);
        }

        public void ParkVehicle(IVehicle vehicle)
        {
            garage.ParkVehicle(vehicle);
        }

        public void CreateNewGarage(int garageCapacity)
        {
            garage = new Garage<IVehicle>(garageCapacity);
            Console.WriteLine($"A new garage with {garageCapacity} spots has been created.");
        }

        public void Start()
        {
            uI.Start();
        }
    }
}