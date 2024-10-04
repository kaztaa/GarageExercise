using GarageExercise.Classes;
using GarageExercise.Interfaces;

namespace GarageExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initializing with standard garage with 10 spots
            var garage = new Garage<IVehicle>(10);
            var garageHandler = new GarageHandler(garage, null); // GarageHandler is first created
            var ui = new UI(garageHandler); // Sending the instance of GarageHandler garageHandler to UI
            garageHandler = new GarageHandler(garage, ui); // Uppdate garageHandler with garage and ui

            var manager = new Manager(ui, garageHandler);
            manager.Start();
        }
    }
}
